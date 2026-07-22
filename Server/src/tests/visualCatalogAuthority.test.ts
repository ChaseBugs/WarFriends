import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import generatedVisualCatalog from "../data/visualCatalog.generated.json";
import {
  VALIDATED_VISUAL_CATALOG,
  validatedVisualCatalogArtifact,
} from "../services/visualCatalogAuthorityService";

function catalogCopy(): Record<string, unknown> {
  return JSON.parse(JSON.stringify(generatedVisualCatalog)) as Record<string, unknown>;
}

test("visual catalog authority validates and deep-freezes the recovered artifact", () => {
  assert.equal(VALIDATED_VISUAL_CATALOG.categories.length, 4);
  assert.equal(VALIDATED_VISUAL_CATALOG.visuals.length, 146);
  assert.equal(VALIDATED_VISUAL_CATALOG.unresolvedRows.length, 1);
  assert.equal(Object.isFrozen(VALIDATED_VISUAL_CATALOG.categories[0].ids), true);
  assert.equal(Object.isFrozen(VALIDATED_VISUAL_CATALOG.visuals[0]), true);
  assert.throws(() => {
    (VALIDATED_VISUAL_CATALOG.categories[0].ids as string[])[0] = "CAMOS_FORGED";
  }, TypeError);
});

test("visual catalog authority rejects truncated, duplicate, split, or non-finite authority", () => {
  const cases = [
    (() => {
      const catalog = catalogCopy();
      (catalog.visuals as unknown[]).pop();
      return catalog;
    })(),
    (() => {
      const catalog = catalogCopy();
      const visuals = catalog.visuals as Array<{ name: string }>;
      visuals[1].name = visuals[0].name;
      return catalog;
    })(),
    (() => {
      const catalog = catalogCopy();
      ((catalog.categories as Array<{ defaultId: string }>)[0]).defaultId = "CAMOS_FORGED";
      return catalog;
    })(),
    (() => {
      const catalog = catalogCopy();
      ((catalog.visuals as Array<{ effectValue: number }>)[0]).effectValue = Number.NaN;
      return catalog;
    })(),
  ];
  for (const catalog of cases) {
    assert.throws(() => validatedVisualCatalogArtifact(catalog), (error: unknown) => (
      typeof error === "object" && error !== null && "code" in error
      && error.code === ApiErrorCode.InternalServerError
    ));
  }
});
