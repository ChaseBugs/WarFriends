import { createHash } from "crypto";
import type { Collection } from "mongodb";
import {
  firebasePushDeliveries,
  messages,
  players,
  type FirebasePushDeliveryDocument,
} from "../db";
import logger from "../utils/logger";
import { serverMetrics } from "./metricsService";
import {
  attemptOfflineInboxPush,
  invalidFirebaseTokenRetirement,
  type FirebasePushTransport,
} from "./firebasePushService";
import { firebasePushPolicy, type FirebasePushPolicy } from "./firebasePushPolicyService";
import {
  firebasePushDeliveryPolicy,
  firebasePushRetryDelaySeconds,
  type FirebasePushDeliveryPolicy,
} from "./firebasePushDeliveryPolicyService";
import { withScheduledJobLease } from "./scheduledJobLeaseService";
import { validatedInboxMessageDocument } from "./inboxMessageAuthorityService";
import type { MessageDoc } from "./socialService";

const JOB_ID = "firebase-inbox-push-delivery";
const MAXIMUM_RECORDED_ATTEMPTS = 1_000_000;
const MAXIMUM_RETRY_DELAY_MS = 7 * 24 * 60 * 60 * 1_000;
const DOCUMENT_KEYS = new Set([
  "_id", "recipientPlayerId", "messageId", "status", "attempts", "createdAt", "updatedAt",
  "nextAttemptAt", "completedAt", "lastDisposition", "terminalReason",
]);

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() > 0;
}

function boundedIdentity(value: unknown): value is string {
  return typeof value === "string"
    && value.length >= 1
    && value.length <= 256
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
}

/** A token-free digest is the global deduplication identity for one inbox recipient/message pair. */
export function firebasePushDeliveryId(recipientPlayerId: string, messageId: string): string {
  if (!boundedIdentity(recipientPlayerId) || !boundedIdentity(messageId)) {
    throw new Error("Firebase push delivery identity is invalid.");
  }
  return createHash("sha256")
    .update(`${Buffer.byteLength(recipientPlayerId, "utf8")}:${recipientPlayerId}:${messageId}`, "utf8")
    .digest("hex");
}

/**
 * Validate the complete fixed-shape delivery ledger before it can suppress or schedule a send.
 *
 * A malformed deadline must never look overdue and reopen provider delivery. Terminal rows have
 * no retry cursor, while pending rows have no completion marker. The deterministic digest binds
 * both plaintext identities so editing either cannot redirect a pending push to another account.
 */
export function validatedFirebasePushDelivery(
  value: FirebasePushDeliveryDocument,
  now: Date,
): FirebasePushDeliveryDocument {
  const keys = value && typeof value === "object" && !Array.isArray(value) ? Object.keys(value) : [];
  if (!safeDate(now)
    || keys.length !== DOCUMENT_KEYS.size
    || keys.some((key) => !DOCUMENT_KEYS.has(key))
    || !boundedIdentity(value?.recipientPlayerId)
    || !boundedIdentity(value?.messageId)
    || value._id !== firebasePushDeliveryId(value.recipientPlayerId, value.messageId)
    || !Number.isSafeInteger(value.attempts)
    || value.attempts < 0
    || value.attempts > MAXIMUM_RECORDED_ATTEMPTS
    || !safeDate(value.createdAt)
    || !safeDate(value.updatedAt)
    || value.createdAt.getTime() > value.updatedAt.getTime()
    || value.updatedAt.getTime() > now.getTime()) {
    throw new Error("Stored Firebase push delivery authority is invalid.");
  }
  if (value.status === "pending") {
    if (!safeDate(value.nextAttemptAt)
      || value.nextAttemptAt.getTime() < value.updatedAt.getTime()
      || value.nextAttemptAt.getTime() - value.updatedAt.getTime() > MAXIMUM_RETRY_DELAY_MS
      || value.completedAt !== null
      || value.terminalReason !== null
      || ![null, "transient", "configuration"].includes(value.lastDisposition)) {
      throw new Error("Stored Firebase push delivery authority is invalid.");
    }
    return value;
  }
  if (!safeDate(value.completedAt)
    || value.completedAt.getTime() < value.createdAt.getTime()
    || value.completedAt.getTime() !== value.updatedAt.getTime()
    || value.nextAttemptAt !== null) {
    throw new Error("Stored Firebase push delivery authority is invalid.");
  }
  if (value.status === "delivered") {
    if (value.lastDisposition !== null || value.terminalReason !== null || value.attempts < 1) {
      throw new Error("Stored Firebase push delivery authority is invalid.");
    }
    return value;
  }
  if (value.status === "suppressed"
    && ["not-eligible", "invalid-token"].includes(value.terminalReason ?? "")
    && ((value.terminalReason === "invalid-token" && value.attempts >= 1)
      || (value.terminalReason === "not-eligible" && value.lastDisposition === null))) {
    return value;
  }
  throw new Error("Stored Firebase push delivery authority is invalid.");
}

