import { ApiError } from "../apiErrors";
import type {
  ItemDeliveryState,
  ItemInventoryState,
  LevelManagerDataState,
  PlayerInventoryDataState,
  PlayerProgressionState,
  SavedWeaponState,
} from "../db";
import generatedWeaponCatalog from "../data/weaponCatalog.generated.json";
import {
  WEAPON_BLACK_MARKET_PRICES,
  WEAPON_UPGRADE_CATALOG,
} from "../data/weaponUpgradeCatalog.generated";
import { subscriptionUpgradeDeliverySeconds } from "./subscriptionBenefitService";
import { hasActiveRentalItem } from "./rentalEntitlementService";
import {
  hasActiveBlackMarketOffer,
  validatedBlackMarketOfferState,
} from "./blackMarketEntitlementService";
import {
  exactRequestIntegerText,
  exactRequestJsonFiniteNumber,
  exactRequestJsonInteger,
} from "./requestJsonNumberService";

/**
 * Recovered weapon ownership and loadout logic.
 *
 * The Unity client changes its local inventory before sending BuyWeapon or EquipWeapon. The
 * server must therefore both validate the requested transition and return a complete rollback
 * snapshot on failure. Catalog name, LevelManager index, category mask, unlock threshold,
 * and price all come from recovered 4.9.5 resources; request values are assertions and never
 * become balancing authority.
 *
 * State helpers clone every nested inventory object before mutation. A rejected request can
 * then safely build recovery fields from the last successful state in the same RequestBuffer,
 * while the outer progression transaction commits wallet and inventory changes atomically.
 * Weapon upgrade delivery is also server-owned: the persisted receipt is created, finished,
 * and consumed only by the recovered three-action lifecycle. Offer-backed discounts remain
 * closed until the backend can prove the corresponding entitlement.
 */

// Exact IJEAJGCCHEF values handled by the stock RequestBuffer result parser.
export const ITEM_NOT_ENOUGH_WARBUCKS = 100;
export const ITEM_NOT_ENOUGH_LEVEL = 101;
export const ITEM_ALREADY_MAXIMUM_UPGRADE = 102;
export const ITEM_NOT_ENOUGH_GOLD = 103;
export const ITEM_WRONG_INDEX_TO_ACTIVATE = 104;
export const ITEM_ALREADY_UPGRADING = 105;
export const ITEM_TOO_SOON_TO_ACTIVATE = 106;
export const ITEM_WEAPON_NOT_BOUGHT = 110;
export const ITEM_PRICE_NOT_FOUND = 113;
export const ITEM_PRICE_MISMATCH = 114;
export const ITEM_NEGATIVE_PRICE_FROM_CLIENT = 7002;
export const ITEM_NO_DISCOUNT_FOUND = 13601;

// Exact 4.9.5 Constants rows consumed by MEJMLNDFDBP.BCEGIAODLCL. The client
// echoes both values in InstantWeaponUpgrade, but the server always calculates
// premium cost from these recovered constants and its own delivery receipt.
export const WEAPON_GOLD_COEFFICIENT = 0.6325;
export const WEAPON_GOLD_EXP_COEFFICIENT = -0.175;

