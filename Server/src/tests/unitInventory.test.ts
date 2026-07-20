import assert from "node:assert/strict";
import test from "node:test";
import generatedUnitCatalog from "../data/unitCatalog.generated.json";
import generatedUnitUpgradeCatalog from "../data/unitUpgradeCatalog.generated.json";
import { DbAction } from "../dbActions";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  ITEM_ALREADY_MAXIMUM_UPGRADE,
  ITEM_ALREADY_UPGRADING,
  ITEM_NEGATIVE_PRICE_FROM_CLIENT,
  ITEM_NO_DISCOUNT_FOUND,
  ITEM_NOT_ENOUGH_GOLD,
  ITEM_NOT_ENOUGH_LEVEL,
  ITEM_NOT_ENOUGH_WARBUCKS,
  ITEM_PRICE_MISMATCH,
  ITEM_PRICE_NOT_FOUND,
  ITEM_TOO_SOON_TO_ACTIVATE,
  weaponUpgradeInstantPrice,
} from "../services/itemInventoryService";
import { createInitialProgression } from "../services/playerStateService";
import {
  activateUnitState,
  activateUnitUpgradeState,
  convertScrapsToUnitPartsState,
  convertUnitPartsToScrapsState,
  equippedUnitPower,
  instantUnitUpgradeState,
  parseUnitActivateData,
  parseUnitEquipData,
  parseUnitEliteUpgradeData,
  parseUnitPartsToScrapsData,
  parseUnitPromoteData,
  parseUnitPurchaseData,
  parseUnitScrapsToPartsData,
  parseUnitUpgradeActivateData,
  parseUnitUpgradeInstantData,
  parseUnitUpgradePurchaseData,
  purchaseUnitState,
  promoteUnitState,
  startUnitUpgradeState,
  UNIT_CANT_EQUIP,
  UNIT_CATALOG,
  UNIT_ELITE_INCORRECT_VALUES,
  UNIT_ELITE_INCORRECT_PARTS_AMOUNT,
  UNIT_ELITE_NOT_ENOUGH_PARTS,
  UNIT_ELITE_NOT_ENOUGH_SCRAPS,
  UNIT_ELITE_SLOT_LOCKED,
  UNIT_NOT_ENOUGH_LEVEL_FOR_PROMOTE,
  UNIT_PART_TO_SCRAPS_SELL_RATE,
  UNIT_SCRAPS_TO_PART_UPGRADE_RATE,
  unitArmyPower,
  upgradeUnitEliteState,
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

function upgradePurchaseData(
  name = SHOTGUNNER,
  isSpecial = false,
  overrides: Record<string, unknown> = {},
): string {
  const table = generatedUnitUpgradeCatalog.catalog.find((row) => row.name === name);
  const level = (isSpecial ? table?.specialLevels : table?.normalLevels)?.[0];
  return JSON.stringify({
    LevelName: name,
    BoughtIndex: 0,
    StartTime: NOW,
    IsSpecial: isSpecial ? "1" : "0",
    discount: 0,
    DeliveryTime: level?.deliverySeconds ?? 0,
    deliveryReduce: 0,
    ...overrides,
  });
}

function upgradeActivateData(
  name = SHOTGUNNER,
  overrides: Record<string, unknown> = {},
): string {
  return JSON.stringify({ LevelName: name, BoughtIndex: 0, ArmyPower: 100, ...overrides });
}

function upgradeInstantData(
  expectedPrice: number,
  name = SHOTGUNNER,
  overrides: Record<string, unknown> = {},
): string {
  return JSON.stringify({
    LevelName: name,
    BoughtIndex: 0,
    ExpectedPrice: expectedPrice,
    ArmyPower: 100,
    GoldCoefficient: 0.6325,
    GoldExpCoefficient: -0.175,
    discount: 0,
    ...overrides,
  });
}

function promoteData(name = SHOTGUNNER): string {
  return JSON.stringify({ LevelName: name });
}

function eliteUpgradeData(
  name = SHOTGUNNER,
  boughtIndex = 0,
  overrides: Record<string, unknown> = {},
): string {
  const table = generatedUnitUpgradeCatalog.catalog.find((row) => row.name === name);
  const level = table?.eliteLevels[boughtIndex];
  return JSON.stringify({
    LevelName: name,
    BoughtIndex: boughtIndex,
    SpentWarbucks: level?.warBucks ?? 0,
    SpentParts: level?.parts ?? 0,
    ...overrides,
  });
}

function partsToScrapsData(
  name = SHOTGUNNER,
  partsToConvert = 10,
  scraps = partsToConvert * UNIT_PART_TO_SCRAPS_SELL_RATE,
): string {
  return JSON.stringify({ LevelName: name, PartsToConvert: partsToConvert, Scraps: scraps });
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

test("unit upgrade extraction preserves all three slot offsets, power, and player tables", () => {
  assert.equal(generatedUnitUpgradeCatalog.schemaVersion, 2);
  assert.equal(generatedUnitUpgradeCatalog.catalog.length, 24);
  assert.equal(
    generatedUnitUpgradeCatalog.catalog.reduce((sum, row) => sum + row.normalLevels.length, 0),
    4_124,
  );
  assert.equal(
    generatedUnitUpgradeCatalog.catalog.reduce((sum, row) => sum + row.specialLevels.length, 0),
    684,
  );
  assert.equal(
    generatedUnitUpgradeCatalog.catalog.reduce((sum, row) => sum + row.eliteLevels.length, 0),
    216,
  );

  for (const upgrades of generatedUnitUpgradeCatalog.catalog) {
    const definition = generatedUnitCatalog.catalog.find((row) => row.name === upgrades.name);
    assert.ok(definition);
    assert.equal(upgrades.normalLevels[0]?.sourceIndex, 0);
    assert.equal(upgrades.specialLevels[0]?.sourceIndex, definition.startingSpecial);
    assert.equal(upgrades.eliteLevels[0]?.sourceIndex, definition.startingElite);
    assert.equal(upgrades.normalLevels.every((row) => row.slot === 0), true);
    assert.equal(upgrades.specialLevels.every((row) => row.slot === 1), true);
    assert.equal(upgrades.eliteLevels.length, 9);
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
    armyPower: 71.97,
  });
  assert.equal(sniper?.specialLevels[0]?.sourceIndex, 196);
  assert.deepEqual(sniper?.eliteLevels[0], {
    sourceIndex: 232,
    parts: 50,
    warBucks: 0,
    armyPower: 5,
  });
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

test("normal unit upgrade debits extracted price and waits for server delivery", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  const started = startUnitUpgradeState(
    { ...owned.state, warBucks: 375 },
    NOW,
    parseUnitUpgradePurchaseData(upgradePurchaseData()),
  );

  assert.equal(started.state.warBucks, 0);
  assert.equal(started.unit.boughtIndex, 0);
  assert.equal(started.deliveryTime, 60);
  assert.deepEqual(started.itemInventory.levelManagerData.unitDelivery, {
    activationNeeded: true,
    boughtIndex: 0,
    end: NOW + 60,
    itemId: SHOTGUNNER,
    slotId: 0,
    start: NOW,
  });
  assert.throws(
    () => activateUnitUpgradeState(
      started.state,
      NOW + 59,
      parseUnitUpgradeActivateData(upgradeActivateData()),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_TOO_SOON_TO_ACTIVATE,
  );

  const activated = activateUnitUpgradeState(
    started.state,
    NOW + 60,
    parseUnitUpgradeActivateData(upgradeActivateData()),
  );
  assert.equal(activated.unit.boughtIndex, 1);
  assert.equal(activated.unit.specialSlot, 0);
  assert.equal(activated.itemInventory.levelManagerData.unitDelivery.activationNeeded, false);
});

test("active subscription applies the recovered 0.8 unit delivery multiplier", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  const subscribed = {
    ...owned.state,
    warBucks: 375,
    subscription: {
      type: "subscription1" as const,
      subscribeSince: NOW - 1,
      expireTime: NOW + 3_600,
      dogTagTimerLock: NOW,
    },
  };
  const started = startUnitUpgradeState(
    subscribed,
    NOW,
    parseUnitUpgradePurchaseData(upgradePurchaseData(SHOTGUNNER, false, { DeliveryTime: 48 })),
  );
  assert.equal(started.deliveryTime, 48);
  assert.equal(started.itemInventory.levelManagerData.unitDelivery.end, NOW + 48);
  assert.throws(
    () => startUnitUpgradeState(
      subscribed,
      NOW,
      parseUnitUpgradePurchaseData(upgradePurchaseData()),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
  );
});

test("unit upgrade rejects an unowned roster row with a client-handled rollback code", () => {
  assert.throws(
    () => startUnitUpgradeState(
      { ...createInitialProgression(NOW), warBucks: 10_000 },
      NOW,
      parseUnitUpgradePurchaseData(upgradePurchaseData()),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_NOT_FOUND,
  );
});

test("unit upgrade enforces shared receipt, discounts, and current-tier boundary", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  const funded = { ...owned.state, warBucks: 20_000 };
  assert.throws(
    () => startUnitUpgradeState(
      funded,
      NOW,
      parseUnitUpgradePurchaseData(upgradePurchaseData(SHOTGUNNER, false, { discount: 1 })),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_NO_DISCOUNT_FOUND,
  );

  const started = startUnitUpgradeState(
    funded,
    NOW,
    parseUnitUpgradePurchaseData(upgradePurchaseData()),
  );
  assert.throws(
    () => startUnitUpgradeState(
      started.state,
      NOW + 1,
      parseUnitUpgradePurchaseData(upgradePurchaseData()),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_ALREADY_UPGRADING,
  );

  const tierComplete = purchaseUnitState(
    createInitialProgression(NOW),
    0,
    parseUnitPurchaseData(buyData()),
  );
  tierComplete.unit.boughtIndex = 5;
  assert.throws(
    () => startUnitUpgradeState(
      { ...tierComplete.state, warBucks: 100_000 },
      NOW,
      parseUnitUpgradePurchaseData(upgradePurchaseData(SHOTGUNNER, false, {
        BoughtIndex: 5,
        DeliveryTime: 1_200,
      })),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_ALREADY_MAXIMUM_UPGRADE,
  );
});

test("special upgrade is promotion-gated and advances only specialSlot", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  assert.throws(
    () => startUnitUpgradeState(
      { ...owned.state, warBucks: 10_000 },
      NOW,
      parseUnitUpgradePurchaseData(upgradePurchaseData(SHOTGUNNER, true)),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_LEVEL,
  );

  // Promotion itself is a separate unrecovered action. Setting the exact post-promotion tier
  // here isolates the special-lane lifecycle without pretending that promotion is implemented.
  owned.unit.tier = 2;
  const started = startUnitUpgradeState(
    { ...owned.state, warBucks: 10_000 },
    NOW,
    parseUnitUpgradePurchaseData(upgradePurchaseData(SHOTGUNNER, true)),
  );
  assert.equal(started.itemInventory.levelManagerData.unitDelivery.slotId, 1);
  assert.equal(started.state.warBucks, 0);
  const activated = activateUnitUpgradeState(
    started.state,
    NOW + 3_600,
    parseUnitUpgradeActivateData(upgradeActivateData()),
  );
  assert.equal(activated.unit.boughtIndex, 0);
  assert.equal(activated.unit.specialSlot, 1);
});

test("instant unit upgrade uses receipt-backed Gold price and returns rollback on failure", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  const started = startUnitUpgradeState(
    { ...owned.state, warBucks: 375, gold: 10 },
    NOW,
    parseUnitUpgradePurchaseData(upgradePurchaseData()),
  );
  const price = weaponUpgradeInstantPrice(30);
  assert.equal(price, 1);
  const finished = instantUnitUpgradeState(
    started.state,
    NOW + 30,
    parseUnitUpgradeInstantData(upgradeInstantData(price)),
  );
  assert.equal(finished.state.gold, 9);
  assert.equal(finished.unit.boughtIndex, 1);

  const failed = processAssignmentBufferState(
    started.state,
    NOW + 30,
    "unit-upgrade-negative-price",
    [{ action: DbAction.InstantUnitUpgrade, data: upgradeInstantData(-1) }],
    0,
  );
  const [response] = JSON.parse(failed.requestsResults) as Array<Record<string, unknown>>;
  assert.equal(response.Result, ITEM_NEGATIVE_PRICE_FROM_CLIENT);
  assert.equal(response.LevelName, SHOTGUNNER);
  assert.equal(response.Gold, 10);
  assert.equal(response.WarBucks, 0);
  assert.deepEqual(JSON.parse(String(response.Unit)), started.unit);
  assert.deepEqual(
    JSON.parse(String(response.unitDelivery)),
    started.itemInventory.levelManagerData.unitDelivery,
  );
});

test("buffered unit upgrade returns duration and instant completion is replay-safe", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  const start = processAssignmentBufferState(
    { ...owned.state, warBucks: 375, gold: 10 },
    NOW,
    "unit-upgrade-start",
    [{ action: DbAction.BuyUnitUpgrade, data: upgradePurchaseData() }],
    0,
  );
  assert.deepEqual(JSON.parse(start.requestsResults), [{
    ActionId: DbAction.BuyUnitUpgrade,
    Result: 1,
    DeliveryTime: 60,
  }]);

  const request = [{
    action: DbAction.InstantUnitUpgrade,
    data: upgradeInstantData(weaponUpgradeInstantPrice(30)),
  }];
  const first = processAssignmentBufferState(
    start.state,
    NOW + 30,
    "unit-upgrade-finish",
    request,
    0,
  );
  const replay = processAssignmentBufferState(
    first.state,
    NOW + 40,
    "unit-upgrade-finish",
    request,
    0,
  );
  assert.equal(first.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.boughtIndex, 1);
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.boughtIndex, 1);
});

test("unit promotion requires tier completion and the recovered display-level gate", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  assert.throws(
    () => promoteUnitState(owned.state, 100, parseUnitPromoteData(promoteData())),
    (error: unknown) => (error as { code?: number }).code === ITEM_ALREADY_MAXIMUM_UPGRADE,
  );

  // Shotgunner tier 1 ends at normal cursor 5 and UNLOCKTIER2 is display level 11.
  owned.unit.boughtIndex = 5;
  assert.throws(
    () => promoteUnitState(owned.state, 9, parseUnitPromoteData(promoteData())),
    (error: unknown) => (
      (error as { code?: number }).code === UNIT_NOT_ENOUGH_LEVEL_FOR_PROMOTE
    ),
  );
  const promoted = promoteUnitState(owned.state, 10, parseUnitPromoteData(promoteData()));
  assert.equal(promoted.unit.tier, 2);
  assert.equal(promoted.unit.boughtIndex, 5);
  assert.equal(promoted.unit.specialSlot, 0);
});

test("buffered promotion returns exact level diagnostics and is replay-safe", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  owned.unit.boughtIndex = 5;
  const request = [{ action: DbAction.PromoteUnit, data: promoteData() }];
  const blocked = processAssignmentBufferState(
    owned.state,
    NOW,
    "unit-promote-blocked",
    request,
    9,
  );
  const [failure] = JSON.parse(blocked.requestsResults) as Array<Record<string, unknown>>;
  assert.equal(failure.Result, UNIT_NOT_ENOUGH_LEVEL_FOR_PROMOTE);
  assert.equal(failure.playerLevel, "10");
  assert.equal(failure.requiredLevel, "11");
  assert.equal(JSON.parse(String(failure.Unit)).tier, 1);

  const first = processAssignmentBufferState(
    owned.state,
    NOW,
    "unit-promote-success",
    request,
    10,
  );
  assert.deepEqual(JSON.parse(first.requestsResults), [{
    ActionId: DbAction.PromoteUnit,
    Result: 1,
  }]);
  assert.equal(first.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.tier, 2);
  const replay = processAssignmentBufferState(
    first.state,
    NOW + 5,
    "unit-promote-success",
    request,
    10,
  );
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.tier, 2);
});

