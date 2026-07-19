import assert from "node:assert/strict";
import test from "node:test";
import generatedUnitCatalog from "../data/unitCatalog.generated.json";
import generatedUnitUpgradeCatalog from "../data/unitUpgradeCatalog.generated.json";
import { DbAction } from "../dbActions";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  ITEM_ALREADY_MAXIMUM_UPGRADE,
  ITEM_NOT_ENOUGH_GOLD,
  ITEM_NOT_ENOUGH_LEVEL,
  ITEM_NOT_ENOUGH_WARBUCKS,
  ITEM_PRICE_MISMATCH,
  ITEM_PRICE_NOT_FOUND,
} from "../services/itemInventoryService";
import { createInitialProgression } from "../services/playerStateService";
import {
  activateUnitState,
  parseUnitActivateData,
  parseUnitEquipData,
  parseUnitPurchaseData,
  purchaseUnitState,
  UNIT_CANT_EQUIP,
  UNIT_CATALOG,
  updateEquippedUnitsState,
} from "../services/unitInventoryService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;
const SHOTGUNNER = "Google2u.DBUpgradeSlotsShotgunner";
const SNIPER = "Google2u.DBUpgradeSlotsSniper";
const DRONE = "Google2u.DBUpgradeSlotsDrone";
const TUTORIAL_ASSAULTER = "Google2u.DBUpgradeSlotsAssaulter";
const HELPER_TURRET = "Google2u.DBUpgradeSlotsTurret";
const UNRESOLVED_RIKO = "Google2u.DBUpgradeSlotsRiko";

function buyData(
  name = SHOTGUNNER,
  overrides: Record<string, unknown> = {},
): string {
  const definition = (generatedUnitCatalog.catalog as Array<Record<string, unknown>>)
    .find((row) => row.name === name);
  return JSON.stringify({
    Name: name,
    Warbucks: definition?.warBucks ?? 0,
    Gold: definition?.gold ?? 0,
    UnlockLevel: definition?.unlockLevel ?? 1,
    StartTime: NOW,
    discount: 0,
    ...overrides,
  });
}

function activateData(name = SHOTGUNNER): string {
  return JSON.stringify({ LevelName: name });
}

function equippedData(
  equips: Record<string, { wasEquipped?: boolean; equipped?: boolean }>,
  armyPower = 100,
): string {
  return JSON.stringify({ armyPower, equips });
}

test("unit extraction preserves player, helper, and unresolved boundaries", () => {
  assert.equal(generatedUnitCatalog.schemaVersion, 1);
  assert.equal(generatedUnitCatalog.source, "Client/ExportedProject/Assets/Scenes/MainScene.unity");
  assert.match(generatedUnitCatalog.sourceSha256, /^[0-9a-f]{64}$/);
  assert.equal(generatedUnitCatalog.catalog.filter((row) => row.roster === "player").length, 24);
  assert.equal(generatedUnitCatalog.catalog.filter((row) => row.roster === "additional").length, 3);
  assert.equal(generatedUnitCatalog.unresolvedRows.length, 18);
  assert.equal(generatedUnitCatalog.catalog.every((row) => row.deliverySeconds === 0), true);
  assert.equal(generatedUnitCatalog.catalog.every((row) => row.deploymentType >= 0 && row.deploymentType <= 3), true);
  assert.equal(generatedUnitCatalog.catalog.filter((row) => row.roster === "player" && !row.isSoldier).length, 8);

  // The normal purchase map excludes one tutorial-owned player row as well as helpers and
  // unresolved rows. Keeping the full artifact in the test makes this security filter visible.
  assert.equal(Object.keys(UNIT_CATALOG).length, 23);
  assert.equal(UNIT_CATALOG[TUTORIAL_ASSAULTER], undefined);
  assert.equal(UNIT_CATALOG[HELPER_TURRET], undefined);
  assert.equal(UNIT_CATALOG[UNRESOLVED_RIKO], undefined);
  assert.deepEqual(
    Object.values(UNIT_CATALOG).map((row) => row.name).sort(),
    generatedUnitCatalog.catalog
      .filter((row) => row.roster === "player" && !row.tutorialUnit)
      .map((row) => row.name)
      .sort(),
  );
});

