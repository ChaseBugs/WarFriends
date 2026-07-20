import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok, type ResponseEnvelope } from "../dtos";
import { progressionForPlayer } from "../services/playerStateService";
import { findById } from "../services/playerService";
import {
  VIP_CATALOG,
  VIP_DISCOUNT_NOT_FOUND,
  VIP_NOT_ENOUGH_GOLD,
  purchaseVip,
} from "../services/vipService";
import { authed, type HandlerEntry } from "./types";

function productId(value: unknown): string {
  if (typeof value !== "string" || !VIP_CATALOG[value]) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Id must name a recovered VIP product.");
  }
  return value;
}

function integer(value: unknown, field: string): number {
  const parsed = typeof value === "number" ? value : Number(value);
  if (!Number.isInteger(parsed)) throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an integer.`);
  return parsed;
}

function failure(
  action: DbAction,
  code: number,
  message: string,
  fields: Record<string, unknown>,
): ResponseEnvelope {
  // Action 114 has dedicated recovery branches that read these fields only after Result is the
  // exact IJEAJGCCHEF value. Code is retained for newer diagnostics, but Result is authoritative.
  return { DbAction: action, Result: code, Code: code, Message: message, ...fields };
}

export const vipHandlers: Record<number, HandlerEntry> = {
  [DbAction.BuyVip]: authed(async ({ player, req }) => {
    const id = productId(req.Id);
    const discount = integer(req.discount ?? 0, "discount");
    try {
      const result = await purchaseVip(player!.id, id, discount);
      return ok(DbAction.BuyVip, {
        Vip: result.vipExpiration,
        VipStart: result.vipStart,
        // GFGIJJMCPLO calls Wallet.OFHCEFPOCMI(Gold), so this is the amount spent rather than
        // the remaining balance. Returning the balance here would subtract it a second time.
        Gold: result.cost,
        Id: result.product.id,
      });
    } catch (error) {
      if (!(error instanceof ApiError)) throw error;
      // The optimistic mutation may have retried after another wallet write. Reload the
      // committed snapshot so recovery fields cannot restore the older auth-time balance.
      const current = await findById(player!.id);
      const state = progressionForPlayer(current ?? player!);
      if (error.code === VIP_NOT_ENOUGH_GOLD) {
        return failure(DbAction.BuyVip, error.code, error.message, {
          vipId: id,
          VIPCost: VIP_CATALOG[id]!.gold,
          PlayerGold: state.gold,
        });
      }
      if (error.code === VIP_DISCOUNT_NOT_FOUND) {
        return failure(DbAction.BuyVip, error.code, error.message, {
          Id: id,
          SpecialOffers: {},
        });
      }
      throw error;
    }
  }),

  [DbAction.OnVIPExpired]: authed(({ player }) => {
    // Expiration is a Unix deadline, so no client callback or scheduler is required to revoke
    // authority. Acknowledge the legacy telemetry action and return the persisted values; all
    // entitlement checks compare Vip against server time.
    const state = progressionForPlayer(player!);
    return ok(DbAction.OnVIPExpired, {
      Vip: state.vipExpiration ?? player!.player.vipExpiration,
      VipStart: state.vipStart,
    });
  }),
};
