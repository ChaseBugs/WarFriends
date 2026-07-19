import { randomUUID } from "crypto";
import type { ClientSession } from "mongodb";
import { matches, players, squads, withMongoTransaction, type PlayerProgressionState } from "../db";
import { findById, updatePlayerFields } from "./playerService";
import { PlayerStatus } from "../constants";
import logger from "../utils/logger";
import { recordPvpAssignmentProgress } from "./assignmentService";
import { recordRankedPvpAchievements } from "./achievementService";
import { consumePvpUsedCardsState } from "./cardInventoryService";
import { progressionForPlayer } from "./playerStateService";

/**
 * Persistent PvP match lifecycle and reward settlement.
 *
 * `gameHub` and `RoomManager` own transient WebSocket connections; this service owns the
 * durable match row, player presence, result reports, terminal state, and rewards. A match is
 * created before either profile is marked InGame. Settlement atomically commits both player
 * rewards and the direct `active -> finished` match transition in one MongoDB transaction.
 * Competing reports or timeout handlers cannot commit the same match after that transition.
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
  /** Authenticated reporter's own card IDs; never accepted for the opponent. */
  usedCardsReports?: Record<string, string[]>;
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

interface CoreGrant {
  playerId: string;
  won: boolean;
  squadName: string;
  squadPoints: number;
}

function progressionRevisionFilter(player: { progression?: PlayerProgressionState }): Record<string, unknown> {
  if (!player.progression) return { progression: { $exists: false } };
  return player.progression.revision === undefined
    ? { "progression.revision": { $exists: false } }
    : { "progression.revision": player.progression.revision };
}

function canonicalProgression(state: PlayerProgressionState): PlayerProgressionState {
  const { dogTags: _legacyDogTags, ...canonical } = state;
  return canonical;
}

/**
 * Commit one participant's core settlement inside the enclosing match transaction.
 *
 * Inventory consumption, lifetime card-play proof, XP, medals, squad points, presence, and
 * progression XP use one document write guarded by the progression revision. The match row
 * becomes finished in that same MongoDB transaction, eliminating the old crash window where
 * one player could be rewarded while the other player or terminal match state was missing.
 */
async function settlePlayerCore(
  session: ClientSession,
  playerId: string,
  won: boolean,
  usedCards: readonly string[],
): Promise<CoreGrant> {
  const player = await players().findOne({ id: playerId }, { session });
  if (!player) throw new Error(`Match participant ${playerId} was not found.`);
  const experience = won ? REWARDS.winExperience : REWARDS.loseExperience;
  const medalDelta = won ? REWARDS.winMedals : REWARDS.loseMedals;
  const squadPoints = won && player.player.squadName ? REWARDS.winSquadPoints : 0;
  const consumed = consumePvpUsedCardsState(progressionForPlayer(player), usedCards);
  const canonical = canonicalProgression({
    ...consumed.state,
    levelExperience: consumed.state.levelExperience + experience,
  });

  const update = await players().updateOne(
    { id: playerId, ...progressionRevisionFilter(player) },
    [
      {
        $set: {
          progression: { $literal: canonical },
          experience: { $add: [{ $ifNull: ["$experience", 0] }, experience] },
          squadPoints: { $add: [{ $ifNull: ["$squadPoints", 0] }, squadPoints] },
          "player.experience": { $add: [{ $ifNull: ["$player.experience", 0] }, experience] },
          "player.squadPoints": { $add: [{ $ifNull: ["$player.squadPoints", 0] }, squadPoints] },
          "player.medalsBalance": {
            $max: [0, { $add: [{ $ifNull: ["$player.medalsBalance", 0] }, medalDelta] }],
          },
          "player.status": PlayerStatus.Online,
          updatedAt: "$$NOW",
        },
      },
    ],
    { session },
  );
  if (update.modifiedCount !== 1) throw new Error(`Concurrent settlement rejected player ${playerId}.`);
  return { playerId, won, squadName: player.player.squadName, squadPoints };
}

