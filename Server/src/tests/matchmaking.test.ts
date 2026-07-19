import assert from "node:assert/strict";
import test from "node:test";
import { enqueue, queueSize, remove } from "../services/matchmakingService";

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
