import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType, SquadRank } from "../constants";
import type { PlayerDocument, SquadDocument } from "../db";
import { newPlayer, newSquad, type SquadDTO } from "../dtos";
import { createInitialProgression } from "../services/playerStateService";
import { reclaimDepositedCardsForDepartureState } from "../services/squadCardPoolService";
import {
  planLeadershipTransfer,
  planDeclineSquadJoinRequest,
  planSquadInvitation,
  planSquadJoin,
  planSquadKick,
  planSquadLeave,
  planSquadRankChange,
  squadJoinRequestDisposition,
} from "../services/squadService";
import {
  validatedSquadDocument,
  validatedSquadEmblem,
} from "../services/squadAuthorityService";

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

function durableSquad(overrides: Partial<SquadDocument> = {}): SquadDocument {
  return {
    ...squadDocument(),
    createdAt: new Date(NOW),
    updatedAt: new Date(NOW),
    ...overrides,
  };
}

test("complete squad authority binds roster leadership, admission identities, counters, and clocks", () => {
  const now = new Date(NOW + 1_000);
  const squad = durableSquad();
  assert.equal(validatedSquadDocument(squad, now), squad);
  assert.deepEqual(validatedSquadEmblem({ id: "menu-squad-1" }), { id: "menu-squad-1" });

  assert.throws(
    () => validatedSquadDocument({
      ...squad,
      members: [...squad.members, { ...squad.members[0]!, playerId: "leader-2" }],
    }, now),
    /Stored squad authority is invalid/u,
  );
  assert.throws(
    () => validatedSquadDocument({ ...squad, squadPoints: Number.NaN }, now),
    /Stored squad authority is invalid/u,
  );
  assert.throws(
    () => validatedSquadDocument({
      ...squad,
      joinRequests: [{ playerId: "leader", name: "Player-leader", createdAt: NOW }],
    }, now),
    /Stored squad authority is invalid/u,
  );
  assert.throws(
    () => validatedSquadDocument({ ...squad, updatedAt: new Date(now.getTime() + 1) }, now),
    /Stored squad authority is invalid/u,
  );
  assert.throws(
    () => validatedSquadEmblem({ id: "menu-squad-1", forged: true }),
    /Stored squad authority is invalid/u,
  );
});

test("squad failures use the exact recovered IJEAJGCCHEF numeric contract", () => {
  assert.equal(ApiErrorCode.SquadIsFull, 3801);
  assert.equal(ApiErrorCode.NotEnoughSquadSkill, 3803);
  assert.equal(ApiErrorCode.SquadIsNotPublic, 3804);
  assert.equal(ApiErrorCode.SquadNoLongerExists, 3805);
  assert.equal(ApiErrorCode.SquadLeaveError, 4901);
  assert.equal(ApiErrorCode.PromotePlayerError, 5501);
  assert.equal(ApiErrorCode.PromoteToFounderError, 5701);
  assert.equal(ApiErrorCode.DemotePlayerError, 5801);
  assert.equal(ApiErrorCode.KickPlayerError, 5802);
  assert.equal(ApiErrorCode.PlayerAlreadyInSquad, 13301);
  assert.equal(ApiErrorCode.SquadJoinRequestNotExists, 13302);
});

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
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.SquadIsNotPublic,
  );
});

test("join-request action preserves request-required and invite-only policy", () => {
  const open = squadDocument(0);
  assert.equal(squadJoinRequestDisposition(open, "member"), "join");

  const requestRequired = squadDocument(1);
  assert.equal(squadJoinRequestDisposition(requestRequired, "member"), "request");

  const inviteOnly = squadDocument(2);
  assert.equal(squadJoinRequestDisposition(inviteOnly, "member"), "reject");
  inviteOnly.invitedPlayerIds.push("member");
  assert.equal(squadJoinRequestDisposition(inviteOnly, "member"), "join");

  assert.throws(
    () => squadJoinRequestDisposition({ joinPolicy: 3, invitedPlayerIds: [] }, "member"),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.InternalServerError,
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
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotLeaderOfSquad,
  );
  assert.throws(
    () => planSquadJoin(squadDocument(1), playerDocument("member"), "leader"),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.SquadJoinRequestNotExists,
  );
});

