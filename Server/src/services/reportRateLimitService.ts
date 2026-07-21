import { createHmac } from "crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { reportRateLimits, type ReportRateLimitDocument } from "../db";
import { reportRateLimitMaximum } from "./abuseLimitPolicyService";

export { reportRateLimitMaximum } from "./abuseLimitPolicyService";

const WINDOW_MS = 60 * 60 * 1_000;
const MAXIMUM_ATTEMPTS = 100;
const DENIED_ATTEMPT_SENTINEL = MAXIMUM_ATTEMPTS + 1;
const REPORT_RATE_LIMIT_KEYS = new Set([
  "_id", "key", "attemptCount", "windowStartedAt", "updatedAt", "expiresAt",
]);

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

export function reportRateLimitAllows(attemptCount: number, maximum: number): boolean {
  return Number.isSafeInteger(attemptCount)
    && Number.isSafeInteger(maximum)
    && maximum >= 1
    && maximum <= MAXIMUM_ATTEMPTS
    && attemptCount > 0
    && attemptCount <= maximum;
}

/**
 * Prove the complete fixed-window row before its count can authorize or reject a report.
 *
 * The counter deliberately saturates at 101, one above the largest supported deployment limit.
 * Rejected spam therefore remains rejected without growing an attacker-controlled durable number
 * toward unsafe arithmetic. The globally supported bound also lets an operator raise or lower the
 * current per-hour policy without falsely declaring a legitimate in-flight window corrupt.
 */
export function validatedReportRateLimit(
  state: ReportRateLimitDocument,
  now: Date,
  expectedKey?: string,
): ReportRateLimitDocument {
  const raw = state as unknown as Record<string, unknown>;
  if (!state
    || typeof state !== "object"
    || Array.isArray(state)
    || Object.keys(raw).some((key) => !REPORT_RATE_LIMIT_KEYS.has(key))
    || typeof state.key !== "string"
    || !/^[0-9a-f]{64}$/u.test(state.key)
    || (expectedKey !== undefined && state.key !== expectedKey)
    || !Number.isSafeInteger(state.attemptCount)
    || state.attemptCount < 1
    || state.attemptCount > DENIED_ATTEMPT_SENTINEL
    || !safeDate(state.windowStartedAt)
    || !safeDate(state.updatedAt)
    || !safeDate(state.expiresAt)
    || !safeDate(now)
    || state.windowStartedAt.getTime() > state.updatedAt.getTime()
    || state.updatedAt.getTime() - state.windowStartedAt.getTime() >= WINDOW_MS
    || state.updatedAt.getTime() > now.getTime()
    || state.expiresAt.getTime() - state.updatedAt.getTime() !== WINDOW_MS * 2) {
    throw new Error("Stored report rate-limit authority is invalid.");
  }
  return state;
}

function keyFor(playerId: string): string {
  return createHmac("sha256", config.authSecret).update(`report:${playerId}`).digest("hex");
}

/**
 * Atomically reserve one report slot across every backend process.
 *
 * The old count-then-insert sequence allowed simultaneous requests to observe the same count and
 * all pass. This aggregation update resets an expired fixed window and increments one shared row
 * in a single MongoDB operation. A creation collision is retried against the winning row. The
 * counter is reserved before evidence work, so database failures cannot create an uncounted retry
 * storm; the logical duplicate check still runs before this function.
 */
export async function reserveReportSubmission(playerId: string, now = new Date(), retry = 0): Promise<void> {
  const key = keyFor(playerId);
  const cutoff = new Date(now.getTime() - WINDOW_MS);
  try {
    const state = await reportRateLimits().findOneAndUpdate(
      { key },
      [
        { $set: { _reset: { $lte: [{ $ifNull: ["$windowStartedAt", new Date(0)] }, cutoff] } } },
        { $set: {
          key,
          // Keep one stable denied sentinel instead of increasing the durable counter for every
          // blocked request. The logical window still resets from windowStartedAt, independently
          // of delayed TTL cleanup or an attacker continuing to submit during the blocked hour.
          attemptCount: {
            $cond: ["$_reset", 1, {
              $min: [DENIED_ATTEMPT_SENTINEL, { $add: [{ $ifNull: ["$attemptCount", 0] }, 1] }],
            }],
          },
          windowStartedAt: { $cond: ["$_reset", now, { $ifNull: ["$windowStartedAt", now] }] },
          updatedAt: now,
          expiresAt: new Date(now.getTime() + WINDOW_MS * 2),
        } },
        { $unset: "_reset" },
      ],
      { upsert: true, returnDocument: "after" },
    );
    if (!state) throw new Error("Report rate-limit reservation was not persisted.");
    validatedReportRateLimit(state, now, key);
    if (!reportRateLimitAllows(state.attemptCount, reportRateLimitMaximum())) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Report rate limit reached. Try again later.");
    }
  } catch (error) {
    if ((error as { code?: number }).code === 11000 && retry < 2) {
      return reserveReportSubmission(playerId, now, retry + 1);
    }
    throw error;
  }
}
