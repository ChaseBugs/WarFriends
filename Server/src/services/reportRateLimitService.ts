import { createHmac } from "crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { reportRateLimits } from "../db";

const WINDOW_MS = 60 * 60 * 1_000;

export function reportRateLimitMaximum(value = config.reportMaxPerHour): number {
  return Number.isFinite(value) ? Math.min(100, Math.max(1, Math.floor(value))) : 5;
}

export function reportRateLimitAllows(attemptCount: number, maximum: number): boolean {
  return Number.isInteger(attemptCount) && attemptCount > 0 && attemptCount <= maximum;
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
          attemptCount: { $cond: ["$_reset", 1, { $add: [{ $ifNull: ["$attemptCount", 0] }, 1] }] },
          windowStartedAt: { $cond: ["$_reset", now, { $ifNull: ["$windowStartedAt", now] }] },
          updatedAt: now,
          expiresAt: new Date(now.getTime() + WINDOW_MS * 2),
        } },
        { $unset: "_reset" },
      ],
      { upsert: true, returnDocument: "after" },
    );
    if (!state || !reportRateLimitAllows(state.attemptCount, reportRateLimitMaximum())) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Report rate limit reached. Try again later.");
    }
  } catch (error) {
    if ((error as { code?: number }).code === 11000 && retry < 2) {
      return reserveReportSubmission(playerId, now, retry + 1);
    }
    throw error;
  }
}
