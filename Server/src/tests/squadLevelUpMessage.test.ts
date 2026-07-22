import assert from "node:assert/strict";
import test from "node:test";
import { SquadRank } from "../constants";
import type { SquadDocument } from "../db";
import { newSquad } from "../dtos";
import { liveInboxMessageFor } from "../services/inboxFanoutService";
import { validatedInboxMessageDocument } from "../services/inboxMessageAuthorityService";
import { buildSquadLevelUpMessages } from "../services/squadLevelUpMessageService";
import { toClientMessage, type MessageDoc } from "../services/socialService";

const NOW = new Date("2026-07-22T00:00:00.000Z");
const UNIX = Math.floor(NOW.getTime() / 1_000);
const BATTLE_ID = "aaaaaaaa-aaaa-4aaa-8aaa-aaaaaaaaaaaa";

function squad(): SquadDocument {
  return {
    ...newSquad("Safe Squad", "founder"),
    members: [
      {
        playerId: "founder",
        name: "Founder",
        rank: SquadRank.Leader,
        squadPoints: 0,
        joinedAt: NOW.getTime(),
        lastSeenChatTimestamp: 0,
      },
      {
        playerId: "member",
        name: "Member",
        rank: SquadRank.Member,
        squadPoints: 0,
        joinedAt: NOW.getTime(),
        lastSeenChatTimestamp: 0,
      },
    ],
    createdAt: NOW,
    updatedAt: NOW,
  };
}

test("Squad rank transitions build one deterministic type-10 row per member and crossed level", () => {
  const messages = buildSquadLevelUpMessages(squad(), 1, 3, NOW, BATTLE_ID);
  assert.equal(messages.length, 4);
  assert.deepEqual(messages.map((message) => ({
    recipient: message.toPlayerId,
    id: message.messageId,
    key: message.idempotencyKey,
    payload: message.payload,
  })), [
    {
      recipient: "founder",
      id: `SquadLevelUp-${BATTLE_ID}-2-${UNIX}`,
      key: `squad-level-up:${BATTLE_ID}:Safe Squad:2:founder`,
      payload: { Level: 1, SquadId: "Safe Squad" },
    },
    {
      recipient: "member",
      id: `SquadLevelUp-${BATTLE_ID}-2-${UNIX}`,
      key: `squad-level-up:${BATTLE_ID}:Safe Squad:2:member`,
      payload: { Level: 1, SquadId: "Safe Squad" },
    },
    {
      recipient: "founder",
      id: `SquadLevelUp-${BATTLE_ID}-3-${UNIX}`,
      key: `squad-level-up:${BATTLE_ID}:Safe Squad:3:founder`,
      payload: { Level: 2, SquadId: "Safe Squad" },
    },
    {
      recipient: "member",
      id: `SquadLevelUp-${BATTLE_ID}-3-${UNIX}`,
      key: `squad-level-up:${BATTLE_ID}:Safe Squad:3:member`,
      payload: { Level: 2, SquadId: "Safe Squad" },
    },
  ]);
});

test("type-10 wire projection matches KGALJDLJCEH's exact DynamoDB attributes", () => {
  const message = buildSquadLevelUpMessages(squad(), 1, 2, NOW, BATTLE_ID)[0]!;
  assert.deepEqual(toClientMessage(message), {
    MessageId: { S: `SquadLevelUp-${BATTLE_ID}-2-${UNIX}` },
    PlayerId: { S: "founder" },
    MessageType: { N: "10" },
    Level: { N: "1" },
    SquadId: { S: "Safe Squad" },
  });
  assert.deepEqual(liveInboxMessageFor(message, "founder", NOW)?.message, toClientMessage(message));
});

test("type-10 durable authority rejects payload, rank, and retry-identity drift", () => {
  const message = buildSquadLevelUpMessages(squad(), 1, 2, NOW, BATTLE_ID)[0]!;
  const damaged: MessageDoc[] = [
    { ...message, payload: { ...message.payload, Level: 0 } },
    { ...message, payload: { ...message.payload, Level: 50 } },
    { ...message, payload: { ...message.payload, SquadId: "Other Squad" } },
    { ...message, idempotencyKey: `squad-level-up:${BATTLE_ID}:Safe Squad:2:someone-else` },
    { ...message, messageId: `SquadLevelUp-${BATTLE_ID}-3-${UNIX}` },
    { ...message, rewardClaimed: true },
  ];
  for (const candidate of damaged) {
    assert.throws(() => validatedInboxMessageDocument(candidate, NOW), /invalid/iu);
  }
});

test("Squad level-up builder rejects duplicate recipients and invalid transitions", () => {
  const duplicate = squad();
  duplicate.members.push({ ...duplicate.members[0]! });
  assert.throws(() => buildSquadLevelUpMessages(duplicate, 1, 2, NOW, BATTLE_ID), /roster is invalid/);
  assert.throws(() => buildSquadLevelUpMessages(squad(), 2, 1, NOW, BATTLE_ID), /input is invalid/);
  assert.throws(() => buildSquadLevelUpMessages(squad(), 1, 51, NOW, BATTLE_ID), /input is invalid/);
  assert.throws(() => buildSquadLevelUpMessages(squad(), 1, 2, NOW, "not-a-match"), /input is invalid/);
  assert.deepEqual(buildSquadLevelUpMessages(squad(), 2, 2, NOW, BATTLE_ID), []);
});
