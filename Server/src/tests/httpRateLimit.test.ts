import assert from "node:assert/strict";
import test from "node:test";
import { HttpRateLimiter, httpRateLimitKey } from "../services/httpRateLimitService";
import { trafficPolicy } from "../services/trafficPolicyService";

test("HTTP and WebSocket limits are one immutable startup traffic policy", () => {
  assert.equal(Object.isFrozen(trafficPolicy()), true);
  assert.deepEqual(trafficPolicy(), {
    trustedProxyHops: 0,
    httpRequestCapacity: 120,
    httpWindowSeconds: 60,
    httpMemoryEntryCap: 10_000,
    webSocketPayloadBytes: 65_536,
    webSocketMessageCapacity: 120,
    webSocketWindowSeconds: 10,
    webSocketViolationLimit: 3,
  });
});

test("trusted proxy hops preserve an exact bounded deployment topology", () => {
  const configured = trafficPolicy();
  assert.deepEqual(trafficPolicy({ ...configured, trustedProxyHops: 3 }), {
    ...configured,
    trustedProxyHops: 3,
  });
  for (const trustedProxyHops of [Number.NaN, Number.POSITIVE_INFINITY, -1, 0.5, 33]) {
    assert.throws(
      () => trafficPolicy({ ...configured, trustedProxyHops }),
      /Traffic trusted-proxy hop-count policy is invalid/,
    );
  }
});

test("HTTP token bucket rejects a burst and refills continuously", () => {
  const limiter = new HttpRateLimiter(3, 6, 100);
  assert.deepEqual(limiter.consume("client", 1_000), {
    allowed: true, limit: 3, remaining: 2, retryAfterSeconds: 0,
  });
  assert.equal(limiter.consume("client", 1_000).allowed, true);
  assert.equal(limiter.consume("client", 1_000).allowed, true);
  const rejected = limiter.consume("client", 1_000);
  assert.equal(rejected.allowed, false);
  assert.equal(rejected.retryAfterSeconds, 2);

  assert.equal(limiter.consume("client", 2_999).allowed, false);
  assert.equal(limiter.consume("client", 3_000).allowed, true);
});

test("HTTP limiter has a hard LRU memory bound", () => {
  const limiter = new HttpRateLimiter(120, 1, 100);
  assert.equal(limiter.capacity, 120);
  assert.equal(limiter.windowMs, 1_000);
  assert.equal(limiter.maxEntries, 100);

  for (let index = 0; index < 130; index += 1) limiter.consume(`client-${index}`, index);
  assert.equal(limiter.size(), 100);
});

test("HTTP limiter rejects policy values previously floored, clamped, or defaulted", () => {
  for (const args of [
    [Number.NaN, 60, 10_000],
    [120.5, 60, 10_000],
    [0, 60, 10_000],
    [100_001, 60, 10_000],
    [120, 0, 10_000],
    [120, 86_401, 10_000],
    [120, 60, 99],
    [120, 60, 1_000_001],
  ] as const) {
    assert.throws(() => new HttpRateLimiter(args[0], args[1], args[2]), /Traffic HTTP .* policy is invalid/);
  }
});

test("HTTP limiter keys are deterministic, secret-bound, and hide raw addresses", () => {
  const first = httpRateLimitKey("203.0.113.9", "secret-a");
  assert.equal(first, httpRateLimitKey("203.0.113.9", "secret-a"));
  assert.notEqual(first, httpRateLimitKey("203.0.113.9", "secret-b"));
  assert.notEqual(first, httpRateLimitKey("203.0.113.10", "secret-a"));
  assert.equal(first.includes("203.0.113.9"), false);
  assert.match(first, /^[0-9a-f]{64}$/u);
});
