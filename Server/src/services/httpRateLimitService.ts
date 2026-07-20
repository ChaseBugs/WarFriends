import { createHmac } from "crypto";
import type { NextFunction, Request, Response } from "express";
import { config } from "../config";
import logger from "../utils/logger";
import { consumeDistributedToken } from "./distributedRateLimitService";

interface Bucket {
  tokens: number;
  lastRefillAt: number;
  lastSeenAt: number;
}

export interface RateLimitDecision {
  allowed: boolean;
  limit: number;
  remaining: number;
  retryAfterSeconds: number;
}

function boundedInteger(value: number, fallback: number, minimum: number, maximum: number): number {
  return Number.isFinite(value)
    ? Math.min(maximum, Math.max(minimum, Math.floor(value)))
    : fallback;
}

/**
 * Bounded in-process token bucket used at the HTTP boundary.
 *
 * Tokens refill continuously rather than at fixed-window boundaries, preventing a caller from
 * doubling its burst by sending once immediately before and once immediately after a reset. The
 * entry cap prevents a stream of spoofed/unique addresses from growing memory without limit.
 */
export class HttpRateLimiter {
  readonly capacity: number;
  readonly windowMs: number;
  readonly maxEntries: number;
  private readonly buckets = new Map<string, Bucket>();

  constructor(capacity: number, windowSeconds: number, maxEntries: number) {
    this.capacity = boundedInteger(capacity, 120, 1, 100_000);
    this.windowMs = boundedInteger(windowSeconds, 60, 1, 86_400) * 1_000;
    this.maxEntries = boundedInteger(maxEntries, 10_000, 100, 1_000_000);
  }

  consume(key: string, now = Date.now()): RateLimitDecision {
    let bucket = this.buckets.get(key);
    if (!bucket) {
      this.reserveEntry(key, now);
      bucket = { tokens: this.capacity, lastRefillAt: now, lastSeenAt: now };
    } else {
      const elapsed = Math.max(0, now - bucket.lastRefillAt);
      bucket.tokens = Math.min(this.capacity, bucket.tokens + elapsed * this.capacity / this.windowMs);
      bucket.lastRefillAt = Math.max(bucket.lastRefillAt, now);
      bucket.lastSeenAt = Math.max(bucket.lastSeenAt, now);
      // Refresh insertion order so bounded eviction removes the least recently used key.
      this.buckets.delete(key);
    }
    this.buckets.set(key, bucket);

    if (bucket.tokens >= 1) {
      bucket.tokens -= 1;
      return {
        allowed: true,
        limit: this.capacity,
        remaining: Math.floor(bucket.tokens),
        retryAfterSeconds: 0,
      };
    }

    const millisecondsUntilToken = (1 - bucket.tokens) * this.windowMs / this.capacity;
    return {
      allowed: false,
      limit: this.capacity,
      remaining: 0,
      retryAfterSeconds: Math.max(1, Math.ceil(millisecondsUntilToken / 1_000)),
    };
  }

  size(): number {
    return this.buckets.size;
  }

  private reserveEntry(key: string, now: number): void {
    if (this.buckets.size < this.maxEntries) return;

    // A fully refilled idle bucket carries no useful enforcement state. Remove these first, then
    // evict only the oldest remaining key if the map is still at its hard memory ceiling.
    const idleBefore = now - this.windowMs;
    for (const [candidate, bucket] of this.buckets) {
      if (bucket.lastSeenAt <= idleBefore) this.buckets.delete(candidate);
      if (this.buckets.size < this.maxEntries) return;
    }
    const oldest = this.buckets.keys().next().value as string | undefined;
    if (oldest !== undefined && oldest !== key) this.buckets.delete(oldest);
  }
}

/** Never retain or log a raw address; AUTH_SECRET turns it into a deployment-local opaque key. */
export function httpRateLimitKey(address: string, secret: string): string {
  return createHmac("sha256", secret).update("http-rate-limit\0").update(address).digest("hex");
}

export function createHttpRateLimitMiddleware(
  limiter = new HttpRateLimiter(
    config.httpRateLimitMaxRequests,
    config.httpRateLimitWindowSeconds,
    config.httpRateLimitMaxEntries,
  ),
) {
  return (req: Request, res: Response, next: NextFunction): void => {
    // Monitoring must remain able to determine that the process is alive, and a browser's CORS
    // preflight does not execute game logic. Every actual API request still consumes one token.
    if (req.method === "OPTIONS" || req.path === "/health" || req.path === "/metrics") {
      next();
      return;
    }

    const key = httpRateLimitKey(req.ip || req.socket.remoteAddress || "unknown", config.authSecret);
    void consumeDistributedToken("http", key, limiter.capacity, limiter.windowMs)
      .then((distributed) => {
        const decision: RateLimitDecision = distributed
          ? { ...distributed, limit: limiter.capacity }
          : limiter.consume(key);
        res.setHeader("RateLimit-Limit", decision.limit);
        res.setHeader("RateLimit-Remaining", decision.remaining);
        if (decision.allowed) {
          next();
          return;
        }

        res.setHeader("Retry-After", decision.retryAfterSeconds);
        logger.warnWithEmoji("RATE", "HTTP rate limit exceeded", "SECURITY", {
          clientKey: key.slice(0, 12),
          retryAfterSeconds: decision.retryAfterSeconds,
          distributed: Boolean(distributed),
        });
        res.status(429).json({ Code: 10, Message: "Too many requests. Try again later." });
      })
      .catch(next);
  };
}
