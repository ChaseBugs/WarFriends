import assert from "node:assert/strict";
import test from "node:test";
import type { Collection } from "mongodb";
import type { PurchaseReconciliationCursorDocument, ScheduledJobLeaseDocument } from "../db";
import { validatedPurchaseReconciliationCursor } from "../services/googlePlayVoidedPurchaseService";
import {
  acquireScheduledJobLease,
  renewScheduledJobLease,
  validatedScheduledJobLease,
  withScheduledJobLease,
} from "../services/scheduledJobLeaseService";

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

  const renewedAt = new Date(acquiredAt.getTime() + 86_400_000);
  const renewable = {
    ...lease,
    renewedAt,
    expiresAt: new Date(renewedAt.getTime() + 60_000),
    leaseMs: 60_000,
  };
  assert.equal(validatedScheduledJobLease(renewable, renewedAt), renewable);
  assert.throws(
    () => validatedScheduledJobLease({ ...renewable, expiresAt: new Date(renewedAt.getTime() + 59_999) }, renewedAt),
    /lease authority is invalid/,
  );
  assert.throws(
    () => validatedScheduledJobLease({ ...renewable, renewedAt: new Date(renewedAt.getTime() + 1) }, renewedAt),
    /lease authority is invalid/,
  );
});

test("scheduled-job takeover binds the complete expired lease snapshot", async () => {
  const now = new Date("2026-07-21T01:00:00.000Z");
  const previous: ScheduledJobLeaseDocument = {
    _id: "player-league-settlement",
    ownerId: "123e4567-e89b-42d3-a456-426614174000",
    acquiredAt: new Date(now.getTime() - 120_000),
    expiresAt: new Date(now.getTime() - 60_000),
  };
  const nextOwner = "223e4567-e89b-42d3-a456-426614174000";
  let capturedFilter: Record<string, unknown> | undefined;
  let capturedOptions: Record<string, unknown> | undefined;
  const collection = {
    findOne: async () => previous,
    findOneAndUpdate: async (
      filter: Record<string, unknown>,
      update: { $set: Record<string, unknown> },
      options: Record<string, unknown>,
    ) => {
      capturedFilter = filter;
      capturedOptions = options;
      return { _id: previous._id, ...update.$set };
    },
  } as unknown as Collection<ScheduledJobLeaseDocument>;

  const acquired = await acquireScheduledJobLease(collection, previous._id, nextOwner, 60_000, now);
  assert.equal(acquired?.ownerId, nextOwner);
  assert.deepEqual(capturedFilter, {
    ...previous,
    $expr: { $eq: [{ $size: { $objectToArray: "$$ROOT" } }, 4] },
  });
  assert.deepEqual(capturedOptions, { returnDocument: "after" });
});

test("scheduled-job renewal cannot resurrect an expired owner", async () => {
  const now = new Date("2026-07-21T01:00:00.000Z");
  let capturedFilter: Record<string, unknown> | undefined;
  const collection = {
    findOneAndUpdate: async (filter: Record<string, unknown>) => {
      capturedFilter = filter;
      return null;
    },
  } as unknown as Collection<ScheduledJobLeaseDocument>;

  await assert.rejects(
    () => renewScheduledJobLease(
      collection,
      "player-league-settlement",
      "123e4567-e89b-42d3-a456-426614174000",
      60_000,
      now,
    ),
    /lease was lost/,
  );
  assert.deepEqual(capturedFilter?.expiresAt, { $gt: now });
  assert.deepEqual(capturedFilter?.renewedAt, { $lte: now });
});

test("scheduled-job wrapper fences work and releases only its renewable owner", async () => {
  let row: ScheduledJobLeaseDocument | null = null;
  let renewals = 0;
  let releaseFilter: Record<string, unknown> | undefined;
  const collection = {
    findOne: async () => row,
    insertOne: async (value: ScheduledJobLeaseDocument) => { row = value; },
    findOneAndUpdate: async (
      _filter: Record<string, unknown>,
      update: { $set: Record<string, unknown> },
    ) => {
      if (!row) return null;
      renewals += 1;
      row = { ...row, ...update.$set } as ScheduledJobLeaseDocument;
      return row;
    },
    deleteOne: async (filter: Record<string, unknown>) => {
      releaseFilter = filter;
      row = null;
      return { deletedCount: 1 };
    },
  } as unknown as Collection<ScheduledJobLeaseDocument>;

  const result = await withScheduledJobLease("test-sweep", 1_000, async (lease) => {
    await lease.assertOwned();
    return 7;
  }, collection);

  assert.deepEqual(result, { ran: true, result: 7 });
  assert.equal(renewals, 2, "one work fence and one final-success fence must renew");
  assert.equal(releaseFilter?._id, "test-sweep");
  assert.equal(releaseFilter?.leaseMs, 1_000);
  assert.equal(row, null);
});

test("scheduled-job wrapper makes the first uncertain renewal terminal for that run", async () => {
  let row: ScheduledJobLeaseDocument | null = null;
  let renewals = 0;
  let releases = 0;
  const collection = {
    findOne: async () => row,
    insertOne: async (value: ScheduledJobLeaseDocument) => { row = value; },
    findOneAndUpdate: async () => {
      renewals += 1;
      return null;
    },
    deleteOne: async () => {
      releases += 1;
      row = null;
      return { deletedCount: 1 };
    },
  } as unknown as Collection<ScheduledJobLeaseDocument>;

  await assert.rejects(
    () => withScheduledJobLease("failed-sweep", 1_000, async (lease) => {
      await lease.assertOwned();
      await lease.assertOwned();
      return 1;
    }, collection),
    /lease was lost/,
  );
  assert.equal(renewals, 1);
  assert.equal(releases, 1);
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
