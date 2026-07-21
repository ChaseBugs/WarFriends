import { randomUUID } from "crypto";
import type { ClientSession } from "mongodb";
import type { CardPlayedEventData } from "../gameRooms/types";
import {
  matches,
  players,
  squads,
  withMongoTransaction,
  type PlayerProgressionState,
  type PvpWinStreakState,
} from "../db";
import { findById, updatePlayerFields } from "./playerService";
import { League, PlayerStatus } from "../constants";
import logger from "../utils/logger";
import { recordPvpAssignmentProgressState } from "./assignmentService";
import {
  advanceAchievementState,
  synchronizeCardsPlayedInMatchAchievementState,
  synchronizeLeagueAchievementState,
} from "./achievementService";
import {
  CARD_NOT_FOUND,
  MAX_PVP_CARDS_PER_MATCH,
  consumePvpUsedCardsState,
  parsePvpUsedCards,
} from "./cardInventoryService";
import { ApiError } from "../apiErrors";
import { progressionForPlayer } from "./playerStateService";
import {
  checkedPlayerLifetimeExperience,
  checkedPlayerLifetimeSquadPoints,
  validatedPlayerAccountEnvelope,
} from "./playerProfileMirrorAuthorityService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { nextSquadUpdatedAt, validatedSquadDocument } from "./squadAuthorityService";
import { applyLevelExperienceState } from "./levelProgressionService";
import { calculateArmyPower } from "./armyPowerService";
import {
  advanceBeginnerLeagueAfterPvp,
  advancePlayerLeaguePlacementAfterPvp,
  BEGINNER_LEAGUE_REWARDS,
  playerLeagueRule,
} from "./playerLeagueContract";
import {
  getActiveConfiguredSquadEvent,
  recordConfirmedPvpSquadEventProgressWithFanouts,
  squadEventConfigHash,
  type SquadEventProjectionStatus,
} from "./squadEventService";
import { applyVipBattleLootboxState } from "./vipLootboxService";
import { checkedRewardBalance } from "./rewardMathService";
import { isVipActiveAt } from "./vipEntitlementService";
import {
  PVP_WIN_STREAK_INTERVAL_SECONDS,
  PVP_WIN_STREAK_WARBUCKS,
  validatedPvpWinStreak,
} from "./pvpWinStreakAuthorityService";
import {
  advanceRentalAfterBattleState,
  type RentalWireOffer,
} from "./rentalService";
import { config } from "../config";
import {
  prepareSquadWarSettlement,
  prepareSquadWarParticipantAssignments,
  recordConfirmedSquadWarProgress,
  type SquadWarProgressStatus,
} from "./squadWarService";
import { allocatePlayerLeagueDivision } from "./playerLeagueService";
import { validatedMatchDocument } from "./matchAuthorityService";
import { validatedPlayerLastAction } from "./playerPublicScalarAuthorityService";
import { validatedPlayerPresenceTransitions } from "./playerPresenceService";
import { matchResultConsensusTimeoutMilliseconds } from "./multiplayerTimeoutPolicyService";
import {
  publishInboxFanouts,
  type InboxFanoutReference,
} from "./inboxFanoutService";

export { validatedMatchDocument } from "./matchAuthorityService";

export {
  PVP_WIN_STREAK_INTERVAL_SECONDS,
  PVP_WIN_STREAK_WARBUCKS,
  validatedPvpWinStreak,
} from "./pvpWinStreakAuthorityService";

/**
 * Persistent PvP match lifecycle and reward settlement.
 *
 * `gameHub` and `RoomManager` own transient WebSocket connections; this service owns the
 * durable match row, player presence, result reports, terminal state, and rewards. Match creation
 * and both profile `InGame` reservations commit in one MongoDB transaction. Settlement atomically
 * commits both player rewards and the direct `active -> finished` transition in another.
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

export class MatchAdmissionError extends Error {
  constructor(message: string) {
    super(message);
    this.name = "MatchAdmissionError";
  }
}

/** Validate the immutable pair before opening the MongoDB admission transaction. */
export function validateMatchParticipants(a: MatchPlayer, b: MatchPlayer): void {
  const valid = (participant: MatchPlayer): boolean => Boolean(
    participant.playerId
    && participant.playerId.length <= 128
    && !/\p{Cc}/u.test(participant.playerId)
    && !/[.$]/u.test(participant.playerId)
    && participant.name
    && participant.name.length <= 64
    && !/\p{Cc}/u.test(participant.name)
    && Number.isFinite(participant.armyPower)
    && participant.armyPower >= 0
    && Number.isInteger(participant.leagueTier)
    && participant.leagueTier >= League.NoLeague
    && participant.leagueTier <= League.Champion
  );
  if (!valid(a) || !valid(b) || a.playerId === b.playerId) {
    throw new MatchAdmissionError("Match participants are invalid or not distinct.");
  }
}

export interface MatchDoc {
  matchId: string;
  /** Backend node that owns transient timers/room state; liveness is advertised through Redis. */
  coordinatorId?: string;
  /** Authenticated participants that completed JoinMatch; used for cross-node room admission. */
  joinedPlayerIds?: string[];
  /** Written once when every assigned participant has joined the distributed room. */
  roomStartedAt?: Date;
  /** Server-owned disconnect clocks used by cross-node grace/forfeit resolution. */
  disconnectedAt?: Record<string, Date>;
  players: MatchPlayer[];
  state: "active" | "settling" | "finished" | "cancelled";
  /** Written only by the atomic settlement claim and preserved for idempotent retries. */
  winnerId?: string;
  /** Durable REST reports, keyed by authenticated reporter player ID. */
  resultReports?: Record<string, string>;
  /** Authenticated reporter's own card IDs; never accepted for the opponent. */
  usedCardsReports?: Record<string, string[]>;
  /** Sequenced CardPlayed events accepted from the authenticated replacement-room transport. */
  relayedCardPlays?: Record<string, string[]>;
  /** CardPlayed sequences successfully handed to the live-room transport. */
  relayedCardDeliveries?: Record<string, number[]>;
  /** Immutable core reward receipts returned unchanged by finished GameEnded retries. */
  rewardReceipts?: Record<string, MatchPlayerReward>;
  /** Audit receipt for Squad Event projection committed with the terminal match transition. */
  squadEventProjection?: {
    eventId: string;
    configHash: string;
    participants: Array<{ playerId: string; squadId: string; status: SquadEventProjectionStatus }>;
  };
  /** Audit receipt for current-round Squad Wars score committed with this match. */
  squadWarProjection?: Array<{
    playerId: string;
    squadId: string;
    status: SquadWarProgressStatus;
  }>;
  createdAt: Date;
  /** Terminal timestamp for both normal completion and cancellation. */
  endedAt?: Date;
  /** Server-only reason retained when an unresolved match is cancelled without rewards. */
  cancelReason?: string;
}

/** Keep internal terminal reasons bounded and machine-readable in durable audit rows. */
export function normalizeMatchCancelReason(reason: string): string {
  const normalized = reason.trim();
  if (!/^[a-z0-9][a-z0-9_:-]{0,63}$/u.test(normalized)) {
    throw new MatchAdmissionError("Match cancellation reason is invalid.");
  }
  return normalized;
}

/**
 * These lifecycle reasons are valid only before the one-time room start transition. Keeping the
 * policy in one predicate prevents a late queue/join callback from cancelling gameplay that has
 * already acquired active-room authority.
 */
export function cancellationRequiresUnstartedRoom(cancelReason: string): boolean {
  return cancelReason === "join_timeout" || cancelReason === "participant_cancelled_before_start";
}

export interface BothPlayersDisconnectedAuthority {
  /** Exact two-player disconnect snapshot captured after transport liveness says both are gone. */
  disconnectedAt: Record<string, Date>;
}

/** Return cancellation authority only when every assigned player has one durable marker. */
export function completeBothPlayersDisconnectedAuthority(
  match: MatchDoc,
): BothPlayersDisconnectedAuthority | null {
  if (match.state !== "active") return null;
  const playerIds = match.players.map((participant) => participant.playerId);
  const disconnectedAt = match.disconnectedAt ?? {};
  const keys = Object.keys(disconnectedAt);
  if (keys.length !== playerIds.length
    || keys.some((playerId) => !playerIds.includes(playerId))
    || playerIds.some((playerId) => !(disconnectedAt[playerId] instanceof Date))) return null;
  return { disconnectedAt: Object.fromEntries(playerIds.map((playerId) => [playerId, disconnectedAt[playerId]])) };
}

/**
 * Compare a complete two-player disconnect snapshot inside the cancellation transaction.
 *
 * Socket/Redis liveness cannot share MongoDB atomicity. A reconnect clears its marker, and a later
 * disconnect replaces it. Exact timestamp equality therefore fences both cases before presence is
 * released or the durable match is cancelled.
 */
export function matchesBothPlayersDisconnectedAuthority(
  match: MatchDoc,
  authority: BothPlayersDisconnectedAuthority,
): boolean {
  const expectedIds = match.players.map((participant) => participant.playerId);
  const authorityIds = Object.keys(authority.disconnectedAt);
  const currentIds = Object.keys(match.disconnectedAt ?? {});
  return match.state === "active"
    && authorityIds.length === expectedIds.length
    && currentIds.length === expectedIds.length
    && expectedIds.every((playerId) => {
      const expected = authority.disconnectedAt[playerId];
      const current = match.disconnectedAt?.[playerId];
      return expected instanceof Date
        && Number.isFinite(expected.getTime())
        && current instanceof Date
        && current.getTime() === expected.getTime();
    });
}

