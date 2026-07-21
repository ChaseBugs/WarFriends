import { createHash, randomUUID } from "crypto";
import type { Collection } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  clientErrorEvents,
  type ClientErrorEventDocument,
  type PlayerDocument,
} from "../db";
import { clientErrorPolicy, type ClientErrorPolicy } from "./clientErrorPolicyService";
import { reserveClientErrorSlot } from "./outgoingMessageRateLimitService";
import { validatedPlayerAccountEnvelope } from "./playerProfileMirrorAuthorityService";

const UUID_V4 = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;
const SHA256 = /^[0-9a-f]{64}$/u;
const VERSION = /^[A-Za-z0-9][A-Za-z0-9._+-]{0,63}$/u;
const DOCUMENT_KEYS = new Set([
  "_id", "playerId", "playerName", "clientVersion", "kind", "exceptionMessage",
  "exceptionStacktrace", "sourceAction", "serverResponse", "postParameters",
  "messageToParse", "payloadSha256", "byteLength", "receivedAt", "expiresAt",
]);
const MAXIMUM_HISTORICAL_RETENTION_DAYS = 30;
const MAXIMUM_HISTORICAL_PAYLOAD_BYTES = 65_536;

export interface ClientErrorRequestFields {
  readonly PlayerName: unknown;
  readonly ExceptionMessage: unknown;
  readonly ExceptionStacktrace: unknown;
  readonly ReportedDbAction: unknown;
  readonly ServerResponse: unknown;
  readonly PostParameters: unknown;
  readonly MessageToParse: unknown;
  readonly ClientVersion: unknown;
}

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

function exactText(value: unknown, label: string): string {
  if (typeof value !== "string") {
    throw new ApiError(ApiErrorCode.UnknownAction, `Client error ${label} is invalid.`);
  }
  return value;
}

function diagnosticBytes(value: Pick<ClientErrorEventDocument,
  "exceptionMessage" | "exceptionStacktrace" | "sourceAction" | "serverResponse" | "postParameters" | "messageToParse"
>): number {
  return Buffer.byteLength(JSON.stringify([
    value.exceptionMessage,
    value.exceptionStacktrace,
    value.sourceAction,
    value.serverResponse,
    value.postParameters,
    value.messageToParse,
  ]), "utf8");
}

function diagnosticSha256(value: Pick<ClientErrorEventDocument,
  "exceptionMessage" | "exceptionStacktrace" | "sourceAction" | "serverResponse" | "postParameters" | "messageToParse"
>): string {
  return createHash("sha256").update(JSON.stringify([
    value.exceptionMessage,
    value.exceptionStacktrace,
    value.sourceAction,
    value.serverResponse,
    value.postParameters,
    value.messageToParse,
  ]), "utf8").digest("hex");
}

/** Validate the complete expiring diagnostic before any operator-side consumer can trust it. */
export function validatedClientErrorEvent(
  value: ClientErrorEventDocument,
  now: Date,
): ClientErrorEventDocument {
  const raw = value as unknown as Record<string, unknown>;
  const serverResponseShape = value.kind === "server-response"
    && typeof value.sourceAction === "string"
    && typeof value.serverResponse === "string"
    && typeof value.postParameters === "string"
    && value.messageToParse === null;
  const messageParseShape = value.kind === "message-parse"
    && value.sourceAction === null
    && value.serverResponse === null
    && value.postParameters === null
    && typeof value.messageToParse === "string";
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
    || typeof value.exceptionMessage !== "string"
    || typeof value.exceptionStacktrace !== "string"
    || (!serverResponseShape && !messageParseShape)
    || !SHA256.test(value.payloadSha256)
    || !Number.isSafeInteger(value.byteLength)
    || value.byteLength !== diagnosticBytes(value)
    || value.byteLength < 1
    || value.byteLength > MAXIMUM_HISTORICAL_PAYLOAD_BYTES
    || value.payloadSha256 !== diagnosticSha256(value)
    || !safeDate(value.receivedAt)
    || !safeDate(value.expiresAt)
    || !safeDate(now)
    || value.receivedAt.getTime() > now.getTime()
    || value.expiresAt.getTime() <= value.receivedAt.getTime()
    || value.expiresAt.getTime() - value.receivedAt.getTime() > MAXIMUM_HISTORICAL_RETENTION_DAYS * 86_400_000) {
    throw new Error("Stored client error authority is invalid.");
  }
  return value;
}

export function createClientErrorEvent(
  player: PlayerDocument,
  request: ClientErrorRequestFields,
  now: Date,
  policy: ClientErrorPolicy,
): ClientErrorEventDocument {
  validatedPlayerAccountEnvelope(player);
  const exact = clientErrorPolicy(policy);
  if (!exact.enabled || player.player.sendLogsValue !== 1 || !safeDate(now)) {
    throw new Error("Client error retention context is invalid.");
  }
  if (request.PlayerName !== player.player.accountName) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Client error PlayerName does not match the session.");
  }
  if (typeof request.ClientVersion !== "string" || !VERSION.test(request.ClientVersion)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Client error ClientVersion is invalid.");
  }

  const exceptionMessage = exactText(request.ExceptionMessage, "ExceptionMessage");
  const exceptionStacktrace = exactText(request.ExceptionStacktrace, "ExceptionStacktrace");
  const isServerResponse = request.ReportedDbAction !== undefined
    || request.ServerResponse !== undefined
    || request.PostParameters !== undefined;
  const isMessageParse = request.MessageToParse !== undefined;
  if (isServerResponse === isMessageParse) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Client error payload shape is invalid.");
  }

  const event: ClientErrorEventDocument = {
    _id: randomUUID(),
    playerId: player.id,
    playerName: player.player.accountName,
    clientVersion: request.ClientVersion,
    kind: isServerResponse ? "server-response" : "message-parse",
    exceptionMessage,
    exceptionStacktrace,
    sourceAction: isServerResponse ? exactText(request.ReportedDbAction, "DbAction") : null,
    serverResponse: isServerResponse ? exactText(request.ServerResponse, "ServerResponse") : null,
    postParameters: isServerResponse ? exactText(request.PostParameters, "PostParameters") : null,
    messageToParse: isMessageParse ? exactText(request.MessageToParse, "MessageToParse") : null,
    payloadSha256: "",
    byteLength: 0,
    receivedAt: now,
    expiresAt: new Date(now.getTime() + exact.retentionDays * 86_400_000),
  };
  event.payloadSha256 = diagnosticSha256(event);
  event.byteLength = diagnosticBytes(event);
  if (event.byteLength > exact.maximumPayloadBytes) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Client error payload size is invalid.");
  }
  return validatedClientErrorEvent(event, now);
}

/**
 * Retain one authenticated automatic client diagnostic when both deployment policy and the
 * player's existing SendLogs setting permit it. Disabled/pre-login/no-consent calls remain exact
 * acknowledgements because rejecting an error report can create an error-report feedback loop.
 */
export async function ingestClientError(
  player: PlayerDocument | null,
  request: ClientErrorRequestFields,
  now = new Date(),
  collection?: Collection<ClientErrorEventDocument>,
  policy: ClientErrorPolicy = clientErrorPolicy(),
  reserve: (playerId: string, maximum: number, now: Date) => Promise<void> = reserveClientErrorSlot,
): Promise<boolean> {
  const exact = clientErrorPolicy(policy);
  if (!exact.enabled || !player || player.player.sendLogsValue !== 1) return false;
  const event = createClientErrorEvent(player, request, now, exact);
  await reserve(player.id, exact.eventsPerMinute, now);
  await (collection ?? clientErrorEvents()).insertOne(event);
  return true;
}
