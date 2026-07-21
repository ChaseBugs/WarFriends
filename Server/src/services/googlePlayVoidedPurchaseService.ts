import { createHmac } from "crypto";
import type { Filter } from "mongodb";
import { config } from "../config";
import {
  players,
  purchaseReceipts,
  purchaseReconciliationCursors,
  withMongoTransaction,
  type PlayerDocument,
  type PlayerProgressionState,
  type PurchaseReconciliationCursorDocument,
  type PurchaseReceiptDocument,
  type PurchaseReversibleGrant,
} from "../db";
import logger from "../utils/logger";
import { calculateArmyPower } from "./armyPowerService";
import {
  GooglePlayDeveloperApiVerifier,
  type GooglePlayVoidedPurchase,
  type GooglePlayVoidedPurchaseLister,
} from "./googlePlayPurchaseVerifier";
import { createInitialItemInventory, itemInventoryStateFor } from "./itemInventoryService";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { validatedPlayerAccountEnvelope } from "./playerProfileMirrorAuthorityService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { withScheduledJobLease } from "./scheduledJobLeaseService";
import { cardInventoryStateFor } from "./cardInventoryService";
import { createInitialVisualInventory, visualInventoryStateFor } from "./visualInventoryService";
import { validatedVipExpiration } from "./vipEntitlementService";
import { validatedPurchaseReceipt } from "./purchaseReceiptAuthorityService";

const jobId = "google-play-voided-products";
const cursorId = "google-play-voided-products" as const;
const THIRTY_DAYS_MS = 30 * 24 * 60 * 60 * 1_000;
const WINDOW_OVERLAP_MS = 10 * 60 * 1_000;
const defaultLister = new GooglePlayDeveloperApiVerifier();
const CURSOR_KEYS = new Set(["_id", "lastSuccessfulEndTime", "updatedAt"]);

/** A future or drifted cursor could skip provider events, so validate it as reconciliation authority. */
export function validatedPurchaseReconciliationCursor(
  cursor: PurchaseReconciliationCursorDocument,
  now: Date,
): PurchaseReconciliationCursorDocument {
  const raw = cursor as unknown as Record<string, unknown>;
  const nowMillis = now.getTime();
  if (!cursor
    || typeof cursor !== "object"
    || Array.isArray(cursor)
    || Object.keys(raw).some((key) => !CURSOR_KEYS.has(key))
    || cursor._id !== cursorId
    || !(cursor.lastSuccessfulEndTime instanceof Date)
    || !(cursor.updatedAt instanceof Date)
    || !Number.isSafeInteger(cursor.lastSuccessfulEndTime.getTime())
    || !Number.isSafeInteger(cursor.updatedAt.getTime())
    || !Number.isSafeInteger(nowMillis)
    || cursor.lastSuccessfulEndTime.getTime() < 0
    || cursor.updatedAt.getTime() !== cursor.lastSuccessfulEndTime.getTime()
    || cursor.lastSuccessfulEndTime.getTime() > nowMillis) {
    throw new Error("Stored purchase-reconciliation cursor authority is invalid.");
  }
  return cursor;
}

function receiptIdForToken(token: string): string {
  return createHmac("sha256", config.purchaseTokenHashSecret)
    .update("google-play-purchase\0", "utf8")
    .update(token, "utf8")
    .digest("hex");
}

function checkedSubtract(current: number, amount: number, field: string): number {
  const next = current - amount;
  if (!Number.isSafeInteger(next)) throw new Error(`${field} chargeback balance overflow.`);
  // Negative currency is intentional debt: a player who already spent refunded currency must
  // repay it through later earnings before any spend check can pass again.
  return next;
}

function progressionFilter(player: PlayerDocument): Filter<PlayerDocument> {
  const rawRevision = player.progression?.revision;
  if (!player.progression) return { id: player.id, progression: { $exists: false } };
  return rawRevision === undefined
    ? { id: player.id, "progression.revision": { $exists: false } }
    : { id: player.id, "progression.revision": rawRevision };
}

