import assert from "node:assert/strict";
import test from "node:test";
import { createInitialProgression } from "../services/playerStateService";
import {
  VIP_CATALOG,
  VIP_DISCOUNT_NOT_FOUND,
  VIP_GOLD_CARD_REWARD_CHANCE,
  VIP_NOT_ENOUGH_GOLD,
  grantDailyVipCardsState,
  purchaseVipState,
} from "../services/vipService";
import { CARD_CATALOG } from "../services/cardInventoryService";
import {
  isVipActiveAt,
  validatedVipExpiration,
  validatedVipTimeline,
} from "../services/vipEntitlementService";
import { validatedVipDailyCardState } from "../services/vipDailyCardAuthorityService";

const NOW = 1_700_000_000;

function scriptedRandom(...values: number[]): (upperBound: number) => number {
  let cursor = 0;
  return (upperBound) => {
    const value = values[cursor++];
    assert.notEqual(value, undefined, "test selector exhausted");
    assert.ok(value! >= 0 && value! < upperBound, `test value ${value} exceeds ${upperBound}`);
    return value!;
  };
}

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
  const result = purchaseVipState(initial, NOW, "VIP_3", 0, 0, scriptedRandom(0, 0, 0, 1));
  assert.equal(result.cost, 499);
  assert.equal(result.state.gold, 1_501);
  assert.equal(result.state.vipStart, NOW);
  assert.equal(result.state.vipExpiration, NOW + 604_800);
  assert.equal(result.state.revision, initial.revision + 1);
  assert.equal(result.dailyCardReward?.cardIds.length, 2);
});

test("active VIP renewal preserves remaining time instead of replacing it", () => {
  const existingExpiration = NOW + 86_400;
  const initial = {
    ...createInitialProgression(NOW),
    gold: 1_000,
    vipStart: NOW - 10,
    vipExpiration: existingExpiration,
  };
  const result = purchaseVipState(initial, NOW, "VIP_2", 0, 0, scriptedRandom(0, 0, 0, 1));
  assert.equal(result.state.vipStart, NOW);
  assert.equal(result.state.vipExpiration, existingExpiration + 259_200);
});

test("VIP daily cards use the decoded 75 percent Gold chance and otherwise select Silver", () => {
  assert.equal(VIP_GOLD_CARD_REWARD_CHANCE, 0.75);
  const active = { ...createInitialProgression(NOW), vipExpiration: NOW + 60 };
  // First rarity roll succeeds (<7500), the second fails. Pool indexes then select concrete IDs.
  const result = grantDailyVipCardsState(active, NOW, scriptedRandom(7_499, 0, 7_500, 0));
  assert.ok(result.reward);
  const [goldId, silverId] = result.reward.cardIds;
  assert.equal(CARD_CATALOG[goldId]?.rarity, 3);
  assert.equal(CARD_CATALOG[silverId]?.rarity, 2);
  assert.equal(result.state.cardInventory?.cardData[goldId]?.amount, 1);
  assert.equal(result.state.cardInventory?.cardData[silverId]?.amount, 1);
  assert.equal(result.state.revision, active.revision + 1);
});

test("VIP daily cards allow duplicate identities but never grant a second pair on the same UTC day", () => {
  const active = { ...createInitialProgression(NOW), vipExpiration: NOW + 172_800 };
  const first = grantDailyVipCardsState(active, NOW, scriptedRandom(0, 0, 0, 0));
  assert.deepEqual(first.reward?.cardIds[0], first.reward?.cardIds[1]);
  const duplicateId = first.reward!.cardIds[0];
  assert.equal(first.state.cardInventory?.cardData[duplicateId]?.amount, 2);

  let randomWasCalled = false;
  const repeated = grantDailyVipCardsState(first.state, NOW + 60, () => {
    randomWasCalled = true;
    return 0;
  });
  assert.equal(repeated.reward, undefined);
  assert.equal(repeated.state.revision, first.state.revision);
  assert.equal(repeated.state.cardInventory?.cardData[duplicateId]?.amount, 2);
  assert.equal(randomWasCalled, false);
});

