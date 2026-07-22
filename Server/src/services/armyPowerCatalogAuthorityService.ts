import { ApiError, ApiErrorCode } from "../apiErrors";
import generatedArmyPowerCatalog from "../data/armyPowerCatalog.generated.json";

export interface PlayerLevelDefinition {
  index: number;
  displayLevel: number;
  experience: number;
  rewardGold: number;
  armyPower: number;
  convertGoldToWarBucks: number;
}

export interface WeaponPowerDefinition {
  name: string;
  index: number;
  powerByLevel: readonly number[];
}

export interface FeatureDpsDefinition {
  index: number;
  name: string;
  coefficient: number;
}

export interface FeatureCategoryDefinition {
  category: string;
  categoryMask: number;
  dpsByFeature: readonly Readonly<FeatureDpsDefinition>[];
}

export interface ValidatedArmyPowerCatalog {
  schemaVersion: number;
  clientVersion: string;
  source: string;
  sourceSha256: string;
  rankLevels: readonly Readonly<PlayerLevelDefinition>[];
  featureDpsCoefficients: readonly Readonly<FeatureCategoryDefinition>[];
  weapons: readonly Readonly<WeaponPowerDefinition>[];
}

const ROOT_KEYS = new Set([
  "schemaVersion", "clientVersion", "source", "sourceSha256", "rankLevels",
  "featureDpsCoefficients", "weapons",
]);
const LEVEL_KEYS = new Set([
  "index", "displayLevel", "experience", "rewardGold", "armyPower", "convertGoldToWarBucks",
]);
const CATEGORY_KEYS = new Set(["category", "categoryMask", "dpsByFeature"]);
const FEATURE_KEYS = new Set(["index", "name", "coefficient"]);
const WEAPON_KEYS = new Set(["name", "index", "powerByLevel"]);
const CATEGORY_NAMES = Object.freeze([
  "AssaultRifle", "SMG", "LMG", "SniperRifle", "RocketLauncher", "Shotgun",
  "Grenade", "Pistol", "Minigun", "GrenadeLauncher", "PulseRifle",
]);
const FEATURE_NAMES = Object.freeze([
  "MagazineSize", "Reload", "Damage", "Critical", "BurstSize", "TotalAmmo",
  "Accuracy", "RateOfFire", "ShotVelocity",
]);
const SHA256 = /^[0-9a-f]{64}$/;

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function record(value: unknown, keys: ReadonlySet<string>, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) return invalid(`${label} is invalid.`);
  const result = value as Record<string, unknown>;
  if (Object.keys(result).length !== keys.size || Object.keys(result).some((key) => !keys.has(key))) {
    return invalid(`${label} has an invalid field set.`);
  }
  return result;
}

function integer(value: unknown, label: string, minimum = 0): number {
  if (!Number.isSafeInteger(value) || (value as number) < minimum || (value as number) > 2_147_483_647) {
    return invalid(`${label} is invalid.`);
  }
  return value as number;
}

