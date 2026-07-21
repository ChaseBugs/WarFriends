import { createHash, randomUUID } from "crypto";
import type { Collection } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  clientLogEntries,
  type ClientLogEntryDocument,
  type PlayerDocument,
} from "../db";
import { validatedPlayerAccountEnvelope } from "./playerProfileMirrorAuthorityService";
import { clientLogPolicy, type ClientLogPolicy } from "./clientLogPolicyService";
import { reserveClientLogSlot } from "./outgoingMessageRateLimitService";

const UUID_V4 = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;
const SHA256 = /^[0-9a-f]{64}$/u;
const VERSION = /^[A-Za-z0-9][A-Za-z0-9._+-]{0,63}$/u;
const DOCUMENT_KEYS = new Set([
  "_id", "playerId", "playerName", "clientVersion", "logs", "logsSha256", "byteLength",
  "receivedAt", "expiresAt",
]);
const MAXIMUM_HISTORICAL_RETENTION_DAYS = 30;
const MAXIMUM_HISTORICAL_PAYLOAD_BYTES = 1_048_576;

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function boundedIdentity(value: unknown): value is string {
  return typeof value === "string"
    && value.length >= 1
    && value.length <= 256
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
}

function exactLogText(value: unknown, maximumPayloadBytes: number): string {
  if (typeof value !== "string"
    || !Number.isSafeInteger(maximumPayloadBytes)
    || maximumPayloadBytes < 1_024
    || maximumPayloadBytes > MAXIMUM_HISTORICAL_PAYLOAD_BYTES) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Support log payload is invalid.");
  }
  const size = Buffer.byteLength(value, "utf8");
  if (size < 1 || size > maximumPayloadBytes) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Support log payload size is invalid.");
  }
  return value;
}

function exactClientVersion(value: unknown): string {
  if (typeof value !== "string" || !VERSION.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Support log client version is invalid.");
  }
  return value;
}

/** Complete durable authority check for one operator-readable, gameplay-inert support upload. */
export function validatedClientLogEntry(
  value: ClientLogEntryDocument,
  now: Date,
): ClientLogEntryDocument {
  const raw = value as unknown as Record<string, unknown>;
  if (!value
    || typeof value !== "object"
    || Array.isArray(value)
    || Object.keys(raw).length !== DOCUMENT_KEYS.size
    || Object.keys(raw).some((key) => !DOCUMENT_KEYS.has(key))
    || !UUID_V4.test(value._id)
    || !boundedIdentity(value.playerId)
    || typeof value.playerName !== "string"
    || value.playerName.length < 1
    || value.playerName.length > 15
    || value.playerName.trim() !== value.playerName
    || /[\u0000-\u001f\u007f]/u.test(value.playerName)
    || !VERSION.test(value.clientVersion)
    || typeof value.logs !== "string"
    || !SHA256.test(value.logsSha256)
    || !Number.isSafeInteger(value.byteLength)
    || value.byteLength !== Buffer.byteLength(value.logs, "utf8")
    || value.byteLength < 1
    || value.byteLength > MAXIMUM_HISTORICAL_PAYLOAD_BYTES
    || createHash("sha256").update(value.logs, "utf8").digest("hex") !== value.logsSha256
    || !safeDate(value.receivedAt)
    || !safeDate(value.expiresAt)
    || !safeDate(now)
    || value.receivedAt.getTime() > now.getTime()
    || value.expiresAt.getTime() <= value.receivedAt.getTime()
    || value.expiresAt.getTime() - value.receivedAt.getTime() > MAXIMUM_HISTORICAL_RETENTION_DAYS * 86_400_000) {
    throw new Error("Stored client support-log authority is invalid.");
  }
  return value;
}

export function createClientLogEntry(
  player: PlayerDocument,
  logsValue: unknown,
  clientVersionValue: unknown,
  now: Date,
  policy: ClientLogPolicy,
): ClientLogEntryDocument {
  validatedPlayerAccountEnvelope(player);
  const exact = clientLogPolicy(policy);
  if (player.player.sendLogsValue !== 1) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Support log consent is disabled.");
  }
  if (!safeDate(now)) throw new Error("Client support-log time is invalid.");
  const logs = exactLogText(logsValue, exact.maximumPayloadBytes);
  const clientVersion = exactClientVersion(clientVersionValue);
  const entry: ClientLogEntryDocument = {
    _id: randomUUID(),
    playerId: player.id,
    playerName: player.player.accountName,
    clientVersion,
    logs,
    logsSha256: createHash("sha256").update(logs, "utf8").digest("hex"),
    byteLength: Buffer.byteLength(logs, "utf8"),
    receivedAt: now,
    expiresAt: new Date(now.getTime() + exact.retentionDays * 86_400_000),
  };
  return validatedClientLogEntry(entry, now);
}

/**
 * Store one explicit user support upload and return the LogId required by OGLEHLIPEFM.CDDOAAGDJMJ.
 *
 * PlayerName and PlayerId request fields are assertions only; the document uses the authenticated
 * account snapshot. The request has no replay nonce, so a lost response may create another log ID.
 * Each upload is non-authoritative, rate-limited, expiring, and isolated from gameplay state.
 */
export async function submitClientLog(
  player: PlayerDocument,
  logsValue: unknown,
  clientVersionValue: unknown,
  now = new Date(),
  collection?: Collection<ClientLogEntryDocument>,
  policy: ClientLogPolicy = clientLogPolicy(),
  reserve: (playerId: string, maximum: number, now: Date) => Promise<void> = reserveClientLogSlot,
): Promise<ClientLogEntryDocument> {
  const exact = clientLogPolicy(policy);
  // Build first so malformed or consent-disabled requests do not consume abuse capacity. Valid
  // attempts reserve before insertion, making concurrent large uploads share one global limit.
  const entry = createClientLogEntry(player, logsValue, clientVersionValue, now, exact);
  await reserve(player.id, exact.eventsPerMinute, now);
  await (collection ?? clientLogEntries()).insertOne(entry);
  return entry;
}
