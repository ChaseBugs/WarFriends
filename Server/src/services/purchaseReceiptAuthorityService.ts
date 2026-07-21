import { config } from "../config";
import type { PurchaseReceiptDocument, PurchaseReversibleGrant } from "../db";
import {
  googlePlayStoreProductId,
  inAppEntitlement,
  type InAppEntitlement,
  type PackEntitlement,
} from "./inAppCatalogService";

const RECEIPT_KEYS = new Set([
  "_id", "platform", "playerId", "productId", "storeProductId", "orderId", "kind",
  "purchasedAt", "verifiedAt", "response", "reversibleGrant", "encryptedPurchaseToken",
  "subscriptionState", "subscriptionExpiresAt", "revalidateAfter", "lastRevalidatedAt",
  "revalidationFailures", "revokedAt", "voidedSource", "voidedReason", "voidedOrderId",
]);
const GRANT_KEYS = new Set([
  "gold", "warBucks", "vipSeconds", "weapons", "visuals", "extraCardSlot", "introducedExtraCardSlot",
]);
export const TERMINAL_PURCHASE_SUBSCRIPTION_STATES = [
  "SUBSCRIPTION_STATE_EXPIRED",
  "SUBSCRIPTION_STATE_PENDING_PURCHASE_CANCELED",
] as const;
const SUBSCRIPTION_STATES = new Set([
  "SUBSCRIPTION_STATE_UNSPECIFIED",
  "SUBSCRIPTION_STATE_PENDING",
  "SUBSCRIPTION_STATE_ACTIVE",
  "SUBSCRIPTION_STATE_PAUSED",
  "SUBSCRIPTION_STATE_IN_GRACE_PERIOD",
  "SUBSCRIPTION_STATE_ON_HOLD",
  "SUBSCRIPTION_STATE_CANCELED",
  "SUBSCRIPTION_STATE_EXPIRED",
  "SUBSCRIPTION_STATE_PENDING_PURCHASE_CANCELED",
]);
const TERMINAL_SUBSCRIPTION_STATES = new Set<string>(TERMINAL_PURCHASE_SUBSCRIPTION_STATES);
const MAX_REVALIDATION_FAILURES = 1_000_000;

function fail(): never {
  throw new Error("Stored purchase receipt is invalid.");
}

function exactKeys(value: object, allowed: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => allowed.has(key));
}

function boundedString(value: unknown, maximum: number): value is string {
  return typeof value === "string"
    && value.length > 0
    && value.length <= maximum
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() > 0;
}

function canonicalBase64(value: unknown, expectedBytes?: number): boolean {
  if (typeof value !== "string" || value.length === 0 || value.length > 16_384) return false;
  try {
    const decoded = Buffer.from(value, "base64");
    return decoded.length > 0
      && (expectedBytes === undefined || decoded.length === expectedBytes)
      && decoded.toString("base64") === value;
  } catch {
    return false;
  }
}

function validResponse(
  response: unknown,
  entitlement: InAppEntitlement,
): response is PurchaseReceiptDocument["response"] {
  if (!response || typeof response !== "object" || Array.isArray(response)) return false;
  const record = response as Record<string, unknown>;
  if (entitlement.kind === "currency") {
    const expected = {
      Id: entitlement.productId,
      ...(entitlement.gold > 0 ? { Gold: entitlement.gold } : {}),
      ...(entitlement.warBucks > 0 ? { Warbucks: entitlement.warBucks } : {}),
    };
    return Object.keys(record).length === Object.keys(expected).length
      && Object.entries(expected).every(([key, value]) => record[key] === value);
  }
  if (entitlement.kind === "pack") {
    return Object.keys(record).length === 1 && record.PackId === entitlement.productId;
  }
  const bought = record.SubscriptionBought;
  const allowed = bought === true
    ? new Set(["Id", "SubscriptionBought", "ExpireTime", "dogTagTimerLock"])
    : new Set(["Id", "SubscriptionBought", "SubscriptionNoChange", "ExpireTime", "dogTagTimerLock"]);
  return exactKeys(record, allowed)
    && record.Id === entitlement.productId
    && (bought === true || (bought === false && record.SubscriptionNoChange === true))
    && Number.isSafeInteger(record.ExpireTime)
    && Number.isSafeInteger(record.dogTagTimerLock)
    && (record.ExpireTime as number) > 0
    && (record.dogTagTimerLock as number) >= 0
    && (record.dogTagTimerLock as number) <= (record.ExpireTime as number);
}

