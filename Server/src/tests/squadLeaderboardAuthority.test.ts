import assert from "node:assert/strict";
import test from "node:test";
import type { Collection, Filter, Sort } from "mongodb";
import { AccountType, SquadRank } from "../constants";
import type { PlayerDocument, SquadDocument } from "../db";
import { newPlayer, newSquad } from "../dtos";
import { createInitialProgression } from "../services/playerStateService";
import { listByExperience, searchSquadsByName, suggestedSquads } from "../services/squadService";

const NOW = Date.now() - 10_000;

function squadDocument(name: string, squadPoints: number, experience = 0): SquadDocument {
  const squad = newSquad(name, `${name}-leader`);
  squad.squadPoints = squadPoints;
  squad.experience = experience;
  squad.members.push({
    playerId: squad.founderId,
    name: "LeaderOne",
    rank: SquadRank.Leader,
    squadPoints,
    joinedAt: NOW,
    lastSeenChatTimestamp: 0,
  });
  return {
    ...squad,
    createdAt: new Date(NOW),
    updatedAt: new Date(NOW),
  };
}

function playerDocument(skill: number, medalsBalance = 0): PlayerDocument {
  const player = newPlayer("directory-player", "DirectoryPlayer", AccountType.Guest);
  player.skill = skill;
  player.medalsBalance = medalsBalance;
  return {
    id: player.id,
    accountName: player.accountName,
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: createInitialProgression(Math.floor(NOW / 1_000)),
    createdAt: new Date(NOW),
    updatedAt: new Date(NOW),
  };
}

function squadCollection(
  rows: SquadDocument[],
  capture?: (filter: Filter<SquadDocument>, sort: Sort, limit: number) => void,
): Collection<SquadDocument> {
  let filter: Filter<SquadDocument> = {};
  let sort: Sort = {};
  let limit = 0;
  const cursor = {
    sort: (value: Sort) => {
      sort = value;
      return cursor;
    },
    limit: (value: number) => {
      limit = value;
      return cursor;
    },
    toArray: async () => {
      capture?.(filter, sort, limit);
      return rows;
    },
  };
  return {
    find: (value: Filter<SquadDocument> = {}) => {
      filter = value;
      return cursor;
    },
  } as unknown as Collection<SquadDocument>;
}

test("action 101 admits Squads by recovered Skill order with stable name ties", async () => {
  const alpha = squadDocument("Alpha Squad", 500, 1);
  const bravo = squadDocument("Bravo Squad", 500, 10_000);
  const lower = squadDocument("Lower Squad", 400, 1_000_000);
  let captured: { filter: Filter<SquadDocument>; sort: Sort; limit: number } | undefined;

  const rows = await listByExperience(3, squadCollection(
    [alpha, bravo, lower],
    (filter, sort, limit) => { captured = { filter, sort, limit }; },
  ));

  assert.deepEqual(captured, {
    filter: {},
    sort: { squadPoints: -1, name: 1 },
    limit: 3,
  });
  assert.deepEqual(rows.map((row) => row.name), ["Alpha Squad", "Bravo Squad", "Lower Squad"]);
});

test("Squad leaderboard rejects malformed and incorrectly ordered selected rows", async () => {
  const higher = squadDocument("Higher Squad", 500);
  const lower = squadDocument("Lower Squad", 400);
  await assert.rejects(
    listByExperience(2, squadCollection([lower, higher])),
    /not in authoritative rank order/,
  );

  const corrupt = squadDocument("Corrupt Squad", 600);
  corrupt.squadPoints = Number.NaN;
  await assert.rejects(
    listByExperience(1, squadCollection([corrupt])),
    /Stored squad authority is invalid/,
  );
});

test("Squad leaderboard limits are exact and bounded", async () => {
  for (const limit of [0, 101, 1.5, Number.NaN, Number.POSITIVE_INFINITY]) {
    await assert.rejects(
      listByExperience(limit, squadCollection([])),
      /limit is invalid/,
    );
  }
  await assert.rejects(
    listByExperience(1, squadCollection([
      squadDocument("First Squad", 2),
      squadDocument("Second Squad", 1),
    ])),
    /too many rows/,
  );
});

test("Squad name search uses the recovered literal case-insensitive prefix", async () => {
  const alpha = squadDocument("Alpha Squad", 100);
  const alpine = squadDocument("Alpine Squad", 90);
  let captured: { filter: Filter<SquadDocument>; sort: Sort; limit: number } | undefined;
  const rows = await searchSquadsByName(
    "Alp",
    2,
    squadCollection([alpha, alpine], (filter, sort, limit) => {
      captured = { filter, sort, limit };
    }),
  );

  assert.deepEqual(captured, {
    filter: { name: { $regex: "^Alp", $options: "i" } },
    sort: { name: 1 },
    limit: 2,
  });
  assert.deepEqual(rows.map((row) => row.name), ["Alpha Squad", "Alpine Squad"]);
  await assert.rejects(
    searchSquadsByName("Alp", 1, squadCollection([squadDocument("Other Squad", 10)])),
    /does not match the requested prefix/,
  );
});

test("Suggested Squads use authenticated global Skill and return only joinable rows", async () => {
  const player = playerDocument(100, 0);
  const open = squadDocument("Open Squad", 500);
  open.requiredMedals = 100;
  const requested = squadDocument("Request Squad", 400);
  requested.joinPolicy = 1;
  requested.requiredMedals = 50;
  let captured: { filter: Filter<SquadDocument>; sort: Sort; limit: number } | undefined;

  const rows = await suggestedSquads(
    player,
    2,
    squadCollection([open, requested], (filter, sort, limit) => {
      captured = { filter, sort, limit };
    }),
  );
  assert.deepEqual(captured, {
    filter: {
      joinPolicy: { $in: [0, 1] },
      requiredMedals: { $lte: 100 },
      $expr: { $lt: [{ $size: "$members" }, "$maxMembers"] },
    },
    sort: { squadPoints: -1, name: 1 },
    limit: 2,
  });
  assert.deepEqual(rows.map((row) => row.name), ["Open Squad", "Request Squad"]);

  const weeklyOnlyPlayer = playerDocument(0, 1_000);
  await assert.rejects(
    suggestedSquads(weeklyOnlyPlayer, 1, squadCollection([open])),
    /not eligible for the authenticated player/,
  );
  const inviteOnly = squadDocument("Invite Squad", 600);
  inviteOnly.joinPolicy = 2;
  await assert.rejects(
    suggestedSquads(player, 1, squadCollection([inviteOnly])),
    /not eligible for the authenticated player/,
  );
  const full = squadDocument("Full Squad", 600);
  full.maxMembers = 1;
  await assert.rejects(
    suggestedSquads(player, 1, squadCollection([full])),
    /not eligible for the authenticated player/,
  );
});
