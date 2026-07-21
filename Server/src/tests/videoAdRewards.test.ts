import assert from "node:assert/strict";
import test from "node:test";
import type { PlayerDocument, PlayerProgressionState } from "../db";
import { AccountType } from "../constants";
import { newPlayer } from "../dtos";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import { VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS } from "../services/vipLootboxService";
import {
  grantVideoAdRewardState,
  OFFLINE_GOLDEN_SUITCASE_REWARDS,
  VIDEO_AD_LIMITS,
  validatedVideoAdRewardTimes,
  VideoAdRewardKind,
} from "../services/videoAdRewardService";

const NOW = 1_700_000_000;

function state(): PlayerProgressionState {
  return createInitialProgression(NOW);
}

function picker(...values: number[]): (exclusiveMaximum: number) => number {
  let cursor = 0;
  return (exclusiveMaximum) => {
    const value = values[cursor++];
    assert.notEqual(value, undefined, `missing selector value for upper bound ${exclusiveMaximum}`);
    assert.ok(value! >= 0 && value! < exclusiveMaximum);
    return value!;
  };
}

test("source-decoded rolling limits preserve every 4.9.5 ad policy", () => {
  assert.deepEqual(VIDEO_AD_LIMITS, {
    1: { key: "warcards", count: 24, intervalSeconds: 18_000, minimumSpacingSeconds: 0 },
    2: { key: "dogtags", count: 24, intervalSeconds: 43_200, minimumSpacingSeconds: 0 },
    3: { key: "goldenSuitcase", count: 24, intervalSeconds: 54_000, minimumSpacingSeconds: 60 },
    4: { key: "lootboxes", count: 24, intervalSeconds: 360_000, minimumSpacingSeconds: 0 },
  });
});

test("RandomCard grants one server-selected visible Bronze card and records its ledger", () => {
  const result = grantVideoAdRewardState(state(), NOW, 5, VideoAdRewardKind.RandomCard, picker(0));
  const cards = result.response.AddedCards as string[];

  assert.equal(cards.length, 1);
  assert.equal(result.state.cardInventory?.cardData[cards[0]!]?.amount, 1);
  assert.deepEqual(result.state.videoAdRewards?.times, {
    warcards: [NOW],
    dogtags: [],
    goldenSuitcase: [],
    lootboxes: [],
  });
  assert.equal(result.state.revision, 1);
});

test("Dogtag materializes elapsed time, grants exactly one tag, and refuses a full wallet", () => {
  const empty = { ...state(), dogTagSeconds: 0, dogTagLastUpdate: NOW };
  const result = grantVideoAdRewardState(empty, NOW, 5, VideoAdRewardKind.Dogtag);

  assert.equal(result.state.dogTagSeconds, 900);
  assert.equal(result.response.DogTagSeconds, 900);
  assert.equal(result.response.DogTagLastUpdate, NOW);
  assert.deepEqual(result.state.videoAdRewards?.times.dogtags, [NOW]);

  assert.throws(
    () => grantVideoAdRewardState(state(), NOW, 5, VideoAdRewardKind.Dogtag),
    /Dog tags are already full/,
  );
});

test("all four offline Golden Suitcase branches persist exactly what the stock parser displays", () => {
  assert.deepEqual(OFFLINE_GOLDEN_SUITCASE_REWARDS, [
    { kind: "warBucks", amount: 1_000 },
    { kind: "gold", amount: 5 },
    { kind: "card", amount: 1 },
    { kind: "lootbox", amount: 1 },
  ]);

  const warBucks = grantVideoAdRewardState(state(), NOW, 5, VideoAdRewardKind.GoldenSuitcase, picker(0));
  assert.equal(warBucks.state.warBucks, 1_000);
  assert.equal(warBucks.response.WarBucks, 1_000);

  const gold = grantVideoAdRewardState(state(), NOW, 5, VideoAdRewardKind.GoldenSuitcase, picker(1));
  assert.equal(gold.state.gold, 5);
  assert.equal(gold.response.Gold, 5);

  const card = grantVideoAdRewardState(state(), NOW, 5, VideoAdRewardKind.GoldenSuitcase, picker(2, 0));
  assert.equal((card.response.AddedCards as string[]).length, 1);

  const visualIndex = VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.indexOf("HEAD_CLOWN");
  assert.notEqual(visualIndex, -1);
  const lootbox = grantVideoAdRewardState(
    state(),
    NOW,
    5,
    VideoAdRewardKind.GoldenSuitcase,
    picker(3, visualIndex),
  );
  assert.deepEqual(JSON.parse(lootbox.response.NewVisuals as string), { HEAD_CLOWN: "1" });
  assert.equal(lootbox.state.visualInventory?.visuals.HEAD_CLOWN?.parts, 1);
});