export interface WeaponDefinition {
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
 * Construct one row without repeating values that are identical across the recovered shop.
 * Every enabled 4.9.5 `PURCHASABLE: shop` row has `DELIVERTIME=0`, so a successful purchase
 * grants ownership immediately. This is important for WarBucks rows too: inventing a delivery
 * timer would disagree with the client sheet even though older code still contains delivery UI.
 */
function weapon(
  name: string,
  index: number,
  category: number,
  canBuyLevelIndex: number,
  unlockLevel: number,
  warBucks: number,
  gold: number,
  starterOwned = false,
): WeaponDefinition {
  return {
    name,
    index,
    category,
    canBuyLevelIndex,
    unlockLevel,
    warBucks,
    gold,
    deliverySeconds: 0,
    starterOwned,
  };
}

/**
 * Authoritative weapon rows recovered end-to-end from the 4.9.5 MainScene.
 *
 * Prices come from the Google2u `WeaponUpgrades.Rows` component by XOR-decoding each
 * ObscuredInt's `currentCryptoKey` and `hiddenValue`. Indexes do not follow that sheet's row
 * order: they come from the separate `LevelManager.weaponLevelsSetups` reference array. The
 * four `starterOwned` rows are the choices created by `PlayerInventory.Init`; their sheet price
 * remains documented here but is never charged because the purchase path rejects starter rows.
 *
 * The scene contains nine additional shop-priced Pulse Rifle rows whose corresponding
 * LevelManager entries are null (Grade1-8 at indexes 176-191 and PR9 at 194). They are excluded
 * deliberately: accepting their price would create an owned item that the recovered client
 * cannot resolve or equip. Unknown and unresolved rows therefore continue to fail closed.
 */
const RECOVERED_WEAPON_ROWS: readonly WeaponDefinition[] = [
  weapon("Google2u.AssaultRifle_AK47", 1, 1, 0, 1, 0, 100, true),
  weapon("Google2u.AssaultRifle_Famas", 2, 1, 13, 17, 0, 949),
  weapon("Google2u.AssaultRifle_G36", 29, 1, 28, 32, 0, 4_199),
  weapon("Google2u.AssaultRifle_M16", 0, 1, 5, 9, 0, 269),
  weapon("Google2u.AssaultRifle_QBZ95", 26, 1, 9, 13, 0, 799),
  weapon("Google2u.AssaultRifle_SteyrAUG", 32, 1, 19, 23, 0, 1_499),
  weapon("Google2u.Bazooka_FGM", 35, 16, 24, 28, 0, 2_479),
  weapon("Google2u.Bazooka_HMV", 36, 16, 11, 15, 179_999, 0),
  weapon("Google2u.Bazooka_RPG7", 4, 16, 0, 4, 0, 89),
  weapon("Google2u.Grenade_FLASH", 8, 64, 7, 11, 0, 199),
  weapon("Google2u.Grenade_FRAG", 6, 64, 0, 2, 999, 0, true),
  weapon("Google2u.Grenade_POISON", 9, 64, 14, 18, 239_999, 0),
  weapon("Google2u.Grenade_SMOKE", 7, 64, 20, 24, 0, 2_499),
  weapon("Google2u.GrenadeLauncher_M320", 25, 512, 3, 7, 0, 139),
  weapon("Google2u.LMG_M249", 18, 4, 7, 11, 199_999, 0),
  weapon("Google2u.LMG_M60", 34, 4, 31, 35, 0, 4_499),
  weapon("Google2u.LMG_MG4", 19, 4, 23, 27, 0, 2_499),
  weapon("Google2u.LMG_Minigun", 21, 256, 1, 5, 0, 199),
  weapon("Google2u.LMG_PKMachinegun", 17, 4, 1, 5, 14_999, 0),
  weapon("Google2u.LMG_SA80", 20, 4, 15, 19, 1_599_999, 0),
  weapon("Google2u.Pistol_Berreta", 14, 128, 9, 13, 0, 119),
  weapon("Google2u.Pistol_DesertEagle", 12, 128, 29, 33, 6_349_999, 0),
  weapon("Google2u.Pistol_M1911", 15, 128, 16, 20, 203_799, 0),
  weapon("Google2u.Pistol_Magnum357", 37, 128, 21, 25, 0, 699),
  weapon("Google2u.Pistol_Remmington51", 13, 128, 0, 1, 0, 0, true),
  weapon("Google2u.Shotgun_Benelli", 27, 32, 2, 6, 8_999, 0),
  weapon("Google2u.Shotgun_Saiga", 5, 32, 18, 22, 0, 1_599),
  weapon("Google2u.Shotgun_SPAS", 38, 32, 10, 14, 0, 429),
  weapon("Google2u.Shotgun_Striker", 31, 32, 26, 30, 0, 2_589),
  weapon("Google2u.SMG_CPW", 24, 2, 11, 15, 619_999, 0),
  weapon("Google2u.SMG_MP5", 22, 2, 3, 7, 59_999, 0),
  weapon("Google2u.SMG_MP7", 23, 2, 21, 25, 0, 1_999),
  weapon("Google2u.SMG_P90", 33, 2, 25, 29, 0, 3_999),
  weapon("Google2u.SMG_UMP45", 10, 2, 17, 21, 0, 1_129),
  weapon("Google2u.SniperRifle_AWMF", 28, 8, 14, 18, 489_999, 0),
  weapon("Google2u.SniperRifle_Dragunov", 16, 8, 6, 10, 59_999, 0),
  weapon("Google2u.SniperRifle_M110", 11, 8, 22, 26, 0, 1_999),
  weapon("Google2u.SniperRifle_M24", 3, 8, 0, 1, 0, 100, true),
  weapon("Google2u.SniperRifle_M90", 30, 8, 29, 33, 0, 3_139),
  weapon("Google2u.Grenade_Molotov", 39, 64, 27, 31, 0, 2_999),
  weapon("Google2u.Bazooka_Panzerfaust", 40, 16, 17, 21, 0, 619),
  weapon("Google2u.Bazooka_M202", 41, 16, 31, 35, 0, 3_099),
  weapon("Google2u.AssaultRifle_AKS47U", 43, 1, 35, 39, 0, 5_299),
  weapon("Google2u.LMG_M249Elite", 47, 4, 37, 41, 0, 5_499),
  weapon("Google2u.Shotgun_Blackhand", 49, 32, 39, 43, 0, 3_999),
  weapon("Google2u.Shotgun_SawnOff", 50, 32, 21, 25, 0, 1_799),
  weapon("Google2u.Pistol_Jester", 51, 128, 38, 42, 0, 3_499),
  weapon("Google2u.Grenade_M84", 52, 64, 34, 38, 0, 3_499),
  weapon("Google2u.Shotgun_AA12", 54, 32, 32, 36, 0, 3_399),
  weapon("Google2u.SMG_Vector", 55, 2, 33, 37, 0, 4_999),
  weapon("Google2u.Bazooka_Hater", 57, 16, 36, 40, 0, 3_499),
  weapon("Google2u.SniperRifle_MSR", 58, 8, 35, 39, 0, 3_699),
  weapon("Google2u.AssaultRifle_AK47Elite", 64, 1, 3, 7, 0, 139),
  weapon("Google2u.LMG_PKMachinegunElite", 65, 4, 1, 5, 0, 99),
  weapon("Google2u.GrenadeLauncher_DP64", 124, 512, 15, 19, 0, 499),
  weapon("Google2u.GrenadeLauncher_M79", 125, 512, 8, 12, 0, 249),
  weapon("Google2u.GrenadeLauncher_MGL", 126, 512, 23, 27, 0, 2_469),
  weapon("Google2u.GrenadeLauncher_QLB06", 127, 512, 37, 41, 0, 3_599),
  weapon("Google2u.GrenadeLauncher_QLZ87", 128, 512, 30, 34, 0, 3_049),
  weapon("Google2u.AssaultRifle_XM8", 142, 1, 3, 44, 0, 5_899),
  weapon("Google2u.SMG_Apollo", 135, 2, 45, 49, 0, 6_699),
  weapon("Google2u.LMG_StarHammer", 136, 4, 43, 47, 0, 6_299),
  weapon("Google2u.SniperRifle_3Eyes", 137, 8, 42, 46, 0, 5_499),
  weapon("Google2u.Shotgun_DP12", 138, 32, 46, 50, 0, 4_699),
  weapon("Google2u.Grenade_Doombringer", 139, 64, 41, 45, 0, 3_999),
  weapon("Google2u.GrenadeLauncher_XM25", 140, 512, 44, 48, 0, 4_599),
  weapon("Google2u.Bazooka_Juggernaut", 141, 16, 43, 47, 0, 4_399),
  weapon("Google2u.Pistol_P320", 134, 128, 45, 49, 18_999_999, 0),
  weapon("Google2u.LMG_T8", 159, 4, 50, 54, 0, 9_499),
  weapon("Google2u.SniperRifle_SRT8", 160, 8, 53, 57, 0, 7_199),
  weapon("Google2u.AssaultRifle_ART8", 161, 1, 47, 51, 0, 8_999),
  weapon("Google2u.SMG_ST8", 162, 2, 52, 56, 0, 9_999),
  weapon("Google2u.Grenade_GT8", 163, 64, 47, 51, 0, 4_999),
  weapon("Google2u.GrenadeLauncher_GLT8", 164, 512, 48, 52, 0, 5_199),
  weapon("Google2u.Bazooka_RLT8", 165, 16, 51, 55, 0, 5_499),
  weapon("Google2u.Shotgun_SGT8", 166, 32, 49, 53, 0, 5_999),
  weapon("Google2u.AssaultRifle_ART9", 192, 1, 55, 59, 0, 10_499),
  weapon("Google2u.GrenadeLauncher_GLT9", 193, 512, 56, 60, 0, 5_999),
  weapon("Google2u.SMG_ST9", 198, 2, 57, 61, 0, 10_999),
  weapon("Google2u.Grenade_GT9", 199, 64, 58, 62, 0, 5_999),
  weapon("Google2u.Shotgun_SGT9", 200, 32, 61, 65, 0, 7_499),
  weapon("Google2u.LMG_T9", 201, 4, 60, 64, 0, 11_499),
  weapon("Google2u.Bazooka_RLT9", 202, 16, 60, 64, 0, 6_999),
  weapon("Google2u.SniperRifle_SRT9", 203, 8, 62, 66, 0, 7_999),
];

export const WEAPON_CATALOG: Readonly<Record<string, WeaponDefinition>> = Object.freeze(
  Object.fromEntries(RECOVERED_WEAPON_ROWS.map((definition) => [definition.name, definition])),
);

/**
 * Dedicated `PURCHASABLE: blackmarket` LevelManager setups recovered by the same catalog
 * extractor as normal shop weapons. They are separate runtime types and indexes; treating a
 * Black Market offer as a discount on WEAPON_CATALOG would grant the wrong client object.
 */
export const BLACK_MARKET_WEAPON_CATALOG: Readonly<Record<string, WeaponDefinition>> = Object.freeze(
  Object.fromEntries(generatedWeaponCatalog.blackMarketCatalog.map((definition) => [
    definition.name,
    Object.freeze({ ...definition, starterOwned: false }),
  ])),
);

/** Resolve either authoritative weapon family for shared equip/upgrade/power code. */
export function weaponDefinitionFor(name: string): WeaponDefinition | undefined {
  return WEAPON_CATALOG[name] ?? BLACK_MARKET_WEAPON_CATALOG[name];
}

// These are the four category masks serialized on PlayerInventory.inventorySlots in the
// 4.9.5 MainScene. A weapon category must be wholly contained in its destination mask.
const WEAPON_SLOT_MASKS = [263, 1064, 592, 128] as const;

export interface WeaponPurchasePayload {
  /** Recovered Google2u runtime type name used as the catalog key. */
  name: string;
  /** Client-echoed soft-currency price; it must equal the server catalog value. */
  warBucks: number;
  /** Client-echoed premium-currency price; it must equal the server catalog value. */
  gold: number;
  /** Display unlock level echoed by WeaponScreen, not the authoritative level gate. */
  unlockLevel: number;
  /** Client purchase timestamp retained for protocol validation; it does not order writes. */
  startTime: number;
  /** Offer discount percentage. Only zero is accepted until server offers are recovered. */
  discount: number;
}

export interface WeaponEquipPayload {
  /** Recovered Google2u runtime type name of the weapon being equipped. */
  name: string;
  /** Position in LevelManager.weaponLevelsSetups, encoded as a string by the stock client. */
  index: number;
  /** Destination PlayerInventory slot, validated against its recovered category mask. */
  slotIndex: number;
  /** Client-computed display value; checked for shape but never persisted as authority. */
  armyPower: number;
  /** Must match the special feature already stored on the owned weapon record. */
  specialFeature: number;
}

export interface WeaponUpgradePurchasePayload {
  /** Google2u component type returned by WeaponLevelsSetup.DHHKOKKDDDO. */
  name: string;
  /** Current saved upgrade index before the requested transition starts. */
  boughtIndex: number;
  /** Client server-clock snapshot; retained as a protocol assertion only. */
  startTime: number;
  /** Upgrade-price offer discount. Unsupported discounts fail closed. */
  discount: number;
  /** Client-reduced duration, checked against the recovered source row. */
  deliveryTime: number;
  /** Offer-derived number of seconds removed from the source duration. */
  deliveryReduce: number;
}

export interface WeaponUpgradeInstantPayload {
  name: string;
  boughtIndex: number;
  expectedPrice: number;
  armyPower: number;
  goldCoefficient: number;
  goldExpCoefficient: number;
  discount: number;
}

export interface WeaponUpgradeActivatePayload {
  name: string;
  boughtIndex: number;
  armyPower: number;
}

/** Payload of the separate zero-delivery purchase acknowledgement (action 128). */
export interface WeaponActivatePayload {
  name: string;
}

export interface WeaponPurchaseInstantPayload {
  name: string;
  expectedPrice: number;
  goldCoefficient: number;
  goldExpCoefficient: number;
}

export interface ItemInventoryMutationResult {
  state: PlayerProgressionState;
  itemInventory: ItemInventoryState;
  weapon: SavedWeaponState;
  definition: WeaponDefinition;
}

export interface WeaponUpgradeMutationResult extends ItemInventoryMutationResult {
  /** Present only when BuyWeaponUpgrade creates a new server delivery receipt. */
  deliveryTime?: number;
  /** Present only when InstantWeaponUpgrade debits the remaining delivery cost. */
  goldSpent?: number;
}

function emptyDelivery(): ItemDeliveryState {
  return { activationNeeded: false, boughtIndex: 0, end: 0, itemId: "", slotId: 0, start: 0 };
}

function ownedWeapon(boughtIndex = 0, specialFeature = 0): SavedWeaponState {
  return { bought: true, boughtIndex, showed: true, borrowed: false, specialFeature };
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
    warBucks: exactRequestJsonInteger(data.Warbucks, "Warbucks", ITEM_PRICE_MISMATCH),
    gold: exactRequestJsonInteger(data.Gold, "Gold", ITEM_PRICE_MISMATCH),
    unlockLevel: exactRequestJsonInteger(data.UnlockLevel, "UnlockLevel", ITEM_PRICE_MISMATCH),
    startTime: exactRequestJsonInteger(data.StartTime, "StartTime", ITEM_PRICE_MISMATCH),
    discount: exactRequestJsonInteger(data.discount, "discount", ITEM_PRICE_MISMATCH),
  };
}

