import assert from "node:assert/strict";
import test from "node:test";
import {
  claimPvpSocket,
  combinePvpParticipantLiveness,
  isUnidentifiedPvpSocket,
  parsePvpSocketLivenessObservation,
  pvpSocketOwner,
  usesDistributedPvpSocket,
} from "../services/pvpSocketPresenceService";

test("distributed socket ownership binds one hub instance to one connection", () => {
  assert.equal(pvpSocketOwner("hub-a", "client-1"), "hub-a:client-1");
  assert.notEqual(pvpSocketOwner("hub-a", "client-1"), pvpSocketOwner("hub-b", "client-1"));
});

test("one live socket cannot be rebound from its authenticated account", () => {
  assert.equal(isUnidentifiedPvpSocket(undefined), true);
  assert.equal(isUnidentifiedPvpSocket("already-authenticated-player"), false);
});

test("distributed socket mode requires a successful Redis ownership claim", () => {
  assert.equal(usesDistributedPvpSocket(null), false, "real no-Redis mode keeps the local room path");
  assert.equal(usesDistributedPvpSocket(true), true);
  assert.throws(
    () => usesDistributedPvpSocket(false),
    /ownership could not be established/i,
    "an attempted Redis write failure must not masquerade as a distributed route",
  );
});

test("an unavailable Redis coordinator is distinguished from a failed ownership write", async () => {
  assert.equal(
    await claimPvpSocket("socket-local-player", "hub-a:client-local"),
    null,
    "the test process has no connected Redis coordinator and must retain explicit local mode",
  );
});

test("disconnect settlement accepts only an exact expiring socket-owner observation", () => {
  const owner = "ce5a282d-fbb2-45ad-8df2-99a1b9568a15:441086ee-6d4a-4af2-91a2-5ae55c243f97";
  assert.equal(parsePvpSocketLivenessObservation([1, owner, 30_000]), true);
  assert.equal(parsePvpSocketLivenessObservation([0, "", -2]), false);

  for (const malformed of [
    undefined,
    [1, "not-an-owner", 30_000],
    [1, owner, -1],
    [1, owner, 0],
    [1, owner, 30_001],
    [0, owner, -2],
    [0, "", -1],
  ]) {
    assert.equal(
      parsePvpSocketLivenessObservation(malformed),
      null,
      "malformed or non-expiring liveness must remain unknown",
    );
  }
});

test("room activation requires one definite live observation for each assigned socket", () => {
  assert.equal(combinePvpParticipantLiveness([true, true]), true);
  assert.equal(combinePvpParticipantLiveness([true, false]), false);
  assert.equal(combinePvpParticipantLiveness([null, false]), false);
  assert.equal(combinePvpParticipantLiveness([true, null]), null);
  assert.equal(combinePvpParticipantLiveness([]), null);
});
