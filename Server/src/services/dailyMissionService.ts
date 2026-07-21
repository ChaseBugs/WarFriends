import { randomInt } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import type {
  DailyMissionMode,
  DailyMissionRecordState,
  DailyMissionsState,
  MissionUnitState,
  PlayerDocument,
  PlayerProgressionState,
} from "../db";
import { players } from "../db";
import { advanceAchievementState } from "./achievementService";
import { calculateArmyPower } from "./armyPowerService";
import {
  CARD_UNLOCK_LEVEL,
  grantCardPackRewardState,
  grantMissionCardsState,
} from "./cardInventoryService";
import { applyLevelExperienceState, playerLevelDefinition } from "./levelProgressionService";
import {
  VIP_BATTLE_EXPERIENCE_MULTIPLIER,
  VIP_BATTLE_WARBUCKS_MULTIPLIER,
  VIP_LEVEL_GOLD_MULTIPLIER,
} from "./matchService";
import { mutateProgression } from "./progressionMutationService";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { advanceRentalAfterBattleState } from "./rentalService";
import { grantMissionElitePartsState, selectMissionElitePartUnit } from "./unitInventoryService";
import { isVipActiveAt } from "./vipEntitlementService";

/**
 * Persistent daily/heroic mission lifecycle reconstructed from the Unity client contract.
 *
 * Mission selection and balancing are server-owned. Starting a mission creates a short-lived
 * receipt containing its generated battle ID, mission mode, selected index, and reward row.
 * `GameEnded` may settle only that receipt, exactly once. Recent settlement responses are
 * cached so a retry after a dropped connection returns the original reward instead of
 * crediting the player a second time.
 *
 * This is authoritative for entry validation, completion state, currency rewards, and replay
 * protection, but not for combat simulation. Until the recovered unit/RPC protocol can be
 * validated server-side, the result still originates from the authenticated client. That
 * limitation is deliberately kept visible rather than disguised as anti-cheat authority.
 */

// GameController.HKGHCIEPGEL serializes these exact EndReason values in 1.6.0. Keeping the
// numeric values local to this module prevents generic PvP outcomes (Win=2, Forfeit=5, etc.)
// from accidentally being interpreted as mission completion.
const MISSION_FAILED = 9;
const MISSION_SUCCESS = 10;

// The unlock threshold is serialized by MissionsConstants in the recovered scene. The
// remaining limits are backend safety bounds: they cap abandoned receipts and replay data
// without changing any client-visible mission fields.
const HEROIC_POINTS_TO_UNLOCK = 30;
const MAX_ACTIVE_SESSIONS = 4;
const MAX_RECENT_SETTLEMENTS = 20;
const SESSION_LIFETIME_SECONDS = 4 * 60 * 60;
const MAX_CONCURRENCY_RETRIES = 4;

/*
 * Exact mission battle-reward inputs recovered from MainScene's MissionsConstants and
 * MissionsSettings components. The spelling `RweardModifier` is preserved in the scene,
 * but these arrays contain its values in Daily1..3 and Heroic1..5 order.
 *
 * DailyMission.GenerateRewards uses the same modifier for XP and WarBucks. It first divides
 * one slot by the sum of all slots in that mission family, multiplies by the family size,
 * applies exponential player-level scaling, and finally rounds upward to the next 50. This
 * deliberately replaces the earlier fixed offline payout; no retired remote table is needed
 * for mission battle rewards because the complete formula survived in the 1.6.0 client.
 */
const MISSION_REWARD_XP_ROOT = Math.fround(1.09934);
const MISSION_REWARD_WARBUCKS_ROOT = Math.fround(1.033);
const MISSION_REWARD_XP_BASE = Math.fround(10_000);
const MISSION_REWARD_WARBUCKS_BASE = Math.fround(10_000);
const DAILY_REWARD_MODIFIERS = [2, 2.33, 2.66].map((value) => Math.fround(value));
const HEROIC_REWARD_MODIFIERS = [3, 3.12, 3.24, 3.36, 3.5].map((value) => Math.fround(value));

/**
 * Reward rows serialized on the MissionsRewards component in MainScene.unity.
 *
 * Every column is now represented. Card and unit inventories are authoritative, so completion
 * can grant the source pack class and unit-specific Elite part together with these currencies.
 */
const MISSION_REWARD_ROWS = [
  { level: 5, dailyGold: 10, dailyTickets: 2, dailyScraps: 20, dailyCards: [8, 5, 3], heroicGoldMission: 1, heroicGold: 15, heroicTickets: 10, heroicScraps: 30, heroicPack: "BRONZE_CARDPACK", heroicEliteParts: 1 },
  { level: 10, dailyGold: 10, dailyTickets: 2, dailyScraps: 20, dailyCards: [8, 5, 3], heroicGoldMission: 1, heroicGold: 15, heroicTickets: 10, heroicScraps: 30, heroicPack: "BRONZE_CARDPACK", heroicEliteParts: 1 },
  { level: 15, dailyGold: 10, dailyTickets: 2, dailyScraps: 20, dailyCards: [8, 5, 3], heroicGoldMission: 1, heroicGold: 15, heroicTickets: 10, heroicScraps: 30, heroicPack: "BRONZE_CARDPACK", heroicEliteParts: 1 },
  { level: 20, dailyGold: 15, dailyTickets: 3, dailyScraps: 30, dailyCards: [9, 6, 4], heroicGoldMission: 1, heroicGold: 20, heroicTickets: 13, heroicScraps: 40, heroicPack: "BRONZE_CARDPACK", heroicEliteParts: 1 },
  { level: 25, dailyGold: 15, dailyTickets: 3, dailyScraps: 30, dailyCards: [9, 6, 4], heroicGoldMission: 1, heroicGold: 20, heroicTickets: 13, heroicScraps: 40, heroicPack: "SILVER_CARDPACK", heroicEliteParts: 1 },
  { level: 30, dailyGold: 15, dailyTickets: 3, dailyScraps: 30, dailyCards: [9, 6, 4], heroicGoldMission: 2, heroicGold: 20, heroicTickets: 13, heroicScraps: 40, heroicPack: "SILVER_CARDPACK", heroicEliteParts: 1 },
  { level: 35, dailyGold: 20, dailyTickets: 4, dailyScraps: 40, dailyCards: [10, 7, 5], heroicGoldMission: 2, heroicGold: 30, heroicTickets: 17, heroicScraps: 60, heroicPack: "SILVER_CARDPACK", heroicEliteParts: 1 },
  { level: 40, dailyGold: 20, dailyTickets: 4, dailyScraps: 40, dailyCards: [10, 7, 5], heroicGoldMission: 2, heroicGold: 30, heroicTickets: 17, heroicScraps: 60, heroicPack: "GOLD_CARDPACK", heroicEliteParts: 1 },
  { level: 43, dailyGold: 20, dailyTickets: 4, dailyScraps: 40, dailyCards: [10, 7, 5], heroicGoldMission: 2, heroicGold: 30, heroicTickets: 17, heroicScraps: 60, heroicPack: "GOLD_CARDPACK", heroicEliteParts: 1 },
] as const;

