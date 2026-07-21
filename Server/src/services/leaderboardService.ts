import { players, squads, type PlayerDocument } from "../db";
import { RedisKeys } from "../constants";
import { config } from "../config";
import { redisZRevRange, redisZAdd } from "../redis";
import { numberAttribute, progressionForPlayer } from "./playerStateService";
import { buildDatabaseSquad } from "./squadWireService";
import { serializeWarArenaData } from "./warArenaContract";

// MongoDB is authoritative; Redis is only an opportunistic rank cache. Wire conversion is
// performed here because the experience leaderboard uses FHIPGDADNFG, which has different
// field names from DatabasePlayer even though both describe the same account.

type StringAttribute = { S: string };
type NumberAttribute = { N: string };
export type PlayerLeaderboardItem = Record<string, StringAttribute | NumberAttribute>;

function s(value: unknown): StringAttribute {
  return { S: String(value ?? "") };
}

/** Build the exact item parsed by FHIPGDADNFG.MAINIENLLIL. */
export function buildPlayerLeaderboardItem(doc: PlayerDocument, position: number): PlayerLeaderboardItem {
  const player = doc.player;
  const progression = progressionForPlayer(doc);
  const item: PlayerLeaderboardItem = {
    PlayerId: s(player.id),
    PlayerName: s(player.accountName),
    Experience: numberAttribute(player.experience),
    Level: numberAttribute(player.level),
    LevelExperience: numberAttribute(progression.levelExperience),
    ArmyPower: numberAttribute(player.armyPower),
    Skill: numberAttribute(player.skill),
    Position: numberAttribute(position),
    Country: s(player.country),
    DecalManagerData: s(JSON.stringify({
      slots: progression.visualInventory?.slots ?? player.playerVisuals,
    })),
  };
  if (player.facebookId !== -1) item.FacebookId = s(player.facebookId);
  if (player.squadName) item.SquadId = s(player.squadName);
  if (player.leagueId) item.LeagueId = s(player.leagueId);
  else item.BeginnersLeague = numberAttribute(player.beginnersLeague);
  return item;
}

export async function topPlayersByExperience(limit = 100, country?: string): Promise<PlayerLeaderboardItem[]> {
  const filter = country ? { "player.country": country } : {};
  const docs = await players().find(filter).sort({ experience: -1 }).limit(limit).toArray();
  if (!country) {
    // Cache warming is deliberately fire-and-forget: a Redis outage must never make the
    // authoritative MongoDB leaderboard unavailable.
    for (const doc of docs) void redisZAdd(RedisKeys.leaderboardExperience, doc.experience, doc.id);
  }
  return docs.map((doc, index) => buildPlayerLeaderboardItem(doc, index + 1));
}

/**
 * Build the FHIPGDADNFG item used by GEKJKNLPJIL's Arena leaderboard parser.
 * The parser reuses normal player fields and additionally deserializes the exact string
 * attribute `WarArenaData`; a bare object or different key silently loses crown/run data.
 */
export function buildArenaLeaderboardItem(doc: PlayerDocument, position: number): PlayerLeaderboardItem {
  const item = buildPlayerLeaderboardItem(doc, position);
  const arena = progressionForPlayer(doc).warArena;
  if (arena) item.WarArenaData = s(serializeWarArenaData(arena));
  return item;
}

export async function topArenaPlayers(limit = 100): Promise<PlayerLeaderboardItem[]> {
  const docs = await players()
    .find({ "progression.warArena.played": true })
    .sort({
      "progression.warArena.topRun": -1,
      "progression.warArena.flawless": -1,
      "progression.warArena.wins": -1,
      updatedAt: 1,
    })
    .limit(limit)
    .toArray();
  return docs.map((doc, index) => buildArenaLeaderboardItem(doc, index + 1));
}

/** 1-based global rank by experience (players strictly ahead plus one). */
export async function playerRank(playerId: string): Promise<number> {
  const doc = await players().findOne({ id: playerId });
  if (!doc) return 0;
  const ahead = await players().countDocuments({ experience: { $gt: doc.experience } });
  return ahead + 1;
}

export async function topSquads(limit = 100): Promise<Record<string, unknown>[]> {
  const docs = await squads().find().sort({ experience: -1 }).limit(limit).toArray();
  return docs.map(buildDatabaseSquad);
}

/** Cached top-N ids from Redis if available; callers fall back to MongoDB on null. */
export async function cachedTopPlayerIds(limit = 100): Promise<string[] | null> {
  const flat = await redisZRevRange(RedisKeys.leaderboardExperience, limit);
  if (!flat) return null;
  const ids: string[] = [];
  for (let i = 0; i < flat.length; i += 2) ids.push(flat[i]!);
  return ids;
}

export const leaderboardCacheTtl = config.redisLeaderboardTtl;
