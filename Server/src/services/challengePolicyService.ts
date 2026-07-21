import { config } from "../config";

export const MIN_CHALLENGE_TTL_SECONDS = 60;
export const MAX_CHALLENGE_TTL_SECONDS = 7 * 24 * 60 * 60;

/**
 * Exact lifetime assigned to a newly created challenge message.
 *
 * Historical rows validate their own one-minute-to-seven-day interval because they do not retain
 * a policy version. New rows must not floor, clamp, or replace a damaged deployment value: doing
 * so would publish a durable invitation lifetime different from the one the operator configured.
 */
export function challengeTtlSeconds(value = config.challengeTtlSeconds): number {
  if (!Number.isSafeInteger(value)
    || value < MIN_CHALLENGE_TTL_SECONDS
    || value > MAX_CHALLENGE_TTL_SECONDS) {
    throw new Error("Challenge TTL policy is invalid.");
  }
  return value;
}
