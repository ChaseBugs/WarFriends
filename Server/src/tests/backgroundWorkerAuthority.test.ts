import assert from "node:assert/strict";
import test from "node:test";
import type { PurchaseReconciliationCursorDocument, ScheduledJobLeaseDocument } from "../db";
import { validatedPurchaseReconciliationCursor } from "../services/googlePlayVoidedPurchaseService";
import { validatedScheduledJobLease } from "../services/scheduledJobLeaseService";

test("scheduled-job lease authority rejects malformed identity, time, and duration", () => {
  const acquiredAt = new Date("2026-07-21T00:00:00.000Z");
  const lease: ScheduledJobLeaseDocument = {
    _id: "squad-war-maintenance",
    ownerId: "123e4567-e89b-42d3-a456-426614174000",
    acquiredAt,
    expiresAt: new Date(acquiredAt.getTime() + 60_000),
  };
  assert.equal(validatedScheduledJobLease(lease, acquiredAt), lease);
  assert.throws(
    () => validatedScheduledJobLease({ ...lease, ownerId: "operator" }, acquiredAt),
    /lease authority is invalid/,
  );
  assert.throws(
    () => validatedScheduledJobLease({ ...lease, expiresAt: acquiredAt }, acquiredAt),
    /lease authority is invalid/,
  );
  assert.throws(
    () => validatedScheduledJobLease(lease, new Date(acquiredAt.getTime() - 1)),
    /lease authority is invalid/,
  );
});

test("purchase reconciliation cursor cannot drift from its successful provider window", () => {
  const now = new Date("2026-07-21T00:00:00.000Z");
  const cursor: PurchaseReconciliationCursorDocument = {
    _id: "google-play-voided-products",
    lastSuccessfulEndTime: now,
    updatedAt: now,
  };
  assert.equal(validatedPurchaseReconciliationCursor(cursor, now), cursor);
  assert.throws(
    () => validatedPurchaseReconciliationCursor({ ...cursor, updatedAt: new Date(now.getTime() - 1) }, now),
    /cursor authority is invalid/,
  );
  assert.throws(
    () => validatedPurchaseReconciliationCursor(cursor, new Date(now.getTime() - 1)),
    /cursor authority is invalid/,
  );
});
