import { createHash } from "crypto";
import { isIP } from "net";
import type { ClientSession, Collection, Filter } from "mongodb";
import { GoogleAuth } from "google-auth-library";
import { config } from "../config";
import {
  googlePlayRefundReviews,
  googlePlayRtdnEvents,
  withMongoTransaction,
  type GooglePlayRefundReviewDocument,
  type GooglePlayRtdnEventDocument,
} from "../db";
import logger from "../utils/logger";
import { outboundRequestHeaders } from "./requestContextService";
import {
  googlePlayApplicationPolicy,
  googlePlayRtdnBatchSize,
  googlePlayRtdnSchedulerIntervalSeconds,
} from "./googlePlayPolicyService";
import { validatedGooglePlayRtdnEvent } from "./googlePlayRtdnService";
import { decryptPurchaseToken, encryptPurchaseToken } from "./purchaseTokenCryptoService";
import { withScheduledJobLease } from "./scheduledJobLeaseService";
import { unixNow } from "./playerStateService";

const APPLICATION = googlePlayApplicationPolicy();
const androidPublisherScope = "https://www.googleapis.com/auth/androidpublisher";
const publisherRoot = "https://androidpublisher.googleapis.com/androidpublisher/v3/applications";
const workerJobId = "google-play-refund-reviews";
const MESSAGE_ID = /^[1-9][0-9]{0,19}$/u;
const OPERATION_ID = /^[A-Za-z0-9._:-]{8,128}$/u;
const HASH = /^[0-9a-f]{64}$/u;
const REVIEW_KEYS = new Set([
  "_id", "operationId", "actor", "packageName", "orderId", "requestSha256", "encryptedRequest",
  "refundPreference", "sampleContentProvided", "consumptionPercentageMilliunits", "usageEventCount",
  "retentionDays", "status", "attempts", "lastErrorCode", "createdAt", "nextAttemptAt", "submittedAt",
  "expiresAt",
]);
const SUBMISSION_KEYS = new Set([
  "expectedStatus", "sampleContentProvided", "refundPreference", "consumptionPercentageMilliunits",
  "consumptionUsageEvents",
]);
const EVIDENCE_KEYS = new Set([
  "sampleContentProvided", "refundPreference", "consumptionPercentageMilliunits", "consumptionUsageEvents",
]);
const USAGE_EVENT_KEYS = new Set([
  "obfuscatedAccountId", "obfuscatedProfileId", "consumptionTime", "ipAddress",
  "consumptionItemDescription", "location",
]);
const LOCATION_KEYS = new Set(["regionCode", "administrativeArea", "locality", "sublocality"]);

export type GooglePlayRefundPreference = "DECLINE" | "APPROVE" | "NEUTRAL";

export interface GooglePlayCoarseLocation {
  regionCode: string;
  administrativeArea?: string;
  locality?: string;
  sublocality?: string;
}

export interface GooglePlayConsumptionUsageEvent {
  obfuscatedAccountId?: string;
  obfuscatedProfileId?: string;
  consumptionTime?: string;
  ipAddress?: string;
  consumptionItemDescription?: string;
  location?: GooglePlayCoarseLocation;
}

export interface GooglePlayRefundReviewEvidence {
  sampleContentProvided: boolean;
  refundPreference: GooglePlayRefundPreference;
  consumptionPercentageMilliunits?: number;
  consumptionUsageEvents?: GooglePlayConsumptionUsageEvent[];
}

export interface GooglePlayRefundReviewProviderRequest extends GooglePlayRefundReviewEvidence {
  pendingRefundToken: string;
}

export interface GooglePlayRefundReviewSubmission {
  eventId: string;
  operationId: string;
  actor: string;
  evidence: GooglePlayRefundReviewEvidence;
}

export class GooglePlayRefundReviewInputError extends Error {
  constructor(message: string, readonly httpStatus: 400 | 404 | 409 = 400) {
    super(message);
    this.name = "GooglePlayRefundReviewInputError";
  }
}

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value) && !(value instanceof Date);
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function exactNow(now: Date): number {
  if (!safeDate(now)) throw new Error("Google Play refund-review time is invalid.");
  return now.getTime();
}

function boundedExactText(value: unknown, field: string, maximum: number): string {
  if (typeof value !== "string"
    || value.length === 0
    || value.length > maximum
    || value.trim() !== value
    || /[\u0000-\u001f\u007f]/u.test(value)) {
    throw new GooglePlayRefundReviewInputError(`${field} is invalid.`);
  }
  return value;
}

function normalizedActor(value: unknown): string {
  if (typeof value !== "string") throw new GooglePlayRefundReviewInputError("X-Admin-Actor is invalid.");
  const actor = value.trim().replace(/\s+/gu, " ");
  if (actor.length === 0 || actor.length > 100 || /[\u0000-\u001f\u007f]/u.test(actor)) {
    throw new GooglePlayRefundReviewInputError("X-Admin-Actor is invalid.");
  }
  return actor;
}

function canonicalStoredActor(value: unknown): value is string {
  if (typeof value !== "string") return false;
  try {
    return normalizedActor(value) === value;
  } catch {
    // Durable validation must report damaged server authority as a server failure. Reusing the
    // request-layer error here would incorrectly turn a corrupt MongoDB row into an HTTP 400.
    return false;
  }
}

