import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Parse one integer carried by the recovered HTTP request contract without JavaScript's broad
 * numeric coercion. Express may expose a stock-client form value as a decimal string, while tests
 * and replacement clients may send a JSON number, so both exact representations are accepted.
 * Booleans, arrays, objects, blank strings, fractions, exponent notation, and unsafe magnitudes
 * are rejected before the authoritative squad service sees a normalized but different value.
 */
export function exactSquadInteger(value: unknown, field: string, fallback?: number): number {
  if (value === undefined) {
    if (fallback !== undefined) return fallback;
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an exact integer.`);
  }
  let parsed: number;
  if (typeof value === "number") {
    parsed = value;
  } else if (typeof value === "string" && /^-?\d+$/.test(value.trim())) {
    parsed = Number(value.trim());
  } else {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an exact integer.`);
  }
  if (!Number.isSafeInteger(parsed)) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an exact integer.`);
  }
  return parsed;
}

/** Resolve the current JoinPolicy field or its older inverse IsPublic projection exactly. */
export function requestedSquadJoinPolicy(req: Record<string, unknown>): number | undefined {
  if (req.JoinPolicy !== undefined) return exactSquadInteger(req.JoinPolicy, "JoinPolicy");
  if (req.IsPublic === undefined) return undefined;

  const value = typeof req.IsPublic === "string" ? req.IsPublic.trim().toLowerCase() : req.IsPublic;
  if (value === 1 || value === "1" || value === true || value === "true") return 0;
  if (value === 0 || value === "0" || value === false || value === "false") return 1;
  throw new ApiError(ApiErrorCode.UnknownAction, "IsPublic must be an exact Boolean value.");
}
