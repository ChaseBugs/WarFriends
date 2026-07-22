import { config } from "../config";

export interface GooglePlayApplicationPolicy {
  readonly purchasesEnabled: boolean;
  readonly subscriptionRevalidationEnabled: boolean;
  readonly voidedPurchaseReconciliationEnabled: boolean;
  readonly rtdnEnabled: boolean;
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
    || typeof policy.rtdnEnabled !== "boolean"
    || !validPackageName
    || (policy.subscriptionRevalidationEnabled && !policy.purchasesEnabled)
    || (policy.voidedPurchaseReconciliationEnabled && !policy.purchasesEnabled)
    || (policy.rtdnEnabled && (!policy.purchasesEnabled
      || !policy.subscriptionRevalidationEnabled
      || !policy.voidedPurchaseReconciliationEnabled))) {
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
  rtdnEnabled: config.googlePlayRtdnEnabled,
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
  readonly rtdnSchedulerIntervalSeconds: number;
  readonly rtdnBatchSize: number;
  readonly rtdnRetentionDays: number;
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
    rtdnSchedulerIntervalSeconds: exactPolicyInteger(
      policy.rtdnSchedulerIntervalSeconds,
      "RTDN scheduler interval",
      10,
      3_600,
    ),
    rtdnBatchSize: exactPolicyInteger(policy.rtdnBatchSize, "RTDN batch size", 1, 1_000),
    rtdnRetentionDays: exactPolicyInteger(policy.rtdnRetentionDays, "RTDN retention", 30, 365),
  };
}

// Receipt creation and all three background workers share this provider schedule. Resolve the
// complete seven-value snapshot before traffic so one process cannot publish a receipt/event
// cursor under one cadence or retention policy and later poll it under mutable configuration.
const CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY = Object.freeze(exactGooglePlaySchedulingPolicy({
  subscriptionRevalidationCadenceSeconds: config.googlePlaySubscriptionRevalidationCadenceSeconds,
  subscriptionSchedulerIntervalSeconds: config.googlePlaySubscriptionSchedulerIntervalSeconds,
  subscriptionRevalidationBatchSize: config.googlePlaySubscriptionRevalidationBatchSize,
  voidedPurchaseSchedulerIntervalSeconds: config.googlePlayVoidedPurchaseSchedulerIntervalSeconds,
  rtdnSchedulerIntervalSeconds: config.googlePlayRtdnSchedulerIntervalSeconds,
  rtdnBatchSize: config.googlePlayRtdnBatchSize,
  rtdnRetentionDays: config.googlePlayRtdnRetentionDays,
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

export interface GooglePlayRtdnIdentityPolicy {
  readonly enabled: boolean;
  readonly audience: string;
  readonly serviceAccountEmail: string;
  readonly subscription: string;
}

function exactGooglePlayRtdnIdentityPolicy(
  policy: GooglePlayRtdnIdentityPolicy,
): GooglePlayRtdnIdentityPolicy {
  const exact = (value: unknown, maximum: number): value is string => typeof value === "string"
    && value.length <= maximum
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
  let validAudience = policy.audience === "";
  if (exact(policy.audience, 2_048) && policy.audience !== "") {
    try {
      const parsed = new URL(policy.audience);
      validAudience = parsed.protocol === "https:"
        && parsed.username === ""
        && parsed.password === ""
        && parsed.hash === "";
    } catch {
      validAudience = false;
    }
  }
  const validEmail = policy.serviceAccountEmail === "" || (exact(policy.serviceAccountEmail, 254)
    && /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.gserviceaccount\.com$/u.test(policy.serviceAccountEmail));
  const validSubscription = policy.subscription === "" || (exact(policy.subscription, 512)
    && /^projects\/[^/\s]{1,128}\/subscriptions\/[^/\s]{1,255}$/u.test(policy.subscription));
  if (typeof policy.enabled !== "boolean"
    || !validAudience
    || !validEmail
    || !validSubscription
    || (policy.enabled && (!policy.audience || !policy.serviceAccountEmail || !policy.subscription))) {
    throw new Error("Google Play RTDN identity policy is invalid.");
  }
  return { ...policy };
}

const CONFIGURED_GOOGLE_PLAY_RTDN_IDENTITY_POLICY = Object.freeze(exactGooglePlayRtdnIdentityPolicy({
  enabled: CONFIGURED_GOOGLE_PLAY_APPLICATION_POLICY.rtdnEnabled,
  audience: config.googlePlayRtdnAudience,
  serviceAccountEmail: config.googlePlayRtdnServiceAccountEmail,
  subscription: config.googlePlayRtdnSubscription,
}));

/** Exact OIDC and Pub/Sub resource identity accepted for the lifetime of this process. */
export function googlePlayRtdnIdentityPolicy(
  policy?: GooglePlayRtdnIdentityPolicy,
): GooglePlayRtdnIdentityPolicy {
  return policy === undefined
    ? CONFIGURED_GOOGLE_PLAY_RTDN_IDENTITY_POLICY
    : exactGooglePlayRtdnIdentityPolicy(policy);
}

export function googlePlayRtdnSchedulerIntervalSeconds(value?: number): number {
  return value === undefined
    ? CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY.rtdnSchedulerIntervalSeconds
    : exactPolicyInteger(value, "RTDN scheduler interval", 10, 3_600);
}

export function googlePlayRtdnBatchSize(value?: number): number {
  return value === undefined
    ? CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY.rtdnBatchSize
    : exactPolicyInteger(value, "RTDN batch size", 1, 1_000);
}

export function googlePlayRtdnRetentionDays(value?: number): number {
  return value === undefined
    ? CONFIGURED_GOOGLE_PLAY_SCHEDULING_POLICY.rtdnRetentionDays
    : exactPolicyInteger(value, "RTDN retention", 30, 365);
}
