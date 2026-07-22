import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import generatedWeaponCatalog from "../data/weaponCatalog.generated.json";
import {
  VALIDATED_WEAPON_CATALOG,
  validatedWeaponCatalogArtifact,
} from "../services/weaponCatalogAuthorityService";

function catalogCopy(): Record<string, unknown> {
  return JSON.parse(JSON.stringify(generatedWeaponCatalog)) as Record<string, unknown>;
}

test("weapon catalog authority validates and deep-freezes every recovered family", () => {
  assert.equal(VALIDATED_WEAPON_CATALOG.catalog.length, 84);
  assert.equal(VALIDATED_WEAPON_CATALOG.blackMarketCatalog.length, 81);
  assert.equal(VALIDATED_WEAPON_CATALOG.unresolvedShopRows.length, 9);
  assert.equal(VALIDATED_WEAPON_CATALOG.unresolvedBlackMarketRows.length, 9);
  assert.equal(Object.isFrozen(VALIDATED_WEAPON_CATALOG.catalog[0]), true);
  assert.throws(() => {
    (VALIDATED_WEAPON_CATALOG.catalog as unknown as Array<{ gold: number }>)[0].gold = 0;
  }, TypeError);
});

test("weapon catalog rejects truncated, duplicate, unordered, or unsafe authority", () => {
  const cases = [
    (() => { const value = catalogCopy(); (value.catalog as unknown[]).pop(); return value; })(),
    (() => {
      const value = catalogCopy();
      const rows = value.blackMarketCatalog as Array<{ name: string }>;
      rows[1].name = rows[0].name;
      return value;
    })(),
    (() => {
      const value = catalogCopy();
      ((value.catalog as Array<{ index: number }>)[1]).index = 0;
      return value;
    })(),
    (() => {
      const value = catalogCopy();
      ((value.catalog as Array<{ gold: number }>)[0]).gold = Number.NaN;
      return value;
    })(),
  ];
  for (const value of cases) {
    assert.throws(() => validatedWeaponCatalogArtifact(value), (error: unknown) => (
      typeof error === "object" && error !== null && "code" in error
      && error.code === ApiErrorCode.InternalServerError
    ));
  }
});
