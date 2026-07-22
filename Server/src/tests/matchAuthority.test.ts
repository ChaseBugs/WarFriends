import assert from "node:assert/strict";
import test from "node:test";
import {
  completeBothPlayersDisconnectedAuthority,
  matchesBothPlayersDisconnectedAuthority,
  matchesDisconnectForfeitAuthority,
  matchesParticipantDisconnectMarker,
  terminalMatchReportResult,
  type MatchDoc,
  type MatchPlayerReward,
} from "../services/matchService";
import { validatedMatchDocument } from "../services/matchAuthorityService";

const CREATED_AT = new Date("2026-07-21T10:00:00.000Z");
const STARTED_AT = new Date("2026-07-21T10:00:05.000Z");
const ENDED_AT = new Date("2026-07-21T10:03:00.000Z");
const NOW = new Date("2026-07-21T10:03:01.000Z");
const MATCH_ID = "11111111-1111-4111-8111-111111111111";

function reward(values: Partial<MatchPlayerReward> = {}): MatchPlayerReward {
  return {
    baseWarBucks: 800,
    warBucks: 800,
    baseWinStreakWarBucks: 0,
    winStreakWarBucks: 0,
    winCount: 0,
    winStreakTimestamp: 0,
    baseLeagueWarBucks: 0,
    leagueWarBucks: 0,
    squadPoints: 0,
    skill: 25,
    medalsBalance: 25,
    placementMatchesRequired: 0,
    beginnersLeague: 0,
    baseExperience: 30,
    experience: 30,
    baseGold: 0,
    gold: 0,
    isVip: false,
    matchesToNextLootboxes: 3,
    lootboxWarBucks: 0,
    levelFrom: 0,
    levelTo: 0,
    levelExperience: 30,
    rentalSettled: true,
    ...values,
  };
}

function activeMatch(values: Partial<MatchDoc> = {}): MatchDoc {
  return {
    matchId: MATCH_ID,
    coordinatorId: "node-1",
    joinedPlayerIds: ["player-a", "player-b"],
    roomStartedAt: STARTED_AT,
    players: [
      { playerId: "player-a", name: "Alpha", armyPower: 100, leagueTier: 1 },
      { playerId: "player-b", name: "Bravo", armyPower: 125.5, leagueTier: 2 },
    ],
    state: "active",
    relayedCardPlays: { "player-a": ["CARD_A"] },
    relayedCardDeliveries: { "player-a": [0] },
    createdAt: CREATED_AT,
    ...values,
  };
}

test("complete ranked-match authority binds room, card, terminal, and reward state", () => {
  const active = activeMatch();
  assert.equal(validatedMatchDocument(active, NOW), active);

  const cancelled: MatchDoc = {
    ...active,
    state: "cancelled",
    cancelReason: "server_restart",
    endedAt: ENDED_AT,
  };
  assert.equal(validatedMatchDocument(cancelled, NOW), cancelled);

  const finished: MatchDoc = {
    ...active,
    state: "finished",
    winnerId: "player-a",
    resultReports: { "player-a": "player-a", "player-b": "player-a" },
    usedCardsReports: { "player-a": ["CARD_A"], "player-b": [] },
    rewardReceipts: { "player-a": reward(), "player-b": reward({ baseExperience: 10, experience: 10 }) },
    endedAt: ENDED_AT,
  };
  assert.equal(validatedMatchDocument(finished, NOW), finished);
  const legacyReward = { ...reward() } as Partial<MatchPlayerReward>;
  delete legacyReward.rentalSettled;
  assert.doesNotThrow(() => validatedMatchDocument({
    ...finished,
    rewardReceipts: {
      "player-a": legacyReward as MatchPlayerReward,
      "player-b": reward({ baseExperience: 10, experience: 10 }),
    },
  }, NOW));
});

