import { ApiError, ApiErrorCode } from "../apiErrors";
import { SquadRank } from "../constants";
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
export function requestedSquadJoinPolicy(
  req: Record<string, unknown>,
  required = false,
): number | undefined {
  const joinPolicy = req.JoinPolicy === undefined
    ? undefined
    : exactSquadInteger(req.JoinPolicy, "JoinPolicy");
  // Both recovered callers build IsPublic manually with the same literal "0"/"1" form
  // contract as the match lifecycle flags. The server stores the newer JoinPolicy enum, whose
  // value 0 means open and value 1 means request-only, so preserve the legacy inverse mapping
  // only after the transport itself has been validated.
  const legacyPolicy = req.IsPublic === undefined
    ? undefined
    : (exactBinaryBoolean(req.IsPublic, "IsPublic") ? 0 : 1);
  if (joinPolicy !== undefined && legacyPolicy !== undefined && joinPolicy !== legacyPolicy) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad join-policy fields conflict.");
  }
  const policy = joinPolicy ?? legacyPolicy;
  if (required && policy === undefined) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad join policy is required.");
  }
  return policy;
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

/** Parse action 79's only recovered search text field without alias or object coercion. */
export function requestedSquadNamePrefix(req: Record<string, unknown>): string {
  if (typeof req.SquadNameStart !== "string" || /\p{Cc}/u.test(req.SquadNameStart)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "SquadNameStart is invalid.");
  }
  const normalized = req.SquadNameStart.trim().replace(/\s+/gu, " ");
  if (normalized.length < 3 || normalized.length > 24 || /\p{Cc}/u.test(normalized)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "SquadNameStart is invalid.");
  }
  return normalized;
}

/** The stock search/suggestion caller omits IsGlobal for local and emits exact `"1"` for global. */
export function requestedGlobalSquadDirectory(req: Record<string, unknown>): boolean {
  return exactBinaryBoolean(req.IsGlobal, "IsGlobal", false) ?? false;
}

/**
 * Validate action 81's client Skill echo as an assertion, never as recommendation authority.
 * The service receives the already-proven authenticated account and derives its query from that.
 */
export function requestedSuggestedSquadSkill(value: unknown): number {
  const skill = exactSquadInteger(value, "Skill");
  if (skill < 0) throw new ApiError(ApiErrorCode.UnknownAction, "Skill is invalid.");
  return skill;
}

export interface DeclineSquadJoinRequestInput {
  playerId: string;
  squadId: string;
}

function requestedSquadPlayerId(value: unknown, action: string): string {
  if (typeof value !== "string"
    || value.length < 1
    || value.length > 256
    || value.trim() !== value
    || /\p{Cc}/u.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${action} player field is invalid.`);
  }
  return value;
}

function requestedExistingSquadId(value: unknown, action: string): string {
  if (typeof value !== "string"
    || value.length < 3
    || value.length > 24
    || value.trim().replace(/\s+/gu, " ") !== value
    || /\p{Cc}/u.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${action} squad field is invalid.`);
  }
  return value;
}

function requestedSquadDescription(value: unknown, action: string): string | undefined {
  if (value === undefined) return undefined;
  if (typeof value !== "string" || value.length > 250 || /\p{Cc}/u.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${action} Message is invalid.`);
  }
  return value;
}

function requestedSquadIcon(value: unknown, action: string): Record<string, unknown> {
  if (typeof value !== "string"
    || value === "null"
    || value.length < 1
    || value.length > 128
    || value.trim() !== value
    || /\p{Cc}/u.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${action} Icon is invalid.`);
  }
  return { id: value };
}

function requestedNonnegativeSquadInteger(value: unknown, field: string): number {
  const parsed = exactSquadInteger(value, field);
  if (parsed < 0) throw new ApiError(ApiErrorCode.UnknownAction, `${field} is invalid.`);
  return parsed;
}

export interface CreateSquadRequestInput {
  squadId: string;
  description?: string;
  emblem: Record<string, unknown>;
  joinPolicy: number;
  requiredMedals: number;
}

/**
 * Parse the complete action-37 payload emitted by BeanstalkServerManager.CMNMPMOKFLN.
 *
 * Creation is an economy mutation and publishes a new admission policy. Missing policy, medal,
 * emblem, or identity fields must not turn into an open/default Squad after the WarBucks debit.
 * Fields from JoinSquad, UpdateSquad, or older generic adapters are not aliases for this action.
 */
export function requestedCreateSquad(req: Record<string, unknown>): CreateSquadRequestInput {
  return {
    squadId: requestedExistingSquadId(req.SquadId, "Squad creation"),
    description: requestedSquadDescription(req.Message, "Squad creation"),
    emblem: requestedSquadIcon(req.Icon, "Squad creation"),
    joinPolicy: requestedSquadJoinPolicy(req, true)!,
    requiredMedals: requestedNonnegativeSquadInteger(req.SkillRequirement, "SkillRequirement"),
  };
}

export interface UpdateSquadRequestInput {
  description?: string;
  joinPolicy: number;
  requiredMedals: number;
}

/**
 * Parse action 131 as the recovered current-membership settings mutation.
 *
 * UpdateSquadInfo always submits IsPublic and RequiredMedals, and intentionally omits Message when
 * the text is empty. Requiring both policy scalars prevents a partial or malformed request from
 * being acknowledged after changing only whichever field happened to parse first.
 */
