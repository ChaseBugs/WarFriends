import { config } from "../config";
import logger from "../utils/logger";
import { withScheduledJobLease } from "./scheduledJobLeaseService";
import { maintainSquadWars } from "./squadWarService";

const jobId = "squad-war-maintenance";

export async function runSquadWarMaintenanceSweep(now = new Date()): Promise<{
  rounds: number;
  messages: number;
  skipped: boolean;
}> {
  if (!config.squadWarsEnabled) return { rounds: 0, messages: 0, skipped: true };
  const seconds = Math.min(3_600, Math.max(10, Math.floor(config.squadWarsSchedulerIntervalSeconds)));
  // Only the lease owner may allocate/settle. MongoDB's unique indexes and transaction guards
  // remain the final correctness boundary if a lease expires while a slow sweep is finishing.
  const leased = await withScheduledJobLease(jobId, Math.max(900_000, seconds * 2_000), () => maintainSquadWars(now));
  if (!leased.ran) return { rounds: 0, messages: 0, skipped: true };
  return { ...(leased.result ?? { rounds: 0, messages: 0 }), skipped: false };
}

export function startSquadWarScheduler(): NodeJS.Timeout {
  const seconds = Math.min(3_600, Math.max(10, Math.floor(config.squadWarsSchedulerIntervalSeconds)));
  const run = (): void => {
    void runSquadWarMaintenanceSweep().then((result) => {
      if (!result.skipped && (result.rounds > 0 || result.messages > 0)) {
        logger.infoWithEmoji("SQUAD", "Squad Wars maintenance completed", "SCHEDULER", result);
      }
    }).catch((error: unknown) => {
      logger.errorWithEmoji("SQUAD", "Squad Wars scheduler failed", "SCHEDULER", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  };
  run();
  const timer = setInterval(run, seconds * 1_000);
  timer.unref();
  return timer;
}
