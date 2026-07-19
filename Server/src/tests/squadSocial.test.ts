import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import { DbAction } from "../dbActions";
import type { PlayerDocument, SquadDocument } from "../db";
import { newPlayer, newSquad } from "../dtos";
import { processAssignmentBufferState } from "../services/assignmentService";
import { createInitialProgression, buildPlayerData } from "../services/playerStateService";
import {
  advanceSquadChatCursorState,
  buildSquadEventMessage,
} from "../services/squadSocialService";
import { toClientMessage } from "../services/socialService";

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
  assert.throws(
    () => advanceSquadChatCursorState(rollback.state, NOW, NOW + 301),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
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
});

test("GetPlayerData restores the cursor through the recovered PlayerAnalyticsData key", () => {
  const player = playerDocument("cursor-player");
  player.progression!.lastSeenSquadChatTimestamp = NOW - 5;
  const wire = buildPlayerData(player);
  const analytics = JSON.parse((wire.PlayerAnalyticsData as { S: string }).S) as Record<string, number>;

  assert.equal(analytics.lastSeenSquadChatTimeStampDB, NOW - 5);
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
  assert.deepEqual(wire.PlayerId, { S: actor.id });
});
