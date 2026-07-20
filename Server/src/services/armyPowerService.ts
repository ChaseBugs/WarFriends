import generatedArmyPowerCatalog from "../data/armyPowerCatalog.generated.json";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { players, type PlayerDocument, type PlayerProgressionState } from "../db";
import {
  BLACK_MARKET_WEAPON_CATALOG,
  itemInventoryStateFor,
  weaponDefinitionFor,
} from "./itemInventoryService";
import { progressionForPlayer } from "./playerStateService";
import { equippedUnitPower } from "./unitInventoryService";

interface WeaponPowerDefinition {
  name: string;
  index: number;
  powerByLevel: number[];
}

interface ArmyPowerArtifact {
  schemaVersion: number;
  clientVersion: string;
  source: string;
  sourceSha256: string;
  rankLevels: Array<{ index: number; displayLevel: number; armyPower: number }>;
  featureDpsCoefficients: Array<{
    categoryMask: number;
    dpsByFeature: Array<{ index: number; coefficient: number }>;
  }>;
  weapons: WeaponPowerDefinition[];
}

export interface ArmyPowerBreakdown {
  unitPower: number;
  weaponPower: number;
  rankPower: number;
  total: number;
}

const artifact = generatedArmyPowerCatalog as ArmyPowerArtifact;
const WEAPON_POWER = Object.freeze(Object.fromEntries(
  artifact.weapons.map((weapon) => [weapon.name, Object.freeze({
    ...weapon,
    powerByLevel: Object.freeze([...weapon.powerByLevel]),
  })]),
)) as Readonly<Record<string, Readonly<WeaponPowerDefinition>>>;
const FEATURE_DPS = Object.freeze(Object.fromEntries(
  artifact.featureDpsCoefficients.map((category) => [
    category.categoryMask,
    Object.freeze(Object.fromEntries(category.dpsByFeature.map((feature) => [feature.index, feature.coefficient]))),
  ]),
)) as Readonly<Record<number, Readonly<Record<number, number>>>>;

function roundPositiveUnityFloat(value: number): number {
  // MEJMLNDFDBP.LJDADOKBBNA is the positive Army Power rounding boundary used by
  // LevelManager. The value has already been accumulated as C# float, so apply one final
  // float32 addition before FloorToInt instead of JavaScript's double-precision Math.round.
  return Math.floor(Math.fround(Math.fround(value) + Math.fround(0.5)));
}

/** Return the current level row's exact ARMYPOWER value, using LevelManager's clamp rule. */
export function rankPower(playerLevelIndex: number): number {
  if (artifact.rankLevels.length === 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Rank Army Power catalog is empty.");
  }
  const index = Math.max(0, Math.min(
    Math.trunc(Number.isFinite(playerLevelIndex) ? playerLevelIndex : 0),
    artifact.rankLevels.length - 1,
  ));
  return artifact.rankLevels[index]!.armyPower;
}

/**
 * Reproduce LevelManager.weaponPower for the four persisted PlayerInventory slots.
 *
 * WeaponLevelsSetup selects DPS by the stored normal boughtIndex, multiplies it by the active
 * feature's dpsCoef, accumulates every slot as float32, and rounds once. The authoritative
 * normal shop rows use their base coefficient. Dedicated Black Market rows load `special`
 * through WeaponFeatures.CreateFeature, so their recovered category/index coefficient is
 * applied here. Borrowed rental authority remains fail-closed.
 */
export function equippedWeaponPower(state: PlayerProgressionState): number {
  const inventory = itemInventoryStateFor(state);
  const slots = Object.entries(inventory.inventoryData.slots)
    .sort(([left], [right]) => Number(left) - Number(right));
  let total = Math.fround(0);

  for (const [, slot] of slots) {
    const definition = weaponDefinitionFor(slot.name);
    const power = WEAPON_POWER[slot.name];
    const saved = inventory.levelManagerData.savedWeapons[slot.name];
    if (
      !definition
      || !power
      || power.index !== slot.weaponIndex
      || definition.index !== slot.weaponIndex
      || !saved?.bought
    ) {
      throw new ApiError(ApiErrorCode.UnknownAction, `Equipped weapon ${slot.name} is not authoritative.`);
    }
    if (saved.borrowed) {
      throw new ApiError(
        ApiErrorCode.UnknownAction,
        `Weapon ${slot.name} uses unsupported rental authority.`,
      );
    }
    if (!Number.isInteger(saved.boughtIndex) || saved.boughtIndex < 0 || power.powerByLevel.length === 0) {
      throw new ApiError(ApiErrorCode.UnknownAction, `Weapon ${slot.name} has an invalid upgrade cursor.`);
    }

    // WeaponLevelsSetup clamps the cursor to 0..maxWeaponLevel-1. The extraction has already
    // removed the final WARARENA-only source row, so the final array index is the same normal
    // clamp boundary used by the recovered client.
    const levelIndex = Math.min(saved.boughtIndex, power.powerByLevel.length - 1);
    const baseDps = power.powerByLevel[levelIndex]!;
    let coefficient = 1;
    if (BLACK_MARKET_WEAPON_CATALOG[slot.name]) {
      coefficient = FEATURE_DPS[definition.category]?.[saved.specialFeature] ?? Number.NaN;
      if (!Number.isFinite(coefficient) || coefficient <= 0) {
        throw new ApiError(
          ApiErrorCode.UnknownAction,
          `Weapon ${slot.name} has an unsupported Black Market feature.`,
        );
      }
    } else if (saved.specialFeature !== 0) {
      throw new ApiError(ApiErrorCode.UnknownAction, `Normal weapon ${slot.name} has an invalid feature.`);
    }
    const dps = Math.fround(Math.fround(baseDps) * Math.fround(coefficient));
    total = Math.fround(total + dps);
  }

  return roundPositiveUnityFloat(total);
}

/** Calculate all three independently rounded LevelManager Army Power components. */
export function calculateArmyPower(document: PlayerDocument): ArmyPowerBreakdown {
  const progression = progressionForPlayer(document);
  const unitPower = equippedUnitPower(progression);
  const weaponPower = equippedWeaponPower(progression);
  const currentRankPower = rankPower(document.player.level);
  return {
    unitPower,
    weaponPower,
    rankPower: currentRankPower,
    total: unitPower + weaponPower + currentRankPower,
  };
}

/**
 * Recompute and persist the public/indexed Army Power cache from one consistent progression
 * revision. A concurrent inventory mutation makes the compare-and-swap miss and triggers a
 * reload, preventing an older equipment snapshot from overwriting the newly derived total.
 */
export async function recomputePlayerArmyPower(playerId: string): Promise<ArmyPowerBreakdown> {
  for (let attempt = 0; attempt < 4; attempt++) {
    const document = await players().findOne({ id: playerId });
    if (!document) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    const breakdown = calculateArmyPower(document);
    const revision = document.progression?.revision;
    const revisionFilter = revision === undefined
      ? { "progression.revision": { $exists: false } }
      : { "progression.revision": revision };
    const result = await players().updateOne(
      { id: playerId, ...revisionFilter },
      {
        $set: {
          armyPower: breakdown.total,
          "player.armyPower": breakdown.total,
          updatedAt: new Date(),
        },
      },
    );
    if (result.matchedCount === 1) return breakdown;
  }
  throw new ApiError(ApiErrorCode.InternalServerError, "Army Power changed concurrently; retry the request.");
}
