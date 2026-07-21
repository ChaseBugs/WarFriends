import { createHash } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  GameCatalogAvailability,
  GameCatalogCounts,
  GameCatalogEntryDocument,
  GameCatalogKind,
  GameCatalogReleaseDocument,
} from "./gameCatalogService";

const MAX_CLIENT_INTEGER = 2_147_483_647;
const MAX_CATALOG_SOURCES = 64;
const MAX_CATALOG_JSON_NODES = 50_000;
const MAX_CATALOG_JSON_DEPTH = 32;
const SHA256_PATTERN = /^[0-9a-f]{64}$/;
const RELEASE_KEYS = new Set([
  "_id", "clientVersion", "catalogRevision", "entryCount", "counts", "sources", "createdAt", "updatedAt",
]);
const ENTRY_KEYS = new Set([
  "_id", "clientVersion", "catalogRevision", "kind", "key", "availability", "contentHash",
  "source", "sourceSha256", "sourceSchemaVersion", "data", "createdAt", "updatedAt",
]);
const SOURCE_KEYS = new Set(["path", "sha256", "schemaVersion"]);
const COUNT_KEYS: ReadonlyArray<keyof GameCatalogCounts> = [
  "weapons", "playableWeapons", "unresolvedWeapons", "weaponUpgradeLevels", "weaponPowerLevels",
  "rankPowerLevels", "weaponFeatureRows", "visuals", "playableVisuals", "unresolvedVisuals",
  "shopVisuals", "cards", "playableCards", "unresolvedCards", "cardPacks", "units",
  "playableUnits", "helperUnits", "unresolvedUnits", "normalUnitUpgradeLevels",
  "specialUnitUpgradeLevels", "eliteUnitUpgradeLevels",
];
const KINDS = new Set<GameCatalogKind>([
  "weapon", "unit", "rank", "weaponFeature", "visual", "card", "cardPack",
]);
const AVAILABILITY_BY_KIND: Readonly<Record<GameCatalogKind, ReadonlySet<GameCatalogAvailability>>> = {
  weapon: new Set(["playable", "unresolved"]),
  unit: new Set(["playable", "helper", "unresolved"]),
  rank: new Set(["playable"]),
  weaponFeature: new Set(["reference"]),
  visual: new Set(["playable", "unresolved"]),
  card: new Set(["playable", "reference", "unresolved"]),
  cardPack: new Set(["playable"]),
};

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value) && !(value instanceof Date);
}

function exactKeys(value: Record<string, unknown>, allowed: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => allowed.has(key));
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function boundedCanonicalText(value: unknown, maximum: number): value is string {
  return typeof value === "string"
    && value.length > 0
    && value.length <= maximum
    && !/\p{Cc}/u.test(value)
    && value.trim() === value;
}

function boundedCount(value: unknown): value is number {
  return Number.isSafeInteger(value) && (value as number) >= 0 && (value as number) <= MAX_CLIENT_INTEGER;
}

/**
 * JSON object insertion order is not authority. Sorting every object key recursively makes entry
 * and release hashes stable across extraction hosts and prevents semantically identical material
 * from receiving a different revision solely because a serializer emitted a different key order.
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

/**
 * Catalog payloads are recovered JSON, not BSON extension objects or executable graph data. This
 * bounded walk rejects non-finite numbers, dates, cyclic/deep structures, and oversized documents
 * before hashing. Without it, JSON.stringify could omit `undefined`, turn NaN into null, or exhaust
 * the process stack while still producing a content hash that looks authoritative.
 */
function validateCatalogJson(root: unknown): void {
  let nodes = 0;
  const ancestors = new Set<object>();
  const visit = (value: unknown, depth: number): void => {
    nodes += 1;
    if (nodes > MAX_CATALOG_JSON_NODES || depth > MAX_CATALOG_JSON_DEPTH) {
      invalid("Stored game-catalog payload exceeds its bounded JSON shape.");
    }
    if (value === null || typeof value === "boolean") return;
    if (typeof value === "number") {
      if (!Number.isFinite(value)) invalid("Stored game-catalog payload contains a non-finite number.");
      return;
    }
    if (typeof value === "string") {
      if (value.length > 1_000_000) invalid("Stored game-catalog payload contains oversized text.");
      return;
    }
    if (typeof value !== "object" || value instanceof Date) {
      invalid("Stored game-catalog payload is not canonical JSON.");
    }
    if (ancestors.has(value)) invalid("Stored game-catalog payload contains a cycle.");
    ancestors.add(value);
    if (Array.isArray(value)) {
      for (const child of value) visit(child, depth + 1);
    } else {
      const record = value as Record<string, unknown>;
      for (const [key, child] of Object.entries(record)) {
        if (!boundedCanonicalText(key, 512)) invalid("Stored game-catalog payload contains an invalid key.");
        visit(child, depth + 1);
      }
    }
    ancestors.delete(value);
  };
  visit(root, 0);
}

function validateCounts(counts: unknown, entryCount: number): asserts counts is GameCatalogCounts {
  if (!plainRecord(counts)
    || Object.keys(counts).length !== COUNT_KEYS.length
    || Object.keys(counts).some((key) => !COUNT_KEYS.includes(key as keyof GameCatalogCounts))
    || COUNT_KEYS.some((key) => !boundedCount(counts[key]))) {
    invalid("Stored game-catalog counts are invalid.");
  }
  const value = counts as unknown as GameCatalogCounts;
  if (value.weapons !== value.playableWeapons + value.unresolvedWeapons
    || value.units !== value.playableUnits + value.helperUnits + value.unresolvedUnits
    || value.visuals !== value.playableVisuals + value.unresolvedVisuals
    || value.cards < value.playableCards + value.unresolvedCards
    || value.shopVisuals > value.playableVisuals
    || entryCount !== value.weapons + value.units + value.rankPowerLevels
      + value.weaponFeatureRows + value.visuals + value.cards + value.cardPacks) {
    invalid("Stored game-catalog counts do not conserve the published entry total.");
  }
}

