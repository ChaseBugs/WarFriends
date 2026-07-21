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

/** Determine entitlement at one authoritative server timestamp after validating both operands. */
export function isVipActiveAt(value: number | undefined, now: number): boolean {
  if (!Number.isSafeInteger(now) || now < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "VIP entitlement timestamp is invalid.");
  }
  return validatedVipExpiration(value) > now;
}
