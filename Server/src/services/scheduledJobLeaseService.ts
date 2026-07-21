import { randomUUID } from "crypto";
import type { Collection, Filter } from "mongodb";
import { scheduledJobLeases, type ScheduledJobLeaseDocument } from "../db";

const MAXIMUM_LEASE_MS = 24 * 60 * 60 * 1_000;
const LEGACY_LEASE_KEYS = new Set(["_id", "ownerId", "acquiredAt", "expiresAt"]);
const LEASE_KEYS = new Set(["_id", "ownerId", "acquiredAt", "renewedAt", "expiresAt", "leaseMs"]);
const UUID_V4_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/u;

export interface RenewableScheduledJobLeaseDocument extends ScheduledJobLeaseDocument {
  renewedAt: Date;
  leaseMs: number;
}

export interface ScheduledJobLeaseContext {
  /**
   * Prove that this runner still owns a live lease immediately before the next external call or
   * durable transition. The background heartbeat protects normal long sweeps; this explicit fence
   * stops a worker after a renewal failure or an event-loop pause that crossed the deadline.
   */
  assertOwned: () => Promise<void>;
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function validJobId(value: unknown): value is string {
  return typeof value === "string"
    && value.length >= 1
    && value.length <= 128
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
}

function validLeaseMs(value: unknown): value is number {
  return Number.isSafeInteger(value) && (value as number) >= 1_000 && (value as number) <= MAXIMUM_LEASE_MS;
}

function renewableLease(
  jobId: string,
  ownerId: string,
  leaseMs: number,
  now: Date,
): RenewableScheduledJobLeaseDocument {
  return validatedScheduledJobLease({
    _id: jobId,
    ownerId,
    acquiredAt: now,
    renewedAt: now,
    expiresAt: new Date(now.getTime() + leaseMs),
    leaseMs,
  }, now) as RenewableScheduledJobLeaseDocument;
}

/**
 * Validate one complete crash-expiring lease before expiry or ownership is consulted.
 *
 * Four-field rows are the explicit pre-heartbeat schema. They remain readable until expiry, then
 * the first full-snapshot takeover replaces them with the renewable six-field schema. A new row
 * binds its exact configured duration to `expiresAt = renewedAt + leaseMs`, which lets a worker
 * extend a long sweep without turning malformed or non-finite time into permanent ownership.
 */
export function validatedScheduledJobLease(
  lease: ScheduledJobLeaseDocument,
  now?: Date,
): ScheduledJobLeaseDocument {
  const raw = lease as unknown as Record<string, unknown>;
  const keys = lease && typeof lease === "object" && !Array.isArray(lease) ? Object.keys(raw) : [];
  const legacy = keys.length === LEGACY_LEASE_KEYS.size && keys.every((key) => LEGACY_LEASE_KEYS.has(key));
  const renewable = keys.length === LEASE_KEYS.size && keys.every((key) => LEASE_KEYS.has(key));
  if ((!legacy && !renewable)
    || !validJobId(lease?._id)
    || typeof lease?.ownerId !== "string"
    || !UUID_V4_PATTERN.test(lease.ownerId)
    || !safeDate(lease.acquiredAt)
    || !safeDate(lease.expiresAt)
    || lease.expiresAt.getTime() <= lease.acquiredAt.getTime()
    || (now !== undefined && (!safeDate(now) || lease.acquiredAt.getTime() > now.getTime()))) {
    throw new Error("Stored scheduled-job lease authority is invalid.");
  }
  if (legacy) {
    const duration = lease.expiresAt.getTime() - lease.acquiredAt.getTime();
    if (!validLeaseMs(duration)) throw new Error("Stored scheduled-job lease authority is invalid.");
    return lease;
  }
  const current = lease as RenewableScheduledJobLeaseDocument;
  if (!safeDate(current.renewedAt)
    || !validLeaseMs(current.leaseMs)
    || current.renewedAt.getTime() < current.acquiredAt.getTime()
    || current.expiresAt.getTime() - current.renewedAt.getTime() !== current.leaseMs
    || (now !== undefined && current.renewedAt.getTime() > now.getTime())) {
    throw new Error("Stored scheduled-job lease authority is invalid.");
  }
  return lease;
}

function duplicateKey(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error
    && (error as { code?: unknown }).code === 11000;
}

function completeLeaseFilter(lease: ScheduledJobLeaseDocument): Filter<ScheduledJobLeaseDocument> {
  const raw = lease as RenewableScheduledJobLeaseDocument;
  return {
    _id: lease._id,
    ownerId: lease.ownerId,
    acquiredAt: lease.acquiredAt,
    expiresAt: lease.expiresAt,
    ...(Object.prototype.hasOwnProperty.call(lease, "renewedAt")
      ? { renewedAt: raw.renewedAt, leaseMs: raw.leaseMs }
      : {}),
    // Bind the absence of extra fields as well as every known value. A row changed after validation
    // must not be silently normalized by takeover merely because its expiry is still in the past.
    $expr: { $eq: [{ $size: { $objectToArray: "$$ROOT" } }, Object.keys(lease).length] },
  };
}

/** Acquire an absent singleton or replace one exact expired snapshot. */
export async function acquireScheduledJobLease(
  collection: Collection<ScheduledJobLeaseDocument>,
  jobId: string,
  ownerId: string,
  leaseMs: number,
  now: Date,
): Promise<RenewableScheduledJobLeaseDocument | null> {
  if (!validJobId(jobId) || !UUID_V4_PATTERN.test(ownerId) || !validLeaseMs(leaseMs) || !safeDate(now)) {
    throw new Error("Scheduled-job lease request is invalid.");
  }
  const requested = renewableLease(jobId, ownerId, leaseMs, now);
  const current = await collection.findOne({ _id: jobId });
  if (!current) {
    try {
      // A singleton insert cannot steal a lease created after the preceding read. The unique `_id`
      // turns that race into ordinary contention rather than an accidental replacement.
      await collection.insertOne(requested);
      return requested;
    } catch (error) {
      if (duplicateKey(error)) return null;
      throw error;
    }
  }
  validatedScheduledJobLease(current, now);
  if (current.expiresAt.getTime() > now.getTime()) return null;
  const winner = await collection.findOneAndUpdate(
    completeLeaseFilter(current),
    {
      $set: {
        ownerId: requested.ownerId,
        acquiredAt: requested.acquiredAt,
        renewedAt: requested.renewedAt,
        expiresAt: requested.expiresAt,
        leaseMs: requested.leaseMs,
      },
    },
    { returnDocument: "after" },
  );
  if (!winner) return null;
  validatedScheduledJobLease(winner, now);
  return winner.ownerId === ownerId ? winner as RenewableScheduledJobLeaseDocument : null;
}

/** Renew only a still-live lease; an expired owner is never allowed to resurrect itself. */
export async function renewScheduledJobLease(
  collection: Collection<ScheduledJobLeaseDocument>,
  jobId: string,
  ownerId: string,
  leaseMs: number,
  now: Date = new Date(),
): Promise<RenewableScheduledJobLeaseDocument> {
  if (!validJobId(jobId) || !UUID_V4_PATTERN.test(ownerId) || !validLeaseMs(leaseMs) || !safeDate(now)) {
    throw new Error("Scheduled-job lease request is invalid.");
  }
  const renewed = await collection.findOneAndUpdate(
    {
      _id: jobId,
      ownerId,
      leaseMs,
      acquiredAt: { $lte: now },
      renewedAt: { $lte: now },
      expiresAt: { $gt: now },
    },
    {
      $set: {
        renewedAt: now,
        expiresAt: new Date(now.getTime() + leaseMs),
      },
    },
    { returnDocument: "after" },
  );
  if (!renewed) throw new Error("Scheduled-job lease was lost.");
  validatedScheduledJobLease(renewed, now);
  return renewed as RenewableScheduledJobLeaseDocument;
}

function startLeaseHeartbeat(
  collection: Collection<ScheduledJobLeaseDocument>,
  jobId: string,
  ownerId: string,
  leaseMs: number,
): ScheduledJobLeaseContext & { stop: () => Promise<void> } {
  let renewal: Promise<void> = Promise.resolve();
  let failure: unknown;
  const renew = (): Promise<void> => {
    // Ownership becomes permanently failed for this run after the first uncertain renewal. Do not
    // let a later successful call hide that gap or extend a lease the worker has already lost.
    if (failure) return renewal;
    renewal = renewal
      .then(async () => {
        if (failure) return;
        await renewScheduledJobLease(collection, jobId, ownerId, leaseMs);
      })
      .catch((error: unknown) => { failure ??= error; });
    return renewal;
  };
  const timer = setInterval(() => { void renew(); }, Math.max(250, Math.floor(leaseMs / 3)));
  timer.unref();
  return {
    assertOwned: async () => {
      // Queue the explicit fence behind any timer renewal. Each durable transition gets a current
      // MongoDB compare-and-set proof, while serialization prevents an older completion from
      // shortening a newer expiry.
      await renew();
      if (failure) throw failure;
    },
    stop: async () => {
      clearInterval(timer);
      // Drain a timer renewal already queued before deleting the row. Otherwise that update could
      // race release and leave ownership present after the caller believes the job has finished.
      await renewal;
    },
  };
}

/** Run one background job only while this node owns its renewable MongoDB lease. */
export async function withScheduledJobLease<T>(
  jobId: string,
  leaseMs: number,
  work: (lease: ScheduledJobLeaseContext) => Promise<T>,
  collection: Collection<ScheduledJobLeaseDocument> = scheduledJobLeases(),
): Promise<{ ran: boolean; result?: T }> {
  if (!validJobId(jobId) || !validLeaseMs(leaseMs)) {
    throw new Error("Scheduled-job lease request is invalid.");
  }
  const ownerId = randomUUID();
  const lease = await acquireScheduledJobLease(collection, jobId, ownerId, leaseMs, new Date());
  if (!lease) return { ran: false };
  const heartbeat = startLeaseHeartbeat(collection, jobId, ownerId, leaseMs);
  try {
    const result = await work(heartbeat);
    // Do not publish a successful sweep after the last ownership proof expired while its final
    // operation was in flight.
    await heartbeat.assertOwned();
    return { ran: true, result };
  } finally {
    await heartbeat.stop();
    await collection.deleteOne({ _id: jobId, ownerId, leaseMs });
  }
}
