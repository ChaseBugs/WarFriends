import { randomInt } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  ItemInventoryState,
  PlayerProgressionState,
  SavedArmyState,
} from "../db";
import generatedUnitCatalog from "../data/unitCatalog.generated.json";
import generatedUnitUpgradeCatalog from "../data/unitUpgradeCatalog.generated.json";
import {
  ITEM_ALREADY_MAXIMUM_UPGRADE,
  ITEM_ALREADY_UPGRADING,
  ITEM_NEGATIVE_PRICE_FROM_CLIENT,
  ITEM_NO_DISCOUNT_FOUND,
  ITEM_NOT_ENOUGH_GOLD,
  ITEM_NOT_ENOUGH_LEVEL,
  ITEM_NOT_ENOUGH_WARBUCKS,
  ITEM_PRICE_MISMATCH,
  ITEM_PRICE_NOT_FOUND,
  ITEM_TOO_SOON_TO_ACTIVATE,
  ITEM_WRONG_INDEX_TO_ACTIVATE,
  WEAPON_GOLD_COEFFICIENT,
  WEAPON_GOLD_EXP_COEFFICIENT,
  itemInventoryStateFor,
  type TutorialUpgradeFunding,
  weaponUpgradeInstantPrice,
} from "./itemInventoryService";

/** IJEAJGCCHEF.CantEquipUnit, consumed by UpdateEquippedUnits rollback logic. */
export const UNIT_CANT_EQUIP = 11406;
/** IJEAJGCCHEF.NotEnoughLevelForPromote, handled by the client's global warning parser. */
export const UNIT_NOT_ENOUGH_LEVEL_FOR_PROMOTE = 11405;
/** IJEAJGCCHEF.NotEnoughParts, handled only by the UpgradeEliteSlot response branch. */
export const UNIT_ELITE_NOT_ENOUGH_PARTS = 20902;
/** IJEAJGCCHEF.IncorrectValuesOnClient, which forces a relog after an elite mismatch. */
export const UNIT_ELITE_INCORRECT_VALUES = 20903;
/** IJEAJGCCHEF.NotEnoughScraps, handled by ConvertScrapsToParts. */
export const UNIT_ELITE_NOT_ENOUGH_SCRAPS = 20701;
/** IJEAJGCCHEF.EliteSlotLocked, handled by ConvertPartsToScraps. */
export const UNIT_ELITE_SLOT_LOCKED = 20801;
/** IJEAJGCCHEF.IncorrectPartsAmount, handled by ConvertPartsToScraps. */
export const UNIT_ELITE_INCORRECT_PARTS_AMOUNT = 20802;

/**
 * Exact 4.9.5 Constants rows used by UpgradeSlotElite and ConvertToScrapsDialog.
 *
 * The MainScene stores CodeStage ObscuredFloat values as a little-endian encrypted integer.
 * XORing `PartToScrapsSell` (`e785a340`) and `PartToScrapsUpgrade` (`e785c341`) with key
 * 230887 yields IEEE-754 values 5 and 24. They are deliberately server constants: accepting
 * either conversion amount from the request would let a modified APK mint Scraps or parts.
 */
export const UNIT_PART_TO_SCRAPS_SELL_RATE = 5;
export const UNIT_SCRAPS_TO_PART_UPGRADE_RATE = 24;

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

interface UnitUpgradeLevel {
  /** Absolute row in the recovered Google2u table, retained for extraction audits. */
  sourceIndex: number;
  /** Tier digit after removing the slot prefix from the table's encoded Tier field. */
  tier: number;
  /** UpgradeSlot.id: zero for normal power and one for the special ability. */
  slot: 0 | 1;
  warBucks: number;
  deliverySeconds: number;
  /** Float value read by UpgradeSlot/UpgradeSlotSpecial.GetArmyPower. */
  armyPower: number;
}

interface UnitEliteUpgradeLevel {
  /** Absolute STARTINGELITE-based row retained for source audits. */
  sourceIndex: number;
  /** Exact unit-specific elite parts consumed by UpgradeEliteSlot. */
  parts: number;
  /** WarBucks cost; the first elite purchase is zero in the recovered tables. */
  warBucks: number;
  /** Float value included only after SavedArmySlots.eliteSlot becomes positive. */
  armyPower: number;
}

interface UnitUpgradeDefinition {
  name: string;
  normalLevels: readonly UnitUpgradeLevel[];
  specialLevels: readonly UnitUpgradeLevel[];
  eliteLevels: readonly UnitEliteUpgradeLevel[];
}

interface GeneratedUnitUpgradeArtifact {
  catalog: UnitUpgradeDefinition[];
}

const extractedRows = (generatedUnitCatalog as GeneratedUnitArtifact).catalog;
const extractedUpgradeRows = (generatedUnitUpgradeCatalog as GeneratedUnitUpgradeArtifact).catalog;
const UNIT_UPGRADE_CATALOG: Readonly<Record<string, UnitUpgradeDefinition>> = Object.freeze(
  Object.fromEntries(
    extractedUpgradeRows.map((row) => [
      row.name,
      Object.freeze({
        ...row,
        normalLevels: Object.freeze(row.normalLevels.map((level) => Object.freeze({ ...level }))),
        specialLevels: Object.freeze(row.specialLevels.map((level) => Object.freeze({ ...level }))),
        eliteLevels: Object.freeze(row.eliteLevels.map((level) => Object.freeze({ ...level }))),
      }),
    ]),
  ),
);
const PLAYER_UNIT_CATALOG: Readonly<Record<string, UnitDefinition>> = Object.freeze(
  Object.fromEntries(
    extractedRows
      .filter((row) => row.roster === "player")
      .map((row) => [row.name, Object.freeze({ ...row })]),
  ),
);

/** Validate a server-configured Elite-parts reward without exposing helper-only unit rows. */
export function isPlayerUnitName(value: string): boolean {
  return PLAYER_UNIT_CATALOG[value] !== undefined;
}

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