export function normalizeGooglePlayRefundReviewActor(value: unknown): string {
  return normalizedActor(value);
}

export function normalizeGooglePlayRefundReviewOperationId(value: unknown): string {
  const operationId = typeof value === "string" ? value.trim() : "";
  if (!OPERATION_ID.test(operationId)) {
    throw new GooglePlayRefundReviewInputError(
      "Idempotency-Key must contain 8-128 letters, digits, dots, underscores, colons, or hyphens.",
    );
  }
  return operationId;
}

export function normalizeGooglePlayRefundReviewEventId(value: unknown): string {
  if (typeof value !== "string" || !MESSAGE_ID.test(value)) {
    throw new GooglePlayRefundReviewInputError("RTDN messageId is invalid.");
  }
  return value;
}

function normalizeLocation(value: unknown): GooglePlayCoarseLocation {
  if (!plainRecord(value)
    || Object.keys(value).some((key) => !LOCATION_KEYS.has(key))
    || !Object.prototype.hasOwnProperty.call(value, "regionCode")) {
    throw new GooglePlayRefundReviewInputError("Consumption location is invalid.");
  }
  const regionCode = boundedExactText(value.regionCode, "Consumption regionCode", 2);
  if (!/^[A-Z]{2}$/u.test(regionCode)) {
    throw new GooglePlayRefundReviewInputError("Consumption regionCode is invalid.");
  }
  const optional = (field: "administrativeArea" | "locality" | "sublocality"): string | undefined => (
    value[field] === undefined ? undefined : boundedExactText(value[field], `Consumption ${field}`, 200)
  );
  const administrativeArea = optional("administrativeArea");
  const locality = optional("locality");
  const sublocality = optional("sublocality");
  return {
    regionCode,
    ...(administrativeArea === undefined ? {} : { administrativeArea }),
    ...(locality === undefined ? {} : { locality }),
    ...(sublocality === undefined ? {} : { sublocality }),
  };
}

function normalizeUsageEvent(value: unknown, nowMs: number): GooglePlayConsumptionUsageEvent {
  if (!plainRecord(value)
    || Object.keys(value).length === 0
    || Object.keys(value).some((key) => !USAGE_EVENT_KEYS.has(key))) {
    throw new GooglePlayRefundReviewInputError("Consumption usage event is invalid.");
  }
  const accountId = value.obfuscatedAccountId === undefined
    ? undefined
    : boundedExactText(value.obfuscatedAccountId, "Consumption obfuscatedAccountId", 64);
  const profileId = value.obfuscatedProfileId === undefined
    ? undefined
    : boundedExactText(value.obfuscatedProfileId, "Consumption obfuscatedProfileId", 64);
  let consumptionTime: string | undefined;
  if (value.consumptionTime !== undefined) {
    consumptionTime = boundedExactText(value.consumptionTime, "Consumption time", 64);
    const timestamp = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})(?:\.\d{1,9})?(?:Z|[+-]\d{2}:\d{2})$/u.exec(
      consumptionTime,
    );
    if (!timestamp) throw new GooglePlayRefundReviewInputError("Consumption time is invalid.");
    const [, yearText, monthText, dayText, hourText, minuteText, secondText] = timestamp;
    const year = Number(yearText);
    const month = Number(monthText);
    const day = Number(dayText);
    const daysInMonth = month >= 1 && month <= 12
      ? new Date(Date.UTC(year, month, 0)).getUTCDate()
      : 0;
    if (day < 1 || day > daysInMonth || Number(hourText) > 23
      || Number(minuteText) > 59 || Number(secondText) > 59) {
      throw new GooglePlayRefundReviewInputError("Consumption time is invalid.");
    }
    const milliseconds = Date.parse(consumptionTime);
    if (!Number.isFinite(milliseconds) || milliseconds < 0 || milliseconds > nowMs) {
      throw new GooglePlayRefundReviewInputError("Consumption time is invalid.");
    }
  }
  let ipAddress: string | undefined;
  if (value.ipAddress !== undefined) {
    ipAddress = boundedExactText(value.ipAddress, "Consumption IP address", 64);
    if (isIP(ipAddress) === 0) throw new GooglePlayRefundReviewInputError("Consumption IP address is invalid.");
  }
  const description = value.consumptionItemDescription === undefined
    ? undefined
    : boundedExactText(value.consumptionItemDescription, "Consumption item description", 5_000);
  const location = value.location === undefined ? undefined : normalizeLocation(value.location);
  const normalized: GooglePlayConsumptionUsageEvent = {
    ...(accountId === undefined ? {} : { obfuscatedAccountId: accountId }),
    ...(profileId === undefined ? {} : { obfuscatedProfileId: profileId }),
    ...(consumptionTime === undefined ? {} : { consumptionTime }),
    ...(ipAddress === undefined ? {} : { ipAddress }),
    ...(description === undefined ? {} : { consumptionItemDescription: description }),
    ...(location === undefined ? {} : { location }),
  };
  // JSON callers cannot normally send an `undefined` value, but the service boundary is public
  // to tests and future adapters. Reject a syntactically keyed event that normalizes to no
  // evidence instead of forwarding an empty object to the irreversible provider operation.
  if (Object.keys(normalized).length === 0) {
    throw new GooglePlayRefundReviewInputError("Consumption usage event is invalid.");
  }
  return normalized;
}