test("elite purchase consumes exact parts and later levels consume recovered WarBucks", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  owned.unit.parts = 50;
  const first = upgradeUnitEliteState(owned.state, parseUnitEliteUpgradeData(eliteUpgradeData()));
  assert.equal(first.unit.eliteSlot, 1);
  assert.equal(first.unit.parts, 0);
  assert.equal(first.state.warBucks, 0);

  first.unit.parts = 100;
  assert.throws(
    () => upgradeUnitEliteState(first.state, parseUnitEliteUpgradeData(eliteUpgradeData(SHOTGUNNER, 1))),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_WARBUCKS,
  );
  const funded = { ...first.state, warBucks: 50_000 };
  const second = upgradeUnitEliteState(
    funded,
    parseUnitEliteUpgradeData(eliteUpgradeData(SHOTGUNNER, 1)),
  );
  assert.equal(second.unit.eliteSlot, 2);
  assert.equal(second.unit.parts, 0);
  assert.equal(second.state.warBucks, 0);
});

test("elite transition rejects stale cursors, insufficient parts, and client-selected prices", () => {
  assert.throws(
    () => upgradeUnitEliteState(
      createInitialProgression(NOW),
      parseUnitEliteUpgradeData(eliteUpgradeData()),
    ),
    (error: unknown) => (error as { code?: number }).code === UNIT_ELITE_INCORRECT_VALUES,
  );
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  owned.unit.parts = 49;
  assert.throws(
    () => upgradeUnitEliteState(owned.state, parseUnitEliteUpgradeData(eliteUpgradeData())),
    (error: unknown) => (error as { code?: number }).code === UNIT_ELITE_NOT_ENOUGH_PARTS,
  );
  owned.unit.parts = 50;
  assert.throws(
    () => upgradeUnitEliteState(
      owned.state,
      parseUnitEliteUpgradeData(eliteUpgradeData(SHOTGUNNER, 0, { SpentParts: 1 })),
    ),
    (error: unknown) => (error as { code?: number }).code === UNIT_ELITE_INCORRECT_VALUES,
  );
  assert.throws(
    () => upgradeUnitEliteState(
      owned.state,
      parseUnitEliteUpgradeData(eliteUpgradeData(SHOTGUNNER, 0, { BoughtIndex: 1 })),
    ),
    (error: unknown) => (error as { code?: number }).code === 104,
  );
});

