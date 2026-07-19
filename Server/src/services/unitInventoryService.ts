import { ApiError } from "../apiErrors";
import type {
  ItemInventoryState,
  PlayerProgressionState,
  SavedArmyState,
} from "../db";
import generatedUnitCatalog from "../data/unitCatalog.generated.json";
import {
  ITEM_ALREADY_MAXIMUM_UPGRADE,
  ITEM_NO_DISCOUNT_FOUND,
  ITEM_NOT_ENOUGH_GOLD,
  ITEM_NOT_ENOUGH_LEVEL,
  ITEM_NOT_ENOUGH_WARBUCKS,
  ITEM_PRICE_MISMATCH,
  ITEM_PRICE_NOT_FOUND,
  ITEM_WRONG_INDEX_TO_ACTIVATE,
  itemInventoryStateFor,
} from "./itemInventoryService";

/** IJEAJGCCHEF.CantEquipUnit, consumed by UpdateEquippedUnits rollback logic. */
export const UNIT_CANT_EQUIP = 11406;

/**
 * Authoritative unit purchase logic recovered from the 4.9.5 MainScene.
 *
 * ArmyScreen applies `UpgradeSlots.Buy()` locally before it queues BuyUnit, so every request
 * reaches the backend after the phone has already changed its wallet and unit model. This
 * service never trusts that optimistic state. It selects a row from the reproducibly extracted
 * catalog, checks every client-echoed balancing field, debits the stored wallet, and creates
 * the exact LevelManager.SavedArmySlots object in one immutable progression transition.
 *
 * The recovered scene contains three different row groups and they must not be conflated:
 * 24 `player` rows have concrete LevelManager behaviours; three `additional` rows are turret
 * helpers used inside battles; 18 newer ArmyUpgrades rows have no LevelManager object in this
 * client. Only non-tutorial player rows enter UNIT_CATALOG. This fail-closed boundary prevents
 * a modified APK from buying a helper or an item that the stock client cannot instantiate.
 *
 * Every supported player row has DELIVERTIME=0. The stock client consequently queues BuyUnit
 * followed by ActivateUnit in the same RequestBuffer. Purchase grants ownership immediately,
 * and activation is an idempotent acknowledgement of that already-committed state. No timer is
 * invented and `unitDelivery` stays empty. The tutorial Assaulter is excluded because the stock
 * tutorial mutates it locally without sending BuyUnit; its persistence requires a dedicated,
 * separately recovered tutorial transition.
 */

export interface UnitDefinition {
  /** Google2u component type used by ArmyScreen as Name/LevelName. */
  name: string;
  /** Position in LevelManager.behaviours; stable identity for this client build. */
  index: number;
  roster: "player" | "additional";
  behaviourType: string;
  upgradeType: string;
  tutorialUnit: boolean;
  /** LevelBehaviour.UnitType used by ActiveUnitsManager's four deployment categories. */
  deploymentType: 0 | 1 | 2 | 3;
  /** False for mechanical units, which share an additional three-unit global cap. */
  isSoldier: boolean;
  /** Display level echoed in BuyUnit.UnlockLevel. */
  unlockLevel: number;
  /** Zero-based LevelManager.levelNumber gate used by UpgradeSlots.canBuy. */
  canBuyLevelIndex: number;
  warBucks: number;
  gold: number;
  deliverySeconds: number;
  /** Initial SavedArmySlots.tier, not an upgrade count. */
  startingTier: number;
  /** Source-sheet display level retained for later upgrade/promotion recovery. */
  startingLevel: number;
  /** Absolute source-table row at which the special-slot subtable begins. */
  startingSpecial: number;
  /** Absolute source-table row at which elite-part upgrades begin. */
  startingElite: number;
  unitType: number;
  clientId: number;
  /** Display-level requirements for promotions into tiers 2 through 6. */
  unlockTierLevels: readonly number[];
}

interface GeneratedUnitArtifact {
  catalog: UnitDefinition[];
}

const extractedRows = (generatedUnitCatalog as GeneratedUnitArtifact).catalog;
const PLAYER_UNIT_CATALOG: Readonly<Record<string, UnitDefinition>> = Object.freeze(
  Object.fromEntries(
    extractedRows
      .filter((row) => row.roster === "player")
      .map((row) => [row.name, Object.freeze({ ...row })]),
  ),
);

/**
 * Runtime purchase catalog. Filtering is deliberate security logic, not data cleanup: helper
 * rows and tutorial-owned units exist in the artifact so extraction drift is testable, but
 * exposing them here would accidentally authorize them through the normal shop endpoint.
 */
