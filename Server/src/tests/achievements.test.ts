import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import { League } from "../constants";
import {
  ACHIEVEMENT_DEFINITIONS,
  ACHIEVEMENT_ALREADY_CLAIMED,
  ACHIEVEMENT_REWARD_NOT_FOUND,
  NON_AUTHORITATIVE_ACHIEVEMENT_GROUPS,
  acknowledgeAchievementOffsetState,
  achievementStateFor,
  advanceAchievementState,
  claimAchievementState,
  completeFirstSquadWarAchievementState,
  serializeAchievementsData,
  synchronizeCardsPlayedInMatchAchievementState,
  synchronizeLeagueAchievementState,
  validateAchievementProgressState,
} from "../services/achievementService";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  BLACK_MARKET_WEAPON_CATALOG,
  WEAPON_CATALOG,
} from "../services/itemInventoryService";
import { createInitialProgression } from "../services/playerStateService";
import { UNIT_CATALOG } from "../services/unitInventoryService";
import { createInitialVisualInventory, VISUAL_CATALOG } from "../services/visualInventoryService";
import { validatedCardLifecycleCounters } from "../services/cardLifecycleCounterAuthorityService";
import { validatedAchievementState } from "../services/achievementAuthorityService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;

test("card lifecycle counters reject malformed durable reward authority", () => {
  assert.deepEqual(validatedCardLifecycleCounters(createInitialProgression(NOW)), {
    warCardsPlayed: 0,
    goldCardsCrafted: 0,
  });
  for (const state of [
    { ...createInitialProgression(NOW), warCardsPlayed: Number.NaN },
    { ...createInitialProgression(NOW), warCardsPlayed: -1 },
    { ...createInitialProgression(NOW), goldCardsCrafted: 1.5 },
    { ...createInitialProgression(NOW), goldCardsCrafted: Number.POSITIVE_INFINITY },
  ]) {
    assert.throws(
      () => validatedCardLifecycleCounters(state),
      /Stored (War Card play|Gold-card craft) counter is invalid/,
    );
  }
});

