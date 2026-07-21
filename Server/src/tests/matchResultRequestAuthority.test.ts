import assert from "node:assert/strict";
import test from "node:test";
import { validatedMatchResultPayload } from "../services/matchResultRequestAuthorityService";

test("WebSocket MatchResult accepts only its exact bounded identity wrapper", () => {
  const minimal = { MatchId: "match-1", WinnerId: "player-a" };
  assert.equal(validatedMatchResultPayload(minimal), minimal);

  const complete = {
    ...minimal,
    UsedCards: ["AMMOCRATE"],
    Stats: { opaque: true },
  };
  assert.equal(validatedMatchResultPayload(complete), complete);

  for (const value of [
    undefined,
    null,
    [],
    {},
    { WinnerId: "player-a" },
    { MatchId: "match-1" },
    { MatchId: "", WinnerId: "player-a" },
    { MatchId: " match-1", WinnerId: "player-a" },
    { MatchId: "match-1", WinnerId: null },
    { MatchId: "match-1", WinnerId: "player-a", winnerId: "player-b" },
    { MatchId: "match-1", WinnerId: "player-a", Extra: true },
  ]) {
    assert.throws(() => validatedMatchResultPayload(value), /MatchResult payload is invalid/u);
  }
});
