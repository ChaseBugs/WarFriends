import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import { AccountType } from "../constants";
import type { ClientErrorEventDocument, PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { clientErrorHandlers } from "../handlers/clientErrors";
import { normalizeEnvelope } from "../routes";
import { clientErrorPolicy } from "../services/clientErrorPolicyService";
import {
  createClientErrorEvent,
  ingestClientError,
  validatedClientErrorEvent,
  type ClientErrorRequestFields,
} from "../services/clientErrorService";
import { outgoingMessageRateLimitKey } from "../services/outgoingMessageRateLimitService";
import { createInitialProgression } from "../services/playerStateService";

const NOW_SECONDS = 1_900_000_000;
const NOW = new Date(NOW_SECONDS * 1_000);
const POLICY = Object.freeze({
  enabled: true,
  retentionDays: 7,
  maximumPayloadBytes: 4_096,
  eventsPerMinute: 5,
});

function playerDocument(consent = 1): PlayerDocument {
  const player = newPlayer("error-player", "ErrorPlayer", AccountType.Guest);
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

function serverResponseRequest(): ClientErrorRequestFields {
  return {
    PlayerName: "ErrorPlayer",
    ExceptionMessage: "Could not parse player data",
    ExceptionStacktrace: "at DatabasePlayer.CreateFromDatabase()",
    ReportedDbAction: "GetPlayerData 1.6.0",
    ServerResponse: "response= {bad-json}",
    PostParameters: "PlayerId=error-player",
    MessageToParse: undefined,
    ClientVersion: "1.6.0",
  };
}

test("client error retention policy is exact, opt-in, and bounded", () => {
  assert.deepEqual(clientErrorPolicy(POLICY), POLICY);
  assert.throws(() => clientErrorPolicy({ ...POLICY, enabled: 1 as unknown as boolean }), /enablement policy is invalid/);
  assert.throws(() => clientErrorPolicy({ ...POLICY, retentionDays: 31 }), /retention policy is invalid/);
  assert.throws(() => clientErrorPolicy({ ...POLICY, maximumPayloadBytes: 1_023 }), /payload-size policy is invalid/);
  assert.throws(() => clientErrorPolicy({ ...POLICY, eventsPerMinute: 61 }), /rate-limit policy is invalid/);
});

test("action-92 normalization preserves its source DbAction field-name collision", () => {
  const envelope = normalizeEnvelope({
    requestId: "92",
    DbAction: "GetPlayerData 1.6.0",
    PlayerName: "ErrorPlayer",
  }, "92");
  assert.equal(envelope.DbAction, DbAction.ErrorMessage);
  assert.equal(envelope.ReportedDbAction, "GetPlayerData 1.6.0");

  const conflicting = normalizeEnvelope({ requestId: "91", DbAction: "GetPlayerData 1.6.0" }, "92");
  assert.equal(Number.isNaN(conflicting.DbAction), true);
});

test("client error rows bind exact server-response and message-parse shapes", () => {
  const response = createClientErrorEvent(playerDocument(), serverResponseRequest(), NOW, POLICY);
  assert.equal(response.kind, "server-response");
  assert.equal(response.playerId, "error-player");
  assert.equal(response.messageToParse, null);
  assert.equal(response.expiresAt.getTime() - response.receivedAt.getTime(), 7 * 86_400_000);
  assert.equal(validatedClientErrorEvent(response, NOW), response);
  assert.throws(
    () => validatedClientErrorEvent({ ...response, exceptionMessage: `${response.exceptionMessage}!` }, NOW),
    /client error authority is invalid/,
  );

  const parsed = createClientErrorEvent(playerDocument(), {
    ...serverResponseRequest(),
    ReportedDbAction: undefined,
    ServerResponse: undefined,
    PostParameters: undefined,
    MessageToParse: "message= malformed socket frame",
  }, NOW, POLICY);
  assert.equal(parsed.kind, "message-parse");
  assert.equal(parsed.sourceAction, null);
  assert.equal(parsed.messageToParse, "message= malformed socket frame");
});

test("client error retention silently skips disabled, unauthenticated, and no-consent calls", async () => {
  const disabled = { ...POLICY, enabled: false };
  assert.equal(await ingestClientError(playerDocument(), serverResponseRequest(), NOW, undefined, disabled), false);
  assert.equal(await ingestClientError(null, serverResponseRequest(), NOW, undefined, POLICY), false);
  assert.equal(await ingestClientError(playerDocument(0), serverResponseRequest(), NOW, undefined, POLICY), false);
});

test("client error ingestion validates before isolated quota reservation and insertion", async () => {
  const inserted: ClientErrorEventDocument[] = [];
  const reservations: Array<{ playerId: string; maximum: number; now: Date }> = [];
  const collection = {
    insertOne: async (entry: ClientErrorEventDocument) => {
      inserted.push(entry);
      return { acknowledged: true, insertedId: entry._id };
    },
  } as unknown as Collection<ClientErrorEventDocument>;
  assert.equal(await ingestClientError(
    playerDocument(),
    serverResponseRequest(),
    NOW,
    collection,
    POLICY,
    async (playerId, maximum, now) => { reservations.push({ playerId, maximum, now }); },
  ), true);
  assert.equal(inserted.length, 1);
  assert.deepEqual(reservations, [{ playerId: "error-player", maximum: 5, now: NOW }]);

  await assert.rejects(
    ingestClientError(playerDocument(), { ...serverResponseRequest(), PlayerName: "Forged" }, NOW, collection, POLICY),
    /does not match the session/,
  );
  assert.equal(clientErrorHandlers[DbAction.ErrorMessage]?.requiresAuth, false);
  const key = outgoingMessageRateLimitKey("error-player", "client-error");
  assert.notEqual(key, outgoingMessageRateLimitKey("error-player", "client-log"));
  assert.notEqual(key, outgoingMessageRateLimitKey("error-player", "client-analytics"));
});
