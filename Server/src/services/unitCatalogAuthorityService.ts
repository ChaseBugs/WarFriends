import { ApiError, ApiErrorCode } from "../apiErrors";
import generatedUnitCatalog from "../data/unitCatalog.generated.json";
import generatedUnitUpgradeCatalog from "../data/unitUpgradeCatalog.generated.json";

export interface UnitDefinition {
  /** Google2u component type used by ArmyScreen as Name/LevelName. */
  name: string;
  /** Position in the matching LevelManager roster; player and helper indexes are independent. */
  index: number;
  roster: "player" | "additional";
  behaviourType: string;
  upgradeType: string;
  tutorialUnit: boolean;
  /** LevelBehaviour.UnitType projected into ActiveUnitsManager's four deployment categories. */
  deploymentType: 0 | 1 | 2 | 3;
  /** False for mechanical units, which share an additional three-unit global equip cap. */
  isSoldier: boolean;
  /** One-based display level echoed by the purchase contract. */
  unlockLevel: number;
  /** Zero-based LevelManager level gate used before the source row becomes purchasable. */
  canBuyLevelIndex: number;
  warBucks: number;
  gold: number;
  deliverySeconds: number;
  /** Initial SavedArmySlots tier, not the number of normal upgrades already bought. */
  startingTier: number;
  /** Source-sheet display level retained for the initial SavedArmySlots projection. */
  startingLevel: number;
  /** Absolute source-table row at which the special-slot subtable begins. */
  startingSpecial: number;
  /** Absolute source-table row at which the Elite-part subtable begins. */
  startingElite: number;
  unitType: number;
  clientId: number;
  /** Five one-based promotion gates for tiers 2 through 6; helper sentinels are all -1. */
  unlockTierLevels: readonly number[];
}

export interface UnresolvedUnitDefinition {
  name: string;
  unlockLevel: number;
  canBuyLevelIndex: number;
  warBucks: number;
  gold: number;
  deliverySeconds: number;
  startingTier: number;
  startingLevel: number;
  startingSpecial: number;
  startingElite: number;
  unitType: number;
  clientId: number;
  unlockTierLevels: readonly number[];
}

export interface UnitUpgradeLevel {
  sourceIndex: number;
  tier: number;
  slot: 0 | 1;
  warBucks: number;
  deliverySeconds: number;
  armyPower: number;
}

export interface UnitEliteUpgradeLevel {
  sourceIndex: number;
  parts: number;
  warBucks: number;
  armyPower: number;
}

export interface UnitUpgradeDefinition {
  name: string;
  normalLevels: readonly Readonly<UnitUpgradeLevel>[];
  specialLevels: readonly Readonly<UnitUpgradeLevel>[];
  eliteLevels: readonly Readonly<UnitEliteUpgradeLevel>[];
}

export interface ValidatedUnitCatalog {
  schemaVersion: number;
  source: string;
  sourceSha256: string;
  catalog: readonly Readonly<UnitDefinition>[];
  unresolvedRows: readonly Readonly<UnresolvedUnitDefinition>[];
}

export interface ValidatedUnitUpgradeCatalog {
  schemaVersion: number;
  source: string;
  sourceSha256: string;
  catalog: readonly Readonly<UnitUpgradeDefinition>[];
}

export interface ValidatedUnitCatalogPair {
  units: Readonly<ValidatedUnitCatalog>;
  upgrades: Readonly<ValidatedUnitUpgradeCatalog>;
}

const UNIT_ROOT_KEYS = new Set(["schemaVersion", "source", "sourceSha256", "catalog", "unresolvedRows"]);
const UPGRADE_ROOT_KEYS = new Set(["schemaVersion", "source", "sourceSha256", "catalog"]);
const UNIT_KEYS = new Set([
  "name", "index", "roster", "behaviourType", "upgradeType", "tutorialUnit", "deploymentType",
  "isSoldier", "unlockLevel", "canBuyLevelIndex", "warBucks", "gold", "deliverySeconds",
  "startingTier", "startingLevel", "startingSpecial", "startingElite", "unitType", "clientId",
  "unlockTierLevels",
]);
const UNRESOLVED_KEYS = new Set([
  "name", "unlockLevel", "canBuyLevelIndex", "warBucks", "gold", "deliverySeconds",
  "startingTier", "startingLevel", "startingSpecial", "startingElite", "unitType", "clientId",
  "unlockTierLevels",
]);
const UPGRADE_KEYS = new Set(["name", "normalLevels", "specialLevels", "eliteLevels"]);
const LEVEL_KEYS = new Set(["sourceIndex", "tier", "slot", "warBucks", "deliverySeconds", "armyPower"]);
const ELITE_KEYS = new Set(["sourceIndex", "parts", "warBucks", "armyPower"]);
const SOURCE = "Client/ExportedProject/Assets/Scenes/MainScene.unity";
const SHA256 = /^[0-9a-f]{64}$/;
const UNIT_NAME = /^Google2u\.DBUpgradeSlots[A-Za-z0-9_]{1,100}$/;
const TYPE_NAME = /^[A-Za-z][A-Za-z0-9_]{0,100}$/;
const MAX_CLIENT_INTEGER = 2_147_483_647;
const STARTING_LEVEL_BY_TIER = Object.freeze([0, 0, 5, 15, 30, 50, 75]);

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function record(value: unknown, keys: ReadonlySet<string>, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) return invalid(`${label} is invalid.`);
  const row = value as Record<string, unknown>;
  if (Object.keys(row).length !== keys.size || Object.keys(row).some((key) => !keys.has(key))) {
    return invalid(`${label} has an invalid field set.`);
  }
  return row;
}

