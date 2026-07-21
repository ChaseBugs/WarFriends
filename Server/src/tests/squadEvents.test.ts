import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import type { PlayerDocument, SquadEventProgressDocument } from "../db";
import { newPlayer } from "../dtos";
import {
  applyConfirmedPvpSquadEventProgress,
  buildSquadEventDefinition,
  buildSquadEventProgress,
  buildSquadEventTierRewardMessage,
  joinSquadEvent,
  parseSquadEventConfig,
  selectActiveSquadEvent,
  squadEventConfigHash,
  squadEventPlayerLevelProgress,
  validatedSquadEventProgress,
} from "../services/squadEventService";
import { claimableMessageReward, toClientMessage } from "../services/socialService";

const SEASON = {
  id: "season-2026-07",
  startTime: 1_774_000_000,
  endTime: 1_775_000_000,
  tiers: [
    {
      reward: 100,
      assignments: [
        { id: 7, target: 12 },
        { id: 8, target: 3, param: "2.5" },
      ],
    },
    {
      reward: 200,
      assignments: [
        { id: 7, target: 20 },
        { id: 8, target: 5 },
      ],
    },
  ],
};

test("Squad Event configuration is strict and selects a half-open active window", () => {
  const parsed = parseSquadEventConfig({ seasons: [SEASON] });
  assert.equal(selectActiveSquadEvent(parsed, SEASON.startTime)?.id, SEASON.id);
  assert.equal(selectActiveSquadEvent(parsed, SEASON.endTime - 1)?.id, SEASON.id);
  assert.equal(selectActiveSquadEvent(parsed, SEASON.endTime), null);
  assert.notEqual(
    squadEventConfigHash(parsed.seasons[0]),
    squadEventConfigHash({
      ...parsed.seasons[0],
      tiers: [{ ...parsed.seasons[0].tiers[0], reward: 101 }, parsed.seasons[0].tiers[1]],
    }),
  );
  assert.throws(() => parseSquadEventConfig({ seasons: [{ ...SEASON, guessedField: true }] }), /unknown field/);
});

test("Squad Event configuration rejects ambiguous schedules and incompatible tiers", () => {
  assert.throws(
    () => parseSquadEventConfig({ seasons: [SEASON, { ...SEASON, id: "overlap", startTime: SEASON.startTime + 1 }] }),
    /overlap/,
  );
  assert.throws(
    () => parseSquadEventConfig({
      seasons: [{
        ...SEASON,
        tiers: [SEASON.tiers[0], { ...SEASON.tiers[1], assignments: [SEASON.tiers[1].assignments[0]] }],
      }],
    }),
    /same assignment count/,
  );
  assert.throws(
    () => parseSquadEventConfig({
      seasons: [{ ...SEASON, tiers: [{ ...SEASON.tiers[0], reward: -1 }] }],
    }),
    /reward must be an integer/,
  );
  assert.throws(
    () => parseSquadEventConfig({
      seasons: [{ ...SEASON, tiers: [{ ...SEASON.tiers[0], assignments: [{ id: 14, target: 1 }] }] }],
    }),
    /not backed by a server-confirmed gameplay fact/,
  );
});

test("EventDefinition uses the exact flattened stock-client field names", () => {
  assert.deepEqual(buildSquadEventDefinition(SEASON), {
    eventStart: SEASON.startTime,
    eventEnd: SEASON.endTime,
    tierCount: 2,
    assignmentCount: 2,
    T0Reward: 100,
    T0A0Id: 7,
    T0A1Id: 8,
    T1Reward: 200,
    T1A0Id: 7,
    T1A1Id: 8,
  });
});

