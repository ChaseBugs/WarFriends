import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import type { DailyRewardState, PlayerProgressionState } from "../db";
import { advanceAchievementState } from "./achievementService";
import { mutateProgression } from "./progressionMutationService";

// MDNLFMNBNEG.Gold and LGCDFAELDNL.None from the recovered 1.6.0 assemblies.
const GOLD_REWARD_TYPE = 1;
const NO_DOUBLE_BONUS = 0;

export interface DailyRewardDefinition {
  Type: number;
  Double: number;
  Count: number;
  Param: string;
}

export interface DailyRewardWireData {
  month: number;
  year: number;
  canClaim: number;
  claimReward: number;
  nextDay: number;
  config: Record<string, DailyRewardDefinition>;
}

export interface DailyRewardMutationResult {
  state: PlayerProgressionState;
  calendar: DailyRewardState;
  rewardDay?: number;
  goldAdded?: number;
}

function utcDate(now: number): Date {
  return new Date(Math.floor(now) * 1000);
}

function utcDayKey(date: Date): string {
  return date.toISOString().slice(0, 10);
}

function daysInMonth(year: number, month: number): number {
  // Date.UTC uses a zero-based month. Passing the one-based current month as the next
  // month's index and asking for day zero returns the final day of the current month.
  return new Date(Date.UTC(year, month, 0)).getUTCDate();
}

function secondsUntilNextUtcDay(date: Date): number {
  const next = Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate() + 1);
  return Math.max(1, Math.floor((next - date.getTime()) / 1000));
}

/**
 * Return the reconstruction's configurable currency-only reward for a calendar position.
 * The APK preserves the response schema and reward-type enum but not the original remote
 * live-ops amounts. A larger every-seventh-login reward gives the calendar useful cadence
 * while avoiding inventory grants whose serialized schema has not yet been recovered.
 */
export function dailyRewardGoldForDay(day: number): number {
  const ordinary = Math.max(0, Math.floor(config.dailyRewardGold));
  const weekly = Math.max(ordinary, Math.floor(config.dailyRewardWeeklyGold));
  return day % 7 === 0 ? weekly : ordinary;
}

/** Build the exact `config.DayN` objects read by DailyRewardManager.MCGFHPOPMHL. */
export function buildDailyRewardConfig(year: number, month: number): Record<string, DailyRewardDefinition> {
  const result: Record<string, DailyRewardDefinition> = {};
  for (let day = 1; day <= daysInMonth(year, month); day += 1) {
    result[`Day${day}`] = {
      Type: GOLD_REWARD_TYPE,
      Double: NO_DOUBLE_BONUS,
      Count: dailyRewardGoldForDay(day),
      // Param is read with JToken.ToString() even for currency rewards, so it must exist.
      Param: "",
    };
  }
  return result;
}

function calendarFor(state: PlayerProgressionState, date: Date): DailyRewardState {
  const year = date.getUTCFullYear();
  const month = date.getUTCMonth() + 1;
  const existing = state.dailyReward;
  if (existing?.year === year && existing.month === month) return { ...existing };

  // A new month starts a new ordered calendar. We intentionally do not carry unclaimed
  // rewards across months because the Unity model contains only one month/year/config.
  return { year, month, canClaim: 0, claimReward: 0, lastCheckDay: "" };
}

/**
 * Register today's login once. Repeated boot/check requests on the same UTC day only refresh
 * the wire snapshot; they cannot manufacture additional claim slots. Availability advances
 * by login days rather than by the wall-calendar day, matching the client's separate
 * `canClaim` and `claimReward` counters and allowing a returning player to continue in order.
 */
export function checkDailyRewardState(state: PlayerProgressionState, now: number): DailyRewardMutationResult {
  const date = utcDate(now);
  const calendar = calendarFor(state, date);
  const today = utcDayKey(date);
  if (calendar.lastCheckDay !== today) {
    calendar.canClaim = Math.min(daysInMonth(calendar.year, calendar.month), calendar.canClaim + 1);
    calendar.lastCheckDay = today;
  }
  return {
    state: { ...state, revision: state.revision + 1, dailyReward: calendar },
    calendar,
  };
}

/**
 * Claim exactly the next unlocked calendar entry and credit Gold in the same revision-guarded
 * document write. A replay after a lost HTTP response sees the advanced claim cursor and is
 * rejected, so it cannot credit the amount twice even though the old client sends no request
 * UUID. Later days cannot be selected early because `requestedDay` must equal cursor + 1.
 */
export function claimDailyRewardState(
  state: PlayerProgressionState,
  now: number,
  requestedDay: number,
): DailyRewardMutationResult {
  const calendar = calendarFor(state, utcDate(now));
  const expectedDay = calendar.claimReward + 1;
  if (requestedDay <= calendar.claimReward) {
    throw new ApiError(ApiErrorCode.DailyRewardAlreadyClaimed, "Daily reward was already claimed.");
  }
  if (requestedDay !== expectedDay || requestedDay > calendar.canClaim) {
    throw new ApiError(ApiErrorCode.DailyRewardWrongIndex, "Daily reward is not available yet.");
  }

  const goldAdded = dailyRewardGoldForDay(requestedDay);
  calendar.claimReward = requestedDay;
  const rewardedState: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold + goldAdded,
    dailyReward: calendar,
  };

  // Achievement group 16 is `AchievementClaimedRewards`. Advancing it inside this same
  // transition ensures the login reward and achievement progress either both commit or both
  // retry under the progression revision guard; a dropped HTTP response cannot count twice.
  const achievementResult = advanceAchievementState(rewardedState, 16, 1);
  return {
    state: achievementResult.state,
    calendar,
    rewardDay: requestedDay,
    goldAdded,
  };
}

export function buildDailyRewardWireData(calendar: DailyRewardState, now: number): DailyRewardWireData {
  return {
    month: calendar.month,
    year: calendar.year,
    canClaim: calendar.canClaim,
    claimReward: calendar.claimReward,
    nextDay: secondsUntilNextUtcDay(utcDate(now)),
    config: buildDailyRewardConfig(calendar.year, calendar.month),
  };
}

export function checkDailyReward(playerId: string): Promise<DailyRewardMutationResult> {
  return mutateProgression(playerId, checkDailyRewardState);
}

export function claimDailyReward(playerId: string, requestedDay: number): Promise<DailyRewardMutationResult> {
  return mutateProgression(playerId, (state, now) => claimDailyRewardState(state, now, requestedDay));
}
