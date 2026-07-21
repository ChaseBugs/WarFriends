import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, PlayerSubscriptionState } from "../db";

/** Exact 4.9.5 MainScene `UpgradesSubscriptionMultiplierTime` value. */
export const SUBSCRIPTION_UPGRADE_TIME_MULTIPLIER = Math.fround(0.8);

/** Largest Unix-second value that can still be represented by JavaScript's `Date`. */
const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const MAX_CLIENT_INTEGER = 2_147_483_647;
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
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Subscription authority is invalid.");
  }
  const keys = Object.keys(value).sort();
  if (
    keys.length !== 4
    || keys[0] !== "dogTagTimerLock"
    || keys[1] !== "expireTime"
    || keys[2] !== "subscribeSince"
    || keys[3] !== "type"
    || value.type !== "subscription1"
  ) {
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

/**
 * Validate subscription authority at a client-facing time boundary.
 *
 * Publication uses the deterministic interval validator above. Boot additionally rejects a future
 * start because SubscriptionManager's recovered activity predicate primarily observes expiry; if
 * the server serialized a not-yet-started interval, the stock client could expose benefits early.
 */
export function validatedSubscriptionAt(
  value: PlayerSubscriptionState | undefined,
  now: number,
): PlayerSubscriptionState | undefined {
  const subscription = validatedSubscription(value);
  const currentTime = validatedSubscriptionUnixSeconds(now, "Subscription comparison time");
  if (subscription && subscription.subscribeSince > currentTime) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Subscription start is in the future.");
  }
  return subscription;
}

/** Match SubscriptionManager.isSubscribed's strict expiry comparison using validated server time. */
export function hasActiveSubscription(state: PlayerProgressionState, now: number): boolean {
  const subscription = validatedSubscription(state.subscription);
  const currentTime = validatedSubscriptionUnixSeconds(now, "Subscription comparison time");
  return subscription !== undefined
    && subscription.subscribeSince <= currentTime
    && subscription.expireTime > currentTime;
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
  // This duration comes from the extracted server catalog, but this exported helper is also the
  // common boundary for weapon and unit mutations. TypeScript's number annotation disappears at
  // runtime: flooring a fraction or allowing NaN would publish a duration the recovered C# int
  // contract never emitted, while a negative value used to become an invented instant upgrade.
  if (!Number.isSafeInteger(sourceDeliverySeconds)
    || sourceDeliverySeconds < 0
    || sourceDeliverySeconds > MAX_CLIENT_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Subscription upgrade delivery duration is invalid.");
  }
  const seconds = sourceDeliverySeconds;
  if (!hasActiveSubscription(state, now)) return seconds;
  const discounted = Math.ceil(Math.fround(Math.fround(seconds) * SUBSCRIPTION_UPGRADE_TIME_MULTIPLIER));
  if (!Number.isSafeInteger(discounted) || discounted < 0 || discounted > MAX_CLIENT_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Subscription upgrade delivery duration overflowed.");
  }
  return discounted;
}