test("VIP daily cards grant again after the UTC boundary and reject expired membership", () => {
  const active = { ...createInitialProgression(NOW), vipExpiration: NOW + 172_800 };
  const first = grantDailyVipCardsState(active, NOW, scriptedRandom(0, 0, 0, 1));
  const nextUtcDay = (Math.floor(NOW / 86_400) + 1) * 86_400;
  const second = grantDailyVipCardsState(first.state, nextUtcDay, scriptedRandom(9_999, 0, 9_999, 1));
  assert.ok(second.reward);
  assert.notEqual(second.reward!.dayKey, first.reward!.dayKey);

  const expired = grantDailyVipCardsState(
    { ...second.state, vipExpiration: nextUtcDay },
    nextUtcDay,
    () => { throw new Error("expired VIP must not draw cards"); },
  );
  assert.equal(expired.reward, undefined);
});

test("VIP rejects invented discounts and insufficient Gold with stock error codes", () => {
  const rich = { ...createInitialProgression(NOW), gold: 10_000 };
  for (const inheritedId of ["__proto__", "constructor", "toString"]) {
    assert.throws(() => purchaseVipState(rich, NOW, inheritedId, 0), /is not available/);
  }
  assert.throws(
    () => purchaseVipState(rich, NOW, "VIP_4", 50),
    (error: unknown) => (error as { code?: number }).code === VIP_DISCOUNT_NOT_FOUND,
  );
  assert.throws(
    () => purchaseVipState(createInitialProgression(NOW), NOW, "VIP_1", 0),
    (error: unknown) => (error as { code?: number }).code === VIP_NOT_ENOUGH_GOLD,
  );
});

test("every VIP benefit rejects corrupt or overflowing entitlement deadlines", () => {
  assert.equal(validatedVipExpiration(undefined), 0);
  assert.equal(isVipActiveAt(NOW + 1, NOW), true);
  assert.equal(isVipActiveAt(NOW, NOW), false);

  for (const vipExpiration of [Number.NaN, Number.POSITIVE_INFINITY, -1, 1.5]) {
    const corrupt = { ...createInitialProgression(NOW), gold: 10_000, vipExpiration };
    assert.throws(() => validatedVipExpiration(vipExpiration), /Stored VIP expiration is invalid/);
    assert.throws(
      () => grantDailyVipCardsState(corrupt, NOW, () => 0),
      /Stored VIP expiration is invalid/,
    );
    assert.throws(
      () => purchaseVipState(corrupt, NOW, "VIP_1", 0, 0, () => 0),
      /Stored VIP expiration is invalid/,
    );
  }

  const overflow = {
    ...createInitialProgression(NOW),
    gold: 10_000,
    vipExpiration: Number.MAX_SAFE_INTEGER,
  };
  assert.throws(
    () => purchaseVipState(overflow, NOW, "VIP_4", 0, 0, () => 0),
    /VIP expiration overflowed/,
  );
});

test("VIP timeline authority validates display metadata without changing expiry-owned activity", () => {
  assert.deepEqual(validatedVipTimeline(0, 0), { vipStart: 0, vipExpiration: 0 });
  assert.deepEqual(validatedVipTimeline(NOW - 10, NOW + 10), {
    vipStart: NOW - 10,
    vipExpiration: NOW + 10,
  });
  assert.equal(isVipActiveAt(NOW + 10, NOW), true);

  for (const [start, expiration] of [
    [1, 0],
    [-1, NOW],
    [NOW + 1, NOW],
    [Number.NaN, NOW],
    [Number.POSITIVE_INFINITY, Number.POSITIVE_INFINITY],
  ]) {
    assert.throws(() => validatedVipTimeline(start, expiration), /Stored VIP/);
  }
});

test("VIP daily-card marker rejects malformed or future durable grant authority", () => {
  const active = {
    ...createInitialProgression(NOW),
    vipStart: NOW - 100,
    vipExpiration: NOW + 1_000,
  };
  const granted = grantDailyVipCardsState(active, NOW, scriptedRandom(0, 0, 0, 0));
  const marker = granted.state.vipDailyCards!;
  assert.deepEqual(validatedVipDailyCardState(marker, NOW), marker);

  for (const corrupt of [
    { ...marker, lastGrantDay: "2020-02-31" },
    { ...marker, lastGrantedAt: Number.POSITIVE_INFINITY },
    { ...marker, lastRewardIds: [marker.lastRewardIds[0]] },
    { ...marker, lastRewardIds: ["unknown-card", marker.lastRewardIds[1]] },
  ]) {
    assert.throws(
      () => validatedVipDailyCardState(corrupt as typeof marker, NOW),
      /Stored VIP daily-card|VIP daily-card grant time/,
    );
  }
  assert.throws(
    () => grantDailyVipCardsState({ ...active, vipDailyCards: marker }, NOW - 1, () => 0),
    /Stored VIP daily-card grant time is in the future/,
  );
});
