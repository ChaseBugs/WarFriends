import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { instantBattleWireResponse, playInstantBattle } from "../services/instantBattleService";
import { authed, type HandlerEntry } from "./types";

function optionalPaidCost(value: unknown): number | undefined {
  // The free button sends no IsPaid field. The paid confirmation sends the local expected
  // Gold amount as a decimal string after optimistically debiting the Unity wallet. Presence,
  // not truthiness, distinguishes those paths; zero is therefore rejected rather than treated
  // as a free request that could consume a natural batch.
  if (value === undefined || value === null || value === "") return undefined;
  const parsed = Number(value);
  if (!Number.isSafeInteger(parsed) || parsed <= 0) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "IsPaid must contain a positive Gold price.");
  }
  return parsed;
}

export const instantBattleHandlers: Record<number, HandlerEntry> = {
  [DbAction.InstantBattle]: authed(async ({ player, req }) => {
    const result = await playInstantBattle(player!.id, optionalPaidCost(req.IsPaid));
    return ok(DbAction.InstantBattle, instantBattleWireResponse(result));
  }),
};
