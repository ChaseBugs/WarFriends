import { randomInt } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, SavedVisualState } from "../db";
import { VISUAL_CATALOG, visualInventoryStateFor } from "./visualInventoryService";
import { VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS } from "./vipLootboxService";

/** IJEAJGCCHEF values consumed by the stock BuyLootboxes error dispatcher. */
export const LOOTBOX_NOT_ENOUGH_GOLD = 11_404;
export const LOOTBOX_NO_DISCOUNT_FOUND = 13_601;

export interface LootboxProduct {
  id: string;
  gold: number;
  count: number;
}

/**
 * Exact 4.9.5 `GameVariables.lootboxes` rows recovered from MainScene.unity.
 *
 * The client sends only the row ID and a sale percentage. It does not send COUNT, and the
 * Gold value visible in the button is deliberately not accepted as authority. Keeping both
 * values here prevents a modified client from buying the 150-reward product for the price of
 * the five-reward product or from selecting an arbitrary reward count.
 */
export const LOOTBOX_CATALOG: Readonly<Record<string, Readonly<LootboxProduct>>> = Object.freeze({
  lootboxes1: Object.freeze({ id: "lootboxes1", gold: 49, count: 5 }),
  lootboxes2: Object.freeze({ id: "lootboxes2", gold: 89, count: 10 }),
  lootboxes3: Object.freeze({ id: "lootboxes3", gold: 159, count: 20 }),
  lootboxes4: Object.freeze({ id: "lootboxes4", gold: 279, count: 40 }),
  lootboxes5: Object.freeze({ id: "lootboxes5", gold: 479, count: 80 }),
  lootboxes6: Object.freeze({ id: "lootboxes6", gold: 749, count: 150 }),
});

export interface PurchasedLootboxReward {
  visualId: string;
  parts: 1;
}

export interface LootboxPurchaseTransition {
  state: PlayerProgressionState;
  product: Readonly<LootboxProduct>;
  rewards: PurchasedLootboxReward[];
  /** Exact JSON dictionary string parsed by OGLEHLIPEFM.IFAOHFKDHFA. */
  newVisuals: string;
  /** Duplicate conversion included in state.warBucks and exposed for audits/tests. */
  duplicateWarBucks: number;
}

type PickIndex = (exclusiveMaximum: number) => number;

function emptySavedVisual(): SavedVisualState {
  return { bought: false, showed: false, expiresOn: 0, borrowed: false, parts: 0, notificate: false };
}

/**
 * Preserve repeated draws in a JSON dictionary.
 *
 * Newtonsoft cannot deserialize duplicate object keys. The recovered client therefore strips
 * `_#...` before looking up the visual. Suffixing only the second and later occurrences keeps
 * every suitcase in response order while still resolving all of them to the original ID.
 */
export function serializePurchasedLootboxVisuals(
  rewards: readonly PurchasedLootboxReward[],
): string {
  const occurrences = new Map<string, number>();
  const wire: Record<string, string> = {};
  for (const reward of rewards) {
    const occurrence = occurrences.get(reward.visualId) ?? 0;
    occurrences.set(reward.visualId, occurrence + 1);
    const duplicateSuffix = occurrence === 0 ? "" : `_#${occurrence}`;
    wire[`${reward.visualId}${duplicateSuffix}`] = String(reward.parts);
  }
  return JSON.stringify(wire);
}

function selectVisualId(pickIndex: PickIndex): string {
  // The retired backend's rarity/visual probability table is absent from both recovered APKs.
  // Use the same documented normal-shop part pool as periodic VIP suitcases. Selection is
  // uniform until that server table is recovered; event, Arena, hidden, and paid-only visuals
  // remain excluded because a generic Gold lootbox is not authority for those entitlements.
  const pool = VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS;
  if (!pool.length) throw new Error("Purchasable lootbox visual pool is empty.");
  const index = pickIndex(pool.length);
  if (!Number.isInteger(index) || index < 0 || index >= pool.length) {
    throw new Error("Purchasable lootbox selector returned an out-of-range index.");
  }
  return pool[index]!;
}

