import assert from "node:assert/strict";
import test from "node:test";
import {
  claimPvpSocket,
  isUnidentifiedPvpSocket,
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