export interface UnitUpgradePurchasePayload {
  name: string;
  boughtIndex: number;
  startTime: number;
  isSpecial: boolean;
  discount: number;
  deliveryTime: number;
  deliveryReduce: number;
}

export interface UnitUpgradeInstantPayload {
  name: string;
  boughtIndex: number;
  expectedPrice: number;
  armyPower: number;
  goldCoefficient: number;
  goldExpCoefficient: number;
  discount: number;
}

export interface UnitUpgradeActivatePayload {
  name: string;
  boughtIndex: number;
  armyPower: number;
}

export interface UnitPromotePayload {
  name: string;
}

export interface UnitEliteUpgradePayload {
  name: string;
  /** Relative SavedArmySlots.eliteSlot cursor, not the absolute Google2u row. */
  boughtIndex: number;
  spentWarBucks: number;
  spentParts: number;
}

export interface UnitScrapsToPartsPayload {
  /** Raw Google2u sheet name sent as RequestBuffer.data by action 207. */
  name: string;
}

export interface UnitPartsToScrapsPayload {
  name: string;
  /** The stock dialog always converts the complete current balance. */
  partsToConvert: number;
  /** Client echo checked against partsToConvert * the recovered sell rate. */
  scraps: number;
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

export interface UnitUpgradeMutationResult extends UnitInventoryMutationResult {
  /** Present when BuyUnitUpgrade creates the shared server-owned unit receipt. */
  deliveryTime?: number;
  /** Present when InstantUnitUpgrade spends Gold to consume that receipt. */
  goldSpent?: number;
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

function finiteNumber(value: unknown, field: string): number {
  const parsed = Number(value);
  if (!Number.isFinite(parsed)) {
    throw new ApiError(ITEM_PRICE_MISMATCH, `${field} must be finite.`);
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

/** Decode ArmyScreen.EFGAIHKNKGG's action-77 normal/special upgrade request. */
export function parseUnitUpgradePurchaseData(value: string): UnitUpgradePurchasePayload {
  const data = parseObjectJson(value);
  if (data.IsSpecial !== "0" && data.IsSpecial !== "1") {
    // The stock client deliberately serializes this flag as a string. Accepting arbitrary
    // truthy JSON values would let a modified client select a different upgrade lane.
    throw new ApiError(ITEM_PRICE_MISMATCH, "IsSpecial must be the string 0 or 1.");
  }
  return {
    name: unitName(data.LevelName),
    boughtIndex: integer(data.BoughtIndex, "BoughtIndex"),
    startTime: integer(data.StartTime, "StartTime"),
    isSpecial: data.IsSpecial === "1",
    discount: integer(data.discount ?? 0, "discount"),
    deliveryTime: integer(data.DeliveryTime, "DeliveryTime"),
    deliveryReduce: integer(data.deliveryReduce ?? 0, "deliveryReduce"),
  };
}

/** Decode ArmyScreen.ANLLAOJLPGN after Unity has fast-activated the pending slot locally. */
export function parseUnitUpgradeInstantData(value: string): UnitUpgradeInstantPayload {
  const data = parseObjectJson(value);
  return {
    name: unitName(data.LevelName),
    boughtIndex: integer(data.BoughtIndex, "BoughtIndex"),
    expectedPrice: integer(data.ExpectedPrice, "ExpectedPrice"),
    armyPower: integer(data.ArmyPower, "ArmyPower"),
    goldCoefficient: finiteNumber(data.GoldCoefficient, "GoldCoefficient"),
    goldExpCoefficient: finiteNumber(data.GoldExpCoefficient, "GoldExpCoefficient"),
    discount: integer(data.discount ?? 0, "discount"),
  };
}

/** Decode ArmyScreen.JOFEFBHDFIN after normal timed delivery has been activated locally. */
export function parseUnitUpgradeActivateData(value: string): UnitUpgradeActivatePayload {
  const data = parseObjectJson(value);
  return {
    name: unitName(data.LevelName),
    boughtIndex: integer(data.BoughtIndex, "BoughtIndex"),
    armyPower: integer(data.ArmyPower, "ArmyPower"),
  };
}

/** Decode the one-field dictionary queued by ArmyScreen.JNPHAIPOOBB for action 158. */
export function parseUnitPromoteData(value: string): UnitPromotePayload {
  const data = parseObjectJson(value);
  return { name: unitName(data.LevelName) };
}

/** Decode the exact action-209 dictionary shared by first elite purchase and later upgrades. */
export function parseUnitEliteUpgradeData(value: string): UnitEliteUpgradePayload {
  try {
    const data = parseObjectJson(value);
    return {
      name: unitName(data.LevelName),
      boughtIndex: integer(data.BoughtIndex, "BoughtIndex"),
      spentWarBucks: integer(data.SpentWarbucks, "SpentWarbucks"),
      spentParts: integer(data.SpentParts, "SpentParts"),
    };
  } catch (error) {
    if (error instanceof ApiError) {
      // OGLEHLIPEFM's UpgradeEliteSlot branch does not handle the generic unit price codes.
      // IncorrectValuesOnClient is its source-defined malformed/stale-payload result and
      // deliberately forces a full relog so Unity discards every optimistic elite mutation.
      throw new ApiError(UNIT_ELITE_INCORRECT_VALUES, error.message);
    }
    throw error;
  }
}

/** Decode action 207, whose data is the raw unit sheet name rather than JSON. */
export function parseUnitScrapsToPartsData(value: string): UnitScrapsToPartsPayload {
  try {
    return { name: unitName(value) };
  } catch (error) {
    if (error instanceof ApiError) {
      // Action 207 exposes only NotEnoughScraps in the stock response parser. Returning that
      // source code makes the client relog and restore its optimistic wallet/parts mutation.
      throw new ApiError(UNIT_ELITE_NOT_ENOUGH_SCRAPS, error.message);
    }
    throw error;
  }
}

/** Decode the exact dictionary queued by ConvertToScrapsDialog for action 208. */
export function parseUnitPartsToScrapsData(value: string): UnitPartsToScrapsPayload {
  try {
    const data = parseObjectJson(value);
    return {
      name: unitName(data.LevelName),
      partsToConvert: integer(data.PartsToConvert, "PartsToConvert"),
      scraps: integer(data.Scraps, "Scraps"),
    };
  } catch (error) {
    if (error instanceof ApiError) {
      throw new ApiError(UNIT_ELITE_INCORRECT_PARTS_AMOUNT, error.message);
    }
    throw error;
  }
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
 * Persist ArmyScreen's acknowledgement that an unlocked roster unit was displayed.
 *
 * Like the weapon equivalent, this is notification state rather than ownership authority.
 * The complete unowned SavedArmySlots row is materialized because LevelManager reads tier,
 * upgrade cursors, equip flags, and parts from the same object on boot. Existing purchase,
 * rental, upgrade, equipment, and part fields are preserved byte-for-byte; only `showed`
 * changes. Helper units and source rows without a concrete player behaviour remain excluded
 * by UNIT_CATALOG, and a modified client cannot acknowledge a unit before its level gate.
 */
export function markUnitShownState(
  state: PlayerProgressionState,
  playerLevel: number,
  name: string,
): UnitInventoryMutationResult {
  const definition = UNIT_CATALOG[name];
  if (!definition) throw new ApiError(ITEM_PRICE_NOT_FOUND, "Unit was not found.");
  if (!Number.isInteger(playerLevel) || playerLevel < definition.canBuyLevelIndex) {
    throw new ApiError(ITEM_NOT_ENOUGH_LEVEL, "Unit is still locked for this player.");
  }
  const itemInventory = itemInventoryStateFor(state);
  const current = itemInventory.levelManagerData.savedArmies[definition.name];
  if (current?.showed) {
    return { state, itemInventory, unit: current, definition };
  }
  const unit: SavedArmyState = { ...(current ?? emptyUnit(definition)), showed: true };
  itemInventory.levelManagerData.savedArmies[definition.name] = unit;
  return {
    state: { ...state, revision: state.revision + 1, itemInventory },
    itemInventory,
    unit,
    definition,
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

function emptyDelivery() {
  return { activationNeeded: false, boughtIndex: 0, end: 0, itemId: "", slotId: 0, start: 0 };
}

function activeUnitDelivery(delivery: ItemInventoryState["levelManagerData"]["unitDelivery"]): boolean {
  // An elapsed receipt stays occupied until ActivateUnitUpgrade consumes it. This is the
  // server equivalent of UpgradeSlots.deliveryActivationNeeded and prevents a new purchase
  // from overwriting an upgrade the client has not claimed yet.
  return delivery.activationNeeded || delivery.itemId.length > 0;
}

function unitUpgradeContext(
  state: PlayerProgressionState,
  name: string,
): {
  definition: UnitDefinition;
  upgrades: UnitUpgradeDefinition;
  itemInventory: ItemInventoryState;
  unit: SavedArmyState;
} {
  const definition = PLAYER_UNIT_CATALOG[name];
  const upgrades = UNIT_UPGRADE_CATALOG[name];
  const itemInventory = itemInventoryStateFor(state);
  const unit = definition ? itemInventory.levelManagerData.savedArmies[name] : undefined;
  if (!definition || !upgrades || definition.roster !== "player") {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Unit upgrade balancing was not found.");
  }
  if (!unit?.bought || unit.borrowed) {
    // The unit branch in OGLEHLIPEFM does not handle WeaponNotBought (110); PriceNotFound
    // (113) is the recovered failure that performs the unit/wallet/receipt rollback.
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Unit must be permanently owned before it can be upgraded.");
  }
  return { definition, upgrades, itemInventory, unit };
}

function laneCursor(unit: SavedArmyState, slotId: 0 | 1): number {
  return slotId === 0 ? unit.boughtIndex : unit.specialSlot;
}

function laneLevels(upgrades: UnitUpgradeDefinition, slotId: 0 | 1): readonly UnitUpgradeLevel[] {
  return slotId === 0 ? upgrades.normalLevels : upgrades.specialLevels;
}

/**
 * Return the last cursor available in the unit's current tier.
 *
 * UpgradeSlot.AFDBPKHKJHJ counts rows whose encoded tier digit is lower than actualTier and
 * then subtracts one. The generated artifact already splits the slot prefix (0x normal,
 * 1x special) from that digit, so the same rule is expressed directly here. A cursor equal
 * to this boundary is fully upgraded for the tier and must wait for PromoteUnit; allowing it
 * to purchase the next row would silently skip the promotion gate.
 */
function maximumCursorForTier(levels: readonly UnitUpgradeLevel[], actualTier: number): number {
  return levels.filter((level) => level.tier < actualTier).length - 1;
}

function assertUnitUpgradeTransition(
  definition: UnitDefinition,
  unit: SavedArmyState,
  upgrades: UnitUpgradeDefinition,
  slotId: 0 | 1,
  requestedIndex: number,
): UnitUpgradeLevel {
  const cursor = laneCursor(unit, slotId);
  if (requestedIndex !== cursor) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "Unit upgrade index does not match stored state.");
  }
  if (slotId === 1 && unit.tier <= definition.startingTier) {
    // UpgradeSlotSpecial.isBought becomes true only after the first promotion. The source
    // rows exist before then, but their presence is not permission to buy them.
    throw new ApiError(ITEM_NOT_ENOUGH_LEVEL, "Special upgrade is locked until the unit is promoted.");
  }

  const levels = laneLevels(upgrades, slotId);
  const maximumCursor = maximumCursorForTier(levels, unit.tier);
  if (cursor < 0 || cursor >= maximumCursor || levels[cursor] === undefined) {
    throw new ApiError(
      ITEM_ALREADY_MAXIMUM_UPGRADE,
      "Unit upgrade lane is complete for the current tier or globally complete.",
    );
  }
  const level = levels[cursor]!;
  if (level.slot !== slotId || level.warBucks < 0 || level.deliverySeconds < 0) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Recovered unit upgrade balancing is invalid.");
  }
  return level;
}

/** The exact sheet returned by TutorialManagerStage5.ChooseUnit. */
export const TUTORIAL_UNIT_NAME = "Google2u.DBUpgradeSlotsAssaulter";

/**
 * Derive the UnitTutorial grant from the Assaulter's first normal-upgrade row.
 *
 * The optional action-161 Parameter is client input, so accepting any other sheet would let a
 * modified APK ask the tutorial to fund a more expensive unit. The value is calculated without
 * consulting mutable player state because an idempotent replay must return the original amounts
 * after the player has consumed the grant and completed the upgrade.
 */
export function tutorialUnitUpgradeFunding(name: unknown): TutorialUpgradeFunding {
  if (name !== TUTORIAL_UNIT_NAME) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "UnitTutorial is restricted to the recovered Assaulter target.");
  }
  const level = UNIT_UPGRADE_CATALOG[TUTORIAL_UNIT_NAME]?.normalLevels[0];
  if (!level || level.slot !== 0 || level.warBucks < 0 || level.deliverySeconds < 0) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "The tutorial unit upgrade row is unavailable.");
  }
  return {
    warBucks: level.warBucks,
    gold: weaponUpgradeInstantPrice(level.deliverySeconds),
  };
}