/** Decode the exact `{ LevelName }` dictionary queued by WeaponScreen.GFDDLFMLJMJ. */
export function parseWeaponActivateData(value: string): WeaponActivatePayload {
  const data = parseObjectJson(value);
  return { name: boundedName(data.LevelName) };
}

/** Decode WeaponScreen.HDBDPLBHNKD's zero-delivery action-126 dictionary. */
export function parseWeaponPurchaseInstantData(value: string): WeaponPurchaseInstantPayload {
  const data = parseObjectJson(value);
  return {
    name: boundedName(data.LevelName),
    expectedPrice: exactRequestJsonInteger(data.ExpectedPrice, "ExpectedPrice", ITEM_PRICE_MISMATCH),
    goldCoefficient: exactRequestJsonFiniteNumber(data.GoldCoefficient, "GoldCoefficient", ITEM_PRICE_MISMATCH),
    goldExpCoefficient: exactRequestJsonFiniteNumber(data.GoldExpCoefficient, "GoldExpCoefficient", ITEM_PRICE_MISMATCH),
  };
}

/** Decode the exact dictionary queued by WeaponScreen.EquipWeapon. */
export function parseWeaponEquipData(value: string): WeaponEquipPayload {
  const data = parseObjectJson(value);
  return {
    // Index is the only recovered weapon integer explicitly converted to text by Unity.
    index: exactRequestIntegerText(data.Index, "Index", ITEM_PRICE_MISMATCH),
    name: boundedName(data.Name),
    slotIndex: exactRequestJsonInteger(data.SlotIndex, "SlotIndex", ITEM_PRICE_MISMATCH),
    armyPower: exactRequestJsonInteger(data.ArmyPower, "ArmyPower", ITEM_PRICE_MISMATCH),
    specialFeature: exactRequestJsonInteger(data.SpecialFeature, "SpecialFeature", ITEM_PRICE_MISMATCH),
  };
}