test("buffered elite upgrade is exactly-once and malformed payloads use the client elite error", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  owned.unit.parts = 50;
  const request = [{ action: DbAction.UpgradeEliteSlot, data: eliteUpgradeData() }];
  const first = processAssignmentBufferState(owned.state, NOW, "unit-elite-1", request, 0);
  assert.deepEqual(JSON.parse(first.requestsResults), [{ ActionId: DbAction.UpgradeEliteSlot, Result: 1 }]);
  assert.equal(first.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.eliteSlot, 1);
  assert.equal(first.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.parts, 0);

  const replay = processAssignmentBufferState(first.state, NOW + 5, "unit-elite-1", request, 0);
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.eliteSlot, 1);

  const malformed = processAssignmentBufferState(
    owned.state,
    NOW,
    "unit-elite-malformed",
    [{ action: DbAction.UpgradeEliteSlot, data: JSON.stringify({ LevelName: SHOTGUNNER }) }],
    0,
  );
  const [failure] = JSON.parse(malformed.requestsResults) as Array<Record<string, unknown>>;
  assert.equal(failure.Result, UNIT_ELITE_INCORRECT_VALUES);
  assert.equal(JSON.parse(String(failure.Unit)).eliteSlot, 0);
  assert.equal(JSON.parse(String(failure.Unit)).parts, 50);
});

