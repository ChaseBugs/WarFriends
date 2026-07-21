import assert from "node:assert/strict";
import test from "node:test";
import {
  playerLeagueSchedulerIntervalSeconds,
  squadWarSchedulerIntervalSeconds,
} from "../services/competitionSchedulerPolicyService";

test("competition scheduler policy preserves exact supported intervals", () => {
  assert.equal(playerLeagueSchedulerIntervalSeconds(10), 10);
  assert.equal(playerLeagueSchedulerIntervalSeconds(3_600), 3_600);
  assert.equal(squadWarSchedulerIntervalSeconds(10), 10);
  assert.equal(squadWarSchedulerIntervalSeconds(3_600), 3_600);
});

test("competition scheduler policy rejects rounded, clamped, and non-finite intervals", () => {
  for (const policy of [playerLeagueSchedulerIntervalSeconds, squadWarSchedulerIntervalSeconds]) {
    for (const value of [Number.NaN, Number.POSITIVE_INFINITY, -1, 9, 10.5, 3_601]) {
      assert.throws(() => policy(value), /scheduler interval policy is invalid/);
    }
  }
});