/**
 * Enforce the server equivalent of TutorialManagerStage5's local start conditions.
 *
 * By stage five the tutorial Assaulter has already reached the backend through the dedicated
 * UpdateEquippedUnits grant. It must be permanently owned, on normal cursor zero, eligible for
 * its first normal transition, and have no unit receipt occupying the shared delivery slot.
 * These checks run only for the first claim; collected replays deliberately skip them.
 */
export function assertTutorialUnitUpgradeEligible(
  state: PlayerProgressionState,
  name: unknown,
): void {
  tutorialUnitUpgradeFunding(name);
  const { definition, upgrades, itemInventory, unit } = unitUpgradeContext(state, TUTORIAL_UNIT_NAME);
  if (unit.boughtIndex !== 0) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "The tutorial unit has already been upgraded.");
  }
  assertUnitUpgradeTransition(definition, unit, upgrades, 0, 0);
  if (activeUnitDelivery(itemInventory.levelManagerData.unitDelivery)) {
    throw new ApiError(ITEM_ALREADY_UPGRADING, "A unit delivery is already active.");
  }
}

/**
 * Start one normal or special unit upgrade from exact recovered price/time data.
 *
 * ArmyScreen sends the lane and current cursor but keeps the optimistic WarBucks debit in
 * RequestBuffer analytics arguments. Therefore the backend must select the cost itself. The
 * one LevelManager.unitDelivery object is shared by every unit and both lanes, so only one
 * receipt may be pending. Discounts, subscription time multipliers, and offer reductions are
 * rejected until the corresponding server entitlements can be proven.
 */
