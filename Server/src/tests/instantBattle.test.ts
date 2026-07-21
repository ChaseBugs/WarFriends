import test from "node:test";
import assert from "node:assert/strict";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { League } from "../constants";
import type { PlayerDocument } from "../db";
import { optionalInstantBattlePaidCost } from "../handlers/instantBattle";
import {
  INSTANT_BATTLE_MAX_CHARGES,
  INSTANT_BATTLE_RELOAD_SECONDS,
  INSTANT_BATTLE_UNLOCK_DISPLAY_LEVEL,
  instantBattleGoldCost,
  instantBattlesReady,
  instantBattleStateFor,
  instantBattleWireResponse,
  playInstantBattleState,
} from "../services/instantBattleService";
import { playerLevelDefinition } from "../services/levelProgressionService";
import {
  buildPlayerData,
  createInitialProgression,
  progressionForPlayer,
} from "../services/playerStateService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";

const NOW = 1_800_000_000;
const UNLOCKED_LEVEL_INDEX = 8;
const POLICY = { experiencePerBattle: 20, warBucksPerBattle: 600 } as const;

function unlockedState() {
  return {
    ...createInitialProgression(NOW - 100),
    gold: 1_000,
    warBucks: 5_000,
  };
}

test("Instant Battle distinguishes an omitted free request from an exact paid C# integer", () => {
  assert.equal(optionalInstantBattlePaidCost(undefined), undefined);
  assert.equal(optionalInstantBattlePaidCost(35), 35);
  assert.equal(optionalInstantBattlePaidCost("35"), 35);

  for (const value of [null, false, true, [], [35], "", " 35", "35 ", "+35", "035", "35.0", "35e0", 0, -35, "2147483648"]) {
    assert.throws(
      () => optionalInstantBattlePaidCost(value),
      (error: unknown) => error instanceof ApiError && error.code === ApiErrorCode.RequestNotAuthorized,
    );
  }
});

test("Instant Battle source contract uses rank 9, five charges, 48 minutes, and 35/70/140 Gold", () => {
  assert.equal(playerLevelDefinition(UNLOCKED_LEVEL_INDEX).displayLevel, INSTANT_BATTLE_UNLOCK_DISPLAY_LEVEL);
  assert.equal(INSTANT_BATTLE_MAX_CHARGES, 5);
  assert.equal(INSTANT_BATTLE_RELOAD_SECONDS, 48 * 60);
  assert.deepEqual([0, 1, 2, 3, 20].map(instantBattleGoldCost), [35, 70, 140, 140, 140]);
});

test("a free action consumes every ready charge and immediate transport replay is immutable", () => {
  const initial = unlockedState();
  const played = playInstantBattleState(initial, UNLOCKED_LEVEL_INDEX, NOW, undefined, POLICY);

  assert.equal(played.replayed, false);
  assert.equal(played.receipt.battleCount, 5);
  assert.equal(played.receipt.experienceGained, 100);
  assert.equal(played.receipt.warBucks, 3_000);
  assert.equal(played.state.warBucks, 8_000);
  assert.equal(played.instantBattle.instantBattlesTime, NOW);
  assert.equal(played.instantBattle.instantBattles, 5);
  assert.equal(played.instantBattle.paidInstantBattles, 0);
  assert.equal(instantBattlesReady(played.instantBattle, NOW + INSTANT_BATTLE_RELOAD_SECONDS - 1), 0);
  assert.equal(instantBattlesReady(played.instantBattle, NOW + INSTANT_BATTLE_RELOAD_SECONDS), 1);

  const replay = playInstantBattleState(played.state, UNLOCKED_LEVEL_INDEX, NOW, undefined, POLICY);
  assert.equal(replay.replayed, true);
  assert.strictEqual(replay.state, played.state);
  assert.deepEqual(replay.receipt, played.receipt);

  assert.throws(
    () => playInstantBattleState(played.state, UNLOCKED_LEVEL_INDEX, NOW + 1, undefined, POLICY),
    (error: unknown) => error instanceof ApiError && error.code === ApiErrorCode.NoSkirmishAvailable,
  );
});

