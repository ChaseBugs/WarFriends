import { config } from "../config";

function exactAbuseLimit(value: number, label: string, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < 1 || value > maximum) {
    throw new Error(`${label} abuse-limit policy is invalid.`);
  }
  return value;
}

export interface AbuseLimitPolicy {
  readonly outgoingMessagesPerMinute: number;
  readonly reportsPerHour: number;
}

/**
 * Resolve both player-authored abuse thresholds before any atomic reservation can occur.
 *
 * The durable counters retain global sentinels so historical rows survive reviewed policy changes,
 * but one running process must not re-read different admission maxima between requests. Freezing
 * the exact pair at module startup also exposes malformed deployment policy before traffic starts.
 */
function exactAbuseLimitPolicy(policy: AbuseLimitPolicy): AbuseLimitPolicy {
  return {
    outgoingMessagesPerMinute: exactAbuseLimit(
      policy.outgoingMessagesPerMinute,
      "Outgoing-message",
      1_000,
    ),
    reportsPerHour: exactAbuseLimit(policy.reportsPerHour, "Report", 100),
  };
}

const CONFIGURED_ABUSE_LIMIT_POLICY = Object.freeze(exactAbuseLimitPolicy({
  outgoingMessagesPerMinute: config.outgoingMessagesPerMinute,
  reportsPerHour: config.reportMaxPerHour,
}));

export function abuseLimitPolicy(policy?: AbuseLimitPolicy): AbuseLimitPolicy {
  return policy === undefined
    ? CONFIGURED_ABUSE_LIMIT_POLICY
    : exactAbuseLimitPolicy(policy);
}

/** Exact number of player-authored direct/challenge attempts admitted per minute. */
export function outgoingMessageRateLimitMaximum(
  value?: number,
): number {
  return value === undefined
    ? CONFIGURED_ABUSE_LIMIT_POLICY.outgoingMessagesPerMinute
    : exactAbuseLimit(value, "Outgoing-message", 1_000);
}

/** Exact number of player reports admitted per fixed one-hour window. */
export function reportRateLimitMaximum(value?: number): number {
  return value === undefined
    ? CONFIGURED_ABUSE_LIMIT_POLICY.reportsPerHour
    : exactAbuseLimit(value, "Report", 100);
}
