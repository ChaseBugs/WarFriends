import assert from "node:assert/strict";
import test from "node:test";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import {
  applyVipBattleLootboxState,
  serializeVipLootboxVisuals,
  validatedVipLootboxCountdown,
  VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS,
  VIP_LOOTBOX_MATCH_INTERVAL,
  VIP_LOOTBOX_REWARDS_PER_CYCLE,
} from "../services/vipLootboxService";
import { VISUAL_CATALOG } from "../services/visualInventoryService";
import { validatedProgressionSuccessor } from "../services/progressionPublicationAuthorityService";

const NOW = 1_700_000_000;

function selectVisual(name: string): (exclusiveMaximum: number) => number {
  return (exclusiveMaximum) => {
    const index = VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.indexOf(name);
    assert.notEqual(index, -1, `${name} must belong to the reconstructed VIP pool`);
    assert.equal(exclusiveMaximum, VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.length);
    return index;
  };
}

function playerDocument(): PlayerDocument {
  const player = newPlayer("vip-lootbox-player", "VipLootboxPlayer", AccountType.Guest);
  return {
    id: player.id,
    accountName: player.accountName,
    authToken: "token",
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

test("VIP lootbox fallback is limited to the 73 recovered normal-shop part visuals", () => {
  assert.equal(VIP_LOOTBOX_MATCH_INTERVAL, 4);
  assert.equal(VIP_LOOTBOX_REWARDS_PER_CYCLE, 2);
  assert.equal(VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.length, 73);
  for (const id of VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS) {
    const definition = VISUAL_CATALOG[id];
    assert.ok(definition);
    assert.equal(definition.purchasable, "shop");
    assert.ok(definition.parts > 0);
  }
  assert.ok(!VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.includes("HELMETS_CROWNBRONZE"));
  assert.ok(!VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.includes("HELMETS_VIETNAM"));
  assert.ok(!VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.includes("HEAD_HIPSTERGLASSES"));
});

test("only confirmed active-VIP battles advance the 4 to 1 countdown", () => {
  const initial = createInitialProgression(NOW);
  const inactive = applyVipBattleLootboxState(initial, false, () => {
    throw new Error("inactive VIP must not select a reward");
  });
  assert.equal(inactive.state, initial);
  assert.equal(inactive.matchesToNextLootboxes, 4);
  assert.deepEqual(inactive.rewards, []);

  const afterOne = applyVipBattleLootboxState(initial, true);
  const afterTwo = applyVipBattleLootboxState(afterOne.state, true);
  const afterThree = applyVipBattleLootboxState(afterTwo.state, true);
  assert.deepEqual(
    [afterOne.matchesToNextLootboxes, afterTwo.matchesToNextLootboxes, afterThree.matchesToNextLootboxes],
    [3, 2, 1],
  );
  assert.deepEqual(afterThree.rewards, []);
  assert.equal(afterThree.state.revision, initial.revision + 3);
});

test("the fourth active-VIP battle grants two parts and resets the cycle", () => {
  const initial = {
    ...createInitialProgression(NOW),
    matchesToNextLootboxes: 1,
  };
  const result = applyVipBattleLootboxState(initial, true, selectVisual("HEAD_CLOWN"));
  assert.equal(result.matchesToNextLootboxes, 4);
  assert.equal(result.state.matchesToNextLootboxes, 4);
  assert.equal(result.rewards.length, 2);
  assert.deepEqual(result.rewards.map((reward) => reward.visualId), ["HEAD_CLOWN", "HEAD_CLOWN"]);
  assert.equal(result.state.visualInventory?.visuals.HEAD_CLOWN?.parts, 2);
  assert.equal(result.state.visualInventory?.visuals.HEAD_CLOWN?.notificate, true);
  // HEAD_CLOWN needs two parts. The first draw starts progress and the second completes it,
  // so neither is overflow and no duplicate currency is produced yet.
  assert.equal(result.duplicateWarBucks, 0);
  assert.equal(result.state.warBucks, initial.warBucks);
  assert.equal(result.newVisuals, '{"HEAD_CLOWN-VIP":"1","HEAD_CLOWN_#1-VIP":"1"}');
});

test("completed visual draws convert each part with the exact source WarBucks value", () => {
  const definition = VISUAL_CATALOG.HEAD_CLOWN;
  const initial = createInitialProgression(NOW);
  initial.matchesToNextLootboxes = 1;
  initial.warBucks = 250;
  initial.visualInventory!.visuals.HEAD_CLOWN = {
    bought: false,
    showed: false,
    expiresOn: 0,
    borrowed: false,
    parts: definition.parts,
    notificate: false,
  };
  const result = applyVipBattleLootboxState(initial, true, selectVisual("HEAD_CLOWN"));
  assert.equal(result.duplicateWarBucks, definition.duplicateWarBucks * 2);
  assert.equal(result.state.warBucks, 250 + definition.duplicateWarBucks * 2);
  assert.equal(result.state.visualInventory?.visuals.HEAD_CLOWN?.parts, definition.parts);
  assert.equal(result.state.visualInventory?.visuals.HEAD_CLOWN?.notificate, false);
});

test("VIP duplicate rewards pay chargeback debt and reject a corrupt wallet before settlement", () => {
  const definition = VISUAL_CATALOG.HEAD_CLOWN;
  const debt = createInitialProgression(NOW);
  debt.matchesToNextLootboxes = 1;
  debt.warBucks = -2_500;
  debt.visualInventory!.visuals.HEAD_CLOWN = {
    bought: true,
    showed: false,
    expiresOn: 0,
    borrowed: false,
    parts: definition.parts,
    notificate: false,
  };
  const paidDown = applyVipBattleLootboxState(debt, true, selectVisual("HEAD_CLOWN"));
  assert.equal(paidDown.state.warBucks, -500);

  const corrupt = { ...debt, warBucks: Number.NaN };
  assert.throws(
    () => applyVipBattleLootboxState(corrupt, true, selectVisual("HEAD_CLOWN")),
    /reward balance is invalid/,
  );
});

test("countdown authority and duplicate wire suffixes match the recovered parser", () => {
  assert.equal(validatedVipLootboxCountdown(undefined), 4);
  for (const countdown of [1, 2, 3, 4]) {
    assert.equal(validatedVipLootboxCountdown(countdown), countdown);
  }
  for (const countdown of [Number.NaN, Number.POSITIVE_INFINITY, -1, 0, 2.9, 5, 99]) {
    assert.throws(
      () => validatedVipLootboxCountdown(countdown),
      /Stored VIP lootbox countdown is invalid/,
    );
  }
  const clean = createInitialProgression(NOW);
  assert.throws(
    () => validatedProgressionSuccessor(clean, {
      ...clean,
      revision: clean.revision + 1,
      matchesToNextLootboxes: 0,
    }),
    /Stored VIP lootbox countdown is invalid/,
  );
  assert.equal(serializeVipLootboxVisuals([]), undefined);
  assert.equal(
    serializeVipLootboxVisuals([
      { visualId: "HEAD_CLOWN", parts: 1, vip: true },
      { visualId: "HEAD_CLOWN", parts: 1, vip: true },
    ]),
    '{"HEAD_CLOWN-VIP":"1","HEAD_CLOWN_#1-VIP":"1"}',
  );
});

test("GetPlayerData restores the authoritative VIP lootbox countdown", () => {
  const player = playerDocument();
  player.progression!.matchesToNextLootboxes = 2;
  const wire = buildPlayerData(player);
  const analytics = JSON.parse((wire.PlayerAnalyticsData as { S: string }).S) as Record<string, number>;
  assert.equal(analytics.matchesToNextLootboxes, 2);

  player.progression!.matchesToNextLootboxes = Number.POSITIVE_INFINITY;
  assert.throws(() => buildPlayerData(player), /Stored VIP lootbox countdown is invalid/);
});

test("VIP lootbox settlement rejects selected over-target parts before duplicate currency", () => {
  const initial = createInitialProgression(NOW);
  initial.matchesToNextLootboxes = 1;
  initial.visualInventory!.visuals.HEAD_CLOWN = {
    bought: false,
    showed: false,
    expiresOn: 0,
    borrowed: false,
    parts: VISUAL_CATALOG.HEAD_CLOWN.parts + 1,
    notificate: false,
  };

  assert.throws(
    () => applyVipBattleLootboxState(initial, true, selectVisual("HEAD_CLOWN")),
    /VIP lootbox visual HEAD_CLOWN parts are invalid/,
  );
});
