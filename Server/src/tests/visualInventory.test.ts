import assert from "node:assert/strict";
import test from "node:test";
import { ApiError, ApiErrorCode } from "../apiErrors";
import generatedVisualCatalog from "../data/visualCatalog.generated.json";
import { DbAction } from "../dbActions";
import { processAssignmentBufferState } from "../services/assignmentService";
import { buildDatabasePlayer, buildPlayerData, createInitialProgression } from "../services/playerStateService";
import {
  createInitialVisualInventory,
  equipVisualState,
  markVisualShownState,
  parseVisualPurchaseData,
  purchaseVisualState,
  VISUAL_CATEGORY_NOT_FOUND,
  VISUAL_NOT_ENOUGH_GOLD,
  VISUAL_NOT_BOUGHT,
  VISUAL_ONLY_FOR_VIP,
} from "../services/visualInventoryService";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { validatedVisualInventoryState } from "../services/visualEntitlementService";
import { PLAYER_LEVELS } from "../services/levelProgressionService";

const NOW = 1_700_000_000;

function purchaseData(name: string, warBucks: number, gold: number, discount = 0): string {
  return JSON.stringify({ Name: name, Warbucks: warBucks, Gold: gold, discount, StartTime: NOW });
}

test("visual purchase parser requires recovered C# integer JSON members", () => {
  const name = "CAMOS_DEFAULT";
  assert.equal(parseVisualPurchaseData(purchaseData(name, 0, 0)).startTime, NOW);
  for (const field of ["Warbucks", "Gold", "discount", "StartTime"]) {
    const data: Record<string, unknown> = {
      Name: name,
      Warbucks: 0,
      Gold: 0,
      discount: 0,
      StartTime: NOW,
      [field]: "0",
    };
    assert.throws(() => parseVisualPurchaseData(JSON.stringify(data)));
  }
  assert.throws(() => parseVisualPurchaseData(JSON.stringify({
    Name: name,
    Warbucks: 0,
    Gold: 0,
    StartTime: NOW,
  })));
});

