import { ApiError, ApiErrorCode } from "../apiErrors";
import { exactBinaryBoolean } from "./requestBooleanParsing";

/**
 * Parse one integer carried by the recovered HTTP request contract without JavaScript's broad
 * numeric coercion. Express may expose a stock-client form value as a decimal string, while tests
 * and replacement clients may send a JSON number, so both exact representations are accepted.
 * Booleans, arrays, objects, blank strings, fractions, exponent notation, and unsafe magnitudes
 * are rejected before the authoritative squad service sees a normalized but different value.
 */
export function exactSquadInteger(value: unknown, field: string, fallback?: number): number {
  if (value === undefined) {
    if (fallback !== undefined) return fallback;
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an exact integer.`);
  }
  let parsed: number;
  if (typeof value === "number") {
    parsed = value;
  } else if (typeof value === "string" && /^(?:0|-[1-9]\d*|[1-9]\d*)$/.test(value)) {
    parsed = Number(value);
  } else {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an exact integer.`);
  }
  // The recovered fields are C# `int`, not JavaScript safe integers. Rejecting values outside
  // that width here prevents a replacement transport from reaching service comparisons with a
  // number Unity could neither emit nor deserialize.
  if (!Number.isInteger(parsed) || parsed < -2_147_483_648 || parsed > 2_147_483_647) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an exact integer.`);
  }
  return parsed;
}

/** Resolve the current JoinPolicy field or its older inverse IsPublic projection exactly. */
export function requestedSquadJoinPolicy(req: Record<string, unknown>): number | undefined {
  if (req.JoinPolicy !== undefined) return exactSquadInteger(req.JoinPolicy, "JoinPolicy");
  if (req.IsPublic === undefined) return undefined;

  // Both recovered callers build IsPublic manually with the same literal "0"/"1" form
  // contract as the match lifecycle flags. The server stores the newer JoinPolicy enum, whose
  // value 0 means open and value 1 means request-only, so preserve the legacy inverse mapping
  // only after the transport itself has been validated.
  return exactBinaryBoolean(req.IsPublic, "IsPublic") ? 0 : 1;
}

const SQUAD_CHAT_TIMESTAMP_FIELDS = [
  "LastSeenSquadChatTimeStamp",
  "Timestamp",
  "TimeStamp",
] as const;

/**
 * Parse the repaired-client direct action-193 form without alias precedence or JS coercion.
 *
 * The stock client queues a decimal string in RequestBuffer, but historical diagnostic clients
 * have used three direct field names. Exactly one alias may describe the cursor. Requiring the
 * shared C# Int32 transport before the time-aware service check prevents `false`, `[]`, fractions,
 * or two conflicting aliases from becoming a different valid read cursor.
 */
export function requestedDirectSquadChatTimestamp(req: Record<string, unknown>): number {
  const supplied = SQUAD_CHAT_TIMESTAMP_FIELDS.filter((field) => req[field] !== undefined);
  if (supplied.length !== 1) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat timestamp field is invalid.");
  }
  return exactSquadInteger(req[supplied[0]], supplied[0]);
}
