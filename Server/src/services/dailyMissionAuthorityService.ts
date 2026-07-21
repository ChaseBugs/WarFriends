import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  DailyMissionMode,
  DailyMissionRecordState,
  DailyMissionsState,
  MissionUnitState,
} from "../db";
import { isPlayerUnitName } from "./unitInventoryService";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const MAX_ACTIVE_SESSIONS = 4;
const MAX_RECENT_SETTLEMENTS = 20;
const MAX_RESPONSE_JSON_LENGTH = 65_536;
const MAX_LEVEL_INDEX = 57;
const ROOT_KEYS = new Set([
  "dailyMissions", "heroicMissions", "heroicPoints", "isHeroicOpened", "tomorrow",
  "dailyMissionRewardInd", "dailyMissionLevel", "heroicMissionLevel", "heroicUnitReward", "dayKey",
  "dailyCompletionRewardClaimed", "heroicCompletionRewardClaimed", "activeSessions", "recentSettlements",
]);
const MISSION_KEYS = new Set(["type", "cnf", "completedSolo", "completedCoop"]);
const UNIT_KEYS = new Set(["i", "vet", "eli", "lev"]);
const SESSION_KEYS = new Set(["battleId", "startAction", "startedAt", "dayKey"]);
const SETTLEMENT_KEYS = new Set(["battleId", "missionIndex", "missionType", "endReason", "settledAt", "response"]);
const DAILY_TYPES = ["DailyMissionKillUnits", "DailyMissionSurvive", "DailyMissionWaves"] as const;
const HEROIC_TYPES = [
  "DailyMissionKillUnits", "DailyMissionSurvive", "DailyMissionWaves", "DailyMissionKillUnits", "DailyMissionBoss",
] as const;
const MODES: ReadonlySet<string> = new Set(["Daily", "Coop", "CoopClient", "Heroic"]);
const SAFE_ID = /^[\w.:@+-]+$/;

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function exactObject(value: unknown, keys: ReadonlySet<string>, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) invalid(`${label} is invalid.`);
  const record = value as Record<string, unknown>;
  const actual = Object.keys(record);
  if (actual.length !== keys.size || actual.some((key) => !keys.has(key))) invalid(`${label} is invalid.`);
  return record;
}

function safeInteger(value: unknown, label: string, maximum = Number.MAX_SAFE_INTEGER): number {
  if (!Number.isSafeInteger(value) || (value as number) < 0 || (value as number) > maximum) invalid(`${label} is invalid.`);
  return value as number;
}

function unixSeconds(value: unknown, label: string): number {
  return safeInteger(value, label, MAX_DATE_UNIX_SECONDS);
}

function battleId(value: unknown, label: string): string {
  if (typeof value !== "string" || value.length === 0 || value.length > 160 || !SAFE_ID.test(value)) invalid(`${label} is invalid.`);
  return value;
}

function clonedResponse(value: unknown, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) invalid(`${label} is invalid.`);
  let json: string;
  try { json = JSON.stringify(value); } catch { invalid(`${label} is invalid.`); }
  if (json.length > MAX_RESPONSE_JSON_LENGTH) invalid(`${label} is invalid.`);
  return JSON.parse(json) as Record<string, unknown>;
}

function validatedUnit(value: unknown, label: string): MissionUnitState {
  const unit = exactObject(value, UNIT_KEYS, label);
  const i = safeInteger(unit.i, `${label} index`, 23);
  if (typeof unit.vet !== "boolean" || typeof unit.eli !== "boolean") invalid(`${label} flags are invalid.`);
  const lev = safeInteger(unit.lev, `${label} level`, MAX_LEVEL_INDEX);
  return { i, vet: unit.vet, eli: unit.eli, lev };
}