/** Validate and deep-freeze every progression and combat-power row extracted from MainScene. */
export function validatedArmyPowerCatalogArtifact(value: unknown): Readonly<ValidatedArmyPowerCatalog> {
  const root = record(value, ROOT_KEYS, "Army Power catalog root");
  if (root.schemaVersion !== 2 || root.clientVersion !== "4.9.5"
    || root.source !== "Client/ExportedProject/Assets/Scenes/MainScene.unity"
    || typeof root.sourceSha256 !== "string" || !SHA256.test(root.sourceSha256)) {
    return invalid("Army Power catalog provenance is invalid.");
  }

  if (!Array.isArray(root.rankLevels) || root.rankLevels.length !== 58) {
    return invalid("Army Power catalog must contain exactly 58 player ranks.");
  }
  let previousLevel: PlayerLevelDefinition | undefined;
  const rankLevels = Object.freeze(root.rankLevels.map((candidate, index) => {
    const row = record(candidate, LEVEL_KEYS, `Player rank ${index}`);
    const next: PlayerLevelDefinition = {
      index: integer(row.index, `Player rank ${index} index`),
      displayLevel: integer(row.displayLevel, `Player rank ${index} display level`, 1),
      experience: integer(row.experience, `Player rank ${index} experience`, 1),
      rewardGold: integer(row.rewardGold, `Player rank ${index} Gold reward`),
      armyPower: integer(row.armyPower, `Player rank ${index} Army Power`),
      convertGoldToWarBucks: integer(row.convertGoldToWarBucks, `Player rank ${index} conversion`, 1),
    };
    if (next.index !== index || next.displayLevel !== index + 1
      || (previousLevel && (next.experience < previousLevel.experience
        || next.armyPower < previousLevel.armyPower
        || next.convertGoldToWarBucks < previousLevel.convertGoldToWarBucks))) {
      return invalid(`Player rank ${index} is non-contiguous or decreases durable authority.`);
    }
    previousLevel = next;
    return Object.freeze(next);
  }));

  if (!Array.isArray(root.featureDpsCoefficients)
    || root.featureDpsCoefficients.length !== CATEGORY_NAMES.length) {
    return invalid("Army Power catalog must contain exactly 11 feature categories.");
  }
  const featureDpsCoefficients = Object.freeze(root.featureDpsCoefficients.map((candidate, categoryIndex) => {
    const row = record(candidate, CATEGORY_KEYS, `Weapon feature category ${categoryIndex}`);
    if (row.category !== CATEGORY_NAMES[categoryIndex] || row.categoryMask !== 2 ** categoryIndex
      || !Array.isArray(row.dpsByFeature) || row.dpsByFeature.length !== FEATURE_NAMES.length) {
      return invalid(`Weapon feature category ${categoryIndex} is invalid.`);
    }
    const dpsByFeature = Object.freeze(row.dpsByFeature.map((featureCandidate, featureIndex) => {
      const feature = record(featureCandidate, FEATURE_KEYS, `Weapon feature ${categoryIndex}:${featureIndex}`);
      if (feature.index !== featureIndex || feature.name !== FEATURE_NAMES[featureIndex]
        || typeof feature.coefficient !== "number" || !Number.isFinite(feature.coefficient)
        || feature.coefficient <= 0 || feature.coefficient > 10) {
        return invalid(`Weapon feature ${categoryIndex}:${featureIndex} is invalid.`);
      }
      return Object.freeze({
        index: featureIndex,
        name: FEATURE_NAMES[featureIndex]!,
        coefficient: feature.coefficient,
      });
    }));
    return Object.freeze({
      category: CATEGORY_NAMES[categoryIndex]!,
      categoryMask: 2 ** categoryIndex,
      dpsByFeature,
    });
  }));

  if (!Array.isArray(root.weapons) || root.weapons.length !== 165) {
    return invalid("Army Power catalog must contain exactly 165 weapon rows.");
  }
  const names = new Set<string>();
  const indexes = new Set<number>();
  let dpsRows = 0;
  const weapons = Object.freeze(root.weapons.map((candidate, rowIndex) => {
    const row = record(candidate, WEAPON_KEYS, `Weapon power row ${rowIndex}`);
    const index = integer(row.index, `Weapon power row ${rowIndex} index`);
    if (typeof row.name !== "string" || row.name.length < 1 || row.name.length > 128
      || names.has(row.name) || indexes.has(index) || !Array.isArray(row.powerByLevel)
      || row.powerByLevel.length < 1) {
      return invalid(`Weapon power row ${rowIndex} has invalid or duplicate identity.`);
    }
    let previous = -1;
    const powerByLevel = Object.freeze(row.powerByLevel.map((power, levelIndex) => {
      if (typeof power !== "number" || !Number.isFinite(power) || power < 0 || power < previous) {
        return invalid(`Weapon ${row.name} DPS row ${levelIndex} is invalid.`);
      }
      previous = power;
      dpsRows += 1;
      return power;
    }));
    names.add(row.name);
    indexes.add(index);
    return Object.freeze({ name: row.name, index, powerByLevel });
  }));
  if (dpsRows !== 11_805) return invalid("Army Power catalog must contain exactly 11,805 weapon DPS rows.");

  return Object.freeze({
    schemaVersion: 2,
    clientVersion: "4.9.5",
    source: root.source as string,
    sourceSha256: root.sourceSha256 as string,
    rankLevels,
    featureDpsCoefficients,
    weapons,
  });
}

export const VALIDATED_ARMY_POWER_CATALOG = validatedArmyPowerCatalogArtifact(generatedArmyPowerCatalog);