function normalizeEvidenceRecord(value: unknown, now: Date): GooglePlayRefundReviewEvidence {
  const nowMs = exactNow(now);
  if (!plainRecord(value)
    || Object.keys(value).some((key) => !EVIDENCE_KEYS.has(key))
    || typeof value.sampleContentProvided !== "boolean"
    || (value.refundPreference !== "DECLINE"
      && value.refundPreference !== "APPROVE"
      && value.refundPreference !== "NEUTRAL")) {
    throw new GooglePlayRefundReviewInputError("Refund review evidence is invalid.");
  }
  let consumptionPercentageMilliunits: number | undefined;
  if (value.consumptionPercentageMilliunits !== undefined) {
    if (!Number.isSafeInteger(value.consumptionPercentageMilliunits)
      || (value.consumptionPercentageMilliunits as number) < 0
      || (value.consumptionPercentageMilliunits as number) > 100_000) {
      throw new GooglePlayRefundReviewInputError("consumptionPercentageMilliunits is invalid.");
    }
    consumptionPercentageMilliunits = value.consumptionPercentageMilliunits as number;
  }
  let consumptionUsageEvents: GooglePlayConsumptionUsageEvent[] | undefined;
  if (value.consumptionUsageEvents !== undefined) {
    if (!Array.isArray(value.consumptionUsageEvents) || value.consumptionUsageEvents.length > 1_000) {
      throw new GooglePlayRefundReviewInputError("consumptionUsageEvents is invalid.");
    }
    consumptionUsageEvents = value.consumptionUsageEvents.map((entry) => normalizeUsageEvent(entry, nowMs));
  }
  return {
    sampleContentProvided: value.sampleContentProvided,
    refundPreference: value.refundPreference,
    ...(consumptionPercentageMilliunits === undefined ? {} : { consumptionPercentageMilliunits }),
    ...(consumptionUsageEvents === undefined ? {} : { consumptionUsageEvents }),
  };
}

export function normalizeGooglePlayRefundReviewSubmission(
  eventIdValue: unknown,
  body: unknown,
  actorValue: unknown,
  operationIdValue: unknown,
  now = new Date(),
): GooglePlayRefundReviewSubmission {
  if (!plainRecord(body)
    || Object.keys(body).some((key) => !SUBMISSION_KEYS.has(key))
    || body.expectedStatus !== "manual-review") {
    throw new GooglePlayRefundReviewInputError("Refund review request shape or expectedStatus is invalid.");
  }
  return {
    eventId: normalizeGooglePlayRefundReviewEventId(eventIdValue),
    operationId: normalizeGooglePlayRefundReviewOperationId(operationIdValue),
    actor: normalizeGooglePlayRefundReviewActor(actorValue),
    evidence: normalizeEvidenceRecord({
      sampleContentProvided: body.sampleContentProvided,
      refundPreference: body.refundPreference,
      ...(body.consumptionPercentageMilliunits === undefined
        ? {} : { consumptionPercentageMilliunits: body.consumptionPercentageMilliunits }),
      ...(body.consumptionUsageEvents === undefined
        ? {} : { consumptionUsageEvents: body.consumptionUsageEvents }),
    }, now),
  };
}

function validCiphertext(value: GooglePlayRefundReviewDocument["encryptedRequest"]): boolean {
  if (!value || typeof value !== "object" || Array.isArray(value)) return false;
  const keys = Object.keys(value);
  return keys.length === 4
    && keys.every((key) => ["version", "iv", "authTag", "ciphertext"].includes(key))
    && value.version === 1
    && typeof value.iv === "string"
    && typeof value.authTag === "string"
    && typeof value.ciphertext === "string"
    && Buffer.from(value.iv, "base64").length === 12
    && Buffer.from(value.authTag, "base64").length === 16
    && value.iv === Buffer.from(value.iv, "base64").toString("base64")
    && value.authTag === Buffer.from(value.authTag, "base64").toString("base64")
    && value.ciphertext.length > 0
    && value.ciphertext === Buffer.from(value.ciphertext, "base64").toString("base64");
}