test("LootBox ad shares normal visual-part and duplicate conversion authority", () => {
  const visualIndex = VIP_LOOTBOX_ELIGIBLE_VISUAL_IDS.indexOf("HEAD_CLOWN");
  const initial = state();
  initial.visualInventory!.visuals.HEAD_CLOWN = {
    bought: true,
    showed: false,
    expiresOn: 0,
    borrowed: false,
    parts: 2,
    notificate: false,
  };
  const result = grantVideoAdRewardState(
    initial,
    NOW,
    5,
    VideoAdRewardKind.LootBox,
    picker(visualIndex),
  );

  assert.equal(result.state.warBucks, 1_000);
  assert.deepEqual(JSON.parse(result.response.NewVisuals as string), { HEAD_CLOWN: "1" });
  assert.deepEqual(result.state.videoAdRewards?.times.lootboxes, [NOW]);
});

test("rolling caps, Golden spacing, and future timestamps fail closed while expired timestamps leave", () => {
  const capped = state();
  capped.videoAdRewards = {
    times: {
      warcards: Array.from({ length: 24 }, (_, index) => NOW - index),
      dogtags: [],
      goldenSuitcase: [],
      lootboxes: [],
    },
  };
  assert.throws(
    () => grantVideoAdRewardState(capped, NOW, 5, VideoAdRewardKind.RandomCard, picker(0)),
    /limit reached/,
  );

  const cooling = state();
  cooling.videoAdRewards = {
    times: { warcards: [], dogtags: [], goldenSuitcase: [NOW - 30], lootboxes: [] },
  };
  assert.throws(
    () => grantVideoAdRewardState(cooling, NOW, 5, VideoAdRewardKind.GoldenSuitcase, picker(0)),
    /cooling down/,
  );
  const cooled = grantVideoAdRewardState(cooling, NOW + 30, 5, VideoAdRewardKind.GoldenSuitcase, picker(0));
  assert.deepEqual(cooled.state.videoAdRewards?.times.goldenSuitcase, [NOW - 30, NOW + 30]);

  const expired = state();
  expired.videoAdRewards = {
    times: {
      warcards: [NOW - VIDEO_AD_LIMITS[VideoAdRewardKind.RandomCard].intervalSeconds - 1],
      dogtags: [],
      goldenSuitcase: [],
      lootboxes: [],
    },
  };
  const renewed = grantVideoAdRewardState(expired, NOW, 5, VideoAdRewardKind.RandomCard, picker(0));
  assert.deepEqual(renewed.state.videoAdRewards?.times.warcards, [NOW]);

  const future = state();
  future.videoAdRewards = {
    times: {
      warcards: Array.from({ length: 24 }, (_, index) => NOW + index + 1),
      dogtags: [],
      goldenSuitcase: [],
      lootboxes: [],
    },
  };
  assert.throws(
    () => grantVideoAdRewardState(future, NOW, 5, VideoAdRewardKind.RandomCard, picker(0)),
    /limit reached/,
  );
});

