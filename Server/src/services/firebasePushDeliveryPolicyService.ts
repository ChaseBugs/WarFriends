import { config } from "../config";

export interface FirebasePushDeliveryPolicy {
  readonly schedulerIntervalSeconds: number;
  readonly batchSize: number;
  readonly initialRetrySeconds: number;
  readonly maximumRetrySeconds: number;
}

function exactInteger(value: number, minimum: number, maximum: number): boolean {
  return Number.isSafeInteger(value) && value >= minimum && value <= maximum;
}

/**
 * Validate the complete durable-delivery schedule before a worker or retry row can use it.
 *
 * The initial retry is never below one minute because FCM explicitly requires at least that
 * delay for quota failures. The maximum may equal the initial delay but never precede it. Keeping
 * all values bounded also prevents a malformed environment value from creating a hot retry loop,
 * an unbounded provider burst, or a timestamp that JavaScript cannot represent safely.
 */
export function exactFirebasePushDeliveryPolicy(
  policy: FirebasePushDeliveryPolicy,
): FirebasePushDeliveryPolicy {
  if (!exactInteger(policy.schedulerIntervalSeconds, 5, 3_600)
    || !exactInteger(policy.batchSize, 1, 1_000)
    || !exactInteger(policy.initialRetrySeconds, 60, 86_400)
    || !exactInteger(policy.maximumRetrySeconds, policy.initialRetrySeconds, 7 * 86_400)) {
    throw new Error("Firebase push delivery policy is invalid.");
  }
  return { ...policy };
}

const CONFIGURED_FIREBASE_PUSH_DELIVERY_POLICY = Object.freeze(exactFirebasePushDeliveryPolicy({
  schedulerIntervalSeconds: config.firebasePushSchedulerIntervalSeconds,
  batchSize: config.firebasePushBatchSize,
  initialRetrySeconds: config.firebasePushInitialRetrySeconds,
  maximumRetrySeconds: config.firebasePushMaximumRetrySeconds,
}));

export function firebasePushDeliveryPolicy(
  policy?: FirebasePushDeliveryPolicy,
): FirebasePushDeliveryPolicy {
  return policy === undefined
    ? CONFIGURED_FIREBASE_PUSH_DELIVERY_POLICY
    : exactFirebasePushDeliveryPolicy(policy);
}

/** Saturating exponential backoff; attempt zero means the first provider failure. */
export function firebasePushRetryDelaySeconds(
  attempt: number,
  policy: FirebasePushDeliveryPolicy = firebasePushDeliveryPolicy(),
): number {
  const exact = firebasePushDeliveryPolicy(policy);
  if (!Number.isSafeInteger(attempt) || attempt < 0) {
    throw new Error("Firebase push attempt is invalid.");
  }
  // Once the shift is large enough to exceed every permitted maximum, avoid floating-point
  // multiplication altogether. Attempts remain audit history and never control unbounded time.
  if (attempt >= 31) return exact.maximumRetrySeconds;
  return Math.min(exact.maximumRetrySeconds, exact.initialRetrySeconds * (2 ** attempt));
}
