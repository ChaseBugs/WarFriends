import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import type { PlayerDocument, PlayerFeatureIntroductionState } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { analyticsHandlers } from "../handlers/analytics";
import {
  type FeatureIntroductionKey,
  markFeatureIntroductionState,
} from "../services/featureIntroductionService";
import {
  buildPlayerData,
  createInitialProgression,
  progressionForPlayer,
} from "../services/playerStateService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";

const NOW = 1_900_000_000;
const FEATURES: readonly FeatureIntroductionKey[] = [
  "chatShown",
  "elitesShown",
  "customizationShown",
  "warpathShown",
  "cardpoolShown",
  "craftingShown",
  "leagueLeaderboardsShown",
];

function playerDocument(): PlayerDocument {
  const player = newPlayer("feature-player", "FeaturePlayer", AccountType.Guest);
  return {
    id: player.id,
    accountName: player.accountName,
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

test("feature introduction acknowledgements are monotonic and replay safe", () => {
  let state = createInitialProgression(NOW);
  const initialRevision = state.revision;
  for (const feature of FEATURES) {
    const result = markFeatureIntroductionState(state, feature);
    assert.equal(result.changed, true);
    assert.equal(result.featureIntroductions[feature], true);
    state = result.state;
  }
  assert.equal(state.revision, initialRevision + FEATURES.length);

  const replay = markFeatureIntroductionState(state, "chatShown");
  assert.equal(replay.state, state);
  assert.equal(replay.changed, false);
  assert.equal(replay.featureIntroductions.chatShown, true);
});

test("feature introduction mutations reject corrupt snapshots and revision overflow", () => {
  const wrongType = createInitialProgression(NOW);
  wrongType.featureIntroductions = { chatShown: "false" } as unknown as PlayerFeatureIntroductionState;
  assert.throws(
    () => markFeatureIntroductionState(wrongType, "elitesShown"),
    /Stored feature introduction state is invalid/,
  );

  const unknownKey = createInitialProgression(NOW);
  unknownKey.featureIntroductions = { retiredFeatureShown: true } as unknown as PlayerFeatureIntroductionState;
  assert.throws(
    () => markFeatureIntroductionState(unknownKey, "chatShown"),
    /Stored feature introduction state is invalid/,
  );

  const exhaustedRevision = createInitialProgression(NOW);
  exhaustedRevision.revision = Number.MAX_SAFE_INTEGER;
  assert.throws(
    () => markFeatureIntroductionState(exhaustedRevision, "chatShown"),
    /Feature introduction progression revision is invalid/,
  );
});

test("shared progression boundaries reject malformed feature introduction snapshots", () => {
  const corruptRead = playerDocument();
  corruptRead.progression!.featureIntroductions = {
    chatShown: "false",
  } as unknown as PlayerFeatureIntroductionState;
  assert.throws(
    () => progressionForPlayer(corruptRead),
    /Stored feature introduction state is invalid/,
  );

  const current = createInitialProgression(NOW);
  const corruptSuccessor = {
    ...current,
    revision: 1,
    featureIntroductions: { retiredFeatureShown: true } as unknown as PlayerFeatureIntroductionState,
  };
  assert.throws(
    () => validatedProgressionSuccessor(current, corruptSuccessor),
    /Stored feature introduction state is invalid/,
  );

  // A wholly absent legacy snapshot remains the exact empty object consumed as seven false flags.
  assert.deepEqual(progressionForPlayer(playerDocument()).featureIntroductions, {});
});

test("PlayerAnalyticsData restores all durable introduction flags", () => {
  const player = playerDocument();
  player.progression!.featureIntroductions = Object.fromEntries(
    FEATURES.map((feature) => [feature, true]),
  );
  const wire = buildPlayerData(player, NOW);
  const analytics = JSON.parse((wire.PlayerAnalyticsData as { S: string }).S) as Record<string, boolean>;
  for (const feature of FEATURES) assert.equal(analytics[feature], true, feature);

  const empty = buildPlayerData(playerDocument(), NOW);
  const emptyAnalytics = JSON.parse((empty.PlayerAnalyticsData as { S: string }).S) as Record<string, boolean>;
  for (const feature of FEATURES) assert.equal(emptyAnalytics[feature], false, feature);

  player.progression!.featureIntroductions = { chatShown: 1 } as unknown as PlayerFeatureIntroductionState;
  assert.throws(() => buildPlayerData(player, NOW), /Stored feature introduction state is invalid/);
});

test("all seven dedicated shown actions now require authentication", () => {
  const actions = [
    DbAction.ChatShownFirstTime,
    DbAction.CustomizationShown,
    DbAction.WarpathShownFirstTime,
    DbAction.CardpoolShown,
    DbAction.LeagueLeaderboardShown,
    DbAction.CraftingShown,
    DbAction.ElitesFeatureShown,
  ];
  for (const action of actions) assert.equal(analyticsHandlers[action]?.requiresAuth, true, String(action));
  // Broad analytics and impression payloads remain non-authoritative no-ops, but their stock call
  // sites execute in an authenticated gameplay session and must not succeed through the open
  // dispatcher fallback.
  for (const action of [
    DbAction.UpdateAnalytics,
    DbAction.MessageWasShown,
    DbAction.SpecialOfferShowed,
  ]) {
    assert.equal(analyticsHandlers[action]?.requiresAuth, true, String(action));
  }
});

test("non-durable impression actions acknowledge without mutating gameplay", async () => {
  for (const action of [
    DbAction.MessageWasShown,
    DbAction.SpecialOfferShowed,
  ]) {
    const response = await analyticsHandlers[action]!.handler({
      req: { DbAction: action, forgedEconomy: 2_147_483_647 },
      player: playerDocument(),
    });
    assert.deepEqual(response, { DbAction: action, Result: 1, Ignored: true });
  }
});