test("a paid action requires zero ready charges, verifies its price, and buys a full batch", () => {
  const first = playInstantBattleState(unlockedState(), UNLOCKED_LEVEL_INDEX, NOW, undefined, POLICY);
  const paidAt = NOW + 10;
  const paid = playInstantBattleState(first.state, UNLOCKED_LEVEL_INDEX, paidAt, 35, POLICY);

  assert.equal(paid.receipt.battleCount, 5);
  assert.equal(paid.receipt.paidCost, 35);
  assert.equal(paid.state.gold, first.state.gold - 35);
  assert.equal(paid.state.warBucks, first.state.warBucks + 3_000);
  assert.equal(paid.instantBattle.instantBattles, 10);
  assert.equal(paid.instantBattle.paidInstantBattles, 1);
  assert.equal(paid.instantBattle.instantBattlesTime, first.instantBattle.instantBattlesTime);
  assert.equal(instantBattleGoldCost(paid.instantBattle.paidInstantBattles), 70);

  assert.throws(
    () => playInstantBattleState(first.state, UNLOCKED_LEVEL_INDEX, paidAt, 70, POLICY),
    (error: unknown) => {
      assert.ok(error instanceof ApiError);
      assert.equal(error.code, ApiErrorCode.NotEnoughGoldForSkirmish);
      assert.deepEqual(error.details, {
        SkirmishCost: 35,
        PaidBattles: 0,
        PlayerGold: first.state.gold,
      });
      return true;
    },
  );
});

test("partial free consumption preserves recharge remainder while a capped batch discards surplus", () => {
  const anchor = NOW - (2 * INSTANT_BATTLE_RELOAD_SECONDS + 123);
  const state = {
    ...unlockedState(),
    instantBattle: {
      instantBattlesTime: anchor,
      instantBattles: 10,
      paidInstantBattles: 0,
    },
  };
  const partial = playInstantBattleState(state, UNLOCKED_LEVEL_INDEX, NOW, undefined, POLICY);
  assert.equal(partial.receipt.battleCount, 2);
  assert.equal(
    partial.instantBattle.instantBattlesTime,
    anchor + 2 * INSTANT_BATTLE_RELOAD_SECONDS,
  );
  assert.equal(
    instantBattlesReady(partial.instantBattle, NOW + INSTANT_BATTLE_RELOAD_SECONDS - 123),
    1,
  );

  const cappedAnchor = NOW - 20 * INSTANT_BATTLE_RELOAD_SECONDS;
  const capped = playInstantBattleState(
    { ...unlockedState(), instantBattle: { instantBattlesTime: cappedAnchor, instantBattles: 0, paidInstantBattles: 0 } },
    UNLOCKED_LEVEL_INDEX,
    NOW,
    undefined,
    POLICY,
  );
  assert.equal(capped.receipt.battleCount, INSTANT_BATTLE_MAX_CHARGES);
  assert.equal(capped.instantBattle.instantBattlesTime, NOW);
});

test("paid failure returns the stock client's exact wallet repair fields", () => {
  const consumed = playInstantBattleState(unlockedState(), UNLOCKED_LEVEL_INDEX, NOW, undefined, POLICY);
  const poor = { ...consumed.state, gold: 20 };
  assert.throws(
    () => playInstantBattleState(poor, UNLOCKED_LEVEL_INDEX, NOW + 1, 35, POLICY),
    (error: unknown) => {
      assert.ok(error instanceof ApiError);
      assert.equal(error.code, ApiErrorCode.NotEnoughGoldForSkirmish);
      assert.deepEqual(error.details, { SkirmishCost: 35, PaidBattles: 0, PlayerGold: 20 });
      return true;
    },
  );
});

test("rank-up response grants source level Gold and persistently refills dog tags", () => {
  const definition = playerLevelDefinition(UNLOCKED_LEVEL_INDEX);
  const initial = {
    ...unlockedState(),
    levelExperience: definition.experience - 1,
    dogTagSeconds: 0,
  };
  const played = playInstantBattleState(
    initial,
    UNLOCKED_LEVEL_INDEX,
    NOW,
    undefined,
    { experiencePerBattle: 1, warBucksPerBattle: 0 },
  );

  assert.equal(played.receipt.levelFrom, UNLOCKED_LEVEL_INDEX);
  assert.equal(played.receipt.levelTo, UNLOCKED_LEVEL_INDEX + 1);
  assert.equal(played.receipt.levelExperience, 4);
  assert.equal(played.receipt.levelGold, definition.rewardGold);
  assert.equal(played.state.gold, initial.gold + definition.rewardGold);
  assert.equal(played.state.dogTagSeconds, played.state.dogTagMax);
  assert.equal(played.state.dogTagLastUpdate, NOW);

  const wire = instantBattleWireResponse({
    ...played,
    playerLevel: played.receipt.levelTo,
    armyPower: 0,
  });
  assert.equal(wire.Level, UNLOCKED_LEVEL_INDEX + 1);
  assert.equal(wire.LevelGold, definition.rewardGold);
  assert.equal(wire.DogtagsRefillRankUp, true);
  assert.equal(wire.LevelExperience, 4);
});

