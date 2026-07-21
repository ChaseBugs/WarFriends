import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";

const VIP_DOG_TAG_DEBT_COUNT = 2;
const MAX_CLIENT_INTEGER = 2_147_483_647;

/** Exact normal-energy values decoded from the 4.9.5 MainScene Constants rows. */
export const RECOVERED_DOG_TAG_REFILL_SECONDS = 900;
export const RECOVERED_DOG_TAG_CAP = 5;
export const RECOVERED_DOG_TAG_MAX_SECONDS =
  RECOVERED_DOG_TAG_REFILL_SECONDS * RECOVERED_DOG_TAG_CAP;

export interface DogTagAuthority {
  dogTagSeconds: number;
  dogTagLastUpdate: number;
  dogTagMax: number;
  dogTagRefillSeconds: number;
}

/**
 * Validate the complete recovered dog-tag tuple before time arithmetic or boot projection.
 *
 * The normal cap and refill interval are source constants, not per-account balancing. Accepting
 * another exact integer would let one node persist energy that the stock client's fixed 900/5
 * calculations interpret differently. Spending the two virtual VIP tags may legitimately leave
 * at most two refill intervals of base debt; anything below that is not source-backed. Every boot
 * field is parsed through C# `int`, so a safe JavaScript integer above that width is still invalid.
 * A future update cursor would freeze regeneration, while NaN/Infinity can bypass every min/max
 * expression in the old logic.
 */
export function validatedDogTagAuthority(
  state: Pick<
    PlayerProgressionState,
    "dogTagSeconds" | "dogTagLastUpdate" | "dogTagMax" | "dogTagRefillSeconds"
  >,
  now?: number,
): DogTagAuthority {
  const { dogTagSeconds, dogTagLastUpdate, dogTagMax, dogTagRefillSeconds } = state;
  const minimumDogTagSeconds = -VIP_DOG_TAG_DEBT_COUNT * dogTagRefillSeconds;
  if (
    dogTagRefillSeconds !== RECOVERED_DOG_TAG_REFILL_SECONDS
    || dogTagMax !== RECOVERED_DOG_TAG_MAX_SECONDS
    || !Number.isSafeInteger(minimumDogTagSeconds)
    || !Number.isSafeInteger(dogTagSeconds)
    || dogTagSeconds < -MAX_CLIENT_INTEGER - 1
    || dogTagSeconds > MAX_CLIENT_INTEGER
    || dogTagSeconds < minimumDogTagSeconds
    || dogTagSeconds > dogTagMax
    || !Number.isSafeInteger(dogTagLastUpdate)
    || dogTagLastUpdate < 0
    || dogTagLastUpdate > MAX_CLIENT_INTEGER
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored dog-tag authority is invalid.");
  }
  if (now !== undefined) {
    if (!Number.isSafeInteger(now) || now < 0 || now > MAX_CLIENT_INTEGER || dogTagLastUpdate > now) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Stored dog-tag time authority is invalid.");
    }
  }
  return { dogTagSeconds, dogTagLastUpdate, dogTagMax, dogTagRefillSeconds };
}