/** Decode the exact dictionary queued by WeaponScreen.IEFLIEHLBNA. */
export function parseWeaponUpgradePurchaseData(value: string): WeaponUpgradePurchasePayload {
  const data = parseObjectJson(value);
  return {
    name: boundedName(data.LevelName),
    boughtIndex: exactRequestJsonInteger(data.BoughtIndex, "BoughtIndex", ITEM_PRICE_MISMATCH),
    startTime: exactRequestJsonInteger(data.StartTime, "StartTime", ITEM_PRICE_MISMATCH),
    discount: exactRequestJsonInteger(data.discount, "discount", ITEM_PRICE_MISMATCH),
    deliveryTime: exactRequestJsonInteger(data.DeliveryTime, "DeliveryTime", ITEM_PRICE_MISMATCH),
    deliveryReduce: exactRequestJsonInteger(data.deliveryReduce, "deliveryReduce", ITEM_PRICE_MISMATCH),
  };
}

/** Decode the exact dictionary queued after WeaponScreen optimistically fast-activates. */
export function parseWeaponUpgradeInstantData(value: string): WeaponUpgradeInstantPayload {
  const data = parseObjectJson(value);
  return {
    name: boundedName(data.LevelName),
    boughtIndex: exactRequestJsonInteger(data.BoughtIndex, "BoughtIndex", ITEM_PRICE_MISMATCH),
    expectedPrice: exactRequestJsonInteger(data.ExpectedPrice, "ExpectedPrice", ITEM_PRICE_MISMATCH),
    armyPower: exactRequestJsonInteger(data.ArmyPower, "ArmyPower", ITEM_PRICE_MISMATCH),
    goldCoefficient: exactRequestJsonFiniteNumber(data.GoldCoefficient, "GoldCoefficient", ITEM_PRICE_MISMATCH),
    goldExpCoefficient: exactRequestJsonFiniteNumber(data.GoldExpCoefficient, "GoldExpCoefficient", ITEM_PRICE_MISMATCH),
    discount: exactRequestJsonInteger(data.discount, "discount", ITEM_PRICE_MISMATCH),
  };
}

