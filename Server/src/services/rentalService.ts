import { createHash } from "node:crypto";
import { ApiError } from "../apiErrors";
import { DbAction } from "../dbActions";
import type {
  PlayerProgressionState,
  RentalItemType,
  RentalOfferState,
  SavedArmyState,
  SavedWeaponState,
} from "../db";
import {
  ITEM_NOT_ENOUGH_GOLD,
  ITEM_NOT_ENOUGH_WARBUCKS,
  WEAPON_CATALOG,
  itemInventoryStateFor,
  weaponDefinitionFor,
} from "./itemInventoryService";
import { mutateProgression } from "./progressionMutationService";
import { UNIT_CATALOG } from "./unitInventoryService";
import {
  hasActiveRentalItem,
  validatedRentalState,
  validatedRentalUnixSeconds,
} from "./rentalEntitlementService";

/** IJEAJGCCHEF.NoRentalFound, handled explicitly by action 138's nested parser. */
export const RENTAL_NOT_FOUND = 13_602;

/**
 * 4.9.5 MainScene Constants, decoded from CodeStage ObscuredFloat values.
 *
 * `ServerRentalSaleMin/Max` are 20/25. `ServerRentalVisualProbability`,
 * `ServerRentalWeaponProbability`, and `ServerRentalUnitProbability` are 0/2/7, so the
 * recovered release intentionally issues only weapons and units. `ServerRentalRentDuration`
 * is 0.5 day and `ServerRentalOfferDuration` is 1 day. The old production service that
 * selected an exact item is unavailable; the deterministic candidate rule below is the
 * documented reconstruction boundary, while all price, duration, and wire values are source
 * backed.
 */
export const RENTAL_SALE_MIN_PERCENT = 20;
export const RENTAL_SALE_MAX_PERCENT = 25;
export const RENTAL_TRIAL_SECONDS = 12 * 60 * 60;
export const RENTAL_OFFER_SECONDS = 24 * 60 * 60;
export const RENTAL_MIN_PLAYER_LEVEL_INDEX = 3; // zero-based LevelManager level: display rank 4

const RENTAL_WEAPON_WEIGHT = 2;
const RENTAL_UNIT_WEIGHT = 7;
const RENTAL_LOCKED_LEVEL_WINDOW = 3;
const WEAPON_SLOT_MASKS = [263, 1064, 592, 128] as const;

export interface RentalWireOffer {
  Id: string;
  Amount: string;
  Type: RentalItemType;
  nextGenerate: string;
  accepted?: number;
}

export interface RentalMutationResult {
  state: PlayerProgressionState;
  rental?: RentalOfferState;
  bootOffer?: RentalWireOffer;
  saleOffer?: RentalWireOffer;
}

export interface RentalAcceptanceResult extends RentalMutationResult {
  /** Action parsed from the outer action-138 RequestsResults array. */
  resultAction: DbAction;
  resultFields: Record<string, unknown>;
  replayed: boolean;
}

function stableBytes(...parts: Array<string | number>): Buffer {
  return createHash("sha256").update(parts.join(":"), "utf8").digest();
}

function positivePrice(value: { gold: number; warBucks: number }): boolean {
  return value.gold > 0 || value.warBucks > 0;
}

/** Match the positive Mathf.RoundToInt boundary used by RentalDialog's sale calculation. */
export function rentalDiscountedPrice(basePrice: number, discount: number): number {
  const percentage = Math.fround(Math.fround(basePrice * (100 - discount)) / Math.fround(100));
  return Math.floor(Math.fround(percentage + Math.fround(0.5)));
}

function bootWire(rental: RentalOfferState): RentalWireOffer {
  return {
    Id: rental.id,
    Amount: String(rental.discount),
    Type: rental.type,
    nextGenerate: String(rental.nextGenerate),
  };
}

function saleWire(rental: RentalOfferState): RentalWireOffer {
  return {
    ...bootWire(rental),
    // AINIEKCODDE.Tryed. GALPKPPCFJN logs this value and opens the discounted variant.
    accepted: 3,
  };
}

/** Public predicate shared by inventory/equipment/Army Power validation. */
export function isActiveRentalItem(
  state: PlayerProgressionState,
  type: RentalItemType,
  id: string,
  now: number,
): boolean {
  return hasActiveRentalItem(state, type, id, now);
}

function capturedWeaponSlot(state: PlayerProgressionState, weaponId: string) {
  const definition = weaponDefinitionFor(weaponId);
  if (!definition) return undefined;
  const inventory = itemInventoryStateFor(state);
  const slotIndex = WEAPON_SLOT_MASKS.findIndex((mask) => (mask & definition.category) === definition.category);
  if (slotIndex < 0) return undefined;
  const slot = inventory.inventoryData.slots[String(slotIndex)];
  return slot ? { slotIndex, ...slot } : undefined;
}

