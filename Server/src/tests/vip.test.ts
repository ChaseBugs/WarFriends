import assert from "node:assert/strict";
import test from "node:test";
import { createInitialProgression } from "../services/playerStateService";
import {
  VIP_CATALOG,
  VIP_DISCOUNT_NOT_FOUND,
  VIP_NOT_ENOUGH_GOLD,
  purchaseVipState,
} from "../services/vipService";

const NOW = 1_700_000_000;

test("VIP catalog reproduces all four 4.9.5 MainScene price and duration rows", () => {
  assert.deepEqual(VIP_CATALOG, {
    VIP_1: { id: "VIP_1", gold: 49, seconds: 43_200 },
    VIP_2: { id: "VIP_2", gold: 249, seconds: 259_200 },
    VIP_3: { id: "VIP_3", gold: 499, seconds: 604_800 },
    VIP_4: { id: "VIP_4", gold: 1_799, seconds: 2_592_000 },
  });
});

test("VIP purchase debits the server price and grants the exact source duration", () => {
  const initial = { ...createInitialProgression(NOW), gold: 2_000 };
  const result = purchaseVipState(initial, NOW, "VIP_3", 0);
  assert.equal(result.cost, 499);
  assert.equal(result.state.gold, 1_501);
  assert.equal(result.state.vipStart, NOW);
  assert.equal(result.state.vipExpiration, NOW + 604_800);
  assert.equal(result.state.revision, initial.revision + 1);
});

test("active VIP renewal preserves remaining time instead of replacing it", () => {
  const existingExpiration = NOW + 86_400;
  const initial = {
    ...createInitialProgression(NOW),
    gold: 1_000,
    vipStart: NOW - 10,
    vipExpiration: existingExpiration,
  };
  const result = purchaseVipState(initial, NOW, "VIP_2", 0);
  assert.equal(result.state.vipStart, NOW);
  assert.equal(result.state.vipExpiration, existingExpiration + 259_200);
});

test("VIP rejects invented discounts and insufficient Gold with stock error codes", () => {
  const rich = { ...createInitialProgression(NOW), gold: 10_000 };
  assert.throws(
    () => purchaseVipState(rich, NOW, "VIP_4", 50),
    (error: unknown) => (error as { code?: number }).code === VIP_DISCOUNT_NOT_FOUND,
  );
  assert.throws(
    () => purchaseVipState(createInitialProgression(NOW), NOW, "VIP_1", 0),
    (error: unknown) => (error as { code?: number }).code === VIP_NOT_ENOUGH_GOLD,
  );
});
