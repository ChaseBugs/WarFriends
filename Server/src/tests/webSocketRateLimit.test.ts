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

test("WebSocket safety configuration requires exact bounded integers", () => {
  assert.equal(webSocketPayloadLimit(65_536), 65_536);
  assert.equal(webSocketViolationLimit(3), 3);
  for (const args of [
    [Number.NaN, 10],
    [120.5, 10],
    [0, 10],
    [100_001, 10],
    [120, 0],
    [120, 86_401],
  ] as const) {
    assert.throws(() => new WebSocketRateLimiter(args[0], args[1]), /Traffic WebSocket .* policy is invalid/);
  }
  for (const value of [Number.NaN, 1, 1_048_577, 65_536.5]) {
    assert.throws(() => webSocketPayloadLimit(value), /payload-byte-limit policy is invalid/);
  }
  for (const value of [Number.NaN, 0, 101, 3.5]) {
    assert.throws(() => webSocketViolationLimit(value), /violation-limit policy is invalid/);
  }
});
