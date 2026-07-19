import {
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
import { reclaimDepositedCardsForDepartureState } from "./squadCardPoolService";
import logger from "../utils/logger";

/**
 * Squad membership, admission, rank authority, and denormalized player mirrors.
 *
 * `squads.members` is the membership source of truth. Squad name and rank are also copied to
 * each player document because the recovered client expects to render them from a standalone
 * DatabasePlayer response. Creation commits both documents and its WarBucks debit in one
 * transaction. The remaining membership mutations still change the squad first and player
 * mirror second; they must be migrated to the same transaction boundary before that mirror is
 * strongly consistent in a multi-instance production deployment.
 *
 * Admission capabilities are created only inside this service. A public join request cannot
 * set `allowPrivate`; only an already-authorized manager acceptance can pass it to `joinSquad`.
 * Rank checks use `squadRankAuthority` because the recovered wire enum is not ordered by
 * privilege: Leader(2) outranks Coleader(3), despite its smaller numeric value.
 */

function cleanName(name: string): string {
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
  if (result.matchedCount !== 1) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad no longer exists.");
}

export interface CreateSquadOptions {
  description?: string;
  emblem?: Record<string, unknown>;
  joinPolicy?: number;
  requiredMedals?: number;
}

/** IJEAJGCCHEF.NotEnoughWarBucksForCreateSquad; its parser restores count and wallet. */
export const SQUAD_CREATE_NOT_ENOUGH_WARBUCKS = 11403;

/**
 * Exact 4.9.5 `WarBucksCreateSquadPrice` Constants value.
 *
 * MainScene stores the CodeStage ObscuredFloat as hidden bytes `e785cb41` with key 230887.
 * Reading the bytes as little-endian and XORing the key yields IEEE-754 value 25.
 */
export const SQUAD_CREATE_BASE_WARBUCKS_COST = 25;

export interface SquadCreationEconomyResult {
  state: PlayerProgressionState;
  squadCreationsCount: number;
  warBucksSpent: number;
}

export interface CreateSquadResult extends SquadCreationEconomyResult {
  squad: SquadDTO;
}

/** Reproduce PlayerAnalytics.createSquadWarBucksPrice from server-owned creation history. */
export function squadCreationWarBucksPrice(squadCreationsCount: number): number {
  if (!Number.isSafeInteger(squadCreationsCount) || squadCreationsCount < 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad creation count is invalid.");
  }
  const price = (squadCreationsCount + 1) * SQUAD_CREATE_BASE_WARBUCKS_COST;
  if (!Number.isSafeInteger(price) || price <= 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad creation price is outside the safe range.");
  }
  return price;
}

/** Apply only the authoritative currency/count portion so it can be tested without MongoDB. */
export function applySquadCreationEconomyState(state: PlayerProgressionState): SquadCreationEconomyResult {
  const previousCount = state.squadCreationsCount ?? 0;
  const warBucksSpent = squadCreationWarBucksPrice(previousCount);
  if (state.warBucks < warBucksSpent) {
    throw new ApiError(SQUAD_CREATE_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks to create a squad.");
  }
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      warBucks: state.warBucks - warBucksSpent,
      squadCreationsCount: previousCount + 1,
    },
    squadCreationsCount: previousCount + 1,
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
  try {
    const result = await withMongoTransaction(async (session) => {
      const founder = await players().findOne({ id: founderId }, { session });
      if (!founder) throw new ApiError(ApiErrorCode.PlayerNotFound, "Founder not found.");
      if (founder.player.squadName) {
        throw new ApiError(ApiErrorCode.NotSquadMember, "Player already belongs to a squad.");
      }

      const economy = applySquadCreationEconomyState(progressionForPlayer(founder));
      const { dogTags: _legacyDogTags, ...canonicalState } = economy.state;

      // All initial values are derived or bounded on the server. In particular, the request
      // cannot choose its founder, inject members, or create an out-of-range join policy.
      const squad = newSquad(name, founderId);
      squad.description = options.description?.trim().slice(0, 250) ?? "";
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
    requireManager(squad, approvedBy);
    if (!(squad.joinRequests ?? []).some((request) => request.playerId === player.id)) {
      throw new ApiError(ApiErrorCode.NotSquadMember, "Join request not found.");
    }
  }

  const existingMember = squad.members.find((candidate) => candidate.playerId === player.id);
  const conflictingSquadName = [player.squadName, player.player.squadName]
    .find((candidate) => candidate && candidate !== squad.name);
  if (conflictingSquadName) {
    // A roster entry in one squad must never overwrite a player mirror already owned by a
    // different squad. Treat that as conflicting state and require an explicit repair.
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player already belongs to another squad.");
  }

  if (!existingMember) {
    if (squad.members.length >= (squad.maxMembers || 15)) {
      throw new ApiError(ApiErrorCode.SquadFull, "Squad is full.");
    }
    if (player.player.medalsBalance < (squad.requiredMedals || 0)) {
      throw new ApiError(ApiErrorCode.InsufficientRank, "Player does not meet the squad medal requirement.");
    }
    // Policy zero is open. A non-open squad requires either a persisted invitation or an
    // approval actor whose authority and pending request were verified above.
    const invited = (squad.invitedPlayerIds ?? []).includes(player.id);
    if (squad.joinPolicy !== 0 && !approvedBy && !invited) {
      throw new ApiError(ApiErrorCode.InsufficientRank, "This squad requires an invitation or approved request.");
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
    if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
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
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  if (squad.joinPolicy === 0) return joinSquad(playerId, name);
  const player = await findById(playerId);
  if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  if (player.player.squadName) throw new ApiError(ApiErrorCode.NotSquadMember, "Player already belongs to a squad.");
  if (squad.members.length >= (squad.maxMembers || 15)) throw new ApiError(ApiErrorCode.SquadFull, "Squad is full.");
  if (player.player.medalsBalance < (squad.requiredMedals || 0)) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Player does not meet the squad medal requirement.");
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
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  requireManager(squad, actorId);
  squad.joinRequests = squad.joinRequests.filter((request) => request.playerId !== targetId);
  await persist(squad);
  return squad;
}

export async function invitePlayer(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  requireManager(squad, actorId);
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
  const mirrorName = consistentPlayerSquadName(player);
  const name = cleanName(requestedName) || mirrorName;
  if (mirrorName && name !== mirrorName) {
    // The old implementation cleared the real mirror when a modified client supplied any
    // nonexistent SquadId. Binding the request to current server state closes that corruption.
    throw new ApiError(ApiErrorCode.NotSquadMember, "Leave request does not match the player's squad.");
  }
  if (squad && squad.name !== name) {
    throw new ApiError(ApiErrorCode.SquadNotFound, "Leave request resolved to a different squad.");
  }

  const rosterMember = squad?.members.find((candidate) => candidate.playerId === player.id);
  if (rosterMember && squad?.founderId === player.id && squad.members.length > 1) {
    // A multi-member squad must always retain exactly one leader/founder. The explicit transfer
    // action updates both leaders together and is required before the founder may leave.
    throw new ApiError(ApiErrorCode.InsufficientRank, "Transfer squad leadership before leaving.");
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
    const mirrorName = consistentPlayerSquadName(player);
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

    const depositedCards = player.player.depositedCardsDic ?? {};
    const reclaim = reclaimDepositedCardsForDepartureState(
      progressionForPlayer(player),
      depositedCards,
    );
    const progressionChanged = reclaim.state !== player.progression
      && reclaim.returnedCardIds.length > 0;
    const shouldUpdatePlayer =
      plan.playerMirrorChanged
      || Object.keys(depositedCards).length > 0
      || progressionChanged;
    if (shouldUpdatePlayer) {
      const { dogTags: _legacyDogTags, ...canonicalState } = reclaim.state;
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

export async function promoteMember(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  const actor = requireManager(squad, actorId);
  const target = member(squad, targetId);
  // Promotions move one step only and never reach Leader. Leadership has a separate founder-
  // only transfer action, which prevents a coleader from creating a second leader.
  const next = target.rank === SquadRank.Member ? SquadRank.Veteran : target.rank === SquadRank.Veteran ? SquadRank.Coleader : null;
  if (next === null || squadRankAuthority(actor.rank) <= squadRankAuthority(next)) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Member cannot be promoted by this actor.");
  }
  target.rank = next;
  await persist(squad);
  await updatePlayerFields(targetId, { squadRank: next });
  return squad;
}

export async function demoteMember(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  const actor = requireManager(squad, actorId);
  const target = member(squad, targetId);
  // An actor may affect only a strictly lower authority. The founder is protected even if a
  // legacy document contains an incorrect mirrored rank.
  if (targetId === squad.founderId || squadRankAuthority(actor.rank) <= squadRankAuthority(target.rank)) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Member cannot be demoted by this actor.");
  }
  const next = target.rank === SquadRank.Coleader ? SquadRank.Veteran : target.rank === SquadRank.Veteran ? SquadRank.Member : null;
  if (next === null) throw new ApiError(ApiErrorCode.InsufficientRank, "Member cannot be demoted further.");
  target.rank = next;
  await persist(squad);
  await updatePlayerFields(targetId, { squadRank: next });
  return squad;
}

export async function transferLeadership(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  if (squad.founderId !== actorId || actorId === targetId) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Only the squad leader can transfer leadership.");
  }
  // Update the roster ranks and founderId in one squad-document write, then synchronize both
  // player mirrors. This preserves one authoritative leader in the squad document even if a
  // later mirror write needs operational repair.
  const actor = member(squad, actorId);
  const target = member(squad, targetId);
  actor.rank = SquadRank.Coleader;
  target.rank = SquadRank.Leader;
  squad.founderId = targetId;
  await persist(squad);
  await Promise.all([
    updatePlayerFields(actorId, { squadRank: SquadRank.Coleader }),
    updatePlayerFields(targetId, { squadRank: SquadRank.Leader }),
  ]);
  return squad;
}

export async function kickMember(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  const actor = requireManager(squad, actorId);
  const target = member(squad, targetId);
  // Self-removal uses LeaveSquad, which enforces the founder rule. Kick is reserved for
  // strictly lower-ranked targets and can never remove the founder.
  if (targetId === actorId || targetId === squad.founderId || squadRankAuthority(actor.rank) <= squadRankAuthority(target.rank)) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Member cannot be removed by this actor.");
  }
  squad.members = squad.members.filter((candidate) => candidate.playerId !== targetId);
  await persist(squad);
  await updatePlayerFields(targetId, { squadName: "", squadRank: SquadRank.None });
  return squad;
}

export interface UpdateSquadOptions {
  description?: string;
  joinPolicy?: number;
  requiredMedals?: number;
  emblem?: Record<string, unknown>;
}

export async function updateSquad(actorId: string, name: string, values: UpdateSquadOptions): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  requireManager(squad, actorId);
  // Apply only fields explicitly present in the request. This patch behavior prevents an
  // emblem-only update from resetting the description, join policy, or medal requirement.
  if (values.description !== undefined) squad.description = values.description.trim().slice(0, 250);
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
