import assert from "node:assert/strict";
import test from "node:test";
import { checkedRewardBalance } from "../services/rewardMathService";

test("server-authored rewards support chargeback debt and preserve safe integer balances", () => {
  assert.equal(checkedRewardBalance(100, 25, "Gold"), 125);
  assert.equal(checkedRewardBalance(-100, 25, "Gold"), -75);
  assert.equal(checkedRewardBalance(Number.MAX_SAFE_INTEGER - 1, 1, "Gold"), Number.MAX_SAFE_INTEGER);
});

test("server-authored rewards reject invalid amounts and unsafe combined balances", () => {
  assert.throws(() => checkedRewardBalance(0, -1, "Gold"), /balance is invalid/);
  assert.throws(() => checkedRewardBalance(0, 0.5, "Gold"), /balance is invalid/);
  assert.throws(() => checkedRewardBalance(Number.NaN, 1, "Gold"), /balance is invalid/);
  assert.throws(
    () => checkedRewardBalance(Number.MAX_SAFE_INTEGER, 1, "Gold"),
    /balance overflowed/,
  );
});
