import assert from "node:assert/strict";
import test from "node:test";
import {
  rankSquadWarDivision,
  squadWarMemberReward,
  squadWarNextLevel,
  squadWarRewardTier,
  squadWarRoundId,
  squadWarWindowAt,
} from "../services/squadWarContract";
import {
  addConfirmedSquadWarScoreState,
  requireSquadWarSettlementAvailability,
  requireSquadWarScoringEntryIndex,
  squadWarRewardEligiblePlayerIds,
} from "../services/squadWarService";
import {
  claimableMessageReward,
  toClientMessage,
  type MessageDoc,
} from "../services/socialService";

test("Squad Wars reward tiers reproduce the recovered 4.9.5 boundaries", () => {
  // A small seven-squad division uses fixed rank cutoffs: 1-3, 4-5, and 6-7.
  assert.deepEqual(
    Array.from({ length: 7 }, (_, index) => squadWarRewardTier(index + 1, 7)),
    [1, 1, 1, 2, 2, 3, 3],
  );

  // The serialized large-division percentage rows put the first squad in tier 1, ranks 2-10
  // in tier 2, 11-16 in tier 3, 17-25 in tier 4, and the remainder in no reward.
  assert.equal(squadWarRewardTier(1, 50), 1);
  assert.equal(squadWarRewardTier(10, 50), 2);
  assert.equal(squadWarRewardTier(11, 50), 3);
  assert.equal(squadWarRewardTier(16, 50), 3);
  assert.equal(squadWarRewardTier(17, 50), 4);
  assert.equal(squadWarRewardTier(25, 50), 4);
  assert.equal(squadWarRewardTier(26, 50), 0);
});

test("Squad Wars member Gold uses level reward and recovered rank fractions", () => {
  assert.equal(squadWarMemberReward(1, 1, 1), 100);
  assert.equal(squadWarMemberReward(1, 1, 2), 50);
  assert.equal(squadWarMemberReward(1, 1, 6), 33);
  assert.equal(squadWarMemberReward(1, 1, 11), 20);
  assert.equal(squadWarMemberReward(1, 1, 41), 2);
  // 111 / 3 = 37 and proves the level-eight table is selected independently of rank.
  assert.equal(squadWarMemberReward(5, 8, 6), 37);
  assert.equal(squadWarMemberReward(0, 8, 1), 0);
});

test("Squad Wars placement is deterministic and applies promotion or demotion", () => {
  const values = Array.from({ length: 10 }, (_, index) => ({
    squadId: `Squad-${String(index).padStart(2, "0")}`,
    baseScore: index === 0 ? 50 : 0,
    score: index === 1 ? 50 : 10 - index,
  }));
  const ranked = rankSquadWarDivision(values, 4);

  // Equal totals use the stable squad ID tie-breaker, never MongoDB's unspecified row order.
  assert.equal(ranked[0]?.squadId, "Squad-00");
  assert.equal(ranked[1]?.squadId, "Squad-01");
  assert.equal(ranked[0]?.nextLevel, 5);
  assert.equal(ranked[1]?.nextLevel, 4);
  assert.equal(ranked[9]?.nextLevel, 3);
  assert.equal(squadWarNextLevel(1, 7, 4), 4, "small divisions never change level");
  assert.equal(squadWarNextLevel(1, 50, 8), 8, "top level cannot promote");
  assert.equal(squadWarNextLevel(50, 50, 1), 1, "bottom level cannot demote");
});

test("Squad Wars placement rejects non-finite or overflowing totals", () => {
  assert.throws(
    () => rankSquadWarDivision([{ squadId: "Alpha", baseScore: 0, score: Number.NaN }], 1),
    /placement score is invalid/,
  );
  assert.throws(
    () => rankSquadWarDivision([{
      squadId: "Alpha",
      baseScore: Number.MAX_SAFE_INTEGER,
      score: 1,
    }], 1),
    /placement score is invalid/,
  );
});

test("confirmed Squad War scoring validates squad and member counters before addition", () => {
  const entry = {
    squadId: "Alpha",
    squadIcon: "menu-squad-1",
    baseScore: 10,
    score: 5,
    wins: 1,
    members: [{ playerId: "player-1", name: "Player", score: 5, rewardEligible: true }],
  };
  const updated = addConfirmedSquadWarScoreState(entry, { playerId: "player-1", name: "Player" }, 3);
  assert.equal(updated.score, 8);
  assert.equal(updated.wins, 2);
  assert.equal(updated.members[0]!.score, 8);
  assert.equal(entry.score, 5);
  assert.equal(entry.members[0]!.score, 5);

  assert.throws(
    () => addConfirmedSquadWarScoreState(
      { ...entry, members: [{ ...entry.members[0]!, score: Number.NaN }] },
      { playerId: "player-1", name: "Player" },
      3,
    ),
    /member score is invalid/,
  );
  assert.throws(
    () => addConfirmedSquadWarScoreState(
      { ...entry, baseScore: Number.MAX_SAFE_INTEGER, score: 0 },
      { playerId: "player-1", name: "Player" },
      1,
    ),
    /score is invalid/,
  );
});

