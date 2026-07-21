import type { Collection, Document } from "mongodb";
import { players, squads, type PlayerDocument } from "../db";
import { RedisKeys } from "../constants";
import { redisReplaceSortedSet, redisZRevRange } from "../redis";
import { progressionForPlayer } from "./playerStateService";
import { integerNumberAttribute as numberAttribute } from "./dynamoNumberAttributeService";
import {
  validatedPlayerAccountEnvelope,
  validatedPlayerProfileLookup,
} from "./playerProfileMirrorAuthorityService";
import { buildDatabaseSquad } from "./squadWireService";
import { currentArenaId, serializeWarArenaData } from "./warArenaContract";
import { validatedSquadDocument } from "./squadAuthorityService";
import { leaderboardCachePolicy } from "./leaderboardCachePolicyService";

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
  // Leaderboard rows are public account projections, not anonymous score fragments. Validate the
  // complete account before publishing it so a damaged credential/audit envelope cannot remain a
  // believable ranked opponent merely because its duplicated numeric mirrors still agree.
  validatedPlayerAccountEnvelope(doc);
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

export async function topPlayersByExperience(
  limit = 100,
  country?: string,
  collection?: Collection<PlayerDocument>,
): Promise<PlayerLeaderboardItem[]> {
  if (!Number.isSafeInteger(limit) || limit < 1 || limit > 100) {
    throw new Error("Experience leaderboard limit is invalid.");
  }
  const filter = country ? { "player.country": country } : {};
  const docs = await (collection ?? players())
    .find(filter)
    .sort({ experience: -1, id: 1 })
    .limit(limit)
    .toArray();
  if (docs.length > limit) throw new Error("Experience leaderboard returned too many rows.");
  for (let index = 0; index < docs.length; index += 1) {
    const doc = validatedPlayerAccountEnvelope(docs[index]!);
    if (country !== undefined && doc.player.country !== country) {
      throw new Error("Selected experience leaderboard row does not match the country query.");
    }
    if (index > 0) {
      const previous = docs[index - 1]!;
      if (previous.experience < doc.experience
        || (previous.experience === doc.experience && previous.id >= doc.id)) {
        throw new Error("Selected experience leaderboard rows are not in authoritative rank order.");
      }
    }
  }
  const items = docs.map((doc, index) => buildPlayerLeaderboardItem(doc, index + 1));
  if (!country) {
    // Validate every Mongo-backed public row before it can enter the cache, then atomically replace
    // rather than append. A Redis outage must still never make the authoritative result unavailable.
    void redisReplaceSortedSet(
      RedisKeys.leaderboardExperience,
      docs.map((doc) => ({ score: doc.experience, member: doc.id })),
      leaderboardCachePolicy().ttlSeconds,
    );
  }
  return items;
}

/**
 * Build the FHIPGDADNFG item used by GEKJKNLPJIL's Arena leaderboard parser.
 * The parser reuses normal player fields and additionally deserializes the exact string
 * attribute `WarArenaData`; a bare object or different key silently loses crown/run data.
 */
export function buildArenaLeaderboardItem(
  doc: PlayerDocument,
  position: number,
  expectedArenaId?: string,
): PlayerLeaderboardItem {
  const item = buildPlayerLeaderboardItem(doc, position);
  const arena = progressionForPlayer(doc).warArena;
  // A MongoDB match is not authority by itself. Re-prove the selected snapshot before returning
  // it so a damaged/misprojected row cannot leak an old event into the current leaderboard.
  if (expectedArenaId !== undefined
    && (!arena || arena.arenaId !== expectedArenaId || arena.played !== true)) {
    throw new Error("Selected War Arena leaderboard row is not from the current event.");
  }
  if (arena) item.WarArenaData = s(serializeWarArenaData(arena));
  return item;
}

interface ArenaLeaderboardRankKey {
  readonly flawlessClass: number;
  readonly score: number;
  readonly playerName: string;
  readonly playerId: string;
}

function arenaLeaderboardRankKey(doc: PlayerDocument, expectedArenaId: string): ArenaLeaderboardRankKey {
  // progressionForPlayer includes the complete shared progression and War Arena authority proof.
  // Do not trust the aggregation's computed fields: derive the comparison tuple again from the
  // selected durable document before its order or Position can become client-visible.
  validatedPlayerAccountEnvelope(doc);
  const arena = progressionForPlayer(doc).warArena;
  if (!arena || arena.arenaId !== expectedArenaId || arena.played !== true) {
    throw new Error("Selected War Arena leaderboard row is not from the current event.");
  }
  const flawlessClass = arena.flawless > 0 ? 1 : 0;
  return {
    flawlessClass,
    score: flawlessClass ? arena.flawless : arena.topRun,
    playerName: doc.player.accountName,
    playerId: doc.id,
  };
}

