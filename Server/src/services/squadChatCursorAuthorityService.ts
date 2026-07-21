import { ApiError, ApiErrorCode } from "../apiErrors";

/** `PlayerAnalyticsData.lastSeenSquadChatTimeStampDB` is a signed C# `int`. */
const MAX_CLIENT_INTEGER = 2_147_483_647;

/**
 * Photon message clocks and the application server clock can differ slightly in production.
 * The existing compatibility window is deliberately small: it tolerates normal clock skew but
 * cannot turn one modified action-193 request into a cursor that hides future chat indefinitely.
 */
export const MAX_SQUAD_CHAT_CURSOR_CLOCK_SKEW_SECONDS = 300;

function maximumCursorAt(now: number): number {
  if (!Number.isSafeInteger(now) || now < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Squad chat cursor server time is invalid.");
  }
  return Math.min(MAX_CLIENT_INTEGER, now + MAX_SQUAD_CHAT_CURSOR_CLOCK_SKEW_SECONDS);
}

/**
 * Validate the server-owned cursor before comparison or PlayerAnalyticsData projection.
 *
 * Only an absent legacy field defaults to zero. A stored NaN would otherwise make every
 * `requested <= current` comparison false, Infinity would make every request look stale, and a
 * value above Int32.MaxValue cannot survive the recovered client's JSON-to-`int` assignment.
 * Rejecting a cursor beyond the bounded receive-time window also prevents damaged durable state
 * from suppressing newly delivered squad messages after every reconnect.
 */
export function validatedSquadChatCursor(value: number | undefined, now: number): number {
  const cursor = value ?? 0;
  if (!Number.isSafeInteger(cursor) || cursor < 0 || cursor > maximumCursorAt(now)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored squad chat cursor is invalid.");
  }
  return cursor;
}

/** Validate one untrusted action-193 timestamp without treating it as durable authority. */
export function requestedSquadChatCursor(value: number, now: number): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > maximumCursorAt(now)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat timestamp is invalid.");
  }
  return value;
}
