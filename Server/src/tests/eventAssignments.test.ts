import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  buildEventAssignmentClientConfig,
  claimEventAssignmentState,
  claimEventMilestoneState,
  ensureEventAssignmentState,
  eventAssignmentConfigHash,
  eventAssignmentDayIndex,
  parseEventAssignmentsConfig,
  recordConfirmedEventAssignmentProgressState,
  selectActiveEventAssignment,
  type EventAssignmentEventConfig,
} from "../services/eventAssignmentService";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import { validatedEventAssignmentState } from "../services/eventAssignmentAuthorityService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";

const START = 1_728_000_000; // Exact UTC-midnight Unix boundary.
const EVENT: EventAssignmentEventConfig = {
  id: "winter-verified-test",
  startTime: START,
  endTime: START + 2 * 86_400,
  eventName: "Winter Assignment",
  milestones: [{
    target: 10,
    reward: { type: 8, amount: 1, param: "HELMETS_CAKEHAT" },
  }],
  assignments: [
    { type: "xmas", target: 3, progress: 10, reward: { type: 1, amount: 5 } },
    { type: "xmas", target: 4, progress: 20, reward: { type: 0, amount: 100 } },
  ],
};

function document(progression = createInitialProgression(START)): PlayerDocument {
  const player = newPlayer("event-player", "EventPlayer", AccountType.Guest);
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
    progression,
    createdAt: new Date(START * 1_000),
    updatedAt: new Date(START * 1_000),
  };
}

test("Event Assignment config is strict, non-overlapping, and maps one row per UTC day", () => {
  const parsed = parseEventAssignmentsConfig({ events: [EVENT] });
  assert.equal(selectActiveEventAssignment(parsed, START)?.id, EVENT.id);
  assert.equal(selectActiveEventAssignment(parsed, EVENT.endTime), null);
  assert.equal(eventAssignmentDayIndex(EVENT, START + 123), 0);
  assert.equal(eventAssignmentDayIndex(EVENT, START + 86_400 + 123), 1);
  assert.notEqual(eventAssignmentConfigHash(EVENT), eventAssignmentConfigHash({ ...EVENT, eventName: "Changed" }));

  assert.throws(
    () => parseEventAssignmentsConfig({ events: [{ ...EVENT, unknown: true }] }),
    /unknown field/,
  );
  assert.throws(
    () => parseEventAssignmentsConfig({ events: [{ ...EVENT, assignments: [EVENT.assignments[0]] }] }),
    /exactly one entry per event day/,
  );
  assert.throws(
    () => parseEventAssignmentsConfig({ events: [EVENT, { ...EVENT, id: "overlap", startTime: START + 86_400 }] }),
    /overlap/,
  );
  assert.throws(
    () => parseEventAssignmentsConfig({
      events: [{ ...EVENT, milestones: [{ target: 10, reward: { type: 1, amount: 5 } }] }],
    }),
    /must be 8/,
  );
  assert.throws(
    () => parseEventAssignmentsConfig({
      events: [{
        ...EVENT,
        milestones: [{ target: 10, reward: { type: 8, amount: 1, param: "HEAD_CLOWN" } }],
      }],
    }),
    /source event\/assignment visual/,
  );
});

test("client config and PlayerData use the recovered nested wire names without private hash", () => {
  const config = JSON.parse(buildEventAssignmentClientConfig(EVENT)) as Record<string, any>;
  assert.equal(config.startTime, START);
  assert.equal(config.assignments[0].progress, 10);
  assert.deepEqual(config.assignments[0].reward, { type: 1, d: { amount: 5 } });
  assert.deepEqual(config.milestones[0].reward, {
    type: 8,
    d: { amount: 1, param: "HELMETS_CAKEHAT" },
  });

  const initialized = ensureEventAssignmentState(createInitialProgression(START), EVENT);
  const wire = buildPlayerData(document(initialized.state), START + 123);
  assert.deepEqual(wire.Midnight, { N: String(START) });
  const saved = JSON.parse((wire.EventAssignmentData as { S: string }).S);
  assert.deepEqual(saved, {
    eventId: EVENT.id,
    totalValue: 0,
    progress: {},
    milestones: {},
  });
  assert.equal("configHash" in saved, false);
});

