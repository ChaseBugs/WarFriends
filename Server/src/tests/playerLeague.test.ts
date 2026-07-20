import assert from "node:assert/strict";
import test from "node:test";
import { League } from "../constants";
import {
  advanceBeginnerLeagueAfterPvp,
  advancePlayerLeaguePlacementAfterPvp,
  BEGINNER_LEAGUE_REWARDS,
  BEGINNER_LEAGUE_RULES,
  beginnerLeaguePosition,
  managedPlayerLeagueId,
  parseManagedPlayerLeagueId,
  playerLeagueDivisionIndexForOrdinal,
  PLAYER_LEAGUE_MAXIMUM_PLAYERS,
  PLAYER_LEAGUE_MINIMUM_PLAYERS,
  PLAYER_LEAGUE_PLACEMENT_MATCHES,
  PLAYER_LEAGUE_RULES,
  playerLeagueBootFields,
  playerLeagueSettlementDecision,
} from "../services/playerLeagueContract";
import {
  claimableMessageReward,
  toClientMessage,
  type MessageDoc,
} from "../services/socialService";
import { socialHandlers } from "../handlers/social";
import { DbAction } from "../dbActions";

test("recovered player-league table preserves all 16 source tiers and constants", () => {
  assert.equal(PLAYER_LEAGUE_RULES.length, 16);
  assert.equal(PLAYER_LEAGUE_MINIMUM_PLAYERS, 30);
  assert.equal(PLAYER_LEAGUE_PLACEMENT_MATCHES, 1);
  assert.equal(PLAYER_LEAGUE_MAXIMUM_PLAYERS, 100);
  assert.deepEqual(
    PLAYER_LEAGUE_RULES.map((row) => row.durationHours),
    [24, 24, 24, 72, 72, 72, 168, 168, 168, 168, 168, 168, 168, 168, 168, 168],
  );
  assert.deepEqual(
    PLAYER_LEAGUE_RULES.map((row) => row.underfilledGold),
    [10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 125, 150, 175, 200, 225, 250],
  );
  assert.deepEqual(
    PLAYER_LEAGUE_RULES.map((row) => row.rewardWarBucks),
    [800, 900, 1000, 1250, 1500, 1750, 2000, 2250, 2500, 2750, 3000, 3250, 3500, 3750, 4000, 5000],
  );
  assert.deepEqual(PLAYER_LEAGUE_RULES.map((row) => row.rewardSquadPoints), [2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7]);
  assert.deepEqual([...BEGINNER_LEAGUE_REWARDS], [
    { beginnersLeague: 1, rewardWarBucks: 200, rewardSquadPoints: 1 },
    { beginnersLeague: 2, rewardWarBucks: 400, rewardSquadPoints: 1 },
    { beginnersLeague: 3, rewardWarBucks: 600, rewardSquadPoints: 1 },
  ]);
  assert.deepEqual([...BEGINNER_LEAGUE_RULES], [
    { beginnersLeague: 1, maxMedals: 50, promoteAtOrAbovePosition: 40 },
    { beginnersLeague: 2, maxMedals: 100, promoteAtOrAbovePosition: 35 },
    { beginnersLeague: 3, maxMedals: 150, promoteAtOrAbovePosition: 31 },
  ]);
});

test("beginner position math preserves exact recovered promotion boundaries", () => {
  assert.equal(beginnerLeaguePosition(1, 26), 41);
  assert.equal(beginnerLeaguePosition(1, 27), 39);
  assert.equal(beginnerLeaguePosition(2, 58), 36);
  assert.equal(beginnerLeaguePosition(2, 59), 35);
  assert.equal(beginnerLeaguePosition(3, 94), 32);
  assert.equal(beginnerLeaguePosition(3, 95), 31);
  assert.throws(() => beginnerLeaguePosition(4, 100), /Unsupported beginner league/);
});

