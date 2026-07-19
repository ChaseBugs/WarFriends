import { players, squads, type PlayerDocument } from "../db";
import { RedisKeys } from "../constants";
import { config } from "../config";
import { redisZRevRange, redisZAdd } from "../redis";

// Leaderboards (BACKEND.md §2.4). MongoDB is authoritative (indexed on experience); Redis
// sorted sets act as a short-TTL cache. Every entry is projected to the shape the client's
// ServerResultsCache expects for player/squad leaderboard reads.

export interface LeaderboardEntry {
  id: string;
  Name: string;
  Experience: number;
  Level: number;
  ArmyPower: number;
  LeagueId: string;
  SquadId: string;
}

function toEntry(doc: PlayerDocument): LeaderboardEntry {
  return {
    id: doc.id,
    Name: doc.player.accountName,
    Experience: doc.player.experience,
    Level: doc.player.level,
    ArmyPower: doc.player.armyPower,
    LeagueId: doc.player.leagueId,
    SquadId: doc.player.squadName,
  };
}

export async function topPlayersByExperience(limit = 100): Promise<LeaderboardEntry[]> {
  const docs = await players().find().sort({ experience: -1 }).limit(limit).toArray();
  // Warm the Redis cache opportunistically (no-op when Redis is disabled).
  for (const d of docs) void redisZAdd(RedisKeys.leaderboardExperience, d.experience, d.id);
  return docs.map(toEntry);
}

/** 1-based global rank by experience (players strictly ahead + 1). */
export async function playerRank(playerId: string): Promise<number> {
  const doc = await players().findOne({ id: playerId });
  if (!doc) return 0;
  const ahead = await players().countDocuments({ experience: { $gt: doc.experience } });
  return ahead + 1;
}

export interface SquadLeaderboardEntry {
  Name: string;
  Experience: number;
  SquadPoints: number;
  Level: number;
  Members: number;
}

export async function topSquads(limit = 100): Promise<SquadLeaderboardEntry[]> {
  const docs = await squads().find().sort({ experience: -1 }).limit(limit).toArray();
  return docs.map((s) => ({
    Name: s.name,
    Experience: s.experience,
    SquadPoints: s.squadPoints,
    Level: s.level,
    Members: s.members.length,
  }));
}

/** Cached top-N ids from Redis if available (else null → caller uses Mongo). */
export async function cachedTopPlayerIds(limit = 100): Promise<string[] | null> {
  const flat = await redisZRevRange(RedisKeys.leaderboardExperience, limit);
  if (!flat) return null;
  // WITHSCORES returns [member, score, member, score, ...]; keep members only.
  const ids: string[] = [];
  for (let i = 0; i < flat.length; i += 2) ids.push(flat[i]!);
  return ids;
}

export const leaderboardCacheTtl = config.redisLeaderboardTtl;
