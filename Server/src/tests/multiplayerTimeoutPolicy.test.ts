import assert from "node:assert/strict";
import test from "node:test";
import {
  matchmakingTimeoutSeconds,
  matchDisconnectGraceSeconds,
  matchJoinTimeoutSeconds,
  matchResultConsensusTimeoutMilliseconds,
} from "../services/multiplayerTimeoutPolicyService";

test("multiplayer timeout policy preserves exact supported deployment values", () => {
  assert.equal(matchmakingTimeoutSeconds(30), 30);
  assert.equal(matchJoinTimeoutSeconds(30), 30);
  assert.equal(matchDisconnectGraceSeconds(20), 20);
  assert.equal(matchResultConsensusTimeoutMilliseconds(0), 0);
  assert.equal(matchResultConsensusTimeoutMilliseconds(15_000), 15_000);
});

test("multiplayer timeout policy rejects values Node would round, overflow, or fire immediately", () => {
  for (const parser of [
    matchmakingTimeoutSeconds,
    matchJoinTimeoutSeconds,
    matchDisconnectGraceSeconds,
  ]) {
    for (const value of [Number.NaN, Number.POSITIVE_INFINITY, -1, 0, 1.5, 2_147_484]) {
      assert.throws(() => parser(value), /Multiplayer .* timeout policy is invalid/);
    }
  }
  for (const value of [Number.NaN, Number.POSITIVE_INFINITY, -1, 1.5, 15_001]) {
    assert.throws(
      () => matchResultConsensusTimeoutMilliseconds(value),
      /Multiplayer result-consensus timeout policy is invalid/,
    );
  }
});