function pendingDelivery(recipientPlayerId: string, messageId: string, now: Date): FirebasePushDeliveryDocument {
  return validatedFirebasePushDelivery({
    _id: firebasePushDeliveryId(recipientPlayerId, messageId),
    recipientPlayerId,
    messageId,
    status: "pending",
    attempts: 0,
    createdAt: now,
    updatedAt: now,
    nextAttemptAt: now,
    completedAt: null,
    lastDisposition: null,
    terminalReason: null,
  }, now);
}

/** Insert a retry-safe delivery intent after the authoritative inbox row commits. */
export async function enqueueFirebaseInboxPush(
  recipientPlayerId: string,
  messageId: string,
  now = new Date(),
  collection?: Collection<FirebasePushDeliveryDocument>,
  pushPolicy: FirebasePushPolicy = firebasePushPolicy(),
): Promise<boolean> {
  if (!pushPolicy.enabled) return false;
  const deliveryCollection = collection ?? firebasePushDeliveries();
  const delivery = pendingDelivery(recipientPlayerId, messageId, now);
  let inserted = false;
  try {
    const result = await deliveryCollection.updateOne(
      { _id: delivery._id },
      { $setOnInsert: delivery },
      { upsert: true },
    );
    inserted = result.upsertedCount === 1;
  } catch (error) {
    // A normal fan-out can race the leased crash-window reconciler. The deterministic `_id` and
    // compound identity index turn that race into E11000; the complete winner is still validated
    // below before being accepted as this message's existing delivery authority.
    if (!(typeof error === "object" && error !== null && "code" in error
      && (error as { code?: unknown }).code === 11000)) throw error;
  }
  const stored = await deliveryCollection.findOne({ _id: delivery._id });
  if (!stored) throw new Error("Firebase push delivery enqueue was not durable.");
  validatedFirebasePushDelivery(stored, now);
  if (stored.recipientPlayerId !== recipientPlayerId || stored.messageId !== messageId) {
    throw new Error("Firebase push delivery digest identity is ambiguous.");
  }
  return inserted;
}

function successorFilter(delivery: FirebasePushDeliveryDocument) {
  return {
    _id: delivery._id,
    status: delivery.status,
    attempts: delivery.attempts,
    updatedAt: delivery.updatedAt,
    nextAttemptAt: delivery.nextAttemptAt,
  };
}

async function writeSuccessor(
  collection: Collection<FirebasePushDeliveryDocument>,
  current: FirebasePushDeliveryDocument,
  successor: FirebasePushDeliveryDocument,
): Promise<void> {
  validatedFirebasePushDelivery(successor, successor.updatedAt);
  const result = await collection.replaceOne(successorFilter(current), successor);
  if (result.modifiedCount !== 1) throw new Error("Firebase push delivery changed during settlement.");
}

function incrementedAttempts(attempts: number): number {
  return Math.min(MAXIMUM_RECORDED_ATTEMPTS, attempts + 1);
}

