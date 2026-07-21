import { DbAction } from "../dbActions";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { players } from "../db";
import { ok } from "../dtos";
import { buildPlayerData, unixNow } from "../services/playerStateService";
import {
  deliverGooglePlayPackPurchase,
  deliverGooglePlayPurchase,
  parseGooglePlayPurchaseInput,
  type GooglePlayPurchaseInput,
} from "../services/purchaseService";
import type { InAppEntitlement } from "../services/inAppCatalogService";
import { authed, type HandlerEntry } from "./types";

const MAX_RESTORE_PACKS = 50;

type DirectPurchaseKind = Extract<InAppEntitlement["kind"], "currency" | "subscription">;

/**
 * Bind every paid endpoint to the entitlement families its recovered response parser can apply.
 *
 * The stock 1.6.0 billing bridge normally sends both currency and `subscription1` through action
 * 142 (`BuyInApp`), whose shared parser handles Gold, Warbucks, and SubscriptionBought fields.
 * The enum also contains the explicit action 9999999 alias. Some platform/replacement builds use
 * that alias, so register it without letting a currency token cross through the subscription-only
 * route. The Google proof and globally idempotent receipt ledger remain identical for both paths.
 */
export const DIRECT_PURCHASE_KINDS: Readonly<Record<number, readonly DirectPurchaseKind[]>> = Object.freeze({
  [DbAction.BuyInApp]: Object.freeze(["currency", "subscription"] as const),
  [DbAction.BuySubscription]: Object.freeze(["subscription"] as const),
});

function verifiedPurchaseHandler(action: DbAction.BuyInApp | DbAction.BuySubscription): HandlerEntry {
  return authed(async ({ player, req }) => {
    // GoldBase, WarbucksBase, and all other client-authored benefit hints are deliberately ignored
    // by the shared proof parser. Only the verified store product selects the server allowlist row.
    const input = parseGooglePlayPurchaseInput(req);
    const delivered = await deliverGooglePlayPurchase(
      player!.id,
      input,
      undefined,
      undefined,
      DIRECT_PURCHASE_KINDS[action],
    );
    return ok(action, delivered.response);
  });
}

function restoreEntry(value: unknown): GooglePlayPurchaseInput {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Restore pack entry is invalid.");
  }
  const entry = value as Record<string, unknown>;
  // RestorePacks uses Value1..Value4 because the original C# path serializes Tuple-like
  // dictionaries instead of the named BuyPack form. Normalize to the same strict proof parser
  // so both endpoints have identical length, whitespace, and required-field validation.
  return parseGooglePlayPurchaseInput({
    ProductId: entry.Value1,
    PurchaseToken: entry.Value2,
    PackageName: entry.Value3,
    OrderId: entry.Value4,
  });
}

/** Decode the exact JSON list produced by the recovered Android RestorePacks action. */
export function parseRestorePackInputs(value: unknown): GooglePlayPurchaseInput[] {
  if (typeof value !== "string" || value.length < 2 || value.length > 256_000) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Packs restore payload is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Packs restore payload is invalid JSON.");
  }
  if (!Array.isArray(parsed) || parsed.length > MAX_RESTORE_PACKS) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Packs restore payload has an invalid number of entries.");
  }
  return parsed.map(restoreEntry);
}

function validateRefundPackNotice(value: unknown): void {
  if (typeof value !== "string" || value.length < 2 || value.length > 256_000) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Refund pack payload is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Refund pack payload is invalid JSON.");
  }
  if (!Array.isArray(parsed) || parsed.length > MAX_RESTORE_PACKS || parsed.some((item) => (
    !item || typeof item !== "object" || Array.isArray(item)
  ))) {
    throw new ApiError(ApiErrorCode.InvalidInapp, "Refund pack payload has invalid entries.");
  }
}

async function currentPlayerData(playerId: string, now: number): Promise<Record<string, unknown>> {
  const current = await players().findOne({ id: playerId });
  if (!current) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found after purchase delivery.");
  return buildPlayerData(current, now);
}

export const purchaseHandlers: Record<number, HandlerEntry> = {
  [DbAction.BuyInApp]: verifiedPurchaseHandler(DbAction.BuyInApp),
  [DbAction.BuySubscription]: verifiedPurchaseHandler(DbAction.BuySubscription),

  [DbAction.BuyPack]: authed(async ({ player, req }) => {
    const now = unixNow();
    const input = parseGooglePlayPurchaseInput(req);
    await deliverGooglePlayPackPurchase(player!.id, input, undefined, now);
    // BuyPack's recovered response replaces multiple client-side managers from PlayerData. A
    // narrow delta would leave one of wallet, VIP, card slot, weapon, or visual state stale.
    return ok(DbAction.BuyPack, {
      PlayerData: await currentPlayerData(player!.id, now),
      PackId: input.productId,
    });
  }),

  [DbAction.RestorePacks]: authed(async ({ player, req }) => {
    const now = unixNow();
    const inputs = parseRestorePackInputs(req.Packs);
    const restored: string[] = [];
    for (const input of inputs) {
      // Google verification is external, so a multi-token restore cannot share one database
      // transaction. Each token is nevertheless atomic and globally idempotent; if a later
      // token fails, the client can retry the full list without duplicating earlier benefits.
      await deliverGooglePlayPackPurchase(player!.id, input, undefined, now);
      if (!restored.includes(input.productId)) restored.push(input.productId);
    }
    return ok(DbAction.RestorePacks, {
      PlayerData: await currentPlayerData(player!.id, now),
      RestoredPacks: restored,
    });
  }),

  [DbAction.RefundPack]: authed(async ({ req }) => {
    validateRefundPackNotice(req.Packs);
    // The stock client detects a locally missing Billing purchase and submits product/token/order
    // dictionaries, but possession state on a modified or stale device is not refund authority.
    // Keep the wire action successful while deliberately ignoring every claimed identity. The
    // cluster-wide Voided Purchases sweep alone can subtract balances and revoke pack benefits.
    return ok(DbAction.RefundPack);
  }),

  [DbAction.OnSubscriptionExpired]: authed(async () => {
    // SubscriptionManager calls this after its locally cached deadline. The deadline itself is
    // server-owned and already makes benefits inactive, so the client cannot shorten, extend,
    // or replace it through this parameterless notification.
    return ok(DbAction.OnSubscriptionExpired);
  }),

  [DbAction.SaveFuseConfigs]: authed(async ({ req }) => {
    // The recovered debug client can upload a `fuseData` blob, but it is not an administrator
    // credential and must never publish balancing data. Accept only a bounded telemetry-shaped
    // value for wire compatibility; live sheets come exclusively from the signed operator file.
    if (typeof req.fuseData !== "string" || req.fuseData.length > 64_000) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Fuse configuration payload is invalid.");
    }
    return ok(DbAction.SaveFuseConfigs, { Ignored: true });
  }),
};
