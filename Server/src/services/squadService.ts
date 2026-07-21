import {
  messages,
  players,
  squads,
  withMongoTransaction,
  type PlayerDocument,
  type PlayerProgressionState,
  type SquadDocument,
} from "../db";
import type { Collection } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { SquadRank } from "../constants";
import { newSquad, type SquadDTO, type SquadMemberDTO } from "../dtos";
import { findById, updatePlayerFields } from "./playerService";
import { progressionForPlayer } from "./playerStateService";
import { validatedPlayerAccountEnvelope } from "./playerProfileMirrorAuthorityService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { reclaimDepositedCardsForDepartureState } from "./squadCardPoolService";
import { buildSquadKickMessage } from "./socialService";
import { publishInboxFanout } from "./inboxFanoutService";
import logger from "../utils/logger";
import { requireModeratedText } from "./textModerationService";
import { invalidateSquadWarRewardEligibility } from "./squadWarService";
import {
  SQUAD_CREATE_BASE_WARBUCKS_COST,
  squadCreationWarBucksPrice,
  validatedSquadCreationsCount,
} from "./squadCreationAuthorityService";
import {
  nextSquadUpdatedAt,
  requestedSquadEmblem,
  SQUAD_MAX_PENDING_ADMISSIONS,
  validatedSquadDocument,
} from "./squadAuthorityService";

export {
  SQUAD_CREATE_BASE_WARBUCKS_COST,
  squadCreationWarBucksPrice,
  validatedSquadCreationsCount,
} from "./squadCreationAuthorityService";
export { nextSquadUpdatedAt } from "./squadAuthorityService";

/**
 * Squad membership, admission, rank authority, and denormalized player mirrors.
 *
 * `squads.members` is the membership source of truth. Squad name and rank are also copied to
 * each player document because the recovered client expects to render them from a standalone
 * DatabasePlayer response. Every cross-document membership mutation now commits the roster and
 * player mirrors in one MongoDB transaction. Creation includes its WarBucks debit, while leave
 * and kick also return normal card deposits and clear the pool mirror in that same boundary.
 * Squad-only settings, invitations, and pending-request edits remain single-document writes.
 *
 * Admission capabilities are created only inside this service. A public join request cannot
 * set `allowPrivate`; only an already-authorized manager acceptance can pass it to `joinSquad`.
 * Rank checks use `squadRankAuthority` because the recovered wire enum is not ordered by
 * privilege: Leader(2) outranks Coleader(3), despite its smaller numeric value.
 */

function cleanName(name: string): string {
  // This helper is also used to resolve existing squads during join, leave, rank, and kick
  // operations. Do not apply current publication policy here: a legacy squad whose name is no
  // longer acceptable must remain addressable so its members can leave and managers can repair
  // it. Moderation belongs only on creation/preflight entry points below.
  return name.trim().replace(/\s+/g, " ");
}

export function squadRankAuthority(rank: SquadRank): number {
  // Convert wire enum values to an explicit monotonic permission scale. Keeping this mapping
  // centralized protects promote, demote, and kick from the easy Leader(2) < Coleader(3)
  // mistake and gives unknown/None ranks no authority.
  switch (rank) {
    case SquadRank.Leader:
      return 3;
    case SquadRank.Coleader:
      return 2;
    case SquadRank.Veteran:
      return 1;
    case SquadRank.Member:
      return 0;
    default:
      return -1;
  }
}

function member(squad: SquadDTO, playerId: string): SquadMemberDTO {
  const value = squad.members.find((candidate) => candidate.playerId === playerId);
  if (!value) throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not a squad member.");
  return value;
}

function requireManager(squad: SquadDTO, actorId: string): SquadMemberDTO {
  const actor = member(squad, actorId);
  if (actorId !== squad.founderId && actor.rank !== SquadRank.Leader && actor.rank !== SquadRank.Coleader) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Insufficient squad rank.");
  }
  return actor;
}

export async function isNameAvailable(name: string): Promise<boolean> {
  const normalized = cleanName(name);
  if (!normalized) return false;
  requireModeratedText(normalized, "Squad name");
  return (await squads().findOne({ name: normalized })) === null;
}

export async function getByName(name: string): Promise<SquadDocument | null> {
  const normalized = cleanName(name);
  if (!normalized) return null;
  const squad = await squads().findOne({ name: normalized });
  return squad ? validatedSquadDocument(squad) : null;
}

/**
 * Bind a single-document squad write to the exact durable snapshot that authorized it.
 * A name-only replacement lets an older manager snapshot overwrite a concurrent demotion,
 * admission, or roster edit. The recovered document already owns an audited `updatedAt` field,
 * so use it as an optimistic revision and make the caller re-read all authority after a race.
 */
export function squadSnapshotWriteFilter(
  squad: Pick<SquadDocument, "name" | "updatedAt">,
): { name: string; updatedAt: Date } {
  if (!(squad.updatedAt instanceof Date) || !Number.isFinite(squad.updatedAt.getTime())) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Squad write snapshot has an invalid revision.");
  }
  return { name: squad.name, updatedAt: squad.updatedAt };
}

async function persist(squad: SquadDocument): Promise<void> {
  // Match by the immutable squad name and require an existing document. Silently upserting
  // here would allow a delayed mutation to recreate a squad after its last member left.
  const filter = squadSnapshotWriteFilter(squad);
  const now = nextSquadUpdatedAt(squad);
  const successor = validatedSquadDocument({ ...squad, updatedAt: now }, now);
  // MongoDB supplies `_id` even though the public DTO does not declare it. Never echo that field
  // through `$set`: it is immutable and would make otherwise valid settings/request edits fail.
  const { _id: _mongoId, ...writable } = successor as SquadDocument & { _id?: unknown };
  const result = await squads().updateOne(filter, { $set: writable });
  if (result.matchedCount !== 1) {
    // Never retry this stale object automatically: manager rank, roster membership, pending
    // capability, or admission limits may have changed in the winning write.
    throw new ApiError(ApiErrorCode.InternalServerError, "Squad changed concurrently; retry from a fresh snapshot.");
  }
}

export interface CreateSquadOptions {
  description?: string;
  emblem?: Record<string, unknown>;
  joinPolicy?: number;
  requiredMedals?: number;
}

const MAX_SQUAD_CLIENT_INT = 2_147_483_647;