/**
 * Atomically debit Gold and grant all visual-part suitcases in one progression transition.
 *
 * The response animation applies the same parts locally, but the animation is not the grant:
 * a player can close the game before opening every suitcase. Persisting the full result first
 * makes the later PlayerData refresh authoritative. Once a visual already owns all required
 * parts, each further part converts to that row's exact DUPLICATEWARBUCKS value. The part that
 * completes a visual is not an overflow; this matches PlayerVisual.EGMDJMMIOED.
 */
export function purchaseLootboxesState(
  state: PlayerProgressionState,
  id: string,
  clientDiscount: number,
  pickIndex: PickIndex = (exclusiveMaximum) => randomInt(exclusiveMaximum),
): LootboxPurchaseTransition {
  const product = LOOTBOX_CATALOG[id];
  if (!product) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Id must name a recovered lootbox product.");
  }
  if (!Number.isInteger(clientDiscount) || clientDiscount < 0 || clientDiscount > 99) {
    throw new ApiError(ApiErrorCode.UnknownAction, "discount must be an integer from 0 to 99.");
  }
  if (clientDiscount !== 0) {
    // OfferManager can display sales, but no authoritative sale receipt/table survives in the
    // recovered clients. Trusting this client echo would allow any caller to choose its price.
    throw new ApiError(
      LOOTBOX_NO_DISCOUNT_FOUND,
      "No matching server-issued lootbox discount exists.",
      { Id: product.id, SpecialOffers: {} },
    );
  }
  if (state.gold < product.gold) {
    throw new ApiError(
      LOOTBOX_NOT_ENOUGH_GOLD,
      "Not enough Gold for this lootbox product.",
      {
        lootboxId: product.id,
        LootboxesCost: product.gold,
        PlayerGold: state.gold,
      },
    );
  }

  // Select every reward inside the pure transition. If optimistic concurrency loses its write,
  // mutateProgression reruns the entire transition against the winner's current inventory and
  // wallet; no abandoned selection has been exposed or partially granted.
  const selectedIds = Array.from({ length: product.count }, () => selectVisualId(pickIndex));
  const visualInventory = visualInventoryStateFor(state);
  let duplicateWarBucks = 0;

  for (const visualId of selectedIds) {
    const definition = VISUAL_CATALOG[visualId];
    if (!definition || definition.parts <= 0) {
      throw new Error(`Purchasable lootbox selected invalid visual ${visualId}.`);
    }
    const saved = visualInventory.visuals[visualId] ?? emptySavedVisual();
    const storedParts = Number.isFinite(saved.parts)
      ? Math.max(0, Math.min(definition.parts, Math.floor(saved.parts)))
      : 0;
    const ownedBeforeReward = saved.bought || storedParts >= definition.parts;

    if (ownedBeforeReward) {
      if (duplicateWarBucks > Number.MAX_SAFE_INTEGER - definition.duplicateWarBucks) {
        throw new Error("Purchasable lootbox duplicate WarBucks overflowed.");
      }
      duplicateWarBucks += definition.duplicateWarBucks;
      visualInventory.visuals[visualId] = { ...saved, parts: storedParts };
      continue;
    }

    visualInventory.visuals[visualId] = {
      ...saved,
      parts: Math.min(definition.parts, storedParts + 1),
      // JHDGAACJEGH marks unseen, unowned results for the customization notification badge.
      notificate: true,
    };
  }

  if (state.warBucks > Number.MAX_SAFE_INTEGER - duplicateWarBucks) {
    throw new Error("Purchasable lootbox WarBucks balance overflowed.");
  }
  const rewards: PurchasedLootboxReward[] = selectedIds.map((visualId) => ({ visualId, parts: 1 }));
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold: state.gold - product.gold,
      warBucks: state.warBucks + duplicateWarBucks,
      visualInventory,
    },
    product,
    rewards,
    newVisuals: serializePurchasedLootboxVisuals(rewards),
    duplicateWarBucks,
  };
}
