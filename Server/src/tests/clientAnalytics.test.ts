import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import type { ClientAnalyticsEventDocument } from "../db";
import { outgoingMessageRateLimitKey } from "../services/outgoingMessageRateLimitService";
import { clientAnalyticsPolicy } from "../services/clientAnalyticsPolicyService";
import {
  createClientAnalyticsEvent,
  ingestClientAnalytics,
  parseClientAnalyticsPayload,
  validatedClientAnalyticsEvent,
} from "../services/clientAnalyticsService";

const NOW = new Date("2030-01-02T03:04:05.000Z");
const POLICY = Object.freeze({
  enabled: true,
  retentionDays: 7,
  maximumPayloadBytes: 1_024,
  eventsPerMinute: 8,
});

test("client analytics policy is exact and bounded", () => {
  assert.deepEqual(clientAnalyticsPolicy(POLICY), POLICY);
  assert.throws(
    () => clientAnalyticsPolicy({ ...POLICY, retentionDays: 0 }),
    /retention policy is invalid/,
  );
  assert.throws(
    () => clientAnalyticsPolicy({ ...POLICY, maximumPayloadBytes: 65_537 }),
    /payload-size policy is invalid/,
  );
  assert.throws(
    () => clientAnalyticsPolicy({ ...POLICY, eventsPerMinute: 121 }),
    /rate-limit policy is invalid/,
  );
});

test("action-179 parser accepts only a bounded JSON object", () => {
  const source = "{\"wins\":2,\"clientGoldClaim\":2147483647}";
  assert.equal(parseClientAnalyticsPayload(source, 1_024), source);
  assert.throws(() => parseClientAnalyticsPayload(undefined, 1_024), /payload is invalid/);
  assert.throws(() => parseClientAnalyticsPayload("[]", 1_024), /must be a JSON object/);
  assert.throws(() => parseClientAnalyticsPayload("null", 1_024), /must be a JSON object/);
  assert.throws(() => parseClientAnalyticsPayload("{\"x\":", 1_024), /must be valid JSON/);
  assert.throws(() => parseClientAnalyticsPayload(`{\"x\":\"${"x".repeat(1_024)}\"}`, 1_024), /size is invalid/);
});

test("client analytics event binds exact bytes, digest, and expiry without gameplay fields", () => {
  const event = createClientAnalyticsEvent("player-1", "{\"gold\":999999}", NOW, POLICY);
  assert.equal(event.playerId, "player-1");
  assert.equal(event.byteLength, 15);
  assert.equal(event.expiresAt.getTime() - event.receivedAt.getTime(), 7 * 86_400_000);
  assert.equal(validatedClientAnalyticsEvent(event, NOW), event);
  assert.deepEqual(Object.keys(event).sort(), [
    "_id", "byteLength", "expiresAt", "payloadJson", "payloadSha256", "playerId", "receivedAt",
  ]);

  assert.throws(
    () => validatedClientAnalyticsEvent({ ...event, payloadJson: "{\"gold\":1}" }, NOW),
    /event authority is invalid/,
  );
  assert.throws(
    () => validatedClientAnalyticsEvent({ ...event, expiresAt: new Date(event.receivedAt) }, NOW),
    /event authority is invalid/,
  );
});

test("enabled ingestion reserves capacity then stores one expiring diagnostic row", async () => {
  const inserted: ClientAnalyticsEventDocument[] = [];
  const reservations: Array<{ playerId: string; maximum: number; now: Date }> = [];
  const collection = {
    insertOne: async (event: ClientAnalyticsEventDocument) => {
      inserted.push(event);
      return { acknowledged: true, insertedId: event._id };
    },
  } as unknown as Collection<ClientAnalyticsEventDocument>;

  const stored = await ingestClientAnalytics(
    "player-1",
    "{\"matches\":3}",
    NOW,
    collection,
    POLICY,
    async (playerId, maximum, now) => { reservations.push({ playerId, maximum, now }); },
  );
  assert.equal(stored, true);
  assert.deepEqual(reservations, [{ playerId: "player-1", maximum: 8, now: NOW }]);
  assert.equal(inserted.length, 1);
  assert.equal(inserted[0]?.payloadJson, "{\"matches\":3}");
});

test("disabled ingestion neither parses nor touches rate or storage authority", async () => {
  let reserved = false;
  const stored = await ingestClientAnalytics(
    "player-1",
    undefined,
    NOW,
    undefined,
    { ...POLICY, enabled: false },
    async () => { reserved = true; },
  );
  assert.equal(stored, false);
  assert.equal(reserved, false);
});

test("analytics rate-limit identity is isolated from both social quotas", () => {
  const playerId = "same-player";
  const analytics = outgoingMessageRateLimitKey(playerId, "client-analytics");
  assert.notEqual(analytics, outgoingMessageRateLimitKey(playerId, "inbox"));
  assert.notEqual(analytics, outgoingMessageRateLimitKey(playerId, "squad-chat"));
});
