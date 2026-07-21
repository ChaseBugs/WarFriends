import { ApiError, ApiErrorCode } from "../apiErrors";
import type { BlackMarketOfferState, PlayerProgressionState } from "../db";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const MAX_OFFER_COUNT = 4;

/** Validate a Black Market authority timestamp before comparison or serialization. */
export function validatedBlackMarketUnixSeconds(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_DATE_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} is invalid.`);
  }
  return value;
}

/**
 * Validate one complete persisted Black Market offer set.
 *
 * The recovered client accepts the full object as purchase authority. Imported `Infinity` expiry,
 * duplicate identities, an unsafe issue cursor, or an invented special-feature index must not
 * survive merely because JavaScript comparisons and array traversal accept those values.
 */
export function validatedBlackMarketOfferState(
  value: BlackMarketOfferState | undefined,
): BlackMarketOfferState | undefined {
  if (value === undefined) return undefined;
  if (!Number.isSafeInteger(value.offersTotal) || value.offersTotal < 1) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Black Market issue cursor is invalid.");
  }
  if (
    typeof value.lastTrigger !== "string"
    || value.lastTrigger.length === 0
    || value.lastTrigger.length > 64
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Black Market trigger is invalid.");
  }
  const offerEnd = validatedBlackMarketUnixSeconds(value.offerEnd, "Black Market offer expiry");
  if (offerEnd === 0 || !Array.isArray(value.currentOffers) || value.currentOffers.length > MAX_OFFER_COUNT) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Black Market offer set is invalid.");
  }

  const weaponIds = new Set<string>();
  for (const offer of value.currentOffers) {
    if (
      typeof offer.weaponId !== "string"
      || offer.weaponId.length === 0
      || offer.weaponId.length > 256
      || weaponIds.has(offer.weaponId)
      || !Number.isSafeInteger(offer.level)
      || offer.level < 0
      // The offline issuer intentionally supports only recovered feature zero. Accepting a
      // different imported index would invent the retired remote feature-weight decision.
      || offer.special !== 0
    ) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Black Market offered weapon is invalid.");
    }
    weaponIds.add(offer.weaponId);
  }
  return value;
}

/** Determine whether the persisted set has validated authority at one server timestamp. */
export function hasActiveBlackMarketOffer(state: PlayerProgressionState, now: number): boolean {
  const offer = validatedBlackMarketOfferState(state.blackMarket);
  const currentTime = validatedBlackMarketUnixSeconds(now, "Black Market comparison time");
  return offer !== undefined && offer.offerEnd > currentTime;
}
