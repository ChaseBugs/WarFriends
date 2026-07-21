import {
  messages,
  players,
  squads,
  withMongoTransaction,
  type PlayerDocument,
  type PlayerProgressionState,
  type SquadDocument,
} from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { SquadRank } from "../constants";
import { newSquad, type SquadDTO, type SquadMemberDTO } from "../dtos";
import { findById, updatePlayerFields } from "./playerService";
import { progressionForPlayer } from "./playerStateService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { reclaimDepositedCardsForDepartureState } from "./squadCardPoolService";
import { buildSquadKickMessage } from "./socialService";
import logger from "../utils/logger";
import { requireModeratedText } from "./textModerationService";
import { invalidateSquadWarRewardEligibility } from "./squadWarService";
import {
  SQUAD_CREATE_BASE_WARBUCKS_COST,
  squadCreationWarBucksPrice,
  validatedSquadCreationsCount,
} from "./squadCreationAuthorityService";

export {
  SQUAD_CREATE_BASE_WARBUCKS_COST,
  squadCreationWarBucksPrice,
  validatedSquadCreationsCount,
} from "./squadCreationAuthorityService";

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
  return normalized ? squads().findOne({ name: normalized }) : null;
}

async function persist(squad: SquadDTO): Promise<void> {
  // Match by the immutable squad name and require an existing document. Silently upserting
  // here would allow a delayed mutation to recreate a squad after its last member left.
  const result = await squads().updateOne({ name: squad.name }, { $set: { ...squad, updatedAt: new Date() } });
  if (result.matchedCount !== 1) {
    throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad no longer exists.");
  }
}

