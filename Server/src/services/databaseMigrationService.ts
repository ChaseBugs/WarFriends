import { randomUUID } from "crypto";
import type { Db, Document } from "mongodb";
import { mongoDatabase } from "../db";
import logger from "../utils/logger";

/**
 * Versioned database migrations for rolling deployments.
 *
 * Every migration must be safe to run again. MongoDB can acknowledge the schema/index change and
 * the process can still terminate before its receipt is inserted; the next process then executes
 * `up` again. MongoDB index creation and the bounded update operations used here are idempotent.
 * Never edit an applied migration. Add a new ordered entry with a new checksum instead.
 */
export interface DatabaseMigration {
  id: string;
  checksum: string;
  description: string;
  up: (db: Db) => Promise<void>;
}

export interface AppliedMigration {
  id: string;
  checksum: string;
}

const migrations: readonly DatabaseMigration[] = [
  {
    id: "20260721_001_match_lifecycle_indexes",
    // This is a manifest checksum, not a runtime hash. Changing the implementation requires a new
    // migration ID/checksum so an older database can never silently receive different logic.
    checksum: "sha256:0f6be24933201c1b4e7ed2d963dff6506e7e2b5dc7fb4f4f9cce49b184703536",
    description: "Index active match recovery and player presence repair scans.",
    up: async (db) => {
      await db.collection("matches").createIndex(
        { state: 1, createdAt: 1 },
        { name: "match_lifecycle_recovery" },
      );
      await db.collection("players").createIndex(
        { "player.status": 1, updatedAt: 1 },
        { name: "player_presence_repair" },
      );
    },
  },
];

const receiptCollectionName = "schemaMigrations";
const runnerLockId = "__database_migration_runner__";
const lockLeaseMs = 5 * 60 * 1000;

interface MigrationReceiptDocument extends Document {
  _id: string;
  kind: "migration";
  checksum: string;
  description: string;
  appliedAt: Date;
  durationMs: number;
}

interface MigrationLockDocument extends Document {
  _id: string;
  kind: "lock";
  ownerId: string;
  acquiredAt: Date;
  expiresAt: Date;
}

export class MigrationHistoryError extends Error {
  constructor(message: string) {
    super(message);
    this.name = "MigrationHistoryError";
  }
}

/**
 * Validate migration history and return only the unapplied suffix.
 *
 * Refusing unknown, reordered, duplicated, or checksum-drifted history is deliberate. Starting a
 * binary against an incompatible schema is more dangerous than keeping that node out of service,
 * especially during a rolling deployment where another version may already own the database.
 */
export function planDatabaseMigrations(
  known: readonly DatabaseMigration[],
  applied: readonly AppliedMigration[],
): DatabaseMigration[] {
  const knownIds = new Set<string>();
  for (const migration of known) {
    if (!/^\d{8}_\d{3}_[a-z0-9_]+$/u.test(migration.id)) {
      throw new MigrationHistoryError(`Migration ID is invalid: ${migration.id}`);
    }
    if (knownIds.has(migration.id)) throw new MigrationHistoryError(`Duplicate migration ID: ${migration.id}`);
    knownIds.add(migration.id);
  }
  const orderedKnown = [...known].sort((a, b) => a.id.localeCompare(b.id));
  if (orderedKnown.some((migration, index) => migration.id !== known[index]?.id)) {
    throw new MigrationHistoryError("Migration registry is not ordered by ID.");
  }

  const appliedIds = new Set<string>();
  for (let index = 0; index < applied.length; index += 1) {
    const receipt = applied[index]!;
    if (appliedIds.has(receipt.id)) throw new MigrationHistoryError(`Duplicate migration receipt: ${receipt.id}`);
    appliedIds.add(receipt.id);
    const expected = known[index];
    if (!expected || expected.id !== receipt.id) {
      throw new MigrationHistoryError(`Database migration history is unknown or out of order at ${receipt.id}.`);
    }
    if (expected.checksum !== receipt.checksum) {
      throw new MigrationHistoryError(`Applied migration checksum changed: ${receipt.id}`);
    }
  }
  return known.slice(applied.length) as DatabaseMigration[];
}

function duplicateKey(error: unknown): boolean {
  return typeof error === "object" && error !== null && "code" in error && (error as { code?: unknown }).code === 11000;
}