/** Complete durable authority for one first-call-wins provider recommendation. */
export function validatedGooglePlayRefundReview(
  review: GooglePlayRefundReviewDocument,
  now?: Date,
): GooglePlayRefundReviewDocument {
  const raw = review as unknown as Record<string, unknown>;
  const keys = plainRecord(review) ? Object.keys(raw) : [];
  if (keys.length !== REVIEW_KEYS.size
    || keys.some((key) => !REVIEW_KEYS.has(key))
    || !MESSAGE_ID.test(review?._id)
    || !OPERATION_ID.test(review?.operationId)
    || !canonicalStoredActor(review?.actor)
    || review.packageName !== APPLICATION.packageName
    || typeof review.orderId !== "string"
    || review.orderId.length === 0
    || review.orderId.length > 255
    || review.orderId.trim() !== review.orderId
    || !HASH.test(review.requestSha256)
    || !validCiphertext(review.encryptedRequest)
    || !["DECLINE", "APPROVE", "NEUTRAL"].includes(review.refundPreference)
    || typeof review.sampleContentProvided !== "boolean"
    || (review.consumptionPercentageMilliunits !== null
      && (!Number.isSafeInteger(review.consumptionPercentageMilliunits)
        || review.consumptionPercentageMilliunits < 0
        || review.consumptionPercentageMilliunits > 100_000))
    || !Number.isSafeInteger(review.usageEventCount)
    || review.usageEventCount < 0
    || review.usageEventCount > 1_000
    || !Number.isSafeInteger(review.retentionDays)
    || review.retentionDays < 30
    || review.retentionDays > 365
    || !["pending", "submitted"].includes(review.status)
    || !Number.isSafeInteger(review.attempts)
    || review.attempts < 0
    || review.attempts > 1_000_000
    || (review.lastErrorCode !== null
      && review.lastErrorCode !== "provider"
      && review.lastErrorCode !== "configuration")
    || !safeDate(review.createdAt)
    || (now !== undefined && (!safeDate(now) || review.createdAt.getTime() > now.getTime()))) {
    throw new Error("Stored Google Play refund-review authority is invalid.");
  }
  const pending = review.status === "pending"
    && safeDate(review.nextAttemptAt)
    && review.nextAttemptAt.getTime() >= review.createdAt.getTime()
    && review.submittedAt === null
    && review.expiresAt === null;
  const submitted = review.status === "submitted"
    && review.nextAttemptAt === null
    && review.lastErrorCode === null
    && safeDate(review.submittedAt)
    && review.submittedAt.getTime() >= review.createdAt.getTime()
    && (now === undefined || review.submittedAt.getTime() <= now.getTime())
    && safeDate(review.expiresAt)
    && review.expiresAt.getTime() - review.submittedAt.getTime() === review.retentionDays * 86_400_000;
  if (!pending && !submitted) throw new Error("Stored Google Play refund-review lifecycle is invalid.");
  return review;
}

function evidenceJson(evidence: GooglePlayRefundReviewEvidence): string {
  return JSON.stringify(evidence);
}

function requestAad(eventId: string, requestSha256: string): string {
  return `google-play-refund-review:${eventId}:${requestSha256}`;
}

function sameIntent(
  review: GooglePlayRefundReviewDocument,
  input: GooglePlayRefundReviewSubmission,
  requestSha256: string,
): boolean {
  return review._id === input.eventId
    && review.operationId === input.operationId
    && review.actor === input.actor
    && review.requestSha256 === requestSha256
    && review.refundPreference === input.evidence.refundPreference
    && review.sampleContentProvided === input.evidence.sampleContentProvided
    && review.consumptionPercentageMilliunits === (input.evidence.consumptionPercentageMilliunits ?? null)
    && review.usageEventCount === (input.evidence.consumptionUsageEvents?.length ?? 0);
}

function duplicateKey(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error
    && (error as { code?: unknown }).code === 11000;
}

/** Persist immutable encrypted evidence before any first-call-wins provider request can occur. */
export async function createGooglePlayRefundReviewIntent(
  input: GooglePlayRefundReviewSubmission,
  now = new Date(),
  eventCollection: Collection<GooglePlayRtdnEventDocument> = googlePlayRtdnEvents(),
  reviewCollection: Collection<GooglePlayRefundReviewDocument> = googlePlayRefundReviews(),
  encryptionSecret = config.purchaseTokenEncryptionSecret,
): Promise<{ review: GooglePlayRefundReviewDocument; replayed: boolean }> {
  exactNow(now);
  const canonical = evidenceJson(input.evidence);
  const requestSha256 = createHash("sha256").update(canonical, "utf8").digest("hex");
  const byOperation = await reviewCollection.findOne({ operationId: input.operationId });
  if (byOperation) {
    validatedGooglePlayRefundReview(byOperation, now);
    if (!sameIntent(byOperation, input, requestSha256)) {
      throw new GooglePlayRefundReviewInputError("Idempotency-Key was already used for another refund review.", 409);
    }
    return { review: byOperation, replayed: true };
  }
  const event = await eventCollection.findOne({ _id: input.eventId });
  if (!event) throw new GooglePlayRefundReviewInputError("Pending refund review was not found.", 404);
  validatedGooglePlayRtdnEvent(event, now);
  if (event.kind !== "pending-refund-review"
    || event.status !== "manual-review"
    || event.disposition !== "manual-review-required"
    || !event.orderId) {
    throw new GooglePlayRefundReviewInputError("Pending refund review is no longer open.", 409);
  }
  const existing = await reviewCollection.findOne({ _id: input.eventId });
  if (existing) {
    validatedGooglePlayRefundReview(existing, now);
    if (!sameIntent(existing, input, requestSha256)) {
      throw new GooglePlayRefundReviewInputError("Pending refund review already has another submission.", 409);
    }
    return { review: existing, replayed: true };
  }
  const review: GooglePlayRefundReviewDocument = {
    _id: event._id,
    operationId: input.operationId,
    actor: input.actor,
    packageName: event.packageName,
    orderId: event.orderId,
    requestSha256,
    encryptedRequest: encryptPurchaseToken(
      canonical,
      requestAad(event._id, requestSha256),
      encryptionSecret,
    ),
    refundPreference: input.evidence.refundPreference,
    sampleContentProvided: input.evidence.sampleContentProvided,
    consumptionPercentageMilliunits: input.evidence.consumptionPercentageMilliunits ?? null,
    usageEventCount: input.evidence.consumptionUsageEvents?.length ?? 0,
    retentionDays: event.retentionDays,
    status: "pending",
    attempts: 0,
    lastErrorCode: null,
    createdAt: now,
    nextAttemptAt: now,
    submittedAt: null,
    expiresAt: null,
  };
  validatedGooglePlayRefundReview(review, now);
  try {
    await reviewCollection.insertOne(review);
    return { review, replayed: false };
  } catch (error) {
    if (!duplicateKey(error)) throw error;
    const winner = await reviewCollection.findOne({ $or: [{ _id: input.eventId }, { operationId: input.operationId }] });
    if (winner) validatedGooglePlayRefundReview(winner, now);
    if (winner && sameIntent(winner, input, requestSha256)) return { review: winner, replayed: true };
    throw new GooglePlayRefundReviewInputError("Pending refund review already has another submission.", 409);
  }
}

