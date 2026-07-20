import assert from "node:assert/strict";
import test from "node:test";
import { pvpMedalBalances } from "../services/matchService";

test("confirmed PvP results update global and weekly medal mirrors together", () => {
  assert.deepEqual(pvpMedalBalances(100, 40, true), {
    delta: 25,
    skill: 125,
    medalsBalance: 65,
  });
  assert.deepEqual(pvpMedalBalances(100, 40, false), {
    delta: -12,
    skill: 88,
    medalsBalance: 28,
  });
});

test("medal losses floor independently and corrupted balances fail closed", () => {
  assert.deepEqual(pvpMedalBalances(5, 0, false), {
    delta: -12,
    skill: 0,
    medalsBalance: 0,
  });
  assert.throws(() => pvpMedalBalances(-1, 0, true), /invalid/);
  assert.throws(() => pvpMedalBalances(0, Number.MAX_SAFE_INTEGER, true), /overflow/);
});
