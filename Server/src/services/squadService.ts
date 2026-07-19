import { players, squads, type SquadDocument } from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { SquadRank } from "../constants";
import { newSquad, type SquadDTO, type SquadMemberDTO } from "../dtos";
import { findById, updatePlayerFields } from "./playerService";
import logger from "../utils/logger";

/**
 * Squad membership, admission, rank authority, and denormalized player mirrors.
 *
 * `squads.members` is the membership source of truth. Squad name and rank are also copied to
 * each player document because the recovered client expects to render them from a standalone
 * DatabasePlayer response. Every mutation therefore changes the squad document first and the
 * player mirror second. Those writes are intentionally visible here: a multi-instance
 * production deployment should wrap them in a MongoDB transaction or add an idempotent repair
 * worker before treating the mirror as strongly consistent.
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

export async function createSquad(founderId: string, requestedName: string, options: CreateSquadOptions = {}): Promise<SquadDTO> {
  const name = cleanName(requestedName);
  if (name.length < 3 || name.length > 24) {
    throw new ApiError(ApiErrorCode.SquadNotFound, "Squad name must be between 3 and 24 characters.");
  }
  const founder = await findById(founderId);
  if (!founder) throw new ApiError(ApiErrorCode.PlayerNotFound, "Founder not found.");
  if (founder.player.squadName) throw new ApiError(ApiErrorCode.NotSquadMember, "Player already belongs to a squad.");

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
  try {
    // The unique database index is the final arbiter for simultaneous create requests. The
    // separate availability action is only UI feedback and must never be trusted as a lock.
    await squads().insertOne({ ...squad, createdAt: now, updatedAt: now } as SquadDocument);
  } catch (error) {
    if ((error as { code?: number }).code === 11000) {
      throw new ApiError(ApiErrorCode.SquadNameTaken, "Squad name already taken.");
    }
    throw error;
  }

  await updatePlayerFields(founderId, { squadName: name, squadRank: SquadRank.Leader });
  logger.squad.event("Squad created", { name, founderId });
  return squad;
}

export async function joinSquad(playerId: string, name: string, allowPrivate = false): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  if (squad.members.some((candidate) => candidate.playerId === playerId)) return squad;

  const player = await findById(playerId);
  if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  if (player.player.squadName && player.player.squadName !== squad.name) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player already belongs to another squad.");
  }
  if (squad.members.length >= (squad.maxMembers || 15)) throw new ApiError(ApiErrorCode.SquadFull, "Squad is full.");
  if (player.player.medalsBalance < (squad.requiredMedals || 0)) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Player does not meet the squad medal requirement.");
  }
  // joinPolicy 0 is open. Non-open squads require either a stored invitation or the
  // `allowPrivate` capability passed only by the manager-controlled accept-request path.
  // The public JoinSquad handler never obtains that capability from request data.
  const invited = (squad.invitedPlayerIds ?? []).includes(playerId);
  if (squad.joinPolicy !== 0 && !allowPrivate && !invited) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "This squad requires an invitation or approved request.");
  }

  squad.members.push({
    playerId,
    name: player.player.accountName,
    rank: SquadRank.Member,
    squadPoints: player.player.squadPoints,
    joinedAt: Date.now(),
    lastSeenChatTimestamp: 0,
  });
  // Membership consumes all pending admission state. Leaving these entries behind would
  // let a later manager action replay an already accepted application or invitation.
  squad.joinRequests = (squad.joinRequests ?? []).filter((request) => request.playerId !== playerId);
  squad.invitedPlayerIds = (squad.invitedPlayerIds ?? []).filter((id) => id !== playerId);
  await persist(squad);
  await updatePlayerFields(playerId, { squadName: squad.name, squadRank: SquadRank.Member });
  logger.squad.event("Player joined squad", { name: squad.name, playerId });
  return squad;
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
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  requireManager(squad, actorId);
  if (!squad.joinRequests.some((request) => request.playerId === targetId)) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Join request not found.");
  }
  // `true` is a service-internal authorization result, not a client-controlled privacy
  // override. joinSquad still repeats capacity, medal, and existing-membership validation
  // because those facts may have changed while the request was waiting.
  return joinSquad(targetId, squad.name, true);
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

export async function leaveSquad(playerId: string, name: string): Promise<void> {
  const squad = await getByName(name);
  if (!squad) {
    await updatePlayerFields(playerId, { squadName: "", squadRank: SquadRank.None });
    return;
  }
  if (!squad.members.some((candidate) => candidate.playerId === playerId)) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not a squad member.");
  }
  // A multi-member squad must always retain exactly one leader/founder. Requiring an explicit
  // transfer avoids silently promoting a member with surprising authority.
  if (squad.founderId === playerId && squad.members.length > 1) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Transfer squad leadership before leaving.");
  }
  if (squad.members.length === 1) await squads().deleteOne({ name: squad.name });
  else {
    squad.members = squad.members.filter((candidate) => candidate.playerId !== playerId);
    await persist(squad);
  }
  await updatePlayerFields(playerId, { squadName: "", squadRank: SquadRank.None });
  logger.squad.event("Player left squad", { name: squad.name, playerId });
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
