import { createHmac } from "crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import {
  outgoingMessageRateLimits,
  type OutgoingMessageRateLimitDocument,
} from "../db";
import { outgoingMessageRateLimitMaximum } from "./abuseLimitPolicyService";

export { outgoingMessageRateLimitMaximum } from "./abuseLimitPolicyService";

const WINDOW_MS = 60_000;
const MAXIMUM_ATTEMPTS = 1_000;
const DENIED_ATTEMPT_SENTINEL = MAXIMUM_ATTEMPTS + 1;
const RATE_LIMIT_KEYS = new Set([
  "_id", "key", "attemptCount", "windowStartedAt", "updatedAt", "expiresAt",
]);

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

export function outgoingMessageRateLimitAllows(attemptCount: number, maximum: number): boolean {
  return Number.isSafeInteger(attemptCount)
    && Number.isSafeInteger(maximum)
    && maximum >= 1
    && maximum <= MAXIMUM_ATTEMPTS
    && attemptCount >= 1
    && attemptCount <= maximum;
}

/**
 * Validate the complete fixed-window row before its counter can authorize or reject inbox traffic.
 * The denied sentinel prevents attacker traffic from growing durable arithmetic without bound,
 * while the original window start remains unchanged so repeated denials cannot postpone reset.
 */
export function validatedOutgoingMessageRateLimit(
  state: OutgoingMessageRateLimitDocument,
  now: Date,
  expectedKey?: string,
): OutgoingMessageRateLimitDocument {
  const raw = state as unknown as Record<string, unknown>;
  if (!state
    || typeof state !== "object"
    || Array.isArray(state)
    || Object.keys(raw).length !== RATE_LIMIT_KEYS.size
    || Object.keys(raw).some((key) => !RATE_LIMIT_KEYS.has(key))
    || typeof state._id !== "string"
    || typeof state.key !== "string"
    || state._id !== state.key
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
    throw new Error("Stored outgoing-message rate-limit authority is invalid.");
  }
  return state;
}

/** Keep the operational collection from becoming a plaintext secondary player directory. */
export function outgoingMessageRateLimitKey(
  playerId: string,
  scope: "inbox" | "squad-chat" | "client-analytics" = "inbox",
): string {
  return createHmac("sha256", config.authSecret).update(`${scope}:${playerId}`).digest("hex");
}

/**
 * Atomically reserve one authored-message attempt across every server process.
 *
 * A fixed window is used because one MongoDB aggregation update can reset, increment, saturate,
 * and return the winning counter without the write skew of the old message count followed by a
 * separate insert. Identical challenge replay is resolved before this reservation, so a lost
 * response does not spend a second slot; rejected/new attempts remain counted as abuse pressure.
 */
async function reservePlayerAuthoredMessageSlot(
  playerId: string,
  scope: "inbox" | "squad-chat" | "client-analytics",
  maximum: number,
  now: Date,
  collisionRetry: number,
): Promise<void> {
  if (!outgoingMessageRateLimitAllows(1, maximum)) {
    throw new Error("Player-authored message abuse-limit policy is invalid.");
  }
  const key = outgoingMessageRateLimitKey(playerId, scope);
  const cutoff = new Date(now.getTime() - WINDOW_MS);
  const collection = outgoingMessageRateLimits();
  // Validate a present row before the aggregation pipeline can fill missing fields. Without this
  // read, a damaged window could be silently normalized to count one and reopen sender capacity.
  // The post-update validation below remains necessary for the concurrent winner.
  const existing = await collection.findOne({ _id: key });
  if (existing) validatedOutgoingMessageRateLimit(existing, now, key);
  try {
    const state = await collection.findOneAndUpdate(
      { _id: key, key },
      [
        { $set: { _reset: { $lte: [{ $ifNull: ["$windowStartedAt", new Date(0)] }, cutoff] } } },
        {
          $set: {
            key,
            attemptCount: {
              $cond: ["$_reset", 1, {
                $min: [DENIED_ATTEMPT_SENTINEL, { $add: [{ $ifNull: ["$attemptCount", 0] }, 1] }],
              }],
            },
            windowStartedAt: { $cond: ["$_reset", now, { $ifNull: ["$windowStartedAt", now] }] },
            updatedAt: now,
            expiresAt: new Date(now.getTime() + WINDOW_MS * 2),
          },
        },
        { $unset: "_reset" },
      ],
      { upsert: true, returnDocument: "after" },
    );
    if (!state) throw new Error("Outgoing-message rate-limit reservation was not persisted.");
    validatedOutgoingMessageRateLimit(state, now, key);
    if (!outgoingMessageRateLimitAllows(state.attemptCount, maximum)) {
      const label = scope === "squad-chat"
        ? "Squad chat"
        : scope === "client-analytics" ? "Analytics" : "Message";
      throw new ApiError(ApiErrorCode.UnknownAction, `${label} rate limit reached. Try again later.`);
    }
  } catch (error) {
    if ((error as { code?: number }).code === 11000 && collisionRetry < 2) {
      return reservePlayerAuthoredMessageSlot(
        playerId,
        scope,
        maximum,
        now,
        collisionRetry + 1,
      );
    }
    throw error;
  }
}

/** Reserve one direct/challenge inbox attempt under the deployment-owned inbox policy. */
export async function reserveOutgoingMessageSlot(
  playerId: string,
  now = new Date(),
  collisionRetry = 0,
): Promise<void> {
  return reservePlayerAuthoredMessageSlot(
    playerId,
    "inbox",
    outgoingMessageRateLimitMaximum(),
    now,
    collisionRetry,
  );
}

/**
 * Reserve a Squad Chat attempt in the same atomic collection but a separate HMAC domain.
 * This replaces the former count-then-insert race without combining chat and inbox quotas.
 */
export async function reserveSquadChatMessageSlot(
  playerId: string,
  maximum: number,
  now = new Date(),
  collisionRetry = 0,
): Promise<void> {
  return reservePlayerAuthoredMessageSlot(
    playerId,
    "squad-chat",
    maximum,
    now,
    collisionRetry,
  );
}

/**
 * Reserve one action-179 diagnostic submission without sharing inbox or Squad Chat capacity.
 *
 * The same atomic fixed-window implementation is reused, but the HMAC domain is independent.
 * This prevents an analytics flood from consuming social-message quota and prevents concurrent
 * backend nodes from passing a count-then-insert race.
 */
export async function reserveClientAnalyticsSlot(
  playerId: string,
  maximum: number,
  now = new Date(),
  collisionRetry = 0,
): Promise<void> {
  return reservePlayerAuthoredMessageSlot(
    playerId,
    "client-analytics",
    maximum,
    now,
    collisionRetry,
  );
}
