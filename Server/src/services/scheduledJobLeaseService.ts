import { randomUUID } from "crypto";
import { scheduledJobLeases } from "../db";

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
  const ownerId = randomUUID();
  const now = new Date();
  try {
    const lease = await scheduledJobLeases().findOneAndUpdate(
      { _id: jobId, $or: [{ expiresAt: { $lte: now } }, { ownerId }] },
      {
        $set: {
          ownerId,
          acquiredAt: now,
          expiresAt: new Date(now.getTime() + Math.max(1_000, leaseMs)),
        },
      },
      { upsert: true, returnDocument: "after" },
    );
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
