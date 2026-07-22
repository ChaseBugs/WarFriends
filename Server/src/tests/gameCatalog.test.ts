import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import {
  buildGameCatalog,
  catalogContentHash,
  findPublishedCatalogEntry,
  GAME_CATALOG_CLIENT_VERSION,
  syncGameCatalog,
  type GameCatalogEntryDocument,
  type GameCatalogReleaseDocument,
} from "../services/gameCatalogService";
import {
  validatedGameCatalogEntry,
  validatedGameCatalogRelease,
} from "../services/gameCatalogAuthorityService";

const catalogNow = new Date("2026-07-19T12:00:00.000Z");

function durableCatalog() {
  const built = buildGameCatalog();
  const release: GameCatalogReleaseDocument = {
    clientVersion: built.clientVersion,
    catalogRevision: built.catalogRevision,
    entryCount: built.entries.length,
    counts: structuredClone(built.counts),
    sources: structuredClone(built.sources),
    createdAt: catalogNow,
    updatedAt: catalogNow,
  };
  const entry: GameCatalogEntryDocument = {
    ...structuredClone(built.entries[0]!),
    createdAt: catalogNow,
    updatedAt: catalogNow,
  };
  return { built, release, entry };
}

test("material database joins every recovered gameplay inventory family", () => {
  const catalog = buildGameCatalog();

  assert.equal(catalog.clientVersion, GAME_CATALOG_CLIENT_VERSION);
  assert.match(catalog.catalogRevision, /^[0-9a-f]{64}$/);
  assert.equal(catalog.entries.length, 531);
  // All five generated families now bind the same current MainScene digest. Release provenance
  // therefore conserves three unique source triples (schema versions 1, 2, and 4), rather than
  // retaining duplicate triples that differed only because the unit artifacts had a stale hash.
  assert.equal(catalog.sources.length, 3);
  assert.equal(catalog.entries.every((entry) => catalog.sources.some((source) =>
    source.path === entry.source
    && source.sha256 === entry.sourceSha256
    && source.schemaVersion === entry.sourceSchemaVersion)), true);
  assert.deepEqual(catalog.counts, {
    weapons: 183,
    playableWeapons: 165,
    unresolvedWeapons: 18,
    weaponUpgradeLevels: 11_640,
    weaponPowerLevels: 11_805,
    rankPowerLevels: 58,
    weaponFeatureRows: 11,
    visuals: 147,
    playableVisuals: 146,
    unresolvedVisuals: 1,
    shopVisuals: 84,
    cards: 83,
    playableCards: 58,
    unresolvedCards: 25,
    cardPacks: 4,
    units: 45,
    playableUnits: 24,
    helperUnits: 3,
    unresolvedUnits: 18,
    normalUnitUpgradeLevels: 4_124,
    specialUnitUpgradeLevels: 684,
    eliteUnitUpgradeLevels: 216,
  });

  const ak47 = catalog.entries.find((entry) =>
    entry.kind === "weapon" && entry.key === "Google2u.AssaultRifle_AK47");
  assert.equal(ak47?.availability, "playable");
  assert.deepEqual((ak47?.data.upgradeLevels as unknown[])[0], {
    level: 0,
    warBucks: 500,
    deliverySeconds: 60,
  });
  assert.equal((ak47?.data.powerByLevel as number[])[0], 68.544);

  const blackMarketWeapon = catalog.entries.find((entry) =>
    entry.kind === "weapon" && entry.key === "Google2u.AssaultRifle_AKS47UBM");
  assert.equal(blackMarketWeapon?.availability, "playable");
  assert.equal(blackMarketWeapon?.data.purchaseFamily, "blackmarket");
  assert.ok((blackMarketWeapon?.data.blackMarketPrices as number[]).length > 0);

  const firstRank = catalog.entries.find((entry) =>
    entry.kind === "rank" && entry.key === "Level.1");
  assert.deepEqual(firstRank?.data.definition, {
    index: 0,
    displayLevel: 1,
    experience: 50_000,
    rewardGold: 5,
    armyPower: 93,
    convertGoldToWarBucks: 150,
  });

  const assaultFeatures = catalog.entries.find((entry) =>
    entry.kind === "weaponFeature" && entry.key === "WeaponFeature.AssaultRifle");
  assert.equal(assaultFeatures?.availability, "reference");
  assert.equal(
    ((assaultFeatures?.data.definition as { dpsByFeature: unknown[] }).dpsByFeature).length,
    9,
  );

  const defaultCamo = catalog.entries.find((entry) =>
    entry.kind === "visual" && entry.key === "CAMOS_DEFAULT");
  assert.equal(defaultCamo?.availability, "playable");
  assert.equal((defaultCamo?.data.definition as { categoryId: number }).categoryId, 0);
  const unresolvedVisual = catalog.entries.find((entry) =>
    entry.kind === "visual" && entry.key === "HEAD_MASK_ROCKET");
  assert.equal(unresolvedVisual?.availability, "unresolved");

  const ammoCrate = catalog.entries.find((entry) =>
    entry.kind === "card" && entry.key === "AMMOCRATE");
  assert.equal(ammoCrate?.availability, "playable");
  assert.equal((ammoCrate?.data.definition as { rarity: number }).rarity, 1);
  const unresolvedCard = catalog.entries.find((entry) =>
    entry.kind === "card" && entry.key === "PLAYERINVIS");
  assert.equal(unresolvedCard?.availability, "unresolved");
  const goldCardPack = catalog.entries.find((entry) =>
    entry.kind === "cardPack" && entry.key === "GOLD_CARDPACK");
  assert.equal(goldCardPack?.availability, "playable");
  assert.equal((goldCardPack?.data.definition as { priceGold: number }).priceGold, 69);

  const shotgunner = catalog.entries.find((entry) =>
    entry.kind === "unit" && entry.key === "Google2u.DBUpgradeSlotsShotgunner");
  assert.equal(shotgunner?.availability, "playable");
  assert.equal((shotgunner?.data.normalLevels as unknown[]).length > 0, true);
  assert.equal((shotgunner?.data.specialLevels as unknown[]).length > 0, true);
  assert.equal((shotgunner?.data.eliteLevels as unknown[]).length, 9);

  // Unresolved rows remain research evidence but carry no authoritative upgrade data. This
  // prevents database presence from accidentally turning an unverified client row playable.
  const pulseRifle = catalog.entries.find((entry) =>
    entry.kind === "weapon" && entry.key === "Google2u.PulseRifle_Grade1");
  assert.equal(pulseRifle?.availability, "unresolved");
  assert.deepEqual(pulseRifle?.data.upgradeLevels, []);
});