function integer(value: unknown, label: string, minimum = 0, maximum = MAX_CLIENT_INTEGER): number {
  if (!Number.isSafeInteger(value) || (value as number) < minimum || (value as number) > maximum) {
    return invalid(`${label} is invalid.`);
  }
  return value as number;
}

function finitePositive(value: unknown, label: string): number {
  if (typeof value !== "number" || !Number.isFinite(value) || value <= 0 || value > MAX_CLIENT_INTEGER) {
    return invalid(`${label} is invalid.`);
  }
  return value;
}

function name(value: unknown, label: string): string {
  if (typeof value !== "string" || !UNIT_NAME.test(value)) return invalid(`${label} has an invalid name.`);
  return value;
}

function tierLevels(value: unknown, label: string, minimum: -1 | 0): readonly number[] {
  if (!Array.isArray(value) || value.length !== 5) return invalid(`${label} must contain exactly five tier gates.`);
  return Object.freeze(value.map((level, index) => integer(level, `${label} gate ${index}`, minimum, 58)));
}

function commonUnitFields(row: Record<string, unknown>, label: string, allowSentinels = false) {
  const sentinelMinimum = allowSentinels ? -1 : 0;
  return {
    name: name(row.name, label),
    unlockLevel: integer(row.unlockLevel, `${label} unlock level`, 0, 66),
    canBuyLevelIndex: integer(row.canBuyLevelIndex, `${label} purchase level`, 0, 63),
    warBucks: integer(row.warBucks, `${label} WarBucks price`),
    gold: integer(row.gold, `${label} Gold price`),
    deliverySeconds: integer(row.deliverySeconds, `${label} delivery duration`),
    startingTier: integer(row.startingTier, `${label} starting tier`, 0, 9),
    startingLevel: integer(row.startingLevel, `${label} starting level`, 0, 150),
    startingSpecial: integer(row.startingSpecial, `${label} special offset`, 0, 242),
    startingElite: integer(row.startingElite, `${label} Elite offset`, sentinelMinimum, 250),
    unitType: integer(row.unitType, `${label} unit type`, 0, 20),
    clientId: integer(row.clientId, `${label} client ID`, sentinelMinimum, 40),
    unlockTierLevels: tierLevels(row.unlockTierLevels, `${label} unlock tiers`, sentinelMinimum),
  };
}

