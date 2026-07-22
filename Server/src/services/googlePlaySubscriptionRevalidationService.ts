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
import {
  googlePlayApplicationPolicy,
  googlePlaySubscriptionRevalidationBatchSize,
  googlePlaySubscriptionRevalidationCadenceSeconds,
  googlePlaySubscriptionSchedulerIntervalSeconds,
} from "./googlePlayPolicyService";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { validatedPlayerAccountEnvelope } from "./playerProfileMirrorAuthorityService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { decryptPurchaseToken } from "./purchaseTokenCryptoService";
import {
  nextPurchaseRevalidationFailureCount,
  TERMINAL_PURCHASE_SUBSCRIPTION_STATES,
  validatedPurchaseReceipt,
} from "./purchaseReceiptAuthorityService";
import { withScheduledJobLease } from "./scheduledJobLeaseService";
import {
  validatedSubscription,
  validatedSubscriptionUnixSeconds,
} from "./subscriptionBenefitService";

const jobId = "google-play-subscription-revalidation";
const defaultVerifier = new GooglePlayDeveloperApiVerifier();
const GOOGLE_PLAY_APPLICATION = googlePlayApplicationPolicy();

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

function nextSuccessfulCheck(status: GooglePlaySubscriptionStatus, now: number): Date | null {
  if ((TERMINAL_PURCHASE_SUBSCRIPTION_STATES as readonly string[]).includes(status.subscriptionState)) {
    return null;
  }
  const next = status.entitled && status.expiresAt
    ? Math.min(status.expiresAt, now + googlePlaySubscriptionRevalidationCadenceSeconds())
    : now + googlePlaySubscriptionRevalidationCadenceSeconds();
  return new Date(next * 1_000);
}

function retrySeconds(failures: number): number {
  // Begin at five minutes and cap at the normal cadence. The durable counter prevents a broken
  // credential from hammering Play after every process restart while still recovering itself.
  return Math.min(
    googlePlaySubscriptionRevalidationCadenceSeconds(),
    300 * (2 ** Math.min(8, Math.max(0, failures - 1))),
  );
}

