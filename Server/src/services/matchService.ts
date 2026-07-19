import { randomUUID } from "crypto";
import { matches, players, squads } from "../db";
import { findById, updatePlayerFields } from "./playerService";
import { PlayerStatus } from "../constants";
import logger from "../utils/logger";

// Match records + result settlement (BACKEND.md §3.1 steps 2–4). A match is created when
// two players are paired, players report GameStarted, and the winner-bearing GameEnded /
// MatchResult settlement is participant-validated and idempotent. The WebSocket path
// requires matching reports from both participants; a fully authoritative simulation is
// still future work.

export interface MatchPlayer {
  playerId: string;
  name: string;
  armyPower: number;
  leagueTier: number;
}

export interface MatchDoc {
  matchId: string;
  players: MatchPlayer[];
  state: "active" | "settling" | "finished";
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
      await updatePlayerFields(p.playerId, { status: PlayerStatus.InGame });
    }
  }
  logger.match.event("Match created", { matchId, a: a.playerId, b: b.playerId });
  return matchId;
}

async function grant(playerId: string, won: boolean): Promise<void> {
  const player = await findById(playerId);
  if (!player) return;
  const experience = won ? REWARDS.winExperience : REWARDS.loseExperience;
  const medalDelta = won ? REWARDS.winMedals : REWARDS.loseMedals;
  const squadPoints = won && player.player.squadName ? REWARDS.winSquadPoints : 0;

  await players().updateOne(
    { id: playerId },
    [
      {
        $set: {
          experience: { $add: ["$experience", experience] },
          squadPoints: { $add: ["$squadPoints", squadPoints] },
          "player.experience": { $add: ["$player.experience", experience] },
          "player.squadPoints": { $add: ["$player.squadPoints", squadPoints] },
          "player.medalsBalance": { $max: [0, { $add: ["$player.medalsBalance", medalDelta] }] },
          "player.status": PlayerStatus.Online,
          updatedAt: "$$NOW",
        },
      },
    ],
  );

  if (squadPoints > 0) {
    // Reflect the contribution on the squad aggregate + member row.
    await squads().updateOne(
      { name: player.player.squadName, "members.playerId": playerId },
      {
        $inc: { experience: squadPoints, squadPoints, "members.$.squadPoints": squadPoints },
        $set: { updatedAt: new Date() },
      },
    );
  }
}

export async function getMatch(matchId: string): Promise<MatchDoc | null> {
  return (await matches().findOne({ matchId })) as unknown as MatchDoc | null;
}

export async function isMatchParticipant(matchId: string, playerId: string): Promise<boolean> {
  return (await matches().countDocuments({ matchId, "players.playerId": playerId }, { limit: 1 })) === 1;
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
export async function settleResult(matchId: string, winnerId: string, reportedById?: string): Promise<SettlementResult> {
  const match = await getMatch(matchId);
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

  if (reportedById && !match.players.some((p) => p.playerId === reportedById)) {
    logger.match.error("Result reporter is not a participant", { matchId, reportedById });
    return { matchId, winnerId, rewarded: false };
  }

  // Claim settlement atomically so concurrent result reports cannot grant twice.
  const claim = await matches().updateOne(
    { matchId, state: "active" },
    { $set: { state: "settling", winnerId, endedAt: new Date() } },
  );
  if (claim.modifiedCount !== 1) {
    const current = await getMatch(matchId);
    return { matchId, winnerId: current?.winnerId ?? winnerId, rewarded: false };
  }

  for (const p of match.players) {
    await grant(p.playerId, p.playerId === winnerId);
  }
  await matches().updateOne({ matchId, state: "settling" }, { $set: { state: "finished" } });
  logger.match.event("Match settled", { matchId, winnerId });
  return { matchId, winnerId, rewarded: true };
}
