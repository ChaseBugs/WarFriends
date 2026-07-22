import { createHash } from "crypto";
import { TextDecoder } from "util";
import type { Collection, Filter } from "mongodb";
import { OAuth2Client } from "google-auth-library";
import { config } from "../config";
import {
  googlePlayRtdnEvents,
  type GooglePlayRtdnDisposition,
  type GooglePlayRtdnEventDocument,
} from "../db";
import logger from "../utils/logger";
import {
  googlePlayApplicationPolicy,
  googlePlayRtdnBatchSize,
  googlePlayRtdnIdentityPolicy,
  googlePlayRtdnRetentionDays,
  googlePlayRtdnSchedulerIntervalSeconds,
  type GooglePlayRtdnIdentityPolicy,
} from "./googlePlayPolicyService";
import { googlePlayPurchaseTokenReceiptId } from "./googlePlayPurchaseTokenIdentityService";
import { runGooglePlaySubscriptionRevalidationForReceipt } from "./googlePlaySubscriptionRevalidationService";
import { runGooglePlayVoidedPurchaseSweep } from "./googlePlayVoidedPurchaseService";
import { encryptPurchaseToken } from "./purchaseTokenCryptoService";
import { withScheduledJobLease } from "./scheduledJobLeaseService";
import { unixNow } from "./playerStateService";

const APPLICATION = googlePlayApplicationPolicy();
const RTDN_IDENTITY = googlePlayRtdnIdentityPolicy();
const workerJobId = "google-play-rtdn-events";
const EVENT_KEYS = new Set([
  "_id", "payloadSha256", "subscription", "packageName", "kind", "eventTime", "receivedAt",
  "retentionDays", "status", "attempts", "nextAttemptAt", "completedAt", "expiresAt", "disposition", "receiptId",
  "productId", "notificationType", "orderId", "productType", "refundType",
  "encryptedPendingRefundToken", "refundReason",
]);
const terminalRetentionMilliseconds = (days: number): number => days * 86_400_000;

export class GooglePlayRtdnValidationError extends Error {
  constructor(message = "Google Play RTDN payload is invalid.") {
    super(message);
    this.name = "GooglePlayRtdnValidationError";
  }
}

export class GooglePlayRtdnAuthenticationError extends Error {
  constructor() {
    super("Google Play RTDN authentication failed.");
    this.name = "GooglePlayRtdnAuthenticationError";
  }
}

export class GooglePlayRtdnConflictError extends Error {
  constructor() {
    super("Google Play RTDN message identity conflicts with stored authority.");
    this.name = "GooglePlayRtdnConflictError";
  }
}

function objectRecord(value: unknown, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new GooglePlayRtdnValidationError(`${label} must be an object.`);
  }
  return value as Record<string, unknown>;
}

function exactKeys(value: Record<string, unknown>, required: readonly string[], optional: readonly string[] = []): void {
  const allowed = new Set([...required, ...optional]);
  const keys = Object.keys(value);
  if (required.some((key) => !Object.prototype.hasOwnProperty.call(value, key))
    || keys.some((key) => !allowed.has(key))) {
    throw new GooglePlayRtdnValidationError("Google Play RTDN object shape is invalid.");
  }
}

function exactText(value: unknown, label: string, maximum: number): string {
  if (typeof value !== "string"
    || value.length === 0
    || value.length > maximum
    || value.trim() !== value
    || /[\u0000-\u001f\u007f]/u.test(value)) {
    throw new GooglePlayRtdnValidationError(`${label} is invalid.`);
  }
  return value;
}

function exactInteger(value: unknown, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || (value as number) < minimum || (value as number) > maximum) {
    throw new GooglePlayRtdnValidationError(`${label} is invalid.`);
  }
  return value as number;
}

function canonicalBase64(value: unknown): Buffer {
  if (typeof value !== "string"
    || value.length === 0
    || value.length > 65_536
    || value.length % 4 !== 0
    || !/^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$/u.test(value)) {
    throw new GooglePlayRtdnValidationError("Pub/Sub data is not canonical base64.");
  }
  const decoded = Buffer.from(value, "base64");
  if (decoded.length === 0 || decoded.length > 32_768 || decoded.toString("base64") !== value) {
    throw new GooglePlayRtdnValidationError("Pub/Sub data is not canonical base64.");
  }
  return decoded;
}

