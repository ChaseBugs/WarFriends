import { createHmac } from "crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { authRateLimits, type AuthRateLimitDocument } from "../db";

export interface LoginRateLimitPolicy {
  maxAttempts: number;
  windowMilliseconds: number;
  lockoutMilliseconds: number;
}

export interface LoginAttemptReservation {
  key: string;
  revision: number;
}

/** Clamp deploy-time values so a malformed environment cannot silently disable protection. */
export function loginRateLimitPolicy(): LoginRateLimitPolicy {
  const boundedInteger = (value: number, fallback: number, minimum: number, maximum: number): number =>
    Number.isFinite(value) ? Math.min(maximum, Math.max(minimum, Math.floor(value))) : fallback;
  const windowSeconds = boundedInteger(config.authLoginWindowSeconds, 900, 60, 86_400);
  const lockoutSeconds = boundedInteger(config.authLoginLockoutSeconds, 900, 60, 604_800);
  return {
    maxAttempts: boundedInteger(config.authLoginMaxAttempts, 5, 2, 100),
    windowMilliseconds: windowSeconds * 1_000,
    lockoutMilliseconds: lockoutSeconds * 1_000,
  };
}

/**
 * Derive a stable database key without persisting the raw player or external-provider ID.
 * AUTH_SECRET makes an offline dictionary of known platform IDs impractical if this small
 * operational collection is exposed independently of the player database.
 */
export function loginRateLimitKey(presentedId: string): string {
  return createHmac("sha256", config.authSecret).update(`login:${presentedId}`).digest("hex");
}

export function loginRateLimitBlocked(
  state: Pick<AuthRateLimitDocument, "lockedUntil"> | null,
  now: Date,
): boolean {
  return Boolean(state?.lockedUntil && state.lockedUntil.getTime() > now.getTime());
}

function invalidCredentials(): ApiError {
  // Do not reveal whether the ID exists, whether a password was wrong, or whether the throttle
  // caused the rejection. The recovered client handles all three through authorization code 10.
  return new ApiError(ApiErrorCode.RequestNotAuthorized, "Invalid credentials.");
}

/**
 * Atomically reserve one durable-login attempt before expensive credential/provider checks.
 *
 * The aggregation update resets an expired window, increments one shared counter across all
 * server processes, and installs a cooldown when this reservation reaches the limit. An already
 * locked row cannot match the update filter; the attempted upsert then collides with the unique
 * key, which is translated to the same generic authorization failure. This closes the usual
 * count-then-insert race without placing ordinary gameplay-token requests behind this counter.
 *
 * The attempt that reaches the threshold is still verified. A correct credential clears its
 * exact reservation, while an incorrect one leaves the newly installed cooldown in force.
 */
async function reserveLoginAttemptInternal(
  presentedId: string,
  now: Date,
  collisionRetry = 0,
): Promise<LoginAttemptReservation> {
  const policy = loginRateLimitPolicy();
  const key = loginRateLimitKey(presentedId);
  const cutoff = new Date(now.getTime() - policy.windowMilliseconds);
  const lockUntil = new Date(now.getTime() + policy.lockoutMilliseconds);
  const expiresAt = new Date(now.getTime() + policy.windowMilliseconds + policy.lockoutMilliseconds);

  try {
    const updated = await authRateLimits().findOneAndUpdate(
      {
        key,
        $or: [
          { lockedUntil: null },
          { lockedUntil: { $exists: false } },
          { lockedUntil: { $lte: now } },
        ],
      },
      [
        {
          $set: {
            _resetWindow: {
              $or: [
                { $lte: [{ $ifNull: ["$windowStartedAt", new Date(0)] }, cutoff] },
                {
                  $and: [
                    { $ne: [{ $ifNull: ["$lockedUntil", null] }, null] },
                    { $lte: ["$lockedUntil", now] },
                  ],
                },
              ],
            },
          },
        },
        {
          $set: {
            key,
            attemptCount: {
              $cond: ["$_resetWindow", 1, { $add: [{ $ifNull: ["$attemptCount", 0] }, 1] }],
            },
            revision: { $add: [{ $ifNull: ["$revision", 0] }, 1] },
            windowStartedAt: { $cond: ["$_resetWindow", now, { $ifNull: ["$windowStartedAt", now] }] },
            updatedAt: now,
            expiresAt,
          },
        },
        {
          $set: {
            lockedUntil: { $cond: [{ $gte: ["$attemptCount", policy.maxAttempts] }, lockUntil, null] },
          },
        },
        { $unset: "_resetWindow" },
      ],
      { upsert: true, returnDocument: "after" },
    );
    if (!updated) throw new Error("Login attempt reservation was not persisted.");
    return { key, revision: updated.revision };
  } catch (error) {
    // A duplicate key means the row existed but was locked (or another process created it
    // between match and upsert). Re-read once to distinguish a harmless creation race.
    if ((error as { code?: number }).code !== 11000) throw error;
    const existing = await authRateLimits().findOne({ key });
    if (loginRateLimitBlocked(existing, now)) throw invalidCredentials();
    // The concurrent creator has consumed the first attempt. Reserve again against that row.
    // Bound collision retries so pathological delete/create churn cannot grow the call stack.
    if (collisionRetry >= 2) throw invalidCredentials();
    return reserveLoginAttemptInternal(presentedId, now, collisionRetry + 1);
  }
}

export function reserveLoginAttempt(
  presentedId: string,
  now = new Date(),
): Promise<LoginAttemptReservation> {
  return reserveLoginAttemptInternal(presentedId, now, 0);
}

/** Clear only the reservation that authenticated, preserving any later concurrent failures. */
export async function clearLoginAttempt(reservation: LoginAttemptReservation): Promise<void> {
  await authRateLimits().deleteOne({ key: reservation.key, revision: reservation.revision });
}

/** A valid rotatable session token proves account control and may clear all older login failures. */
export async function clearLoginAttemptsForSession(presentedId: string): Promise<void> {
  await authRateLimits().deleteOne({ key: loginRateLimitKey(presentedId) });
}
