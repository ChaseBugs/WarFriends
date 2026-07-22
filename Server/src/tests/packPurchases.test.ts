import assert from "node:assert/strict";
import test from "node:test";
import { ApiError } from "../apiErrors";
import { parseRestorePackInputs, validateRefundPackNotice } from "../handlers/purchases";
import { parseGoogleProductPurchase } from "../services/googlePlayPurchaseVerifier";
import { inAppEntitlement, type PackEntitlement } from "../services/inAppCatalogService";
import { itemInventoryStateFor } from "../services/itemInventoryService";
import { applyPurchaseEntitlementState } from "../services/purchaseService";
import { createInitialProgression } from "../services/playerStateService";
import { visualInventoryStateFor } from "../services/visualInventoryService";
import { cardInventoryStateFor } from "../services/cardInventoryService";

const PACKAGE = "com.chillingo.warfriends.android.gplay";
const NOW = 1_800_000_000;

function entitlement(productId: string): PackEntitlement {
  const value = inAppEntitlement(productId);
  assert.ok(value && value.kind === "pack");
  return value;
}

function verified(productId: string) {
  return {
    kind: "pack" as const,
    productId,
    storeProductId: `${PACKAGE}.${productId.toLowerCase()}`,
    orderId: `GPA.${productId}`,
    purchasedAt: NOW - 1,
  };
}

test("reviewed pack catalog exposes only benefits representable by recovered state", () => {
  const exact = [
    ["afstarterpack", "starterpack", 150, 25_000, 259_200],
    ["starterpackB", "starterpackB", 150, 25_000, 259_200],
    ["valuepackaf", "valuepackaf", 200, 0, 1_209_600],
    ["valuepackafB", "valuepackafB", 200, 0, 1_209_600],
    ["valuepackafc", "valuepackafc", 200, 0, 1_209_600],
    ["moneypack1", "moneypack1", 1_150, 350_000, 86_400],
    ["moneypack1B", "moneypack1B", 575, 180_000, 86_400],
  ] as const;
  for (const [productId, sourcePackName, gold, warBucks, vipSeconds] of exact) {
    const value = entitlement(productId);
    assert.equal(value.sourcePackName, sourcePackName);
    assert.equal(value.gold, gold);
    assert.equal(value.warBucks, warBucks);
    assert.equal(value.vipSeconds, vipSeconds);
  }
  assert.equal(inAppEntitlement("starterpack2"), null);
  assert.equal(inAppEntitlement("elitepack1"), null);
  assert.equal(inAppEntitlement("specialofferpack1"), null);
});

test("Google products.get keeps the server-selected pack discriminator", () => {
  const pack = entitlement("afstarterpack");
  const purchase = parseGoogleProductPurchase({
    purchaseTimeMillis: String((NOW - 1) * 1_000),
    purchaseState: 0,
    orderId: "GPA.pack",
    productId: `${PACKAGE}.afstarterpack`,
    quantity: 1,
  }, {
    packageName: PACKAGE,
    productId: pack.productId,
    purchaseToken: "opaque-token",
    orderId: "GPA.pack",
    entitlement: pack,
  });
  assert.equal(purchase.kind, "pack");
});

test("starter pack atomically grants wallet, VIP, weapon, and timed visual", () => {
  const initial = createInitialProgression(NOW);
  const result = applyPurchaseEntitlementState(
    initial,
    entitlement("afstarterpack"),
    verified("afstarterpack"),
    NOW,
  );
  assert.equal(result.state.revision, initial.revision + 1);
  assert.equal(result.state.gold, initial.gold + 150);
  assert.equal(result.state.warBucks, initial.warBucks + 25_000);
  assert.equal(result.state.vipStart, NOW);
  assert.equal(result.state.vipExpiration, NOW + 259_200);
  assert.deepEqual(itemInventoryStateFor(result.state).levelManagerData.savedWeapons["Google2u.LMG_Minigun"], {
    bought: true,
    boughtIndex: 0,
    showed: true,
    borrowed: false,
    specialFeature: 0,
  });
  const band = visualInventoryStateFor(result.state).visuals.BANDS_DAMAGE_0;
  assert.equal(band.bought, true);
  assert.equal(band.borrowed, false);
  assert.equal(band.expiresOn, NOW + 14_400);
  assert.equal(band.notificate, true);
  assert.deepEqual(result.response, { PackId: "afstarterpack" });
});

test("value pack grants permanent visuals and the durable extra card slot", () => {
  const result = applyPurchaseEntitlementState(
    createInitialProgression(NOW),
    entitlement("valuepackaf"),
    verified("valuepackaf"),
    NOW,
  );
  const visuals = visualInventoryStateFor(result.state).visuals;
  for (const name of ["CAMOS_ALIEN", "HELMETS_SKULL"]) {
    assert.equal(visuals[name].bought, true);
    assert.equal(visuals[name].borrowed, false);
    assert.equal(visuals[name].expiresOn, 0);
  }
  assert.equal(cardInventoryStateFor(result.state).extraSlot, true);
});

