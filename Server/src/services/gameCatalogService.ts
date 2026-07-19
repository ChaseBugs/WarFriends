import { createHash } from "node:crypto";
import type { Collection } from "mongodb";
import generatedArmyPowerCatalog from "../data/armyPowerCatalog.generated.json";
import generatedUnitCatalog from "../data/unitCatalog.generated.json";
import generatedUnitUpgradeCatalog from "../data/unitUpgradeCatalog.generated.json";
import generatedWeaponCatalog from "../data/weaponCatalog.generated.json";
import { WEAPON_UPGRADE_CATALOG } from "../data/weaponUpgradeCatalog.generated";

export const GAME_CATALOG_CLIENT_VERSION = "4.9.5";

export type GameCatalogKind = "weapon" | "unit" | "rank" | "weaponFeature";
export type GameCatalogAvailability = "playable" | "helper" | "reference" | "unresolved";

export interface GameCatalogEntryDocument {
  clientVersion: string;
  catalogRevision: string;
  kind: GameCatalogKind;
  key: string;
  availability: GameCatalogAvailability;
  /** Hash of this entry only, used to audit balancing changes without comparing large payloads. */
  contentHash: string;
  source: string;
  sourceSha256: string;
  sourceSchemaVersion: number;
  data: Record<string, unknown>;
  createdAt: Date;
  updatedAt: Date;
}

export interface GameCatalogCounts {
  weapons: number;
  playableWeapons: number;
  unresolvedWeapons: number;
  weaponUpgradeLevels: number;
  weaponPowerLevels: number;
  rankPowerLevels: number;
  weaponFeatureRows: number;
  units: number;
  playableUnits: number;
  helperUnits: number;
  unresolvedUnits: number;
  normalUnitUpgradeLevels: number;
  specialUnitUpgradeLevels: number;
  eliteUnitUpgradeLevels: number;
}

export interface GameCatalogReleaseDocument {
  clientVersion: string;
  catalogRevision: string;
  entryCount: number;
  counts: GameCatalogCounts;
  sources: Array<{
    path: string;
    sha256: string;
    schemaVersion: number;
  }>;
  createdAt: Date;
  updatedAt: Date;
}

export interface BuiltGameCatalog {
  clientVersion: string;
  catalogRevision: string;
  entries: Array<Omit<GameCatalogEntryDocument, "createdAt" | "updatedAt">>;
  counts: GameCatalogCounts;
  sources: GameCatalogReleaseDocument["sources"];
}

interface CatalogArtifact<Row> {
  schemaVersion: number;
  source: string;
  sourceSha256: string;
  catalog: Row[];
}

interface WeaponArtifact extends CatalogArtifact<Record<string, unknown>> {
  unresolvedShopRows: Array<Record<string, unknown>>;
}

interface UnitArtifact extends CatalogArtifact<Record<string, unknown>> {
  unresolvedRows: Array<Record<string, unknown>>;
}

interface UnitUpgradeRow extends Record<string, unknown> {
  name: string;
  normalLevels: Array<Record<string, unknown>>;
  specialLevels: Array<Record<string, unknown>>;
  eliteLevels?: Array<Record<string, unknown>>;
}

type UnitUpgradeArtifact = CatalogArtifact<UnitUpgradeRow>;

interface ArmyPowerArtifact {
  schemaVersion: number;
  clientVersion: string;
  source: string;
  sourceSha256: string;
  rankLevels: Array<Record<string, unknown>>;
  featureDpsCoefficients: Array<{
    category: string;
    categoryMask: number;
    dpsByFeature: Array<Record<string, unknown>>;
  }>;
  weapons: Array<{ name: string; index: number; powerByLevel: number[] }>;
}

const weapons = generatedWeaponCatalog as unknown as WeaponArtifact;
const units = generatedUnitCatalog as unknown as UnitArtifact;
const unitUpgrades = generatedUnitUpgradeCatalog as unknown as UnitUpgradeArtifact;
const armyPower = generatedArmyPowerCatalog as unknown as ArmyPowerArtifact;

/**
 * JSON.stringify preserves insertion order, which is not a safe canonical form for hashes.
 * Recursively sorting object keys makes release IDs stable across operating systems and lets
 * an operator prove that two databases contain exactly the same recovered client balancing.
 */
function canonicalize(value: unknown): unknown {
  if (Array.isArray(value)) return value.map(canonicalize);
  if (value && typeof value === "object" && !(value instanceof Date)) {
    return Object.fromEntries(
      Object.entries(value as Record<string, unknown>)
        .sort(([left], [right]) => left.localeCompare(right))
        .map(([key, child]) => [key, canonicalize(child)]),
    );
  }
  return value;
}

export function catalogContentHash(value: unknown): string {
  return createHash("sha256").update(JSON.stringify(canonicalize(value))).digest("hex");
}

function requiredName(row: Record<string, unknown>, family: string): string {
  if (typeof row.name !== "string" || row.name.length === 0) {
    throw new Error(`${family} catalog contains a row without a name.`);
  }
  return row.name;
}

