import assert from "node:assert/strict";
import test from "node:test";
import { selectOrphanMatchIds } from "../services/matchService";
import {
  parsePvpCoordinatorLivenessObservation,
  requireInitialPvpCoordinatorHeartbeat,
} from "../services/pvpCoordinatorService";

test("distributed PvP startup requires its first coordinator ownership heartbeat", () => {
  assert.doesNotThrow(() => requireInitialPvpCoordinatorHeartbeat(true));
  assert.throws(
    () => requireInitialPvpCoordinatorHeartbeat(false),
    /heartbeat could not be established/i,
  );
});

test("orphan recovery accepts only the exact expiring coordinator owner", () => {
  assert.equal(parsePvpCoordinatorLivenessObservation([1, "node-a", 30_000], "node-a"), true);
  assert.equal(parsePvpCoordinatorLivenessObservation([0, "", -2], "node-a"), false);
  for (const malformed of [
    undefined,
    [1, "node-b", 30_000],
    [1, "node-a", -1],
    [1, "node-a", 0],
    [1, "node-a", 30_001],
    [0, "node-a", -2],
    [0, "", -1],
  ]) {
    assert.equal(parsePvpCoordinatorLivenessObservation(malformed, "node-a"), null);
  }
});

test("orphan recovery preserves live and unknown peer coordinators", async () => {
  const observations = new Map<string, boolean | null>([
    ["live-node", true],
    ["dead-node", false],
    ["redis-unknown", null],
  ]);
  const selected = await selectOrphanMatchIds([
    { matchId: "live-match", coordinatorId: "live-node" },
    { matchId: "dead-match", coordinatorId: "dead-node" },
    { matchId: "unknown-match", coordinatorId: "redis-unknown" },
    { matchId: "legacy-match" },
  ], async (coordinatorId) => observations.has(coordinatorId) ? observations.get(coordinatorId)! : false);
  assert.deepEqual(selected, ["dead-match", "legacy-match"]);
});

test("single-node recovery treats every interrupted row as orphaned", async () => {
  assert.deepEqual(await selectOrphanMatchIds([
    { matchId: "owned-match", coordinatorId: "old-process" },
    { matchId: "legacy-match" },
  ]), ["owned-match", "legacy-match"]);
});
