import logger from "../utils/logger";
import { RedisKeys } from "../constants";
import { isRedisAvailable, redisEval } from "../redis";
import { config } from "../config";

// Matchmaking — pairs two waiting players for a PvP match (BACKEND.md §3). Pairing favours
// the closest opponent by army power within a widening league window, matching the client's
// MatchMakingConstants/MatchMakingDeviation tuning intent.
//
// The in-memory queue remains the deliberate no-Redis fallback. When Redis is available, the hub
// uses atomic wrappers so players connected to different backend nodes share one queue.

export interface QueueEntry {
  playerId: string;
  armyPower: number;
  leagueTier: number;
  enqueuedAt: number;
}

const queue: QueueEntry[] = [];

/** How far apart two players' league tiers may be; widens with wait time. */
function leagueWindow(waitedMs: number): number {
  return 1 + Math.floor(waitedMs / 10_000); // +1 tier of tolerance per 10s waited
}

function bestOpponent(entry: QueueEntry, now: number): number {
  let bestIndex = -1;
  let bestScore = Number.POSITIVE_INFINITY;
  for (let i = 0; i < queue.length; i++) {
    const candidate = queue[i]!;
    if (candidate.playerId === entry.playerId) continue;
    const window = Math.max(leagueWindow(now - candidate.enqueuedAt), leagueWindow(now - entry.enqueuedAt));
    if (Math.abs(candidate.leagueTier - entry.leagueTier) > window) continue;
    const score = Math.abs(candidate.armyPower - entry.armyPower);
    if (score < bestScore) {
      bestScore = score;
      bestIndex = i;
    }
  }
  return bestIndex;
}

/**
 * Enqueue a player. If a suitable opponent is already waiting, both are removed and the
 * opponent's id is returned (the caller creates the match). Otherwise returns null (queued).
 */
export function enqueue(entry: Omit<QueueEntry, "enqueuedAt">): string | null {
  remove(entry.playerId); // dedupe re-queues
  const full: QueueEntry = { ...entry, enqueuedAt: Date.now() };
  const opponentIndex = bestOpponent(full, full.enqueuedAt);
  if (opponentIndex >= 0) {
    const opponent = queue.splice(opponentIndex, 1)[0]!;
    logger.match.event("Matchmaking paired", { a: full.playerId, b: opponent.playerId });
    return opponent.playerId;
  }
  queue.push(full);
  logger.match.event("Matchmaking queued", { playerId: full.playerId, size: queue.length });
  return null;
}

export function remove(playerId: string): boolean {
  const index = queue.findIndex((e) => e.playerId === playerId);
  if (index < 0) return false;
  queue.splice(index, 1);
  return true;
}

/**
 * Restore players removed by a pairing whose durable admission failed.
 *
 * This intentionally does not run opponent selection while inserting the batch. Calling
 * `enqueue` twice would immediately pair the same two players again and discard its returned ID,
 * losing both entries. Their next FindMatch request (or another player's request) performs the
 * ordinary selection, while normal queue timers continue to bound the restored wait.
 */
export function restoreWaiting(entries: ReadonlyArray<Omit<QueueEntry, "enqueuedAt">>, now = Date.now()): number {
  const unique = [...new Map(entries.map((entry) => [entry.playerId, entry])).values()];
  for (const entry of unique) remove(entry.playerId);
  for (const entry of unique) queue.push({ ...entry, enqueuedAt: now });
  if (unique.length > 0) {
    logger.match.event("Matchmaking entries restored after admission failure", {
      playerIds: unique.map((entry) => entry.playerId),
      size: queue.length,
    });
  }
  return unique.length;
}

export function queueSize(): number {
  return queue.length;
}

// One Lua invocation owns deduplication, opponent selection, and removal. Splitting these into
// separate Redis commands permits two nodes to select the same waiting player concurrently. The
// sorted set stores enqueue time for widening/tie-breaking, while the hash stores bounded snapshots.
const enqueueScript = `
local queueKey = KEYS[1]
local entriesKey = KEYS[2]
local playerId = ARGV[1]
local armyPower = tonumber(ARGV[2])
local leagueTier = tonumber(ARGV[3])
local now = tonumber(ARGV[4])
local encoded = ARGV[5]
local maximumCandidates = tonumber(ARGV[6])
local staleBefore = tonumber(ARGV[7])
local stale = redis.call('ZRANGEBYSCORE', queueKey, '-inf', staleBefore, 'LIMIT', 0, maximumCandidates)
if #stale > 0 then
  for _, staleId in ipairs(stale) do
    redis.call('ZREM', queueKey, staleId)
    redis.call('HDEL', entriesKey, staleId)
  end
end
redis.call('ZREM', queueKey, playerId)
redis.call('HSET', entriesKey, playerId, encoded)
local waiting = redis.call('ZRANGE', queueKey, 0, maximumCandidates - 1, 'WITHSCORES')
local bestId = nil
local bestPower = nil
local bestTime = nil
for index = 1, #waiting, 2 do
  local candidateId = waiting[index]
  local enqueuedAt = tonumber(waiting[index + 1])
  local candidateJson = redis.call('HGET', entriesKey, candidateId)
  if not candidateJson then
    redis.call('ZREM', queueKey, candidateId)
  else
    local candidate = cjson.decode(candidateJson)
    local candidateWindow = 1 + math.floor(math.max(0, now - enqueuedAt) / 10000)
    if math.abs(tonumber(candidate.leagueTier) - leagueTier) <= candidateWindow then
      local powerDifference = math.abs(tonumber(candidate.armyPower) - armyPower)
      if not bestId or powerDifference < bestPower
        or (powerDifference == bestPower and enqueuedAt < bestTime)
        or (powerDifference == bestPower and enqueuedAt == bestTime and candidateId < bestId) then
        bestId = candidateId
        bestPower = powerDifference
        bestTime = enqueuedAt
      end
    end
  end
end
if bestId then
  local opponent = redis.call('HGET', entriesKey, bestId)
  redis.call('ZREM', queueKey, bestId)
  redis.call('HDEL', entriesKey, bestId, playerId)
  return opponent
end
redis.call('ZADD', queueKey, now, playerId)
return nil
`;

