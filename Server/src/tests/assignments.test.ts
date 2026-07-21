import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import { bufferedRequests, requestedAssignmentInteger } from "../handlers/assignments";
import {
  assignmentStateFor,
  claimAssignmentState,
  claimAssignmentMegaRewardState,
  ensureAssignmentsState,
  processAssignmentBufferState,
  recordPvpAssignmentProgressState,
  serializeAssignmentData,
} from "../services/assignmentService";
import { createInitialProgression } from "../services/playerStateService";
import {
  validatedRequestBufferAuthority,
  validatedRequestBufferId,
} from "../services/requestBufferAuthorityService";
import { validatedAssignmentState } from "../services/assignmentAuthorityService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;

test("assignment requests require canonical integers and contiguous RequestBuffer keys", () => {
  assert.equal(requestedAssignmentInteger(0, "Count"), 0);
  assert.equal(requestedAssignmentInteger("0", "Count"), 0);
  assert.equal(requestedAssignmentInteger("2147483647", "Count"), 2_147_483_647);
  for (const value of [undefined, null, false, true, [], [1], "", " 1", "1 ", "+1", "01", "1.0", "1e0", -1, "2147483648"]) {
    assert.throws(() => requestedAssignmentInteger(value, "Count"), /exact nonnegative C# integer/);
  }

  assert.deepEqual(bufferedRequests(JSON.stringify({
    1: { action: DbAction.ClaimAssignmentMegaReward, data: "" },
    0: { action: DbAction.ClaimAssignment, data: "{}" },
  })), [
    { action: DbAction.ClaimAssignment, data: "{}" },
    { action: DbAction.ClaimAssignmentMegaReward, data: "" },
  ]);
  for (const payload of [
    { x: { action: 171, data: "{}" } },
    { "00": { action: 171, data: "{}" } },
    { 1: { action: 171, data: "{}" } },
    { 0: { action: 171, data: "{}" }, 2: { action: 172, data: "" } },
  ]) {
    assert.throws(() => bufferedRequests(JSON.stringify(payload)), /sequence is invalid/);
  }
});

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

test("GetNewAssignments writes only when its UTC cycle changes", () => {
  const initial = createInitialProgression(NOW);
  const created = ensureAssignmentsState(initial, NOW);
  assert.notEqual(created.state, initial);

  const sameDay = ensureAssignmentsState(created.state, NOW + 60);
  assert.equal(sameDay.state, created.state);

  const nextDay = ensureAssignmentsState(created.state, Date.UTC(2026, 6, 20, 0, 0, 1) / 1_000);
  assert.notEqual(nextDay.state, created.state);
  assert.equal(nextDay.state.revision, created.state.revision + 1);
  assert.equal(nextDay.assignments.dayKey, "2026-07-20");
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

test("RequestBuffer durable authority rejects ambiguous replay and outbox snapshots", () => {
  const initial = createInitialProgression(NOW);
  const first = processAssignmentBufferState(initial, NOW, "buffer-authority", []);
  assert.equal(validatedRequestBufferAuthority(first.state).processedRequestBuffers.length, 1);
  assert.throws(() => validatedRequestBufferId("buffer\nreplay"), /BufferId is invalid/);
  assert.throws(
    () => processAssignmentBufferState(initial, Number.NaN, "buffer-time", []),
    /Assignment request time is invalid/,
  );

  const entry = first.state.processedRequestBuffers![0]!;
  for (const corrupt of [
    { ...initial, processedRequestBuffers: [entry, { ...entry }] },
    { ...initial, processedRequestBuffers: [{ ...entry, result: "not-json" }] },
    { ...initial, processedRequestBuffers: [{ ...entry, processedAt: Number.POSITIVE_INFINITY }] },
    { ...initial, pendingMessageIgnores: ["message-1", "message-1"] },
    { ...initial, pendingMessageIgnores: ["message\n1"] },
  ]) {
    assert.throws(() => validatedRequestBufferAuthority(corrupt), /Stored (RequestBuffer|message-ignore)/);
  }
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

test("assignment claims reject corrupt counters before consuming a reward marker", () => {
  const initial = createInitialProgression(NOW);
  const assignments = assignmentStateFor(initial, NOW);
  assignments.assignments[0]!.done = true;

  const corrupt = {
    ...initial,
    assignments: { ...assignments, completed: Number.NaN },
  };
  assert.throws(
    () => claimAssignmentState(corrupt, NOW + 60, assignments.assignments[0]!.id, 2),
    /completion count is invalid/,
  );
  assert.equal(assignments.assignments[0]!.claimed, false);
});

test("mega claims and UTC rollover reject a non-integer carried mega cursor", () => {
  const initial = createInitialProgression(NOW);
  const assignments = assignmentStateFor(initial, NOW);
  const corrupt = {
    ...initial,
    assignments: { ...assignments, megaReward: Number.NaN },
  };

  assert.throws(
    () => claimAssignmentMegaRewardState(corrupt, NOW + 60),
    /mega reward is invalid/,
  );
  assert.throws(
    () => assignmentStateFor(corrupt, assignments.tomorrow + 1),
    /mega reward is invalid/,
  );
});

test("daily assignment UTC cycles reject permanent or internally inconsistent reset authority", () => {
  const initial = createInitialProgression(NOW);
  const assignments = assignmentStateFor(initial, NOW);
  const corruptReset = {
    ...initial,
    assignments: { ...assignments, tomorrow: Number.POSITIVE_INFINITY },
  };

  // A raw `tomorrow > now` check would keep this day's objectives active forever. The same
  // boundary protects gameplay transitions and direct response serialization.
  assert.throws(
    () => assignmentStateFor(corruptReset, NOW + 60),
    /Stored assignment reset time is invalid/,
  );
  assert.throws(
    () => serializeAssignmentData(corruptReset.assignments),
    /Stored assignment reset time is invalid/,
  );
  assert.throws(
    () => assignmentStateFor({
      ...initial,
      assignments: { ...assignments, dayKey: "2026-07-18" },
    }, NOW + 60),
    /Stored assignment UTC cycle is inconsistent/,
  );
});

test("shared progression publication rejects forged daily-assignment definitions and completion flags", () => {
  const current = createInitialProgression(NOW);
  const assignments = assignmentStateFor(current, NOW);
  assignments.assignments[0]!.target = 1;
  assert.throws(
    () => validatedAssignmentState(assignments),
    /Stored assignment 0 definition is invalid/,
  );
  assert.throws(
    () => validatedProgressionSuccessor(current, {
      ...current,
      revision: 1,
      assignments,
    }),
    /Stored assignment 0 definition is invalid/,
  );

  const inconsistent = assignmentStateFor(current, NOW);
  inconsistent.assignments[1]!.claimed = true;
  assert.throws(
    () => validatedAssignmentState(inconsistent),
    /completion authority is inconsistent/,
  );
});