test("Scraps-to-parts conversion derives the full Elite target and recovered 24:1 price", () => {
  assert.equal(UNIT_SCRAPS_TO_PART_UPGRADE_RATE, 24);
  assert.equal(UNIT_PART_TO_SCRAPS_SELL_RATE, 5);
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  owned.unit.parts = 20;
  const funded = { ...owned.state, scraps: 1_000 };

  const converted = convertScrapsToUnitPartsState(
    funded,
    parseUnitScrapsToPartsData(SHOTGUNNER),
  );
  assert.equal(converted.unit.parts, 50);
  assert.equal(converted.state.scraps, 280);

  assert.throws(
    () => convertScrapsToUnitPartsState(
      { ...owned.state, scraps: 719 },
      parseUnitScrapsToPartsData(SHOTGUNNER),
    ),
    (error: unknown) => (error as { code?: number }).code === UNIT_ELITE_NOT_ENOUGH_SCRAPS,
  );
});

test("parts-to-Scraps conversion requires a bought Elite slot and exact full-balance echoes", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  owned.unit.parts = 50;
  const elite = upgradeUnitEliteState(owned.state, parseUnitEliteUpgradeData(eliteUpgradeData()));
  elite.unit.parts = 10;

  const converted = convertUnitPartsToScrapsState(
    elite.state,
    parseUnitPartsToScrapsData(partsToScrapsData()),
  );
  assert.equal(converted.unit.parts, 0);
  assert.equal(converted.state.scraps, 50);

  owned.unit.parts = 10;
  assert.throws(
    () => convertUnitPartsToScrapsState(
      owned.state,
      parseUnitPartsToScrapsData(partsToScrapsData()),
    ),
    (error: unknown) => (error as { code?: number }).code === UNIT_ELITE_SLOT_LOCKED,
  );
  assert.throws(
    () => convertUnitPartsToScrapsState(
      elite.state,
      parseUnitPartsToScrapsData(partsToScrapsData(SHOTGUNNER, 9, 45)),
    ),
    (error: unknown) => (error as { code?: number }).code === UNIT_ELITE_INCORRECT_PARTS_AMOUNT,
  );
});

