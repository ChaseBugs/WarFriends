import assert from "node:assert/strict";
import test from "node:test";
import {
  advancePvpWinStreak,
  PVP_WIN_STREAK_INTERVAL_SECONDS,
  PVP_WIN_STREAK_WARBUCKS,
  validatedPvpWinStreak,
} from "../services/matchService";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import { newPlayer } from "../dtos";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";

test("PvP win-streak table preserves the nine verified MainScene rewards and interval", () => {
  assert.equal(PVP_WIN_STREAK_INTERVAL_SECONDS, 200);
  assert.deepEqual([...PVP_WIN_STREAK_WARBUCKS], [400, 700, 1000, 1400, 1800, 2200, 2600, 3000, 3600]);
});

test("confirmed wins start, continue, expire, and cap the server-owned streak", () => {
  const first = advancePvpWinStreak(undefined, true, false, 10_000);
  assert.deepEqual(first, {
    state: { winCount: 1, timestamp: 10_000 },
    baseWarBucks: 400,
    warBucks: 400,
  });

  const second = advancePvpWinStreak(first.state, true, false, 10_199);
  assert.equal(second.state.winCount, 2);
  assert.equal(second.baseWarBucks, 700);

  // The client uses deadline > current time, so equality is already expired.
  const expired = advancePvpWinStreak(second.state, true, false, 10_399);
  assert.equal(expired.state.winCount, 1);
  assert.equal(expired.baseWarBucks, 400);

  const capped = advancePvpWinStreak({ winCount: 9, timestamp: 20_000 }, true, false, 20_001);
  assert.equal(capped.state.winCount, 9);
  assert.equal(capped.baseWarBucks, 3600);
});

test("losses clear streaks and VIP multiplies the streak component independently", () => {
  const vip = advancePvpWinStreak({ winCount: 1, timestamp: 30_000 }, true, true, 30_001);
  assert.equal(vip.baseWarBucks, 700);
  assert.equal(vip.warBucks, 1050);
  assert.deepEqual(
    advancePvpWinStreak(vip.state, false, true, 30_002),
    { state: { winCount: 0, timestamp: 0 }, baseWarBucks: 0, warBucks: 0 },
  );
  assert.throws(() => advancePvpWinStreak(undefined, true, false, -1), /invalid/);
});

test("ranked settlement rejects corrupt streak authority instead of clamping or restarting it", () => {
  assert.deepEqual(validatedPvpWinStreak(undefined, 40_000), { winCount: 0, timestamp: 0 });
  assert.deepEqual(
    validatedPvpWinStreak({ winCount: 9, timestamp: 39_999 }, 40_000),
    { winCount: 9, timestamp: 39_999 },
  );

  for (const winCount of [Number.NaN, Number.POSITIVE_INFINITY, -1, 1.5, 10, 100]) {
    assert.throws(
      () => advancePvpWinStreak({ winCount, timestamp: 39_999 }, true, false, 40_000),
      /Stored PvP win-streak authority is invalid/,
    );
  }
  for (const timestamp of [Number.NaN, Number.POSITIVE_INFINITY, -1, 40_001, 2_147_483_648]) {
    assert.throws(
      () => advancePvpWinStreak({ winCount: 1, timestamp }, true, false, 40_000),
      /Stored PvP win-streak authority is invalid/,
    );
  }
  assert.throws(
    () => advancePvpWinStreak({ winCount: 0, timestamp: 39_999 }, false, false, 40_000),
    /Stored PvP win-streak authority is invalid/,
  );
  assert.throws(
    () => advancePvpWinStreak({ winCount: 1, timestamp: 0 }, false, false, 40_000),
    /Stored PvP win-streak authority is invalid/,
  );
});

test("GetPlayerData restores WinStreakManager through its exact nested type name", () => {
  const dto = newPlayer("streak-player", "StreakPlayer", AccountType.Guest);
  const now = new Date(40_000_000);
  const player: PlayerDocument = {
    id: dto.id,
    accountName: dto.accountName,
    accountType: dto.accountType,
    leagueTier: dto.leagueTier,
    armyPower: dto.armyPower,
    experience: dto.experience,
    squadPoints: dto.squadPoints,
    squadName: dto.squadName,
    player: dto,
    progression: {
      ...createInitialProgression(40_000),
      pvpWinStreak: { winCount: 4, timestamp: 40_000 },
    },
    createdAt: now,
    updatedAt: now,
  };
  assert.deepEqual(buildPlayerData(player).WinStreak, {
    S: JSON.stringify({ WinCount: 4, TimeStamp: 40_000 }),
  });

  player.progression!.pvpWinStreak = { winCount: 10, timestamp: 40_000 };
  assert.throws(() => buildPlayerData(player), /Stored PvP win-streak authority is invalid/);
  player.progression!.pvpWinStreak = { winCount: 1, timestamp: 40_001 };
  assert.throws(
    () => buildPlayerData(player, 40_000),
    /Stored PvP win-streak authority is invalid/,
  );
});
