import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import type { PlayerDocument, PlayerSubscriptionState } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { DIRECT_PURCHASE_KINDS, purchaseHandlers } from "../handlers/purchases";
import {
  GooglePlayVerificationError,
  parseGoogleProductPurchase,
  parseGoogleSubscriptionPurchase,
  parseGoogleSubscriptionStatus,
  type GooglePlayVerificationInput,
} from "../services/googlePlayPurchaseVerifier";
import { googlePlayStoreProductId, inAppEntitlement } from "../services/inAppCatalogService";
import { applyPurchaseEntitlementState, parseGooglePlayPurchaseInput } from "../services/purchaseService";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import { applySubscriptionRevalidationState } from "../services/googlePlaySubscriptionRevalidationService";
import { decryptPurchaseToken, encryptPurchaseToken } from "../services/purchaseTokenCryptoService";
import {
  hasActiveSubscription,
  validatedSubscriptionAuthorityReceiptId,
} from "../services/subscriptionBenefitService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";

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

test("paid catalog uses recovered 4.9.5 currency amounts and fails closed for unsupported products", () => {
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

test("explicit subscription action is authenticated and cannot deliver currency products", () => {
  assert.equal(purchaseHandlers[DbAction.BuyInApp]?.requiresAuth, true);
  assert.equal(purchaseHandlers[DbAction.BuySubscription]?.requiresAuth, true);
  assert.deepEqual(DIRECT_PURCHASE_KINDS[DbAction.BuyInApp], ["currency", "subscription"]);
  assert.deepEqual(DIRECT_PURCHASE_KINDS[DbAction.BuySubscription], ["subscription"]);
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

test("subscription status distinguishes authoritative non-entitlement from retryable unknown states", () => {
  const input = verificationInput("subscription1");
  const onHold = parseGoogleSubscriptionStatus({
    startTime: "2026-12-01T00:00:00Z",
    subscriptionState: "SUBSCRIPTION_STATE_ON_HOLD",
    lineItems: [{
      productId: `${PACKAGE}.subscription1`,
      expiryTime: "2027-02-01T00:00:00Z",
      latestSuccessfulOrderId: input.orderId,
    }],
  }, input, NOW);
  assert.equal(onHold.entitled, false);
  assert.ok((onHold.expiresAt ?? 0) > NOW);

  assert.throws(
    () => parseGoogleSubscriptionStatus({
      subscriptionState: "SUBSCRIPTION_STATE_FUTURE_UNKNOWN",
      lineItems: [],
    }, input, NOW),
    (error: unknown) => error instanceof GooglePlayVerificationError && error.transient,
  );
});

test("subscription revalidation renews current authority and revokes a held entitlement immediately", () => {
  const receiptId = "receipt-current";
  const initial = {
    ...createInitialProgression(NOW),
    subscription: {
      type: "subscription1" as const,
      expireTime: NOW + 1_000,
      subscribeSince: NOW - 10_000,
      dogTagTimerLock: NOW - 500,
    },
    subscriptionAuthorityReceiptId: receiptId,
  };
  const renewed = applySubscriptionRevalidationState(initial, receiptId, {
    subscriptionState: "SUBSCRIPTION_STATE_ACTIVE",
    entitled: true,
    storeProductId: `${PACKAGE}.subscription1`,
    expiresAt: NOW + 2_000,
  }, NOW);
  assert.equal(renewed.changed, true);
  assert.equal(renewed.state.subscription?.expireTime, NOW + 2_000);
  assert.equal(renewed.state.subscription?.subscribeSince, NOW - 10_000);
  assert.equal(renewed.state.subscription?.dogTagTimerLock, NOW - 500);

  const held = applySubscriptionRevalidationState(renewed.state, receiptId, {
    subscriptionState: "SUBSCRIPTION_STATE_ON_HOLD",
    entitled: false,
    storeProductId: `${PACKAGE}.subscription1`,
    expiresAt: NOW + 2_000,
  }, NOW + 10);
  assert.equal(held.changed, true);
  assert.equal(held.state.subscription?.expireTime, NOW + 10);
});

test("stale subscription receipt cannot shorten a newer token's entitlement", () => {
  const state = {
    ...createInitialProgression(NOW),
    subscription: {
      type: "subscription1" as const,
      expireTime: NOW + 5_000,
      subscribeSince: NOW - 100,
      dogTagTimerLock: NOW,
    },
    subscriptionAuthorityReceiptId: "receipt-new",
  };
  const stale = applySubscriptionRevalidationState(state, "receipt-old", {
    subscriptionState: "SUBSCRIPTION_STATE_EXPIRED",
    entitled: false,
    storeProductId: `${PACKAGE}.subscription1`,
    expiresAt: NOW - 1,
  }, NOW);
  assert.equal(stale.changed, false);
  assert.equal(stale.state, state);
});

test("subscription lifecycle rejects corrupt stored and observed deadlines", () => {
  const entitlement = inAppEntitlement("subscription1");
  assert.ok(entitlement);
  const corrupt = {
    ...createInitialProgression(NOW),
    subscription: {
      type: "subscription1" as const,
      expireTime: Number.POSITIVE_INFINITY,
      subscribeSince: NOW - 100,
      dogTagTimerLock: NOW,
    },
    subscriptionAuthorityReceiptId: "receipt-current",
  };
  assert.throws(
    () => applyPurchaseEntitlementState(corrupt, entitlement, {
      kind: "subscription",
      productId: "subscription1",
      storeProductId: `${PACKAGE}.subscription1`,
      orderId: "GPA.repair",
      purchasedAt: NOW,
      expiresAt: NOW + 2_000,
    }, NOW, "receipt-repair"),
    /Subscription expiry is invalid/,
  );
  assert.throws(
    () => applySubscriptionRevalidationState(corrupt, "receipt-current", {
      subscriptionState: "SUBSCRIPTION_STATE_ACTIVE",
      entitled: true,
      storeProductId: `${PACKAGE}.subscription1`,
      expiresAt: Number.POSITIVE_INFINITY,
    }, NOW),
    /Observed subscription expiry is invalid/,
  );

  const clean = createInitialProgression(NOW);
  const future = {
    ...clean,
    subscription: {
      type: "subscription1" as const,
      subscribeSince: NOW + 100,
      dogTagTimerLock: NOW + 100,
      expireTime: NOW + 1_000,
    },
  };
  assert.equal(hasActiveSubscription(future, NOW), false);
  assert.throws(
    () => validatedProgressionSuccessor(clean, {
      ...future,
      revision: clean.revision + 1,
      subscription: {
        ...future.subscription,
        unexpected: true,
      } as unknown as PlayerSubscriptionState,
    }),
    /Subscription type is invalid/,
  );
  assert.throws(
    () => applyPurchaseEntitlementState(clean, entitlement, {
      kind: "subscription",
      productId: "subscription1",
      storeProductId: `${PACKAGE}.subscription1`,
      orderId: "GPA.future",
      purchasedAt: NOW + 1,
      expiresAt: NOW + 2_000,
    }, NOW, "receipt-future"),
    /Verified subscription timeline is invalid/,
  );
  assert.throws(
    () => applySubscriptionRevalidationState({
      ...clean,
      subscription: {
        type: "subscription1",
        expireTime: NOW + 1_000,
        subscribeSince: NOW - 100,
        dogTagTimerLock: NOW,
      },
      subscriptionAuthorityReceiptId: "receipt-current",
    }, "receipt-current", {
      subscriptionState: "SUBSCRIPTION_STATE_EXPIRED",
      entitled: false,
      storeProductId: `${PACKAGE}.subscription1`,
      expiresAt: NOW - 200,
    }, NOW),
    /Subscription timeline is invalid/,
  );
});

test("subscription authority receipt accepts only the durable HMAC key format", () => {
  const receiptId = "a".repeat(64);
  assert.equal(validatedSubscriptionAuthorityReceiptId(undefined), undefined);
  assert.equal(validatedSubscriptionAuthorityReceiptId(receiptId), receiptId);

  for (const corrupt of [null, "", "A".repeat(64), "g".repeat(64), "a".repeat(63), 1]) {
    assert.throws(
      () => validatedSubscriptionAuthorityReceiptId(corrupt),
      /Subscription authority receipt is invalid/,
    );
  }

  const dto = newPlayer("receipt-player", "ReceiptPlayer", AccountType.Guest);
  const player: PlayerDocument = {
    id: dto.id,
    accountName: dto.accountName,
    authToken: "receipt-session",
    accountType: dto.accountType,
    leagueTier: dto.leagueTier,
    armyPower: dto.armyPower,
    experience: dto.experience,
    squadPoints: dto.squadPoints,
    squadName: dto.squadName,
    player: dto,
    progression: {
      ...createInitialProgression(NOW),
      subscriptionAuthorityReceiptId: "readable-test-placeholder",
    },
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
  assert.throws(() => buildPlayerData(player), /Subscription authority receipt is invalid/);
});

test("subscription purchase tokens are authenticated, receipt-bound ciphertext", () => {
  const secret = "test-only-high-entropy-secret-with-more-than-32-characters";
  const encrypted = encryptPurchaseToken("opaque-google-play-token", "receipt-a", secret);
  assert.notEqual(encrypted.ciphertext, "opaque-google-play-token");
  assert.equal(decryptPurchaseToken(encrypted, "receipt-a", secret), "opaque-google-play-token");
  assert.throws(() => decryptPurchaseToken(encrypted, "receipt-b", secret));
  assert.throws(() => decryptPurchaseToken(encrypted, "receipt-a", `${secret}-wrong`));
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

  assert.throws(
    () => buildPlayerData({
      ...document,
      progression: {
        ...progression,
        subscription: { ...progression.subscription, subscribeSince: Number.NaN },
      },
    }, NOW),
    /Subscription start is invalid/,
  );
  assert.throws(
    () => buildPlayerData({
      ...document,
      progression: {
        ...progression,
        subscription: {
          ...progression.subscription,
          subscribeSince: NOW + 10,
          dogTagTimerLock: NOW + 10,
        },
      },
    }, NOW),
    /Subscription start is in the future/,
  );
});
