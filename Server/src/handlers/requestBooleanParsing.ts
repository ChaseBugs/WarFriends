import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Parse a stock-client flag written as the literal form value `"0"` or `"1"`.
 *
 * The recovered match methods construct these fields manually instead of calling
 * `Boolean.ToString()`. JSON replacement clients may express the same semantic value as an
 * actual Boolean, but numeric values and alternate strings are not part of either transport.
 * Rejecting those aliases matters because these flags select ranked, friendly, tutorial, and
 * Arena settlement paths; treating malformed input as false could route a request into a
 * different reward lifecycle.
 */
export function exactBinaryBoolean(
  value: unknown,
  field: string,
  required = true,
): boolean | undefined {
  if (value === undefined && !required) return undefined;
  if (value === true || value === "1") return true;
  if (value === false || value === "0") return false;
  throw new ApiError(
    ApiErrorCode.UnknownAction,
    `${field} must be the exact stock 0/1 flag or a JSON Boolean.`,
  );
}

/**
 * Parse a C# `Boolean.ToString()` form value (`"True"` or `"False"`).
 *
 * Action 138 uses this spelling to decide between a free rental trial and a discounted permanent
 * purchase. Accepting JavaScript-style truthy aliases would let a modified request choose the paid
 * inventory transition through a representation that the recovered client never emits.
 */
export function exactCsharpBoolean(value: unknown, field: string): boolean {
  if (value === true || value === "True") return true;
  if (value === false || value === "False") return false;
  throw new ApiError(
    ApiErrorCode.UnknownAction,
    `${field} must be an exact C# Boolean or a JSON Boolean.`,
  );
}
