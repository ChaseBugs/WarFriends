import assert from "node:assert/strict";
import test from "node:test";
import type { MessageDoc } from "../services/socialService";
import { challengeAcceptanceDecision } from "../services/socialService";
import { validatedChallengeMessage } from "../services/challengeMessageAuthorityService";

const NOW = new Date(Date.UTC(2026, 6, 20, 12, 0, 0));

function challenge(values: Partial<MessageDoc> = {}): MessageDoc {
  return {
    messageId: `challenger-${Math.floor(NOW.getTime() / 1_000) - 1}`,
    toPlayerId: "recipient",
    fromPlayerId: "challenger",
    fromName: "Challenger",
    body: "",
    messageType: 0,
    payload: {
      MapName: "map_1",
      GameType: 8,
      Region: 0,
      roomName: "room",
      clientVersion: "4.9.5",
    },
    otherPlayerJson: "{}",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: new Date(NOW.getTime() - 1_000),
    expiresAt: new Date(NOW.getTime() + 60_000),
    ...values,
  };
}

test("challenge authority binds recovered payload, identity, TTL, and acceptance time", () => {
  const valid = challenge();
  assert.equal(validatedChallengeMessage(valid, NOW), valid);
  assert.throws(
    () => validatedChallengeMessage(challenge({ accepted: true, acceptedAt: NOW }), NOW),
    /Stored challenge message is invalid/,
    "accepted challenges must also carry the recovered read marker",
  );
  assert.throws(
    () => validatedChallengeMessage(challenge({
      createdAt: new Date(NOW.getTime() + 1),
      expiresAt: new Date(NOW.getTime() + 61_000),
      messageId: `challenger-${Math.floor((NOW.getTime() + 1) / 1_000)}`,
    }), NOW),
    /Stored challenge message is invalid/,
  );
  assert.throws(
    () => validatedChallengeMessage(challenge({ payload: { ...valid.payload, Region: 11 } }), NOW),
    /Stored challenge message is invalid/,
  );
  const afterInt32Time = new Date("2040-01-01T00:00:00Z");
  assert.throws(
    () => validatedChallengeMessage(challenge({
      createdAt: afterInt32Time,
      expiresAt: new Date(afterInt32Time.getTime() + 60_000),
      messageId: `challenger-${Math.floor(afterInt32Time.getTime() / 1_000)}`,
    }), new Date(afterInt32Time.getTime() + 1)),
    /Stored challenge message is invalid/,
  );
});

test("challenge acceptance is recipient-owned and a durable accepted row replays successfully", () => {
  assert.equal(challengeAcceptanceDecision(challenge(), "recipient", NOW), "accept");
  assert.equal(challengeAcceptanceDecision(challenge({ accepted: true, acceptedAt: NOW }), "recipient", NOW), "replay");
  assert.equal(challengeAcceptanceDecision(challenge(), "challenger", NOW), "invalid");
});

test("ignored, expired, non-challenge, and missing rows cannot be accepted or replayed", () => {
  assert.equal(challengeAcceptanceDecision(null, "recipient", NOW), "invalid");
  assert.equal(challengeAcceptanceDecision(challenge({ ignored: true }), "recipient", NOW), "invalid");
  assert.equal(challengeAcceptanceDecision(challenge({ expiresAt: NOW }), "recipient", NOW), "invalid");
  assert.equal(challengeAcceptanceDecision(challenge({ messageType: 27 }), "recipient", NOW), "invalid");
  assert.equal(
    challengeAcceptanceDecision(challenge({ accepted: true, expiresAt: new Date(NOW.getTime() - 1) }), "recipient", NOW),
    "invalid",
  );
});
