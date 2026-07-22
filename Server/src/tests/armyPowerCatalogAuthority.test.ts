import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import generatedArmyPowerCatalog from "../data/armyPowerCatalog.generated.json";
import {
  VALIDATED_ARMY_POWER_CATALOG,
  validatedArmyPowerCatalogArtifact,
} from "../services/armyPowerCatalogAuthorityService";

function catalogCopy(): Record<string, unknown> {
  return JSON.parse(JSON.stringify(generatedArmyPowerCatalog)) as Record<string, unknown>;
}

test("Army Power catalog authority validates and deep-freezes all recovered rows", () => {
  assert.equal(VALIDATED_ARMY_POWER_CATALOG.rankLevels.length, 58);
  assert.equal(VALIDATED_ARMY_POWER_CATALOG.featureDpsCoefficients.length, 11);
  assert.equal(VALIDATED_ARMY_POWER_CATALOG.weapons.length, 165);
  assert.equal(Object.isFrozen(VALIDATED_ARMY_POWER_CATALOG.rankLevels[0]), true);
  assert.equal(Object.isFrozen(VALIDATED_ARMY_POWER_CATALOG.featureDpsCoefficients[0].dpsByFeature), true);
  assert.equal(Object.isFrozen(VALIDATED_ARMY_POWER_CATALOG.weapons[0].powerByLevel), true);
  assert.throws(() => {
    (VALIDATED_ARMY_POWER_CATALOG.weapons[0].powerByLevel as number[])[0] = 0;
  }, TypeError);
});

test("Army Power catalog rejects truncated, duplicate, split, or non-finite combat authority", () => {
  const cases = [
    (() => { const value = catalogCopy(); (value.rankLevels as unknown[]).pop(); return value; })(),
    (() => {
      const value = catalogCopy();
      const weapons = value.weapons as Array<{ name: string }>;
      weapons[1].name = weapons[0].name;
      return value;
    })(),
    (() => {
      const value = catalogCopy();
      ((value.featureDpsCoefficients as Array<{ categoryMask: number }>)[1]).categoryMask = 1;
      return value;
    })(),
    (() => {
      const value = catalogCopy();
      ((value.weapons as Array<{ powerByLevel: number[] }>)[0]).powerByLevel[0] = Number.NaN;
      return value;
    })(),
  ];
  for (const value of cases) {
    assert.throws(() => validatedArmyPowerCatalogArtifact(value), (error: unknown) => (
      typeof error === "object" && error !== null && "code" in error
      && error.code === ApiErrorCode.InternalServerError
    ));
  }
});
