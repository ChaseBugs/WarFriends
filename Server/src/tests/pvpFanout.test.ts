import assert from "node:assert/strict";
import test from "node:test";
import { buildPvpFanoutNotice, parsePvpFanoutNotice } from "../services/pvpFanoutService";

test("PvP fan-out accepts only bounded MatchFound delivery notices", () => {
  const encoded = buildPvpFanoutNotice("node-a", "player-b", "match-1", {
    Type: "MatchFound",
    Payload: { MatchId: "match-1", Opponent: "Player A" },
  });
  assert.deepEqual(parsePvpFanoutNotice(encoded), {
    version: 1,
    originId: "node-a",
    targetPlayerId: "player-b",
    matchId: "match-1",
    envelope: { Type: "MatchFound", Payload: { MatchId: "match-1", Opponent: "Player A" } },
  });
  assert.equal(parsePvpFanoutNotice(JSON.stringify({
    version: 1,
    originId: "node-a",
    targetPlayerId: "player-b",
    matchId: "match-1",
    envelope: { Type: "MatchEnded" },
  })), null);
  assert.equal(parsePvpFanoutNotice(buildPvpFanoutNotice("node-a", "player-b", "match-1", {
    Type: "MatchFound",
    Payload: { MatchId: "different-match", Opponent: "Player A" },
  })), null);
  assert.equal(parsePvpFanoutNotice("x".repeat(32_769)), null);
});

test("PvP fan-out rejects malformed identities and JSON", () => {
  assert.equal(parsePvpFanoutNotice("{"), null);
  assert.equal(parsePvpFanoutNotice(JSON.stringify({
    version: 1,
    originId: "",
    targetPlayerId: "player-b",
    matchId: "match-1",
    envelope: { Type: "MatchFound" },
  })), null);
});

test("PvP fan-out accepts a start instruction bound to the same durable match", () => {
  const encoded = buildPvpFanoutNotice("node-b", "player-a", "match-2", {
    Type: "MatchStart",
    Payload: { MatchId: "match-2" },
  });
  assert.equal(parsePvpFanoutNotice(encoded)?.envelope.Type, "MatchStart");
});

test("PvP event fan-out requires an authenticated bounded source identity", () => {
  const event = {
    Type: "MatchEvent",
    Payload: { MatchId: "match-3", Event: "CardPlayed", Data: { Sequence: 0, CardId: "card-1" } },
  };
  const encoded = buildPvpFanoutNotice("node-a", "player-b", "match-3", event, "player-a");
  assert.equal(parsePvpFanoutNotice(encoded)?.sourcePlayerId, "player-a");
  assert.equal(parsePvpFanoutNotice(buildPvpFanoutNotice(
    "node-a",
    "player-b",
    "match-3",
    event,
  )), null);
});

test("PvP terminal fan-out remains match-bound", () => {
  assert.equal(parsePvpFanoutNotice(buildPvpFanoutNotice("node-a", "player-b", "match-4", {
    Type: "MatchEnded",
    Payload: { MatchId: "match-4", WinnerId: "player-a" },
  }))?.envelope.Type, "MatchEnded");
});

test("PvP opponent presence notifications identify the other assigned player", () => {
  for (const type of ["OpponentDisconnected", "OpponentReconnected"]) {
    const encoded = buildPvpFanoutNotice("node-a", "player-b", "match-5", {
      Type: type,
      Payload: { MatchId: "match-5", PlayerId: "player-a" },
    });
    assert.equal(parsePvpFanoutNotice(encoded)?.envelope.Type, type);
  }
});
