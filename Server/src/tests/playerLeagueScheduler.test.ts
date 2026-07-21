import assert from "node:assert/strict";
import test from "node:test";
import {
  expiredManagedLeagueIds,
  playerLeagueDiscoveryPipeline,
} from "../services/playerLeagueSchedulerService";
import { managedPlayerLeagueId } from "../services/playerLeagueContract";
import { League } from "../constants";

test("league scheduler selects only unique expired managed division IDs", () => {
  const expired = managedPlayerLeagueId(League.Silver2, 1_700_000_000);
  const old = expired.leagueId;
  const oldEnd = expired.endsAt;
  const boundedOld = managedPlayerLeagueId(League.Silver2, 1_700_000_000, 2).leagueId;
  const current = managedPlayerLeagueId(League.Gold1, oldEnd + 1).leagueId;
  assert.deepEqual(expiredManagedLeagueIds([
    old,
    boundedOld,
    old,
    current,
    "3-placement",
    "invalid",
    null,
  ], oldEnd), [old, boundedOld].sort());
});

test("league scheduler surfaces malformed locally owned IDs without claiming retired namespaces", () => {
  assert.deepEqual(expiredManagedLeagueIds([
    "8-retired-production-west",
    "8-placement",
    "not-a-league",
  ], 1_800_000_000), []);
  for (const corrupt of [
    "0-1700000000-local",
    "8-notatime-local",
    "8-1700000000-local0",
  ]) {
    assert.throws(
      () => expiredManagedLeagueIds([corrupt], 1_800_000_000),
      /Stored managed Player League ID is invalid/,
    );
  }
  assert.throws(() => expiredManagedLeagueIds([], Number.NaN), /scheduler time is invalid/);
});

test("league scheduler discovery groups and limits candidates inside MongoDB", () => {
  const pipeline = playerLeagueDiscoveryPipeline(1_800_000_000);
  assert.deepEqual(pipeline[0], {
    $match: {
      "player.leagueId": {
        $type: "string",
        $regex: "^[^-]+-[^-]+-local[^-]*$",
      },
    },
  });
  assert.deepEqual(pipeline.at(-2), { $limit: 101 });
  assert.equal(JSON.stringify(pipeline).includes("$group"), true);
  assert.equal(JSON.stringify(pipeline).includes("$regexMatch"), true);
  assert.throws(() => playerLeagueDiscoveryPipeline(Number.POSITIVE_INFINITY), /scheduler time is invalid/);
});
