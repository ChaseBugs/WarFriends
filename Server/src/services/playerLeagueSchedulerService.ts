import { config } from "../config";
import { players } from "../db";
import logger from "../utils/logger";
import {
  MANAGED_PLAYER_LEAGUE_ID_PATTERN,
  MANAGED_PLAYER_LEAGUE_NAMESPACE_PATTERN,
  parseManagedPlayerLeagueId,
} from "./playerLeagueContract";
import { finishExpiredPlayerLeague } from "./playerLeagueService";
import { validatedPlayerProfileLookup } from "./playerProfileMirrorAuthorityService";
import { withScheduledJobLease } from "./scheduledJobLeaseService";

const jobId = "player-league-settlement";
const maximumDivisionsPerSweep = 100;
const maximumDiscoveryRows = maximumDivisionsPerSweep + 1;

/**
 * Build a bounded MongoDB pipeline for expired scheduler-owned divisions.
 *
 * `distinct("player.leagueId")` must materialize every historical division into one MongoDB
 * response before application code can apply its limit, eventually reaching the server's 16 MiB
 * result ceiling. Grouping and limiting on MongoDB keeps the read bounded. The broad first match
 * deliberately includes malformed `*-local*` values. `_validShape` then keeps every malformed
 * backend-owned ID regardless of its apparent timestamp, while valid IDs continue only when their
 * encoded deadline is due. Application validation runs across all returned rows before the first
 * settlement write, so database expressions are discovery hints rather than trusted authority.
 */
export function playerLeagueDiscoveryPipeline(now: number): Record<string, unknown>[] {
  if (!Number.isSafeInteger(now) || now <= 0) {
    throw new Error("Player League scheduler time is invalid.");
  }
  return [
    { $match: { "player.leagueId": { $type: "string", $regex: MANAGED_PLAYER_LEAGUE_NAMESPACE_PATTERN.source } } },
    { $group: { _id: "$player.leagueId" } },
    { $sort: { _id: 1 } },
    {
      $set: {
        _validShape: {
          $regexMatch: { input: "$_id", regex: MANAGED_PLAYER_LEAGUE_ID_PATTERN.source },
        },
        _endsAt: {
          $convert: {
            input: { $arrayElemAt: [{ $split: ["$_id", "-"] }, 1] },
            to: "long",
            onError: null,
            onNull: null,
          },
        },
      },
    },
    {
      $match: {
        $expr: {
          $or: [
            { $eq: ["$_validShape", false] },
            { $lte: ["$_endsAt", now] },
          ],
        },
      },
    },
    { $limit: maximumDiscoveryRows },
    { $project: { _id: 0, leagueId: "$_id" } },
  ];
}

export function expiredManagedLeagueIds(values: readonly unknown[], now: number): string[] {
  if (!Number.isSafeInteger(now) || now <= 0) {
    throw new Error("Player League scheduler time is invalid.");
  }
  const expired: string[] = [];
  for (const value of new Set(values.filter((candidate): candidate is string => typeof candidate === "string"))) {
    if (!MANAGED_PLAYER_LEAGUE_NAMESPACE_PATTERN.test(value)) continue;
    const managed = parseManagedPlayerLeagueId(value);
    if (!managed) {
      // This namespace is emitted only by the replacement backend. Silently treating damage as an
      // unknown production division would strand its members and hide the row from every sweep.
      throw new Error(`Stored managed Player League ID is invalid: ${value}.`);
    }
    if (managed.endsAt <= now) expired.push(value);
  }
  return expired
    .sort()
    .slice(0, maximumDivisionsPerSweep);
}

export async function runPlayerLeagueSettlementSweep(now = Math.floor(Date.now() / 1_000)): Promise<{
  divisions: number;
  players: number;
  skipped: boolean;
}> {
  const intervalSeconds = Math.min(3_600, Math.max(10, Math.floor(config.playerLeagueSchedulerIntervalSeconds)));
  // A sweep can settle up to 100 divisions and therefore outlive a short polling interval. Keep
  // the lease comfortably longer than one normal sweep; a crashed owner becomes retryable later.
  const leased = await withScheduledJobLease(jobId, Math.max(900_000, intervalSeconds * 2_000), async (lease) => {
    await lease.assertOwned();
    const discovered = await players()
      .aggregate<{ leagueId: unknown }>(playerLeagueDiscoveryPipeline(now))
      .toArray();
    const leagueIds = expiredManagedLeagueIds(discovered.map((row) => row.leagueId), now);
    let settledDivisions = 0;
    let settledPlayers = 0;
    for (const leagueId of leagueIds) {
      await lease.assertOwned();
      // The scheduler owns no authenticated handler snapshot. Prove the full account selected as
      // its division representative before that row can trigger the all-member settlement.
      const requester = validatedPlayerProfileLookup(await players().findOne({ "player.leagueId": leagueId }));
      if (!requester) continue;
      const result = await finishExpiredPlayerLeague(requester, now);
      if (!result.finished) continue;
      settledDivisions += 1;
      settledPlayers += result.settledPlayers;
    }
    return { divisions: settledDivisions, players: settledPlayers };
  });
  if (!leased.ran) return { divisions: 0, players: 0, skipped: true };
  return { ...(leased.result ?? { divisions: 0, players: 0 }), skipped: false };
}

export function startPlayerLeagueSettlementScheduler(): NodeJS.Timeout {
  const seconds = Math.min(3_600, Math.max(10, Math.floor(config.playerLeagueSchedulerIntervalSeconds)));
  const run = (): void => {
    void runPlayerLeagueSettlementSweep().then((result) => {
      if (!result.skipped && (result.divisions > 0 || result.players > 0)) {
        logger.infoWithEmoji("LEAGUE", "Expired player leagues settled", "SCHEDULER", result);
      }
    }).catch((error: unknown) => {
      logger.errorWithEmoji("LEAGUE", "Player league scheduler failed", "SCHEDULER", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  };
  run();
  const timer = setInterval(run, seconds * 1_000);
  timer.unref();
  return timer;
}