function playerDocument(): PlayerDocument {
  const player = newPlayer("visual-player", "VisualPlayer", AccountType.Guest);
  return {
    id: player.id,
    accountName: player.accountName,
    authToken: "a".repeat(64),
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

test("visual extraction joins all four scene categories to source balancing", () => {
  assert.equal(generatedVisualCatalog.schemaVersion, 1);
  assert.equal(generatedVisualCatalog.clientVersion, "4.9.5");
  assert.match(generatedVisualCatalog.sourceSha256, /^[0-9a-f]{64}$/);
  assert.deepEqual(
    generatedVisualCatalog.categories.map((category) => [category.id, category.defaultId, category.ids.length]),
    [
      [0, "CAMOS_DEFAULT", 31],
      [1, "HELMETS_EMPTY", 61],
      [2, "HEAD_EMPTY", 47],
      [3, "BANDS_EMPTY", 7],
    ],
  );
  assert.equal(generatedVisualCatalog.visuals.length, 146);
  assert.deepEqual(
    generatedVisualCatalog.unresolvedRows.map((row) => row.name),
    ["HEAD_MASK_ROCKET"],
  );
});

test("new accounts serialize the exact DecalManagerData shape and default slots", () => {
  const initial = createInitialVisualInventory();
  assert.deepEqual(initial, {
    visuals: {},
    slots: {
      "0": { equippedID: "CAMOS_DEFAULT" },
      "1": { equippedID: "HELMETS_EMPTY" },
      "2": { equippedID: "HEAD_EMPTY" },
      "3": { equippedID: "BANDS_EMPTY" },
    },
    previousHeadDecal: "",
  });
  const wire = buildPlayerData(playerDocument());
  assert.deepEqual(JSON.parse((wire.DecalManagerData as { S: string }).S), initial);
});

test("visual authority rejects unknown rows, impossible parts, and cross-category equipment", () => {
  const initial = createInitialVisualInventory();
  const saved = {
    bought: false,
    showed: false,
    expiresOn: 0,
    borrowed: false,
    parts: 0,
    notificate: false,
  };

  assert.throws(
    () => validatedVisualInventoryState({
      ...initial,
      visuals: { RETIRED_OR_CLIENT_INVENTED_VISUAL: saved },
    }),
    /Saved visual authority is invalid/,
  );
  assert.throws(
    () => validatedVisualInventoryState({
      ...initial,
      visuals: { CAMOS_DEFAULT: { ...saved, parts: 1 } },
    }),
    /Saved visual authority is invalid/,
  );
  assert.throws(
    () => validatedVisualInventoryState({
      ...initial,
      slots: { ...initial.slots, "1": { equippedID: "HEAD_CIGAR" } },
    }),
    /Visual slot authority is invalid/,
  );
  assert.throws(
    () => validatedVisualInventoryState({
      ...initial,
      slots: { "0": initial.slots["0"]! },
    }),
    /Visual slots are invalid/,
  );
  assert.throws(
    () => validatedVisualInventoryState({ ...initial, previousHeadDecal: "CAMOS_DEFAULT" }),
    /Previous head visual is invalid/,
  );
});

test("WarBucks visual purchase and equip use the source row and owned category", () => {
  const state = { ...createInitialProgression(NOW), warBucks: 10_000 };
  const purchased = purchaseVisualState(
    state,
    NOW,
    0,
    0,
    { name: "HEAD_CIGAR", warBucks: 7_500, gold: 0, discount: 0, startTime: NOW },
  );
  assert.equal(purchased.state.warBucks, 2_500);
  assert.equal(purchased.visualInventory.visuals.HEAD_CIGAR?.bought, true);

  const equipped = equipVisualState(purchased.state, NOW, "HEAD_CIGAR");
  assert.equal(equipped.visualInventory.slots["2"]?.equippedID, "HEAD_CIGAR");
  assert.equal(equipped.visualInventory.slots["1"]?.equippedID, "HELMETS_EMPTY");

  const shown = markVisualShownState(equipped.state, "HEAD_CIGAR");
  assert.equal(shown.visualInventory.visuals.HEAD_CIGAR?.showed, true);
  assert.equal(equipVisualState(equipped.state, NOW, "HEAD_CIGAR").state, equipped.state);
  assert.equal(markVisualShownState(shown.state, "HEAD_CIGAR").state, shown.state);

  const notification = {
    ...shown.state,
    visualInventory: {
      ...shown.state.visualInventory!,
      visuals: {
        ...shown.state.visualInventory!.visuals,
        HEAD_CIGAR: { ...shown.state.visualInventory!.visuals.HEAD_CIGAR!, notificate: true },
      },
    },
  };
  const clearedNotification = markVisualShownState(notification, "HEAD_CIGAR");
  assert.notEqual(clearedNotification.state, notification);
  assert.equal(clearedNotification.visualInventory.visuals.HEAD_CIGAR?.notificate, false);

  const publicPlayer = playerDocument();
  publicPlayer.progression = equipped.state;
  const publicWire = buildDatabasePlayer(publicPlayer);
  assert.deepEqual(JSON.parse((publicWire.PlayerVisuals as { S: string }).S), equipped.visualInventory.slots);
});

test("normal visual purchase requires one exact recovered player-level row", () => {
  const state = { ...createInitialProgression(NOW), warBucks: 10_000 };
  const payload = { name: "HEAD_CIGAR", warBucks: 7_500, gold: 0, discount: 0, startTime: NOW };

  for (const playerLevel of [Number.NaN, Number.POSITIVE_INFINITY, -1, 0.5, PLAYER_LEVELS.length]) {
    assert.throws(
      () => purchaseVisualState(state, NOW, playerLevel, 0, payload),
      (error: unknown) => error instanceof ApiError && error.code === ApiErrorCode.InternalServerError,
    );
  }
  assert.equal(state.warBucks, 10_000);
  assert.equal(state.revision, 0);
  assert.equal(state.visualInventory?.visuals.HEAD_CIGAR, undefined);
});

test("temporary power bands expire and VIP-only bands require live entitlement", () => {
  const state = { ...createInitialProgression(NOW), gold: 1_000 };
  assert.throws(
    () => purchaseVisualState(
      state,
      NOW,
      0,
      0,
      { name: "BANDS_DAMAGE_1", warBucks: 0, gold: 299, discount: 0, startTime: NOW },
    ),
    (error: unknown) => (error as { code?: number }).code === VISUAL_ONLY_FOR_VIP,
  );

  const purchased = purchaseVisualState(
    state,
    NOW,
    0,
    NOW + 10_000,
    { name: "BANDS_DAMAGE_1", warBucks: 0, gold: 299, discount: 0, startTime: NOW },
  );
  assert.equal(purchased.expiresOn, NOW + 259_200);
  assert.equal(equipVisualState(purchased.state, NOW, "BANDS_DAMAGE_1").definition.effectType, 1);
  assert.throws(
    () => equipVisualState(purchased.state, purchased.expiresOn, "BANDS_DAMAGE_1"),
    (error: unknown) => (error as { code?: number }).code === VISUAL_NOT_BOUGHT,
  );

  // Imported JSON can contain values that MongoDB/BSON later exposes as Infinity. A raw
  // `expiresOn > now` comparison would turn that damaged record into permanent ownership.
  // Exercise both the gameplay ownership boundary and the boot serializer so neither path can
  // publish or consume a malformed timed-cosmetic entitlement.
  const corrupted = {
    ...purchased.state,
    visualInventory: {
      ...purchased.visualInventory,
      visuals: {
        ...purchased.visualInventory.visuals,
        BANDS_DAMAGE_1: {
          ...purchased.visualInventory.visuals.BANDS_DAMAGE_1!,
          expiresOn: Number.POSITIVE_INFINITY,
        },
      },
    },
  };
  assert.throws(
    () => equipVisualState(corrupted, NOW, "BANDS_DAMAGE_1"),
    /Visual BANDS_DAMAGE_1 expiry is invalid/,
  );
  const corruptedPlayer = playerDocument();
  corruptedPlayer.progression = corrupted;
  assert.throws(
    () => buildPlayerData(corruptedPlayer, NOW),
    /Visual BANDS_DAMAGE_1 expiry is invalid/,
  );
});

test("visual purchases fail closed for wrong price, event rows, and unresolved assets", () => {
  const state = { ...createInitialProgression(NOW), gold: 1_000, warBucks: 1_000_000 };
  assert.throws(
    () => purchaseVisualState(
      state,
      NOW,
      0,
      0,
      { name: "HEAD_CIGAR", warBucks: 1, gold: 0, discount: 0, startTime: NOW },
    ),
    (error: unknown) => (error as { code?: number }).code === 100,
  );
  assert.throws(
    () => purchaseVisualState(
      state,
      NOW,
      0,
      0,
      { name: "CAMOS_CHINESEGIRL", warBucks: 0, gold: 0, discount: 0, startTime: NOW },
    ),
    (error: unknown) => (error as { code?: number }).code === VISUAL_CATEGORY_NOT_FOUND,
  );
  assert.throws(
    () => purchaseVisualState(
      state,
      NOW,
      0,
      0,
      { name: "HEAD_MASK_ROCKET", warBucks: 21_900, gold: 0, discount: 0, startTime: NOW },
    ),
    (error: unknown) => (error as { code?: number }).code === VISUAL_CATEGORY_NOT_FOUND,
  );
  assert.throws(
    () => purchaseVisualState(
      { ...state, gold: 0 },
      NOW,
      0,
      0,
      { name: "HELMETS_SPARTAN", warBucks: 0, gold: 50, discount: 0, startTime: NOW },
    ),
    (error: unknown) => (error as { code?: number }).code === VISUAL_NOT_ENOUGH_GOLD,
  );
});

test("buffered visual purchase, equip, acknowledgement, and replay are exactly once", () => {
  const initial = { ...createInitialProgression(NOW), warBucks: 10_000 };
  const requests = [
    { action: DbAction.BuyDecal, data: purchaseData("HEAD_CIGAR", 7_500, 0) },
    { action: DbAction.EquipDecal, data: "HEAD_CIGAR" },
    { action: DbAction.VisualWasShown, data: "HEAD_CIGAR" },
  ];
  const first = processAssignmentBufferState(initial, NOW, "visual-buffer", requests, 0, 0);
  const firstResponses = JSON.parse(first.requestsResults) as Array<Record<string, unknown>>;
  assert.deepEqual(firstResponses.map((response) => response.Result), [1, 1, 1]);
  assert.equal(first.state.warBucks, 2_500);
  assert.equal(first.state.visualInventory?.slots["2"]?.equippedID, "HEAD_CIGAR");
  assert.equal(first.state.visualInventory?.visuals.HEAD_CIGAR?.showed, true);

  const replay = processAssignmentBufferState(first.state, NOW + 1, "visual-buffer", requests, 0, 0);
  assert.equal(replay.replayed, true);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.state.warBucks, 2_500);
});