async function grantSecondaryProgress(grant: CoreGrant): Promise<void> {
  const { playerId, won, squadName, squadPoints } = grant;
  // Assignment progress is derived only after the match row has won the idempotent
  // terminal transaction. A duplicate result therefore cannot advance objectives twice.
  // Keep this secondary projection from failing an already-committed core transaction if its
  // bounded optimistic-concurrency retries are exhausted; the warning is actionable and the next
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

  if (squadPoints > 0 && squadName) {
    // Keep the squad aggregate and embedded member contribution aligned with the player's
    // mirrored squadPoints field. Only winners that currently belong to a squad contribute.
    try {
      await squads().updateOne(
        { name: squadName, "members.playerId": playerId },
        {
          $inc: { experience: squadPoints, squadPoints, "members.$.squadPoints": squadPoints },
          $set: { updatedAt: new Date() },
        },
      );
    } catch (error) {
      // The player's authoritative points already committed with the core match. Do not turn
      // a squad projection outage into a failed GameEnded response that invites a pointless
      // settlement retry; log the mismatch for an operations reconciliation job instead.
      logger.warnWithEmoji("âš ï¸", "Could not project squad points", "MATCH", {
        playerId,
        squadName,
        error: error instanceof Error ? error.message : String(error),
      });
    }
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
 * players agree, settleResult's terminal MongoDB transaction grants rewards exactly once. If
 * both reports conflict, the match is cancelled without rewards so neither account remains
 * stuck InGame and neither side benefits from inventing a winner.
 */
export async function reportMatchResult(
  matchId: string,
  reporterId: string,
  winnerId: string,
  usedCards: readonly string[] = [],
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

  // Validate only the authenticated reporter's own list before persisting it. Replaying a
  // report may overwrite that same key, but cannot submit cards on behalf of the opponent.
  // The pure transition is repeated inside the final MongoDB transaction so an overlapping
  // economy mutation cannot make this stale ownership check authoritative.
  const reporter = await findById(reporterId);
  if (!reporter) return { status: "invalid" };
  consumePvpUsedCardsState(progressionForPlayer(reporter), usedCards);

  await matches().updateOne(
    { matchId, state: "active", "players.playerId": reporterId },
    {
      $set: {
        [`resultReports.${reporterId}`]: winnerId,
        [`usedCardsReports.${reporterId}`]: [...usedCards],
      },
    },
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
 * no-op. Core rewards, reported War Card consumption, and the terminal match row commit in
 * one transaction. Secondary assignment/achievement projections run only after that commit.
 */
export async function settleResult(matchId: string, winnerId: string, reportedById?: string): Promise<SettlementResult> {
  const transaction = await withMongoTransaction(async (session) => {
    const match = await matches().findOne({ matchId }, { session }) as unknown as MatchDoc | null;
    if (!match) return { result: { matchId, winnerId, rewarded: false }, grants: [] as CoreGrant[], unknown: true };
    if (match.state === "finished") {
      return {
        result: { matchId, winnerId: match.winnerId ?? winnerId, rewarded: false },
        grants: [] as CoreGrant[],
        unknown: false,
      };
    }
    if (match.state !== "active" || !match.players.some((participant) => participant.playerId === winnerId)) {
      return { result: { matchId, winnerId, rewarded: false }, grants: [] as CoreGrant[], unknown: false };
    }
    if (reportedById && !match.players.some((participant) => participant.playerId === reportedById)) {
      return { result: { matchId, winnerId, rewarded: false }, grants: [] as CoreGrant[], unknown: false };
    }

    const grants: CoreGrant[] = [];
    for (const participant of match.players) {
      const cards = match.usedCardsReports?.[participant.playerId] ?? [];
      grants.push(await settlePlayerCore(
        session,
        participant.playerId,
        participant.playerId === winnerId,
        cards,
      ));
    }
    const finish = await matches().updateOne(
      { matchId, state: "active" },
      { $set: { state: "finished", winnerId, endedAt: new Date() } },
      { session },
    );
    if (finish.modifiedCount !== 1) throw new Error(`Concurrent settlement rejected match ${matchId}.`);
    return { result: { matchId, winnerId, rewarded: true }, grants, unknown: false };
  });

  if (transaction.unknown) logger.match.error("Result for unknown match", { matchId });
  if (!transaction.result.rewarded) return transaction.result;
  await Promise.all(transaction.grants.map(grantSecondaryProgress));
  logger.match.event("Match settled", { matchId, winnerId });
  return transaction.result;
}