/** Decode the exact dictionary queued after WeaponScreen optimistically activates delivery. */
export function parseWeaponUpgradeActivateData(value: string): WeaponUpgradeActivatePayload {
  const data = parseObjectJson(value);
  return {
    name: boundedName(data.LevelName),
    boughtIndex: exactRequestJsonInteger(data.BoughtIndex, "BoughtIndex", ITEM_PRICE_MISMATCH),
    armyPower: exactRequestJsonInteger(data.ArmyPower, "ArmyPower", ITEM_PRICE_MISMATCH),
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
 * Persist the one-time "new weapon" badge acknowledgement sent by WeaponScreen.WasShown.
 *
 * The client queues only the exact runtime weapon name after the player opens an unlocked
 * weapon. This action never grants ownership, changes a level, or equips a slot. A sparse
 * non-owned SavedWeapon row is intentional: LevelManager overlays that row onto its scene
 * definition during the next login and therefore stops showing the badge without treating
 * the weapon as purchased. Repeated acknowledgements are true no-ops so a direct retry or a
 * later RequestBuffer cannot create needless progression revisions.
 */
export function markWeaponShownState(
  state: PlayerProgressionState,
  playerLevel: number,
  name: string,
): ItemInventoryMutationResult {
  const definition = weaponDefinitionFor(name);
  if (!definition) throw new ApiError(ITEM_PRICE_NOT_FOUND, "Weapon was not found.");
  if (!Number.isInteger(playerLevel) || playerLevel < definition.canBuyLevelIndex) {
    throw new ApiError(ITEM_NOT_ENOUGH_LEVEL, "Weapon is still locked for this player.");
  }
  const itemInventory = itemInventoryStateFor(state);
  const current = itemInventory.levelManagerData.savedWeapons[definition.name];
  if (current?.showed) {
    return { state, itemInventory, weapon: current, definition };
  }
  const weapon: SavedWeaponState = {
    ...(current ?? {
      bought: false,
      boughtIndex: 0,
      showed: false,
      borrowed: false,
      specialFeature: 0,
    }),
    showed: true,
  };
  itemInventory.levelManagerData.savedWeapons[definition.name] = weapon;
  return {
    state: { ...state, revision: state.revision + 1, itemInventory },
    itemInventory,
    weapon,
    definition,
  };
}

/**
 * Atomically debit a verified 4.9.5 shop or active Black Market price and grant one weapon.
 *
 * The request's price, unlock level, start time, and discount are assertions only. The
 * server selects the catalog row by name and recalculates every authoritative value. A
 * A Black Market purchase is recognized only when the authenticated progression contains a
 * matching, unexpired offer and the request exactly echoes that offer level's scene-extracted
 * WEAPONPRICE with zero WarBucks. The request does not contain level/special fields, so those
 * values always come from stored offer authority. Non-zero OfferManager discounts remain
 * closed because their separate entitlement source has not been reconstructed.
 */
export function purchaseWeaponState(
  state: PlayerProgressionState,
  playerLevel: number,
  payload: WeaponPurchasePayload,
  now?: number,
): ItemInventoryMutationResult {
  const shopDefinition = WEAPON_CATALOG[payload.name];
  const blackMarketDefinition = BLACK_MARKET_WEAPON_CATALOG[payload.name];
  const definition = shopDefinition ?? blackMarketDefinition;
  if (!definition || definition.starterOwned) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Weapon is not available for this purchase path.");
  }
  if (payload.discount !== 0) {
    throw new ApiError(13601, "Weapon discount is not backed by an active server offer.");
  }
  const blackMarket = validatedBlackMarketOfferState(state.blackMarket);
  const offered = blackMarket?.currentOffers.find((offer) => offer.weaponId === definition.name);
  const blackMarketPrices = WEAPON_BLACK_MARKET_PRICES[definition.name];
  const blackMarketGold = offered && blackMarketPrices?.[offered.level];
  const isBlackMarketPurchase = Boolean(
    offered
      && now !== undefined
      && hasActiveBlackMarketOffer(state, now)
      && Number.isInteger(offered.level)
      && offered.level >= 0
      && Number.isInteger(offered.special)
      && offered.special >= 0
      && offered.special <= 8
      && Number.isInteger(blackMarketGold)
      && blackMarketGold! >= 0
      && payload.warBucks === 0
      && payload.gold === blackMarketGold,
  );
  const isNormalShopPurchase = Boolean(
    shopDefinition
      && payload.gold === shopDefinition.gold
      && payload.warBucks === shopDefinition.warBucks,
  );
  if (
    (!isBlackMarketPurchase && !isNormalShopPurchase)
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
  if (!isBlackMarketPurchase && Math.max(0, Math.floor(playerLevel)) < definition.canBuyLevelIndex) {
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
  const goldCost = isBlackMarketPurchase ? blackMarketGold! : definition.gold;
  const warBucksCost = isBlackMarketPurchase ? 0 : definition.warBucks;
  if (state.gold < goldCost) throw new ApiError(ITEM_NOT_ENOUGH_GOLD, "Not enough Gold.");
  if (state.warBucks < warBucksCost) {
    throw new ApiError(ITEM_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks.");
  }

  // Black Market level/special are server-issued. Never copy them from BuyWeapon data: the
  // stock request does not send either field, and a patched client must not be able to mint
  // a maximum-level or enhanced weapon by adding unrecognized JSON properties.
  const weapon = isBlackMarketPurchase
    ? ownedWeapon(offered!.level, offered!.special)
    : ownedWeapon();
  itemInventory.levelManagerData.savedWeapons[definition.name] = weapon;
  // Every enabled 4.9.5 shop row has DELIVERTIME=0, including WarBucks-priced weapons.
  // Ownership therefore becomes active immediately and no pending delivery may be fabricated.
  itemInventory.levelManagerData.weaponDelivery = emptyDelivery();
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold - goldCost,
    warBucks: state.warBucks - warBucksCost,
    itemInventory,
  };
  return { state: next, itemInventory, weapon, definition };
}

/**
 * Acknowledge the client's post-purchase `ActivateWeapon` transition.
 *
 * Every supported 4.9.5 normal-shop weapon has `DELIVERTIME=0`; BuyWeapon already debits the
 * wallet and creates permanent ownership in the preceding buffered subrequest. The stock
 * client still calls `WeaponLevelsSetup.ActivateWeapon()` locally and queues action 128. This
 * transition therefore validates that permanent ownership really exists, but intentionally
 * changes no state and grants nothing. Treating it as an idempotent acknowledgement lets a
 * repeated BufferId return the original result without turning activation into a second grant.
 * Borrowed rental rows are rejected because their authority comes only from action 138 and a
 * bounded trial; action 128 must never convert that temporary row into permanent ownership.
 */
export function activateWeaponState(
  state: PlayerProgressionState,
  payload: WeaponActivatePayload,
): ItemInventoryMutationResult {
  const definition = weaponDefinitionFor(payload.name);
  const itemInventory = itemInventoryStateFor(state);
  const weapon = definition ? itemInventory.levelManagerData.savedWeapons[definition.name] : undefined;
  if (!definition) throw new ApiError(ITEM_PRICE_NOT_FOUND, "Weapon was not found.");
  if (!weapon?.bought || weapon.borrowed) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "A permanent weapon purchase must exist before activation.");
  }
  return { state, itemInventory, weapon, definition };
}

/**
 * Acknowledge InstantBuyWeapon only for the source-backed zero-delivery catalog.
 *
 * Unity may queue action 126 after optimistically calling InstantBuyWeapon even though every
 * enabled 4.9.5 purchase row has `DELIVERTIME=0`. BuyWeapon is therefore the sole debit/grant.
 * Requiring permanent ownership, an empty delivery receipt, zero client price, and the recovered
 * coefficients prevents this compatibility action from becoming a second purchase or a generic
 * way to consume a future timed delivery whose contract has not been recovered.
 */
export function instantBuyWeaponState(
  state: PlayerProgressionState,
  payload: WeaponPurchaseInstantPayload,
): ItemInventoryMutationResult {
  const definition = weaponDefinitionFor(payload.name);
  const itemInventory = itemInventoryStateFor(state);
  const weapon = definition ? itemInventory.levelManagerData.savedWeapons[definition.name] : undefined;
  const delivery = itemInventory.levelManagerData.weaponDelivery;
  if (!definition || definition.deliverySeconds !== 0) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Timed weapon purchase is not source-backed.");
  }
  if (!weapon?.bought || weapon.borrowed) {
    throw new ApiError(ITEM_WEAPON_NOT_BOUGHT, "A permanent weapon purchase must exist before instant acknowledgement.");
  }
  if (
    payload.expectedPrice !== 0
    || Math.abs(payload.goldCoefficient - WEAPON_GOLD_COEFFICIENT) > 0.000_001
    || Math.abs(payload.goldExpCoefficient - WEAPON_GOLD_EXP_COEFFICIENT) > 0.000_001
    || delivery.activationNeeded
    || delivery.itemId.length > 0
  ) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Instant weapon purchase assertion is invalid.");
  }
  return { state, itemInventory, weapon, definition };
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
  now?: number,
): ItemInventoryMutationResult {
  const definition = weaponDefinitionFor(payload.name);
  const itemInventory = itemInventoryStateFor(state);
  const weapon = definition ? itemInventory.levelManagerData.savedWeapons[definition.name] : undefined;
  const slotMask = WEAPON_SLOT_MASKS[payload.slotIndex];
  if (
    !definition
    || !weapon?.bought
    || (weapon.borrowed && !(
      now !== undefined
      && hasActiveRentalItem(state, 1, definition.name, now)
    ))
    || payload.index !== definition.index
    || slotMask === undefined
    || (slotMask & definition.category) !== definition.category
    || payload.specialFeature !== weapon.specialFeature
    || payload.armyPower < 0
  ) {
    throw new ApiError(ITEM_WEAPON_NOT_BOUGHT, "Weapon is not owned or cannot be equipped in this slot.");
  }

  const currentSlot = itemInventory.inventoryData.slots[String(payload.slotIndex)];
  if (currentSlot?.name === definition.name && currentSlot.weaponIndex === definition.index) {
    // EquipWeapon is commonly adjacent to a purchase in RequestBuffer, but it can also be
    // repeated independently after the client has already selected this slot. All ownership,
    // rental, category, index, and feature checks above still run; only the identical durable
    // assignment is skipped. Returning the original state prevents a false inventory revision.
    return { state, itemInventory, weapon, definition };
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

function upgradeContext(
  state: PlayerProgressionState,
  name: string,
): {
  definition: WeaponDefinition;
  itemInventory: ItemInventoryState;
  weapon: SavedWeaponState;
  stages: NonNullable<(typeof WEAPON_UPGRADE_CATALOG)[string]>;
} {
  const definition = weaponDefinitionFor(name);
  const stages = WEAPON_UPGRADE_CATALOG[name];
  const itemInventory = itemInventoryStateFor(state);
  const weapon = definition ? itemInventory.levelManagerData.savedWeapons[name] : undefined;
  if (!definition || !stages) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Weapon upgrade balancing was not found.");
  }
  if (!weapon?.bought || weapon.borrowed) {
    // A rental can be equipped for its bounded trial, but it must never become a permanent
    // upgraded item through the ordinary action-73 path. Only action 138 may convert it.
    throw new ApiError(ITEM_WEAPON_NOT_BOUGHT, "A permanent weapon must be owned before it can be upgraded.");
  }
  return { definition, itemInventory, weapon, stages };
}

function assertTransitionExists(stages: readonly (readonly [number, number])[], boughtIndex: number): void {
  if (!Number.isInteger(boughtIndex) || boughtIndex < 0 || stages[boughtIndex] === undefined) {
    throw new ApiError(ITEM_ALREADY_MAXIMUM_UPGRADE, "Weapon is already at its maximum normal level.");
  }
}

function assertUpgradeIndex(weapon: SavedWeaponState, requestedIndex: number): void {
  if (requestedIndex !== weapon.boughtIndex) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "Weapon upgrade index does not match stored state.");
  }
}

