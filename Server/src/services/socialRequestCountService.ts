import { ApiError, ApiErrorCode } from "../apiErrors";

const CSHARP_INT32_MAX = 2_147_483_647;
const DEFAULT_INBOX_PAGE_SIZE = 50;
const MAX_INBOX_PAGE_SIZE = 100;
const MAX_FACEBOOK_FRIENDS_PER_REQUEST = 500;

function exactNonnegativeInt32(value: unknown, field: string): number {
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

/**
 * Parse the mandatory Count emitted with Friend0..FriendN. The server cap limits dynamic-key and
 * MongoDB work, while a larger source-valid client count remains compatible by using its first
 * bounded slice instead of rejecting a legitimate large Facebook friend list.
 */
export function requestedFacebookFriendCount(value: unknown): number {
  return Math.min(exactNonnegativeInt32(value, "Count"), MAX_FACEBOOK_FRIENDS_PER_REQUEST);
}

/**
 * Honor the recovered `MessagesCount` field before the optional replacement-client `Limit` alias.
 * Stock 1.6.0 asks for its current unignored count plus 100; the existing page cap intentionally
 * bounds that request. Total field absence retains the replacement transport's historical default,
 * but a present malformed or zero field is rejected instead of becoming 50 through `Number() ||`.
 */
export function requestedInboxPageLimit(req: Record<string, unknown>): number {
  const field = req.MessagesCount !== undefined
    ? "MessagesCount"
    : req.Limit !== undefined
      ? "Limit"
      : undefined;
  if (!field) return DEFAULT_INBOX_PAGE_SIZE;
  const requested = exactNonnegativeInt32(req[field], field);
  if (requested < 1) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be greater than zero.`);
  }
  return Math.min(requested, MAX_INBOX_PAGE_SIZE);
}
