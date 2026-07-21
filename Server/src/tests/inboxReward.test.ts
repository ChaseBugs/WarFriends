import assert from "node:assert/strict";
import test from "node:test";
import { createInitialProgression } from "../services/playerStateService";
import { applyInboxGoldRewardState } from "../services/socialService";

test("inbox Gold transition advances wallet and revision exactly once", () => {
  const initial = { ...createInitialProgression(1_000), gold: 25, revision: 7 };
  const rewarded = applyInboxGoldRewardState(initial, 50);

  assert.equal(rewarded.gold, 75);
  assert.equal(rewarded.revision, 8);
  assert.equal(initial.gold, 25);
  assert.equal(initial.revision, 7);
});

test("inbox Gold transition rejects malformed reward, balance, and revision authority", () => {
  const initial = createInitialProgression(1_000);
  assert.throws(() => applyInboxGoldRewardState(initial, 0), /Stored inbox Gold reward is invalid/);
  assert.throws(
    () => applyInboxGoldRewardState({ ...initial, tickets: -1 }, 1),
    /Stored Tickets balance is invalid/,
  );
  assert.throws(
    () => applyInboxGoldRewardState({ ...initial, gold: Number.MAX_SAFE_INTEGER }, 1),
    /Inbox Gold reward balance overflowed/,
  );
  assert.throws(
    () => applyInboxGoldRewardState({ ...initial, revision: Number.MAX_SAFE_INTEGER }, 1),
    /Stored progression revision is invalid/,
  );
});