export const UNIT_CATALOG: Readonly<Record<string, UnitDefinition>> = Object.freeze(
  Object.fromEntries(
    extractedRows
      .filter((row) => row.roster === "player" && !row.tutorialUnit)
      .map((row) => [row.name, Object.freeze({ ...row })]),
  ),
);

export interface UnitPurchasePayload {
  name: string;
  warBucks: number;
  gold: number;
  unlockLevel: number;
  startTime: number;
  discount: number;
}

export interface UnitActivatePayload {
  name: string;
}

export interface UnitEquipDetailPayload {
  wasEquipped: boolean;
  equipped: boolean;
}

export interface UnitEquipPayload {
  /** Client display value. Shape-checked but not authoritative until power rows are recovered. */
  armyPower: number;
  /** Full set of units whose historical or current equip flag is true. */
  equips: Readonly<Record<string, UnitEquipDetailPayload>>;
}

export interface UnitInventoryMutationResult {
  state: PlayerProgressionState;
  itemInventory: ItemInventoryState;
  unit: SavedArmyState;
  definition: UnitDefinition;
}

function isObject(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value);
}

function integer(value: unknown, field: string): number {
  const parsed = Number(value);
  if (!Number.isInteger(parsed)) {
    throw new ApiError(ITEM_PRICE_MISMATCH, `${field} must be an integer.`);
  }
  return parsed;
}

function unitName(value: unknown): string {
  if (typeof value !== "string" || value.length < 1 || value.length > 128) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Unit name is invalid.");
  }
  return value;
}

function parseObjectJson(value: string): Record<string, unknown> {
  if (value.length < 2 || value.length > 64_000) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Unit request data is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Unit request data is invalid JSON.");
  }
  if (!isObject(parsed)) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Unit request data must be an object.");
  }
  return parsed;
}

/** Decode the exact dictionary queued by ArmyScreen.GAKDCJEFKEL for action 80. */
export function parseUnitPurchaseData(value: string): UnitPurchasePayload {
  const data = parseObjectJson(value);
  return {
    name: unitName(data.Name),
    warBucks: integer(data.Warbucks, "Warbucks"),
    gold: integer(data.Gold, "Gold"),
    unlockLevel: integer(data.UnlockLevel, "UnlockLevel"),
    startTime: integer(data.StartTime, "StartTime"),
    discount: integer(data.discount ?? 0, "discount"),
  };
}

/** Decode the zero-delivery confirmation queued as ActivateUnit action 127. */
export function parseUnitActivateData(value: string): UnitActivatePayload {
  const data = parseObjectJson(value);
  return { name: unitName(data.LevelName) };
}

/** Decode ArmyScreen.SendEquippedUnits' exact action-1003 dictionary. */
export function parseUnitEquipData(value: string): UnitEquipPayload {
  const data = parseObjectJson(value);
  const rawEquips = data.equips;
  if (!isObject(rawEquips) || Object.keys(rawEquips).length > 24) {
    throw new ApiError(UNIT_CANT_EQUIP, "Equipped-unit map is invalid.");
  }
  const equips: Record<string, UnitEquipDetailPayload> = {};
  for (const [name, rawDetail] of Object.entries(rawEquips)) {
    if (!isObject(rawDetail)) {
      throw new ApiError(UNIT_CANT_EQUIP, "Equipped-unit detail is invalid.");
    }
    const wasEquipped = rawDetail.wasEquipped ?? false;
    const equipped = rawDetail.equipped ?? false;
    if (typeof wasEquipped !== "boolean" || typeof equipped !== "boolean") {
      throw new ApiError(UNIT_CANT_EQUIP, "Equipped-unit flags must be booleans.");
    }
    equips[unitName(name)] = { wasEquipped, equipped };
  }
  return {
    armyPower: integer(data.armyPower, "armyPower"),
    equips,
  };
}

function newlyOwnedUnit(definition: UnitDefinition): SavedArmyState {
  return {
    bought: true,
    // Buy() initializes the normal-upgrade cursor independently of STARTINGTIER/STARTINGLEVEL.
    boughtIndex: 0,
    specialSlot: 0,
    // ArmyScreen.ShowUnit sets this flag when the user opens the unlocked unit before buying
    // it. The backend does not accept the separate impression action as ownership authority,
    // so a completed shop purchase persists the post-selection value directly.
    showed: true,
    tier: definition.startingTier,
    borrowed: false,
    wasEquipped: false,
    equipped: false,
    eliteSlot: 0,
    parts: 0,
  };
}