test("Squad Wars reconstructed schedule emits client-parseable stable round IDs", () => {
  const window = squadWarWindowAt(new Date("2026-07-21T12:34:56.000Z"));
  assert.equal(window.startsAt.toISOString(), "2026-07-20T00:00:00.000Z");
  assert.equal(window.endsAt.toISOString(), "2026-07-27T00:00:00.000Z");
  assert.match(window.seasonId, /^sw[0-9a-z]+$/u);
  assert.match(squadWarRoundId(4, window, 3), /^4-[0-9a-z]+$/u);
  assert.equal(squadWarRoundId(4, window, 3), squadWarRoundId(4, window, 3));
});

test("Squad War settlement skips only disabled or terminal windows and retries maintenance", () => {
  assert.equal(requireSquadWarSettlementAvailability(false, false, false), false);
  assert.equal(requireSquadWarSettlementAvailability(true, true, false), true);
  assert.equal(requireSquadWarSettlementAvailability(true, false, true), false);
  assert.throws(
    () => requireSquadWarSettlementAvailability(true, false, false),
    /maintenance is still in progress/,
  );
});

test("Squad War scoring requires an in-window round entry instead of silently losing points", () => {
  const startsAt = new Date("2026-07-20T00:00:00Z");
  const endsAt = new Date("2026-07-27T00:00:00Z");
  const round = {
    roundId: "war-round-1",
    startsAt,
    endsAt,
    entries: [{ squadId: "Alpha" }],
  };
  assert.equal(requireSquadWarScoringEntryIndex(round, "Alpha", startsAt), 0);
  assert.throws(
    () => requireSquadWarScoringEntryIndex(round, "Bravo", startsAt),
    /missing from assigned Squad Wars round/,
  );
  assert.throws(
    () => requireSquadWarScoringEntryIndex(round, "Alpha", endsAt),
    /outside the match settlement window/,
  );
});

test("Squad Wars rewards only round-start members who still belong to the squad", () => {
  const entry = {
    members: [
      // Missing rewardEligible represents a legacy round and remains eligible for compatibility.
      { playerId: "legacy", name: "Legacy", score: 0 },
      { playerId: "starter", name: "Starter", score: 10, rewardEligible: true },
      { playerId: "late", name: "Late", score: 20, rewardEligible: false },
      { playerId: "left", name: "Left", score: 30, rewardEligible: true },
    ],
  };
  assert.deepEqual(
    squadWarRewardEligiblePlayerIds(entry, new Set(["legacy", "starter", "late"])),
    ["legacy", "starter"],
  );
});

test("SquadWarEnd message exposes the exact type-9 Dynamo contract and server-owned claim", () => {
  const message: MessageDoc = {
    messageId: "SquadWarEnd-4-round-player-1",
    idempotencyKey: "squad-war-end:4-round:player-1",
    toPlayerId: "player-1",
    fromPlayerId: "server",
    fromName: "Squad Wars",
    body: "Squad Wars division finished.",
    messageType: 9,
    payload: {
      Position: 2,
      SquadId: "Alpha",
      SquadIcon: "menu-squad-8",
      RewardGold: 50,
      PrevLevelId: 4,
      NewLevelId: 5,
      SquadMembers: '[{"Id":{"S":"player-1"},"SquadPoints":{"N":"12"}}]',
    },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: new Date("2026-07-27T00:00:00.000Z"),
  };

  const wire = toClientMessage(message);
  assert.deepEqual(wire.MessageType, { N: "9" });
  assert.deepEqual(wire.Position, { N: "2" });
  assert.deepEqual(wire.SquadId, { S: "Alpha" });
  assert.deepEqual(wire.SquadIcon, { S: "menu-squad-8" });
  assert.deepEqual(wire.RewardGold, { N: "50" });
  assert.deepEqual(wire.PrevLevelId, { N: "4" });
  assert.deepEqual(wire.NewLevelId, { N: "5" });
  assert.deepEqual(wire.SquadMembers, { S: message.payload.SquadMembers as string });
  assert.deepEqual(claimableMessageReward(message), { Gold: 50, Warbucks: 0 });
  assert.equal(claimableMessageReward({ ...message, payload: { ...message.payload, RewardGold: 0 } }), null);
});
