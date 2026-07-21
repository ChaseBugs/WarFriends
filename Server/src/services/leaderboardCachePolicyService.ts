import { config } from "../config";

/** Bound the lifetime of one non-authoritative leaderboard snapshot. */
export function exactLeaderboardCacheTtlSeconds(value: number): number {
  if (!Number.isSafeInteger(value) || value < 1 || value > 3_600) {
    throw new Error("Leaderboard cache TTL policy is invalid.");
  }
  return value;
}

// Resolve once at startup so all refreshes use the same reviewed expiry. Redis is only a cache;
// malformed deployment policy must not produce a permanent sorted set or a one-second hot loop.
const CONFIGURED_LEADERBOARD_CACHE_POLICY = Object.freeze({
  ttlSeconds: exactLeaderboardCacheTtlSeconds(config.redisLeaderboardTtl),
});

export function leaderboardCachePolicy(policy?: { readonly ttlSeconds: number }): {
  readonly ttlSeconds: number;
} {
  return policy === undefined
    ? CONFIGURED_LEADERBOARD_CACHE_POLICY
    : { ttlSeconds: exactLeaderboardCacheTtlSeconds(policy.ttlSeconds) };
}