test("daily reward claim requires confirmed progress and server-owned reward echoes", () => {
  const initial = ensureEventAssignmentState(createInitialProgression(START), EVENT).state;
  assert.throws(
    () => claimEventAssignmentState(initial, EVENT, START + 100, { rewardType: 1, rewardValue: 5 }),
    /incomplete/,
  );
  const confirmed = recordConfirmedEventAssignmentProgressState(initial, EVENT, START + 100, 3).state;
  assert.throws(
    () => claimEventAssignmentState(confirmed, EVENT, START + 100, { rewardType: 1, rewardValue: 5000 }),
    /does not match/,
  );
  const claimed = claimEventAssignmentState(confirmed, EVENT, START + 100, { rewardType: 1, rewardValue: 5 });
  assert.equal(claimed.state.gold, 5);
  assert.equal(claimed.eventAssignment.totalValue, 10);
  assert.deepEqual(claimed.eventAssignment.progress["0"], { v: 3, c: true });
  assert.throws(
    () => claimEventAssignmentState(claimed.state, EVENT, START + 100, { rewardType: 1, rewardValue: 5 }),
    /already claimed/,
  );
});

test("shared publication rejects malformed event state and active config rejects inconsistent totals", () => {
  const current = createInitialProgression(START);
  const initialized = ensureEventAssignmentState(current, EVENT).eventAssignment;
  const malformed = {
    ...initialized,
    progress: { "00": { v: 1, c: false } },
  };
  assert.throws(() => validatedEventAssignmentState(malformed), /Stored Event Assignment progress is invalid/);
  assert.throws(
    () => validatedProgressionSuccessor(current, {
      ...current,
      revision: 1,
      eventAssignment: malformed,
    }),
    /Stored Event Assignment progress is invalid/,
  );

  const inconsistent = {
    ...initialized,
    totalValue: 0,
    progress: { "0": { v: 3, c: true } },
  };
  assert.throws(
    () => ensureEventAssignmentState({ ...current, eventAssignment: inconsistent }, EVENT),
    /Stored Event Assignment progress is invalid/,
  );
});

test("milestones are ordered, threshold-gated, and grant only the configured event visual", () => {
  const initial = ensureEventAssignmentState(createInitialProgression(START), EVENT).state;
  assert.throws(
    () => claimEventMilestoneState(initial, EVENT, START + 100, { milestoneId: 0, rewardValue: "HELMETS_CAKEHAT" }),
    /incomplete/,
  );
  const confirmed = recordConfirmedEventAssignmentProgressState(initial, EVENT, START + 100, 3).state;
  const daily = claimEventAssignmentState(confirmed, EVENT, START + 100, { rewardType: 1, rewardValue: 5 }).state;
  assert.throws(
    () => claimEventMilestoneState(daily, EVENT, START + 100, { milestoneId: 0, rewardValue: "HELMETS_BACKBONE" }),
    /does not match/,
  );
  const milestone = claimEventMilestoneState(
    daily,
    EVENT,
    START + 100,
    { milestoneId: 0, rewardValue: "HELMETS_CAKEHAT" },
  );
  assert.equal(milestone.eventAssignment.milestones["0"], true);
  assert.equal(milestone.state.visualInventory?.visuals.HELMETS_CAKEHAT?.bought, true);
  assert.throws(
    () => claimEventMilestoneState(
      milestone.state,
      EVENT,
      START + 100,
      { milestoneId: 0, rewardValue: "HELMETS_CAKEHAT" },
    ),
    /already claimed or out of order/,
  );
});

test("RequestBuffer executes actions 222/223 atomically and BufferId replay cannot duplicate rewards", () => {
  const initialized = ensureEventAssignmentState(createInitialProgression(START), EVENT).state;
  const confirmed = recordConfirmedEventAssignmentProgressState(initialized, EVENT, START + 100, 3).state;
  const requests = [
    {
      action: DbAction.ClaimEventAssignment,
      data: JSON.stringify({ RewardType: 1, RewardValue: 5 }),
    },
    {
      action: DbAction.ClaimEventMilestone,
      data: JSON.stringify({ MilestoneId: 0, RewardValue: "HELMETS_CAKEHAT" }),
    },
  ];
  const first = processAssignmentBufferState(confirmed, START + 100, "event-buffer-1", requests, 1, 0, 0, EVENT);
  assert.deepEqual(JSON.parse(first.requestsResults), [
    { ActionId: DbAction.ClaimEventAssignment, Result: 1 },
    { ActionId: DbAction.ClaimEventMilestone, Result: 1 },
  ]);
  assert.equal(first.state.gold, 5);
  assert.equal(first.state.eventAssignment?.totalValue, 10);
  assert.equal(first.state.visualInventory?.visuals.HELMETS_CAKEHAT?.bought, true);

  const replay = processAssignmentBufferState(first.state, START + 101, "event-buffer-1", requests, 1, 0, 0, EVENT);
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.state.gold, 5);
  assert.equal(replay.state.eventAssignment?.totalValue, 10);
});