test("catalog hashes are deterministic and react to nested balancing changes", () => {
  const first = buildGameCatalog();
  const second = buildGameCatalog();

  assert.equal(first.catalogRevision, second.catalogRevision);
  assert.deepEqual(
    first.entries.map((entry) => entry.contentHash),
    second.entries.map((entry) => entry.contentHash),
  );
  assert.equal(catalogContentHash({ b: 2, a: { d: 4, c: 3 } }),
    catalogContentHash({ a: { c: 3, d: 4 }, b: 2 }));
  assert.notEqual(catalogContentHash({ price: 500 }), catalogContentHash({ price: 501 }));
});

test("catalog authority binds release conservation, sources, entry identity, and payload hash", () => {
  const { release, entry } = durableCatalog();
  assert.equal(validatedGameCatalogRelease(release, catalogNow), release);
  assert.equal(validatedGameCatalogEntry(entry, release, catalogNow, entry.kind, entry.key), entry);

  assert.throws(
    () => validatedGameCatalogRelease({
      ...release,
      counts: { ...release.counts, weapons: release.counts.weapons + 1 },
    }, catalogNow),
    /counts do not conserve/,
  );
  assert.throws(
    () => validatedGameCatalogRelease({
      ...release,
      sources: [...release.sources].reverse(),
    }, catalogNow),
    /canonical order/,
  );
  assert.throws(
    () => validatedGameCatalogEntry({
      ...entry,
      data: { ...entry.data, forgedPrice: 1 },
    }, release, catalogNow),
    /content hash/,
  );
  assert.throws(
    () => validatedGameCatalogEntry({
      ...entry,
      data: { ...entry.data, corrupt: Number.NaN },
    }, release, catalogNow),
    /non-finite/,
  );
  assert.throws(
    () => validatedGameCatalogEntry({
      ...entry,
      sourceSha256: "0".repeat(64),
    }, release, catalogNow),
    /published source/,
  );
});

test("published catalog lookup validates both the pointer and exact returned entry", async () => {
  const { release, entry } = durableCatalog();
  const entryCollection = {
    async findOne() { return entry; },
  } as unknown as Collection<GameCatalogEntryDocument>;
  const releaseCollection = {
    async findOne() { return release; },
  } as unknown as Collection<GameCatalogReleaseDocument>;

  assert.equal(await findPublishedCatalogEntry(
    entryCollection,
    releaseCollection,
    entry.kind,
    entry.key,
  ), entry);

  const wrongEntryCollection = {
    async findOne() { return { ...entry, key: `${entry.key}.forged` }; },
  } as unknown as Collection<GameCatalogEntryDocument>;
  await assert.rejects(
    findPublishedCatalogEntry(wrongEntryCollection, releaseCollection, entry.kind, entry.key),
    /entry authority is invalid/,
  );
});

test("catalog sync writes all immutable entries before publishing the release pointer", async () => {
  const calls: string[] = [];
  let entryOperations = 0;
  let storedEntries: GameCatalogEntryDocument[] = [];
  let publishedRelease: GameCatalogReleaseDocument | undefined;

  const entryCollection = {
    async bulkWrite(operations: Array<{
      updateOne: { update: { $setOnInsert: GameCatalogEntryDocument; $set?: unknown } };
    }>) {
      calls.push("entries");
      entryOperations = operations.length;
      assert.equal(operations.every((operation) => operation.updateOne.update.$set === undefined), true);
      storedEntries = operations.map((operation) => operation.updateOne.update.$setOnInsert);
      return {};
    },
    find() {
      calls.push("entry-read");
      return { async toArray() { return storedEntries; } };
    },
  } as unknown as Collection<GameCatalogEntryDocument>;
  const releaseCollection = {
    async findOne() {
      calls.push("release-read");
      return null;
    },
    async replaceOne(_filter: unknown, replacement: GameCatalogReleaseDocument) {
      calls.push("release");
      publishedRelease = replacement;
      return {};
    },
  } as unknown as Collection<GameCatalogReleaseDocument>;

  const built = await syncGameCatalog(
    entryCollection,
    releaseCollection,
    catalogNow,
  );

  assert.deepEqual(calls, ["release-read", "entries", "entry-read", "release"]);
  assert.equal(entryOperations, built.entries.length);
  assert.equal(publishedRelease?.catalogRevision, built.catalogRevision);
  assert.equal(publishedRelease?.entryCount, 531);
});