async function processDelivery(
  delivery: FirebasePushDeliveryDocument,
  now: Date,
  collection: Collection<FirebasePushDeliveryDocument>,
  transport: FirebasePushTransport | undefined,
  pushPolicy: FirebasePushPolicy,
  deliveryPolicy: FirebasePushDeliveryPolicy,
  assertOwned: () => Promise<void>,
): Promise<"delivered" | "suppressed" | "retried"> {
  const result = await attemptOfflineInboxPush(
    delivery.recipientPlayerId,
    delivery.messageId,
    transport,
    pushPolicy,
  );
  if (result.outcome === "sent") serverMetrics.firebasePushAttempt("delivered");
  else if (result.outcome === "failed") {
    serverMetrics.firebasePushAttempt(
      result.disposition === "invalidToken" ? "invalid_token" : result.disposition,
    );
  }
  // The provider call may outlive a lease renewal failure. Fence every durable result after the
  // response so a former worker cannot race the node that has taken over the next sweep.
  await assertOwned();
  if (result.outcome === "sent") {
    await writeSuccessor(collection, delivery, {
      ...delivery,
      status: "delivered",
      attempts: incrementedAttempts(delivery.attempts),
      updatedAt: now,
      nextAttemptAt: null,
      completedAt: now,
      lastDisposition: null,
      terminalReason: null,
    });
    serverMetrics.firebasePushSuppressed("not_eligible");
    return "delivered";
  }
  if (result.outcome === "not-eligible") {
    await writeSuccessor(collection, delivery, {
      ...delivery,
      status: "suppressed",
      updatedAt: now,
      nextAttemptAt: null,
      completedAt: now,
      lastDisposition: null,
      terminalReason: "not-eligible",
    });
    serverMetrics.firebasePushSuppressed("invalid_token");
    return "suppressed";
  }

  const attempts = incrementedAttempts(delivery.attempts);
  if (result.disposition === "invalidToken") {
    const retirement = invalidFirebaseTokenRetirement(
      delivery.recipientPlayerId,
      result.attemptedToken,
      now,
    );
    await players().updateOne(retirement.filter, retirement.update);
    await assertOwned();
    await writeSuccessor(collection, delivery, {
      ...delivery,
      status: "suppressed",
      attempts,
      updatedAt: now,
      nextAttemptAt: null,
      completedAt: now,
      lastDisposition: null,
      terminalReason: "invalid-token",
    });
    return "suppressed";
  }

  const delaySeconds = firebasePushRetryDelaySeconds(delivery.attempts, deliveryPolicy);
  await writeSuccessor(collection, delivery, {
    ...delivery,
    attempts,
    updatedAt: now,
    nextAttemptAt: new Date(now.getTime() + (delaySeconds * 1_000)),
    lastDisposition: result.disposition,
  });
  logger.warnWithEmoji("PUSH", "Firebase inbox wake-up scheduled for retry", "FIREBASE", {
    recipientPlayerId: delivery.recipientPlayerId,
    messageId: delivery.messageId,
    disposition: result.disposition,
    attempts,
    retrySeconds: delaySeconds,
    error: result.error,
  });
  return "retried";
}

export interface FirebasePushSweepResult {
  recovered: number;
  delivered: number;
  suppressed: number;
  retried: number;
  skipped: boolean;
}

/**
 * Recover the narrow crash window between inbox commit and normal post-commit enqueue.
 *
 * The join uses plaintext server-owned identities only inside MongoDB; the durable ledger `_id`
 * remains a digest. Validate the complete selected message batch before inserting any intent so
 * a malformed inbox row cannot be normalized into apparently legitimate delivery authority.
 */
async function recoverMissingDeliveryIntents(
  now: Date,
  batchSize: number,
  collection: Collection<FirebasePushDeliveryDocument>,
  pushPolicy: FirebasePushPolicy,
): Promise<number> {
  const candidates = await messages().aggregate<MessageDoc>([
    {
      $match: {
        messageType: { $in: [0, 3, 9, 11, 21, 23, 28] },
        read: false,
        ignored: false,
        accepted: false,
      },
    },
    {
      $lookup: {
        from: "firebasePushDeliveries",
        let: { recipientPlayerId: "$toPlayerId", messageId: "$messageId" },
        pipeline: [
          {
            $match: {
              $expr: {
                $and: [
                  { $eq: ["$recipientPlayerId", "$$recipientPlayerId"] },
                  { $eq: ["$messageId", "$$messageId"] },
                ],
              },
            },
          },
          { $limit: 1 },
        ],
        as: "_firebaseDelivery",
      },
    },
    { $match: { "_firebaseDelivery.0": { $exists: false } } },
    { $sort: { createdAt: 1, messageId: 1 } },
    { $limit: batchSize },
    { $project: { _firebaseDelivery: 0 } },
  ]).toArray();
  candidates.forEach((candidate) => {
    validatedInboxMessageDocument(candidate);
    if (!safeDate(candidate.createdAt) || candidate.createdAt.getTime() > now.getTime()) {
      throw new Error("Stored Firebase push recovery message time is invalid.");
    }
  });
  let recovered = 0;
  for (const candidate of candidates) {
    if (await enqueueFirebaseInboxPush(
      candidate.toPlayerId,
      candidate.messageId,
      now,
      collection,
      pushPolicy,
    )) recovered += 1;
  }
  return recovered;
}