test("confirmed medal state advances beginner tiers and enters a managed normal league", () => {
  const base = {
    beginnersLeague: 1,
    leagueTier: League.Bronze3,
    leagueId: "",
    leagueDivision: "",
    remainingMatches: 1,
  };
  assert.equal(advanceBeginnerLeagueAfterPvp(base, 26, 1_700_000_000), null);
  assert.deepEqual(advanceBeginnerLeagueAfterPvp(base, 27, 1_700_000_000), {
    beginnersLeague: 2,
    medalsBalance: 27,
    leagueTier: League.Bronze3,
    leagueId: "",
    leagueDivision: "",
    remainingMatches: 1,
    enteredBeginnerLeague: true,
    enteredNormalLeague: false,
  });

  const normal = advanceBeginnerLeagueAfterPvp({ ...base, beginnersLeague: 3 }, 95, 1_700_000_000);
  assert.equal(normal?.beginnersLeague, 0);
  assert.equal(normal?.medalsBalance, 0);
  assert.equal(normal?.remainingMatches, 0);
  assert.equal(normal?.enteredNormalLeague, true);
  assert.match(normal?.leagueId ?? "", /^1-\d+-local$/);
});

test("managed IDs preserve Unity's tier-first and division-last parsing contract", () => {
  const season = managedPlayerLeagueId(League.Silver2, 1_700_000_000);
  assert.match(season.leagueId, /^5-\d+-local$/);
  assert.deepEqual(parseManagedPlayerLeagueId(season.leagueId), {
    tier: League.Silver2,
    endsAt: season.endsAt,
    division: "local",
  });
  assert.equal(parseManagedPlayerLeagueId("5-placement"), null);
  assert.equal(parseManagedPlayerLeagueId("5-production-division"), null);
});

test("bounded reconstructed league IDs assign exactly 100 committed ordinals per division", () => {
  assert.equal(playerLeagueDivisionIndexForOrdinal(1), 1);
  assert.equal(playerLeagueDivisionIndexForOrdinal(100), 1);
  assert.equal(playerLeagueDivisionIndexForOrdinal(101), 2);
  assert.equal(playerLeagueDivisionIndexForOrdinal(200), 2);
  assert.equal(playerLeagueDivisionIndexForOrdinal(201), 3);
  assert.throws(() => playerLeagueDivisionIndexForOrdinal(0), /Invalid player league admission ordinal/);

  const bounded = managedPlayerLeagueId(League.Gold2, 1_700_000_000, 37);
  assert.match(bounded.leagueId, /^8-\d+-local37$/);
  assert.deepEqual(parseManagedPlayerLeagueId(bounded.leagueId), {
    tier: League.Gold2,
    endsAt: bounded.endsAt,
    division: "local37",
  });
  assert.equal(parseManagedPlayerLeagueId(`${League.Gold2}-${bounded.endsAt}-local0`), null);
});

test("league boot fields expose the timer and only mark an expired season processing", () => {
  const season = managedPlayerLeagueId(League.Gold3, 1_700_000_000);
  assert.deepEqual(playerLeagueBootFields(season.leagueId, season.endsAt - 1), {
    LeagueEvaluation: season.endsAt,
  });
  assert.deepEqual(playerLeagueBootFields(season.leagueId, season.endsAt), {
    LeagueEvaluation: season.endsAt,
    PlayerLeagueProcessing: true,
  });
  assert.deepEqual(playerLeagueBootFields("7-retired-production-id", season.endsAt), {});
});

test("only a confirmed PvP settlement decision can consume placement and enter a division", () => {
  const now = 1_700_000_000;
  const advanced = advancePlayerLeaguePlacementAfterPvp({
    beginnersLeague: 0,
    leagueTier: League.Bronze2,
    leagueId: "2-placement",
    remainingMatches: 1,
  }, now);
  assert.equal(advanced?.enteredLeague, true);
  assert.equal(advanced?.remainingMatches, 0);
  assert.match(advanced?.leagueId ?? "", /^2-\d+-local$/);

  assert.equal(advancePlayerLeaguePlacementAfterPvp({
    beginnersLeague: 1,
    leagueTier: League.Bronze3,
    leagueId: "",
    remainingMatches: 0,
  }, now), null);
  assert.equal(advancePlayerLeaguePlacementAfterPvp({
    beginnersLeague: 0,
    leagueTier: League.Gold2,
    leagueId: "8-retired-production-division",
    remainingMatches: 0,
  }, now), null);
});

