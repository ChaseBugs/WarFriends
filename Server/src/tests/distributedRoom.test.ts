import assert from "node:assert/strict";
import test from "node:test";
import { distributedRoomJoinState, type MatchDoc } from "../services/matchService";

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