/** Decrypt only after both complete ledgers cross-bind event, order, package, and retention. */
export function googlePlayRefundReviewProviderRequest(
  review: GooglePlayRefundReviewDocument,
  event: GooglePlayRtdnEventDocument,
  secret = config.purchaseTokenEncryptionSecret,
): GooglePlayRefundReviewProviderRequest {
  validatedGooglePlayRefundReview(review);
  validatedGooglePlayRtdnEvent(event);
  if (event._id !== review._id
    || event.kind !== "pending-refund-review"
    || event.packageName !== review.packageName
    || event.orderId !== review.orderId
    || event.retentionDays !== review.retentionDays
    || !event.encryptedPendingRefundToken) {
    throw new Error("Google Play refund-review ledgers do not agree.");
  }
  const canonical = decryptPurchaseToken(
    review.encryptedRequest,
    requestAad(review._id, review.requestSha256),
    secret,
  );
  if (createHash("sha256").update(canonical, "utf8").digest("hex") !== review.requestSha256) {
    throw new Error("Google Play refund-review evidence digest does not agree.");
  }
  let decoded: unknown;
  try {
    decoded = JSON.parse(canonical) as unknown;
  } catch {
    throw new Error("Google Play refund-review evidence is invalid.");
  }
  const evidence = normalizeEvidenceRecord(decoded, review.createdAt);
  if (evidenceJson(evidence) !== canonical
    || evidence.refundPreference !== review.refundPreference
    || evidence.sampleContentProvided !== review.sampleContentProvided
    || (evidence.consumptionPercentageMilliunits ?? null) !== review.consumptionPercentageMilliunits
    || (evidence.consumptionUsageEvents?.length ?? 0) !== review.usageEventCount) {
    throw new Error("Google Play refund-review evidence does not match its audit fields.");
  }
  const pendingRefundToken = decryptPurchaseToken(
    event.encryptedPendingRefundToken,
    `google-play-rtdn:${event._id}`,
    secret,
  );
  boundedExactText(pendingRefundToken, "Pending refund token", 4_096);
  return { pendingRefundToken, ...evidence };
}

export interface GooglePlayRefundReviewSubmitter {
  submit(packageName: string, orderId: string, request: GooglePlayRefundReviewProviderRequest): Promise<void>;
}

export class GooglePlayRefundReviewApiClient implements GooglePlayRefundReviewSubmitter {
  private readonly auth = new GoogleAuth({ scopes: [androidPublisherScope] });

  async submit(
    packageNameValue: string,
    orderIdValue: string,
    request: GooglePlayRefundReviewProviderRequest,
  ): Promise<void> {
    const client = await this.auth.getClient();
    await client.request({
      method: "POST",
      url: `${publisherRoot}/${encodeURIComponent(packageNameValue)}/orders/${encodeURIComponent(orderIdValue)}:reviewrefund`,
      headers: outboundRequestHeaders(),
      data: request,
    });
  }
}

function exactReviewFilter(review: GooglePlayRefundReviewDocument): Filter<GooglePlayRefundReviewDocument> {
  // The provider decision is irreversible. Match the complete validated snapshot so a concurrent
  // repair or unexpected mutation of any audit, evidence, cipher, or lifecycle field cannot be
  // overwritten after Google has accepted the request.
  return { ...review };
}

function exactEventFilter(event: GooglePlayRtdnEventDocument): Filter<GooglePlayRtdnEventDocument> {
  return { ...event };
}

function sameCiphertext(
  left: GooglePlayRefundReviewDocument["encryptedRequest"],
  right: GooglePlayRefundReviewDocument["encryptedRequest"],
): boolean {
  return left.version === right.version
    && left.iv === right.iv
    && left.authTag === right.authTag
    && left.ciphertext === right.ciphertext;
}

function sameImmutableReview(
  left: GooglePlayRefundReviewDocument,
  right: GooglePlayRefundReviewDocument,
): boolean {
  return left._id === right._id
    && left.operationId === right.operationId
    && left.actor === right.actor
    && left.packageName === right.packageName
    && left.orderId === right.orderId
    && left.requestSha256 === right.requestSha256
    && sameCiphertext(left.encryptedRequest, right.encryptedRequest)
    && left.refundPreference === right.refundPreference
    && left.sampleContentProvided === right.sampleContentProvided
    && left.consumptionPercentageMilliunits === right.consumptionPercentageMilliunits
    && left.usageEventCount === right.usageEventCount
    && left.retentionDays === right.retentionDays
    && left.attempts === right.attempts
    && left.createdAt.getTime() === right.createdAt.getTime();
}

