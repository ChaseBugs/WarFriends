import assert from "node:assert/strict";
import test from "node:test";
import {
  challengeLifetimePolicy,
  challengeTtlSeconds,
  MAX_CHALLENGE_TTL_SECONDS,
  MIN_CHALLENGE_TTL_SECONDS,
} from "../services/challengePolicyService";

test("new challenge lifetime is immutable startup authority", () => {
  assert.equal(Object.isFrozen(challengeLifetimePolicy()), true);
  assert.deepEqual(challengeLifetimePolicy(), { ttlSeconds: 86_400 });
  assert.equal(challengeTtlSeconds(), 86_400);
});

test("challenge policy preserves exact supported invitation lifetimes", () => {
  assert.equal(challengeTtlSeconds(MIN_CHALLENGE_TTL_SECONDS), 60);
  assert.equal(challengeTtlSeconds(86_400), 86_400);
  assert.equal(challengeTtlSeconds(MAX_CHALLENGE_TTL_SECONDS), 604_800);
});

test("challenge policy rejects values previously floored, clamped, or substituted", () => {
  for (const value of [
    Number.NaN,
    Number.POSITIVE_INFINITY,
    -1,
    0,
    MIN_CHALLENGE_TTL_SECONDS - 1,
    MIN_CHALLENGE_TTL_SECONDS + 0.5,
    MAX_CHALLENGE_TTL_SECONDS + 1,
  ]) {
    assert.throws(() => challengeTtlSeconds(value), /Challenge TTL policy is invalid/);
  }
});
