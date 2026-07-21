import type { PlayerProgressionState } from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { mutateProgression } from "./progressionMutationService";
import { config } from "../config";
import { playerLevelDefinition } from "./levelProgressionService";
import { checkedRewardBalance } from "./rewardMathService";
import { isVipActiveAt } from "./vipEntitlementService";
import { validatedSubscription } from "./subscriptionBenefitService";

export interface DogTagMutationResult {
  state: PlayerProgressionState;
  currentDogTags: number;
  goldSpent: number;
}

export interface WarBucksConversionResult {
  state: PlayerProgressionState;
  id: string;
  goldDeducted: number;
  warBucksAdded: number;
  replayed: boolean;
}

interface WarBucksConversionDefinition {
  standardId: string;
  variantId: string;
  goldPrice: number;
  standardUnits: number;
  variantUnits: number;
}

/** Exact MainScene Warbucks rows; units are multiplied by the current Levels conversion row. */
const WARBUCKS_CONVERSIONS: readonly WarBucksConversionDefinition[] = [
  { standardId: "warbucks1", variantId: "bwarbucks1", goldPrice: 50, standardUnits: 50, variantUnits: 100 },
  { standardId: "warbucks2", variantId: "bwarbucks2", goldPrice: 200, standardUnits: 210, variantUnits: 400 },
  { standardId: "warbucks3", variantId: "bwarbucks3", goldPrice: 500, standardUnits: 550, variantUnits: 1000 },
  { standardId: "warbucks4", variantId: "bwarbucks4", goldPrice: 1000, standardUnits: 1150, variantUnits: 2000 },
  { standardId: "warbucks5", variantId: "bwarbucks5", goldPrice: 3500, standardUnits: 4200, variantUnits: 7000 },
  { standardId: "warbucks6", variantId: "bwarbucks6", goldPrice: 7000, standardUnits: 9800, variantUnits: 14000 },
];

const CONVERSION_REPLAY_SECONDS = 2;

function configuredWarBucksVariant(): "standard" | "b" {
  if (config.warBucksGoldVariant === "standard" || config.warBucksGoldVariant === "b") {
    return config.warBucksGoldVariant;
  }
  throw new ApiError(ApiErrorCode.InternalServerError, "WARBUCKS_GOLD_VARIANT must be standard or b.");
}

/**
 * Execute action 221 using only MainScene balancing and the authenticated player's level.
 *
 * `WarbucksId` selects a row only within the deployment-owned A/B prefix. The phone cannot
 * choose Gold price, conversion units, level multiplier, or resulting wallet values. The stock
 * request has no transaction ID, so an identical same-revision retry inside two seconds returns
 * its receipt; a later intentional conversion or any intervening economy mutation proceeds.
 */
export function convertGoldToWarBucksState(
  state: PlayerProgressionState,
  now: number,
  playerLevelIndex: number,
  requestedId: string,
  variant = configuredWarBucksVariant(),
): WarBucksConversionResult {
  const prior = state.warBucksConversion;
  if (
    prior?.id === requestedId
    && prior.progressionRevision === state.revision
    && Math.floor(now) >= prior.processedAt
    && Math.floor(now) <= prior.processedAt + CONVERSION_REPLAY_SECONDS
  ) {
    return {
      state,
      id: prior.id,
      goldDeducted: prior.goldDeducted,
      warBucksAdded: prior.warBucksAdded,
      replayed: true,
    };
  }
  const definition = WARBUCKS_CONVERSIONS.find((row) =>
    requestedId === (variant === "b" ? row.variantId : row.standardId));
  if (!definition) throw new ApiError(ApiErrorCode.UnknownAction, "WarbucksId is not active in the server A/B variant.");
  if (!Number.isSafeInteger(state.gold) || state.gold < definition.goldPrice) {
    throw new ApiError(ApiErrorCode.NotEnoughGoldForWarbucks, "Not enough Gold for this WarBucks conversion.");
  }
  const level = playerLevelDefinition(playerLevelIndex);
  const units = variant === "b" ? definition.variantUnits : definition.standardUnits;
  const warBucksAdded = units * level.convertGoldToWarBucks;
  if (!Number.isSafeInteger(warBucksAdded) || warBucksAdded <= 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "WarBucks conversion overflowed.");
  }
  const warBucks = checkedRewardBalance(state.warBucks, warBucksAdded, "Gold conversion WarBucks");
  const revision = state.revision + 1;
  const next: PlayerProgressionState = {
    ...state,
    revision,
    gold: state.gold - definition.goldPrice,
    warBucks,
    warBucksConversion: {
      id: requestedId,
      goldDeducted: definition.goldPrice,
      warBucksAdded,
      processedAt: Math.floor(now),
      progressionRevision: revision,
    },
  };
  return {
    state: next,
    id: requestedId,
    goldDeducted: definition.goldPrice,
    warBucksAdded,
    replayed: false,
  };
}

