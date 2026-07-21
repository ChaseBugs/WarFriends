import assert from "node:assert/strict";
import test from "node:test";
import { AccountType, PlayerStatus } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { newPlayer } from "../dtos";
import { playerHandlers } from "../handlers/player";
import {
  effectivePlayerPresence,
  effectivePlayerStatus,
  validatedPlayerPresenceTransitions,
} from "../services/playerPresenceService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = 1_900_000_000;

function playerDocument(id: string, name: string): PlayerDocument {
  const player = newPlayer(id, name, AccountType.Guest);
  player.lastAction = NOW;
  return {
    id,
    accountName: name,
    accountType: AccountType.Guest,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: createInitialProgression(NOW),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

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

  for (const invalid of [undefined, null, true, false, [], ["1"], {}, "", " 1", "01", "1.0", "1e0"]) {
    const malformed = await playerHandlers[DbAction.SetPlayerStatus].handler({
      req: { DbAction: DbAction.SetPlayerStatus, PlayerStatus: invalid },
      player,
    });
    assert.equal(malformed.Status, PlayerStatus.Online);
    assert.equal(player.player.lastAction, NOW - 1);
  }
});

test("ranked presence transitions validate the exact complete account set and successor", () => {
  const first = playerDocument("presence-player-a", "PresenceA");
  const second = playerDocument("presence-player-b", "PresenceB");
  const transitionAt = new Date((NOW + 10) * 1_000);
  const projected = validatedPlayerPresenceTransitions(
    [first, second],
    [first.id, second.id],
    PlayerStatus.InGame,
    NOW + 10,
    transitionAt,
  );

  assert.deepEqual(projected.map((document) => document.player.status), [
    PlayerStatus.InGame,
    PlayerStatus.InGame,
  ]);
  assert.deepEqual(projected.map((document) => document.player.lastAction), [NOW + 10, NOW + 10]);
  assert.equal(first.player.status, PlayerStatus.Online);
  assert.equal(first.player.lastAction, NOW);

  assert.throws(
    () => validatedPlayerPresenceTransitions(
      [first],
      [first.id, second.id],
      PlayerStatus.Online,
      NOW + 10,
      transitionAt,
    ),
    /invalid participant set/,
  );
  const corrupt = {
    ...first,
    player: { ...first.player, lastAction: Number.NaN },
  };
  assert.throws(
    () => validatedPlayerPresenceTransitions(
      [corrupt],
      [corrupt.id],
      PlayerStatus.Online,
      NOW + 10,
      transitionAt,
    ),
    /public identity is invalid/,
  );
  assert.throws(
    () => validatedPlayerPresenceTransitions(
      [first],
      [first.id],
      PlayerStatus.Online,
      NOW + 10,
      new Date((NOW - 1) * 1_000),
    ),
    /account envelope is invalid/,
  );
});
