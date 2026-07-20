import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import {
  GooglePlayVerificationError,
  parseGoogleProductPurchase,
  parseGoogleSubscriptionPurchase,
  type GooglePlayVerificationInput,
} from "../services/googlePlayPurchaseVerifier";
import { googlePlayStoreProductId, inAppEntitlement } from "../services/inAppCatalogService";
import { applyPurchaseEntitlementState, parseGooglePlayPurchaseInput } from "../services/purchaseService";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";

const PACKAGE = "com.chillingo.warfriends.android.gplay";
const NOW = 1_800_000_000;

function verificationInput(productId: string): GooglePlayVerificationInput {
  const entitlement = inAppEntitlement(productId);
  assert.ok(entitlement);
  return {
    packageName: PACKAGE,
    productId,
    purchaseToken: "opaque-play-token",
    orderId: "GPA.1234-5678-9012-34567",
    entitlement,
  };
}

test("paid catalog uses recovered 4.9.5 currency amounts and fails closed for packs", () => {
  assert.deepEqual(inAppEntitlement("afgold1"), {
    kind: "currency", productId: "afgold1", gold: 100, warBucks: 0,
  });
  assert.deepEqual(inAppEntitlement("bwarbucks6"), {
    kind: "currency", productId: "bwarbucks6", gold: 0, warBucks: 4_500_000,
  });
  assert.deepEqual(inAppEntitlement("subscription1"), { kind: "subscription", productId: "subscription1" });
  assert.equal(inAppEntitlement("starterpack"), null);
  assert.equal(inAppEntitlement("afgold7daily1"), null);
  assert.equal(googlePlayStoreProductId(PACKAGE, "AfGold1"), `${PACKAGE}.afgold1`);
});

test("purchase request reads store proof and ignores client-authored currency hints", () => {
  assert.deepEqual(parseGooglePlayPurchaseInput({
    ProductId: "afgold1",
    PurchaseToken: "opaque-play-token",
    PackageName: PACKAGE,
    OrderId: "GPA.1234-5678-9012-34567",
    GoldBase: "bgold",
    WarbucksBase: "bwarbucks",
  }), {
    productId: "afgold1",
    purchaseToken: "opaque-play-token",
    packageName: PACKAGE,
    orderId: "GPA.1234-5678-9012-34567",
  });
});

test("Google product verification requires completed matching single-quantity purchase", () => {
  const input = verificationInput("afgold1");
  const verified = parseGoogleProductPurchase({
    purchaseTimeMillis: "1799999999000",
    purchaseState: 0,
    consumptionState: 1,
    orderId: input.orderId,
    productId: `${PACKAGE}.afgold1`,
    quantity: 1,
  }, input);
  assert.deepEqual(verified, {
    kind: "currency",
    productId: "afgold1",
    storeProductId: `${PACKAGE}.afgold1`,
    orderId: input.orderId,
    purchasedAt: 1_799_999_999,
  });
  assert.throws(
    () => parseGoogleProductPurchase({
      purchaseTimeMillis: "1799999999000",
      purchaseState: 1,
      orderId: input.orderId,
      productId: `${PACKAGE}.afgold1`,
    }, input),
    GooglePlayVerificationError,
  );
});

test("subscription verification accepts canceled-but-unexpired entitlement and rejects hold", () => {
  const input = verificationInput("subscription1");
  const latestRenewalOrder = `${input.orderId}..1`;
  const verified = parseGoogleSubscriptionPurchase({
    startTime: "2026-12-01T00:00:00Z",
    subscriptionState: "SUBSCRIPTION_STATE_CANCELED",
    lineItems: [{
      productId: `${PACKAGE}.subscription1`,
      expiryTime: "2027-02-01T00:00:00Z",
      latestSuccessfulOrderId: latestRenewalOrder,
    }],
  }, input, NOW);
  assert.equal(verified.kind, "subscription");
  assert.equal(verified.orderId, latestRenewalOrder);
  assert.ok((verified.expiresAt ?? 0) > NOW);
  assert.throws(
    () => parseGoogleSubscriptionPurchase({
      startTime: "2026-12-01T00:00:00Z",
      subscriptionState: "SUBSCRIPTION_STATE_ON_HOLD",
      lineItems: [{
        productId: `${PACKAGE}.subscription1`,
        expiryTime: "2027-02-01T00:00:00Z",
        latestSuccessfulOrderId: input.orderId,
      }],
    }, input, NOW),
    GooglePlayVerificationError,
  );
});

test("verified currency and subscription transitions expose exact stock response fields", () => {
  const initial = createInitialProgression(NOW);
  const currency = inAppEntitlement("bwarbucks1");
  assert.ok(currency);
  const paid = applyPurchaseEntitlementState(initial, currency, {
    kind: "currency",
    productId: "bwarbucks1",
    storeProductId: `${PACKAGE}.bwarbucks1`,
    orderId: "GPA.currency",
    purchasedAt: NOW,
  }, NOW);
  assert.equal(paid.state.warBucks, 30_000);
  assert.deepEqual(paid.response, { Id: "bwarbucks1", Warbucks: 30_000 });

  const subscription = inAppEntitlement("subscription1");
  assert.ok(subscription);
  const subscribed = applyPurchaseEntitlementState(paid.state, subscription, {
    kind: "subscription",
    productId: "subscription1",
    storeProductId: `${PACKAGE}.subscription1`,
    orderId: "GPA.subscription",
    purchasedAt: NOW - 10,
    expiresAt: NOW + 2_592_000,
  }, NOW);
  assert.deepEqual(subscribed.response, {
    Id: "subscription1",
    SubscriptionBought: true,
    ExpireTime: NOW + 2_592_000,
    dogTagTimerLock: NOW,
  });

  const replay = applyPurchaseEntitlementState(subscribed.state, subscription, {
    kind: "subscription",
    productId: "subscription1",
    storeProductId: `${PACKAGE}.subscription1`,
    orderId: "GPA.subscription",
    purchasedAt: NOW - 10,
    expiresAt: NOW + 2_592_000,
  }, NOW + 1);
  assert.equal(replay.state, subscribed.state);
  assert.equal(replay.response.SubscriptionNoChange, true);
});

test("subscription persists through the exact PlayerData serialized-object key", () => {
  const player = newPlayer("purchase-player", "PurchasePlayer", AccountType.Guest);
  const progression = {
    ...createInitialProgression(NOW),
    subscription: {
      type: "subscription1" as const,
      expireTime: NOW + 100,
      subscribeSince: NOW - 100,
      dogTagTimerLock: NOW,
    },
  };
  const document: PlayerDocument = {
    id: player.id,
    accountName: player.accountName,
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression,
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
  const wire = buildPlayerData(document, NOW).Subscription as { S: string };
  assert.deepEqual(JSON.parse(wire.S), progression.subscription);
});
