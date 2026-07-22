import { ApiError, ApiErrorCode } from "../apiErrors";
import generatedVisualCatalog from "../data/visualCatalog.generated.json";

export interface VisualDefinition {
  name: string;
  unlockLevel: number;
  priceWarBucks: number;
  priceGold: number;
  durationSeconds: number;
  effectType: number;
  effectValue: number;
  categoryId: number;
  vipOnly: boolean;
  purchasable: string;
  rarity: number;
  parts: number;
  duplicateWarBucks: number;
}

export interface UnresolvedVisualDefinition extends VisualDefinition {
  reason: string;
}

export interface VisualCategoryDefinition {
  id: number;
  name: string;
  prefix: string;
  defaultId: string;
  ids: readonly string[];
}

export interface ValidatedVisualCatalogArtifact {
  schemaVersion: number;
  clientVersion: string;
  source: string;
  sourceSha256: string;
  categories: readonly Readonly<VisualCategoryDefinition>[];
  visuals: readonly Readonly<VisualDefinition>[];
  unresolvedRows: readonly Readonly<UnresolvedVisualDefinition>[];
}

const ROOT_KEYS = new Set([
  "schemaVersion", "clientVersion", "source", "sourceSha256", "categories", "visuals", "unresolvedRows",
]);
const CATEGORY_KEYS = new Set(["id", "name", "prefix", "defaultId", "ids"]);
const VISUAL_KEYS = new Set([
  "name", "unlockLevel", "priceWarBucks", "priceGold", "durationSeconds", "effectType",
  "effectValue", "categoryId", "vipOnly", "purchasable", "rarity", "parts", "duplicateWarBucks",
]);
const UNRESOLVED_KEYS = new Set([...VISUAL_KEYS, "reason"]);
const EXPECTED_CATEGORIES = Object.freeze([
  Object.freeze({ id: 0, name: "camo", prefix: "CAMOS_", defaultId: "CAMOS_DEFAULT", count: 31 }),
  Object.freeze({ id: 1, name: "helmet", prefix: "HELMETS_", defaultId: "HELMETS_EMPTY", count: 61 }),
  Object.freeze({ id: 2, name: "headAccessory", prefix: "HEAD_", defaultId: "HEAD_EMPTY", count: 47 }),
  Object.freeze({ id: 3, name: "powerBand", prefix: "BANDS_", defaultId: "BANDS_EMPTY", count: 7 }),
]);
const PURCHASE_SOURCES = new Set(["arena", "assignment", "event", "hidden", "loyalty", "shop", "value"]);
const VISUAL_ID = /^(?:CAMOS|HELMETS|HEAD|BANDS)_[A-Z0-9_]{1,127}$/;
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

function integer(value: unknown, label: string, minimum = 0, maximum = 2_147_483_647): number {
  if (!Number.isSafeInteger(value) || (value as number) < minimum || (value as number) > maximum) {
    return invalid(`${label} is invalid.`);
  }
  return value as number;
}

function categories(value: unknown): {
  rows: readonly Readonly<VisualCategoryDefinition>[];
  activeIds: ReadonlySet<string>;
  categoryById: ReadonlyMap<number, Readonly<VisualCategoryDefinition>>;
} {
  if (!Array.isArray(value) || value.length !== EXPECTED_CATEGORIES.length) {
    return invalid("Visual catalog must contain exactly four categories.");
  }
  const activeIds = new Set<string>();
  const rows = Object.freeze(value.map((candidate, index) => {
    const row = record(candidate, CATEGORY_KEYS, `Visual category ${index}`);
    const expected = EXPECTED_CATEGORIES[index];
    if (row.id !== expected.id || row.name !== expected.name || row.prefix !== expected.prefix
      || row.defaultId !== expected.defaultId || !Array.isArray(row.ids) || row.ids.length !== expected.count) {
      return invalid(`Visual category ${index} contradicts the recovered scene component.`);
    }
    const ids = Object.freeze(row.ids.map((id, visualIndex) => {
      if (typeof id !== "string" || !VISUAL_ID.test(id) || !id.startsWith(expected.prefix)
        || activeIds.has(id)) {
        return invalid(`Visual category ${index} asset ${visualIndex} is invalid or duplicated.`);
      }
      activeIds.add(id);
      return id;
    }));
    if (ids[0] !== expected.defaultId) return invalid(`Visual category ${index} has an invalid default.`);
    return Object.freeze({
      id: expected.id,
      name: expected.name,
      prefix: expected.prefix,
      defaultId: expected.defaultId,
      ids,
    });
  }));
  return { rows, activeIds, categoryById: new Map(rows.map((row) => [row.id, row])) };
}

