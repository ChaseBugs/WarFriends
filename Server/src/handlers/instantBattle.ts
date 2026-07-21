import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { instantBattleWireResponse, playInstantBattle } from "../services/instantBattleService";
import { exactMatchInteger } from "./matchRequestParsing";
import { authed, type HandlerEntry } from "./types";

export function optionalInstantBattlePaidCost(value: unknown): number | undefined {
  // The free button sends no IsPaid field. The paid confirmation sends the local expected
  // Gold amount through `NKFGNDFKGHC.ToString()` after optimistically debiting the Unity wallet.
  // Only actual absence selects the free path: explicit null, blank, Boolean, array, padded,
  // signed, fractional, exponent, or oversized values must not become a free or paid request
  // through JavaScript coercion.
  if (value === undefined) return undefined;
  let parsed: number;
  try {
    parsed = exactMatchInteger(value, "IsPaid");
  } catch {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "IsPaid must contain a positive Gold price.");
  }
  if (parsed <= 0) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "IsPaid must contain a positive Gold price.");
  }
  return parsed;
}

export const instantBattleHandlers: Record<number, HandlerEntry> = {
  [DbAction.InstantBattle]: authed(async ({ player, req }) => {
    const result = await playInstantBattle(player!.id, optionalInstantBattlePaidCost(req.IsPaid));
    return ok(DbAction.InstantBattle, instantBattleWireResponse(result));
  }),
};
