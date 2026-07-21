import assert from "node:assert/strict";
import test from "node:test";
import {
  validatedIdentifyPayload,
  validatedJoinMatchPayload,
  validatedMatchEventPayload,
  validatedMatchResultPayload,
  validatedSendSquadChatPayload,
  validatedSquadChatHistoryPayload,
} from "../services/gameHubRequestAuthorityService";

test("WebSocket Identify accepts only one exact bounded credential pair", () => {
  const valid = { PlayerId: "player-a", Token: "token-value" };
  assert.equal(validatedIdentifyPayload(valid), valid);
  for (const value of [
    undefined,
    null,
    [],
    {},
    { PlayerId: "player-a" },
    { Token: "token-value" },
    { PlayerId: " player-a", Token: "token-value" },
    { PlayerId: "player-a", Token: "" },
    { PlayerId: "player-a", Token: "token-value", playerId: "player-b" },
    { PlayerId: "player-a", Token: "token-value", Password: "other" },
  ]) {
    assert.throws(() => validatedIdentifyPayload(value), /Identify payload is invalid/u);
  }
});

test("WebSocket JoinMatch accepts only its exact bounded match identity", () => {
  const valid = { MatchId: "match-1" };
  assert.equal(validatedJoinMatchPayload(valid), valid);
  for (const value of [
    undefined,
    null,
    [],
    {},
    { MatchId: "" },
    { MatchId: " match-1" },
    { MatchId: 1 },
    { MatchId: "match-1", matchId: "match-2" },
  ]) {
    assert.throws(() => validatedJoinMatchPayload(value), /JoinMatch payload is invalid/u);
  }
});

test("WebSocket MatchEvent validates only its wrapper while retaining opaque Data", () => {
  const minimal = { MatchId: "match-1", Event: "Damage" };
  assert.equal(validatedMatchEventPayload(minimal), minimal);
  const withData = { ...minimal, Data: { opaque: true } };
  assert.equal(validatedMatchEventPayload(withData), withData);

  for (const value of [
    undefined,
    null,
    [],
    {},
    { MatchId: "match-1" },
    { Event: "Damage" },
    { MatchId: "match-1", Event: "" },
    { MatchId: "match-1", Event: " Damage" },
    { MatchId: "match-1", Event: "Damage", event: "Other" },
  ]) {
    assert.throws(() => validatedMatchEventPayload(value), /MatchEvent payload is invalid/u);
  }
});

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

test("WebSocket Squad Chat history distinguishes an absent cursor from malformed presence", () => {
  assert.deepEqual(validatedSquadChatHistoryPayload(undefined), {});
  const latest = {};
  assert.equal(validatedSquadChatHistoryPayload(latest), latest);
  const older = { BeforeCursor: "v1:opaque-cursor" };
  assert.equal(validatedSquadChatHistoryPayload(older), older);

  for (const value of [
    null,
    [],
    { BeforeCursor: undefined },
    { BeforeCursor: null },
    { BeforeCursor: 1 },
    { beforeCursor: "v1:opaque-cursor" },
    { BeforeCursor: "v1:opaque-cursor", Extra: true },
  ]) {
    assert.throws(() => validatedSquadChatHistoryPayload(value), /GetSquadChatHistory payload is invalid/u);
  }
});

test("WebSocket SendSquadChat accepts only its exact string wrapper", () => {
  const valid = { ClientMessageId: "message-1", Text: "Squad ready" };
  assert.equal(validatedSendSquadChatPayload(valid), valid);

  for (const value of [
    undefined,
    null,
    [],
    {},
    { ClientMessageId: "message-1" },
    { Text: "Squad ready" },
    { ClientMessageId: 1, Text: "Squad ready" },
    { ClientMessageId: "message-1", Text: null },
    { clientMessageId: "message-1", Text: "Squad ready" },
    { ClientMessageId: "message-1", Text: "Squad ready", SenderId: "player-b" },
  ]) {
    assert.throws(() => validatedSendSquadChatPayload(value), /SendSquadChat payload is invalid/u);
  }
});