function compareArenaLeaderboardRank(left: ArenaLeaderboardRankKey, right: ArenaLeaderboardRankKey): number {
  if (left.flawlessClass !== right.flawlessClass) return right.flawlessClass - left.flawlessClass;
  if (left.score !== right.score) return right.score - left.score;
  // Unity uses the device culture for this final presentation tie. MongoDB cannot reproduce every
  // client locale simultaneously, so the backend freezes one binary string order and player ID as
  // the deterministic authority for Position; Unity remains free to re-sort equal scores locally.
  if (left.playerName !== right.playerName) return left.playerName < right.playerName ? -1 : 1;
  if (left.playerId !== right.playerId) return left.playerId < right.playerId ? -1 : 1;
  return 0;
}

export async function topArenaPlayers(
  limit = 100,
  nowSeconds = Math.floor(Date.now() / 1_000),
  collection?: Collection<PlayerDocument>,
): Promise<PlayerLeaderboardItem[]> {
  if (!Number.isSafeInteger(limit) || limit < 1 || limit > 100) {
    throw new Error("War Arena leaderboard limit is invalid.");
  }
  const arenaId = currentArenaId(nowSeconds);
  const flawless = "$progression.warArena.flawless";
  const topRun = "$progression.warArena.topRun";
  const pipeline: Document[] = [
    {
      $match: {
        "progression.warArena.arenaId": arenaId,
        "progression.warArena.played": true,
      },
    },
    {
      // The recovered FHIPGDADNFG comparator puts every flawless run before a non-flawless run,
      // then compares `flawless` inside that group or `topRun` otherwise. Computing those two
      // keys in MongoDB keeps Position consistent with the order Unity derives after parsing.
      $set: {
        __arenaLeaderboardFlawless: { $cond: [{ $gt: [flawless, 0] }, 1, 0] },
        __arenaLeaderboardScore: { $cond: [{ $gt: [flawless, 0] }, flawless, topRun] },
      },
    },
    {
      $sort: {
        __arenaLeaderboardFlawless: -1,
        __arenaLeaderboardScore: -1,
        "player.accountName": 1,
        id: 1,
      },
    },
    { $limit: limit },
    { $unset: ["__arenaLeaderboardFlawless", "__arenaLeaderboardScore"] },
  ];
  const docs = await (collection ?? players()).aggregate<PlayerDocument>(pipeline).toArray();
  const rankKeys = docs.map((doc) => arenaLeaderboardRankKey(doc, arenaId));
  for (let index = 1; index < rankKeys.length; index += 1) {
    if (compareArenaLeaderboardRank(rankKeys[index - 1]!, rankKeys[index]!) > 0) {
      throw new Error("Selected War Arena leaderboard rows are not in authoritative rank order.");
    }
  }
  return docs.map((doc, index) => buildArenaLeaderboardItem(doc, index + 1, arenaId));
}

/** 1-based global rank by experience (players strictly ahead plus one). */
export async function playerRank(
  playerId: string,
  collection?: Collection<PlayerDocument>,
): Promise<number> {
  const source = collection ?? players();
  const doc = validatedPlayerProfileLookup(await source.findOne({ id: playerId }));
  if (!doc) return 0;
  let ahead = 0;
  // countDocuments would let a split root/DTO row, malformed credential, or damaged progression
  // influence an honest player's rank without passing the same complete authority required for a
  // visible leaderboard item. Stream every strictly higher row through that proof instead.
  for await (const candidate of source.find({ experience: { $gt: doc.experience } })) {
    validatedPlayerAccountEnvelope(candidate);
    if (candidate.experience <= doc.experience) {
      throw new Error("Selected experience rank row is not strictly ahead of the player.");
    }
    if (ahead === 2_147_483_646) {
      throw new Error("Experience leaderboard rank exceeds the recovered client integer range.");
    }
    ahead += 1;
  }
  return ahead + 1;
}

export async function topSquads(limit = 100): Promise<Record<string, unknown>[]> {
  const docs = await squads().find().sort({ experience: -1 }).limit(limit).toArray();
  const now = new Date();
  docs.forEach((squad) => validatedSquadDocument(squad, now));
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