function sourceFor(artifact: CatalogArtifact<unknown>): Pick<GameCatalogEntryDocument,
  "source" | "sourceSha256" | "sourceSchemaVersion"> {
  return {
    source: artifact.source,
    sourceSha256: artifact.sourceSha256,
    sourceSchemaVersion: artifact.schemaVersion,
  };
}

/**
 * Builds the database representation exclusively from checked-in, reproducible client
 * extractions. Runtime player input is never accepted here. Resolved shop rows are joined to
 * their complete upgrade tables, while unresolved and helper rows are deliberately retained
 * with a non-playable availability flag so later research does not silently lose evidence.
 */
export function buildGameCatalog(): BuiltGameCatalog {
  const rawEntries: Array<Omit<GameCatalogEntryDocument,
    "clientVersion" | "catalogRevision" | "contentHash" | "createdAt" | "updatedAt">> = [];
  const weaponSource = sourceFor(weapons);
  const unitSource = sourceFor(units);
  const weaponPowerByName = new Map(armyPower.weapons.map((row) => [row.name, row]));

  for (const definition of weapons.catalog) {
    const key = requiredName(definition, "Weapon");
    const stages = WEAPON_UPGRADE_CATALOG[key];
    if (!stages) throw new Error(`Resolved weapon ${key} has no upgrade table.`);
    const power = weaponPowerByName.get(key);
    if (!power || power.index !== definition.index || power.powerByLevel.length !== stages.length + 1) {
      throw new Error(`Resolved weapon ${key} has an incompatible Army Power table.`);
    }

    rawEntries.push({
      kind: "weapon",
      key,
      availability: "playable",
      ...weaponSource,
      data: {
        definition,
        upgradeLevels: stages.map(([warBucks, deliverySeconds], level) => ({
          level,
          warBucks,
          deliverySeconds,
        })),
        powerByLevel: power.powerByLevel,
      },
    });
  }

  for (const definition of weapons.unresolvedShopRows) {
    rawEntries.push({
      kind: "weapon",
      key: requiredName(definition, "Unresolved weapon"),
      availability: "unresolved",
      ...weaponSource,
      data: { definition, upgradeLevels: [] },
    });
  }

  const unitUpgradesByName = new Map(unitUpgrades.catalog.map((row) => [row.name, row]));
  for (const definition of units.catalog) {
    const key = requiredName(definition, "Unit");
    const roster = definition.roster;
    const upgrades = unitUpgradesByName.get(key);
    if (roster === "player" && !upgrades) {
      throw new Error(`Player unit ${key} has no upgrade table.`);
    }

    rawEntries.push({
      kind: "unit",
      key,
      availability: roster === "player" ? "playable" : "helper",
      ...unitSource,
      data: {
        definition,
        normalLevels: upgrades?.normalLevels ?? [],
        specialLevels: upgrades?.specialLevels ?? [],
        eliteLevels: upgrades?.eliteLevels ?? [],
      },
    });
  }

  for (const definition of units.unresolvedRows) {
    rawEntries.push({
      kind: "unit",
      key: requiredName(definition, "Unresolved unit"),
      availability: "unresolved",
      ...unitSource,
      data: { definition, normalLevels: [], specialLevels: [], eliteLevels: [] },
    });
  }

  const rankSource = {
    source: armyPower.source,
    sourceSha256: armyPower.sourceSha256,
    sourceSchemaVersion: armyPower.schemaVersion,
  };
  for (const definition of armyPower.rankLevels) {
    const displayLevel = definition.displayLevel;
    if (!Number.isInteger(displayLevel) || Number(displayLevel) <= 0) {
      throw new Error("Rank Army Power catalog contains an invalid display level.");
    }
    rawEntries.push({
      kind: "rank",
      key: `Level.${displayLevel}`,
      availability: "playable",
      ...rankSource,
      data: { definition },
    });
  }

  for (const definition of armyPower.featureDpsCoefficients) {
    if (!definition.category || !Number.isInteger(definition.categoryMask)) {
      throw new Error("Weapon feature catalog contains an invalid category row.");
    }
    rawEntries.push({
      kind: "weaponFeature",
      key: `WeaponFeature.${definition.category}`,
      // Coefficients are verified reference data, but their black-market acquisition flow is
      // not implemented. A distinct availability prevents data presence from authorizing sale.
      availability: "reference",
      ...rankSource,
      data: { definition },
    });
  }

  rawEntries.sort((left, right) =>
    left.kind.localeCompare(right.kind) || left.key.localeCompare(right.key));
  const duplicateKeys = rawEntries.filter((entry, index) =>
    index > 0 && entry.kind === rawEntries[index - 1]?.kind && entry.key === rawEntries[index - 1]?.key);
  if (duplicateKeys.length > 0) {
    throw new Error(`Catalog has duplicate keys: ${duplicateKeys.map((entry) => `${entry.kind}:${entry.key}`).join(", ")}`);
  }

  const entryBodies = rawEntries.map((entry) => ({
    ...entry,
    contentHash: catalogContentHash(entry),
  }));
  const catalogRevision = catalogContentHash(entryBodies.map((entry) => ({
    kind: entry.kind,
    key: entry.key,
    contentHash: entry.contentHash,
  })));
  const entries = entryBodies.map((entry) => ({
    clientVersion: GAME_CATALOG_CLIENT_VERSION,
    catalogRevision,
    ...entry,
  }));

  const playableWeapons = entries.filter((entry) => entry.kind === "weapon" && entry.availability === "playable");
  const unresolvedWeapons = entries.filter((entry) => entry.kind === "weapon" && entry.availability === "unresolved");
  const playableUnits = entries.filter((entry) => entry.kind === "unit" && entry.availability === "playable");
  const helperUnits = entries.filter((entry) => entry.kind === "unit" && entry.availability === "helper");
  const unresolvedUnits = entries.filter((entry) => entry.kind === "unit" && entry.availability === "unresolved");

  const countLevels = (entry: typeof entries[number], field: string): number => {
    const levels = entry.data[field];
    return Array.isArray(levels) ? levels.length : 0;
  };
  const counts: GameCatalogCounts = {
    weapons: playableWeapons.length + unresolvedWeapons.length,
    playableWeapons: playableWeapons.length,
    unresolvedWeapons: unresolvedWeapons.length,
    weaponUpgradeLevels: playableWeapons.reduce((total, entry) => total + countLevels(entry, "upgradeLevels"), 0),
    weaponPowerLevels: playableWeapons.reduce((total, entry) => total + countLevels(entry, "powerByLevel"), 0),
    rankPowerLevels: armyPower.rankLevels.length,
    weaponFeatureRows: armyPower.featureDpsCoefficients.length,
    units: playableUnits.length + helperUnits.length + unresolvedUnits.length,
    playableUnits: playableUnits.length,
    helperUnits: helperUnits.length,
    unresolvedUnits: unresolvedUnits.length,
    normalUnitUpgradeLevels: playableUnits.reduce((total, entry) => total + countLevels(entry, "normalLevels"), 0),
    specialUnitUpgradeLevels: playableUnits.reduce((total, entry) => total + countLevels(entry, "specialLevels"), 0),
    eliteUnitUpgradeLevels: playableUnits.reduce((total, entry) => total + countLevels(entry, "eliteLevels"), 0),
  };

  const sourceMap = new Map<string, GameCatalogReleaseDocument["sources"][number]>();
  for (const source of [
    { path: weapons.source, sha256: weapons.sourceSha256, schemaVersion: weapons.schemaVersion },
    { path: units.source, sha256: units.sourceSha256, schemaVersion: units.schemaVersion },
    { path: unitUpgrades.source, sha256: unitUpgrades.sourceSha256, schemaVersion: unitUpgrades.schemaVersion },
    { path: armyPower.source, sha256: armyPower.sourceSha256, schemaVersion: armyPower.schemaVersion },
  ]) sourceMap.set(`${source.path}:${source.schemaVersion}`, source);

  return {
    clientVersion: GAME_CATALOG_CLIENT_VERSION,
    catalogRevision,
    entries,
    counts,
    sources: [...sourceMap.values()].sort((left, right) =>
      left.path.localeCompare(right.path) || left.schemaVersion - right.schemaVersion),
  };
}

