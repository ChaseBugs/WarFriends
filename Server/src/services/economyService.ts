import type { PlayerProgressionState } from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { mutateProgression } from "./progressionMutationService";

export interface DogTagMutationResult {
  state: PlayerProgressionState;
  currentDogTags: number;
  goldSpent: number;
}

/**
 * Apply elapsed server time to the stored energy credit. Time is capped at DogTagMax, so
 * remaining logged-out time cannot be banked beyond the configured capacity. The timestamp
 * moves to `now` only in the returned state; callers persist it inside an atomic mutation.
 */
export function materializeDogTags(state: PlayerProgressionState, now: number): PlayerProgressionState {
  const elapsed = Math.max(0, Math.floor(now) - Math.floor(state.dogTagLastUpdate));
  return {
    ...state,
    dogTagSeconds: Math.min(state.dogTagMax, Math.max(0, state.dogTagSeconds) + elapsed),
    dogTagLastUpdate: Math.floor(now),
  };
}

export function currentDogTagCount(state: PlayerProgressionState): number {
  return Math.floor(Math.max(0, state.dogTagSeconds) / Math.max(1, state.dogTagRefillSeconds));
}

/** Exact formula recovered from DogTagManager.dogtagRefillPrice. */
export function dogTagRefillPrice(currentDogTags: number): number {
  return Math.max(0, 35 - 2 * Math.max(0, Math.floor(currentDogTags)));
}

/** Pure transition used by both the database mutation and contract tests. */
export function spendOneDogTagState(state: PlayerProgressionState, now: number): DogTagMutationResult {
  const materialized = materializeDogTags(state, now);
  if (currentDogTagCount(materialized) < 1) {
    throw new ApiError(ApiErrorCode.NotEnoughCurrency, "Not enough dog tags.");
  }
  const next = {
    ...materialized,
    revision: materialized.revision + 1,
    dogTagSeconds: materialized.dogTagSeconds - materialized.dogTagRefillSeconds,
  };
  return { state: next, currentDogTags: currentDogTagCount(next), goldSpent: 0 };
}

/**
 * Refill all dog tags while charging the server-owned gold balance. The client sends only
 * timing/cap constants and never sends a price; both price and resulting balance are derived
 * here, preventing a modified client from buying energy for an arbitrary amount.
 */
export function refillDogTagsState(state: PlayerProgressionState, now: number): DogTagMutationResult {
  const materialized = materializeDogTags(state, now);
  const currentDogTags = currentDogTagCount(materialized);
  const maximumDogTags = Math.floor(materialized.dogTagMax / materialized.dogTagRefillSeconds);
  if (currentDogTags >= maximumDogTags) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Dog tags are already full.");
  }
  const goldSpent = dogTagRefillPrice(currentDogTags);
  if (materialized.gold < goldSpent) {
    throw new ApiError(ApiErrorCode.NotEnoughCurrency, "Not enough gold to refill dog tags.");
  }
  const next = {
    ...materialized,
    revision: materialized.revision + 1,
    gold: materialized.gold - goldSpent,
    dogTagSeconds: materialized.dogTagMax,
  };
  return { state: next, currentDogTags: maximumDogTags, goldSpent };
}

export function spendOneDogTag(playerId: string): Promise<DogTagMutationResult> {
  return mutateProgression(playerId, spendOneDogTagState);
}

export function refillDogTags(playerId: string): Promise<DogTagMutationResult> {
  return mutateProgression(playerId, refillDogTagsState);
}
