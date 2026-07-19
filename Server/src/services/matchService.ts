import { randomUUID } from "crypto";
import { matches, players, squads } from "../db";
import { findById, updatePlayerFields } from "./playerService";
import { PlayerStatus } from "../constants";
import logger from "../utils/logger";
import { recordPvpAssignmentProgress } from "./assignmentService";
import { recordRankedPvpAchievements } from "./achievementService";

/**
 * Persistent PvP match lifecycle and reward settlement.
 *
 * `gameHub` and `RoomManager` own transient WebSocket connections; this service owns the
 * durable match row, player presence, result reports, terminal state, and rewards. A match is
 * created before either profile is marked InGame. Settlement then atomically claims
 * `active -> settling`, grants each participant once, and finally marks the row `finished`.
 * Competing reports or timeout handlers cannot claim the same match after that transition.
 *
 * Normal settlement requires both authenticated participants to report the same winner. This
 * prevents one client from unilaterally awarding itself a win, but it is consensus validation,
 * not authoritative combat simulation. Damage, deployment, and hit events remain opaque
 * until the original Photon RPC/event schema is recovered and validated by the backend.
 */

export interface MatchPlayer {
  /** Stable authenticated player ID; never taken from a later result payload. */
  playerId: string;
  /** Snapshot used for the MatchFound/room UI. */
  name: string;
  /** Matchmaking snapshot; reward settlement does not trust or recalculate it. */
  armyPower: number;
  /** League snapshot used by the queue's widening compatibility window. */
  leagueTier: number;
}

export interface MatchDoc {
  matchId: string;
  players: MatchPlayer[];
  state: "active" | "settling" | "finished" | "cancelled";
  /** Written only by the atomic settlement claim and preserved for idempotent retries. */
  winnerId?: string;
  /** Durable REST reports, keyed by authenticated reporter player ID. */
  resultReports?: Record<string, string>;
  createdAt: Date;
  /** Terminal timestamp for both normal completion and cancellation. */
  endedAt?: Date;
}

/**
 * Cancel an unresolved match without granting rewards and release both players back to
 * Online. The state transition is atomic, so competing disconnect timers cannot cancel a
 * match that has already been claimed for normal result settlement.
 */
export async function cancelMatch(matchId: string, reason: string): Promise<boolean> {
  const match = await getMatch(matchId);
  if (!match) return false;
  const claim = await matches().updateOne(
    { matchId, state: "active" },
    { $set: { state: "cancelled", cancelReason: reason, endedAt: new Date() } },
  );
  if (claim.modifiedCount !== 1) return false;
  await Promise.all(match.players.map((participant) => updatePlayerFields(participant.playerId, { status: PlayerStatus.Online })));
  logger.match.event("Match cancelled", { matchId, reason });
  return true;
}

/**
 * A process restart destroys in-memory rooms but not MongoDB match rows. In this
 * single-instance server, any active/settling row found during boot is therefore orphaned.
 * Mark it cancelled and restore player presence so accounts never remain permanently
 * blocked by the InGame matchmaking guard.
 */