/** Validate the exact three-state join-policy integer consumed by DatabaseSquad. */
export function validatedSquadJoinPolicy(value: number | undefined, fallback?: number): number | undefined {
  const candidate = value ?? fallback;
  if (candidate === undefined) return undefined;
  if (!Number.isSafeInteger(candidate) || candidate < 0 || candidate > 2) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad join policy is invalid.");
  }
  return candidate;
}

/** Validate the nonnegative C# int medal gate before it can affect squad admission. */
export function validatedSquadRequiredMedals(value: number | undefined, fallback?: number): number | undefined {
  const candidate = value ?? fallback;
  if (candidate === undefined) return undefined;
  if (!Number.isSafeInteger(candidate) || candidate < 0 || candidate > MAX_SQUAD_CLIENT_INT) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad medal requirement is invalid.");
  }
  return candidate;
}

/** IJEAJGCCHEF.NotEnoughWarBucksForCreateSquad; its parser restores count and wallet. */
export const SQUAD_CREATE_NOT_ENOUGH_WARBUCKS = 11403;

export interface SquadCreationEconomyResult {
  state: PlayerProgressionState;
  squadCreationsCount: number;
  warBucksSpent: number;
}

export interface CreateSquadResult extends SquadCreationEconomyResult {
  squad: SquadDTO;
}

/** Apply only the authoritative currency/count portion so it can be tested without MongoDB. */
export function applySquadCreationEconomyState(state: PlayerProgressionState): SquadCreationEconomyResult {
  const previousCount = validatedSquadCreationsCount(state.squadCreationsCount);
  const squadCreationsCount = validatedSquadCreationsCount(previousCount + 1);
  if (!Number.isSafeInteger(state.revision) || state.revision < 0 || state.revision === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Squad creation progression revision is invalid.");
  }
  if (!Number.isSafeInteger(state.warBucks)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Squad creation WarBucks balance is invalid.");
  }
  const warBucksSpent = squadCreationWarBucksPrice(previousCount);
  if (state.warBucks < warBucksSpent) {
    throw new ApiError(SQUAD_CREATE_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks to create a squad.");
  }
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      warBucks: state.warBucks - warBucksSpent,
      squadCreationsCount,
    },
    squadCreationsCount,
    warBucksSpent,
  };
}

function progressionRevisionFilter(player: PlayerDocument): Record<string, unknown> {
  if (!player.progression) return { progression: { $exists: false } };
  return player.progression.revision === undefined
    ? { "progression.revision": { $exists: false } }
    : { "progression.revision": player.progression.revision };
}

export async function createSquad(
  founderId: string,
  requestedName: string,
  options: CreateSquadOptions = {},
): Promise<CreateSquadResult> {
  const name = cleanName(requestedName);
  if (name.length < 3 || name.length > 24 || /\p{Cc}/u.test(name)) {
    throw new ApiError(ApiErrorCode.SquadNotFound, "Squad name must be between 3 and 24 characters.");
  }
  requireModeratedText(name, "Squad name");
  try {
    const result = await withMongoTransaction(async (session) => {
      const founder = await players().findOne({ id: founderId }, { session });
      if (!founder) throw new ApiError(ApiErrorCode.PlayerNotFound, "Founder not found.");
      // This fresh transaction snapshot owns both the creation debit and the first roster/profile
      // mirrors; authentication's earlier player object is not sufficient publication authority.
      validatedPlayerAccountEnvelope(founder);
      if (founder.player.squadName) {
        throw new ApiError(ApiErrorCode.SquadAlreadyExists, "Player already belongs to a squad.");
      }

      const currentProgression = progressionForPlayer(founder);
      const economy = applySquadCreationEconomyState(currentProgression);
      const successor = validatedProgressionSuccessor(currentProgression, economy.state);
      const { dogTags: _legacyDogTags, ...canonicalState } = successor;

      // All initial values are derived or bounded on the server. In particular, the request
      // cannot choose its founder, inject members, or create an out-of-range join policy.
      const squad = newSquad(name, founderId);
      const description = options.description?.trim().replace(/\s+/gu, " ").slice(0, 250) ?? "";
      if (/\p{Cc}/u.test(description)) {
        throw new ApiError(ApiErrorCode.UnknownAction, "Squad description contains unsupported control characters.");
      }
      squad.description = description
        ? requireModeratedText(description, "Squad description")
        : "";
      squad.emblem = requestedSquadEmblem(options.emblem ?? {});
      // These client settings are assertions, not values to normalize. Silently flooring a
      // fractional or oversized requirement would publish a different admission policy than the
      // player requested and could accidentally open a squad that was meant to be restricted.
      squad.joinPolicy = validatedSquadJoinPolicy(options.joinPolicy, 0)!;
      squad.requiredMedals = validatedSquadRequiredMedals(options.requiredMedals, 0)!;
      squad.members.push({
        playerId: founderId,
        name: founder.player.accountName,
        rank: SquadRank.Leader,
        squadPoints: founder.player.squadPoints,
        joinedAt: Date.now(),
        lastSeenChatTimestamp: 0,
      });

      const now = new Date();
      const document = validatedSquadDocument({ ...squad, createdAt: now, updatedAt: now }, now);
      // The unique index is the final arbiter for simultaneous create requests. The separate
      // availability action is UI feedback only and is never trusted as a reservation.
      await squads().insertOne(document, { session });

      const update = await players().updateOne(
        {
          id: founderId,
          squadName: founder.squadName,
          "player.squadName": founder.player.squadName,
          ...progressionRevisionFilter(founder),
        },
        {
          $set: {
            progression: canonicalState,
            squadName: name,
            "player.squadName": name,
            "player.squadRank": SquadRank.Leader,
            updatedAt: now,
          },
        },
        { session },
      );
      if (update.modifiedCount !== 1) {
        // Throwing aborts the squad insert too. A caller may safely retry after reloading;
        // no name, membership, creation count, or WarBucks debit has partially committed.
        throw new ApiError(ApiErrorCode.InternalServerError, "Squad founder state changed concurrently.");
      }

      return { ...economy, state: canonicalState, squad };
    });
    logger.squad.event("Squad created", {
      name,
      founderId,
      warBucksSpent: result.warBucksSpent,
      squadCreationsCount: result.squadCreationsCount,
    });
    return result;
  } catch (error) {
    if ((error as { code?: number }).code === 11000) {
      throw new ApiError(ApiErrorCode.SquadNameTaken, "Squad name already taken.");
    }
    throw error;
  }
}

