import { RedisKeys } from "../constants";
import { isRedisAvailable, redisDel, redisGet, redisSet } from "../redis";
import logger from "../utils/logger";

const heartbeatTtlSeconds = 30;
const heartbeatIntervalMs = 10_000;

export interface PvpCoordinatorHeartbeat {
  stop: () => Promise<void>;
}

/**
 * Advertise this node's transient PvP ownership with a renewable, crash-expiring key. Match rows
 * keep the coordinator UUID, allowing startup recovery to distinguish a real orphan from a live
 * room owned by another backend process during rolling deployments.
 */
export async function startPvpCoordinatorHeartbeat(instanceId: string): Promise<PvpCoordinatorHeartbeat> {
  if (!isRedisAvailable()) return { stop: async () => undefined };
  const key = RedisKeys.pvpCoordinator(instanceId);
  const renew = async (): Promise<void> => {
    const written = await redisSet(key, instanceId, heartbeatTtlSeconds);
    if (!written) logger.match.error("PvP coordinator heartbeat failed", { instanceId });
  };
  await renew();
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
  const value = await redisGet(RedisKeys.pvpCoordinator(instanceId));
  // `null` is an authoritative missing key; `undefined` means Redis could not answer. Recovery is
  // conservative on an unknown observation so a transient outage never cancels a healthy match.
  if (value === undefined) return null;
  return value === instanceId;
}
