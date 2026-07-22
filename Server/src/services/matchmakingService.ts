import logger from "../utils/logger";
import { League, RedisKeys } from "../constants";
import { exactRedisIntegerReply, isRedisAvailable, redisEval } from "../redis";
import { matchmakingTimeoutSeconds } from "./multiplayerTimeoutPolicyService";

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
const QUEUE_ENTRY_KEYS = new Set(["playerId", "armyPower", "leagueTier", "enqueuedAt"]);
const MAX_CLIENT_INTEGER = 2_147_483_647;

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
  // Validate before deduplication: an invalid retry must not remove an already valid search owned
  // by the same player ID and thereby turn malformed transport input into queue mutation.
  const full = validatedQueueEntry({ ...entry, enqueuedAt: Date.now() });
  remove(full.playerId); // dedupe re-queues
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
  // Build and prove the complete batch before removing any current searches. Durable admission can
  // fail after two candidates were removed; restoration must be all-or-nothing at this boundary.
  const validated = entries.map((entry) => validatedQueueEntry({ ...entry, enqueuedAt: now }));
  const unique = [...new Map(validated.map((entry) => [entry.playerId, entry])).values()];
  for (const entry of unique) remove(entry.playerId);
  for (const entry of unique) queue.push(entry);
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
    -- Redis is transient coordination, not gameplay authority, but one damaged hash value must not
    -- abort this atomic script and deny matching to every healthy row behind it. Mirror Node's exact
    -- four-field QueueEntry proof here because the candidate is consumed before control returns to
    -- Node. Invalid rows are removed from both structures and require their owner to enqueue again.
    local decoded, candidate = pcall(cjson.decode, candidateJson)
    local candidateValid = decoded and type(candidate) == 'table'
    local fieldCount = 0
    if candidateValid then
      for key, _ in pairs(candidate) do
        fieldCount = fieldCount + 1
        if key ~= 'playerId' and key ~= 'armyPower' and key ~= 'leagueTier' and key ~= 'enqueuedAt' then
          candidateValid = false
        end
      end
    end
    local candidatePower = candidateValid and tonumber(candidate.armyPower) or nil
    local candidateTier = candidateValid and tonumber(candidate.leagueTier) or nil
    local candidateTime = candidateValid and tonumber(candidate.enqueuedAt) or nil
    candidateValid = candidateValid
      and fieldCount == 4
      and type(candidate.playerId) == 'string'
      and candidate.playerId == candidateId
      and string.len(candidate.playerId) > 0
      and string.len(candidate.playerId) <= 128
      and not string.find(candidate.playerId, '%c')
      and not string.find(candidate.playerId, '%.')
      and not string.find(candidate.playerId, '%$')
      and type(candidate.armyPower) == 'number'
      and candidatePower ~= nil
      and candidatePower == candidatePower
      and candidatePower >= 0
      and candidatePower < math.huge
      and math.floor(candidatePower) <= 2147483647
      and type(candidate.leagueTier) == 'number'
      and candidateTier ~= nil
      and candidateTier == math.floor(candidateTier)
      and candidateTier >= 1
      and candidateTier <= 16
      and type(candidate.enqueuedAt) == 'number'
      and candidateTime ~= nil
      and candidateTime == math.floor(candidateTime)
      and candidateTime > 0
      and candidateTime <= 9007199254740991
      and candidateTime == enqueuedAt
    if not candidateValid then
      redis.call('ZREM', queueKey, candidateId)
      redis.call('HDEL', entriesKey, candidateId)
    else
      local candidateWindow = 1 + math.floor(math.max(0, now - enqueuedAt) / 10000)
      if math.abs(candidateTier - leagueTier) <= candidateWindow then
        local powerDifference = math.abs(candidatePower - armyPower)
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
  const keys = Object.keys(entry);
  const armyPowerProjection = Math.trunc(Number(entry.armyPower));
  return keys.length === QUEUE_ENTRY_KEYS.size
    && keys.every((key) => QUEUE_ENTRY_KEYS.has(key))
    && typeof entry.playerId === "string"
    && entry.playerId.length > 0
    && entry.playerId.length <= 128
    // Match rows use participant IDs as MongoDB map keys. Reject a damaged Redis candidate at the
    // queue boundary instead of selecting it and waiting for durable admission to discover that
    // controls, `.` or `$` cannot represent one safe participant identity.
    && !/[\p{Cc}.$]/u.test(entry.playerId)
    && Number.isFinite(entry.armyPower)
    && Number(entry.armyPower) >= 0
    && Number.isSafeInteger(armyPowerProjection)
    && armyPowerProjection <= MAX_CLIENT_INTEGER
    && Number.isInteger(entry.leagueTier)
    && Number(entry.leagueTier) >= League.Bronze3
    && Number(entry.leagueTier) <= League.Champion
    && Number.isSafeInteger(entry.enqueuedAt)
    && Number(entry.enqueuedAt) > 0;
}

