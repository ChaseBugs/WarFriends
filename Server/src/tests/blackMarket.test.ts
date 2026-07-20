import assert from "node:assert/strict";
import test from "node:test";
import { ApiError } from "../apiErrors";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { WEAPON_BLACK_MARKET_PRICES } from "../data/weaponUpgradeCatalog.generated";
import {
  BLACK_MARKET_OFFER_COUNT,
  BLACK_MARKET_OFFER_SECONDS,
  ensureBlackMarketOfferState,
  serializeBlackMarketOffer,
} from "../services/blackMarketService";
import {
  BLACK_MARKET_WEAPON_CATALOG,
  equipWeaponState,
  ITEM_PRICE_MISMATCH,
  parseWeaponPurchaseData,
  parseWeaponEquipData,
  purchaseWeaponState,
  WEAPON_CATALOG,
} from "../services/itemInventoryService";
import { equippedWeaponPower } from "../services/armyPowerService";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";

const NOW = 1_900_000_000;

test("Black Market issues one stable four-weapon set and rotates it only after expiry", () => {
  const initial = createInitialProgression(NOW);
  const issued = ensureBlackMarketOfferState(initial, "player-black-market", 7, NOW);

  assert.equal(issued.issued, true);
  assert.equal(issued.blackMarket.offersTotal, 1);
  assert.equal(issued.blackMarket.lastTrigger, "ServerSchedule");
  assert.equal(issued.blackMarket.offerEnd, NOW + BLACK_MARKET_OFFER_SECONDS);
  assert.equal(issued.blackMarket.currentOffers.length, BLACK_MARKET_OFFER_COUNT);
  assert.equal(
    new Set(issued.blackMarket.currentOffers.map((offer) => offer.weaponId)).size,
    BLACK_MARKET_OFFER_COUNT,
  );
  for (const offer of issued.blackMarket.currentOffers) {
    assert.equal(offer.level, 7);
    assert.equal(offer.special, 0);
    assert.equal(BLACK_MARKET_WEAPON_CATALOG[offer.weaponId]?.starterOwned, false);
    assert.equal(WEAPON_CATALOG[offer.weaponId], undefined);
    assert.ok(WEAPON_BLACK_MARKET_PRICES[offer.weaponId]?.[offer.level] !== undefined);
  }

  const replay = ensureBlackMarketOfferState(issued.state, "player-black-market", 99, NOW + 60);
  assert.equal(replay.issued, false);
  assert.equal(replay.state, issued.state, "active offer replay must not advance revision");
  assert.deepEqual(replay.blackMarket, issued.blackMarket);

  const rotated = ensureBlackMarketOfferState(
    replay.state,
    "player-black-market",
    8,
    issued.blackMarket.offerEnd,
  );
  assert.equal(rotated.issued, true);
  assert.equal(rotated.blackMarket.offersTotal, 2);
  assert.equal(rotated.blackMarket.offerEnd, issued.blackMarket.offerEnd + BLACK_MARKET_OFFER_SECONDS);
});

test("Black Market redemption derives price, level, and feature from the active stored offer", () => {
  const initial = { ...createInitialProgression(NOW), gold: 10_000_000 };
  const issued = ensureBlackMarketOfferState(initial, "player-redeem", 5, NOW);
  const offer = issued.blackMarket.currentOffers[0]!;
  const definition = BLACK_MARKET_WEAPON_CATALOG[offer.weaponId]!;
  const gold = WEAPON_BLACK_MARKET_PRICES[offer.weaponId]![offer.level]!;
  const payload = parseWeaponPurchaseData(JSON.stringify({
    Name: offer.weaponId,
    Warbucks: 0,
    Gold: gold,
    UnlockLevel: definition.unlockLevel,
    StartTime: NOW,
    discount: 0,
  }));

  // Black Market authority deliberately bypasses the normal unlock gate: this account has
  // profile level zero, while the issued weapon can be a later normal-shop row.
  const bought = purchaseWeaponState(issued.state, 0, payload, NOW + 1);
  assert.equal(bought.state.gold, initial.gold - gold);
  assert.equal(bought.state.warBucks, initial.warBucks);
  assert.deepEqual(bought.weapon, {
    bought: true,
    boughtIndex: offer.level,
    showed: true,
    borrowed: false,
    specialFeature: offer.special,
  });

  const slotMasks = [263, 1064, 592, 128];
  const slotIndex = slotMasks.findIndex((mask) => (definition.category & mask) === definition.category);
  assert.notEqual(slotIndex, -1);
  const equipped = equipWeaponState(bought.state, parseWeaponEquipData(JSON.stringify({
    Name: offer.weaponId,
    Index: String(definition.index),
    SlotIndex: slotIndex,
    ArmyPower: 0,
    SpecialFeature: offer.special,
  })));
  assert.equal(
    equipped.state.itemInventory?.inventoryData.slots[String(slotIndex)]?.name,
    offer.weaponId,
  );
  assert.ok(equippedWeaponPower(equipped.state) > 0);

  for (const [changedPayload, purchaseTime] of [
    [{ ...payload, gold: payload.gold + 1 }, NOW + 1],
    [payload, issued.blackMarket.offerEnd],
  ] as const) {
    assert.throws(
      () => purchaseWeaponState(issued.state, 0, changedPayload, purchaseTime),
      (error) => error instanceof ApiError && error.code === ITEM_PRICE_MISMATCH,
    );
  }
});

test("Black Market wire serializer exposes only the recovered client fields", () => {
  const issued = ensureBlackMarketOfferState(
    createInitialProgression(NOW),
    "player-wire",
    3,
    NOW,
  );
  const wire = JSON.parse(serializeBlackMarketOffer(issued.blackMarket)) as Record<string, unknown>;
  assert.deepEqual(Object.keys(wire).sort(), ["currentOffers", "lastTrigger", "offerEnd", "offersTotal"]);
  assert.deepEqual(
    Object.keys((wire.currentOffers as Record<string, unknown>[])[0]!).sort(),
    ["level", "special", "weaponId"],
  );

  const player = newPlayer("player-wire", "BlackMarketWire", AccountType.Guest);
  const document: PlayerDocument = {
    id: player.id,
    accountName: player.accountName,
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: issued.state,
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
  const boot = buildPlayerData(document).BlackMarketOfferData as { S: string };
  assert.deepEqual(JSON.parse(boot.S), wire);
});
