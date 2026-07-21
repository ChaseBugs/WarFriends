import { ApiError } from "../apiErrors";

const CSHARP_INT32_MIN = -2_147_483_648;
const CSHARP_INT32_MAX = 2_147_483_647;

/**
 * Require the wire shape produced when a C# `int` is stored in a request dictionary and
 * serialized by Json.NET. The old `Number(value)` parsers silently accepted null, booleans,
 * blank strings, arrays, and numeric text, even though none can be emitted by the recovered
 * client field. Keeping the signed Int32 range here still lets feature logic return its
 * source-specific negative-value errors instead of changing those protocol branches.
 */
export function exactRequestJsonInteger(value: unknown, field: string, errorCode: number): number {
  if (
    typeof value !== "number"
    || !Number.isSafeInteger(value)
    || value < CSHARP_INT32_MIN
    || value > CSHARP_INT32_MAX
  ) {
    throw new ApiError(errorCode, `${field} must be an exact C# integer JSON number.`);
  }
  return value;
}

/** Require an actual finite JSON number for recovered C# float/double dictionary members. */
export function exactRequestJsonFiniteNumber(value: unknown, field: string, errorCode: number): number {
  if (typeof value !== "number" || !Number.isFinite(value)) {
    throw new ApiError(errorCode, `${field} must be an exact finite JSON number.`);
  }
  return value;
}

/**
 * Decode the exceptional WeaponScreen `Index` member. Its recovered call site explicitly
 * invokes `ToString()` on a nonnegative LevelManager array index before JSON serialization.
 * Accept only canonical decimal text so padded, signed, fractional, and exponent spellings
 * cannot become alternative representations of one replayed request.
 */
export function exactRequestIntegerText(value: unknown, field: string, errorCode: number): number {
  if (typeof value !== "string" || !/^(?:0|[1-9]\d*)$/.test(value)) {
    throw new ApiError(errorCode, `${field} must be canonical nonnegative integer text.`);
  }
  const parsed = Number(value);
  if (!Number.isSafeInteger(parsed) || parsed > CSHARP_INT32_MAX) {
    throw new ApiError(errorCode, `${field} must be canonical nonnegative integer text.`);
  }
  return parsed;
}
