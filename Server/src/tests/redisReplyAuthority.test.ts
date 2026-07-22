import assert from "node:assert/strict";
import test from "node:test";
import { exactRedisIntegerReply, parseRedisTimeReply } from "../redis";
import { parseDistributedRateLimitDecision } from "../services/distributedRateLimitService";

test("Redis integer authority accepts only exact bounded RESP number replies", () => {
  assert.equal(exactRedisIntegerReply(0, 0, 1), 0);
  assert.equal(exactRedisIntegerReply(1, 0, 1), 1);
  for (const value of ["1", true, false, null, [1], 0.5, Number.NaN, 2]) {
    assert.equal(exactRedisIntegerReply(value, 0, 1), null);
  }
  assert.throws(() => exactRedisIntegerReply(1, 2, 1), /bounds are invalid/);
});

test("Redis TIME authority requires canonical seconds and microseconds strings", () => {
  assert.equal(parseRedisTimeReply(["1750000000", "123456"]), 1_750_000_000_123);
  assert.equal(parseRedisTimeReply(["0", "0"]), 0);
  for (const malformed of [
    [1_750_000_000, "123456"],
    ["1750000000", 123_456],
    ["01750000000", "123456"],
    ["1750000000", "0123456"],
    ["1750000000", "1000000"],
    ["-1", "0"],
    ["8640000000001", "0"],
    ["1750000000"],
  ]) {
    assert.equal(parseRedisTimeReply(malformed), null);
  }
});

test("distributed rate-limit replies require one coherent exact token-bucket state", () => {
  assert.deepEqual(parseDistributedRateLimitDecision([1, 4, 0], 5, 60_000), {
    allowed: true,
    remaining: 4,
    retryAfterSeconds: 0,
  });
  assert.deepEqual(parseDistributedRateLimitDecision([0, 0, 12], 5, 60_000), {
    allowed: false,
    remaining: 0,
    retryAfterSeconds: 12,
  });
  for (const malformed of [
    ["1", 4, 0],
    [true, 4, 0],
    [1, 5, 0],
    [1, 4, 1],
    [0, 1, 12],
    [0, 0, 0],
    [0, 0, 13],
    [0, 0.5, 12],
    [1, 4],
  ]) {
    assert.equal(parseDistributedRateLimitDecision(malformed, 5, 60_000), null);
  }
});
