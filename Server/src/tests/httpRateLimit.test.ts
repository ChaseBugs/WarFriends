import assert from "node:assert/strict";
import test from "node:test";
import { HttpRateLimiter, httpRateLimitKey } from "../services/httpRateLimitService";

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

test("HTTP limiter has a hard LRU memory bound and clamps unsafe configuration", () => {
  const limiter = new HttpRateLimiter(Number.NaN, -1, 2);
  assert.equal(limiter.capacity, 120);
  assert.equal(limiter.windowMs, 1_000);
  assert.equal(limiter.maxEntries, 100);

  for (let index = 0; index < 130; index += 1) limiter.consume(`client-${index}`, index);
  assert.equal(limiter.size(), 100);
});

test("HTTP limiter keys are deterministic, secret-bound, and hide raw addresses", () => {
  const first = httpRateLimitKey("203.0.113.9", "secret-a");
  assert.equal(first, httpRateLimitKey("203.0.113.9", "secret-a"));
  assert.notEqual(first, httpRateLimitKey("203.0.113.9", "secret-b"));
  assert.notEqual(first, httpRateLimitKey("203.0.113.10", "secret-a"));
  assert.equal(first.includes("203.0.113.9"), false);
  assert.match(first, /^[0-9a-f]{64}$/u);
});
