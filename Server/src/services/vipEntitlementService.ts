import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Validate the private Unix-second deadline that owns every paid VIP benefit.
 *
 * MongoDB can retain non-finite doubles from a damaged import even though JSON cannot represent
 * them faithfully. JavaScript then treats `Infinity > now` as true, which would turn one corrupt
 * field into permanent dog tags, battle multipliers, daily cards, and VIP-only shop access.
 * Keeping the check in a dependency-free service lets every entitlement consumer share exactly
 * the same fail-closed rule without coupling unrelated economy modules to VipService.
 */
export function validatedVipExpiration(value: number | undefined): number {
  const expiration = value ?? 0;
  if (!Number.isSafeInteger(expiration) || expiration < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored VIP expiration is invalid.");
  }
  return expiration;
}

export interface VipTimelineAuthority {
  vipStart: number;
  vipExpiration: number;
}

/**
 * Validate the full paid-VIP timeline without changing the recovered entitlement predicate.
 *
 * VipManager.NOGEIPHFNPK checks only expiration against server time; `vipStart` drives duration
 * and progress calculations in BuyVIPDialog and ReminderManager. It therefore remains display
 * metadata, but malformed or inverted values can still poison client math. Every server writer
 * creates 0/0 for no entitlement and `start <= expiration` for a paid interval, so any other
 * durable pair is corruption rather than a source-backed state.
 */
export function validatedVipTimeline(
  vipStart: number,
  vipExpirationValue: number | undefined,
): VipTimelineAuthority {
  const vipExpiration = validatedVipExpiration(vipExpirationValue);
  if (
    !Number.isSafeInteger(vipStart)
    || vipStart < 0
    || (vipExpiration === 0 ? vipStart !== 0 : vipStart > vipExpiration)
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored VIP timeline is invalid.");
  }
  return { vipStart, vipExpiration };
}

/** Determine entitlement at one authoritative server timestamp after validating both operands. */
export function isVipActiveAt(value: number | undefined, now: number): boolean {
  if (!Number.isSafeInteger(now) || now < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "VIP entitlement timestamp is invalid.");
  }
  return validatedVipExpiration(value) > now;
}
