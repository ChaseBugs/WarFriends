import assert from "node:assert/strict";
import test from "node:test";
import {
  exactLeaderboardCacheTtlSeconds,
  leaderboardCachePolicy,
} from "../services/leaderboardCachePolicyService";
import { redisReplaceSortedSet } from "../redis";

test("leaderboard cache uses one immutable exact startup TTL", () => {
  assert.equal(Object.isFrozen(leaderboardCachePolicy()), true);
  assert.deepEqual(leaderboardCachePolicy(), { ttlSeconds: 15 });
  assert.deepEqual(leaderboardCachePolicy({ ttlSeconds: 60 }), { ttlSeconds: 60 });
});

test("leaderboard cache TTL rejects permanent, fractional, and excessive snapshots", () => {
  for (const value of [Number.NaN, Number.POSITIVE_INFINITY, 0, 0.5, 3_601]) {
    assert.throws(
      () => exactLeaderboardCacheTtlSeconds(value),
      /Leaderboard cache TTL policy is invalid/,
    );
  }
});

test("leaderboard cache replacement rejects unsafe or ambiguous Redis members before I/O", async () => {
  await assert.rejects(
    redisReplaceSortedSet("leaderboard", [
      { score: 10, member: "same-player" },
      { score: 9, member: "same-player" },
    ], 15),
    /Redis sorted-set snapshot is invalid/,
  );
  await assert.rejects(
    redisReplaceSortedSet("leaderboard", [{ score: Number.NaN, member: "player" }], 15),
    /Redis sorted-set snapshot is invalid/,
  );
  await assert.rejects(
    redisReplaceSortedSet("leaderboard", [{ score: 10, member: "player\n2" }], 15),
    /Redis sorted-set snapshot is invalid/,
  );
});
