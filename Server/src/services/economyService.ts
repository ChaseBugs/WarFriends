import type { PlayerProgressionState } from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { mutateProgression } from "./progressionMutationService";

export interface DogTagMutationResult {
  state: PlayerProgressionState;
  currentDogTags: number;
  goldSpent: number;
}

/** Exact 4.9.5 MainScene `VipDogtags` value and localized VIP benefit count. */
export const VIP_DOG_TAG_COUNT = 2;

/**
 * Return the virtual capacity credit used by the recovered DogTagManager.
 *
 * VIP does not rewrite the server-provided DogTagMax. DogTagManager.GOFEHOCFIMM adds two
 * refill intervals to both the visible balance and maximum while VipManager reports an
 * active deadline. Keeping the bonus virtual is important: purchase immediately exposes two
 * full tags, renewal does not stack another two, and expiry removes the capacity without a
 * migration or background job.
 */
export function vipDogTagBonusSeconds(state: PlayerProgressionState): number {
  return Math.floor(state.vipExpiration ?? 0) > Math.floor(state.dogTagLastUpdate)
    ? VIP_DOG_TAG_COUNT * Math.max(1, Math.floor(state.dogTagRefillSeconds))
    : 0;
}

/**
 * Apply elapsed server time to the stored energy credit. Time is capped at DogTagMax, so
 * remaining logged-out time cannot be banked beyond the configured capacity. The timestamp
 * moves to `now` only in the returned state; callers persist it inside an atomic mutation.
 */
export function materializeDogTags(state: PlayerProgressionState, now: number): PlayerProgressionState {
  const elapsed = Math.max(0, Math.floor(now) - Math.floor(state.dogTagLastUpdate));
  const refillSeconds = Math.max(1, Math.floor(state.dogTagRefillSeconds));
  // Spending the two virtual VIP tags can legitimately make the stored base credit negative.
  // The stock client then adds elapsed time to that debt, so clamping to zero here would grant
  // a consumed VIP tag again on every request. Bound the debt to the only source-backed bonus
  // while continuing to cap positive base credit at the normal (non-VIP) DogTagMax.
  const minimumBaseSeconds = -VIP_DOG_TAG_COUNT * refillSeconds;
  return {
    ...state,
    dogTagSeconds: Math.min(
      state.dogTagMax,
      Math.max(minimumBaseSeconds, state.dogTagSeconds + elapsed),
    ),
    dogTagLastUpdate: Math.floor(now),
  };
}

export function currentDogTagCount(state: PlayerProgressionState): number {
  const refillSeconds = Math.max(1, Math.floor(state.dogTagRefillSeconds));
  const vipBonus = vipDogTagBonusSeconds(state);
  const effectiveSeconds = Math.min(
    state.dogTagMax + vipBonus,
    Math.max(0, state.dogTagSeconds + vipBonus),
  );
  return Math.floor(effectiveSeconds / refillSeconds);
}

/** Visible maximum; DogTagMax itself deliberately remains the normal five-tag base cap. */
export function maximumDogTagCount(state: PlayerProgressionState): number {
  return Math.floor(
    (state.dogTagMax + vipDogTagBonusSeconds(state))
      / Math.max(1, Math.floor(state.dogTagRefillSeconds)),
  );
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
  const maximumDogTags = maximumDogTagCount(materialized);
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
