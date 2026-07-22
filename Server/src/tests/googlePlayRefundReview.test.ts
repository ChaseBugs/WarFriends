import assert from "node:assert/strict";
import test from "node:test";
import type { Collection, Filter } from "mongodb";
import type { GooglePlayRefundReviewDocument, GooglePlayRtdnEventDocument } from "../db";
import {
  createGooglePlayRefundReviewIntent,
  googlePlayRefundReviewProviderRequest,
  GooglePlayRefundReviewInputError,
  normalizeGooglePlayRefundReviewListInput,
  normalizeGooglePlayRefundReviewSubmission,
  validatedGooglePlayRefundReview,
  wireGooglePlayRefundReview,
} from "../services/googlePlayRefundReviewService";
import { encryptPurchaseToken } from "../services/purchaseTokenCryptoService";
import { validatedGooglePlayRtdnEvent } from "../services/googlePlayRtdnService";

const NOW = new Date("2026-07-22T05:00:00.000Z");
const EVENT_ID = "136969346948";
const SECRET = "refund-review-test-encryption-secret-is-long-enough";
const PENDING_TOKEN = "pending-refund-review-token";

function pendingEvent(): GooglePlayRtdnEventDocument {
  return {
    _id: EVENT_ID,
    payloadSha256: "a".repeat(64),
    subscription: "",
    packageName: "com.chillingo.warfriends.android.gplay",
    kind: "pending-refund-review",
    eventTime: new Date(NOW.getTime() - 1_000),
    receivedAt: new Date(NOW.getTime() - 500),
    retentionDays: 90,
    status: "manual-review",
    attempts: 0,
    nextAttemptAt: null,
    completedAt: null,
    expiresAt: null,
    disposition: "manual-review-required",
    receiptId: null,
    productId: null,
    notificationType: null,
    orderId: "GPA.1234-5678-9012-34567",
    productType: null,
    refundType: null,
    encryptedPendingRefundToken: encryptPurchaseToken(
      PENDING_TOKEN,
      `google-play-rtdn:${EVENT_ID}`,
      SECRET,
    ),
    refundReason: 7,
  };
}

function validBody(): Record<string, unknown> {
  return {
    expectedStatus: "manual-review",
    sampleContentProvided: true,
    refundPreference: "DECLINE",
    consumptionPercentageMilliunits: 75_000,
    consumptionUsageEvents: [{
      obfuscatedAccountId: "opaque-account",
      obfuscatedProfileId: "opaque-profile",
      consumptionTime: "2026-07-22T04:59:00.123Z",
      ipAddress: "2001:db8::1",
      consumptionItemDescription: "The purchased consumable was delivered and used.",
      location: {
        regionCode: "US",
        administrativeArea: "CA",
        locality: "San Francisco",
      },
    }],
  };
}

test("refund-review submission preserves the reviewed Google API evidence shape exactly", () => {
  const submission = normalizeGooglePlayRefundReviewSubmission(
    EVENT_ID,
    validBody(),
    "Operator One",
    "refund-review:case-001",
    NOW,
  );
  assert.equal(submission.eventId, EVENT_ID);
  assert.equal(submission.operationId, "refund-review:case-001");
  assert.equal(submission.actor, "Operator One");
  assert.deepEqual(submission.evidence, {
    sampleContentProvided: true,
    refundPreference: "DECLINE",
    consumptionPercentageMilliunits: 75_000,
    consumptionUsageEvents: [{
      obfuscatedAccountId: "opaque-account",
      obfuscatedProfileId: "opaque-profile",
      consumptionTime: "2026-07-22T04:59:00.123Z",
      ipAddress: "2001:db8::1",
      consumptionItemDescription: "The purchased consumable was delivered and used.",
      location: {
        regionCode: "US",
        administrativeArea: "CA",
        locality: "San Francisco",
      },
    }],
  });
});

test("refund-review input rejects coercion, unknown fields, and invalid irreversible evidence", () => {
  const invalidBodies: Record<string, unknown>[] = [
    { ...validBody(), expectedStatus: "queued" },
    { ...validBody(), extra: true },
    { ...validBody(), sampleContentProvided: 1 },
    { ...validBody(), refundPreference: "REFUND" },
    { ...validBody(), consumptionPercentageMilliunits: "75000" },
    { ...validBody(), consumptionPercentageMilliunits: 1.5 },
    { ...validBody(), consumptionPercentageMilliunits: 100_001 },
    { ...validBody(), consumptionUsageEvents: Array.from({ length: 1_001 }, () => ({ ipAddress: "127.0.0.1" })) },
    { ...validBody(), consumptionUsageEvents: [{}] },
    { ...validBody(), consumptionUsageEvents: [{ obfuscatedAccountId: undefined }] },
    { ...validBody(), consumptionUsageEvents: [{ ipAddress: "999.1.1.1" }] },
    { ...validBody(), consumptionUsageEvents: [{ consumptionTime: "2026-07-22 04:59:00Z" }] },
    { ...validBody(), consumptionUsageEvents: [{ consumptionTime: "2026-02-30T04:59:00Z" }] },
    { ...validBody(), consumptionUsageEvents: [{ consumptionTime: "2026-07-22T05:00:01Z" }] },
    { ...validBody(), consumptionUsageEvents: [{ consumptionItemDescription: "x".repeat(5_001) }] },
    { ...validBody(), consumptionUsageEvents: [{ location: { regionCode: "us" } }] },
  ];
  for (const body of invalidBodies) {
    assert.throws(
      () => normalizeGooglePlayRefundReviewSubmission(
        EVENT_ID,
        body,
        "Operator One",
        "refund-review:case-001",
        NOW,
      ),
      GooglePlayRefundReviewInputError,
    );
  }
});

