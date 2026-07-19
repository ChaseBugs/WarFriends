import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { playerRank, topPlayersByExperience, topSquads } from "../services/leaderboardService";
import { authed, type HandlerEntry } from "./types";

// Leaderboards / leagues (BACKEND.md §2.4). Reads project to the shape the client's
// ServerResultsCache expects. Arena/mission boards are stubbed until those systems exist.

export const leaderboardHandlers: Record<number, HandlerEntry> = {
  [DbAction.GetPlayersByExperience]: authed(async () =>
    ok(DbAction.GetPlayersByExperience, { globalPlayerLeaderboard: await topPlayersByExperience() }),
  ),

  [DbAction.GetPlayerLeaguesDivision]: authed(async ({ player }) =>
    ok(DbAction.GetPlayerLeaguesDivision, {
      LeagueId: player!.player.leagueId,
      LeagueDivision: player!.player.leagueDivision,
      LeagueTier: player!.player.leagueTier,
      Rank: await playerRank(player!.id),
    }),
  ),

  [DbAction.GetMissionLeaderboards]: authed(() => ok(DbAction.GetMissionLeaderboards, { missionLeaderboards: [] })),

  [DbAction.GetArenaLeaderboards]: authed(() => ok(DbAction.GetArenaLeaderboards, { arenaLeaderboard: [] })),

  // League settlement (promotion/relegation) is a follow-up; acknowledge for now.
  [DbAction.FinishPlayerLeague]: authed(() => ok(DbAction.FinishPlayerLeague)),

  // Squad leaderboard read (also served by squad handlers' GetSquadsByExperience).
  [DbAction.LeagueLeaderboardShown]: authed(async () =>
    ok(DbAction.LeagueLeaderboardShown, { globalSquadLeaderboard: await topSquads() }),
  ),
};
