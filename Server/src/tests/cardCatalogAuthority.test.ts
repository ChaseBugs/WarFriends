import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import generatedCardCatalog from "../data/cardCatalog.generated.json";
import {
  VALIDATED_CARD_CATALOG,
  validatedCardCatalogArtifact,
} from "../services/cardCatalogAuthorityService";

function catalogCopy(): Record<string, unknown> {
  return JSON.parse(JSON.stringify(generatedCardCatalog)) as Record<string, unknown>;
}

test("card catalog authority validates and deep-freezes the recovered artifact", () => {
  assert.equal(VALIDATED_CARD_CATALOG.cards.length, 58);
  assert.equal(VALIDATED_CARD_CATALOG.unresolvedRows.length, 25);
  assert.equal(VALIDATED_CARD_CATALOG.packs.length, 4);
  assert.equal(Object.isFrozen(VALIDATED_CARD_CATALOG), true);
  assert.equal(Object.isFrozen(VALIDATED_CARD_CATALOG.cards), true);
  assert.equal(Object.isFrozen(VALIDATED_CARD_CATALOG.cards[0]), true);
  assert.equal(Object.isFrozen(VALIDATED_CARD_CATALOG.cardPoolRules.reputationPoints), true);
  assert.equal(Object.isFrozen(VALIDATED_CARD_CATALOG.cardPoolRules.capacityBySquadLevel), true);
  assert.throws(() => {
    (VALIDATED_CARD_CATALOG.cardPoolRules.capacityBySquadLevel as number[])[0] = 999;
  }, TypeError);
});

test("card catalog authority rejects truncated, duplicate, malformed, or split economy data", () => {
  const cases = [
    (() => {
      const catalog = catalogCopy();
      (catalog.cards as unknown[]).pop();
      return catalog;
    })(),
    (() => {
      const catalog = catalogCopy();
      const cards = catalog.cards as Array<{ name: string }>;
      cards[1].name = cards[0].name;
      return catalog;
    })(),
    (() => {
      const catalog = catalogCopy();
      ((catalog.craftingRules as { bronzeToSilverMinutes: number }).bronzeToSilverMinutes) = Number.NaN;
      return catalog;
    })(),
    (() => {
      const catalog = catalogCopy();
      ((catalog.packs as Array<{ priceGold: number }>)[0]).priceGold = 0;
      return catalog;
    })(),
    (() => {
      const catalog = catalogCopy();
      ((catalog.cardPoolRules as { capacityBySquadLevel: number[] }).capacityBySquadLevel)[0] = 999;
      return catalog;
    })(),
  ];

  for (const catalog of cases) {
    assert.throws(() => validatedCardCatalogArtifact(catalog), (error: unknown) => (
      typeof error === "object"
      && error !== null
      && "code" in error
      && error.code === ApiErrorCode.InternalServerError
    ));
  }
});