function sameImmutableEvent(
  left: GooglePlayRtdnEventDocument,
  right: GooglePlayRtdnEventDocument,
): boolean {
  const leftCipher = left.encryptedPendingRefundToken;
  const rightCipher = right.encryptedPendingRefundToken;
  const cipherMatches = leftCipher !== null && rightCipher !== null
    && sameCiphertext(leftCipher, rightCipher);
  return left._id === right._id
    && left.payloadSha256 === right.payloadSha256
    && left.subscription === right.subscription
    && left.packageName === right.packageName
    && left.kind === right.kind
    && left.eventTime.getTime() === right.eventTime.getTime()
    && left.receivedAt.getTime() === right.receivedAt.getTime()
    && left.retentionDays === right.retentionDays
    && left.attempts === right.attempts
    && left.receiptId === right.receiptId
    && left.productId === right.productId
    && left.notificationType === right.notificationType
    && left.orderId === right.orderId
    && left.productType === right.productType
    && left.refundType === right.refundType
    && left.refundReason === right.refundReason
    && cipherMatches;
}

function submittedReview(
  review: GooglePlayRefundReviewDocument,
  now: Date,
): GooglePlayRefundReviewDocument {
  return validatedGooglePlayRefundReview({
    ...review,
    status: "submitted",
    lastErrorCode: null,
    nextAttemptAt: null,
    submittedAt: now,
    expiresAt: new Date(now.getTime() + review.retentionDays * 86_400_000),
  }, now);
}

function submittedEvent(event: GooglePlayRtdnEventDocument, now: Date): GooglePlayRtdnEventDocument {
  return validatedGooglePlayRtdnEvent({
    ...event,
    status: "completed",
    nextAttemptAt: null,
    completedAt: now,
    expiresAt: new Date(now.getTime() + event.retentionDays * 86_400_000),
    disposition: "refund-review-submitted",
  }, now);
}

function retriedReview(review: GooglePlayRefundReviewDocument, now: Date): GooglePlayRefundReviewDocument {
  const attempts = Math.min(1_000_000, review.attempts + 1);
  const delaySeconds = Math.min(3_600, 60 * (2 ** Math.min(6, review.attempts)));
  return validatedGooglePlayRefundReview({
    ...review,
    attempts,
    lastErrorCode: "provider",
    nextAttemptAt: new Date(now.getTime() + delaySeconds * 1_000),
  }, now);
}

async function commitSubmittedReview(
  review: GooglePlayRefundReviewDocument,
  event: GooglePlayRtdnEventDocument,
  now: Date,
): Promise<void> {
  const nextReview = submittedReview(review, now);
  const nextEvent = submittedEvent(event, now);
  await withMongoTransaction(async (session: ClientSession) => {
    const liveReview = await googlePlayRefundReviews().findOne({ _id: review._id }, { session });
    const liveEvent = await googlePlayRtdnEvents().findOne({ _id: event._id }, { session });
    if (!liveReview || !liveEvent) throw new Error("Google Play refund-review authority disappeared.");
    validatedGooglePlayRefundReview(liveReview, now);
    validatedGooglePlayRtdnEvent(liveEvent, now);
    if (liveReview.status === "submitted"
      && sameImmutableReview(liveReview, review)
      && liveEvent.status === "completed"
      && liveEvent.disposition === "refund-review-submitted"
      && sameImmutableEvent(liveEvent, event)) return;
    if (liveReview.status !== "pending"
      || liveReview.requestSha256 !== review.requestSha256
      || liveReview.attempts !== review.attempts
      || liveEvent.status !== "manual-review"
      || liveEvent.disposition !== "manual-review-required") {
      throw new Error("Concurrent Google Play refund-review transition conflicts with provider evidence.");
    }
    const reviewResult = await googlePlayRefundReviews().replaceOne(
      exactReviewFilter(review),
      nextReview,
      { session },
    );
    const eventResult = await googlePlayRtdnEvents().replaceOne(
      exactEventFilter(event),
      nextEvent,
      { session },
    );
    if (reviewResult.modifiedCount !== 1 || eventResult.modifiedCount !== 1) {
      throw new Error("Google Play refund-review terminal audit could not be committed.");
    }
  });
}

