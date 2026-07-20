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

test("material database joins every recovered gameplay inventory family", () => {
  const catalog = buildGameCatalog();

  assert.equal(catalog.clientVersion, GAME_CATALOG_CLIENT_VERSION);
  assert.match(catalog.catalogRevision, /^[0-9a-f]{64}$/);
  assert.equal(catalog.entries.length, 531);
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
  assert.equal(publishedRelease?.entryCount, 531);
});