test("immutable intent replay stores no raw provider token or detailed consumption evidence", async () => {
  const event = pendingEvent();
  let stored: GooglePlayRefundReviewDocument | null = null;
  const eventCollection = {
    findOne: async () => event,
  } as unknown as Collection<GooglePlayRtdnEventDocument>;
  const reviewCollection = {
    findOne: async (filter: Filter<GooglePlayRefundReviewDocument>) => {
      if (!stored) return null;
      const candidate = filter as Record<string, unknown>;
      if (candidate.operationId !== undefined) {
        return candidate.operationId === stored.operationId ? stored : null;
      }
      if (candidate._id !== undefined) return candidate._id === stored._id ? stored : null;
      if (candidate.$or !== undefined) return stored;
      return null;
    },
    insertOne: async (value: GooglePlayRefundReviewDocument) => {
      stored = value;
      return { acknowledged: true, insertedId: value._id };
    },
  } as unknown as Collection<GooglePlayRefundReviewDocument>;
  const submission = normalizeGooglePlayRefundReviewSubmission(
    EVENT_ID,
    validBody(),
    "Operator One",
    "refund-review:case-001",
    NOW,
  );
  const created = await createGooglePlayRefundReviewIntent(
    submission,
    NOW,
    eventCollection,
    reviewCollection,
    SECRET,
  );
  assert.equal(created.replayed, false);
  assert.ok(stored);
  const serialized = JSON.stringify(stored);
  assert.equal(serialized.includes(PENDING_TOKEN), false);
  assert.equal(serialized.includes("2001:db8::1"), false);
  assert.equal(serialized.includes("The purchased consumable"), false);

  const providerRequest = googlePlayRefundReviewProviderRequest(created.review, event, SECRET);
  assert.deepEqual(providerRequest, { pendingRefundToken: PENDING_TOKEN, ...submission.evidence });
  const replay = await createGooglePlayRefundReviewIntent(
    submission,
    NOW,
    eventCollection,
    reviewCollection,
    SECRET,
  );
  assert.equal(replay.replayed, true);
  await assert.rejects(
    () => createGooglePlayRefundReviewIntent(
      { ...submission, evidence: { ...submission.evidence, refundPreference: "APPROVE" } },
      NOW,
      eventCollection,
      reviewCollection,
      SECRET,
    ),
    (error: unknown) => error instanceof GooglePlayRefundReviewInputError && error.httpStatus === 409,
  );
});

test("durable refund-review authority rejects damaged audit and lifecycle fields", async () => {
  const event = pendingEvent();
  let stored: GooglePlayRefundReviewDocument | null = null;
  const eventCollection = { findOne: async () => event } as unknown as Collection<GooglePlayRtdnEventDocument>;
  const reviewCollection = {
    findOne: async () => stored,
    insertOne: async (value: GooglePlayRefundReviewDocument) => {
      stored = value;
      return { acknowledged: true, insertedId: value._id };
    },
  } as unknown as Collection<GooglePlayRefundReviewDocument>;
  const submission = normalizeGooglePlayRefundReviewSubmission(
    EVENT_ID,
    validBody(),
    "Operator One",
    "refund-review:case-002",
    NOW,
  );
  const { review } = await createGooglePlayRefundReviewIntent(
    submission,
    NOW,
    eventCollection,
    reviewCollection,
    SECRET,
  );
  assert.equal(validatedGooglePlayRefundReview(review, NOW), review);
  const damaged: GooglePlayRefundReviewDocument[] = [
    { ...review, actor: " Operator One " },
    { ...review, attempts: Number.NaN },
    { ...review, requestSha256: "f".repeat(63) },
    { ...review, status: "submitted", nextAttemptAt: null },
    { ...review, nextAttemptAt: new Date(review.createdAt.getTime() - 1) },
    { ...review, expiresAt: new Date(NOW.getTime() + 1) },
  ];
  for (const value of damaged) {
    assert.throws(() => validatedGooglePlayRefundReview(value, NOW), /Stored Google Play refund-review/);
  }
  assert.throws(
    () => validatedGooglePlayRefundReview({ ...review, actor: " Operator One " }, NOW),
    (error: unknown) => !(error instanceof GooglePlayRefundReviewInputError),
  );
});

test("admin queue projection is bounded and never exposes encrypted provider evidence", () => {
  const event = pendingEvent();
  const input = normalizeGooglePlayRefundReviewListInput({ limit: "100" }, NOW);
  assert.equal(input.limit, 100);
  assert.equal(input.decodedCursor, null);
  const item = wireGooglePlayRefundReview(event);
  assert.equal(item.state, "manual-review");
  assert.equal(JSON.stringify(item).includes(PENDING_TOKEN), false);
  assert.equal(JSON.stringify(item).includes("encryptedPendingRefundToken"), false);
  for (const limit of ["0", "101", "1.5", 10]) {
    assert.throws(
      () => normalizeGooglePlayRefundReviewListInput({ limit }, NOW),
      GooglePlayRefundReviewInputError,
    );
  }
});

test("RTDN terminal refund-review lifecycle is accepted only as one retained completed pair", () => {
  const event = pendingEvent();
  const submittedAt = new Date(NOW.getTime() + 1_000);
  const completed: GooglePlayRtdnEventDocument = {
    ...event,
    status: "completed",
    disposition: "refund-review-submitted",
    completedAt: submittedAt,
    expiresAt: new Date(submittedAt.getTime() + event.retentionDays * 86_400_000),
  };
  assert.equal(validatedGooglePlayRtdnEvent(completed, submittedAt), completed);
  assert.throws(
    () => validatedGooglePlayRtdnEvent({ ...completed, disposition: "manual-review-required" }, submittedAt),
    /Stored Google Play RTDN event/,
  );
});
