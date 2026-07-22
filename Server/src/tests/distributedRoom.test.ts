import assert from "node:assert/strict";
import test from "node:test";
import {
  distributedRoomJoinState,
  hasStartedMatchAuthority,
  type MatchDoc,
} from "../services/matchService";

function match(joinedPlayerIds?: string[]): MatchDoc {
  return {
    matchId: "match-1",
    state: "active",
    players: [
      { playerId: "a", name: "A", armyPower: 10, leagueTier: 1 },
      { playerId: "b", name: "B", armyPower: 10, leagueTier: 1 },
    ],
    ...(joinedPlayerIds ? { joinedPlayerIds } : {}),
    createdAt: new Date(),
  };
}

test("distributed room starts only after both distinct assigned players join", () => {
  assert.deepEqual(distributedRoomJoinState(match()), {
    allowedPlayerIds: ["a", "b"],
    joinedPlayerIds: [],
    ready: false,
  });
  assert.equal(distributedRoomJoinState(match(["a", "a", "intruder"])).ready, false);
  assert.deepEqual(distributedRoomJoinState(match(["b", "a", "intruder"])), {
    allowedPlayerIds: ["a", "b"],
    joinedPlayerIds: ["b", "a"],
    ready: true,
  });
});

test("gameplay authority requires both durable joins and the one-time room-start marker", () => {
  assert.equal(hasStartedMatchAuthority(match()), false);
  assert.equal(hasStartedMatchAuthority(match(["a", "b"])), false);
  assert.equal(hasStartedMatchAuthority({
    ...match(["a"]),
    roomStartedAt: new Date(),
  }), false);
  assert.equal(hasStartedMatchAuthority({
    ...match(["a", "b"]),
    roomStartedAt: new Date(),
  }), true);
});
