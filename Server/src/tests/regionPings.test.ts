import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { DbAction } from "../dbActions";
import { matchHandlers } from "../handlers/match";
import { buildDatabasePlayer, createInitialProgression } from "../services/playerStateService";
import {
  parseInternetConnection,
  parseRegionPings,
} from "../services/regionPingService";

const NOW = 1_900_000_000;

function playerDocument(): PlayerDocument {
  const player = newPlayer("region-player", "RegionPlayer", AccountType.Guest);
  player.bestRegions = { eu: 42, us: 110 };
  player.connectionType = 2;
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
    progression: createInitialProgression(NOW),
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };
}

test("region ping parsing accepts only the recovered Photon region family", () => {
  assert.deepEqual(
    parseRegionPings('{"us":110,"eu":42,"in":205}'),
    { eu: 42, us: 110, in: 205 },
  );
  assert.deepEqual(parseRegionPings("{}"), {});
  assert.throws(() => parseRegionPings('{"ru":30}'));
  assert.throws(() => parseRegionPings('{"eu":-1}'));
  assert.throws(() => parseRegionPings('{"eu":12.5}'));
  assert.throws(() => parseRegionPings('{"eu":"42"}'));
  assert.throws(() => parseRegionPings("[]"));
});

test("connection parsing follows the recovered enum names exactly", () => {
  assert.equal(parseInternetConnection("None"), 0);
  assert.equal(parseInternetConnection("Cellural"), 1);
  assert.equal(parseInternetConnection("Wifi"), 2);
  assert.throws(() => parseInternetConnection("Cellular"));
  assert.throws(() => parseInternetConnection(2));
});

test("public player snapshots restore the exact Regions string contract", () => {
  const wire = buildDatabasePlayer(playerDocument());
  assert.deepEqual(JSON.parse((wire.Regions as { S: string }).S), { eu: 42, us: 110 });
  assert.equal(wire.Connection, undefined);
  assert.equal(matchHandlers[DbAction.UpdateRegionPings]?.requiresAuth, true);
});