test("PlayerAnalyticsData restores authoritative timer, lifetime, and paid counters", () => {
  const state = unlockedState();
  state.instantBattle = {
    instantBattlesTime: NOW - 500,
    instantBattles: 45,
    paidInstantBattles: 2,
  };
  const player = {
    id: "instant-player",
    accountName: "InstantPlayer",
    accountType: 0,
    leagueTier: League.Bronze3,
    armyPower: 0,
    experience: 0,
    squadPoints: 0,
    squadName: "",
    progression: state,
    createdAt: new Date((NOW - 1_000) * 1_000),
    updatedAt: new Date(NOW * 1_000),
    player: {
      id: "instant-player",
      accountName: "InstantPlayer",
      level: UNLOCKED_LEVEL_INDEX,
      experience: 0,
      armyPower: 0,
      leagueTier: League.Bronze3,
      squadPoints: 0,
      squadName: "",
      facebookId: -1,
      gameCenterId: "",
      googlePlayId: "",
      accountType: 0,
      reputation: 0,
      skill: 0,
      medalsBalance: 0,
      remainingMatches: 0,
      leagueId: "",
      leagueDivision: "",
      beginnersLeague: 1,
      squadRank: 0,
      vipExpiration: 0,
      country: "",
      status: 0,
      lastAction: 0,
      awaitingSquadMember: false,
      visualType: "",
      visualTimestamp: 0,
      influencerLink: "",
      influencerAlias: "",
      bestRegions: {},
      connectionType: 0,
      deviceToken: "",
      sendLogsValue: 0,
      locale: "en",
      renameCount: 0,
      notificationSettings: {
        challenge: true,
        squadStatus: true,
        squadEvents: true,
        maintenance: false,
        playerLeague: true,
        dailyRewardNotification: true,
      },
      inventoryData: null,
      levelManagerData: null,
      statisticsData: null,
      playerVisuals: {},
      depositedCardsDic: {},
    },
  } satisfies PlayerDocument;

  const data = buildPlayerData(player, NOW);
  const analytics = JSON.parse((data.PlayerAnalyticsData as { S: string }).S) as Record<string, number>;
  assert.equal(analytics.instantBattlesTime, NOW - 500);
  assert.equal(analytics.instantBattles, 45);
  assert.equal(analytics.paidInstantBattles, 2);
  assert.deepEqual(instantBattleStateFor(state), state.instantBattle);

  state.instantBattle.instantBattlesTime = NOW + 1;
  assert.throws(
    () => buildPlayerData(player, NOW),
    /Instant Battle timer is in the future/,
  );

  state.instantBattle = {
    instantBattlesTime: NOW - 500,
    instantBattles: 45,
    paidInstantBattles: 2,
    lastReceipt: null,
  } as unknown as typeof state.instantBattle;
  assert.throws(
    () => progressionForPlayer(player),
    /Instant Battle receipt is invalid/,
  );
});

test("Instant Battle counter authority rejects non-client and inconsistent persisted tuples", () => {
  const state = unlockedState();
  const valid = {
    instantBattlesTime: NOW - 500,
    instantBattles: 45,
    paidInstantBattles: 2,
  };
  state.instantBattle = valid;
  assert.deepEqual(instantBattleStateFor(state, NOW), valid);

  for (const value of [Number.NaN, Number.POSITIVE_INFINITY, -1, 1.5, 2_147_483_648]) {
    for (const field of ["instantBattlesTime", "instantBattles", "paidInstantBattles"] as const) {
      state.instantBattle = { ...valid, [field]: value };
      assert.throws(() => instantBattleStateFor(state, NOW), /is invalid/);
    }
  }

  state.instantBattle = { ...valid, instantBattles: 9, paidInstantBattles: 2 };
  assert.throws(
    () => playInstantBattleState(state, UNLOCKED_LEVEL_INDEX, NOW, undefined, POLICY),
    /Instant Battle counters are inconsistent/,
  );
});

test("Instant Battle replay receipt is exact and revision-bound at shared publication", () => {
  const current = unlockedState();
  const settled = playInstantBattleState(
    current,
    UNLOCKED_LEVEL_INDEX,
    NOW,
    undefined,
    POLICY,
  );
  assert.equal(validatedProgressionSuccessor(current, settled.state), settled.state);

  const futureRevision = {
    ...settled.state,
    revision: settled.state.revision + 1,
    instantBattle: {
      ...settled.instantBattle,
      lastReceipt: {
        ...settled.receipt,
        progressionRevision: settled.state.revision + 2,
      },
    },
  };
  assert.throws(
    () => validatedProgressionSuccessor(settled.state, futureRevision),
    /Instant Battle receipt is inconsistent/,
  );

  const unknownReceiptField = {
    ...settled.state,
    revision: settled.state.revision + 1,
    instantBattle: {
      ...settled.instantBattle,
      lastReceipt: { ...settled.receipt, clientReward: 999 },
    },
  };
  assert.throws(
    () => validatedProgressionSuccessor(settled.state, unknownReceiptField),
    /Instant Battle receipt is invalid/,
  );
});
