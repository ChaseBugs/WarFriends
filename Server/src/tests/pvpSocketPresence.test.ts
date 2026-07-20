import assert from "node:assert/strict";
import test from "node:test";
import { pvpSocketOwner } from "../services/pvpSocketPresenceService";

test("distributed socket ownership binds one hub instance to one connection", () => {
  assert.equal(pvpSocketOwner("hub-a", "client-1"), "hub-a:client-1");
  assert.notEqual(pvpSocketOwner("hub-a", "client-1"), pvpSocketOwner("hub-b", "client-1"));
});
