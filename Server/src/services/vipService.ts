import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";
import { mutateProgression } from "./progressionMutationService";

/** IJEAJGCCHEF values handled by the stock BuyVip failure parser. */
export const VIP_NOT_ENOUGH_GOLD = 11_401;
export const VIP_DISCOUNT_NOT_FOUND = 13_601;

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

  const currentExpiration = Math.max(0, Math.floor(state.vipExpiration ?? 0));
  // Renewals preserve every paid second: an active membership extends from its old deadline,
  // while an expired membership starts at the authoritative request time. vipStart is reset to
  // now so the membership dialog can display progress for the newly purchased interval.
  const vipExpiration = Math.max(now, currentExpiration) + product.seconds;
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold: state.gold - cost,
      vipStart: now,
      vipExpiration,
    },
    product,
    cost,
    vipStart: now,
    vipExpiration,
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
