import { ApiError } from "../apiErrors";
import type {
  ItemDeliveryState,
  ItemInventoryState,
  LevelManagerDataState,
  PlayerInventoryDataState,
  PlayerProgressionState,
  SavedWeaponState,
} from "../db";

// Exact IJEAJGCCHEF values handled by the stock RequestBuffer result parser.
export const ITEM_NOT_ENOUGH_WARBUCKS = 100;
export const ITEM_NOT_ENOUGH_LEVEL = 101;
export const ITEM_NOT_ENOUGH_GOLD = 103;
export const ITEM_WEAPON_NOT_BOUGHT = 110;
export const ITEM_PRICE_NOT_FOUND = 113;
export const ITEM_PRICE_MISMATCH = 114;

interface WeaponDefinition {
  /** GetType().ToString() value written by WeaponLevelsSetup.DHHKOKKDDDO. */
  name: string;
  /** Position in LevelManager.weaponLevelsSetups, sent as EquipWeapon.Index. */
  index: number;
  /** One-bit WeaponCategory value checked against the destination slot mask. */
  category: number;
  /** First zero-based LevelManager.levelNumber at which canBeBought becomes true. */
  canBuyLevelIndex: number;
  /** Display level echoed by the stock BuyWeapon request. */
  unlockLevel: number;
  warBucks: number;
  gold: number;
  deliverySeconds: number;
  starterOwned: boolean;
}

/**
 * Authoritative weapon rows currently recovered end-to-end from the 4.9.5 MainScene.
 *
 * Four entries are the initial PlayerInventory.Init choices for the serialized slot masks
 * 263, 1064, 592, and 128. FAMAS is the first non-starter transaction implemented here:
 * MainScene stores its obscured PRICEGOLD as 445353 XOR 444444 = 949, CANBEBOUGHT=14,
 * UNLOCKLEVEL=17, category=1, and LevelManager index=2. Limiting the catalog to verified
 * rows makes unknown weapons fail closed instead of assigning guessed prices or indexes.
 */
export const WEAPON_CATALOG: Readonly<Record<string, WeaponDefinition>> = Object.freeze({
  "Google2u.AssaultRifle_AK47": {
    name: "Google2u.AssaultRifle_AK47", index: 1, category: 1,
    canBuyLevelIndex: 0, unlockLevel: 1, warBucks: 0, gold: 0, deliverySeconds: 0, starterOwned: true,
  },
  "Google2u.SniperRifle_M24": {
    name: "Google2u.SniperRifle_M24", index: 3, category: 8,
    canBuyLevelIndex: 0, unlockLevel: 1, warBucks: 0, gold: 0, deliverySeconds: 0, starterOwned: true,
  },
  "Google2u.Grenade_FRAG": {
    name: "Google2u.Grenade_FRAG", index: 6, category: 64,
    canBuyLevelIndex: 0, unlockLevel: 2, warBucks: 0, gold: 0, deliverySeconds: 0, starterOwned: true,
  },
  "Google2u.Pistol_Remmington51": {
    name: "Google2u.Pistol_Remmington51", index: 13, category: 128,
    canBuyLevelIndex: 0, unlockLevel: 1, warBucks: 0, gold: 0, deliverySeconds: 0, starterOwned: true,
  },
  "Google2u.AssaultRifle_Famas": {
    name: "Google2u.AssaultRifle_Famas", index: 2, category: 1,
    // HCICPDLJNCK.CANBEBOUGHT is 14, and WeaponLevelsSetup.canBeBought compares the
    // zero-based currentLevel.index against CANBEBOUGHT - 1.
    canBuyLevelIndex: 13, unlockLevel: 17, warBucks: 0, gold: 949, deliverySeconds: 0, starterOwned: false,
  },
});

// These are the four category masks serialized on PlayerInventory.inventorySlots in the
// 4.9.5 MainScene. A weapon category must be wholly contained in its destination mask.
const WEAPON_SLOT_MASKS = [263, 1064, 592, 128] as const;

export interface WeaponPurchasePayload {
  name: string;
  warBucks: number;
  gold: number;
  unlockLevel: number;
  startTime: number;
  discount: number;
}

export interface WeaponEquipPayload {
  name: string;
  index: number;
  slotIndex: number;
  armyPower: number;
  specialFeature: number;
}

export interface ItemInventoryMutationResult {
  state: PlayerProgressionState;
  itemInventory: ItemInventoryState;
  weapon: SavedWeaponState;
  definition: WeaponDefinition;
}

function emptyDelivery(): ItemDeliveryState {
  return { activationNeeded: false, boughtIndex: 0, end: 0, itemId: "", slotId: 0, start: 0 };
}

function ownedWeapon(): SavedWeaponState {
  return { bought: true, boughtIndex: 0, showed: true, borrowed: false, specialFeature: 0 };
}

