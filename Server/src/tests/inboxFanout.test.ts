import assert from "node:assert/strict";
import test from "node:test";
import {
  buildInboxFanoutNotice,
  liveInboxMessageFor,
  parseInboxFanoutNotice,
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
