import { ApiError, ApiErrorCode } from "../apiErrors";
import type { DailyRewardState } from "../db";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const DAILY_REWARD_KEYS = new Set(["year", "month", "canClaim", "claimReward", "lastCheckDay"]);

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function daysInMonth(year: number, month: number): number {
  // Date.UTC uses a zero-based month. Passing the one-based current month as the next month's
  // index and day zero returns the final day of the requested recovered calendar month.
  return new Date(Date.UTC(year, month, 0)).getUTCDate();
}

function calendarCoordinates(value: unknown): { record: Record<string, unknown>; year: number; month: number } {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    invalid("Daily reward calendar is invalid.");
  }
  const record = value as Record<string, unknown>;
  const year = record.year;
  const month = record.month;
  if (!Number.isSafeInteger(year) || (year as number) < 1970 || (year as number) > 9_999
    || !Number.isSafeInteger(month) || (month as number) < 1 || (month as number) > 12) {
    invalid("Daily reward calendar date is invalid.");
  }
  return { record, year: year as number, month: month as number };
}

/** Validate the exact five-field calendar snapshot independently of the active server month. */
export function validatedDailyRewardState(value: DailyRewardState): DailyRewardState {
  const { record, year, month } = calendarCoordinates(value);
  const actualKeys = Object.keys(record);
  if (actualKeys.length !== DAILY_REWARD_KEYS.size
    || actualKeys.some((key) => !DAILY_REWARD_KEYS.has(key))) {
    invalid("Daily reward calendar shape is invalid.");
  }
  const maximumDay = daysInMonth(year, month);
  const canClaim = record.canClaim;
  const claimReward = record.claimReward;
  if (!Number.isSafeInteger(canClaim) || (canClaim as number) < 0 || (canClaim as number) > maximumDay
    || !Number.isSafeInteger(claimReward) || (claimReward as number) < 0
    || (claimReward as number) > (canClaim as number)) {
    invalid("Daily reward cursors are invalid.");
  }
  const lastCheckDay = record.lastCheckDay;
  if (typeof lastCheckDay !== "string") invalid("Daily reward last-check day is invalid.");
  if (lastCheckDay !== "") {
    const match = /^(\d{4})-(\d{2})-(\d{2})$/.exec(lastCheckDay);
    const day = Number(match?.[3]);
    if (!match
      || Number(match[1]) !== year
      || Number(match[2]) !== month
      || !Number.isSafeInteger(day)
      || day < 1
      || day > maximumDay) {
      invalid("Daily reward last-check day is invalid.");
    }
  }
  return {
    year,
    month,
    canClaim: canClaim as number,
    claimReward: claimReward as number,
    lastCheckDay,
  };
}

/**
 * Resolve the one monthly calendar that can currently authorize a claim.
 *
 * A prior-month snapshot has no authority in the recovered one-calendar model, so it must be
 * discarded before cursor validation. This is intentionally not a generic corruption repair:
 * malformed calendar coordinates and every future/current-month inconsistency fail closed. That
 * distinction lets an old broken development row roll over without allowing Infinity/NaN in the
 * active month to freeze or reopen rewards.
 */
export function dailyRewardAuthorityFor(
  value: DailyRewardState | undefined,
  now: number,
): DailyRewardState | undefined {
  if (value === undefined) return undefined;
  if (!Number.isSafeInteger(now) || now < 0 || now > MAX_DATE_UNIX_SECONDS) {
    invalid("Daily reward authority time is invalid.");
  }
  const currentDate = new Date(now * 1000);
  if (Number.isNaN(currentDate.getTime())) invalid("Daily reward authority time is invalid.");
  const currentYear = currentDate.getUTCFullYear();
  const currentMonth = currentDate.getUTCMonth() + 1;
  const { year, month } = calendarCoordinates(value);
  const storedOrdinal = year * 12 + month;
  const currentOrdinal = currentYear * 12 + currentMonth;
  if (storedOrdinal < currentOrdinal) return undefined;
  if (storedOrdinal > currentOrdinal) invalid("Daily reward calendar is from the future.");
  return validatedDailyRewardState(value);
}