/** Process one bounded batch under the cluster-wide renewable scheduler lease. */
export async function runFirebasePushDeliverySweep(
  transport?: FirebasePushTransport,
  now = new Date(),
  deliveryPolicy: FirebasePushDeliveryPolicy = firebasePushDeliveryPolicy(),
  pushPolicy: FirebasePushPolicy = firebasePushPolicy(),
  collection?: Collection<FirebasePushDeliveryDocument>,
): Promise<FirebasePushSweepResult> {
  if (!pushPolicy.enabled) {
    return { recovered: 0, delivered: 0, suppressed: 0, retried: 0, skipped: true };
  }
  const exactDeliveryPolicy = firebasePushDeliveryPolicy(deliveryPolicy);
  if (!safeDate(now)) throw new Error("Firebase push delivery time is invalid.");
  const deliveryCollection = collection ?? firebasePushDeliveries();
  const leaseMs = Math.max(300_000, exactDeliveryPolicy.schedulerIntervalSeconds * 2_000);
  const leased = await withScheduledJobLease(JOB_ID, leaseMs, async (lease) => {
    await lease.assertOwned();
    const recovered = await recoverMissingDeliveryIntents(
      now,
      exactDeliveryPolicy.batchSize,
      deliveryCollection,
      pushPolicy,
    );
    serverMetrics.firebasePushRecoveredIntents(recovered);
    await lease.assertOwned();
    const due = await deliveryCollection.find({
      $or: [
        { status: "pending", nextAttemptAt: { $lte: now } },
        { status: "pending", nextAttemptAt: { $exists: false } },
        { status: "pending", nextAttemptAt: { $not: { $type: "date" } } },
        { status: { $nin: ["pending", "delivered", "suppressed"] } },
      ],
    }).sort({ nextAttemptAt: 1, _id: 1 }).limit(exactDeliveryPolicy.batchSize).toArray();
    // A corrupt selected row aborts before the first external call. Partial provider delivery is
    // harder to repair than one visibly stuck batch, and malformed time must never reopen capacity.
    due.forEach((delivery) => validatedFirebasePushDelivery(delivery, now));
    let delivered = 0;
    let suppressed = 0;
    let retried = 0;
    for (const delivery of due) {
      await lease.assertOwned();
      const outcome = await processDelivery(
        delivery,
        now,
        deliveryCollection,
        transport,
        pushPolicy,
        exactDeliveryPolicy,
        lease.assertOwned,
      );
      if (outcome === "delivered") delivered += 1;
      else if (outcome === "suppressed") suppressed += 1;
      else retried += 1;
    }
    return { recovered, delivered, suppressed, retried };
  });
  if (!leased.ran) {
    return { recovered: 0, delivered: 0, suppressed: 0, retried: 0, skipped: true };
  }
  return {
    ...(leased.result ?? { recovered: 0, delivered: 0, suppressed: 0, retried: 0 }),
    skipped: false,
  };
}

/** Start the process-local timer; the MongoDB lease elects the one active backend node. */
export function startFirebasePushDeliveryScheduler(): NodeJS.Timeout | null {
  if (!firebasePushPolicy().enabled) return null;
  const seconds = firebasePushDeliveryPolicy().schedulerIntervalSeconds;
  const run = (): void => {
    void runFirebasePushDeliverySweep().then((result) => {
      if (!result.skipped && (result.recovered > 0
        || result.delivered > 0
        || result.suppressed > 0
        || result.retried > 0)) {
        logger.infoWithEmoji("PUSH", "Firebase inbox delivery sweep completed", "SCHEDULER", {
          recovered: result.recovered,
          delivered: result.delivered,
          suppressed: result.suppressed,
          retried: result.retried,
        });
      }
    }).catch((error: unknown) => {
      serverMetrics.firebasePushSweepFailed();
      logger.errorWithEmoji("PUSH", "Firebase inbox delivery sweep failed", "SCHEDULER", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  };
  run();
  const timer = setInterval(run, seconds * 1_000);
  timer.unref();
  return timer;
}