/** Acquire the cluster-wide lease. A live runner makes later nodes fail startup instead of race. */
async function acquireMigrationLease(db: Db, ownerId: string, now: Date): Promise<void> {
  const receipts = db.collection<MigrationLockDocument>(receiptCollectionName);
  try {
    const lock = await receipts.findOneAndUpdate(
      {
        _id: runnerLockId,
        $or: [
          { expiresAt: { $lte: now } },
          { ownerId },
        ],
      },
      {
        $set: {
          kind: "lock",
          ownerId,
          acquiredAt: now,
          expiresAt: new Date(now.getTime() + lockLeaseMs),
        },
      },
      { upsert: true, returnDocument: "after" },
    );
    if (!lock || lock.ownerId !== ownerId) throw new MigrationHistoryError("Database migration lease is unavailable.");
  } catch (error) {
    // An upsert against an existing unexpired singleton lock produces E11000 because `_id` is
    // unique. Translate that expected contention into one stable operational error.
    if (duplicateKey(error)) throw new MigrationHistoryError("Database migration lease is held by another server.");
    throw error;
  }
}

async function renewMigrationLease(db: Db, ownerId: string): Promise<void> {
  const renewed = await db.collection<MigrationLockDocument>(receiptCollectionName).updateOne(
    { _id: runnerLockId, ownerId },
    { $set: { expiresAt: new Date(Date.now() + lockLeaseMs) } },
  );
  if (renewed.matchedCount !== 1) throw new MigrationHistoryError("Database migration lease was lost.");
}

/**
 * Keep ownership alive while MongoDB performs a potentially long index build. The timer stores its
 * first failure instead of throwing from an unobserved callback; the migration loop checks that
 * failure before writing the success receipt. This preserves the important invariant that a node
 * never records a migration as applied after it has lost exclusive ownership.
 */
function startLeaseHeartbeat(db: Db, ownerId: string): {
  assertOwned: () => Promise<void>;
  stop: () => void;
} {
  let renewal: Promise<void> = Promise.resolve();
  let failure: unknown;
  const timer = setInterval(() => {
    renewal = renewal.then(() => renewMigrationLease(db, ownerId)).catch((error: unknown) => {
      failure ??= error;
    });
  }, Math.floor(lockLeaseMs / 3));
  timer.unref();
  return {
    assertOwned: async () => {
      await renewal;
      if (failure) throw failure;
      await renewMigrationLease(db, ownerId);
    },
    stop: () => clearInterval(timer),
  };
}

/**
 * Apply every pending migration under one database-wide lease and persist immutable receipts.
 * The lease document is removed only by its owner; an expired lease is recoverable after a crash.
 */
export async function runDatabaseMigrations(db: Db = mongoDatabase()): Promise<number> {
  const ownerId = randomUUID();
  const receipts = db.collection<MigrationReceiptDocument>(receiptCollectionName);
  await acquireMigrationLease(db, ownerId, new Date());
  const heartbeat = startLeaseHeartbeat(db, ownerId);
  try {
    const appliedDocuments = await receipts
      .find({ kind: "migration" })
      .sort({ _id: 1 })
      .project<MigrationReceiptDocument>({ _id: 1, checksum: 1 })
      .toArray();
    const pending = planDatabaseMigrations(
      migrations,
      appliedDocuments.map((receipt) => ({ id: receipt._id, checksum: receipt.checksum })),
    );

    for (const migration of pending) {
      await renewMigrationLease(db, ownerId);
      const startedAt = Date.now();
      await migration.up(db);
      await heartbeat.assertOwned();
      await receipts.insertOne({
        _id: migration.id,
        kind: "migration",
        checksum: migration.checksum,
        description: migration.description,
        appliedAt: new Date(),
        durationMs: Date.now() - startedAt,
      });
      logger.infoWithEmoji("DB", "Database migration applied", "MIGRATION", {
        migrationId: migration.id,
        description: migration.description,
      });
    }
    return pending.length;
  } finally {
    heartbeat.stop();
    await db.collection<MigrationLockDocument>(receiptCollectionName).deleteOne({
      _id: runnerLockId,
      ownerId,
    });
  }
}
