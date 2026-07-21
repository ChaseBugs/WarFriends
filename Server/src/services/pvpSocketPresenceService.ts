import { RedisKeys } from "../constants";
import { isRedisAvailable, redisEval, redisGet, redisSet } from "../redis";

const socketPresenceTtlSeconds = 30;
export const socketPresenceHeartbeatMs = 10_000;

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
  const value = await redisGet(RedisKeys.socketOfPlayer(playerId));
  if (value === undefined) return null;
  return value !== null;
}