test("unit upgrade extraction preserves normal/special offsets and all player tables", () => {
  assert.equal(generatedUnitUpgradeCatalog.schemaVersion, 1);
  assert.equal(generatedUnitUpgradeCatalog.catalog.length, 24);
  assert.equal(
    generatedUnitUpgradeCatalog.catalog.reduce((sum, row) => sum + row.normalLevels.length, 0),
    4_124,
  );
  assert.equal(
    generatedUnitUpgradeCatalog.catalog.reduce((sum, row) => sum + row.specialLevels.length, 0),
    684,
  );

  for (const upgrades of generatedUnitUpgradeCatalog.catalog) {
    const definition = generatedUnitCatalog.catalog.find((row) => row.name === upgrades.name);
    assert.ok(definition);
    assert.equal(upgrades.normalLevels[0]?.sourceIndex, 0);
    assert.equal(upgrades.specialLevels[0]?.sourceIndex, definition.startingSpecial);
    assert.equal(upgrades.normalLevels.every((row) => row.slot === 0), true);
    assert.equal(upgrades.specialLevels.every((row) => row.slot === 1), true);
  }

  // Sniper begins at tier 2, so its first normal row is tier 1 balancing but its saved tier
  // starts at 2. This proves the extractor does not incorrectly replace tier with cursor.
  const sniper = generatedUnitUpgradeCatalog.catalog.find((row) => row.name === SNIPER);
  assert.deepEqual(sniper?.normalLevels[0], {
    sourceIndex: 0,
    tier: 1,
    slot: 0,
    warBucks: 1_800,
    deliverySeconds: 240,
  });
  assert.equal(sniper?.specialLevels[0]?.sourceIndex, 196);
});

