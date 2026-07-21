import { ApiError, ApiErrorCode } from "../apiErrors";

/** Exact 4.9.5 `SecondRenameGoldCost` value decoded from MainScene. */
export const SECOND_RENAME_BASE_GOLD_COST = 4;

/** Highest persisted count whose current doubling price remains positive in signed C# `int`. */
const MAX_POSITIVE_STOCK_RENAME_COUNT = 29;

/**
 * Validate the profile-owned rename count before price, recovery, mutation, or boot projection.
 *
 * Unity computes `4 * (1 << (count - 1))` with signed 32-bit arithmetic. Count 29 still has a
 * positive current price, but a successful rename from it would persist count 30 and make the
 * next client price negative. The validator permits existing count 29 so it can be displayed and
 * diagnosed; the mutation must separately validate its increment before committing anything.
 */
export function validatedRenameCount(value: number | undefined): number {
  const count = value ?? 0;
  if (!Number.isSafeInteger(count) || count < 0 || count > MAX_POSITIVE_STOCK_RENAME_COUNT) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored rename count is invalid.");
  }
  return count;
}

/** Reproduce PlayerAnalytics.renameGoldPrice without reproducing its signed-overflow bug. */
export function renameGoldPrice(renameCount: number): number {
  const count = validatedRenameCount(renameCount);
  return count === 0 ? 0 : SECOND_RENAME_BASE_GOLD_COST * (2 ** (count - 1));
}