function validIntroducedRows(
  grant: PurchaseReversibleGrant,
  entitlement: PackEntitlement,
): boolean {
  return grant.weapons.length === entitlement.weapons.length
    && grant.weapons.every((row, index) => (
      row
      && typeof row === "object"
      && !Array.isArray(row)
      && exactKeys(row, new Set(["name", "introduced"]))
      && row.name === entitlement.weapons[index]
      && typeof row.introduced === "boolean"
    ))
    && grant.visuals.length === entitlement.visuals.length
    && grant.visuals.every((row, index) => (
      row
      && typeof row === "object"
      && !Array.isArray(row)
      && exactKeys(row, new Set(["name", "durationSeconds", "introduced"]))
      && row.name === entitlement.visuals[index]?.name
      && row.durationSeconds === entitlement.visuals[index]?.durationSeconds
      && typeof row.introduced === "boolean"
    ));
}

function validReversibleGrant(value: unknown, entitlement: InAppEntitlement): boolean {
  if (!value || typeof value !== "object" || Array.isArray(value) || !exactKeys(value, GRANT_KEYS)) return false;
  const grant = value as PurchaseReversibleGrant;
  if (!Number.isSafeInteger(grant.gold) || grant.gold < 0
    || !Number.isSafeInteger(grant.warBucks) || grant.warBucks < 0
    || !Number.isSafeInteger(grant.vipSeconds) || grant.vipSeconds < 0
    || !Array.isArray(grant.weapons) || !Array.isArray(grant.visuals)
    || typeof grant.extraCardSlot !== "boolean"
    || typeof grant.introducedExtraCardSlot !== "boolean"
    || (grant.introducedExtraCardSlot && !grant.extraCardSlot)) return false;
  if (entitlement.kind === "subscription") return false;
  if (entitlement.kind === "currency") {
    return grant.gold === entitlement.gold
      && grant.warBucks === entitlement.warBucks
      && grant.vipSeconds === 0
      && grant.weapons.length === 0
      && grant.visuals.length === 0
      && !grant.extraCardSlot
      && !grant.introducedExtraCardSlot;
  }
  return grant.gold === entitlement.gold
    && grant.warBucks === entitlement.warBucks
    && grant.vipSeconds === entitlement.vipSeconds
    && grant.extraCardSlot === entitlement.extraCardSlot
    && (!grant.introducedExtraCardSlot || entitlement.extraCardSlot)
    && validIntroducedRows(grant, entitlement);
}

/**
 * Validate the complete durable Google Play receipt before replay or reconciliation.
 *
 * Store verification happened before this row was written, but later reads no longer have the
 * plaintext token or original provider response. The immutable catalog/product/response/grant tuple
 * and the kind-specific lifecycle therefore become the only durable authority. Reject the whole row
 * rather than treating malformed fields as absent, expired, retryable, or already delivered.
 */
