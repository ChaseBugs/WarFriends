import assert from "node:assert/strict";
import test from "node:test";
import type { MessageDoc } from "../services/socialService";
import { challengeAcceptanceDecision } from "../services/socialService";

const NOW = new Date(Date.UTC(2026, 6, 20, 12, 0, 0));

function challenge(values: Partial<MessageDoc> = {}): MessageDoc {
  return {
    messageId: "challenger-1753012800000",
    toPlayerId: "recipient",
    fromPlayerId: "challenger",
    fromName: "Challenger",
    body: "",
    messageType: 0,
    payload: { GameType: 8, roomName: "room" },
    otherPlayerJson: "{}",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: new Date(NOW.getTime() - 1_000),
    expiresAt: new Date(NOW.getTime() + 60_000),
    ...values,
  };
}

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
