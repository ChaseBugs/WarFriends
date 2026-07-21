import { randomInt } from "node:crypto";
import type { PlayerProgressionState, SavedVisualState } from "../db";
import { checkedRewardBalance } from "./rewardMathService";
import { VISUAL_CATALOG, visualInventoryStateFor } from "./visualInventoryService";

/** Source-decoded 4.9.5 `Constants.LootboxAfterBattles` value. */
export const VIP_LOOTBOX_MATCH_INTERVAL = 4;

/** `ID_VIP_BENEFITS2` says "2X LOOTBOX AFTER {0} BATTLE". */
export const VIP_LOOTBOX_REWARDS_PER_CYCLE = 2;

/** One ordinary suitcase represents one visual part in the recovered opening animation. */
export const VIP_LOOTBOX_PARTS_PER_REWARD = 1;

/**
 * Reconstructed normal-lootbox pool.
 *
 * The production service-side probability table was not shipped in either recovered APK,
 * so its rarity weights cannot be claimed as source truth. The narrowest usable pool that is
 * fully backed by the 4.9.5 client is every normal-shop visual with a positive PARTS target.
 * Event, Arena, assignment, loyalty, hidden, value-pack, and power-band rows are deliberately
 * excluded because each of those acquisition families has a separate entitlement contract.
 *
 * Until a retired server table is recovered, each concrete visual is selected uniformly.
 * This policy is explicit, deterministic from the generated catalog, and easy to replace
 * without changing the countdown, receipt, inventory, or wire contracts implemented here.
 */
export const VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS: readonly string[] = Object.freeze(
  Object.values(VISUAL_CATALOG)
    .filter((definition) => definition.purchasable === "shop" && definition.parts > 0)
    .map((definition) => definition.name)
    .sort(),
);

export interface VipLootboxVisualReward {
  visualId: string;
  parts: number;
  vip: true;
}

export interface VipLootboxTransition {
  state: PlayerProgressionState;
  matchesToNextLootboxes: number;
  rewards: VipLootboxVisualReward[];
  /** Exact JSON dictionary string consumed by IIGFODGJBFA.GameReward.NewVisuals. */
  newVisuals?: string;
  /** Overflow currency included in `state.warBucks`; retained separately for audit/tests. */
  duplicateWarBucks: number;
}

type PickIndex = (exclusiveMaximum: number) => number;

function emptySavedVisual(): SavedVisualState {
  return { bought: false, showed: false, expiresOn: 0, borrowed: false, parts: 0, notificate: false };
}

/**
 * Validate the exact source-defined paid-benefit countdown at the authority boundary.
 *
 * The stock client treats zero as an uninitialized value during boot and clamps its display
 * to a small positive range. The server must not repeat that presentation clamp: turning a
 * damaged zero, fraction, or oversized value into 1..4 either loses earned progress or creates
 * a reward schedule the durable state did not prove. Only an absent legacy field starts at four;
 * 1 means the next confirmed active-VIP battle grants the pair and 4 is a freshly reset cycle.
 */
export function validatedVipLootboxCountdown(value: number | undefined): number {
  if (value === undefined) return VIP_LOOTBOX_MATCH_INTERVAL;
  if (!Number.isSafeInteger(value) || value < 1 || value > VIP_LOOTBOX_MATCH_INTERVAL) {
    throw new Error("Stored VIP lootbox countdown is invalid.");
  }
  return value;
}

/**
 * Serialize duplicate visual IDs without losing either dictionary entry.
 *
 * Newtonsoft deserializes NewVisuals as Dictionary<string,string>, so two identical keys
 * cannot coexist. CCNAEIGGMNK.JHDGAACJEGH strips `_#...` and then the `-VIP` marker. The
 * marker must remain at the very end (`ID_#1-VIP`), otherwise the parser does not classify
 * a repeated reward as a VIP suitcase.
 */
export function serializeVipLootboxVisuals(rewards: readonly VipLootboxVisualReward[]): string | undefined {
  if (!rewards.length) return undefined;
  const occurrences = new Map<string, number>();
  const wire: Record<string, string> = {};
  for (const reward of rewards) {
    const occurrence = occurrences.get(reward.visualId) ?? 0;
    occurrences.set(reward.visualId, occurrence + 1);
    const duplicateSuffix = occurrence === 0 ? "" : `_#${occurrence}`;
    wire[`${reward.visualId}${duplicateSuffix}-VIP`] = String(reward.parts);
  }
  return JSON.stringify(wire);
}

