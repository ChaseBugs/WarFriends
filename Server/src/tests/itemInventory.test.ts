import assert from "node:assert/strict";
import test from "node:test";
import generatedWeaponCatalog from "../data/weaponCatalog.generated.json";
import { DbAction } from "../dbActions";
import {
  acknowledgeBufferedMessageIgnoresState,
  processAssignmentBufferState,
} from "../services/assignmentService";
import {
  activateWeaponState,
  activateWeaponUpgradeState,
  createInitialItemInventory,
  equipWeaponState,
  instantBuyWeaponState,
  instantWeaponUpgradeState,
  ITEM_ALREADY_UPGRADING,
  ITEM_NEGATIVE_PRICE_FROM_CLIENT,
  ITEM_NO_DISCOUNT_FOUND,
  ITEM_NOT_ENOUGH_GOLD,
  ITEM_NOT_ENOUGH_LEVEL,
  ITEM_NOT_ENOUGH_WARBUCKS,
  ITEM_PRICE_MISMATCH,
  ITEM_TOO_SOON_TO_ACTIVATE,
  ITEM_WRONG_INDEX_TO_ACTIVATE,
  ITEM_WEAPON_NOT_BOUGHT,
  parseWeaponUpgradeActivateData,
  parseWeaponActivateData,
  parseWeaponPurchaseInstantData,
  parseWeaponUpgradeInstantData,
  parseWeaponUpgradePurchaseData,
  parseWeaponEquipData,
  parseWeaponPurchaseData,
  purchaseWeaponState,
  serializeInventoryData,
  serializeLevelManagerData,
  startWeaponUpgradeState,
  BLACK_MARKET_WEAPON_CATALOG,
  WEAPON_CATALOG,
  weaponUpgradeInstantPrice,
} from "../services/itemInventoryService";
import {
  WEAPON_BLACK_MARKET_PRICES,
  WEAPON_UPGRADE_CATALOG,
} from "../data/weaponUpgradeCatalog.generated";
import { createInitialProgression } from "../services/playerStateService";
import {
  SUBSCRIPTION_UPGRADE_TIME_MULTIPLIER,
  subscriptionUpgradeDeliverySeconds,
} from "../services/subscriptionBenefitService";
import { MAX_ITEM_DELIVERY_UNIX_SECONDS } from "../services/itemDeliveryTimeAuthorityService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;
const FAMAS = "Google2u.AssaultRifle_Famas";
const AK47 = "Google2u.AssaultRifle_AK47";

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

function activateData(overrides: Record<string, unknown> = {}): string {
  return JSON.stringify({ LevelName: FAMAS, ...overrides });
}

function instantBuyData(overrides: Record<string, unknown> = {}): string {
  return JSON.stringify({
    LevelName: FAMAS,
    ExpectedPrice: 0,
    GoldCoefficient: 0.6325,
    GoldExpCoefficient: -0.175,
    ...overrides,
  });
}

function upgradePurchaseData(overrides: Record<string, unknown> = {}): string {
  return JSON.stringify({
    LevelName: AK47,
    BoughtIndex: 0,
    StartTime: NOW,
    discount: 0,
    DeliveryTime: 60,
    deliveryReduce: 0,
    ...overrides,
  });
}

function upgradeActivateData(overrides: Record<string, unknown> = {}): string {
  return JSON.stringify({
    LevelName: AK47,
    BoughtIndex: 0,
    ArmyPower: 100,
    ...overrides,
  });
}

function upgradeInstantData(expectedPrice: number, overrides: Record<string, unknown> = {}): string {
  return JSON.stringify({
    LevelName: AK47,
    BoughtIndex: 0,
    ExpectedPrice: expectedPrice,
    ArmyPower: 100,
    GoldCoefficient: 0.6325,
    GoldExpCoefficient: -0.175,
    discount: 0,
    ...overrides,
  });
}

