import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import {
  convertGoldToWarBucksState,
} from "../services/economyService";
import { playerLevelDefinition } from "../services/levelProgressionService";
import { createInitialProgression } from "../services/playerStateService";

function funded(gold = 20_000) {
  return { ...createInitialProgression(1_700_000_000), gold };
}

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