async function recordRetry(receipt: PurchaseReceiptDocument, now: number): Promise<void> {
  const previousFailures = receipt.revalidationFailures;
  const failures = nextPurchaseRevalidationFailureCount(receipt);
  const revalidateAfter = new Date((now + retrySeconds(failures)) * 1_000);
  // Prove the complete successor before a retry cursor becomes durable. This catches a clock or
  // arithmetic regression before it can strand the receipt outside every later due query.
  validatedPurchaseReceipt({ ...receipt, revalidateAfter, revalidationFailures: failures });
  const retry = await purchaseReceipts().updateOne(
    {
      _id: receipt._id,
      playerId: receipt.playerId,
      kind: "subscription",
      // Older valid receipts omitted the counter. Preserve that migration distinction instead of
      // matching a concurrently initialized or already advanced value as though it were still zero.
      ...(previousFailures === undefined
        ? { revalidationFailures: { $exists: false } }
        : { revalidationFailures: previousFailures }),
    },
    {
      $set: {
        revalidateAfter,
        revalidationFailures: failures,
      },
    },
  );
  if (retry.modifiedCount !== 1) {
    throw new Error("Concurrent subscription retry scheduling could not be committed.");
  }
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
    validatedPurchaseReceipt(liveReceipt);
    const player = await players().findOne({ id: receipt.playerId }, { session });
    if (!player) {
      const retiredAt = new Date(now * 1_000);
      const retiredReceipt: PurchaseReceiptDocument = {
        ...liveReceipt,
        lastRevalidatedAt: retiredAt,
        revokedAt: retiredAt,
      };
      delete retiredReceipt.revalidateAfter;
      // A deleted account deliberately retires even an otherwise active Play token. Validate that
      // exact terminal storage shape before removing it from future scheduler selection.
      validatedPurchaseReceipt(retiredReceipt);
      await purchaseReceipts().updateOne(
        { _id: receipt._id },
        {
          $set: { lastRevalidatedAt: retiredAt, revokedAt: retiredAt },
          $unset: { revalidateAfter: "" },
        },
        { session },
      );
      return false;
    }

    // A missing account has the explicit terminal behavior above, but a present damaged account is
    // not equivalent to deletion. Throw inside the transaction before changing subscription state
    // or its receipt so an operator can repair authority without losing the provider event.
    validatedPlayerAccountEnvelope(player);
    const currentProgression = progressionForPlayer(player);
    const transition = applySubscriptionRevalidationState(
      currentProgression,
      receipt._id,
      status,
      now,
    );
    if (transition.changed) {
      const successor = validatedProgressionSuccessor(currentProgression, transition.state);
      const { dogTags: _legacyDogTags, ...canonicalState } = successor;
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
    // Some terminal provider states omit a fresh expiry. Preserve the last verified expiry in that
    // case: it remains immutable audit context, while deleting it would make the receipt invalid
    // and erase the boundary that originally authorized the subscription.
    if (Object.keys(unsetFields).length > 0) receiptUpdate.$unset = unsetFields;
    const projectedReceipt: PurchaseReceiptDocument = {
      ...liveReceipt,
      subscriptionState: status.subscriptionState,
      lastRevalidatedAt: new Date(now * 1_000),
      revalidationFailures: 0,
    };
    if (status.expiresAt !== undefined) projectedReceipt.subscriptionExpiresAt = new Date(status.expiresAt * 1_000);
    if (next) projectedReceipt.revalidateAfter = next;
    else delete projectedReceipt.revalidateAfter;
    if (status.entitled) delete projectedReceipt.revokedAt;
    else projectedReceipt.revokedAt = new Date(now * 1_000);
    // The provider response changes several lifecycle fields together. Validate their fully
    // projected combination before the update so terminal/cursor contradictions never become a
    // durable receipt that later queries silently skip.
    validatedPurchaseReceipt(projectedReceipt);
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
  assertLeaseOwned: () => Promise<void>,
): Promise<{ checked: boolean; changed: boolean; failed: boolean }> {
  validatedPurchaseReceipt(receipt);
  if (!receipt.encryptedPurchaseToken) return { checked: false, changed: false, failed: false };
  try {
    const purchaseToken = decryptPurchaseToken(
      receipt.encryptedPurchaseToken,
      receipt._id,
      config.purchaseTokenEncryptionSecret,
    );
    const status = await verifier.getSubscriptionStatus({
      packageName: GOOGLE_PLAY_APPLICATION.packageName,
      productId: receipt.productId,
      purchaseToken,
    }, now);
    // Provider latency can outlive a lease heartbeat failure. Fence the durable entitlement write
    // after the response rather than letting an ex-owner commit provider evidence.
    await assertLeaseOwned();
    return { checked: true, changed: await commitSuccessfulStatus(receipt, status, now), failed: false };
  } catch (error) {
    // Retry scheduling is also durable authority. Prove ownership again before changing it; if the
    // lease was lost this assertion escapes the catch and aborts the entire sweep.
    await assertLeaseOwned();
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
  if (!GOOGLE_PLAY_APPLICATION.subscriptionRevalidationEnabled) {
    return { checked: 0, changed: 0, failed: 0, skipped: true };
  }
  const interval = googlePlaySubscriptionSchedulerIntervalSeconds();
  const leased = await withScheduledJobLease(jobId, Math.max(300_000, interval * 2_000), async (lease) => {
    await lease.assertOwned();
    const batchSize = googlePlaySubscriptionRevalidationBatchSize();
    const due = await purchaseReceipts().find({
      $and: [
        {
          // Do not let a damaged `kind` or missing ciphertext hide an otherwise subscription-like
          // row. Any subscription product or lifecycle field places the receipt in this audit
          // domain; the complete validator then decides whether it is legitimate authority.
          $or: [
            { kind: "subscription" },
            { productId: "subscription1" },
            { encryptedPurchaseToken: { $exists: true } },
            { subscriptionState: { $exists: true } },
            { subscriptionExpiresAt: { $exists: true } },
            { revalidateAfter: { $exists: true } },
            { lastRevalidatedAt: { $exists: true } },
            { revalidationFailures: { $exists: true } },
          ],
        },
        {
          $or: [
            { revalidateAfter: { $lte: new Date(now * 1_000) } },
            // Cursor anomalies must enter the audited batch instead of disappearing from the due
            // comparison forever. Revoked rows without a cursor are intentional deleted-account or
            // terminal-state retirement and remain outside provider polling.
            { revalidateAfter: { $exists: false }, revokedAt: { $exists: false } },
            { revalidateAfter: { $exists: true, $not: { $type: "date" } } },
            {
              subscriptionState: { $in: [...TERMINAL_PURCHASE_SUBSCRIPTION_STATES] },
              revalidateAfter: { $exists: true },
            },
          ],
        },
      ],
    }).sort({ revalidateAfter: 1, _id: 1 }).limit(batchSize).toArray();
    // Validate the complete selected batch before its first external call or durable mutation. A
    // corrupt receipt is operator-repair authority, not permission to partially advance neighbors.
    due.forEach((receipt) => validatedPurchaseReceipt(receipt));
    let checked = 0;
    let changed = 0;
    let failed = 0;
    // Status checks are deliberately sequential. This bounds Play API pressure and makes the
    // configured batch size an honest worst-case request count for each leased sweep.
    for (const receipt of due) {
      const result = await revalidateReceipt(receipt, verifier, now, lease.assertOwned);
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
  if (!GOOGLE_PLAY_APPLICATION.subscriptionRevalidationEnabled) return null;
  const seconds = googlePlaySubscriptionSchedulerIntervalSeconds();
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
