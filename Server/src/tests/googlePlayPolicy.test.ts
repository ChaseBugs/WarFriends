import assert from "node:assert/strict";
import test from "node:test";
import {
  googlePlayApplicationPolicy,
  googlePlaySchedulingPolicy,
  googlePlaySubscriptionRevalidationBatchSize,
  googlePlaySubscriptionRevalidationCadenceSeconds,
  googlePlaySubscriptionSchedulerIntervalSeconds,
  googlePlayVoidedPurchaseSchedulerIntervalSeconds,
} from "../services/googlePlayPolicyService";

test("Google Play application identity and worker enablement are one immutable startup policy", () => {
  assert.equal(Object.isFrozen(googlePlayApplicationPolicy()), true);
  assert.deepEqual(googlePlayApplicationPolicy(), {
    purchasesEnabled: false,
    subscriptionRevalidationEnabled: false,
    voidedPurchaseReconciliationEnabled: false,
    packageName: "com.chillingo.warfriends.android.gplay",
  });
  assert.deepEqual(googlePlayApplicationPolicy({
    purchasesEnabled: true,
    subscriptionRevalidationEnabled: true,
    voidedPurchaseReconciliationEnabled: true,
    packageName: "com.example.game_2",
  }), {
    purchasesEnabled: true,
    subscriptionRevalidationEnabled: true,
    voidedPurchaseReconciliationEnabled: true,
    packageName: "com.example.game_2",
  });
});

test("Google Play application policy rejects malformed or split provider authority", () => {
  const base = {
    purchasesEnabled: false,
    subscriptionRevalidationEnabled: false,
    voidedPurchaseReconciliationEnabled: false,
    packageName: "com.example.game",
  };
  for (const packageName of [
    "", "com", " com.example.game", "com.example.game ", "1com.example.game",
    "com..game", "com.example.game-name", `com.${"a".repeat(252)}`,
  ]) {
    assert.throws(
      () => googlePlayApplicationPolicy({ ...base, packageName }),
      /Google Play application policy is invalid/,
    );
  }
  assert.throws(
    () => googlePlayApplicationPolicy({ ...base, subscriptionRevalidationEnabled: true }),
    /Google Play application policy is invalid/,
  );
  assert.throws(
    () => googlePlayApplicationPolicy({ ...base, voidedPurchaseReconciliationEnabled: true }),
    /Google Play application policy is invalid/,
  );
  assert.throws(
    () => googlePlayApplicationPolicy({ ...base, purchasesEnabled: 1 as unknown as boolean }),
    /Google Play application policy is invalid/,
  );
});

test("Google Play scheduling is one immutable startup policy", () => {
  assert.equal(Object.isFrozen(googlePlaySchedulingPolicy()), true);
  assert.deepEqual(googlePlaySchedulingPolicy(), {
    subscriptionRevalidationCadenceSeconds: 21_600,
    subscriptionSchedulerIntervalSeconds: 300,
    subscriptionRevalidationBatchSize: 100,
    voidedPurchaseSchedulerIntervalSeconds: 300,
  });
  assert.equal(googlePlaySubscriptionRevalidationCadenceSeconds(), 21_600);
  assert.equal(googlePlaySubscriptionSchedulerIntervalSeconds(), 300);
  assert.equal(googlePlaySubscriptionRevalidationBatchSize(), 100);
  assert.equal(googlePlayVoidedPurchaseSchedulerIntervalSeconds(), 300);
});

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