/** Construct the exact starter objects expected by PlayerInventory and LevelManager. */
export function createInitialItemInventory(): ItemInventoryState {
  const starterDefinitions = Object.values(WEAPON_CATALOG).filter((weapon) => weapon.starterOwned);
  const savedWeapons = Object.fromEntries(starterDefinitions.map((weapon) => [weapon.name, ownedWeapon()]));
  const slots: PlayerInventoryDataState["slots"] = {
    "0": { name: "Google2u.AssaultRifle_AK47", weaponIndex: 1 },
    "1": { name: "Google2u.SniperRifle_M24", weaponIndex: 3 },
    "2": { name: "Google2u.Grenade_FRAG", weaponIndex: 6 },
    "3": { name: "Google2u.Pistol_Remmington51", weaponIndex: 13 },
  };
  return {
    inventoryData: { slots },
    levelManagerData: {
      savedArmies: {},
      savedWeapons,
      unitDelivery: emptyDelivery(),
      weaponDelivery: emptyDelivery(),
    },
  };
}

function isObject(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value);
}

function integer(value: unknown, field: string): number {
  const parsed = Number(value);
  if (!Number.isInteger(parsed)) throw new ApiError(ITEM_PRICE_MISMATCH, `${field} must be an integer.`);
  return parsed;
}

function boundedName(value: unknown): string {
  if (typeof value !== "string" || value.length < 1 || value.length > 128) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Weapon name is invalid.");
  }
  return value;
}

function parseObjectJson(value: string): Record<string, unknown> {
  if (value.length < 2 || value.length > 64_000) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Weapon request data is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Weapon request data is invalid JSON.");
  }
  if (!isObject(parsed)) throw new ApiError(ITEM_PRICE_MISMATCH, "Weapon request data must be an object.");
  return parsed;
}

/** Decode the exact dictionary queued by WeaponScreen.BJBCNPHMEBI. */
export function parseWeaponPurchaseData(value: string): WeaponPurchasePayload {
  const data = parseObjectJson(value);
  return {
    name: boundedName(data.Name),
    warBucks: integer(data.Warbucks, "Warbucks"),
    gold: integer(data.Gold, "Gold"),
    unlockLevel: integer(data.UnlockLevel, "UnlockLevel"),
    startTime: integer(data.StartTime, "StartTime"),
    discount: integer(data.discount ?? 0, "discount"),
  };
}

/** Decode the exact dictionary queued by WeaponScreen.EquipWeapon. */
export function parseWeaponEquipData(value: string): WeaponEquipPayload {
  const data = parseObjectJson(value);
  return {
    // Index is a string in the stock request; integer() intentionally accepts that shape.
    index: integer(data.Index, "Index"),
    name: boundedName(data.Name),
    slotIndex: integer(data.SlotIndex, "SlotIndex"),
    armyPower: integer(data.ArmyPower, "ArmyPower"),
    specialFeature: integer(data.SpecialFeature, "SpecialFeature"),
  };
}

function cloneSavedWeapon(value: SavedWeaponState): SavedWeaponState {
  return { ...value };
}

function cloneLevelManagerData(value: LevelManagerDataState): LevelManagerDataState {
  return {
    savedArmies: Object.fromEntries(Object.entries(value.savedArmies).map(([key, item]) => [key, { ...item }])),
    savedWeapons: Object.fromEntries(
      Object.entries(value.savedWeapons).map(([key, item]) => [key, cloneSavedWeapon(item)]),
    ),
    unitDelivery: { ...value.unitDelivery },
    weaponDelivery: { ...value.weaponDelivery },
  };
}

/** Return an isolated working copy so failed optimistic mutations cannot leak object writes. */
export function itemInventoryStateFor(state: PlayerProgressionState): ItemInventoryState {
  const source = state.itemInventory ?? createInitialItemInventory();
  return {
    inventoryData: {
      slots: Object.fromEntries(
        Object.entries(source.inventoryData.slots).map(([key, slot]) => [key, { ...slot }]),
      ),
    },
    levelManagerData: cloneLevelManagerData(source.levelManagerData),
  };
}

/**
 * Atomically debit a verified 4.9.5 price and grant one weapon.
 *
 * The request's price, unlock level, start time, and discount are assertions only. The
 * server selects the catalog row by name and recalculates every authoritative value. A
 * non-zero discount is rejected because the offer subsystem is not implemented and cannot
 * prove entitlement; silently accepting it would let a modified APK choose its own price.
 */
