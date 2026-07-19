import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  createInitialItemInventory,
  equipWeaponState,
  ITEM_NOT_ENOUGH_GOLD,
  ITEM_NOT_ENOUGH_LEVEL,
  ITEM_PRICE_MISMATCH,
  ITEM_WEAPON_NOT_BOUGHT,
  parseWeaponEquipData,
  parseWeaponPurchaseData,
  purchaseWeaponState,
  serializeInventoryData,
  serializeLevelManagerData,
  WEAPON_CATALOG,
} from "../services/itemInventoryService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;
const FAMAS = "Google2u.AssaultRifle_Famas";

function purchaseData(overrides: Record<string, unknown> = {}): string {
  return JSON.stringify({
    Name: FAMAS,
    Warbucks: 0,
    Gold: 949,
    UnlockLevel: 17,
    StartTime: NOW,
    discount: 0,
    ...overrides,
  });
}

function equipData(overrides: Record<string, unknown> = {}): string {
  return JSON.stringify({
    // The recovered client serializes Index as text even though it represents an integer.
    Index: "2",
    Name: FAMAS,
    SlotIndex: 0,
    ArmyPower: 123,
    SpecialFeature: 0,
    ...overrides,
  });
}

test("initial item inventory matches recovered InventoryData and LevelManagerData fields", () => {
  const inventory = createInitialItemInventory();

  assert.deepEqual(Object.keys(inventory.inventoryData), ["slots"]);
  assert.deepEqual(inventory.inventoryData.slots, {
    "0": { name: "Google2u.AssaultRifle_AK47", weaponIndex: 1 },
    "1": { name: "Google2u.SniperRifle_M24", weaponIndex: 3 },
    "2": { name: "Google2u.Grenade_FRAG", weaponIndex: 6 },
    "3": { name: "Google2u.Pistol_Remmington51", weaponIndex: 13 },
  });
  assert.deepEqual(Object.keys(inventory.levelManagerData), [
    "savedArmies",
    "savedWeapons",
    "unitDelivery",
    "weaponDelivery",
  ]);
  assert.deepEqual(Object.keys(inventory.levelManagerData.savedWeapons["Google2u.AssaultRifle_AK47"]!), [
    "bought",
    "boughtIndex",
    "showed",
    "borrowed",
    "specialFeature",
  ]);
  assert.doesNotThrow(() => JSON.parse(serializeInventoryData(inventory)));
  assert.doesNotThrow(() => JSON.parse(serializeLevelManagerData(inventory)));
});

test("FAMAS purchase enforces recovered level and price before debiting Gold", () => {
  const initial = { ...createInitialProgression(NOW), gold: 1_000 };
  const payload = parseWeaponPurchaseData(purchaseData());

  assert.throws(
    () => purchaseWeaponState(initial, 12, payload),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_LEVEL,
  );
  assert.throws(
    () => purchaseWeaponState(initial, 13, { ...payload, gold: 948 }),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
  );
  assert.throws(
    () => purchaseWeaponState({ ...initial, gold: 948 }, 13, payload),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_GOLD,
  );

  const bought = purchaseWeaponState(initial, 13, payload);
  assert.equal(bought.state.gold, 51);
  assert.equal(bought.state.itemInventory?.levelManagerData.savedWeapons[FAMAS]?.bought, true);
  // Buying does not silently equip the weapon; EquipWeapon owns that separate mutation.
  assert.equal(bought.state.itemInventory?.inventoryData.slots["0"]?.weaponIndex, 1);
});

test("weapon catalog contains every shop row with a resolvable LevelManager entry", () => {
  const definitions = Object.values(WEAPON_CATALOG);

  assert.equal(definitions.length, 84);
  assert.equal(new Set(definitions.map((definition) => definition.index)).size, definitions.length);
  assert.deepEqual(
    {
      m16: WEAPON_CATALOG["Google2u.AssaultRifle_M16"]?.index,
      dp64: WEAPON_CATALOG["Google2u.GrenadeLauncher_DP64"]?.index,
      p320: WEAPON_CATALOG["Google2u.Pistol_P320"]?.index,
      art9: WEAPON_CATALOG["Google2u.AssaultRifle_ART9"]?.index,
    },
    { m16: 0, dp64: 124, p320: 134, art9: 192 },
  );
  // These rows have prices in WeaponUpgrades but null LevelManager references in MainScene.
  // Keeping them absent proves the server will fail closed instead of granting unusable items.
  assert.equal(WEAPON_CATALOG["Google2u.PulseRifle_Grade1"], undefined);
  assert.equal(WEAPON_CATALOG["Google2u.PulseRifle_PR9"], undefined);
});