/**
 * Debit a recovered price and grant one roster unit atomically.
 *
 * Prices, unlock display value, level gate, discount, and delivery duration come from the
 * server artifact. Request values are assertions used to detect a stale or modified client;
 * they never become persisted balancing. A second purchase with a different BufferId fails
 * as AlreadyMaximumUpgrade (the stock parser's existing code 102) and returns a rollback unit.
 */
export function purchaseUnitState(
  state: PlayerProgressionState,
  playerLevel: number,
  payload: UnitPurchasePayload,
): UnitInventoryMutationResult {
  const definition = UNIT_CATALOG[payload.name];
  if (!definition) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Unit is not available for the normal purchase path.");
  }
  if (payload.discount !== 0) {
    throw new ApiError(ITEM_NO_DISCOUNT_FOUND, "Unit purchase offer is not backed by the server.");
  }
  if (
    payload.warBucks !== definition.warBucks
    || payload.gold !== definition.gold
    || payload.unlockLevel !== definition.unlockLevel
  ) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Unit price or unlock level does not match server balancing.");
  }
  if (payload.startTime < 0) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Unit purchase start time is invalid.");
  }
  if (definition.deliverySeconds !== 0) {
    // The current lifecycle intentionally has no inferred timer behavior. If a future source
    // artifact changes this value, fail closed until InstantBuyUnit/ActivateUnit are recovered.
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Timed unit purchase is not implemented.");
  }
  if (!Number.isInteger(playerLevel) || playerLevel < definition.canBuyLevelIndex) {
    throw new ApiError(ITEM_NOT_ENOUGH_LEVEL, "Player level is too low for this unit.");
  }

  const itemInventory = itemInventoryStateFor(state);
  if (itemInventory.levelManagerData.savedArmies[definition.name]?.bought) {
    throw new ApiError(ITEM_ALREADY_MAXIMUM_UPGRADE, "Unit is already owned.");
  }
  if (state.gold < definition.gold) {
    throw new ApiError(ITEM_NOT_ENOUGH_GOLD, "Not enough Gold.");
  }
  if (state.warBucks < definition.warBucks) {
    throw new ApiError(ITEM_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks.");
  }

  const unit = newlyOwnedUnit(definition);
  itemInventory.levelManagerData.savedArmies[definition.name] = unit;
  const nextState: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold - definition.gold,
    warBucks: state.warBucks - definition.warBucks,
    itemInventory,
  };
  return { state: nextState, itemInventory, unit, definition };
}

/**
 * Confirm the stock client's immediate ActivateUnit follow-up.
 *
 * BuyUnit has already granted the unit because the recovered duration is zero. Requiring the
 * stored ownership record binds activation to a successful earlier purchase while allowing
 * BuyUnit and ActivateUnit to execute sequentially in one RequestBuffer. No wallet or army
 * fields change here, and BufferId replay protection remains owned by assignmentService.
 */
export function activateUnitState(
  state: PlayerProgressionState,
  payload: UnitActivatePayload,
): UnitInventoryMutationResult {
  const definition = UNIT_CATALOG[payload.name];
  if (!definition) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Unit is not available for activation.");
  }
  const itemInventory = itemInventoryStateFor(state);
  const unit = itemInventory.levelManagerData.savedArmies[definition.name];
  if (!unit?.bought) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "Unit has no completed purchase to activate.");
  }
  return { state, itemInventory, unit, definition };
}

/**
 * Persist the full active-unit snapshot sent after purchase or roster editing.
 *
 * ActiveUnitsManager allows at most two equipped units in each of the four
 * LevelBehaviour.UnitType categories and at most three non-soldier (mechanical) units in
 * total. `equips` omits rows whose two flags are both false, so the server first clears only
 * the current `equipped` bit on every owned row while preserving `wasEquipped` as monotonic
 * history, then applies and validates the supplied true rows.
 *
 * The tutorial Assaulter is a special source-backed exception. ArmyScreen deliberately skips
 * BuyUnit/ActivateUnit for `isTutorialUnit`, leaving UpdateEquippedUnits as the first normal
 * backend event capable of persisting it. Materializing that one exact recovered row here is
 * safe and required for the post-tutorial roster to survive login; helpers and unresolved
 * table rows remain rejected. Client armyPower is not stored because its per-upgrade formula
 * has not yet been recovered and therefore cannot be independently verified by the server.
 */
