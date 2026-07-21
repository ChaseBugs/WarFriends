import { config } from "../config";

function exactAbuseLimit(value: number, label: string, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < 1 || value > maximum) {
    throw new Error(`${label} abuse-limit policy is invalid.`);
  }
  return value;
}

/** Exact number of player-authored direct/challenge attempts admitted per minute. */
export function outgoingMessageRateLimitMaximum(
  value = config.outgoingMessagesPerMinute,
): number {
  return exactAbuseLimit(value, "Outgoing-message", 1_000);
}

/** Exact number of player reports admitted per fixed one-hour window. */
export function reportRateLimitMaximum(value = config.reportMaxPerHour): number {
  return exactAbuseLimit(value, "Report", 100);
}
