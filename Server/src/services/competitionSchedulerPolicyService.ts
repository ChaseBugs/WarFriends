import { config } from "../config";
import { validatedSquadWarSeasonDurationSeconds } from "./squadWarContract";

function exactSchedulerSeconds(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value < 10 || value > 3_600) {
    throw new Error(`${label} scheduler interval policy is invalid.`);
  }
  return value;
}

export interface CompetitionTimingPolicy {
  readonly playerLeagueSchedulerSeconds: number;
  readonly squadWarSchedulerSeconds: number;
  readonly squadWarSeasonSeconds: number;
}

/**
 * Resolve every competition clock that must remain coherent for the lifetime of one process.
 *
 * The scheduler interval sizes both its local timer and its renewable distributed lease. The Squad
 * War season duration also derives durable IDs and settlement deadlines. Reading mutable config at
 * each call could therefore let one node use different authority within the same process even when
 * every individual value is valid. Validate and freeze the complete timing snapshot at startup.
 */
function exactCompetitionTimingPolicy(policy: CompetitionTimingPolicy): CompetitionTimingPolicy {
  return {
    playerLeagueSchedulerSeconds: exactSchedulerSeconds(
      policy.playerLeagueSchedulerSeconds,
      "Player League",
    ),
    squadWarSchedulerSeconds: exactSchedulerSeconds(
      policy.squadWarSchedulerSeconds,
      "Squad War",
    ),
    squadWarSeasonSeconds: validatedSquadWarSeasonDurationSeconds(policy.squadWarSeasonSeconds),
  };
}

const CONFIGURED_COMPETITION_TIMING_POLICY = Object.freeze(exactCompetitionTimingPolicy({
  playerLeagueSchedulerSeconds: config.playerLeagueSchedulerIntervalSeconds,
  squadWarSchedulerSeconds: config.squadWarsSchedulerIntervalSeconds,
  squadWarSeasonSeconds: config.squadWarsSeasonDurationSeconds,
}));

export function competitionTimingPolicy(
  policy?: CompetitionTimingPolicy,
): CompetitionTimingPolicy {
  return policy === undefined
    ? CONFIGURED_COMPETITION_TIMING_POLICY
    : exactCompetitionTimingPolicy(policy);
}

/** Polling interval for global Player League settlement and its renewable lease sizing. */
export function playerLeagueSchedulerIntervalSeconds(
  value?: number,
): number {
  return value === undefined
    ? CONFIGURED_COMPETITION_TIMING_POLICY.playerLeagueSchedulerSeconds
    : exactSchedulerSeconds(value, "Player League");
}

/** Polling interval for Squad War maintenance and its renewable lease sizing. */
export function squadWarSchedulerIntervalSeconds(
  value?: number,
): number {
  return value === undefined
    ? CONFIGURED_COMPETITION_TIMING_POLICY.squadWarSchedulerSeconds
    : exactSchedulerSeconds(value, "Squad War");
}

/** Season cadence used by every Squad War read, allocation, and settlement path. */
export function squadWarSeasonDurationSeconds(value?: number): number {
  return value === undefined
    ? CONFIGURED_COMPETITION_TIMING_POLICY.squadWarSeasonSeconds
    : validatedSquadWarSeasonDurationSeconds(value);
}
