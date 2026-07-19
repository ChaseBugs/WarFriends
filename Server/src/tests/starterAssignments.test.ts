import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import { processAssignmentBufferState } from "../services/assignmentService";
import { dailyMissionsStateFor } from "../services/dailyMissionService";
import { createInitialProgression } from "../services/playerStateService";
import {
  STARTER_ASSIGNMENT_DEFINITIONS,
  claimStarterAssignmentState,
  completeStarterAssignmentsState,
} from "../services/starterAssignmentService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;
const FACTS = { medalsBalance: 35, level: 6, squadPointsTotal: 3 };

test("starter assignment table preserves recovered thresholds, rewards, and display order", () => {
  assert.deepEqual(
    STARTER_ASSIGNMENT_DEFINITIONS.map((item) => [
      item.id,
      item.target,
      item.gold,
      item.warBucks,
      item.order,
    ]),
    [
      ["ID_1", 1, 2, 0, 1],
      ["ID_2", 3, 6, 0, 10],
      ["ID_3", -1, 3, 0, 3],
      ["ID_4", 35, 0, 2_000, 2],
      ["ID_5", 5, 4, 0, 5],
      ["ID_6", 1, 0, 4_000, 6],
      ["ID_7", 3, 0, 3_000, 4],
      ["ID_8", -1, 0, 5_000, 9],
      ["ID_9", 6, 5, 0, 8],
      ["ID_10", 3, 0, 6_000, 7],
    ],
  );
});

test("starter completion accepts server-owned facts and rejects unrecovered client-only facts", () => {
  const initial = createInitialProgression(NOW);
  initial.achievements = {
    data: [{ id: 2, offset: 0, value: 1, progress: [{ claimed: false }] }],
  };
  initial.dailyMissions = {
    ...dailyMissionsStateFor(initial, NOW, FACTS.level),
    heroicPoints: 1,
  };
  const completed = completeStarterAssignmentsState(
    initial,
    NOW + 10,
    NOW,
    FACTS,
    ["ID_1", "ID_4", "ID_5", "ID_6", "ID_9", "ID_10"],
  );
  assert.equal(completed.starterAssignments.assignments.ID_1.completed, true);
  assert.equal(completed.starterAssignments.assignments.ID_10.completed, true);
  assert.equal(completed.starterAssignments.assignments.ID_6.completed, true);

  assert.throws(
    () => completeStarterAssignmentsState(completed.state, NOW + 20, NOW, FACTS, ["ID_3"]),
    (error: unknown) => (error as { code?: number }).code === 18501,
  );
});

test("weapon-upgrade starter assignment uses the equipped secondary weapon level", () => {
  const initial = createInitialProgression(NOW);
  const sniper = initial.itemInventory!.levelManagerData.savedWeapons["Google2u.SniperRifle_M24"]!;

  // StarterAssignmentUpgradeWeapon reads weaponLevel, which is boughtIndex + 1. An index of
  // one is therefore level two and must not satisfy the recovered target of three.
  sniper.boughtIndex = 1;
  assert.throws(
    () => completeStarterAssignmentsState(initial, NOW + 10, NOW, FACTS, ["ID_7"]),
    (error: unknown) => (error as { code?: number }).code === 18501,
  );

  sniper.boughtIndex = 2;
  const completed = completeStarterAssignmentsState(initial, NOW + 20, NOW, FACTS, ["ID_7"]);
  assert.equal(completed.starterAssignments.assignments.ID_7.completed, true);
});

test("starter claims enforce order and server balancing before crediting currency", () => {
  const initial = createInitialProgression(NOW);
  initial.achievements = {
    data: [{ id: 2, offset: 0, value: 1, progress: [{ claimed: false }] }],
  };
  const completed = completeStarterAssignmentsState(
    initial,
    NOW + 10,
    NOW,
    FACTS,
    ["ID_1", "ID_4"],
  );

  assert.throws(
    () => claimStarterAssignmentState(completed.state, NOW + 20, "ID_4", 0, 2_000),
    (error: unknown) => (error as { code?: number }).code === 18501,
  );
  assert.throws(
    () => claimStarterAssignmentState(completed.state, NOW + 20, "ID_1", 999, 0),
    (error: unknown) => (error as { code?: number }).code === 18502,
  );

  const first = claimStarterAssignmentState(completed.state, NOW + 20, "ID_1", 2, 0);
  const second = claimStarterAssignmentState(first.state, NOW + 30, "ID_4", 0, 2_000);
  assert.equal(second.state.gold, initial.gold + 2);
  assert.equal(second.state.warBucks, initial.warBucks + 2_000);
});

test("starter RequestBuffer replay returns the cached result without granting twice", () => {
  const initial = createInitialProgression(NOW);
  initial.achievements = {
    data: [{ id: 2, offset: 0, value: 1, progress: [{ claimed: false }] }],
  };
  const completed = completeStarterAssignmentsState(initial, NOW + 10, NOW, FACTS, ["ID_1"]);
  const requests = [{
    action: DbAction.ClaimStarterAssignment,
    data: JSON.stringify({ AssignmentId: "ID_1", Gold: 2, WarBucks: 0 }),
  }];

  const first = processAssignmentBufferState(completed.state, NOW + 20, "starter-buffer", requests);
  const replay = processAssignmentBufferState(first.state, NOW + 30, "starter-buffer", requests);
  assert.equal(first.state.gold, completed.state.gold + 2);
  assert.equal(replay.state.gold, first.state.gold);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.replayed, true);
});
