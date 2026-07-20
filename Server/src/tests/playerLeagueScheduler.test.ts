import assert from "node:assert/strict";
import test from "node:test";
import { expiredManagedLeagueIds } from "../services/playerLeagueSchedulerService";
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