function validatedMission(value: unknown, expectedType: string, label: string): DailyMissionRecordState {
  const mission = exactObject(value, MISSION_KEYS, label);
  if (mission.type !== expectedType || typeof mission.completedSolo !== "boolean"
    || typeof mission.completedCoop !== "boolean") invalid(`${label} is invalid.`);
  const expectedConfigKeys = expectedType === "DailyMissionKillUnits"
    ? new Set(["units", "time", "killUnits"])
    : expectedType === "DailyMissionSurvive"
      ? new Set(["units", "time"])
      : new Set(["units", "waves"]);
  const config = exactObject(mission.cnf, expectedConfigKeys, `${label} config`);
  if (!Array.isArray(config.units) || config.units.length !== 3) invalid(`${label} units are invalid.`);
  const units = config.units.map((unit, index) => validatedUnit(unit, `${label} unit ${index}`));
  const boss = expectedType === "DailyMissionBoss";
  if (units.some((unit, index) => unit.i !== index || unit.vet || unit.lev !== 0
    || unit.eli !== (boss && index === 0))) {
    invalid(`${label} units are invalid.`);
  }
  const resultConfig: DailyMissionRecordState["cnf"] = { units };
  if (expectedConfigKeys.has("time")) {
    if (config.time !== 90) invalid(`${label} time is invalid.`);
    resultConfig.time = 90;
  }
  if (expectedConfigKeys.has("killUnits")) {
    if (config.killUnits !== 10) invalid(`${label} kill target is invalid.`);
    resultConfig.killUnits = 10;
  }
  if (expectedConfigKeys.has("waves")) {
    if (!Array.isArray(config.waves) || config.waves.length !== 0) invalid(`${label} waves are invalid.`);
    resultConfig.waves = [];
  }
  return {
    type: expectedType as DailyMissionRecordState["type"],
    cnf: resultConfig,
    completedSolo: mission.completedSolo,
    completedCoop: mission.completedCoop,
  };
}

function utcDayKey(now: number): string {
  return new Date(now * 1_000).toISOString().slice(0, 10);
}

