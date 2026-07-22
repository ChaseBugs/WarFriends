import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import {
  WEAPON_BLACK_MARKET_PRICES,
  WEAPON_UPGRADE_CATALOG,
} from "../data/weaponUpgradeCatalog.generated";
import {
  VALIDATED_WEAPON_BLACK_MARKET_PRICES,
  VALIDATED_WEAPON_UPGRADE_CATALOG,
  validatedWeaponEconomyCatalog,
} from "../services/weaponEconomyCatalogAuthorityService";

function upgradeCopy(): Record<string, number[][]> {
  return JSON.parse(JSON.stringify(WEAPON_UPGRADE_CATALOG)) as Record<string, number[][]>;
}

function priceCopy(): Record<string, number[]> {
  return JSON.parse(JSON.stringify(WEAPON_BLACK_MARKET_PRICES)) as Record<string, number[]>;
}

function isInternalError(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error
    && error.code === ApiErrorCode.InternalServerError;
}

test("weapon economy authority cross-validates and deep-freezes every recovered table", () => {
  assert.equal(Object.keys(VALIDATED_WEAPON_UPGRADE_CATALOG).length, 165);
  assert.equal(Object.keys(VALIDATED_WEAPON_BLACK_MARKET_PRICES).length, 79);
  assert.equal(
    Object.values(VALIDATED_WEAPON_UPGRADE_CATALOG).reduce((sum, rows) => sum + rows.length, 0),
    11_640,
  );
  assert.equal(
    Object.values(VALIDATED_WEAPON_BLACK_MARKET_PRICES).reduce((sum, rows) => sum + rows.length, 0),
    5_860,
  );
  const firstStages = Object.values(VALIDATED_WEAPON_UPGRADE_CATALOG)[0]!;
  assert.equal(Object.isFrozen(firstStages), true);
  assert.equal(Object.isFrozen(firstStages[0]), true);
  assert.throws(() => {
    (firstStages[0] as unknown as number[])[0] = 0;
  }, TypeError);
});

test("weapon economy authority rejects incomplete, reordered, unsafe, or unsupported authority", () => {
  const cases: Array<[Record<string, number[][]>, Record<string, number[]>]> = [
    (() => {
      const upgrades = upgradeCopy();
      delete upgrades[Object.keys(upgrades)[0]!];
      return [upgrades, priceCopy()];
    })(),
    (() => {
      const upgrades = upgradeCopy();
      const entries = Object.entries(upgrades);
      [entries[0], entries[1]] = [entries[1]!, entries[0]!];
      return [Object.fromEntries(entries), priceCopy()];
    })(),
    (() => {
      const upgrades = upgradeCopy();
      upgrades[Object.keys(upgrades)[0]!]!.pop();
      return [upgrades, priceCopy()];
    })(),
    (() => {
      const upgrades = upgradeCopy();
      upgrades[Object.keys(upgrades)[0]!]![0]![0] = Number.NaN;
      return [upgrades, priceCopy()];
    })(),
    (() => {
      const upgrades = upgradeCopy();
      upgrades[Object.keys(upgrades)[0]!]![1]![1] = 1;
      return [upgrades, priceCopy()];
    })(),
    (() => {
      const prices = priceCopy();
      prices["Google2u.LMG_GSh"] = [1];
      return [upgradeCopy(), prices];
    })(),
    (() => {
      const prices = priceCopy();
      prices[Object.keys(prices)[0]!]!.pop();
      return [upgradeCopy(), prices];
    })(),
    (() => {
      const prices = priceCopy();
      prices[Object.keys(prices)[0]!]![0] = Number.POSITIVE_INFINITY;
      return [upgradeCopy(), prices];
    })(),
  ];

  for (const [upgrades, prices] of cases) {
    assert.throws(() => validatedWeaponEconomyCatalog(upgrades, prices), isInternalError);
  }
});