function activeWeaponDelivery(delivery: ItemDeliveryState): boolean {
  // The receipt remains active after its timer reaches zero until ActivateWeaponUpgrade
  // consumes it. This mirrors the client's `activationNeeded` state and prevents a second
  // purchase from overwriting an expired-but-unclaimed upgrade.
  return delivery.activationNeeded || delivery.itemId.length > 0;
}

/**
 * Start one server-owned weapon upgrade and debit its recovered WarBucks cost.
 *
 * WeaponScreen only sends price through RequestBuffer's analytics arguments, which are not
 * part of Request.data. Consequently the server must select both price and duration from the
 * generated MainScene catalog. Client StartTime, DeliveryTime, discount, and deliveryReduce
 * are assertions; none can alter the authoritative receipt. The recovered LevelManager has
 * one shared weaponDelivery object, so a player may have only one pending weapon transition.
 */
export function startWeaponUpgradeState(
  state: PlayerProgressionState,
  now: number,
  payload: WeaponUpgradePurchasePayload,
): WeaponUpgradeMutationResult {
  const { definition, itemInventory, weapon, stages } = upgradeContext(state, payload.name);
  assertUpgradeIndex(weapon, payload.boughtIndex);
  assertTransitionExists(stages, weapon.boughtIndex);
  const [warBucks, sourceDeliverySeconds] = stages[weapon.boughtIndex]!;
  const deliverySeconds = subscriptionUpgradeDeliverySeconds(state, now, sourceDeliverySeconds);

  if (payload.discount !== 0 || payload.deliveryReduce !== 0) {
    throw new ApiError(ITEM_NO_DISCOUNT_FOUND, "Weapon upgrade offer is not backed by the server.");
  }
  if (warBucks < 0 || sourceDeliverySeconds < 0) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "Recovered weapon upgrade balancing is invalid.");
  }
  if (payload.deliveryTime !== deliverySeconds || payload.startTime < 0) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Weapon upgrade duration or start time does not match server balancing.");
  }
  if (activeWeaponDelivery(itemInventory.levelManagerData.weaponDelivery)) {
    throw new ApiError(ITEM_ALREADY_UPGRADING, "Another weapon upgrade is awaiting delivery or activation.");
  }
  if (state.warBucks < warBucks) {
    throw new ApiError(ITEM_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks for this weapon upgrade.");
  }

  const start = Math.max(0, Math.floor(now));
  itemInventory.levelManagerData.weaponDelivery = {
    activationNeeded: true,
    boughtIndex: weapon.boughtIndex,
    end: start + deliverySeconds,
    itemId: definition.name,
    // WeaponLevelsSetup uses one upgrade lane. slotId is retained for exact ItemDelivery
    // serialization even though the recovered weapon code does not read it.
    slotId: 0,
    start,
  };
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    warBucks: state.warBucks - warBucks,
    itemInventory,
  };
  return { state: next, itemInventory, weapon, definition, deliveryTime: deliverySeconds };
}

