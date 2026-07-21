import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  JoinMatchPayload,
  MatchEventPayload,
  MatchResultPayload,
} from "../gameRooms/types";

const JOIN_MATCH_KEYS = new Set(["MatchId"]);
const MATCH_EVENT_KEYS = new Set(["MatchId", "Event", "Data"]);
const MATCH_RESULT_KEYS = new Set(["MatchId", "WinnerId", "UsedCards", "Stats"]);

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value);
}

function boundedIdentity(value: unknown): value is string {
  return typeof value === "string"
    && value.length >= 1
    && value.length <= 128
    && value.trim() === value
    && !/\p{Cc}/u.test(value);
}

function hasOnlyKnownKeys(value: Record<string, unknown>, keys: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => keys.has(key));
}

/** Require the replacement join request to name exactly one bounded durable match. */
export function validatedJoinMatchPayload(value: unknown): JoinMatchPayload {
  if (!plainRecord(value)
    || !Object.prototype.hasOwnProperty.call(value, "MatchId")
    || !hasOnlyKnownKeys(value, JOIN_MATCH_KEYS)
    || !boundedIdentity(value.MatchId)) {
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
    || !boundedIdentity(value.MatchId)
    || !boundedIdentity(value.Event)) {
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
    || !boundedIdentity(value.MatchId)
    || !boundedIdentity(value.WinnerId)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "MatchResult payload is invalid.");
  }
  return value as unknown as MatchResultPayload;
}