export function validatedPurchaseReceipt(receipt: PurchaseReceiptDocument): PurchaseReceiptDocument {
  if (!receipt || typeof receipt !== "object" || !exactKeys(receipt, RECEIPT_KEYS)) fail();
  const entitlement = typeof receipt.productId === "string" ? inAppEntitlement(receipt.productId) : null;
  if (!entitlement
    || !/^[0-9a-f]{64}$/u.test(receipt._id)
    || receipt.platform !== "google-play"
    || !boundedString(receipt.playerId, 256)
    || receipt.kind !== entitlement.kind
    || receipt.storeProductId !== googlePlayStoreProductId(config.googlePlayPackageName, entitlement.productId)
    || !boundedString(receipt.orderId, 512)
    || !safeDate(receipt.purchasedAt)
    || !safeDate(receipt.verifiedAt)
    || receipt.purchasedAt.getTime() > receipt.verifiedAt.getTime()
    || !validResponse(receipt.response, entitlement)) fail();

  const optionalDates = [
    receipt.subscriptionExpiresAt,
    receipt.revalidateAfter,
    receipt.lastRevalidatedAt,
    receipt.revokedAt,
  ];
  if (optionalDates.some((value) => value !== undefined && !safeDate(value))) fail();
  if (receipt.lastRevalidatedAt && receipt.lastRevalidatedAt < receipt.verifiedAt) fail();
  if (receipt.revokedAt && receipt.revokedAt < receipt.purchasedAt) fail();
  if (receipt.revalidationFailures !== undefined
    && (!Number.isSafeInteger(receipt.revalidationFailures)
      || receipt.revalidationFailures < 0
      || receipt.revalidationFailures > MAX_REVALIDATION_FAILURES)) fail();

  if (entitlement.kind === "subscription") {
    const encrypted = receipt.encryptedPurchaseToken;
    const terminal = TERMINAL_SUBSCRIPTION_STATES.has(receipt.subscriptionState ?? "");
    const revalidationBaseline = receipt.lastRevalidatedAt ?? receipt.verifiedAt;
    if (!encrypted
      || !exactKeys(encrypted, new Set(["version", "iv", "authTag", "ciphertext"]))
      || encrypted.version !== 1
      || !canonicalBase64(encrypted.iv, 12)
      || !canonicalBase64(encrypted.authTag, 16)
      || !canonicalBase64(encrypted.ciphertext)
      || !SUBSCRIPTION_STATES.has(receipt.subscriptionState ?? "")
      || !receipt.subscriptionExpiresAt
      || receipt.subscriptionExpiresAt < receipt.purchasedAt
      // A live receipt needs a future retry cursor. The only nonterminal exception is a revoked
      // orphan whose player account was deleted; that row is deliberately retired from provider
      // polling. Terminal Play states must have the revocation audit and no retry cursor at all.
      || (terminal && (!receipt.revokedAt || receipt.revalidateAfter !== undefined))
      || (!terminal && !receipt.revalidateAfter && !receipt.revokedAt)
      || (receipt.revalidateAfter !== undefined && receipt.revalidateAfter <= revalidationBaseline)
      || receipt.reversibleGrant !== undefined
      || receipt.voidedSource !== undefined
      || receipt.voidedReason !== undefined
      || receipt.voidedOrderId !== undefined) fail();
  } else {
    // Reconstruction builds predating void reconciliation wrote currency receipts without the
    // reversible snapshot. Their exact catalog-bound response is sufficient to derive the same
    // two wallet amounts; packs have ownership history and therefore never get this migration path.
    const validGrant = receipt.reversibleGrant === undefined && entitlement.kind === "currency"
      ? true
      : validReversibleGrant(receipt.reversibleGrant, entitlement);
    if (!validGrant
      || receipt.encryptedPurchaseToken !== undefined
      || receipt.subscriptionState !== undefined
      || receipt.subscriptionExpiresAt !== undefined
      || receipt.revalidateAfter !== undefined
      || receipt.lastRevalidatedAt !== undefined
      || receipt.revalidationFailures !== undefined) fail();
    const hasVoidedMetadata = receipt.voidedSource !== undefined
      || receipt.voidedReason !== undefined
      || receipt.voidedOrderId !== undefined;
    if (hasVoidedMetadata !== Boolean(receipt.revokedAt)
      || (hasVoidedMetadata && (
        !Number.isSafeInteger(receipt.voidedSource) || (receipt.voidedSource ?? -1) < 0
        || !Number.isSafeInteger(receipt.voidedReason) || (receipt.voidedReason ?? -1) < 0
        || receipt.voidedOrderId !== receipt.orderId
      ))) fail();
  }
  return receipt;
}

/**
 * Advance the durable subscription retry counter without allowing a valid row to overflow its
 * bounded authority. Callers still compare-and-set the old value so concurrent workers cannot
 * collapse multiple provider failures into an unreviewed retry schedule.
 */
export function nextPurchaseRevalidationFailureCount(receipt: PurchaseReceiptDocument): number {
  validatedPurchaseReceipt(receipt);
  const current = receipt.revalidationFailures ?? 0;
  if (current >= MAX_REVALIDATION_FAILURES) fail();
  return current + 1;
}