/** Remove temporary authority and restore the weapon slot that the trial replaced. */
function clearBorrowedItem(state: PlayerProgressionState, rental: RentalOfferState): PlayerProgressionState {
  const itemInventory = itemInventoryStateFor(state);
  if (rental.type === 1) {
    const saved = itemInventory.levelManagerData.savedWeapons[rental.id];
    if (saved?.borrowed) delete itemInventory.levelManagerData.savedWeapons[rental.id];
    for (const [slotKey, slot] of Object.entries(itemInventory.inventoryData.slots)) {
      if (slot.name !== rental.id) continue;
      const previous = rental.previousWeaponSlot;
      if (previous && String(previous.slotIndex) === slotKey) {
        itemInventory.inventoryData.slots[slotKey] = {
          name: previous.name,
          weaponIndex: previous.weaponIndex,
        };
      }
    }
  } else if (rental.type === 0) {
    const saved = itemInventory.levelManagerData.savedArmies[rental.id];
    if (saved?.borrowed) delete itemInventory.levelManagerData.savedArmies[rental.id];
  }
  return { ...state, itemInventory };
}

function candidateWindow<T extends { canBuyLevelIndex: number }>(rows: T[], playerLevel: number): T[] {
  const nearby = rows.filter((row) => row.canBuyLevelIndex <= playerLevel + RENTAL_LOCKED_LEVEL_WINDOW);
  return nearby.length > 0 ? nearby : rows;
}

function selectRental(
  state: PlayerProgressionState,
  playerId: string,
  playerLevel: number,
  generation: number,
): { id: string; type: RentalItemType; discount: number } | undefined {
  const savedWeapons = state.itemInventory?.levelManagerData.savedWeapons ?? {};
  const savedArmies = state.itemInventory?.levelManagerData.savedArmies ?? {};
  const weapons = candidateWindow(
    Object.values(WEAPON_CATALOG).filter((row) => (
      !row.starterOwned && positivePrice(row) && !savedWeapons[row.name]?.bought
    )),
    playerLevel,
  );
  const units = candidateWindow(
    Object.values(UNIT_CATALOG).filter((row) => positivePrice(row) && !savedArmies[row.name]?.bought),
    playerLevel,
  );
  if (weapons.length === 0 && units.length === 0) return undefined;

  const seed = stableBytes(playerId, generation, Math.floor(playerLevel));
  const familyRoll = seed[0]! % (RENTAL_WEAPON_WEIGHT + RENTAL_UNIT_WEIGHT);
  const preferWeapon = familyRoll < RENTAL_WEAPON_WEIGHT;
  const family = preferWeapon
    ? (weapons.length > 0 ? weapons : units)
    : (units.length > 0 ? units : weapons);
  const type: RentalItemType = family === weapons ? 1 : 0;
  const ordered = family
    .map((row) => ({ row, key: stableBytes(playerId, generation, row.name).toString("hex") }))
    .sort((left, right) => left.key.localeCompare(right.key));
  const discountRange = RENTAL_SALE_MAX_PERCENT - RENTAL_SALE_MIN_PERCENT + 1;
  return {
    id: ordered[0]!.row.name,
    type,
    discount: RENTAL_SALE_MIN_PERCENT + (seed[1]! % discountRange),
  };
}

/**
 * Pure GetPlayerData transition.
 *
 * Only the initial `offered` state is exposed on boot because EGPLNLMMADN always opens that
 * object as the free-trial RentalDialog. A trial or sale must never be returned through this
 * parser: doing so would incorrectly turn a discounted purchase back into another free try.
 */
