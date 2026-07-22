import { RedisKeys } from "../constants";
import { exactRedisIntegerReply, isRedisAvailable, redisEval, redisTimeMs } from "../redis";

export interface DistributedRateLimitDecision {
  allowed: boolean;
  remaining: number;
  retryAfterSeconds: number;
}

// Redis TIME gives every node one clock. It is read immediately before this deterministic script
// because older Redis versions forbid writes after TIME inside Lua. The hash mutation itself stays
// atomic; the tiny read-to-script delay can only under-refill, never grant an extra token.
const tokenBucketScript = `
local capacity = tonumber(ARGV[1])
local windowMs = tonumber(ARGV[2])
local nowMs = tonumber(ARGV[3])
local values = redis.call('HMGET', KEYS[1], 'tokens', 'refilledAt')
local tokens = tonumber(values[1]) or capacity
local refilledAt = tonumber(values[2]) or nowMs
local elapsed = math.max(0, nowMs - refilledAt)
tokens = math.min(capacity, tokens + elapsed * capacity / windowMs)
local allowed = 0
local retryMs = 0
if tokens >= 1 then
  tokens = tokens - 1
  allowed = 1
else
  retryMs = math.ceil((1 - tokens) * windowMs / capacity)
end
redis.call('HMSET', KEYS[1], 'tokens', tostring(tokens), 'refilledAt', tostring(nowMs))
redis.call('PEXPIRE', KEYS[1], math.max(1000, math.ceil(windowMs * 2)))
return { allowed, math.floor(tokens), math.max(0, math.ceil(retryMs / 1000)) }
`;

/**
 * Validate the complete Lua token-bucket reply before it can grant or deny shared capacity.
 *
 * The script emits RESP integers. Coercing strings/Booleans or clamping impossible counters would
 * turn a damaged Redis boundary into believable rate-limit authority. Cross-field validation also
 * proves the only two legal states: an allowed request has zero retry delay, while a denied request
 * has no whole token remaining and a bounded positive wait.
 */
export function parseDistributedRateLimitDecision(
  result: unknown,
  capacity: number,
  windowMs: number,
): DistributedRateLimitDecision | null {
  if (!Number.isSafeInteger(capacity)
    || capacity < 1
    || !Number.isSafeInteger(windowMs)
    || windowMs < 1
    || !Array.isArray(result)
    || result.length !== 3) return null;
  const allowed = exactRedisIntegerReply(result[0], 0, 1);
  const remaining = exactRedisIntegerReply(result[1], 0, capacity - 1);
  const maximumRetrySeconds = Math.max(1, Math.ceil(windowMs / capacity / 1_000));
  const retryAfterSeconds = exactRedisIntegerReply(result[2], 0, maximumRetrySeconds);
  if (allowed === null || remaining === null || retryAfterSeconds === null) return null;
  if (allowed === 1) {
    return retryAfterSeconds === 0 ? { allowed: true, remaining, retryAfterSeconds: 0 } : null;
  }
  return remaining === 0 && retryAfterSeconds >= 1
    ? { allowed: false, remaining: 0, retryAfterSeconds }
    : null;
}

/** Return null only when Redis is disabled/unavailable so the caller can use its local fallback. */
export async function consumeDistributedToken(
  scope: string,
  identity: string,
  capacity: number,
  windowMs: number,
): Promise<DistributedRateLimitDecision | null> {
  if (!isRedisAvailable()) return null;
  const nowMs = await redisTimeMs();
  if (nowMs === undefined) return null;
  const result = await redisEval(
    tokenBucketScript,
    [RedisKeys.distributedRateLimit(scope, identity)],
    [capacity, windowMs, nowMs],
  );
  return parseDistributedRateLimitDecision(result, capacity, windowMs);
}
