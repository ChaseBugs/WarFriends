import assert from "node:assert/strict";
import test from "node:test";
import type { Collection, Filter, Sort } from "mongodb";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { playerRank, topPlayersByExperience } from "../services/leaderboardService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = 1_900_000_000;

function playerDocument(id: string, name: string, experience: number, country = "US"): PlayerDocument {
  const player = newPlayer(id, name, AccountType.Guest);
  player.experience = experience;
  player.country = country;
  return {
    id: player.id,
    accountName: player.accountName,
    authToken: "a".repeat(64),
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: createInitialProgression(NOW),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

function topCollection(
  rows: PlayerDocument[],
  capture?: (filter: Filter<PlayerDocument>, sort: Sort, limit: number) => void,
): Collection<PlayerDocument> {
  let filter: Filter<PlayerDocument> = {};
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
    find: (value: Filter<PlayerDocument>) => {
      filter = value;
      return cursor;
    },
  } as unknown as Collection<PlayerDocument>;
}

function rankCollection(
  current: PlayerDocument | null,
  ahead: PlayerDocument[],
  capture?: (filter: Filter<PlayerDocument>) => void,
): Collection<PlayerDocument> {
  return {
    findOne: async () => current,
    find: (filter: Filter<PlayerDocument>) => {
      capture?.(filter);
      return {
        async *[Symbol.asyncIterator]() {
          for (const row of ahead) yield row;
        },
      };
    },
  } as unknown as Collection<PlayerDocument>;
}

test("experience leaderboards use deterministic global and country ordering", async () => {
  const first = playerDocument("experience-a", "Alpha", 200);
  const second = playerDocument("experience-b", "Bravo", 200);
  const third = playerDocument("experience-c", "Charlie", 150);
  let captured: { filter: Filter<PlayerDocument>; sort: Sort; limit: number } | undefined;
  const items = await topPlayersByExperience(
    3,
    "US",
    topCollection([first, second, third], (filter, sort, limit) => {
      captured = { filter, sort, limit };
    }),
  );

  assert.deepEqual(captured, {
    filter: { "player.country": "US" },
    sort: { experience: -1, id: 1 },
    limit: 3,
  });
  assert.deepEqual(items.map((item) => item.Position), [{ N: "1" }, { N: "2" }, { N: "3" }]);
});

test("experience leaderboard pages reject mismatched or unstable selected rows", async () => {
  const first = playerDocument("experience-first", "First", 200);
  const lower = playerDocument("experience-lower", "Lower", 100);
  await assert.rejects(
    topPlayersByExperience(2, undefined, topCollection([lower, first])),
    /not in authoritative rank order/,
  );

  const wrongCountry = playerDocument("experience-country", "Country", 300, "CA");
  await assert.rejects(
    topPlayersByExperience(1, "US", topCollection([wrongCountry])),
    /does not match the country query/,
  );
});

test("experience leaderboard limits are exact and bounded", async () => {
  for (const limit of [0, 101, 1.5, Number.NaN, Number.POSITIVE_INFINITY]) {
    await assert.rejects(
      topPlayersByExperience(limit, undefined, topCollection([])),
      /limit is invalid/,
    );
  }
  await assert.rejects(
    topPlayersByExperience(1, undefined, topCollection([
      playerDocument("experience-over-1", "OverOne", 2),
      playerDocument("experience-over-2", "OverTwo", 1),
    ])),
    /too many rows/,
  );
});

test("player rank validates every strictly higher account before counting it", async () => {
  const current = playerDocument("rank-current", "Current", 100);
  const ahead = [
    playerDocument("rank-first", "First", 300),
    playerDocument("rank-second", "Second", 200),
  ];
  let captured: Filter<PlayerDocument> | undefined;
  assert.equal(
    await playerRank(current.id, rankCollection(current, ahead, (filter) => { captured = filter; })),
    3,
  );
  assert.deepEqual(captured, { experience: { $gt: 100 } });

  const corrupt = playerDocument("rank-corrupt", "Corrupt", 400);
  corrupt.player.experience = 399;
  await assert.rejects(
    playerRank(current.id, rankCollection(current, [corrupt])),
    /profile mirrors are inconsistent/,
  );

  await assert.rejects(
    playerRank(current.id, rankCollection(current, [playerDocument("rank-tied", "Tied", 100)])),
    /not strictly ahead/,
  );
  assert.equal(await playerRank("missing", rankCollection(null, [])), 0);
});
