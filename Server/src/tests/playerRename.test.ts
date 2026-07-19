import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import {
  PLAYER_RENAME_NOT_ENOUGH_GOLD,
  SECOND_RENAME_BASE_GOLD_COST,
  applyRenameEconomyState,
  renameGoldPrice,
} from "../services/playerRenameService";
import { createInitialProgression } from "../services/playerStateService";

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
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
  );
});