test("buffered Elite-part conversions are atomic, replay-safe, and return stock error codes", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  const funded = { ...owned.state, scraps: 1_200 };
  const fillRequest = [{ action: DbAction.ConvertScrapsToParts, data: SHOTGUNNER }];
  const filled = processAssignmentBufferState(funded, NOW, "elite-fill-1", fillRequest, 0);
  assert.deepEqual(JSON.parse(filled.requestsResults), [
    { ActionId: DbAction.ConvertScrapsToParts, Result: 1 },
  ]);
  assert.equal(filled.state.scraps, 0);
  assert.equal(filled.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.parts, 50);

  const replay = processAssignmentBufferState(filled.state, NOW + 1, "elite-fill-1", fillRequest, 0);
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, filled.requestsResults);
  assert.equal(replay.state.scraps, 0);

  const elite = processAssignmentBufferState(
    filled.state,
    NOW + 2,
    "elite-buy-after-fill",
    [{ action: DbAction.UpgradeEliteSlot, data: eliteUpgradeData() }],
    0,
  );
  const withParts = elite.state.itemInventory!.levelManagerData.savedArmies[SHOTGUNNER]!;
  withParts.parts = 10;
  const sold = processAssignmentBufferState(
    elite.state,
    NOW + 3,
    "elite-sell-1",
    [{ action: DbAction.ConvertPartsToScraps, data: partsToScrapsData() }],
    0,
  );
  assert.deepEqual(JSON.parse(sold.requestsResults), [
    { ActionId: DbAction.ConvertPartsToScraps, Result: 1 },
  ]);
  assert.equal(sold.state.scraps, 50);
  assert.equal(sold.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.parts, 0);

  const stale = processAssignmentBufferState(
    elite.state,
    NOW + 4,
    "elite-sell-stale",
    [{ action: DbAction.ConvertPartsToScraps, data: partsToScrapsData(SHOTGUNNER, 9, 45) }],
    0,
  );
  assert.deepEqual(JSON.parse(stale.requestsResults), [
    { ActionId: DbAction.ConvertPartsToScraps, Result: UNIT_ELITE_INCORRECT_PARTS_AMOUNT },
  ]);
  assert.equal(stale.state.itemInventory?.levelManagerData.savedArmies[SHOTGUNNER]?.parts, 10);
});

