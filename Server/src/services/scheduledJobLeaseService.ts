import { randomUUID } from "crypto";
import { scheduledJobLeases, type ScheduledJobLeaseDocument } from "../db";

const MAXIMUM_LEASE_MS = 24 * 60 * 60 * 1_000;
const LEASE_KEYS = new Set(["_id", "ownerId", "acquiredAt", "expiresAt"]);

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

/** Validate the complete crash-expiring lease instead of treating malformed expiry as contention. */
export function validatedScheduledJobLease(
  lease: ScheduledJobLeaseDocument,
  now?: Date,
): ScheduledJobLeaseDocument {
  const raw = lease as unknown as Record<string, unknown>;
  if (!lease
    || typeof lease !== "object"
    || Array.isArray(lease)
    || Object.keys(raw).some((key) => !LEASE_KEYS.has(key))
    || typeof lease._id !== "string"
    || lease._id.length < 1
    || lease._id.length > 128
    || lease._id.trim() !== lease._id
    || /[\u0000-\u001f\u007f]/u.test(lease._id)
    || typeof lease.ownerId !== "string"
    || !/^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/u.test(lease.ownerId)
    || !safeDate(lease.acquiredAt)
    || !safeDate(lease.expiresAt)
    || lease.expiresAt.getTime() - lease.acquiredAt.getTime() < 1_000
    || lease.expiresAt.getTime() - lease.acquiredAt.getTime() > MAXIMUM_LEASE_MS
    || (now !== undefined && (!safeDate(now) || lease.acquiredAt.getTime() > now.getTime()))) {
    throw new Error("Stored scheduled-job lease authority is invalid.");
  }
  return lease;
}

function duplicateKey(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error
    && (error as { code?: unknown }).code === 11000;
}

/** Run one background job only on the node that owns its crash-expiring MongoDB lease. */
export async function withScheduledJobLease<T>(
  jobId: string,
  leaseMs: number,
  work: () => Promise<T>,
): Promise<{ ran: boolean; result?: T }> {
  if (typeof jobId !== "string" || jobId.length < 1 || jobId.length > 128
    || jobId.trim() !== jobId || /[\u0000-\u001f\u007f]/u.test(jobId)
    || !Number.isSafeInteger(leaseMs) || leaseMs < 1_000 || leaseMs > MAXIMUM_LEASE_MS) {
    throw new Error("Scheduled-job lease request is invalid.");
  }
  const ownerId = randomUUID();
  const now = new Date();
  try {
    // An invalid expiry must surface as damaged authority. Without this read, MongoDB's `$lte`
    // filter would merely fail to match and the unique key would make the job look perpetually busy.
    const current = await scheduledJobLeases().findOne({ _id: jobId });
    if (current) validatedScheduledJobLease(current, now);
    const requested = validatedScheduledJobLease({
      _id: jobId,
      ownerId,
      acquiredAt: now,
      expiresAt: new Date(now.getTime() + leaseMs),
    }, now);
    const lease = await scheduledJobLeases().findOneAndUpdate(
      { _id: jobId, $or: [{ expiresAt: { $lte: now } }, { ownerId }] },
      {
        $set: {
          ownerId,
          acquiredAt: requested.acquiredAt,
          expiresAt: requested.expiresAt,
        },
      },
      { upsert: true, returnDocument: "after" },
    );
    if (lease) validatedScheduledJobLease(lease, now);
    if (!lease || lease.ownerId !== ownerId) return { ran: false };
  } catch (error) {
    if (duplicateKey(error)) return { ran: false };
    throw error;
  }

  try {
    return { ran: true, result: await work() };
  } finally {
    await scheduledJobLeases().deleteOne({ _id: jobId, ownerId });
  }
}
