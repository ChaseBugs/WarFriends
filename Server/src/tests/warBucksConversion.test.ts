import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import {
  convertGoldToWarBucksState,
  warBucksGoldVariantPolicy,
} from "../services/economyService";
import { playerLevelDefinition } from "../services/levelProgressionService";
import { createInitialProgression } from "../services/playerStateService";
import { validatedWarBucksConversionReceipt } from "../services/warBucksConversionAuthorityService";

function funded(gold = 20_000) {
  return { ...createInitialProgression(1_700_000_000), gold };
}

test("deployment A/B selector is immutable exact startup authority", () => {
  assert.equal(Object.isFrozen(warBucksGoldVariantPolicy()), true);
  assert.deepEqual(warBucksGoldVariantPolicy(), { variant: "standard" });
  assert.deepEqual(warBucksGoldVariantPolicy({ variant: "b" }), { variant: "b" });
  for (const variant of ["", "Standard", " standard", "b ", "warbucks", null, 0]) {
    assert.throws(
      () => warBucksGoldVariantPolicy({ variant }),
      /WARBUCKS_GOLD_VARIANT must be standard or b/,
    );
  }
  assert.throws(
    () => convertGoldToWarBucksState(
      funded(),
      1_700_000_100,
      0,
      "warbucks1",
      "invalid" as "standard",
    ),
    /WARBUCKS_GOLD_VARIANT must be standard or b/,
  );
});

test("action 221 uses exact MainScene Gold price and level conversion multiplier", () => {
  assert.equal(playerLevelDefinition(0).convertGoldToWarBucks, 150);
  assert.equal(playerLevelDefinition(3).convertGoldToWarBucks, 180);

  const standard = convertGoldToWarBucksState(funded(), 1_700_000_100, 0, "warbucks2", "standard");
  assert.equal(standard.goldDeducted, 200);
  assert.equal(standard.warBucksAdded, 210 * 150);
  assert.equal(standard.state.gold, 19_800);
  assert.equal(standard.state.warBucks, 31_500);

  const higherLevel = convertGoldToWarBucksState(funded(), 1_700_000_100, 3, "warbucks2", "standard");
  assert.equal(higherLevel.warBucksAdded, 210 * 180);
});

test("deployment A/B variant owns the accepted ID and reward curve", () => {
  assert.throws(
    () => convertGoldToWarBucksState(funded(), 1_700_000_100, 0, "bwarbucks1", "standard"),
    /not active in the server A\/B variant/,
  );
  assert.throws(
    () => convertGoldToWarBucksState(funded(), 1_700_000_100, 0, "warbucks1", "b"),
    /not active in the server A\/B variant/,
  );
  const variant = convertGoldToWarBucksState(funded(), 1_700_000_100, 0, "bwarbucks1", "b");
  assert.equal(variant.goldDeducted, 50);
  assert.equal(variant.warBucksAdded, 100 * 150);
});

test("conversion rejects insufficient Gold with the recovered dedicated error", () => {
  assert.throws(
    () => convertGoldToWarBucksState(funded(199), 1_700_000_100, 0, "warbucks2", "standard"),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotEnoughGoldForWarbucks,
  );
});

test("same-revision transport retry reuses its receipt without a second debit or grant", () => {
  const first = convertGoldToWarBucksState(funded(), 1_700_000_100, 0, "warbucks1", "standard");
  const replay = convertGoldToWarBucksState(first.state, 1_700_000_102, 0, "warbucks1", "standard");
  assert.equal(replay.replayed, true);
  assert.equal(replay.state, first.state);
  assert.equal(replay.state.gold, 19_950);
  assert.equal(replay.state.warBucks, 7_500);

  const later = convertGoldToWarBucksState(first.state, 1_700_000_103, 0, "warbucks1", "standard");
  assert.equal(later.replayed, false);
  assert.equal(later.state.gold, 19_900);
  assert.equal(later.state.warBucks, 15_000);
});

test("conversion receipt authority rejects malformed rows without reopening their reward", () => {
  const first = convertGoldToWarBucksState(funded(), 1_700_000_100, 0, "warbucks1", "standard");
  const receipt = first.state.warBucksConversion!;
  assert.deepEqual(validatedWarBucksConversionReceipt(receipt, first.state.revision), receipt);

  for (const corrupt of [
    { ...receipt, id: "warbucks7" },
    { ...receipt, goldDeducted: receipt.goldDeducted + 1 },
    { ...receipt, warBucksAdded: Number.NaN },
    { ...receipt, processedAt: Number.POSITIVE_INFINITY },
    { ...receipt, progressionRevision: first.state.revision + 1 },
  ]) {
    assert.throws(
      () => validatedWarBucksConversionReceipt(corrupt, first.state.revision),
      /Stored WarBucks conversion receipt is invalid/,
    );
  }
  assert.throws(
    () => convertGoldToWarBucksState({ ...first.state, warBucksConversion: { ...receipt, id: "forged" } }, 1_700_000_101, 0, "warbucks1", "standard"),
    /Stored WarBucks conversion receipt is invalid/,
  );
  assert.throws(
    () => convertGoldToWarBucksState(funded(), 1_700_000_100.5, 0, "warbucks1", "standard"),
    /WarBucks conversion time is invalid/,
  );
});
