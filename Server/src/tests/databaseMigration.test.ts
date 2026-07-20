import assert from "node:assert/strict";
import test from "node:test";
import type { DatabaseMigration } from "../services/databaseMigrationService";
import { MigrationHistoryError, planDatabaseMigrations } from "../services/databaseMigrationService";

function migration(id: string, checksum: string): DatabaseMigration {
  return { id, checksum, description: id, up: async () => undefined };
}

const known = [
  migration("20260721_001_first", "one"),
  migration("20260721_002_second", "two"),
];

test("database migration plan returns only the unapplied ordered suffix", () => {
  assert.deepEqual(planDatabaseMigrations(known, []), known);
  assert.deepEqual(planDatabaseMigrations(known, [{ id: known[0]!.id, checksum: "one" }]), [known[1]]);
  assert.deepEqual(planDatabaseMigrations(known, [
    { id: known[0]!.id, checksum: "one" },
    { id: known[1]!.id, checksum: "two" },
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
  assert.throws(() => planDatabaseMigrations([known[1]!, known[0]!], []), MigrationHistoryError);
});
