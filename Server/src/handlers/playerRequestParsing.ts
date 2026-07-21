import { ApiError, ApiErrorCode } from "../apiErrors";
import { PlayerStatus } from "../constants";

function canonicalUnsignedInteger(value: unknown): number | undefined {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  return Number.isSafeInteger(parsed) && parsed >= 0 ? parsed : undefined;
}

/**
 * Parse the action-29 enum emitted through `PlayerStatus.ToString`. Invalid heartbeats remain
 * callback-safe, but return undefined so missing/null/Boolean/array input cannot become a valid
 * Offline or Online transition through JavaScript numeric coercion.
 */
export function exactPlayerStatus(value: unknown): PlayerStatus | undefined {
  const parsed = canonicalUnsignedInteger(value);
  return parsed === PlayerStatus.Offline
    || parsed === PlayerStatus.Online
    || parsed === PlayerStatus.InGame
    ? parsed
    : undefined;
}

/** Parse the recovered paid-rename 0/1 integer without accepting truthy/falsy substitutes. */
export function exactRenamePaymentFlag(value: unknown): 0 | 1 {
  const parsed = canonicalUnsignedInteger(value);
  if (parsed !== 0 && parsed !== 1) {
    throw new ApiError(ApiErrorCode.UnknownAction, "PayForRename must be an exact 0 or 1 integer.");
  }
  return parsed;
}
