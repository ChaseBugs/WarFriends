import { ApiError, ApiErrorCode } from "../apiErrors";

/** Largest Unix-second value that remains representable by JavaScript Date and BSON Date. */
export const MAX_ITEM_DELIVERY_UNIX_SECONDS = 8_640_000_000_000;

/**
 * Validate application time before it can create, release, or price an upgrade delivery receipt.
 *
 * These state helpers are exported for RequestBuffer and replacement-client use. TypeScript does
 * not protect their runtime `number` arguments, so flooring NaN, fractions, or negative values can
 * create an invalid receipt, release an upgrade early, or calculate a cheaper instant completion.
 */
export function validatedItemDeliveryUnixSeconds(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_ITEM_DELIVERY_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} is invalid.`);
  }
  return value;
}

/** Add one already validated duration without publishing an invalid Date-compatible deadline. */
export function checkedItemDeliveryEnd(start: number, duration: number, field: string): number {
  const checkedStart = validatedItemDeliveryUnixSeconds(start, `${field} start`);
  if (!Number.isSafeInteger(duration) || duration < 0 || duration > 2_147_483_647) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} duration is invalid.`);
  }
  return validatedItemDeliveryUnixSeconds(checkedStart + duration, `${field} end`);
}
