import assert from "node:assert/strict";
import test from "node:test";
import generatedCardCatalog from "../data/cardCatalog.generated.json";
import { AccountType } from "../constants";
import type { CardCraftingState, CardInventoryState, PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  CARD_PACK_NO_DISCOUNT,
  CARD_PACK_NOT_ENOUGH_FUNDS,
  CARD_PACK_NOT_FOUND,
  ALREADY_CRAFTING,
  BUDDY_CARD_NOT_READY,
  CARD_ALREADY_WITHDRAWN,
  CARD_NOT_FOUND,
  CRAFTED_CARD_NOT_READY,
  WITHDRAW_NOT_YET_AVAILABLE,
  claimCraftedCardState,
  consumePvpUsedCardsState,
  createInitialCardCrafting,
  createInitialCardInventory,
  craftAndClaimSubscribedCardState,
  parsePvpUsedCards,
  purchaseCardPackState,
  startCardCraftingState,
} from "../services/cardInventoryService";
import {
  applyDepositCardChangesState,
  buddyDepositAuthorityFor,
  parseDepositCardChanges,
  squadCardPoolCapacity,
  withdrawSquadCardState,
} from "../services/squadCardPoolService";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";
import { checkedPlayerReputationIncrement } from "../services/playerPublicScalarAuthorityService";

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
  assert.equal(generatedCardCatalog.schemaVersion, 3);
  assert.equal(generatedCardCatalog.clientVersion, "4.9.5");
  assert.match(generatedCardCatalog.sourceSha256, /^[0-9a-f]{64}$/);
  assert.equal(generatedCardCatalog.unlockLevel, 6);
  assert.equal(generatedCardCatalog.cards.length, 58);
  assert.equal(generatedCardCatalog.cards.every((card) => card.implemented), true);
  assert.equal(generatedCardCatalog.unresolvedRows.length, 25);
  assert.equal(generatedCardCatalog.packs.length, 4);
  assert.deepEqual(generatedCardCatalog.craftingRules, {
    inputCount: 3,
    bronzeToSilverMinutes: 30,
    silverToGoldMinutes: 60,
  });
  assert.deepEqual(generatedCardCatalog.cardPoolRules, {
    withdrawCooldownMinutes: 240,
    buddyDepositCooldownMinutes: 480,
    maximumBuddyCards: 10,
    reputationPoints: { bronze: 5, silver: 15, gold: 45, buddy: 30 },
    capacityBySquadLevel: [
      3, 4, 5, 5, 6, 6, 6, 6, 7, 7,
      7, 7, 7, 7, 7, 7, 8, 8, 8, 8,
      8, 8, 8, 8, 8, 8, 8, 8, 9, 9,
      9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
      9, 9, 9, 9, 9, 9, 9, 9, 10, 10,
    ],
  });
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
  assert.deepEqual(
    JSON.parse((wire.CraftData as { S: string }).S),
    createInitialCardCrafting(),
  );
});

test("War Card inventory authority rejects malformed durable ownership before boot, action, or publication", () => {
  const initialInventory = createInitialCardInventory();
  const buddy = {
    amount: 1,
    buddyName: "Legacy Buddy",
    equippedVisuals: { "0": { equippedID: "HEAD_DEFAULT" } },
    unityType: 2,
    primaryWeapon: 3,
    secondaryWeapon: -1,
    armypower: 900,
    level: 12,
  };
  const malformed: unknown[] = [
    { ...initialInventory, cardData: { MISSING: { amount: 1 } } },
    { ...initialInventory, cardData: { AMMOCRATE: { amount: 0 } } },
    { ...initialInventory, cardData: { AMMOCRATE: { amount: Number.NaN } } },
    { ...initialInventory, cardData: { AMMOCRATE: { amount: 1, claimed: true } } },
    { ...initialInventory, buddyCardData: { buddy: { ...buddy, amount: 2 } } },
    { ...initialInventory, buddyCardData: { buddy: { ...buddy, primaryWeapon: 999 } } },
    { ...initialInventory, buddyCardData: { buddy: { ...buddy, equippedVisuals: { "4": { equippedID: "x" } } } } },
    { ...initialInventory, nextWithdraw: 2_147_483_648 },
    { ...initialInventory, nextBuddyDeposit: Number.POSITIVE_INFINITY },
    { ...initialInventory, extraSlot: 1 },
    { ...initialInventory, unknown: true },
  ];
  for (const cardInventory of malformed) {
    const document = playerDocument();
    document.progression!.cardInventory = cardInventory as CardInventoryState;
    assert.throws(() => buildPlayerData(document), /War Card inventory/);
  }

  const corruptAction = createInitialProgression(NOW);
  corruptAction.cardInventory = malformed[1] as CardInventoryState;
  assert.throws(
    () => consumePvpUsedCardsState(corruptAction, ["AMMOCRATE"]),
    /War Card inventory/,
  );

  const clean = createInitialProgression(NOW);
  assert.throws(
    () => validatedProgressionSuccessor(clean, {
      ...clean,
      revision: clean.revision + 1,
      cardInventory: malformed[4] as CardInventoryState,
    }),
    /War Card inventory/,
  );
  assert.throws(
    () => withdrawSquadCardState(
      clean,
      { AMMOCRATE: JSON.stringify({ amount: 1 }) },
      0,
      "AMMOCRATE",
      2_147_483_647,
    ),
    /War Card inventory/,
  );
});

