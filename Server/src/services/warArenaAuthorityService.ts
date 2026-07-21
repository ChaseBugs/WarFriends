import { ApiError, ApiErrorCode } from "../apiErrors";
import type { WarArenaState } from "../db";
import { arenaPolicy } from "./warArenaContract";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const MAX_RECENT_SETTLEMENTS = 20;
const MAX_SHOWN_ARENA_IDS = 24;
const MAX_RESPONSE_JSON_LENGTH = 65_536;
const REQUIRED_KEYS = new Set([
  "wins", "lives", "opponents", "arenaId", "runs", "visualType", "visualTimestamp", "flawless",
  "topRun", "matches", "shields", "played", "heartDialogShown", "runLosses",
  "runRewardClaimed", "recentSettlements",
]);
const OPTIONAL_KEYS = new Set([
  "shownArenaIds", "activeBattle", "lastEntryResponse", "lastHeartPurchaseAt", "lastHeartResponse",
  "lastRunRewardResponse",
]);
const BATTLE_KEYS = new Set(["battleId", "startedAt", "arenaId"]);
const SETTLEMENT_KEYS = new Set(["battleId", "endReason", "settledAt", "response"]);
const SETTLEMENT_REASONS = new Set([1, 2, 3, 5, 8]);
const SAFE_ID = /^[\w.:@+-]+$/;

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function record(value: unknown, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) invalid(`${label} is invalid.`);
  return value as Record<string, unknown>;
}

function exactRecord(value: unknown, keys: ReadonlySet<string>, label: string): Record<string, unknown> {
  const result = record(value, label);
  const actual = Object.keys(result);
  if (actual.length !== keys.size || actual.some((key) => !keys.has(key))) invalid(`${label} is invalid.`);
  return result;
}

function unixSeconds(value: unknown, label: string): number {
  if (!Number.isSafeInteger(value) || (value as number) < 0 || (value as number) > MAX_DATE_UNIX_SECONDS) {
    invalid(`${label} is invalid.`);
  }
  return value as number;
}

function boundedString(value: unknown, maximum: number, label: string, id = false): string {
  if (typeof value !== "string" || value.length > maximum || /[\u0000-\u001f\u007f]/.test(value)
    || (id && (value.length === 0 || !SAFE_ID.test(value)))) {
    invalid(`${label} is invalid.`);
  }
  return value;
}

function clonedResponse(value: unknown, label: string): Record<string, unknown> {
  const response = record(value, label);
  let json: string;
  try {
    json = JSON.stringify(response);
  } catch {
    invalid(`${label} is invalid.`);
  }
  if (json.length > MAX_RESPONSE_JSON_LENGTH) invalid(`${label} is invalid.`);
  return JSON.parse(json) as Record<string, unknown>;
}

