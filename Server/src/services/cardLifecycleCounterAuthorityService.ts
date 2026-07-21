import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";

export interface CardLifecycleCounters {
  warCardsPlayed: number;
  goldCardsCrafted: number;
}

function counter(value: number | undefined, label: string): number {
  const normalized = value ?? 0;
  if (!Number.isSafeInteger(normalized) || normalized < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `Stored ${label} counter is invalid.`);
  }
  return normalized;
}

/** Validate the two private lifetime counters that prove card gameplay and crafting rewards. */
export function validatedCardLifecycleCounters(
  state: Pick<PlayerProgressionState, "warCardsPlayed" | "goldCardsCrafted">,
): CardLifecycleCounters {
  return {
    warCardsPlayed: counter(state.warCardsPlayed, "War Card play"),
    goldCardsCrafted: counter(state.goldCardsCrafted, "Gold-card craft"),
  };
}