type MissionRewardRow = (typeof MISSION_REWARD_ROWS)[number];

export interface DailyMissionMutationResult {
  state: PlayerProgressionState;
  dailyMissions: DailyMissionsState;
}

export interface DailyMissionStartResult extends DailyMissionMutationResult {
  battleId: string;
  replayed: boolean;
}

export interface DailyMissionSettlementInput {
  battleId: string;
  missionIndex: number;
  missionType: DailyMissionMode;
  endReason: number;
}

export interface DailyMissionSettlementResult extends DailyMissionMutationResult {
  response: Record<string, unknown>;
  replayed: boolean;
  levelFrom: number;
  levelTo: number;
  experienceGained: number;
}

export interface MissionBattleRewardPolicy {
  /** Test-only override. Production derives the amount from the recovered source formula. */
  experience?: number;
  /** Test-only override. Production derives the amount from the recovered source formula. */
  warBucks?: number;
  /** Test seam for server-owned card identity selection; production uses crypto.randomInt. */
  chooseCardIndex?: (upperBound: number) => number;
}

export interface MissionBattleReward {
  experience: number;
  warBucks: number;
}

function checkedNonNegativeInteger(value: number, name: string): number {
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} is invalid.`);
  }
  return value;
}

function checkedSum(left: number, right: number, name: string): number {
  const value = left + right;
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} overflowed.`);
  }
  return value;
}

function checkedBalanceSum(left: number, right: number, name: string): number {
  if (!Number.isSafeInteger(left) || !Number.isSafeInteger(right) || right < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} is invalid.`);
  }
  const value = left + right;
  if (!Number.isSafeInteger(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} overflowed.`);
  }
  return value;
}

