import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import {
  ACHIEVEMENT_DEFINITIONS,
  ACHIEVEMENT_ALREADY_CLAIMED,
  ACHIEVEMENT_REWARD_NOT_FOUND,
  acknowledgeAchievementOffsetState,
  achievementStateFor,
  advanceAchievementState,
  claimAchievementState,
  serializeAchievementsData,
  validateAchievementProgressState,
} from "../services/achievementService";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  BLACK_MARKET_WEAPON_CATALOG,
  WEAPON_CATALOG,
} from "../services/itemInventoryService";
import { createInitialProgression } from "../services/playerStateService";
import { UNIT_CATALOG } from "../services/unitInventoryService";
import { VISUAL_CATALOG } from "../services/visualInventoryService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;

test("achievement state uses the exact recovered AchievementsData wire fields", () => {
  const achievements = achievementStateFor(createInitialProgression(NOW));
  const rankedWins = achievements.data.find((group) => group.id === 2)!;

  assert.deepEqual(rankedWins, {
    id: 2,
    offset: 0,
    value: 0,
    progress: [{ claimed: false }, { claimed: false }, { claimed: false }],
  });
  assert.deepEqual(Object.keys(JSON.parse(serializeAchievementsData(achievements))), ["data"]);
});

test("only confirmed events can advance supported achievement counters", () => {
  const initial = createInitialProgression(NOW);
  const advanced = advanceAchievementState(initial, 2, 1);
  assert.equal(advanced.achievements.data.find((group) => group.id === 2)?.value, 1);

  // The old client reports its local StatsManager total through action 220. A number above
  // the server-owned total must not become reward-authoritative state.
  assert.throws(
    () => validateAchievementProgressState(advanced.state, 2, 10),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_REWARD_NOT_FOUND,
  );
  assert.doesNotThrow(() => validateAchievementProgressState(advanced.state, 2, 1));

  const offset = acknowledgeAchievementOffsetState(advanced.state, 2, -999);
  assert.equal(offset.achievements.data.find((group) => group.id === 2)?.offset, 0);
});

test("inventory achievement groups preserve source tiers and derive StatsManager-equivalent values", () => {
  assert.deepEqual(
    [0, 1, 8, 9, 10, 11, 15].map((id) =>
      ACHIEVEMENT_DEFINITIONS[id].map((tier) => [tier.target, tier.gold, tier.warBucks])),
    [
      [[8, 1, 0], [16, 10, 0], [24, 15, 0]],
      [[5, 1, 0], [10, 10, 0], [15, 15, 0]],
      [[5, 0, 2_500], [50, 0, 25_000], [500, 0, 250_000]],
      [[10, 1, 0], [25, 5, 0], [100, 25, 0]],
      [[1, 1, 0], [10, 5, 0], [50, 25, 0]],
      [[15, 1, 0], [150, 5, 0], [300, 25, 0]],
      [[7, 0, 5_000], [14, 0, 50_000], [29, 0, 500_000]],
    ],
  );

  const state = createInitialProgression(NOW);
  state.warCardsPlayed = 5;
  const weapons = Object.values({ ...WEAPON_CATALOG, ...BLACK_MARKET_WEAPON_CATALOG })
    .filter((definition) => definition.unlockLevel > 3)
    .slice(0, 5);
  for (const definition of weapons) {
    state.itemInventory!.levelManagerData.savedWeapons[definition.name] = {
      bought: true,
      boughtIndex: 0,
      showed: true,
      borrowed: false,
      specialFeature: 0,
    };
  }
  state.itemInventory!.levelManagerData.savedWeapons["Google2u.AssaultRifle_AK47"]!.boughtIndex = 15;

  const unitDefinitions = Object.values(UNIT_CATALOG).filter((definition) => definition.unlockLevel > 3);
  const soldier = unitDefinitions.find((definition) => definition.isSoldier)!;
  const mechanical = unitDefinitions.find((definition) => !definition.isSoldier)!;
  const units = [soldier, mechanical, ...unitDefinitions
    .filter((definition) => definition.name !== soldier.name && definition.name !== mechanical.name)
    .slice(0, 6)];
  for (const definition of units) {
    state.itemInventory!.levelManagerData.savedArmies[definition.name] = {
      bought: true,
      boughtIndex: definition.name === soldier.name ? 10 : definition.name === mechanical.name ? 1 : 0,
      specialSlot: 0,
      showed: true,
      tier: definition.startingTier,
      borrowed: false,
      wasEquipped: false,
      equipped: false,
      eliteSlot: 0,
      parts: 0,
    };
  }

  state.visualInventory = { visuals: {}, slots: {}, previousHeadDecal: "" };
  const visuals = Object.values(VISUAL_CATALOG)
    .filter((definition) =>
      definition.categoryId !== 3 && definition.priceGold + definition.priceWarBucks > 0)
    .slice(0, 7);
  for (const definition of visuals) {
    state.visualInventory.visuals[definition.name] = {
      bought: true,
      showed: true,
      expiresOn: 0,
      borrowed: false,
      parts: 0,
      notificate: false,
    };
  }

  const achievements = achievementStateFor(state);
  assert.deepEqual(
    [0, 1, 8, 9, 10, 11, 15].map((id) => achievements.data.find((group) => group.id === id)?.value),
    [8, 5, 5, 10, 1, 15, 7],
  );
  assert.doesNotThrow(() => validateAchievementProgressState(state, 15, 7));
  assert.throws(
    () => validateAchievementProgressState(state, 15, 8),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_REWARD_NOT_FOUND,
  );
});

test("achievement claims enforce tier order and credit scene-defined rewards once", () => {
  let state = createInitialProgression(NOW);
  state = advanceAchievementState(state, 2, 10).state;

  assert.throws(
    () => claimAchievementState(state, 2, 1),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_REWARD_NOT_FOUND,
  );

  const claim = claimAchievementState(state, 2, 0);
  assert.equal(claim.state.gold, 1);
  assert.equal(claim.achievements.data.find((group) => group.id === 2)?.progress[0].claimed, true);
  assert.throws(
    () => claimAchievementState(claim.state, 2, 0),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_ALREADY_CLAIMED,
  );
});

test("achievement RequestBuffer replay cannot grant the same tier twice", () => {
  let state = createInitialProgression(NOW);
  state = advanceAchievementState(state, 2, 10).state;
  const requests = [
    { action: DbAction.ChangeAchievementProgres, data: JSON.stringify({ Id: 2, Progress: 10 }) },
    { action: DbAction.ClaimAchievement, data: JSON.stringify({ Id: 2, ProgressId: 0 }) },
  ];

  const first = processAssignmentBufferState(state, NOW, "achievement-buffer", requests);
  assert.equal(first.state.gold, 1);
  assert.deepEqual(JSON.parse(first.requestsResults), [
    { ActionId: DbAction.ChangeAchievementProgres, Result: 1 },
    { ActionId: DbAction.ClaimAchievement, Result: 1 },
  ]);

  const replay = processAssignmentBufferState(first.state, NOW + 1, "achievement-buffer", requests);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.gold, 1);
  assert.equal(replay.requestsResults, first.requestsResults);
});
