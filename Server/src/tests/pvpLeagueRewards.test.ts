import assert from "node:assert/strict";
import test from "node:test";
import { League } from "../constants";
import { pvpLeagueReward } from "../services/matchService";

test("ranked wins use exact beginner and normal league reward rows", () => {
  assert.deepEqual(pvpLeagueReward(true, false, 2, League.Bronze3), {
    baseWarBucks: 400,
    warBucks: 400,
    squadPoints: 1,
  });
  assert.deepEqual(pvpLeagueReward(true, false, 0, League.Gold2), {
    baseWarBucks: 2250,
    warBucks: 2250,
    squadPoints: 4,
  });
});

test("league VIP multiplication is independent and losses cannot mint league rewards", () => {
  assert.deepEqual(pvpLeagueReward(true, true, 0, League.Silver3), {
    baseWarBucks: 1250,
    warBucks: 1875,
    squadPoints: 3,
  });
  assert.deepEqual(pvpLeagueReward(false, true, 0, League.Champion), {
    baseWarBucks: 0,
    warBucks: 0,
    squadPoints: 0,
  });
  assert.throws(() => pvpLeagueReward(true, false, 4, League.Bronze3), /Unsupported beginner league/);
  assert.throws(() => pvpLeagueReward(true, false, 0, 99), /Unsupported player league tier/);
});