export interface SquadJoinPlan {
  squad: SquadDTO;
  rank: SquadRank;
  rosterChanged: boolean;
  admissionStateChanged: boolean;
  playerMirrorChanged: boolean;
}

/**
 * Validate and calculate a squad admission without writing either MongoDB document.
 *
 * `approvedBy` is a server-internal actor ID, never a request flag. When present, manager
 * authority and the target's stored join request are checked against the same squad snapshot
 * used for capacity and roster changes. This closes the old time-of-check/time-of-use gap in
 * which a demoted manager could still approve a waiting player.
 */
export function planSquadJoin(
  squad: SquadDTO,
  player: PlayerDocument,
  approvedBy?: string,
): SquadJoinPlan {
  if (approvedBy) {
    try {
      requireManager(squad, approvedBy);
    } catch (error) {
      if (error instanceof ApiError) {
        throw new ApiError(ApiErrorCode.NotLeaderOfSquad, "Only a squad manager can approve requests.");
      }
      throw error;
    }
    if (!(squad.joinRequests ?? []).some((request) => request.playerId === player.id)) {
      throw new ApiError(ApiErrorCode.SquadJoinRequestNotExists, "Join request not found.");
    }
  }

  const existingMember = squad.members.find((candidate) => candidate.playerId === player.id);
  const conflictingSquadName = [player.squadName, player.player.squadName]
    .find((candidate) => candidate && candidate !== squad.name);
  if (conflictingSquadName) {
    // A roster entry in one squad must never overwrite a player mirror already owned by a
    // different squad. Treat that as conflicting state and require an explicit repair.
    throw new ApiError(
      approvedBy ? ApiErrorCode.PlayerAlreadyInSquad : ApiErrorCode.PlayerAlreadyInSquadCantJoin,
      "Player already belongs to another squad.",
    );
  }

  if (!existingMember) {
    if (squad.members.length >= squad.maxMembers) {
      throw new ApiError(ApiErrorCode.SquadIsFull, "Squad is full.");
    }
    // SquadRecord compares the parsed SkillRequirement to DatabasePlayer.skill. MedalsBalance is
    // the separate weekly Player League counter and can reset independently, so it must never
    // reject a player whose persistent global-medal Skill satisfies the Squad gate.
    if (player.player.skill < (squad.requiredMedals || 0)) {
      throw new ApiError(ApiErrorCode.NotEnoughSquadSkill, "Player does not meet the squad medal requirement.");
    }
    // Policy zero is open. A non-open squad requires either a persisted invitation or an
    // approval actor whose authority and pending request were verified above.
    const invited = (squad.invitedPlayerIds ?? []).includes(player.id);
    if (squad.joinPolicy !== 0 && !approvedBy && !invited) {
      throw new ApiError(ApiErrorCode.SquadIsNotPublic, "This squad requires an invitation or approved request.");
    }
  }

  const rank = existingMember?.rank ?? SquadRank.Member;
  const members = existingMember
    ? [...squad.members]
    : [
        ...squad.members,
        {
          playerId: player.id,
          name: player.player.accountName,
          rank,
          squadPoints: player.player.squadPoints,
          joinedAt: Date.now(),
          lastSeenChatTimestamp: 0,
        },
      ];
  // A successful admission consumes all pending state. Removing both forms prevents a stale
  // manager approval or invitation from becoming a reusable authorization capability later.
  const joinRequests = (squad.joinRequests ?? []).filter((request) => request.playerId !== player.id);
  const invitedPlayerIds = (squad.invitedPlayerIds ?? []).filter((id) => id !== player.id);
  const admissionStateChanged =
    joinRequests.length !== (squad.joinRequests ?? []).length
    || invitedPlayerIds.length !== (squad.invitedPlayerIds ?? []).length;

  return {
    squad: { ...squad, members, joinRequests, invitedPlayerIds },
    rank,
    rosterChanged: !existingMember,
    admissionStateChanged,
    playerMirrorChanged:
      player.squadName !== squad.name
      || player.player.squadName !== squad.name
      || player.player.squadRank !== rank,
  };
}

async function joinSquadTransaction(playerId: string, requestedName: string, approvedBy?: string): Promise<SquadDTO> {
  const name = cleanName(requestedName);
  const result = await withMongoTransaction(async (session) => {
    const [squad, player] = await Promise.all([
      squads().findOne({ name }, { session }),
      players().findOne({ id: playerId }, { session }),
    ]);
    if (!squad) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad not found.");
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    validatedSquadDocument(squad);
    validatedPlayerAccountEnvelope(player);

    const plan = planSquadJoin(squad, player, approvedBy);
    const now = nextSquadUpdatedAt(squad);
    validatedSquadDocument({ ...plan.squad, createdAt: squad.createdAt, updatedAt: now }, now);
    if (plan.rosterChanged || plan.admissionStateChanged) {
      const squadUpdate = await squads().updateOne(
        { name: squad.name, updatedAt: squad.updatedAt },
        {
          $set: {
            members: plan.squad.members,
            joinRequests: plan.squad.joinRequests,
            invitedPlayerIds: plan.squad.invitedPlayerIds,
            updatedAt: now,
          },
        },
        { session },
      );
      if (squadUpdate.modifiedCount !== 1) {
        throw new ApiError(ApiErrorCode.InternalServerError, "Squad admission changed concurrently.");
      }
    }

    if (plan.playerMirrorChanged) {
      const playerUpdate = await players().updateOne(
        {
          id: player.id,
          squadName: player.squadName,
          "player.squadName": player.player.squadName,
          "player.squadRank": player.player.squadRank,
        },
        {
          $set: {
            squadName: squad.name,
            "player.squadName": squad.name,
            "player.squadRank": plan.rank,
            updatedAt: now,
          },
        },
        { session },
      );
      if (playerUpdate.modifiedCount !== 1) {
        // The surrounding transaction also rolls back the roster/pending-state update.
        throw new ApiError(ApiErrorCode.InternalServerError, "Player squad state changed concurrently.");
      }
    }
    return { squad: plan.squad, joined: plan.rosterChanged };
  });

  if (result.joined) logger.squad.event("Player joined squad", { name: result.squad.name, playerId });
  return result.squad;
}

/** Public join path: privacy can be satisfied only by an open policy or stored invitation. */
export async function joinSquad(playerId: string, name: string): Promise<SquadDTO> {
  return joinSquadTransaction(playerId, name);
}

