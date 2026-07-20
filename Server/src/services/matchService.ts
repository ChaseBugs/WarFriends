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
import { applyLevelExperienceState } from "./levelProgressionService";
import { calculateArmyPower } from "./armyPowerService";
import { advancePlayerLeaguePlacementAfterPvp } from "./playerLeagueContract";
import {
  getActiveConfiguredSquadEvent,
  recordConfirmedPvpSquadEventProgress,
  squadEventConfigHash,
  type SquadEventProjectionStatus,
} from "./squadEventService";
import { applyVipBattleLootboxState } from "./vipLootboxService";

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
  /** Immutable core reward receipts returned unchanged by finished GameEnded retries. */
  rewardReceipts?: Record<string, MatchPlayerReward>;
  /** Audit receipt for Squad Event projection committed with the terminal match transition. */
  squadEventProjection?: {
    eventId: string;
    configHash: string;
    participants: Array<{ playerId: string; squadId: string; status: SquadEventProjectionStatus }>;
  };
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

/**
 * VIP battle multipliers decoded from the 4.9.5 MainScene Constants component.
 *
 * The scene stores CodeStage ObscuredFloat values. `VipExperienceMultiplier` decodes to
 * 1.5 and `VipGoldMultiplier` decodes to 2.0. The recovered 1.6.0 IIGFODGJBFA reward
 * parser expects the server to send the unmultiplied component values together with
 * `IsVip=true`; it applies these same constants for the wallet/results presentation.
 * Durable settlement must nevertheless store the multiplied totals, otherwise the client
 * would display a reward that disappears on the next authoritative PlayerData refresh.
 */
export const VIP_BATTLE_EXPERIENCE_MULTIPLIER = 1.5;
export const VIP_LEVEL_GOLD_MULTIPLIER = 2;

/**
 * Derive the base client component and the authoritative amount for one PvP result.
 *
 * C# converts the positive float product to int by truncation. Math.trunc therefore keeps
 * this service bit-for-bit compatible if a future base reward is not evenly divisible by
 * two. VIP eligibility is sampled at settlement time, not when matchmaking began: this is
 * the only moment at which rewards become durable and matches VipManager's strict
 * `vipExpiration > currentTimestamp` check.
 */
export function pvpExperienceAmounts(won: boolean, isVip: boolean): {
  baseExperience: number;
  experience: number;
} {
  const baseExperience = won ? REWARDS.winExperience : REWARDS.loseExperience;
  return {
    baseExperience,
    experience: isVip
      ? Math.trunc(baseExperience * VIP_BATTLE_EXPERIENCE_MULTIPLIER)
      : baseExperience,
  };
}

/**
 * Convert the source level-row Gold into the amount committed by a PvP settlement.
 * Keeping this beside the XP calculation makes the otherwise easy-to-miss 2x VIP rule
 * directly testable. The guard also prevents a corrupted/oversized reward from overflowing
 * JavaScript's exact-integer range before it reaches the MongoDB transaction.
 */
export function pvpLevelGoldAmount(baseGold: number, isVip: boolean): number {
  if (!Number.isSafeInteger(baseGold) || baseGold < 0) {
    throw new Error("PvP base level Gold is invalid.");
  }
  const gold = isVip ? Math.trunc(baseGold * VIP_LEVEL_GOLD_MULTIPLIER) : baseGold;
  if (!Number.isSafeInteger(gold)) throw new Error("PvP VIP level Gold overflowed.");
  return gold;
}

/**
 * Build the minimum exact object consumed by IIGFODGJBFA before the GameEnded parser reads
 * Skill and medal fields. The parser dereferences ServerResultsCache.lastGameReward whenever
 * Skill exists, so omitting this object causes a null reference even when every balance was
 * settled correctly. Pending/conflicting reports receive a real zero-valued object; confirmed
 * results and finished retries receive the deterministic server XP for that participant.
 */
export function pvpGameReward(
  resultAvailable: boolean,
  battleExperience = 0,
  gameGold = 0,
  isVip = false,
  newVisuals?: string,
): Record<string, unknown> {
  return {
    Xp: {
      BattleRewards: resultAvailable ? battleExperience : 0,
      ExtraRewards: 0,
      Winstreak: 0,
      Time: 0,
      offerMult: 1,
    },
    GameGold: {
      BattleRewards: resultAvailable ? gameGold : 0,
      League: 0,
      offerMult: 1,
    },
    // Never mark a pending/conflicting response as VIP. IIGFODGJBFA multiplies every
    // component when this flag is true, so it must describe an immutable settlement receipt
    // rather than the account's current VIP state at response/retry time.
    IsVip: resultAvailable && isVip,
    // NewVisuals is itself a JSON dictionary string, not a nested object. Include it only in
    // the immutable successful receipt; an empty key makes some recovered end-screen paths
    // try to open a suitcase dialog with no entries.
    ...(resultAvailable && newVisuals ? { NewVisuals: newVisuals } : {}),
  };
}

