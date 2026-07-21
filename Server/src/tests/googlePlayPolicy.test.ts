import assert from "node:assert/strict";
import test from "node:test";
import {
  googlePlaySubscriptionRevalidationBatchSize,
  googlePlaySubscriptionRevalidationCadenceSeconds,
  googlePlaySubscriptionSchedulerIntervalSeconds,
  googlePlayVoidedPurchaseSchedulerIntervalSeconds,
} from "../services/googlePlayPolicyService";

test("Google Play policy preserves exact supported provider scheduling values", () => {
  assert.equal(googlePlaySubscriptionRevalidationCadenceSeconds(300), 300);
  assert.equal(googlePlaySubscriptionRevalidationCadenceSeconds(86_400), 86_400);
  assert.equal(googlePlaySubscriptionSchedulerIntervalSeconds(30), 30);
  assert.equal(googlePlaySubscriptionSchedulerIntervalSeconds(3_600), 3_600);
  assert.equal(googlePlaySubscriptionRevalidationBatchSize(1), 1);
  assert.equal(googlePlaySubscriptionRevalidationBatchSize(1_000), 1_000);
  assert.equal(googlePlayVoidedPurchaseSchedulerIntervalSeconds(60), 60);
  assert.equal(googlePlayVoidedPurchaseSchedulerIntervalSeconds(3_600), 3_600);
});

test("Google Play policy rejects values previously rounded, clamped, or stored as invalid dates", () => {
  const cases: ReadonlyArray<readonly [(value: number) => number, readonly number[]]> = [
    [googlePlaySubscriptionRevalidationCadenceSeconds, [Number.NaN, Infinity, 299, 300.5, 86_401]],
    [googlePlaySubscriptionSchedulerIntervalSeconds, [Number.NaN, Infinity, 29, 30.5, 3_601]],
    [googlePlaySubscriptionRevalidationBatchSize, [Number.NaN, Infinity, 0, 1.5, 1_001]],
    [googlePlayVoidedPurchaseSchedulerIntervalSeconds, [Number.NaN, Infinity, 59, 60.5, 3_601]],
  ];
  for (const [policy, values] of cases) {
    for (const value of values) {
      assert.throws(() => policy(value), /Google Play .* policy is invalid/);
    }
  }
});
