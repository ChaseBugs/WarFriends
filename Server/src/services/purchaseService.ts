import { createHmac } from "crypto";
import type { ClientSession, Filter } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import {
  players,
  purchaseReceipts,
  withMongoTransaction,
  type PlayerDocument,
  type PlayerProgressionState,
  type PurchaseReversibleGrant,
  type PurchaseReceiptDocument,
} from "../db";
import { inAppEntitlement, type InAppEntitlement } from "./inAppCatalogService";
import {
  GooglePlayDeveloperApiVerifier,
  GooglePlayVerificationError,
  type GooglePlayPurchaseVerifier,
  type VerifiedGooglePlayPurchase,
} from "./googlePlayPurchaseVerifier";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { encryptPurchaseToken } from "./purchaseTokenCryptoService";
import { applyPackEntitlementState } from "./packPurchaseService";
import {
  validatedSubscription,
  validatedSubscriptionUnixSeconds,
} from "./subscriptionBenefitService";

const defaultVerifier = new GooglePlayDeveloperApiVerifier();

export interface GooglePlayPurchaseInput {
  productId: string;
  purchaseToken: string;
  packageName: string;
  orderId: string;
}

export interface PurchaseDeliveryTransition {
  state: PlayerProgressionState;
  response: Record<string, string | number | boolean>;
  changed: boolean;
  reversibleGrant?: PurchaseReversibleGrant;
}

export interface PurchaseDeliveryResult {
  response: Record<string, string | number | boolean>;
  replayed: boolean;
}

function requiredBoundedString(value: unknown, field: string, maximumLength: number): string {
  if (typeof value !== "string" || value.length === 0 || value.length > maximumLength || value.trim() !== value) {
    throw new ApiError(ApiErrorCode.InvalidInapp, `${field} is invalid.`);
  }
  return value;
}

/** Parse only the four fields emitted by Android PLIABAOLHBE.GDBAPFIKEJN. */
export function parseGooglePlayPurchaseInput(values: Record<string, unknown>): GooglePlayPurchaseInput {
  return {
    productId: requiredBoundedString(values.ProductId, "ProductId", 128),
    purchaseToken: requiredBoundedString(values.PurchaseToken, "PurchaseToken", 4_096),
    packageName: requiredBoundedString(values.PackageName, "PackageName", 255),
    orderId: requiredBoundedString(values.OrderId, "OrderId", 255),
  };
}

