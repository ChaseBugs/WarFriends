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
  if (!Number.isSafeInteger(next) || next < 0) {
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
    };
  }

  const expiresAt = Math.floor(purchase.expiresAt ?? 0);
  if (expiresAt <= now) throw new ApiError(ApiErrorCode.InvalidInapp, "Verified subscription is expired.");
  const current = state.subscription;
  if (current && current.expireTime >= expiresAt) {
    return {
      state,
      changed: false,
      response: {
        Id: entitlement.productId,
        SubscriptionBought: false,
        SubscriptionNoChange: true,
        ExpireTime: current.expireTime,
        dogTagTimerLock: current.dogTagTimerLock,
      },
    };
  }
  const subscription = {
    type: "subscription1" as const,
    expireTime: expiresAt,
    subscribeSince: current?.subscribeSince ?? purchase.purchasedAt,
    // This timestamp is the stock client's boundary between normal and subscription dog-tag
    // refill timing. Preserve the original boundary on renewal so elapsed time is not lost.
    dogTagTimerLock: current?.dogTagTimerLock ?? now,
  };
  return {
    state: { ...state, revision: state.revision + 1, subscription },
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
  const { dogTags: _legacyDogTags, ...canonicalState } = transition.state;
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
): Promise<PurchaseDeliveryResult> {
  if (!config.googlePlayPurchasesEnabled) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Google Play purchases are not configured.");
  }
  if (input.packageName !== config.googlePlayPackageName) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Google Play package does not match this server.");
  }
  const entitlement = inAppEntitlement(input.productId);
  if (!entitlement) throw new ApiError(ApiErrorCode.InvalidInapp, "Paid product is not supported.");

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
      if (existing && entitlement.kind === "currency") {
        return { response: existing.response, replayed: true };
      }

      const player = await players().findOne({ id: playerId }, { session });
      if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
      const transition = applyPurchaseEntitlementState(
        progressionForPlayer(player),
        entitlement,
        verified,
        now,
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
