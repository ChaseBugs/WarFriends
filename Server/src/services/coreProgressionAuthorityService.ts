import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";

export interface CoreProgressionBalances {
  gold: number;
  warBucks: number;
  tickets: number;
  scraps: number;
  levelExperience: number;
}

function safeBalance(value: number, label: string, allowDebt: boolean): number {
  if (!Number.isSafeInteger(value) || (!allowDebt && value < 0)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `Stored ${label} balance is invalid.`);
  }
  return value;
}

/**
 * Validate the core numeric progression fields before the Dynamo-style boot adapter sees them.
 *
 * `numberAttribute` is intentionally a wire-format helper, not an authority validator; its legacy
 * finite-number fallback cannot decide whether zero is a legitimate balance. Gold and WarBucks
 * may remain negative after an audited Google Play chargeback, while Tickets, Scraps, and rank XP
 * have no recovered debt semantics. Requiring safe integers here prevents NaN/Infinity from being
 * silently projected as zero and prevents fractional or unsafe balances from losing value through
 * the recovered client's integer parser.
 */
export function validatedCoreProgressionBalances(
  state: Pick<PlayerProgressionState, "gold" | "warBucks" | "tickets" | "scraps" | "levelExperience">,
): CoreProgressionBalances {
  return {
    gold: safeBalance(state.gold, "Gold", true),
    warBucks: safeBalance(state.warBucks, "WarBucks", true),
    tickets: safeBalance(state.tickets, "Tickets", false),
    scraps: safeBalance(state.scraps, "Scraps", false),
    levelExperience: safeBalance(state.levelExperience, "level experience", false),
  };
}
