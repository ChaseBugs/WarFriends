import assert from "node:assert/strict";
import test from "node:test";
import { DbAction } from "../dbActions";
import {
  ACHIEVEMENT_ALREADY_CLAIMED,
  ACHIEVEMENT_REWARD_NOT_FOUND,
  acknowledgeAchievementOffsetState,
  achievementStateFor,
  advanceAchievementState,
  claimAchievementState,
  serializeAchievementsData,
  validateAchievementProgressState,
} from "../services/achievementService";
import { processAssignmentBufferState } from "../services/assignmentService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;

test("achievement state uses the exact recovered AchievementsData wire fields", () => {
  const achievements = achievementStateFor(createInitialProgression(NOW));
  const rankedWins = achievements.data.find((group) => group.id === 2)!;

  assert.deepEqual(rankedWins, {
    id: 2,
    offset: 0,
    value: 0,
    progress: [{ claimed: false }, { claimed: false }, { claimed: false }],
  });
  assert.deepEqual(Object.keys(JSON.parse(serializeAchievementsData(achievements))), ["data"]);
});

test("only confirmed events can advance supported achievement counters", () => {
  const initial = createInitialProgression(NOW);
  const advanced = advanceAchievementState(initial, 2, 1);
  assert.equal(advanced.achievements.data.find((group) => group.id === 2)?.value, 1);

  // The old client reports its local StatsManager total through action 220. A number above
  // the server-owned total must not become reward-authoritative state.
  assert.throws(
    () => validateAchievementProgressState(advanced.state, 2, 10),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_REWARD_NOT_FOUND,
  );
  assert.doesNotThrow(() => validateAchievementProgressState(advanced.state, 2, 1));

  const offset = acknowledgeAchievementOffsetState(advanced.state, 2, -999);
  assert.equal(offset.achievements.data.find((group) => group.id === 2)?.offset, 0);
});

test("achievement claims enforce tier order and credit scene-defined rewards once", () => {
  let state = createInitialProgression(NOW);
  state = advanceAchievementState(state, 2, 10).state;

  assert.throws(
    () => claimAchievementState(state, 2, 1),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_REWARD_NOT_FOUND,
  );

  const claim = claimAchievementState(state, 2, 0);
  assert.equal(claim.state.gold, 1);
  assert.equal(claim.achievements.data.find((group) => group.id === 2)?.progress[0].claimed, true);
  assert.throws(
    () => claimAchievementState(claim.state, 2, 0),
    (error: unknown) => (error as { code?: number }).code === ACHIEVEMENT_ALREADY_CLAIMED,
  );
});

test("achievement RequestBuffer replay cannot grant the same tier twice", () => {
  let state = createInitialProgression(NOW);
  state = advanceAchievementState(state, 2, 10).state;
  const requests = [
    { action: DbAction.ChangeAchievementProgres, data: JSON.stringify({ Id: 2, Progress: 10 }) },
    { action: DbAction.ClaimAchievement, data: JSON.stringify({ Id: 2, ProgressId: 0 }) },
  ];

  const first = processAssignmentBufferState(state, NOW, "achievement-buffer", requests);
  assert.equal(first.state.gold, 1);
  assert.deepEqual(JSON.parse(first.requestsResults), [
    { ActionId: DbAction.ChangeAchievementProgres, Result: 1 },
    { ActionId: DbAction.ClaimAchievement, Result: 1 },
  ]);

  const replay = processAssignmentBufferState(first.state, NOW + 1, "achievement-buffer", requests);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.gold, 1);
  assert.equal(replay.requestsResults, first.requestsResults);
});