function legacyCurrencyGrant(receipt: PurchaseReceiptDocument): PurchaseReversibleGrant | null {
  if (receipt.kind !== "currency") return null;
  const gold = Number(receipt.response.Gold ?? 0);
  const warBucks = Number(receipt.response.Warbucks ?? 0);
  if (!Number.isSafeInteger(gold) || gold < 0 || !Number.isSafeInteger(warBucks) || warBucks < 0) return null;
  return {
    gold,
    warBucks,
    vipSeconds: 0,
    weapons: [],
    visuals: [],
    extraCardSlot: false,
    introducedExtraCardSlot: false,
  };
}

function grantsWeapon(grant: PurchaseReversibleGrant | undefined, name: string): boolean {
  return Boolean(grant?.weapons.some((weapon) => weapon.name === name));
}

function grantsPermanentVisual(grant: PurchaseReversibleGrant | undefined, name: string): boolean {
  return Boolean(grant?.visuals.some((visual) => visual.name === name && visual.durationSeconds === 0));
}

/**
 * Reverse one delivered one-time benefit while preserving overlapping, still-paid pack grants.
 *
 * `activeOtherReceipts` handles A/B products that grant the same weapon, visuals, or card slot.
 * `allPackReceipts` establishes whether this purchase family originally introduced durable
 * ownership; if an item predated every pack, refund processing leaves that independent ownership
 * untouched. Timed benefits and currency are additive, so exactly this receipt's amount/duration
 * is removed even when another receipt remains active.
 */
export function applyVoidedOneTimePurchaseState(
  state: PlayerProgressionState,
  grant: PurchaseReversibleGrant,
  activeOtherReceipts: readonly PurchaseReceiptDocument[],
  allPackReceipts: readonly PurchaseReceiptDocument[],
  now: number,
): PlayerProgressionState {
  const itemInventory = itemInventoryStateFor(state);
  const visualInventory = visualInventoryStateFor(state);
  const cardInventory = cardInventoryStateFor(state);
  const initialItems = createInitialItemInventory();
  const initialVisuals = createInitialVisualInventory();

  for (const weaponGrant of grant.weapons) {
    const stillGranted = activeOtherReceipts.some((receipt) => grantsWeapon(receipt.reversibleGrant, weaponGrant.name));
    const introducedByPack = allPackReceipts.some((receipt) => receipt.reversibleGrant?.weapons.some(
      (weapon) => weapon.name === weaponGrant.name && weapon.introduced,
    ));
    if (stillGranted || !introducedByPack) continue;
    const saved = itemInventory.levelManagerData.savedWeapons[weaponGrant.name];
    if (saved) itemInventory.levelManagerData.savedWeapons[weaponGrant.name] = {
      ...saved,
      bought: false,
      borrowed: false,
    };
    for (const [slotId, slot] of Object.entries(itemInventory.inventoryData.slots)) {
      if (slot.name === weaponGrant.name && initialItems.inventoryData.slots[slotId]) {
        itemInventory.inventoryData.slots[slotId] = { ...initialItems.inventoryData.slots[slotId]! };
      }
    }
  }

  for (const visualGrant of grant.visuals) {
    const saved = visualInventory.visuals[visualGrant.name];
    if (!saved || !saved.bought) continue;
    if (visualGrant.durationSeconds > 0) {
      // A permanent copy (expiresOn=0) may have been earned separately and is never shortened.
      if (saved.expiresOn > 0) {
        const expiresOn = Math.max(0, saved.expiresOn - visualGrant.durationSeconds);
        visualInventory.visuals[visualGrant.name] = {
          ...saved,
          expiresOn: expiresOn > now ? expiresOn : 0,
          bought: expiresOn > now,
        };
      }
      continue;
    }
    const stillGranted = activeOtherReceipts.some((receipt) => grantsPermanentVisual(
      receipt.reversibleGrant,
      visualGrant.name,
    ));
    const introducedByPack = allPackReceipts.some((receipt) => receipt.reversibleGrant?.visuals.some(
      (visual) => visual.name === visualGrant.name && visual.durationSeconds === 0 && visual.introduced,
    ));
    if (stillGranted || !introducedByPack) continue;
    visualInventory.visuals[visualGrant.name] = { ...saved, bought: false, borrowed: false, expiresOn: 0 };
    for (const [slotId, slot] of Object.entries(visualInventory.slots)) {
      if (slot.equippedID === visualGrant.name && initialVisuals.slots[slotId]) {
        visualInventory.slots[slotId] = { ...initialVisuals.slots[slotId]! };
      }
    }
  }

  if (grant.extraCardSlot) {
    const stillGranted = activeOtherReceipts.some((receipt) => receipt.reversibleGrant?.extraCardSlot);
    const introducedByPack = allPackReceipts.some((receipt) => receipt.reversibleGrant?.introducedExtraCardSlot);
    if (!stillGranted && introducedByPack) cardInventory.extraSlot = false;
  }

  const currentVipExpiration = validatedVipExpiration(state.vipExpiration);
  const vipExpiration = Math.max(0, currentVipExpiration - grant.vipSeconds);
  return {
    ...state,
    revision: state.revision + 1,
    gold: checkedSubtract(state.gold, grant.gold, "Gold"),
    warBucks: checkedSubtract(state.warBucks, grant.warBucks, "WarBucks"),
    vipExpiration,
    ...(vipExpiration <= now ? { vipStart: 0 } : {}),
    itemInventory,
    visualInventory,
    cardInventory,
  };
}