/**
 * Publishes one immutable content revision. The release pointer is updated only after every
 * entry upsert succeeds, so readers always resolve either the complete old revision or the
 * complete new revision. Re-running the same source is idempotent because both the release
 * hash and every entry key are deterministic.
 */
export async function syncGameCatalog(
  entryCollection: Collection<GameCatalogEntryDocument>,
  releaseCollection: Collection<GameCatalogReleaseDocument>,
  now = new Date(),
): Promise<BuiltGameCatalog> {
  const built = buildGameCatalog();

  if (built.entries.length > 0) {
    await entryCollection.bulkWrite(built.entries.map((entry) => ({
      updateOne: {
        filter: {
          clientVersion: entry.clientVersion,
          catalogRevision: entry.catalogRevision,
          kind: entry.kind,
          key: entry.key,
        },
        update: {
          $set: { ...entry, updatedAt: now },
          $setOnInsert: { createdAt: now },
        },
        upsert: true,
      },
    })), { ordered: true });
  }

  await releaseCollection.updateOne(
    { clientVersion: built.clientVersion },
    {
      $set: {
        catalogRevision: built.catalogRevision,
        entryCount: built.entries.length,
        counts: built.counts,
        sources: built.sources,
        updatedAt: now,
      },
      $setOnInsert: { createdAt: now },
    },
    { upsert: true },
  );

  return built;
}

/** Resolve an item only through the release pointer; partial/stale revisions stay invisible. */
export async function findPublishedCatalogEntry(
  entryCollection: Collection<GameCatalogEntryDocument>,
  releaseCollection: Collection<GameCatalogReleaseDocument>,
  kind: GameCatalogKind,
  key: string,
  clientVersion = GAME_CATALOG_CLIENT_VERSION,
): Promise<GameCatalogEntryDocument | null> {
  const release = await releaseCollection.findOne({ clientVersion });
  if (!release) return null;
  return entryCollection.findOne({
    clientVersion,
    catalogRevision: release.catalogRevision,
    kind,
    key,
  });
}