function eventDate(value: unknown, receivedAt: Date): Date {
  if (typeof value !== "string" || !/^(?:0|[1-9][0-9]{0,15})$/u.test(value)) {
    throw new GooglePlayRtdnValidationError("Google Play eventTimeMillis is invalid.");
  }
  const milliseconds = Number(value);
  const eventTime = new Date(milliseconds);
  if (!Number.isSafeInteger(milliseconds)
    || milliseconds < 0
    || !Number.isSafeInteger(eventTime.getTime())
    || eventTime.getTime() !== milliseconds
    || milliseconds > receivedAt.getTime()) {
    throw new GooglePlayRtdnValidationError("Google Play eventTimeMillis is invalid.");
  }
  return eventTime;
}

function versionOne(value: unknown): void {
  if (value !== "1.0") throw new GooglePlayRtdnValidationError("Google Play RTDN version is unsupported.");
}

interface ParsedNotification {
  kind: GooglePlayRtdnEventDocument["kind"];
  receiptId: string | null;
  productId: string | null;
  notificationType: number | null;
  orderId: string | null;
  productType: 1 | 2 | null;
  refundType: 1 | 2 | null;
  encryptedPendingRefundToken: GooglePlayRtdnEventDocument["encryptedPendingRefundToken"];
  refundReason: number | null;
}

function parseNotification(
  developer: Record<string, unknown>,
  messageId: string,
  encryptionSecret: string,
): ParsedNotification {
  const notificationNames = [
    "subscriptionNotification",
    "oneTimeProductNotification",
    "voidedPurchaseNotification",
    "pendingRefundReviewNotification",
    "testNotification",
  ].filter((key) => Object.prototype.hasOwnProperty.call(developer, key));
  if (notificationNames.length !== 1) {
    throw new GooglePlayRtdnValidationError("Exactly one Google Play notification kind is required.");
  }
  const name = notificationNames[0];
  exactKeys(developer, ["version", "packageName", "eventTimeMillis", name]);
  const nested = objectRecord(developer[name], name);
  const empty = {
    receiptId: null,
    productId: null,
    notificationType: null,
    orderId: null,
    productType: null,
    refundType: null,
    encryptedPendingRefundToken: null,
    refundReason: null,
  } satisfies Omit<ParsedNotification, "kind">;

  if (name === "subscriptionNotification") {
    exactKeys(nested, ["version", "notificationType", "purchaseToken"]);
    versionOne(nested.version);
    const token = exactText(nested.purchaseToken, "Subscription purchaseToken", 4_096);
    return {
      ...empty,
      kind: "subscription",
      receiptId: googlePlayPurchaseTokenReceiptId(token),
      notificationType: exactInteger(nested.notificationType, "Subscription notificationType", 1, 1_000),
    };
  }
  if (name === "oneTimeProductNotification") {
    exactKeys(nested, ["version", "notificationType", "purchaseToken", "sku"]);
    versionOne(nested.version);
    const token = exactText(nested.purchaseToken, "One-time purchaseToken", 4_096);
    return {
      ...empty,
      kind: "one-time-product",
      receiptId: googlePlayPurchaseTokenReceiptId(token),
      productId: exactText(nested.sku, "One-time product sku", 255),
      notificationType: exactInteger(nested.notificationType, "One-time notificationType", 1, 2),
    };
  }
  if (name === "voidedPurchaseNotification") {
    exactKeys(nested, ["purchaseToken", "orderId", "productType", "refundType"]);
    const token = exactText(nested.purchaseToken, "Voided purchaseToken", 4_096);
    return {
      ...empty,
      kind: "voided-purchase",
      receiptId: googlePlayPurchaseTokenReceiptId(token),
      orderId: exactText(nested.orderId, "Voided orderId", 255),
      productType: exactInteger(nested.productType, "Voided productType", 1, 2) as 1 | 2,
      refundType: exactInteger(nested.refundType, "Voided refundType", 1, 2) as 1 | 2,
    };
  }
  if (name === "pendingRefundReviewNotification") {
    exactKeys(
      nested,
      ["version", "pendingRefundToken", "orderId", "refundReason"],
      ["obfuscatedAccountId", "obfuscatedProfileId"],
    );
    versionOne(nested.version);
    const pendingToken = exactText(nested.pendingRefundToken, "Pending refund token", 4_096);
    if (nested.obfuscatedAccountId !== undefined) {
      exactText(nested.obfuscatedAccountId, "Pending refund account identity", 255);
    }
    if (nested.obfuscatedProfileId !== undefined) {
      exactText(nested.obfuscatedProfileId, "Pending refund profile identity", 255);
    }
    return {
      ...empty,
      kind: "pending-refund-review",
      orderId: exactText(nested.orderId, "Pending refund orderId", 255),
      encryptedPendingRefundToken: encryptPurchaseToken(
        pendingToken,
        `google-play-rtdn:${messageId}`,
        encryptionSecret,
      ),
      refundReason: exactInteger(nested.refundReason, "Pending refund reason", 1, 1_000),
    };
  }
  exactKeys(nested, ["version"]);
  versionOne(nested.version);
  return { ...empty, kind: "test" };
}