/** Submit immutable outbox rows sequentially under one renewable cluster lease. */
export async function runGooglePlayRefundReviewSweep(
  submitter: GooglePlayRefundReviewSubmitter = new GooglePlayRefundReviewApiClient(),
  nowSeconds = unixNow(),
): Promise<{ submitted: number; retried: number; skipped: boolean }> {
  if (!APPLICATION.rtdnEnabled) return { submitted: 0, retried: 0, skipped: true };
  if (!Number.isSafeInteger(nowSeconds) || nowSeconds < 0) throw new Error("Refund-review worker time is invalid.");
  const now = new Date(nowSeconds * 1_000);
  exactNow(now);
  const interval = googlePlayRtdnSchedulerIntervalSeconds();
  const leased = await withScheduledJobLease(workerJobId, Math.max(300_000, interval * 2_000), async (lease) => {
    await lease.assertOwned();
    const reviews = await googlePlayRefundReviews().find({
      $or: [
        { status: "pending", nextAttemptAt: { $lte: now } },
        { status: "pending", nextAttemptAt: { $exists: false } },
        { status: "pending", nextAttemptAt: { $not: { $type: "date" } } },
        { status: { $nin: ["pending", "submitted"] } },
      ],
    }).sort({ nextAttemptAt: 1, _id: 1 }).limit(googlePlayRtdnBatchSize()).toArray();
    reviews.forEach((review) => validatedGooglePlayRefundReview(review, now));
    const events = reviews.length === 0 ? [] : await googlePlayRtdnEvents().find({
      _id: { $in: reviews.map((review) => review._id) },
    }).toArray();
    const eventById = new Map(events.map((event) => [event._id, event]));
    const prepared = reviews.map((review) => {
      const event = eventById.get(review._id);
      if (!event) throw new Error("Google Play refund-review RTDN authority is missing.");
      validatedGooglePlayRtdnEvent(event, now);
      return { review, event, request: googlePlayRefundReviewProviderRequest(review, event) };
    });
    if (eventById.size !== reviews.length) throw new Error("Google Play refund-review RTDN selection is inconsistent.");
    let submitted = 0;
    let retried = 0;
    for (const item of prepared) {
      try {
        await submitter.submit(item.review.packageName, item.review.orderId, item.request);
      } catch (error) {
        await lease.assertOwned();
        const successor = retriedReview(item.review, now);
        const result = await googlePlayRefundReviews().replaceOne(exactReviewFilter(item.review), successor);
        if (result.modifiedCount !== 1) throw new Error("Concurrent refund-review retry could not be committed.");
        retried += 1;
        logger.errorWithEmoji("PURCHASE", "Google Play refund review remains retryable", "SCHEDULER", {
          messageId: item.review._id,
          attempts: successor.attempts,
          error: error instanceof Error ? error.message : String(error),
        });
        continue;
      }
      // Google's first accepted call wins and later identical calls return OK. Fence the local
      // transaction after the response; a crash here safely resends the same encrypted intent.
      await lease.assertOwned();
      await commitSubmittedReview(item.review, item.event, now);
      submitted += 1;
    }
    return { submitted, retried };
  });
  if (!leased.ran) return { submitted: 0, retried: 0, skipped: true };
  return { ...(leased.result ?? { submitted: 0, retried: 0 }), skipped: false };
}