export function requestedUpdateSquad(req: Record<string, unknown>): UpdateSquadRequestInput {
  return {
    description: requestedSquadDescription(req.Message, "Squad update"),
    joinPolicy: requestedSquadJoinPolicy(req, true)!,
    requiredMedals: requestedNonnegativeSquadInteger(req.RequiredMedals, "RequiredMedals"),
  };
}

export interface DirectSquadJoinInput {
  squadId: string;
  messageId?: string;
}

/**
 * Parse action 38 exactly as emitted by BeanstalkServerManager.LINEMJAIGMI.
 *
 * `NewSquadId` is always present. `MessageId` exists only when the player accepts a durable
 * SquadInvitation inbox row, so it is preserved separately for capability validation rather
 * than being allowed to compete with SquadId/SquadName aliases for the destination Squad.
 */
export function requestedDirectSquadJoin(req: Record<string, unknown>): DirectSquadJoinInput {
  const input: DirectSquadJoinInput = {
    squadId: requestedExistingSquadId(req.NewSquadId, "Direct Squad join"),
  };
  if (req.MessageId !== undefined) {
    input.messageId = requestedSquadPlayerId(req.MessageId, "Direct Squad join invitation");
  }
  return input;
}

/** Parse action 132's sole recovered destination field without accepting direct-join aliases. */
export function requestedSquadJoinRequest(req: Record<string, unknown>): string {
  return requestedExistingSquadId(req.SquadId, "Squad join request");
}

/** Actions 45 and 151 both require the recovered `SquadId` lookup field. */
export function requestedSquadRead(req: Record<string, unknown>, action: string): string {
  return requestedExistingSquadId(req.SquadId, action);
}

export interface SquadMembersReadInput {
  squadId: string;
  checkMessages: boolean;
}

/**
 * Parse action 44's complete recovered request. CheckMessages is an exact stock 0/1 form value;
 * it remains a presentation hint and does not grant manager or inbox authority.
 */
export function requestedSquadMembersRead(req: Record<string, unknown>): SquadMembersReadInput {
  return {
    squadId: requestedExistingSquadId(req.SquadId, "Squad member read"),
    checkMessages: exactBinaryBoolean(req.CheckMessages, "CheckMessages") ?? false,
  };
}

/** Parse action 59's sole recovered gameplay field without accepting another action's aliases. */
export function requestedSquadInvitation(req: Record<string, unknown>): string {
  return requestedSquadPlayerId(req.PlayerToInviteId, "Squad invitation");
}

export interface SquadRankChangeInput {
  playerId: string;
  oldRank: SquadRank;
}

/**
 * Bind the optimistic rank action to the exact roster rank the recovered caller displayed.
 * `OldSquadRank` is not decorative rollback metadata: without checking it, a transport retry can
 * promote or demote the same member twice after the first response was lost.
 */
export function requestedSquadRankChange(
  req: Record<string, unknown>,
  direction: "promote" | "demote",
): SquadRankChangeInput {
  const targetField = direction === "promote" ? "PlayerToPromoteId" : "PlayerToDemoteId";
  const oldRank = exactSquadInteger(req.OldSquadRank, "OldSquadRank");
  const rankAllowed = direction === "promote"
    ? oldRank === SquadRank.Member || oldRank === SquadRank.Veteran
    : oldRank === SquadRank.Veteran || oldRank === SquadRank.Coleader;
  if (!rankAllowed) {
    throw new ApiError(ApiErrorCode.UnknownAction, "OldSquadRank is invalid for this action.");
  }
  return {
    playerId: requestedSquadPlayerId(req[targetField], `Squad ${direction}`),
    oldRank,
  };
}

/** Action 57 reuses `PlayerToPromoteId` but has no `OldSquadRank` field. */
export function requestedSquadLeadershipTarget(req: Record<string, unknown>): string {
  return requestedSquadPlayerId(req.PlayerToPromoteId, "Squad leadership transfer");
}

/** Parse action 172's sole recovered target field. */
export function requestedSquadKickTarget(req: Record<string, unknown>): string {
  return requestedSquadPlayerId(req.PlayerToKickId, "Squad kick");
}

export interface AcceptSquadJoinRequestInput {
  playerId: string;
  squadId: string;
}

/** Parse the exact `SquadId` and `PlayerToJoin` pair emitted by recovered action 133. */
export function requestedAcceptSquadJoinRequest(
  req: Record<string, unknown>,
): AcceptSquadJoinRequestInput {
  return {
    playerId: requestedSquadPlayerId(req.PlayerToJoin, "Squad join-request approval"),
    squadId: requestedExistingSquadId(req.SquadId, "Squad join-request approval"),
  };
}

/**
 * Decode action 181's misleading recovered field names exactly.
 *
 * AwaitingSquadMembersManager passes the applicant player ID as the first argument to
 * BeanstalkServerManager.DFMLCJMDLHJ; that method serializes it under `MessageId`, while its second
 * argument is the current squad name serialized under `Id`. Treating generic `Id` as the player
 * target declines the squad name instead and leaves every real applicant pending.
 */
export function requestedDeclineSquadJoinRequest(
  req: Record<string, unknown>,
): DeclineSquadJoinRequestInput {
  try {
    return {
      playerId: requestedSquadPlayerId(req.MessageId, "Squad join-request decline"),
      squadId: requestedExistingSquadId(req.Id, "Squad join-request decline"),
    };
  } catch (error) {
    if (!(error instanceof ApiError)) throw error;
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad join-request decline fields are invalid.");
  }
}
