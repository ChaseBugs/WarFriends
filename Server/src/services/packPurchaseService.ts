import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, PurchaseReversibleGrant, SavedVisualState } from "../db";
import { cardInventoryStateFor } from "./cardInventoryService";
import type { PackEntitlement } from "./inAppCatalogService";
import { itemInventoryStateFor, WEAPON_CATALOG } from "./itemInventoryService";
import { VISUAL_CATALOG, visualInventoryStateFor } from "./visualInventoryService";
import { validatedVipExpiration } from "./vipEntitlementService";

function checkedAmount(current: number, amount: number, field: string): number {
  const next = current + amount;
  if (!Number.isSafeInteger(next)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} balance overflow.`);
  }
  return next;
}

function checkedDeadline(base: number, duration: number, field: string): number {
  const deadline = base + duration;
  if (!Number.isSafeInteger(deadline) || deadline < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} deadline overflow.`);
  }
  return deadline;
}

function emptyVisual(): SavedVisualState {
  return { bought: false, showed: false, expiresOn: 0, borrowed: false, parts: 0, notificate: false };
}

/**
 * Apply every benefit of one reviewed Packs-sheet row in one progression revision.
 *
 * This helper deliberately has no concept of Google tokens or MongoDB. purchaseService first
 * proves the token and then calls this function inside the same transaction that inserts the
 * global receipt. Consequently a retry either observes the old receipt and grants nothing, or
 * commits the complete wallet/VIP/inventory bundle; a partially delivered paid pack is not a
 * representable database state.
 */
export function applyPackEntitlementState(
  state: PlayerProgressionState,
  entitlement: PackEntitlement,
  now: number,
): { state: PlayerProgressionState; reversibleGrant: PurchaseReversibleGrant } {
  if (!Number.isSafeInteger(now) || now <= 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Pack delivery time is invalid.");
  }

  const itemInventory = itemInventoryStateFor(state);
  const visualInventory = visualInventoryStateFor(state);
  const cardInventory = cardInventoryStateFor(state);
  const reversibleGrant: PurchaseReversibleGrant = {
    gold: entitlement.gold,
    warBucks: entitlement.warBucks,
    vipSeconds: entitlement.vipSeconds,
    weapons: [],
    visuals: [],
    extraCardSlot: entitlement.extraCardSlot,
    introducedExtraCardSlot: entitlement.extraCardSlot && !cardInventory.extraSlot,
  };

  for (const weaponName of entitlement.weapons) {
    // A paid entitlement may reference only a concrete recovered normal-shop runtime object.
    // Missing rows fail before any state is persisted, which avoids charging for a weapon the
    // reconstructed client cannot instantiate. Existing permanent ownership is naturally kept.
    if (!WEAPON_CATALOG[weaponName]) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Pack weapon is absent from the recovered catalog.");
    }
    const current = itemInventory.levelManagerData.savedWeapons[weaponName];
    reversibleGrant.weapons.push({ name: weaponName, introduced: !current?.bought || Boolean(current.borrowed) });
    itemInventory.levelManagerData.savedWeapons[weaponName] = {
      ...(current ?? {
        bought: false,
        boughtIndex: 0,
        showed: false,
        borrowed: false,
        specialFeature: 0,
      }),
      bought: true,
      borrowed: false,
      showed: true,
    };
  }

  for (const visualGrant of entitlement.visuals) {
    if (!VISUAL_CATALOG[visualGrant.name]) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Pack visual is absent from the recovered catalog.");
    }
    const current = visualInventory.visuals[visualGrant.name] ?? emptyVisual();
    reversibleGrant.visuals.push({
      name: visualGrant.name,
      durationSeconds: visualGrant.durationSeconds,
      introduced: !current.bought || Boolean(current.borrowed),
    });
    if (visualGrant.durationSeconds === 0) {
      // Permanent ownership supersedes an expired, borrowed, or previously timed instance.
      visualInventory.visuals[visualGrant.name] = {
        ...current,
        bought: true,
        borrowed: false,
        expiresOn: 0,
        notificate: true,
      };
    } else {
      // Re-buying a timed pack extends remaining paid time instead of throwing it away. A stale
      // or missing instance starts from authoritative server time, never a client timestamp.
      const activeBase = current.bought && current.expiresOn > now ? current.expiresOn : now;
      visualInventory.visuals[visualGrant.name] = {
        ...current,
        bought: true,
        borrowed: false,
        expiresOn: checkedDeadline(activeBase, visualGrant.durationSeconds, "Pack visual"),
        notificate: true,
      };
    }
  }

  const currentVipExpiration = validatedVipExpiration(state.vipExpiration);
  const vipExpiration = entitlement.vipSeconds > 0
    ? checkedDeadline(Math.max(now, currentVipExpiration), entitlement.vipSeconds, "VIP")
    : currentVipExpiration;
  const vipWasActive = currentVipExpiration > now;

  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold: checkedAmount(state.gold, entitlement.gold, "Gold"),
      warBucks: checkedAmount(state.warBucks, entitlement.warBucks, "WarBucks"),
      // Preserve the beginning of a still-active membership. The stock client uses VipStart for
      // analytics; replacing it on every extension would make one uninterrupted term look new.
      vipStart: entitlement.vipSeconds > 0 && !vipWasActive ? now : state.vipStart,
      vipExpiration,
      itemInventory,
      visualInventory,
      cardInventory: entitlement.extraCardSlot
        ? { ...cardInventory, extraSlot: true }
        : cardInventory,
    },
    reversibleGrant,
  };
}