test("Gold and WarBucks catalog rows use their recovered indexes and compatible slots", () => {
  const m16 = parseWeaponPurchaseData(purchaseData({
    Name: "Google2u.AssaultRifle_M16",
    Gold: 269,
    UnlockLevel: 9,
  }));
  const m16Bought = purchaseWeaponState({ ...createInitialProgression(NOW), gold: 269 }, 5, m16);
  const m16Equipped = equipWeaponState(m16Bought.state, parseWeaponEquipData(equipData({
    Name: "Google2u.AssaultRifle_M16",
    Index: "0",
  })));
  assert.equal(m16Equipped.state.gold, 0);
  assert.deepEqual(m16Equipped.state.itemInventory?.inventoryData.slots["0"], {
    name: "Google2u.AssaultRifle_M16",
    weaponIndex: 0,
  });

  const benelli = parseWeaponPurchaseData(purchaseData({
    Name: "Google2u.Shotgun_Benelli",
    Warbucks: 8_999,
    Gold: 0,
    UnlockLevel: 6,
  }));
  const benelliBought = purchaseWeaponState(
    { ...createInitialProgression(NOW), warBucks: 9_000 },
    2,
    benelli,
  );
  const benelliEquipped = equipWeaponState(benelliBought.state, parseWeaponEquipData(equipData({
    Name: "Google2u.Shotgun_Benelli",
    Index: "27",
    SlotIndex: 1,
  })));
  assert.equal(benelliEquipped.state.warBucks, 1);
  assert.deepEqual(benelliEquipped.state.itemInventory?.inventoryData.slots["1"], {
    name: "Google2u.Shotgun_Benelli",
    weaponIndex: 27,
  });

  const dp64 = parseWeaponPurchaseData(purchaseData({
    Name: "Google2u.GrenadeLauncher_DP64",
    Gold: 499,
    UnlockLevel: 19,
  }));
  const dp64Bought = purchaseWeaponState({ ...createInitialProgression(NOW), gold: 499 }, 15, dp64);
  const dp64Equipped = equipWeaponState(dp64Bought.state, parseWeaponEquipData(equipData({
    Name: "Google2u.GrenadeLauncher_DP64",
    Index: "124",
    SlotIndex: 2,
  })));
  assert.deepEqual(dp64Equipped.state.itemInventory?.inventoryData.slots["2"], {
    name: "Google2u.GrenadeLauncher_DP64",
    weaponIndex: 124,
  });
});

test("EquipWeapon requires ownership, exact catalog index, and a compatible slot", () => {
  const initial = { ...createInitialProgression(NOW), gold: 1_000 };
  const equip = parseWeaponEquipData(equipData());

  assert.throws(
    () => equipWeaponState(initial, equip),
    (error: unknown) => (error as { code?: number }).code === ITEM_WEAPON_NOT_BOUGHT,
  );

  const bought = purchaseWeaponState(initial, 13, parseWeaponPurchaseData(purchaseData()));
  assert.throws(
    () => equipWeaponState(bought.state, { ...equip, slotIndex: 3 }),
    (error: unknown) => (error as { code?: number }).code === ITEM_WEAPON_NOT_BOUGHT,
  );
  assert.throws(
    () => equipWeaponState(bought.state, { ...equip, index: 999 }),
    (error: unknown) => (error as { code?: number }).code === ITEM_WEAPON_NOT_BOUGHT,
  );

  const equipped = equipWeaponState(bought.state, equip);
  assert.deepEqual(equipped.state.itemInventory?.inventoryData.slots["0"], {
    name: FAMAS,
    weaponIndex: 2,
  });
  // The untrusted client-calculated ArmyPower is not copied into server progression.
  assert.equal("armyPower" in equipped.state, false);
});

test("weapon RequestBuffer purchase/equip is atomic and replay-safe by BufferId", () => {
  const initial = { ...createInitialProgression(NOW), gold: 1_000 };
  const requests = [
    { action: DbAction.BuyWeapon, data: purchaseData() },
    { action: DbAction.EquipWeapon, data: equipData() },
  ];
  const first = processAssignmentBufferState(initial, NOW, "weapon-buffer-1", requests, 13);
  assert.deepEqual(JSON.parse(first.requestsResults), [
    { ActionId: DbAction.BuyWeapon, Result: 1 },
    { ActionId: DbAction.EquipWeapon, Result: 1 },
  ]);
  assert.equal(first.state.gold, 51);
  assert.equal(first.state.itemInventory?.inventoryData.slots["0"]?.weaponIndex, 2);

  const replay = processAssignmentBufferState(first.state, NOW + 10, "weapon-buffer-1", requests, 13);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.gold, 51);
  assert.equal(replay.requestsResults, first.requestsResults);
});

test("failed buffered weapon purchase returns the exact rollback fields Unity consumes", () => {
  const initial = { ...createInitialProgression(NOW), gold: 1_000 };
  const result = processAssignmentBufferState(
    initial,
    NOW,
    "weapon-buffer-bad-price",
    [{ action: DbAction.BuyWeapon, data: purchaseData({ Gold: 1 }) }],
    13,
  );
  const [response] = JSON.parse(result.requestsResults) as Array<Record<string, unknown>>;

  assert.equal(response.ActionId, DbAction.BuyWeapon);
  assert.equal(response.Result, ITEM_PRICE_MISMATCH);
  assert.equal(response.LevelName, FAMAS);
  assert.equal(response.Gold, 1_000);
  assert.equal(response.WarBucks, 0);
  assert.equal(typeof response.Weapon, "string");
  assert.equal(typeof response.InventoryData, "string");
  assert.equal(typeof response.weaponDelivery, "string");
  assert.equal(result.state.gold, 1_000);
  assert.equal(result.state.itemInventory?.levelManagerData.savedWeapons[FAMAS], undefined);
});
