import assert from "node:assert/strict";
import test from "node:test";
import { RoomManager } from "../gameRooms/roomManager";

test("rooms reject nonparticipants and only relay active participant traffic", () => {
  const manager = new RoomManager();
  const sent: Array<{ clientId: string; envelope: unknown }> = [];
  manager.setSender((clientId, envelope) => sent.push({ clientId, envelope }));

  assert.equal(manager.join("m1", "attacker", "c0", ["p1", "p2"]), null);
  assert.ok(manager.join("m1", "p1", "c1", ["p1", "p2"]));
  assert.equal(manager.relay("m1", "p1", { Type: "early" }), false);
  assert.ok(manager.join("m1", "p2", "c2", ["p1", "p2"]));

  sent.length = 0;
  assert.equal(manager.relay("m1", "attacker", { Type: "forged" }), false);
  assert.equal(sent.length, 0);
  assert.equal(manager.relay("m1", "p1", { Type: "valid" }), true);
  assert.deepEqual(sent, [{ clientId: "c2", envelope: { Type: "valid" } }]);
});

test("match results require matching reports from both participants", () => {
  const manager = new RoomManager();
  manager.join("m2", "p1", "c1", ["p1", "p2"]);
  manager.join("m2", "p2", "c2", ["p1", "p2"]);

  assert.equal(manager.recordResult("m2", "attacker", "p1"), "invalid");
  assert.equal(manager.recordResult("m2", "p1", "attacker"), "invalid");
  assert.equal(manager.recordResult("m2", "p1", "p1"), "pending");
  assert.equal(manager.recordResult("m2", "p2", "p1"), "confirmed");

  manager.join("m3", "p1", "c1", ["p1", "p2"]);
  manager.join("m3", "p2", "c2", ["p1", "p2"]);
  assert.equal(manager.recordResult("m3", "p1", "p1"), "pending");
  assert.equal(manager.recordResult("m3", "p2", "p2"), "conflict");
});

test("disconnect keeps the authorized room available for a legitimate reconnect", () => {
  const manager = new RoomManager();
  const sent: Array<{ clientId: string; envelope: unknown }> = [];
  manager.setSender((clientId, envelope) => sent.push({ clientId, envelope }));
  manager.join("m4", "p1", "c1", ["p1", "p2"]);
  manager.join("m4", "p2", "c2", ["p1", "p2"]);

  sent.length = 0;
  assert.deepEqual(manager.evictClient("c1"), {
    matchId: "m4",
    playerId: "p1",
    opponentId: "p2",
    wasActive: true,
  });
  assert.equal(manager.getRoom("m4")?.state, "active");
  assert.equal(manager.isParticipant("m4", "p1"), false);
  assert.equal(manager.join("m4", "attacker", "c3", ["p1", "p2"]), null);
  assert.ok(manager.join("m4", "p1", "c4", ["p1", "p2"]));
  assert.equal(manager.isParticipant("m4", "p1"), true);
  assert.equal(manager.relay("m4", "p1", { Type: "after-reconnect" }), true);
});

test("CardPlayed delivery retries only when durable evidence was not delivered before reconnect", () => {
  const manager = new RoomManager();
  const sent: Array<{ clientId: string; envelope: unknown }> = [];
  manager.setSender((clientId, envelope) => sent.push({ clientId, envelope }));
  manager.join("m5", "p1", "c1", ["p1", "p2"]);
  manager.join("m5", "p2", "c2", ["p1", "p2"]);

  const event = { Type: "MatchEvent", Payload: { Event: "CardPlayed", Sequence: 0 } };
  assert.equal(manager.relayCardEvent("m5", "p1", 0, event), "delivered");
  assert.equal(manager.relayCardEvent("m5", "p1", 0, event), "replayed");
  assert.equal(sent.filter((item) => item.envelope === event).length, 1);

  manager.evictClient("c2");
  assert.equal(manager.relayCardEvent("m5", "p1", 1, event), "invalid");
  manager.join("m5", "p2", "c3", ["p1", "p2"]);
  assert.equal(manager.relayCardEvent("m5", "p1", 1, event), "delivered");
  assert.equal(sent.filter((item) => item.clientId === "c3" && item.envelope === event).length, 1);
});