const removeScript = `
local removed = redis.call('ZREM', KEYS[1], ARGV[1])
redis.call('HDEL', KEYS[2], ARGV[1])
return removed
`;

const restoreScript = `
local entries = cjson.decode(ARGV[1])
local now = tonumber(ARGV[2])
for _, entry in ipairs(entries) do
  redis.call('ZREM', KEYS[1], entry.playerId)
  redis.call('HSET', KEYS[2], entry.playerId, cjson.encode(entry))
end
for _, entry in ipairs(entries) do
  redis.call('ZADD', KEYS[1], now, entry.playerId)
end
return #entries
`;

export function validQueueEntry(value: unknown): value is QueueEntry {
  if (!value || typeof value !== "object") return false;
  const entry = value as Partial<QueueEntry>;
  return typeof entry.playerId === "string"
    && entry.playerId.length > 0
    && entry.playerId.length <= 128
    && Number.isFinite(entry.armyPower)
    && Number(entry.armyPower) >= 0
    && Number.isInteger(entry.leagueTier)
    && Number(entry.leagueTier) >= 0
    && Number(entry.leagueTier) <= 100
    && Number.isFinite(entry.enqueuedAt)
    && Number(entry.enqueuedAt) > 0;
}

/** Build the complete Redis hash payload; restored snapshots must retain a valid enqueue clock. */
export function buildRestoredQueueEntries(
  entries: ReadonlyArray<Omit<QueueEntry, "enqueuedAt">>,
  now: number,
): QueueEntry[] {
  return [...new Map(entries.map((entry) => [entry.playerId, entry])).values()]
    .map((entry) => ({ ...entry, enqueuedAt: now }));
}

/**
 * Pair through Redis when it is healthy, otherwise preserve the verified single-node queue.
 * The returned opponent is only a candidate; createMatch still re-reads MongoDB snapshots and
 * transactionally reserves both accounts before a durable match exists.
 */
export async function enqueueForHub(entry: Omit<QueueEntry, "enqueuedAt">): Promise<string | null> {
  if (!isRedisAvailable()) return enqueue(entry);
  const now = Date.now();
  const encoded = JSON.stringify({ ...entry, enqueuedAt: now });
  const result = await redisEval(
    enqueueScript,
    [RedisKeys.matchmakingQueue, RedisKeys.matchmakingEntries],
    [
      entry.playerId,
      entry.armyPower,
      entry.leagueTier,
      now,
      encoded,
      500,
      // Give the owning node's ordinary timer a full extra window to remove and notify its player
      // before another node treats the entry as abandoned after a crash or prolonged pause.
      now - Math.max(1, config.matchmakingTimeout) * 2000,
    ],
  );
  if (result === undefined) throw new Error("Distributed matchmaking coordination is unavailable.");
  if (typeof result !== "string") return null;
  try {
    const opponent = JSON.parse(result) as unknown;
    if (!validQueueEntry(opponent) || opponent.playerId === entry.playerId) return null;
    logger.match.event("Distributed matchmaking paired", { a: entry.playerId, b: opponent.playerId });
    return opponent.playerId;
  } catch {
    return null;
  }
}

/** Remove a search from the coordination backend that admitted it. */
export async function removeForHub(playerId: string): Promise<boolean> {
  // Always clear fallback state as well. Redis may recover between an in-memory enqueue and this
  // removal, and leaving that old local row would allow a timed-out socket to be paired later.
  const removedLocally = remove(playerId);
  if (!isRedisAvailable()) return removedLocally;
  const result = await redisEval(
    removeScript,
    [RedisKeys.matchmakingQueue, RedisKeys.matchmakingEntries],
    [playerId],
  );
  if (result === undefined) return removedLocally;
  return Number(result) > 0 || removedLocally;
}

/** Restore a failed admission batch atomically without immediately pairing its two members. */
export async function restoreWaitingForHub(
  entries: ReadonlyArray<Omit<QueueEntry, "enqueuedAt">>,
  now = Date.now(),
): Promise<number> {
  const unique = [...new Map(entries.map((entry) => [entry.playerId, entry])).values()];
  if (!isRedisAvailable()) return restoreWaiting(unique, now);
  const distributedEntries = buildRestoredQueueEntries(unique, now);
  const result = await redisEval(
    restoreScript,
    [RedisKeys.matchmakingQueue, RedisKeys.matchmakingEntries],
    [JSON.stringify(distributedEntries), now],
  );
  if (result === undefined) return restoreWaiting(unique, now);
  return Number.isInteger(Number(result)) ? Number(result) : 0;
}
