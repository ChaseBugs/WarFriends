import { ApiError, ApiErrorCode } from "../apiErrors";

/** Largest Unix second representable by the JavaScript/BSON Date boundary used by the server. */
export const MAX_APPLICATION_UNIX_SECONDS = 8_640_000_000_000;

/**
 * Validate an application-owned clock before it can influence boot or durable progression state.
 *
 * TypeScript's `number` type does not protect exported state helpers at runtime. Keeping this
 * boundary separate from feature policy prevents callers from flooring a fraction, accepting an
 * infinite "future", or publishing a timestamp that BSON cannot represent as a Date.
 */
export function validatedApplicationUnixSeconds(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_APPLICATION_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} is invalid.`);
  }
  return value;
}
