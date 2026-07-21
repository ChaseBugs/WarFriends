import type { Filter, UpdateFilter } from "mongodb";
import { config } from "../config";
import {
  players,
  purchaseReceipts,
  withMongoTransaction,
  type PlayerDocument,
  type PlayerProgressionState,
  type PurchaseReceiptDocument,
} from "../db";
import logger from "../utils/logger";
import {
  GooglePlayDeveloperApiVerifier,
  type GooglePlaySubscriptionStatus,
  type GooglePlaySubscriptionStatusVerifier,
} from "./googlePlayPurchaseVerifier";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { decryptPurchaseToken } from "./purchaseTokenCryptoService";
import { withScheduledJobLease } from "./scheduledJobLeaseService";
import {
  validatedSubscription,
  validatedSubscriptionUnixSeconds,
} from "./subscriptionBenefitService";

const jobId = "google-play-subscription-revalidation";
const defaultVerifier = new GooglePlayDeveloperApiVerifier();

export interface SubscriptionRevalidationTransition {
  state: PlayerProgressionState;
  changed: boolean;
  effectiveExpiry: number | null;
}

/**
 * Project one authoritative Play status into the private progression snapshot.
 *
 * The receipt-ownership check is the essential stale-event guard. Google can return an older
 * token after an upgrade, re-signup, or delayed sweep; only the receipt bound by the latest
 * successful purchase is allowed to change benefits. Canceled-but-unexpired statuses arrive as
 * `entitled=true` and retain their expiry. Paused/on-hold statuses revoke at server time, while a
 * normally expired status preserves Google's earlier expiry for an accurate audit trail.
 */
export function applySubscriptionRevalidationState(
  state: PlayerProgressionState,
  authorityReceiptId: string,
  status: GooglePlaySubscriptionStatus,
  now: number,
): SubscriptionRevalidationTransition {
  // Validate the provider observation even for a stale receipt. The receipt audit fields and
  // next-check cursor are updated after this transition, so accepting Infinity here could still
  // create an invalid BSON Date even when ownership correctly prevents a player-state mutation.
  const currentTime = validatedSubscriptionUnixSeconds(now, "Subscription revalidation time");
  const observedExpiry = status.expiresAt === undefined
    ? 0
    : validatedSubscriptionUnixSeconds(status.expiresAt, "Observed subscription expiry");
  const current = validatedSubscription(state.subscription);
  if (!current || state.subscriptionAuthorityReceiptId !== authorityReceiptId) {
    return { state, changed: false, effectiveExpiry: null };
  }

  const effectiveExpiry = status.entitled && observedExpiry > currentTime
    ? observedExpiry
    : Math.min(
      current.expireTime,
      observedExpiry > 0 && observedExpiry <= currentTime ? observedExpiry : currentTime,
    );
  if (effectiveExpiry === current.expireTime) {
    return { state, changed: false, effectiveExpiry };
  }
  const subscription = validatedSubscription({ ...current, expireTime: effectiveExpiry })!;
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      subscription,
    },
    changed: true,
    effectiveExpiry,
  };
}

function progressionFilter(player: PlayerDocument): Filter<PlayerDocument> {
  const rawRevision = player.progression?.revision;
  if (!player.progression) return { id: player.id, progression: { $exists: false } };
  return rawRevision === undefined
    ? { id: player.id, "progression.revision": { $exists: false } }
    : { id: player.id, "progression.revision": rawRevision };
}

function cadenceSeconds(): number {
  return Math.min(86_400, Math.max(300, Math.floor(config.googlePlaySubscriptionRevalidationCadenceSeconds)));
}

function nextSuccessfulCheck(status: GooglePlaySubscriptionStatus, now: number): Date | null {
  if (status.subscriptionState === "SUBSCRIPTION_STATE_EXPIRED"
    || status.subscriptionState === "SUBSCRIPTION_STATE_PENDING_PURCHASE_CANCELED") {
    return null;
  }
  const next = status.entitled && status.expiresAt
    ? Math.min(status.expiresAt, now + cadenceSeconds())
    : now + cadenceSeconds();
  return new Date(next * 1_000);
}

function retrySeconds(failures: number): number {
  // Begin at five minutes and cap at the normal cadence. The durable counter prevents a broken
  // credential from hammering Play after every process restart while still recovering itself.
  return Math.min(cadenceSeconds(), 300 * (2 ** Math.min(8, Math.max(0, failures - 1))));
}

async function recordRetry(receipt: PurchaseReceiptDocument, now: number): Promise<void> {
  const failures = Math.max(0, Math.floor(receipt.revalidationFailures ?? 0)) + 1;
  await purchaseReceipts().updateOne(
    { _id: receipt._id, playerId: receipt.playerId, kind: "subscription" },
    {
      $set: { revalidateAfter: new Date((now + retrySeconds(failures)) * 1_000) },
      $inc: { revalidationFailures: 1 },
    },
  );
}