export function ensureRentalOfferState(
  state: PlayerProgressionState,
  playerId: string,
  playerLevel: number,
  now: number,
): RentalMutationResult {
  const currentTime = validatedRentalUnixSeconds(now, "Rental offer time");
  const current = validatedRentalState(state.rental);
  if (!state.tutorialFinished) {
    // The recovered rental gate explicitly requires both level 4 and a finished tutorial.
    // GetPlayerData must not issue a valuable free trial to an unfinished account even if a
    // modified/debug client has raised its visible level. Remove any legacy borrowed row too.
    if (!current) return { state };
    const cleared = clearBorrowedItem(state, current);
    const { rental: _rental, ...withoutRental } = cleared;
    return { state: { ...withoutRental, revision: state.revision + 1 } };
  }
  let working = state;
  let previousGeneration = current?.generation ?? 0;
  if (current) {
    // The trial can end before the source-backed 24-hour generation deadline. Remove its
    // borrowed inventory immediately, but preserve a private cooldown record so relogging at
    // hour 12 cannot force a second daily offer.
    if (
      current.status === "trial"
      && current.trialExpiresAt <= currentTime
      && current.nextGenerate > currentTime
    ) {
      const cleared = clearBorrowedItem(state, current);
      const cooldown = validatedRentalState({
        ...current,
        status: "cooldown",
        trialExpiresAt: 0,
      })!;
      return {
        state: { ...cleared, revision: state.revision + 1, rental: cooldown },
        rental: cooldown,
      };
    }
    const deadline = current.status === "trial"
      ? current.trialExpiresAt
      : current.status === "sale"
        ? current.saleExpiresAt
        : current.nextGenerate;
    if (deadline > currentTime) {
      return {
        // GetPlayerData may run repeatedly during reconnect. Projection of the same live offer
        // is a read, so preserve state identity and avoid turning every boot into a write.
        state,
        rental: current,
        ...(current.status === "offered" ? { bootOffer: bootWire(current) } : {}),
      };
    }
    working = clearBorrowedItem(state, current);
  }

  if (Math.floor(playerLevel) < RENTAL_MIN_PLAYER_LEVEL_INDEX) {
    if (!current) return { state };
    const { rental: _expired, ...withoutRental } = working;
    return { state: { ...withoutRental, revision: state.revision + 1 } };
  }

  const generation = previousGeneration + 1;
  const selected = selectRental(working, playerId, playerLevel, generation);
  if (!selected) {
    if (!current) return { state };
    const { rental: _expired, ...withoutRental } = working;
    return { state: { ...withoutRental, revision: state.revision + 1 } };
  }
  const rental = validatedRentalState({
    id: selected.id,
    type: selected.type,
    discount: selected.discount,
    status: "offered",
    generation,
    nextGenerate: currentTime + RENTAL_OFFER_SECONDS,
    trialExpiresAt: 0,
    saleExpiresAt: 0,
  })!;
  return {
    state: { ...working, revision: state.revision + 1, rental },
    rental,
    bootOffer: bootWire(rental),
  };
}

function borrowedWeapon(): SavedWeaponState {
  return { bought: true, boughtIndex: 0, showed: true, borrowed: true, specialFeature: 0 };
}

function unitState(type: "borrowed" | "owned", id: string): SavedArmyState {
  const definition = UNIT_CATALOG[id]!;
  return {
    bought: true,
    boughtIndex: 0,
    specialSlot: 0,
    showed: true,
    tier: definition.startingTier,
    borrowed: type === "borrowed",
    wasEquipped: false,
    equipped: false,
    eliteSlot: 0,
    parts: 0,
  };
}

function successfulPurchaseAction(type: RentalItemType): DbAction {
  return type === 1 ? DbAction.BuyWeapon : type === 0 ? DbAction.BuyUnit : DbAction.BuyDecal;
}

