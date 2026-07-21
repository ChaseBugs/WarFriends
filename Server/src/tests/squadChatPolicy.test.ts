import assert from "node:assert/strict";
import test from "node:test";
import {
  squadChatHistoryLimit,
  squadChatMaximumLength,
  squadChatMessagesPerMinute,
  squadChatRetentionDays,
} from "../services/squadChatPolicyService";

test("Squad Chat policy preserves exact supported deployment values", () => {
  assert.equal(squadChatHistoryLimit(3), 3);
  assert.equal(squadChatHistoryLimit(100), 100);
  assert.equal(squadChatRetentionDays(1), 1);
  assert.equal(squadChatRetentionDays(365), 365);
  assert.equal(squadChatMessagesPerMinute(10), 10);
  assert.equal(squadChatMessagesPerMinute(1_000), 1_000);
  assert.equal(squadChatMaximumLength(256), 256);
  assert.equal(squadChatMaximumLength(2_048), 2_048);
});

test("Squad Chat policy rejects hidden defaults, clamping, and unsafe bounds", () => {
  const cases: ReadonlyArray<readonly [(value: number) => number, readonly number[]]> = [
    [squadChatHistoryLimit, [Number.NaN, Infinity, 0, 3.5, 101]],
    [squadChatRetentionDays, [Number.NaN, Infinity, 0, 30.5, 366]],
    [squadChatMessagesPerMinute, [Number.NaN, Infinity, 0, 10.5, 1_001]],
    [squadChatMaximumLength, [Number.NaN, Infinity, 0, 256.5, 2_049]],
  ];
  for (const [policy, values] of cases) {
    for (const value of values) {
      assert.throws(() => policy(value), /Squad Chat .* policy is invalid/);
    }
  }
});
