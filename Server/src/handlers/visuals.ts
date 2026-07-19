import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  equipVisualState,
  markVisualShownState,
  parseVisualPurchaseData,
  purchaseVisualState,
  serializeVisualInventory,
  VISUAL_CATALOG,
} from "../services/visualInventoryService";
import { mutateProgression } from "../services/progressionMutationService";
import { authed, type HandlerEntry } from "./types";

function visualName(value: unknown): string {
  if (typeof value !== "string" || value.length < 1 || value.length > 128) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Visual name is invalid.");
  }
  return value;
}

/**
 * Direct routes retained for old/diagnostic client paths.
 *
 * The stock customization screen normally queues these actions in SendRequestBuffer. Both
 * paths call the same progression transitions, so direct calls cannot bypass catalog, wallet,
 * ownership, expiry, VIP, or optimistic-concurrency checks.
 */
export const visualHandlers: Record<number, HandlerEntry> = {
  [DbAction.BuyDecal]: authed(async ({ player, req }) => {
    const raw = req.ObjData ?? req.Data ?? req.data;
    if (typeof raw !== "string") throw new ApiError(ApiErrorCode.UnknownAction, "Visual purchase data is missing.");
    const payload = parseVisualPurchaseData(raw);
    const result = await mutateProgression(player!.id, (state, now) =>
      purchaseVisualState(state, now, player!.player.level, player!.player.vipExpiration, payload));
    return ok(DbAction.BuyDecal, {
      DecalId: result.definition.name,
      ExpiresOn: result.expiresOn,
      GoldBalance: result.state.gold,
      WarBucksBalance: result.state.warBucks,
      DecalManagerData: serializeVisualInventory(result.visualInventory),
    });
  }),

  [DbAction.EquipDecal]: authed(async ({ player, req }) => {
    const name = visualName(req.DecalId ?? req.Name ?? req.Data ?? req.data);
    const result = await mutateProgression(player!.id, (state, now) => equipVisualState(state, now, name));
    return ok(DbAction.EquipDecal, {
      DecalManagerData: serializeVisualInventory(result.visualInventory),
    });
  }),

  [DbAction.DecalWasShown]: authed(async ({ player, req }) => {
    const candidate = req.DecalId ?? req.Name ?? req.Data ?? req.data;
    if (typeof candidate !== "string" || !VISUAL_CATALOG[candidate]) {
      // Action 108 is a legacy impression route. Some recovered call sites do not contain a
      // visual ID, so accepting those as telemetry preserves compatibility without mutating
      // ownership, notification state, expiry, or equipment.
      return ok(DbAction.DecalWasShown, { Ignored: true });
    }
    const name = visualName(candidate);
    const result = await mutateProgression(player!.id, (state) => markVisualShownState(state, name));
    return ok(DbAction.DecalWasShown, {
      DecalManagerData: serializeVisualInventory(result.visualInventory),
    });
  }),

  [DbAction.VisualWasShown]: authed(async ({ player, req }) => {
    const name = visualName(req.DecalId ?? req.Name ?? req.Data ?? req.data);
    const result = await mutateProgression(player!.id, (state) => markVisualShownState(state, name));
    return ok(DbAction.VisualWasShown, {
      DecalManagerData: serializeVisualInventory(result.visualInventory),
    });
  }),
};
