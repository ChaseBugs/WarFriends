import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  IdentifyPayload,
  JoinMatchPayload,
  MatchEventPayload,
  MatchResultPayload,
  SendSquadChatPayload,
  SquadChatHistoryPayload,
} from "../gameRooms/types";

const IDENTIFY_KEYS = new Set(["PlayerId", "Token"]);
const JOIN_MATCH_KEYS = new Set(["MatchId"]);
const MATCH_EVENT_KEYS = new Set(["MatchId", "Event", "Data"]);
const MATCH_RESULT_KEYS = new Set(["MatchId", "WinnerId", "UsedCards", "Stats"]);
const SEND_SQUAD_CHAT_KEYS = new Set(["ClientMessageId", "Text"]);
const SQUAD_CHAT_HISTORY_KEYS = new Set(["BeforeCursor"]);

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value);
}

function boundedText(value: unknown, maximum: number): value is string {
  return typeof value === "string"
    && value.length >= 1
    && value.length <= maximum
    && value.trim() === value
    && !/\p{Cc}/u.test(value);
}

function hasOnlyKnownKeys(value: Record<string, unknown>, keys: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => keys.has(key));
}

/**
 * Validate the only message allowed to establish immutable WebSocket player identity.
 *
 * Authentication still proves the credential cryptographically. This wrapper prevents a socket
 * from carrying alternate player/token aliases that one server version ignores and another might
 * prefer, and rejects malformed values before they reach authentication logging or lookups.
 */
export function validatedIdentifyPayload(value: unknown): IdentifyPayload {
  if (!plainRecord(value)
    || !Object.prototype.hasOwnProperty.call(value, "PlayerId")
    || !Object.prototype.hasOwnProperty.call(value, "Token")
    || !hasOnlyKnownKeys(value, IDENTIFY_KEYS)
    || !boundedText(value.PlayerId, 256)
    || !boundedText(value.Token, 4_096)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Identify payload is invalid.");
  }
  return value as unknown as IdentifyPayload;
}

/** Require the replacement join request to name exactly one bounded durable match. */
export function validatedJoinMatchPayload(value: unknown): JoinMatchPayload {
  if (!plainRecord(value)
    || !Object.prototype.hasOwnProperty.call(value, "MatchId")
    || !hasOnlyKnownKeys(value, JOIN_MATCH_KEYS)
    || !boundedText(value.MatchId, 128)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "JoinMatch payload is invalid.");
  }
  return value as unknown as JoinMatchPayload;
}

/**
 * Validate the opaque event wrapper without pretending its unrecovered Data is combat authority.
 * CardPlayed receives its separate exact Data validation after this common match/event identity
 * check; every other event remains transport-only and cannot affect rewards or progression.
 */
export function validatedMatchEventPayload(value: unknown): MatchEventPayload {
  if (!plainRecord(value)
    || !Object.prototype.hasOwnProperty.call(value, "MatchId")
    || !Object.prototype.hasOwnProperty.call(value, "Event")
    || !hasOnlyKnownKeys(value, MATCH_EVENT_KEYS)
    || !boundedText(value.MatchId, 128)
    || !boundedText(value.Event, 128)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "MatchEvent payload is invalid.");
  }
  return value as unknown as MatchEventPayload;
}

/**
 * Validate the replacement WebSocket MatchResult wrapper before any room or MongoDB lookup.
 *
 * TypeScript interfaces disappear at runtime, while socket JSON is attacker-controlled. MatchId
 * selects one durable lifecycle and WinnerId selects a consensus candidate, so both are mandatory
 * bounded identities. UsedCards and Stats remain optional exactly as declared by the replacement
 * protocol; the former is parsed by the shared inventory authority and the latter remains opaque,
 * non-authoritative telemetry. Extra fields are rejected so two client versions cannot describe
 * competing result identities that one server node silently ignores.
 */
export function validatedMatchResultPayload(value: unknown): MatchResultPayload {
  if (!plainRecord(value)
    || !Object.prototype.hasOwnProperty.call(value, "MatchId")
    || !Object.prototype.hasOwnProperty.call(value, "WinnerId")
    || !hasOnlyKnownKeys(value, MATCH_RESULT_KEYS)
    || !boundedText(value.MatchId, 128)
    || !boundedText(value.WinnerId, 128)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "MatchResult payload is invalid.");
  }
  return value as unknown as MatchResultPayload;
}

/**
 * Preserve the exact distinction between an omitted history cursor and a malformed cursor.
 *
 * A truly absent payload, or an exact empty object, requests the latest recovered-size page. When
 * BeforeCursor is present it must remain a string for the Squad Chat service to verify as an opaque
 * cursor. Explicit null, undefined, numeric values, aliases, and extra fields must not be erased
 * into the no-cursor path because that would turn an invalid older-page request into a valid read.
 */
export function validatedSquadChatHistoryPayload(value: unknown): SquadChatHistoryPayload {
  if (value === undefined) return {};
  if (!plainRecord(value) || !hasOnlyKnownKeys(value, SQUAD_CHAT_HISTORY_KEYS)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "GetSquadChatHistory payload is invalid.");
  }
  if (Object.prototype.hasOwnProperty.call(value, "BeforeCursor")
    && typeof value.BeforeCursor !== "string") {
    throw new ApiError(ApiErrorCode.UnknownAction, "GetSquadChatHistory payload is invalid.");
  }
  return value as unknown as SquadChatHistoryPayload;
}

/**
 * Validate the two client-authored Squad Chat fields before the request reaches persistence.
 *
 * This wrapper proves only the recovered transport shape. The Squad Chat service remains the
 * authority for nonce grammar, text normalization, length, moderation, membership, rate limits,
 * and retry identity. Keeping those semantic checks in one place prevents WebSocket admission and
 * direct service callers from drifting while still rejecting casts, aliases, and missing fields.
 */
export function validatedSendSquadChatPayload(value: unknown): SendSquadChatPayload {
  if (!plainRecord(value)
    || !Object.prototype.hasOwnProperty.call(value, "ClientMessageId")
    || !Object.prototype.hasOwnProperty.call(value, "Text")
    || !hasOnlyKnownKeys(value, SEND_SQUAD_CHAT_KEYS)
    || typeof value.ClientMessageId !== "string"
    || typeof value.Text !== "string") {
    throw new ApiError(ApiErrorCode.UnknownAction, "SendSquadChat payload is invalid.");
  }
  return value as unknown as SendSquadChatPayload;
}