export type SquadJoinRequestDisposition = "join" | "request" | "reject";

/**
 * Resolve the stock private-Squad button without collapsing request-required and invite-only.
 *
 * The wire projection exposes both non-open policies as `IsPublic=0`, so the stock UI can send
 * JoinSquadRequest for either. Server state still owns the exact policy: open squads join directly,
 * a durable invitation is consumed through the normal join transaction, policy 1 may enqueue a
 * manager request, and policy 2 rejects an uninvited request instead of silently weakening its
 * invite-only contract.
 */
export function squadJoinRequestDisposition(
  squad: Pick<SquadDTO, "joinPolicy" | "invitedPlayerIds">,
  playerId: string,
): SquadJoinRequestDisposition {
  if (squad.joinPolicy === 0) return "join";
  if (squad.invitedPlayerIds.includes(playerId)) return "join";
  if (squad.joinPolicy === 1) return "request";
  if (squad.joinPolicy === 2) return "reject";
  throw new ApiError(ApiErrorCode.InternalServerError, "Stored squad join policy is invalid.");
}

export async function requestToJoin(playerId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad not found.");
  const disposition = squadJoinRequestDisposition(squad, playerId);
  if (disposition === "join") return joinSquad(playerId, name);
  if (disposition === "reject") {
    throw new ApiError(ApiErrorCode.SquadIsNotPublic, "This squad accepts invited players only.");
  }
  const player = await findById(playerId);
  if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  if (player.player.squadName) {
    throw new ApiError(ApiErrorCode.PlayerAlreadyInSquadCantJoin, "Player already belongs to a squad.");
  }
  if (squad.members.length >= squad.maxMembers) {
    throw new ApiError(ApiErrorCode.SquadIsFull, "Squad is full.");
  }
  if (player.player.skill < (squad.requiredMedals || 0)) {
    throw new ApiError(ApiErrorCode.NotEnoughSquadSkill, "Player does not meet the squad medal requirement.");
  }
  // A player has at most one pending request per squad. Repeated taps are idempotent and do
  // not grow the embedded request list or reset its original creation time.
  if (!squad.joinRequests.some((request) => request.playerId === playerId)) {
    if (squad.joinRequests.length >= SQUAD_MAX_PENDING_ADMISSIONS) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Squad join-request queue is full.");
    }
    squad.joinRequests.push({ playerId, name: player.player.accountName, createdAt: Date.now() });
    await persist(squad);
  }
  return squad;
}

export async function acceptJoinRequest(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  return joinSquadTransaction(targetId, name, actorId);
}

export interface DeclineSquadJoinRequestPlan {
  squad: SquadDTO;
  changed: boolean;
}

/** Validate current manager authority and remove at most the exact requested applicant. */
export function planDeclineSquadJoinRequest(
  squad: SquadDTO,
  actorId: string,
  targetId: string,
): DeclineSquadJoinRequestPlan {
  try {
    requireManager(squad, actorId);
  } catch (error) {
    if (error instanceof ApiError) {
      throw new ApiError(ApiErrorCode.NotLeaderOfSquad, "Only a squad manager can decline requests.");
    }
    throw error;
  }
  const joinRequests = squad.joinRequests.filter((request) => request.playerId !== targetId);
  return {
    squad: joinRequests.length === squad.joinRequests.length
      ? squad
      : { ...squad, joinRequests },
    changed: joinRequests.length !== squad.joinRequests.length,
  };
}

export async function declineJoinRequest(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad not found.");
  const plan = planDeclineSquadJoinRequest(squad, actorId, targetId);
  // A lost-response retry is already complete. Do not advance updatedAt for an identical result;
  // that false write could make an unrelated manager's fresh optimistic snapshot fail.
  if (!plan.changed) return plan.squad;
  await persist(plan.squad as SquadDocument);
  return plan.squad;
}

export async function invitePlayer(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad not found.");
  try {
    requireManager(squad, actorId);
  } catch (error) {
    if (error instanceof ApiError) {
      throw new ApiError(ApiErrorCode.OnlyLeaderCanSendInvites, "Only a squad manager can invite players.");
    }
    throw error;
  }
  if (!(await findById(targetId))) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  squad.invitedPlayerIds ??= [];
  if (!squad.invitedPlayerIds.includes(targetId)) {
    if (squad.invitedPlayerIds.length >= SQUAD_MAX_PENDING_ADMISSIONS) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Squad invitation queue is full.");
    }
    squad.invitedPlayerIds.push(targetId);
  }
  await persist(squad);
  return squad;
}

export interface SquadLeavePlan {
  squad: SquadDTO | null;
  squadWrite: "none" | "update" | "delete";
  playerMirrorChanged: boolean;
  departed: boolean;
}

function consistentPlayerSquadName(player: PlayerDocument): string {
  const names = [...new Set([player.squadName, player.player.squadName].filter((value) => Boolean(value)))];
  if (names.length > 1) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player squad mirrors conflict and require repair.");
  }
  return names[0] ?? "";
}

/** Calculate a replay-safe leave transition without mutating the supplied snapshots. */
export function planSquadLeave(
  squad: SquadDTO | null,
  player: PlayerDocument,
  requestedName: string,
): SquadLeavePlan {
  let mirrorName: string;
  try {
    mirrorName = consistentPlayerSquadName(player);
  } catch (error) {
    if (error instanceof ApiError) throw new ApiError(ApiErrorCode.SquadLeaveError, error.message);
    throw error;
  }
  const name = cleanName(requestedName) || mirrorName;
  if (mirrorName && name !== mirrorName) {
    // The old implementation cleared the real mirror when a modified client supplied any
    // nonexistent SquadId. Binding the request to current server state closes that corruption.
    throw new ApiError(ApiErrorCode.SquadLeaveError, "Leave request does not match the player's squad.");
  }
  if (squad && squad.name !== name) {
    throw new ApiError(ApiErrorCode.SquadLeaveError, "Leave request resolved to a different squad.");
  }

  const rosterMember = squad?.members.find((candidate) => candidate.playerId === player.id);
  if (rosterMember && squad?.founderId === player.id && squad.members.length > 1) {
    // A multi-member squad must always retain exactly one leader/founder. The explicit transfer
    // action updates both leaders together and is required before the founder may leave.
    throw new ApiError(ApiErrorCode.SquadLeaveError, "Transfer squad leadership before leaving.");
  }

  const playerMirrorChanged = Boolean(
    player.squadName
    || player.player.squadName
    || player.player.squadRank !== SquadRank.None,
  );
  if (!squad || !rosterMember) {
    // A retry after a committed leave is a success. If an older two-write implementation left
    // only the player mirror behind, clearing it repairs that safe direction of partial state.
    return {
      squad,
      squadWrite: "none",
      playerMirrorChanged,
      departed: playerMirrorChanged,
    };
  }

  if (squad.members.length === 1) {
    return { squad, squadWrite: "delete", playerMirrorChanged, departed: true };
  }
  return {
    squad: {
      ...squad,
      members: squad.members.filter((candidate) => candidate.playerId !== player.id),
    },
    squadWrite: "update",
    playerMirrorChanged,
    departed: true,
  };
}