/** Apply action 138 using only the persisted item/discount authority. */
export function acceptRentalOfferState(
  state: PlayerProgressionState,
  buyRentalDiscounted: boolean,
  now: number,
): RentalAcceptanceResult {
  const currentTime = validatedRentalUnixSeconds(now, "Rental acceptance time");
  const rental = validatedRentalState(state.rental);
  if (!rental) throw new ApiError(RENTAL_NOT_FOUND, "No server-issued rental exists.");

  if (!buyRentalDiscounted) {
    if (rental.status === "trial" && rental.trialExpiresAt > currentTime) {
      return {
        // Action 138 may be retried after Unity loses the response. The borrowed item and
        // trial deadline already exist, so return the exact input progression and let
        // mutateProgression skip an unnecessary MongoDB replacement.
        state,
        rental,
        resultAction: DbAction.AcceptRentalOffer,
        resultFields: { Rental: bootWire(rental) },
        replayed: true,
      };
    }
    if (rental.status !== "offered" || rental.nextGenerate <= currentTime) {
      throw new ApiError(RENTAL_NOT_FOUND, "The free rental offer is no longer active.");
    }
    const itemInventory = itemInventoryStateFor(state);
    const nextRental = validatedRentalState({
      ...rental,
      status: "trial",
      trialExpiresAt: currentTime + RENTAL_TRIAL_SECONDS,
      saleExpiresAt: 0,
      nextGenerate: Math.max(rental.nextGenerate, currentTime + RENTAL_OFFER_SECONDS),
      ...(rental.type === 1 ? { previousWeaponSlot: capturedWeaponSlot(state, rental.id) } : {}),
    })!;
    if (rental.type === 1 && WEAPON_CATALOG[rental.id]) {
      itemInventory.levelManagerData.savedWeapons[rental.id] = borrowedWeapon();
    } else if (rental.type === 0 && UNIT_CATALOG[rental.id]) {
      itemInventory.levelManagerData.savedArmies[rental.id] = unitState("borrowed", rental.id);
    } else {
      throw new ApiError(RENTAL_NOT_FOUND, "The rental item is unavailable in this client catalog.");
    }
    return {
      state: { ...state, revision: state.revision + 1, itemInventory, rental: nextRental },
      rental: nextRental,
      resultAction: DbAction.AcceptRentalOffer,
      resultFields: { Rental: bootWire(nextRental) },
      replayed: false,
    };
  }

  if (rental.status === "purchased" && rental.nextGenerate > currentTime) {
    return {
      // Permanent ownership and the debit were committed together on the first request.
      // Replaying the purchase must not manufacture a new revision as a fake side effect.
      state,
      rental,
      resultAction: successfulPurchaseAction(rental.type),
      resultFields: {},
      replayed: true,
    };
  }
  if (rental.status !== "sale" || rental.saleExpiresAt <= currentTime) {
    throw new ApiError(RENTAL_NOT_FOUND, "The discounted rental purchase is not active.");
  }

  let working = clearBorrowedItem(state, rental);
  const itemInventory = itemInventoryStateFor(working);
  const definition = rental.type === 1 ? WEAPON_CATALOG[rental.id] : UNIT_CATALOG[rental.id];
  if (!definition || !positivePrice(definition)) {
    throw new ApiError(RENTAL_NOT_FOUND, "The rental item has no authoritative purchase price.");
  }
  const usesGold = definition.gold > 0;
  const basePrice = usesGold ? definition.gold : definition.warBucks;
  const price = rentalDiscountedPrice(basePrice, rental.discount);
  if (usesGold && working.gold < price) throw new ApiError(ITEM_NOT_ENOUGH_GOLD, "Not enough Gold.");
  if (!usesGold && working.warBucks < price) {
    throw new ApiError(ITEM_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks.");
  }

  if (rental.type === 1) {
    itemInventory.levelManagerData.savedWeapons[rental.id] = {
      bought: true,
      boughtIndex: 0,
      showed: true,
      borrowed: false,
      specialFeature: 0,
    };
  } else {
    itemInventory.levelManagerData.savedArmies[rental.id] = unitState("owned", rental.id);
  }
  const purchased = validatedRentalState({
    ...rental,
    status: "purchased",
    trialExpiresAt: 0,
    saleExpiresAt: 0,
  })!;
  working = {
    ...working,
    revision: state.revision + 1,
    gold: working.gold - (usesGold ? price : 0),
    warBucks: working.warBucks - (usesGold ? 0 : price),
    itemInventory,
    rental: purchased,
  };
  return {
    state: working,
    rental: purchased,
    resultAction: successfulPurchaseAction(rental.type),
    resultFields: {},
    replayed: false,
  };
}

/** End a free trial after one battle and emit the sale variant expected by GameEnded. */
export function advanceRentalAfterBattleState(
  state: PlayerProgressionState,
  battleId: string,
  now: number,
): RentalMutationResult {
  const currentTime = validatedRentalUnixSeconds(now, "Rental battle-settlement time");
  const rental = validatedRentalState(state.rental);
  // The optimistic mutation helper now recognizes exact-state no-ops. Returning `state` is also
  // the correct race behavior: if action 138 or GetPlayerData changed the rental after the match
  // handler inspected it, this transition observes that newer snapshot and acknowledges it
  // without inventing a revision or replacing MongoDB with identical progression.
  if (!rental || !battleId) return { state };
  if (
    rental.status === "sale"
    && rental.saleBattleId === battleId
    && rental.saleExpiresAt > currentTime
  ) {
    return {
      state,
      rental,
      saleOffer: saleWire(rental),
    };
  }
  if (rental.status !== "trial" || rental.trialExpiresAt <= currentTime) {
    return { state, rental };
  }

  const cleared = clearBorrowedItem(state, rental);
  const sale = validatedRentalState({
    ...rental,
    status: "sale",
    trialExpiresAt: 0,
    saleExpiresAt: currentTime + RENTAL_OFFER_SECONDS,
    nextGenerate: currentTime + RENTAL_OFFER_SECONDS,
    saleBattleId: battleId,
  })!;
  return {
    state: { ...cleared, revision: state.revision + 1, rental: sale },
    rental: sale,
    saleOffer: saleWire(sale),
  };
}

export function ensureRentalOffer(
  playerId: string,
  playerLevel: number,
): Promise<RentalMutationResult> {
  return mutateProgression(playerId, (state, now) => (
    ensureRentalOfferState(state, playerId, playerLevel, now)
  ));
}

export function acceptRentalOffer(
  playerId: string,
  buyRentalDiscounted: boolean,
): Promise<RentalAcceptanceResult> {
  return mutateProgression(playerId, (state, now) => (
    acceptRentalOfferState(state, buyRentalDiscounted, now)
  ));
}

export function advanceRentalAfterBattle(
  playerId: string,
  battleId: string,
): Promise<RentalMutationResult> {
  return mutateProgression(playerId, (state, now) => (
    advanceRentalAfterBattleState(state, battleId, now)
  ));
}