export function startUnitUpgradeState(
  state: PlayerProgressionState,
  now: number,
  payload: UnitUpgradePurchasePayload,
): UnitUpgradeMutationResult {
  const { definition, upgrades, itemInventory, unit } = unitUpgradeContext(state, payload.name);
  const slotId: 0 | 1 = payload.isSpecial ? 1 : 0;
  const level = assertUnitUpgradeTransition(
    definition,
    unit,
    upgrades,
    slotId,
    payload.boughtIndex,
  );
  if (payload.discount !== 0 || payload.deliveryReduce !== 0) {
    throw new ApiError(ITEM_NO_DISCOUNT_FOUND, "Unit upgrade offer is not backed by the server.");
  }
  if (payload.deliveryTime !== level.deliverySeconds || payload.startTime < 0) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Unit upgrade duration or start time does not match balancing.");
  }
  if (activeUnitDelivery(itemInventory.levelManagerData.unitDelivery)) {
    throw new ApiError(ITEM_ALREADY_UPGRADING, "Another unit upgrade is awaiting delivery or activation.");
  }
  if (state.warBucks < level.warBucks) {
    throw new ApiError(ITEM_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks for this unit upgrade.");
  }

  const start = Math.max(0, Math.floor(now));
  itemInventory.levelManagerData.unitDelivery = {
    activationNeeded: true,
    boughtIndex: payload.boughtIndex,
    end: start + level.deliverySeconds,
    itemId: definition.name,
    slotId,
    start,
  };
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    warBucks: state.warBucks - level.warBucks,
    itemInventory,
  };
  return { state: next, itemInventory, unit, definition, deliveryTime: level.deliverySeconds };
}

function matchingUnitDelivery(
  itemInventory: ItemInventoryState,
  unit: SavedArmyState,
  name: string,
  requestedIndex: number,
) {
  const delivery = itemInventory.levelManagerData.unitDelivery;
  if (
    !delivery.activationNeeded
    || delivery.itemId !== name
    || (delivery.slotId !== 0 && delivery.slotId !== 1)
    || delivery.boughtIndex !== requestedIndex
    || laneCursor(unit, delivery.slotId) !== requestedIndex
  ) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "No matching unit upgrade delivery exists.");
  }
  return delivery as typeof delivery & { slotId: 0 | 1 };
}

