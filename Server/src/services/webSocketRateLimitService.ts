export interface WebSocketRateLimitDecision {
  allowed: boolean;
  remaining: number;
  retryAfterSeconds: number;
}

/** Validate the ws library's per-frame allocation before it accepts a payload into application code. */
export function webSocketPayloadLimit(value?: number): number {
  return value === undefined
    ? trafficPolicy().webSocketPayloadBytes
    : exactTrafficPolicyInteger(value, "WebSocket payload-byte-limit", 1_024, 1_048_576);
}

/** Require an exact repeated-violation tolerance so configuration cannot disable disconnect. */
export function webSocketViolationLimit(value?: number): number {
  return value === undefined
    ? trafficPolicy().webSocketViolationLimit
    : exactTrafficPolicyInteger(value, "WebSocket violation-limit", 1, 100);
}

/**
 * Continuous-refill token bucket owned by one WebSocket connection.
 *
 * A per-connection object needs no unbounded address/player map and disappears when the socket
 * closes. Continuous refill prevents a double burst at fixed-window boundaries. Backward clock
 * movement grants no tokens, and a large forward jump can refill only to the configured capacity.
 */
export class WebSocketRateLimiter {
  readonly capacity: number;
  readonly windowMs: number;
  private tokens: number;
  private lastRefillAt: number | null = null;

  constructor(capacity: number, windowSeconds: number) {
    this.capacity = exactTrafficPolicyInteger(capacity, "WebSocket message-capacity", 1, 100_000);
    this.windowMs = exactTrafficPolicyInteger(windowSeconds, "WebSocket window-seconds", 1, 86_400) * 1_000;
    this.tokens = this.capacity;
  }

  consume(now = Date.now()): WebSocketRateLimitDecision {
    if (this.lastRefillAt == null) {
      this.lastRefillAt = now;
    } else {
      const elapsed = Math.max(0, now - this.lastRefillAt);
      this.tokens = Math.min(this.capacity, this.tokens + elapsed * this.capacity / this.windowMs);
      this.lastRefillAt = Math.max(this.lastRefillAt, now);
    }

    if (this.tokens >= 1) {
      this.tokens -= 1;
      return { allowed: true, remaining: Math.floor(this.tokens), retryAfterSeconds: 0 };
    }
    const millisecondsUntilToken = (1 - this.tokens) * this.windowMs / this.capacity;
    return {
      allowed: false,
      remaining: 0,
      retryAfterSeconds: Math.max(1, Math.ceil(millisecondsUntilToken / 1_000)),
    };
  }
}

/** HMAC-hide either the pre-auth address or authenticated player ID with a WS-specific domain. */
export function webSocketRateLimitKey(identity: string, secret = config.authSecret): string {
  return createHmac("sha256", secret).update("websocket-rate-limit\0").update(identity).digest("hex");
}

export async function consumeWebSocketRateLimit(
  limiter: WebSocketRateLimiter,
  identityKey: string,
): Promise<WebSocketRateLimitDecision & { distributed: boolean }> {
  const distributed = await consumeDistributedToken("ws", identityKey, limiter.capacity, limiter.windowMs);
  return distributed
    ? { ...distributed, distributed: true }
    : { ...limiter.consume(), distributed: false };
}
import { createHmac } from "crypto";
import { config } from "../config";
import { consumeDistributedToken } from "./distributedRateLimitService";
import { exactTrafficPolicyInteger, trafficPolicy } from "./trafficPolicyService";
