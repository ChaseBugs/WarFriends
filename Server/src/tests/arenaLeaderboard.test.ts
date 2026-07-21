import assert from "node:assert/strict";
import test from "node:test";
import type { Collection, Document } from "mongodb";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { topArenaPlayers } from "../services/leaderboardService";
import { createInitialProgression } from "../services/playerStateService";
import { currentArenaId } from "../services/warArenaContract";
import { initialWarArenaState } from "../services/warArenaService";

const NOW = Date.UTC(2030, 2, 17, 17, 46, 40) / 1_000;

function arenaPlayer(
  id: string,
  name: string,
  values: { flawless: number; topRun: number; wins?: number; arenaId?: string },
): PlayerDocument {
  const player = newPlayer(id, name, AccountType.Guest);
  const wins = values.wins ?? values.topRun;
  const arena = {
    ...initialWarArenaState(),
    arenaId: values.arenaId ?? currentArenaId(NOW),
    played: true,
    flawless: values.flawless,
    topRun: values.topRun,
    wins,
    matches: Math.max(wins, values.topRun),
  };
  return {
    id: player.id,
    accountName: player.accountName,
    authToken: "a".repeat(64),
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: { ...createInitialProgression(NOW), warArena: arena },
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

function fakeCollection(
  rows: PlayerDocument[],
  capture?: (pipeline: Document[]) => void,
): Collection<PlayerDocument> {
  return {
    aggregate: (pipeline: Document[]) => {
      capture?.(pipeline);
      return { toArray: async () => rows };
    },
  } as unknown as Collection<PlayerDocument>;
}

test("Arena leaderboard admits only the exact current monthly event", async () => {
  const current = arenaPlayer("arena-current", "Current", { flawless: 0, topRun: 4 });
  let pipeline: Document[] | undefined;
  const items = await topArenaPlayers(100, NOW, fakeCollection([current], (value) => { pipeline = value; }));

  assert.deepEqual(pipeline?.[0], {
    $match: {
      "progression.warArena.arenaId": currentArenaId(NOW),
      "progression.warArena.played": true,
    },
  });
  assert.deepEqual(items[0]?.Position, { N: "1" });
  const wire = JSON.parse((items[0]?.WarArenaData as { S: string }).S) as Record<string, unknown>;
  assert.equal(wire.arenaId, currentArenaId(NOW));

  const prior = arenaPlayer("arena-prior", "Prior", {
    flawless: 10,
    topRun: 12,
    arenaId: currentArenaId(Date.UTC(2030, 1, 17) / 1_000),
  });
  await assert.rejects(
    topArenaPlayers(100, NOW, fakeCollection([prior])),
    /not from the current event/,
  );
});

test("Arena leaderboard pipeline implements the recovered flawless-first score", async () => {
  const flawless = arenaPlayer("arena-flawless", "Bravo", { flawless: 1, topRun: 2 });
  const longRun = arenaPlayer("arena-long-run", "Alpha", { flawless: 0, topRun: 12 });
  let pipeline: Document[] | undefined;
  await topArenaPlayers(2, NOW, fakeCollection([flawless, longRun], (value) => { pipeline = value; }));

  assert.deepEqual(pipeline?.[1], {
    $set: {
      __arenaLeaderboardFlawless: {
        $cond: [{ $gt: ["$progression.warArena.flawless", 0] }, 1, 0],
      },
      __arenaLeaderboardScore: {
        $cond: [
          { $gt: ["$progression.warArena.flawless", 0] },
          "$progression.warArena.flawless",
          "$progression.warArena.topRun",
        ],
      },
    },
  });
  assert.deepEqual(pipeline?.[2], {
    $sort: {
      __arenaLeaderboardFlawless: -1,
      __arenaLeaderboardScore: -1,
      "player.accountName": 1,
      id: 1,
    },
  });
});

test("Arena leaderboard fails closed if storage returns a non-authoritative order", async () => {
  const flawless = arenaPlayer("arena-flawless-order", "Bravo", { flawless: 1, topRun: 1 });
  const longRun = arenaPlayer("arena-long-order", "Alpha", { flawless: 0, topRun: 12 });
  await assert.rejects(
    topArenaPlayers(2, NOW, fakeCollection([longRun, flawless])),
    /not in authoritative rank order/,
  );
});

test("Arena leaderboard rejects invalid internal limits before database access", async () => {
  for (const limit of [0, 101, 1.5, Number.NaN, Number.POSITIVE_INFINITY]) {
    await assert.rejects(topArenaPlayers(limit, NOW, fakeCollection([])), /limit is invalid/);
  }
});