test("unit ArmyPower follows normal, promoted special, and bought elite rows", () => {
  const owned = purchaseUnitState(createInitialProgression(NOW), 0, parseUnitPurchaseData(buyData()));
  assert.equal(unitArmyPower(owned.state, SHOTGUNNER), 60);
  assert.equal(equippedUnitPower(owned.state), 0);

  owned.unit.equipped = true;
  assert.equal(equippedUnitPower(owned.state), 60);
  owned.unit.parts = 50;
  const elite = upgradeUnitEliteState(owned.state, parseUnitEliteUpgradeData(eliteUpgradeData()));
  // The cursor advances to elite row one; row zero priced that transition but was hidden while
  // isBought was false, so the newly bought elite contribution is row one's value of 10.
  assert.equal(unitArmyPower(elite.state, SHOTGUNNER), 70);
  assert.equal(equippedUnitPower(elite.state), 70);

  // At tier 2, special cursor zero contributes 5 and normal cursor five contributes 68.47.
  elite.unit.boughtIndex = 5;
  elite.unit.tier = 2;
  assert.ok(Math.abs(unitArmyPower(elite.state, SHOTGUNNER) - 83.47) < 0.000_01);
  assert.equal(equippedUnitPower(elite.state), 83);
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
  const replay = updateEquippedUnitsState(
    updated.state,
    parseUnitEquipData(equippedData({
      [TUTORIAL_ASSAULTER]: { wasEquipped: true, equipped: true },
    })),
  );
  assert.equal(replay.state, updated.state);
  assert.equal(replay.state.revision, updated.state.revision);
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
