import { createHash, randomUUID } from "crypto";
import type { Collection } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  clientAnalyticsEvents,
  type ClientAnalyticsEventDocument,
} from "../db";
import {
  clientAnalyticsPolicy,
  type ClientAnalyticsPolicy,
} from "./clientAnalyticsPolicyService";
import { reserveClientAnalyticsSlot } from "./outgoingMessageRateLimitService";

const UUID_V4 = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;
const SHA256 = /^[0-9a-f]{64}$/u;
const DOCUMENT_KEYS = new Set([
  "_id", "playerId", "payloadJson", "payloadSha256", "byteLength", "receivedAt", "expiresAt",
]);
const MAXIMUM_HISTORICAL_RETENTION_DAYS = 90;
const MAXIMUM_HISTORICAL_PAYLOAD_BYTES = 65_536;

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function boundedPlayerId(value: unknown): value is string {
  return typeof value === "string"
    && value.length >= 1
    && value.length <= 256
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
}

/** Parse only the outer source-defined object; every nested value remains an untrusted claim. */
export function parseClientAnalyticsPayload(value: unknown, maximumPayloadBytes: number): string {
  if (!Number.isSafeInteger(maximumPayloadBytes)
    || maximumPayloadBytes < 256
    || maximumPayloadBytes > MAXIMUM_HISTORICAL_PAYLOAD_BYTES
    || typeof value !== "string") {
    throw new ApiError(ApiErrorCode.UnknownAction, "PlayerAnalytics payload is invalid.");
  }
  const byteLength = Buffer.byteLength(value, "utf8");
  if (byteLength < 2 || byteLength > maximumPayloadBytes) {
    throw new ApiError(ApiErrorCode.UnknownAction, "PlayerAnalytics payload size is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "PlayerAnalytics must be valid JSON.");
  }
  if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "PlayerAnalytics must be a JSON object.");
  }
  return value;
}

/**
 * Validate every stored diagnostic field before tests, tools, or future operator reads use it.
 * Historical rows are checked against global bounds rather than today's configured policy so a
 * deliberate retention reduction does not retroactively label still-expiring data as corrupt.
 */
export function validatedClientAnalyticsEvent(
  value: ClientAnalyticsEventDocument,
  now: Date,
): ClientAnalyticsEventDocument {
  const raw = value as unknown as Record<string, unknown>;
  if (!value
    || typeof value !== "object"
    || Array.isArray(value)
    || Object.keys(raw).length !== DOCUMENT_KEYS.size
    || Object.keys(raw).some((key) => !DOCUMENT_KEYS.has(key))
    || !UUID_V4.test(value._id)
    || !boundedPlayerId(value.playerId)
    || typeof value.payloadJson !== "string"
    || !SHA256.test(value.payloadSha256)
    || !Number.isSafeInteger(value.byteLength)
    || value.byteLength !== Buffer.byteLength(value.payloadJson, "utf8")
    || value.byteLength < 2
    || value.byteLength > MAXIMUM_HISTORICAL_PAYLOAD_BYTES
    || createHash("sha256").update(value.payloadJson, "utf8").digest("hex") !== value.payloadSha256
    || !safeDate(value.receivedAt)
    || !safeDate(value.expiresAt)
    || !safeDate(now)
    || value.receivedAt.getTime() > now.getTime()
    || value.expiresAt.getTime() <= value.receivedAt.getTime()
    || value.expiresAt.getTime() - value.receivedAt.getTime() > MAXIMUM_HISTORICAL_RETENTION_DAYS * 86_400_000) {
    throw new Error("Stored client analytics event authority is invalid.");
  }
  // Re-run outer JSON validation at the global storage bound. A matching digest proves bytes,
  // not that a manually inserted row still satisfies the recovered object-shaped contract.
  parseClientAnalyticsPayload(value.payloadJson, MAXIMUM_HISTORICAL_PAYLOAD_BYTES);
  return value;
}

export function createClientAnalyticsEvent(
  playerId: string,
  payloadJson: string,
  now: Date,
  policy: ClientAnalyticsPolicy,
): ClientAnalyticsEventDocument {
  const exact = clientAnalyticsPolicy(policy);
  if (!exact.enabled || !boundedPlayerId(playerId) || !safeDate(now)) {
    throw new Error("Client analytics event context is invalid.");
  }
  const payload = parseClientAnalyticsPayload(payloadJson, exact.maximumPayloadBytes);
  const event: ClientAnalyticsEventDocument = {
    _id: randomUUID(),
    playerId,
    payloadJson: payload,
    payloadSha256: createHash("sha256").update(payload, "utf8").digest("hex"),
    byteLength: Buffer.byteLength(payload, "utf8"),
    receivedAt: now,
    expiresAt: new Date(now.getTime() + exact.retentionDays * 86_400_000),
  };
  return validatedClientAnalyticsEvent(event, now);
}

/**
 * Persist an authenticated action-179 snapshot as diagnostic data only.
 *
 * The recovered request has no operation UUID, so an uncertain HTTP retry can create a second
 * observation. Guessing deduplication from identical JSON would incorrectly collapse two real
 * submissions whose changed fields happened to match. The atomic per-player rate limit bounds
 * both cases, while TTL bounds privacy and storage exposure. No progression write occurs here.
 */
export async function ingestClientAnalytics(
  playerId: string,
  payloadValue: unknown,
  now = new Date(),
  collection?: Collection<ClientAnalyticsEventDocument>,
  policy: ClientAnalyticsPolicy = clientAnalyticsPolicy(),
  reserve: (playerId: string, maximum: number, now: Date) => Promise<void> = reserveClientAnalyticsSlot,
): Promise<boolean> {
  const exact = clientAnalyticsPolicy(policy);
  if (!exact.enabled) return false;
  const payload = parseClientAnalyticsPayload(payloadValue, exact.maximumPayloadBytes);
  await reserve(playerId, exact.eventsPerMinute, now);
  const event = createClientAnalyticsEvent(playerId, payload, now, exact);
  await (collection ?? clientAnalyticsEvents()).insertOne(event);
  return true;
}
