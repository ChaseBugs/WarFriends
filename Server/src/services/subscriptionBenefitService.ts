import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, PlayerSubscriptionState } from "../db";

/** Exact 4.9.5 MainScene `UpgradesSubscriptionMultiplierTime` value. */
export const SUBSCRIPTION_UPGRADE_TIME_MULTIPLIER = Math.fround(0.8);

/** Largest Unix-second value that can still be represented by JavaScript's `Date`. */
const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const SUBSCRIPTION_AUTHORITY_RECEIPT_PATTERN = /^[0-9a-f]{64}$/;

/**
 * Validate the private receipt key that owns subscription revalidation authority.
 *
 * Purchase tokens are never stored directly. purchaseService domain-separates and HMAC-SHA256
 * hashes them, producing exactly 64 lowercase hexadecimal characters. Absence remains valid for
 * subscriptions created before receipt ownership was added; any present noncanonical value could
 * make stale-event equality behave unpredictably and must not be republished.
 */
export function validatedSubscriptionAuthorityReceiptId(value: unknown): string | undefined {
  if (value === undefined) return undefined;
  if (typeof value !== "string" || !SUBSCRIPTION_AUTHORITY_RECEIPT_PATTERN.test(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Subscription authority receipt is invalid.");
  }
  return value;
}

/**
 * Validate a timestamp that participates in paid-subscription authority.
 *
 * MongoDB can retain values such as `Infinity` when old or manually repaired documents bypass
 * normal request validation. JavaScript comparisons would treat an infinite expiry as permanent
 * access, while converting a huge safe integer into a receipt `Date` can create an invalid BSON
 * value. Keep this validation at the shared entitlement boundary so every benefit consumer and
 * purchase lifecycle path has the same fail-closed behavior.
 */
export function validatedSubscriptionUnixSeconds(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_DATE_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} is invalid.`);
  }
  return value;
}

/** Validate the complete private subscription projection before exposing or consuming it. */
export function validatedSubscription(
  value: PlayerSubscriptionState | undefined,
): PlayerSubscriptionState | undefined {
  if (value === undefined) return undefined;
  if (value.type !== "subscription1") {
    throw new ApiError(ApiErrorCode.InternalServerError, "Subscription type is invalid.");
  }
  const subscription = {
    type: value.type,
    expireTime: validatedSubscriptionUnixSeconds(value.expireTime, "Subscription expiry"),
    subscribeSince: validatedSubscriptionUnixSeconds(value.subscribeSince, "Subscription start"),
    dogTagTimerLock: validatedSubscriptionUnixSeconds(value.dogTagTimerLock, "Subscription dog-tag lock"),
  };
  // These fields describe one interval, not three unrelated counters. An inverted interval could
  // make one consumer report active access while another calculates accelerated regeneration from
  // a future lock. Reject the entire paid authority instead of normalizing or guessing which
  // imported field was intended.
  if (
    subscription.subscribeSince > subscription.dogTagTimerLock
    || subscription.dogTagTimerLock > subscription.expireTime
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Subscription timeline is invalid.");
  }
  return subscription;
}

/** Match SubscriptionManager.isSubscribed's strict expiry comparison using validated server time. */
export function hasActiveSubscription(state: PlayerProgressionState, now: number): boolean {
  const subscription = validatedSubscription(state.subscription);
  const currentTime = validatedSubscriptionUnixSeconds(now, "Subscription comparison time");
  return subscription !== undefined && subscription.expireTime > currentTime;
}

/**
 * Reproduce the Client's `Mathf.CeilToInt(deliveryTime * upgradesMultiplier)` calculation.
 *
 * The multiplication is explicitly rounded to System.Single before the ceiling operation. The
 * resulting integer is both the DeliveryTime sent in RequestBuffer and the local receipt length,
 * so the backend must derive the same value from verified subscription authority. Expiry after a
 * receipt starts does not lengthen it; entitlement is evaluated once at purchase, exactly as the
 * recovered UpgradeSlot and WeaponLevelsSetup methods do.
 */
export function subscriptionUpgradeDeliverySeconds(
  state: PlayerProgressionState,
  now: number,
  sourceDeliverySeconds: number,
): number {
  const seconds = Math.max(0, Math.floor(sourceDeliverySeconds));
  if (!hasActiveSubscription(state, now)) return seconds;
  return Math.ceil(Math.fround(Math.fround(seconds) * SUBSCRIPTION_UPGRADE_TIME_MULTIPLIER));
}
