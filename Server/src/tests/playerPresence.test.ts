import assert from "node:assert/strict";
import test from "node:test";
import { PlayerStatus } from "../constants";
import { effectivePlayerStatus } from "../services/playerPresenceService";

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
