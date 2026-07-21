import assert from "node:assert/strict";
import test from "node:test";
import type { Collection, Filter, Sort } from "mongodb";
import { SquadRank } from "../constants";
import type { SquadDocument } from "../db";
import { newSquad } from "../dtos";
import { listByExperience } from "../services/squadService";

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
