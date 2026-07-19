import { squads, type SquadDocument } from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { SquadRank } from "../constants";
import { newSquad, type SquadDTO, type SquadMemberDTO } from "../dtos";
import { findById, savePlayer } from "./playerService";
import logger from "../utils/logger";

// Squad lifecycle — BACKEND.md §2.5. Squad membership is authoritative here (squads.members)
// and denormalized onto the player (player.squadName/squadRank) for the client's menu reads.

export async function isNameAvailable(name: string): Promise<boolean> {
  const existing = await squads().findOne({ name });
  return existing === null;
}

export async function getByName(name: string): Promise<SquadDocument | null> {
  return squads().findOne({ name });
}

async function persist(squad: SquadDTO): Promise<void> {
  await squads().updateOne({ name: squad.name }, { $set: { ...squad, updatedAt: new Date() } });
}

export async function createSquad(founderId: string, name: string): Promise<SquadDTO> {
  if (!name || name.trim().length === 0) {
    throw new ApiError(ApiErrorCode.SquadNotFound, "Squad name required.");
  }
  if (!(await isNameAvailable(name))) {
    throw new ApiError(ApiErrorCode.SquadNameTaken, "Squad name already taken.");
  }
  const founder = await findById(founderId);
  if (!founder) throw new ApiError(ApiErrorCode.PlayerNotFound, "Founder not found.");

  const squad = newSquad(name, founderId);
  squad.members.push({
    playerId: founderId,
    name: founder.player.accountName,
    rank: SquadRank.Founder,
    squadPoints: founder.player.squadPoints,
    joinedAt: Date.now(),
    lastSeenChatTimestamp: 0,
  });

  const now = new Date();
  await squads().insertOne({ ...squad, createdAt: now, updatedAt: now } as SquadDocument);

  founder.player.squadName = name;
  founder.player.squadRank = SquadRank.Founder;
  await savePlayer(founderId, founder.player);

  logger.squad.event("Squad created", { name, founderId });
  return squad;
}

export async function joinSquad(playerId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  if (squad.members.some((m) => m.playerId === playerId)) return squad;

  const player = await findById(playerId);
  if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");

  const member: SquadMemberDTO = {
    playerId,
    name: player.player.accountName,
    rank: SquadRank.Member,
    squadPoints: player.player.squadPoints,
    joinedAt: Date.now(),
    lastSeenChatTimestamp: 0,
  };
  squad.members.push(member);
  squad.joinRequests = squad.joinRequests.filter((r) => r.playerId !== playerId);
  await persist(squad);

  player.player.squadName = name;
  player.player.squadRank = SquadRank.Member;
  await savePlayer(playerId, player.player);

  logger.squad.event("Player joined squad", { name, playerId });
  return squad;
}

export async function leaveSquad(playerId: string, name: string): Promise<void> {
  const squad = await getByName(name);
  if (!squad) return;
  squad.members = squad.members.filter((m) => m.playerId !== playerId);
  await persist(squad);

  const player = await findById(playerId);
  if (player) {
    player.player.squadName = "";
    player.player.squadRank = SquadRank.Member;
    await savePlayer(playerId, player.player);
  }
  logger.squad.event("Player left squad", { name, playerId });
}

/** Rank change guarded by the actor's own rank. */
export async function setMemberRank(
  actorId: string,
  targetId: string,
  name: string,
  rank: SquadRank,
): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");

  const actor = squad.members.find((m) => m.playerId === actorId);
  if (!actor || actor.rank < SquadRank.Leader) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Insufficient rank.");
  }
  const target = squad.members.find((m) => m.playerId === targetId);
  if (!target) throw new ApiError(ApiErrorCode.NotSquadMember, "Target is not a squad member.");

  target.rank = rank;
  await persist(squad);

  const targetPlayer = await findById(targetId);
  if (targetPlayer) {
    targetPlayer.player.squadRank = rank;
    await savePlayer(targetId, targetPlayer.player);
  }
  logger.squad.event("Member rank changed", { name, actorId, targetId, rank });
  return squad;
}

export async function kickMember(actorId: string, targetId: string, name: string): Promise<SquadDTO> {
  const squad = await getByName(name);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  const actor = squad.members.find((m) => m.playerId === actorId);
  if (!actor || actor.rank < SquadRank.Officer) {
    throw new ApiError(ApiErrorCode.InsufficientRank, "Insufficient rank to kick.");
  }
  await leaveSquad(targetId, name);
  return (await getByName(name)) ?? squad;
}

export async function listByExperience(limit = 50): Promise<SquadDocument[]> {
  return squads().find().sort({ experience: -1 }).limit(limit).toArray();
}
