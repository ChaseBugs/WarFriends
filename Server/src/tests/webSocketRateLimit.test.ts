import assert from "node:assert/strict";
import test from "node:test";
import {
  WebSocketRateLimiter,
  webSocketRateLimitKey,
  webSocketPayloadLimit,
  webSocketViolationLimit,
} from "../services/webSocketRateLimitService";

test("WebSocket distributed keys hide and domain-separate stable identities", () => {
  const key = webSocketRateLimitKey("player:abc", "secret");
  assert.equal(key.length, 64);
  assert.equal(key.includes("abc"), false);
  assert.notEqual(key, webSocketRateLimitKey("player:abcd", "secret"));
});

test("WebSocket token bucket rejects a burst and refills continuously", () => {
  const limiter = new WebSocketRateLimiter(3, 6);
  assert.deepEqual(limiter.consume(1_000), { allowed: true, remaining: 2, retryAfterSeconds: 0 });
  assert.equal(limiter.consume(1_000).allowed, true);
  assert.equal(limiter.consume(1_000).allowed, true);
  assert.deepEqual(limiter.consume(1_000), { allowed: false, remaining: 0, retryAfterSeconds: 2 });
  assert.equal(limiter.consume(2_999).allowed, false);
  assert.equal(limiter.consume(3_000).allowed, true);
});

test("WebSocket limiter grants nothing when the clock moves backwards", () => {
  const limiter = new WebSocketRateLimiter(1, 10);
  assert.equal(limiter.consume(10_000).allowed, true);
  assert.equal(limiter.consume(9_000).allowed, false);
  assert.equal(limiter.consume(20_000).allowed, true);
});

test("WebSocket safety configuration is clamped to useful hard bounds", () => {
  const limiter = new WebSocketRateLimiter(Number.NaN, -20);
  assert.equal(limiter.capacity, 120);
  assert.equal(limiter.windowMs, 1_000);
  assert.equal(webSocketPayloadLimit(Number.NaN), 65_536);
  assert.equal(webSocketPayloadLimit(1), 1_024);
  assert.equal(webSocketPayloadLimit(9_999_999), 1_048_576);
  assert.equal(webSocketViolationLimit(0), 1);
  assert.equal(webSocketViolationLimit(500), 100);
});
