import assert from "node:assert/strict";
import test from "node:test";
import { League } from "../constants";
import {
  MatchAdmissionError,
  type MatchPlayer,
  validateMatchParticipants,
} from "../services/matchService";

function participant(playerId: string): MatchPlayer {
  return {
    playerId,
    name: `Player ${playerId}`,
    armyPower: 150.5,
    leagueTier: League.Silver3,
  };
}

test("match admission accepts two distinct server-derived participant snapshots", () => {
  assert.doesNotThrow(() => validateMatchParticipants(participant("player-a"), participant("player-b")));
});

test("match admission rejects duplicate, corrupt, and out-of-range participants", () => {
  const valid = participant("player-a");
  for (const invalid of [
    { ...participant("player-b"), playerId: "" },
    { ...participant("player-b"), name: "bad\nname" },
    { ...participant("player-b"), armyPower: Number.NaN },
    { ...participant("player-b"), armyPower: -1 },
    { ...participant("player-b"), leagueTier: League.Champion + 1 },
  ]) {
    assert.throws(
      () => validateMatchParticipants(valid, invalid),
      (error: unknown) => error instanceof MatchAdmissionError,
    );
  }
  assert.throws(
    () => validateMatchParticipants(valid, { ...valid }),
    (error: unknown) => error instanceof MatchAdmissionError,
  );
});