export interface LeaveSquadResult {
  returnedCardIds: string[];
}

/** Atomically remove membership, clear mirrors/deposits, and reclaim normal deposited cards. */
export async function leaveSquad(playerId: string, requestedName: string): Promise<LeaveSquadResult> {
  const result = await withMongoTransaction(async (session) => {
    const player = await players().findOne({ id: playerId }, { session });
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    validatedPlayerAccountEnvelope(player);
    let mirrorName: string;
    try {
      mirrorName = consistentPlayerSquadName(player);
    } catch (error) {
      if (error instanceof ApiError) throw new ApiError(ApiErrorCode.SquadLeaveError, error.message);
      throw error;
    }
    const name = cleanName(requestedName) || mirrorName;
    const squad = name ? await squads().findOne({ name }, { session }) : null;
    if (squad) validatedSquadDocument(squad);
    const plan = planSquadLeave(squad, player, name);
    const now = squad ? nextSquadUpdatedAt(squad) : new Date();

    if (plan.squadWrite === "delete" && squad) {
      const deleted = await squads().deleteOne(
        { name: squad.name, updatedAt: squad.updatedAt },
        { session },
      );
      if (deleted.deletedCount !== 1) {
        throw new ApiError(ApiErrorCode.InternalServerError, "Squad departure changed concurrently.");
      }
    } else if (plan.squadWrite === "update" && squad && plan.squad) {
      validatedSquadDocument({ ...plan.squad, createdAt: squad.createdAt, updatedAt: now }, now);
      const updated = await squads().updateOne(
        { name: squad.name, updatedAt: squad.updatedAt },
        { $set: { members: plan.squad.members, updatedAt: now } },
        { session },
      );
      if (updated.modifiedCount !== 1) {
        throw new ApiError(ApiErrorCode.InternalServerError, "Squad departure changed concurrently.");
      }
    }

    // The stock confirmation dialog explicitly says that leaving forfeits the current reward and
    // that joining another squad does not grant a first-week reward. Persist that irreversible
    // round fact before clearing the player mirror; it commits or rolls back with membership.
    if (plan.departed && squad?.squadWarRoundId) {
      await invalidateSquadWarRewardEligibility(
        session,
        squad.squadWarRoundId,
        squad.name,
        player.id,
        now,
      );
    }

    const depositedCards = player.player.depositedCardsDic ?? {};
    const currentProgression = progressionForPlayer(player);
    const reclaim = reclaimDepositedCardsForDepartureState(
      currentProgression,
      depositedCards,
    );
    const progressionChanged = reclaim.state !== currentProgression;
    const shouldUpdatePlayer =
      plan.playerMirrorChanged
      || Object.keys(depositedCards).length > 0
      || progressionChanged;
    if (shouldUpdatePlayer) {
      const successor = progressionChanged
        ? validatedProgressionSuccessor(currentProgression, reclaim.state)
        : currentProgression;
      const { dogTags: _legacyDogTags, ...canonicalState } = successor;
      const updated = await players().updateOne(
        {
          id: player.id,
          squadName: player.squadName,
          "player.squadName": player.player.squadName,
          "player.squadRank": player.player.squadRank,
          ...(progressionChanged ? progressionRevisionFilter(player) : {}),
        },
        {
          $set: {
            ...(progressionChanged ? { progression: canonicalState } : {}),
            squadName: "",
            "player.squadName": "",
            "player.squadRank": SquadRank.None,
            "player.depositedCardsDic": {},
            updatedAt: now,
          },
        },
        { session },
      );
      if (updated.modifiedCount !== 1) {
        throw new ApiError(ApiErrorCode.InternalServerError, "Player departure state changed concurrently.");
      }
    }

    return { returnedCardIds: reclaim.returnedCardIds, departed: plan.departed, name };
  });

  if (result.departed) logger.squad.event("Player left squad", { name: result.name, playerId });
  return { returnedCardIds: result.returnedCardIds };
}

export interface SquadRankChangePlan {
  squad: SquadDTO;
  rank: SquadRank;
}

/** Apply one validated promotion/demotion step without mutating the supplied squad snapshot. */
export function planSquadRankChange(
  squad: SquadDTO,
  actorId: string,
  targetId: string,
  direction: "promote" | "demote",
): SquadRankChangePlan {
  const failureCode = direction === "promote"
    ? ApiErrorCode.PromotePlayerError
    : ApiErrorCode.DemotePlayerError;
  let actor: SquadMemberDTO;
  let target: SquadMemberDTO;
  try {
    actor = requireManager(squad, actorId);
    target = member(squad, targetId);
  } catch (error) {
    if (error instanceof ApiError) throw new ApiError(failureCode, error.message);
    throw error;
  }
  let next: SquadRank | null;
  if (direction === "promote") {
    // Promotions move one step and never reach Leader. Leadership has a separate founder-only
    // action, preventing a coleader from creating a second leader.
    next = target.rank === SquadRank.Member
      ? SquadRank.Veteran
      : target.rank === SquadRank.Veteran
        ? SquadRank.Coleader
        : null;
    if (next === null || squadRankAuthority(actor.rank) <= squadRankAuthority(next)) {
      throw new ApiError(failureCode, "Member cannot be promoted by this actor.");
    }
  } else {
    // An actor may affect only a strictly lower authority. Founder identity is checked in
    // addition to rank because a damaged legacy roster could contain the wrong founder rank.
    if (targetId === squad.founderId || squadRankAuthority(actor.rank) <= squadRankAuthority(target.rank)) {
      throw new ApiError(failureCode, "Member cannot be demoted by this actor.");
    }
    next = target.rank === SquadRank.Coleader
      ? SquadRank.Veteran
      : target.rank === SquadRank.Veteran
        ? SquadRank.Member
        : null;
    if (next === null) throw new ApiError(failureCode, "Member cannot be demoted further.");
  }

  return {
    squad: {
      ...squad,
      members: squad.members.map((candidate) =>
        candidate.playerId === targetId ? { ...candidate, rank: next! } : { ...candidate }),
    },
    rank: next,
  };
}

