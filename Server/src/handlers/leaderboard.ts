import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  playerRank,
  playersInLeague,
  topPlayersByExperience,
  topArenaPlayers,
  topSquads,
} from "../services/leaderboardService";
import { buildDatabasePlayer } from "../services/playerStateService";
import { authed, type HandlerEntry } from "./types";

// Leaderboard responses use callback-specific schemas recovered from OGLEHLIPEFM. They are
// intentionally not generic `{ globalPlayerLeaderboard: ... }` cache objects.

export const leaderboardHandlers: Record<number, HandlerEntry> = {
  [DbAction.GetPlayersByExperience]: authed(async ({ player }) => {
    const global = await topPlayersByExperience();
    const local = await topPlayersByExperience(100, player!.player.country || undefined);
    // FLOIMADDPPC reads both arrays unconditionally. When country is unknown, local falls
    // back to the global board instead of omitting the key and crashing the parser.
    return ok(DbAction.GetPlayersByExperience, {
      Items: global,
      Local: player!.player.country ? local : global,
      Rank: await playerRank(player!.id),
    });
  }),

  [DbAction.GetPlayerLeaguesDivision]: authed(async ({ player }) => {
    const members = await playersInLeague(player!.player.leagueTier);
    // FPFMCNOBKBK parses Items through DatabasePlayer.CreateFromDatabase and derives its
    // cache key from LeagueId. Both fields therefore remain mandatory even in placement.
    return ok(DbAction.GetPlayerLeaguesDivision, {
      Items: members.map(buildDatabasePlayer),
      LeagueId: player!.player.leagueId || `${player!.player.leagueTier}-placement`,
      Rank: await playerRank(player!.id),
    });
  }),

  [DbAction.GetMissionLeaderboards]: authed(() => ok(DbAction.GetMissionLeaderboards, { Items: [] })),

  [DbAction.GetArenaLeaderboards]: authed(async () =>
    // GEKJKNLPJIL.LLCLNJKBGGM unconditionally casts Items to JArray and parses each entry
    // through FHIPGDADNFG.MAINIENLLIL, including its WarArenaData string attribute.
    ok(DbAction.GetArenaLeaderboards, { Items: await topArenaPlayers() }),
  ),

  [DbAction.LeagueLeaderboardShown]: authed(async () =>
    ok(DbAction.LeagueLeaderboardShown, { Items: await topSquads() }),
  ),
};
