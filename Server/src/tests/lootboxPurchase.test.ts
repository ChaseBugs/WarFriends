import assert from "node:assert/strict";
import test from "node:test";
import { createInitialProgression } from "../services/playerStateService";
import {
  LOOTBOX_CATALOG,
  LOOTBOX_NO_DISCOUNT_FOUND,
  LOOTBOX_NOT_ENOUGH_GOLD,
  purchaseLootboxesState,
  serializePurchasedLootboxVisuals,
} from "../services/lootboxPurchaseService";
import { VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS } from "../services/vipLootboxService";

const NOW = 1_700_000_000;

function selectVisual(name: string): (exclusiveMaximum: number) => number {
  const index = VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.indexOf(name);
  assert.notEqual(index, -1, `${name} must belong to the recovered normal lootbox pool`);
  return (exclusiveMaximum) => {
    assert.equal(exclusiveMaximum, VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.length);
    return index;
  };
}

test("4.9.5 lootbox catalog preserves all six exact scene price/count rows", () => {
  assert.deepEqual(Object.values(LOOTBOX_CATALOG), [
    { id: "lootboxes1", gold: 49, count: 5 },
    { id: "lootboxes2", gold: 89, count: 10 },
    { id: "lootboxes3", gold: 159, count: 20 },
    { id: "lootboxes4", gold: 279, count: 40 },
    { id: "lootboxes5", gold: 479, count: 80 },
    { id: "lootboxes6", gold: 749, count: 150 },
  ]);
});

test("purchase debits authoritative Gold and persists every awarded part", () => {
  const initial = { ...createInitialProgression(NOW), gold: 100 };
  const result = purchaseLootboxesState(initial, "lootboxes1", 0, selectVisual("HEAD_CIGAR"));

  assert.equal(result.state.gold, 51);
  assert.equal(result.state.revision, initial.revision + 1);
  assert.equal(result.rewards.length, 5);
  assert.equal(result.state.visualInventory?.visuals.HEAD_CIGAR?.parts, 5);
  assert.equal(result.state.visualInventory?.visuals.HEAD_CIGAR?.notificate, true);
  assert.equal(result.duplicateWarBucks, 0);
  assert.deepEqual(JSON.parse(result.newVisuals), {
    HEAD_CIGAR: "1",
    "HEAD_CIGAR_#1": "1",
    "HEAD_CIGAR_#2": "1",
    "HEAD_CIGAR_#3": "1",
    "HEAD_CIGAR_#4": "1",
  });
});

test("parts after completion convert with the exact per-visual duplicate value", () => {
  const initial = { ...createInitialProgression(NOW), gold: 100, warBucks: 50 };
  const result = purchaseLootboxesState(initial, "lootboxes1", 0, selectVisual("HEAD_CLOWN"));

  // HEAD_CLOWN requires two parts. The first two complete it without overflow; the remaining
  // three each convert at the source row's 1,000 WarBucks DUPLICATEWARBUCKS value.
  assert.equal(result.state.visualInventory?.visuals.HEAD_CLOWN?.parts, 2);
  assert.equal(result.duplicateWarBucks, 3_000);
  assert.equal(result.state.warBucks, 3_050);
  assert.equal(result.state.gold, 51);
});

test("duplicate conversion pays chargeback debt and rejects a corrupt persisted wallet", () => {
  const debt = { ...createInitialProgression(NOW), gold: 100, warBucks: -4_000 };
  const paidDown = purchaseLootboxesState(debt, "lootboxes1", 0, selectVisual("HEAD_CLOWN"));
  assert.equal(paidDown.duplicateWarBucks, 3_000);
  assert.equal(paidDown.state.warBucks, -1_000);

  const corrupt = { ...debt, warBucks: Number.NaN };
  assert.throws(
    () => purchaseLootboxesState(corrupt, "lootboxes1", 0, selectVisual("HEAD_CLOWN")),
    /reward balance is invalid/,
  );
});

test("purchase rejects client-authored discounts and insufficient balances with stock fields", () => {
  const initial = { ...createInitialProgression(NOW), gold: 48 };
  assert.throws(
    () => purchaseLootboxesState(initial, "lootboxes1", 10, selectVisual("HEAD_CLOWN")),
    (error: unknown) => {
      const actual = error as { code?: number; details?: Record<string, unknown> };
      assert.equal(actual.code, LOOTBOX_NO_DISCOUNT_FOUND);
      assert.deepEqual(actual.details, { Id: "lootboxes1", SpecialOffers: {} });
      return true;
    },
  );
  assert.throws(
    () => purchaseLootboxesState(initial, "lootboxes1", 0, selectVisual("HEAD_CLOWN")),
    (error: unknown) => {
      const actual = error as { code?: number; details?: Record<string, unknown> };
      assert.equal(actual.code, LOOTBOX_NOT_ENOUGH_GOLD);
      assert.deepEqual(actual.details, {
        lootboxId: "lootboxes1",
        LootboxesCost: 49,
        PlayerGold: 48,
      });
      return true;
    },
  );
});

test("normal duplicate serialization never applies the VIP marker", () => {
  assert.equal(
    serializePurchasedLootboxVisuals([
      { visualId: "HEAD_CLOWN", parts: 1 },
      { visualId: "HEAD_CLOWN", parts: 1 },
    ]),
    '{"HEAD_CLOWN":"1","HEAD_CLOWN_#1":"1"}',
  );
});