export async function recoverInterruptedMatches(): Promise<number> {
  const interrupted = (await matches().find({ state: { $in: ["active", "settling"] } }).toArray()) as unknown as MatchDoc[];
  if (!interrupted.length) return 0;
  const matchIds = interrupted.map((match) => match.matchId);
  await matches().updateMany(
    { matchId: { $in: matchIds }, state: { $in: ["active", "settling"] } },
    { $set: { state: "cancelled", cancelReason: "server_restart", endedAt: new Date() } },
  );
  const playerIds = new Set(interrupted.flatMap((match) => match.players.map((participant) => participant.playerId)));
  await Promise.all([...playerIds].map((playerId) => updatePlayerFields(playerId, { status: PlayerStatus.Online })));
  logger.match.event("Recovered interrupted matches", { count: interrupted.length });
  return interrupted.length;
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
  // Move both persistent player records to InGame only after the match row exists. If neither
  // client joins, the hub's join deadline cancels this row and restores both statuses.
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

  // MongoDB's update pipeline derives every balance from the stored value in one write. This
  // prevents a concurrent request from overwriting XP, medals, or squad points with a stale
  // read-modify-write snapshot. Medals are clamped at zero to preserve the client invariant.
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
          // LevelExperience is the value read unconditionally by the GameEnded callback.
          // Incrementing the progression revision also makes an overlapping economy write
          // fail its optimistic-concurrency filter and retry instead of losing this reward.
          "progression.levelExperience": {
            $add: [{ $ifNull: ["$progression.levelExperience", 0] }, experience],
          },
          "progression.revision": { $add: [{ $ifNull: ["$progression.revision", 0] }, 1] },
          updatedAt: "$$NOW",
        },
      },
    ],
  );

  // Assignment progress is derived only after the match row has won the idempotent
  // active-to-settling claim. A duplicate result therefore cannot advance objectives twice.
  // Keep this secondary feature from stranding the core match in `settling` if its bounded
  // optimistic-concurrency retries are exhausted; the warning is actionable and the next
  // legitimate match can still continue the player's objectives.
  try {
    await recordPvpAssignmentProgress(playerId, won);
  } catch (error) {
    logger.warnWithEmoji("⚠️", "Could not advance assignment progress", "MATCH", {
      playerId,
      error: error instanceof Error ? error.message : String(error),
    });
  }

  // Ranked-win and lifetime squad-point achievements are derived from this same settlement
  // decision. They are intentionally not advanced from ChangeAchievementProgres (action
  // 220), because that request contains a client-computed StatsManager value.
  try {
    await recordRankedPvpAchievements(playerId, won, squadPoints);
  } catch (error) {
    logger.warnWithEmoji("⚠️", "Could not advance achievement progress", "MATCH", {
      playerId,
      error: error instanceof Error ? error.message : String(error),
    });
  }

  if (squadPoints > 0) {
    // Keep the squad aggregate and embedded member contribution aligned with the player's
    // mirrored squadPoints field. Only winners that currently belong to a squad contribute.
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

export type MatchReportStatus = "pending" | "confirmed" | "conflict" | "invalid" | "finished";

export interface MatchReportResult {
  status: MatchReportStatus;
  settlement?: SettlementResult;
}

/**
 * Interpret the local EndReason enum sent by the recovered GameEnded request.
 *
 * Win (2) and WinByForfeit (3) identify the authenticated reporter as winner. Killed (1),
 * Forfeit (5), and Kia (8) identify the other assigned participant. Mission-only outcomes
 * are rejected for PvP because treating MissionSuccess as a PvP win would let a modified
 * client bypass result consensus with an unrelated enum value.
 */
export function winnerFromEndReason(
  playerIds: readonly string[],
  reporterId: string,
  endReason: number,
): string | null {
  if (!playerIds.includes(reporterId)) return null;
  if (endReason === 2 || endReason === 3) return reporterId;
  if (endReason === 1 || endReason === 5 || endReason === 8) {
    return playerIds.find((playerId) => playerId !== reporterId) ?? null;
  }
  return null;
}

/**
 * Record a REST/Photon result without trusting either client alone.
 *
 * Each authenticated player may overwrite only their own report key. Once both assigned
 * players agree, settleResult's active-to-settling claim grants rewards exactly once. If
 * both reports conflict, the match is cancelled without rewards so neither account remains
 * stuck InGame and neither side benefits from inventing a winner.
 */
export async function reportMatchResult(
  matchId: string,
  reporterId: string,
  winnerId: string,
): Promise<MatchReportResult> {
  const match = await getMatch(matchId);
  if (!match || !match.players.some((player) => player.playerId === reporterId)) return { status: "invalid" };
  if (!match.players.some((player) => player.playerId === winnerId)) return { status: "invalid" };
  if (match.state === "finished") {
    return {
      status: "finished",
      settlement: { matchId, winnerId: match.winnerId ?? winnerId, rewarded: false },
    };
  }
  if (match.state !== "active") return { status: "invalid" };

  await matches().updateOne(
    { matchId, state: "active", "players.playerId": reporterId },
    { $set: { [`resultReports.${reporterId}`]: winnerId } },
  );
  const updated = await getMatch(matchId);
  if (!updated || updated.state !== "active") return { status: "invalid" };
  const reports = updated.resultReports ?? {};
  const reportedWinners = updated.players
    .map((player) => reports[player.playerId])
    .filter((value): value is string => typeof value === "string");
  if (reportedWinners.length < updated.players.length) return { status: "pending" };
  if (new Set(reportedWinners).size !== 1) {
    await cancelMatch(matchId, "result_conflict");
    return { status: "conflict" };
  }

  const settlement = await settleResult(matchId, reportedWinners[0], reporterId);
  return { status: "confirmed", settlement };
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