test("achievement state uses the exact recovered AchievementsData wire fields", () => {
  const achievements = achievementStateFor(createInitialProgression(NOW));
  const rankedWins = achievements.data.find((group) => group.id === 2)!;

  // MainScene 4.9.5 contains every group from 0 through 19. Even the combat-telemetry rows must
  // be present at zero so the stock UI can merge its scene definitions with the server model.
  assert.deepEqual(achievements.data.map((group) => group.id), Array.from({ length: 20 }, (_, id) => id));

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

test("finishing a Squad War completes the exact one-time 4.9.5 achievement", () => {
  assert.deepEqual(ACHIEVEMENT_DEFINITIONS[19], [
    { target: 1, gold: 0, warBucks: 5_000, scraps: 0, tickets: 0 },
  ]);

  const initial = createInitialProgression(NOW);
  const completed = completeFirstSquadWarAchievementState(initial);
  assert.equal(completed.achievements.data.find((group) => group.id === 19)?.value, 1);
  assert.equal(completed.state.revision, initial.revision + 1);

  // A scheduler replay or a later finished war is a strict no-op. The one-tier achievement
  // cannot manufacture another progression revision or a second claimable reward.
  const replay = completeFirstSquadWarAchievementState(completed.state);
  assert.equal(replay.state, completed.state);
});

test("combat-telemetry achievements keep their exact 4.9.5 wire tiers but remain locked", () => {
  assert.deepEqual([...NON_AUTHORITATIVE_ACHIEVEMENT_GROUPS], [6, 7, 18]);
  assert.deepEqual(
    [6, 7, 18].map((id) => ACHIEVEMENT_DEFINITIONS[id].map((tier) => [tier.target, tier.gold])),
    [
      [[100, 1], [1_000, 5], [10_000, 10]],
      [[30, 1], [300, 5], [3_000, 10]],
      [[15, 1], [150, 5], [1_500, 25]],
    ],
  );

  const imported = createInitialProgression(NOW);
  imported.achievements = {
    data: [
      { id: 6, offset: 99, value: 10_000, progress: [{ claimed: false }, { claimed: false }, { claimed: false }] },
    ],
  };
  const normalized = achievementStateFor(imported);
  assert.deepEqual(
    normalized.data.find((group) => group.id === 6),
    { id: 6, offset: 0, value: 0, progress: [{ claimed: false }, { claimed: false }, { claimed: false }] },
  );
  assert.throws(
    () => advanceAchievementState(imported, 6, 100),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_REWARD_NOT_FOUND,
  );
  assert.throws(
    () => claimAchievementState(imported, 6, 0),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_REWARD_NOT_FOUND,
  );
});

test("achievement acknowledgements and satisfied projections preserve exact state identity", () => {
  const initial = createInitialProgression(NOW);
  const materialized = advanceAchievementState(initial, 2, 100);
  const revision = materialized.state.revision;

  const zeroAdvance = advanceAchievementState(materialized.state, 2, 0);
  const cappedAdvance = advanceAchievementState(materialized.state, 2, 1_000);
  const confirmedProgress = validateAchievementProgressState(materialized.state, 2, 10);
  const zeroOffset = acknowledgeAchievementOffsetState(materialized.state, 2, -999);

  assert.equal(zeroAdvance.state, materialized.state);
  assert.equal(cappedAdvance.state, materialized.state);
  assert.equal(confirmedProgress.state, materialized.state);
  assert.equal(zeroOffset.state, materialized.state);
  assert.equal(materialized.state.revision, revision);

  const league = synchronizeLeagueAchievementState(materialized.state, League.Gold1);
  assert.notEqual(league.state, materialized.state);
  assert.equal(synchronizeLeagueAchievementState(league.state, League.Silver3).state, league.state);

  const cards = synchronizeCardsPlayedInMatchAchievementState(league.state, 5);
  assert.notEqual(cards.state, league.state);
  assert.equal(synchronizeCardsPlayedInMatchAchievementState(cards.state, 2).state, cards.state);
});

test("no-op achievement actions still persist a stale account normalization exactly once", () => {
  const legacy = createInitialProgression(NOW);
  legacy.achievements = {
    data: [{ id: 2, offset: 9, value: 0, progress: [{ claimed: false }] }],
  };

  const normalized = acknowledgeAchievementOffsetState(legacy, 2, 0);
  assert.notEqual(normalized.state, legacy);
  assert.equal(normalized.state.revision, legacy.revision + 1);
  assert.equal(normalized.achievements.data.find((group) => group.id === 2)?.offset, 0);
  assert.equal(normalized.achievements.data.find((group) => group.id === 2)?.progress.length, 3);
  assert.equal(acknowledgeAchievementOffsetState(normalized.state, 2, 0).state, normalized.state);
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

  state.visualInventory = createInitialVisualInventory();
  const shopVisual = Object.values(VISUAL_CATALOG).find((definition) =>
    definition.categoryId !== 3
    && definition.purchasable === "shop"
    && definition.priceGold + definition.priceWarBucks > 0)!;
  const eventVisual = Object.values(VISUAL_CATALOG).find((definition) =>
    definition.categoryId !== 3 && definition.purchasable === "event")!;
  const partsVisual = Object.values(VISUAL_CATALOG).find((definition) =>
    definition.categoryId !== 3
    && definition.parts > 0
    && definition.name !== shopVisual.name
    && definition.name !== eventVisual.name)!;
  state.visualInventory.visuals[shopVisual.name] = {
    bought: true,
    showed: true,
    expiresOn: 0,
    borrowed: false,
    parts: 0,
    notificate: false,
  };
  state.visualInventory.visuals[eventVisual.name] = {
    bought: true,
    showed: true,
    expiresOn: 0,
    borrowed: false,
    parts: 0,
    notificate: false,
  };
  state.visualInventory.visuals[partsVisual.name] = {
    bought: false,
    showed: true,
    expiresOn: 0,
    borrowed: false,
    parts: partsVisual.parts,
    notificate: false,
  };

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

  // A voided purchase may remove the underlying visual after an earned tier was claimed. Keep
  // only that claim's minimum target; an unclaimed imported value remains non-authoritative.
  const reversed = createInitialProgression(NOW);
  reversed.achievements = {
    data: [{ id: 15, offset: 0, value: 7, progress: [
      { claimed: true }, { claimed: false }, { claimed: false },
    ] }],
  };
  assert.equal(achievementStateFor(reversed).data.find((group) => group.id === 15)?.value, 7);
  reversed.achievements.data[0] = {
    id: 15,
    offset: 0,
    value: 29,
    progress: [{ claimed: false }, { claimed: false }, { claimed: false }],
  };
  assert.equal(achievementStateFor(reversed).data.find((group) => group.id === 15)?.value, 4);
});

test("Arena achievement definitions preserve exact Ticket and Scraps rewards", () => {
  assert.deepEqual(
    [3, 4].map((id) => ACHIEVEMENT_DEFINITIONS[id].map((tier) => [
      tier.target,
      tier.scraps,
      tier.tickets,
    ])),
    [
      [[2, 0, 5], [10, 0, 15], [100, 0, 50]],
      [[1, 50, 0], [3, 150, 0], [10, 250, 0]],
    ],
  );
});

test("league achievement uses exact tiers and preserves the highest server-owned league", () => {
  assert.deepEqual(
    ACHIEVEMENT_DEFINITIONS[13].map((tier) => [tier.target, tier.gold]),
    [[League.Silver2, 5], [League.Gold1, 10], [League.Master3, 20]],
  );

  const promoted = synchronizeLeagueAchievementState(createInitialProgression(NOW), League.Gold1);
  assert.equal(promoted.achievements.data.find((group) => group.id === 13)?.value, League.Gold1);
  const demoted = synchronizeLeagueAchievementState(promoted.state, League.Silver3);
  assert.equal(demoted.achievements.data.find((group) => group.id === 13)?.value, League.Gold1);
});

test("league achievement buffer claims only the authenticated profile tier", () => {
  const requests = [
    { action: DbAction.ChangeAchievementProgres, data: JSON.stringify({ Id: 13, Progress: League.Silver2 }) },
    { action: DbAction.ClaimAchievement, data: JSON.stringify({ Id: 13, ProgressId: 0 }) },
  ];
  const result = processAssignmentBufferState(
    createInitialProgression(NOW),
    NOW,
    "league-achievement-buffer",
    requests,
    1,
    0,
    League.Silver2,
  );
  assert.equal(result.state.gold, 5);
  assert.equal(result.state.achievements?.data.find((group) => group.id === 13)?.value, League.Silver2);

  const forged = processAssignmentBufferState(
    createInitialProgression(NOW),
    NOW,
    "forged-league-achievement-buffer",
    [{
      action: DbAction.ChangeAchievementProgres,
      data: JSON.stringify({ Id: 13, Progress: League.Gold1 }),
    }],
    1,
    0,
    League.Silver2,
  );
  assert.deepEqual(JSON.parse(forged.requestsResults), [
    { ActionId: DbAction.ChangeAchievementProgres, Result: ACHIEVEMENT_REWARD_NOT_FOUND },
  ]);
});

test("five-card match achievement keeps the largest accepted one-match count", () => {
  assert.deepEqual(
    ACHIEVEMENT_DEFINITIONS[17].map((tier) => [tier.target, tier.warBucks]),
    [[5, 50_000]],
  );

  const four = synchronizeCardsPlayedInMatchAchievementState(createInitialProgression(NOW), 4);
  assert.equal(four.achievements.data.find((group) => group.id === 17)?.value, 4);
  const laterTwo = synchronizeCardsPlayedInMatchAchievementState(four.state, 2);
  assert.equal(laterTwo.achievements.data.find((group) => group.id === 17)?.value, 4);
  const completed = synchronizeCardsPlayedInMatchAchievementState(laterTwo.state, 5);
  assert.equal(completed.achievements.data.find((group) => group.id === 17)?.value, 5);
  assert.equal(claimAchievementState(completed.state, 17, 0).state.warBucks, 50_000);
  assert.throws(
    () => synchronizeCardsPlayedInMatchAchievementState(completed.state, 7),
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

test("achievement claims reject corrupt progress before a tier marker or reward is consumed", () => {
  const initial = createInitialProgression(NOW);
  const achievements = achievementStateFor(initial);
  const missionGroup = achievements.data.find((group) => group.id === 2)!;
  missionGroup.value = Number.NaN;
  const corrupt = { ...initial, achievements };

  assert.throws(
    () => claimAchievementState(corrupt, 2, 0),
    /Stored achievement progress is invalid/,
  );
  assert.equal(missionGroup.progress[0]!.claimed, false);
  assert.equal(corrupt.gold, initial.gold);
});

test("shared progression publication rejects duplicate, out-of-order, or unearned achievement authority", () => {
  const current = createInitialProgression(NOW);
  const achievements = achievementStateFor(current);
  const first = achievements.data[0]!;
  const duplicate = { data: [first, structuredClone(first)] };
  assert.throws(() => validatedAchievementState(duplicate), /group IDs are duplicated/);
  assert.throws(
    () => validatedProgressionSuccessor(current, {
      ...current,
      revision: 1,
      achievements: duplicate,
    }),
    /group IDs are duplicated/,
  );

  const outOfOrder = achievementStateFor(current);
  outOfOrder.data.find((group) => group.id === 2)!.progress[1]!.claimed = true;
  assert.throws(() => validatedAchievementState(outOfOrder), /claim order is invalid/);

  const unearned = achievementStateFor(current);
  unearned.data.find((group) => group.id === 2)!.progress[0]!.claimed = true;
  assert.throws(() => validatedAchievementState(unearned), /claimed tier is not earned/);
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