function requireCompatiblePlayerSquad(player: PlayerDocument, squadName: string): void {
  const mirrorName = consistentPlayerSquadName(player);
  if (mirrorName && mirrorName !== squadName) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player belongs to a different squad.");
  }
}

async function changeMemberRankTransaction(
  actorId: string,
  targetId: string,
  requestedName: string,
  direction: "promote" | "demote",
): Promise<SquadDTO> {
  const name = cleanName(requestedName);
  return withMongoTransaction(async (session) => {
    const [squad, targetPlayer] = await Promise.all([
      squads().findOne({ name }, { session }),
      players().findOne({ id: targetId }, { session }),
    ]);
    const failureCode = direction === "promote"
      ? ApiErrorCode.PromotePlayerError
      : ApiErrorCode.DemotePlayerError;
    if (!squad) throw new ApiError(failureCode, "Squad not found.");
    if (!targetPlayer) throw new ApiError(failureCode, "Squad member not found.");
    validatedSquadDocument(squad);
    validatedPlayerAccountEnvelope(targetPlayer);
    const plan = planSquadRankChange(squad, actorId, targetId, direction);
    try {
      requireCompatiblePlayerSquad(targetPlayer, squad.name);
    } catch (error) {
      if (error instanceof ApiError) throw new ApiError(failureCode, error.message);
      throw error;
    }
    const now = nextSquadUpdatedAt(squad);
    validatedSquadDocument({ ...plan.squad, createdAt: squad.createdAt, updatedAt: now }, now);

    const squadUpdate = await squads().updateOne(
      { name: squad.name, updatedAt: squad.updatedAt },
      { $set: { members: plan.squad.members, updatedAt: now } },
      { session },
    );
    if (squadUpdate.modifiedCount !== 1) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Squad rank changed concurrently.");
    }
    if (squad.squadWarRoundId) {
      await invalidateSquadWarRewardEligibility(
        session,
        squad.squadWarRoundId,
        squad.name,
        targetPlayer.id,
        now,
      );
    }
    const playerUpdate = await players().updateOne(
      {
        id: targetPlayer.id,
        squadName: targetPlayer.squadName,
        "player.squadName": targetPlayer.player.squadName,
        "player.squadRank": targetPlayer.player.squadRank,
      },
      {
        $set: {
          squadName: squad.name,
          "player.squadName": squad.name,
          "player.squadRank": plan.rank,
          updatedAt: now,
        },
      },
      { session },
    );
    if (playerUpdate.modifiedCount !== 1) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Player rank changed concurrently.");
    }
    return plan.squad;
  });
}

export async function promoteMember(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  return changeMemberRankTransaction(actorId, targetId, name, "promote");
}

export async function demoteMember(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  return changeMemberRankTransaction(actorId, targetId, name, "demote");
}

export interface LeadershipTransferPlan {
  squad: SquadDTO;
  formerLeaderRank: SquadRank.Veteran;
}

/** Reproduce the stock leadership callback's Leader -> Veteran transition. */
export function planLeadershipTransfer(squad: SquadDTO, actorId: string, targetId: string): LeadershipTransferPlan {
  if (squad.founderId !== actorId || actorId === targetId) {
    throw new ApiError(ApiErrorCode.PromoteToFounderError, "Only the squad leader can transfer leadership.");
  }
  try {
    member(squad, actorId);
    member(squad, targetId);
  } catch (error) {
    if (error instanceof ApiError) throw new ApiError(ApiErrorCode.PromoteToFounderError, error.message);
    throw error;
  }
  return {
    squad: {
      ...squad,
      founderId: targetId,
      members: squad.members.map((candidate) => {
        if (candidate.playerId === actorId) return { ...candidate, rank: SquadRank.Veteran };
        if (candidate.playerId === targetId) return { ...candidate, rank: SquadRank.Leader };
        return { ...candidate };
      }),
    },
    formerLeaderRank: SquadRank.Veteran,
  };
}

export async function transferLeadership(actorId: string, targetId: string, requestedName: string): Promise<SquadDTO> {
  const name = cleanName(requestedName);
  return withMongoTransaction(async (session) => {
    const [squad, actorPlayer, targetPlayer] = await Promise.all([
      squads().findOne({ name }, { session }),
      players().findOne({ id: actorId }, { session }),
      players().findOne({ id: targetId }, { session }),
    ]);
    if (!squad) throw new ApiError(ApiErrorCode.PromoteToFounderError, "Squad not found.");
    if (!actorPlayer || !targetPlayer) {
      throw new ApiError(ApiErrorCode.PromoteToFounderError, "Squad member not found.");
    }
    // Leadership changes publish two player rank mirrors with the roster. Validate both accounts
    // before the first cross-document write so a partial/damaged participant cannot inherit authority.
    validatedPlayerAccountEnvelope(actorPlayer);
    validatedPlayerAccountEnvelope(targetPlayer);
    validatedSquadDocument(squad);
    const plan = planLeadershipTransfer(squad, actorId, targetId);
    try {
      requireCompatiblePlayerSquad(actorPlayer, squad.name);
      requireCompatiblePlayerSquad(targetPlayer, squad.name);
    } catch (error) {
      if (error instanceof ApiError) throw new ApiError(ApiErrorCode.PromoteToFounderError, error.message);
      throw error;
    }
    const now = nextSquadUpdatedAt(squad);
    validatedSquadDocument({ ...plan.squad, createdAt: squad.createdAt, updatedAt: now }, now);

    const squadUpdate = await squads().updateOne(
      { name: squad.name, updatedAt: squad.updatedAt },
      {
        $set: {
          founderId: plan.squad.founderId,
          members: plan.squad.members,
          updatedAt: now,
        },
      },
      { session },
    );
    if (squadUpdate.modifiedCount !== 1) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Squad leadership changed concurrently.");
    }

    const updateMirror = async (player: PlayerDocument, rank: SquadRank): Promise<void> => {
      const update = await players().updateOne(
        {
          id: player.id,
          squadName: player.squadName,
          "player.squadName": player.player.squadName,
          "player.squadRank": player.player.squadRank,
        },
        {
          $set: {
            squadName: squad.name,
            "player.squadName": squad.name,
            "player.squadRank": rank,
            updatedAt: now,
          },
        },
        { session },
      );
      if (update.modifiedCount !== 1) {
        throw new ApiError(ApiErrorCode.InternalServerError, "Leadership mirror changed concurrently.");
      }
    };
    await updateMirror(actorPlayer, plan.formerLeaderRank);
    await updateMirror(targetPlayer, SquadRank.Leader);
    return plan.squad;
  });
}

