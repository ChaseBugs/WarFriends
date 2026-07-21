import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import {
  ITEM_ALREADY_UPGRADING,
  ITEM_PRICE_NOT_FOUND,
  ITEM_WRONG_INDEX_TO_ACTIVATE,
  itemInventoryStateFor,
  TUTORIAL_WEAPON_NAME,
} from "../services/itemInventoryService";
import {
  applyOneTimeRewardState,
  ONE_TIME_REWARD_RULES,
  oneTimeRewardRule,
  oneTimeRewardWire,
  validatedCollectedRewards,
} from "../services/oneTimeRewardService";
import {
  TUTORIAL_UNIT_NAME,
  updateEquippedUnitsState,
} from "../services/unitInventoryService";

function playerDocument(): PlayerDocument {
  const player = newPlayer("one-time-player", "OneTimePlayer", AccountType.Guest);
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
    progression: createInitialProgression(1_700_000_000),
    createdAt: new Date(1_700_000_000_000),
    updatedAt: new Date(1_700_000_000_000),
  };
}

test("one-time reward catalog preserves exact decoded MainScene Gold values", () => {
  assert.deepEqual([...ONE_TIME_REWARD_RULES], [
    { id: "FacebookLike", gold: 10, trigger: "direct" },
    { id: "TwitterFollow", gold: 10, trigger: "direct" },
    { id: "FacebookLoginReward", gold: 10, trigger: "facebook-link" },
    { id: "NotificationAllowReward", gold: 4, trigger: "direct" },
  ]);
});

test("one-time rewards credit once and leave the caller snapshot immutable", () => {
  const initial = { ...createInitialProgression(1_700_000_000), gold: 7 };
  const first = applyOneTimeRewardState(initial, "FacebookLike");
  assert.equal(first.wasAdded, true);
  assert.equal(first.state.gold, 17);
  assert.equal(first.state.revision, initial.revision + 1);
  assert.deepEqual(first.state.collectedRewards, { FacebookLike: 1 });
  assert.deepEqual(initial.collectedRewards, {});

  const replay = applyOneTimeRewardState(first.state, "FacebookLike");
  assert.equal(replay.wasAdded, false);
  assert.equal(replay.state, first.state);
  assert.equal(replay.state.gold, 17);
  assert.deepEqual(oneTimeRewardWire(first), {
    RewardId: "FacebookLike",
    Gold: 10,
    WasAdded: true,
  });
  assert.deepEqual(oneTimeRewardWire(replay), {
    RewardId: "FacebookLike",
    Gold: 10,
  });
});

test("one-time rewards pay chargeback debt and reject corrupt wallets before collecting", () => {
  const debt = { ...createInitialProgression(1_700_000_000), gold: -15 };
  const paidDown = applyOneTimeRewardState(debt, "FacebookLike");
  assert.equal(paidDown.state.gold, -5);
  assert.deepEqual(paidDown.state.collectedRewards, { FacebookLike: 1 });

  const corrupt = { ...debt, gold: Number.NaN };
  assert.throws(
    () => applyOneTimeRewardState(corrupt, "FacebookLike"),
    /reward balance is invalid/,
  );
  assert.deepEqual(corrupt.collectedRewards, {});
});

test("collected reward markers use exact key-presence authority and reject split client state", () => {
  assert.deepEqual(
    validatedCollectedRewards({ FacebookLike: 1, RetiredLiveOpsReward: 1 }),
    { FacebookLike: 1, RetiredLiveOpsReward: 1 },
  );
  for (const marker of [0, 2, -1, 1.5, Number.NaN, Number.POSITIVE_INFINITY]) {
    assert.throws(
      () => validatedCollectedRewards({ FacebookLike: marker }),
      /Collected reward marker is invalid/,
    );
    assert.throws(
      () => applyOneTimeRewardState({
        ...createInitialProgression(1_700_000_000),
        collectedRewards: { FacebookLike: marker },
      }, "FacebookLike"),
      /Collected reward marker is invalid/,
    );
  }
  assert.throws(
    () => validatedCollectedRewards(Object.fromEntries(
      Array.from({ length: 257 }, (_, index) => [`LegacyReward${index}`, 1]),
    )),
    /Collected reward markers are oversized/,
  );
  assert.throws(
    () => applyOneTimeRewardState({
      ...createInitialProgression(1_700_000_000),
      revision: Number.MAX_SAFE_INTEGER,
    }, "FacebookLike"),
    /One-time reward progression revision is invalid/,
  );
});

test("unknown and malformed one-time reward IDs fail closed", () => {
  for (const invalid of ["UnknownReward", " FacebookLike", "facebooklike", "", 10]) {
    assert.throws(
      () => oneTimeRewardRule(invalid),
      (error: unknown) => typeof error === "object" && error !== null
        && "code" in error && error.code === ApiErrorCode.UnknownAction,
    );
  }
  assert.throws(
    () => oneTimeRewardRule("FacebookLoginReward"),
    (error: unknown) => typeof error === "object" && error !== null
      && "code" in error && error.code === ApiErrorCode.RequestNotAuthorized,
  );
  assert.equal(oneTimeRewardRule("FacebookLoginReward", "facebook-link").gold, 10);
});

