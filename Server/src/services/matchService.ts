import { randomUUID } from "crypto";
import { matches, squads } from "../db";
import { findById, savePlayer } from "./playerService";
import { PlayerStatus } from "../constants";
import logger from "../utils/logger";

// Match records + result settlement (BACKEND.md §3.1 steps 2–4). A match is created when
// two players are paired, players report GameStarted, and the winner-bearing GameEnded /
// MatchResult settles rewards. Settlement is server-authoritative and idempotent.

export interface MatchPlayer {
  playerId: string;
  name: string;
  armyPower: number;
  leagueTier: number;
}

interface MatchDoc {
  matchId: string;
  players: MatchPlayer[];
  state: "active" | "finished";
  winnerId?: string;
  createdAt: Date;
  endedAt?: Date;
}

const REWARDS = {
  winExperience: 30,
  loseExperience: 10,
  winMedals: 25,
  loseMedals: -12,
  winSquadPoints: 10,
} as const;

export async function createMatch(a: MatchPlayer, b: MatchPlayer): Promise<string> {
  const matchId = randomUUID();
  const doc: MatchDoc = { matchId, players: [a, b], state: "active", createdAt: new Date() };
  await matches().insertOne(doc);
  // Flag both players as in battle.
  for (const p of [a, b]) {
    const player = await findById(p.playerId);
    if (player) {
      player.player.status = PlayerStatus.InBattle;
      await savePlayer(p.playerId, player.player);
    }
  }
  logger.match.event("Match created", { matchId, a: a.playerId, b: b.playerId });
  return matchId;
}

async function grant(playerId: string, won: boolean): Promise<void> {
  const player = await findById(playerId);
  if (!player) return;
  const p = player.player;
  p.experience += won ? REWARDS.winExperience : REWARDS.loseExperience;
  p.medalsBalance = Math.max(0, p.medalsBalance + (won ? REWARDS.winMedals : REWARDS.loseMedals));
  p.status = PlayerStatus.Online;
  if (won && p.squadName) {
    p.squadPoints += REWARDS.winSquadPoints;
    // Reflect the contribution on the squad aggregate + member row.
    await squads().updateOne(
      { name: p.squadName, "members.playerId": playerId },
      {
        $inc: { experience: REWARDS.winSquadPoints, squadPoints: REWARDS.winSquadPoints, "members.$.squadPoints": REWARDS.winSquadPoints },
        $set: { updatedAt: new Date() },
      },
    );
  }
  await savePlayer(playerId, p);
}

export interface SettlementResult {
  matchId: string;
  winnerId: string;
  rewarded: boolean;
}

/**
 * Settle a finished match. Idempotent: a second call for an already-finished match is a
 * no-op. Returns whether rewards were granted this call.
 */
export async function settleResult(matchId: string, winnerId: string): Promise<SettlementResult> {
  const match = (await matches().findOne({ matchId })) as MatchDoc | null;
  if (!match) {
    logger.match.error("Result for unknown match", { matchId });
    return { matchId, winnerId, rewarded: false };
  }
  if (match.state === "finished") {
    return { matchId, winnerId: match.winnerId ?? winnerId, rewarded: false };
  }
  const isParticipant = match.players.some((p) => p.playerId === winnerId);
  if (!isParticipant) {
    logger.match.error("Winner is not a participant", { matchId, winnerId });
    return { matchId, winnerId, rewarded: false };
  }

  for (const p of match.players) {
    await grant(p.playerId, p.playerId === winnerId);
  }
  await matches().updateOne({ matchId }, { $set: { state: "finished", winnerId, endedAt: new Date() } });
  logger.match.event("Match settled", { matchId, winnerId });
  return { matchId, winnerId, rewarded: true };
}