export function updateEquippedUnitsState(
  state: PlayerProgressionState,
  payload: UnitEquipPayload,
): { state: PlayerProgressionState; itemInventory: ItemInventoryState } {
  if (payload.armyPower < 0) {
    throw new ApiError(UNIT_CANT_EQUIP, "Army power must be non-negative.");
  }
  const itemInventory = itemInventoryStateFor(state);
  const savedArmies = itemInventory.levelManagerData.savedArmies;

  for (const unit of Object.values(savedArmies)) {
    unit.equipped = false;
  }

  const categoryCounts = [0, 0, 0, 0];
  let mechanicalCount = 0;
  for (const [name, requested] of Object.entries(payload.equips)) {
    const definition = PLAYER_UNIT_CATALOG[name];
    if (!definition) {
      throw new ApiError(UNIT_CANT_EQUIP, "Unit is not part of the player roster.");
    }

    let unit = savedArmies[name];
    if (!unit?.bought && definition.tutorialUnit) {
      // This is the only client-authoritative grant in the path and is constrained to the
      // scene's single isTutorialUnit row. It cannot mint currency or another catalog item.
      unit = newlyOwnedUnit(definition);
      savedArmies[name] = unit;
    }
    if (!unit?.bought || unit.borrowed) {
      throw new ApiError(UNIT_CANT_EQUIP, "Only owned, non-rental units can be equipped.");
    }
    if (requested.equipped && !(requested.wasEquipped || unit.wasEquipped)) {
      throw new ApiError(UNIT_CANT_EQUIP, "An equipped unit must carry its wasEquipped history flag.");
    }

    unit.wasEquipped = unit.wasEquipped || requested.wasEquipped || requested.equipped;
    unit.equipped = requested.equipped;
    if (requested.equipped) {
      categoryCounts[definition.deploymentType] += 1;
      if (!definition.isSoldier) mechanicalCount += 1;
    }
  }

  if (categoryCounts.some((count) => count > 2) || mechanicalCount > 3) {
    throw new ApiError(UNIT_CANT_EQUIP, "Equipped units exceed recovered category or mechanical limits.");
  }
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    itemInventory,
  };
  return { state: next, itemInventory };
}

function emptyUnit(definition?: UnitDefinition): SavedArmyState {
  return {
    bought: false,
    boughtIndex: 0,
    specialSlot: 0,
    // GetArmySlot initializes these two fields before the user buys anything. Returning the
    // same defaults prevents rollback from changing the unit's displayed tier or seen state.
    showed: definition?.canBuyLevelIndex === 0,
    tier: definition?.startingTier ?? 0,
    borrowed: false,
    wasEquipped: false,
    equipped: false,
    eliteSlot: 0,
    parts: 0,
  };
}

/**
 * Build the exact fields OGLEHLIPEFM consumes to undo an optimistic unit mutation.
 *
 * Unknown names deliberately fall back to a non-owned object under the requested LevelName;
 * unlike weapons, no starter unit can safely substitute for an invalid row. Currency and the
 * shared delivery receipt always come from the last successful state in the current buffer.
 */
export function unitRecoveryFields(
  state: PlayerProgressionState,
  requestedName: string,
): Record<string, unknown> {
  const itemInventory = itemInventoryStateFor(state);
  const name = requestedName || "";
  const unit = itemInventory.levelManagerData.savedArmies[name] ?? emptyUnit(PLAYER_UNIT_CATALOG[name]);
  return {
    LevelName: name,
    Unit: JSON.stringify(unit),
    unitDelivery: JSON.stringify(itemInventory.levelManagerData.unitDelivery),
    Gold: state.gold,
    WarBucks: state.warBucks,
  };
}

/** Exact UpdateEquippedUnits failure payload consumed by OGLEHLIPEFM. */
export function equippedUnitsRecoveryFields(state: PlayerProgressionState): Record<string, unknown> {
  const savedArmies = itemInventoryStateFor(state).levelManagerData.savedArmies;
  return {
    data: JSON.stringify(
      Object.fromEntries(
        Object.values(PLAYER_UNIT_CATALOG).map((definition) => [
          definition.name,
          JSON.stringify(savedArmies[definition.name] ?? emptyUnit(definition)),
        ]),
      ),
    ),
  };
}

/** Best-effort name extraction used only to select rollback data after a parse error. */
export function requestedUnitName(value: string): string {
  try {
    const parsed = JSON.parse(value) as Record<string, unknown>;
    if (typeof parsed?.Name === "string") return parsed.Name;
    return typeof parsed?.LevelName === "string" ? parsed.LevelName : "";
  } catch {
    return "";
  }
}
