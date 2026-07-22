import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import generatedUnitCatalog from "../data/unitCatalog.generated.json";
import generatedUnitUpgradeCatalog from "../data/unitUpgradeCatalog.generated.json";
import {
  VALIDATED_UNIT_CATALOG,
  VALIDATED_UNIT_UPGRADE_CATALOG,
  validatedUnitCatalogArtifacts,
} from "../services/unitCatalogAuthorityService";

function unitCopy(): Record<string, unknown> {
  return JSON.parse(JSON.stringify(generatedUnitCatalog)) as Record<string, unknown>;
}

function upgradeCopy(): Record<string, unknown> {
  return JSON.parse(JSON.stringify(generatedUnitUpgradeCatalog)) as Record<string, unknown>;
}

function isInternalError(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error
    && error.code === ApiErrorCode.InternalServerError;
}

test("unit catalog authority validates and deep-freezes the paired recovered snapshot", () => {
  assert.equal(VALIDATED_UNIT_CATALOG.catalog.length, 27);
  assert.equal(VALIDATED_UNIT_CATALOG.unresolvedRows.length, 18);
  assert.equal(VALIDATED_UNIT_UPGRADE_CATALOG.catalog.length, 24);
  assert.equal(
    VALIDATED_UNIT_UPGRADE_CATALOG.catalog.reduce((sum, row) => sum + row.normalLevels.length, 0),
    4_124,
  );
  assert.equal(
    VALIDATED_UNIT_UPGRADE_CATALOG.catalog.reduce((sum, row) => sum + row.specialLevels.length, 0),
    684,
  );
  assert.equal(
    VALIDATED_UNIT_UPGRADE_CATALOG.catalog.reduce((sum, row) => sum + row.eliteLevels.length, 0),
    216,
  );
  assert.equal(Object.isFrozen(VALIDATED_UNIT_CATALOG.catalog[0]?.unlockTierLevels), true);
  assert.equal(Object.isFrozen(VALIDATED_UNIT_UPGRADE_CATALOG.catalog[0]?.normalLevels[0]), true);
  assert.throws(() => {
    (VALIDATED_UNIT_UPGRADE_CATALOG.catalog[0]!.normalLevels as unknown as Array<{ warBucks: number }>)[0]!
      .warBucks = 0;
  }, TypeError);
});

test("unit catalog authority rejects incomplete, duplicate, unsafe, or cross-bound authority", () => {
  const cases: Array<[Record<string, unknown>, Record<string, unknown>]> = [
    (() => {
      const units = unitCopy();
      (units.catalog as unknown[]).pop();
      return [units, upgradeCopy()];
    })(),
    (() => {
      const units = unitCopy();
      const rows = units.catalog as Array<{ name: string }>;
      rows[1]!.name = rows[0]!.name;
      return [units, upgradeCopy()];
    })(),
    (() => {
      const units = unitCopy();
      (units.catalog as Array<{ gold: number }>)[1]!.gold = Number.NaN;
      return [units, upgradeCopy()];
    })(),
    (() => {
      const units = unitCopy();
      (units.catalog as Array<{ clientId: number }>)[24]!.clientId = 0;
      return [units, upgradeCopy()];
    })(),
    (() => {
      const upgrades = upgradeCopy();
      upgrades.sourceSha256 = "0".repeat(64);
      return [unitCopy(), upgrades];
    })(),
    (() => {
      const upgrades = upgradeCopy();
      const table = (upgrades.catalog as Array<{ normalLevels: unknown[] }>)[0]!;
      table.normalLevels.pop();
      return [unitCopy(), upgrades];
    })(),
    (() => {
      const upgrades = upgradeCopy();
      const level = (upgrades.catalog as Array<{ specialLevels: Array<{ sourceIndex: number }> }>)[0]!
        .specialLevels[0]!;
      level.sourceIndex += 1;
      return [unitCopy(), upgrades];
    })(),
    (() => {
      const upgrades = upgradeCopy();
      const level = (upgrades.catalog as Array<{ eliteLevels: Array<{ armyPower: number }> }>)[0]!
        .eliteLevels[0]!;
      level.armyPower = Number.POSITIVE_INFINITY;
      return [unitCopy(), upgrades];
    })(),
  ];

  for (const [units, upgrades] of cases) {
    assert.throws(() => validatedUnitCatalogArtifacts(units, upgrades), isInternalError);
  }
});
