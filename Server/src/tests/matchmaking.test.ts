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

test("distributed matchmaking snapshots accept only bounded numeric queue entries", () => {
  assert.equal(validQueueEntry({
    playerId: "queue-player",
    armyPower: 100,
    leagueTier: 2,
    enqueuedAt: Date.now(),
  }), true);
  assert.equal(validQueueEntry({ playerId: "", armyPower: 100, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: -1, leagueTier: 2, enqueuedAt: 1 }), false);
  assert.equal(validQueueEntry({ playerId: "player", armyPower: 1, leagueTier: 1.5, enqueuedAt: 1 }), false);
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