test("free unit purchase creates the exact SavedArmySlots shape", () => {
  const initial = createInitialProgression(NOW);
  const bought = purchaseUnitState(initial, 0, parseUnitPurchaseData(buyData()));

  assert.equal(bought.state.gold, 0);
  assert.equal(bought.state.warBucks, 0);
  assert.deepEqual(bought.unit, {
    bought: true,
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
  assert.equal(bought.itemInventory.levelManagerData.unitDelivery.activationNeeded, false);
});

test("WarBucks unit purchase enforces level, price, balance, and duplicate ownership", () => {
  const payload = parseUnitPurchaseData(buyData(SNIPER));
  const initial = { ...createInitialProgression(NOW), warBucks: 20_000 };

  assert.throws(
    () => purchaseUnitState(initial, 0, payload),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_LEVEL,
  );
  assert.throws(
    () => purchaseUnitState(initial, 1, { ...payload, warBucks: 1 }),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
  );
  assert.throws(
    () => purchaseUnitState({ ...initial, warBucks: 19_998 }, 1, payload),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_WARBUCKS,
  );

  const bought = purchaseUnitState(initial, 1, payload);
  assert.equal(bought.state.warBucks, 1);
  assert.equal(bought.unit.tier, 2);
  assert.equal(bought.unit.boughtIndex, 0);
  assert.throws(
    () => purchaseUnitState(bought.state, 1, payload),
    (error: unknown) => (error as { code?: number }).code === ITEM_ALREADY_MAXIMUM_UPGRADE,
  );
});

test("Gold unit purchase debits the recovered premium price", () => {
  const payload = parseUnitPurchaseData(buyData(DRONE));
  const initial = { ...createInitialProgression(NOW), gold: 169 };

  assert.throws(
    () => purchaseUnitState({ ...initial, gold: 168 }, 5, payload),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_GOLD,
  );
  const bought = purchaseUnitState(initial, 5, payload);
  assert.equal(bought.state.gold, 0);
  assert.equal(bought.state.itemInventory?.levelManagerData.savedArmies[DRONE]?.bought, true);
});

test("normal purchase fails closed for tutorial, helper, and unresolved unit rows", () => {
  const initial = { ...createInitialProgression(NOW), gold: 20_000, warBucks: 20_000 };
  for (const name of [TUTORIAL_ASSAULTER, HELPER_TURRET, UNRESOLVED_RIKO]) {
    assert.throws(
      () => purchaseUnitState(initial, 100, parseUnitPurchaseData(buyData(name))),
      (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_NOT_FOUND,
    );
  }
});

test("BuyUnit, ActivateUnit, and auto-equip are atomic and replay-safe in RequestBuffer", () => {
  const initial = createInitialProgression(NOW);
  const requests = [
    { action: DbAction.BuyUnit, data: buyData() },
    { action: DbAction.ActivateUnit, data: activateData() },
    {
      action: DbAction.UpdateEquippedUnits,
      data: equippedData({ [SHOTGUNNER]: { wasEquipped: true, equipped: true } }),
    },
  ];
  const first = processAssignmentBufferState(initial, NOW, "unit-buy-1", requests, 0);
  assert.deepEqual(JSON.parse(first.requestsResults), [
    { ActionId: DbAction.BuyUnit, Result: 1 },
    { ActionId: DbAction.ActivateUnit, Result: 1 },
    { ActionId: DbAction.UpdateEquippedUnits, Result: 1 },
  ]);
  assert.equal(first.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.bought, true);
  assert.equal(first.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.equipped, true);

  const replay = processAssignmentBufferState(first.state, NOW + 10, "unit-buy-1", requests, 0);
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(Object.keys(replay.state.itemInventory?.levelManagerData.savedArmies ?? {}).length, 1);
});

test("UpdateEquippedUnits persists the tutorial grant from its first backend-visible event", () => {
  const initial = createInitialProgression(NOW);
  const updated = updateEquippedUnitsState(
    initial,
    parseUnitEquipData(equippedData({
      [TUTORIAL_ASSAULTER]: { wasEquipped: true, equipped: true },
    })),
  );
  assert.deepEqual(updated.itemInventory.levelManagerData.savedArmies[TUTORIAL_ASSAULTER], {
    bought: true,
    boughtIndex: 0,
    specialSlot: 0,
    showed: true,
    tier: 1,
    borrowed: false,
    wasEquipped: true,
    equipped: true,
    eliteSlot: 0,
    parts: 0,
  });
});

test("UpdateEquippedUnits enforces ownership and the recovered two-per-category cap", () => {
  let state = { ...createInitialProgression(NOW), warBucks: 400_000 };
  for (const [name, level] of [[SHOTGUNNER, 0], ["Google2u.DBUpgradeSlotsSwat", 15], ["Google2u.DBUpgradeSlotsParachuter", 7]] as const) {
    state = purchaseUnitState(state, level, parseUnitPurchaseData(buyData(name))).state;
  }
  const threeRushers = Object.fromEntries(
    [SHOTGUNNER, "Google2u.DBUpgradeSlotsSwat", "Google2u.DBUpgradeSlotsParachuter"]
      .map((name) => [name, { wasEquipped: true, equipped: true }]),
  );
  assert.throws(
    () => updateEquippedUnitsState(state, parseUnitEquipData(equippedData(threeRushers))),
    (error: unknown) => (error as { code?: number }).code === UNIT_CANT_EQUIP,
  );

  assert.throws(
    () => updateEquippedUnitsState(
      createInitialProgression(NOW),
      parseUnitEquipData(equippedData({ [SNIPER]: { wasEquipped: true, equipped: true } })),
    ),
    (error: unknown) => (error as { code?: number }).code === UNIT_CANT_EQUIP,
  );
});

test("failed UpdateEquippedUnits returns the exact saved-army rollback dictionary", () => {
  const initial = createInitialProgression(NOW);
  const failed = processAssignmentBufferState(
    initial,
    NOW,
    "unit-equip-unowned",
    [{
      action: DbAction.UpdateEquippedUnits,
      data: equippedData({ [SNIPER]: { wasEquipped: true, equipped: true } }),
    }],
  );
  const [response] = JSON.parse(failed.requestsResults) as Array<Record<string, unknown>>;
  assert.equal(response.Result, UNIT_CANT_EQUIP);
  assert.equal(response.Result, 11_406);
  const rollback = JSON.parse(String(response.data)) as Record<string, string>;
  assert.equal(Object.keys(rollback).length, 24);
  assert.deepEqual(JSON.parse(rollback[SNIPER]!), {
    bought: false,
    boughtIndex: 0,
    specialSlot: 0,
    showed: false,
    tier: 2,
    borrowed: false,
    wasEquipped: false,
    equipped: false,
    eliteSlot: 0,
    parts: 0,
  });
  assert.equal(failed.state.itemInventory?.levelManagerData.savedArmies[SNIPER], undefined);
});

test("ActivateUnit requires prior ownership and returns client rollback fields", () => {
  const initial = createInitialProgression(NOW);
  assert.throws(
    () => activateUnitState(initial, parseUnitActivateData(activateData())),
    (error: unknown) => (error as { code?: number }).code === 104,
  );

  const failed = processAssignmentBufferState(
    initial,
    NOW,
    "unit-bad-price",
    [{ action: DbAction.BuyUnit, data: buyData(SNIPER, { Warbucks: 1 }) }],
    1,
  );
  const [response] = JSON.parse(failed.requestsResults) as Array<Record<string, unknown>>;
  assert.equal(response.ActionId, DbAction.BuyUnit);
  assert.equal(response.Result, ITEM_PRICE_MISMATCH);
  assert.equal(response.LevelName, SNIPER);
  assert.equal(response.Gold, 0);
  assert.equal(response.WarBucks, 0);
  assert.deepEqual(JSON.parse(String(response.Unit)), {
    bought: false,
    boughtIndex: 0,
    specialSlot: 0,
    showed: false,
    tier: 2,
    borrowed: false,
    wasEquipped: false,
    equipped: false,
    eliteSlot: 0,
    parts: 0,
  });
  assert.equal(JSON.parse(String(response.unitDelivery)).activationNeeded, false);
  assert.equal(failed.state.itemInventory?.levelManagerData.savedArmies[SNIPER], undefined);
});
