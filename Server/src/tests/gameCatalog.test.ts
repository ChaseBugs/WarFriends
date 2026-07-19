import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import {
  buildGameCatalog,
  catalogContentHash,
  GAME_CATALOG_CLIENT_VERSION,
  syncGameCatalog,
  type GameCatalogEntryDocument,
  type GameCatalogReleaseDocument,
} from "../services/gameCatalogService";

test("material database joins every recovered weapon and unit family", () => {
  const catalog = buildGameCatalog();

  assert.equal(catalog.clientVersion, GAME_CATALOG_CLIENT_VERSION);
  assert.match(catalog.catalogRevision, /^[0-9a-f]{64}$/);
  assert.equal(catalog.entries.length, 207);
  assert.deepEqual(catalog.counts, {
    weapons: 93,
    playableWeapons: 84,
    unresolvedWeapons: 9,
    weaponUpgradeLevels: 5_781,
    weaponPowerLevels: 5_865,
    rankPowerLevels: 58,
    weaponFeatureRows: 11,
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

  const firstRank = catalog.entries.find((entry) =>
    entry.kind === "rank" && entry.key === "Level.1");
  assert.deepEqual(firstRank?.data.definition, {
    index: 0,
    displayLevel: 1,
    armyPower: 93,
  });

  const assaultFeatures = catalog.entries.find((entry) =>
    entry.kind === "weaponFeature" && entry.key === "WeaponFeature.AssaultRifle");
  assert.equal(assaultFeatures?.availability, "reference");
  assert.equal(
    ((assaultFeatures?.data.definition as { dpsByFeature: unknown[] }).dpsByFeature).length,
    9,
  );

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

test("catalog sync writes all immutable entries before publishing the release pointer", async () => {
  const calls: string[] = [];
  let entryOperations = 0;
  let publishedRelease: Record<string, unknown> | undefined;

  const entryCollection = {
    async bulkWrite(operations: unknown[]) {
      calls.push("entries");
      entryOperations = operations.length;
      return {};
    },
  } as unknown as Collection<GameCatalogEntryDocument>;
  const releaseCollection = {
    async updateOne(_filter: unknown, update: { $set: Record<string, unknown> }) {
      calls.push("release");
      publishedRelease = update.$set;
      return {};
    },
  } as unknown as Collection<GameCatalogReleaseDocument>;

  const built = await syncGameCatalog(
    entryCollection,
    releaseCollection,
    new Date("2026-07-19T12:00:00.000Z"),
  );

  assert.deepEqual(calls, ["entries", "release"]);
  assert.equal(entryOperations, built.entries.length);
  assert.equal(publishedRelease?.catalogRevision, built.catalogRevision);
  assert.equal(publishedRelease?.entryCount, 207);
});