function finishUnitUpgrade(
  state: PlayerProgressionState,
  itemInventory: ItemInventoryState,
  unit: SavedArmyState,
  definition: UnitDefinition,
  slotId: 0 | 1,
  goldSpent = 0,
): UnitUpgradeMutationResult {
  if (slotId === 0) unit.boughtIndex += 1;
  else unit.specialSlot += 1;
  itemInventory.levelManagerData.unitDelivery = emptyDelivery();
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold - goldSpent,
    itemInventory,
  };
  return { state: next, itemInventory, unit, definition, goldSpent };
}

/** Consume a completed unit receipt only after the server-owned end timestamp. */
export function activateUnitUpgradeState(
  state: PlayerProgressionState,
  now: number,
  payload: UnitUpgradeActivatePayload,
): UnitUpgradeMutationResult {
  const { definition, upgrades, itemInventory, unit } = unitUpgradeContext(state, payload.name);
  const delivery = matchingUnitDelivery(itemInventory, unit, definition.name, payload.boughtIndex);
  assertUnitUpgradeTransition(definition, unit, upgrades, delivery.slotId, payload.boughtIndex);
  if (payload.armyPower < 0) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "ArmyPower must be non-negative.");
  }
  if (Math.floor(now) < delivery.end) {
    throw new ApiError(ITEM_TOO_SOON_TO_ACTIVATE, "Unit upgrade delivery is not finished.");
  }
  return finishUnitUpgrade(state, itemInventory, unit, definition, delivery.slotId);
}

/**
 * Spend Gold to finish the remaining unit delivery and advance the recorded lane atomically.
 *
 * UpgradeSlot.JCDBPPBDHBC has already incremented the local cursor before action 78 is sent.
 * The payload carries the old cursor, while slot identity must come from the server receipt
 * because InstantUnitUpgrade does not include IsSpecial. As with weapons, the accepted price
 * range covers RequestBuffer queue delay but both bounds derive solely from persisted time.
 */
export function instantUnitUpgradeState(
  state: PlayerProgressionState,
  now: number,
  payload: UnitUpgradeInstantPayload,
): UnitUpgradeMutationResult {
  const { definition, upgrades, itemInventory, unit } = unitUpgradeContext(state, payload.name);
  const delivery = matchingUnitDelivery(itemInventory, unit, definition.name, payload.boughtIndex);
  assertUnitUpgradeTransition(definition, unit, upgrades, delivery.slotId, payload.boughtIndex);
  if (payload.discount !== 0) {
    throw new ApiError(ITEM_NO_DISCOUNT_FOUND, "Unit delivery discount is not backed by the server.");
  }
  if (payload.expectedPrice < 0) {
    throw new ApiError(ITEM_NEGATIVE_PRICE_FROM_CLIENT, "ExpectedPrice cannot be negative.");
  }
  if (
    payload.armyPower < 0
    || Math.abs(payload.goldCoefficient - WEAPON_GOLD_COEFFICIENT) > 0.000_001
    || Math.abs(payload.goldExpCoefficient - WEAPON_GOLD_EXP_COEFFICIENT) > 0.000_001
  ) {
    // Both weapon and unit screens call the same client helper and constants rows. Keeping a
    // single formula prevents the two delivery endpoints from drifting at float32 boundaries.
    throw new ApiError(ITEM_PRICE_MISMATCH, "Unit instant-upgrade constants do not match balancing.");
  }

  const remainingAtReceipt = Math.max(0, delivery.end - Math.floor(now));
  const fullDeliveryDuration = Math.max(0, delivery.end - delivery.start);
  const minimumPrice = weaponUpgradeInstantPrice(remainingAtReceipt);
  const maximumPrice = weaponUpgradeInstantPrice(fullDeliveryDuration);
  if (payload.expectedPrice < minimumPrice || payload.expectedPrice > maximumPrice) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Unit instant-upgrade price is outside the receipt range.");
  }
  if (state.gold < payload.expectedPrice) {
    throw new ApiError(ITEM_NOT_ENOUGH_GOLD, "Not enough Gold to finish the unit upgrade.");
  }
  return finishUnitUpgrade(
    state,
    itemInventory,
    unit,
    definition,
    delivery.slotId,
    payload.expectedPrice,
  );
}

/** Return the recovered display-level gate for the unit's next promotion. */
export function unitPromotionRequiredLevel(
  definition: UnitDefinition,
  actualTier: number,
): number {
  // unlockTierLevels stores UNLOCKTIER2 through UNLOCKTIER6. Promoting from tier N to N+1
  // therefore selects N-1. Zeroes before a high-tier unit's starting tier are source data,
  // not missing values, and are never reached by a normally purchased unit.
  return definition.unlockTierLevels[actualTier - 1] ?? 999;
}

/** Fields read by the global NotEnoughLevelForPromote warning handler. */
export function unitPromotionErrorFields(
  state: PlayerProgressionState,
  playerLevel: number,
  requestedName: string,
): Record<string, unknown> {
  const definition = PLAYER_UNIT_CATALOG[requestedName];
  const unit = itemInventoryStateFor(state).levelManagerData.savedArmies[requestedName];
  const actualTier = unit?.tier || definition?.startingTier || 0;
  return {
    playerLevel: String(Math.max(0, Math.floor(playerLevel)) + 1),
    requiredLevel: String(definition ? unitPromotionRequiredLevel(definition, actualTier) : 999),
  };
}

/**
 * Promote a fully upgraded unit to the next source-defined tier.
 *
 * ArmyScreen queues only LevelName and calls UpgradeSlots.PromoteUnit immediately, so all
 * preconditions must be reconstructed from persisted state. The normal cursor (not the
 * special cursor) owns the promotion gate in ArmyLeftPowerDialog. The client compares its
 * one-based GameLevel.displayNumber to UNLOCKTIERn; DatabasePlayer.Level is zero-based, hence
 * the explicit +1 below. Promotion has no currency cost and does not reset either cursor.
 */