function chooseVisualId(pickIndex: PickIndex): string {
  if (!VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.length) {
    throw new Error("VIP lootbox visual pool is empty.");
  }
  const index = pickIndex(VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.length);
  if (!Number.isInteger(index) || index < 0 || index >= VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.length) {
    throw new Error("VIP lootbox selector returned an out-of-range index.");
  }
  return VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS[index];
}

/**
 * Advance one participant's source-defined periodic VIP benefit.
 *
 * This is a pure state transition so matchService can place it inside the same MongoDB
 * transaction as XP, medals, card consumption, both player writes, and the terminal match
 * receipt. An inactive account keeps its existing validated countdown; it does not make
 * progress toward a paid benefit. At the threshold, two independent draws are performed,
 * which intentionally permits the same visual twice just like the recovered `_#` wire
 * convention.
 *
 * Parts and duplicate WarBucks are committed before GameEnded returns NewVisuals. The Unity
 * lootbox dialog updates its local cache while opening the animation and only queues a
 * notification acknowledgement afterward; treating that acknowledgement as the grant would
 * lose unopened rewards and allow response retries to double-credit the player.
 */
export function applyVipBattleLootboxState(
  state: PlayerProgressionState,
  isVip: boolean,
  pickIndex: PickIndex = (exclusiveMaximum) => randomInt(exclusiveMaximum),
): VipLootboxTransition {
  const current = validatedVipLootboxCountdown(state.matchesToNextLootboxes);
  if (!isVip) {
    return {
      state,
      matchesToNextLootboxes: current,
      rewards: [],
      duplicateWarBucks: 0,
    };
  }

  if (current > 1) {
    const matchesToNextLootboxes = current - 1;
    return {
      state: {
        ...state,
        revision: state.revision + 1,
        matchesToNextLootboxes,
      },
      matchesToNextLootboxes,
      rewards: [],
      duplicateWarBucks: 0,
    };
  }

  const selectedIds = Array.from(
    { length: VIP_LOOTBOX_REWARDS_PER_CYCLE },
    () => chooseVisualId(pickIndex),
  );
  const visualInventory = visualInventoryStateFor(state);
  let duplicateWarBucks = 0;

  // Apply in response order. If the first of two equal draws completes an item, the second
  // is a true duplicate and converts using that visual row's exact DUPLICATEWARBUCKS value.
  for (const visualId of selectedIds) {
    const definition = VISUAL_CATALOG[visualId];
    if (!definition || definition.parts <= 0) {
      throw new Error(`VIP lootbox selected invalid visual ${visualId}.`);
    }
    const saved = visualInventory.visuals[visualId] ?? emptySavedVisual();
    // visualInventoryStateFor already rejects non-integer/negative counts. Enforce the selected
    // catalog row's upper bound here as well: clamping an imported over-target value would make
    // an unproven item look owned and turn this paid benefit into duplicate WarBucks.
    const storedParts = saved.parts;
    if (storedParts > definition.parts) {
      throw new Error(`VIP lootbox visual ${visualId} parts are invalid.`);
    }
    const ownedBeforeReward = saved.bought || storedParts >= definition.parts;
    if (ownedBeforeReward) {
      if (duplicateWarBucks > Number.MAX_SAFE_INTEGER - definition.duplicateWarBucks) {
        throw new Error("VIP lootbox duplicate WarBucks overflowed.");
      }
      duplicateWarBucks += definition.duplicateWarBucks;
      visualInventory.visuals[visualId] = { ...saved, parts: storedParts };
      continue;
    }
    visualInventory.visuals[visualId] = {
      ...saved,
      parts: Math.min(definition.parts, storedParts + VIP_LOOTBOX_PARTS_PER_REWARD),
      // JHDGAACJEGH sets this flag when the visual was not already owned at parse time.
      // Persisting the same result keeps a later PlayerData refresh consistent with the UI.
      notificate: true,
    };
  }

  // This transition is part of the terminal match transaction. Compute the exact wallet first so
  // invalid persisted data rolls the match back instead of consuming the four-battle countdown.
  const warBucks = checkedRewardBalance(state.warBucks, duplicateWarBucks, "VIP lootbox WarBucks");
  const rewards: VipLootboxVisualReward[] = selectedIds.map((visualId) => ({
    visualId,
    parts: VIP_LOOTBOX_PARTS_PER_REWARD,
    vip: true,
  }));
  const matchesToNextLootboxes = VIP_LOOTBOX_MATCH_INTERVAL;
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      warBucks,
      visualInventory,
      matchesToNextLootboxes,
    },
    matchesToNextLootboxes,
    rewards,
    newVisuals: serializeVipLootboxVisuals(rewards),
    duplicateWarBucks,
  };
}