function validateUnitArtifact(value: unknown): Readonly<ValidatedUnitCatalog> {
  const root = record(value, UNIT_ROOT_KEYS, "Unit catalog root");
  if (root.schemaVersion !== 1 || root.source !== SOURCE
    || typeof root.sourceSha256 !== "string" || !SHA256.test(root.sourceSha256)) {
    return invalid("Unit catalog provenance is invalid.");
  }
  if (!Array.isArray(root.catalog) || root.catalog.length !== 27) {
    return invalid("Unit catalog must contain exactly 24 player rows and three helper rows.");
  }

  const names = new Set<string>();
  const catalog = Object.freeze(root.catalog.map((candidate, rowIndex) => {
    const row = record(candidate, UNIT_KEYS, `Unit row ${rowIndex}`);
    const isPlayer = rowIndex < 24;
    const base = commonUnitFields(row, `Unit row ${rowIndex}`, !isPlayer);
    const index = integer(row.index, `Unit row ${rowIndex} index`);
    const deploymentType = integer(row.deploymentType, `Unit row ${rowIndex} deployment type`, 0, 3);
    if (names.has(base.name) || row.roster !== (isPlayer ? "player" : "additional")
      || index !== (isPlayer ? rowIndex : rowIndex - 24)
      || typeof row.behaviourType !== "string" || !TYPE_NAME.test(row.behaviourType)
      || typeof row.upgradeType !== "string" || !TYPE_NAME.test(row.upgradeType)
      || typeof row.tutorialUnit !== "boolean" || typeof row.isSoldier !== "boolean") {
      return invalid(`Unit row ${rowIndex} has invalid, duplicate, or unordered identity.`);
    }

    if (isPlayer) {
      const expectedStartingLevel = STARTING_LEVEL_BY_TIER[base.startingTier];
      if (base.clientId !== index || base.unlockLevel < 1 || base.deliverySeconds !== 0
        || (base.warBucks > 0 && base.gold > 0)
        || base.startingTier < 1 || base.startingTier > 6 || base.startingLevel !== expectedStartingLevel
        || base.startingSpecial < 1 || base.startingElite <= base.startingSpecial
        || ![1, 2, 4, 8, 17, 18, 20].includes(base.unitType)
        || (base.unitType & (1 << deploymentType)) === 0
        || row.tutorialUnit !== (rowIndex === 0)
        || (row.isSoldier !== (base.unitType <= 8))) {
        return invalid(`Player unit row ${rowIndex} has contradictory gameplay authority.`);
      }
    } else if (row.tutorialUnit !== false || row.isSoldier !== false || deploymentType !== 0
      || base.unlockLevel !== 0 || base.canBuyLevelIndex !== 0 || base.warBucks !== 0 || base.gold !== 0
      || base.deliverySeconds !== 0 || base.startingTier !== 0 || base.startingSpecial !== 0
      || base.startingElite !== -1 || base.unitType !== 1 || base.clientId !== -1
      || base.unlockTierLevels.some((level) => level !== -1)) {
      return invalid(`Helper unit row ${rowIndex} has contradictory non-player authority.`);
    }

    names.add(base.name);
    return Object.freeze({
      ...base,
      index,
      roster: row.roster as "player" | "additional",
      behaviourType: row.behaviourType,
      upgradeType: row.upgradeType,
      tutorialUnit: row.tutorialUnit,
      deploymentType: deploymentType as 0 | 1 | 2 | 3,
      isSoldier: row.isSoldier,
    });
  }));

  if (!Array.isArray(root.unresolvedRows) || root.unresolvedRows.length !== 18) {
    return invalid("Unresolved unit catalog must contain exactly 18 rows.");
  }
  let previousName = "";
  const unresolvedRows = Object.freeze(root.unresolvedRows.map((candidate, rowIndex) => {
    const row = record(candidate, UNRESOLVED_KEYS, `Unresolved unit row ${rowIndex}`);
    const base = commonUnitFields(row, `Unresolved unit row ${rowIndex}`, true);
    if (names.has(base.name) || base.name.localeCompare(previousName) <= 0 || base.deliverySeconds !== 0
      || (base.warBucks > 0 && base.gold > 0)) {
      return invalid(`Unresolved unit row ${rowIndex} is duplicated, unordered, or contradictory.`);
    }
    names.add(base.name);
    previousName = base.name;
    return Object.freeze(base);
  }));

  return Object.freeze({
    schemaVersion: 1,
    source: SOURCE,
    sourceSha256: root.sourceSha256,
    catalog,
    unresolvedRows,
  });
}

function validateUpgradeLane(
  value: unknown,
  nameValue: string,
  lane: "normal" | "special",
  firstSourceIndex: number,
  expectedCount: number,
): readonly Readonly<UnitUpgradeLevel>[] {
  if (!Array.isArray(value) || value.length !== expectedCount) {
    return invalid(`${nameValue} ${lane} lane has an invalid source range.`);
  }
  let previousTier = -1;
  let previousPower = -1;
  const slot = lane === "normal" ? 0 : 1;
  const levels = Object.freeze(value.map((candidate, levelIndex) => {
    const row = record(candidate, LEVEL_KEYS, `${nameValue} ${lane} level ${levelIndex}`);
    const sourceIndex = integer(row.sourceIndex, `${nameValue} ${lane} source index`);
    const tier = integer(row.tier, `${nameValue} ${lane} tier`, 0, 9);
    const warBucks = integer(row.warBucks, `${nameValue} ${lane} WarBucks`);
    const deliverySeconds = integer(row.deliverySeconds, `${nameValue} ${lane} duration`, 1);
    const armyPower = finitePositive(row.armyPower, `${nameValue} ${lane} Army Power`);
    if (sourceIndex !== firstSourceIndex + levelIndex || row.slot !== slot
      || tier < previousTier || armyPower < previousPower) {
      return invalid(`${nameValue} ${lane} level ${levelIndex} is non-contiguous or contradictory.`);
    }
    previousTier = tier;
    previousPower = armyPower;
    return Object.freeze({ sourceIndex, tier, slot, warBucks, deliverySeconds, armyPower });
  }));
  return levels;
}