test("PvP settlement parses, validates, and consumes normal and Buddy War Cards once", () => {
  assert.deepEqual(parsePvpUsedCards('["AMMOCRATE","buddy-player-1700000000"]'), [
    "AMMOCRATE",
    "buddy-player-1700000000",
  ]);
  assert.deepEqual(parsePvpUsedCards([]), []);
  assert.deepEqual(parsePvpUsedCards('["AMMOCRATE","AMMOCRATE"]'), ["AMMOCRATE", "AMMOCRATE"]);
  assert.throws(() => parsePvpUsedCards(JSON.stringify(Array.from({ length: 7 }, (_, index) => `card-${index}`))));

  const initial = createInitialProgression(NOW);
  initial.cardInventory = {
    ...createInitialCardInventory(),
    cardData: { AMMOCRATE: { amount: 2 } },
    buddyCardData: {
      "buddy-player-1700000000": {
        amount: 1,
        buddyName: "Buddy",
        equippedVisuals: {},
        unityType: 0,
        primaryWeapon: 0,
        secondaryWeapon: 0,
        armypower: 100,
        level: 4,
      },
    },
  };
  const consumed = consumePvpUsedCardsState(initial, [
    "AMMOCRATE",
    "AMMOCRATE",
    "buddy-player-1700000000",
  ]);
  assert.equal(consumed.cardInventory.cardData.AMMOCRATE, undefined);
  assert.equal(consumed.cardInventory.buddyCardData["buddy-player-1700000000"], undefined);
  assert.equal(consumed.state.warCardsPlayed, 3);
  assert.equal(consumed.state.revision, initial.revision + 1);
  assert.throws(() => consumePvpUsedCardsState(consumed.state, ["buddy-player-1700000000"]));
  assert.throws(() => consumePvpUsedCardsState(initial, ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"]));
  assert.throws(() => consumePvpUsedCardsState(initial, ["AIRSTRIKE"]));
});

test("timed Bronze and Silver recipes consume three cards and grant one server-selected next-rarity card", () => {
  const initial = createInitialProgression(NOW);
  initial.cardInventory = {
    ...createInitialCardInventory(),
    cardData: { AMMOCRATE: { amount: 3 }, AMMOBOX: { amount: 3 } },
  };

  const bronze = startCardCraftingState(initial, NOW, ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"]);
  assert.equal(bronze.cardInventory.cardData.AMMOCRATE, undefined);
  assert.deepEqual(bronze.cardCrafting, {
    cards: ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"],
    start: NOW,
    end: NOW + 30 * 60,
  });
  assert.throws(
    () => claimCraftedCardState(bronze.state, bronze.cardCrafting.end - 1, () => 0),
    (error: unknown) => (error as { code?: number }).code === CRAFTED_CARD_NOT_READY,
  );
  const expectedSilverId = generatedCardCatalog.cards
    .filter((card) => card.implemented && card.rarity === 2)
    .map((card) => card.name)
    .sort()[0];
  const silverBefore = bronze.cardInventory.cardData[expectedSilverId]?.amount ?? 0;
  const silverResult = claimCraftedCardState(bronze.state, bronze.cardCrafting.end, () => 0);
  const silverDefinition = generatedCardCatalog.cards.find((card) => card.name === silverResult.cardId);
  assert.equal(silverDefinition?.rarity, 2);
  assert.equal(silverResult.cardInventory.cardData[silverResult.cardId!]?.amount, silverBefore + 1);
  assert.deepEqual(silverResult.cardCrafting, createInitialCardCrafting());
  assert.equal(silverResult.state.goldCardsCrafted, 0);

  const silver = startCardCraftingState(
    silverResult.state,
    NOW + 4_000,
    ["AMMOBOX", "AMMOBOX", "AMMOBOX"],
  );
  assert.equal(silver.cardCrafting.end, NOW + 4_000 + 60 * 60);
  const goldResult = claimCraftedCardState(silver.state, silver.cardCrafting.end, () => 0);
  const goldDefinition = generatedCardCatalog.cards.find((card) => card.name === goldResult.cardId);
  assert.equal(goldDefinition?.rarity, 3);
  assert.equal(goldResult.state.goldCardsCrafted, 1);
});

test("card-crafting authority rejects malformed durable receipts before boot, action, or publication", () => {
  const malformed: unknown[] = [
    { cards: [], start: NOW, end: 0 },
    { cards: ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"], start: NOW, end: NOW + 1 },
    { cards: ["AMMOCRATE", "AMMOBOX", "AMMOCRATE"], start: NOW, end: NOW + 30 * 60 },
    { cards: ["AMMOCRATE", "AMMOCRATE", "MISSING"], start: NOW, end: NOW + 30 * 60 },
    { cards: ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"], start: NOW, end: 2_147_483_648 },
    { cards: [], start: 0, end: 0, claimed: true },
  ];
  for (const cardCrafting of malformed) {
    const document = playerDocument();
    document.progression!.cardCrafting = cardCrafting as CardCraftingState;
    assert.throws(() => buildPlayerData(document), /card-crafting|Card-crafting/);
  }

  const active = createInitialProgression(NOW);
  active.cardInventory = {
    ...createInitialCardInventory(),
    cardData: { AMMOCRATE: { amount: 3 } },
  };
  active.cardCrafting = malformed[1] as CardCraftingState;
  assert.throws(
    () => startCardCraftingState(active, NOW, ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"]),
    /card-crafting|Card-crafting/,
  );
  assert.throws(() => claimCraftedCardState(active, NOW + 30 * 60), /card-crafting|Card-crafting/);

  const clean = createInitialProgression(NOW);
  const corruptSuccessor = {
    ...clean,
    revision: clean.revision + 1,
    cardCrafting: malformed[2] as CardCraftingState,
  };
  assert.throws(
    () => validatedProgressionSuccessor(clean, corruptSuccessor),
    /card-crafting|Card-crafting/,
  );
  assert.throws(
    () => startCardCraftingState({
      ...clean,
      cardInventory: {
        ...createInitialCardInventory(),
        cardData: { AMMOCRATE: { amount: 3 } },
      },
    }, 2_147_483_647, ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"]),
    /Card-crafting time is invalid/,
  );
});

test("Gold-card crafting rejects a corrupt or overflowing starter-assignment proof", () => {
  const initial = createInitialProgression(NOW);
  initial.cardInventory = {
    ...createInitialCardInventory(),
    cardData: { AMMOBOX: { amount: 6 } },
  };

  const timed = startCardCraftingState(initial, NOW, ["AMMOBOX", "AMMOBOX", "AMMOBOX"]);
  timed.state.goldCardsCrafted = Number.MAX_SAFE_INTEGER;
  assert.throws(
    () => claimCraftedCardState(timed.state, timed.cardCrafting.end, () => 0),
    /Gold-card craft counter overflowed/,
  );

  const subscribed = {
    ...initial,
    goldCardsCrafted: Number.NaN,
    subscription: {
      type: "subscription1" as const,
      subscribeSince: NOW - 60,
      expireTime: NOW + 60,
      dogTagTimerLock: NOW - 60,
    },
  };
  assert.throws(
    () => craftAndClaimSubscribedCardState(
      subscribed,
      NOW,
      ["AMMOBOX", "AMMOBOX", "AMMOBOX"],
      () => 0,
    ),
    /Gold-card craft counter is invalid/,
  );
});

test("crafting rejects invalid recipes, insufficient ownership, concurrent receipts, and duplicate claims", () => {
  const initial = createInitialProgression(NOW);
  initial.cardInventory = {
    ...createInitialCardInventory(),
    cardData: {
      AMMOCRATE: { amount: 3 },
      AMMOBOX: { amount: 3 },
      AIRSTRIKE: { amount: 3 },
    },
  };
  assert.throws(
    () => startCardCraftingState(initial, NOW, ["AMMOCRATE", "AMMOBOX", "AMMOCRATE"]),
    (error: unknown) => (error as { code?: number }).code === CARD_NOT_FOUND,
  );
  assert.throws(
    () => startCardCraftingState(initial, NOW, ["AIRSTRIKE", "AIRSTRIKE", "AIRSTRIKE"]),
    (error: unknown) => (error as { code?: number }).code === CARD_NOT_FOUND,
  );
  assert.throws(
    () => startCardCraftingState(initial, NOW, ["AMMOCRATE", "AMMOCRATE", "PLAGUE"]),
    (error: unknown) => (error as { code?: number }).code === CARD_NOT_FOUND,
  );

  const active = startCardCraftingState(initial, NOW, ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"]);
  assert.throws(
    () => startCardCraftingState(active.state, NOW + 1, ["AMMOBOX", "AMMOBOX", "AMMOBOX"]),
    (error: unknown) => (error as { code?: number }).code === ALREADY_CRAFTING,
  );
  const expectedCardId = generatedCardCatalog.cards
    .filter((card) => card.implemented && card.rarity === 2)
    .map((card) => card.name)
    .sort()[0];
  const beforeClaim = active.cardInventory.cardData[expectedCardId]?.amount ?? 0;
  const claimed = claimCraftedCardState(active.state, active.cardCrafting.end, () => 0);
  assert.throws(
    () => claimCraftedCardState(claimed.state, active.cardCrafting.end + 1, () => 0),
    (error: unknown) => (error as { code?: number }).code === CRAFTED_CARD_NOT_READY,
  );
  assert.equal(claimed.cardInventory.cardData[claimed.cardId!]?.amount, beforeClaim + 1);
});

test("active subscription crafts and claims immediately in one atomic state transition", () => {
  const initial = createInitialProgression(NOW);
  initial.subscription = {
    type: "subscription1",
    subscribeSince: NOW - 100,
    expireTime: NOW + 3_600,
    dogTagTimerLock: NOW - 100,
  };
  initial.cardInventory = {
    ...createInitialCardInventory(),
    cardData: { AMMOCRATE: { amount: 3 } },
  };

  const result = craftAndClaimSubscribedCardState(
    initial,
    NOW,
    ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"],
    () => 0,
  );
  const definition = generatedCardCatalog.cards.find((card) => card.name === result.cardId);
  assert.equal(definition?.rarity, 2);
  assert.equal(result.cardInventory.cardData.AMMOCRATE, undefined);
  assert.equal(result.cardInventory.cardData[result.cardId!]?.amount, 1);
  assert.deepEqual(result.cardCrafting, createInitialCardCrafting());
  assert.equal(result.state.revision, initial.revision + 1);

  const expired = {
    ...initial,
    subscription: { ...initial.subscription, expireTime: NOW },
  };
  assert.throws(
    () => craftAndClaimSubscribedCardState(expired, NOW, ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"]),
    (error: unknown) => (error as { code?: number }).code === CARD_NOT_FOUND,
  );
  assert.throws(
    () => craftAndClaimSubscribedCardState({
      ...initial,
      subscription: { ...initial.subscription!, expireTime: Number.POSITIVE_INFINITY },
    }, NOW, ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"]),
    /Subscription expiry is invalid/,
  );

  const activeCraft = startCardCraftingState(initial, NOW, ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"]);
  assert.throws(
    () => craftAndClaimSubscribedCardState(
      activeCraft.state,
      NOW + 1,
      ["AMMOCRATE", "AMMOCRATE", "AMMOCRATE"],
    ),
    (error: unknown) => (error as { code?: number }).code === ALREADY_CRAFTING,
  );
});

test("normal squad-card deposits atomically exchange inventory and enforce source capacity", () => {
  const initial = createInitialProgression(NOW);
  initial.cardInventory = {
    ...createInitialCardInventory(),
    cardData: { AMMOCRATE: { amount: 5 }, FREEZE: { amount: 1 } },
  };
  const deposit = applyDepositCardChangesState(
    initial,
    {},
    parseDepositCardChanges(
      JSON.stringify({ AMMOCRATE: JSON.stringify({ amount: 2 }) }),
      JSON.stringify({}),
    ),
    squadCardPoolCapacity(1),
  );
  assert.equal(deposit.cardInventory.cardData.AMMOCRATE?.amount, 3);
  assert.deepEqual(JSON.parse(deposit.depositedCards.AMMOCRATE), { amount: 2 });
  assert.equal(deposit.state.revision, initial.revision + 1);

  const edited = applyDepositCardChangesState(
    deposit.state,
    deposit.depositedCards,
    parseDepositCardChanges(
      JSON.stringify({ FREEZE: JSON.stringify({ amount: 1 }) }),
      JSON.stringify({ AMMOCRATE: JSON.stringify({ amount: 1 }) }),
    ),
    squadCardPoolCapacity(1),
  );
  assert.equal(edited.cardInventory.cardData.AMMOCRATE?.amount, 4);
  assert.equal(edited.cardInventory.cardData.FREEZE, undefined);
  assert.deepEqual(JSON.parse(edited.depositedCards.AMMOCRATE), { amount: 1 });
  assert.deepEqual(JSON.parse(edited.depositedCards.FREEZE), { amount: 1 });

  assert.throws(
    () => applyDepositCardChangesState(
      initial,
      {},
      parseDepositCardChanges(
        JSON.stringify({ AMMOCRATE: JSON.stringify({ amount: 4 }) }),
        JSON.stringify({}),
      ),
      squadCardPoolCapacity(1),
    ),
    (error: unknown) => (error as { code?: number }).code === CARD_NOT_FOUND,
  );
  assert.equal(squadCardPoolCapacity(0), 3);
  assert.equal(squadCardPoolCapacity(500), 10);
});

test("squad-card deposits reject forged ownership and contradictory deltas", () => {
  const initial = createInitialProgression(NOW);
  initial.cardInventory = {
    ...createInitialCardInventory(),
    cardData: { AMMOCRATE: { amount: 1 } },
  };
  assert.throws(
    () => applyDepositCardChangesState(
      initial,
      {},
      parseDepositCardChanges(
        JSON.stringify({ AMMOCRATE: JSON.stringify({ amount: 2 }) }),
        JSON.stringify({}),
      ),
      3,
    ),
    (error: unknown) => (error as { code?: number }).code === CARD_NOT_FOUND,
  );
  assert.throws(
    () => parseDepositCardChanges(
      JSON.stringify({ AMMOCRATE: JSON.stringify({ amount: 1 }) }),
      JSON.stringify({ AMMOCRATE: JSON.stringify({ amount: 1 }) }),
    ),
    (error: unknown) => (error as { code?: number }).code === CARD_NOT_FOUND,
  );
});

test("Buddy deposit reproduces the current loadout and starts the exact cooldown", () => {
  const document = playerDocument();
  document.player.armyPower = 1_234;
  document.player.level = 9;
  const initial = document.progression!;
  const authority = buddyDepositAuthorityFor(document, initial, NOW);
  const id = `${document.id}${NOW}`;
  const buddy = JSON.stringify({
    amount: 1,
    buddyName: document.player.accountName,
    equippedVisuals: authority.equippedVisuals,
    unityType: 1,
    // Starter slot 2 is a grenade rather than a launcher, so the recovered explosive branch
    // uses the slot-3 pistol as primary and the grenade as secondary.
    primaryWeapon: 13,
    secondaryWeapon: 6,
    armypower: 1_234,
    level: 8,
  });
  const result = applyDepositCardChangesState(
    initial,
    {},
    parseDepositCardChanges(JSON.stringify({ [id]: buddy }), JSON.stringify({})),
    3,
    authority,
  );

  assert.deepEqual(JSON.parse(result.depositedCards[id]!), JSON.parse(buddy));
  assert.equal(result.cardInventory.nextBuddyDeposit, NOW + 480 * 60);
  assert.deepEqual(result.cardInventory.buddyCardData, {});

  const forged = JSON.stringify({ ...JSON.parse(buddy), armypower: 9_999 });
  assert.throws(
    () => applyDepositCardChangesState(
      initial,
      {},
      parseDepositCardChanges(JSON.stringify({ [id]: forged }), JSON.stringify({})),
      3,
      authority,
    ),
    (error: unknown) => (error as { code?: number }).code === BUDDY_CARD_NOT_READY,
  );

  const withoutExistingBuddy = { ...result.depositedCards };
  delete withoutExistingBuddy[id];
  const nextId = `${document.id}${NOW + 1}`;
  assert.throws(
    () => applyDepositCardChangesState(
      result.state,
      withoutExistingBuddy,
      parseDepositCardChanges(JSON.stringify({ [nextId]: buddy }), JSON.stringify({})),
      3,
      { ...authority, now: NOW + 1 },
    ),
    (error: unknown) => (error as { code?: number }).code === BUDDY_CARD_NOT_READY,
  );
});

test("squad-card withdrawal grants once, rewards the donor, and starts the exact cooldown", () => {
  const recipient = createInitialProgression(NOW);
  const first = withdrawSquadCardState(
    recipient,
    { AMMOCRATE: JSON.stringify({ amount: 2 }) },
    7,
    "AMMOCRATE",
    NOW,
  );
  assert.equal(first.recipientInventory.cardData.AMMOCRATE?.amount, 1);
  assert.deepEqual(JSON.parse(first.donorDepositedCards.AMMOCRATE), { amount: 1 });
  assert.equal(first.donorReputation, 12);
  assert.equal(first.nextWithdraw, NOW + 240 * 60);
  assert.equal(first.recipientInventory.nextWithdraw, first.nextWithdraw);

  assert.throws(
    () => withdrawSquadCardState(
      first.recipientState,
      first.donorDepositedCards,
      first.donorReputation,
      "AMMOCRATE",
      NOW + 1,
    ),
    (error: unknown) => (error as { code?: number }).code === WITHDRAW_NOT_YET_AVAILABLE,
  );
  const readyAgain = {
    ...first.recipientState,
    cardInventory: { ...first.recipientInventory, nextWithdraw: NOW },
  };
  const last = withdrawSquadCardState(
    readyAgain,
    first.donorDepositedCards,
    first.donorReputation,
    "AMMOCRATE",
    NOW + 1,
  );
  assert.equal(last.recipientInventory.cardData.AMMOCRATE?.amount, 2);
  assert.equal(last.donorDepositedCards.AMMOCRATE, undefined);
  assert.throws(
    () => withdrawSquadCardState(
      { ...last.recipientState, cardInventory: { ...last.recipientInventory, nextWithdraw: NOW } },
      last.donorDepositedCards,
      last.donorReputation,
      "AMMOCRATE",
      NOW + 2,
    ),
    (error: unknown) => (error as { code?: number }).code === CARD_ALREADY_WITHDRAWN,
  );
});

test("squad-card donor Reputation cannot overflow the recovered signed-client field", () => {
  for (const reward of [5, 15, 45, 30]) {
    assert.equal(
      checkedPlayerReputationIncrement(2_147_483_647 - reward, reward),
      2_147_483_647,
    );
    assert.throws(
      () => checkedPlayerReputationIncrement(2_147_483_648 - reward, reward),
      /reputation increment is invalid/,
    );
  }

  assert.throws(
    () => withdrawSquadCardState(
      createInitialProgression(NOW),
      { AMMOCRATE: JSON.stringify({ amount: 1 }) },
      2_147_483_643,
      "AMMOCRATE",
      NOW,
    ),
    /Donor reputation is invalid/,
  );
});

test("legacy Buddy cards transfer exact loadout data and enforce the ten-card ownership cap", () => {
  const buddy = {
    amount: 1,
    buddyName: "Donor",
    equippedVisuals: { "0": { equippedID: "HEAD_DEFAULT" } },
    unityType: 2,
    primaryWeapon: 3,
    secondaryWeapon: -1,
    armypower: 900,
    level: 12,
  };
  const initial = createInitialProgression(NOW);
  const result = withdrawSquadCardState(
    initial,
    { "donor-buddy": JSON.stringify(buddy) },
    10,
    "donor-buddy",
    NOW,
  );
  assert.deepEqual(result.recipientInventory.buddyCardData["donor-buddy"], buddy);
  assert.equal(result.donorReputation, 40);
  assert.equal(result.donorDepositedCards["donor-buddy"], undefined);

  const capped = createInitialProgression(NOW);
  capped.cardInventory = {
    ...createInitialCardInventory(),
    buddyCardData: Object.fromEntries(
      Array.from({ length: 10 }, (_, index) => [`buddy-${index}`, { ...buddy, buddyName: `Buddy ${index}` }]),
    ),
  };
  assert.throws(
    () => withdrawSquadCardState(
      capped,
      { "donor-buddy": JSON.stringify(buddy) },
      10,
      "donor-buddy",
      NOW,
    ),
    (error: unknown) => (error as { code?: number }).code === BUDDY_CARD_NOT_READY,
  );
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
