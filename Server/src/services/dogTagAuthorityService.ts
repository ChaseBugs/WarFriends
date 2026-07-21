import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";

const VIP_DOG_TAG_DEBT_COUNT = 2;

export interface DogTagAuthority {
  dogTagSeconds: number;
  dogTagLastUpdate: number;
  dogTagMax: number;
  dogTagRefillSeconds: number;
}

/**
 * Validate the complete recovered dog-tag tuple before time arithmetic or boot projection.
 *
 * The normal cap and refill interval are stored in seconds and must describe a whole positive
 * number of tags. Spending the two virtual VIP tags may legitimately leave at most two refill
 * intervals of base debt; anything below that is not source-backed. A future update cursor would
 * freeze regeneration, while NaN/Infinity can bypass every min/max expression in the old logic.
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
    !Number.isSafeInteger(dogTagRefillSeconds)
    || dogTagRefillSeconds <= 0
    || !Number.isSafeInteger(dogTagMax)
    || dogTagMax <= 0
    || dogTagMax % dogTagRefillSeconds !== 0
    || !Number.isSafeInteger(minimumDogTagSeconds)
    || !Number.isSafeInteger(dogTagSeconds)
    || dogTagSeconds < minimumDogTagSeconds
    || dogTagSeconds > dogTagMax
    || !Number.isSafeInteger(dogTagLastUpdate)
    || dogTagLastUpdate < 0
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored dog-tag authority is invalid.");
  }
  if (now !== undefined) {
    if (!Number.isSafeInteger(now) || now < 0 || dogTagLastUpdate > now) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Stored dog-tag time authority is invalid.");
    }
  }
  return { dogTagSeconds, dogTagLastUpdate, dogTagMax, dogTagRefillSeconds };
}
