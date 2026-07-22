import { config } from "../config";

export interface GooglePlayApplicationPolicy {
  readonly purchasesEnabled: boolean;
  readonly subscriptionRevalidationEnabled: boolean;
  readonly voidedPurchaseReconciliationEnabled: boolean;
  readonly packageName: string;
}

/**
 * Validate the one Google Play application identity shared by every paid-entitlement path.
 *
 * Android application IDs are Java-style dotted identifiers. The value is also the immutable
 * prefix of every recovered Play SKU and the provider API resource path, so trimming or accepting
 * a malformed value would let one node validate durable receipts against a different identity
 * from the node that created them. Background readers cannot be enabled independently because
 * their HMAC/encryption authority is provisioned only with the main purchase integration.
 */
function exactGooglePlayApplicationPolicy(
  policy: GooglePlayApplicationPolicy,
): GooglePlayApplicationPolicy {
  const validPackageName = typeof policy.packageName === "string"
    && policy.packageName.length <= 255
    && policy.packageName.trim() === policy.packageName
    && /^[A-Za-z][A-Za-z0-9_]*(?:\.[A-Za-z][A-Za-z0-9_]*)+$/u.test(policy.packageName);
  if (typeof policy.purchasesEnabled !== "boolean"
    || typeof policy.subscriptionRevalidationEnabled !== "boolean"
    || typeof policy.voidedPurchaseReconciliationEnabled !== "boolean"
    || !validPackageName
    || (policy.subscriptionRevalidationEnabled && !policy.purchasesEnabled)
    || (policy.voidedPurchaseReconciliationEnabled && !policy.purchasesEnabled)) {
    throw new Error("Google Play application policy is invalid.");
  }
  return { ...policy };
}

// Receipt creation, replay validation, subscription polling, and void reconciliation must all
// observe the exact same application identity for the lifetime of this process.
const CONFIGURED_GOOGLE_PLAY_APPLICATION_POLICY = Object.freeze(exactGooglePlayApplicationPolicy({
  purchasesEnabled: config.googlePlayPurchasesEnabled,
  subscriptionRevalidationEnabled: config.googlePlaySubscriptionRevalidationEnabled,
  voidedPurchaseReconciliationEnabled: config.googlePlayVoidedPurchaseReconciliationEnabled,
  packageName: config.googlePlayPackageName,
}));

export function googlePlayApplicationPolicy(
  policy?: GooglePlayApplicationPolicy,
): GooglePlayApplicationPolicy {
  return policy === undefined
    ? CONFIGURED_GOOGLE_PLAY_APPLICATION_POLICY
    : exactGooglePlayApplicationPolicy(policy);
}

function exactPolicyInteger(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Google Play ${label} policy is invalid.`);
  }
  return value;
}

export interface GooglePlaySchedulingPolicy {
  readonly subscriptionRevalidationCadenceSeconds: number;
  readonly subscriptionSchedulerIntervalSeconds: number;
  readonly subscriptionRevalidationBatchSize: number;
  readonly voidedPurchaseSchedulerIntervalSeconds: number;
}

function exactGooglePlaySchedulingPolicy(
  policy: GooglePlaySchedulingPolicy,
): GooglePlaySchedulingPolicy {
  return {
    subscriptionRevalidationCadenceSeconds: exactPolicyInteger(
      policy.subscriptionRevalidationCadenceSeconds,
      "subscription revalidation cadence",
      300,
      86_400,
    ),
    subscriptionSchedulerIntervalSeconds: exactPolicyInteger(
      policy.subscriptionSchedulerIntervalSeconds,
      "subscription scheduler interval",
      30,
      3_600,
    ),
    subscriptionRevalidationBatchSize: exactPolicyInteger(
      policy.subscriptionRevalidationBatchSize,
      "subscription revalidation batch size",
      1,
      1_000,
    ),
    voidedPurchaseSchedulerIntervalSeconds: exactPolicyInteger(
      policy.voidedPurchaseSchedulerIntervalSeconds,
      "voided-purchase scheduler interval",
      60,
      3_600,
    ),
  };
}

// Receipt creation and two background workers share this provider schedule. Resolve all four
// values before traffic so one process cannot publish a revalidation cursor under one cadence and
// later poll or batch it under independently re-read mutable configuration.
const CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY = Object.freeze(exactGooglePlaySchedulingPolicy({
  subscriptionRevalidationCadenceSeconds: config.googlePlaySubscriptionRevalidationCadenceSeconds,
  subscriptionSchedulerIntervalSeconds: config.googlePlaySubscriptionSchedulerIntervalSeconds,
  subscriptionRevalidationBatchSize: config.googlePlaySubscriptionRevalidationBatchSize,
  voidedPurchaseSchedulerIntervalSeconds: config.googlePlayVoidedPurchaseSchedulerIntervalSeconds,
}));

export function googlePlaySchedulingPolicy(
  policy?: GooglePlaySchedulingPolicy,
): GooglePlaySchedulingPolicy {
  return policy === undefined
    ? CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY
    : exactGooglePlaySchedulingPolicy(policy);
}

/**
 * How long a nonterminal subscription receipt may wait before its next provider check.
 *
 * Receipt creation and later revalidation must use the same exact value. Otherwise one malformed
 * deployment setting can write a cursor that disagrees with the scheduler policy or even becomes
 * an invalid Date, consuming provider proof without leaving recoverable polling authority.
 */
export function googlePlaySubscriptionRevalidationCadenceSeconds(
  value?: number,
): number {
  return value === undefined
    ? CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY.subscriptionRevalidationCadenceSeconds
    : exactPolicyInteger(value, "subscription revalidation cadence", 300, 86_400);
}

/** Bounded polling frequency for the leased subscription revalidation worker. */
export function googlePlaySubscriptionSchedulerIntervalSeconds(
  value?: number,
): number {
  return value === undefined
    ? CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY.subscriptionSchedulerIntervalSeconds
    : exactPolicyInteger(value, "subscription scheduler interval", 30, 3_600);
}

/** Maximum number of complete durable receipts selected by one leased provider sweep. */
export function googlePlaySubscriptionRevalidationBatchSize(
  value?: number,
): number {
  return value === undefined
    ? CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY.subscriptionRevalidationBatchSize
    : exactPolicyInteger(value, "subscription revalidation batch size", 1, 1_000);
}

/** Bounded polling frequency for the delayed voided-purchase chargeback worker. */
export function googlePlayVoidedPurchaseSchedulerIntervalSeconds(
  value?: number,
): number {
  return value === undefined
    ? CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY.voidedPurchaseSchedulerIntervalSeconds
    : exactPolicyInteger(value, "voided-purchase scheduler interval", 60, 3_600);
}
