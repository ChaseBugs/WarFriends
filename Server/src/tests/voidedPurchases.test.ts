import assert from "node:assert/strict";
import test from "node:test";
import type { PurchaseReceiptDocument, PurchaseReversibleGrant } from "../db";
import {
  GooglePlayVerificationError,
  parseGoogleVoidedPurchasesPage,
} from "../services/googlePlayPurchaseVerifier";
import { inAppEntitlement } from "../services/inAppCatalogService";
import { applyVoidedOneTimePurchaseState } from "../services/googlePlayVoidedPurchaseService";
import { itemInventoryStateFor } from "../services/itemInventoryService";
import { applyPurchaseEntitlementState } from "../services/purchaseService";
import { createInitialProgression } from "../services/playerStateService";
import { visualInventoryStateFor } from "../services/visualInventoryService";
import { cardInventoryStateFor } from "../services/cardInventoryService";

const NOW = 1_800_000_000;
const PACKAGE = "com.chillingo.warfriends.android.gplay";

function buyPack(productId: string, state = createInitialProgression(NOW)) {
  const entitlement = inAppEntitlement(productId);
  assert.ok(entitlement && entitlement.kind === "pack");
  const result = applyPurchaseEntitlementState(state, entitlement, {
    kind: "pack",
    productId,
    storeProductId: `${PACKAGE}.${productId.toLowerCase()}`,
    orderId: `GPA.${productId}`,
    purchasedAt: NOW,
  }, NOW);
  assert.ok(result.reversibleGrant);
  return result;
}

function receipt(
  productId: string,
  reversibleGrant: PurchaseReversibleGrant,
  revoked = false,
): PurchaseReceiptDocument {
  return {
    _id: `receipt-${productId}`,
    platform: "google-play",
    playerId: "player",
    productId,
    storeProductId: `${PACKAGE}.${productId.toLowerCase()}`,
    orderId: `GPA.${productId}`,
    kind: "pack",
    purchasedAt: new Date(NOW * 1_000),
    verifiedAt: new Date(NOW * 1_000),
    response: { PackId: productId },
    reversibleGrant,
    ...(revoked ? { revokedAt: new Date(NOW * 1_000) } : {}),
  };
}

test("voided page parsing validates authoritative token, order, time, and reason fields", () => {
  assert.deepEqual(parseGoogleVoidedPurchasesPage({
    tokenPagination: { nextPageToken: "next" },
    voidedPurchases: [{
      purchaseToken: "opaque-token",
      orderId: "GPA.order",
      purchaseTimeMillis: "1799999000000",
      voidedTimeMillis: "1800000000000",
      voidedSource: 2,
      voidedReason: 7,
    }],
  }), {
    purchases: [{
      purchaseToken: "opaque-token",
      orderId: "GPA.order",
      purchaseTimeMillis: 1_799_999_000_000,
      voidedTimeMillis: 1_800_000_000_000,
      voidedSource: 2,
      voidedReason: 7,
    }],
    nextPageToken: "next",
  });
  assert.throws(() => parseGoogleVoidedPurchasesPage({
    voidedPurchases: [{ orderId: "GPA.missing-token" }],
  }), GooglePlayVerificationError);
});

test("currency chargeback becomes durable debt when the original grant was spent", () => {
  const initial = { ...createInitialProgression(NOW), gold: 25, warBucks: 100 };
  const reversed = applyVoidedOneTimePurchaseState(initial, {
    gold: 100,
    warBucks: 500,
    vipSeconds: 0,
    weapons: [],
    visuals: [],
    extraCardSlot: false,
    introducedExtraCardSlot: false,
  }, [], [], NOW);
  assert.equal(reversed.gold, -75);
  assert.equal(reversed.warBucks, -400);
  assert.equal(reversed.revision, initial.revision + 1);
});

test("starter pack chargeback removes its weapon, timed visual, currencies, and VIP time", () => {
  const bought = buyPack("afstarterpack");
  assert.ok(bought.reversibleGrant);
  const packReceipt = receipt("afstarterpack", bought.reversibleGrant);
  const equipped = itemInventoryStateFor(bought.state);
  equipped.inventoryData.slots["0"] = { name: "Google2u.LMG_Minigun", weaponIndex: 4 };
  const reversed = applyVoidedOneTimePurchaseState(
    { ...bought.state, itemInventory: equipped },
    bought.reversibleGrant,
    [],
    [packReceipt],
    NOW + 10,
  );
  assert.equal(reversed.gold, 0);
  assert.equal(reversed.warBucks, 0);
  assert.equal(reversed.vipExpiration, NOW);
  assert.equal(reversed.vipStart, 0);
  const inventory = itemInventoryStateFor(reversed);
  assert.equal(inventory.levelManagerData.savedWeapons["Google2u.LMG_Minigun"].bought, false);
  assert.equal(inventory.inventoryData.slots["0"].name, "Google2u.AssaultRifle_AK47");
  const visual = visualInventoryStateFor(reversed).visuals.BANDS_DAMAGE_0;
  assert.equal(visual.bought, false);
  assert.equal(visual.expiresOn, 0);
});

test("overlapping value packs preserve shared benefits until the final active receipt is voided", () => {
  const first = buyPack("valuepackaf");
  const second = buyPack("valuepackafB", first.state);
  assert.ok(first.reversibleGrant && second.reversibleGrant);
  const firstReceipt = receipt("valuepackaf", first.reversibleGrant);
  const secondReceipt = receipt("valuepackafB", second.reversibleGrant);

  const afterFirstRefund = applyVoidedOneTimePurchaseState(
    second.state,
    first.reversibleGrant,
    [secondReceipt],
    [firstReceipt, secondReceipt],
    NOW,
  );
  assert.equal(visualInventoryStateFor(afterFirstRefund).visuals.CAMOS_ALIEN.bought, true);
  assert.equal(cardInventoryStateFor(afterFirstRefund).extraSlot, true);

  const voidedFirst = receipt("valuepackaf", first.reversibleGrant, true);
  const afterFinalRefund = applyVoidedOneTimePurchaseState(
    afterFirstRefund,
    second.reversibleGrant,
    [],
    [voidedFirst, secondReceipt],
    NOW,
  );
  assert.equal(visualInventoryStateFor(afterFinalRefund).visuals.CAMOS_ALIEN.bought, false);
  assert.equal(visualInventoryStateFor(afterFinalRefund).visuals.HELMETS_SKULL.bought, false);
  assert.equal(cardInventoryStateFor(afterFinalRefund).extraSlot, false);
});
