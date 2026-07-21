import { config } from "../config";

export const MIN_CHALLENGE_TTL_SECONDS = 60;
export const MAX_CHALLENGE_TTL_SECONDS = 7 * 24 * 60 * 60;

export interface ChallengeLifetimePolicy {
  readonly ttlSeconds: number;
}

function exactChallengeTtlSeconds(value: number): number {
  if (!Number.isSafeInteger(value)
    || value < MIN_CHALLENGE_TTL_SECONDS
    || value > MAX_CHALLENGE_TTL_SECONDS) {
    throw new Error("Challenge TTL policy is invalid.");
  }
  return value;
}

// A challenge stores its absolute expiry but no policy version. Resolve the deployment lifetime
// once so all invitations issued by one process use one auditable authority snapshot.
const CONFIGURED_CHALLENGE_LIFETIME_POLICY = Object.freeze({
  ttlSeconds: exactChallengeTtlSeconds(config.challengeTtlSeconds),
});

export function challengeLifetimePolicy(
  policy?: ChallengeLifetimePolicy,
): ChallengeLifetimePolicy {
  return policy === undefined
    ? CONFIGURED_CHALLENGE_LIFETIME_POLICY
    : { ttlSeconds: exactChallengeTtlSeconds(policy.ttlSeconds) };
}

/**
 * Exact lifetime assigned to a newly created challenge message.
 *
 * Historical rows validate their own one-minute-to-seven-day interval because they do not retain
 * a policy version. New rows must not floor, clamp, or replace a damaged deployment value: doing
 * so would publish a durable invitation lifetime different from the one the operator configured.
 */
export function challengeTtlSeconds(value?: number): number {
  return value === undefined
    ? CONFIGURED_CHALLENGE_LIFETIME_POLICY.ttlSeconds
    : exactChallengeTtlSeconds(value);
}
