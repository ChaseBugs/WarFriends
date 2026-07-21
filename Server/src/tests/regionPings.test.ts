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
  validatedInternetConnection,
  validatedPhotonRoutingSnapshot,
  validatedRegionPings,
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

test("durable routing hints allow only exact recovered values or total legacy absence", () => {
  assert.deepEqual(validatedRegionPings(undefined), {});
  assert.deepEqual(validatedRegionPings({ in: 205, eu: 42 }), { eu: 42, in: 205 });
  assert.throws(() => validatedRegionPings({ moon: 1 }), /Stored Region moon is not supported/);
  for (const ping of [-1, 60_001, 12.5, Number.NaN, Number.POSITIVE_INFINITY, "42"]) {
    assert.throws(() => validatedRegionPings({ eu: ping }), /Stored Region eu has an invalid ping/);
  }
  assert.throws(() => validatedRegionPings([]), /Stored Regions must be an object/);
  assert.throws(() => validatedRegionPings(new Date()), /Stored Regions must be a plain object/);

  assert.equal(validatedInternetConnection(undefined), 0);
  assert.equal(validatedInternetConnection(0), 0);
  assert.equal(validatedInternetConnection(1), 1);
  assert.equal(validatedInternetConnection(2), 2);
  for (const connection of [3, -1, 1.5, Number.NaN, Number.POSITIVE_INFINITY, "Wifi"]) {
    assert.throws(
      () => validatedInternetConnection(connection),
      /Stored Connection is not a recovered InternetConnection value/,
    );
  }

  assert.deepEqual(validatedPhotonRoutingSnapshot(undefined, undefined), {
    bestRegions: {},
    connectionType: 0,
  });
  assert.throws(
    () => validatedPhotonRoutingSnapshot({ eu: 42 }, undefined),
    /Stored Photon routing snapshot is incomplete/,
  );
  assert.throws(
    () => validatedPhotonRoutingSnapshot(undefined, 2),
    /Stored Photon routing snapshot is incomplete/,
  );
});

test("public player snapshots restore the exact Regions string contract", () => {
  const wire = buildDatabasePlayer(playerDocument());
  assert.deepEqual(JSON.parse((wire.Regions as { S: string }).S), { eu: 42, us: 110 });
  assert.equal(wire.Connection, undefined);
  assert.equal(matchHandlers[DbAction.UpdateRegionPings]?.requiresAuth, true);
});
