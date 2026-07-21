import assert from "node:assert/strict";
import test from "node:test";
import { PlayerStatus } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { playerHandlers } from "../handlers/player";
import { effectivePlayerPresence, effectivePlayerStatus } from "../services/playerPresenceService";

const NOW = 1_900_000_000;

test("active ranked reservations cannot be cleared by client status reports", () => {
  assert.equal(effectivePlayerStatus(PlayerStatus.Online, true), PlayerStatus.InGame);
  assert.equal(effectivePlayerStatus(PlayerStatus.Offline, true), PlayerStatus.InGame);
  assert.equal(effectivePlayerStatus(PlayerStatus.InGame, true), PlayerStatus.InGame);
});

test("non-ranked modes retain the recovered client presence contract", () => {
  assert.equal(effectivePlayerStatus(PlayerStatus.Online, false), PlayerStatus.Online);
  assert.equal(effectivePlayerStatus(PlayerStatus.Offline, false), PlayerStatus.Offline);
  assert.equal(effectivePlayerStatus(PlayerStatus.InGame, false), PlayerStatus.InGame);
});

test("presence publishes one validated Status and LastAction snapshot", () => {
  assert.deepEqual(effectivePlayerPresence(PlayerStatus.Online, false, NOW), {
    status: PlayerStatus.Online,
    lastAction: NOW,
  });
  assert.deepEqual(effectivePlayerPresence(PlayerStatus.Offline, true, NOW), {
    status: PlayerStatus.InGame,
    lastAction: NOW,
  });

  for (const invalid of [-1, 1.5, 2_147_483_648, Number.NaN, Number.POSITIVE_INFINITY]) {
    assert.throws(
      () => effectivePlayerPresence(PlayerStatus.Online, false, invalid),
      /last-action time is invalid/,
    );
  }
});

test("invalid action-29 status remains callback-safe without refreshing durable presence", async () => {
  const player = {
    id: "presence-test-player",
    player: { status: PlayerStatus.Online, lastAction: NOW - 1 },
  } as unknown as PlayerDocument;
  const response = await playerHandlers[DbAction.SetPlayerStatus].handler({
    req: { DbAction: DbAction.SetPlayerStatus, PlayerStatus: 99 },
    player,
  });

  assert.equal(response.Result, 1);
  assert.equal(response.Status, PlayerStatus.Online);
  assert.equal(Number.isSafeInteger(Number(response.Time)), true);
  assert.equal(player.player.lastAction, NOW - 1);
});