test("persisted video-ad ledgers reject malformed authority instead of reopening capacity", () => {
  const valid = { warcards: [NOW], dogtags: [], goldenSuitcase: [], lootboxes: [] };
  assert.deepEqual(validatedVideoAdRewardTimes(valid, NOW), valid);

  for (const timestamp of [Number.NaN, Number.POSITIVE_INFINITY, 0, -1, 1.5]) {
    assert.throws(
      () => validatedVideoAdRewardTimes({ ...valid, warcards: [timestamp] }, NOW),
      /Video ad reward timestamp is invalid/,
    );
  }
  assert.throws(
    () => validatedVideoAdRewardTimes({ ...valid, dogtags: undefined } as never, NOW),
    /Video ad reward ledger is invalid/,
  );
  assert.throws(
    () => validatedVideoAdRewardTimes({
      ...valid,
      lootboxes: Array.from({ length: 25 }, (_, index) => NOW - index),
    }, NOW),
    /Video ad reward ledger is invalid/,
  );

  const poisoned = state();
  poisoned.videoAdRewards = { times: { ...valid, warcards: [Number.POSITIVE_INFINITY] } };
  assert.throws(
    () => grantVideoAdRewardState(poisoned, NOW, 5, VideoAdRewardKind.RandomCard, picker(0)),
    /Video ad reward timestamp is invalid/,
  );
});

test("same-revision HTTP replay returns the immutable receipt without a second grant", () => {
  const first = grantVideoAdRewardState(state(), NOW, 5, VideoAdRewardKind.RandomCard, picker(0));
  const replay = grantVideoAdRewardState(first.state, NOW + 5, 5, VideoAdRewardKind.RandomCard, () => {
    throw new Error("a replay must not reroll");
  });

  assert.equal(replay.state, first.state);
  assert.equal(replay.replayed, true);
  assert.deepEqual(replay.response, first.response);
  assert.deepEqual(replay.state.videoAdRewards?.times.warcards, [NOW]);
});

test("GetPlayerData restores only the public videoAdRewardTimes arrays", () => {
  const dto = newPlayer("video-ad-player", "VideoAdPlayer", AccountType.Guest);
  const progression = state();
  progression.videoAdRewards = {
    times: { warcards: [NOW], dogtags: [], goldenSuitcase: [], lootboxes: [] },
    lastReceipt: {
      reward: VideoAdRewardKind.RandomCard,
      settledAt: NOW,
      progressionRevision: 1,
      response: { AddedCards: ["AIRSTRIKE"] },
    },
  };
  const player: PlayerDocument = {
    id: dto.id,
    accountName: dto.accountName,
    authToken: "token",
    accountType: dto.accountType,
    leagueTier: dto.leagueTier,
    armyPower: dto.armyPower,
    experience: dto.experience,
    squadPoints: dto.squadPoints,
    squadName: dto.squadName,
    player: dto,
    progression,
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };

  const wire = buildPlayerData(player, NOW);
  const restored = JSON.parse((wire.videoAdRewardTimes as { S: string }).S);
  assert.deepEqual(restored, progression.videoAdRewards.times);
  assert.equal(JSON.stringify(restored).includes("lastReceipt"), false);
});

test("GetPlayerData validates and window-normalizes video-ad ledgers before boot projection", () => {
  const dto = newPlayer("video-ad-window-player", "VideoAdWindowPlayer", AccountType.Guest);
  const progression = state();
  progression.videoAdRewards = {
    times: {
      warcards: [NOW + 1, NOW - VIDEO_AD_LIMITS[VideoAdRewardKind.RandomCard].intervalSeconds - 1, NOW],
      dogtags: [],
      goldenSuitcase: [],
      lootboxes: [],
    },
  };
  const player: PlayerDocument = {
    id: dto.id,
    accountName: dto.accountName,
    authToken: "token",
    accountType: dto.accountType,
    leagueTier: dto.leagueTier,
    armyPower: dto.armyPower,
    experience: dto.experience,
    squadPoints: dto.squadPoints,
    squadName: dto.squadName,
    player: dto,
    progression,
    createdAt: new Date(NOW * 1_000),
    updatedAt: new Date(NOW * 1_000),
  };

  const restored = JSON.parse(
    (buildPlayerData(player, NOW).videoAdRewardTimes as { S: string }).S,
  );
  assert.deepEqual(restored.warcards, [NOW, NOW + 1]);

  progression.videoAdRewards.times.warcards = [Number.POSITIVE_INFINITY];
  assert.throws(() => buildPlayerData(player, NOW), /Video ad reward timestamp is invalid/);
});