export function purchaseWeaponState(
  state: PlayerProgressionState,
  playerLevel: number,
  payload: WeaponPurchasePayload,
): ItemInventoryMutationResult {
  const definition = WEAPON_CATALOG[payload.name];
  if (!definition || definition.starterOwned) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Weapon is not available for this purchase path.");
  }
  if (payload.discount !== 0) {
    throw new ApiError(13601, "Weapon discount is not backed by an active server offer.");
  }
  if (
    payload.gold !== definition.gold
    || payload.warBucks !== definition.warBucks
    || payload.unlockLevel !== definition.unlockLevel
    || payload.gold < 0
    || payload.warBucks < 0
  ) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Weapon price or unlock level does not match server balancing.");
  }
  if (!Number.isFinite(payload.startTime) || payload.startTime < 0) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Weapon purchase start time is invalid.");
  }
  // DatabasePlayer.Level is passed directly to LevelManager.LoadData and stored as the
  // zero-based levelNumber. Comparing it to a display level here would create an off-by-one
  // purchase gate relative to WeaponLevelsSetup.canBeBought.
  if (Math.max(0, Math.floor(playerLevel)) < definition.canBuyLevelIndex) {
    throw new ApiError(ITEM_NOT_ENOUGH_LEVEL, "Player level is too low for this weapon.");
  }

  const itemInventory = itemInventoryStateFor(state);
  const existing = itemInventory.levelManagerData.savedWeapons[definition.name];
  if (existing?.bought) {
    // The client groups this result with its other weapon-state recovery failures. Returning
    // AlreadyMaximumUpgrade (102) is safer than charging again or pretending a duplicate
    // buffered purchase created a second item.
    throw new ApiError(102, "Weapon is already owned.");
  }
  if (state.gold < definition.gold) throw new ApiError(ITEM_NOT_ENOUGH_GOLD, "Not enough Gold.");
  if (state.warBucks < definition.warBucks) {
    throw new ApiError(ITEM_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks.");
  }

  const weapon = ownedWeapon();
  itemInventory.levelManagerData.savedWeapons[definition.name] = weapon;
  // FAMAS is a premium/Gold row with DELIVERTIME=0. Delivery-bearing WarBucks rows remain
  // disabled until activation/instant-finish actions are implemented as one lifecycle.
  itemInventory.levelManagerData.weaponDelivery = emptyDelivery();
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold - definition.gold,
    warBucks: state.warBucks - definition.warBucks,
    itemInventory,
  };
  return { state: next, itemInventory, weapon, definition };
}

/**
 * Equip an owned weapon into a compatible recovered slot.
 *
 * ArmyPower is deliberately not written back: the client calculates it from upgrade sheets,
 * but those upgrade rows are not yet server-authoritative. Ownership, catalog index, slot
 * category, and SpecialFeature are all checked against stored state before the slot changes.
 */
export function equipWeaponState(
  state: PlayerProgressionState,
  payload: WeaponEquipPayload,
): ItemInventoryMutationResult {
  const definition = WEAPON_CATALOG[payload.name];
  const itemInventory = itemInventoryStateFor(state);
  const weapon = definition ? itemInventory.levelManagerData.savedWeapons[definition.name] : undefined;
  const slotMask = WEAPON_SLOT_MASKS[payload.slotIndex];
  if (
    !definition
    || !weapon?.bought
    || payload.index !== definition.index
    || slotMask === undefined
    || (slotMask & definition.category) !== definition.category
    || payload.specialFeature !== weapon.specialFeature
    || payload.armyPower < 0
  ) {
    throw new ApiError(ITEM_WEAPON_NOT_BOUGHT, "Weapon is not owned or cannot be equipped in this slot.");
  }

  itemInventory.inventoryData.slots[String(payload.slotIndex)] = {
    name: definition.name,
    weaponIndex: definition.index,
  };
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    itemInventory,
  };
  return { state: next, itemInventory, weapon, definition };
}

export function serializeInventoryData(value: ItemInventoryState): string {
  return JSON.stringify(value.inventoryData);
}

export function serializeLevelManagerData(value: ItemInventoryState): string {
  return JSON.stringify(value.levelManagerData);
}

/**
 * Build the rollback fields read by OGLEHLIPEFM.JIMIKHFDEFC after a failed weapon request.
 * The client has already mutated its local model optimistically, so an error without these
 * fields would leave the UI and wallet diverged from the committed server state.
 */
export function weaponRecoveryFields(
  state: PlayerProgressionState,
  requestedName: string,
): Record<string, unknown> {
  const itemInventory = itemInventoryStateFor(state);
  const name = WEAPON_CATALOG[requestedName]?.name ?? "Google2u.AssaultRifle_AK47";
  const weapon = itemInventory.levelManagerData.savedWeapons[name] ?? {
    bought: false, boughtIndex: 0, showed: false, borrowed: false, specialFeature: 0,
  };
  return {
    LevelName: name,
    Weapon: JSON.stringify(weapon),
    InventoryData: serializeInventoryData(itemInventory),
    weaponDelivery: JSON.stringify(itemInventory.levelManagerData.weaponDelivery),
    Gold: state.gold,
    WarBucks: state.warBucks,
  };
}

/** Best-effort extraction used only to choose a safe rollback row after parse failure. */
export function requestedWeaponName(value: string): string {
  try {
    const parsed = JSON.parse(value) as Record<string, unknown>;
    return typeof parsed?.Name === "string" ? parsed.Name : "";
  } catch {
    return "";
  }
}
