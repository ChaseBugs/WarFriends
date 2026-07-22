import assert from "node:assert/strict";
import test from "node:test";
import {
  buildRestoredQueueEntries,
  enqueue,
  queueSize,
  remove,
  restoreWaiting,
  validQueueEntry,
} from "../services/matchmakingService";

test("distributed matchmaking snapshots require the exact source-backed queue authority", () => {
  assert.equal(validQueueEntry({
    playerId: "queue-player",
    armyPower: 100.75,
    leagueTier: 2,
    enqueuedAt: Date.now(),
  }), true);
  assert.equal(validQueueEntry({
    playerId: "queue-player",
    armyPower: 2_147_483_647.9,
    leagueTier: 16,
    enqueuedAt: Number.MAX_SAFE_INTEGER,
  }), true, "the recovered client truncates the finite Army Power projection to a signed int");
  assert.equal(validQueueEntry({ playerId: "", armyPower: 100, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player.control\n", armyPower: 100, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player.path", armyPower: 100, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player$path", armyPower: 100, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: -1, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: 2_147_483_648, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: Number.POSITIVE_INFINITY, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: 1, leagueTier: 0, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: 1, leagueTier: 17, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: 1, leagueTier: 1.5, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: 1, leagueTier: 1, enqueuedAt: 1.5 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: 1, leagueTier: 1, enqueuedAt: 0 }), false);
  assert.equal(validQueueEntry({
    playerId: "player",
    armyPower: 1,
    leagueTier: 1,
    enqueuedAt: 1,
    trusted: true,
  }), false, "unknown fields must not survive the Redis hash boundary");
});

test("distributed failed-admission restoration keeps one complete timestamped snapshot per player", () => {
  const restored = buildRestoredQueueEntries([
    { playerId: "restore-a", armyPower: 10, leagueTier: 1 },
    { playerId: "restore-a", armyPower: 20, leagueTier: 2 },
    { playerId: "restore-b", armyPower: 30, leagueTier: 3 },
  ], 5_000);
  assert.deepEqual(restored, [
    { playerId: "restore-a", armyPower: 20, leagueTier: 2, enqueuedAt: 5_000 },
    { playerId: "restore-b", armyPower: 30, leagueTier: 3, enqueuedAt: 5_000 },
  ]);
  assert.equal(restored.every(validQueueEntry), true);
});

test("matchmaking deduplicates queue entries and removes both players when paired", () => {
  remove("queue-p1");
  remove("queue-p2");
  const initialSize = queueSize();

  assert.equal(enqueue({ playerId: "queue-p1", armyPower: 100, leagueTier: 2 }), null);
  assert.equal(enqueue({ playerId: "queue-p1", armyPower: 105, leagueTier: 2 }), null);
  assert.equal(queueSize(), initialSize + 1);
  assert.equal(enqueue({ playerId: "queue-p2", armyPower: 110, leagueTier: 2 }), "queue-p1");
  assert.equal(queueSize(), initialSize);
});

test("an invalid enqueue cannot erase the player's existing valid search", () => {
  for (const id of ["queue-preserve", "queue-preserve-opponent"]) remove(id);
  const initialSize = queueSize();

  assert.equal(enqueue({ playerId: "queue-preserve", armyPower: 100, leagueTier: 2 }), null);
  assert.throws(
    () => enqueue({ playerId: "queue-preserve", armyPower: 100, leagueTier: 17 }),
    /queue entry is invalid/i,
  );
  assert.equal(queueSize(), initialSize + 1);
  assert.equal(
    enqueue({ playerId: "queue-preserve-opponent", armyPower: 100, leagueTier: 2 }),
    "queue-preserve",
  );
  assert.equal(queueSize(), initialSize);
});

test("queue removal reports whether a pending search actually existed", () => {
  remove("queue-remove");
  enqueue({ playerId: "queue-remove", armyPower: 1, leagueTier: 1 });
  assert.equal(remove("queue-remove"), true);
  assert.equal(remove("queue-remove"), false);
});

test("failed durable admission restores a deduplicated batch without immediately re-pairing it", () => {
  for (const id of ["restore-a", "restore-b", "restore-c"]) remove(id);
  const initialSize = queueSize();
  const a = { playerId: "restore-a", armyPower: 100, leagueTier: 2 };
  const b = { playerId: "restore-b", armyPower: 110, leagueTier: 2 };

  assert.equal(restoreWaiting([a, b, a], 5_000), 2);
  assert.equal(queueSize(), initialSize + 2, "restoration must not pair the restored entries together");
  assert.ok(["restore-a", "restore-b"].includes(
    enqueue({ playerId: "restore-c", armyPower: 105, leagueTier: 2 }) ?? "",
  ));
  assert.equal(queueSize(), initialSize + 1);

  for (const id of ["restore-a", "restore-b", "restore-c"]) remove(id);
  assert.equal(queueSize(), initialSize);
});

test("failed-admission restoration validates the complete batch before queue mutation", () => {
  for (const id of ["restore-atomic", "restore-atomic-opponent"]) remove(id);
  const initialSize = queueSize();
  const valid = { playerId: "restore-atomic", armyPower: 100, leagueTier: 2 };

  assert.equal(enqueue(valid), null);
  assert.throws(
    () => restoreWaiting([
      { ...valid, leagueTier: 0 },
      valid,
    ], 5_000),
    /queue entry is invalid/i,
    "a valid last duplicate must not hide an invalid earlier snapshot",
  );
  assert.equal(queueSize(), initialSize + 1);
  assert.equal(
    enqueue({ playerId: "restore-atomic-opponent", armyPower: 100, leagueTier: 2 }),
    "restore-atomic",
  );
  assert.equal(queueSize(), initialSize);
});

test("distributed restoration rejects an invalid clock before producing Redis payloads", () => {
  assert.throws(
    () => buildRestoredQueueEntries([
      { playerId: "restore-clock", armyPower: 1, leagueTier: 1 },
    ], 1.5),
    /queue entry is invalid/i,
  );
});
