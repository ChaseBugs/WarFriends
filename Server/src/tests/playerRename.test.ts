import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import {
  PLAYER_RENAME_NOT_ENOUGH_GOLD,
  SECOND_RENAME_BASE_GOLD_COST,
  applyRenameEconomyState,
  renameGoldPrice,
} from "../services/playerRenameService";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";

const NOW = Date.UTC(2026, 6, 20, 12, 0, 0) / 1_000;

test("rename price reproduces the recovered free-first and doubling Gold schedule", () => {
  assert.equal(SECOND_RENAME_BASE_GOLD_COST, 4);
  assert.equal(renameGoldPrice(0), 0);
  assert.equal(renameGoldPrice(1), 4);
  assert.equal(renameGoldPrice(2), 8);
  assert.equal(renameGoldPrice(5), 64);
  assert.equal(renameGoldPrice(29), 1_073_741_824);
});

test("first rename is free for both platform sync and RenameDialog request flags", () => {
  const initial = { ...createInitialProgression(NOW), gold: 10 };
  const platform = applyRenameEconomyState(initial, 0, false);
  const dialog = applyRenameEconomyState(initial, 0, true);

  assert.equal(platform.goldSpent, 0);
  assert.equal(platform.renameCount, 1);
  assert.equal(platform.state.gold, 10);
  assert.equal(dialog.goldSpent, 0);
  assert.equal(dialog.renameCount, 1);
  assert.equal(dialog.state.gold, 10);
  assert.equal(initial.revision, 0);
});

test("paid rename debits the server price and advances RenameCount exactly once", () => {
  const initial = { ...createInitialProgression(NOW), gold: 20, revision: 7 };
  const result = applyRenameEconomyState(initial, 2, true);

  assert.equal(result.previousRenameCount, 2);
  assert.equal(result.renameCount, 3);
  assert.equal(result.goldSpent, 8);
  assert.equal(result.state.gold, 12);
  assert.equal(result.state.revision, 8);
  assert.equal(initial.gold, 20);
});

test("paid rename rejects missing confirmation, insufficient Gold, and overflow prices", () => {
  const initial = { ...createInitialProgression(NOW), gold: 3 };
  assert.throws(
    () => applyRenameEconomyState(initial, 1, false),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
  );
  assert.throws(
    () => applyRenameEconomyState(initial, 1, true),
    (error: unknown) => (error as { code?: number }).code === PLAYER_RENAME_NOT_ENOUGH_GOLD,
  );
  assert.throws(
    () => renameGoldPrice(30),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.InternalServerError,
  );
});

test("rename authority rejects malformed counts, wallets, revisions, and an overflowing next count", () => {
  for (const count of [Number.NaN, Number.POSITIVE_INFINITY, -1, 1.5, 30]) {
    assert.throws(
      () => renameGoldPrice(count),
      (error: unknown) => (error as { code?: number }).code === ApiErrorCode.InternalServerError,
    );
  }
  for (const gold of [Number.NaN, Number.POSITIVE_INFINITY]) {
    assert.throws(
      () => applyRenameEconomyState({ ...createInitialProgression(NOW), gold }, 1, true),
      /Rename Gold balance is invalid/,
    );
  }
  assert.throws(
    () => applyRenameEconomyState({
      ...createInitialProgression(NOW),
      gold: 10,
      revision: Number.MAX_SAFE_INTEGER,
    }, 0, true),
    /Rename progression revision is invalid/,
  );
  assert.throws(
    () => applyRenameEconomyState({ ...createInitialProgression(NOW), gold: Number.MAX_SAFE_INTEGER }, 29, true),
    /Stored rename count is invalid/,
  );
});

test("PlayerAnalyticsData restores validated rename count for the doubling price", () => {
  const dto = newPlayer("rename-player", "RenamePlayer", AccountType.Guest);
  dto.renameCount = 2;
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
    progression: createInitialProgression(NOW),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
  const analytics = JSON.parse(
    (buildPlayerData(player, NOW).PlayerAnalyticsData as { S: string }).S,
  ) as Record<string, number>;
  assert.equal(analytics.renameCount, 2);

  player.player.renameCount = 30;
  // Full boot projection now crosses the shared account boundary first. Keep this assertion on
  // the public failure contract while the narrower price/mutation tests above retain the exact
  // rename-authority diagnostic.
  assert.throws(() => buildPlayerData(player, NOW), /Stored player public identity is invalid/);
});
