import { randomInt } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";
import { CARD_CATALOG, cardInventoryStateFor } from "./cardInventoryService";
import { mutateProgression } from "./progressionMutationService";
import { isVipActiveAt, validatedVipExpiration } from "./vipEntitlementService";

/** IJEAJGCCHEF values handled by the stock BuyVip failure parser. */
export const VIP_NOT_ENOUGH_GOLD = 11_401;
export const VIP_DISCOUNT_NOT_FOUND = 13_601;

/**
 * Source-exact chance that one daily VIP reward is Gold rather than Silver.
 *
 * The 4.9.5 MainScene row `VipGoldCardRewardChance` stores ObscuredFloat bytes e785433f with
 * crypto key 230887. Little-endian XOR decoding produces 0.75. The benefit text promises two
 * rare cards each day, and the archived card rarity model names levels 2/3 Silver/Gold, so each
 * of the two independent selections falls back to Silver when this Gold roll fails.
 */
export const VIP_GOLD_CARD_REWARD_CHANCE = 0.75;

export type VipRandomIndex = (upperBound: number) => number;

export interface VipDailyCardReward {
  cardIds: [string, string];
  /** Stable value used by NGGINCOPKKJ to make `VipCardMessage {0}` unique for the UTC day. */
  dayKey: string;
}

export interface VipDailyCardResult {
  state: PlayerProgressionState;
  reward?: VipDailyCardReward;
}

export interface VipProductDefinition {
  id: string;
  gold: number;
  seconds: number;
}

/**
 * Exact Google2u.VIP rows serialized in the recovered 4.9.5 MainScene.
 *
 * Action 114 sends the row NAME and a client-computed discount, but it does not send duration.
 * Keeping both price and duration here prevents a modified client from purchasing an arbitrary
 * amount of entitlement or choosing its own Gold debit.
 */
export const VIP_CATALOG: Readonly<Record<string, VipProductDefinition>> = Object.freeze({
  VIP_1: { id: "VIP_1", gold: 49, seconds: 43_200 },
  VIP_2: { id: "VIP_2", gold: 249, seconds: 259_200 },
  VIP_3: { id: "VIP_3", gold: 499, seconds: 604_800 },
  VIP_4: { id: "VIP_4", gold: 1_799, seconds: 2_592_000 },
});

export interface VipPurchaseResult {
  state: PlayerProgressionState;
  product: VipProductDefinition;
  cost: number;
  vipStart: number;
  vipExpiration: number;
  dailyCardReward?: VipDailyCardReward;
}

const VIP_CARD_POOLS: Readonly<Record<2 | 3, readonly string[]>> = Object.freeze({
  2: Object.freeze(Object.values(CARD_CATALOG)
    .filter((card) => card.implemented && card.rarity === 2)
    .map((card) => card.name)
    .sort()),
  3: Object.freeze(Object.values(CARD_CATALOG)
    .filter((card) => card.implemented && card.rarity === 3)
    .map((card) => card.name)
    .sort()),
});

function utcDayKey(now: number): string {
  return new Date(now * 1_000).toISOString().slice(0, 10);
}

function chooseIndex(choose: VipRandomIndex, upperBound: number): number {
  const selected = choose(upperBound);
  if (!Number.isInteger(selected) || selected < 0 || selected >= upperBound) {
    throw new ApiError(ApiErrorCode.InternalServerError, "VIP card selector returned an invalid index.");
  }
  return selected;
}

function chooseVipCard(choose: VipRandomIndex): string {
  // Use an integer roll instead of floating-point Math.random. This keeps the decoded 0.75
  // threshold exact and delegates entropy to Node's rejection-sampled cryptographic RNG.
  const rarity: 2 | 3 = chooseIndex(choose, 10_000) < VIP_GOLD_CARD_REWARD_CHANCE * 10_000 ? 3 : 2;
  const pool = VIP_CARD_POOLS[rarity];
  if (pool.length === 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `VIP rarity ${rarity} card pool is empty.`);
  }
  return pool[chooseIndex(choose, pool.length)]!;
}

/**
 * Apply the daily benefit without changing the progression revision.
 *
 * Keeping this as a private composition primitive lets BuyVip debit Gold, extend the entitlement,
 * grant both cards, and increment the revision exactly once. The public wrapper below increments
 * once when GetPlayerData grants a pair to an already-active member.
 */