export function promoteUnitState(
  state: PlayerProgressionState,
  playerLevel: number,
  payload: UnitPromotePayload,
): UnitInventoryMutationResult {
  const { definition, upgrades, itemInventory, unit } = unitUpgradeContext(state, payload.name);
  if (activeUnitDelivery(itemInventory.levelManagerData.unitDelivery)) {
    throw new ApiError(ITEM_ALREADY_UPGRADING, "A unit delivery must be completed before promotion.");
  }

  // UpgradeSlots.actualTier treats stored zero as STARTINGTIER for legacy/default records.
  const actualTier = unit.tier === 0 ? definition.startingTier : unit.tier;
  if (actualTier < definition.startingTier || actualTier >= 6) {
    throw new ApiError(ITEM_ALREADY_MAXIMUM_UPGRADE, "Unit is already at its maximum tier.");
  }
  const normalTierMaximum = maximumCursorForTier(upgrades.normalLevels, actualTier);
  if (unit.boughtIndex !== normalTierMaximum) {
    throw new ApiError(ITEM_ALREADY_MAXIMUM_UPGRADE, "Normal upgrades are not complete for this tier.");
  }

  const requiredLevel = unitPromotionRequiredLevel(definition, actualTier);
  const displayLevel = Math.max(0, Math.floor(playerLevel)) + 1;
  if (!Number.isInteger(playerLevel) || displayLevel < requiredLevel) {
    throw new ApiError(
      UNIT_NOT_ENOUGH_LEVEL_FOR_PROMOTE,
      `Player display level ${displayLevel} is below promotion requirement ${requiredLevel}.`,
    );
  }

  unit.tier = actualTier + 1;
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    itemInventory,
  };
  return { state: next, itemInventory, unit, definition };
}

/**
 * Consume parts and WarBucks for one immediate elite-slot transition.
 *
 * ArmyScreen uses UpgradeEliteSlot for both the first elite purchase and every later elite
 * level. It optimistically subtracts `upgradePriceParts` and increments eliteSlot before the
 * RequestBuffer is sent. Unlike normal/special upgrades, elite has no delivery receipt: the
 * old relative cursor selects the STARTINGELITE row, and the entire transition commits in one
 * request. `NextUpgradePriceGold` is a misleading historical column name; UpgradeSlotElite
 * reads it as a unit-specific parts requirement, while `NextUpgradePrice` remains WarBucks.
 */
export function upgradeUnitEliteState(
  state: PlayerProgressionState,
  payload: UnitEliteUpgradePayload,
): UnitInventoryMutationResult {
  let context: ReturnType<typeof unitUpgradeContext>;
  try {
    context = unitUpgradeContext(state, payload.name);
  } catch (error) {
    if (error instanceof ApiError) {
      // The action-209 parser has no PriceNotFound/WeaponNotBought case. Mapping ownership and
      // catalog failures to its dedicated IncorrectValuesOnClient result preserves the stock
      // client's relog/rollback behavior instead of returning a code it silently ignores.
      throw new ApiError(UNIT_ELITE_INCORRECT_VALUES, error.message);
    }
    throw error;
  }
  const { definition, upgrades, itemInventory, unit } = context;
  const levels = upgrades.eliteLevels;
  if (definition.startingElite <= 0 || levels.length < 2) {
    throw new ApiError(UNIT_ELITE_INCORRECT_VALUES, "Elite balancing is not available for this unit.");
  }
  if (payload.boughtIndex !== unit.eliteSlot) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "Elite cursor does not match stored state.");
  }

  // UpgradeSlot.isMaxUpgraded is `boughtIndex + 1 >= maxPower`. The row at the current cursor
  // prices the transition into cursor + 1, so the final row is a terminal display/stat row and
  // cannot itself be purchased.
  const level = levels[unit.eliteSlot];
  if (!level || unit.eliteSlot < 0 || unit.eliteSlot >= levels.length - 1) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "Elite slot is already fully upgraded.");
  }
  if (level.sourceIndex !== definition.startingElite + unit.eliteSlot) {
    throw new ApiError(UNIT_ELITE_INCORRECT_VALUES, "Elite source row is not contiguous.");
  }
  if (level.warBucks < 0 || level.parts < 0 || level.armyPower < 0) {
    throw new ApiError(UNIT_ELITE_INCORRECT_VALUES, "Recovered elite balancing is invalid.");
  }
  if (payload.spentWarBucks !== level.warBucks || payload.spentParts !== level.parts) {
    // Offer/discount entitlement has not been recovered. Accepting a smaller client echo here
    // would let a modified APK choose its own price, so only the exact source row is valid.
    throw new ApiError(UNIT_ELITE_INCORRECT_VALUES, "Elite price does not match server balancing.");
  }
  if (unit.parts < level.parts) {
    throw new ApiError(UNIT_ELITE_NOT_ENOUGH_PARTS, "Not enough unit-specific elite parts.");
  }
  if (state.warBucks < level.warBucks) {
    throw new ApiError(ITEM_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks for the elite upgrade.");
  }

  unit.parts -= level.parts;
  unit.eliteSlot += 1;
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    warBucks: state.warBucks - level.warBucks,
    itemInventory,
  };
  return { state: next, itemInventory, unit, definition };
}

/**
 * Fill the current Elite level's missing unit parts by spending server-owned Scraps.
 *
 * The stock client sends only the unit name, then immediately spends Scraps and sets its local
 * part count to `upgradePriceParts`. The server therefore derives the target from the current
 * elite cursor and the generated 4.9.5 row. It never trusts a client-selected quantity. The
 * first Elite level may be filled before it is bought, matching the ArmyLeftBuffDialog button;
 * a permanently owned, non-borrowed unit and a real Elite table are still required.
 */