export interface SquadKickPlan {
  squad: SquadDTO;
}

export function planSquadKick(squad: SquadDTO, actorId: string, targetId: string): SquadKickPlan {
  let actor: SquadMemberDTO;
  let target: SquadMemberDTO;
  try {
    actor = requireManager(squad, actorId);
    target = member(squad, targetId);
  } catch (error) {
    if (error instanceof ApiError) throw new ApiError(ApiErrorCode.KickPlayerError, error.message);
    throw error;
  }
  // Self-removal uses LeaveSquad, which enforces the founder rule. Kick is reserved for
  // strictly lower-ranked targets and can never remove the founder.
  if (targetId === actorId || targetId === squad.founderId || squadRankAuthority(actor.rank) <= squadRankAuthority(target.rank)) {
    throw new ApiError(ApiErrorCode.KickPlayerError, "Member cannot be removed by this actor.");
  }
  return {
    squad: {
      ...squad,
      members: squad.members.filter((candidate) => candidate.playerId !== targetId).map((candidate) => ({ ...candidate })),
    },
  };
}

export async function kickMember(actorId: string, targetId: string, requestedName: string): Promise<SquadDTO> {
  const name = cleanName(requestedName);
  const committed = await withMongoTransaction(async (session) => {
    const [squad, actorPlayer, targetPlayer] = await Promise.all([
      squads().findOne({ name }, { session }),
      players().findOne({ id: actorId }, { session }),
      players().findOne({ id: targetId }, { session }),
    ]);
    if (!squad) throw new ApiError(ApiErrorCode.KickPlayerError, "Squad not found.");
    if (!actorPlayer) throw new ApiError(ApiErrorCode.KickPlayerError, "Squad manager not found.");
    if (!targetPlayer) throw new ApiError(ApiErrorCode.KickPlayerError, "Squad member not found.");
    validatedSquadDocument(squad);
    validatedPlayerAccountEnvelope(actorPlayer);
    validatedPlayerAccountEnvelope(targetPlayer);
    const plan = planSquadKick(squad, actorId, targetId);
    try {
      requireCompatiblePlayerSquad(targetPlayer, squad.name);
    } catch (error) {
      if (error instanceof ApiError) throw new ApiError(ApiErrorCode.KickPlayerError, error.message);
      throw error;
    }
    const currentProgression = progressionForPlayer(targetPlayer);
    const reclaim = reclaimDepositedCardsForDepartureState(
      currentProgression,
      targetPlayer.player.depositedCardsDic ?? {},
    );
    const progressionChanged = reclaim.state !== currentProgression;
    const successor = progressionChanged
      ? validatedProgressionSuccessor(currentProgression, reclaim.state)
      : currentProgression;
    const { dogTags: _legacyDogTags, ...canonicalState } = successor;
    const now = nextSquadUpdatedAt(squad);
    validatedSquadDocument({ ...plan.squad, createdAt: squad.createdAt, updatedAt: now }, now);

    const squadUpdate = await squads().updateOne(
      { name: squad.name, updatedAt: squad.updatedAt },
      { $set: { members: plan.squad.members, updatedAt: now } },
      { session },
    );
    if (squadUpdate.modifiedCount !== 1) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Squad removal changed concurrently.");
    }
    const playerUpdate = await players().updateOne(
      {
        id: targetPlayer.id,
        squadName: targetPlayer.squadName,
        "player.squadName": targetPlayer.player.squadName,
        "player.squadRank": targetPlayer.player.squadRank,
        ...(progressionChanged ? progressionRevisionFilter(targetPlayer) : {}),
      },
      {
        $set: {
          ...(progressionChanged ? { progression: canonicalState } : {}),
          squadName: "",
          "player.squadName": "",
          "player.squadRank": SquadRank.None,
          "player.depositedCardsDic": {},
          updatedAt: now,
        },
      },
      { session },
    );
    if (playerUpdate.modifiedCount !== 1) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Removed player state changed concurrently.");
    }
    // Persist the recovered MessageType=3 payload in the same transaction as membership and
    // inventory. This is delivery for both connected and offline targets, not merely an audit
    // row: GetAllMessages converts it to the DynamoDB fields parsed by MBACFNICJPL.
    const message = buildSquadKickMessage(actorPlayer, targetPlayer, squad.name, reclaim.returnedCardIds, now);
    await messages().insertOne(message, { session });
    return { squad: plan.squad, message };
  });
  // Never publish from inside the transaction callback: withTransaction can retry that callback,
  // and a remote node must not observe a notice for a row that later rolls back. The wake-up is
  // deliberately best-effort after commit; the durable inbox row is the offline recovery path.
  await publishInboxFanout(committed.message.toPlayerId, committed.message.messageId);
  return committed.squad;
}

export interface UpdateSquadOptions {
  description?: string;
  joinPolicy?: number;
  requiredMedals?: number;
  emblem?: Record<string, unknown>;
}

export async function updateSquad(actorId: string, name: string, values: UpdateSquadOptions): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad not found.");
  try {
    requireManager(squad, actorId);
  } catch (error) {
    if (error instanceof ApiError) {
      throw new ApiError(ApiErrorCode.NotLeaderOfSquad, "Only a squad manager can update squad settings.");
    }
    throw error;
  }
  // Apply only fields explicitly present in the request. This patch behavior prevents an
  // emblem-only update from resetting the description, join policy, or medal requirement.
  if (values.description !== undefined) {
    const description = values.description.trim().replace(/\s+/gu, " ").slice(0, 250);
    if (/\p{Cc}/u.test(description)) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Squad description contains unsupported control characters.");
    }
    squad.description = description ? requireModeratedText(description, "Squad description") : "";
  }
  if (values.joinPolicy !== undefined) squad.joinPolicy = validatedSquadJoinPolicy(values.joinPolicy)!;
  if (values.requiredMedals !== undefined) {
    squad.requiredMedals = validatedSquadRequiredMedals(values.requiredMedals)!;
  }
  if (values.emblem !== undefined) squad.emblem = requestedSquadEmblem(values.emblem);
  await persist(squad);
  return squad;
}

