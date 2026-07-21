import { ApiError, ApiErrorCode } from "../apiErrors";
import { SquadRank } from "../constants";
import type { SquadDocument } from "../db";

const MAX_CLIENT_INTEGER = 2_147_483_647;
const MAX_PLAYER_ID_LENGTH = 256;
export const SQUAD_MAX_PENDING_ADMISSIONS = 100;
const MAX_SQUAD_MEMBERS = 50;
const MAX_CLOCK_SKEW_SECONDS = 300;
const SQUAD_KEYS = new Set([
  "_id", "name", "emblem", "description", "experience", "squadPoints", "level", "leagueId",
  "leagueDivision", "squadWarLevel", "squadWarRoundId", "squadWarWins", "founderId",
  "joinPolicy", "minLevel", "requiredMedals", "maxMembers", "members", "joinRequests",
  "invitedPlayerIds", "createdAt", "updatedAt",
]);
const MEMBER_KEYS = new Set([
  "playerId", "name", "rank", "squadPoints", "joinedAt", "lastSeenChatTimestamp",
]);
const REQUEST_KEYS = new Set(["playerId", "name", "createdAt"]);

function invalid(): never {
  throw new ApiError(ApiErrorCode.InternalServerError, "Stored squad authority is invalid.");
}

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value) && !(value instanceof Date);
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function boundedCanonicalText(value: unknown, minimum: number, maximum: number): value is string {
  return typeof value === "string"
    && value.length >= minimum
    && value.length <= maximum
    && !/\p{Cc}/u.test(value)
    && value.trim().replace(/\s+/gu, " ") === value;
}

function boundedIdentity(value: unknown): value is string {
  return boundedCanonicalText(value, 1, MAX_PLAYER_ID_LENGTH);
}

function boundedClientInteger(value: unknown, minimum = 0): value is number {
  return Number.isSafeInteger(value) && (value as number) >= minimum && (value as number) <= MAX_CLIENT_INTEGER;
}

/**
 * The recovered request sends one Icon string. Keep the internal object solely for compatibility
 * with older reconstructed rows, but do not let arbitrary nested client JSON become durable squad
 * state or reach JSON.stringify at a public wire boundary.
 */
export function validatedSquadEmblem(value: unknown): Record<string, unknown> {
  if (!plainRecord(value)) invalid();
  const keys = Object.keys(value);
  if (keys.length === 0) return value;
  if (keys.length !== 1
    || keys[0] !== "id"
    || !boundedCanonicalText(value.id, 1, 128)) {
    invalid();
  }
  return value;
}

/** Reject a modified client's unsupported emblem shape as input, not as stored corruption. */
export function requestedSquadEmblem(value: unknown): Record<string, unknown> {
  try {
    return validatedSquadEmblem(value);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad emblem is invalid.");
  }
}

/**
 * Prove the complete roster and admission snapshot before it can authorize a leader action, chat,
 * event, card-pool operation, PvP squad reward, leaderboard row, or Squad War placement.
 *
 * The embedded rank is server authority, not display metadata. Exactly one Leader must exist and
 * must equal founderId; member and pending identities are unique; no pending identity may already
 * own membership. All counters and clocks are bounded to the signed client contract so NaN,
 * Infinity, duplicate IDs, or a future timestamp cannot gain authority through JavaScript
 * comparison behavior.
 */
