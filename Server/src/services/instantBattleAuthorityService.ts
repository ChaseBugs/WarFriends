import { ApiError, ApiErrorCode } from "../apiErrors";
import type { InstantBattleReceiptState, InstantBattleState } from "../db";

/** PlayerAnalyticsData stores all three public Skirmish fields as signed C# `int` values. */
const MAX_CLIENT_COUNTER = 2_147_483_647;
const INSTANT_BATTLE_STATE_KEYS = new Set([
  "instantBattlesTime",
  "instantBattles",
  "paidInstantBattles",
  "lastReceipt",
]);
const INSTANT_BATTLE_RECEIPT_KEYS = new Set([
  "settledAt",
  "progressionRevision",
  "paidCost",
  "battleCount",
  "experienceGained",
  "warBucks",
  "levelFrom",
  "levelTo",
  "levelExperience",
  "levelGold",
  "dogTagsRefilled",
]);
/** Source-aligned 4.9.5/1.6.0 action-199 constants. */
export const INSTANT_BATTLE_UNLOCK_DISPLAY_LEVEL = 9;
export const INSTANT_BATTLE_MAX_CHARGES = 5;
export const INSTANT_BATTLE_RELOAD_SECONDS = 48 * 60;
export const INSTANT_BATTLE_MIN_GOLD_COST = 35;
export const INSTANT_BATTLE_MAX_GOLD_COST = 140;
const INSTANT_BATTLE_PAID_COSTS = new Set([
  0,
  INSTANT_BATTLE_MIN_GOLD_COST,
  INSTANT_BATTLE_MIN_GOLD_COST * 2,
  INSTANT_BATTLE_MAX_GOLD_COST,
]);

function clientCounter(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_CLIENT_COUNTER) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} is invalid.`);
  }
  return value;
}

function safeCounter(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} is invalid.`);
  }
  return value;
}

function validatedInstantBattleReceipt(
  value: InstantBattleReceiptState,
  instantBattles: number,
  paidInstantBattles: number,
  progressionRevision?: number,
): InstantBattleReceiptState {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle receipt is invalid.");
  }
  const keys = Object.keys(value);
  if (keys.length !== INSTANT_BATTLE_RECEIPT_KEYS.size
    || keys.some((key) => !INSTANT_BATTLE_RECEIPT_KEYS.has(key))) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle receipt is invalid.");
  }

  const settledAt = clientCounter(value.settledAt, "Instant Battle receipt time");
  const receiptRevision = safeCounter(value.progressionRevision, "Instant Battle receipt revision");
  const paidCost = clientCounter(value.paidCost, "Instant Battle receipt Gold cost");
  const battleCount = clientCounter(value.battleCount, "Instant Battle receipt battle count");
  const experienceGained = clientCounter(value.experienceGained, "Instant Battle receipt experience");
  const warBucks = clientCounter(value.warBucks, "Instant Battle receipt WarBucks");
  const levelFrom = clientCounter(value.levelFrom, "Instant Battle receipt source level");
  const levelTo = clientCounter(value.levelTo, "Instant Battle receipt target level");
  const levelExperience = clientCounter(value.levelExperience, "Instant Battle receipt level experience");
  const levelGold = clientCounter(value.levelGold, "Instant Battle receipt level Gold");
  if (
    receiptRevision < 1
    || (progressionRevision !== undefined && receiptRevision > progressionRevision)
    || !INSTANT_BATTLE_PAID_COSTS.has(paidCost)
    || battleCount < 1
    || battleCount > INSTANT_BATTLE_MAX_CHARGES
    || battleCount > instantBattles
    || (paidCost > 0 && (battleCount !== INSTANT_BATTLE_MAX_CHARGES || paidInstantBattles < 1))
    || levelTo < levelFrom
    || typeof value.dogTagsRefilled !== "boolean"
    || value.dogTagsRefilled !== (levelTo !== levelFrom)
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle receipt is inconsistent.");
  }
  return {
    settledAt,
    progressionRevision: receiptRevision,
    paidCost,
    battleCount,
    experienceGained,
    warBucks,
    levelFrom,
    levelTo,
    levelExperience,
    levelGold,
    dogTagsRefilled: value.dogTagsRefilled,
  };
}

/**
 * Validate the complete public Skirmish counter tuple and private replay receipt shape.
 *
 * JavaScript safe integers are wider than the recovered client's signed `int`, so checking only
 * `Number.isSafeInteger` still lets boot serialize values the C# parser cannot represent. A future
 * recharge anchor freezes free capacity, and a paid-batch count whose required five-battle groups
 * exceed the lifetime count creates contradictory pricing authority. These are durable server
 * counters, not presentation values: reject damaged tuples instead of clamping them into a valid
 * timer, price tier, replay result, or capacity. An absent record alone represents a fresh zeroed
 * account. The wall-clock comparison remains in `validatedInstantBattleState` so this proof is
 * deterministic when it guards a multi-document transaction publisher.
 */
export function validatedInstantBattleShape(
  value: InstantBattleState | undefined,
  progressionRevision?: number,
): InstantBattleState {
  const current = value ?? {
    instantBattlesTime: 0,
    instantBattles: 0,
    paidInstantBattles: 0,
  };
  if (!current || typeof current !== "object" || Array.isArray(current)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle state is invalid.");
  }
  const keys = Object.keys(current);
  if (keys.length < 3 || keys.length > INSTANT_BATTLE_STATE_KEYS.size
    || keys.some((key) => !INSTANT_BATTLE_STATE_KEYS.has(key))) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle state is invalid.");
  }
  if (progressionRevision !== undefined) safeCounter(progressionRevision, "Instant Battle progression revision");
  const instantBattlesTime = clientCounter(current.instantBattlesTime, "Instant Battle timer");
  const instantBattles = clientCounter(current.instantBattles, "Instant Battle lifetime count");
  const paidInstantBattles = clientCounter(current.paidInstantBattles, "Paid Instant Battle count");
  if (paidInstantBattles > Math.floor(instantBattles / INSTANT_BATTLE_MAX_CHARGES)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle counters are inconsistent.");
  }
  const lastReceipt = Object.prototype.hasOwnProperty.call(current, "lastReceipt")
    ? validatedInstantBattleReceipt(
      current.lastReceipt as InstantBattleReceiptState,
      instantBattles,
      paidInstantBattles,
      progressionRevision,
    )
    : undefined;
  return {
    instantBattlesTime,
    instantBattles,
    paidInstantBattles,
    ...(lastReceipt ? { lastReceipt } : {}),
  };
}

/**
 * Apply request-time checks to an already deterministic Instant Battle authority snapshot.
 * Shared progression publication uses `validatedInstantBattleShape`; boot and action 199 add
 * the authoritative clock here so future recharge anchors or replay receipts cannot freeze
 * capacity or become valid merely through JavaScript time comparison behavior.
 */
export function validatedInstantBattleState(
  value: InstantBattleState | undefined,
  now?: number,
  progressionRevision?: number,
): InstantBattleState {
  if (now !== undefined) clientCounter(now, "Instant Battle authority time");
  const current = validatedInstantBattleShape(value, progressionRevision);
  if (now !== undefined && current.instantBattlesTime > now) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle timer is in the future.");
  }
  if (now !== undefined && current.lastReceipt && current.lastReceipt.settledAt > now) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle receipt is in the future.");
  }
  return current;
}