test("pack extension preserves active VIP start and remaining timed visual duration", () => {
  const initial = {
    ...createInitialProgression(NOW),
    vipStart: NOW - 1_000,
    vipExpiration: NOW + 5_000,
    visualInventory: {
      ...visualInventoryStateFor(createInitialProgression(NOW)),
      visuals: {
        BANDS_DAMAGE_0: {
          bought: true,
          showed: true,
          expiresOn: NOW + 100,
          borrowed: false,
          parts: 0,
          notificate: false,
        },
      },
    },
  };
  const result = applyPurchaseEntitlementState(
    initial,
    entitlement("starterpackB"),
    verified("starterpackB"),
    NOW,
  );
  assert.equal(result.state.vipStart, NOW - 1_000);
  assert.equal(result.state.vipExpiration, NOW + 5_000 + 259_200);
  const visual = visualInventoryStateFor(result.state).visuals.BANDS_DAMAGE_0;
  assert.equal(visual.expiresOn, NOW + 100 + 14_400);
  assert.equal(visual.showed, true);
  assert.equal(visual.parts, 0);
});

test("pack delivery rejects a non-finite existing timed visual before extending it", () => {
  const initial = {
    ...createInitialProgression(NOW),
    visualInventory: {
      ...visualInventoryStateFor(createInitialProgression(NOW)),
      visuals: {
        BANDS_DAMAGE_0: {
          bought: true,
          showed: true,
          expiresOn: Number.POSITIVE_INFINITY,
          borrowed: false,
          parts: 0,
          notificate: false,
        },
      },
    },
  };

  // Failing before the paid-pack transition ensures corrupt imported state cannot be extended,
  // serialized, or used to create an irreversible purchase receipt.
  assert.throws(
    () => applyPurchaseEntitlementState(
      initial,
      entitlement("starterpackB"),
      verified("starterpackB"),
      NOW,
    ),
    /Visual BANDS_DAMAGE_0 expiry is invalid/,
  );
  assert.equal(initial.revision, 0);
});

test("pack delivery rejects a mismatched verified product before changing state", () => {
  const initial = createInitialProgression(NOW);
  assert.throws(() => applyPurchaseEntitlementState(
    initial,
    entitlement("moneypack1"),
    verified("moneypack1B"),
    NOW,
  ), ApiError);
  assert.equal(initial.revision, 0);
});

test("RestorePacks parser normalizes the recovered Value1 through Value4 dictionaries", () => {
  const parsed = parseRestorePackInputs(JSON.stringify([{
    Value1: "valuepackaf",
    Value2: "opaque-token",
    Value3: PACKAGE,
    Value4: "GPA.restore",
  }]));
  assert.deepEqual(parsed, [{
    productId: "valuepackaf",
    purchaseToken: "opaque-token",
    packageName: PACKAGE,
    orderId: "GPA.restore",
  }]);
  assert.throws(() => parseRestorePackInputs("not-json"), ApiError);
  assert.throws(() => parseRestorePackInputs("[]"), ApiError);
  assert.throws(() => parseRestorePackInputs(JSON.stringify(new Array(51).fill({}))), ApiError);
  for (const invalid of [
    { Value1: "valuepackaf", Value2: "opaque-token", Value3: PACKAGE },
    { Value1: "valuepackaf", Value2: "opaque-token", Value3: PACKAGE, Value4: "GPA.restore", Alias: "x" },
    { value1: "valuepackaf", Value2: "opaque-token", Value3: PACKAGE, Value4: "GPA.restore" },
  ]) {
    assert.throws(() => parseRestorePackInputs(JSON.stringify([invalid])), ApiError);
  }
});

test("RefundPack accepts only the exact non-authoritative Android notice shape", () => {
  assert.doesNotThrow(() => validateRefundPackNotice(JSON.stringify([{
    inappId: "valuepackaf",
    purchaseToken: "opaque-token",
    packageName: PACKAGE,
    orderId: "GPA.refund",
  }])));

  for (const invalid of [
    [],
    [{ inappId: "valuepackaf", purchaseToken: "opaque-token", packageName: PACKAGE }],
    [{
      inappId: "valuepackaf",
      purchaseToken: "opaque-token",
      packageName: PACKAGE,
      orderId: "GPA.refund",
      ProductId: "valuepackaf",
    }],
    [{
      inappId: " valuepackaf",
      purchaseToken: "opaque-token",
      packageName: PACKAGE,
      orderId: "GPA.refund",
    }],
  ]) {
    assert.throws(() => validateRefundPackNotice(JSON.stringify(invalid)), ApiError);
  }
});
