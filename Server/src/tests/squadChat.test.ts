import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType, SquadRank } from "../constants";
import type { PlayerDocument, SquadChatMessageDocument, SquadDocument } from "../db";
import { newPlayer, newSquad } from "../dtos";
import { createInitialProgression } from "../services/playerStateService";
import {
  normalizeSquadChatSend,
  resolveSquadChatMembership,
  toSquadChatWireMessage,
} from "../services/squadChatService";

const NOW = Date.UTC(2026, 6, 20, 4, 30, 12);

function memberDocuments(): { player: PlayerDocument; squad: SquadDocument } {
  const snapshot = newPlayer("member-1", "Honest Member", AccountType.Guest);
  snapshot.level = 19;
  snapshot.squadName = "Alpha Squad";
  snapshot.squadRank = SquadRank.Veteran;
  const player: PlayerDocument = {
    id: snapshot.id,
    accountName: snapshot.accountName,
    authToken: "token",
    accountType: snapshot.accountType,
    leagueTier: snapshot.leagueTier,
    armyPower: snapshot.armyPower,
    experience: snapshot.experience,
    squadPoints: snapshot.squadPoints,
    squadName: snapshot.squadName,
    player: snapshot,
    progression: createInitialProgression(NOW / 1_000),
    createdAt: new Date(NOW),
    updatedAt: new Date(NOW),
  };
  const squad: SquadDocument = {
    ...newSquad("Alpha Squad", "leader-1"),
    members: [{
      playerId: player.id,
      name: snapshot.accountName,
      rank: SquadRank.Veteran,
      squadPoints: 0,
      joinedAt: NOW / 1_000,
      lastSeenChatTimestamp: 0,
    }],
    createdAt: new Date(NOW),
    updatedAt: new Date(NOW),
  };
  return { player, squad };
}

test("squad chat accepts a bounded sender nonce and moderated single-line text", () => {
  assert.deepEqual(
    normalizeSquadChatSend({ clientMessageId: "  retry:42  ", text: "  Ready for battle!  " }, 32),
    { clientMessageId: "retry:42", text: "Ready for battle!" },
  );

  for (const input of [
    { clientMessageId: "", text: "hello" },
    { clientMessageId: "contains space", text: "hello" },
    { clientMessageId: "valid", text: "" },
    { clientMessageId: "valid", text: "line one\nline two" },
    { clientMessageId: "valid", text: "x".repeat(33) },
    { clientMessageId: "valid", text: "f.u.c.k" },
  ]) {
    assert.throws(
      () => normalizeSquadChatSend(input, 32),
      (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
    );
  }
});

test("squad chat membership requires matching player mirrors, roster, and rank", () => {
  const { player, squad } = memberDocuments();
  assert.equal(resolveSquadChatMembership(player, squad).rank, SquadRank.Veteran);

  assert.throws(
    () => resolveSquadChatMembership({ ...player, squadName: "Other Squad" }, squad),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotSquadMember,
  );
  assert.throws(
    () => resolveSquadChatMembership(player, { ...squad, members: [] }),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotSquadMember,
  );
  assert.throws(
    () => resolveSquadChatMembership(player, {
      ...squad,
      members: squad.members.map((member) => ({ ...member, rank: SquadRank.Member })),
    }),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotSquadMember,
  );
});

test("squad chat wire output contains server-owned display metadata and Unix time", () => {
  const document: SquadChatMessageDocument = {
    messageId: "server-message-1",
    idempotencyKey: "member-1:retry-1",
    clientMessageId: "retry-1",
    squadId: "Alpha Squad",
    senderId: "member-1",
    senderName: "Honest Member",
    senderLevel: 19,
    senderLeague: -2,
    senderSquadRank: SquadRank.Veteran,
    text: "Ready for battle!",
    createdAt: new Date(NOW),
    expiresAt: new Date(NOW + 86_400_000),
  };

  assert.deepEqual(toSquadChatWireMessage(document), {
    MessageId: "server-message-1",
    SquadId: "Alpha Squad",
    SenderId: "member-1",
    SenderName: "Honest Member",
    SenderLevel: 19,
    SenderLeague: -2,
    SenderSquadRank: SquadRank.Veteran,
    Text: "Ready for battle!",
    Timestamp: NOW / 1_000,
  });
});
