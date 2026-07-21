import { RedisKeys } from "../constants";
import { isRedisAvailable, redisDel, redisEval, redisSet } from "../redis";
import logger from "../utils/logger";

const heartbeatTtlSeconds = 30;
const heartbeatIntervalMs = 10_000;
const observeHeartbeatScript = `
local value = redis.call('GET', KEYS[1])
if not value then
  return {0, '', -2}
end
return {1, value, redis.call('PTTL', KEYS[1])}
`;

export interface PvpCoordinatorHeartbeat {
  stop: () => Promise<void>;
}

/** A Redis-selected node must publish its owner lease before it can create durable match rows. */
export function requireInitialPvpCoordinatorHeartbeat(written: boolean): void {
  if (!written) throw new Error("Initial PvP coordinator heartbeat could not be established.");
}

/**
 * Interpret one atomic owner/PTTL observation. Only the exact coordinator identity with the
 * bounded remaining lease proves a live node. Corrupt or non-expiring keys remain unknown so
 * orphan recovery cannot cancel or preserve matches based on JavaScript truthiness alone.
 */
export function parsePvpCoordinatorLivenessObservation(
  result: unknown,
  instanceId: string,
): boolean | null {
  if (!Array.isArray(result) || result.length !== 3) return null;
  const present = Number(result[0]);
  const value = result[1];
  const ttlMilliseconds = Number(result[2]);
  if (present === 0) return value === "" && ttlMilliseconds === -2 ? false : null;
  if (present !== 1
    || value !== instanceId
    || !Number.isInteger(ttlMilliseconds)
    || ttlMilliseconds < 1
    || ttlMilliseconds > heartbeatTtlSeconds * 1_000) return null;
  return true;
}

/**
 * Advertise this node's transient PvP ownership with a renewable, crash-expiring key. Match rows
 * keep the coordinator UUID, allowing startup recovery to distinguish a real orphan from a live
 * room owned by another backend process during rolling deployments.
 */
export async function startPvpCoordinatorHeartbeat(instanceId: string): Promise<PvpCoordinatorHeartbeat> {
  if (!isRedisAvailable()) return { stop: async () => undefined };
  const key = RedisKeys.pvpCoordinator(instanceId);
  const renew = async (): Promise<boolean> => {
    const written = await redisSet(key, instanceId, heartbeatTtlSeconds);
    if (!written) logger.match.error("PvP coordinator heartbeat failed", { instanceId });
    return written;
  };
  // Match rows immediately persist this instance ID as their transient room/timer owner. Starting
  // the server without the first lease would let a healthy peer classify those new matches as
  // orphaned before this node had ever proved ownership. Runtime renewal failures remain logged;
  // Redis reads become unknown during an outage and the recovery path conservatively waits.
  requireInitialPvpCoordinatorHeartbeat(await renew());
  const timer = setInterval(() => void renew(), heartbeatIntervalMs);
  timer.unref();
  return {
    stop: async () => {
      clearInterval(timer);
      await redisDel(key);
    },
  };
}

/** Redis is a liveness oracle only; MongoDB remains authoritative for match state and ownership. */
export async function isPvpCoordinatorAlive(instanceId: string): Promise<boolean | null> {
  if (!isRedisAvailable()) return null;
  const result = await redisEval(observeHeartbeatScript, [RedisKeys.pvpCoordinator(instanceId)], []);
  return parsePvpCoordinatorLivenessObservation(result, instanceId);
}
