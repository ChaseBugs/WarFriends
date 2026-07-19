import assert from "node:assert/strict";
import test from "node:test";
import generatedCardCatalog from "../data/cardCatalog.generated.json";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  CARD_PACK_NO_DISCOUNT,
  CARD_PACK_NOT_ENOUGH_FUNDS,
  CARD_PACK_NOT_FOUND,
  createInitialCardInventory,
  purchaseCardPackState,
} from "../services/cardInventoryService";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";

const NOW = 1_700_000_000;

function playerDocument(): PlayerDocument {
  const player = newPlayer("card-player", "CardPlayer", AccountType.Guest);
  return {
    id: player.id,
    accountName: player.accountName,
    authToken: "token",
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: createInitialProgression(NOW),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

function packData(cardPack: string, cards: string[], discount = 0): string {
  return JSON.stringify({ cards, cardPack, discount, StartTime: NOW });
}

const GOLD_PACK_CARDS = [
  "AIRSTRIKE", "APOCALYPSE", "BIGMEDKIT", "BIGROCKET", "CLUSTERGRENADE",
  "AMMOBOX", "AMMOTHIEF", "BOOBYTRAP", "DECOY", "ELECTRICTRAPS",
];

test("card extraction joins serialized components, definitions, pack prices, and rarity rules", () => {
  assert.equal(generatedCardCatalog.schemaVersion, 1);
  assert.equal(generatedCardCatalog.clientVersion, "4.9.5");
  assert.match(generatedCardCatalog.sourceSha256, /^[0-9a-f]{64}$/);
  assert.equal(generatedCardCatalog.unlockLevel, 6);
  assert.equal(generatedCardCatalog.cards.length, 58);
  assert.equal(generatedCardCatalog.cards.every((card) => card.implemented), true);
  assert.equal(generatedCardCatalog.unresolvedRows.length, 25);
  assert.equal(generatedCardCatalog.packs.length, 4);
  assert.deepEqual(
    generatedCardCatalog.packs.map((pack) => [
      pack.name,
      pack.priceGold,
      pack.priceWarBucks,
      pack.cardCount,
      pack.fixedRarityCount,
      pack.guaranteedRarity,
      pack.maxRarity,
    ]),
    [
      ["BRONZE_CARDPACK", 19, 0, 10, 7, 1, 2],
      ["SILVER_CARDPACK", 39, 0, 10, 6, 2, 3],
      ["GOLD_CARDPACK", 69, 0, 10, 5, 2, 3],
      ["THREE_CARDS", 0, 1_200, 3, 0, 1, 3],
    ],
  );
});

test("new accounts serialize the exact empty CardManagerData contract", () => {
  const initial = createInitialCardInventory();
  assert.deepEqual(initial, {
    cardData: {},
    buddyCardData: {},
    nextWithdraw: 0,
    nextBuddyDeposit: 0,
    extraSlot: false,
  });
  const wire = buildPlayerData(playerDocument());
  assert.deepEqual(JSON.parse((wire.CardManagerData as { S: string }).S), initial);
});

test("Gold and WarBucks card packs debit source prices and add validated card counts", () => {
  const state = { ...createInitialProgression(NOW), gold: 100, warBucks: 2_000 };
  const goldPack = purchaseCardPackState(state, 5, {
    cards: GOLD_PACK_CARDS,
    cardPack: "GOLD_CARDPACK",
    discount: 0,
    startTime: NOW,
  });
  assert.equal(goldPack.state.gold, 31);
  assert.equal(goldPack.state.warBucks, 2_000);
  assert.equal(goldPack.cardInventory.cardData.AIRSTRIKE?.amount, 1);
  assert.equal(goldPack.cardInventory.cardData.AMMOBOX?.amount, 1);

  const threeCards = purchaseCardPackState(goldPack.state, 5, {
    cards: ["AMMOCRATE", "FREEZE", "AIRSTRIKE"],
    cardPack: "THREE_CARDS",
    discount: 0,
    startTime: NOW,
  });
  assert.equal(threeCards.state.gold, 31);
  assert.equal(threeCards.state.warBucks, 800);
  assert.equal(threeCards.cardInventory.cardData.AIRSTRIKE?.amount, 2);
});

test("card packs fail closed for locked level, invalid roll, unresolved cards, discount, and balance", () => {
  const state = { ...createInitialProgression(NOW), gold: 100, warBucks: 2_000 };
  const validPayload = {
    cards: GOLD_PACK_CARDS,
    cardPack: "GOLD_CARDPACK",
    discount: 0,
    startTime: NOW,
  };
  assert.throws(
    () => purchaseCardPackState(state, 4, validPayload),
    (error: unknown) => (error as { code?: number }).code === CARD_PACK_NOT_FOUND,
  );
  assert.throws(
    () => purchaseCardPackState(state, 5, {
      ...validPayload,
      cards: ["AMMOCRATE", ...GOLD_PACK_CARDS.slice(1)],
    }),
    (error: unknown) => (error as { code?: number }).code === CARD_PACK_NOT_FOUND,
  );
  assert.throws(
    () => purchaseCardPackState(state, 5, {
      cards: ["PLAYERINVIS", "FREEZE", "AIRSTRIKE"],
      cardPack: "THREE_CARDS",
      discount: 0,
      startTime: NOW,
    }),
    (error: unknown) => (error as { code?: number }).code === CARD_PACK_NOT_FOUND,
  );
  assert.throws(
    () => purchaseCardPackState(state, 5, { ...validPayload, discount: 25 }),
    (error: unknown) => (error as { code?: number }).code === CARD_PACK_NO_DISCOUNT,
  );
  assert.throws(
    () => purchaseCardPackState({ ...state, gold: 0 }, 5, validPayload),
    (error: unknown) => (error as { code?: number }).code === CARD_PACK_NOT_ENOUGH_FUNDS,
  );
});

test("buffered card-pack purchase is atomic, returns rollback data, and replays exactly once", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 2_000 };
  const requests = [{
    action: DbAction.BuyCardPack,
    data: packData("THREE_CARDS", ["AMMOCRATE", "FREEZE", "AIRSTRIKE"]),
  }];
  const first = processAssignmentBufferState(initial, NOW, "card-pack-buffer", requests, 5);
  const firstResponses = JSON.parse(first.requestsResults) as Array<Record<string, unknown>>;
  assert.equal(firstResponses[0]?.Result, 1);
  assert.equal(first.state.warBucks, 800);
  assert.equal(first.state.cardInventory?.cardData.AMMOCRATE?.amount, 1);

  const replay = processAssignmentBufferState(first.state, NOW + 1, "card-pack-buffer", requests, 5);
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.state.warBucks, 800);
  assert.equal(replay.state.cardInventory?.cardData.AMMOCRATE?.amount, 1);

  const invalid = processAssignmentBufferState(
    initial,
    NOW,
    "invalid-card-pack-buffer",
    [{ action: DbAction.BuyCardPack, data: packData("THREE_CARDS", ["PLAYERINVIS"]) }],
    5,
  );
  const invalidResponse = (JSON.parse(invalid.requestsResults) as Array<Record<string, unknown>>)[0];
  assert.equal(invalidResponse?.Result, CARD_PACK_NOT_FOUND);
  assert.equal(invalidResponse?.Gold, initial.gold);
  assert.equal(invalidResponse?.WarBucks, initial.warBucks);
  assert.deepEqual(
    JSON.parse(invalidResponse?.CardManagerData as string),
    createInitialCardInventory(),
  );
});
