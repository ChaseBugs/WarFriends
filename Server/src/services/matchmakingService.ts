import logger from "../utils/logger";

// Matchmaking — pairs two waiting players for a PvP match (BACKEND.md §3). Pairing favours
// the closest opponent by army power within a widening league window, matching the client's
// MatchMakingConstants/MatchMakingDeviation tuning intent.
//
// Single-process in-memory queue: players are matched while connected to the ws hub, so the
// queue naturally lives with the hub. A Redis-backed queue (RedisKeys.matchmakingQueue) can
// replace this to shard across multiple hub instances — left as a follow-up.

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
