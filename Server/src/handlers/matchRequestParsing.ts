import { ApiError, ApiErrorCode } from "../apiErrors";

const CSHARP_INT32_MAX = 2_147_483_647;

/**
 * Parse a nonnegative decimal emitted by C# `int.ToString(CultureInfo.InvariantCulture)`.
 * GameEnded fields select reward-bearing mission and battle outcomes, so null, booleans, arrays,
 * blanks, signs, leading zeros, fractions, and exponent text must not become integers through
 * JavaScript coercion. Feature services still restrict the resulting value to their exact enum or
 * mission-index set.
 */
export function exactMatchInteger(value: unknown, field: string): number {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  if (!Number.isSafeInteger(parsed) || parsed < 0 || parsed > CSHARP_INT32_MAX) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an exact nonnegative C# integer.`);
  }
  return parsed;
}
