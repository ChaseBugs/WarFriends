import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  ItemDeliveryState,
  ItemInventoryState,
  SavedArmyState,
  SavedWeaponState,
} from "../db";
import { WEAPON_UPGRADE_CATALOG } from "../data/weaponUpgradeCatalog.generated";
import {
  createInitialItemInventory,
  weaponDefinitionFor,
} from "./itemInventoryService";
import {
  playerUnitDefinitionFor,
  playerUnitUpgradeLimitsFor,
} from "./unitInventoryService";

const MAX_CLIENT_INTEGER = 2_147_483_647;
const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const INVENTORY_KEYS = new Set(["inventoryData", "levelManagerData"]);
const INVENTORY_DATA_KEYS = new Set(["slots"]);
const LEVEL_MANAGER_KEYS = new Set(["savedArmies", "savedWeapons", "unitDelivery", "weaponDelivery"]);
const SLOT_KEYS = new Set(["name", "weaponIndex"]);
const WEAPON_KEYS = new Set(["bought", "boughtIndex", "showed", "borrowed", "specialFeature"]);
const UNIT_KEYS = new Set([
  "bought",
  "boughtIndex",
  "specialSlot",
  "showed",
  "tier",
  "borrowed",
  "wasEquipped",
  "equipped",
  "eliteSlot",
  "parts",
]);
const DELIVERY_KEYS = new Set(["activationNeeded", "boughtIndex", "end", "itemId", "slotId", "start"]);
const WEAPON_SLOT_MASKS = [263, 1064, 592, 128] as const;

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function exactObject(value: unknown, keys: ReadonlySet<string>, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) invalid(`${label} is invalid.`);
  const record = value as Record<string, unknown>;
  const actual = Object.keys(record);
  if (actual.length !== keys.size || actual.some((key) => !keys.has(key))) invalid(`${label} is invalid.`);
  return record;
}

function dictionary(value: unknown, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) invalid(`${label} is invalid.`);
  return value as Record<string, unknown>;
}

function clientInteger(value: unknown, label: string): number {
  if (!Number.isSafeInteger(value) || (value as number) < 0 || (value as number) > MAX_CLIENT_INTEGER) {
    invalid(`${label} is invalid.`);
  }
  return value as number;
}

function timestamp(value: unknown, label: string): number {
  if (!Number.isSafeInteger(value) || (value as number) < 0 || (value as number) > MAX_DATE_UNIX_SECONDS) {
    invalid(`${label} is invalid.`);
  }
  return value as number;
}

function boolean(value: unknown, label: string): boolean {
  if (typeof value !== "boolean") invalid(`${label} is invalid.`);
  return value;
}

function validatedSavedWeapon(name: string, value: unknown): SavedWeaponState {
  const definition = weaponDefinitionFor(name);
  if (!definition || name.length > 256) invalid("Saved weapon identity is invalid.");
  const record = exactObject(value, WEAPON_KEYS, `Saved weapon ${name}`);
  const bought = boolean(record.bought, `Saved weapon ${name} bought flag`);
  const boughtIndex = clientInteger(record.boughtIndex, `Saved weapon ${name} upgrade cursor`);
  const showed = boolean(record.showed, `Saved weapon ${name} shown flag`);
  const borrowed = boolean(record.borrowed, `Saved weapon ${name} borrowed flag`);
  const specialFeature = clientInteger(record.specialFeature, `Saved weapon ${name} feature`);
  const upgradeCount = WEAPON_UPGRADE_CATALOG[name]?.length ?? 0;
  if (boughtIndex > upgradeCount || specialFeature > 10 || (borrowed && !bought)) {
    invalid(`Saved weapon ${name} authority is inconsistent.`);
  }
  return { bought, boughtIndex, showed, borrowed, specialFeature };
}

function validatedSavedUnit(name: string, value: unknown): SavedArmyState {
  const definition = playerUnitDefinitionFor(name);
  const limits = playerUnitUpgradeLimitsFor(name);
  if (!definition || !limits || name.length > 256) invalid("Saved unit identity is invalid.");
  const record = exactObject(value, UNIT_KEYS, `Saved unit ${name}`);
  const bought = boolean(record.bought, `Saved unit ${name} bought flag`);
  const boughtIndex = clientInteger(record.boughtIndex, `Saved unit ${name} normal cursor`);
  const specialSlot = clientInteger(record.specialSlot, `Saved unit ${name} special cursor`);
  const showed = boolean(record.showed, `Saved unit ${name} shown flag`);
  const tier = clientInteger(record.tier, `Saved unit ${name} tier`);
  const borrowed = boolean(record.borrowed, `Saved unit ${name} borrowed flag`);
  const wasEquipped = boolean(record.wasEquipped, `Saved unit ${name} equipped history`);
  const equipped = boolean(record.equipped, `Saved unit ${name} equipped flag`);
  const eliteSlot = clientInteger(record.eliteSlot, `Saved unit ${name} Elite cursor`);
  const parts = clientInteger(record.parts, `Saved unit ${name} parts`);
  if (
    boughtIndex > limits.normal
    || specialSlot > limits.special
    || eliteSlot > limits.elite
    || tier < definition.startingTier
    || tier > 6
    || (borrowed && !bought)
    || (equipped && (!bought || !wasEquipped))
  ) {
    invalid(`Saved unit ${name} authority is inconsistent.`);
  }
  return {
    bought,
    boughtIndex,
    specialSlot,
    showed,
    tier,
    borrowed,
    wasEquipped,
    equipped,
    eliteSlot,
    parts,
  };
}

