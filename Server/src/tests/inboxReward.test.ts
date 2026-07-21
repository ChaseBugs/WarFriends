import assert from "node:assert/strict";
import test from "node:test";
import { createInitialProgression } from "../services/playerStateService";
import { applyInboxGoldRewardState } from "../services/socialService";
import { validatedInboxRewardMessage } from "../services/inboxRewardAuthorityService";
import type { MessageDoc } from "../services/socialService";

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

test("reward inbox authority binds the payload to its terminal replay response", () => {
  const message: MessageDoc = {
    messageId: "player-league-finished:league-1:player-1",
    idempotencyKey: "player-league-finished:league-1:player-1",
    toPlayerId: "player-1",
    fromPlayerId: "system",
    fromName: "Player League",
    body: "",
    messageType: 23,
    payload: {
      LeagueId: 7,
      BeforeLeagueId: 6,
      Medals: 42,
      FormerFullLeagueId: "6-1700000000-local1",
      RewardGold: 60,
      Position: 2,
    },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: new Date("2026-07-21T00:00:00.000Z"),
  };

  assert.deepEqual(validatedInboxRewardMessage(message), { Gold: 60, Warbucks: 0 });
  assert.throws(
    () => validatedInboxRewardMessage({ ...message, payload: { ...message.payload, RewardGold: Number.NaN } }),
    /Stored inbox reward message is invalid/,
  );
  assert.throws(
    () => validatedInboxRewardMessage({ ...message, rewardClaimed: true, claimResponse: { Gold: 61, Warbucks: 0 } }),
    /Stored inbox reward message is invalid/,
  );
  assert.deepEqual(
    validatedInboxRewardMessage({
      ...message,
      read: true,
      ignored: true,
      rewardClaimed: true,
      claimResponse: { Gold: 60, Warbucks: 0 },
    }),
    { Gold: 60, Warbucks: 0 },
  );
});