function checkedCurrency(current: number, amount: number, field: string): number {
  const next = current + amount;
  // A chargeback can create a negative balance when the original currency was already spent.
  // Later purchases and earned rewards pay that debt down naturally, so delivery must accept a
  // still-negative result while retaining the integer-overflow boundary.
  if (!Number.isSafeInteger(next)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} balance overflow.`);
  }
  return next;
}

/**
 * Apply one verified store entitlement to the server-owned progression snapshot.
 *
 * The Play response proves the SKU, but the amount always comes from inAppCatalogService. The
 * client-supplied GoldBase/WarbucksBase fields are intentionally absent from this function.
 */
export function applyPurchaseEntitlementState(
  state: PlayerProgressionState,
  entitlement: InAppEntitlement,
  purchase: VerifiedGooglePlayPurchase,
  now: number,
  authorityReceiptId?: string,
): PurchaseDeliveryTransition {
  if (purchase.productId !== entitlement.productId || purchase.kind !== entitlement.kind) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Verified purchase does not match its entitlement.");
  }

  if (entitlement.kind === "currency") {
    const next: PlayerProgressionState = {
      ...state,
      revision: state.revision + 1,
      gold: checkedCurrency(state.gold, entitlement.gold, "Gold"),
      warBucks: checkedCurrency(state.warBucks, entitlement.warBucks, "WarBucks"),
    };
    return {
      state: next,
      changed: true,
      response: {
        Id: entitlement.productId,
        ...(entitlement.gold > 0 ? { Gold: entitlement.gold } : {}),
        ...(entitlement.warBucks > 0 ? { Warbucks: entitlement.warBucks } : {}),
      },
      reversibleGrant: {
        gold: entitlement.gold,
        warBucks: entitlement.warBucks,
        vipSeconds: 0,
        weapons: [],
        visuals: [],
        extraCardSlot: false,
        introducedExtraCardSlot: false,
      },
    };
  }

  if (entitlement.kind === "pack") {
    const applied = applyPackEntitlementState(state, entitlement, now);
    return {
      state: applied.state,
      changed: true,
      // The recovered BuyPack callback uses PackId for analytics/product lookup. Return the
      // InApps identity, not sourcePackName (afstarterpack intentionally maps to starterpack).
      response: { PackId: entitlement.productId },
      reversibleGrant: applied.reversibleGrant,
    };
  }

  // The production verifier emits whole Unix seconds, but this pure transition is also the last
  // boundary before mocked/custom verifiers reach durable state. Validate rather than flooring so
  // NaN, Infinity, fractions, or a timestamp outside JavaScript Date's range cannot become a
  // malformed receipt or outrank every later legitimate renewal.
  const currentTime = validatedSubscriptionUnixSeconds(now, "Subscription purchase time");
  const expiresAt = validatedSubscriptionUnixSeconds(
    purchase.expiresAt ?? 0,
    "Verified subscription expiry",
  );
  const purchasedAt = validatedSubscriptionUnixSeconds(
    purchase.purchasedAt,
    "Verified subscription start",
  );
  if (expiresAt <= currentTime) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Verified subscription is expired.");
  }
  if (purchasedAt > currentTime || purchasedAt > expiresAt) {
    // The verified start is the subscription's first entitlement boundary. A future start must not
    // activate benefits early, and an inverted provider interval cannot create durable authority.
    throw new ApiError(ApiErrorCode.InvalidInapp, "Verified subscription timeline is invalid.");
  }
  const current = validatedSubscription(state.subscription);
  if (current && current.expireTime >= expiresAt) {
    // A replacement/re-signup token can represent the same current expiry. Bind only an equal
    // entitlement to the latest successfully verified token; a shorter stale token must never
    // take authority away from a newer subscription.
    const shouldBindAuthority = Boolean(
      authorityReceiptId
      && current.expireTime === expiresAt
      && state.subscriptionAuthorityReceiptId !== authorityReceiptId,
    );
    return {
      state: shouldBindAuthority
        ? { ...state, revision: state.revision + 1, subscriptionAuthorityReceiptId: authorityReceiptId }
        : state,
      changed: shouldBindAuthority,
      response: {
        Id: entitlement.productId,
        SubscriptionBought: false,
        SubscriptionNoChange: true,
        ExpireTime: current.expireTime,
        dogTagTimerLock: current.dogTagTimerLock,
      },
    };
  }
  const subscription = validatedSubscription({
    type: "subscription1" as const,
    expireTime: expiresAt,
    subscribeSince: current?.subscribeSince ?? purchasedAt,
    // This timestamp is the stock client's boundary between normal and subscription dog-tag
    // refill timing. Preserve the original boundary on renewal so elapsed time is not lost.
    dogTagTimerLock: current?.dogTagTimerLock ?? currentTime,
  })!;
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      subscription,
      ...(authorityReceiptId ? { subscriptionAuthorityReceiptId: authorityReceiptId } : {}),
    },
    changed: true,
    response: {
      Id: entitlement.productId,
      SubscriptionBought: true,
      ExpireTime: expiresAt,
      dogTagTimerLock: subscription.dogTagTimerLock,
    },
  };
}

function purchaseTokenKey(token: string): string {
  return createHmac("sha256", config.purchaseTokenHashSecret)
    .update("google-play-purchase\0", "utf8")
    .update(token, "utf8")
    .digest("hex");
}

function progressionFilter(player: PlayerDocument): Filter<PlayerDocument> {
  const rawRevision = player.progression?.revision;
  if (!player.progression) return { id: player.id, progression: { $exists: false } };
  return rawRevision === undefined
    ? { id: player.id, "progression.revision": { $exists: false } }
    : { id: player.id, "progression.revision": rawRevision };
}

async function persistTransition(
  player: PlayerDocument,
  transition: PurchaseDeliveryTransition,
  session: ClientSession,
): Promise<void> {
  if (!transition.changed) return;
  const successor = validatedProgressionSuccessor(progressionForPlayer(player), transition.state);
  const { dogTags: _legacyDogTags, ...canonicalState } = successor;
  const update = await players().updateOne(
    progressionFilter(player),
    { $set: { progression: canonicalState, updatedAt: new Date() } },
    { session },
  );
  if (update.modifiedCount !== 1) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Concurrent purchase delivery could not be committed.");
  }
}

function duplicateKey(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error
    && (error as { code?: unknown }).code === 11000;
}

/** Verify a Play token first, then bind and deliver it atomically exactly once in MongoDB. */
export async function deliverGooglePlayPurchase(
  playerId: string,
  input: GooglePlayPurchaseInput,
  verifier: GooglePlayPurchaseVerifier = defaultVerifier,
  now = unixNow(),
  allowedKinds: readonly InAppEntitlement["kind"][] = ["currency", "subscription"],
): Promise<PurchaseDeliveryResult> {
  if (!config.googlePlayPurchasesEnabled) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Google Play purchases are not configured.");
  }
  if (input.packageName !== config.googlePlayPackageName) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Google Play package does not match this server.");
  }
  const entitlement = inAppEntitlement(input.productId);
  if (!entitlement) throw new ApiError(ApiErrorCode.InvalidInapp, "Paid product is not supported.");
  // BuyInApp and BuyPack carry identical proof fields, but they have different response
  // contracts. Bind each endpoint to its reviewed entitlement families so a caller cannot route
  // a valid currency receipt through BuyPack (or a pack through BuyInApp) to confuse the client.
  if (!allowedKinds.includes(entitlement.kind)) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Paid product is not valid for this action.");
  }

  let verified: VerifiedGooglePlayPurchase;
  try {
    verified = await verifier.verify({ ...input, entitlement }, now);
  } catch (error) {
    if (error instanceof GooglePlayVerificationError) {
      throw new ApiError(
        error.transient ? ApiErrorCode.InternalServerError : ApiErrorCode.InvalidInapp,
        error.transient ? "Google Play verification is temporarily unavailable." : error.message,
      );
    }
    throw error;
  }

  const receiptId = purchaseTokenKey(input.purchaseToken);
  try {
    return await withMongoTransaction(async (session) => {
      const existing = await purchaseReceipts().findOne({ _id: receiptId }, { session });
      if (existing && (existing.playerId !== playerId || existing.productId !== input.productId)) {
        throw new ApiError(ApiErrorCode.InvalidInapp, "Purchase token is already bound to another entitlement.");
      }
      if (existing && entitlement.kind !== "subscription") {
        return { response: existing.response, replayed: true };
      }

      const player = await players().findOne({ id: playerId }, { session });
      if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
      const transition = applyPurchaseEntitlementState(
        progressionForPlayer(player),
        entitlement,
        verified,
        now,
        receiptId,
      );
      await persistTransition(player, transition, session);

      const receipt: PurchaseReceiptDocument = {
        _id: receiptId,
        platform: "google-play",
        playerId,
        productId: input.productId,
        storeProductId: verified.storeProductId,
        orderId: verified.orderId,
        kind: entitlement.kind,
        purchasedAt: new Date(verified.purchasedAt * 1_000),
        verifiedAt: new Date(now * 1_000),
        response: transition.response,
        ...(transition.reversibleGrant ? { reversibleGrant: transition.reversibleGrant } : {}),
        ...(entitlement.kind === "subscription" ? {
          // One-time product tokens are immutable after delivery and need no reversible copy.
          // Subscription tokens are encrypted because Google expects the same bearer token for
          // renewal, hold, cancellation, and expiry checks throughout the entitlement lifecycle.
          encryptedPurchaseToken: encryptPurchaseToken(
            input.purchaseToken,
            receiptId,
            config.purchaseTokenEncryptionSecret,
          ),
          subscriptionState: verified.subscriptionState ?? "SUBSCRIPTION_STATE_ACTIVE",
          subscriptionExpiresAt: new Date((verified.expiresAt ?? now) * 1_000),
          revalidateAfter: new Date(Math.min(
            verified.expiresAt ?? now,
            now + Math.max(300, Math.floor(config.googlePlaySubscriptionRevalidationCadenceSeconds)),
          ) * 1_000),
          revalidationFailures: 0,
        } : {}),
      };
      if (existing) {
        const replacement = await purchaseReceipts().replaceOne({ _id: receiptId, playerId }, receipt, { session });
        if (replacement.matchedCount !== 1) {
          throw new ApiError(ApiErrorCode.InternalServerError, "Purchase receipt changed during delivery.");
        }
      } else {
        await purchaseReceipts().insertOne(receipt, { session });
      }
      return { response: transition.response, replayed: !transition.changed };
    });
  } catch (error) {
    if (duplicateKey(error)) {
      throw new ApiError(ApiErrorCode.InvalidInapp, "Purchase order was already delivered.");
    }
    throw error;
  }
}

/** BuyPack/RestorePacks adapter that cannot deliver currency or subscription products. */
export function deliverGooglePlayPackPurchase(
  playerId: string,
  input: GooglePlayPurchaseInput,
  verifier: GooglePlayPurchaseVerifier = defaultVerifier,
  now = unixNow(),
): Promise<PurchaseDeliveryResult> {
  return deliverGooglePlayPurchase(playerId, input, verifier, now, ["pack"]);
}