test("WeaponTutorial funds exactly the recovered first AK47 transition once", () => {
  const initial = { ...createInitialProgression(1_700_000_000), gold: 9, warBucks: 11 };
  const first = applyOneTimeRewardState(initial, "WeaponTutorial", "direct", TUTORIAL_WEAPON_NAME);
  assert.equal(first.wasAdded, true);
  assert.equal(first.state.gold, 10);
  assert.equal(first.state.warBucks, 511);
  assert.deepEqual(oneTimeRewardWire(first), {
    RewardId: "WeaponTutorial",
    Gold: 1,
    WarBucks: 500,
    WasAdded: true,
  });

  // Model the completed forced upgrade. The collected marker must be checked before inventory
  // eligibility so a network retry remains a no-op after boughtIndex advances.
  const itemInventory = itemInventoryStateFor(first.state);
  itemInventory.levelManagerData.savedWeapons[TUTORIAL_WEAPON_NAME]!.boughtIndex = 1;
  const completed = { ...first.state, itemInventory };
  const replay = applyOneTimeRewardState(completed, "WeaponTutorial", "direct", TUTORIAL_WEAPON_NAME);
  assert.equal(replay.state, completed);
  assert.equal(replay.wasAdded, false);
  assert.deepEqual(oneTimeRewardWire(replay), {
    RewardId: "WeaponTutorial",
    Gold: 1,
    WarBucks: 500,
  });
});

test("UnitTutorial funds exactly the recovered first Assaulter transition once", () => {
  const owned = updateEquippedUnitsState(
    createInitialProgression(1_700_000_000),
    {
      armyPower: 0,
      equips: { [TUTORIAL_UNIT_NAME]: { wasEquipped: true, equipped: true } },
    },
  ).state;
  const first = applyOneTimeRewardState(owned, "UnitTutorial", "direct", TUTORIAL_UNIT_NAME);
  assert.equal(first.state.gold, owned.gold + 1);
  assert.equal(first.state.warBucks, owned.warBucks + 375);
  assert.deepEqual(oneTimeRewardWire(first), {
    RewardId: "UnitTutorial",
    Gold: 1,
    WarBucks: 375,
    WasAdded: true,
  });

  const itemInventory = itemInventoryStateFor(first.state);
  itemInventory.levelManagerData.savedArmies[TUTORIAL_UNIT_NAME]!.boughtIndex = 1;
  const completed = { ...first.state, itemInventory };
  const replay = applyOneTimeRewardState(completed, "UnitTutorial", "direct", TUTORIAL_UNIT_NAME);
  assert.equal(replay.state, completed);
  assert.equal(replay.wasAdded, false);
  assert.deepEqual(oneTimeRewardWire(replay), {
    RewardId: "UnitTutorial",
    Gold: 1,
    WarBucks: 375,
  });
});

test("tutorial rewards reject altered targets and ineligible first claims", () => {
  const initial = createInitialProgression(1_700_000_000);
  assert.throws(
    () => applyOneTimeRewardState(initial, "WeaponTutorial", "direct", "Google2u.AssaultRifle_Famas"),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_NOT_FOUND,
  );
  assert.throws(
    () => applyOneTimeRewardState(initial, "UnitTutorial", "direct", TUTORIAL_UNIT_NAME),
    (error: unknown) => (error as { code?: number }).code === ITEM_PRICE_NOT_FOUND,
  );

  const upgradedInventory = itemInventoryStateFor(initial);
  upgradedInventory.levelManagerData.savedWeapons[TUTORIAL_WEAPON_NAME]!.boughtIndex = 1;
  assert.throws(
    () => applyOneTimeRewardState(
      { ...initial, itemInventory: upgradedInventory },
      "WeaponTutorial",
      "direct",
      TUTORIAL_WEAPON_NAME,
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_WRONG_INDEX_TO_ACTIVATE,
  );

  const deliveringInventory = itemInventoryStateFor(initial);
  deliveringInventory.levelManagerData.weaponDelivery = {
    activationNeeded: true,
    boughtIndex: 0,
    end: 1_700_000_060,
    itemId: TUTORIAL_WEAPON_NAME,
    slotId: 0,
    start: 1_700_000_000,
  };
  assert.throws(
    () => applyOneTimeRewardState(
      { ...initial, itemInventory: deliveringInventory },
      "WeaponTutorial",
      "direct",
      TUTORIAL_WEAPON_NAME,
    ),
    (error: unknown) => (error as { code?: number }).code === ITEM_ALREADY_UPGRADING,
  );
});

test("PlayerAnalyticsData restores authoritative collected reward markers", () => {
  const player = playerDocument();
  player.progression = {
    ...createInitialProgression(1_700_000_000),
    collectedRewards: { FacebookLike: 1, NotificationAllowReward: 1 },
  };
  const wire = buildPlayerData(player);
  const analytics = JSON.parse((wire.PlayerAnalyticsData as { S: string }).S) as {
    collectedRewards: Record<string, number>;
  };
  assert.deepEqual(analytics.collectedRewards, {
    FacebookLike: 1,
    NotificationAllowReward: 1,
  });

  player.progression!.collectedRewards = { FacebookLike: 2 };
  assert.throws(() => buildPlayerData(player), /Collected reward marker is invalid/);
});