function validatedDelivery(
  value: unknown,
  kind: "weapon" | "unit",
  weapons: Readonly<Record<string, SavedWeaponState>>,
  units: Readonly<Record<string, SavedArmyState>>,
): ItemDeliveryState {
  const record = exactObject(value, DELIVERY_KEYS, `${kind} delivery`);
  const activationNeeded = boolean(record.activationNeeded, `${kind} delivery activation flag`);
  const boughtIndex = clientInteger(record.boughtIndex, `${kind} delivery cursor`);
  const start = timestamp(record.start, `${kind} delivery start`);
  const end = timestamp(record.end, `${kind} delivery end`);
  const slotId = clientInteger(record.slotId, `${kind} delivery slot`);
  const itemId = record.itemId;
  if (typeof itemId !== "string" || itemId.length > 256) invalid(`${kind} delivery item is invalid.`);

  if (!activationNeeded) {
    if (boughtIndex !== 0 || start !== 0 || end !== 0 || slotId !== 0 || itemId !== "") {
      invalid(`Inactive ${kind} delivery is inconsistent.`);
    }
  } else if (itemId.length === 0 || start <= 0 || end < start) {
    invalid(`Active ${kind} delivery is inconsistent.`);
  } else if (kind === "weapon") {
    const saved = weapons[itemId];
    if (slotId !== 0 || !weaponDefinitionFor(itemId) || !saved?.bought || saved.borrowed
      || saved.boughtIndex !== boughtIndex) {
      invalid("Active weapon delivery has no matching permanent weapon cursor.");
    }
  } else {
    const saved = units[itemId];
    if ((slotId !== 0 && slotId !== 1) || !playerUnitDefinitionFor(itemId) || !saved?.bought
      || saved.borrowed || (slotId === 0 ? saved.boughtIndex : saved.specialSlot) !== boughtIndex) {
      invalid("Active unit delivery has no matching permanent unit cursor.");
    }
  }
  return { activationNeeded, boughtIndex, end, itemId, slotId, start };
}

/**
 * Validate the complete InventoryData and LevelManagerData authority snapshot.
 *
 * The recovered client treats these nested dictionaries as ownership, upgrade, delivery, and
 * loadout authority. A shallow clone is not a proof: `NaN` cursors, unknown runtime names, a
 * future-infinite delivery, or a slot pointing at an unowned weapon would reach price and Army
 * Power logic through normal JavaScript comparisons. Only a wholly absent legacy snapshot may
 * materialize the exact recovered starter inventory.
 */
export function itemInventoryAuthorityFor(value: ItemInventoryState | undefined): ItemInventoryState {
  const current = value ?? createInitialItemInventory();
  const root = exactObject(current, INVENTORY_KEYS, "Item inventory");
  const inventoryData = exactObject(root.inventoryData, INVENTORY_DATA_KEYS, "InventoryData");
  const levelManager = exactObject(root.levelManagerData, LEVEL_MANAGER_KEYS, "LevelManagerData");
  const savedWeaponValues = dictionary(levelManager.savedWeapons, "Saved weapon dictionary");
  const savedUnitValues = dictionary(levelManager.savedArmies, "Saved unit dictionary");
  const savedWeapons = Object.fromEntries(
    Object.entries(savedWeaponValues).map(([name, saved]) => [name, validatedSavedWeapon(name, saved)]),
  );
  const savedArmies = Object.fromEntries(
    Object.entries(savedUnitValues).map(([name, saved]) => [name, validatedSavedUnit(name, saved)]),
  );

  // UpdateEquippedUnits applies both limits when the client changes its loadout. Rechecking the
  // complete persisted set here closes the same invariant for imported data and for unrelated
  // full-document replacements, which otherwise never pass through that action handler.
  const equippedByDeploymentType = [0, 0, 0, 0];
  let equippedMechanicalUnits = 0;
  for (const [name, saved] of Object.entries(savedArmies)) {
    if (!saved.equipped) continue;
    const definition = playerUnitDefinitionFor(name)!;
    equippedByDeploymentType[definition.deploymentType]! += 1;
    if (!definition.isSoldier) equippedMechanicalUnits += 1;
  }
  if (equippedByDeploymentType.some((count) => count > 2) || equippedMechanicalUnits > 3) {
    invalid("Equipped unit authority exceeds recovered loadout limits.");
  }

  const slotValues = dictionary(inventoryData.slots, "Weapon slot dictionary");
  if (Object.keys(slotValues).length !== WEAPON_SLOT_MASKS.length) invalid("Weapon slot count is invalid.");
  const slots = Object.fromEntries(Object.entries(slotValues).map(([key, value]) => {
    if (!/^[0-3]$/.test(key)) invalid("Weapon slot identity is invalid.");
    const record = exactObject(value, SLOT_KEYS, `Weapon slot ${key}`);
    const name = record.name;
    const weaponIndex = clientInteger(record.weaponIndex, `Weapon slot ${key} index`);
    if (typeof name !== "string") invalid(`Weapon slot ${key} identity is invalid.`);
    const definition = weaponDefinitionFor(name);
    const saved = savedWeapons[name];
    const slotIndex = Number(key);
    if (!definition || definition.index !== weaponIndex
      || (definition.category & WEAPON_SLOT_MASKS[slotIndex]!) !== definition.category
      || !saved?.bought) {
      invalid(`Weapon slot ${key} authority is inconsistent.`);
    }
    return [key, { name, weaponIndex }];
  }));

  return {
    inventoryData: { slots },
    levelManagerData: {
      savedArmies,
      savedWeapons,
      unitDelivery: validatedDelivery(levelManager.unitDelivery, "unit", savedWeapons, savedArmies),
      weaponDelivery: validatedDelivery(levelManager.weaponDelivery, "weapon", savedWeapons, savedArmies),
    },
  };
}