function checkedScaledInteger(value: number, multiplier: number, name: string): number {
  const scaled = Math.trunc(value * multiplier);
  if (!Number.isSafeInteger(scaled) || scaled < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} overflowed.`);
  }
  return scaled;
}

function unityModifierSum(values: readonly number[]): number {
  // The client accumulates into a C# float. Rounding every addition avoids a rare one-step
  // difference at a 50-unit boundary that a JavaScript double-only implementation can cause.
  return values.reduce((sum, value) => Math.fround(sum + value), Math.fround(0));
}

function unityMissionRewardAmount(
  base: number,
  root: number,
  displayLevel: number,
  modifiers: readonly number[],
  missionIndex: number,
  modeMultiplier: number,
): number {
  const modifierSum = unityModifierSum(modifiers);
  const levelExponent = Math.fround(displayLevel - 3);

  // Match the left-to-right float operations in DailyMission.GenerateRewards. Mathf.Pow
  // returns a float, and EDEIDMHHCAO divides the final float by 50 before Math.Ceiling.
  let value = Math.fround(base * Math.fround(Math.pow(root, levelExponent)));
  value = Math.fround(value * Math.fround(modifiers.length));
  value = Math.fround(value * Math.fround(modifiers[missionIndex] / modifierSum));
  value = Math.fround(value * Math.fround(modeMultiplier));
  return checkedNonNegativeInteger(Math.ceil(Math.fround(value / 50)) * 50, "Mission reward");
}

/**
 * Calculate the exact base components displayed by the recovered mission result screen.
 *
 * Daily and Heroic missions pay their full slot-scaled amounts. A co-op master receives only
 * the Heroic unlock point in the stock client and therefore has zero personal XP/WarBucks.
 * A joining co-op client receives half of the Daily slot amount, rounded upward after the
 * half multiplier. VIP multiplication is intentionally not performed here; the result parser
 * applies that entitlement to these base components and the server mirrors it at settlement.
 */
export function missionBattleRewardFor(
  playerLevelIndex: number,
  missionType: DailyMissionMode,
  missionIndex: number,
): MissionBattleReward {
  if (missionType === "Coop") return { experience: 0, warBucks: 0 };

  // DatabasePlayer.Level is LevelManager's zero-based index, while GenerateRewards reads
  // currentLevel.displayNumber. Resolve the exact recovered row instead of assuming those two
  // values are interchangeable; otherwise every payout is scaled one display rank too low.
  const displayLevel = playerLevelDefinition(playerLevelIndex).displayLevel;
  const modifiers = missionType === "Heroic" ? HEROIC_REWARD_MODIFIERS : DAILY_REWARD_MODIFIERS;
  if (!Number.isInteger(missionIndex) || missionIndex < 0 || missionIndex >= modifiers.length) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Mission reward index is invalid.");
  }
  const modeMultiplier = missionType === "CoopClient" ? 0.5 : 1;
  return {
    experience: unityMissionRewardAmount(
      MISSION_REWARD_XP_BASE,
      MISSION_REWARD_XP_ROOT,
      displayLevel,
      modifiers,
      missionIndex,
      modeMultiplier,
    ),
    warBucks: unityMissionRewardAmount(
      MISSION_REWARD_WARBUCKS_BASE,
      MISSION_REWARD_WARBUCKS_ROOT,
      displayLevel,
      modifiers,
      missionIndex,
      modeMultiplier,
    ),
  };
}

function dateAt(now: number): Date {
  // Progression services use integer Unix seconds. Flooring here makes all rollover helpers
  // agree when tests or callers provide a sub-second timestamp.
  return new Date(Math.floor(now) * 1_000);
}

function utcDayKey(now: number): string {
  return dateAt(now).toISOString().slice(0, 10);
}

function nextUtcMidnight(now: number): number {
  // The server uses UTC rather than device-local midnight. This prevents timezone changes
  // or a modified device clock from issuing several mission sets during one server day.
  const date = dateAt(now);
  return Math.floor(Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate() + 1) / 1_000);
}

function cloneMission(record: DailyMissionRecordState): DailyMissionRecordState {
  return {
    ...record,
    cnf: {
      ...record.cnf,
      units: record.cnf.units.map((unit) => ({ ...unit })),
    },
  };
}

function cloneDailyMissions(value: DailyMissionsState): DailyMissionsState {
  // Mutations run inside an optimistic compare-and-swap loop. Deep-cloning arrays and cached
  // responses keeps a failed/retried mutation from modifying the snapshot owned by another
  // attempt before MongoDB accepts the revision.
  return {
    ...value,
    dailyMissions: value.dailyMissions.map(cloneMission),
    heroicMissions: value.heroicMissions.map(cloneMission),
    activeSessions: value.activeSessions.map((session) => ({ ...session })),
    recentSettlements: value.recentSettlements.map((settlement) => ({
      ...settlement,
      response: cloneResponse(settlement.response),
    })),
  };
}

function cloneResponse(value: Record<string, unknown>): Record<string, unknown> {
  return JSON.parse(JSON.stringify(value)) as Record<string, unknown>;
}

function normalUnits(): MissionUnitState[] {
  // MainScene's LevelManager list begins with Assaulter, Shotgunner, and Sniper. These three
  // indices are present in the recovered resource project. Unity recalculates `lev` from the
  // current player's mission level in DailyMissionG.GetUnitsLevels.
  return [0, 1, 2].map((i) => ({ i, vet: false, eli: false, lev: 0 }));
}

function bossUnits(): MissionUnitState[] {
  const units = normalUnits();
  // MissionConfig.bossUnit selects the first elite/veteran row. Marking the first recovered
  // behavior elite gives DailyMissionBoss a structurally valid boss without inventing an ID.
  units[0] = { ...units[0], eli: true };
  return units;
}

function mission(
  type: DailyMissionRecordState["type"],
  options: { boss?: boolean; time?: number; killUnits?: number; waves?: boolean } = {},
): DailyMissionRecordState {
  const cnf: DailyMissionRecordState["cnf"] = {
    units: options.boss ? bossUnits() : normalUnits(),
  };
  // These are the defaults in the recovered config classes. The client normally overwrites
  // them from MissionsSettings during Load; retaining them keeps the wire self-describing and
  // supports future repaired clients that choose not to overwrite server-provided values.
  if (options.time !== undefined) cnf.time = options.time;
  if (options.killUnits !== undefined) cnf.killUnits = options.killUnits;
  if (options.waves) cnf.waves = [];
  return { type, cnf, completedSolo: false, completedCoop: false };
}

function newDailyMissionList(): DailyMissionRecordState[] {
  /*
   * The archived client proves the four supported mission classes and their JSON configs,
   * but it does not contain the original server's random-selection algorithm. This stable
   * three-class rotation is therefore an explicit reconstruction fallback, not a claim about
   * production weighting. It avoids duplicates while keeping every daily slot playable.
   */
  return [
    mission("DailyMissionKillUnits", { time: 90, killUnits: 10 }),
    mission("DailyMissionSurvive", { time: 90 }),
    mission("DailyMissionWaves", { waves: true }),
  ];
}

function newHeroicMissionList(): DailyMissionRecordState[] {
  // HeroicScreen expects five entries and the fifth entry is labelled as the boss mission.
  return [
    mission("DailyMissionKillUnits", { time: 90, killUnits: 10 }),
    mission("DailyMissionSurvive", { time: 90 }),
    mission("DailyMissionWaves", { waves: true }),
    mission("DailyMissionKillUnits", { time: 90, killUnits: 10 }),
    mission("DailyMissionBoss", { boss: true, waves: true }),
  ];
}

function rewardRow(playerLevel: number): MissionRewardRow {
  // MissionsRewards rows are upper level bounds (5, 10, 15, ...), not exact-level-only
  // records. Levels beyond the final recovered row intentionally use that final row rather
  // than yielding no reward or guessing unrecovered high-level balancing.
  const level = Math.max(1, Math.floor(playerLevel));
  return MISSION_REWARD_ROWS.find((row) => row.level >= level)
    ?? MISSION_REWARD_ROWS[MISSION_REWARD_ROWS.length - 1];
}

export function selectDailyCompletionRewardIndex(
  playerLevelIndex: number,
  choose: (upperBound: number) => number = (upperBound) => randomInt(upperBound),
): number {
  /*
   * DailyMissionsData proves that the backend chooses one of six reward types for the whole
   * UTC cycle, but the production weights are retired. Use a uniform cryptographic fallback
   * across Gold/Tickets/Scraps and, after the source War Card unlock display level, the three
   * exact-rarity card variants. Persisting the index makes every device preview the same prize.
  */
  const cardRewardsUnlocked = Math.max(0, Math.floor(playerLevelIndex)) >= CARD_UNLOCK_LEVEL - 1;
  const upperBound = cardRewardsUnlocked ? 6 : 3;
  const selected = choose(upperBound);
  if (!Number.isInteger(selected) || selected < 0 || selected >= upperBound) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Daily mission reward selector is invalid.");
  }
  return selected;
}

/**
 * Materialize the current UTC mission cycle without trusting a client-supplied save blob.
 * Heroic progress survives a daily rollover; the three daily records and their completion
 * reward reset at midnight. A currently open heroic chain also survives midnight so a player
 * is not forced to finish all five missions before the daily reset.
 */
export function dailyMissionsStateFor(
  state: PlayerProgressionState,
  now: number,
  playerLevel: number,
): DailyMissionsState {
  const key = utcDayKey(now);
  const existing = state.dailyMissions;
  if (existing?.dayKey === key && existing.tomorrow > now) {
    // Reading mission state must not silently extend a receipt. Expired sessions are removed
    // against their original startedAt value, even when GetPlayerData is called repeatedly.
    const cloned = cloneDailyMissions(existing);
    cloned.activeSessions = cloned.activeSessions.filter((session) => now - session.startedAt <= SESSION_LIFETIME_SECONDS);
    // Accounts issued by the earlier currency-only reconstruction stored an empty target.
    // Fill it once at the normal persistence boundary before any Heroic reward is claimable.
    if (!cloned.heroicUnitReward) {
      cloned.heroicUnitReward = selectMissionElitePartUnit(state, playerLevel);
    }
    return cloned;
  }

  const previous = existing ? cloneDailyMissions(existing) : undefined;
  // Once a player starts an open heroic chain, preserve its ordered progress across the
  // daily reset. An open but untouched chain may be regenerated because no reward-bearing
  // progress exists yet; isHeroicOpened itself remains true below.
  const keepOpenHeroic = previous?.isHeroicOpened === true && previous.heroicMissions.some((item) => item.completedSolo);
  const displayLevel = Math.max(1, Math.floor(playerLevel));
  const heroicUnitReward = keepOpenHeroic && previous!.heroicUnitReward
    ? previous!.heroicUnitReward
    : selectMissionElitePartUnit(state, playerLevel);
  return {
    dailyMissions: newDailyMissionList(),
    heroicMissions: keepOpenHeroic ? previous!.heroicMissions : newHeroicMissionList(),
    heroicPoints: Math.min(HEROIC_POINTS_TO_UNLOCK, Math.max(0, previous?.heroicPoints ?? 0)),
    isHeroicOpened: previous?.isHeroicOpened ?? false,
    tomorrow: nextUtcMidnight(now),
    dailyMissionRewardInd: selectDailyCompletionRewardIndex(playerLevel),
    // DailyMissionsManager exposes these stored zero-based values as `value + 1`.
    dailyMissionLevel: displayLevel - 1,
    heroicMissionLevel: displayLevel - 1,
    // The exact target is part of DailyMissionsData before the chain starts. Persisting it
    // here keeps the Heroic rewards preview and eventual completion response on one unit.
    heroicUnitReward,
    dayKey: key,
    dailyCompletionRewardClaimed: false,
    heroicCompletionRewardClaimed: keepOpenHeroic ? previous!.heroicCompletionRewardClaimed : false,
    activeSessions: [],
    recentSettlements: (previous?.recentSettlements ?? []).slice(-MAX_RECENT_SETTLEMENTS),
  };
}

/** Return only fields declared by DailyMissionsManager.DailyMissionsData. */
export function dailyMissionsWireData(value: DailyMissionsState): Record<string, unknown> {
  return {
    dailyMissions: value.dailyMissions.map(cloneMission),
    heroicMissions: value.heroicMissions.map(cloneMission),
    heroicPoints: value.heroicPoints,
    isHeroicOpened: value.isHeroicOpened,
    tomorrow: value.tomorrow,
    dailyMissionRewardInd: value.dailyMissionRewardInd,
    dailyMissionLevel: value.dailyMissionLevel,
    heroicMissionLevel: value.heroicMissionLevel,
    heroicUnitReward: value.heroicUnitReward,
  };
}

export function serializeDailyMissionsData(value: DailyMissionsState): string {
  return JSON.stringify(dailyMissionsWireData(value));
}

/**
 * dailyMissionsStateFor clones every nested list for safe mutation, so reference equality cannot
 * distinguish a read from maintenance. Within one UTC cycle it can change only two stored facts:
 * prune expired private sessions and fill a missing legacy Heroic reward target. Day keys and
 * deadlines cover rollover. Keeping this comparison explicit avoids serializing the full mission
 * document on every boot while still committing every real normalization.
 */
function dailyMissionNormalizationChanged(
  existing: DailyMissionsState | undefined,
  normalized: DailyMissionsState,
): boolean {
  return !existing
    || existing.dayKey !== normalized.dayKey
    || existing.tomorrow !== normalized.tomorrow
    || existing.activeSessions.length !== normalized.activeSessions.length
    || existing.heroicUnitReward !== normalized.heroicUnitReward;
}

function stateAfterDailyMissionNormalization(
  state: PlayerProgressionState,
  dailyMissions: DailyMissionsState,
): PlayerProgressionState {
  return dailyMissionNormalizationChanged(state.dailyMissions, dailyMissions)
    ? { ...state, revision: state.revision + 1, dailyMissions }
    : state;
}

export function ensureDailyMissionsState(
  state: PlayerProgressionState,
  now: number,
  playerLevel: number,
): DailyMissionMutationResult {
  // Persist generated/rolled state, expired receipt pruning, and the legacy Heroic-target
  // migration. An unchanged same-day read returns the exact input so reconnect does not write.
  const dailyMissions = dailyMissionsStateFor(state, now, playerLevel);
  return {
    state: stateAfterDailyMissionNormalization(state, dailyMissions),
    dailyMissions,
  };
}

function validateBattleId(battleId: string): void {
  // The allowlist accepts UUID-like IDs and common backend prefixes while rejecting control
  // characters and oversized keys before they enter MongoDB or structured logs.
  if (!battleId || battleId.length > 160 || !/^[\w.:@+-]+$/.test(battleId)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "BattleId is invalid.");
  }
}

function isMissionStartAction(action: number): boolean {
  return action === DbAction.GameStartedCampaign
    || action === DbAction.GameStartedCoopMaster
    || action === DbAction.GameStartedCoopClient;
}

/**
 * Issue a short-lived start receipt. This does not spend a dog tag: the recovered client
 * calls PayOneDogTag separately when the UI consumes energy. Start retries with the same
 * BattleId are idempotent and do not create a second receipt.
 */
export function startDailyMissionState(
  state: PlayerProgressionState,
  now: number,
  playerLevel: number,
  battleId: string,
  startAction: number,
): DailyMissionStartResult {
  validateBattleId(battleId);
  if (!isMissionStartAction(startAction)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Mission start action is invalid.");
  }

  const dailyMissions = dailyMissionsStateFor(state, now, playerLevel);
  const previousSettlement = dailyMissions.recentSettlements.find((item) => item.battleId === battleId);
  if (previousSettlement) {
    return {
      state: stateAfterDailyMissionNormalization(state, dailyMissions),
      dailyMissions,
      battleId,
      replayed: true,
    };
  }

  const existing = dailyMissions.activeSessions.find((session) => session.battleId === battleId);
  if (existing && existing.startAction !== startAction) {
    throw new ApiError(ApiErrorCode.UnknownAction, "BattleId belongs to another mission mode.");
  }
  if (!existing) {
    dailyMissions.activeSessions = [
      ...dailyMissions.activeSessions,
      { battleId, startAction, startedAt: now, dayKey: dailyMissions.dayKey },
    ].slice(-MAX_ACTIVE_SESSIONS);
  }
  return {
    // A same-receipt retry is a true no-op unless normalization pruned another expired receipt
    // or performed a day/migration transition before the replay was recognized.
    state: existing
      ? stateAfterDailyMissionNormalization(state, dailyMissions)
      : { ...state, revision: state.revision + 1, dailyMissions },
    dailyMissions,
    battleId,
    replayed: Boolean(existing),
  };
}

function expectedStartAction(missionType: DailyMissionMode): number {
  // Solo Daily and Heroic modes both launch through action 67. Co-op ownership is asymmetric:
  // the master uses 68 and is allowed to mark completedCoop, while the joining client uses
  // 69 and cannot claim the master's completion flag.
  if (missionType === "Daily" || missionType === "Heroic") return DbAction.GameStartedCampaign;
  if (missionType === "Coop") return DbAction.GameStartedCoopMaster;
  return DbAction.GameStartedCoopClient;
}

function missionListFor(value: DailyMissionsState, missionType: DailyMissionMode): DailyMissionRecordState[] {
  // Daily, Coop, and CoopClient are three views of the same saved daily list. Unity builds
  // separate runtime objects from those records but persists solo/co-op completion together.
  return missionType === "Heroic" ? value.heroicMissions : value.dailyMissions;
}

function completionReward(
  value: DailyMissionsState,
  row: MissionRewardRow,
): {
  gold: number;
  tickets: number;
  scraps: number;
  field: string;
  cardRarity?: number;
  cardCount?: number;
} {
  // dailyMissionRewardInd is chosen when the daily set is issued and must stay server-owned.
  // The response key matters as much as the amount because CBBKFKCOLPP selects the wallet
  // operation by checking which one of these exact keys exists.
  switch (value.dailyMissionRewardInd) {
    case 0:
      return { gold: row.dailyGold, tickets: 0, scraps: 0, field: "DailyMissionsCompletionRewardGold" };
    case 1:
      return { gold: 0, tickets: row.dailyTickets, scraps: 0, field: "DailyMissionsCompletionRewardTickets" };
    case 2:
      return { gold: 0, tickets: 0, scraps: row.dailyScraps, field: "DailyMissionsCompletionRewardScraps" };
    case 3:
      return { gold: 0, tickets: 0, scraps: 0, field: "DailyMissionsCompletionRewardCards", cardRarity: 1, cardCount: row.dailyCards[0] };
    case 4:
      return { gold: 0, tickets: 0, scraps: 0, field: "DailyMissionsCompletionRewardCards", cardRarity: 2, cardCount: row.dailyCards[1] };
    case 5:
      return { gold: 0, tickets: 0, scraps: 0, field: "DailyMissionsCompletionRewardCards", cardRarity: 3, cardCount: row.dailyCards[2] };
    default:
      throw new ApiError(ApiErrorCode.InternalServerError, "Stored Daily mission reward index is invalid.");
  }
}

/**
 * Consume one authenticated mission receipt and settle its result exactly once.
 *
 * The server can prove issuance, mode, index, completion history, and replay identity. It
 * cannot yet simulate the archived Photon/offline combat, so MissionSuccess remains a client
 * result assertion. That limitation is intentionally documented instead of being disguised
 * as authoritative combat validation.
 */
export function settleDailyMissionState(
  state: PlayerProgressionState,
  now: number,
  playerLevel: number,
  input: DailyMissionSettlementInput,
  policy: MissionBattleRewardPolicy = {},
): DailyMissionSettlementResult {
  validateBattleId(input.battleId);
  if (!Number.isInteger(input.missionIndex) || ![MISSION_FAILED, MISSION_SUCCESS].includes(input.endReason)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Mission settlement fields are invalid.");
  }

  const dailyMissions = dailyMissionsStateFor(state, now, playerLevel);
  const replay = dailyMissions.recentSettlements.find((item) => item.battleId === input.battleId);
  if (replay) {
    if (
      replay.missionIndex !== input.missionIndex
      || replay.missionType !== input.missionType
      || replay.endReason !== input.endReason
    ) {
      throw new ApiError(ApiErrorCode.UnknownAction, "BattleId was already settled with different data.");
    }
    return {
      // A transport retry returns the exact cached wire result without producing a new
      // progression revision. The database wrapper therefore has no write to race and no
      // opportunity to repeat XP, currency, level-up Gold, or the dog-tag refill.
      state,
      dailyMissions,
      response: cloneResponse(replay.response),
      replayed: true,
      levelFrom: playerLevel,
      levelTo: playerLevel,
      experienceGained: 0,
    };
  }

  const session = dailyMissions.activeSessions.find((item) => item.battleId === input.battleId);
  if (!session || session.dayKey !== dailyMissions.dayKey || now - session.startedAt > SESSION_LIFETIME_SECONDS) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Mission was not started or its receipt expired.");
  }
  if (session.startAction !== expectedStartAction(input.missionType)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Mission type does not match its start action.");
  }

  const missions = missionListFor(dailyMissions, input.missionType);
  if (input.missionIndex < 0 || input.missionIndex >= missions.length) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Mission index is invalid.");
  }
  if (input.missionType === "Heroic" && !dailyMissions.isHeroicOpened) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Heroic missions are not open.");
  }

  const selected = missions[input.missionIndex];
  const succeeded = input.endReason === MISSION_SUCCESS;
  let newlyCompleted = false;
  if (succeeded && input.missionType !== "CoopClient") {
    // A successful joining client is acknowledged but cannot mutate the shared co-op flag.
    // Only the authenticated master receipt owns completedCoop and its heroic-point credit.
    if (input.missionType === "Coop") {
      if (selected.completedCoop) throw new ApiError(ApiErrorCode.UnknownAction, "Co-op mission is already completed.");
      selected.completedCoop = true;
    } else {
      if (selected.completedSolo) throw new ApiError(ApiErrorCode.UnknownAction, "Mission is already completed.");
      if (input.missionType === "Heroic") {
        const firstIncomplete = missions.findIndex((item) => !item.completedSolo);
        if (firstIncomplete !== input.missionIndex) {
          throw new ApiError(ApiErrorCode.UnknownAction, "Heroic missions must be completed in order.");
        }
      }
      selected.completedSolo = true;
    }
    newlyCompleted = true;
  }

  // A receipt is consumed for success and failure. Keeping a failed receipt active would let
  // the same played battle be resubmitted later as MissionSuccess.
  dailyMissions.activeSessions = dailyMissions.activeSessions.filter((item) => item.battleId !== input.battleId);

  const row = rewardRow(playerLevel);
  const missionGold = newlyCompleted && input.missionType === "Heroic" ? row.heroicGoldMission : 0;
  let completionGold = 0;
  let addedTickets = 0;
  let addedScraps = 0;
  let heroicUnlocked = false;
  let heroicChainCompleted = false;
  let dailyCardReward: { rarity: number; count: number } | undefined;
  const response: Record<string, unknown> = {};

  if (newlyCompleted && (input.missionType === "Daily" || input.missionType === "Coop")) {
    // One unique daily/co-op completion contributes one point. Replays and CoopClient
    // acknowledgements never reach this block, so they cannot accelerate the 30-point gate.
    const wasOpen = dailyMissions.isHeroicOpened;
    dailyMissions.heroicPoints = Math.min(HEROIC_POINTS_TO_UNLOCK, dailyMissions.heroicPoints + 1);
    if (!wasOpen && dailyMissions.heroicPoints >= HEROIC_POINTS_TO_UNLOCK) {
      dailyMissions.isHeroicOpened = true;
      dailyMissions.heroicCompletionRewardClaimed = false;
      dailyMissions.heroicMissions = newHeroicMissionList();
      dailyMissions.heroicUnitReward = selectMissionElitePartUnit(state, playerLevel);
      heroicUnlocked = true;
    }
  }

  if (
    newlyCompleted
    && input.missionType === "Daily"
    && dailyMissions.dailyMissions.every((item) => item.completedSolo)
    && !dailyMissions.dailyCompletionRewardClaimed
  ) {
    // The three-mission bonus is a one-time transition on the stored cycle, not a value
    // recomputed and paid on every successful GameEnded response after all flags are true.
    const reward = completionReward(dailyMissions, row);
    dailyMissions.dailyCompletionRewardClaimed = true;
    completionGold = checkedSum(completionGold, reward.gold, "Mission completion Gold");
    addedTickets += reward.tickets;
    addedScraps += reward.scraps;
    if (reward.cardRarity !== undefined && reward.cardCount !== undefined) {
      dailyCardReward = { rarity: reward.cardRarity, count: reward.cardCount };
    } else {
      response[reward.field] = reward.gold || reward.tickets || reward.scraps;
    }
  }

  if (
    newlyCompleted
    && input.missionType === "Heroic"
    && dailyMissions.heroicMissions.every((item) => item.completedSolo)
    && !dailyMissions.heroicCompletionRewardClaimed
  ) {
    // Completing the fifth ordered heroic mission closes the chain and resets its unlock
    // meter. The claimed flag remains as defense in depth for retries until a future unlock
    // explicitly creates a fresh chain.
    dailyMissions.heroicCompletionRewardClaimed = true;
    dailyMissions.isHeroicOpened = false;
    dailyMissions.heroicPoints = 0;
    heroicChainCompleted = true;
    completionGold = checkedSum(completionGold, row.heroicGold, "Heroic completion Gold");
    addedTickets += row.heroicTickets;
    addedScraps += row.heroicScraps;
    response.HeroicMissionsCompletionRewardGold = row.heroicGold;
    response.HeroicMissionsCompletionRewardTickets = row.heroicTickets;
    response.HeroicMissionsCompletionRewardScraps = row.heroicScraps;
  }

  if (heroicUnlocked) response.HeroicMissionsUnlocked = 1;
  response.HeroicPoints = dailyMissions.heroicPoints;

  let inventoryRewardState = state;
  if (dailyCardReward) {
    // The stock mission parser iterates this exact array and calls CardManager.AddCard once
    // per ID. Persist the identical selections before caching the response, so retrying the
    // third mission returns its original cards without incrementing authoritative ownership.
    const cards = grantMissionCardsState(
      inventoryRewardState,
      dailyCardReward.rarity,
      dailyCardReward.count,
      playerLevel,
      policy.chooseCardIndex,
    );
    inventoryRewardState = cards.state;
    response.DailyMissionsCompletionRewardCards = [...cards.cards];
  }
  if (heroicChainCompleted) {
    /*
     * CBBKFKCOLPP consumes both inventory fields directly: the card field is a JSON array of
     * IDs and the unit field is the exact Google2u sheet name paired with an integer part
     * count. The target was selected when DailyMissionsData was issued, so the fifth mission
     * cannot substitute another unit. Both grants enter the same settlement state and receipt
     * as the currencies; a dropped response therefore cannot award either inventory twice.
     */
    const cardReward = grantCardPackRewardState(
      inventoryRewardState,
      row.heroicPack,
      policy.chooseCardIndex,
    );
    inventoryRewardState = cardReward.state;
    const partsReward = grantMissionElitePartsState(
      inventoryRewardState,
      dailyMissions.heroicUnitReward,
      row.heroicEliteParts,
    );
    inventoryRewardState = partsReward.state;
    response.HeroicMissionsCompletionRewardCardPack = [...cardReward.cards];
    response.HeroicMissionsCompletionRewardArmyUnitId = partsReward.unitName;
    response.HeroicMissionsCompletionRewardArmyUnitParts = partsReward.parts;
  }

  /*
   * Normal battle rewards are separate from the one-time daily/heroic completion prizes.
   * Calculate the source base components before applying VIP. Optional values on `policy`
   * exist only as deterministic test seams; the database path never supplies them.
   *
   * CBBKFKCOLPP expects base components and applies its source VIP constants locally when
   * IsVip is true. Persist the multiplied totals while sending the unmultiplied components,
   * which keeps the stock result animation and the authoritative wallet in exact agreement.
   */
  const sourceBattleReward = missionBattleRewardFor(playerLevel, input.missionType, input.missionIndex);
  const successfulExperience = checkedNonNegativeInteger(
    policy.experience ?? sourceBattleReward.experience,
    "Mission XP reward",
  );
  const successfulWarBucks = checkedNonNegativeInteger(
    policy.warBucks ?? sourceBattleReward.warBucks,
    "Mission WarBucks reward",
  );
  const baseExperience = succeeded ? successfulExperience : 0;
  const baseWarBucks = succeeded ? successfulWarBucks : 0;
  const isVip = isVipActiveAt(state.vipExpiration, now);
  const experienceGained = isVip
    ? checkedScaledInteger(baseExperience, VIP_BATTLE_EXPERIENCE_MULTIPLIER, "Mission VIP XP")
    : baseExperience;
  const warBucksGained = isVip
    ? checkedScaledInteger(baseWarBucks, VIP_BATTLE_WARBUCKS_MULTIPLIER, "Mission VIP WarBucks")
    : baseWarBucks;

  const leveled = applyLevelExperienceState(inventoryRewardState, playerLevel, experienceGained);
  const levelChanged = leveled.levelTo !== leveled.levelFrom;
  const baseGameGold = checkedSum(missionGold, leveled.goldGranted, "Mission GameGold reward");
  const actualGameGold = isVip
    ? checkedScaledInteger(baseGameGold, VIP_LEVEL_GOLD_MULTIPLIER, "Mission VIP GameGold")
    : baseGameGold;
  // applyLevelExperienceState already included the base rank-up Gold. Replace only that base
  // amount with the actual GameGold total, then add completion prizes, which the source parser
  // treats as separate top-level rewards and does not multiply for VIP.
  const goldWithoutBaseLevelReward = leveled.state.gold - leveled.goldGranted;
  const goldWithGameReward = checkedBalanceSum(goldWithoutBaseLevelReward, actualGameGold, "Gold balance");
  const nextGold = checkedBalanceSum(goldWithGameReward, completionGold, "Gold balance");
  const nextWarBucks = checkedBalanceSum(leveled.state.warBucks, warBucksGained, "WarBucks balance");
  const nextTickets = checkedSum(leveled.state.tickets, addedTickets, "Tickets balance");
  const nextScraps = checkedSum(leveled.state.scraps, addedScraps, "Scraps balance");

  let nextState: PlayerProgressionState = {
    ...leveled.state,
    revision: checkedSum(state.revision, 1, "Progression revision"),
    gold: nextGold,
    warBucks: nextWarBucks,
    tickets: nextTickets,
    scraps: nextScraps,
    // Both mission and PvP result parsers refill energy when a rank marker is returned. The
    // durable state must receive the same refill or reconnecting would undo the client UI.
    ...(levelChanged
      ? { dogTagSeconds: leveled.state.dogTagMax, dogTagLastUpdate: now }
      : {}),
    dailyMissions,
  };
  // AchievementMissionsFinished reads StatsManager.missionsCompleted, which the recovered
  // StatsManager increments only for successful solo Daily missions (not co-op or heroic).
  if (newlyCompleted && input.missionType === "Daily") {
    nextState = advanceAchievementState(nextState, 5, 1).state;
  }

  /*
   * A rental trial is authority over a borrowed inventory row, not an end-screen decoration.
   * Consume that authority in this same pure settlement before the guarded player write. The
   * former handler-level follow-up could fail after XP/currency had committed; without another
   * client retry the borrowed item then survived more than its source-defined one battle.
   */
  const rental = advanceRentalAfterBattleState(nextState, input.battleId, now);
  nextState = rental.state;
  if (rental.saleOffer) response.Rental = rental.saleOffer;

  // OGLEHLIPEFM.KPPNCJBMDPE uses IsWarPath to select CBBKFKCOLPP. The nested component
  // names and zero fields are intentionally exact: omitting one makes the archived parser
  // dereference a missing dictionary or choose its legacy Gold-only branch.
  response.IsWarPath = 1;
  response.IsMission = 1;
  response.GameReward = {
    Warbucks: {
      BattleRewards: baseWarBucks,
      ExtraRewards: 0,
      Winstreak: 0,
      League: 0,
      offerMult: 1,
    },
    Xp: {
      BattleRewards: baseExperience,
      ExtraRewards: 0,
      Winstreak: 0,
      Time: 0,
      offerMult: 1,
    },
    GameGold: {
      BattleRewards: baseGameGold,
      League: 0,
      offerMult: 1,
    },
    IsVip: isVip,
  };
  response.DailyMissionsData = serializeDailyMissionsData(dailyMissions);
  response.LevelExperience = nextState.levelExperience;
  if (levelChanged) {
    response.Level = leveled.levelTo;
    response.DogtagsRefillRankUp = true;
  }
  response.GoldBalance = nextState.gold;
  response.WarBucksBalance = nextState.warBucks;
  response.TicketsBalance = nextState.tickets;
  response.ScrapsBalance = nextState.scraps;

  dailyMissions.recentSettlements = [
    // Store the exact client-facing response after all rewards and balances are known. If the
    // HTTP response is lost, retrying the same BattleId returns byte-equivalent reward data
    // while the persisted balances remain unchanged.
    ...dailyMissions.recentSettlements.filter((item) => item.battleId !== input.battleId),
    {
      battleId: input.battleId,
      missionIndex: input.missionIndex,
      missionType: input.missionType,
      endReason: input.endReason,
      settledAt: now,
      response: cloneResponse(response),
    },
  ].slice(-MAX_RECENT_SETTLEMENTS);
  nextState = { ...nextState, dailyMissions };

  return {
    state: nextState,
    dailyMissions,
    response,
    replayed: false,
    levelFrom: leveled.levelFrom,
    levelTo: leveled.levelTo,
    experienceGained,
  };
}

export function getOrCreateDailyMissions(playerId: string, playerLevel: number): Promise<DailyMissionMutationResult> {
  return mutateProgression(playerId, (state, now) => ensureDailyMissionsState(state, now, playerLevel));
}

export function startDailyMission(
  playerId: string,
  playerLevel: number,
  battleId: string,
  startAction: number,
): Promise<DailyMissionStartResult> {
  return mutateProgression(playerId, (state, now) =>
    startDailyMissionState(state, now, playerLevel, battleId, startAction));
}

function progressionRevisionFilter(player: PlayerDocument): Record<string, unknown> {
  if (!player.progression) return { progression: { $exists: false } };
  return player.progression.revision === undefined
    ? { "progression.revision": { $exists: false } }
    : { "progression.revision": player.progression.revision };
}

/**
 * Commit mission completion, currencies, XP/rank, dog tags, and Army Power atomically.
 *
 * A normal progression-only mutation is insufficient because a rank-up also changes the
 * public DatabasePlayer snapshot and indexed root mirrors. The revision predicate makes a
 * concurrent economy write lose cleanly; this loop then reloads the winner and recomputes
 * the entire deterministic settlement instead of overwriting newer balances.
 */
export async function settleDailyMission(
  playerId: string,
  input: DailyMissionSettlementInput,
): Promise<DailyMissionSettlementResult> {
  for (let attempt = 0; attempt < MAX_CONCURRENCY_RETRIES; attempt += 1) {
    const player = await players().findOne({ id: playerId });
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");

    const state = progressionForPlayer(player);
    const result = settleDailyMissionState(
      state,
      unixNow(),
      player.player.level,
      input,
    );
    if (result.replayed) return result;

    const nextLifetimeExperience = checkedSum(
      player.player.experience,
      result.experienceGained,
      "Player lifetime experience",
    );
    const levelChanged = result.levelTo !== result.levelFrom;
    const projected: PlayerDocument = {
      ...player,
      progression: result.state,
      player: {
        ...player.player,
        experience: nextLifetimeExperience,
        level: result.levelTo,
      },
    };
    const armyPower = levelChanged ? calculateArmyPower(projected).total : player.player.armyPower;
    const { dogTags: _legacyDogTags, ...canonicalState } = result.state;
    const update = await players().updateOne(
      { id: playerId, ...progressionRevisionFilter(player) },
      {
        $set: {
          progression: canonicalState,
          experience: nextLifetimeExperience,
          "player.experience": nextLifetimeExperience,
          "player.level": result.levelTo,
          armyPower,
          "player.armyPower": armyPower,
          updatedAt: new Date(),
        },
      },
    );
    if (update.modifiedCount === 1) {
      return { ...result, state: canonicalState };
    }
  }
  throw new ApiError(
    ApiErrorCode.InternalServerError,
    "Concurrent mission settlement could not be completed.",
  );
}
