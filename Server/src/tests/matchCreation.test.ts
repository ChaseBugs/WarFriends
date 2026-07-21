import assert from "node:assert/strict";
import test from "node:test";
import { League } from "../constants";
import {
  cancellationRequiresUnstartedRoom,
  MatchAdmissionError,
  normalizeMatchCancelReason,
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

test("match cancellation reasons remain bounded machine-readable audit values", () => {
  assert.equal(normalizeMatchCancelReason("  server_restart  "), "server_restart");
  for (const invalid of ["", "contains spaces", "bad\nreason", "x".repeat(65)]) {
    assert.throws(
      () => normalizeMatchCancelReason(invalid),
      (error: unknown) => error instanceof MatchAdmissionError,
    );
  }
});

test("queue and participant cancellation callbacks cannot cancel a started room", () => {
  assert.equal(cancellationRequiresUnstartedRoom("join_timeout"), true);
  assert.equal(cancellationRequiresUnstartedRoom("participant_cancelled_before_start"), true);
  assert.equal(cancellationRequiresUnstartedRoom("both_players_disconnected"), false);
  assert.equal(cancellationRequiresUnstartedRoom("server_restart"), false);
});

test("match admission rejects duplicate, corrupt, and out-of-range participants", () => {
  const valid = participant("player-a");
  for (const invalid of [
    { ...participant("player-b"), playerId: "" },
    { ...participant("player-b"), playerId: "unsafe.path" },
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