export function validatedGameCatalogRelease(
  release: GameCatalogReleaseDocument,
  now = new Date(),
  expectedClientVersion?: string,
): GameCatalogReleaseDocument {
  const raw = release as unknown as Record<string, unknown>;
  if (!plainRecord(release)
    || !exactKeys(raw, RELEASE_KEYS)
    || !boundedCanonicalText(release.clientVersion, 64)
    || (expectedClientVersion !== undefined && release.clientVersion !== expectedClientVersion)
    || !SHA256_PATTERN.test(release.catalogRevision)
    || !boundedCount(release.entryCount)
    || release.entryCount === 0
    || !Array.isArray(release.sources)
    || release.sources.length === 0
    || release.sources.length > MAX_CATALOG_SOURCES
    || !safeDate(release.createdAt)
    || !safeDate(release.updatedAt)
    || !safeDate(now)
    || release.createdAt.getTime() > release.updatedAt.getTime()
    || release.updatedAt.getTime() > now.getTime()) {
    invalid("Stored game-catalog release authority is invalid.");
  }
  validateCounts(release.counts, release.entryCount);

  const identities = new Set<string>();
  let previousSource: GameCatalogReleaseDocument["sources"][number] | undefined;
  for (const source of release.sources) {
    const rawSource = source as unknown as Record<string, unknown>;
    if (!plainRecord(source)
      || Object.keys(rawSource).length !== SOURCE_KEYS.size
      || !exactKeys(rawSource, SOURCE_KEYS)
      || !boundedCanonicalText(source.path, 1_024)
      || !SHA256_PATTERN.test(source.sha256)
      || !Number.isSafeInteger(source.schemaVersion)
      || source.schemaVersion < 1
      || source.schemaVersion > MAX_CLIENT_INTEGER) {
      invalid("Stored game-catalog release source authority is invalid.");
    }
    // One recovered scene path may have multiple reviewed extraction snapshots. The digest is
    // part of provenance identity; collapsing on path/schema would orphan entries from one source.
    const identity = `${source.path}\u0000${source.schemaVersion}\u0000${source.sha256}`;
    if (identities.has(identity)) invalid("Stored game-catalog release contains a duplicate source.");
    if (previousSource
      && (previousSource.path.localeCompare(source.path) > 0
        || (previousSource.path === source.path && previousSource.schemaVersion > source.schemaVersion)
        || (previousSource.path === source.path
          && previousSource.schemaVersion === source.schemaVersion
          && previousSource.sha256.localeCompare(source.sha256) >= 0))) {
      invalid("Stored game-catalog release sources are not in canonical order.");
    }
    identities.add(identity);
    previousSource = source;
  }
  return release;
}

export function validatedGameCatalogEntry(
  entry: GameCatalogEntryDocument,
  release: GameCatalogReleaseDocument,
  now = new Date(),
  expectedKind?: GameCatalogKind,
  expectedKey?: string,
): GameCatalogEntryDocument {
  validatedGameCatalogRelease(release, now, release.clientVersion);
  const raw = entry as unknown as Record<string, unknown>;
  if (!plainRecord(entry)
    || !exactKeys(raw, ENTRY_KEYS)
    || entry.clientVersion !== release.clientVersion
    || entry.catalogRevision !== release.catalogRevision
    || !KINDS.has(entry.kind)
    || (expectedKind !== undefined && entry.kind !== expectedKind)
    || !boundedCanonicalText(entry.key, 512)
    || (expectedKey !== undefined && entry.key !== expectedKey)
    || !AVAILABILITY_BY_KIND[entry.kind]?.has(entry.availability)
    || !SHA256_PATTERN.test(entry.contentHash)
    || !boundedCanonicalText(entry.source, 1_024)
    || !SHA256_PATTERN.test(entry.sourceSha256)
    || !Number.isSafeInteger(entry.sourceSchemaVersion)
    || entry.sourceSchemaVersion < 1
    || entry.sourceSchemaVersion > MAX_CLIENT_INTEGER
    || !plainRecord(entry.data)
    || Object.keys(entry.data).length === 0
    || !safeDate(entry.createdAt)
    || !safeDate(entry.updatedAt)
    || entry.createdAt.getTime() > entry.updatedAt.getTime()
    || entry.updatedAt.getTime() > release.updatedAt.getTime()
    || entry.updatedAt.getTime() > now.getTime()) {
    invalid("Stored game-catalog entry authority is invalid.");
  }
  const sourceMatches = release.sources.some((source) => source.path === entry.source
    && source.sha256 === entry.sourceSha256
    && source.schemaVersion === entry.sourceSchemaVersion);
  if (!sourceMatches) invalid("Stored game-catalog entry is not bound to a published source.");

  validateCatalogJson(entry.data);
  const contentHash = catalogContentHash({
    kind: entry.kind,
    key: entry.key,
    availability: entry.availability,
    source: entry.source,
    sourceSha256: entry.sourceSha256,
    sourceSchemaVersion: entry.sourceSchemaVersion,
    data: entry.data,
  });
  if (contentHash !== entry.contentHash) {
    invalid("Stored game-catalog entry content hash does not match its payload.");
  }
  return entry;
}
