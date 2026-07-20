import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { newPlayer } from "../dtos";
import { buildPlayerData, createInitialProgression } from "../services/playerStateService";
import {
  applyOneTimeRewardState,
  ONE_TIME_REWARD_RULES,
  oneTimeRewardRule,
  oneTimeRewardWire,
} from "../services/oneTimeRewardService";

function playerDocument(): PlayerDocument {
  const player = newPlayer("one-time-player", "OneTimePlayer", AccountType.Guest);
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
    progression: createInitialProgression(1_700_000_000),
    createdAt: new Date(1_700_000_000_000),
    updatedAt: new Date(1_700_000_000_000),
  };
}

test("one-time reward catalog preserves exact decoded MainScene Gold values", () => {
  assert.deepEqual([...ONE_TIME_REWARD_RULES], [
    { id: "FacebookLike", gold: 10, trigger: "direct" },
    { id: "TwitterFollow", gold: 10, trigger: "direct" },
    { id: "FacebookLoginReward", gold: 10, trigger: "facebook-link" },
    { id: "NotificationAllowReward", gold: 4, trigger: "direct" },
  ]);
});

test("one-time rewards credit once and leave the caller snapshot immutable", () => {
  const initial = { ...createInitialProgression(1_700_000_000), gold: 7 };
  const first = applyOneTimeRewardState(initial, "FacebookLike");
  assert.equal(first.wasAdded, true);
  assert.equal(first.state.gold, 17);
  assert.equal(first.state.revision, initial.revision + 1);
  assert.deepEqual(first.state.collectedRewards, { FacebookLike: 1 });
  assert.deepEqual(initial.collectedRewards, {});

  const replay = applyOneTimeRewardState(first.state, "FacebookLike");
  assert.equal(replay.wasAdded, false);
  assert.equal(replay.state, first.state);
  assert.equal(replay.state.gold, 17);
  assert.deepEqual(oneTimeRewardWire(first), {
    RewardId: "FacebookLike",
    Gold: 10,
    WasAdded: true,
  });
  assert.deepEqual(oneTimeRewardWire(replay), {
    RewardId: "FacebookLike",
    Gold: 10,
  });
});

test("unknown and malformed one-time reward IDs fail closed", () => {
  for (const invalid of ["UnknownReward", " FacebookLike", "facebooklike", "", 10]) {
    assert.throws(
      () => oneTimeRewardRule(invalid),
      (error: unknown) => typeof error === "object" && error !== null
        && "code" in error && error.code === ApiErrorCode.UnknownAction,
    );
  }
  assert.throws(
    () => oneTimeRewardRule("FacebookLoginReward"),
    (error: unknown) => typeof error === "object" && error !== null
      && "code" in error && error.code === ApiErrorCode.RequestNotAuthorized,
  );
  assert.equal(oneTimeRewardRule("FacebookLoginReward", "facebook-link").gold, 10);
});

test("PlayerAnalyticsData restores authoritative collected reward markers", () => {
  const player = playerDocument();
  player.progression = {
    ...createInitialProgression(1_700_000_000),
    collectedRewards: { FacebookLike: 1, NotificationAllowReward: 1 },
  };
  const wire = buildPlayerData(player);
  const analytics = JSON.parse((wire.PlayerAnalyticsData as { S: string }).S) as {
    collectedRewards: Record<string, number>;
  };
  assert.deepEqual(analytics.collectedRewards, {
    FacebookLike: 1,
    NotificationAllowReward: 1,
  });
});
