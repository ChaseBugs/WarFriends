import type { PlayerProgressionState } from "../db";

/** Exact 4.9.5 MainScene `UpgradesSubscriptionMultiplierTime` value. */
export const SUBSCRIPTION_UPGRADE_TIME_MULTIPLIER = Math.fround(0.8);

/** Match SubscriptionManager.isSubscribed's strict expiry comparison using server time. */
export function hasActiveSubscription(state: PlayerProgressionState, now: number): boolean {
  return state.subscription?.type === "subscription1"
    && Math.floor(state.subscription.expireTime) > Math.floor(now);
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
