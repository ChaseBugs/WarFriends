import { ApiError, ApiErrorCode } from "../apiErrors";
import type { VipDailyCardRewardState } from "../db";
import { CARD_CATALOG } from "./cardInventoryService";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const UTC_DAY_PATTERN = /^\d{4}-\d{2}-\d{2}$/;

export function validatedVipDailyCardTime(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_DATE_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} is invalid.`);
  }
  return value;
}

function utcDayKey(value: number): string {
  return new Date(value * 1_000).toISOString().slice(0, 10);
}

/** Validate the complete private once-per-UTC-day paid-VIP card marker. */
export function validatedVipDailyCardState(
  value: VipDailyCardRewardState | undefined,
  now?: number,
): VipDailyCardRewardState | undefined {
  if (value === undefined) return undefined;
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored VIP daily-card marker is invalid.");
  }
  const keys = Object.keys(value).sort();
  const grantedAt = validatedVipDailyCardTime(value.lastGrantedAt, "VIP daily-card grant time");
  if (
    keys.length !== 3
    || keys[0] !== "lastGrantDay"
    || keys[1] !== "lastGrantedAt"
    || keys[2] !== "lastRewardIds"
    || typeof value.lastGrantDay !== "string"
    || !UTC_DAY_PATTERN.test(value.lastGrantDay)
    || value.lastGrantDay !== utcDayKey(grantedAt)
    || !Array.isArray(value.lastRewardIds)
    || value.lastRewardIds.length !== 2
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored VIP daily-card marker is invalid.");
  }
  if (now !== undefined && grantedAt > validatedVipDailyCardTime(now, "VIP daily-card comparison time")) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored VIP daily-card grant time is in the future.");
  }
  const cardIds = value.lastRewardIds.map((id) => {
    const card = typeof id === "string" ? CARD_CATALOG[id] : undefined;
    if (!card?.implemented || (card.rarity !== 2 && card.rarity !== 3)) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Stored VIP daily-card reward is invalid.");
    }
    return id;
  }) as [string, string];
  return { lastGrantDay: value.lastGrantDay, lastGrantedAt: grantedAt, lastRewardIds: cardIds };
}

export function vipDailyCardDayKey(now: number): string {
  return utcDayKey(validatedVipDailyCardTime(now, "VIP daily-card request time"));
}
