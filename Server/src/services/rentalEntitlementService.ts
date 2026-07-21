import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, RentalItemType, RentalOfferState } from "../db";

/** Largest Unix-second value that JavaScript can convert to a valid `Date`. */
const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const RENTAL_MIN_DISCOUNT = 20;
const RENTAL_MAX_DISCOUNT = 25;

/**
 * Validate a server-owned rental timestamp before it participates in authority.
 *
 * MongoDB documents imported from an old service or modified outside this application can contain
 * values such as `Infinity`, fractions, or integers too large for BSON/JavaScript dates. Raw
 * comparisons would turn an infinite trial or sale deadline into permanent access. All rental
 * consumers therefore share this fail-closed scalar boundary.
 */
export function validatedRentalUnixSeconds(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_DATE_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} is invalid.`);
  }
  return value;
}

function validPreviousWeaponSlot(value: RentalOfferState["previousWeaponSlot"]): boolean {
  return value === undefined || (
    Number.isSafeInteger(value.slotIndex)
    && value.slotIndex >= 0
    && value.slotIndex < 4
    && typeof value.name === "string"
    && value.name.length > 0
    && value.name.length <= 256
    && Number.isSafeInteger(value.weaponIndex)
    && value.weaponIndex >= 0
  );
}

/**
 * Validate the complete private rental lifecycle before exposing or consuming it.
 *
 * The three deadlines are state-machine fields, not independent counters. Zero is the explicit
 * inactive sentinel. A live trial must end no later than the daily replacement boundary, and a
 * post-battle sale must end no later than that same boundary. Rejecting contradictory imported
 * state avoids one subsystem granting a borrowed item while another has already expired it.
 */
export function validatedRentalState(
  value: RentalOfferState | undefined,
): RentalOfferState | undefined {
  if (value === undefined) return undefined;
  if (typeof value.id !== "string" || value.id.length === 0 || value.id.length > 256) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rental item identity is invalid.");
  }
  // The recovered 4.9.5 probability for visual rentals is zero. This server issues only unit and
  // weapon rows, so accepting type 2 from an imported document would create unsupported authority.
  if (value.type !== 0 && value.type !== 1) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rental item type is invalid.");
  }
  if (
    !Number.isSafeInteger(value.discount)
    || value.discount < RENTAL_MIN_DISCOUNT
    || value.discount > RENTAL_MAX_DISCOUNT
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rental discount is invalid.");
  }
  if (!Number.isSafeInteger(value.generation) || value.generation < 1) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rental generation is invalid.");
  }
  if (!validPreviousWeaponSlot(value.previousWeaponSlot) || (value.previousWeaponSlot && value.type !== 1)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rental previous weapon slot is invalid.");
  }

  const nextGenerate = validatedRentalUnixSeconds(value.nextGenerate, "Rental replacement deadline");
  const trialExpiresAt = validatedRentalUnixSeconds(value.trialExpiresAt, "Rental trial expiry");
  const saleExpiresAt = validatedRentalUnixSeconds(value.saleExpiresAt, "Rental sale expiry");
  if (nextGenerate === 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rental replacement deadline is invalid.");
  }

  if (value.status === "trial") {
    if (trialExpiresAt === 0 || trialExpiresAt > nextGenerate || saleExpiresAt !== 0) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Rental trial timeline is invalid.");
    }
  } else if (value.status === "sale") {
    if (
      trialExpiresAt !== 0
      || saleExpiresAt === 0
      || saleExpiresAt > nextGenerate
      || typeof value.saleBattleId !== "string"
      || value.saleBattleId.length === 0
      || value.saleBattleId.length > 128
    ) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Rental sale timeline is invalid.");
    }
  } else if (
    value.status === "offered"
    || value.status === "purchased"
    || value.status === "cooldown"
  ) {
    if (trialExpiresAt !== 0 || saleExpiresAt !== 0) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Inactive rental timeline is invalid.");
    }
  } else {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rental status is invalid.");
  }
  return value;
}

/** Determine whether one exact borrowed catalog row still has validated trial authority. */
export function hasActiveRentalItem(
  state: PlayerProgressionState,
  type: RentalItemType,
  id: string,
  now: number,
): boolean {
  const rental = validatedRentalState(state.rental);
  const currentTime = validatedRentalUnixSeconds(now, "Rental comparison time");
  return rental !== undefined
    && rental.status === "trial"
    && rental.type === type
    && rental.id === id
    && rental.trialExpiresAt > currentTime;
}