export function validatedSquadDocument(
  squad: SquadDocument,
  now = new Date(),
): SquadDocument {
  const raw = squad as unknown as Record<string, unknown>;
  if (!plainRecord(squad)
    || Object.keys(raw).some((key) => !SQUAD_KEYS.has(key))
    || !boundedCanonicalText(squad.name, 3, 24)
    || !boundedCanonicalText(squad.description, 0, 250)
    || !boundedClientInteger(squad.experience)
    || !boundedClientInteger(squad.squadPoints)
    || !boundedClientInteger(squad.level, 1)
    || !boundedCanonicalText(squad.leagueId, 0, 128)
    || !boundedCanonicalText(squad.leagueDivision, 0, 128)
    || (squad.squadWarLevel !== undefined
      && (!Number.isSafeInteger(squad.squadWarLevel) || squad.squadWarLevel < 1 || squad.squadWarLevel > 8))
    || (squad.squadWarRoundId !== undefined
      && !boundedCanonicalText(squad.squadWarRoundId, 0, 128))
    || (squad.squadWarWins !== undefined && !boundedClientInteger(squad.squadWarWins))
    || !boundedIdentity(squad.founderId)
    || !Number.isSafeInteger(squad.joinPolicy)
    || squad.joinPolicy < 0
    || squad.joinPolicy > 2
    || !boundedClientInteger(squad.minLevel)
    || !boundedClientInteger(squad.requiredMedals)
    || !Number.isSafeInteger(squad.maxMembers)
    || squad.maxMembers < 1
    || squad.maxMembers > MAX_SQUAD_MEMBERS
    || !Array.isArray(squad.members)
    || squad.members.length < 1
    || squad.members.length > squad.maxMembers
    || !Array.isArray(squad.joinRequests)
    || squad.joinRequests.length > SQUAD_MAX_PENDING_ADMISSIONS
    || !Array.isArray(squad.invitedPlayerIds)
    || squad.invitedPlayerIds.length > SQUAD_MAX_PENDING_ADMISSIONS
    || !safeDate(squad.createdAt)
    || !safeDate(squad.updatedAt)
    || !safeDate(now)
    || squad.createdAt.getTime() > squad.updatedAt.getTime()
    || squad.updatedAt.getTime() > now.getTime()) {
    invalid();
  }
  validatedSquadEmblem(squad.emblem);

  const memberIds = new Set<string>();
  let leaders = 0;
  for (const member of squad.members) {
    const memberRaw = member as unknown as Record<string, unknown>;
    if (!plainRecord(member)
      || Object.keys(memberRaw).some((key) => !MEMBER_KEYS.has(key))
      || !boundedIdentity(member.playerId)
      || memberIds.has(member.playerId)
      || !boundedCanonicalText(member.name, 3, 15)
      || ![SquadRank.Member, SquadRank.Veteran, SquadRank.Leader, SquadRank.Coleader].includes(member.rank)
      || !boundedClientInteger(member.squadPoints)
      || !Number.isSafeInteger(member.joinedAt)
      || member.joinedAt < squad.createdAt.getTime()
      || member.joinedAt > now.getTime()
      || !Number.isSafeInteger(member.lastSeenChatTimestamp)
      || member.lastSeenChatTimestamp < 0
      || member.lastSeenChatTimestamp > Math.min(
        MAX_CLIENT_INTEGER,
        Math.floor(now.getTime() / 1_000) + MAX_CLOCK_SKEW_SECONDS,
      )) {
      invalid();
    }
    memberIds.add(member.playerId);
    if (member.rank === SquadRank.Leader) leaders += 1;
  }
  const founder = squad.members.find((member) => member.playerId === squad.founderId);
  if (!founder || founder.rank !== SquadRank.Leader || leaders !== 1) invalid();

  const requestIds = new Set<string>();
  for (const request of squad.joinRequests) {
    const requestRaw = request as unknown as Record<string, unknown>;
    if (!plainRecord(request)
      || Object.keys(requestRaw).some((key) => !REQUEST_KEYS.has(key))
      || !boundedIdentity(request.playerId)
      || memberIds.has(request.playerId)
      || requestIds.has(request.playerId)
      || !boundedCanonicalText(request.name, 3, 15)
      || !Number.isSafeInteger(request.createdAt)
      || request.createdAt < squad.createdAt.getTime()
      || request.createdAt > now.getTime()) {
      invalid();
    }
    requestIds.add(request.playerId);
  }

  const invitationIds = new Set<string>();
  for (const playerId of squad.invitedPlayerIds) {
    if (!boundedIdentity(playerId)
      || memberIds.has(playerId)
      || invitationIds.has(playerId)) {
      invalid();
    }
    invitationIds.add(playerId);
  }
  return squad;
}
