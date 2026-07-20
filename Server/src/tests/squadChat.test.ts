import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType, SquadRank } from "../constants";
import type { PlayerDocument, SquadChatMessageDocument, SquadDocument } from "../db";
import { newPlayer, newSquad } from "../dtos";
import { createInitialProgression } from "../services/playerStateService";
import {
  buildSquadChatFanoutNotice,
  createSquadChatHistoryCursor,
  normalizeSquadChatSend,
  parseSquadChatFanoutNotice,
  parseSquadChatHistoryCursor,
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

test("cross-node Squad Chat notices carry UUID identity but no trusted content", () => {
  const originId = "1d7bb8b2-e3eb-4d6a-8f13-3758fe109d20";
  const messageId = "dff18ca4-1677-421c-bec4-62fcd96ea10d";
  const serialized = buildSquadChatFanoutNotice(originId, messageId);

  assert.deepEqual(JSON.parse(serialized), { originId, messageId });
  assert.deepEqual(parseSquadChatFanoutNotice(serialized), { originId, messageId });
  assert.equal("text" in JSON.parse(serialized), false);
  assert.equal(parseSquadChatFanoutNotice("not-json"), null);
  assert.equal(parseSquadChatFanoutNotice(JSON.stringify({ originId, messageId: "../../message" })), null);
  assert.throws(() => buildSquadChatFanoutNotice("invalid", messageId));
});

test("Squad Chat history cursor preserves millisecond and UUID tie-break position", () => {
  const messageId = "dff18ca4-1677-421c-bec4-62fcd96ea10d";
  const cursor = createSquadChatHistoryCursor({ createdAt: new Date(NOW + 321), messageId });

  assert.deepEqual(parseSquadChatHistoryCursor(cursor), { v: 1, t: NOW + 321, id: messageId });
  assert.equal(parseSquadChatHistoryCursor(""), null);
  assert.equal(parseSquadChatHistoryCursor("not+base64"), null);
  const unsupported = Buffer.from(JSON.stringify({ v: 2, t: NOW, id: messageId })).toString("base64url");
  assert.equal(parseSquadChatHistoryCursor(unsupported), null);
  const invalidId = Buffer.from(JSON.stringify({ v: 1, t: NOW, id: "not-a-uuid" })).toString("base64url");
  assert.equal(parseSquadChatHistoryCursor(invalidId), null);
});
