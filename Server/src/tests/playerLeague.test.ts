import assert from "node:assert/strict";
import test from "node:test";
import { League } from "../constants";
import {
  advancePlayerLeaguePlacementAfterPvp,
  managedPlayerLeagueId,
  parseManagedPlayerLeagueId,
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
  assert.deepEqual(
    PLAYER_LEAGUE_RULES.map((row) => row.durationHours),
    [24, 24, 24, 72, 72, 72, 168, 168, 168, 168, 168, 168, 168, 168, 168, 168],
  );
  assert.deepEqual(
    PLAYER_LEAGUE_RULES.map((row) => row.underfilledGold),
    [10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 125, 150, 175, 200, 225, 250],
  );
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
