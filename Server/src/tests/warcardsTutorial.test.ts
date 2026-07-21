import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { matchHandlers } from "../handlers/match";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import {
  WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
  WARCARDS_TUTORIAL_REWARD_IDS,
  settleWarcardsTutorialState,
  shouldStartWarcardsTutorial,
  startWarcardsTutorialState,
} from "../services/warcardsTutorialService";

const NOW = 1_900_000_000;
const BATTLE_ID = "warcards-tutorial-battle";

function eligibleState() {
  return { ...createInitialProgression(NOW), tutorialFinished: true };
}

function playerDocument(level: number, tutorialFinished: boolean, warcardsFinished: boolean): PlayerDocument {
  const player = newPlayer("warcards-player", "WarcardsPlayer", AccountType.Guest);
  player.level = level;
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
    progression: {
      ...createInitialProgression(NOW),
      tutorialFinished,
      warcardsTutorialFinished: warcardsFinished,
    },
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

function cardTutState(player: PlayerDocument): number {
  const data = buildPlayerData(player, NOW);
  const analytics = JSON.parse((data.PlayerAnalyticsData as { S: string }).S) as { cardTutState: number };
  return analytics.cardTutState;
}

test("Play Warcards starts only after bootcamp and the recovered display-level-six gate", () => {
  const state = eligibleState();
  assert.equal(shouldStartWarcardsTutorial(state, WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX - 1), false);
  assert.equal(shouldStartWarcardsTutorial(
    { ...state, tutorialFinished: false },
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
  ), false);
  assert.equal(shouldStartWarcardsTutorial(state, WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX), true);

  const belowLevel = startWarcardsTutorialState(
    state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX - 1,
    BATTLE_ID,
    NOW,
  );
  assert.equal(belowLevel.state, state);
  assert.equal(belowLevel.started, false);

  const started = startWarcardsTutorialState(
    state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    NOW,
  );
  assert.equal(started.started, true);
  assert.equal(started.replayed, false);
  assert.deepEqual(started.state.warcardsTutorialBattle, { battleId: BATTLE_ID, startedAt: NOW });

  const replay = startWarcardsTutorialState(
    started.state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    NOW + 10,
  );
  assert.equal(replay.state, started.state);
  assert.equal(replay.replayed, true);
});

test("Play Warcards rejects contradictory completion order and exhausted revisions", () => {
  const contradictory = createInitialProgression(NOW);
  contradictory.warcardsTutorialFinished = true;
  assert.throws(
    () => shouldStartWarcardsTutorial(contradictory, WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX),
    /Stored tutorial completion order is invalid/,
  );

  const exhausted = eligibleState();
  exhausted.revision = Number.MAX_SAFE_INTEGER;
  assert.throws(
    () => startWarcardsTutorialState(
      exhausted,
      WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
      BATTLE_ID,
      NOW,
    ),
    /Tutorial progression revision is invalid/,
  );

  const futureReceipt = eligibleState();
  futureReceipt.warcardsTutorialBattle = { battleId: BATTLE_ID, startedAt: NOW + 1 };
  assert.throws(
    () => startWarcardsTutorialState(
      futureReceipt,
      WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
      BATTLE_ID,
      NOW,
    ),
    /Stored Play Warcards battle is invalid/,
  );
});

test("a restarted Play Warcards battle replaces an abandoned receipt", () => {
  const first = startWarcardsTutorialState(
    eligibleState(),
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    NOW,
  );
  const second = startWarcardsTutorialState(
    first.state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    "replacement-battle",
    NOW + 30,
  );
  assert.equal(second.replayed, false);
  assert.deepEqual(second.state.warcardsTutorialBattle, {
    battleId: "replacement-battle",
    startedAt: NOW + 30,
  });
});

test("non-forfeit completion grants the exact fixed five cards once", () => {
  const initial = eligibleState();
  initial.cardInventory!.cardData.CLUSTERGRENADE = { amount: 2 };
  const started = startWarcardsTutorialState(
    initial,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    NOW,
  );
  const finished = settleWarcardsTutorialState(
    started.state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    1,
    NOW,
  );
  assert.equal(finished.awarded, true);
  assert.deepEqual(finished.cards, [...WARCARDS_TUTORIAL_REWARD_IDS]);
  assert.equal(finished.state.warcardsTutorialFinished, true);
  assert.equal(finished.state.warcardsTutorialBattle, undefined);
  assert.equal(finished.state.cardInventory!.cardData.CLUSTERGRENADE?.amount, 3);
  for (const id of WARCARDS_TUTORIAL_REWARD_IDS.slice(1)) {
    assert.equal(finished.state.cardInventory!.cardData[id]?.amount, 1);
  }

  const replay = settleWarcardsTutorialState(
    finished.state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    2,
    NOW,
  );
  assert.equal(replay.state, finished.state);
  assert.equal(replay.awarded, false);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.cardInventory!.cardData.CLUSTERGRENADE?.amount, 3);
});

test("forfeit consumes the receipt without granting cards and permits a fresh start", () => {
  const started = startWarcardsTutorialState(
    eligibleState(),
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    NOW,
  );
  const forfeited = settleWarcardsTutorialState(
    started.state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    5,
    NOW,
  );
  assert.equal(forfeited.awarded, false);
  assert.equal(forfeited.state.warcardsTutorialFinished, undefined);
  assert.equal(forfeited.state.warcardsTutorialBattle, undefined);
  assert.deepEqual(forfeited.state.cardInventory!.cardData, {});

  const restarted = startWarcardsTutorialState(
    forfeited.state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    "retry-after-forfeit",
    NOW + 60,
  );
  assert.equal(restarted.started, true);
  assert.equal(restarted.replayed, false);
});

test("Play Warcards settlement rejects missing receipts, forged IDs, and invalid outcomes", () => {
  const state = eligibleState();
  assert.throws(() => settleWarcardsTutorialState(
    state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    2,
    NOW,
  ));
  const started = startWarcardsTutorialState(
    state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    NOW,
  );
  assert.throws(() => settleWarcardsTutorialState(
    started.state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    "forged-battle",
    2,
    NOW,
  ));
  assert.throws(() => settleWarcardsTutorialState(
    started.state,
    WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX,
    BATTLE_ID,
    999,
    NOW,
  ));
});

test("PlayerAnalyticsData restores cardTutState 0, 1, and 2 from durable authority", () => {
  assert.equal(cardTutState(playerDocument(WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX, false, false)), 0);
  assert.equal(cardTutState(playerDocument(WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX - 1, true, false)), 0);
  assert.equal(cardTutState(playerDocument(WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX, true, false)), 1);
  assert.equal(cardTutState(playerDocument(WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX, true, true)), 2);
  const contradictory = playerDocument(WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX, false, true);
  assert.throws(() => cardTutState(contradictory), /Stored tutorial completion order is invalid/);
  assert.equal(matchHandlers[DbAction.GameStartedMaster]?.requiresAuth, true);
  assert.equal(matchHandlers[DbAction.GameEnded]?.requiresAuth, true);
});