test("terminal result replay follows finished and conflict-cancelled durable rows", () => {
  const rewards = { "player-a": reward(), "player-b": reward({ baseExperience: 10, experience: 10 }) };
  const finished = activeMatch({
    state: "finished",
    winnerId: "player-a",
    resultReports: { "player-a": "player-a", "player-b": "player-a" },
    rewardReceipts: rewards,
    endedAt: ENDED_AT,
  });
  assert.deepEqual(terminalMatchReportResult(finished, "player-b"), {
    status: "finished",
    settlement: {
      matchId: MATCH_ID,
      winnerId: "player-a",
      rewarded: false,
      rewards,
    },
  });
  assert.deepEqual(terminalMatchReportResult(activeMatch({
    state: "cancelled",
    cancelReason: "result_conflict",
    endedAt: ENDED_AT,
  }), "player-a"), { status: "conflict" });
  assert.deepEqual(terminalMatchReportResult(activeMatch({
    state: "cancelled",
    cancelReason: "server_restart",
    endedAt: ENDED_AT,
  }), "player-a"), { status: "invalid" });
  assert.equal(terminalMatchReportResult(activeMatch(), "player-a"), null);
});

test("disconnect forfeit authority binds the exact loser marker", () => {
  const disconnectedAt = new Date("2026-07-21T10:01:00.000Z");
  const disconnected = activeMatch({ disconnectedAt: { "player-b": disconnectedAt } });
  assert.equal(matchesDisconnectForfeitAuthority(disconnected, "player-a", {
    disconnectedPlayerId: "player-b",
    disconnectedAt: new Date(disconnectedAt),
  }), true);
  assert.equal(matchesDisconnectForfeitAuthority(disconnected, "player-a", {
    disconnectedPlayerId: "player-b",
    disconnectedAt: new Date(disconnectedAt.getTime() + 1),
  }), false);
  assert.equal(matchesDisconnectForfeitAuthority(activeMatch(), "player-a", {
    disconnectedPlayerId: "player-b",
    disconnectedAt,
  }), false);
  assert.equal(matchesDisconnectForfeitAuthority(disconnected, "player-b", {
    disconnectedPlayerId: "player-b",
    disconnectedAt,
  }), false);
  assert.equal(matchesDisconnectForfeitAuthority({
    ...disconnected,
    joinedPlayerIds: undefined,
  }, "player-a", {
    disconnectedPlayerId: "player-b",
    disconnectedAt,
  }), false);
});

test("reconnect clearing binds the disconnect generation observed by durable join", () => {
  const observed = new Date("2026-07-21T10:01:00.000Z");
  const disconnected = activeMatch({ disconnectedAt: { "player-b": observed } });
  assert.equal(matchesParticipantDisconnectMarker(disconnected, "player-b", new Date(observed)), true);
  assert.equal(matchesParticipantDisconnectMarker(disconnected, "player-b", new Date(observed.getTime() + 1)), false);
  assert.equal(matchesParticipantDisconnectMarker(disconnected, "player-a", observed), false);
  assert.equal(matchesParticipantDisconnectMarker(activeMatch(), "player-b", observed), false);
  assert.equal(matchesParticipantDisconnectMarker({
    ...disconnected,
    roomStartedAt: undefined,
  }, "player-b", observed), false);
});

test("both-offline cancellation requires both exact durable disconnect markers", () => {
  const playerA = new Date("2026-07-21T10:01:00.000Z");
  const playerB = new Date("2026-07-21T10:01:01.000Z");
  const disconnected = activeMatch({ disconnectedAt: { "player-a": playerA, "player-b": playerB } });
  const authority = completeBothPlayersDisconnectedAuthority(disconnected);
  assert.ok(authority);
  assert.equal(matchesBothPlayersDisconnectedAuthority(disconnected, authority), true);
  assert.equal(completeBothPlayersDisconnectedAuthority(activeMatch({
    disconnectedAt: { "player-a": playerA },
  })), null);
  assert.equal(matchesBothPlayersDisconnectedAuthority(activeMatch({
    disconnectedAt: { "player-a": playerA, "player-b": new Date(playerB.getTime() + 1) },
  }), authority), false);
  assert.equal(matchesBothPlayersDisconnectedAuthority(activeMatch(), authority), false);
  assert.equal(completeBothPlayersDisconnectedAuthority({
    ...disconnected,
    roomStartedAt: undefined,
  }), null);
});