function validateUpgradeArtifact(
  value: unknown,
  units: Readonly<ValidatedUnitCatalog>,
): Readonly<ValidatedUnitUpgradeCatalog> {
  const root = record(value, UPGRADE_ROOT_KEYS, "Unit upgrade catalog root");
  if (root.schemaVersion !== 2 || root.source !== units.source || root.sourceSha256 !== units.sourceSha256) {
    return invalid("Unit upgrade catalog provenance does not match the unit catalog.");
  }
  if (!Array.isArray(root.catalog) || root.catalog.length !== 24) {
    return invalid("Unit upgrade catalog must contain exactly 24 player tables.");
  }

  let normalCount = 0;
  let specialCount = 0;
  let eliteCount = 0;
  const catalog = Object.freeze(root.catalog.map((candidate, rowIndex) => {
    const row = record(candidate, UPGRADE_KEYS, `Unit upgrade table ${rowIndex}`);
    const definition = units.catalog[rowIndex];
    if (!definition || definition.roster !== "player" || row.name !== definition.name) {
      return invalid(`Unit upgrade table ${rowIndex} does not match its player row.`);
    }
    const normalLevels = validateUpgradeLane(row.normalLevels, definition.name, "normal", 0, definition.startingSpecial);
    const specialLevels = validateUpgradeLane(
      row.specialLevels,
      definition.name,
      "special",
      definition.startingSpecial,
      definition.startingElite - definition.startingSpecial,
    );
    if (normalLevels[0]?.tier !== definition.startingTier - 1 || normalLevels.at(-1)?.tier !== 9
      || specialLevels[0]?.tier !== definition.startingTier || specialLevels.at(-1)?.tier !== 8) {
      return invalid(`${definition.name} upgrade tiers do not match its starting tier.`);
    }

    if (!Array.isArray(row.eliteLevels) || row.eliteLevels.length !== 9) {
      return invalid(`${definition.name} Elite lane must contain exactly nine levels.`);
    }
    let previousPower = -1;
    const eliteLevels = Object.freeze(row.eliteLevels.map((candidateValue, levelIndex) => {
      const level = record(candidateValue, ELITE_KEYS, `${definition.name} Elite level ${levelIndex}`);
      const sourceIndex = integer(level.sourceIndex, `${definition.name} Elite source index`);
      const parts = integer(level.parts, `${definition.name} Elite parts`, 1);
      const warBucks = integer(level.warBucks, `${definition.name} Elite WarBucks`);
      const armyPower = finitePositive(level.armyPower, `${definition.name} Elite Army Power`);
      if (sourceIndex !== definition.startingElite + levelIndex || armyPower < previousPower) {
        return invalid(`${definition.name} Elite level ${levelIndex} is non-contiguous or contradictory.`);
      }
      previousPower = armyPower;
      return Object.freeze({ sourceIndex, parts, warBucks, armyPower });
    }));

    normalCount += normalLevels.length;
    specialCount += specialLevels.length;
    eliteCount += eliteLevels.length;
    return Object.freeze({ name: definition.name, normalLevels, specialLevels, eliteLevels });
  }));

  if (normalCount !== 4_124 || specialCount !== 684 || eliteCount !== 216) {
    return invalid("Unit upgrade catalog has incomplete recovered lane totals.");
  }
  return Object.freeze({
    schemaVersion: 2,
    source: units.source,
    sourceSha256: units.sourceSha256,
    catalog,
  });
}

/**
 * Validate the identity and economy artifacts as one authority snapshot before constructing maps.
 * The recovered tables are split across two generated files, so validating either file alone
 * could let a duplicate name overwrite a purchase row or bind prices/power to another unit's
 * offsets. The paired boundary also deep-freezes every nested row so later code cannot mutate
 * the process-wide economy after startup validation.
 */
export function validatedUnitCatalogArtifacts(
  unitValue: unknown,
  upgradeValue: unknown,
): Readonly<ValidatedUnitCatalogPair> {
  const units = validateUnitArtifact(unitValue);
  const upgrades = validateUpgradeArtifact(upgradeValue, units);
  return Object.freeze({ units, upgrades });
}

const VALIDATED_PAIR = validatedUnitCatalogArtifacts(generatedUnitCatalog, generatedUnitUpgradeCatalog);
export const VALIDATED_UNIT_CATALOG = VALIDATED_PAIR.units;
export const VALIDATED_UNIT_UPGRADE_CATALOG = VALIDATED_PAIR.upgrades;
