import { ApiError, ApiErrorCode } from "../apiErrors";
import type { MatchResultPayload } from "../gameRooms/types";

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
    || Object.keys(value).some((key) => !MATCH_RESULT_KEYS.has(key))
    || !boundedIdentity(value.MatchId)
    || !boundedIdentity(value.WinnerId)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "MatchResult payload is invalid.");
  }
  return value as unknown as MatchResultPayload;
}
