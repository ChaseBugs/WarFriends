import { config } from "../config";

function exactSchedulerSeconds(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value < 10 || value > 3_600) {
    throw new Error(`${label} scheduler interval policy is invalid.`);
  }
  return value;
}

/** Polling interval for global Player League settlement and its renewable lease sizing. */
export function playerLeagueSchedulerIntervalSeconds(
  value = config.playerLeagueSchedulerIntervalSeconds,
): number {
  return exactSchedulerSeconds(value, "Player League");
}

/** Polling interval for Squad War maintenance and its renewable lease sizing. */
export function squadWarSchedulerIntervalSeconds(
  value = config.squadWarsSchedulerIntervalSeconds,
): number {
  return exactSchedulerSeconds(value, "Squad War");
}
