import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import {
  assignmentStateFor,
  claimAssignmentState,
  processAssignmentBufferState,
  recordPvpAssignmentProgressState,
} from "../services/assignmentService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;

test("assignment cycle is stable for one UTC day and rolls at midnight", () => {
  const initial = createInitialProgression(NOW);
  const first = assignmentStateFor(initial, NOW);
  const repeated = assignmentStateFor({ ...initial, assignments: first }, NOW + 60);

  assert.equal(first.assignments.length, 3);
  assert.equal(repeated.issued, first.issued);
  assert.equal(repeated.tomorrow, Date.UTC(2026, 6, 20) / 1_000);

  const nextDay = assignmentStateFor(
    { ...initial, assignments: { ...first, megaReward: 17 } },
    Date.UTC(2026, 6, 20, 0, 0, 1) / 1_000,
  );
  assert.equal(nextDay.completed, 0);
  assert.equal(nextDay.megaReward, 17);
  assert.notEqual(nextDay.dayKey, first.dayKey);
});

test("only server-confirmed PvP facts advance assignment objectives", () => {
  let state = createInitialProgression(NOW);
  state = recordPvpAssignmentProgressState(state, NOW, false).state;

  const afterLoss = state.assignments!;
  assert.equal(afterLoss.assignments.find((item) => item.id === 5)?.completeFract, 0.5);
  assert.equal(afterLoss.assignments.find((item) => item.id === 8)?.completeFract, 1 / 6);
  assert.equal(afterLoss.assignments.find((item) => item.id === 7)?.completeFract, 0);

  state = recordPvpAssignmentProgressState(state, NOW + 30, true).state;
  assert.equal(state.assignments!.assignments.find((item) => item.id === 5)?.done, true);
  assert.equal(state.assignments!.assignments.find((item) => item.id === 7)?.completeFract, 1 / 3);
});

test("buffer replay returns the original assignment result without granting Gold twice", () => {
  let state = createInitialProgression(NOW);
  state = recordPvpAssignmentProgressState(state, NOW, false).state;
  state = recordPvpAssignmentProgressState(state, NOW + 30, false).state;

  const request = [{
    action: DbAction.ClaimAssignment,
    data: JSON.stringify({ AssignmentId: 5, Reward: 2 }),
  }];
  const first = processAssignmentBufferState(state, NOW + 60, "buffer-1", request);
  const replay = processAssignmentBufferState(first.state, NOW + 90, "buffer-1", request);

  assert.equal(first.state.gold, state.gold + 2);
  assert.equal(first.assignments.assignments.find((item) => item.id === 5)?.claimed, true);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state, first.state, "BufferId replay must not advance progression revision");
  assert.equal(replay.state.gold, first.state.gold);
  assert.equal(replay.requestsResults, first.requestsResults);
});

test("BufferId replay after UTC midnight does not roll unrelated assignments", () => {
  const beforeMidnight = Date.UTC(2026, 6, 19, 23, 59, 50) / 1_000;
  const first = processAssignmentBufferState(
    createInitialProgression(beforeMidnight),
    beforeMidnight,
    "midnight-buffer",
    [],
  );
  const replay = processAssignmentBufferState(
    first.state,
    beforeMidnight + 20,
    "midnight-buffer",
    [],
  );
  assert.equal(replay.replayed, true);
  assert.equal(replay.state, first.state);
  assert.equal(replay.assignments.dayKey, "2026-07-19");
});

test("assignment claim validates the reward amount supplied by the old client", () => {
  let state = createInitialProgression(NOW);
  state = recordPvpAssignmentProgressState(state, NOW, false).state;
  state = recordPvpAssignmentProgressState(state, NOW + 30, false).state;

  assert.throws(
    () => claimAssignmentState(state, NOW + 60, 5, 999),
    (error: unknown) => (error as { code?: number }).code === 11203,
  );
});