export interface CreateSquadOptions {
  description?: string;
  emblem?: Record<string, unknown>;
  joinPolicy?: number;
  requiredMedals?: number;
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
  if (name.length < 3 || name.length > 24) {
    throw new ApiError(ApiErrorCode.SquadNotFound, "Squad name must be between 3 and 24 characters.");
  }
  requireModeratedText(name, "Squad name");
  try {
    const result = await withMongoTransaction(async (session) => {
      const founder = await players().findOne({ id: founderId }, { session });
      if (!founder) throw new ApiError(ApiErrorCode.PlayerNotFound, "Founder not found.");
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
      const description = options.description?.trim().slice(0, 250) ?? "";
      squad.description = description ? requireModeratedText(description, "Squad description") : "";
      squad.emblem = options.emblem ?? {};
      squad.joinPolicy = options.joinPolicy === 1 || options.joinPolicy === 2 ? options.joinPolicy : 0;
      squad.requiredMedals = Math.max(0, Math.floor(options.requiredMedals ?? 0));
      squad.members.push({
        playerId: founderId,
        name: founder.player.accountName,
        rank: SquadRank.Leader,
        squadPoints: founder.player.squadPoints,
        joinedAt: Date.now(),
        lastSeenChatTimestamp: 0,
      });

      const now = new Date();
      // The unique index is the final arbiter for simultaneous create requests. The separate
      // availability action is UI feedback only and is never trusted as a reservation.
      await squads().insertOne({ ...squad, createdAt: now, updatedAt: now } as SquadDocument, { session });

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
    if (squad.members.length >= (squad.maxMembers || 15)) {
      throw new ApiError(ApiErrorCode.SquadIsFull, "Squad is full.");
    }
    if (player.player.medalsBalance < (squad.requiredMedals || 0)) {
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

    const plan = planSquadJoin(squad, player, approvedBy);
    const now = new Date();
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

export async function requestToJoin(playerId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad not found.");
  if (squad.joinPolicy === 0) return joinSquad(playerId, name);
  const player = await findById(playerId);
  if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  if (player.player.squadName) {
    throw new ApiError(ApiErrorCode.PlayerAlreadyInSquadCantJoin, "Player already belongs to a squad.");
  }
  if (squad.members.length >= (squad.maxMembers || 15)) {
    throw new ApiError(ApiErrorCode.SquadIsFull, "Squad is full.");
  }
  if (player.player.medalsBalance < (squad.requiredMedals || 0)) {
    throw new ApiError(ApiErrorCode.NotEnoughSquadSkill, "Player does not meet the squad medal requirement.");
  }
  // A player has at most one pending request per squad. Repeated taps are idempotent and do
  // not grow the embedded request list or reset its original creation time.
  if (!squad.joinRequests.some((request) => request.playerId === playerId)) {
    squad.joinRequests.push({ playerId, name: player.player.accountName, createdAt: Date.now() });
    await persist(squad);
  }
  return squad;
}

export async function acceptJoinRequest(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  return joinSquadTransaction(targetId, name, actorId);
}

export async function declineJoinRequest(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad not found.");
  try {
    requireManager(squad, actorId);
  } catch (error) {
    if (error instanceof ApiError) {
      throw new ApiError(ApiErrorCode.NotLeaderOfSquad, "Only a squad manager can decline requests.");
    }
    throw error;
  }
  squad.joinRequests = squad.joinRequests.filter((request) => request.playerId !== targetId);
  await persist(squad);
  return squad;
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
  if (!squad.invitedPlayerIds.includes(targetId)) squad.invitedPlayerIds.push(targetId);
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
    let mirrorName: string;
    try {
      mirrorName = consistentPlayerSquadName(player);
    } catch (error) {
      if (error instanceof ApiError) throw new ApiError(ApiErrorCode.SquadLeaveError, error.message);
      throw error;
    }
    const name = cleanName(requestedName) || mirrorName;
    const squad = name ? await squads().findOne({ name }, { session }) : null;
    const plan = planSquadLeave(squad, player, name);
    const now = new Date();

    if (plan.squadWrite === "delete" && squad) {
      const deleted = await squads().deleteOne(
        { name: squad.name, updatedAt: squad.updatedAt },
        { session },
      );
      if (deleted.deletedCount !== 1) {
        throw new ApiError(ApiErrorCode.InternalServerError, "Squad departure changed concurrently.");
      }
    } else if (plan.squadWrite === "update" && squad && plan.squad) {
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
    const plan = planSquadRankChange(squad, actorId, targetId, direction);
    try {
      requireCompatiblePlayerSquad(targetPlayer, squad.name);
    } catch (error) {
      if (error instanceof ApiError) throw new ApiError(failureCode, error.message);
      throw error;
    }
    const now = new Date();

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
    const plan = planLeadershipTransfer(squad, actorId, targetId);
    try {
      requireCompatiblePlayerSquad(actorPlayer, squad.name);
      requireCompatiblePlayerSquad(targetPlayer, squad.name);
    } catch (error) {
      if (error instanceof ApiError) throw new ApiError(ApiErrorCode.PromoteToFounderError, error.message);
      throw error;
    }
    const now = new Date();

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
  return withMongoTransaction(async (session) => {
    const [squad, actorPlayer, targetPlayer] = await Promise.all([
      squads().findOne({ name }, { session }),
      players().findOne({ id: actorId }, { session }),
      players().findOne({ id: targetId }, { session }),
    ]);
    if (!squad) throw new ApiError(ApiErrorCode.KickPlayerError, "Squad not found.");
    if (!actorPlayer) throw new ApiError(ApiErrorCode.KickPlayerError, "Squad manager not found.");
    if (!targetPlayer) throw new ApiError(ApiErrorCode.KickPlayerError, "Squad member not found.");
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
    const now = new Date();

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
    await messages().insertOne(
      buildSquadKickMessage(actorPlayer, targetPlayer, squad.name, reclaim.returnedCardIds, now),
      { session },
    );
    return plan.squad;
  });
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
    const description = values.description.trim().slice(0, 250);
    squad.description = description ? requireModeratedText(description, "Squad description") : "";
  }
  if (values.joinPolicy === 0 || values.joinPolicy === 1 || values.joinPolicy === 2) squad.joinPolicy = values.joinPolicy;
  if (values.requiredMedals !== undefined) squad.requiredMedals = Math.max(0, Math.floor(values.requiredMedals));
  if (values.emblem !== undefined) squad.emblem = values.emblem;
  await persist(squad);
  return squad;
}

export async function listByExperience(limit = 50): Promise<SquadDocument[]> {
  return squads().find().sort({ experience: -1 }).limit(Math.min(Math.max(limit, 1), 100)).toArray();
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