function applyDailyVipCards(
  state: PlayerProgressionState,
  now: number,
  choose: VipRandomIndex,
): VipDailyCardResult {
  const expiration = validatedVipExpiration(state.vipExpiration);
  const dayKey = utcDayKey(now);
  if (!isVipActiveAt(expiration, now) || state.vipDailyCards?.lastGrantDay === dayKey) return { state };

  // The two cards are independent draws. A duplicate is valid and increments the same amount
  // twice, matching CardManager.AddCard being invoked once for each response field.
  const cardIds: [string, string] = [chooseVipCard(choose), chooseVipCard(choose)];
  const cardInventory = cardInventoryStateFor(state);
  for (const cardId of cardIds) {
    const previous = cardInventory.cardData[cardId]?.amount ?? 0;
    if (!Number.isSafeInteger(previous) || previous < 0 || previous >= Number.MAX_SAFE_INTEGER) {
      throw new ApiError(ApiErrorCode.InternalServerError, "VIP card amount cannot be incremented safely.");
    }
    cardInventory.cardData[cardId] = { amount: previous + 1 };
  }

  return {
    state: {
      ...state,
      cardInventory,
      vipDailyCards: {
        lastGrantDay: dayKey,
        lastGrantedAt: now,
        lastRewardIds: [...cardIds],
      },
    },
    reward: { cardIds, dayKey },
  };
}

/** Grant at most one pair for the current UTC day to an already-active VIP account. */
export function grantDailyVipCardsState(
  state: PlayerProgressionState,
  now: number,
  choose: VipRandomIndex = randomInt,
): VipDailyCardResult {
  const result = applyDailyVipCards(state, now, choose);
  if (!result.reward) return result;
  return { ...result, state: { ...result.state, revision: state.revision + 1 } };
}

function discountedPrice(base: number, discount: number): number {
  // Positive integer prices use the same truncating arithmetic shown by BuyVIPDialog.
  return Math.floor((base * (100 - discount)) / 100);
}

/** Apply one source-backed VIP purchase without trusting any client price or duration. */
export function purchaseVipState(
  state: PlayerProgressionState,
  now: number,
  id: string,
  clientDiscount: number,
  authorizedDiscount = 0,
  choose: VipRandomIndex = randomInt,
): VipPurchaseResult {
  const product = VIP_CATALOG[id];
  if (!product) throw new ApiError(ApiErrorCode.UnknownAction, `VIP product ${id} is not available.`);
  if (
    !Number.isInteger(clientDiscount)
    || !Number.isInteger(authorizedDiscount)
    || authorizedDiscount < 0
    || authorizedDiscount > 99
    || clientDiscount !== authorizedDiscount
  ) {
    // The retired Fusebox service used special-offer types VIPFlat/VIPOne. Until those offer
    // definitions are recovered into a server allowlist, accepting a nonzero request value
    // would let a modified client invent its own discount.
    throw new ApiError(VIP_DISCOUNT_NOT_FOUND, "No matching server-issued VIP discount exists.");
  }

  const cost = discountedPrice(product.gold, authorizedDiscount);
  if (state.gold < cost) {
    throw new ApiError(VIP_NOT_ENOUGH_GOLD, "Not enough Gold for this VIP product.");
  }

  const currentExpiration = validatedVipExpiration(state.vipExpiration);
  // Renewals preserve every paid second: an active membership extends from its old deadline,
  // while an expired membership starts at the authoritative request time. vipStart is reset to
  // now so the membership dialog can display progress for the newly purchased interval.
  const vipExpiration = Math.max(now, currentExpiration) + product.seconds;
  if (!Number.isSafeInteger(vipExpiration)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "VIP expiration overflowed.");
  }
  const extendedState: PlayerProgressionState = {
    ...state,
    gold: state.gold - cost,
    vipStart: now,
    vipExpiration,
  };
  // A new purchase or renewal is also a valid delivery surface in the recovered callback.
  // Apply the daily pair inside this same state transition so a crash cannot persist the Gold
  // debit and entitlement while losing the cards (or grant cards without charging for VIP).
  const daily = applyDailyVipCards(extendedState, now, choose);
  return {
    state: { ...daily.state, revision: state.revision + 1 },
    product,
    cost,
    vipStart: now,
    vipExpiration,
    dailyCardReward: daily.reward,
  };
}

export function purchaseVip(
  playerId: string,
  id: string,
  clientDiscount: number,
): Promise<VipPurchaseResult> {
  return mutateProgression(playerId, (state, now) => (
    purchaseVipState(state, now, id, clientDiscount)
  ));
}

export function ensureDailyVipCards(playerId: string): Promise<VipDailyCardResult> {
  return mutateProgression(playerId, (state, now) => grantDailyVipCardsState(state, now));
}
