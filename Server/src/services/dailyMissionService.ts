import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import type {
  DailyMissionMode,
  DailyMissionRecordState,
  DailyMissionsState,
  MissionUnitState,
  PlayerProgressionState,
} from "../db";
import { advanceAchievementState } from "./achievementService";
import { mutateProgression } from "./progressionMutationService";

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

/**
 * Reward rows serialized on the MissionsRewards component in MainScene.unity.
 *
 * The scene includes card-pack and elite-part columns as well. They are deliberately not
 * represented here until the corresponding inventory schema is authoritative: silently
 * manufacturing card IDs would be less faithful than granting the recovered currency part
 * and keeping the missing inventory delivery visible in BACKEND_FEATURES.md.
 */
const MISSION_REWARD_ROWS = [
  { level: 5, dailyGold: 10, dailyTickets: 2, dailyScraps: 20, heroicGoldMission: 1, heroicGold: 15, heroicTickets: 10, heroicScraps: 30 },
  { level: 10, dailyGold: 10, dailyTickets: 2, dailyScraps: 20, heroicGoldMission: 1, heroicGold: 15, heroicTickets: 10, heroicScraps: 30 },
  { level: 15, dailyGold: 10, dailyTickets: 2, dailyScraps: 20, heroicGoldMission: 1, heroicGold: 15, heroicTickets: 10, heroicScraps: 30 },
  { level: 20, dailyGold: 15, dailyTickets: 3, dailyScraps: 30, heroicGoldMission: 1, heroicGold: 20, heroicTickets: 13, heroicScraps: 40 },
  { level: 25, dailyGold: 15, dailyTickets: 3, dailyScraps: 30, heroicGoldMission: 1, heroicGold: 20, heroicTickets: 13, heroicScraps: 40 },
  { level: 30, dailyGold: 15, dailyTickets: 3, dailyScraps: 30, heroicGoldMission: 2, heroicGold: 20, heroicTickets: 13, heroicScraps: 40 },
  { level: 35, dailyGold: 20, dailyTickets: 4, dailyScraps: 40, heroicGoldMission: 2, heroicGold: 30, heroicTickets: 17, heroicScraps: 60 },
  { level: 40, dailyGold: 20, dailyTickets: 4, dailyScraps: 40, heroicGoldMission: 2, heroicGold: 30, heroicTickets: 17, heroicScraps: 60 },
  { level: 43, dailyGold: 20, dailyTickets: 4, dailyScraps: 40, heroicGoldMission: 2, heroicGold: 30, heroicTickets: 17, heroicScraps: 60 },
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
    return cloned;
  }

  const previous = existing ? cloneDailyMissions(existing) : undefined;
  // Once a player starts an open heroic chain, preserve its ordered progress across the
  // daily reset. An open but untouched chain may be regenerated because no reward-bearing
  // progress exists yet; isHeroicOpened itself remains true below.
  const keepOpenHeroic = previous?.isHeroicOpened === true && previous.heroicMissions.some((item) => item.completedSolo);
  const displayLevel = Math.max(1, Math.floor(playerLevel));
  return {
    dailyMissions: newDailyMissionList(),
    heroicMissions: keepOpenHeroic ? previous!.heroicMissions : newHeroicMissionList(),
    heroicPoints: Math.min(HEROIC_POINTS_TO_UNLOCK, Math.max(0, previous?.heroicPoints ?? 0)),
    isHeroicOpened: previous?.isHeroicOpened ?? false,
    tomorrow: nextUtcMidnight(now),
    // The original random choice among Gold/Tickets/Scraps/cards is absent from the archive.
    // Index 0 selects the exact scene-defined Gold reward until card inventory is recovered.
    dailyMissionRewardInd: 0,
    // DailyMissionsManager exposes these stored zero-based values as `value + 1`.
    dailyMissionLevel: displayLevel - 1,
    heroicMissionLevel: displayLevel - 1,
    // The elite-parts unit is inventory-dependent and must not be guessed from a display row.
    heroicUnitReward: keepOpenHeroic ? previous!.heroicUnitReward : "",
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

export function ensureDailyMissionsState(
  state: PlayerProgressionState,
  now: number,
  playerLevel: number,
): DailyMissionMutationResult {
  // Persist generated/rolled state on read so every device receives the same mission set.
  // Revision is incremented even when the public day is unchanged because expired private
  // receipts may have been pruned by dailyMissionsStateFor.
  const dailyMissions = dailyMissionsStateFor(state, now, playerLevel);
  return {
    state: { ...state, revision: state.revision + 1, dailyMissions },
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
      state: { ...state, revision: state.revision + 1, dailyMissions },
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
    state: { ...state, revision: state.revision + 1, dailyMissions },
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
): { gold: number; tickets: number; scraps: number; field: string } {
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
    default:
      // Indices 3-5 are card rewards. Existing legacy rows may contain one, but awarding an
      // empty card array would consume the claim without delivering the configured items.
      throw new ApiError(ApiErrorCode.UnknownAction, "Daily mission card reward delivery is not recovered.");
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
      state: { ...state, revision: state.revision + 1, dailyMissions },
      dailyMissions,
      response: cloneResponse(replay.response),
      replayed: true,
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
  let missionGold = newlyCompleted && input.missionType === "Heroic" ? row.heroicGoldMission : 0;
  let addedGold = missionGold;
  let addedTickets = 0;
  let addedScraps = 0;
  let heroicUnlocked = false;
  const response: Record<string, unknown> = {
    // OGLEHLIPEFM.KPPNCJBMDPE uses IsWarPath to select CBBKFKCOLPP, the mission-reward
    // parser. Without it, the response goes through the PvP parser and the mission end UI
    // never receives its reward model. IsMission is a descriptive replacement-client alias;
    // the stock parser ignores unknown fields.
    IsWarPath: 1,
    IsMission: 1,
    GameReward: { Gold: missionGold, IsVip: false },
  };

  if (newlyCompleted && (input.missionType === "Daily" || input.missionType === "Coop")) {
    // One unique daily/co-op completion contributes one point. Replays and CoopClient
    // acknowledgements never reach this block, so they cannot accelerate the 30-point gate.
    const wasOpen = dailyMissions.isHeroicOpened;
    dailyMissions.heroicPoints = Math.min(HEROIC_POINTS_TO_UNLOCK, dailyMissions.heroicPoints + 1);
    if (!wasOpen && dailyMissions.heroicPoints >= HEROIC_POINTS_TO_UNLOCK) {
      dailyMissions.isHeroicOpened = true;
      dailyMissions.heroicCompletionRewardClaimed = false;
      dailyMissions.heroicMissions = newHeroicMissionList();
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
    addedGold += reward.gold;
    addedTickets += reward.tickets;
    addedScraps += reward.scraps;
    response[reward.field] = reward.gold || reward.tickets || reward.scraps;
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
    addedGold += row.heroicGold;
    addedTickets += row.heroicTickets;
    addedScraps += row.heroicScraps;
    response.HeroicMissionsCompletionRewardGold = row.heroicGold;
    response.HeroicMissionsCompletionRewardTickets = row.heroicTickets;
    response.HeroicMissionsCompletionRewardScraps = row.heroicScraps;
  }

  if (heroicUnlocked) response.HeroicMissionsUnlocked = 1;
  response.HeroicPoints = dailyMissions.heroicPoints;

  let nextState: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold + addedGold,
    tickets: state.tickets + addedTickets,
    scraps: state.scraps + addedScraps,
    dailyMissions,
  };
  // AchievementMissionsFinished reads StatsManager.missionsCompleted, which the recovered
  // StatsManager increments only for successful solo Daily missions (not co-op or heroic).
  if (newlyCompleted && input.missionType === "Daily") {
    nextState = advanceAchievementState(nextState, 5, 1).state;
  }

  response.DailyMissionsData = serializeDailyMissionsData(dailyMissions);
  response.GoldBalance = nextState.gold;
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

  return { state: nextState, dailyMissions, response, replayed: false };
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

export function settleDailyMission(
  playerId: string,
  playerLevel: number,
  input: DailyMissionSettlementInput,
): Promise<DailyMissionSettlementResult> {
  return mutateProgression(playerId, (state, now) => settleDailyMissionState(state, now, playerLevel, input));
}
