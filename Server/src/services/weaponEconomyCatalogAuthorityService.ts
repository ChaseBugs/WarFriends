import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  WEAPON_BLACK_MARKET_PRICES as generatedBlackMarketPrices,
  WEAPON_UPGRADE_CATALOG as generatedWeaponUpgrades,
} from "../data/weaponUpgradeCatalog.generated";
import { VALIDATED_ARMY_POWER_CATALOG } from "./armyPowerCatalogAuthorityService";
import { VALIDATED_WEAPON_CATALOG } from "./weaponCatalogAuthorityService";

export type WeaponUpgradeStage = readonly [warBucks: number, deliverySeconds: number];

export interface ValidatedWeaponEconomyCatalog {
  upgrades: Readonly<Record<string, readonly WeaponUpgradeStage[]>>;
  blackMarketPrices: Readonly<Record<string, readonly number[]>>;
}

const MAX_CLIENT_INTEGER = 2_147_483_647;
const EXPECTED_UPGRADE_ROWS = 11_640;
const EXPECTED_BLACK_MARKET_PRICE_ROWS = 5_860;
// These two concrete LevelManager tables have no WEAPONPRICE column. Keeping their identities
// explicit prevents a generated empty/default price from silently enabling their sale.
const BLACK_MARKET_WITHOUT_SOURCE_PRICE = new Set([
  "Google2u.LMG_GSh",
  "Google2u.LMG_Scifi",
]);

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function dictionary(value: unknown, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) return invalid(`${label} is invalid.`);
  return value as Record<string, unknown>;
}

function positiveInteger(value: unknown, label: string): number {
  if (!Number.isSafeInteger(value) || (value as number) <= 0 || (value as number) > MAX_CLIENT_INTEGER) {
    return invalid(`${label} is invalid.`);
  }
  return value as number;
}

/**
 * Validate the generated weapon upgrade and Black Market tables against both identity and combat
 * power authority. The extractor emits TypeScript rather than a provenance-bearing JSON artifact,
 * so its strongest runtime proof is conservation across the independently validated catalogs:
 * exact weapon order and indexes, one fewer upgrade than DPS rows, and one more purchase price than
 * upgrades for every Black Market table whose source actually contains WEAPONPRICE.
 */
export function validatedWeaponEconomyCatalog(
  upgradeValue: unknown,
  blackMarketValue: unknown,
): Readonly<ValidatedWeaponEconomyCatalog> {
  const rawUpgrades = dictionary(upgradeValue, "Weapon upgrade catalog");
  const definitions = [
    ...VALIDATED_WEAPON_CATALOG.catalog,
    ...VALIDATED_WEAPON_CATALOG.blackMarketCatalog,
  ];
  const upgradeKeys = Object.keys(rawUpgrades);
  if (upgradeKeys.length !== definitions.length
    || upgradeKeys.some((key, index) => key !== definitions[index]?.name)) {
    return invalid("Weapon upgrade catalog identities are incomplete, duplicated, or unordered.");
  }

  const powerByName = new Map(VALIDATED_ARMY_POWER_CATALOG.weapons.map((row) => [row.name, row]));
  let upgradeRows = 0;
  const upgrades: Record<string, readonly WeaponUpgradeStage[]> = {};
  for (const definition of definitions) {
    const rawStages = rawUpgrades[definition.name];
    const power = powerByName.get(definition.name);
    if (!Array.isArray(rawStages) || rawStages.length < 1 || !power
      || power.index !== definition.index || power.powerByLevel.length !== rawStages.length + 1) {
      return invalid(`Weapon ${definition.name} has incompatible upgrade or Army Power authority.`);
    }
    let previousDuration = -1;
    const stages = Object.freeze(rawStages.map((candidate, stageIndex) => {
      if (!Array.isArray(candidate) || candidate.length !== 2) {
        return invalid(`Weapon ${definition.name} upgrade ${stageIndex} has an invalid field set.`);
      }
      const warBucks = positiveInteger(candidate[0], `Weapon ${definition.name} upgrade ${stageIndex} price`);
      const deliverySeconds = positiveInteger(
        candidate[1],
        `Weapon ${definition.name} upgrade ${stageIndex} duration`,
      );
      if (deliverySeconds < previousDuration) {
        return invalid(`Weapon ${definition.name} upgrade durations are out of source order.`);
      }
      previousDuration = deliverySeconds;
      upgradeRows += 1;
      return Object.freeze([warBucks, deliverySeconds] as const);
    }));
    upgrades[definition.name] = stages;
  }
  if (upgradeRows !== EXPECTED_UPGRADE_ROWS) {
    return invalid(`Weapon upgrade catalog must contain exactly ${EXPECTED_UPGRADE_ROWS} stages.`);
  }

  const rawBlackMarket = dictionary(blackMarketValue, "Black Market price catalog");
  const pricedDefinitions = VALIDATED_WEAPON_CATALOG.blackMarketCatalog.filter(
    (definition) => !BLACK_MARKET_WITHOUT_SOURCE_PRICE.has(definition.name),
  );
  const blackMarketKeys = Object.keys(rawBlackMarket);
  if (blackMarketKeys.length !== pricedDefinitions.length
    || blackMarketKeys.some((key, index) => key !== pricedDefinitions[index]?.name)) {
    return invalid("Black Market price identities are incomplete, unsupported, or unordered.");
  }

  let priceRows = 0;
  const blackMarketPrices: Record<string, readonly number[]> = {};
  for (const definition of pricedDefinitions) {
    const rawPrices = rawBlackMarket[definition.name];
    const stages = upgrades[definition.name]!;
    if (!Array.isArray(rawPrices) || rawPrices.length !== stages.length + 1) {
      return invalid(`Black Market weapon ${definition.name} has an incompatible price range.`);
    }
    let previousPrice = -1;
    const prices = Object.freeze(rawPrices.map((candidate, level) => {
      const price = positiveInteger(candidate, `Black Market weapon ${definition.name} level ${level} price`);
      if (price < previousPrice) {
        return invalid(`Black Market weapon ${definition.name} prices are out of source order.`);
      }
      previousPrice = price;
      priceRows += 1;
      return price;
    }));
    blackMarketPrices[definition.name] = prices;
  }
  if (priceRows !== EXPECTED_BLACK_MARKET_PRICE_ROWS) {
    return invalid(`Black Market price catalog must contain exactly ${EXPECTED_BLACK_MARKET_PRICE_ROWS} rows.`);
  }

  return Object.freeze({
    upgrades: Object.freeze(upgrades),
    blackMarketPrices: Object.freeze(blackMarketPrices),
  });
}

const VALIDATED_WEAPON_ECONOMY = validatedWeaponEconomyCatalog(
  generatedWeaponUpgrades,
  generatedBlackMarketPrices,
);
export const VALIDATED_WEAPON_UPGRADE_CATALOG = VALIDATED_WEAPON_ECONOMY.upgrades;
export const VALIDATED_WEAPON_BLACK_MARKET_PRICES = VALIDATED_WEAPON_ECONOMY.blackMarketPrices;
