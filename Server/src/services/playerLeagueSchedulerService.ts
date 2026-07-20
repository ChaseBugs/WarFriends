import { config } from "../config";
import { players } from "../db";
import logger from "../utils/logger";
import { parseManagedPlayerLeagueId } from "./playerLeagueContract";
import { finishExpiredPlayerLeague } from "./playerLeagueService";
import { withScheduledJobLease } from "./scheduledJobLeaseService";

const jobId = "player-league-settlement";
const maximumDivisionsPerSweep = 100;

export function expiredManagedLeagueIds(values: readonly unknown[], now: number): string[] {
  return [...new Set(values.filter((value): value is string => typeof value === "string"))]
    .filter((value) => {
      const managed = parseManagedPlayerLeagueId(value);
      return Boolean(managed && managed.endsAt <= now);
    })
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
  const leased = await withScheduledJobLease(jobId, Math.max(900_000, intervalSeconds * 2_000), async () => {
    const leagueIds = expiredManagedLeagueIds(await players().distinct("player.leagueId"), now);
    let settledDivisions = 0;
    let settledPlayers = 0;
    for (const leagueId of leagueIds) {
      const requester = await players().findOne({ "player.leagueId": leagueId });
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
