import assert from "node:assert/strict";
import test from "node:test";
import {
  buildInboxFanoutNotice,
  liveInboxMessageFor,
  parseInboxFanoutNotice,
  publishInboxFanouts,
  registerLocalInboxDelivery,
} from "../services/inboxFanoutService";
import { buildDirectMessage, type MessageDoc } from "../services/socialService";

const ORIGIN = "15b2c548-6b2b-4e3f-8a34-1bfc6f3352e2";
const NOW = new Date("2026-07-22T00:00:00.000Z");

function direct(overrides: Partial<MessageDoc> = {}): MessageDoc {
  return {
    ...buildDirectMessage("sender", "Sender", "recipient", "hello", NOW, ORIGIN),
    ...overrides,
  };
}

test("inbox fan-out notices contain only bounded routing identities", () => {
  const serialized = buildInboxFanoutNotice(ORIGIN, "recipient", "InGameMessage-id-1784678400");
  assert.deepEqual(parseInboxFanoutNotice(serialized), {
    originId: ORIGIN,
    recipientPlayerId: "recipient",
    messageId: "InGameMessage-id-1784678400",
  });
  assert.equal(parseInboxFanoutNotice(JSON.stringify({
    originId: ORIGIN,
    recipientPlayerId: "recipient",
    messageId: "message",
    body: "must not cross Redis",
  })), null);
  assert.equal(parseInboxFanoutNotice("[]"), null);
  assert.throws(() => buildInboxFanoutNotice("not-a-uuid", "recipient", "message"));
});

test("committed inbox batches are handed to local delivery in source order", async () => {
  const delivered: string[] = [];
  registerLocalInboxDelivery((recipientPlayerId, messageId) => {
    delivered.push(`${recipientPlayerId}:${messageId}`);
  });

  await publishInboxFanouts([
    { recipientPlayerId: "player-a", messageId: "message-a" },
    { recipientPlayerId: "player-b", messageId: "message-b" },
  ]);

  assert.deepEqual(delivered, ["player-a:message-a", "player-b:message-b"]);
});

test("live inbox delivery reuses the exact GetAllMessages wire projection", () => {
  const fanout = liveInboxMessageFor(direct(), "recipient", NOW);
  assert.equal(fanout?.recipientPlayerId, "recipient");
  assert.deepEqual(fanout?.message.MessageType, { N: "27" });
  assert.deepEqual(fanout?.message.Text, { S: "hello" });
  assert.deepEqual(fanout?.message.PlayerId, { S: "recipient" });
});

test("live inbox delivery is recipient-bound and excludes terminal presentation rows", () => {
  assert.equal(liveInboxMessageFor(direct(), "another-player", NOW), null);
  assert.equal(liveInboxMessageFor(direct({ read: true, ignored: true }), "recipient", NOW), null);
  assert.equal(liveInboxMessageFor(direct({ read: true }), "recipient", NOW), null);
});

test("live inbox delivery supports every recovered Squad notification family", () => {
  const createdAt = new Date("2026-07-21T23:59:00.000Z");
  const timestamp = Math.floor(createdAt.getTime() / 1_000);
  const notices: MessageDoc[] = [
    {
      messageId: `SquadDemotion-recipient-${timestamp}`,
      toPlayerId: "recipient",
      fromPlayerId: "leader",
      fromName: "Leader",
      body: "You were removed from your squad.",
      messageType: 3,
      payload: {
        PlayerName: "Recipient",
        Level: 3,
        SquadId: "Safe Squad",
        KickedPlayerId: "recipient",
        SquadKickedFrom: "Safe Squad",
        AdminName: "Leader",
        AdminId: "leader",
        AdminLevel: 4,
        KickedPlayerDepositedCards: "[]",
      },
      otherPlayerJson: "",
      read: false,
      ignored: false,
      accepted: false,
      createdAt,
    },
    {
      messageId: `InformSquadLeader-member-${timestamp}`,
      idempotencyKey: "squad-event:Safe Squad:member:2026-07-21",
      toPlayerId: "recipient",
      fromPlayerId: "member",
      fromName: "Member",
      body: "A squad event is available.",
      messageType: 21,
      payload: {},
      otherPlayerJson: "",
      read: false,
      ignored: false,
      accepted: false,
      createdAt,
    },
    {
      messageId: `DepositWarcards-Leader-${timestamp}`,
      idempotencyKey: "deposit-warcards:Safe Squad:leader:recipient:2026-07-21",
      toPlayerId: "recipient",
      fromPlayerId: "leader",
      fromName: "Leader",
      body: "Please deposit War Cards into the squad card pool.",
      messageType: 28,
      payload: {
        PlayerName: "Leader",
        Level: 4,
        SquadId: "Safe Squad",
        SquadRank: 2,
        AdminPlayerId: "leader",
      },
      otherPlayerJson: "",
      read: false,
      ignored: false,
      accepted: false,
      createdAt,
    },
  ];

  assert.deepEqual(notices.map((notice) =>
    liveInboxMessageFor(notice, "recipient", NOW)?.message.MessageType), [
    { N: "3" },
    { N: "21" },
    { N: "28" },
  ]);
});

test("live reward delivery preserves the unclaimed action-91 payload", () => {
  const createdAt = new Date("2026-07-21T23:59:00.000Z");
  const message: MessageDoc = {
    messageId: "player-league-finished:6-1784678400-local1:recipient-1784678340",
    idempotencyKey: "player-league-finished:6-1784678400-local1:recipient",
    toPlayerId: "recipient",
    fromPlayerId: "system",
    fromName: "Player League",
    body: "",
    messageType: 23,
    payload: {
      LeagueId: 7,
      BeforeLeagueId: 6,
      Medals: 42,
      FormerFullLeagueId: "6-1784678400-local1",
      Position: 2,
      RewardGold: 60,
    },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt,
  };

  const wire = liveInboxMessageFor(message, "recipient", NOW)?.message;
  assert.deepEqual(wire?.MessageType, { N: "23" });
  assert.deepEqual(wire?.RewardGold, { N: "60" });
  assert.equal(message.rewardClaimed, undefined);
});

test("expired challenges are never revived by a delayed Redis notice", () => {
  const challenge: MessageDoc = {
    messageId: "sender-1784678340",
    toPlayerId: "recipient",
    fromPlayerId: "sender",
    fromName: "Sender",
    body: "",
    messageType: 0,
    payload: {
      MapName: "City",
      GameType: 2,
      Region: 0,
      roomName: "room-1",
      clientVersion: "1.6.0",
    },
    otherPlayerJson: "{}",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: new Date("2026-07-21T23:59:00.000Z"),
    expiresAt: NOW,
  };
  assert.equal(liveInboxMessageFor(challenge, "recipient", NOW), null);
});