async function reconcileVoidedPurchase(event: GooglePlayVoidedPurchase, now: number): Promise<"revoked" | "replayed" | "unmatched"> {
  const receiptId = receiptIdForToken(event.purchaseToken);
  return withMongoTransaction(async (session) => {
    const receipt = await purchaseReceipts().findOne({ _id: receiptId }, { session });
    if (!receipt) return "unmatched";
    validatedPurchaseReceipt(receipt);
    if (receipt.kind === "subscription") return "unmatched";
    // A token and order must identify the same immutable product purchase. Treat disagreement as
    // unmatched evidence rather than revoking a potentially unrelated account benefit.
    if (receipt.orderId !== event.orderId) return "unmatched";
    if (receipt.revokedAt) return "replayed";
    const grant = receipt.reversibleGrant ?? legacyCurrencyGrant(receipt);
    if (!grant) return "unmatched";
    const player = await players().findOne({ id: receipt.playerId }, { session });
    if (player) {
      // Preserve the existing missing-player receipt behavior, but fail closed when the account is
      // present and corrupt. Validation must precede inventory reads and the final revoked marker so
      // the whole reversal remains retryable after authoritative player repair.
      validatedPlayerAccountEnvelope(player);
      const allPackReceipts = await purchaseReceipts().find(
        { playerId: receipt.playerId, kind: "pack" },
        { session },
      ).toArray();
      // Overlap decisions preserve paid inventory only when every contributing receipt is valid;
      // one corrupt row must abort instead of making a benefit permanent or revoking it too early.
      for (const packReceipt of allPackReceipts) validatedPurchaseReceipt(packReceipt);
      const activeOtherReceipts = allPackReceipts.filter((other) => other._id !== receipt._id && !other.revokedAt);
      const currentProgression = progressionForPlayer(player);
      const reversedProgression = applyVoidedOneTimePurchaseState(
        currentProgression,
        grant,
        activeOtherReceipts,
        allPackReceipts,
        now,
      );
      const progression = validatedProgressionSuccessor(currentProgression, reversedProgression);
      const projected: PlayerDocument = { ...player, progression };
      const armyPower = calculateArmyPower(projected, now).total;
      const { dogTags: _legacyDogTags, ...canonicalState } = progression;
      const updated = await players().updateOne(
        progressionFilter(player),
        {
          $set: {
            progression: canonicalState,
            armyPower,
            "player.armyPower": armyPower,
            updatedAt: new Date(now * 1_000),
          },
        },
        { session },
      );
      if (updated.modifiedCount !== 1) throw new Error("Concurrent voided purchase reversal could not be committed.");
    }
    await purchaseReceipts().updateOne(
      { _id: receipt._id, revokedAt: { $exists: false } },
      {
        $set: {
          revokedAt: new Date(event.voidedTimeMillis),
          voidedSource: event.voidedSource,
          voidedReason: event.voidedReason,
          voidedOrderId: event.orderId,
        },
      },
      { session },
    );
    return "revoked";
  });
}