function visualRow(
  candidate: unknown,
  index: number,
  unresolved: boolean,
  categoryById: ReadonlyMap<number, Readonly<VisualCategoryDefinition>>,
): Readonly<VisualDefinition | UnresolvedVisualDefinition> {
  const row = record(candidate, unresolved ? UNRESOLVED_KEYS : VISUAL_KEYS, `Visual row ${index}`);
  const name = row.name;
  const categoryId = integer(row.categoryId, `Visual row ${index} category`, 0, 3);
  const category = categoryById.get(categoryId);
  if (typeof name !== "string" || !VISUAL_ID.test(name) || !category || !name.startsWith(category.prefix)
    || typeof row.vipOnly !== "boolean" || typeof row.purchasable !== "string"
    || !PURCHASE_SOURCES.has(row.purchasable)) {
    return invalid(`Visual row ${index} has invalid identity or availability.`);
  }
  const effectValue = row.effectValue;
  if (typeof effectValue !== "number" || !Number.isFinite(effectValue) || effectValue < 0) {
    return invalid(`Visual ${name} effect value is invalid.`);
  }
  const definition: VisualDefinition = {
    name,
    unlockLevel: integer(row.unlockLevel, `Visual ${name} unlock level`),
    priceWarBucks: integer(row.priceWarBucks, `Visual ${name} WarBucks price`),
    priceGold: integer(row.priceGold, `Visual ${name} Gold price`),
    durationSeconds: integer(row.durationSeconds, `Visual ${name} duration`),
    effectType: integer(row.effectType, `Visual ${name} effect type`, -1, 2),
    effectValue,
    categoryId,
    vipOnly: row.vipOnly,
    purchasable: row.purchasable,
    rarity: integer(row.rarity, `Visual ${name} rarity`),
    parts: integer(row.parts, `Visual ${name} part target`),
    duplicateWarBucks: integer(row.duplicateWarBucks, `Visual ${name} duplicate reward`),
  };
  if (unresolved) {
    if (row.reason !== "No matching serialized PlayerVisual asset in MainScene.") {
      return invalid(`Unresolved visual ${name} has an invalid reason.`);
    }
    return Object.freeze({ ...definition, reason: row.reason as string });
  }
  return Object.freeze(definition);
}

/** Validate and deep-freeze the one visual authority shared by entitlements, economy, and sync. */
export function validatedVisualCatalogArtifact(value: unknown): Readonly<ValidatedVisualCatalogArtifact> {
  const root = record(value, ROOT_KEYS, "Visual catalog root");
  if (root.schemaVersion !== 1 || root.clientVersion !== "4.9.5"
    || root.source !== "Client/ExportedProject/Assets/Scenes/MainScene.unity"
    || typeof root.sourceSha256 !== "string" || !SHA256.test(root.sourceSha256)) {
    return invalid("Visual catalog provenance is invalid.");
  }
  const validatedCategories = categories(root.categories);
  if (!Array.isArray(root.visuals) || root.visuals.length !== 146
    || !Array.isArray(root.unresolvedRows) || root.unresolvedRows.length !== 1) {
    return invalid("Visual catalog row counts are incomplete.");
  }
  const names = new Set<string>();
  let previous: VisualDefinition | undefined;
  const visuals = Object.freeze(root.visuals.map((candidate, index) => {
    const row = visualRow(candidate, index, false, validatedCategories.categoryById) as Readonly<VisualDefinition>;
    if (!validatedCategories.activeIds.has(row.name) || names.has(row.name)
      || (previous && (previous.categoryId > row.categoryId
        || (previous.categoryId === row.categoryId && previous.name.localeCompare(row.name) >= 0)))) {
      return invalid(`Visual row ${index} is missing from its category or out of deterministic order.`);
    }
    names.add(row.name);
    previous = row;
    return row;
  }));
  if (names.size !== validatedCategories.activeIds.size) {
    return invalid("Visual catalog does not exactly cover the serialized category assets.");
  }
  const unresolvedRows = Object.freeze(root.unresolvedRows.map((candidate, index) => {
    const row = visualRow(candidate, index, true, validatedCategories.categoryById) as Readonly<UnresolvedVisualDefinition>;
    if (names.has(row.name) || validatedCategories.activeIds.has(row.name)) {
      return invalid(`Unresolved visual row ${index} duplicates a playable asset.`);
    }
    names.add(row.name);
    return row;
  }));
  return Object.freeze({
    schemaVersion: 1,
    clientVersion: "4.9.5",
    source: root.source as string,
    sourceSha256: root.sourceSha256 as string,
    categories: validatedCategories.rows,
    visuals,
    unresolvedRows,
  });
}

export const VALIDATED_VISUAL_CATALOG = validatedVisualCatalogArtifact(generatedVisualCatalog);