function validatedQueueEntry(value: unknown): QueueEntry {
  if (!validQueueEntry(value)) throw new Error("Matchmaking queue entry is invalid.");
  return value;
}

/** Build the complete Redis hash payload; restored snapshots must retain a valid enqueue clock. */
export function buildRestoredQueueEntries(
  entries: ReadonlyArray<Omit<QueueEntry, "enqueuedAt">>,
  now: number,
): QueueEntry[] {
  const validated = entries.map((entry) => validatedQueueEntry({ ...entry, enqueuedAt: now }));
  return [...new Map(validated.map((entry) => [entry.playerId, entry])).values()];
}

/**
 * Pair through Redis when it is healthy, otherwise preserve the verified single-node queue.
 * The returned opponent is only a candidate; createMatch still re-reads MongoDB snapshots and
 * transactionally reserves both accounts before a durable match exists.
 */
export async function enqueueForHub(entry: Omit<QueueEntry, "enqueuedAt">): Promise<string | null> {
  if (!isRedisAvailable()) return enqueue(entry);
  const now = Date.now();
  const full = validatedQueueEntry({ ...entry, enqueuedAt: now });
  const encoded = JSON.stringify(full);
  const result = await redisEval(
    enqueueScript,
    [RedisKeys.matchmakingQueue, RedisKeys.matchmakingEntries],
    [
      full.playerId,
      full.armyPower,
      full.leagueTier,
      now,
      encoded,
      500,
      // Give the owning node's ordinary timer a full extra window to remove and notify its player
      // before another node treats the entry as abandoned after a crash or prolonged pause.
      now - matchmakingTimeoutSeconds() * 2_000,
    ],
  );
  if (result === undefined) throw new Error("Distributed matchmaking coordination is unavailable.");
  if (typeof result !== "string") return null;
  try {
    const opponent = JSON.parse(result) as unknown;
    if (!validQueueEntry(opponent) || opponent.playerId === full.playerId) return null;
    logger.match.event("Distributed matchmaking paired", { a: full.playerId, b: opponent.playerId });
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
  const removedFromRedis = exactRedisIntegerReply(result, 0, 1);
  return removedFromRedis === 1 || removedLocally;
}

/** Restore a failed admission batch atomically without immediately pairing its two members. */
export async function restoreWaitingForHub(
  entries: ReadonlyArray<Omit<QueueEntry, "enqueuedAt">>,
  now = Date.now(),
): Promise<number> {
  // Validate every submitted snapshot before deduplicating. Otherwise an invalid earlier duplicate
  // could be hidden by a later valid value and partially trusted at a recovery boundary.
  if (!isRedisAvailable()) return restoreWaiting(entries, now);
  const distributedEntries = buildRestoredQueueEntries(entries, now);
  const result = await redisEval(
    restoreScript,
    [RedisKeys.matchmakingQueue, RedisKeys.matchmakingEntries],
    [JSON.stringify(distributedEntries), now],
  );
  if (result === undefined) return restoreWaiting(distributedEntries, now);
  const restored = exactRedisIntegerReply(result, distributedEntries.length, distributedEntries.length);
  if (restored === null) {
    // The script either reports the complete submitted batch or the coordination result is
    // uncertain. Do not claim zero/some restoration and let callers continue with a split queue.
    throw new Error("Distributed matchmaking restoration result is invalid.");
  }
  return restored;
}