async function commitSuccessfulStatus(
  receipt: PurchaseReceiptDocument,
  status: GooglePlaySubscriptionStatus,
  now: number,
): Promise<boolean> {
  return withMongoTransaction(async (session) => {
    const liveReceipt = await purchaseReceipts().findOne(
      { _id: receipt._id, playerId: receipt.playerId, kind: "subscription" },
      { session },
    );
    if (!liveReceipt) return false;
    const player = await players().findOne({ id: receipt.playerId }, { session });
    if (!player) {
      await purchaseReceipts().updateOne(
        { _id: receipt._id },
        {
          $set: { lastRevalidatedAt: new Date(now * 1_000), revokedAt: new Date(now * 1_000) },
          $unset: { revalidateAfter: "" },
        },
        { session },
      );
      return false;
    }

    const transition = applySubscriptionRevalidationState(
      progressionForPlayer(player),
      receipt._id,
      status,
      now,
    );
    if (transition.changed) {
      const { dogTags: _legacyDogTags, ...canonicalState } = transition.state;
      const update = await players().updateOne(
        progressionFilter(player),
        { $set: { progression: canonicalState, updatedAt: new Date(now * 1_000) } },
        { session },
      );
      if (update.modifiedCount !== 1) throw new Error("Concurrent subscription revalidation could not be committed.");
    }

    const next = nextSuccessfulCheck(status, now);
    const terminal = next === null;
    const receiptUpdate: UpdateFilter<PurchaseReceiptDocument> = {
      $set: {
        subscriptionState: status.subscriptionState,
        ...(status.expiresAt ? { subscriptionExpiresAt: new Date(status.expiresAt * 1_000) } : {}),
        lastRevalidatedAt: new Date(now * 1_000),
        revalidationFailures: 0,
        ...(next ? { revalidateAfter: next } : {}),
        ...(!status.entitled ? { revokedAt: new Date(now * 1_000) } : {}),
      },
    };
    const unsetFields: Record<string, ""> = {};
    if (terminal) unsetFields.revalidateAfter = "";
    // A hold can recover after payment succeeds. Clear its audit marker when Google later reports
    // entitlement again instead of leaving an active receipt labeled as permanently revoked.
    if (status.entitled) unsetFields.revokedAt = "";
    if (status.expiresAt === undefined) unsetFields.subscriptionExpiresAt = "";
    if (Object.keys(unsetFields).length > 0) receiptUpdate.$unset = unsetFields;
    await purchaseReceipts().updateOne(
      { _id: receipt._id, playerId: receipt.playerId },
      receiptUpdate,
      { session },
    );
    return transition.changed;
  });
}

async function revalidateReceipt(
  receipt: PurchaseReceiptDocument,
  verifier: GooglePlaySubscriptionStatusVerifier,
  now: number,
): Promise<{ checked: boolean; changed: boolean; failed: boolean }> {
  if (!receipt.encryptedPurchaseToken) return { checked: false, changed: false, failed: false };
  try {
    const purchaseToken = decryptPurchaseToken(
      receipt.encryptedPurchaseToken,
      receipt._id,
      config.purchaseTokenEncryptionSecret,
    );
    const status = await verifier.getSubscriptionStatus({
      packageName: config.googlePlayPackageName,
      productId: receipt.productId,
      purchaseToken,
    }, now);
    return { checked: true, changed: await commitSuccessfulStatus(receipt, status, now), failed: false };
  } catch (error) {
    await recordRetry(receipt, now);
    logger.errorWithEmoji("PURCHASE", "Google Play subscription revalidation failed", "SCHEDULER", {
      receiptId: receipt._id,
      playerId: receipt.playerId,
      error: error instanceof Error ? error.message : String(error),
    });
    return { checked: false, changed: false, failed: true };
  }
}

export async function runGooglePlaySubscriptionRevalidationSweep(
  verifier: GooglePlaySubscriptionStatusVerifier = defaultVerifier,
  now = unixNow(),
): Promise<{ checked: number; changed: number; failed: number; skipped: boolean }> {
  if (!config.googlePlaySubscriptionRevalidationEnabled) {
    return { checked: 0, changed: 0, failed: 0, skipped: true };
  }
  const interval = Math.min(3_600, Math.max(30, Math.floor(config.googlePlaySubscriptionSchedulerIntervalSeconds)));
  const leased = await withScheduledJobLease(jobId, Math.max(300_000, interval * 2_000), async () => {
    const batchSize = Math.min(1_000, Math.max(1, Math.floor(config.googlePlaySubscriptionRevalidationBatchSize)));
    const due = await purchaseReceipts().find({
      kind: "subscription",
      encryptedPurchaseToken: { $exists: true },
      revalidateAfter: { $lte: new Date(now * 1_000) },
    }).sort({ revalidateAfter: 1, _id: 1 }).limit(batchSize).toArray();
    let checked = 0;
    let changed = 0;
    let failed = 0;
    // Status checks are deliberately sequential. This bounds Play API pressure and makes the
    // configured batch size an honest worst-case request count for each leased sweep.
    for (const receipt of due) {
      const result = await revalidateReceipt(receipt, verifier, now);
      if (result.checked) checked += 1;
      if (result.changed) changed += 1;
      if (result.failed) failed += 1;
    }
    return { checked, changed, failed };
  });
  if (!leased.ran) return { checked: 0, changed: 0, failed: 0, skipped: true };
  return { ...(leased.result ?? { checked: 0, changed: 0, failed: 0 }), skipped: false };
}

export function startGooglePlaySubscriptionRevalidationScheduler(): NodeJS.Timeout | null {
  if (!config.googlePlaySubscriptionRevalidationEnabled) return null;
  const seconds = Math.min(3_600, Math.max(30, Math.floor(config.googlePlaySubscriptionSchedulerIntervalSeconds)));
  const run = (): void => {
    void runGooglePlaySubscriptionRevalidationSweep().then((result) => {
      if (!result.skipped && (result.checked > 0 || result.failed > 0)) {
        logger.infoWithEmoji("PURCHASE", "Google Play subscriptions revalidated", "SCHEDULER", result);
      }
    }).catch((error: unknown) => {
      logger.errorWithEmoji("PURCHASE", "Subscription revalidation sweep failed", "SCHEDULER", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  };
  run();
  const timer = setInterval(run, seconds * 1_000);
  timer.unref();
  return timer;
}