export function startGooglePlayRefundReviewScheduler(): NodeJS.Timeout | null {
  if (!APPLICATION.rtdnEnabled) return null;
  const run = (): void => {
    void runGooglePlayRefundReviewSweep().then((result) => {
      if (!result.skipped && (result.submitted > 0 || result.retried > 0)) {
        logger.infoWithEmoji("PURCHASE", "Google Play refund reviews processed", "SCHEDULER", result);
      }
    }).catch((error: unknown) => {
      logger.errorWithEmoji("PURCHASE", "Google Play refund-review sweep failed", "SCHEDULER", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  };
  run();
  const timer = setInterval(run, googlePlayRtdnSchedulerIntervalSeconds() * 1_000);
  timer.unref();
  return timer;
}

interface RefundReviewCursor {
  v: 1;
  receivedAtMs: number;
  eventId: string;
}

export interface GooglePlayRefundReviewListInput {
  limit: number;
  cursor: string | null;
}

function decodeCursor(value: unknown, nowMs: number): RefundReviewCursor | null {
  if (value === undefined || value === null || value === "") return null;
  if (typeof value !== "string" || value.length > 1_024 || !/^[A-Za-z0-9_-]+$/u.test(value)) {
    throw new GooglePlayRefundReviewInputError("Refund-review cursor is invalid.");
  }
  try {
    const bytes = Buffer.from(value, "base64url");
    if (bytes.toString("base64url") !== value) throw new Error("noncanonical");
    const parsed = JSON.parse(bytes.toString("utf8")) as Record<string, unknown>;
    if (!plainRecord(parsed)
      || Object.keys(parsed).length !== 3
      || parsed.v !== 1
      || !Number.isSafeInteger(parsed.receivedAtMs)
      || (parsed.receivedAtMs as number) < 0
      || (parsed.receivedAtMs as number) > nowMs
      || typeof parsed.eventId !== "string"
      || !MESSAGE_ID.test(parsed.eventId)) throw new Error("shape");
    return parsed as unknown as RefundReviewCursor;
  } catch {
    throw new GooglePlayRefundReviewInputError("Refund-review cursor is invalid.");
  }
}

export function normalizeGooglePlayRefundReviewListInput(
  values: Record<string, unknown>,
  now = new Date(),
): GooglePlayRefundReviewListInput & { decodedCursor: RefundReviewCursor | null } {
  const nowMs = exactNow(now);
  const rawLimit = values.limit;
  const limit = rawLimit === undefined
    ? 50
    : typeof rawLimit === "string" && /^(?:[1-9]|[1-9][0-9]|100)$/u.test(rawLimit)
      ? Number(rawLimit)
      : 0;
  if (limit === 0) throw new GooglePlayRefundReviewInputError("limit must be an integer from 1 through 100.");
  return {
    limit,
    cursor: typeof values.cursor === "string" ? values.cursor : null,
    decodedCursor: decodeCursor(values.cursor, nowMs),
  };
}

function queueState(
  event: GooglePlayRtdnEventDocument,
  review: GooglePlayRefundReviewDocument | undefined,
): "manual-review" | "queued" | "submitted" {
  if (event.status === "manual-review" && !review) return "manual-review";
  if (event.status === "manual-review" && review?.status === "pending") return "queued";
  if (event.status === "completed"
    && event.disposition === "refund-review-submitted"
    && review?.status === "submitted") return "submitted";
  throw new Error("Google Play refund-review queue ledgers do not agree.");
}

export function wireGooglePlayRefundReview(
  event: GooglePlayRtdnEventDocument,
  review?: GooglePlayRefundReviewDocument,
): Record<string, unknown> {
  return {
    messageId: event._id,
    orderId: event.orderId,
    refundReason: event.refundReason,
    state: queueState(event, review),
    eventTime: event.eventTime.toISOString(),
    receivedAt: event.receivedAt.toISOString(),
    ...(review ? {
      operationId: review.operationId,
      actor: review.actor,
      refundPreference: review.refundPreference,
      sampleContentProvided: review.sampleContentProvided,
      consumptionPercentageMilliunits: review.consumptionPercentageMilliunits,
      usageEventCount: review.usageEventCount,
      attempts: review.attempts,
      lastErrorCode: review.lastErrorCode,
      createdAt: review.createdAt.toISOString(),
      ...(review.submittedAt ? { submittedAt: review.submittedAt.toISOString() } : {}),
    } : {}),
  };
}

async function joinReviews(
  events: GooglePlayRtdnEventDocument[],
  now: Date,
  reviewCollection: Collection<GooglePlayRefundReviewDocument>,
): Promise<Array<{ event: GooglePlayRtdnEventDocument; review?: GooglePlayRefundReviewDocument }>> {
  const reviews = events.length === 0 ? [] : await reviewCollection.find({
    _id: { $in: events.map((event) => event._id) },
  }).toArray();
  const byId = new Map<string, GooglePlayRefundReviewDocument>();
  for (const review of reviews) {
    validatedGooglePlayRefundReview(review, now);
    if (byId.has(review._id)) throw new Error("Duplicate Google Play refund-review authority was selected.");
    byId.set(review._id, review);
  }
  return events.map((event) => {
    validatedGooglePlayRtdnEvent(event, now);
    const review = byId.get(event._id);
    queueState(event, review);
    return { event, ...(review ? { review } : {}) };
  });
}

export async function listGooglePlayRefundReviews(
  input: GooglePlayRefundReviewListInput,
  now = new Date(),
  eventCollection: Collection<GooglePlayRtdnEventDocument> = googlePlayRtdnEvents(),
  reviewCollection: Collection<GooglePlayRefundReviewDocument> = googlePlayRefundReviews(),
): Promise<{ items: Array<{ event: GooglePlayRtdnEventDocument; review?: GooglePlayRefundReviewDocument }>; nextCursor: string | null }> {
  const normalized = normalizeGooglePlayRefundReviewListInput({ limit: String(input.limit), cursor: input.cursor }, now);
  const cursor = normalized.decodedCursor;
  const filter: Filter<GooglePlayRtdnEventDocument> = {
    kind: "pending-refund-review",
    $and: [
      { $or: [
        { status: "manual-review", disposition: "manual-review-required" },
        { status: "completed", disposition: "refund-review-submitted" },
      ] },
      ...(cursor ? [{ $or: [
        { receivedAt: { $lt: new Date(cursor.receivedAtMs) } },
        { receivedAt: new Date(cursor.receivedAtMs), _id: { $lt: cursor.eventId } },
      ] }] : []),
    ],
  };
  const events = await eventCollection.find(filter)
    .sort({ receivedAt: -1, _id: -1 })
    .limit(normalized.limit)
    .toArray();
  const items = await joinReviews(events, now, reviewCollection);
  const last = items.length === normalized.limit ? items[items.length - 1].event : undefined;
  return {
    items,
    nextCursor: last ? Buffer.from(JSON.stringify({
      v: 1,
      receivedAtMs: last.receivedAt.getTime(),
      eventId: last._id,
    } satisfies RefundReviewCursor), "utf8").toString("base64url") : null,
  };
}

export async function findGooglePlayRefundReview(
  eventIdValue: unknown,
  now = new Date(),
  eventCollection: Collection<GooglePlayRtdnEventDocument> = googlePlayRtdnEvents(),
  reviewCollection: Collection<GooglePlayRefundReviewDocument> = googlePlayRefundReviews(),
): Promise<{ event: GooglePlayRtdnEventDocument; review?: GooglePlayRefundReviewDocument } | null> {
  const eventId = normalizeGooglePlayRefundReviewEventId(eventIdValue);
  exactNow(now);
  const event = await eventCollection.findOne({ _id: eventId, kind: "pending-refund-review" });
  if (!event) return null;
  const [joined] = await joinReviews([event], now, reviewCollection);
  return joined;
}