/**
 * Select the global Squad leaderboard consumed by recovered action 101.
 *
 * The action name says `GetSquadsByExperience`, but `AllTimeContent.NCPEFJJFECF` re-sorts and
 * displays the parsed `Skill` field. `buildDatabaseSquad` maps that field from server-owned
 * `squadPoints`; preselecting a truncated page by `experience` could therefore omit the actual
 * highest-scoring squad before Unity receives the rows. Freeze the same score key here and use
 * the unique squad name as a stable tie-breaker. Every selected document is fully validated before
 * its score, roster size, or public settings can become a believable leaderboard row.
 */
export async function listByExperience(
  limit = 50,
  collection?: Collection<SquadDocument>,
): Promise<SquadDocument[]> {
  if (!Number.isSafeInteger(limit) || limit < 1 || limit > 100) {
    throw new Error("Squad leaderboard limit is invalid.");
  }
  const rows = await (collection ?? squads())
    .find()
    .sort({ squadPoints: -1, name: 1 })
    .limit(limit)
    .toArray();
  if (rows.length > limit) throw new Error("Squad leaderboard returned too many rows.");
  const now = new Date();
  for (let index = 0; index < rows.length; index += 1) {
    const row = validatedSquadDocument(rows[index]!, now);
    if (index > 0) {
      const previous = rows[index - 1]!;
      if (previous.squadPoints < row.squadPoints
        || (previous.squadPoints === row.squadPoints && previous.name >= row.name)) {
        throw new Error("Selected Squad leaderboard rows are not in authoritative rank order.");
      }
    }
  }
  return rows;
}

function validatedSquadReadLimit(limit: number, family: string): number {
  if (!Number.isSafeInteger(limit) || limit < 1 || limit > 100) {
    throw new Error(`${family} limit is invalid.`);
  }
  return limit;
}

/**
 * Resolve action 79's literal SquadNameStart contract.
 *
 * Search is intentionally a directory read, not an admission shortcut: full, private, or
 * medal-gated squads may still be found by name and the normal join/request path remains the sole
 * authority for membership. The anchored case-insensitive behavior matches the recovered field's
 * prefix meaning and the existing player-directory search contract.
 */
export async function searchSquadsByName(
  prefix: string,
  limit = 50,
  collection?: Collection<SquadDocument>,
): Promise<SquadDocument[]> {
  const exactLimit = validatedSquadReadLimit(limit, "Squad search");
  if (/\p{Cc}/u.test(prefix)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "SquadNameStart is invalid.");
  }
  const normalized = cleanName(prefix);
  if (normalized.length < 3 || normalized.length > 24 || /\p{Cc}/u.test(normalized)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "SquadNameStart is invalid.");
  }
  const escaped = normalized.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
  const rows = await (collection ?? squads())
    .find({ name: { $regex: `^${escaped}`, $options: "i" } })
    .sort({ name: 1 })
    .limit(exactLimit)
    .toArray();
  if (rows.length > exactLimit) throw new Error("Squad search returned too many rows.");
  const now = new Date();
  for (let index = 0; index < rows.length; index += 1) {
    const row = validatedSquadDocument(rows[index]!, now);
    if (!row.name.toLocaleLowerCase("en-US").startsWith(normalized.toLocaleLowerCase("en-US"))) {
      throw new Error("Selected Squad search row does not match the requested prefix.");
    }
    if (index > 0 && rows[index - 1]!.name >= row.name) {
      throw new Error("Selected Squad search rows are not in authoritative name order.");
    }
  }
  return rows;
}

/**
 * Return joinable action-81 recommendations using authenticated player authority.
 *
 * The stock caller sends `Skill`, but that number is only an assertion. The handler compares it
 * with the complete authenticated profile before this service runs. Recommendations include open
 * and request-required squads, exclude invite-only or full rosters, and keep the same recovered
 * Skill/squadPoints order used by the global board. Geographic local-vs-global membership was not
 * recovered, so callers explicitly publish IsLocal=false and let the stock UI use its global
 * fallback instead of inventing a country owner for a multi-member Squad.
 */
export async function suggestedSquads(
  player: PlayerDocument,
  limit = 20,
  collection?: Collection<SquadDocument>,
): Promise<SquadDocument[]> {
  const exactLimit = validatedSquadReadLimit(limit, "Suggested Squads");
  const authority = validatedPlayerAccountEnvelope(player);
  const skill = authority.player.skill;
  const rows = await (collection ?? squads())
    .find({
      joinPolicy: { $in: [0, 1] },
      requiredMedals: { $lte: skill },
      $expr: { $lt: [{ $size: "$members" }, "$maxMembers"] },
    })
    .sort({ squadPoints: -1, name: 1 })
    .limit(exactLimit)
    .toArray();
  if (rows.length > exactLimit) throw new Error("Suggested Squads returned too many rows.");
  const now = new Date();
  for (let index = 0; index < rows.length; index += 1) {
    const row = validatedSquadDocument(rows[index]!, now);
    if (row.joinPolicy === 2
      || row.requiredMedals > skill
      || row.members.length >= row.maxMembers) {
      throw new Error("Selected Suggested Squad is not eligible for the authenticated player.");
    }
    if (index > 0) {
      const previous = rows[index - 1]!;
      if (previous.squadPoints < row.squadPoints
        || (previous.squadPoints === row.squadPoints && previous.name >= row.name)) {
        throw new Error("Selected Suggested Squads are not in authoritative rank order.");
      }
    }
  }
  return rows;
}

export async function getSquadMemberPlayers(name: string) {
  const squad = await getByName(name);
  if (!squad) return [];
  const ids = squad.members.map((value) => value.playerId);
  const docs = await players().find({ id: { $in: ids } }).toArray();
  const byId = new Map(docs.map((doc) => [doc.id, doc]));
  // Preserve the squad roster order expected by the member screen. Return full documents so
  // the handler can apply the same DatabasePlayer wire adapter used by login and search.
  return ids.map((id) => byId.get(id)).filter((value) => value !== undefined);
}