/** Validate and clone one complete DailyMissionsData lifecycle plus private receipts. */
export function validatedDailyMissionsState(value: DailyMissionsState | undefined): DailyMissionsState | undefined {
  if (value === undefined) return undefined;
  const root = exactObject(value, ROOT_KEYS, "Stored Daily Missions state");
  const dailyValues = root.dailyMissions;
  const heroicValues = root.heroicMissions;
  if (!Array.isArray(dailyValues) || dailyValues.length !== DAILY_TYPES.length
    || !Array.isArray(heroicValues) || heroicValues.length !== HEROIC_TYPES.length) {
    invalid("Stored Daily Missions collection is invalid.");
  }
  const dailyMissions = DAILY_TYPES.map((type, index) => validatedMission(dailyValues[index], type, `Stored daily mission ${index}`));
  const heroicMissions = HEROIC_TYPES.map((type, index) => validatedMission(heroicValues[index], type, `Stored heroic mission ${index}`));
  if (heroicMissions.some((mission) => mission.completedCoop)) invalid("Stored heroic mission completion is invalid.");
  let incompleteHeroicSeen = false;
  for (const mission of heroicMissions) {
    if (!mission.completedSolo) incompleteHeroicSeen = true;
    else if (incompleteHeroicSeen) invalid("Stored heroic mission order is invalid.");
  }

  const heroicPoints = safeInteger(root.heroicPoints, "Stored heroic points", 30);
  if (typeof root.isHeroicOpened !== "boolean" || typeof root.dailyCompletionRewardClaimed !== "boolean"
    || typeof root.heroicCompletionRewardClaimed !== "boolean") invalid("Stored Daily Missions flags are invalid.");
  if (root.dailyCompletionRewardClaimed && !dailyMissions.every((mission) => mission.completedSolo)) {
    invalid("Stored daily completion reward authority is inconsistent.");
  }
  if (root.heroicCompletionRewardClaimed && (!heroicMissions.every((mission) => mission.completedSolo)
    || root.isHeroicOpened || heroicPoints !== 0)) {
    invalid("Stored heroic completion reward authority is inconsistent.");
  }
  if (root.isHeroicOpened && root.heroicCompletionRewardClaimed) invalid("Stored heroic lifecycle is inconsistent.");

  const tomorrow = unixSeconds(root.tomorrow, "Stored Daily Missions reset time");
  if (typeof root.dayKey !== "string" || root.dayKey !== utcDayKey(Math.max(0, tomorrow - 1))) {
    invalid("Stored Daily Missions UTC cycle is inconsistent.");
  }
  const dayKey = root.dayKey;
  const dailyMissionRewardInd = safeInteger(root.dailyMissionRewardInd, "Stored Daily mission reward index", 5);
  const dailyMissionLevel = safeInteger(root.dailyMissionLevel, "Stored daily mission level", MAX_LEVEL_INDEX);
  const heroicMissionLevel = safeInteger(root.heroicMissionLevel, "Stored heroic mission level", MAX_LEVEL_INDEX);
  // The selector receives the zero-based player level index and enables cards at index 5, while
  // DailyMissionsData stores that input minus one for the client's `value + 1` projection.
  if (dailyMissionLevel < 4 && dailyMissionRewardInd > 2) invalid("Stored Daily mission reward index is invalid.");
  if (typeof root.heroicUnitReward !== "string"
    || (root.heroicUnitReward !== "" && !isPlayerUnitName(root.heroicUnitReward))) {
    invalid("Stored heroic unit reward is invalid.");
  }

  if (!Array.isArray(root.activeSessions) || root.activeSessions.length > MAX_ACTIVE_SESSIONS
    || !Array.isArray(root.recentSettlements) || root.recentSettlements.length > MAX_RECENT_SETTLEMENTS) {
    invalid("Stored Daily Missions receipts are invalid.");
  }
  const receiptIds = new Set<string>();
  const activeSessions = root.activeSessions.map((value, index) => {
    const session = exactObject(value, SESSION_KEYS, `Stored mission session ${index}`);
    const id = battleId(session.battleId, "Stored mission battle receipt");
    if (receiptIds.has(id) || ![67, 68, 69].includes(session.startAction as number)
      || session.dayKey !== dayKey) invalid("Stored mission battle receipt is invalid.");
    receiptIds.add(id);
    return {
      battleId: id,
      startAction: session.startAction as number,
      startedAt: unixSeconds(session.startedAt, "Stored mission battle receipt"),
      dayKey,
    };
  });
  const recentSettlements = root.recentSettlements.map((value, index) => {
    const settlement = exactObject(value, SETTLEMENT_KEYS, `Stored mission settlement ${index}`);
    const id = battleId(settlement.battleId, "Stored mission settlement receipt");
    const mode = settlement.missionType;
    const missionIndex = settlement.missionIndex;
    if (receiptIds.has(id) || typeof mode !== "string" || !MODES.has(mode)
      || !Number.isSafeInteger(missionIndex) || (missionIndex as number) < 0
      || (missionIndex as number) >= (mode === "Heroic" ? 5 : 3)
      || ![9, 10].includes(settlement.endReason as number)) {
      invalid("Stored mission settlement receipt is invalid.");
    }
    receiptIds.add(id);
    return {
      battleId: id,
      missionIndex: missionIndex as number,
      missionType: mode as DailyMissionMode,
      endReason: settlement.endReason as number,
      settledAt: unixSeconds(settlement.settledAt, "Stored mission settlement receipt"),
      response: clonedResponse(settlement.response, "Stored mission settlement response"),
    };
  });

  return {
    dailyMissions, heroicMissions, heroicPoints, isHeroicOpened: root.isHeroicOpened, tomorrow,
    dailyMissionRewardInd, dailyMissionLevel, heroicMissionLevel, heroicUnitReward: root.heroicUnitReward,
    dayKey, dailyCompletionRewardClaimed: root.dailyCompletionRewardClaimed,
    heroicCompletionRewardClaimed: root.heroicCompletionRewardClaimed, activeSessions, recentSettlements,
  };
}
