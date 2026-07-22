import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import type { GooglePlayRtdnEventDocument } from "../db";
import {
  authenticateGooglePlayRtdn,
  GooglePlayRtdnAuthenticationError,
  GooglePlayRtdnConflictError,
  GooglePlayRtdnValidationError,
  ingestGooglePlayRtdn,
  parseGooglePlayRtdnEnvelope,
  validatedGooglePlayRtdnEvent,
} from "../services/googlePlayRtdnService";
import type { GooglePlayRtdnIdentityPolicy } from "../services/googlePlayPolicyService";
import { googlePlayPurchaseTokenReceiptId } from "../services/googlePlayPurchaseTokenIdentityService";

const RECEIVED_AT = new Date("2026-07-22T03:00:00.000Z");
const EVENT_MILLIS = String(RECEIVED_AT.getTime() - 1_000);
const SECRET = "rtdn-test-encryption-secret-that-is-long-enough";
const IDENTITY: GooglePlayRtdnIdentityPolicy = {
  enabled: true,
  audience: "https://game.example.com/providers/google-play/rtdn",
  serviceAccountEmail: "warfriends@example-project.iam.gserviceaccount.com",
  subscription: "projects/example-project/subscriptions/warfriends-rtdn",
};

function push(developer: Record<string, unknown>, messageId = "136969346945"): Record<string, unknown> {
  return {
    message: {
      data: Buffer.from(JSON.stringify(developer), "utf8").toString("base64"),
      messageId,
      attributes: { source: "google-play" },
      publishTime: "2026-07-22T02:59:59.000Z",
    },
    subscription: IDENTITY.subscription,
  };
}

function developer(notification: Record<string, unknown>): Record<string, unknown> {
  return {
    version: "1.0",
    packageName: "com.chillingo.warfriends.android.gplay",
    eventTimeMillis: EVENT_MILLIS,
    ...notification,
  };
}

test("authenticated Pub/Sub push binds signature claims to the exact RTDN identity", async () => {
  let observedAudience = "";
  await authenticateGooglePlayRtdn(
    "Bearer aaa.bbb.ccc",
    IDENTITY,
    async (_jwt, audience) => {
      observedAudience = audience;
      return {
        iss: "https://accounts.google.com",
        aud: IDENTITY.audience,
        email: IDENTITY.serviceAccountEmail,
        email_verified: true,
      };
    },
  );
  assert.equal(observedAudience, IDENTITY.audience);

  for (const authorization of [undefined, "", "bearer aaa.bbb.ccc", "Bearer no-dots", "Bearer aaa.bbb.ccc extra"]) {
    await assert.rejects(
      () => authenticateGooglePlayRtdn(authorization, IDENTITY, async () => ({})),
      GooglePlayRtdnAuthenticationError,
    );
  }
  for (const claims of [
    { iss: "https://issuer.example", aud: IDENTITY.audience, email: IDENTITY.serviceAccountEmail, email_verified: true },
    { iss: "accounts.google.com", aud: "https://other.example/rtdn", email: IDENTITY.serviceAccountEmail, email_verified: true },
    { iss: "accounts.google.com", aud: IDENTITY.audience, email: "other@example-project.iam.gserviceaccount.com", email_verified: true },
    { iss: "accounts.google.com", aud: IDENTITY.audience, email: IDENTITY.serviceAccountEmail, email_verified: false },
  ]) {
    await assert.rejects(
      () => authenticateGooglePlayRtdn("Bearer aaa.bbb.ccc", IDENTITY, async () => claims),
      GooglePlayRtdnAuthenticationError,
    );
  }
});

test("subscription RTDN stores only the shared token HMAC and a retryable provider wake-up", () => {
  const token = "subscription-token_123";
  const event = parseGooglePlayRtdnEnvelope(push(developer({
    subscriptionNotification: { version: "1.0", notificationType: 4, purchaseToken: token },
  })), RECEIVED_AT, IDENTITY, SECRET);
  assert.equal(event.kind, "subscription");
  assert.equal(event.status, "pending");
  assert.equal(event.receiptId, googlePlayPurchaseTokenReceiptId(token));
  assert.equal(event.notificationType, 4);
  assert.equal(event.nextAttemptAt?.getTime(), RECEIVED_AT.getTime());
  assert.equal(event.disposition, null);
  assert.equal(JSON.stringify(event).includes(token), false);
  assert.equal(validatedGooglePlayRtdnEvent(event, RECEIVED_AT, IDENTITY), event);
});

