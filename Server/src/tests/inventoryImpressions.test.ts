import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  ITEM_NOT_ENOUGH_LEVEL,
  markWeaponShownState,
} from "../services/itemInventoryService";
import { createInitialProgression } from "../services/playerStateService";
import { markUnitShownState } from "../services/unitInventoryService";

const NOW = 1_700_000_000;
const LOCKED_WEAPON = "Google2u.AssaultRifle_Famas";
const UNLOCKED_UNIT = "Google2u.DBUpgradeSlotsShotgunner";

test("weapon acknowledgement creates only a sparse non-owned shown row", () => {
  const initial = createInitialProgression(NOW);
  const shown = markWeaponShownState(initial, 13, LOCKED_WEAPON);
  assert.deepEqual(shown.weapon, {
    bought: false,
    boughtIndex: 0,
    showed: true,
    borrowed: false,
    specialFeature: 0,
  });
  assert.equal(shown.itemInventory.inventoryData.slots["0"]?.name, "Google2u.AssaultRifle_AK47");

  const replay = markWeaponShownState(shown.state, 13, LOCKED_WEAPON);
  assert.equal(replay.state, shown.state);
});

test("unit acknowledgement preserves complete non-owned SavedArmySlots defaults", () => {
  const initial = createInitialProgression(NOW);
  const shown = markUnitShownState(initial, 0, UNLOCKED_UNIT);
  assert.deepEqual(shown.unit, {
    bought: false,
    boughtIndex: 0,
    specialSlot: 0,
    showed: true,
    tier: 1,
    borrowed: false,
    wasEquipped: false,
    equipped: false,
    eliteSlot: 0,
    parts: 0,
  });
  assert.equal(shown.state.gold, initial.gold);
  assert.equal(shown.state.warBucks, initial.warBucks);
});

test("shown actions reject locked items instead of accepting client telemetry as authority", () => {
  const initial = createInitialProgression(NOW);
  assert.throws(
    () => markWeaponShownState(initial, 0, LOCKED_WEAPON),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_LEVEL,
  );
});

test("RequestBuffer persists both acknowledgements exactly once", () => {
  const initial = createInitialProgression(NOW);
  const requests = [
    { action: DbAction.WeaponWasShown, data: LOCKED_WEAPON },
    { action: DbAction.ArmyUnitWasShown, data: UNLOCKED_UNIT },
  ];
  const first = processAssignmentBufferState(initial, NOW, "shown-items", requests, 13);
  assert.deepEqual(JSON.parse(first.requestsResults), [
    { ActionId: DbAction.WeaponWasShown, Result: 1 },
    { ActionId: DbAction.ArmyUnitWasShown, Result: 1 },
  ]);
  assert.equal(first.state.itemInventory?.levelManagerData.savedWeapons[LOCKED_WEAPON]?.showed, true);
  assert.equal(first.state.itemInventory?.levelManagerData.savedWeapons[LOCKED_WEAPON]?.bought, false);
  assert.equal(first.state.itemInventory?.levelManagerData.savedArmies[UNLOCKED_UNIT]?.showed, true);
  assert.equal(first.state.itemInventory?.levelManagerData.savedArmies[UNLOCKED_UNIT]?.bought, false);

  const replay = processAssignmentBufferState(first.state, NOW + 1, "shown-items", requests, 13);
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
});