test("ranked-match authority rejects unsafe dynamic identities and contradictory lifecycle state", () => {
  assert.throws(
    () => validatedMatchDocument(activeMatch({
      players: [
        { playerId: "player.a", name: "Alpha", armyPower: 100, leagueTier: 1 },
        { playerId: "player-b", name: "Bravo", armyPower: 125, leagueTier: 2 },
      ],
      joinedPlayerIds: ["player.a", "player-b"],
    }), NOW),
    /participant authority/,
  );
  assert.throws(
    () => validatedMatchDocument(activeMatch({ joinedPlayerIds: ["player-a", "player-a"] }), NOW),
    /room-admission authority/,
  );
  assert.throws(
    () => validatedMatchDocument(activeMatch({ joinedPlayerIds: ["player-a"] }), NOW),
    /room-start authority/,
  );
  assert.throws(
    () => validatedMatchDocument(activeMatch({
      relayedCardDeliveries: { "player-a": [1] },
    }), NOW),
    /card-delivery evidence/,
  );
  assert.throws(
    () => validatedMatchDocument(activeMatch({
      relayedCardPlays: { "player-a": ["CARD_A", "CARD_B"] },
      relayedCardDeliveries: { "player-a": [0, 0] },
    }), NOW),
    /card-delivery evidence/,
  );
  assert.throws(
    () => validatedMatchDocument(activeMatch({
      usedCardsReports: { "player-a": ["CARD_A"] },
      relayedCardDeliveries: { "player-a": [] },
    }), NOW),
    /used-card report exceeds delivered relay evidence/,
  );
  assert.throws(
    () => validatedMatchDocument(activeMatch({
      rewardReceipts: { "player-a": reward(), "player-b": reward() },
    }), NOW),
    /terminal authority/,
  );
});

test("ranked-match authority keeps gameplay evidence behind the durable room-start boundary", () => {
  const unstarted = activeMatch({
    joinedPlayerIds: undefined,
    roomStartedAt: undefined,
    relayedCardPlays: undefined,
    relayedCardDeliveries: undefined,
  });
  assert.equal(validatedMatchDocument(unstarted, NOW), unstarted);

  for (const evidence of [
    { disconnectedAt: { "player-a": STARTED_AT } },
    { resultReports: { "player-a": "player-a" } },
    { usedCardsReports: { "player-a": [] } },
    { relayedCardPlays: { "player-a": ["CARD_A"] } },
    { relayedCardDeliveries: { "player-a": [] } },
  ] satisfies Array<Partial<MatchDoc>>) {
    assert.throws(
      () => validatedMatchDocument({ ...unstarted, ...evidence }, NOW),
      /gameplay evidence exists before room start/,
    );
  }

  assert.throws(
    () => validatedMatchDocument({
      ...unstarted,
      state: "finished",
      winnerId: "player-a",
      rewardReceipts: { "player-a": reward(), "player-b": reward() },
      endedAt: ENDED_AT,
    }, NOW),
    /finished-match authority/,
  );

  // Join timeout and participant cancellation remain valid terminal outcomes before battle start.
  assert.doesNotThrow(() => validatedMatchDocument({
    ...unstarted,
    state: "cancelled",
    cancelReason: "join_timeout",
    endedAt: ENDED_AT,
  }, NOW));
});

test("finished ranked-match receipts reject forged multipliers and conflicting reports", () => {
  const finished = activeMatch({
    state: "finished",
    winnerId: "player-a",
    resultReports: { "player-a": "player-a", "player-b": "player-a" },
    rewardReceipts: { "player-a": reward(), "player-b": reward() },
    endedAt: ENDED_AT,
  });
  assert.throws(
    () => validatedMatchDocument({
      ...finished,
      rewardReceipts: { ...finished.rewardReceipts, "player-a": reward({ isVip: true, warBucks: 800 }) },
    }, NOW),
    /reward receipt/,
  );
  assert.throws(
    () => validatedMatchDocument({
      ...finished,
      rewardReceipts: {
        ...finished.rewardReceipts,
        "player-a": { ...reward(), rentalSettled: false as unknown as true },
      },
    }, NOW),
    /reward receipt/,
  );
  assert.throws(
    () => validatedMatchDocument({
      ...finished,
      resultReports: { "player-a": "player-a", "player-b": "player-b" },
    }, NOW),
    /conflicts/,
  );
  assert.throws(
    () => validatedMatchDocument({
      ...finished,
      state: "cancelled",
      cancelReason: "result_conflict",
    }, NOW),
    /cancelled-match authority/,
  );
});