/**
 * Cancel an unresolved match without granting rewards and release both players back to
 * Online. The match transition and every participant presence repair are atomic, so a crash
 * cannot leave a cancelled match whose accounts remain blocked as InGame. Competing disconnect
 * timers still cannot cancel a match already claimed for normal result settlement.
 */
export async function cancelMatch(
  matchId: string,
  reason: string,
  bothPlayersDisconnectedAuthority?: BothPlayersDisconnectedAuthority,
): Promise<boolean> {
  const cancelReason = normalizeMatchCancelReason(reason);
  // This terminal reason carries a stronger proof contract than operator/startup timeouts. Keep
  // the reason and its complete two-marker authority inseparable so a future call site cannot
  // accidentally restore the former unconditional both-offline cancellation path.
  if ((cancelReason === "both_players_disconnected") !== Boolean(bothPlayersDisconnectedAuthority)) {
    return false;
  }
  const transitionAt = new Date();
  const transitionUnix = validatedPlayerLastAction(Math.floor(transitionAt.getTime() / 1_000));
  // A late join-timeout callback must never cancel a distributed room whose second participant
  // already committed the start transition on another node.
  const cancellationGuard = cancellationRequiresUnstartedRoom(cancelReason)
    ? { roomStartedAt: { $exists: false } }
    : {};
  const cancelled = await withMongoTransaction(async (session) => {
    const match = await matches().findOne(
      { matchId, state: "active", ...cancellationGuard },
      { session },
    ) as unknown as MatchDoc | null;
    if (!match) return false;
    validatedMatchDocument(match, transitionAt);
    if (bothPlayersDisconnectedAuthority
      && !matchesBothPlayersDisconnectedAuthority(match, bothPlayersDisconnectedAuthority)) return false;
    validatedMatchDocument({
      ...match,
      state: "cancelled",
      cancelReason,
      endedAt: transitionAt,
    }, transitionAt);
    const playerIds = [...new Set(match.players.map((participant) => participant.playerId))];
    const participantDocuments = await players().find(
      { id: { $in: playerIds } },
      { session },
    ).toArray();
    validatedPlayerPresenceTransitions(
      participantDocuments,
      playerIds,
      PlayerStatus.Online,
      transitionUnix,
      transitionAt,
    );
    const claim = await matches().updateOne(
      { matchId, state: "active", ...cancellationGuard },
      { $set: { state: "cancelled", cancelReason, endedAt: transitionAt } },
      { session },
    );
    if (claim.modifiedCount !== 1) return false;
    const presence = await players().updateMany(
      { id: { $in: playerIds } },
      {
        $set: {
          "player.status": PlayerStatus.Online,
          "player.lastAction": transitionUnix,
          updatedAt: transitionAt,
        },
      },
      { session },
    );
    if (presence.matchedCount !== playerIds.length) {
      throw new Error("Ranked cancellation did not release every participant.");
    }
    return true;
  });
  if (cancelled) logger.match.event("Match cancelled", { matchId, reason: cancelReason });
  return cancelled;
}

/**
 * A process restart destroys its in-memory rooms but not MongoDB match rows. Single-node startup
 * treats every interrupted row as orphaned. A Redis-enabled cluster cancels only rows whose owning
 * coordinator heartbeat has expired; live peer-owned matches survive rolling deployments.
 */
export async function selectOrphanMatchIds(
  candidates: ReadonlyArray<{ matchId: unknown; coordinatorId?: unknown }>,
  isCoordinatorAlive?: (coordinatorId: string) => Promise<boolean | null>,
): Promise<string[]> {
  const orphanIds: string[] = [];
  for (const candidate of candidates) {
    const coordinatorId = typeof candidate.coordinatorId === "string" ? candidate.coordinatorId : "";
    const liveness = coordinatorId && isCoordinatorAlive ? await isCoordinatorAlive(coordinatorId) : false;
    // `null` means the liveness backend could not answer. Preserve the row and retry on the next
    // sweep rather than turning a transient Redis outage into a cluster-wide match cancellation.
    if (liveness === true || liveness === null) continue;
    orphanIds.push(String(candidate.matchId));
  }
  return orphanIds;
}

export async function recoverInterruptedMatches(
  isCoordinatorAlive?: (coordinatorId: string) => Promise<boolean | null>,
): Promise<number> {
  // Coordinator liveness is checked before opening the transaction because it is an external
  // Redis read. MongoDB transactions must not wait on another service or retry non-deterministic
  // network observations. Rows without coordinatorId belong to legacy single-node builds.
  const candidates = await matches()
    .find(
      { state: { $in: ["active", "settling"] } },
    )
    .toArray();
  const candidateReadAt = new Date();
  candidates.forEach((candidate) => validatedMatchDocument(candidate as unknown as MatchDoc, candidateReadAt));
  const orphanIds = await selectOrphanMatchIds(
    candidates.map((candidate) => ({ matchId: candidate.matchId, coordinatorId: candidate.coordinatorId })),
    isCoordinatorAlive,
  );

  const recovered = await withMongoTransaction(async (session) => {
    const transitionAt = new Date();
    const transitionUnix = validatedPlayerLastAction(Math.floor(transitionAt.getTime() / 1_000));
    const interrupted = await matches()
      .find(
        { matchId: { $in: orphanIds }, state: { $in: ["active", "settling"] } },
        { session },
      )
      .toArray();
    interrupted.forEach((match) => {
      const current = validatedMatchDocument(match as unknown as MatchDoc, transitionAt);
      validatedMatchDocument({
        ...current,
        state: "cancelled",
        cancelReason: "server_restart",
        endedAt: transitionAt,
      }, transitionAt);
    });
    const matchIds = interrupted.map((match) => String(match.matchId));
    if (matchIds.length > 0) {
      await matches().updateMany(
        { matchId: { $in: matchIds }, state: { $in: ["active", "settling"] } },
        { $set: { state: "cancelled", cancelReason: "server_restart", endedAt: transitionAt } },
        { session },
      );
    }
    // Protect every participant still owned by a live active/settling match, including matches on
    // peer nodes. Every other InGame profile is stale because PvP admission is the only backend
    // path that writes this status. This also heals partial rows from pre-transaction builds.
    const liveMatches = await matches()
      .find(
        { state: { $in: ["active", "settling"] } },
        { session },
      )
      .toArray();
    liveMatches.forEach((match) => validatedMatchDocument(match as unknown as MatchDoc, transitionAt));
    const protectedPlayerIds = liveMatches.flatMap((match) =>
      Array.isArray(match.players)
        ? match.players.map((participant: { playerId?: unknown }) => String(participant.playerId ?? "")).filter(Boolean)
        : []
    );
    const repairFilter = {
      "player.status": PlayerStatus.InGame,
      ...(protectedPlayerIds.length > 0 ? { id: { $nin: protectedPlayerIds } } : {}),
    };
    const repairCandidates = await players().find(repairFilter, { session }).toArray();
    const repairIds = repairCandidates.map((candidate) => candidate.id);
    validatedPlayerPresenceTransitions(
      repairCandidates,
      repairIds,
      PlayerStatus.Online,
      transitionUnix,
      transitionAt,
    );
    const presence = repairIds.length === 0
      ? { matchedCount: 0, modifiedCount: 0 }
      : await players().updateMany(
        { id: { $in: repairIds }, "player.status": PlayerStatus.InGame },
        {
          $set: {
            "player.status": PlayerStatus.Online,
            "player.lastAction": transitionUnix,
            updatedAt: transitionAt,
          },
        },
        { session },
      );
    if (presence.matchedCount !== repairIds.length) {
      throw new Error("Ranked restart recovery did not release every selected player.");
    }
    return { count: matchIds.length, repairedPlayers: presence.modifiedCount };
  });
  if (recovered.count > 0 || recovered.repairedPlayers > 0) {
    logger.match.event("Recovered interrupted matches", recovered);
  }
  return recovered.count;
}