test("declining a join request removes only the recovered applicant and replays without a change", () => {
  const squad = squadDocument(1);
  squad.joinRequests.push(
    { playerId: "first", name: "Player-first", createdAt: NOW },
    { playerId: "second", name: "Player-second", createdAt: NOW },
  );

  const declined = planDeclineSquadJoinRequest(squad, "leader", "first");
  assert.equal(declined.changed, true);
  assert.deepEqual(declined.squad.joinRequests.map((request) => request.playerId), ["second"]);
  assert.equal(squad.joinRequests.length, 2);

  const replay = planDeclineSquadJoinRequest(declined.squad, "leader", "first");
  assert.equal(replay.changed, false);
  assert.equal(replay.squad, declined.squad);
  assert.throws(
    () => planDeclineSquadJoinRequest(squad, "outsider", "first"),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotLeaderOfSquad,
  );
});

test("squad invitations are membership-aware capabilities with no-write exact replay", () => {
  const squad = squadDocument(2);
  const target = playerDocument("member");
  const invited = planSquadInvitation(squad, "leader", target);

  assert.equal(invited.changed, true);
  assert.deepEqual(invited.squad.invitedPlayerIds, ["member"]);
  assert.deepEqual(squad.invitedPlayerIds, []);

  const replay = planSquadInvitation(invited.squad, "leader", target);
  assert.equal(replay.changed, false);
  assert.equal(replay.squad, invited.squad);

  assert.throws(
    () => planSquadInvitation(squad, "leader", playerDocument("owned", "Other Squad")),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.PlayerAlreadyInSquad,
  );
  const rootOwned = playerDocument("root-owned");
  rootOwned.squadName = "Other Squad";
  assert.throws(
    () => planSquadInvitation(squad, "leader", rootOwned),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.PlayerAlreadyInSquad,
  );
  assert.throws(
    () => planSquadInvitation(squad, "outsider", target),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.OnlyLeaderCanSendInvites,
  );
});

test("capacity and medal requirements are rechecked at the admission snapshot", () => {
  const full = squadDocument();
  full.maxMembers = 1;
  assert.throws(
    () => planSquadJoin(full, playerDocument("member")),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.SquadIsFull,
  );

  const gated = squadDocument();
  gated.requiredMedals = 10;
  assert.throws(
    () => planSquadJoin(gated, playerDocument("member")),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotEnoughSquadSkill,
  );

  // SquadRecord compares SkillRequirement to DatabasePlayer.skill (global medals), not the
  // separately reset weekly Player League MedalsBalance field.
  const globallyEligible = playerDocument("global-medals");
  globallyEligible.player.skill = 10;
  globallyEligible.player.medalsBalance = 0;
  assert.equal(planSquadJoin(gated, globallyEligible).rosterChanged, true);

  const weeklyOnly = playerDocument("weekly-medals");
  weeklyOnly.player.skill = 0;
  weeklyOnly.player.medalsBalance = 10;
  assert.throws(
    () => planSquadJoin(gated, weeklyOnly),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.NotEnoughSquadSkill,
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
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.PlayerAlreadyInSquadCantJoin,
  );

  const rootConflict = playerDocument("root");
  rootConflict.squadName = "Other Squad";
  assert.throws(
    () => planSquadJoin(squadDocument(), rootConflict),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.PlayerAlreadyInSquadCantJoin,
  );
});

test("member departure removes one roster entry without mutating its input snapshot", () => {
  const squad = squadDocument();
  squad.members.push({
    playerId: "member",
    name: "Player-member",
    rank: SquadRank.Member,
    squadPoints: 0,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  });
  const player = playerDocument("member", squad.name, SquadRank.Member);
  const plan = planSquadLeave(squad, player, squad.name);

  assert.equal(plan.squadWrite, "update");
  assert.equal(plan.departed, true);
  assert.deepEqual(plan.squad?.members.map((member) => member.playerId), ["leader"]);
  assert.equal(squad.members.length, 2);
  assert.equal(player.player.squadName, squad.name);
});

test("last member deletes the squad while a multi-member founder must transfer leadership", () => {
  const single = squadDocument();
  const leader = playerDocument("leader", single.name, SquadRank.Leader);
  assert.equal(planSquadLeave(single, leader, "").squadWrite, "delete");

  const multi = squadDocument();
  multi.members.push({
    playerId: "member",
    name: "Player-member",
    rank: SquadRank.Member,
    squadPoints: 0,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  });
  assert.throws(
    () => planSquadLeave(multi, leader, multi.name),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.SquadLeaveError,
  );
});

test("leave replay repairs stale mirrors but cannot clear membership in another squad", () => {
  const stale = playerDocument("member", "Deleted Squad", SquadRank.Member);
  const repair = planSquadLeave(null, stale, "Deleted Squad");
  assert.equal(repair.squadWrite, "none");
  assert.equal(repair.playerMirrorChanged, true);
  assert.equal(repair.departed, true);

  const clean = playerDocument("member");
  assert.equal(planSquadLeave(null, clean, "Deleted Squad").departed, false);
  assert.throws(
    () => planSquadLeave(null, stale, "Forged Squad"),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.SquadLeaveError,
  );
});

