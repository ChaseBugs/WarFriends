import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import { matchHandlers } from "../handlers/match";
import { playerHandlers } from "../handlers/player";

/**
 * Keep the feature tracker tied to executable handler ownership rather than documentation prose.
 * These are the exact direct profile/settings actions named by the recovered client contract.
 * UpdateRegionPings lives with matchmaking because its value is a routing hint; every other action
 * belongs to the profile registry. Losing, moving, or accidentally making one open must fail the
 * test before the tracker can continue to call the complete backend feature Implemented.
 */
const profileActions = Object.freeze([
  DbAction.GetPlayerInfo,
  DbAction.ChangePlayerName,
  DbAction.ChangePlayerCountry,
  DbAction.SetPlayerStatus,
  DbAction.UpdateDeviceToken,
  DbAction.UpdateArmyPower,
  DbAction.UpdateSettings,
  DbAction.ChangeLanguage,
] as const);

test("every recovered player profile and settings action has an authenticated handler", () => {
  for (const action of profileActions) {
    assert.equal(playerHandlers[action]?.requiresAuth, true, `Missing authenticated profile handler ${action}`);
  }
  assert.equal(matchHandlers[DbAction.UpdateRegionPings]?.requiresAuth, true);
});