/**
 * Calculate the exact premium price used by MEJMLNDFDBP.BCEGIAODLCL.
 *
 * Remaining seconds are converted to minutes and evaluated as
 * ceil(GoldCoefficient * minutes^GoldExpCoefficient * minutes). The recovered client first
 * rounds its remaining double to Int32; server receipts and `now` are integral seconds, so
 * the same expression is deterministic here without trusting client clock state.
 */
export function weaponUpgradeInstantPrice(remainingSeconds: number): number {
  const seconds = Math.max(0, Math.round(remainingSeconds));
  if (seconds <= 0) return 0;
  // C# evaluates `seconds / 60f`, both obscured constants, and the values passed to
  // Math.Pow as System.Single before widening the final multiplication to double. Math.fround
  // reproduces those binary32 conversions; plain JavaScript doubles are one Gold lower at a
  // small set of long-duration boundaries present in the recovered tables.
  const minutes = Math.fround(Math.fround(seconds) / Math.fround(60));
  return Math.ceil(
    Math.fround(WEAPON_GOLD_COEFFICIENT)
      * Math.pow(minutes, Math.fround(WEAPON_GOLD_EXP_COEFFICIENT))
      * minutes,
  );
}

export interface TutorialUpgradeFunding {
  warBucks: number;
  gold: number;
}

/** The only weapon selected by TutorialManagerStage4.ChooseWeapon. */
export const TUTORIAL_WEAPON_NAME = "Google2u.AssaultRifle_AK47";

/**
 * Derive the tutorial wallet grant from the same recovered row used by BuyWeaponUpgrade.
 *
 * Action 161 sends a sheet name but no currency values. Keeping the amount derived from stage
 * zero prevents a modified client from selecting a more expensive weapon and also prevents the
 * reward from drifting away from the purchase validator when the generated catalog is refreshed.
 * This helper intentionally performs no player-state checks so an already-collected replay can
 * reproduce the original response amounts after the player has spent them.
 */
export function tutorialWeaponUpgradeFunding(name: unknown): TutorialUpgradeFunding {
  if (name !== TUTORIAL_WEAPON_NAME) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "WeaponTutorial is restricted to the recovered AK47 target.");
  }
  const stage = WEAPON_UPGRADE_CATALOG[TUTORIAL_WEAPON_NAME]?.[0];
  if (!stage || stage[0] < 0 || stage[1] < 0) {
    throw new ApiError(ITEM_PRICE_NOT_FOUND, "The tutorial weapon upgrade row is unavailable.");
  }
  return { warBucks: stage[0], gold: weaponUpgradeInstantPrice(stage[1]) };
}

