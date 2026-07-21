import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { purchaseLootboxesState } from "../services/lootboxPurchaseService";
import { mutateProgression } from "../services/progressionMutationService";
import { authed, type HandlerEntry } from "./types";
import { exactPurchaseDiscount } from "./purchaseRequestParsing";

function productId(value: unknown): string {
  if (typeof value !== "string" || value.length < 1 || value.length > 64) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Lootbox Id is invalid.");
  }
  return value;
}

export const lootboxHandlers: Record<number, HandlerEntry> = {
  [DbAction.BuyLootboxes]: authed(async ({ player, req }) => {
    // BeanstalkServerManager.FCCLNIOHOPK sends exactly `Id` and lower-case `discount`.
    // The server derives price, reward count, eligible pool, parts, and duplicate conversion.
    const id = productId(req.Id);
    const discount = exactPurchaseDiscount(req.discount);
    const result = await mutateProgression(
      player!.id,
      (state) => purchaseLootboxesState(state, id, discount),
    );
    return ok(DbAction.BuyLootboxes, {
      // IFAOHFKDHFA parses this string as Dictionary<string,string> and opens one dialog entry
      // per key. It then subtracts LootboxCost locally, so return amount spent, not balance.
      NewVisuals: result.newVisuals,
      Id: result.product.id,
      LootboxCost: result.product.gold,
      GoldBalance: result.state.gold,
      WarBucksBalance: result.state.warBucks,
    });
  }),
};
