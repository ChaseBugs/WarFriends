import assert from "node:assert/strict";
import test from "node:test";
import { AccountType, SquadRank } from "../constants";
import type { PlayerDocument, SquadDocument } from "../db";
import { newPlayer, newSquad } from "../dtos";
import { createInitialProgression } from "../services/playerStateService";
import { inspectSquadIntegrity } from "../services/squadIntegrityService";

const NOW = Date.UTC(2026, 6, 20, 12, 0, 0) / 1_000;

function playerDocument(id: string): PlayerDocument {
  const player = newPlayer(id, `Player-${id}`, AccountType.Guest);
  return {
    id,
    accountName: player.accountName,
    authToken: "token",
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: "",
    player,
    progression: createInitialProgression(NOW),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

function squadDocument(name: string, founderId: string): SquadDocument {
  return {
    ...newSquad(name, founderId),
    members: [{
      playerId: founderId,
      name: `Player-${founderId}`,
      rank: SquadRank.Leader,
      squadPoints: 0,
      joinedAt: NOW,
      lastSeenChatTimestamp: 0,
    }],
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

test("integrity audit plans authoritative roster-to-player mirror repair", () => {
  const player = playerDocument("leader");
  const report = inspectSquadIntegrity([squadDocument("Alpha", player.id)], [player]);

  assert.deepEqual(report.issues.map((issue) => issue.code), ["PLAYER_MIRROR_MISMATCH"]);
  assert.equal(report.repairs.length, 1);
  assert.equal(report.repairs[0]?.squadName, "Alpha");
  assert.equal(report.repairs[0]?.squadRank, SquadRank.Leader);
});

test("integrity audit returns orphaned normal cards before clearing stale membership", () => {
  const player = playerDocument("orphan");
  player.squadName = "Deleted Squad";
  player.player.squadName = "Deleted Squad";
  player.player.squadRank = SquadRank.Member;
  player.player.depositedCardsDic = { AMMOCRATE: JSON.stringify({ amount: 2 }) };

  const report = inspectSquadIntegrity([], [player]);
  const repair = report.repairs[0]!;
  assert.deepEqual(report.issues.map((issue) => issue.code), [
    "PLAYER_MIRROR_MISMATCH",
    "ORPHANED_DEPOSITED_CARDS",
  ]);
  assert.equal(repair.clearDepositedCards, true);
  assert.equal(repair.progression?.cardInventory?.cardData.AMMOCRATE?.amount, 2);
  assert.equal(repair.progression?.revision, player.progression!.revision + 1);
});

test("integrity audit never guesses authority for duplicate cross-squad membership", () => {
  const player = playerDocument("duplicate");
  const alpha = squadDocument("Alpha", player.id);
  const bravo = squadDocument("Bravo", player.id);
  const report = inspectSquadIntegrity([alpha, bravo], [player]);

  assert.equal(report.issues.some((issue) => issue.code === "MULTIPLE_SQUAD_MEMBERSHIPS"), true);
  assert.equal(report.repairs.length, 0);
});

test("integrity audit reports broken founder and leader rosters for manual resolution", () => {
  const member = playerDocument("member");
  const squad = squadDocument("Broken", "missing-founder");
  squad.members = [{
    playerId: member.id,
    name: member.player.accountName,
    rank: SquadRank.Member,
    squadPoints: 0,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  }];
  const report = inspectSquadIntegrity([squad], [member]);

  assert.equal(report.issues.some((issue) => issue.code === "FOUNDER_NOT_IN_ROSTER" && !issue.repairable), true);
  assert.equal(report.issues.some((issue) => issue.code === "INVALID_LEADER_SET" && !issue.repairable), true);
  assert.equal(report.repairs.length, 0);
});
