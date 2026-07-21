import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { DbAction } from "../dbActions";
import { tutorialHandlers } from "../handlers/tutorial";
import {
  buildPlayerData,
  createInitialProgression,
  progressionForPlayer,
} from "../services/playerStateService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";
import {
  TUTORIAL_STARTING_GOLD,
  TUTORIAL_STARTING_WARBUCKS,
  finishTutorialState,
  startTutorialState,
} from "../services/tutorialService";

const NOW = 1_900_000_000;
const BATTLE_ID = "tutorial-battle-1";

function playerDocument(tutorialFinished: boolean): PlayerDocument {
  const player = newPlayer("tutorial-player", "TutorialPlayer", AccountType.Guest);
  return {
    id: player.id,
    accountName: player.accountName,
    authToken: "tutorial-token",
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: { ...createInitialProgression(NOW), tutorialFinished },
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

test("tutorial start issues one server battle receipt and replays it exactly", () => {
  const initial = createInitialProgression(NOW);
  const started = startTutorialState(initial, NOW, BATTLE_ID);
  assert.equal(started.battleId, BATTLE_ID);
  assert.equal(started.replayed, false);
  assert.deepEqual(started.state.tutorialBattle, { battleId: BATTLE_ID, startedAt: NOW });

  const replay = startTutorialState(started.state, NOW + 30, "different-id");
  assert.equal(replay.state, started.state);
  assert.equal(replay.battleId, BATTLE_ID);
  assert.equal(replay.replayed, true);
});

test("tutorial completion grants only recovered starter constants and one placement match", () => {
  const started = startTutorialState(createInitialProgression(NOW), NOW, BATTLE_ID);
  const finished = finishTutorialState(started.state, BATTLE_ID, 2, 0, NOW);
  assert.equal(finished.state.tutorialFinished, true);
  assert.equal(finished.state.tutorialBattle, undefined);
  assert.equal(finished.state.gold, TUTORIAL_STARTING_GOLD);
  assert.equal(finished.state.warBucks, TUTORIAL_STARTING_WARBUCKS);
  assert.equal(finished.remainingMatches, 1);
  assert.equal(finished.replayed, false);

  // A terminal replay after spending never replenishes either currency.
  const spent = { ...finished.state, gold: 5, warBucks: 10 };
  const replay = finishTutorialState(spent, BATTLE_ID, 2, 1, NOW);
  assert.equal(replay.state, spent);
  assert.equal(replay.state.gold, 5);
  assert.equal(replay.state.warBucks, 10);
  assert.equal(replay.replayed, true);

  assert.throws(
    () => finishTutorialState(spent, BATTLE_ID, 2, Number.POSITIVE_INFINITY, NOW),
    /Player league placement counter is invalid/,
  );
});

test("tutorial starter grant pays chargeback debt instead of erasing it", () => {
  const debt = {
    ...createInitialProgression(NOW),
    gold: -40,
    warBucks: -2_000,
  };
  const finished = finishTutorialState(debt, "", 2, 0, NOW);
  assert.equal(finished.state.gold, TUTORIAL_STARTING_GOLD - 40);
  assert.equal(finished.state.warBucks, TUTORIAL_STARTING_WARBUCKS - 2_000);
});

test("tutorial completion rejects corrupt wallets before publishing its terminal marker", () => {
  const corrupt = { ...createInitialProgression(NOW), gold: Number.NaN };
  assert.throws(
    () => finishTutorialState(corrupt, "", 2, 0, NOW),
    /reward balance is invalid/,
  );
  assert.equal(corrupt.tutorialFinished, false);
});

test("tutorial lifecycle rejects non-Boolean completion authority and revision overflow", () => {
  const corrupt = createInitialProgression(NOW);
  corrupt.tutorialFinished = "false" as unknown as boolean;
  assert.throws(
    () => startTutorialState(corrupt, NOW, BATTLE_ID),
    /Stored tutorial completion state is invalid/,
  );

  const exhausted = createInitialProgression(NOW);
  exhausted.revision = Number.MAX_SAFE_INTEGER;
  assert.throws(
    () => startTutorialState(exhausted, NOW, BATTLE_ID),
    /Tutorial progression revision is invalid/,
  );
  assert.throws(
    () => finishTutorialState(exhausted, "", 2, 0, NOW),
    /Tutorial progression revision is invalid/,
  );

  const corruptReceipt = createInitialProgression(NOW);
  corruptReceipt.tutorialBattle = { battleId: BATTLE_ID, startedAt: Number.NaN };
  assert.throws(
    () => startTutorialState(corruptReceipt, NOW, "replacement"),
    /Stored tutorial battle is invalid/,
  );
  assert.throws(
    () => startTutorialState(createInitialProgression(NOW), Number.NaN, BATTLE_ID),
    /Tutorial lifecycle server time is invalid/,
  );
});

test("shared progression boundaries reject corrupt tutorial lifecycle authority", () => {
  const corruptRead = playerDocument(false);
  corruptRead.progression!.warcardsTutorialBattle = { battleId: BATTLE_ID, startedAt: NOW };
  assert.throws(
    () => progressionForPlayer(corruptRead),
    /Stored tutorial lifecycle order is invalid/,
  );

  const current = createInitialProgression(NOW);
  const corruptSuccessor = {
    ...current,
    revision: 1,
    tutorialBattle: { battleId: BATTLE_ID, startedAt: Number.POSITIVE_INFINITY },
  };
  assert.throws(
    () => validatedProgressionSuccessor(current, corruptSuccessor),
    /Stored tutorial battle is invalid/,
  );

  // Missing legacy completion fields normalize to false at the common persisted read boundary.
  const legacy = playerDocument(false);
  delete legacy.progression!.tutorialFinished;
  delete legacy.progression!.warcardsTutorialFinished;
  const normalized = progressionForPlayer(legacy);
  assert.equal(normalized.tutorialFinished, false);
  assert.equal(normalized.warcardsTutorialFinished, false);
});

test("tutorial completion rejects forged receipts and non-win results", () => {
  const started = startTutorialState(createInitialProgression(NOW), NOW, BATTLE_ID);
  assert.throws(() => finishTutorialState(started.state, "forged", 2, 0, NOW));
  assert.throws(() => finishTutorialState(started.state, BATTLE_ID, 1, 0, NOW));

  // Compatibility is deliberately narrow: only an empty ID may migrate an old no-receipt run.
  const migrated = finishTutorialState(createInitialProgression(NOW), "", 2, 0, NOW);
  assert.equal(migrated.state.tutorialFinished, true);
  assert.throws(() => finishTutorialState(createInitialProgression(NOW), "forged", 2, 0, NOW));
});

test("TutorialData appears in PlayerData only after durable completion", () => {
  const unfinished = buildPlayerData(playerDocument(false), NOW);
  assert.equal(unfinished.TutorialData, undefined);

  const finished = buildPlayerData(playerDocument(true), NOW);
  assert.deepEqual(finished.TutorialData, { S: "{}" });

  const corrupt = playerDocument(false);
  corrupt.progression!.tutorialFinished = "true" as unknown as boolean;
  assert.throws(() => buildPlayerData(corrupt, NOW), /Stored tutorial completion state is invalid/);

  const futureReceipt = playerDocument(false);
  futureReceipt.progression!.tutorialBattle = { battleId: BATTLE_ID, startedAt: NOW + 1 };
  assert.throws(() => buildPlayerData(futureReceipt, NOW), /Stored tutorial battle is invalid/);
  assert.equal(tutorialHandlers[DbAction.GameStartedTutorial]?.requiresAuth, true);
  assert.equal(tutorialHandlers[DbAction.TutorialEnded]?.requiresAuth, true);
});
