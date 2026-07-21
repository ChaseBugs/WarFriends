import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Parse the decimal percentage emitted by the recovered VIP and lootbox dialogs. Both stock
 * calls always include this field, even when it is zero. Requiring a canonical integer prevents
 * JavaScript from converting missing/null/Boolean/array/blank values into an authorized zero and
 * then committing a real Gold purchase from a malformed request.
 */
export function exactPurchaseDiscount(value: unknown): number {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  if (!Number.isSafeInteger(parsed) || parsed < 0 || parsed > 99) {
    throw new ApiError(ApiErrorCode.UnknownAction, "discount must be an exact integer from 0 to 99.");
  }
  return parsed;
}