/**
 * Emit Level only for a real server-side level transition.
 *
 * DMGJCGJDDID treats the mere presence of `Level` as proof of a level-up and sets
 * LevelManager.isLevelUp. Returning the unchanged level after every match therefore opens
 * level-up UI and tutorials incorrectly. LevelExperience is unconditional, while Level is a
 * conditional transition marker in this wire contract.
 */
export function pvpLevelFields(
  previousLevel: number,
  currentLevel: number,
  levelExperience: number,
): Record<string, number> {
  return currentLevel > previousLevel
    ? { LevelExperience: levelExperience, Level: currentLevel }
    : { LevelExperience: levelExperience };
}

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
  reward: MatchPlayerReward;
}

export interface MatchPlayerReward {
  /** Unmultiplied Xp.BattleRewards value consumed by the stock client reward parser. */
  baseExperience: number;
  /** Actual XP committed to the player after the settlement-time VIP multiplier. */
  experience: number;
  /** Unmultiplied GameGold.BattleRewards value; the client doubles it for VIP receipts. */
  baseGold: number;
  /** Actual level-up Gold committed to progression after the VIP multiplier. */
  gold: number;
  /** Immutable settlement-time entitlement; later expiry must not rewrite a retry receipt. */
  isVip: boolean;
  /** Authoritative countdown after this participant's confirmed settlement. */
  matchesToNextLootboxes: number;
  /** Exact JSON string for GameReward.NewVisuals; absent when this match did not grant boxes. */
  newVisuals?: string;
  /** Duplicate overflow already committed to progression.warBucks in the same transaction. */
  lootboxWarBucks: number;
  levelFrom: number;
  levelTo: number;
  levelExperience: number;
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
  settledAt: Date,
): Promise<CoreGrant> {
  const player = await players().findOne({ id: playerId }, { session });
  if (!player) throw new Error(`Match participant ${playerId} was not found.`);
  const initialState = progressionForPlayer(player);
  const settlementUnix = Math.floor(settledAt.getTime() / 1_000);
  const isVip = Math.floor(initialState.vipExpiration ?? 0) > settlementUnix;
  const { baseExperience, experience } = pvpExperienceAmounts(won, isVip);
  const medalDelta = won ? REWARDS.winMedals : REWARDS.loseMedals;
  const squadPoints = won && player.player.squadName ? REWARDS.winSquadPoints : 0;
  const consumed = consumePvpUsedCardsState(initialState, usedCards);
  const leveled = applyLevelExperienceState(consumed.state, player.player.level, experience);
  // Advance the periodic paid-VIP benefit before constructing the canonical progression.
  // This pure transition persists its countdown, visual parts, and duplicate WarBucks in the
  // same guarded player write and exposes presentation data for the immutable match receipt.
  const vipLootboxes = applyVipBattleLootboxState(leveled.state, isVip);
  const baseGold = leveled.goldGranted;
  const gold = pvpLevelGoldAmount(baseGold, isVip);
  const vipLevelGoldBonus = gold - baseGold;
  if (vipLootboxes.state.gold > Number.MAX_SAFE_INTEGER - vipLevelGoldBonus) {
    throw new Error("PvP VIP level Gold balance overflowed.");
  }
  // applyLevelExperienceState grants the source row's base Gold. Add only the VIP delta here
  // so the level transition remains reusable and the progression wallet equals the amount
  // IIGFODGJBFA adds after applying its VipGoldMultiplier to GameGold.
  const canonical = canonicalProgression({
    ...vipLootboxes.state,
    gold: vipLootboxes.state.gold + vipLevelGoldBonus,
  });
  const levelChanged = leveled.levelTo !== leveled.levelFrom;
  const nextArmyPower = levelChanged
    ? calculateArmyPower({
      ...player,
      progression: canonical,
      player: { ...player.player, level: leveled.levelTo },
    }).total
    : player.player.armyPower;
  const leagueAdvance = advancePlayerLeaguePlacementAfterPvp(
    player.player,
    Math.floor(settledAt.getTime() / 1_000),
  );
  const leagueFields: Record<string, unknown> = leagueAdvance
    ? {
      leagueTier: leagueAdvance.leagueTier,
      "player.leagueTier": leagueAdvance.leagueTier,
      "player.leagueId": leagueAdvance.leagueId,
      "player.leagueDivision": leagueAdvance.leagueDivision,
      "player.remainingMatches": leagueAdvance.remainingMatches,
    }
    : {};

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
          "player.level": leveled.levelTo,
          "player.armyPower": nextArmyPower,
          armyPower: nextArmyPower,
          "player.status": PlayerStatus.Online,
          // Placement advances only inside this confirmed two-party settlement. Folding it
          // into the same player write prevents a forged standalone request or a replay from
          // consuming the recovered one-match placement requirement.
          ...leagueFields,
          updatedAt: settledAt,
        },
      },
    ],
    { session },
  );
  if (update.modifiedCount !== 1) throw new Error(`Concurrent settlement rejected player ${playerId}.`);
  return {
    playerId,
    won,
    squadName: player.player.squadName,
    squadPoints,
    reward: {
      baseExperience,
      experience,
      baseGold,
      gold,
      isVip,
      matchesToNextLootboxes: vipLootboxes.matchesToNextLootboxes,
      newVisuals: vipLootboxes.newVisuals,
      lootboxWarBucks: vipLootboxes.duplicateWarBucks,
      levelFrom: leveled.levelFrom,
      levelTo: leveled.levelTo,
      levelExperience: leveled.levelExperience,
    },
  };
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
      settlement: {
        matchId,
        winnerId: match.winnerId ?? winnerId,
        rewarded: false,
        rewards: match.rewardReceipts,
      },
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
  rewards?: Record<string, MatchPlayerReward>;
}

