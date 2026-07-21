import assert from "node:assert/strict";
import test from "node:test";
import type { Collection, Filter } from "mongodb";
import { AccountType } from "../constants";
import type {
  ClientAnalyticsEventDocument,
  ClientErrorEventDocument,
  ClientLogEntryDocument,
  PlayerDocument,
} from "../db";
import { newPlayer } from "../dtos";
import {
  listAdminDiagnostics,
  findAdminDiagnostic,
  normalizeAdminDiagnosticListInput,
  normalizeAdminDiagnosticId,
  wireAdminDiagnostic,
  type AdminDiagnosticDocument,
} from "../services/adminDiagnosticService";
import { createClientAnalyticsEvent } from "../services/clientAnalyticsService";
import { createClientErrorEvent } from "../services/clientErrorService";
import { createClientLogEntry } from "../services/clientLogService";
import { createInitialProgression } from "../services/playerStateService";

const NOW_SECONDS = 1_900_000_000;
const NOW = new Date(NOW_SECONDS * 1_000);

function playerDocument(): PlayerDocument {
  const player = newPlayer("diagnostic-player", "DiagPlayer", AccountType.Guest);
  player.sendLogsValue = 1;
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

function analytics(): ClientAnalyticsEventDocument {
  return createClientAnalyticsEvent(
    "diagnostic-player",
    "{\"screen\":\"army\"}",
    NOW,
    { enabled: true, retentionDays: 7, maximumPayloadBytes: 4_096, eventsPerMinute: 5 },
  );
}

function supportLog(): ClientLogEntryDocument {
  return createClientLogEntry(
    playerDocument(),
    "support log bytes",
    "1.6.0",
    NOW,
    { retentionDays: 7, maximumPayloadBytes: 4_096, eventsPerMinute: 3 },
  );
}

function clientError(): ClientErrorEventDocument {
  return createClientErrorEvent(playerDocument(), {
    PlayerName: "DiagPlayer",
    ExceptionMessage: "parse failed",
    ExceptionStacktrace: "at Parser.Read()",
    ReportedDbAction: undefined,
    ServerResponse: undefined,
    PostParameters: undefined,
    MessageToParse: "message= bad-json",
    ClientVersion: "1.6.0",
  }, NOW, { enabled: true, retentionDays: 7, maximumPayloadBytes: 4_096, eventsPerMinute: 5 });
}

function fakeCollection(
  rows: AdminDiagnosticDocument[],
  capture?: (filter: Filter<AdminDiagnosticDocument>) => void,
): Collection<AdminDiagnosticDocument> {
  const cursor = {
    sort: () => cursor,
    limit: () => cursor,
    toArray: async () => rows,
  };
  return {
    find: (filter: Filter<AdminDiagnosticDocument>) => {
      capture?.(filter);
      return cursor;
    },
  } as unknown as Collection<AdminDiagnosticDocument>;
}

test("admin diagnostic query input is exact, bounded, and kind-specific", () => {
  assert.deepEqual(normalizeAdminDiagnosticListInput({ kind: "analytics" }, NOW), {
    kind: "analytics",
    playerId: null,
    limit: 50,
    cursor: null,
    decodedCursor: null,
  });
  assert.throws(
    () => normalizeAdminDiagnosticListInput({ kind: "unknown" }, NOW),
    /kind is invalid/,
  );
  assert.throws(
    () => normalizeAdminDiagnosticListInput({ kind: "support-logs", limit: "01" }, NOW),
    /integer from 1 through 100/,
  );
  assert.throws(
    () => normalizeAdminDiagnosticListInput({ kind: "client-errors", playerId: " padded " }, NOW),
    /playerId is invalid/,
  );
});

test("admin diagnostic detail lookup resolves the exact action-166 LogId", async () => {
  const event = supportLog();
  let captured: Filter<AdminDiagnosticDocument> | undefined;
  const collection = {
    findOne: async (filter: Filter<AdminDiagnosticDocument>) => {
      captured = filter;
      return event;
    },
  } as unknown as Collection<AdminDiagnosticDocument>;
  assert.equal(normalizeAdminDiagnosticId(event._id.toUpperCase()), event._id);
  assert.equal(await findAdminDiagnostic("support-logs", event._id, NOW, collection), event);
  assert.deepEqual(captured, { _id: event._id, expiresAt: { $gt: NOW } });
  assert.throws(() => normalizeAdminDiagnosticId("not-a-log-id"), /canonical UUIDv4/);

  const missing = {
    findOne: async () => null,
  } as unknown as Collection<AdminDiagnosticDocument>;
  assert.equal(await findAdminDiagnostic("client-errors", event._id, NOW, missing), null);
});

test("admin diagnostic detail lookup rejects damaged selected authority", async () => {
  const event = clientError();
  const collection = {
    findOne: async () => ({ ...event, payloadSha256: "0".repeat(64) }),
  } as unknown as Collection<AdminDiagnosticDocument>;
  await assert.rejects(
    findAdminDiagnostic("client-errors", event._id, NOW, collection),
    /client error authority is invalid/,
  );
});

test("admin diagnostics use a stable query-bound descending cursor", async () => {
  const event = analytics();
  const first = await listAdminDiagnostics(
    { kind: "analytics", playerId: null, limit: 1, cursor: null },
    NOW,
    fakeCollection([event]),
  );
  assert.equal(first.items[0], event);
  assert.equal(typeof first.nextCursor, "string");

  let captured: Filter<AdminDiagnosticDocument> | undefined;
  await listAdminDiagnostics(
    { kind: "analytics", playerId: null, limit: 1, cursor: first.nextCursor },
    NOW,
    fakeCollection([], (filter) => { captured = filter; }),
  );
  assert.deepEqual(captured?.expiresAt, { $gt: NOW });
  assert.equal(Array.isArray(captured?.$or), true);

  assert.throws(
    () => normalizeAdminDiagnosticListInput({
      kind: "support-logs",
      cursor: first.nextCursor,
    }, NOW),
    /does not match this query/,
  );
});

test("admin diagnostic pages validate every selected row and enforce application-time expiry", async () => {
  const event = supportLog();
  const corrupt = { ...event, logs: `${event.logs}!` };
  await assert.rejects(
    listAdminDiagnostics(
      { kind: "support-logs", playerId: "diagnostic-player", limit: 50, cursor: null },
      NOW,
      fakeCollection([corrupt]),
    ),
    /support-log authority is invalid/,
  );

  const afterExpiry = new Date(event.expiresAt.getTime() + 1);
  await assert.rejects(
    listAdminDiagnostics(
      { kind: "support-logs", playerId: null, limit: 50, cursor: null },
      afterExpiry,
      fakeCollection([event]),
    ),
    /Selected client diagnostic is expired/,
  );
});

test("admin diagnostic wire adapters expose only each reviewed diagnostic family", () => {
  const analyticsWire = wireAdminDiagnostic("analytics", analytics());
  assert.equal(analyticsWire.payloadJson, "{\"screen\":\"army\"}");
  assert.equal("logs" in analyticsWire, false);

  const logWire = wireAdminDiagnostic("support-logs", supportLog());
  assert.equal(logWire.logs, "support log bytes");
  assert.equal("exceptionMessage" in logWire, false);

  const errorWire = wireAdminDiagnostic("client-errors", clientError());
  assert.equal(errorWire.kind, "message-parse");
  assert.equal(errorWire.messageToParse, "message= bad-json");
  assert.equal("payloadJson" in errorWire, false);
});