export function convertScrapsToUnitPartsState(
  state: PlayerProgressionState,
  payload: UnitScrapsToPartsPayload,
): UnitInventoryMutationResult {
  let context: ReturnType<typeof unitUpgradeContext>;
  try {
    context = unitUpgradeContext(state, payload.name);
  } catch (error) {
    if (error instanceof ApiError) {
      throw new ApiError(UNIT_ELITE_NOT_ENOUGH_SCRAPS, error.message);
    }
    throw error;
  }
  const { definition, upgrades, itemInventory, unit } = context;
  const level = upgrades.eliteLevels[unit.eliteSlot];
  if (
    definition.startingElite <= 0
    || !level
    || unit.eliteSlot < 0
    || unit.eliteSlot >= upgrades.eliteLevels.length - 1
    || level.sourceIndex !== definition.startingElite + unit.eliteSlot
  ) {
    throw new ApiError(UNIT_ELITE_NOT_ENOUGH_SCRAPS, "The current Elite part target is unavailable.");
  }

  const missingParts = level.parts - unit.parts;
  const scrapsToSpend = missingParts * UNIT_SCRAPS_TO_PART_UPGRADE_RATE;
  if (
    missingParts <= 0
    || !Number.isSafeInteger(scrapsToSpend)
    || scrapsToSpend <= 0
    || state.scraps < scrapsToSpend
  ) {
    throw new ApiError(UNIT_ELITE_NOT_ENOUGH_SCRAPS, "Not enough Scraps for the current Elite part target.");
  }

  unit.parts = level.parts;
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    scraps: state.scraps - scrapsToSpend,
    itemInventory,
  };
  return { state: next, itemInventory, unit, definition };
}

/**
 * Sell every stored part for one already-bought Elite slot at the recovered 5:1 rate.
 *
 * ConvertToScrapsDialog optimistically clears the unit's complete part balance and credits
 * Scraps before transport. Both echoed values must therefore equal the last committed unit
 * state exactly. Partial sales, zero-value calls, stale dialogs, and fabricated rewards use
 * the client's dedicated IncorrectPartsAmount response and cause a full player-data reload.
 */
export function convertUnitPartsToScrapsState(
  state: PlayerProgressionState,
  payload: UnitPartsToScrapsPayload,
): UnitInventoryMutationResult {
  let context: ReturnType<typeof unitUpgradeContext>;
  try {
    context = unitUpgradeContext(state, payload.name);
  } catch (error) {
    if (error instanceof ApiError) {
      throw new ApiError(UNIT_ELITE_SLOT_LOCKED, error.message);
    }
    throw error;
  }
  const { definition, upgrades, itemInventory, unit } = context;
  if (definition.startingElite <= 0 || upgrades.eliteLevels.length < 2 || unit.eliteSlot <= 0) {
    // FPPPLPHDBMO exposes the sell button only after UpgradeSlotElite.isBought is true.
    throw new ApiError(UNIT_ELITE_SLOT_LOCKED, "The unit's Elite slot has not been bought.");
  }

  const authoritativeReward = unit.parts * UNIT_PART_TO_SCRAPS_SELL_RATE;
  if (
    unit.parts <= 0
    || payload.partsToConvert !== unit.parts
    || payload.scraps !== authoritativeReward
    || !Number.isSafeInteger(authoritativeReward)
  ) {
    throw new ApiError(
      UNIT_ELITE_INCORRECT_PARTS_AMOUNT,
      "Converted parts or Scraps do not match the server-owned unit state.",
    );
  }

  unit.parts = 0;
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    scraps: state.scraps + authoritativeReward,
    itemInventory,
  };
  return { state: next, itemInventory, unit, definition };
}

function clampCursor(cursor: number, length: number): number {
  return Math.max(0, Math.min(Math.trunc(cursor), length - 1));
}

/** Reproduce UpgradeSlots.GetArmyPower's float32 addition for one persisted unit. */
function unitArmyPowerValue(
  definition: UnitDefinition,
  upgrades: UnitUpgradeDefinition,
  unit: SavedArmyState,
): number {
  if (upgrades.normalLevels.length < 1 || upgrades.specialLevels.length < 1 || upgrades.eliteLevels.length < 1) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Unit ArmyPower rows are incomplete.");
  }
  const normal = Math.fround(upgrades.normalLevels[clampCursor(unit.boughtIndex, upgrades.normalLevels.length)]!.armyPower);
  const actualTier = unit.tier === 0 ? definition.startingTier : unit.tier;
  const special = actualTier <= definition.startingTier
    ? 0
    : Math.fround(upgrades.specialLevels[clampCursor(unit.specialSlot, upgrades.specialLevels.length)]!.armyPower);
  const elite = unit.eliteSlot <= 0
    ? 0
    : Math.fround(upgrades.eliteLevels[clampCursor(unit.eliteSlot, upgrades.eliteLevels.length)]!.armyPower);

  // C# evaluates float additions after every operator. Math.fround at both boundaries avoids
  // JavaScript's double precision changing a half-step before Unity's FloorToInt(value + .5f).
  return Math.fround(Math.fround(normal + special) + elite);
}

/** Source-authoritative floating ArmyPower for one owned unit, excluding weapon/rank power. */
export function unitArmyPower(state: PlayerProgressionState, name: string): number {
  const definition = PLAYER_UNIT_CATALOG[name];
  const upgrades = UNIT_UPGRADE_CATALOG[name];
  const unit = itemInventoryStateFor(state).levelManagerData.savedArmies[name];
  if (!definition || !upgrades || !unit?.bought) return 0;
  return unitArmyPowerValue(definition, upgrades, unit);
}

/**
 * Reproduce LevelManager.unitPower for equipped permanent units and the exact active rental.
 *
 * LevelManager sums UpgradeSlots.armyPower as float32 in behaviour order and rounds once with
 * FloorToInt(total + 0.5f). Weapon and rank power are intentionally outside this helper; those
 * independent source tables must be recovered before UpdateArmyPower can replace the current
 * fail-closed client-echo boundary with a complete server-owned total.
 */