/**
 * Prove that a first-time WeaponTutorial claim can still fund its intended transition.
 *
 * The stock tutorial is suppressed once any weapon upgrade exists or a weapon delivery is
 * active. The backend cannot trust those local StatsManager checks, so it independently requires
 * the permanent starter AK47 at cursor zero and the shared delivery slot to be empty. Replays do
 * not call this function: their collected marker is authority and they must remain harmless even
 * after the tutorial upgrade advances the cursor.
 */
export function assertTutorialWeaponUpgradeEligible(
  state: PlayerProgressionState,
  name: unknown,
): void {
  tutorialWeaponUpgradeFunding(name);
  const { itemInventory, weapon } = upgradeContext(state, TUTORIAL_WEAPON_NAME);
  if (weapon.boughtIndex !== 0) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "The tutorial weapon has already been upgraded.");
  }
  if (activeWeaponDelivery(itemInventory.levelManagerData.weaponDelivery)) {
    throw new ApiError(ITEM_ALREADY_UPGRADING, "A weapon delivery is already active.");
  }
}

function matchingDelivery(
  itemInventory: ItemInventoryState,
  weapon: SavedWeaponState,
  name: string,
  requestedIndex: number,
): ItemDeliveryState {
  assertUpgradeIndex(weapon, requestedIndex);
  const delivery = itemInventory.levelManagerData.weaponDelivery;
  if (
    !delivery.activationNeeded
    || delivery.itemId !== name
    || delivery.boughtIndex !== weapon.boughtIndex
  ) {
    throw new ApiError(ITEM_WRONG_INDEX_TO_ACTIVATE, "No matching weapon upgrade delivery exists.");
  }
  return delivery;
}

function finishWeaponUpgrade(
  state: PlayerProgressionState,
  itemInventory: ItemInventoryState,
  weapon: SavedWeaponState,
  definition: WeaponDefinition,
  goldSpent = 0,
): WeaponUpgradeMutationResult {
  weapon.boughtIndex += 1;
  itemInventory.levelManagerData.weaponDelivery = emptyDelivery();
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold - goldSpent,
    itemInventory,
  };
  return { state: next, itemInventory, weapon, definition, goldSpent };
}

/** Activate a completed receipt exactly once after the server-owned end timestamp. */
export function activateWeaponUpgradeState(
  state: PlayerProgressionState,
  now: number,
  payload: WeaponUpgradeActivatePayload,
): WeaponUpgradeMutationResult {
  const { definition, itemInventory, weapon, stages } = upgradeContext(state, payload.name);
  assertTransitionExists(stages, weapon.boughtIndex);
  const delivery = matchingDelivery(itemInventory, weapon, definition.name, payload.boughtIndex);
  if (payload.armyPower < 0) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "ArmyPower must be non-negative.");
  }
  if (Math.floor(now) < delivery.end) {
    throw new ApiError(ITEM_TOO_SOON_TO_ACTIVATE, "Weapon upgrade delivery is not finished.");
  }
  return finishWeaponUpgrade(state, itemInventory, weapon, definition);
}

/**
 * Pay Gold for the remaining delivery duration and activate the upgrade atomically.
 *
 * The client has already incremented boughtIndex locally before this request is sent, so all
 * validation must use the old index included in the payload and the persisted receipt. Both
 * echoed constants and ExpectedPrice are checked to detect stale configuration or tampering.
 * A queued RequestBuffer can reach the server after the client calculated ExpectedPrice, so
 * one exact receipt-time value would reject legitimate requests. The accepted interval runs
 * from the price at server receipt up to the price at delivery start; both bounds are derived
 * from the same persisted receipt, and the exact client amount is debited to keep its already
 * optimistic wallet mutation synchronized with server state.
 */
export function instantWeaponUpgradeState(
  state: PlayerProgressionState,
  now: number,
  payload: WeaponUpgradeInstantPayload,
): WeaponUpgradeMutationResult {
  const { definition, itemInventory, weapon, stages } = upgradeContext(state, payload.name);
  assertTransitionExists(stages, weapon.boughtIndex);
  const delivery = matchingDelivery(itemInventory, weapon, definition.name, payload.boughtIndex);
  if (payload.discount !== 0) {
    throw new ApiError(ITEM_NO_DISCOUNT_FOUND, "Weapon delivery discount is not backed by the server.");
  }
  if (payload.expectedPrice < 0) {
    throw new ApiError(ITEM_NEGATIVE_PRICE_FROM_CLIENT, "ExpectedPrice cannot be negative.");
  }
  if (
    payload.armyPower < 0
    || Math.abs(payload.goldCoefficient - WEAPON_GOLD_COEFFICIENT) > 0.000_001
    || Math.abs(payload.goldExpCoefficient - WEAPON_GOLD_EXP_COEFFICIENT) > 0.000_001
  ) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Weapon instant-upgrade constants do not match server balancing.");
  }

  const remainingAtReceipt = Math.max(0, delivery.end - Math.floor(now));
  const fullDeliveryDuration = Math.max(0, delivery.end - delivery.start);
  const minimumPrice = weaponUpgradeInstantPrice(remainingAtReceipt);
  const maximumPrice = weaponUpgradeInstantPrice(fullDeliveryDuration);
  if (payload.expectedPrice < minimumPrice || payload.expectedPrice > maximumPrice) {
    throw new ApiError(ITEM_PRICE_MISMATCH, "Weapon instant-upgrade price is outside the server receipt range.");
  }
  if (state.gold < payload.expectedPrice) {
    throw new ApiError(ITEM_NOT_ENOUGH_GOLD, "Not enough Gold to finish the weapon upgrade.");
  }
  return finishWeaponUpgrade(state, itemInventory, weapon, definition, payload.expectedPrice);
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
  const name = weaponDefinitionFor(requestedName)?.name ?? "Google2u.AssaultRifle_AK47";
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
    if (typeof parsed?.Name === "string") return parsed.Name;
    return typeof parsed?.LevelName === "string" ? parsed.LevelName : "";
  } catch {
    return "";
  }
}
