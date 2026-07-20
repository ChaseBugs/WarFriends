import assert from "node:assert/strict";
import test from "node:test";
import generatedArmyPowerCatalog from "../data/armyPowerCatalog.generated.json";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { WEAPON_UPGRADE_CATALOG } from "../data/weaponUpgradeCatalog.generated";
import {
  calculateArmyPower,
  equippedWeaponPower,
  rankPower,
} from "../services/armyPowerService";
import { createInitialProgression } from "../services/playerStateService";

function playerDocument(): PlayerDocument {
  const player = newPlayer("army-power-player", "ArmyPowerPlayer", AccountType.Guest);
  return {
    id: player.id,
    accountName: player.accountName,
    authToken: "session-token",
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: createInitialProgression(1_700_000_000),
    createdAt: new Date("2023-11-14T22:13:20Z"),
    updatedAt: new Date("2023-11-14T22:13:20Z"),
  };
}

test("Army Power extraction covers rank rows and every normal weapon power row", () => {
  assert.equal(generatedArmyPowerCatalog.schemaVersion, 2);
  assert.equal(generatedArmyPowerCatalog.clientVersion, "4.9.5");
  assert.match(generatedArmyPowerCatalog.sourceSha256, /^[0-9a-f]{64}$/);
  assert.equal(generatedArmyPowerCatalog.rankLevels.length, 58);
  assert.deepEqual(generatedArmyPowerCatalog.rankLevels[0], {
    index: 0,
    displayLevel: 1,
    experience: 50_000,
    rewardGold: 5,
    armyPower: 93,
  });
  assert.deepEqual(generatedArmyPowerCatalog.rankLevels.at(-1), {
    index: 57,
    displayLevel: 58,
    experience: 845_433_656,
    rewardGold: 60,
    armyPower: 1_060,
  });
  assert.equal(generatedArmyPowerCatalog.weapons.length, 165);
  assert.equal(generatedArmyPowerCatalog.featureDpsCoefficients.length, 11);
  assert.equal(
    generatedArmyPowerCatalog.featureDpsCoefficients.every((row) => row.dpsByFeature.length === 9),
    true,
  );
  assert.equal(
    generatedArmyPowerCatalog.weapons.reduce((total, weapon) => total + weapon.powerByLevel.length, 0),
    11_805,
  );
  for (const weapon of generatedArmyPowerCatalog.weapons) {
    assert.equal(weapon.powerByLevel.length, WEAPON_UPGRADE_CATALOG[weapon.name]!.length + 1);
  }
});

test("starter weapon and rank power reproduce LevelManager float32 component rounding", () => {
  const document = playerDocument();

  assert.equal(equippedWeaponPower(document.progression!), 210);
  assert.equal(rankPower(0), 93);
  assert.equal(rankPower(1), 97);
  assert.equal(rankPower(-100), 93);
  assert.equal(rankPower(10_000), 1_060);
  assert.deepEqual(calculateArmyPower(document), {
    unitPower: 0,
    weaponPower: 210,
    // New accounts currently store zero-based level index 1, matching LevelManager.LoadData.
    rankPower: 97,
    total: 307,
  });
});

test("weapon power uses stored upgrade cursors and rejects unsupported feature authority", () => {
  const document = playerDocument();
  const inventory = document.progression!.itemInventory!;
  const ak47 = inventory.levelManagerData.savedWeapons["Google2u.AssaultRifle_AK47"]!;
  const initial = equippedWeaponPower(document.progression!);

  ak47.boughtIndex = 1;
  assert.equal(equippedWeaponPower(document.progression!) > initial, true);

  ak47.specialFeature = 1;
  assert.throws(
    () => equippedWeaponPower(document.progression!),
    (error: unknown) => (error as { code?: number }).code === 90,
  );
});
