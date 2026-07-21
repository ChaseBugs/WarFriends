import { ApiError, ApiErrorCode } from "../apiErrors";
import type { InstantBattleState } from "../db";

/** PlayerAnalyticsData stores all three public Skirmish fields as signed C# `int` values. */
const MAX_CLIENT_COUNTER = 2_147_483_647;

/** Source-aligned 4.9.5/1.6.0 action-199 constants. */
export const INSTANT_BATTLE_UNLOCK_DISPLAY_LEVEL = 9;
export const INSTANT_BATTLE_MAX_CHARGES = 5;
export const INSTANT_BATTLE_RELOAD_SECONDS = 48 * 60;
export const INSTANT_BATTLE_MIN_GOLD_COST = 35;
export const INSTANT_BATTLE_MAX_GOLD_COST = 140;

function clientCounter(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_CLIENT_COUNTER) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} is invalid.`);
  }
  return value;
}

/**
 * Validate the complete public Skirmish counter tuple before readiness, settlement, or boot.
 *
 * JavaScript safe integers are wider than the recovered client's signed `int`, so checking only
 * `Number.isSafeInteger` still lets boot serialize values the C# parser cannot represent. A future
 * recharge anchor freezes free capacity, and a paid-batch count whose required five-battle groups
 * exceed the lifetime count creates contradictory pricing authority. These are durable server
 * counters, not presentation values: reject damaged tuples instead of clamping them into a valid
 * timer, price tier, or capacity. An absent record alone represents a fresh zeroed account.
 */
export function validatedInstantBattleState(
  value: InstantBattleState | undefined,
  now?: number,
): InstantBattleState {
  if (now !== undefined) clientCounter(now, "Instant Battle authority time");
  const current = value ?? {
    instantBattlesTime: 0,
    instantBattles: 0,
    paidInstantBattles: 0,
  };
  const instantBattlesTime = clientCounter(current.instantBattlesTime, "Instant Battle timer");
  const instantBattles = clientCounter(current.instantBattles, "Instant Battle lifetime count");
  const paidInstantBattles = clientCounter(current.paidInstantBattles, "Paid Instant Battle count");
  if (now !== undefined && instantBattlesTime > now) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle timer is in the future.");
  }
  if (paidInstantBattles > Math.floor(instantBattles / INSTANT_BATTLE_MAX_CHARGES)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Instant Battle counters are inconsistent.");
  }
  return {
    instantBattlesTime,
    instantBattles,
    paidInstantBattles,
    ...(current.lastReceipt ? { lastReceipt: { ...current.lastReceipt } } : {}),
  };
}
