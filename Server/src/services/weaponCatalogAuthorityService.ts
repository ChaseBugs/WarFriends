import { ApiError, ApiErrorCode } from "../apiErrors";
import generatedWeaponCatalog from "../data/weaponCatalog.generated.json";

export interface WeaponCatalogDefinition {
  name: string;
  index: number;
  category: number;
  canBuyLevelIndex: number;
  unlockLevel: number;
  warBucks: number;
  gold: number;
  deliverySeconds: number;
  starterOwned: boolean;
}

export interface UnresolvedWeaponDefinition {
  name: string;
  category: number;
  canBuyLevelIndex: number;
  unlockLevel: number;
  warBucks: number;
  gold: number;
  deliverySeconds: number;
  reason: string;
}

export interface ValidatedWeaponCatalog {
  schemaVersion: number;
  source: string;
  sourceSha256: string;
  catalog: readonly Readonly<WeaponCatalogDefinition>[];
  unresolvedShopRows: readonly Readonly<UnresolvedWeaponDefinition>[];
  blackMarketCatalog: readonly Readonly<WeaponCatalogDefinition>[];
  unresolvedBlackMarketRows: readonly Readonly<UnresolvedWeaponDefinition>[];
}

const ROOT_KEYS = new Set([
  "schemaVersion", "source", "sourceSha256", "catalog", "unresolvedShopRows",
  "blackMarketCatalog", "unresolvedBlackMarketRows",
]);
const RESOLVED_KEYS = new Set([
  "name", "index", "category", "canBuyLevelIndex", "unlockLevel", "warBucks", "gold",
  "deliverySeconds", "starterOwned",
]);
const UNRESOLVED_KEYS = new Set([
  "name", "category", "canBuyLevelIndex", "unlockLevel", "warBucks", "gold",
  "deliverySeconds", "reason",
]);
const SHA256 = /^[0-9a-f]{64}$/;
const WEAPON_NAME = /^Google2u\.[A-Za-z0-9_]{1,120}$/;
const UNRESOLVED_REASON = "No non-null LevelManager.weaponLevelsSetups entry resolves this row.";

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

function integer(value: unknown, label: string, minimum = 0): number {
  if (!Number.isSafeInteger(value) || (value as number) < minimum || (value as number) > 2_147_483_647) {
    return invalid(`${label} is invalid.`);
  }
  return value as number;
}

function baseRow(row: Record<string, unknown>, label: string) {
  const name = row.name;
  const category = integer(row.category, `${label} category`, 1);
  if (typeof name !== "string" || !WEAPON_NAME.test(name)
    || category > 1024 || (category & (category - 1)) !== 0) {
    return invalid(`${label} has invalid identity or category.`);
  }
  return {
    name,
    category,
    canBuyLevelIndex: integer(row.canBuyLevelIndex, `${label} purchase level`, 0),
    unlockLevel: integer(row.unlockLevel, `${label} unlock level`, 1),
    warBucks: integer(row.warBucks, `${label} WarBucks price`),
    gold: integer(row.gold, `${label} Gold price`),
    deliverySeconds: integer(row.deliverySeconds, `${label} delivery duration`),
  };
}

function resolvedRows(
  value: unknown,
  count: number,
  family: string,
  names: Set<string>,
  indexes: Set<number>,
): readonly Readonly<WeaponCatalogDefinition>[] {
  if (!Array.isArray(value) || value.length !== count) return invalid(`${family} must contain exactly ${count} rows.`);
  let previousIndex = -1;
  return Object.freeze(value.map((candidate, rowIndex) => {
    const row = record(candidate, RESOLVED_KEYS, `${family} row ${rowIndex}`);
    const base = baseRow(row, `${family} row ${rowIndex}`);
    const index = integer(row.index, `${family} row ${rowIndex} index`);
    if (names.has(base.name) || indexes.has(index) || index <= previousIndex
      || row.deliverySeconds !== 0 || typeof row.starterOwned !== "boolean"
      || (family === "Black Market catalog" && row.starterOwned !== false)) {
      return invalid(`${family} row ${rowIndex} is duplicated, unordered, or contradictory.`);
    }
    names.add(base.name);
    indexes.add(index);
    previousIndex = index;
    return Object.freeze({ ...base, index, starterOwned: row.starterOwned });
  }));
}

function unresolvedRows(
  value: unknown,
  family: string,
  names: Set<string>,
): readonly Readonly<UnresolvedWeaponDefinition>[] {
  if (!Array.isArray(value) || value.length !== 9) return invalid(`${family} must contain exactly nine rows.`);
  let previousName = "";
  return Object.freeze(value.map((candidate, rowIndex) => {
    const row = record(candidate, UNRESOLVED_KEYS, `${family} row ${rowIndex}`);
    const base = baseRow(row, `${family} row ${rowIndex}`);
    if (names.has(base.name) || base.name.localeCompare(previousName) <= 0
      || row.deliverySeconds !== 0 || row.reason !== UNRESOLVED_REASON) {
      return invalid(`${family} row ${rowIndex} is duplicated, unordered, or contradictory.`);
    }
    names.add(base.name);
    previousName = base.name;
    return Object.freeze({ ...base, reason: UNRESOLVED_REASON });
  }));
}

/** Validate and deep-freeze all recovered shop and Black Market weapon identity/price rows. */
export function validatedWeaponCatalogArtifact(value: unknown): Readonly<ValidatedWeaponCatalog> {
  const root = record(value, ROOT_KEYS, "Weapon catalog root");
  if (root.schemaVersion !== 1 || root.source !== "Client/ExportedProject/Assets/Scenes/MainScene.unity"
    || typeof root.sourceSha256 !== "string" || !SHA256.test(root.sourceSha256)) {
    return invalid("Weapon catalog provenance is invalid.");
  }
  const names = new Set<string>();
  const indexes = new Set<number>();
  const catalog = resolvedRows(root.catalog, 84, "Shop weapon catalog", names, indexes);
  const unresolvedShopRows = unresolvedRows(root.unresolvedShopRows, "Unresolved shop catalog", names);
  const blackMarketCatalog = resolvedRows(root.blackMarketCatalog, 81, "Black Market catalog", names, indexes);
  const unresolvedBlackMarketRows = unresolvedRows(
    root.unresolvedBlackMarketRows,
    "Unresolved Black Market catalog",
    names,
  );
  if (catalog.filter((row) => row.starterOwned).length !== 4) {
    return invalid("Weapon catalog must contain exactly four starter-owned rows.");
  }
  return Object.freeze({
    schemaVersion: 1,
    source: root.source as string,
    sourceSha256: root.sourceSha256 as string,
    catalog,
    unresolvedShopRows,
    blackMarketCatalog,
    unresolvedBlackMarketRows,
  });
}

export const VALIDATED_WEAPON_CATALOG = validatedWeaponCatalogArtifact(generatedWeaponCatalog);
