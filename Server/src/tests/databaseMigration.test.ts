import assert from "node:assert/strict";
import test from "node:test";
import type { Db } from "mongodb";
import type { DatabaseMigration } from "../services/databaseMigrationService";
import {
  MigrationHistoryError,
  planDatabaseMigrations,
  renewMigrationLease,
  validateMigrationLockAuthority,
  validateMigrationReceiptAuthority,
} from "../services/databaseMigrationService";

function migration(id: string, checksum: string): DatabaseMigration {
  return { id, checksum, description: id, up: async () => undefined };
}

const known = [
  migration("20260721_001_first", `sha256:${"a".repeat(64)}`),
  migration("20260721_002_second", `sha256:${"b".repeat(64)}`),
];

test("database migration plan returns only the unapplied ordered suffix", () => {
  assert.deepEqual(planDatabaseMigrations(known, []), known);
  assert.deepEqual(planDatabaseMigrations(known, [{ id: known[0]!.id, checksum: known[0]!.checksum }]), [known[1]]);
  assert.deepEqual(planDatabaseMigrations(known, [
    { id: known[0]!.id, checksum: known[0]!.checksum },
    { id: known[1]!.id, checksum: known[1]!.checksum },
  ]), []);
});

test("database migration plan rejects changed or unknown applied history", () => {
  assert.throws(
    () => planDatabaseMigrations(known, [{ id: known[0]!.id, checksum: "changed" }]),
    MigrationHistoryError,
  );
  assert.throws(
    () => planDatabaseMigrations(known, [{ id: "20260720_001_unknown", checksum: "old" }]),
    MigrationHistoryError,
  );
});

test("database migration registry rejects duplicate, malformed, and reordered IDs", () => {
  assert.throws(() => planDatabaseMigrations([known[0]!, known[0]!], []), MigrationHistoryError);
  assert.throws(() => planDatabaseMigrations([migration("bad", "bad")], []), MigrationHistoryError);
  assert.throws(
    () => planDatabaseMigrations([migration("20260721_003_bad_checksum", "bad")], []),
    MigrationHistoryError,
  );
  assert.throws(
    () => planDatabaseMigrations([{ ...known[0]!, description: " padded " }], []),
    MigrationHistoryError,
  );
  assert.throws(() => planDatabaseMigrations([known[1]!, known[0]!], []), MigrationHistoryError);
});

test("database migration receipts require their complete immutable authority", () => {
  const now = new Date("2026-07-21T12:00:00.000Z");
  const expected = migration(
    "20260721_003_receipt_authority",
    `sha256:${"a".repeat(64)}`,
  );
  const valid = {
    _id: expected.id,
    kind: "migration",
    checksum: expected.checksum,
    description: expected.description,
    appliedAt: new Date(now.getTime() - 1_000),
    durationMs: 1_234,
  };

  assert.doesNotThrow(() => validateMigrationReceiptAuthority(valid, now, expected));
  assert.throws(
    () => validateMigrationReceiptAuthority({ ...valid, description: "different" }, now, expected),
    MigrationHistoryError,
  );
  assert.throws(
    () => validateMigrationReceiptAuthority({ ...valid, appliedAt: new Date(now.getTime() + 1) }, now, expected),
    MigrationHistoryError,
  );
  assert.throws(
    () => validateMigrationReceiptAuthority({ ...valid, durationMs: Number.NaN }, now, expected),
    MigrationHistoryError,
  );
  assert.throws(
    () => validateMigrationReceiptAuthority({ ...valid, unexpected: true }, now, expected),
    MigrationHistoryError,
  );
});

test("database migration lease authority rejects malformed or impossible clocks", () => {
  const now = new Date("2026-07-21T12:00:00.000Z");
  const ownerId = "11111111-1111-4111-8111-111111111111";
  const active = {
    _id: "__database_migration_runner__",
    kind: "lock",
    ownerId,
    acquiredAt: new Date(now.getTime() - 1_000),
    expiresAt: new Date(now.getTime() + 299_000),
  };
  const expired = {
    ...active,
    acquiredAt: new Date(now.getTime() - 600_000),
    expiresAt: new Date(now.getTime() - 300_000),
  };

  assert.doesNotThrow(() => validateMigrationLockAuthority(active, now));
  assert.doesNotThrow(() => validateMigrationLockAuthority(expired, now));
  assert.throws(
    () => validateMigrationLockAuthority({ ...active, acquiredAt: new Date(now.getTime() + 1) }, now),
    MigrationHistoryError,
  );
  assert.throws(
    () => validateMigrationLockAuthority({ ...active, expiresAt: new Date(now.getTime() + 300_001) }, now),
    MigrationHistoryError,
  );
  assert.throws(
    () => validateMigrationLockAuthority({ ...active, ownerId: "not-a-uuid" }, now),
    MigrationHistoryError,
  );
});

test("database migration renewal cannot resurrect an expired lease", async () => {
  const now = new Date("2026-07-21T12:00:00.000Z");
  const ownerId = "11111111-1111-4111-8111-111111111111";
  let capturedFilter: Record<string, unknown> | undefined;
  const db = {
    collection: () => ({
      findOneAndUpdate: async (filter: Record<string, unknown>) => {
        capturedFilter = filter;
        return null;
      },
    }),
  } as unknown as Db;

  await assert.rejects(() => renewMigrationLease(db, ownerId, now), MigrationHistoryError);
  assert.deepEqual(capturedFilter?.expiresAt, { $gt: now });
  assert.deepEqual(capturedFilter?.acquiredAt, { $lte: now });
});