test("departure returns deposited normal-card amounts as repeated stock response IDs", () => {
  const initial = createInitialProgression(Math.floor(NOW / 1_000));
  initial.cardInventory!.cardData.AMMOCRATE = { amount: 1 };
  const result = reclaimDepositedCardsForDepartureState(initial, {
    AMMOCRATE: JSON.stringify({ amount: 2 }),
  });

  assert.deepEqual(result.returnedCardIds, ["AMMOCRATE", "AMMOCRATE"]);
  assert.equal(result.cardInventory.cardData.AMMOCRATE?.amount, 3);
  assert.equal(result.state.revision, initial.revision + 1);
  assert.equal(initial.cardInventory!.cardData.AMMOCRATE?.amount, 1);
});

test("departure clears a temporary Buddy projection without granting its dynamic ID", () => {
  const initial = createInitialProgression(Math.floor(NOW / 1_000));
  const result = reclaimDepositedCardsForDepartureState(initial, {
    "member-1784558400": JSON.stringify({
      amount: 1,
      buddyName: "Player-member",
      equippedVisuals: {},
      unityType: 0,
      primaryWeapon: 0,
      secondaryWeapon: -1,
      armypower: 0,
      level: 0,
    }),
  });

  assert.deepEqual(result.returnedCardIds, []);
  assert.equal(result.state, initial);
});

test("rank planning applies exactly one promotion or demotion step", () => {
  const squad = squadDocument();
  squad.members.push({
    playerId: "member",
    name: "Player-member",
    rank: SquadRank.Member,
    squadPoints: 0,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  });
  const promoted = planSquadRankChange(squad, "leader", "member", "promote", SquadRank.Member);
  const promotedRank = promoted.squad.members.find((member) => member.playerId === "member")?.rank;
  const demoted = planSquadRankChange(
    promoted.squad,
    "leader",
    "member",
    "demote",
    SquadRank.Veteran,
  );

  assert.equal(promoted.rank, SquadRank.Veteran);
  assert.equal(promotedRank, SquadRank.Veteran);
  assert.equal(demoted.rank, SquadRank.Member);
  assert.equal(squad.members.find((member) => member.playerId === "member")?.rank, SquadRank.Member);
  assert.throws(
    () => planSquadRankChange(promoted.squad, "leader", "member", "promote", SquadRank.Member),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.PromotePlayerError,
  );
});

test("rank planning enforces explicit authority instead of numeric enum order", () => {
  const squad = squadDocument();
  squad.members.push(
    {
      playerId: "coleader",
      name: "Player-coleader",
      rank: SquadRank.Coleader,
      squadPoints: 0,
      joinedAt: NOW,
      lastSeenChatTimestamp: 0,
    },
    {
      playerId: "veteran",
      name: "Player-veteran",
      rank: SquadRank.Veteran,
      squadPoints: 0,
      joinedAt: NOW,
      lastSeenChatTimestamp: 0,
    },
  );
  assert.throws(
    () => planSquadRankChange(squad, "coleader", "veteran", "promote", SquadRank.Veteran),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.PromotePlayerError,
  );
  assert.throws(
    () => planSquadRankChange(squad, "coleader", "leader", "demote", SquadRank.Leader),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.DemotePlayerError,
  );
});

test("leadership transfer uses the stock Leader-to-Veteran result", () => {
  const squad = squadDocument();
  squad.members.push({
    playerId: "successor",
    name: "Player-successor",
    rank: SquadRank.Coleader,
    squadPoints: 0,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  });
  const plan = planLeadershipTransfer(squad, "leader", "successor");

  assert.equal(plan.squad.founderId, "successor");
  assert.equal(plan.formerLeaderRank, SquadRank.Veteran);
  assert.equal(plan.squad.members.find((member) => member.playerId === "leader")?.rank, SquadRank.Veteran);
  assert.equal(plan.squad.members.find((member) => member.playerId === "successor")?.rank, SquadRank.Leader);
  assert.equal(squad.founderId, "leader");
});

test("kick planning removes only a strictly lower-ranked non-founder target", () => {
  const squad = squadDocument();
  squad.members.push({
    playerId: "member",
    name: "Player-member",
    rank: SquadRank.Member,
    squadPoints: 0,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  });
  const plan = planSquadKick(squad, "leader", "member");
  assert.deepEqual(plan.squad.members.map((member) => member.playerId), ["leader"]);
  assert.equal(squad.members.length, 2);
  assert.throws(
    () => planSquadKick(squad, "leader", "leader"),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.KickPlayerError,
  );
});
