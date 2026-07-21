import { RedisKeys } from "../constants";
import { isRedisAvailable, redisEval, redisGet, redisSet } from "../redis";

const socketPresenceTtlSeconds = 30;
export const socketPresenceHeartbeatMs = 10_000;
const UUID_PAIR_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}:[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/;

const compareExpireScript = `
if redis.call('GET', KEYS[1]) == ARGV[1] then
  return redis.call('EXPIRE', KEYS[1], ARGV[2])
end
return 0
`;

const compareDeleteScript = `
if redis.call('GET', KEYS[1]) == ARGV[1] then
  return redis.call('DEL', KEYS[1])
end
return 0
`;

const observePresenceScript = `
local value = redis.call('GET', KEYS[1])
if not value then
  return {0, '', -2}
end
return {1, value, redis.call('PTTL', KEYS[1])}
`;

export function pvpSocketOwner(instanceId: string, clientId: string): string {
  return `${instanceId}:${clientId}`;
}

/** One transport can own only one authenticated account; account switching requires reconnect. */
export function isUnidentifiedPvpSocket(playerId: string | undefined): boolean {
  return playerId === undefined;
}

/**
 * Claim the player's current distributed socket; a newer Identify replaces the older owner.
 *
 * `null` is the deliberate no-Redis/local-room mode. `false` is materially different: Redis was
 * selected as the coordinator but the ownership write failed, so the caller must not pretend that
 * this socket has a renewable cross-node route.
 */
export async function claimPvpSocket(playerId: string, owner: string): Promise<boolean | null> {
  if (!isRedisAvailable()) return null;
  return redisSet(RedisKeys.socketOfPlayer(playerId), owner, socketPresenceTtlSeconds);
}

/** Convert the tri-state write result into the room mode, rejecting an uncertain failed claim. */
export function usesDistributedPvpSocket(claimed: boolean | null): boolean {
  if (claimed === false) {
    throw new Error("Distributed PvP socket ownership could not be established.");
  }
  return claimed === true;
}

/**
 * Interpret one atomic Redis GET/PTTL observation. A malformed value or missing expiry is unknown,
 * never connected: only this process's exact UUID-pair owner written with the bounded lease can
 * authorize a disconnect forfeit. Unknown observations make the caller wait for operator cleanup
 * or a later valid/expired observation rather than manufacturing a reward.
 */
export function parsePvpSocketLivenessObservation(result: unknown): boolean | null {
  if (!Array.isArray(result) || result.length !== 3) return null;
  const present = Number(result[0]);
  const value = result[1];
  const ttlMilliseconds = Number(result[2]);
  if (present === 0) {
    return value === "" && ttlMilliseconds === -2 ? false : null;
  }
  if (present !== 1
    || typeof value !== "string"
    || !UUID_PAIR_PATTERN.test(value)
    || !Number.isInteger(ttlMilliseconds)
    || ttlMilliseconds < 1
    || ttlMilliseconds > socketPresenceTtlSeconds * 1_000) return null;
  return true;
}

/** Refresh only if this exact socket still owns the player route. */
export async function refreshPvpSocket(playerId: string, owner: string): Promise<boolean | null> {
  const result = await redisEval(
    compareExpireScript,
    [RedisKeys.socketOfPlayer(playerId)],
    [owner, socketPresenceTtlSeconds],
  );
  if (result === undefined) return null;
  return Number(result) === 1;
}

/** Delete only this socket's route so an old close cannot remove a replacement login. */
export async function releasePvpSocket(playerId: string, owner: string): Promise<boolean | null> {
  const result = await redisEval(compareDeleteScript, [RedisKeys.socketOfPlayer(playerId)], [owner]);
  if (result === undefined) return null;
  if (Number(result) === 1) return true;
  const current = await redisGet(RedisKeys.socketOfPlayer(playerId));
  if (current === undefined) return null;
  // A missing key means this exact socket's TTL expired before close cleanup; it is still a real
  // offline transition. A different value belongs to a replacement socket and must be preserved.
  return current === null;
}

/** True/false is authoritative; null means Redis could not answer and forfeiture must wait. */
export async function isPvpPlayerConnected(playerId: string): Promise<boolean | null> {
  const result = await redisEval(observePresenceScript, [RedisKeys.socketOfPlayer(playerId)], []);
  return parsePvpSocketLivenessObservation(result);
}

/**
 * Combine one complete set of participant-route observations without converting uncertainty into
 * authority. A definite missing route is enough to prove that the pair is not currently live;
 * otherwise any malformed/unavailable observation keeps the result unknown.
 */
export function combinePvpParticipantLiveness(
  observations: readonly (boolean | null)[],
): boolean | null {
  if (observations.length === 0) return null;
  if (observations.some((observation) => observation === false)) return false;
  if (observations.some((observation) => observation === null)) return null;
  return true;
}

/**
 * Prove that every assigned participant still owns an expiring Redis socket route immediately
 * before MatchStart fan-out. Durable joinedPlayerIds records admission attempts, not current
 * transport presence, so it cannot by itself authorize gameplay after a pre-start disconnect.
 */
export async function arePvpParticipantsConnected(
  playerIds: readonly string[],
): Promise<boolean | null> {
  const uniquePlayerIds = [...new Set(playerIds)];
  if (uniquePlayerIds.length !== 2 || uniquePlayerIds.length !== playerIds.length) return null;
  return combinePvpParticipantLiveness(
    await Promise.all(uniquePlayerIds.map((playerId) => isPvpPlayerConnected(playerId))),
  );
}