test("one-time, voided, refund-review, and test RTDN kinds retain distinct safe lifecycles", () => {
  const oneTime = parseGooglePlayRtdnEnvelope(push(developer({
    oneTimeProductNotification: {
      version: "1.0",
      notificationType: 1,
      purchaseToken: "one-time-token",
      sku: "com.chillingo.warfriends.android.gplay.gold01",
    },
  }), "136969346946"), RECEIVED_AT, IDENTITY, SECRET);
  assert.equal(oneTime.status, "completed");
  assert.equal(oneTime.disposition, "one-time-client-verification");
  assert.equal(oneTime.expiresAt!.getTime() - oneTime.completedAt!.getTime(), 90 * 86_400_000);

  const voided = parseGooglePlayRtdnEnvelope(push(developer({
    voidedPurchaseNotification: {
      purchaseToken: "voided-token",
      orderId: "GPA.1234-5678-9012-34567",
      productType: 2,
      refundType: 1,
    },
  }), "136969346947"), RECEIVED_AT, IDENTITY, SECRET);
  assert.equal(voided.status, "pending");
  assert.equal(voided.productType, 2);
  assert.equal(voided.refundType, 1);

  const refundToken = "pending-refund-review-token";
  const review = parseGooglePlayRtdnEnvelope(push(developer({
    pendingRefundReviewNotification: {
      version: "1.0",
      pendingRefundToken: refundToken,
      orderId: "GPA.1234-5678-9012-34567",
      refundReason: 7,
      obfuscatedAccountId: "opaque-player",
    },
  }), "136969346948"), RECEIVED_AT, IDENTITY, SECRET);
  assert.equal(review.status, "manual-review");
  assert.equal(review.disposition, "manual-review-required");
  assert.equal(review.expiresAt, null);
  assert.ok(review.encryptedPendingRefundToken);
  assert.equal(JSON.stringify(review).includes(refundToken), false);

  const publishedTest = parseGooglePlayRtdnEnvelope(push(developer({
    testNotification: { version: "1.0" },
  }), "136969346949"), RECEIVED_AT, IDENTITY, SECRET);
  assert.equal(publishedTest.status, "completed");
  assert.equal(publishedTest.disposition, "test");
});

test("RTDN parser rejects ambiguous, padded, noncanonical, future, and cross-application authority", () => {
  const base = developer({ testNotification: { version: "1.0" } });
  const cases: unknown[] = [
    { ...push(base), extra: true },
    { ...push(base), subscription: `${IDENTITY.subscription} ` },
    { ...push(base), subscription: "projects/other/subscriptions/warfriends-rtdn" },
    push({ ...base, packageName: "com.attacker.game" }),
    push({ ...base, eventTimeMillis: String(RECEIVED_AT.getTime() + 1) }),
    push({ ...base, testNotification: { version: "1.0", extra: true } }),
    push({ ...base, subscriptionNotification: { version: "1.0", notificationType: 4, purchaseToken: "token" } }),
    { message: { data: "YQ==\n", messageId: "136969346950" }, subscription: IDENTITY.subscription },
    { message: { data: "!!!!", messageId: "136969346951" }, subscription: IDENTITY.subscription },
    { message: { data: Buffer.from("not-json").toString("base64"), messageId: "136969346952" }, subscription: IDENTITY.subscription },
    { ...push(base), message: { ...(push(base).message as object), messageId: "001" } },
  ];
  for (const value of cases) {
    assert.throws(
      () => parseGooglePlayRtdnEnvelope(value, RECEIVED_AT, IDENTITY, SECRET),
      GooglePlayRtdnValidationError,
    );
  }
});

test("durable RTDN authority rejects lifecycle damage instead of reopening provider work", () => {
  const event = parseGooglePlayRtdnEnvelope(push(developer({
    testNotification: { version: "1.0" },
  })), RECEIVED_AT, IDENTITY, SECRET);
  const damaged: GooglePlayRtdnEventDocument[] = [
    { ...event, attempts: Number.NaN },
    { ...event, status: "pending", disposition: null, completedAt: null, expiresAt: null, nextAttemptAt: null },
    { ...event, expiresAt: new Date(event.expiresAt!.getTime() + 1) },
    { ...event, receiptId: "raw-token" },
    { ...event, eventTime: new Date(event.receivedAt.getTime() + 1) },
    { ...event, disposition: "subscription-revalidated" },
  ];
  for (const value of damaged) {
    assert.throws(
      () => validatedGooglePlayRtdnEvent(value, RECEIVED_AT, IDENTITY),
      /Stored Google Play RTDN event/,
    );
  }
});

test("messageId insertion acknowledges only an exact durable replay", async () => {
  const event = parseGooglePlayRtdnEnvelope(push(developer({
    testNotification: { version: "1.0" },
  })), RECEIVED_AT, IDENTITY, SECRET);
  let stored: GooglePlayRtdnEventDocument | null = null;
  const collection = {
    insertOne: async (value: GooglePlayRtdnEventDocument) => {
      if (stored) {
        const error = new Error("duplicate") as Error & { code: number };
        error.code = 11000;
        throw error;
      }
      stored = value;
      return { acknowledged: true };
    },
    findOne: async () => stored,
  } as unknown as Collection<GooglePlayRtdnEventDocument>;
  assert.deepEqual(await ingestGooglePlayRtdn(event, collection, IDENTITY), { replayed: false, status: "completed" });
  assert.deepEqual(await ingestGooglePlayRtdn(event, collection, IDENTITY), { replayed: true, status: "completed" });
  await assert.rejects(
    () => ingestGooglePlayRtdn({ ...event, payloadSha256: "f".repeat(64) }, collection, IDENTITY),
    GooglePlayRtdnConflictError,
  );
});

test("shared purchase-token identity rejects values that another producer could normalize", () => {
  assert.match(googlePlayPurchaseTokenReceiptId("opaque-token"), /^[0-9a-f]{64}$/u);
  for (const token of ["", " padded", "padded ", "bad\nvalue", "x".repeat(4_097)]) {
    assert.throws(() => googlePlayPurchaseTokenReceiptId(token), /purchase token is invalid/);
  }
});