test("SquadEventProgress uses exact DynamoDB S/N wrappers and zero-based tier keys", () => {
  const now = new Date((SEASON.startTime + 100) * 1_000);
  const progress: SquadEventProgressDocument = {
    squadId: "Alpha",
    eventId: SEASON.id,
    configHash: squadEventConfigHash(SEASON),
    activeTier: 0,
    tiers: [{
      reward: 100,
      assignments: [
        { id: 7, value: Math.fround(1 / 12), target: 12 },
        { id: 8, value: Math.fround(1 / 3), target: 3, param: "2.5" },
      ],
    }, {
      reward: 200,
      assignments: [
        { id: 7, value: 0, target: 20 },
        { id: 8, value: 0, target: 5 },
      ],
    }],
    revision: 1,
    joinedAt: now,
    updatedAt: now,
  };
  assert.deepEqual(buildSquadEventProgress(progress, 0.25, SEASON, now), {
    SquadId: { S: "Alpha" },
    EventId: { S: SEASON.id },
    ActiveTier: { N: "0" },
    LevelProgress: { N: "0.25" },
    T0Reward: { N: "100" },
    T0A0: { N: String(Math.fround(1 / 12)) },
    T0A0Target: { N: "12" },
    T0A1: { N: String(Math.fround(1 / 3)) },
    T0A1Target: { N: "3" },
    T0A1Param: { N: "2.5" },
    T1Reward: { N: "200" },
    T1A0: { N: "0" },
    T1A0Target: { N: "20" },
    T1A1: { N: "0" },
    T1A1Target: { N: "5" },
  });

  const corruptProgress = structuredClone(progress);
  corruptProgress.tiers[0]!.assignments[0]!.value = Number.NaN;
  assert.throws(
    () => buildSquadEventProgress(corruptProgress, 0.25, SEASON, now),
    /does not match its immutable season definition/,
  );
  assert.throws(
    () => buildSquadEventProgress(progress, Number.POSITIVE_INFINITY, SEASON, now),
    /DynamoDB numeric attribute authority is invalid/,
  );
});

test("durable Squad Event authority rejects identity, time, and tier-order corruption", () => {
  const joinedAt = new Date((SEASON.startTime + 100) * 1_000);
  const progress: SquadEventProgressDocument = {
    squadId: "Alpha",
    eventId: SEASON.id,
    configHash: squadEventConfigHash(SEASON),
    activeTier: 1,
    tiers: [{
      reward: 100,
      assignments: [{ id: 7, value: 1, target: 12 }, { id: 8, value: 1, target: 3, param: "2.5" }],
    }, {
      reward: 200,
      assignments: [{ id: 7, value: 0, target: 20 }, { id: 8, value: 0, target: 5 }],
    }],
    revision: 1,
    joinedAt,
    updatedAt: joinedAt,
  };
  assert.equal(validatedSquadEventProgress(progress, SEASON, joinedAt), progress);
  assert.throws(
    () => validatedSquadEventProgress({ ...progress, eventId: "another-event" }, SEASON, joinedAt),
    /identity is invalid/,
  );
  assert.throws(
    () => validatedSquadEventProgress({ ...progress, updatedAt: new Date(SEASON.endTime * 1_000) }, SEASON),
    /does not match its immutable season definition/,
  );
  const skipped = structuredClone(progress);
  skipped.tiers[0].assignments[0].value = 0;
  assert.throws(
    () => validatedSquadEventProgress(skipped, SEASON, joinedAt),
    /does not match its immutable season definition/,
  );
  assert.throws(
    () => validatedSquadEventProgress({ ...progress, revision: Number.MAX_SAFE_INTEGER }, SEASON, joinedAt),
    /does not match its immutable season definition/,
  );
});

