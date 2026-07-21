import assert from "node:assert/strict";
import test from "node:test";
import {
  buildPvpFanoutNotice,
  completePvpCardFanout,
  parsePvpFanoutNotice,
  pvpFanoutMatchesDurableAuthority,
  type PvpFanoutMatchAuthority,
} from "../services/pvpFanoutService";

test("remote card fan-out writes a receipt only after one live socket effect", async () => {
  const operations: string[] = [];
  assert.equal(await completePvpCardFanout(
    false,
    () => { operations.push("send"); return true; },
    () => { operations.push("remember"); },
    async () => { operations.push("receipt"); return true; },
  ), "delivered");
  assert.deepEqual(operations, ["send", "remember", "receipt"]);
});

test("repeated remote card fan-out retries only its missing durable receipt", async () => {
  const operations: string[] = [];
  assert.equal(await completePvpCardFanout(
    true,
    () => { operations.push("duplicate-send"); return true; },
    () => { operations.push("duplicate-remember"); },
    async () => { operations.push("receipt"); return true; },
  ), "receipt-retried");
  assert.deepEqual(operations, ["receipt"]);

  assert.equal(await completePvpCardFanout(false, () => false, () => undefined, async () => true), "not-delivered");
});

function activeAuthority(values: Partial<PvpFanoutMatchAuthority> = {}): PvpFanoutMatchAuthority {
  return {
    matchId: "match-authority",
    players: [
      { playerId: "player-a", name: "Player A", armyPower: 100, leagueTier: 2 },
      { playerId: "player-b", name: "Player B", armyPower: 110, leagueTier: 2 },
    ],
    state: "active",
    joinedPlayerIds: ["player-a", "player-b"],
    roomStartedAt: new Date(1_000),
    ...values,
  };
}

function parsedNotice(
  targetPlayerId: string,
  authority: PvpFanoutMatchAuthority,
  envelope: { Type: string; Payload: unknown },
  sourcePlayerId?: string,
) {
  const parsed = parsePvpFanoutNotice(buildPvpFanoutNotice(
    "node-a",
    targetPlayerId,
    authority.matchId,
    envelope,
    sourcePlayerId,
  ));
  assert.ok(parsed);
  return parsed;
}

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
  assert.equal(parsePvpFanoutNotice(JSON.stringify({
    version: 1,
    originId: "node-a",
    targetPlayerId: "player-b",
    matchId: "match-1",
    trusted: true,
    envelope: { Type: "MatchStart", Payload: { MatchId: "match-1" } },
  })), null, "unknown transport authority must not survive parsing");
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
  assert.equal(parsePvpFanoutNotice(buildPvpFanoutNotice(
    "node-a",
    "player-b",
    "match-3",
    { Type: "MatchEvent", Payload: { MatchId: "match-3", Event: "CardPlayed", Data: {
      Sequence: 6,
      CardId: "card-1",
    } } },
    "player-a",
  )), null, "CardPlayed must retain the recovered six-card sequence bound");
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

test("MatchFound and MatchStart fan-out bind exact durable opponent and room authority", () => {
  const match = activeAuthority();
  const found = parsedNotice("player-b", match, {
    Type: "MatchFound",
    Payload: { MatchId: match.matchId, Opponent: "Player A" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(found, match), true);

  const forgedName = parsedNotice("player-b", match, {
    Type: "MatchFound",
    Payload: { MatchId: match.matchId, Opponent: "Forged Name" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(forgedName, match), false);

  const start = parsedNotice("player-b", match, {
    Type: "MatchStart",
    Payload: { MatchId: match.matchId },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(start, match), true);
  assert.equal(pvpFanoutMatchesDurableAuthority(start, activeAuthority({ roomStartedAt: undefined })), false);
});

test("CardPlayed fan-out must reproduce the authenticated sender's durable sequence evidence", () => {
  const match = activeAuthority({ relayedCardPlays: { "player-a": ["AMMOCRATE"] } });
  const accepted = parsedNotice("player-b", match, {
    Type: "MatchEvent",
    Payload: {
      MatchId: match.matchId,
      Event: "CardPlayed",
      Data: { Sequence: 0, CardId: "AMMOCRATE" },
    },
  }, "player-a");
  assert.equal(pvpFanoutMatchesDurableAuthority(accepted, match), true);

  const forgedCard = parsedNotice("player-b", match, {
    Type: "MatchEvent",
    Payload: {
      MatchId: match.matchId,
      Event: "CardPlayed",
      Data: { Sequence: 0, CardId: "FREEZE" },
    },
  }, "player-a");
  assert.equal(pvpFanoutMatchesDurableAuthority(forgedCard, match), false);
  assert.equal(pvpFanoutMatchesDurableAuthority(accepted, activeAuthority({ joinedPlayerIds: ["player-a"] })), false);
});

test("terminal fan-out derives winner and visible reason from durable match state", () => {
  const finished = activeAuthority({
    state: "finished",
    winnerId: "player-a",
    resultReports: { "player-a": "player-a", "player-b": "player-a" },
  });
  const normal = parsedNotice("player-b", finished, {
    Type: "MatchEnded",
    Payload: { MatchId: finished.matchId, WinnerId: "player-a" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(normal, finished), true);

  const forgedWinner = parsedNotice("player-b", finished, {
    Type: "MatchEnded",
    Payload: { MatchId: finished.matchId, WinnerId: "player-b" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(forgedWinner, finished), false);

  const forfeit = activeAuthority({ state: "finished", winnerId: "player-a", resultReports: undefined });
  const forfeitNotice = parsedNotice("player-b", forfeit, {
    Type: "MatchEnded",
    Payload: { MatchId: forfeit.matchId, WinnerId: "player-a", Reason: "OpponentForfeit" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(forfeitNotice, forfeit), true);

  const cancelled = activeAuthority({ state: "cancelled", cancelReason: "join_timeout" });
  const cancellation = parsedNotice("player-b", cancelled, {
    Type: "MatchEnded",
    Payload: { MatchId: cancelled.matchId, Reason: "JoinTimeout" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(cancellation, cancelled), true);

  const unprovenActivation = activeAuthority({
    state: "cancelled",
    cancelReason: "room_activation_presence_unproven",
  });
  const activationCancellation = parsedNotice("player-b", unprovenActivation, {
    Type: "MatchEnded",
    Payload: { MatchId: unprovenActivation.matchId, Reason: "ActivationPresenceUnproven" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(activationCancellation, unprovenActivation), true);

  const playerCancelled = activeAuthority({
    state: "cancelled",
    cancelReason: "participant_cancelled_before_start",
  });
  const playerCancellation = parsedNotice("player-b", playerCancelled, {
    Type: "MatchEnded",
    Payload: { MatchId: playerCancelled.matchId, Reason: "ParticipantCancelledBeforeStart" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(playerCancellation, playerCancelled), true);
});

test("opponent presence fan-out follows the durable disconnect clock", () => {
  const disconnected = activeAuthority({ disconnectedAt: { "player-a": new Date(2_000) } });
  const notice = parsedNotice("player-b", disconnected, {
    Type: "OpponentDisconnected",
    Payload: { MatchId: disconnected.matchId, PlayerId: "player-a" },
  });
  assert.equal(pvpFanoutMatchesDurableAuthority(notice, disconnected), true);
  assert.equal(pvpFanoutMatchesDurableAuthority(notice, activeAuthority()), false);
});