const REWARDS = {
  winExperience: 30,
  loseExperience: 10,
  winMedals: 25,
  loseMedals: -12,
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
/** `VipWarbucksMultiplier` decoded from the 4.9.5 MainScene Constants component. */
export const VIP_BATTLE_WARBUCKS_MULTIPLIER = 1.5;

export interface PvpWarBucksPolicyConfiguration {
  readonly win: number;
  readonly loss: number;
}

const CSHARP_REWARD_INTEGER_MAX = 2_147_483_647;

/**
 * Validate the offline PvP economy policy without replacing a malformed deployment value.
 *
 * The stock reward parser stores `BattleRewards` in a C# `int` and independently applies the
 * recovered 1.5x VIP multiplier. A base grant is therefore valid only when both its normal and VIP
 * forms fit that signed width. Falling back to 800/400 after an operator supplied bad policy would
 * hide configuration drift and make nodes settle a different economy than the reviewed deploy.
 */
function exactPvpWarBucksPolicy(
  configuration: PvpWarBucksPolicyConfiguration,
): PvpWarBucksPolicyConfiguration {
  const exactGrant = (value: number, outcome: string): number => {
    const vipValue = Math.trunc(value * VIP_BATTLE_WARBUCKS_MULTIPLIER);
    if (!Number.isSafeInteger(value)
      || value < 0
      || value > CSHARP_REWARD_INTEGER_MAX
      || !Number.isSafeInteger(vipValue)
      || vipValue > CSHARP_REWARD_INTEGER_MAX) {
      throw new Error(`PvP ${outcome} WarBucks policy is invalid.`);
    }
    return value;
  };
  return {
    win: exactGrant(configuration.win, "win"),
    loss: exactGrant(configuration.loss, "loss"),
  };
}

// Resolve environment-owned economy authority during module startup and keep it immutable for the
// process. Every match on one node must settle against the same reviewed Win/Loss policy.
const CONFIGURED_PVP_WARBUCKS_POLICY = Object.freeze(exactPvpWarBucksPolicy({
  win: config.pvpWinWarBucks,
  loss: config.pvpLoseWarBucks,
}));

export function pvpWarBucksPolicy(
  configuration?: PvpWarBucksPolicyConfiguration,
): PvpWarBucksPolicyConfiguration {
  return configuration === undefined
    ? CONFIGURED_PVP_WARBUCKS_POLICY
    : exactPvpWarBucksPolicy(configuration);
}

export interface PvpWinStreakTransition {
  state: PvpWinStreakState;
  baseWarBucks: number;
  warBucks: number;
}

/**
 * Advance the timed streak from a server-confirmed result and derive its immutable payout.
 *
 * The previous streak is active only while `timestamp + 200 > settledAt`, matching the
 * recovered WinStreak.deadline strict comparison. Future/corrupt timestamps are not allowed
 * to preserve a streak forever. A loss clears both fields. A win after expiry starts again at
 * tier one; an in-window win advances up to the last verified tier. VIP multiplication is
 * calculated on this component separately because IIGFODGJBFA truncates BattleRewards and
 * Winstreak independently before summing them.
 */
export function advancePvpWinStreak(
  current: PvpWinStreakState | undefined,
  won: boolean,
  isVip: boolean,
  settledAtUnix: number,
): PvpWinStreakTransition {
  if (!Number.isSafeInteger(settledAtUnix) || settledAtUnix < 0) {
    throw new Error("PvP win-streak settlement time is invalid.");
  }
  const previous = validatedPvpWinStreak(current, settledAtUnix);
  if (!won) return { state: { winCount: 0, timestamp: 0 }, baseWarBucks: 0, warBucks: 0 };

  const previousCount = previous.winCount;
  const previousTimestamp = previous.timestamp;
  const continues = previousCount > 0
    && previousTimestamp <= settledAtUnix
    && previousTimestamp + PVP_WIN_STREAK_INTERVAL_SECONDS > settledAtUnix;
  const winCount = continues
    ? Math.min(previousCount + 1, PVP_WIN_STREAK_WARBUCKS.length)
    : 1;
  const baseWarBucks = PVP_WIN_STREAK_WARBUCKS[winCount - 1];
  const warBucks = isVip
    ? Math.trunc(baseWarBucks * VIP_BATTLE_WARBUCKS_MULTIPLIER)
    : baseWarBucks;
  return {
    state: { winCount, timestamp: settledAtUnix },
    baseWarBucks,
    warBucks,
  };
}

/**
 * Resolve the base and durable normal PvP WarBucks grant.
 *
 * The recovered GameEnded request echoes Fusebox's `BattleWarbucksRewards.Win/Loss` values,
 * but accepting either field would let a modified client mint arbitrary currency. The old
 * remote document is not packaged in the 1.6.0 or 4.9.5 APK, so the offline server uses the
 * reviewed, environment-tunable defaults in config.ts. IIGFODGJBFA applies the 1.5x VIP
 * multiplier to the unmultiplied `Warbucks.BattleRewards` component and truncates the
 * positive float-to-int conversion; durable state performs the identical calculation.
 */
export function pvpWarBucksAmounts(won: boolean, isVip: boolean): {
  baseWarBucks: number;
  warBucks: number;
} {
  const baseWarBucks = won
    ? CONFIGURED_PVP_WARBUCKS_POLICY.win
    : CONFIGURED_PVP_WARBUCKS_POLICY.loss;
  const warBucks = isVip
    ? Math.trunc(baseWarBucks * VIP_BATTLE_WARBUCKS_MULTIPLIER)
    : baseWarBucks;
  if (!Number.isSafeInteger(warBucks)) throw new Error("PvP VIP WarBucks overflowed.");
  return { baseWarBucks, warBucks };
}

export interface PvpLeagueReward {
  baseWarBucks: number;
  warBucks: number;
  squadPoints: number;
}

/**
 * Resolve the source-owned ranked-win bonuses advertised by the active league.
 *
 * `PlayerLeaderboards.REWARDWARBUCKS/REWARDSQUADPOINTS` and
 * `StringConstants.BeginnersRewards` are complete in MainScene. The recovered result parser
 * has dedicated `Warbucks.League` and outer `squadPoints` fields for these values. A loss is
 * intentionally zero: the scene does not prove that league bonuses were paid on defeats, so
 * the offline backend follows the existing winner-only policy instead of creating currency.
 * VIP multiplication is separate because IIGFODGJBFA truncates the League component on its
 * own, independently from BattleRewards and Winstreak.
 */
export function pvpLeagueReward(
  won: boolean,
  isVip: boolean,
  beginnersLeague: number,
  leagueTier: number,
): PvpLeagueReward {
  if (!won) return { baseWarBucks: 0, warBucks: 0, squadPoints: 0 };
  // Positive beginner IDs select only the recovered three-row table. Do not silently fall
  // through to the much larger normal-league payout if persistent league state is corrupt.
  const beginner = BEGINNER_LEAGUE_REWARDS.find((row) => row.beginnersLeague === beginnersLeague);
  if (beginnersLeague > 0 && !beginner) {
    throw new Error(`Unsupported beginner league ${beginnersLeague}.`);
  }
  const source = beginner ?? playerLeagueRule(leagueTier);
  const baseWarBucks = source.rewardWarBucks;
  const warBucks = isVip
    ? Math.trunc(baseWarBucks * VIP_BATTLE_WARBUCKS_MULTIPLIER)
    : baseWarBucks;
  if (!Number.isSafeInteger(warBucks)) throw new Error("PvP VIP league WarBucks overflowed.");
  return { baseWarBucks, warBucks, squadPoints: source.rewardSquadPoints };
}

export interface PvpMedalBalances {
  delta: number;
  skill: number;
  medalsBalance: number;
}

/**
 * Apply the replacement backend's reviewed medal policy to both client-visible mirrors.
 *
 * DatabasePlayer identifies `Skill` as global medals and `MedalsBalance` as weekly/league
 * medals. The original service's base medal document is absent, so +25/-12 remains explicit
 * offline policy. Previously settlement changed only MedalsBalance while returning an unchanged
 * Skill, which made the global ladder permanently static. Both values now use the same proven
 * result and zero floor. League WINFACTOR/LOSEFACTOR values remain unapplied until the missing
 * original formula establishes which medal mirror and rounding rule they controlled.
 */
export function pvpMedalBalances(
  currentSkill: number,
  currentLeagueMedals: number,
  won: boolean,
): PvpMedalBalances {
  if (!Number.isSafeInteger(currentSkill) || currentSkill < 0
    || !Number.isSafeInteger(currentLeagueMedals) || currentLeagueMedals < 0) {
    throw new Error("PvP medal balances are invalid.");
  }
  const delta = won ? REWARDS.winMedals : REWARDS.loseMedals;
  const skill = Math.max(0, currentSkill + delta);
  const medalsBalance = Math.max(0, currentLeagueMedals + delta);
  if (!Number.isSafeInteger(skill) || !Number.isSafeInteger(medalsBalance)) {
    throw new Error("PvP medal balance overflowed.");
  }
  return { delta, skill, medalsBalance };
}

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
  battleWarBucks = 0,
  winStreakWarBucks = 0,
  leagueWarBucks = 0,
): Record<string, unknown> {
  return {
    Warbucks: {
      // The first reconstruction omitted this object entirely, so ordinary PvP never paid
      // the game's main soft currency. Send the base component: IsVip tells the recovered
      // parser to apply its local 1.5x constant exactly once for display and wallet parity.
      BattleRewards: resultAvailable ? battleWarBucks : 0,
      ExtraRewards: 0,
      Winstreak: resultAvailable ? winStreakWarBucks : 0,
      League: resultAvailable ? leagueWarBucks : 0,
      offerMult: 1,
    },
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

export async function createMatch(a: MatchPlayer, b: MatchPlayer, coordinatorId?: string): Promise<string> {
  validateMatchParticipants(a, b);
  const matchId = randomUUID();
  const normalizedCoordinatorId = coordinatorId?.trim();
  if (normalizedCoordinatorId && (normalizedCoordinatorId.length > 128 || /\p{Cc}/u.test(normalizedCoordinatorId))) {
    throw new MatchAdmissionError("Match coordinator identity is invalid.");
  }
  const createdAt = new Date();
  const createdAtUnix = validatedPlayerLastAction(Math.floor(createdAt.getTime() / 1_000));
  const doc: MatchDoc = validatedMatchDocument({
    matchId,
    ...(normalizedCoordinatorId ? { coordinatorId: normalizedCoordinatorId } : {}),
    players: [a, b],
    state: "active",
    createdAt,
  }, createdAt);

  await withMongoTransaction(async (session) => {
    const playerIds = [a.playerId, b.playerId];
    const participants = await players().find(
      { id: { $in: playerIds } },
      { session },
    ).toArray();
    // Admission reserves status on the full durable account. A narrow projection could prove the
    // five queue fields while silently bypassing malformed credential/profile/progression
    // authority, then normalize that damaged row through the status write below.
    participants.forEach((participant) => validatedPlayerAccountEnvelope(participant));
    if (participants.length !== 2
      || participants.some((participant) => participant.player?.status === PlayerStatus.InGame)) {
      throw new MatchAdmissionError("A match participant no longer exists or is already in battle.");
    }
    const byId = new Map(participants.map((participant) => [String(participant.id), participant]));
    if ([a, b].some((snapshot) => {
      const current = byId.get(snapshot.playerId);
      return !current
        || current.accountName !== snapshot.name
        || current.armyPower !== snapshot.armyPower
        || current.leagueTier !== snapshot.leagueTier;
    })) {
      throw new MatchAdmissionError("A match participant snapshot changed during pairing.");
    }
    // Prove the complete successor accounts before inserting the room. Transaction rollback
    // protects both profiles, but it cannot make an invalid projected public snapshot safe.
    validatedPlayerPresenceTransitions(
      participants,
      playerIds,
      PlayerStatus.InGame,
      createdAtUnix,
      createdAt,
    );

    // Insert the durable room and reserve both profiles inside one snapshot transaction. A
    // concurrent pairing touches the same player rows, so MongoDB aborts/retries one transaction;
    // its retry then observes InGame and fails without leaving a second active match. A crash can
    // no longer persist only the match row or only one player's status.
    await matches().insertOne(doc, { session });
    const reserved = await players().updateMany(
      { id: { $in: playerIds }, "player.status": { $ne: PlayerStatus.InGame } },
      {
        $set: {
          // Ranked admission owns both parts of public presence. Keeping the timestamp on the
          // same transaction prevents a valid InGame reservation from looking stale in rosters.
          "player.status": PlayerStatus.InGame,
          "player.lastAction": createdAtUnix,
          updatedAt: createdAt,
        },
      },
      { session },
    );
    if (reserved.matchedCount !== 2) {
      throw new MatchAdmissionError("Match participants changed during admission.");
    }
    return true;
  });
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

/**
 * Apply every personal counter proven by one confirmed ranked PvP settlement.
 *
 * This helper intentionally contains no database write and no client-authored values. The
 * caller must execute it only while atomically claiming an active match. Keeping assignment,
 * ranked-win, and squad-point achievement progress in the resulting progression document fixes
 * the former post-commit projection window: a process crash can no longer leave the match reward
 * committed while these counters are missing, and a finished-match retry cannot count them twice.
 */
export function applyConfirmedPvpProgressionState(
  state: PlayerProgressionState,
  settledAtUnix: number,
  won: boolean,
  squadPointsAwarded: number,
): PlayerProgressionState {
  if (!Number.isSafeInteger(settledAtUnix) || settledAtUnix < 0) {
    throw new Error("PvP progression settlement time is invalid.");
  }
  if (!Number.isSafeInteger(squadPointsAwarded) || squadPointsAwarded < 0) {
    throw new Error("PvP squad-point achievement amount is invalid.");
  }

  let next = recordPvpAssignmentProgressState(state, settledAtUnix, won).state;
  // A zero increment still materializes/migrates the recovered achievement wire model on a
  // legacy account. The win value itself advances only for a server-confirmed winner.
  next = advanceAchievementState(next, 2, won ? 1 : 0).state;
  next = advanceAchievementState(next, 14, squadPointsAwarded).state;
  return next;
}

/**
 * Compose the personal PvP counters with the one-battle rental transition.
 *
 * Returning the sale payload beside the next progression snapshot gives the transaction one
 * value to persist in both the player document and immutable match receipt. This is deliberately
 * pure so receipt/revision behavior can be verified without relying on a live MongoDB replica set.
 */
export function applyConfirmedPvpBattleState(
  state: PlayerProgressionState,
  settledAtUnix: number,
  won: boolean,
  squadPointsAwarded: number,
  battleId: string,
): { state: PlayerProgressionState; rental?: RentalWireOffer } {
  const progressed = applyConfirmedPvpProgressionState(
    state,
    settledAtUnix,
    won,
    squadPointsAwarded,
  );
  const rental = advanceRentalAfterBattleState(progressed, battleId, settledAtUnix);
  return { state: rental.state, rental: rental.saleOffer };
}

export interface MatchPlayerReward {
  /** Unmultiplied Warbucks.BattleRewards value from server-owned offline reward policy. */
  baseWarBucks: number;
  /** Actual normal battle WarBucks committed after the settlement-time VIP multiplier. */
  warBucks: number;
  /** Unmultiplied Warbucks.Winstreak component selected from the verified scene tier. */
  baseWinStreakWarBucks: number;
  /** Actual win-streak component committed after its independent VIP multiplication. */
  winStreakWarBucks: number;
  /** Immutable outer GameEnded fields used to restore WinStreakManager on response/retry. */
  winCount: number;
  winStreakTimestamp: number;
  /** Unmultiplied source tier value returned through Warbucks.League. */
  baseLeagueWarBucks: number;
  /** Durable league component after its independent settlement-time VIP multiplier. */
  leagueWarBucks: number;
  /** Exact source tier squad-point grant returned by the outer GameEnded field. */
  squadPoints: number;
  /** Immutable post-match global medal value returned through outer `Skill`. */
  skill: number;
  /** Immutable post-match weekly/league medal value. */
  medalsBalance: number;
  /** Exact placement counter and beginner league returned with this result. */
  placementMatchesRequired: number;
  beginnersLeague: number;
  /** Present only when this confirmed match consumed placement and entered a managed league. */
  enteredLeague?: string;
  enteredNormalLeague?: boolean;
  leagueEvaluation?: number;
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
  /** Marker distinguishing new no-rental receipts from legacy receipts that need repair. */
  rentalSettled: true;
  /** Exact post-trial sale dialog committed with this match and replayed from its receipt. */
  rental?: RentalWireOffer;
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
  battleId: string,
  playerId: string,
  won: boolean,
  usedCards: readonly string[],
  settledAt: Date,
): Promise<CoreGrant> {
  const player = await players().findOne({ id: playerId }, { session });
  if (!player) throw new Error(`Match participant ${playerId} was not found.`);
  // Authentication happened before matchmaking, but terminal settlement re-reads both players in
  // a later transaction. Re-prove each complete account before the first irreversible PvP reward.
  validatedPlayerAccountEnvelope(player);
  const initialState = progressionForPlayer(player);
  const settlementUnix = Math.floor(settledAt.getTime() / 1_000);
  // A corrupt non-finite deadline must abort the complete terminal transaction. Treating
  // Infinity as active would grant permanent paid battle multipliers and publish an immutable
  // receipt that could no longer be repaired safely after settlement.
  const isVip = isVipActiveAt(initialState.vipExpiration, settlementUnix);
  const { baseExperience, experience } = pvpExperienceAmounts(won, isVip);
  const { baseWarBucks, warBucks } = pvpWarBucksAmounts(won, isVip);
  const winStreak = advancePvpWinStreak(initialState.pvpWinStreak, won, isVip, settlementUnix);
  const leagueReward = pvpLeagueReward(
    won,
    isVip,
    player.player.beginnersLeague,
    player.player.leagueTier,
  );
  const medals = pvpMedalBalances(player.player.skill, player.player.medalsBalance, won);
  // The profile mirror alone is not membership authority: a leave/kick transaction may have
  // removed the roster row just before settlement. Resolve membership from the squad document
  // in this same MongoDB snapshot. A concurrent roster change then causes a write conflict and
  // retries the whole transaction instead of granting points against stale membership.
  const activeSquad = player.player.squadName
    ? await squads().findOne(
      { name: player.player.squadName, "members.playerId": playerId },
      { session },
    )
    : null;
  if (activeSquad) validatedSquadDocument(activeSquad, settledAt);
  const squadName = activeSquad?.name ?? "";
  const squadPoints = squadName ? leagueReward.squadPoints : 0;
  const consumed = consumePvpUsedCardsState(initialState, usedCards);
  // AchievementFiveCardsPlayedInMatch is a one-match maximum, not another lifetime counter.
  // Couple it to the exact validated inventory consumption that already commits with PvP rewards;
  // a retry reads the immutable finished match and never executes this participant transition again.
  const cardsInMatchAchievement = synchronizeCardsPlayedInMatchAchievementState(
    consumed.state,
    consumed.usedCards.length,
  );
  // Daily assignments plus ranked-win/squad-point achievements are progression data, so they
  // must be calculated before the guarded player replacement below. The match's active ->
  // finished compare-and-set is the exactly-once receipt for all three counters.
  const confirmedBattle = applyConfirmedPvpBattleState(
    cardsInMatchAchievement.state,
    settlementUnix,
    won,
    squadPoints,
    battleId,
  );
  const leveled = applyLevelExperienceState(
    confirmedBattle.state,
    player.player.level,
    experience,
  );
  // Advance the periodic paid-VIP benefit before constructing the canonical progression.
  // This pure transition persists its countdown, visual parts, and duplicate WarBucks in the
  // same guarded player write and exposes presentation data for the immutable match receipt.
  const vipLootboxes = applyVipBattleLootboxState(leveled.state, isVip);
  const baseGold = leveled.goldGranted;
  const gold = pvpLevelGoldAmount(baseGold, isVip);
  const vipLevelGoldBonus = gold - baseGold;
  const totalPvpWarBucks = warBucks + winStreak.warBucks + leagueReward.warBucks;
  const settledGold = checkedRewardBalance(vipLootboxes.state.gold, vipLevelGoldBonus, "PvP VIP level Gold");
  const settledWarBucks = checkedRewardBalance(
    vipLootboxes.state.warBucks,
    totalPvpWarBucks,
    "PvP WarBucks",
  );
  // applyLevelExperienceState grants the source row's base Gold. Add only the VIP delta here
  // so the level transition remains reusable and the progression wallet equals the amount
  // IIGFODGJBFA adds after applying its VipGoldMultiplier to GameGold.
  let canonical = canonicalProgression({
    ...vipLootboxes.state,
    gold: settledGold,
    warBucks: settledWarBucks,
    pvpWinStreak: winStreak.state,
  });
  const levelChanged = leveled.levelTo !== leveled.levelFrom;
  const nextArmyPower = levelChanged
    ? calculateArmyPower({
      ...player,
      progression: canonical,
      player: { ...player.player, level: leveled.levelTo },
    }).total
    : player.player.armyPower;
  const beginnerAdvance = advanceBeginnerLeagueAfterPvp(
    player.player,
    medals.medalsBalance,
    settlementUnix,
  );
  const normalLeagueAdvance = beginnerAdvance ? null : advancePlayerLeaguePlacementAfterPvp(
    player.player,
    settlementUnix,
  );
  const leagueAdvance = beginnerAdvance ?? normalLeagueAdvance;
  // The league achievement reads DatabasePlayer.leagueTier, so persist its monotonic projection
  // in the same confirmed-PvP transaction that consumes placement/beginner progression. This
  // prevents a lost response or duplicate result report from creating a separate achievement
  // event, and also migrates accounts whose existing league predates group 13 support.
  canonical = synchronizeLeagueAchievementState(
    canonical,
    leagueAdvance?.leagueTier ?? player.player.leagueTier,
  ).state;
  // PvP composes card consumption, assignments, achievements, XP, VIP lootboxes, currencies,
  // win streak, and league projection before one full player replacement. Prove the final state
  // once here so no helper's unsafe balance or revision can reach the terminal transaction.
  canonical = canonicalProgression(validatedProgressionSuccessor(initialState, canonical));
  const enteredNormalLeague = beginnerAdvance?.enteredNormalLeague
    ? beginnerAdvance
    : normalLeagueAdvance?.enteredLeague
      ? normalLeagueAdvance
      : null;
  // The pure recovered placement decision identifies the tier and season window. Actual
  // membership is allocated here, inside the same transaction as rewards and the terminal match
  // row, so concurrent placements cannot overfill one division or leave capacity without a player.
  const allocatedLeague = enteredNormalLeague
    ? await allocatePlayerLeagueDivision(session, enteredNormalLeague.leagueTier, settlementUnix)
    : null;
  const leagueFields: Record<string, unknown> = leagueAdvance
    ? {
      leagueTier: leagueAdvance.leagueTier,
      "player.leagueTier": leagueAdvance.leagueTier,
      "player.leagueId": allocatedLeague?.leagueId ?? leagueAdvance.leagueId,
      "player.leagueDivision": allocatedLeague?.division ?? leagueAdvance.leagueDivision,
      "player.remainingMatches": leagueAdvance.remainingMatches,
    }
    : {};
  const placementMatchesRequired = leagueAdvance?.remainingMatches ?? player.player.remainingMatches;
  const beginnersLeague = beginnerAdvance?.beginnersLeague ?? player.player.beginnersLeague;
  const medalsBalance = beginnerAdvance?.medalsBalance ?? medals.medalsBalance;
  const nextExperience = checkedPlayerLifetimeExperience(player.experience, experience);
  const nextSquadPoints = checkedPlayerLifetimeSquadPoints(player.squadPoints, squadPoints);
  const nextLastAction = validatedPlayerLastAction(settlementUnix);
  const nextLeagueTier = leagueAdvance?.leagueTier ?? player.player.leagueTier;
  const nextLeagueId = leagueAdvance
    ? allocatedLeague?.leagueId ?? leagueAdvance.leagueId
    : player.player.leagueId;
  const nextLeagueDivision = leagueAdvance
    ? allocatedLeague?.division ?? leagueAdvance.leagueDivision
    : player.player.leagueDivision;
  const nextRemainingMatches = leagueAdvance?.remainingMatches ?? player.player.remainingMatches;

  // Validate the exact account produced by the aggregation pipeline before its first write. This
  // catches overflow and cross-field drift across root mirrors, public profile fields, league
  // identity, progression, presence, and audit time while the whole match can still roll back.
  validatedPlayerAccountEnvelope({
    ...player,
    leagueTier: nextLeagueTier,
    armyPower: nextArmyPower,
    experience: nextExperience,
    squadPoints: nextSquadPoints,
    progression: canonical,
    player: {
      ...player.player,
      experience: nextExperience,
      squadPoints: nextSquadPoints,
      skill: medals.skill,
      medalsBalance,
      beginnersLeague,
      level: leveled.levelTo,
      armyPower: nextArmyPower,
      status: PlayerStatus.Online,
      lastAction: nextLastAction,
      leagueTier: nextLeagueTier,
      leagueId: nextLeagueId,
      leagueDivision: nextLeagueDivision,
      remainingMatches: nextRemainingMatches,
    },
    updatedAt: settledAt,
  });

  const update = await players().updateOne(
    { id: playerId, ...progressionRevisionFilter(player) },
    [
      {
        $set: {
          progression: { $literal: canonical },
          // These literal successors were checked above. Using `$add` here would let MongoDB
          // apply rewards to a non-finite or overflowing imported counter after validation.
          experience: nextExperience,
          squadPoints: nextSquadPoints,
          "player.experience": nextExperience,
          "player.squadPoints": nextSquadPoints,
          // Skill and MedalsBalance are global and weekly medal mirrors in DatabasePlayer.
          // Use literal prevalidated values so the immutable receipt exactly matches this write.
          "player.skill": medals.skill,
          "player.medalsBalance": medalsBalance,
          "player.beginnersLeague": beginnersLeague,
          "player.level": leveled.levelTo,
          "player.armyPower": nextArmyPower,
          armyPower: nextArmyPower,
          "player.status": PlayerStatus.Online,
          // Settlement releases presence at the exact authoritative settlement second. A later
          // retry replays the terminal receipt and cannot publish a second heartbeat.
          "player.lastAction": nextLastAction,
          // Beginner/placement advances occur only inside this confirmed two-party settlement.
          // Folding them into the same player write prevents a forged standalone request or
          // replay from changing leagues without the matching medal result.
          ...leagueFields,
          updatedAt: settledAt,
        },
      },
    ],
    { session },
  );
  if (update.modifiedCount !== 1) throw new Error(`Concurrent settlement rejected player ${playerId}.`);
  if (squadPoints > 0) {
    // The squad leaderboard total and embedded member contribution are not a best-effort cache:
    // both are client-visible economy/progression state. Updating them inside the match
    // transaction guarantees equality with the player's mirrored lifetime squad points.
    const rewardedMember = activeSquad!.members.find((member) => member.playerId === playerId)!;
    const squadUpdatedAt = nextSquadUpdatedAt(activeSquad!, settledAt);
    // Prove all three incremented mirrors before MongoDB applies them. A corrupt or exhausted
    // squad counter must abort the same transaction as player rewards and the terminal match.
    validatedSquadDocument({
      ...activeSquad!,
      experience: activeSquad!.experience + squadPoints,
      squadPoints: activeSquad!.squadPoints + squadPoints,
      members: activeSquad!.members.map((member) => member.playerId === playerId
        ? { ...member, squadPoints: rewardedMember.squadPoints + squadPoints }
        : member),
      updatedAt: squadUpdatedAt,
    }, squadUpdatedAt);
    const squadUpdate = await squads().updateOne(
      { name: squadName, "members.playerId": playerId },
      {
        $inc: { experience: squadPoints, squadPoints, "members.$.squadPoints": squadPoints },
        $set: { updatedAt: squadUpdatedAt },
      },
      { session },
    );
    if (squadUpdate.modifiedCount !== 1) {
      throw new Error(`Concurrent squad-point settlement rejected player ${playerId}.`);
    }
  }
  return {
    playerId,
    won,
    squadName,
    squadPoints,
    reward: {
      baseWarBucks,
      warBucks,
      baseWinStreakWarBucks: winStreak.baseWarBucks,
      winStreakWarBucks: winStreak.warBucks,
      winCount: winStreak.state.winCount,
      winStreakTimestamp: winStreak.state.timestamp,
      baseLeagueWarBucks: leagueReward.baseWarBucks,
      leagueWarBucks: leagueReward.warBucks,
      squadPoints,
      skill: medals.skill,
      medalsBalance,
      placementMatchesRequired,
      beginnersLeague,
      ...(enteredNormalLeague
        ? {
          enteredLeague: allocatedLeague?.leagueId ?? enteredNormalLeague.leagueId,
          enteredNormalLeague: true,
          leagueEvaluation: allocatedLeague?.endsAt ?? enteredNormalLeague.endsAt,
        }
        : {}),
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
      rentalSettled: true,
      rental: confirmedBattle.rental,
    },
  };
}

export async function getMatch(matchId: string): Promise<MatchDoc | null> {
  const match = (await matches().findOne({ matchId })) as unknown as MatchDoc | null;
  return match ? validatedMatchDocument(match) : null;
}

export interface JoinActiveMatchResult {
  match: MatchDoc;
  joinedCount: number;
  started: boolean;
  /** True only for the request that won the waiting-to-start compare-and-set. */
  activatedByCaller: boolean;
}

export function distributedRoomJoinState(match: MatchDoc): {
  allowedPlayerIds: string[];
  joinedPlayerIds: string[];
  ready: boolean;
} {
  const allowedPlayerIds = [...new Set(match.players.map((player) => player.playerId))];
  const joinedPlayerIds = [...new Set(match.joinedPlayerIds ?? [])]
    .filter((id) => allowedPlayerIds.includes(id));
  return {
    allowedPlayerIds,
    joinedPlayerIds,
    ready: allowedPlayerIds.length > 0 && allowedPlayerIds.every((id) => joinedPlayerIds.includes(id)),
  };
}

/**
 * Durably admit one authenticated assigned participant to a distributed PvP room.
 *
 * `$addToSet` makes reconnect/retry joins idempotent. Once all immutable participants are present,
 * a second compare-and-set writes roomStartedAt exactly once. Concurrent joins may both observe the
 * active room, but only one publishes the initial MatchStart fan-out.
 */
export async function joinActiveMatch(matchId: string, playerId: string): Promise<JoinActiveMatchResult | null> {
  if (!matchId || !playerId || matchId.length > 128 || playerId.length > 128) return null;
  const beforeAdmission = await getMatch(matchId);
  if (!beforeAdmission
    || beforeAdmission.state !== "active"
    || !beforeAdmission.players.some((participant) => participant.playerId === playerId)) return null;
  const projectedJoined = [...new Set([...(beforeAdmission.joinedPlayerIds ?? []), playerId])];
  validatedMatchDocument({ ...beforeAdmission, joinedPlayerIds: projectedJoined });
  const admitted = await matches().updateOne(
    { matchId, state: "active", "players.playerId": playerId },
    { $addToSet: { joinedPlayerIds: playerId } },
  );
  if (admitted.matchedCount !== 1) return null;

  let match = await getMatch(matchId);
  if (!match || match.state !== "active" || !match.players.some((player) => player.playerId === playerId)) return null;
  const { allowedPlayerIds, joinedPlayerIds, ready } = distributedRoomJoinState(match);
  let activatedByCaller = false;
  if (ready) {
    const roomStartedAt = new Date();
    validatedMatchDocument({ ...match, roomStartedAt }, roomStartedAt);
    const activation = await matches().updateOne(
      {
        matchId,
        state: "active",
        roomStartedAt: { $exists: false },
        joinedPlayerIds: { $all: allowedPlayerIds },
      },
      { $set: { roomStartedAt } },
    );
    activatedByCaller = activation.modifiedCount === 1;
    match = await getMatch(matchId);
    if (!match || match.state !== "active") return null;
  }
  return {
    match,
    joinedCount: joinedPlayerIds.length,
    started: match.roomStartedAt instanceof Date,
    activatedByCaller,
  };
}

export async function findStartedMatchForPlayer(playerId: string): Promise<MatchDoc | null> {
  const match = await matches().findOne({
    state: "active",
    roomStartedAt: { $exists: true },
    "players.playerId": playerId,
    joinedPlayerIds: playerId,
  }) as unknown as MatchDoc | null;
  return match ? validatedMatchDocument(match) : null;
}

/** Find the caller's server-assigned pair only while it is still safe to cancel without a result. */
export async function findUnstartedMatchForPlayer(playerId: string): Promise<MatchDoc | null> {
  if (!playerId || playerId.length > 128) return null;
  const match = await matches().findOne({
    state: "active",
    roomStartedAt: { $exists: false },
    "players.playerId": playerId,
  }) as unknown as MatchDoc | null;
  return match ? validatedMatchDocument(match) : null;
}

export async function markMatchParticipantDisconnected(matchId: string, playerId: string): Promise<MatchDoc | null> {
  const path = `disconnectedAt.${playerId}`;
  const current = await getMatch(matchId);
  if (!current || current.state !== "active" || !current.players.some((player) => player.playerId === playerId)) {
    return null;
  }
  const disconnectedAt = new Date();
  validatedMatchDocument({
    ...current,
    disconnectedAt: { ...(current.disconnectedAt ?? {}), [playerId]: disconnectedAt },
  }, disconnectedAt);
  const updated = await matches().findOneAndUpdate(
    {
      matchId,
      state: "active",
      roomStartedAt: { $exists: true },
      "players.playerId": playerId,
      joinedPlayerIds: playerId,
    },
    { $set: { [path]: disconnectedAt } },
    { returnDocument: "after" },
  );
  return updated ? validatedMatchDocument(updated as unknown as MatchDoc, disconnectedAt) : null;
}

/** Prove one reconnect is clearing only the disconnect generation it originally observed. */
export function matchesParticipantDisconnectMarker(
  match: MatchDoc,
  playerId: string,
  expectedDisconnectedAt: Date,
): boolean {
  const current = match.disconnectedAt?.[playerId];
  return match.state === "active"
    && match.players.some((participant) => participant.playerId === playerId)
    && expectedDisconnectedAt instanceof Date
    && Number.isFinite(expectedDisconnectedAt.getTime())
    && current instanceof Date
    && current.getTime() === expectedDisconnectedAt.getTime();
}

export async function clearMatchParticipantDisconnected(
  matchId: string,
  playerId: string,
  expectedDisconnectedAt: Date,
): Promise<boolean> {
  const path = `disconnectedAt.${playerId}`;
  const current = await getMatch(matchId);
  const observedDisconnectedAt = current?.disconnectedAt?.[playerId];
  if (!current
    || !(observedDisconnectedAt instanceof Date)
    || !matchesParticipantDisconnectMarker(current, playerId, expectedDisconnectedAt)) return false;
  const disconnectedAt = { ...current.disconnectedAt };
  delete disconnectedAt[playerId];
  validatedMatchDocument({
    ...current,
    ...(Object.keys(disconnectedAt).length > 0 ? { disconnectedAt } : { disconnectedAt: undefined }),
  });
  const cleared = await matches().updateOne(
    // Compare the exact marker read above. A socket can reconnect and disconnect again while this
    // request is awaiting MongoDB; an existence-only filter would erase that newer disconnect and
    // prevent its own grace timer from ever resolving.
    { matchId, state: "active", [path]: observedDisconnectedAt },
    { $unset: { [path]: "" } },
  );
  return cleared.modifiedCount === 1;
}

export async function isMatchParticipant(matchId: string, playerId: string): Promise<boolean> {
  const match = await getMatch(matchId);
  return Boolean(match?.players.some((participant) => participant.playerId === playerId));
}

export interface RelayedCardPlayResult {
  cards: string[];
  replayed: boolean;
}

/**
 * Canonicalize the only recovered MatchEvent data shape that may become gameplay authority.
 *
 * Unknown event Data remains opaque transport, but CardPlayed can eventually consume inventory.
 * It therefore requires exactly one JSON-number sequence and one string card identity. Extra keys
 * and alternate aliases are rejected rather than stripped before durable evidence and opponent
 * delivery. The shared card-list parser retains the same identity bounds as terminal UsedCards.
 */
export function validatedCardPlayedEventData(value: unknown): CardPlayedEventData {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(CARD_NOT_FOUND, "CardPlayed Data is invalid.");
  }
  const record = value as Record<string, unknown>;
  const keys = Object.keys(record);
  if (keys.length !== 2 || !keys.includes("Sequence") || !keys.includes("CardId")) {
    throw new ApiError(CARD_NOT_FOUND, "CardPlayed Data is invalid.");
  }
  const Sequence = validatedRelayedCardSequence(record.Sequence);
  const [CardId] = parsePvpUsedCards([record.CardId]);
  if (!CardId) {
    throw new ApiError(CARD_NOT_FOUND, "CardPlayed Data is invalid.");
  }
  return { Sequence, CardId };
}

/**
 * Require the replacement WebSocket contract's zero-based sequence to remain a JSON number.
 * `Number(value)` is unsafe here because null, false, an empty string, and an empty array all
 * coerce to zero, which could create or replay durable card-consumption evidence for sequence 0.
 */
export function validatedRelayedCardSequence(value: unknown): number {
  if (typeof value !== "number"
    || !Number.isInteger(value)
    || value < 0
    || value >= MAX_PVP_CARDS_PER_MATCH) {
    throw new ApiError(CARD_NOT_FOUND, "CardPlayed sequence is invalid.");
  }
  return value;
}

/**
 * Validate one participant's ordered CardPlayed evidence without mutating the stored list.
 *
 * Sequence numbers make a lost acknowledgement retry distinguishable from a second activation.
 * A repeated sequence is accepted only for the same CardId, gaps are rejected, and the recovered
 * six-slot selection limit bounds both memory and the eventual inventory debit.
 */
export function applyRelayedCardPlay(
  existing: readonly string[],
  sequence: unknown,
  cardId: string,
): RelayedCardPlayResult {
  const checkedSequence = validatedRelayedCardSequence(sequence);
  const [normalized] = parsePvpUsedCards([cardId]);
  if (!normalized) {
    throw new ApiError(CARD_NOT_FOUND, "CardPlayed sequence or identity is invalid.");
  }
  if (checkedSequence < existing.length) {
    if (existing[checkedSequence] !== normalized) {
      throw new ApiError(CARD_NOT_FOUND, "CardPlayed sequence was already used for another card.");
    }
    return { cards: [...existing], replayed: true };
  }
  if (checkedSequence !== existing.length || existing.length >= MAX_PVP_CARDS_PER_MATCH) {
    throw new ApiError(CARD_NOT_FOUND, "CardPlayed events must be contiguous and bounded.");
  }
  return { cards: [...existing, normalized], replayed: false };
}

/** Require the terminal list to reproduce the durable relay evidence byte-for-byte. */
export function validateRelayedCardReport(
  relayedCards: readonly string[],
  reportedCards: readonly string[],
): string[] {
  const normalized = parsePvpUsedCards([...reportedCards]);
  if (
    normalized.length !== relayedCards.length
    || normalized.some((cardId, index) => cardId !== relayedCards[index])
  ) {
    throw new ApiError(CARD_NOT_FOUND, "UsedCards does not match sequenced CardPlayed evidence.");
  }
  return [...relayedCards];
}

/**
 * Return only CardPlayed effects proven handed to the opponent transport.
 *
 * Card evidence is stored before socket delivery so a lost publish can be retried safely. That
 * pre-delivery row is not inventory-consumption authority: only a contiguous zero-based delivery
 * prefix represents effects the opponent could have observed. Gaps or reordered markers indicate
 * damaged durable authority and must not be normalized into a cheaper terminal card report.
 */
export function deliveredRelayedCards(
  relayedCards: readonly string[],
  deliveredSequences: readonly number[],
): string[] {
  const cards = parsePvpUsedCards([...relayedCards]);
  if (!Array.isArray(deliveredSequences)
    || deliveredSequences.length > cards.length
    || deliveredSequences.some((sequence, index) => sequence !== index)) {
    throw new ApiError(CARD_NOT_FOUND, "CardPlayed delivery evidence is not a contiguous prefix.");
  }
  return cards.slice(0, deliveredSequences.length);
}

/**
 * Persist one validated replacement-room card activation with optimistic list sequencing.
 *
 * Ownership is checked against the complete candidate list before the match row advances. The
 * final settlement repeats that check inside its MongoDB transaction, so spending or moving a
 * card concurrently cannot turn this earlier observation into an unauthorized debit. A retry of
 * an already committed sequence returns without writing or relaying the effect twice.
 */
export async function recordRelayedCardPlay(
  matchId: string,
  playerId: string,
  sequence: number,
  cardId: string,
): Promise<RelayedCardPlayResult> {
  const path = `relayedCardPlays.${playerId}`;
  for (let attempt = 0; attempt < 4; attempt += 1) {
    const match = await getMatch(matchId);
    if (!match || match.state !== "active" || !match.players.some((player) => player.playerId === playerId)) {
      throw new ApiError(CARD_NOT_FOUND, "CardPlayed sender is not in an active match.");
    }
    const existing = match.relayedCardPlays?.[playerId] ?? [];
    const result = applyRelayedCardPlay(existing, sequence, cardId);
    if (result.replayed) return result;
    validatedMatchDocument({
      ...match,
      relayedCardPlays: { ...(match.relayedCardPlays ?? {}), [playerId]: result.cards },
    });

    const player = await findById(playerId);
    if (!player) throw new ApiError(CARD_NOT_FOUND, "CardPlayed owner was not found.");
    consumePvpUsedCardsState(progressionForPlayer(player), result.cards);

    const update = await matches().updateOne(
      {
        matchId,
        state: "active",
        "players.playerId": playerId,
        [path]: existing.length === 0 ? { $exists: false } : existing,
      },
      { $set: { [path]: result.cards } },
    );
    if (update.modifiedCount === 1) return result;
  }
  throw new ApiError(CARD_NOT_FOUND, "CardPlayed evidence changed concurrently.");
}

export async function wasRelayedCardDelivered(
  matchId: string,
  playerId: string,
  sequence: number,
): Promise<boolean> {
  const match = await getMatch(matchId);
  return Boolean(match?.relayedCardDeliveries?.[playerId]?.includes(sequence));
}

/**
 * Persist transport handoff only after the opponent's node actually wrote the event to its live
 * socket. Redis publish acknowledgement is not delivery acknowledgement: pub/sub can accept a
 * message while the target route closes or the subscriber is unavailable.
 */
export async function markRelayedCardDelivered(
  matchId: string,
  playerId: string,
  sequence: number,
  cardId: string,
): Promise<boolean> {
  const match = await getMatch(matchId);
  if (!match || match.state !== "active" || !match.players.some((participant) => participant.playerId === playerId)) {
    return false;
  }
  if (match.relayedCardPlays?.[playerId]?.[sequence] !== cardId) return false;
  const path = `relayedCardDeliveries.${playerId}`;
  const existing = match.relayedCardDeliveries?.[playerId];
  if (existing?.includes(sequence)) return true;
  // Delivery is serialized per sender, but the database boundary still proves the complete prior
  // prefix. Sequence 1 can never become durable while sequence 0 is merely recorded/undelivered.
  const checkedExisting = deliveredRelayedCards(match.relayedCardPlays?.[playerId] ?? [], existing ?? []);
  if (sequence !== checkedExisting.length) return false;
  const deliveries = [...(existing ?? []), sequence];
  validatedMatchDocument({
    ...match,
    relayedCardDeliveries: { ...(match.relayedCardDeliveries ?? {}), [playerId]: deliveries },
  });
  const delivered = await matches().updateOne(
    {
      matchId,
      state: "active",
      "players.playerId": playerId,
      [`relayedCardPlays.${playerId}.${sequence}`]: cardId,
      [path]: existing === undefined ? { $exists: false } : existing,
    },
    { $set: { [path]: deliveries } },
  );
  // A concurrent retry may have committed the identical next marker after our read. Re-read only
  // on compare-and-set loss so exact idempotent delivery is accepted without permitting a gap.
  return delivered.modifiedCount === 1
    || await wasRelayedCardDelivered(matchId, playerId, sequence);
}

export type MatchReportStatus = "pending" | "confirmed" | "conflict" | "invalid" | "finished";

export interface MatchReportResult {
  status: MatchReportStatus;
  settlement?: SettlementResult;
}

/**
 * Convert a validated durable terminal row into the result-report contract.
 *
 * This is deliberately shared by the pre-write and post-write paths. Two participants can
 * report concurrently, so the row may become finished or result-conflict-cancelled between this
 * request's conditional update and its reload. In that case the terminal MongoDB row is the sole
 * authority: returning stale "invalid"/"pending" state would make both live sockets miss the
 * terminal notification even though settlement or cancellation already committed.
 */
export function terminalMatchReportResult(
  match: MatchDoc,
  fallbackWinnerId: string,
): MatchReportResult | null {
  if (match.state === "finished") {
    return {
      status: "finished",
      settlement: {
        matchId: match.matchId,
        winnerId: match.winnerId ?? fallbackWinnerId,
        rewarded: false,
        rewards: match.rewardReceipts,
      },
    };
  }
  if (match.state === "cancelled") {
    return { status: match.cancelReason === "result_conflict" ? "conflict" : "invalid" };
  }
  return null;
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
  requireRelayedCardEvidence = false,
): Promise<MatchReportResult> {
  const match = await getMatch(matchId);
  if (!match || !match.players.some((player) => player.playerId === reporterId)) return { status: "invalid" };
  if (!match.players.some((player) => player.playerId === winnerId)) return { status: "invalid" };
  const existingTerminal = terminalMatchReportResult(match, winnerId);
  if (existingTerminal) return existingTerminal;
  if (match.state !== "active") return { status: "invalid" };

  const authoritativeCards = requireRelayedCardEvidence
    ? validateRelayedCardReport(
      deliveredRelayedCards(
        match.relayedCardPlays?.[reporterId] ?? [],
        match.relayedCardDeliveries?.[reporterId] ?? [],
      ),
      usedCards,
    )
    : parsePvpUsedCards([...usedCards]);

  // Validate only the authenticated reporter's own list before persisting it. Replaying a
  // report may overwrite that same key, but cannot submit cards on behalf of the opponent.
  // The pure transition is repeated inside the final MongoDB transaction so an overlapping
  // economy mutation cannot make this stale ownership check authoritative.
  const reporter = await findById(reporterId);
  if (!reporter) return { status: "invalid" };
  consumePvpUsedCardsState(progressionForPlayer(reporter), authoritativeCards);
  validatedMatchDocument({
    ...match,
    resultReports: { ...(match.resultReports ?? {}), [reporterId]: winnerId },
    usedCardsReports: { ...(match.usedCardsReports ?? {}), [reporterId]: authoritativeCards },
  });

  await matches().updateOne(
    { matchId, state: "active", "players.playerId": reporterId },
    {
      $set: {
        [`resultReports.${reporterId}`]: winnerId,
        [`usedCardsReports.${reporterId}`]: authoritativeCards,
      },
    },
  );
  const updated = await getMatch(matchId);
  if (!updated) return { status: "invalid" };
  const postWriteTerminal = terminalMatchReportResult(updated, winnerId);
  if (postWriteTerminal) return postWriteTerminal;
  if (updated.state !== "active") return { status: "invalid" };
  const reports = updated.resultReports ?? {};
  const reportedWinners = updated.players
    .map((player) => reports[player.playerId])
    .filter((value): value is string => typeof value === "string");
  if (reportedWinners.length < updated.players.length) return { status: "pending" };
  if (new Set(reportedWinners).size !== 1) {
    await cancelMatch(matchId, "result_conflict");
    // Cancellation may lose its compare-and-set to a concurrent settlement after a participant
    // corrected their own report. Re-read instead of publishing the stale conflict observation.
    const terminal = await getMatch(matchId);
    return terminalMatchReportResult(terminal ?? updated, winnerId) ?? { status: "invalid" };
  }

  const settlement = await settleResult(matchId, reportedWinners[0], reporterId);
  // A conflicting cancellation can win immediately before settleResult opens its transaction.
  // Confirm success only from the resulting durable row, never from the helper's no-reward shape.
  const terminal = await getMatch(matchId);
  const resolved = terminal ? terminalMatchReportResult(terminal, winnerId) : null;
  return resolved?.status === "finished"
    ? { status: "confirmed", settlement: resolved.settlement ?? settlement }
    : resolved ?? { status: "invalid" };
}

/**
 * Briefly wait for the other participant's already-in-flight REST report.
 *
 * `reportMatchResult` intentionally requires two matching authenticated reports. Without
 * this bridge, whichever stock client reports first receives a zero-valued pending response
 * and never gets the immutable receipt produced milliseconds later by the second request.
 * Polling is bounded and read-only: it cannot settle, change a report, or turn a timeout into
 * a win. Finished rows reproduce their stored winner and receipts; a conflict/cancellation
 * remains non-rewarding, and an absent second report still returns pending at the deadline.
 */
export async function waitForMatchResolution(
  matchId: string,
  timeoutMilliseconds = matchResultConsensusTimeoutMilliseconds(),
): Promise<MatchReportResult> {
  const boundedTimeout = matchResultConsensusTimeoutMilliseconds(timeoutMilliseconds);
  const deadline = Date.now() + boundedTimeout;
  do {
    const match = await getMatch(matchId);
    if (!match) return { status: "invalid" };
    const terminal = terminalMatchReportResult(match, "");
    if (terminal) return terminal;
    if (Date.now() >= deadline) break;
    await new Promise<void>((resolve) => setTimeout(resolve, Math.min(100, deadline - Date.now())));
  } while (Date.now() <= deadline);
  return { status: "pending" };
}

export interface SettlementResult {
  matchId: string;
  winnerId: string;
  rewarded: boolean;
  rewards?: Record<string, MatchPlayerReward>;
}

export interface DisconnectForfeitAuthority {
  /** Assigned participant whose exact durable disconnect marker authorizes the forfeit. */
  disconnectedPlayerId: string;
  /** Marker captured by the grace timer; a reconnect or later disconnect changes authority. */
  disconnectedAt: Date;
}

/**
 * Prove that a disconnect-forfeit still owns the exact active match snapshot it observed.
 *
 * Redis answers whether the opponent route is live, but it cannot participate in the MongoDB
 * reward transaction. Binding the loser's exact durable timestamp inside that transaction closes
 * the reconnect race: clearing or replacing the marker makes the stale timer a no-op before any
 * economy, progression, card, rental, league, event, or terminal write.
 */
export function matchesDisconnectForfeitAuthority(
  match: MatchDoc,
  winnerId: string,
  authority: DisconnectForfeitAuthority,
): boolean {
  const observed = match.disconnectedAt?.[authority.disconnectedPlayerId];
  return match.state === "active"
    && winnerId !== authority.disconnectedPlayerId
    && match.players.some((participant) => participant.playerId === winnerId)
    && match.players.some((participant) => participant.playerId === authority.disconnectedPlayerId)
    && observed instanceof Date
    && authority.disconnectedAt instanceof Date
    && Number.isFinite(authority.disconnectedAt.getTime())
    && observed.getTime() === authority.disconnectedAt.getTime();
}

/**
 * Settle a finished match. Idempotent: a second call for an already-finished match is a
 * no-op. Core rewards, reported War Card consumption, supported Squad Event progress, and the
 * terminal match row commit in one transaction. Daily assignments, achievements, and the squad
 * aggregate/member contribution are part of that same transaction because they are durable
 * gameplay state, not disposable projections.
 */
export async function settleResult(
  matchId: string,
  winnerId: string,
  reportedById?: string,
  disconnectForfeitAuthority?: DisconnectForfeitAuthority,
): Promise<SettlementResult> {
  // A completed match already contains every projection decision and immutable player receipt.
  // Return it before consulting current live-event configuration: an operator file problem must
  // block only a new atomic settlement, never prevent a client from recovering a response that
  // committed earlier. The transaction repeats this check for races after this read.
  const completed = await getMatch(matchId);
  if (completed?.state === "finished") {
    return {
      matchId,
      winnerId: completed.winnerId ?? winnerId,
      rewarded: false,
      rewards: completed.rewardReceipts,
    };
  }
  if (disconnectForfeitAuthority
    && (!completed || !matchesDisconnectForfeitAuthority(completed, winnerId, disconnectForfeitAuthority))) {
    return { matchId, winnerId, rewarded: false };
  }
  // Live-event configuration is resolved before opening the MongoDB transaction. No configured
  // or active season is a valid null result. A malformed operator file is logged and rethrown:
  // finalizing the match would make its missing shared progress impossible to replay safely.
  const squadEventSeason = await getActiveConfiguredSquadEvent().catch((error: unknown) => {
    logger.warnWithEmoji("⚠️", "Squad Event configuration could not be used for PvP settlement", "MATCH", {
      matchId,
      error: error instanceof Error ? error.message : String(error),
    });
    throw error;
  });
  const settlementTime = new Date();
  // Allocation must occur before the core transaction: creating a whole season can touch many
  // squads and does not belong in a two-player settlement. Once materialized, the per-player
  // score updates below share the terminal match transaction and are therefore exactly once.
  const squadWarsAvailable = await prepareSquadWarSettlement(settlementTime).catch((error: unknown) => {
    logger.warnWithEmoji("âš ï¸", "Squad Wars could not be prepared for PvP settlement", "MATCH", {
      matchId,
      error: error instanceof Error ? error.message : String(error),
    });
    // Core rewards have not started. Preserve that clean retry boundary instead of treating a
    // database or maintenance failure as "wars disabled" and permanently dropping this score.
    throw error;
  });
  if (squadWarsAvailable && completed && (completed.state === "active" || completed.state === "settling")) {
    // New squads are not part of the season's original allocation snapshot. Assign every current
    // participant roster before rewards begin so a first ranked win never depends on opening the
    // Squad Wars UI. The transaction below still rechecks membership and round authority.
    await prepareSquadWarParticipantAssignments(
      completed.players.map((participant) => participant.playerId),
      settlementTime,
    );
  }
  const transaction = await withMongoTransaction(async (session) => {
    const match = await matches().findOne({ matchId }, { session }) as unknown as MatchDoc | null;
    if (!match) return {
      result: { matchId, winnerId, rewarded: false },
      grants: [] as CoreGrant[],
      inboxFanouts: [] as InboxFanoutReference[],
      unknown: true,
    };
    validatedMatchDocument(match, settlementTime);
    if (match.state === "finished") {
      return {
        result: {
          matchId,
          winnerId: match.winnerId ?? winnerId,
          rewarded: false,
          rewards: match.rewardReceipts,
        },
        grants: [] as CoreGrant[],
        inboxFanouts: [] as InboxFanoutReference[],
        unknown: false,
      };
    }
    if (match.state !== "active" || !match.players.some((participant) => participant.playerId === winnerId)) {
      return {
        result: { matchId, winnerId, rewarded: false },
        grants: [] as CoreGrant[],
        inboxFanouts: [] as InboxFanoutReference[],
        unknown: false,
      };
    }
    if (reportedById && !match.players.some((participant) => participant.playerId === reportedById)) {
      return {
        result: { matchId, winnerId, rewarded: false },
        grants: [] as CoreGrant[],
        inboxFanouts: [] as InboxFanoutReference[],
        unknown: false,
      };
    }
    if (disconnectForfeitAuthority
      && !matchesDisconnectForfeitAuthority(match, winnerId, disconnectForfeitAuthority)) {
      return {
        result: { matchId, winnerId, rewarded: false },
        grants: [] as CoreGrant[],
        inboxFanouts: [] as InboxFanoutReference[],
        unknown: false,
      };
    }

    const grants: CoreGrant[] = [];
    for (const participant of match.players) {
      // A disconnect-forfeit may settle before the disconnected player submits MatchResult. Only
      // the contiguous delivered prefix represents effects handed to the opponent; a CardPlayed
      // row persisted before a failed socket handoff must not debit inventory. A normal terminal
      // report stores the exact same delivered list above.
      const cards = match.usedCardsReports?.[participant.playerId]
        ?? deliveredRelayedCards(
          match.relayedCardPlays?.[participant.playerId] ?? [],
          match.relayedCardDeliveries?.[participant.playerId] ?? [],
        );
      grants.push(await settlePlayerCore(
        session,
        matchId,
        participant.playerId,
        participant.playerId === winnerId,
        cards,
        settlementTime,
      ));
    }
    const rewardReceipts = Object.fromEntries(
      grants.map((grant) => [grant.playerId, grant.reward]),
    );
    const inboxFanouts: InboxFanoutReference[] = [];
    const eventParticipants: Array<{
      playerId: string;
      squadId: string;
      status: SquadEventProjectionStatus;
    }> = [];
    if (squadEventSeason) {
      for (const grant of grants) {
        const projection = await recordConfirmedPvpSquadEventProgressWithFanouts(
          session,
          squadEventSeason,
          grant.playerId,
          grant.squadName,
          grant.won,
          settlementTime,
        );
        eventParticipants.push({
          playerId: grant.playerId,
          squadId: grant.squadName,
          status: projection.status,
        });
        inboxFanouts.push(...projection.fanouts);
      }
    }
    const squadWarParticipants: Array<{
      playerId: string;
      squadId: string;
      status: SquadWarProgressStatus;
    }> = [];
    if (squadWarsAvailable) {
      for (const grant of grants) {
        const status = await recordConfirmedSquadWarProgress(
          session,
          grant.playerId,
          grant.squadName,
          grant.won,
          grant.squadPoints,
          settlementTime,
        );
        squadWarParticipants.push({ playerId: grant.playerId, squadId: grant.squadName, status });
      }
    }
    validatedMatchDocument({
      ...match,
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
      ...(squadWarsAvailable ? { squadWarProjection: squadWarParticipants } : {}),
    }, settlementTime);
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
          ...(squadWarsAvailable ? { squadWarProjection: squadWarParticipants } : {}),
        },
      },
      { session },
    );
    if (finish.modifiedCount !== 1) throw new Error(`Concurrent settlement rejected match ${matchId}.`);
    return {
      result: { matchId, winnerId, rewarded: true, rewards: rewardReceipts },
      grants,
      inboxFanouts,
      unknown: false,
    };
  });

  if (transaction.unknown) logger.match.error("Result for unknown match", { matchId });
  if (!transaction.result.rewarded) return transaction.result;
  // Squad Event type-11 rows were inserted inside the same atomic match/economy transaction.
  // Announce only the final committed attempt; the recipient still claims Gold through action 91.
  await publishInboxFanouts(transaction.inboxFanouts);
  logger.match.event("Match settled", { matchId, winnerId });
  return transaction.result;
}