/**
 * Settle a finished match. Idempotent: a second call for an already-finished match is a
 * no-op. Core rewards, reported War Card consumption, supported Squad Event progress, and the
 * terminal match row commit in one transaction. Non-critical daily-assignment and achievement
 * projections run only after that commit and cannot cause the client to retry core rewards.
 */
export async function settleResult(matchId: string, winnerId: string, reportedById?: string): Promise<SettlementResult> {
  // Live-event configuration is resolved before opening the MongoDB transaction. A malformed
  // operator file disables this optional projection for the match but must not prevent the
  // already-confirmed participants from receiving their core PvP settlement.
  const squadEventSeason = await getActiveConfiguredSquadEvent().catch((error: unknown) => {
    logger.warnWithEmoji("⚠️", "Squad Event configuration could not be used for PvP settlement", "MATCH", {
      matchId,
      error: error instanceof Error ? error.message : String(error),
    });
    return null;
  });
  const settlementTime = new Date();
  const transaction = await withMongoTransaction(async (session) => {
    const match = await matches().findOne({ matchId }, { session }) as unknown as MatchDoc | null;
    if (!match) return { result: { matchId, winnerId, rewarded: false }, grants: [] as CoreGrant[], unknown: true };
    if (match.state === "finished") {
      return {
        result: {
          matchId,
          winnerId: match.winnerId ?? winnerId,
          rewarded: false,
          rewards: match.rewardReceipts,
        },
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
        settlementTime,
      ));
    }
    const rewardReceipts = Object.fromEntries(
      grants.map((grant) => [grant.playerId, grant.reward]),
    );
    const eventParticipants: Array<{
      playerId: string;
      squadId: string;
      status: SquadEventProjectionStatus;
    }> = [];
    if (squadEventSeason) {
      for (const grant of grants) {
        const status = await recordConfirmedPvpSquadEventProgress(
          session,
          squadEventSeason,
          grant.playerId,
          grant.squadName,
          grant.won,
          settlementTime,
        );
        eventParticipants.push({ playerId: grant.playerId, squadId: grant.squadName, status });
      }
    }
    const finish = await matches().updateOne(
      { matchId, state: "active" },
      {
        $set: {
          state: "finished",
          winnerId,
          rewardReceipts,
          endedAt: settlementTime,
          ...(squadEventSeason ? {
            squadEventProjection: {
              eventId: squadEventSeason.id,
              configHash: squadEventConfigHash(squadEventSeason),
              participants: eventParticipants,
            },
          } : {}),
        },
      },
      { session },
    );
    if (finish.modifiedCount !== 1) throw new Error(`Concurrent settlement rejected match ${matchId}.`);
    return {
      result: { matchId, winnerId, rewarded: true, rewards: rewardReceipts },
      grants,
      unknown: false,
    };
  });

  if (transaction.unknown) logger.match.error("Result for unknown match", { matchId });
  if (!transaction.result.rewarded) return transaction.result;
  await Promise.all(transaction.grants.map(grantSecondaryProgress));
  logger.match.event("Match settled", { matchId, winnerId });
  return transaction.result;
}
