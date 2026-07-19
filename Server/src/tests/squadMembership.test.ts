import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType, SquadRank } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer, newSquad, type SquadDTO } from "../dtos";
import { planSquadJoin } from "../services/squadService";

const NOW = Date.UTC(2026, 6, 20, 12, 0, 0);

function playerDocument(id: string, squadName = "", rank = SquadRank.None): PlayerDocument {
  const player = newPlayer(id, `Player-${id}`, AccountType.Guest);
  player.squadName = squadName;
  player.squadRank = rank;
  return {
    id,
    accountName: player.accountName,
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName,
    player,
    createdAt: new Date(NOW),
    updatedAt: new Date(NOW),
  };
}

function squadDocument(joinPolicy = 0): SquadDTO {
  const squad = newSquad("Atomic Squad", "leader");
  squad.joinPolicy = joinPolicy;
  squad.members.push({
    playerId: "leader",
    name: "Player-leader",
    rank: SquadRank.Leader,
    squadPoints: 0,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  });
  return squad;
}

test("open squad admission adds one member and leaves its input snapshots unchanged", () => {
  const squad = squadDocument();
  const player = playerDocument("member");
  const plan = planSquadJoin(squad, player);

  assert.equal(plan.rosterChanged, true);
  assert.equal(plan.playerMirrorChanged, true);
  assert.equal(plan.rank, SquadRank.Member);
  assert.deepEqual(plan.squad.members.map((member) => member.playerId), ["leader", "member"]);
  assert.equal(squad.members.length, 1);
  assert.equal(player.player.squadName, "");
});

test("private squad admission requires and consumes a stored invitation", () => {
  const squad = squadDocument(2);
  squad.invitedPlayerIds.push("member");
  squad.joinRequests.push({ playerId: "member", name: "Player-member", createdAt: NOW });
  const plan = planSquadJoin(squad, playerDocument("member"));

  assert.equal(plan.admissionStateChanged, true);
  assert.deepEqual(plan.squad.invitedPlayerIds, []);
  assert.deepEqual(plan.squad.joinRequests, []);
  assert.throws(
    () => planSquadJoin(squadDocument(2), playerDocument("outsider")),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.InsufficientRank,
  );
});

test("manager approval validates current authority and the target request in one snapshot", () => {
  const squad = squadDocument(1);
  squad.joinRequests.push({ playerId: "member", name: "Player-member", createdAt: NOW });
  const accepted = planSquadJoin(squad, playerDocument("member"), "leader");

  assert.equal(accepted.rosterChanged, true);
  assert.deepEqual(accepted.squad.joinRequests, []);
  assert.throws(
    () => planSquadJoin(squad, playerDocument("member"), "outsider"),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotSquadMember,
  );
  assert.throws(
    () => planSquadJoin(squadDocument(1), playerDocument("member"), "leader"),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotSquadMember,
  );
});

test("capacity and medal requirements are rechecked at the admission snapshot", () => {
  const full = squadDocument();
  full.maxMembers = 1;
  assert.throws(
    () => planSquadJoin(full, playerDocument("member")),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.SquadFull,
  );

  const gated = squadDocument();
  gated.requiredMedals = 10;
  assert.throws(
    () => planSquadJoin(gated, playerDocument("member")),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.InsufficientRank,
  );
});

test("idempotent admission repairs a missing player mirror without duplicating the roster", () => {
  const squad = squadDocument();
  squad.members.push({
    playerId: "veteran",
    name: "Player-veteran",
    rank: SquadRank.Veteran,
    squadPoints: 5,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  });
  const plan = planSquadJoin(squad, playerDocument("veteran"));

  assert.equal(plan.rosterChanged, false);
  assert.equal(plan.playerMirrorChanged, true);
  assert.equal(plan.rank, SquadRank.Veteran);
  assert.equal(plan.squad.members.length, 2);
});

test("admission never overwrites either mirror of membership in another squad", () => {
  const nestedConflict = playerDocument("nested", "Other Squad", SquadRank.Member);
  assert.throws(
    () => planSquadJoin(squadDocument(), nestedConflict),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotSquadMember,
  );

  const rootConflict = playerDocument("root");
  rootConflict.squadName = "Other Squad";
  assert.throws(
    () => planSquadJoin(squadDocument(), rootConflict),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotSquadMember,
  );
});