test("weapon request parsers preserve recovered JSON number and Index text shapes", () => {
  assert.equal(parseWeaponPurchaseData(purchaseData()).discount, 0);
  for (const field of ["Warbucks", "Gold", "UnlockLevel", "StartTime", "discount"]) {
    assert.throws(
      () => parseWeaponPurchaseData(purchaseData({ [field]: "0" })),
      (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
    );
  }
  assert.throws(
    () => parseWeaponPurchaseData(purchaseData({ discount: undefined })),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
  );

  assert.equal(parseWeaponEquipData(equipData()).index, 2);
  for (const index of [2, "02", "+2", "2.0", "2e0", "2147483648"]) {
    assert.throws(
      () => parseWeaponEquipData(equipData({ Index: index })),
      (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
    );
  }

  assert.equal(parseWeaponUpgradeInstantData(upgradeInstantData(1)).goldCoefficient, 0.6325);
  assert.throws(
    () => parseWeaponUpgradeInstantData(upgradeInstantData(1, { GoldCoefficient: "0.6325" })),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
  );
});

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

test("weapon upgrade catalog covers shop and Black Market families with recovered variable-length stages", () => {
  const allNames = [...Object.keys(WEAPON_CATALOG), ...Object.keys(BLACK_MARKET_WEAPON_CATALOG)].sort();
  assert.equal(Object.keys(WEAPON_UPGRADE_CATALOG).length, 165);
  assert.deepEqual(Object.keys(WEAPON_UPGRADE_CATALOG).sort(), allNames);
  assert.equal(
    Object.values(WEAPON_UPGRADE_CATALOG).reduce((total, stages) => total + stages.length, 0),
    11_640,
  );
  assert.equal(Object.keys(WEAPON_BLACK_MARKET_PRICES).length, 79);
  assert.equal(
    Object.values(WEAPON_BLACK_MARKET_PRICES).reduce((total, prices) => total + prices.length, 0),
    5_860,
  );
  assert.deepEqual(WEAPON_UPGRADE_CATALOG[AK47]?.[0], [500, 60]);
  assert.deepEqual(WEAPON_UPGRADE_CATALOG[FAMAS]?.[0], [10_900, 60]);
  assert.equal(WEAPON_UPGRADE_CATALOG[AK47]?.length, 24);
  assert.equal(WEAPON_UPGRADE_CATALOG[FAMAS]?.length, 54);
});

test("weapon upgrade purchase debits WarBucks and activation waits for server delivery", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 2_000 };
  const started = startWeaponUpgradeState(
    initial,
    NOW,
    parseWeaponUpgradePurchaseData(upgradePurchaseData()),
  );

  assert.equal(started.state.warBucks, 1_500);
  assert.equal(started.weapon.boughtIndex, 0);
  assert.equal(started.deliveryTime, 60);
  assert.deepEqual(started.itemInventory.levelManagerData.weaponDelivery, {
    activationNeeded: true,
    boughtIndex: 0,
    end: NOW + 60,
    itemId: AK47,
    slotId: 0,
    start: NOW,
  });

  for (const invalidTime of [NaN, Infinity, -1, 0.5, MAX_ITEM_DELIVERY_UNIX_SECONDS + 1]) {
    assert.throws(
      () => startWeaponUpgradeState(initial, invalidTime, parseWeaponUpgradePurchaseData(upgradePurchaseData())),
      /(?:Subscription comparison time|Weapon upgrade receipt time) is invalid/u,
    );
    assert.throws(
      () => activateWeaponUpgradeState(
        started.state,
        invalidTime,
        parseWeaponUpgradeActivateData(upgradeActivateData()),
      ),
      /Weapon upgrade activation time is invalid/u,
    );
    assert.throws(
      () => instantWeaponUpgradeState(
        started.state,
        invalidTime,
        parseWeaponUpgradeInstantData(upgradeInstantData(weaponUpgradeInstantPrice(60))),
      ),
      /Weapon instant-upgrade time is invalid/u,
    );
  }
  assert.throws(
    () => startWeaponUpgradeState(
      initial,
      MAX_ITEM_DELIVERY_UNIX_SECONDS,
      parseWeaponUpgradePurchaseData(upgradePurchaseData()),
    ),
    /Weapon upgrade receipt end is invalid/u,
  );

  assert.throws(
    () => activateWeaponUpgradeState(
      started.state,
      NOW + 59,
      parseWeaponUpgradeActivateData(upgradeActivateData()),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_TOO_SOON_TO_ACTIVATE,
  );

  const activated = activateWeaponUpgradeState(
    started.state,
    NOW + 60,
    parseWeaponUpgradeActivateData(upgradeActivateData()),
  );
  assert.equal(activated.weapon.boughtIndex, 1);
  assert.deepEqual(activated.itemInventory.levelManagerData.weaponDelivery, {
    activationNeeded: false,
    boughtIndex: 0,
    end: 0,
    itemId: "",
    slotId: 0,
    start: 0,
  });
});

test("active subscription applies the recovered float32 0.8 weapon delivery multiplier", () => {
  const initial = {
    ...createInitialProgression(NOW),
    warBucks: 2_000,
    subscription: {
      type: "subscription1" as const,
      subscribeSince: NOW - 1,
      expireTime: NOW + 3_600,
      dogTagTimerLock: NOW,
    },
  };
  assert.equal(SUBSCRIPTION_UPGRADE_TIME_MULTIPLIER, Math.fround(0.8));
  assert.equal(subscriptionUpgradeDeliverySeconds(initial, NOW, 60), 48);
  const started = startWeaponUpgradeState(
    initial,
    NOW,
    parseWeaponUpgradePurchaseData(upgradePurchaseData({ DeliveryTime: 48 })),
  );
  assert.equal(started.deliveryTime, 48);
  assert.equal(started.itemInventory.levelManagerData.weaponDelivery.end, NOW + 48);
  assert.throws(
    () => startWeaponUpgradeState(
      initial,
      NOW,
      parseWeaponUpgradePurchaseData(upgradePurchaseData({ DeliveryTime: 60 })),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
  );
  assert.equal(subscriptionUpgradeDeliverySeconds(initial, NOW + 3_600, 60), 60);

  for (const invalid of [NaN, Infinity, -1, 0.5, 2_147_483_648]) {
    assert.throws(
      () => subscriptionUpgradeDeliverySeconds(initial, NOW, invalid),
      /Subscription upgrade delivery duration is invalid/,
    );
    assert.throws(
      () => subscriptionUpgradeDeliverySeconds(initial, NOW + 3_600, invalid),
      /Subscription upgrade delivery duration is invalid/,
    );
  }

  // A corrupt imported deadline must fail closed instead of turning the 20% paid speed benefit
  // into permanent access through JavaScript's `Infinity > now` comparison behavior.
  assert.throws(
    () => subscriptionUpgradeDeliverySeconds({
      ...initial,
      subscription: { ...initial.subscription, expireTime: Number.POSITIVE_INFINITY },
    }, NOW, 60),
    /Subscription expiry is invalid/,
  );
});

test("weapon upgrade rejects stale indexes and a second shared delivery", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 2_000 };
  assert.throws(
    () => startWeaponUpgradeState(
      initial,
      NOW,
      parseWeaponUpgradePurchaseData(upgradePurchaseData({ DeliveryTime: 59 })),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
  );
  assert.throws(
    () => startWeaponUpgradeState(
      initial,
      NOW,
      parseWeaponUpgradePurchaseData(upgradePurchaseData({ discount: 1 })),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_NO_DISCOUNT_FOUND,
  );
  assert.throws(
    () => startWeaponUpgradeState(
      { ...initial, warBucks: 499 },
      NOW,
      parseWeaponUpgradePurchaseData(upgradePurchaseData()),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_NOT_ENOUGH_WARBUCKS,
  );
  assert.throws(
    () => startWeaponUpgradeState(
      initial,
      NOW,
      parseWeaponUpgradePurchaseData(upgradePurchaseData({ BoughtIndex: 1 })),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_WRONG_INDEX_TO_ACTIVATE,
  );

  const started = startWeaponUpgradeState(
    initial,
    NOW,
    parseWeaponUpgradePurchaseData(upgradePurchaseData()),
  );
  assert.throws(
    () => startWeaponUpgradeState(
      started.state,
      NOW + 1,
      parseWeaponUpgradePurchaseData(upgradePurchaseData()),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_ALREADY_UPGRADING,
  );
});

test("instant weapon upgrade derives Gold from remaining server time", () => {
  // This long-duration boundary distinguishes the stock client's float32 calculation from
  // a superficially similar JavaScript-double implementation (761 versus 760 Gold).
  assert.equal(weaponUpgradeInstantPrice(324_478), 761);
  const initial = { ...createInitialProgression(NOW), warBucks: 500, gold: 10 };
  const started = startWeaponUpgradeState(
    initial,
    NOW,
    parseWeaponUpgradePurchaseData(upgradePurchaseData()),
  );
  const price = weaponUpgradeInstantPrice(30);
  assert.equal(price, 1);

  assert.throws(
    () => instantWeaponUpgradeState(
      started.state,
      NOW + 30,
      parseWeaponUpgradeInstantData(upgradeInstantData(price + 1)),
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_MISMATCH,
  );

  const finished = instantWeaponUpgradeState(
    started.state,
    NOW + 30,
    parseWeaponUpgradeInstantData(upgradeInstantData(price)),
  );
  assert.equal(finished.state.gold, 9);
  assert.equal(finished.goldSpent, 1);
  assert.equal(finished.weapon.boughtIndex, 1);
  assert.equal(finished.itemInventory.levelManagerData.weaponDelivery.activationNeeded, false);
});

test("queued instant upgrade accepts an earlier receipt-backed price without undercharging", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 1_060, gold: 10 };
  const firstStarted = startWeaponUpgradeState(
    initial,
    NOW,
    parseWeaponUpgradePurchaseData(upgradePurchaseData()),
  );
  const firstActivated = activateWeaponUpgradeState(
    firstStarted.state,
    NOW + 60,
    parseWeaponUpgradeActivateData(upgradeActivateData()),
  );
  const secondStarted = startWeaponUpgradeState(
    firstActivated.state,
    NOW + 60,
    parseWeaponUpgradePurchaseData(upgradePurchaseData({
      BoughtIndex: 1,
      StartTime: NOW + 60,
      DeliveryTime: 180,
    })),
  );

  // The client can calculate the full-duration price and then sit in RequestBuffer while
  // server time advances. Charging the exact sent amount preserves the optimistic wallet;
  // the receipt-derived lower bound still prevents a modified client from underpaying.
  const priceAtClientQueue = weaponUpgradeInstantPrice(180);
  const priceAtServerReceipt = weaponUpgradeInstantPrice(60);
  assert.equal(priceAtClientQueue, 2);
  assert.equal(priceAtServerReceipt, 1);
  const finished = instantWeaponUpgradeState(
    secondStarted.state,
    NOW + 180,
    parseWeaponUpgradeInstantData(upgradeInstantData(priceAtClientQueue, { BoughtIndex: 1 })),
  );
  assert.equal(finished.goldSpent, 2);
  assert.equal(finished.state.gold, 8);
  assert.equal(finished.weapon.boughtIndex, 2);
});

test("failed instant upgrade returns code 7002 and the authoritative rollback receipt", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 500, gold: 10 };
  const purchase = processAssignmentBufferState(
    initial,
    NOW,
    "weapon-upgrade-negative-start",
    [{ action: DbAction.BuyWeaponUpgrade, data: upgradePurchaseData() }],
  );
  const failed = processAssignmentBufferState(
    purchase.state,
    NOW + 30,
    "weapon-upgrade-negative-finish",
    [{ action: DbAction.InstantWeaponUpgrade, data: upgradeInstantData(-1) }],
  );
  const [response] = JSON.parse(failed.requestsResults) as Array<Record<string, unknown>>;

  assert.equal(response.Result, ITEM_NEGATIVE_PRICE_FROM_CLIENT);
  assert.equal(response.Result, 7_002);
  assert.equal(response.Gold, 10);
  assert.equal(response.WarBucks, 0);
  assert.equal(JSON.parse(String(response.Weapon)).boughtIndex, 0);
  assert.equal(JSON.parse(String(response.weaponDelivery)).itemId, AK47);
  assert.equal(failed.state.gold, 10);
  assert.equal(failed.state.itemInventory?.levelManagerData.savedWeapons[AK47]?.boughtIndex, 0);
});

test("buffered weapon upgrade returns duration and instant completion is replay-safe", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 500, gold: 10 };
  const purchase = processAssignmentBufferState(
    initial,
    NOW,
    "weapon-upgrade-start",
    [{ action: DbAction.BuyWeaponUpgrade, data: upgradePurchaseData() }],
  );
  assert.deepEqual(JSON.parse(purchase.requestsResults), [{
    ActionId: DbAction.BuyWeaponUpgrade,
    Result: 1,
    DeliveryTime: 60,
  }]);
  assert.equal(purchase.state.warBucks, 0);

  const price = weaponUpgradeInstantPrice(30);
  const request = [{ action: DbAction.InstantWeaponUpgrade, data: upgradeInstantData(price) }];
  const first = processAssignmentBufferState(
    purchase.state,
    NOW + 30,
    "weapon-upgrade-finish",
    request,
  );
  assert.equal(first.state.gold, 9);
  assert.equal(first.state.itemInventory?.levelManagerData.savedWeapons[AK47]?.boughtIndex, 1);

  const replay = processAssignmentBufferState(
    first.state,
    NOW + 40,
    "weapon-upgrade-finish",
    request,
  );
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.gold, 9);
  assert.equal(replay.state.itemInventory?.levelManagerData.savedWeapons[AK47]?.boughtIndex, 1);
  assert.equal(replay.requestsResults, first.requestsResults);
});