/** Decode and validate one exact authenticated Pub/Sub push envelope. */
export function parseGooglePlayRtdnEnvelope(
  body: unknown,
  receivedAt: Date,
  identity: GooglePlayRtdnIdentityPolicy = RTDN_IDENTITY,
  encryptionSecret = config.purchaseTokenEncryptionSecret,
): GooglePlayRtdnEventDocument {
  if (!Number.isSafeInteger(receivedAt?.getTime()) || receivedAt.getTime() < 0) {
    throw new GooglePlayRtdnValidationError("RTDN receipt time is invalid.");
  }
  const envelope = objectRecord(body, "Pub/Sub envelope");
  exactKeys(envelope, ["message", "subscription"]);
  const subscription = exactText(envelope.subscription, "Pub/Sub subscription", 512);
  if (!identity.enabled || subscription !== identity.subscription) {
    throw new GooglePlayRtdnValidationError("Pub/Sub subscription is not configured.");
  }
  const message = objectRecord(envelope.message, "Pub/Sub message");
  exactKeys(message, ["data", "messageId"], ["attributes", "publishTime", "orderingKey"]);
  const messageId = exactText(message.messageId, "Pub/Sub messageId", 20);
  if (!/^[1-9][0-9]{0,19}$/u.test(messageId)) {
    throw new GooglePlayRtdnValidationError("Pub/Sub messageId is invalid.");
  }
  if (message.attributes !== undefined) {
    const attributes = objectRecord(message.attributes, "Pub/Sub attributes");
    if (Object.keys(attributes).length > 32) throw new GooglePlayRtdnValidationError("Pub/Sub attributes are invalid.");
    for (const [key, value] of Object.entries(attributes)) {
      exactText(key, "Pub/Sub attribute name", 256);
      exactText(value, "Pub/Sub attribute value", 1_024);
    }
  }
  if (message.publishTime !== undefined) {
    const publishTime = exactText(message.publishTime, "Pub/Sub publishTime", 64);
    if (!Number.isFinite(Date.parse(publishTime))) throw new GooglePlayRtdnValidationError("Pub/Sub publishTime is invalid.");
  }
  if (message.orderingKey !== undefined) exactText(message.orderingKey, "Pub/Sub orderingKey", 1_024);

  const decoded = canonicalBase64(message.data);
  let developer: Record<string, unknown>;
  try {
    const json = new TextDecoder("utf-8", { fatal: true }).decode(decoded);
    developer = objectRecord(JSON.parse(json) as unknown, "DeveloperNotification");
  } catch (error) {
    if (error instanceof GooglePlayRtdnValidationError) throw error;
    throw new GooglePlayRtdnValidationError("DeveloperNotification is not valid UTF-8 JSON.");
  }
  versionOne(developer.version);
  if (developer.packageName !== APPLICATION.packageName) {
    throw new GooglePlayRtdnValidationError("Google Play packageName does not match this application.");
  }
  const eventTime = eventDate(developer.eventTimeMillis, receivedAt);
  const parsed = parseNotification(developer, messageId, encryptionSecret);
  const directDisposition: GooglePlayRtdnDisposition | null = parsed.kind === "one-time-product"
    ? "one-time-client-verification"
    : parsed.kind === "test"
      ? "test"
      : parsed.kind === "pending-refund-review"
        ? "manual-review-required"
        : null;
  const status = parsed.kind === "pending-refund-review"
    ? "manual-review" as const
    : directDisposition
      ? "completed" as const
      : "pending" as const;
  const completedAt = status === "completed" ? receivedAt : null;
  const retentionDays = googlePlayRtdnRetentionDays();
  const event: GooglePlayRtdnEventDocument = {
    _id: messageId,
    payloadSha256: createHash("sha256").update(subscription, "utf8").update("\0").update(decoded).digest("hex"),
    subscription,
    packageName: APPLICATION.packageName,
    eventTime,
    receivedAt,
    retentionDays,
    status,
    attempts: 0,
    nextAttemptAt: status === "pending" ? receivedAt : null,
    completedAt,
    expiresAt: completedAt ? new Date(completedAt.getTime() + terminalRetentionMilliseconds(retentionDays)) : null,
    disposition: directDisposition,
    ...parsed,
  };
  return validatedGooglePlayRtdnEvent(event, receivedAt, identity);
}

function validDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function validCiphertext(value: GooglePlayRtdnEventDocument["encryptedPendingRefundToken"]): boolean {
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

/** Validate every durable field before ingestion replay, worker selection, or transition. */
export function validatedGooglePlayRtdnEvent(
  event: GooglePlayRtdnEventDocument,
  now?: Date,
  identity: GooglePlayRtdnIdentityPolicy = RTDN_IDENTITY,
): GooglePlayRtdnEventDocument {
  const raw = event as unknown as Record<string, unknown>;
  const keys = event && typeof event === "object" && !Array.isArray(event) ? Object.keys(raw) : [];
  const receiptIdValid = event?.receiptId === null || /^[0-9a-f]{64}$/u.test(event.receiptId);
  const productIdValid = event?.productId === null || (typeof event.productId === "string"
    && event.productId.length > 0 && event.productId.length <= 255 && event.productId.trim() === event.productId);
  const orderIdValid = event?.orderId === null || (typeof event.orderId === "string"
    && event.orderId.length > 0 && event.orderId.length <= 255 && event.orderId.trim() === event.orderId);
  if (keys.length !== EVENT_KEYS.size
    || keys.some((key) => !EVENT_KEYS.has(key))
    || !/^[1-9][0-9]{0,19}$/u.test(event?._id)
    || !/^[0-9a-f]{64}$/u.test(event?.payloadSha256)
    || event?.subscription !== identity.subscription
    || event?.packageName !== APPLICATION.packageName
    || !["subscription", "one-time-product", "voided-purchase", "pending-refund-review", "test"].includes(event?.kind)
    || !validDate(event?.eventTime)
    || !validDate(event?.receivedAt)
    || event.eventTime.getTime() > event.receivedAt.getTime()
    || (now !== undefined && (!validDate(now) || event.receivedAt.getTime() > now.getTime()))
    || !Number.isSafeInteger(event?.retentionDays)
    || event.retentionDays < 30
    || event.retentionDays > 365
    || !["pending", "completed", "manual-review"].includes(event?.status)
    || !Number.isSafeInteger(event?.attempts)
    || event.attempts < 0
    || event.attempts > 1_000_000
    || !receiptIdValid
    || !productIdValid
    || !orderIdValid
    || (event.notificationType !== null
      && (!Number.isSafeInteger(event.notificationType) || event.notificationType < 1 || event.notificationType > 1_000))
    || (event.productType !== null && event.productType !== 1 && event.productType !== 2)
    || (event.refundType !== null && event.refundType !== 1 && event.refundType !== 2)
    || (event.refundReason !== null
      && (!Number.isSafeInteger(event.refundReason) || event.refundReason < 1 || event.refundReason > 1_000))) {
    throw new Error("Stored Google Play RTDN event authority is invalid.");
  }

  const pendingShape = event.status === "pending"
    && (event.kind === "subscription" || event.kind === "voided-purchase")
    && validDate(event.nextAttemptAt)
    && event.completedAt === null
    && event.expiresAt === null
    && event.disposition === null;
  const completedShape = event.status === "completed"
    && validDate(event.completedAt)
    && validDate(event.expiresAt)
    && event.nextAttemptAt === null
    && event.completedAt.getTime() >= event.receivedAt.getTime()
    && event.expiresAt.getTime() - event.completedAt.getTime() === terminalRetentionMilliseconds(event.retentionDays)
    && event.disposition !== null;
  const reviewShape = event.status === "manual-review"
    && event.kind === "pending-refund-review"
    && event.nextAttemptAt === null
    && event.completedAt === null
    && event.expiresAt === null
    && event.disposition === "manual-review-required";
  if (!pendingShape && !completedShape && !reviewShape) {
    throw new Error("Stored Google Play RTDN event lifecycle is invalid.");
  }

  const subscriptionShape = event.kind === "subscription"
    && event.receiptId !== null && event.productId === null && event.notificationType !== null
    && event.orderId === null && event.productType === null && event.refundType === null
    && event.encryptedPendingRefundToken === null && event.refundReason === null
    && (event.disposition === null
      || event.disposition === "subscription-revalidated"
      || event.disposition === "subscription-unmatched");
  const oneTimeShape = event.kind === "one-time-product"
    && event.receiptId !== null && event.productId !== null
    && (event.notificationType === 1 || event.notificationType === 2)
    && event.orderId === null && event.productType === null && event.refundType === null
    && event.encryptedPendingRefundToken === null && event.refundReason === null
    && event.disposition === "one-time-client-verification";
  const voidedShape = event.kind === "voided-purchase"
    && event.receiptId !== null && event.productId === null && event.notificationType === null
    && event.orderId !== null && event.productType !== null && event.refundType !== null
    && event.encryptedPendingRefundToken === null && event.refundReason === null
    && (event.disposition === null
      || event.disposition === "voided-sweep-completed"
      || event.disposition === "subscription-revalidated"
      || event.disposition === "subscription-unmatched");
  const reviewNotificationShape = event.kind === "pending-refund-review"
    && event.receiptId === null && event.productId === null && event.notificationType === null
    && event.orderId !== null && event.productType === null && event.refundType === null
    && validCiphertext(event.encryptedPendingRefundToken) && event.refundReason !== null
    && ((event.status === "manual-review" && event.disposition === "manual-review-required")
      || (event.status === "completed" && event.disposition === "refund-review-submitted"));
  const testShape = event.kind === "test"
    && event.receiptId === null && event.productId === null && event.notificationType === null
    && event.orderId === null && event.productType === null && event.refundType === null
    && event.encryptedPendingRefundToken === null && event.refundReason === null
    && event.disposition === "test";
  if (!subscriptionShape && !oneTimeShape && !voidedShape && !reviewNotificationShape && !testShape) {
    throw new Error("Stored Google Play RTDN event payload is invalid.");
  }
  return event;
}

export interface GooglePlayRtdnOidcClaims {
  iss?: string;
  aud?: string | string[];
  email?: string;
  email_verified?: boolean;
}

export type GooglePlayRtdnOidcVerifier = (
  jwt: string,
  audience: string,
) => Promise<GooglePlayRtdnOidcClaims | undefined>;

const oidcClient = new OAuth2Client();
const defaultOidcVerifier: GooglePlayRtdnOidcVerifier = async (jwt, audience) => {
  const ticket = await oidcClient.verifyIdToken({ idToken: jwt, audience });
  return ticket.getPayload();
};

/** Verify Google's signature/audience, then bind the token to the configured push service account. */
export async function authenticateGooglePlayRtdn(
  authorization: unknown,
  identity: GooglePlayRtdnIdentityPolicy = RTDN_IDENTITY,
  verify: GooglePlayRtdnOidcVerifier = defaultOidcVerifier,
): Promise<void> {
  if (!identity.enabled || typeof authorization !== "string" || authorization.length > 8_192) {
    throw new GooglePlayRtdnAuthenticationError();
  }
  const match = /^Bearer ([A-Za-z0-9_-]+\.[A-Za-z0-9_-]+\.[A-Za-z0-9_-]+)$/u.exec(authorization);
  if (!match) throw new GooglePlayRtdnAuthenticationError();
  try {
    const claims = await verify(match[1], identity.audience);
    if (!claims
      || (claims.iss !== "accounts.google.com" && claims.iss !== "https://accounts.google.com")
      || claims.aud !== identity.audience
      || claims.email !== identity.serviceAccountEmail
      || claims.email_verified !== true) {
      throw new GooglePlayRtdnAuthenticationError();
    }
  } catch {
    throw new GooglePlayRtdnAuthenticationError();
  }
}

function duplicateKey(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error
    && (error as { code?: unknown }).code === 11000;
}

/** Insert before acknowledging Pub/Sub; an exact message-ID replay performs no provider work. */
export async function ingestGooglePlayRtdn(
  event: GooglePlayRtdnEventDocument,
  collection: Collection<GooglePlayRtdnEventDocument> = googlePlayRtdnEvents(),
  identity: GooglePlayRtdnIdentityPolicy = RTDN_IDENTITY,
): Promise<{ replayed: boolean; status: GooglePlayRtdnEventDocument["status"] }> {
  validatedGooglePlayRtdnEvent(event, event.receivedAt, identity);
  try {
    await collection.insertOne(event);
    return { replayed: false, status: event.status };
  } catch (error) {
    if (!duplicateKey(error)) throw error;
    const existing = await collection.findOne({ _id: event._id });
    if (!existing) throw error;
    validatedGooglePlayRtdnEvent(existing, undefined, identity);
    if (existing.payloadSha256 !== event.payloadSha256
      || existing.subscription !== event.subscription
      || existing.packageName !== event.packageName) {
      throw new GooglePlayRtdnConflictError();
    }
    return { replayed: true, status: existing.status };
  }
}

function exactEventFilter(event: GooglePlayRtdnEventDocument): Filter<GooglePlayRtdnEventDocument> {
  return {
    _id: event._id,
    payloadSha256: event.payloadSha256,
    status: event.status,
    attempts: event.attempts,
    nextAttemptAt: event.nextAttemptAt,
  };
}

function completedEvent(
  event: GooglePlayRtdnEventDocument,
  disposition: GooglePlayRtdnDisposition,
  now: Date,
): GooglePlayRtdnEventDocument {
  return validatedGooglePlayRtdnEvent({
    ...event,
    status: "completed",
    nextAttemptAt: null,
    completedAt: now,
    expiresAt: new Date(now.getTime() + terminalRetentionMilliseconds(event.retentionDays)),
    disposition,
  }, now);
}

function retriedEvent(event: GooglePlayRtdnEventDocument, now: Date): GooglePlayRtdnEventDocument {
  const attempts = Math.min(1_000_000, event.attempts + 1);
  const delaySeconds = Math.min(3_600, 60 * (2 ** Math.min(6, event.attempts)));
  return validatedGooglePlayRtdnEvent({
    ...event,
    attempts,
    nextAttemptAt: new Date(now.getTime() + delaySeconds * 1_000),
  }, now);
}

async function processPendingEvent(
  event: GooglePlayRtdnEventDocument,
  nowSeconds: number,
): Promise<GooglePlayRtdnDisposition> {
  if (event.kind === "subscription" || (event.kind === "voided-purchase" && event.productType === 1)) {
    const result = await runGooglePlaySubscriptionRevalidationForReceipt(event.receiptId!, undefined, nowSeconds);
    if (result.skipped || result.failed) throw new Error("Subscription revalidation remains retryable.");
    return result.found && result.checked ? "subscription-revalidated" : "subscription-unmatched";
  }
  if (event.kind === "voided-purchase" && event.productType === 2) {
    const result = await runGooglePlayVoidedPurchaseSweep(undefined, nowSeconds);
    if (result.skipped) throw new Error("Voided-purchase reconciliation lease is busy.");
    return "voided-sweep-completed";
  }
  throw new Error("Stored RTDN pending kind has no safe provider workflow.");
}

/** Drain authenticated events under a cluster lease and fence every terminal/retry write. */
export async function runGooglePlayRtdnSweep(
  nowSeconds = unixNow(),
): Promise<{ completed: number; retried: number; skipped: boolean }> {
  if (!APPLICATION.rtdnEnabled) return { completed: 0, retried: 0, skipped: true };
  if (!Number.isSafeInteger(nowSeconds) || nowSeconds < 0) throw new Error("RTDN worker time is invalid.");
  const now = new Date(nowSeconds * 1_000);
  if (!validDate(now)) throw new Error("RTDN worker time is invalid.");
  const interval = googlePlayRtdnSchedulerIntervalSeconds();
  const leased = await withScheduledJobLease(workerJobId, Math.max(300_000, interval * 2_000), async (lease) => {
    await lease.assertOwned();
    const events = await googlePlayRtdnEvents().find({
      $or: [
        { status: "pending", nextAttemptAt: { $lte: now } },
        { status: "pending", nextAttemptAt: { $exists: false } },
        { status: "pending", nextAttemptAt: { $not: { $type: "date" } } },
        { status: { $nin: ["pending", "completed", "manual-review"] } },
      ],
    }).sort({ nextAttemptAt: 1, _id: 1 }).limit(googlePlayRtdnBatchSize()).toArray();
    // One corrupt row aborts before any provider call. It must be repaired, not skipped while a
    // believable neighboring event changes paid entitlement.
    events.forEach((event) => validatedGooglePlayRtdnEvent(event, now));
    let completed = 0;
    let retried = 0;
    for (const event of events) {
      try {
        const disposition = await processPendingEvent(event, nowSeconds);
        await lease.assertOwned();
        const successor = completedEvent(event, disposition, now);
        const result = await googlePlayRtdnEvents().replaceOne(exactEventFilter(event), successor);
        if (result.modifiedCount !== 1) throw new Error("Concurrent RTDN completion could not be committed.");
        completed += 1;
      } catch (error) {
        await lease.assertOwned();
        const successor = retriedEvent(event, now);
        const result = await googlePlayRtdnEvents().replaceOne(exactEventFilter(event), successor);
        if (result.modifiedCount !== 1) throw new Error("Concurrent RTDN retry could not be committed.");
        retried += 1;
        logger.errorWithEmoji("PURCHASE", "Google Play RTDN event remains retryable", "SCHEDULER", {
          messageId: event._id,
          kind: event.kind,
          attempts: successor.attempts,
          error: error instanceof Error ? error.message : String(error),
        });
      }
    }
    return { completed, retried };
  });
  if (!leased.ran) return { completed: 0, retried: 0, skipped: true };
  return { ...(leased.result ?? { completed: 0, retried: 0 }), skipped: false };
}

export function startGooglePlayRtdnScheduler(): NodeJS.Timeout | null {
  if (!APPLICATION.rtdnEnabled) return null;
  const run = (): void => {
    void runGooglePlayRtdnSweep().then((result) => {
      if (!result.skipped && (result.completed > 0 || result.retried > 0)) {
        logger.infoWithEmoji("PURCHASE", "Google Play RTDN events processed", "SCHEDULER", result);
      }
    }).catch((error: unknown) => {
      logger.errorWithEmoji("PURCHASE", "Google Play RTDN sweep failed", "SCHEDULER", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  };
  run();
  const timer = setInterval(run, googlePlayRtdnSchedulerIntervalSeconds() * 1_000);
  timer.unref();
  return timer;
}
