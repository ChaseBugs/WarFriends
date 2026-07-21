import assert from "node:assert/strict";
import test from "node:test";
import type { MessageDoc } from "../services/socialService";
import { buildDirectMessage, toClientMessage } from "../services/socialService";
import { validatedInboxMessageDocument } from "../services/inboxMessageAuthorityService";
import { validatedStandardInboxMessage } from "../services/standardInboxMessageAuthorityService";

const CREATED_AT = new Date("2026-07-21T12:34:56.789Z");
const NOW = new Date("2026-07-21T12:35:00.000Z");
const UUID = "11111111-1111-4111-8111-111111111111";

function direct(values: Partial<MessageDoc> = {}): MessageDoc {
  return {
    messageId: `InGameMessage-${UUID}-1784637296`,
    toPlayerId: "player-b",
    fromPlayerId: "player-a",
    fromName: "Alpha",
    body: "Meet me in battle.",
    messageType: 27,
    payload: {},
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: CREATED_AT,
    ...values,
  };
}

test("type-27 messages keep the numeric suffix required by the recovered Unity parser", () => {
  const message = buildDirectMessage(
    "player-a",
    "Alpha",
    "player-b",
    "Meet me in battle.",
    CREATED_AT,
    UUID,
  );
  assert.equal(message.messageId, `InGameMessage-${UUID}-1784637296`);
  assert.equal(validatedInboxMessageDocument(message, NOW), message);
  assert.deepEqual(toClientMessage(message), {
    MessageId: { S: message.messageId },
    PlayerId: { S: "player-b" },
    MessageType: { N: "27" },
    Title: { S: "Alpha" },
    Text: { S: "Meet me in battle." },
    CreationTime: { N: "1784637296" },
  });
});

test("standard inbox authority rejects legacy UUID IDs and contradictory lifecycle state", () => {
  assert.throws(
    () => validatedStandardInboxMessage(direct({ messageId: UUID }), NOW),
    /standard inbox message/,
  );
  assert.throws(
    () => validatedStandardInboxMessage(direct({ ignored: true, read: false }), NOW),
    /standard inbox message/,
  );
  assert.throws(
    () => validatedStandardInboxMessage(direct({ accepted: true }), NOW),
    /standard inbox message/,
  );
  assert.throws(
    () => validatedStandardInboxMessage(direct({ createdAt: new Date(NOW.getTime() + 1) }), NOW),
    /standard inbox message/,
  );
  assert.throws(
    () => buildDirectMessage("player-a", "Alpha", "player-b", "Late", new Date("2040-01-01T00:00:00Z"), UUID),
    /standard inbox message/,
  );
});

test("standard inbox authority binds every type-specific payload field", () => {
  const kick: MessageDoc = {
    messageId: "SquadDemotion-player-b-1784637296",
    toPlayerId: "player-b",
    fromPlayerId: "player-a",
    fromName: "Alpha",
    body: "You were removed from your squad.",
    messageType: 3,
    payload: {
      PlayerName: "Bravo",
      Level: 3,
      SquadId: "Safe Squad",
      KickedPlayerId: "player-b",
      SquadKickedFrom: "Safe Squad",
      AdminName: "Alpha",
      AdminId: "player-a",
      AdminLevel: 4,
      KickedPlayerDepositedCards: '["AMMOCRATE"]',
    },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: CREATED_AT,
  };
  assert.equal(validatedInboxMessageDocument(kick, NOW), kick);
  assert.throws(
    () => validatedInboxMessageDocument({
      ...kick,
      payload: { ...kick.payload, AdminId: "forged-admin" },
    }, NOW),
    /standard inbox message/,
  );
  assert.throws(
    () => validatedInboxMessageDocument({
      ...kick,
      payload: { ...kick.payload, KickedPlayerDepositedCards: '["UNKNOWN_CARD"]' },
    }, NOW),
    /standard inbox message/,
  );
});
