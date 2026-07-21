import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import { AccountType } from "../constants";
import type { ClientLogEntryDocument, PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { clientLogHandlers } from "../handlers/clientLogs";
import { clientLogPolicy } from "../services/clientLogPolicyService";
import {
  createClientLogEntry,
  submitClientLog,
  validatedClientLogEntry,
} from "../services/clientLogService";
import { outgoingMessageRateLimitKey } from "../services/outgoingMessageRateLimitService";
import { createInitialProgression } from "../services/playerStateService";

const NOW_SECONDS = 1_900_000_000;
const NOW = new Date(NOW_SECONDS * 1_000);
const POLICY = Object.freeze({ retentionDays: 7, maximumPayloadBytes: 4_096, eventsPerMinute: 3 });

function playerDocument(consent = 1): PlayerDocument {
  const player = newPlayer("support-player", "SupportPlayer", AccountType.Guest);
  player.sendLogsValue = consent;
  return {
    id: player.id,
    accountName: player.accountName,
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: createInitialProgression(NOW_SECONDS),
    createdAt: NOW,
    updatedAt: NOW,
  };
}

test("client support-log policy is exact and bounded", () => {
  assert.deepEqual(clientLogPolicy(POLICY), POLICY);
  assert.throws(() => clientLogPolicy({ ...POLICY, retentionDays: 31 }), /retention policy is invalid/);
  assert.throws(() => clientLogPolicy({ ...POLICY, maximumPayloadBytes: 1_023 }), /payload-size policy is invalid/);
  assert.throws(() => clientLogPolicy({ ...POLICY, eventsPerMinute: 21 }), /rate-limit policy is invalid/);
});

test("support-log entry returns a source-compatible UUID LogId and binds opaque bytes", () => {
  const entry = createClientLogEntry(playerDocument(), "line one\nline two ✓", "1.6.0", NOW, POLICY);
  assert.match(entry._id, /^[0-9a-f-]{36}$/u);
  assert.equal(entry.playerId, "support-player");
  assert.equal(entry.playerName, "SupportPlayer");
  assert.equal(entry.clientVersion, "1.6.0");
  assert.equal(entry.byteLength, Buffer.byteLength(entry.logs, "utf8"));
  assert.equal(entry.expiresAt.getTime() - entry.receivedAt.getTime(), 7 * 86_400_000);
  assert.equal(validatedClientLogEntry(entry, NOW), entry);

  assert.throws(
    () => validatedClientLogEntry({ ...entry, logs: `${entry.logs}!` }, NOW),
    /support-log authority is invalid/,
  );
  assert.throws(
    () => validatedClientLogEntry({ ...entry, receivedAt: new Date(NOW.getTime() + 1) }, NOW),
    /support-log authority is invalid/,
  );
});

test("support-log creation enforces durable consent and exact source fields", () => {
  assert.throws(
    () => createClientLogEntry(playerDocument(0), "logs", "1.6.0", NOW, POLICY),
    /Support log consent is disabled/,
  );
  assert.throws(
    () => createClientLogEntry(playerDocument(), "", "1.6.0", NOW, POLICY),
    /payload size is invalid/,
  );
  assert.throws(
    () => createClientLogEntry(playerDocument(), "logs", " 1.6.0", NOW, POLICY),
    /client version is invalid/,
  );
  assert.throws(
    () => createClientLogEntry(playerDocument(), "x".repeat(4_097), "1.6.0", NOW, POLICY),
    /payload size is invalid/,
  );
});

test("support-log submission reserves its isolated quota before durable insertion", async () => {
  const inserted: ClientLogEntryDocument[] = [];
  const reservations: Array<{ playerId: string; maximum: number; now: Date }> = [];
  const collection = {
    insertOne: async (entry: ClientLogEntryDocument) => {
      inserted.push(entry);
      return { acknowledged: true, insertedId: entry._id };
    },
  } as unknown as Collection<ClientLogEntryDocument>;
  const entry = await submitClientLog(
    playerDocument(),
    "captured logs",
    "1.6.0",
    NOW,
    collection,
    POLICY,
    async (playerId, maximum, now) => { reservations.push({ playerId, maximum, now }); },
  );
  assert.equal(inserted[0], entry);
  assert.deepEqual(reservations, [{ playerId: "support-player", maximum: 3, now: NOW }]);
});

test("action 166 is authenticated and its rate identity cannot consume other quotas", () => {
  assert.equal(clientLogHandlers[DbAction.SendLog]?.requiresAuth, true);
  const playerId = "support-player";
  const key = outgoingMessageRateLimitKey(playerId, "client-log");
  assert.notEqual(key, outgoingMessageRateLimitKey(playerId, "inbox"));
  assert.notEqual(key, outgoingMessageRateLimitKey(playerId, "squad-chat"));
  assert.notEqual(key, outgoingMessageRateLimitKey(playerId, "client-analytics"));
});