export async function runGooglePlayVoidedPurchaseSweep(
  lister: GooglePlayVoidedPurchaseLister = defaultLister,
  now = unixNow(),
): Promise<{ revoked: number; replayed: number; unmatched: number; skipped: boolean }> {
  if (!config.googlePlayVoidedPurchaseReconciliationEnabled) {
    return { revoked: 0, replayed: 0, unmatched: 0, skipped: true };
  }
  const interval = Math.min(3_600, Math.max(60, Math.floor(config.googlePlayVoidedPurchaseSchedulerIntervalSeconds)));
  const leased = await withScheduledJobLease(jobId, Math.max(300_000, interval * 2_000), async (lease) => {
    await lease.assertOwned();
    const nowMillis = now * 1_000;
    const cursor = await purchaseReconciliationCursors().findOne({ _id: cursorId });
    if (cursor) validatedPurchaseReconciliationCursor(cursor, new Date(nowMillis));
    // Google accepts at most a 30-day lookback. Leave one minute inside that hard boundary to
    // avoid clock skew, and overlap successful windows so records delayed around an edge replay.
    const earliest = nowMillis - THIRTY_DAYS_MS + 60_000;
    const startTime = Math.max(earliest, (cursor?.lastSuccessfulEndTime.getTime() ?? earliest) - WINDOW_OVERLAP_MS);
    let pageToken: string | undefined;
    let revoked = 0;
    let replayed = 0;
    let unmatched = 0;
    let pages = 0;
    do {
      if (++pages > 100) throw new Error("Google Play voided purchase pagination exceeded the safety limit.");
      const page = await lister.listVoidedProductPurchases(
        config.googlePlayPackageName,
        startTime,
        nowMillis,
        pageToken,
      );
      await lease.assertOwned();
      for (const event of page.purchases) {
        await lease.assertOwned();
        const result = await reconcileVoidedPurchase(event, now);
        if (result === "revoked") revoked += 1;
        else if (result === "replayed") replayed += 1;
        else unmatched += 1;
      }
      pageToken = page.nextPageToken;
    } while (pageToken);
    const successor = validatedPurchaseReconciliationCursor({
      _id: cursorId,
      lastSuccessfulEndTime: new Date(nowMillis),
      updatedAt: new Date(nowMillis),
    }, new Date(nowMillis));
    await lease.assertOwned();
    await purchaseReconciliationCursors().updateOne(
      { _id: cursorId },
      {
        $set: {
          lastSuccessfulEndTime: successor.lastSuccessfulEndTime,
          updatedAt: successor.updatedAt,
        },
      },
      { upsert: true },
    );
    return { revoked, replayed, unmatched };
  });
  if (!leased.ran) return { revoked: 0, replayed: 0, unmatched: 0, skipped: true };
  return { ...(leased.result ?? { revoked: 0, replayed: 0, unmatched: 0 }), skipped: false };
}

export function startGooglePlayVoidedPurchaseScheduler(): NodeJS.Timeout | null {
  if (!config.googlePlayVoidedPurchaseReconciliationEnabled) return null;
  const seconds = Math.min(3_600, Math.max(60, Math.floor(config.googlePlayVoidedPurchaseSchedulerIntervalSeconds)));
  const run = (): void => {
    void runGooglePlayVoidedPurchaseSweep().then((result) => {
      if (!result.skipped && (result.revoked > 0 || result.unmatched > 0)) {
        logger.infoWithEmoji("PURCHASE", "Google Play voided purchases reconciled", "SCHEDULER", result);
      }
    }).catch((error: unknown) => {
      logger.errorWithEmoji("PURCHASE", "Voided purchase reconciliation sweep failed", "SCHEDULER", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  };
  run();
  const timer = setInterval(run, seconds * 1_000);
  timer.unref();
  return timer;
}