test("runtime weapon catalog exactly matches the reproducible 4.9.5 extraction artifact", () => {
  const runtimeRows = Object.values(WEAPON_CATALOG).sort((left, right) => left.index - right.index);
  const blackMarketRows = Object.values(BLACK_MARKET_WEAPON_CATALOG)
    .sort((left, right) => left.index - right.index);

  assert.equal(generatedWeaponCatalog.schemaVersion, 1);
  assert.equal(generatedWeaponCatalog.source, "Client/ExportedProject/Assets/Scenes/MainScene.unity");
  assert.match(generatedWeaponCatalog.sourceSha256, /^[0-9a-f]{64}$/);
  assert.deepEqual(runtimeRows, generatedWeaponCatalog.catalog);
  assert.deepEqual(blackMarketRows, generatedWeaponCatalog.blackMarketCatalog);
  assert.equal(generatedWeaponCatalog.unresolvedBlackMarketRows.length, 9);
  assert.deepEqual(
    generatedWeaponCatalog.unresolvedShopRows.map((row) => row.name).sort(),
    [
      "Google2u.PulseRifle_Grade1",
      "Google2u.PulseRifle_Grade2",
      "Google2u.PulseRifle_Grade3",
      "Google2u.PulseRifle_Grade4",
      "Google2u.PulseRifle_Grade5",
      "Google2u.PulseRifle_Grade6",
      "Google2u.PulseRifle_Grade7",
      "Google2u.PulseRifle_Grade8",
      "Google2u.PulseRifle_PR9",
    ],
  );
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
  const replay = equipWeaponState(equipped.state, equip);
  assert.equal(replay.state, equipped.state);
  assert.equal(replay.state.revision, equipped.state.revision);
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

test("ActivateWeapon validates a permanent purchase and never grants or debits twice", () => {
  const initial = { ...createInitialProgression(NOW), gold: 1_000 };
  const payload = parseWeaponActivateData(activateData());

  assert.throws(
    () => activateWeaponState(initial, payload),
    (error: unknown) => (error as { code?: number }).code === ITEM_WRONG_INDEX_TO_ACTIVATE,
  );

  const bought = purchaseWeaponState(initial, 13, parseWeaponPurchaseData(purchaseData()));
  const activated = activateWeaponState(bought.state, payload);
  assert.equal(activated.state, bought.state);
  assert.equal(activated.state.gold, 51);
  assert.equal(activated.weapon.bought, true);
});

test("InstantBuyWeapon is a zero-price ownership acknowledgement, not a second purchase", () => {
  const initial = { ...createInitialProgression(NOW), gold: 1_000 };
  const payload = parseWeaponPurchaseInstantData(instantBuyData());
  assert.throws(() => instantBuyWeaponState(initial, payload), /permanent weapon purchase/);

  const requests = [
    { action: DbAction.BuyWeapon, data: purchaseData() },
    { action: DbAction.InstantBuyWeapon, data: instantBuyData() },
  ];
  const result = processAssignmentBufferState(initial, NOW, "weapon-instant-buy", requests, 13);
  assert.deepEqual(JSON.parse(result.requestsResults), [
    { ActionId: DbAction.BuyWeapon, Result: 1 },
    { ActionId: DbAction.InstantBuyWeapon, Result: 1 },
  ]);
  assert.equal(result.state.gold, 51);

  const forged = processAssignmentBufferState(
    initial,
    NOW,
    "weapon-instant-buy-forged",
    [
      { action: DbAction.BuyWeapon, data: purchaseData() },
      { action: DbAction.InstantBuyWeapon, data: instantBuyData({ ExpectedPrice: 1 }) },
    ],
    13,
  );
  assert.equal((JSON.parse(forged.requestsResults) as Array<{ Result: number }>)[1]?.Result, ITEM_PRICE_MISMATCH);
  assert.equal(forged.state.gold, 51);
});

test("buffered BuyWeapon/ActivateWeapon and message impression are ordered and replay-safe", () => {
  const initial = { ...createInitialProgression(NOW), gold: 1_000 };
  const requests = [
    { action: DbAction.BuyWeapon, data: purchaseData() },
    { action: DbAction.ActivateWeapon, data: activateData() },
    {
      action: DbAction.MessageWasShown,
      data: JSON.stringify({ MessageId: "message-1", PlayerId: "untrusted-echo" }),
    },
  ];
  const first = processAssignmentBufferState(initial, NOW, "weapon-activate-buffer", requests, 13);
  assert.deepEqual(JSON.parse(first.requestsResults), [
    { ActionId: DbAction.BuyWeapon, Result: 1 },
    { ActionId: DbAction.ActivateWeapon, Result: 1 },
    { ActionId: DbAction.MessageWasShown, Result: 1 },
  ]);
  assert.equal(first.state.gold, 51);
  assert.equal(first.state.itemInventory?.levelManagerData.savedWeapons[FAMAS]?.bought, true);

  const replay = processAssignmentBufferState(
    first.state,
    NOW + 10,
    "weapon-activate-buffer",
    requests,
    13,
  );
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.state.gold, 51);
});

test("buffered IgnoreMessage persists a bounded retryable outbox entry", () => {
  const initial = createInitialProgression(NOW);
  const request = [{ action: DbAction.IgnoreMessage, data: "message-123" }];
  const first = processAssignmentBufferState(initial, NOW, "ignore-message-buffer", request);

  assert.deepEqual(JSON.parse(first.requestsResults), [
    { ActionId: DbAction.IgnoreMessage, Result: 1 },
  ]);
  assert.deepEqual(first.state.pendingMessageIgnores, ["message-123"]);

  const replay = processAssignmentBufferState(
    first.state,
    NOW + 1,
    "ignore-message-buffer",
    request,
  );
  assert.equal(replay.replayed, true);
  assert.deepEqual(replay.state.pendingMessageIgnores, ["message-123"]);
  assert.equal(replay.requestsResults, first.requestsResults);
});

test("buffered IgnoreMessage rejects invalid IDs without discarding a full durable outbox", () => {
  const pendingMessageIgnores = Array.from({ length: 100 }, (_, index) => `message-${index}`);
  const initial = { ...createInitialProgression(NOW), pendingMessageIgnores };
  const result = processAssignmentBufferState(
    initial,
    NOW,
    "ignore-message-full",
    [{ action: DbAction.IgnoreMessage, data: "message-new" }],
  );
  const [response] = JSON.parse(result.requestsResults) as Array<Record<string, unknown>>;

  assert.equal(response.Result, 90);
  assert.deepEqual(result.state.pendingMessageIgnores, pendingMessageIgnores);
});

test("completed message-ignore outbox entries are cleared selectively and idempotently", () => {
  const initial = {
    ...createInitialProgression(NOW),
    pendingMessageIgnores: ["message-1", "message-2"],
  };
  const cleared = acknowledgeBufferedMessageIgnoresState(initial, ["message-1"]);
  assert.deepEqual(cleared.pendingMessageIgnores, ["message-2"]);
  assert.equal(cleared.revision, initial.revision + 1);

  const repeated = acknowledgeBufferedMessageIgnoresState(cleared, ["message-1"]);
  assert.equal(repeated, cleared);
  const empty = acknowledgeBufferedMessageIgnoresState(cleared, ["message-2"]);
  assert.equal(empty.pendingMessageIgnores, undefined);
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
