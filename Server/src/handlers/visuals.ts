import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  equipVisualState,
  markVisualShownState,
  parseVisualPurchaseData,
  purchaseVisualState,
  serializeVisualInventory,
} from "../services/visualInventoryService";
import { mutateProgression } from "../services/progressionMutationService";
import {
  requestedDirectVisualName,
  requestedDirectVisualPurchase,
} from "./inventoryRequestParsing";
import { authed, type HandlerEntry } from "./types";

/**
 * Direct routes retained for old/diagnostic client paths.
 *
 * The stock customization screen normally queues these actions in SendRequestBuffer. Both
 * paths call the same progression transitions, so direct calls cannot bypass catalog, wallet,
 * ownership, expiry, VIP, or optimistic-concurrency checks.
 */
export const visualHandlers: Record<number, HandlerEntry> = {
  [DbAction.BuyDecal]: authed(async ({ player, req }) => {
    const raw = requestedDirectVisualPurchase(req);
    const payload = parseVisualPurchaseData(raw);
    const result = await mutateProgression(player!.id, (state, now) =>
      // Read VIP from the same optimistic progression snapshot as the Gold debit. A purchase
      // arriving beside BuyVip must either observe the committed entitlement or retry against
      // it; the stale authentication document must not decide access to a VIP-only visual.
      purchaseVisualState(
        state,
        now,
        player!.player.level,
        state.vipExpiration ?? player!.player.vipExpiration,
        payload,
      ));
    return ok(DbAction.BuyDecal, {
      DecalId: result.definition.name,
      ExpiresOn: result.expiresOn,
      GoldBalance: result.state.gold,
      WarBucksBalance: result.state.warBucks,
      DecalManagerData: serializeVisualInventory(result.visualInventory),
    });
  }),

  [DbAction.EquipDecal]: authed(async ({ player, req }) => {
    const name = requestedDirectVisualName(req);
    const result = await mutateProgression(player!.id, (state, now) => equipVisualState(state, now, name));
    return ok(DbAction.EquipDecal, {
      DecalManagerData: serializeVisualInventory(result.visualInventory),
    });
  }),

  [DbAction.DecalWasShown]: authed(async ({ player, req }) => {
    // The only recovered direct action-108 builder carries unrelated impression fields, while
    // current visual notification acknowledgement is buffered action 191. Do not reinterpret a
    // diagnostic DecalId/Name/Data property as visual authority on this ambiguous legacy route.
    void player;
    void req;
    return ok(DbAction.DecalWasShown, { Ignored: true });
  }),

  [DbAction.VisualWasShown]: authed(async ({ player, req }) => {
    const name = requestedDirectVisualName(req);
    const result = await mutateProgression(player!.id, (state) => markVisualShownState(state, name));
    return ok(DbAction.VisualWasShown, {
      DecalManagerData: serializeVisualInventory(result.visualInventory),
    });
  }),
};