test("confirmed PvP facts advance only recovered win and play assignment fractions", () => {
  const now = new Date((SEASON.startTime + 200) * 1_000);
  const initial: SquadEventProgressDocument = {
    squadId: "Alpha",
    eventId: SEASON.id,
    configHash: squadEventConfigHash(SEASON),
    activeTier: 0,
    tiers: [
      {
        reward: 100,
        assignments: [
          { id: 7, value: 0, target: 12 },
          { id: 8, value: 0, target: 3, param: "2.5" },
        ],
      },
      {
        reward: 200,
        assignments: [
          { id: 7, value: 0, target: 20 },
          { id: 8, value: 0, target: 5 },
        ],
      },
    ],
    revision: 0,
    joinedAt: now,
    updatedAt: now,
  };

  const winner = applyConfirmedPvpSquadEventProgress(initial, SEASON, true, now);
  assert.equal(winner.changed, true);
  assert.equal(winner.progress.tiers[0].assignments[0].value, Math.fround(1 / 12));
  assert.equal(winner.progress.tiers[0].assignments[1].value, Math.fround(1 / 3));
  assert.equal(winner.progress.tiers[1].assignments[0].value, 0);
  assert.equal(winner.progress.activeTier, 0);
  assert.equal(winner.progress.revision, 1);
  assert.equal(initial.tiers[0].assignments[0].value, 0);

  const loser = applyConfirmedPvpSquadEventProgress(initial, SEASON, false, now);
  assert.equal(loser.progress.tiers[0].assignments[0].value, 0);
  assert.equal(loser.progress.tiers[0].assignments[1].value, Math.fround(1 / 3));

  const damaged = structuredClone(initial);
  damaged.tiers[0].assignments[0].value = Number.NaN;
  assert.throws(
    () => applyConfirmedPvpSquadEventProgress(damaged, SEASON, true, now),
    /does not match its immutable season definition/,
  );
  assert.throws(
    () => applyConfirmedPvpSquadEventProgress(
      { ...initial, configHash: "retired-live-definition" },
      SEASON,
      true,
      now,
    ),
    /definition changed after progress was created/,
  );
});

test("completing a tier advances ActiveTier and creates the exact claimable type-11 Gold message", () => {
  const now = new Date((SEASON.startTime + 300) * 1_000);
  const season = {
    id: "one-tier",
    startTime: SEASON.startTime,
    endTime: SEASON.endTime,
    tiers: [{
      reward: 125,
      assignments: [{ id: 7, target: 1 }, { id: 8, target: 1 }],
    }],
  };
  const initial: SquadEventProgressDocument = {
    squadId: "Alpha",
    eventId: season.id,
    configHash: squadEventConfigHash(season),
    activeTier: 0,
    tiers: [{
      reward: 125,
      assignments: [{ id: 7, value: 0, target: 1 }, { id: 8, value: 0, target: 1 }],
    }],
    revision: 0,
    joinedAt: now,
    updatedAt: now,
  };
  const completed = applyConfirmedPvpSquadEventProgress(initial, season, true, now);
  assert.equal(completed.progress.activeTier, 1);
  assert.deepEqual(completed.completedTier, { tierIndex: 0, reward: 125 });
  assert.equal(applyConfirmedPvpSquadEventProgress(completed.progress, season, true, now).changed, false);

  const message = buildSquadEventTierRewardMessage("member-1", "Alpha", season.id, 0, 125, now);
  assert.equal(message.messageType, 11);
  assert.deepEqual(claimableMessageReward(message), { Gold: 125, Warbucks: 0 });
  assert.deepEqual(toClientMessage(message), {
    MessageId: { S: "squad-event-tier:one-tier:Alpha:0:member-1" },
    PlayerId: { S: "member-1" },
    MessageType: { N: "11" },
    Tier: { N: "0" },
    SquadId: { S: "Alpha" },
    Reward: { N: "125" },
  });
});

test("LevelProgress reproduces the viewer-specific LevelManager float calculation", () => {
  assert.equal(squadEventPlayerLevelProgress(0), Math.fround(1 / 58));
  assert.equal(squadEventPlayerLevelProgress(57), 1);
  assert.throws(() => squadEventPlayerLevelProgress(58), /level index 58 is invalid/);
});

test("JoinSquadEvent fails with the recovered no-active-event code before storage access", async () => {
  const player = newPlayer("event-player", "EventPlayer", AccountType.Guest);
  const document: PlayerDocument = {
    id: player.id,
    accountName: player.accountName,
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    createdAt: new Date(),
    updatedAt: new Date(),
  };
  await assert.rejects(
    () => joinSquadEvent(document),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NoActiveEvent,
  );
  assert.equal(ApiErrorCode.NoActiveEvent, 11302);
});
