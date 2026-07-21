import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import { DbAction } from "../dbActions";
import type { PlayerDocument, SquadDocument } from "../db";
import { newPlayer, newSquad } from "../dtos";
import { processAssignmentBufferState } from "../services/assignmentService";
import {
  createInitialProgression,
  buildPlayerData,
  progressionForPlayer,
} from "../services/playerStateService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";
import {
  advanceSquadChatCursorState,
  buildDepositWarcardsMessage,
  buildSquadEventMessage,
} from "../services/squadSocialService";
import { buildSquadKickMessage, toClientMessage } from "../services/socialService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;

function playerDocument(id: string): PlayerDocument {
  const player = newPlayer(id, `Player-${id}`, AccountType.Guest);
  return {
    id,
    accountName: player.accountName,
    authToken: "token",
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: "Test Squad",
    player: { ...player, squadName: "Test Squad" },
    progression: createInitialProgression(NOW),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

test("squad chat cursor is monotonic and rejects destructive future values", () => {
  const initial = createInitialProgression(NOW);
  const first = advanceSquadChatCursorState(initial, NOW, NOW - 20);
  const rollback = advanceSquadChatCursorState(first.state, NOW, NOW - 40);

  assert.equal(first.timestamp, NOW - 20);
  assert.equal(rollback.timestamp, NOW - 20);
  assert.equal(rollback.state, first.state, "stale cursor must not advance progression revision");
  const equal = advanceSquadChatCursorState(first.state, NOW, NOW - 20);
  assert.equal(equal.state, first.state, "equal cursor must not advance progression revision");
  assert.throws(
    () => advanceSquadChatCursorState(rollback.state, NOW, NOW + 301),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
  );
  assert.throws(
    () => advanceSquadChatCursorState(rollback.state, NOW, 2_147_483_648),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
  );
  assert.throws(
    () => advanceSquadChatCursorState(rollback.state, NOW, Number.NaN),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
  );
});

test("squad chat cursor rejects corrupt durable authority before comparison or revision", () => {
  const corrupt = createInitialProgression(NOW);
  corrupt.lastSeenSquadChatTimestamp = Number.POSITIVE_INFINITY;
  assert.throws(
    () => advanceSquadChatCursorState(corrupt, NOW, NOW - 30),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.InternalServerError,
  );

  const exhaustedRevision = createInitialProgression(NOW);
  exhaustedRevision.revision = Number.MAX_SAFE_INTEGER;
  assert.throws(
    () => advanceSquadChatCursorState(exhaustedRevision, NOW, NOW - 30),
    /Squad chat cursor progression revision is invalid/,
  );
});

test("stock RequestBuffer persists and idempotently replays squad chat cursor action 193", () => {
  const initial = createInitialProgression(NOW);
  const request = [{ action: DbAction.SaveLastSeenSquadChatTimeStamp, data: String(NOW - 10) }];
  const first = processAssignmentBufferState(initial, NOW, "cursor-buffer", request);
  const replay = processAssignmentBufferState(first.state, NOW + 1, "cursor-buffer", [
    { action: DbAction.SaveLastSeenSquadChatTimeStamp, data: String(NOW) },
  ]);

  assert.equal(first.state.lastSeenSquadChatTimestamp, NOW - 10);
  assert.deepEqual(JSON.parse(first.requestsResults), [{ ActionId: 193, Result: 1 }]);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.lastSeenSquadChatTimestamp, NOW - 10);
  assert.equal(replay.requestsResults, first.requestsResults);

  const malformed = processAssignmentBufferState(initial, NOW, "cursor-empty", [
    { action: DbAction.SaveLastSeenSquadChatTimeStamp, data: "" },
  ]);
  assert.equal(malformed.state.lastSeenSquadChatTimestamp, undefined);
  assert.deepEqual(JSON.parse(malformed.requestsResults), [
    { ActionId: 193, Result: ApiErrorCode.UnknownAction },
  ]);
});

test("GetPlayerData restores squad analytics through the recovered PlayerAnalyticsData key", () => {
  const player = playerDocument("cursor-player");
  player.progression!.lastSeenSquadChatTimestamp = NOW - 5;
  player.progression!.squadCreationsCount = 3;
  const wire = buildPlayerData(player);
  const analytics = JSON.parse((wire.PlayerAnalyticsData as { S: string }).S) as Record<string, number>;

  assert.equal(analytics.lastSeenSquadChatTimeStampDB, NOW - 5);
  assert.equal(analytics.squadCreationsCount, 3);

  player.progression!.lastSeenSquadChatTimestamp = Number.POSITIVE_INFINITY;
  assert.throws(() => buildPlayerData(player, NOW), /Stored squad chat cursor is invalid/);
  player.progression!.lastSeenSquadChatTimestamp = NOW - 5;

  player.progression!.squadCreationsCount = Number.POSITIVE_INFINITY;
  assert.throws(() => buildPlayerData(player), /Stored squad creation count is invalid/);
});

test("shared progression boundaries validate the squad creation price counter", () => {
  const corruptRead = playerDocument("corrupt-creation-read");
  corruptRead.progression!.squadCreationsCount = Number.POSITIVE_INFINITY;
  assert.throws(
    () => progressionForPlayer(corruptRead),
    /Stored squad creation count is invalid/,
  );

  const current = createInitialProgression(NOW);
  assert.throws(
    () => validatedProgressionSuccessor(current, {
      ...current,
      revision: 1,
      squadCreationsCount: Number.MAX_SAFE_INTEGER,
    }),
    /Stored squad creation count is invalid/,
  );

  // Missing legacy history is the first-squad state and materializes as zero on every read.
  assert.equal(progressionForPlayer(playerDocument("legacy-creation-read")).squadCreationsCount, 0);
});

test("shared progression boundaries reject a corrupt or far-future squad chat cursor", () => {
  const corruptRead = playerDocument("corrupt-chat-cursor-read");
  corruptRead.progression!.lastSeenSquadChatTimestamp = Number.NaN;
  assert.throws(
    () => progressionForPlayer(corruptRead, NOW),
    /Stored squad chat cursor is invalid/,
  );

  const current = createInitialProgression(NOW);
  assert.throws(
    () => validatedProgressionSuccessor(current, {
      ...current,
      revision: 1,
      lastSeenSquadChatTimestamp: NOW + 301,
    }, NOW),
    /Stored squad chat cursor is invalid/,
  );
  assert.equal(progressionForPlayer(playerDocument("legacy-chat-cursor-read"), NOW).lastSeenSquadChatTimestamp, 0);
});

test("squad event notification uses the message type and numeric suffix parsed by Unity", () => {
  const actor = playerDocument("member-1");
  const squad = {
    ...newSquad("Test Squad", "leader-1"),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  } as SquadDocument;
  const message = buildSquadEventMessage(actor, squad, new Date(NOW * 1_000));
  const wire = toClientMessage(message);

  assert.match(message.messageId, new RegExp(`-${NOW}$`));
  assert.deepEqual(wire.MessageType, { N: "21" });
  assert.deepEqual(wire.PlayerId, { S: "leader-1" });
});

test("War Card deposit reminder emits the exact BOAFLMMKCGB player snapshot", () => {
  const actor = playerDocument("member-1");
  actor.player.level = 17;
  const squad = {
    ...newSquad("Test Squad", "leader-1"),
    members: [
      {
        playerId: actor.id,
        name: actor.player.accountName,
        rank: 1,
        squadPoints: 10,
        joinedAt: NOW,
        lastSeenChatTimestamp: 0,
      },
      {
        playerId: "member-2",
        name: "Player-member-2",
        rank: 0,
        squadPoints: 0,
        joinedAt: NOW,
        lastSeenChatTimestamp: 0,
      },
    ],
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  } as SquadDocument;

  const message = buildDepositWarcardsMessage(actor, "member-2", squad, new Date(NOW * 1_000));
  const wire = toClientMessage(message);

  assert.equal(message.toPlayerId, "member-2");
  assert.equal(message.messageId, `DepositWarcards-${actor.player.accountName}-${NOW}`);
  assert.deepEqual(wire, {
    MessageId: { S: message.messageId },
    PlayerId: { S: "member-2" },
    MessageType: { N: "28" },
    PlayerName: { S: actor.player.accountName },
    Level: { N: "17" },
    SquadId: { S: "Test Squad" },
    SquadRank: { N: "1" },
    AdminPlayerId: { S: actor.id },
  });
});

test("War Card deposit reminder refuses to build for an actor outside the roster", () => {
  const actor = playerDocument("outsider");
  const squad = {
    ...newSquad("Test Squad", "leader-1"),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  } as SquadDocument;

  assert.throws(
    () => buildDepositWarcardsMessage(actor, "member-2", squad, new Date(NOW * 1_000)),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotSquadMember,
  );
});

test("offline squad kick message emits the exact MBACFNICJPL recovery contract", () => {
  const actor = playerDocument("leader-1");
  actor.player.accountName = "Squad Leader";
  actor.player.level = 28;
  const target = playerDocument("member-1");
  target.player.accountName = "Removed Member";
  target.player.level = 14;
  const message = buildSquadKickMessage(
    actor,
    target,
    "Test Squad",
    ["AMMOCRATE", "AMMOCRATE", "TROOP_HEAL"],
    new Date(NOW * 1_000),
  );

  assert.equal(message.messageId, `SquadDemotion-${target.id}-${NOW}`);
  assert.deepEqual(toClientMessage(message), {
    MessageId: { S: message.messageId },
    PlayerId: { S: target.id },
    MessageType: { N: "3" },
    PlayerName: { S: "Removed Member" },
    Level: { N: "14" },
    SquadId: { S: "Test Squad" },
    KickedPlayerId: { S: target.id },
    SquadKickedFrom: { S: "Test Squad" },
    AdminName: { S: "Squad Leader" },
    AdminId: { S: actor.id },
    AdminLevel: { N: "28" },
    KickedPlayerDepositedCards: { S: '["AMMOCRATE","AMMOCRATE","TROOP_HEAL"]' },
  });
  assert.equal("SquadRank" in toClientMessage(message), false);
});
