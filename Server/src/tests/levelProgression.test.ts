import assert from "node:assert/strict";
import test from "node:test";
import { createInitialProgression } from "../services/playerStateService";
import {
  PLAYER_LEVELS,
  applyLevelExperienceState,
  playerLevelDefinition,
} from "../services/levelProgressionService";

test("player-level catalog preserves all recovered XP, Gold, and rank-power rows", () => {
  assert.equal(PLAYER_LEVELS.length, 58);
  assert.deepEqual(playerLevelDefinition(0), {
    index: 0,
    displayLevel: 1,
    experience: 50_000,
    rewardGold: 5,
    armyPower: 93,
  });
  assert.deepEqual(playerLevelDefinition(57), {
    index: 57,
    displayLevel: 58,
    experience: 845_433_656,
    rewardGold: 60,
    armyPower: 1_060,
  });
  assert.throws(() => playerLevelDefinition(-1));
  assert.throws(() => playerLevelDefinition(58));
});

test("PvP XP crosses the exact threshold and grants the source level-up Gold", () => {
  const state = createInitialProgression(1_700_000_000);
  state.levelExperience = 49_980;
  state.gold = 7;
  const result = applyLevelExperienceState(state, 0, 30);
  assert.equal(result.levelFrom, 0);
  assert.equal(result.levelTo, 1);
  assert.equal(result.levelExperience, 10);
  assert.equal(result.goldGranted, 5);
  assert.equal(result.state.levelExperience, 10);
  assert.equal(result.state.gold, 12);
  // The enclosing match mutation owns the single revision increment.
  assert.equal(result.state.revision, state.revision);
});

test("level transition supports multiple rows and does not repeatedly reward max level", () => {
  const state = createInitialProgression(1_700_000_000);
  state.gold = 1;
  const result = applyLevelExperienceState(state, 0, 100_025);
  assert.equal(result.levelTo, 2);
  assert.equal(result.levelExperience, 25);
  assert.equal(result.goldGranted, 10);
  assert.equal(result.state.gold, 11);

  const max = createInitialProgression(1_700_000_000);
  max.levelExperience = 845_433_650;
  max.gold = 9;
  const maxResult = applyLevelExperienceState(max, 57, 30);
  assert.equal(maxResult.levelTo, 57);
  assert.equal(maxResult.levelExperience, 845_433_680);
  assert.equal(maxResult.goldGranted, 0);
  assert.equal(maxResult.state.gold, 9);
});
