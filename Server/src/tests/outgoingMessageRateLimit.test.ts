import assert from "node:assert/strict";
import test from "node:test";
import {
  outgoingMessageRateLimitAllows,
  outgoingMessageRateLimitKey,
  outgoingMessageRateLimitMaximum,
  validatedOutgoingMessageRateLimit,
} from "../services/outgoingMessageRateLimitService";

test("outgoing-message policy preserves exact supported values and rejects normalization", () => {
  assert.equal(outgoingMessageRateLimitMaximum(1), 1);
  assert.equal(outgoingMessageRateLimitMaximum(20), 20);
  assert.equal(outgoingMessageRateLimitMaximum(1_000), 1_000);
  for (const value of [Number.NaN, Number.POSITIVE_INFINITY, 0, 1_001, 20.9]) {
    assert.throws(() => outgoingMessageRateLimitMaximum(value), /Outgoing-message abuse-limit policy is invalid/);
  }
});

test("outgoing-message admission accepts only the configured atomic reservations", () => {
  assert.equal(outgoingMessageRateLimitAllows(1, 20), true);
  assert.equal(outgoingMessageRateLimitAllows(20, 20), true);
  assert.equal(outgoingMessageRateLimitAllows(21, 20), false);
  assert.equal(outgoingMessageRateLimitAllows(0, 20), false);
  assert.equal(outgoingMessageRateLimitAllows(1.5, 20), false);
  assert.equal(outgoingMessageRateLimitAllows(1_001, 1_000), false);
  assert.equal(outgoingMessageRateLimitAllows(1, Number.NaN), false);
});

test("outgoing-message keys are HMAC-hidden and domain stable", () => {
  const first = outgoingMessageRateLimitKey("player-1");
  assert.match(first, /^[0-9a-f]{64}$/u);
  assert.equal(outgoingMessageRateLimitKey("player-1"), first);
  assert.notEqual(outgoingMessageRateLimitKey("player-2"), first);
  assert.notEqual(outgoingMessageRateLimitKey("player-1", "squad-chat"), first);
});

test("complete outgoing-message rate-limit authority is bounded and ordered", () => {
  const now = new Date("2026-07-21T12:00:00.000Z");
  const key = "a".repeat(64);
  const valid = {
    _id: key,
    key,
    attemptCount: 1_001,
    windowStartedAt: new Date(now.getTime() - 59_999),
    updatedAt: now,
    expiresAt: new Date(now.getTime() + 120_000),
  };
  assert.equal(validatedOutgoingMessageRateLimit(valid, now, key), valid);
  assert.throws(
    () => validatedOutgoingMessageRateLimit({ ...valid, attemptCount: 1_002 }, now, key),
    /rate-limit authority is invalid/,
  );
  assert.throws(
    () => validatedOutgoingMessageRateLimit({ ...valid, windowStartedAt: new Date(now.getTime() + 1) }, now, key),
    /rate-limit authority is invalid/,
  );
  assert.throws(
    () => validatedOutgoingMessageRateLimit({ ...valid, expiresAt: new Date(now.getTime() + 120_001) }, now, key),
    /rate-limit authority is invalid/,
  );
  assert.throws(
    () => validatedOutgoingMessageRateLimit({ ...valid, _id: "b".repeat(64) }, now, key),
    /rate-limit authority is invalid/,
  );
  assert.throws(
    () => validatedOutgoingMessageRateLimit({ ...valid, unexpected: true }, now, key),
    /rate-limit authority is invalid/,
  );
});
