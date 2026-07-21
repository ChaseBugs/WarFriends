import assert from "node:assert/strict";
import test from "node:test";
import {
  competitionTimingPolicy,
  playerLeagueSchedulerIntervalSeconds,
  squadWarSeasonDurationSeconds,
  squadWarSchedulerIntervalSeconds,
} from "../services/competitionSchedulerPolicyService";

test("competition timing is one immutable startup snapshot", () => {
  assert.equal(Object.isFrozen(competitionTimingPolicy()), true);
  assert.deepEqual(competitionTimingPolicy(), {
    playerLeagueSchedulerSeconds: 60,
    squadWarSchedulerSeconds: 60,
    squadWarSeasonSeconds: 604_800,
  });
  assert.equal(playerLeagueSchedulerIntervalSeconds(), 60);
  assert.equal(squadWarSchedulerIntervalSeconds(), 60);
  assert.equal(squadWarSeasonDurationSeconds(), 604_800);
});

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

test("Squad War season timing preserves only the exact client-width calendar domain", () => {
  assert.equal(squadWarSeasonDurationSeconds(3_600), 3_600);
  assert.equal(squadWarSeasonDurationSeconds(2_147_483_647), 2_147_483_647);
  for (const value of [Number.NaN, Number.POSITIVE_INFINITY, -1, 3_599, 3_600.5, 2_147_483_648]) {
    assert.throws(() => squadWarSeasonDurationSeconds(value), /calendar policy is invalid/);
  }
  assert.throws(
    () => competitionTimingPolicy({
      playerLeagueSchedulerSeconds: 60,
      squadWarSchedulerSeconds: 60,
      squadWarSeasonSeconds: Number.NaN,
    }),
    /calendar policy is invalid/,
  );
});
