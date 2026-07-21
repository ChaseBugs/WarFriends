import { config } from "../config";

function exactPolicyInteger(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Google Play ${label} policy is invalid.`);
  }
  return value;
}

/**
 * How long a nonterminal subscription receipt may wait before its next provider check.
 *
 * Receipt creation and later revalidation must use the same exact value. Otherwise one malformed
 * deployment setting can write a cursor that disagrees with the scheduler policy or even becomes
 * an invalid Date, consuming provider proof without leaving recoverable polling authority.
 */
export function googlePlaySubscriptionRevalidationCadenceSeconds(
  value = config.googlePlaySubscriptionRevalidationCadenceSeconds,
): number {
  return exactPolicyInteger(value, "subscription revalidation cadence", 300, 86_400);
}

/** Bounded polling frequency for the leased subscription revalidation worker. */
export function googlePlaySubscriptionSchedulerIntervalSeconds(
  value = config.googlePlaySubscriptionSchedulerIntervalSeconds,
): number {
  return exactPolicyInteger(value, "subscription scheduler interval", 30, 3_600);
}

/** Maximum number of complete durable receipts selected by one leased provider sweep. */
export function googlePlaySubscriptionRevalidationBatchSize(
  value = config.googlePlaySubscriptionRevalidationBatchSize,
): number {
  return exactPolicyInteger(value, "subscription revalidation batch size", 1, 1_000);
}

/** Bounded polling frequency for the delayed voided-purchase chargeback worker. */
export function googlePlayVoidedPurchaseSchedulerIntervalSeconds(
  value = config.googlePlayVoidedPurchaseSchedulerIntervalSeconds,
): number {
  return exactPolicyInteger(value, "voided-purchase scheduler interval", 60, 3_600);
}