test("normal divisions use the recovered promotion and relegation bands", () => {
  // Silver2 promotes 30% and relegates 10%. With 100 members that means 1..30 and 91..100.
  assert.deepEqual(playerLeagueSettlementDecision(League.Silver2, 30, 100), {
    nextTier: League.Silver1,
    rewardGold: 0,
    notEnoughPlayers: false,
    result: "promote",
  });
  assert.equal(playerLeagueSettlementDecision(League.Silver2, 31, 100).result, "stay");
  assert.equal(playerLeagueSettlementDecision(League.Silver2, 90, 100).result, "stay");
  assert.deepEqual(playerLeagueSettlementDecision(League.Silver2, 91, 100), {
    nextTier: League.Silver3,
    rewardGold: 0,
    notEnoughPlayers: false,
    result: "demote",
  });

  // The first tier of each metal band has no demotion in the archived table.
  assert.equal(playerLeagueSettlementDecision(League.Gold3, 100, 100).result, "stay");
});

test("underfilled divisions stay put and reward only the top ten percent", () => {
  const count = 30;
  assert.deepEqual(playerLeagueSettlementDecision(League.Elite2, 3, count), {
    nextTier: League.Elite2,
    rewardGold: 125,
    notEnoughPlayers: true,
    result: "stay",
  });
  assert.deepEqual(playerLeagueSettlementDecision(League.Elite2, 4, count), {
    nextTier: League.Elite2,
    rewardGold: 0,
    notEnoughPlayers: true,
    result: "stay",
  });
});

test("Champion uses recovered first, second, and remaining top-ten-percent rewards", () => {
  assert.equal(playerLeagueSettlementDecision(League.Champion, 1, 100).rewardGold, 700);
  assert.equal(playerLeagueSettlementDecision(League.Champion, 2, 100).rewardGold, 350);
  assert.equal(playerLeagueSettlementDecision(League.Champion, 10, 100).rewardGold, 150);
  assert.equal(playerLeagueSettlementDecision(League.Champion, 11, 100).rewardGold, 0);
  assert.equal(playerLeagueSettlementDecision(League.Champion, 91, 100).result, "demote");
});

test("PlayerLeagueFinished inbox messages use MMKFEEGDFKN's typed attribute contract", () => {
  const message: MessageDoc = {
    messageId: "player-league-result",
    toPlayerId: "league-player",
    fromPlayerId: "system",
    fromName: "Player League",
    body: "",
    messageType: 23,
    payload: {
      LeagueId: League.Gold3,
      BeforeLeagueId: League.Silver1,
      Medals: 42,
      FormerFullLeagueId: "6-1700000000-local",
      RewardGold: 60,
      Position: 2,
      NotEnoughPlayers: 1,
    },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: new Date("2024-01-01T00:00:00Z"),
  };

  assert.deepEqual(toClientMessage(message), {
    MessageId: { S: "player-league-result" },
    PlayerId: { S: "league-player" },
    MessageType: { N: "23" },
    LeagueId: { N: "7" },
    BeforeLeagueId: { N: "6" },
    Medals: { N: "42" },
    FormerFullLeagueId: { S: "6-1700000000-local" },
    RewardGold: { N: "60" },
    Position: { N: "2" },
    NotEnoughPlayers: { BOOL: true },
  });
  assert.deepEqual(claimableMessageReward(message), { Gold: 60, Warbucks: 0 });
  assert.equal(claimableMessageReward({ messageType: 27, payload: { RewardGold: 999 } }), null);
  assert.equal(claimableMessageReward({ messageType: 23, payload: { RewardGold: -1 } }), null);
  assert.equal(socialHandlers[DbAction.ClaimReward]?.requiresAuth, true);
});