/** Exact 4.9.5 MainScene `VipDogtags` value and localized VIP benefit count. */
export const VIP_DOG_TAG_COUNT = 2;

/** Exact 4.9.5 MainScene `DogTagSubscriptionRefillTime` value. */
export const SUBSCRIPTION_DOG_TAG_REFILL_SECONDS = 450;

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
  return isVipActiveAt(state.vipExpiration, Math.floor(state.dogTagLastUpdate))
    ? VIP_DOG_TAG_COUNT * Math.max(1, Math.floor(state.dogTagRefillSeconds))
    : 0;
}

/**
 * Convert subscription-active wall time into additional normal-rate dog-tag credit.
 *
 * The recovered Client keeps DogTagSeconds and DogTagMax in normal 900-second units even while
 * its visible timer runs at 450 seconds. Its integer factor is normal/subscription (900/450 = 2),
 * so every active wall-clock second contributes one ordinary second plus one bonus second. The
 * lock returned by BuyInApp protects the partially completed interval at purchase time; expiry
 * ends acceleration without needing a background mutation. Calculating the overlap historically
 * also means the correct credit is recovered when the first request arrives after expiry.
 */
function subscriptionDogTagBonusSeconds(
  state: PlayerProgressionState,
  from: number,
  to: number,
): number {
  const subscription = validatedSubscription(state.subscription);
  if (!subscription) return 0;
  const normalRefillSeconds = Math.max(1, Math.floor(state.dogTagRefillSeconds));
  const accelerationFactor = Math.floor(normalRefillSeconds / SUBSCRIPTION_DOG_TAG_REFILL_SECONDS);
  if (accelerationFactor <= 1) return 0;

  const lock = subscription.dogTagTimerLock;
  const acceleratedFrom = Math.max(Math.floor(from), lock);
  const acceleratedTo = Math.min(Math.floor(to), subscription.expireTime);
  const acceleratedWallSeconds = Math.max(0, acceleratedTo - acceleratedFrom);
  return acceleratedWallSeconds * (accelerationFactor - 1);
}

/**
 * Apply elapsed server time to the stored energy credit. Time is capped at DogTagMax, so
 * remaining logged-out time cannot be banked beyond the configured capacity. The timestamp
 * moves to `now` only in the returned state; callers persist it inside an atomic mutation.
 */
export function materializeDogTags(state: PlayerProgressionState, now: number): PlayerProgressionState {
  const previousUpdate = Math.floor(state.dogTagLastUpdate);
  const currentTime = Math.max(previousUpdate, Math.floor(now));
  const elapsed = currentTime - previousUpdate;
  const subscriptionBonus = subscriptionDogTagBonusSeconds(state, previousUpdate, currentTime);
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
      Math.max(minimumBaseSeconds, state.dogTagSeconds + elapsed + subscriptionBonus),
    ),
    dogTagLastUpdate: currentTime,
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

export function convertGoldToWarBucks(
  playerId: string,
  playerLevelIndex: number,
  requestedId: string,
): Promise<WarBucksConversionResult> {
  return mutateProgression(playerId, (state, now) =>
    convertGoldToWarBucksState(state, now, playerLevelIndex, requestedId));
}