export function equippedUnitPower(state: PlayerProgressionState, now?: number): number {
  const saved = itemInventoryStateFor(state).levelManagerData.savedArmies;
  let total = Math.fround(0);
  for (const definition of Object.values(PLAYER_UNIT_CATALOG).sort((a, b) => a.index - b.index)) {
    const unit = saved[definition.name];
    const upgrades = UNIT_UPGRADE_CATALOG[definition.name];
    if (!unit?.bought || !unit.equipped || !upgrades) continue;
    if (unit.borrowed && !(
      Number.isInteger(now)
      && state.rental?.status === "trial"
      && state.rental.type === 0
      && state.rental.id === definition.name
      && state.rental.trialExpiresAt > now!
    )) continue;
    total = Math.fround(total + unitArmyPowerValue(definition, upgrades, unit));
  }
  return Math.floor(Math.fround(total + Math.fround(0.5)));
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
 * table rows remain rejected. Unit ArmyPower is now source-authoritative, but the request's
 * total also contains equipped-weapon and rank rows. The client echo is therefore not stored
 * until those remaining two components can be independently reproduced by the server.
 */
export function updateEquippedUnitsState(
  state: PlayerProgressionState,
  payload: UnitEquipPayload,
  now?: number,
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
    const activeRental = Boolean(
      unit?.borrowed
        && Number.isInteger(now)
        && state.rental?.status === "trial"
        && state.rental.type === 0
        && state.rental.id === name
        && state.rental.trialExpiresAt > now!,
    );
    if (!unit?.bought || (unit.borrowed && !activeRental)) {
      throw new ApiError(UNIT_CANT_EQUIP, "Only permanent units or the active rental trial can be equipped.");
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
  const persistedArmies = state.itemInventory?.levelManagerData.savedArmies ?? {};
  const persistedNames = Object.keys(persistedArmies);
  const derivedNames = Object.keys(savedArmies);
  const unchanged = persistedNames.length === derivedNames.length && derivedNames.every((name) => {
    const left = persistedArmies[name];
    const right = savedArmies[name];
    return Boolean(
      left
      && right
      && left.bought === right.bought
      && left.boughtIndex === right.boughtIndex
      && left.specialSlot === right.specialSlot
      && left.showed === right.showed
      && left.tier === right.tier
      && left.borrowed === right.borrowed
      && left.wasEquipped === right.wasEquipped
      && left.equipped === right.equipped
      && left.eliteSlot === right.eliteSlot
      && left.parts === right.parts,
    );
  });
  if (unchanged) {
    // UpdateEquippedUnits sends the full selected-unit dictionary and has no independent UUID.
    // Validate the entire reconstructed loadout first, then preserve exact state when every
    // SavedArmy field already matches. This also keeps a repeated tutorial-unit grant harmless;
    // a missing tutorial row still differs and is persisted on its first valid request.
    return { state, itemInventory };
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

export interface MissionElitePartsRewardResult {
  state: PlayerProgressionState;
  itemInventory: ItemInventoryState;
  unitName: string;
  parts: number;
}

/**
 * Choose the unit shown by DailyMissionsData.heroicUnitReward for a fresh Heroic chain.
 *
 * The client proves that this value is server-selected, but neither recovered APK contains
 * the retired production weighting. Prefer bought permanent units so the reward is immediately
 * useful; if an account has not persisted a unit yet, fall back to concrete LevelManager units
 * currently unlocked by the player's zero-based level. Selection is cryptographic and the
 * chosen name is persisted with the chain, so reconnects and the eventual fifth mission use
 * one stable target. Helpers and rows without a LevelManager behaviour never enter this pool.
 */
export function selectMissionElitePartUnit(
  state: PlayerProgressionState,
  playerLevelIndex: number,
  choose: (upperBound: number) => number = (upperBound) => randomInt(upperBound),
): string {
  const saved = itemInventoryStateFor(state).levelManagerData.savedArmies;
  const bought = Object.keys(saved)
    .filter((name) => saved[name]?.bought && PLAYER_UNIT_CATALOG[name])
    .sort();
  const unlocked = Object.values(PLAYER_UNIT_CATALOG)
    .filter((definition) => definition.canBuyLevelIndex <= Math.max(0, Math.floor(playerLevelIndex)))
    .map((definition) => definition.name)
    .sort();
  const candidates = bought.length > 0 ? bought : unlocked;
  if (candidates.length === 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Heroic elite-parts reward pool is empty.");
  }
  const selected = choose(candidates.length);
  if (!Number.isInteger(selected) || selected < 0 || selected >= candidates.length) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Heroic elite-parts selector is invalid.");
  }
  return candidates[selected]!;
}

/**
 * Add unit-specific Heroic parts without incrementing progression revision.
 *
 * The enclosing mission settlement owns the revision and receipt. Creating the normal saved
 * row for an unlocked-but-not-yet-bought unit is intentional: LevelManager loads `parts` from
 * SavedArmySlots even before purchase, preserving the reward until that unit becomes owned.
 */
export function grantMissionElitePartsState(
  state: PlayerProgressionState,
  unitName: string,
  parts: number,
): MissionElitePartsRewardResult {
  const definition = PLAYER_UNIT_CATALOG[unitName];
  if (!definition || !Number.isSafeInteger(parts) || parts <= 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Heroic elite-parts reward is invalid.");
  }
  const itemInventory = itemInventoryStateFor(state);
  const unit = itemInventory.levelManagerData.savedArmies[unitName] ?? emptyUnit(definition);
  if (!Number.isSafeInteger(unit.parts) || unit.parts < 0 || unit.parts > Number.MAX_SAFE_INTEGER - parts) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Heroic unit parts overflowed.");
  }
  itemInventory.levelManagerData.savedArmies[unitName] = {
    ...unit,
    parts: unit.parts + parts,
  };
  return {
    state: { ...state, itemInventory },
    itemInventory,
    unitName,
    parts,
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