/** Validate and clone one complete durable War Arena lifecycle snapshot. */
export function validatedWarArenaState(value: WarArenaState | undefined): WarArenaState | undefined {
  if (value === undefined) return undefined;
  const root = record(value, "Stored War Arena state");
  const keys = Object.keys(root);
  if (keys.some((key) => !REQUIRED_KEYS.has(key) && !OPTIONAL_KEYS.has(key))
    || [...REQUIRED_KEYS].some((key) => !Object.prototype.hasOwnProperty.call(root, key))) {
    invalid("Stored War Arena state is invalid.");
  }

  const counterNames = ["wins", "lives", "runs", "visualTimestamp", "flawless", "topRun", "matches", "shields", "runLosses"];
  if (counterNames.some((name) => !Number.isSafeInteger(root[name]) || (root[name] as number) < 0)) {
    invalid("Stored War Arena counters are invalid.");
  }
  const counters = Object.fromEntries(counterNames.map((name) => [name, root[name] as number])) as Record<string, number>;
  if (counters.visualTimestamp! > MAX_DATE_UNIX_SECONDS
    || counters.wins! > arenaPolicy().maxBattles || counters.topRun! > arenaPolicy().maxBattles) {
    invalid("Stored War Arena counters are invalid.");
  }
  if (typeof root.played !== "boolean" || typeof root.heartDialogShown !== "boolean"
    || typeof root.runRewardClaimed !== "boolean") {
    invalid("Stored War Arena flags are invalid.");
  }
  const arenaId = boundedString(root.arenaId, 128, "Stored War Arena identity");
  const visualType = boundedString(root.visualType, 128, "Stored War Arena visual type");

  if (!Array.isArray(root.opponents) || root.opponents.length > arenaPolicy().maxBattles) {
    invalid("Stored War Arena collections are invalid.");
  }
  const opponents = root.opponents.map((opponent) => boundedString(opponent, 160, "Stored War Arena opponent", true));
  if (new Set(opponents).size !== opponents.length) invalid("Stored War Arena collections are invalid.");

  const shownValues = root.shownArenaIds ?? [];
  if (!Array.isArray(shownValues) || shownValues.length > MAX_SHOWN_ARENA_IDS) {
    invalid("Stored War Arena collections are invalid.");
  }
  const shownArenaIds = shownValues.map((id) => boundedString(id, 128, "Stored War Arena shown identity"));
  if (new Set(shownArenaIds).size !== shownArenaIds.length) invalid("Stored War Arena collections are invalid.");

  let activeBattle: WarArenaState["activeBattle"];
  if (root.activeBattle !== undefined) {
    const battle = exactRecord(root.activeBattle, BATTLE_KEYS, "Stored War Arena battle receipt");
    activeBattle = {
      battleId: boundedString(battle.battleId, 160, "Stored War Arena battle receipt", true),
      startedAt: unixSeconds(battle.startedAt, "Stored War Arena battle receipt"),
      arenaId: boundedString(battle.arenaId, 128, "Stored War Arena battle receipt"),
    };
    if (activeBattle.arenaId !== arenaId) invalid("Stored War Arena battle receipt is invalid.");
  }

  if (!Array.isArray(root.recentSettlements) || root.recentSettlements.length > MAX_RECENT_SETTLEMENTS) {
    invalid("Stored War Arena collections are invalid.");
  }
  const settlementIds = new Set<string>();
  const recentSettlements = root.recentSettlements.map((value, index) => {
    const settlement = exactRecord(value, SETTLEMENT_KEYS, "Stored War Arena settlement receipt");
    const battleId = boundedString(settlement.battleId, 160, "Stored War Arena settlement receipt", true);
    const endReason = settlement.endReason;
    if (!Number.isSafeInteger(endReason) || !SETTLEMENT_REASONS.has(endReason as number)
      || settlementIds.has(battleId)) {
      invalid("Stored War Arena settlement receipt is invalid.");
    }
    settlementIds.add(battleId);
    return {
      battleId,
      endReason: endReason as number,
      settledAt: unixSeconds(settlement.settledAt, "Stored War Arena settlement receipt"),
      response: clonedResponse(settlement.response, `Stored War Arena settlement ${index} response`),
    };
  });
  if (activeBattle && settlementIds.has(activeBattle.battleId)) invalid("Stored War Arena battle receipt is invalid.");

  const lastHeartPurchaseAt = root.lastHeartPurchaseAt === undefined
    ? undefined
    : unixSeconds(root.lastHeartPurchaseAt, "Stored War Arena heart receipt");
  return {
    wins: counters.wins!, lives: counters.lives!, opponents, arenaId, runs: counters.runs!, visualType,
    visualTimestamp: counters.visualTimestamp!, flawless: counters.flawless!, topRun: counters.topRun!,
    matches: counters.matches!, shields: counters.shields!, played: root.played,
    heartDialogShown: root.heartDialogShown, shownArenaIds, runLosses: counters.runLosses!,
    runRewardClaimed: root.runRewardClaimed, ...(activeBattle ? { activeBattle } : {}), recentSettlements,
    ...(root.lastEntryResponse === undefined ? {} : { lastEntryResponse: clonedResponse(root.lastEntryResponse, "Stored War Arena entry response") }),
    ...(lastHeartPurchaseAt === undefined ? {} : { lastHeartPurchaseAt }),
    ...(root.lastHeartResponse === undefined ? {} : { lastHeartResponse: clonedResponse(root.lastHeartResponse, "Stored War Arena heart response") }),
    ...(root.lastRunRewardResponse === undefined ? {} : { lastRunRewardResponse: clonedResponse(root.lastRunRewardResponse, "Stored War Arena reward response") }),
  };
}
