import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  playerRank,
  topPlayersByExperience,
  topArenaPlayers,
  topSquads,
} from "../services/leaderboardService";
import { buildDatabasePlayer } from "../services/playerStateService";
import {
  ensureActivePlayerLeague,
  finishExpiredPlayerLeague,
  playersInPlayerLeague,
} from "../services/playerLeagueService";
import { parseManagedPlayerLeagueId } from "../services/playerLeagueContract";
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
    const current = await ensureActivePlayerLeague(player!, Math.floor(Date.now() / 1_000));
    const managed = parseManagedPlayerLeagueId(current.player.leagueId);
    const members = managed ? await playersInPlayerLeague(current.player.leagueId) : [];
    // FPFMCNOBKBK parses Items through DatabasePlayer.CreateFromDatabase and derives its
    // cache key from LeagueId. LeagueEvaluation drives LeagueArcManager's local timer and is
    // what eventually causes the stock client to call FinishPlayerLeague at the deadline.
    // Both fields therefore remain mandatory for a managed active division.
    return ok(DbAction.GetPlayerLeaguesDivision, {
      Items: members.map(buildDatabasePlayer),
      LeagueId: current.player.leagueId || `${current.player.leagueTier}-placement`,
      Rank: members.findIndex((member) => member.id === current.id) + 1,
      ...(managed ? { LeagueEvaluation: managed.endsAt } : {}),
    });
  }),

  [DbAction.FinishPlayerLeague]: authed(async ({ player }) => {
    const result = await finishExpiredPlayerLeague(player!, Math.floor(Date.now() / 1_000));
    // OGLEHLIPEFM.INNPDDAJBPN treats the *presence* of Finished as success. Omitting it when
    // the timer is still active is important: returning Finished:false would still make the
    // unmodified client log and present the request as a completed settlement.
    return ok(DbAction.FinishPlayerLeague, result.finished
      ? { Finished: true, SettledPlayers: result.settledPlayers }
      : { Pending: true });
  }),

  [DbAction.RemoveFromLeague]: authed(async ({ player }) => {
    // Type-23 message handling already moved the authoritative row to placement. This legacy
    // action is an idempotent refresh acknowledgement; accepting client-provided league IDs
    // here would allow arbitrary tier changes.
    return ok(DbAction.RemoveFromLeague, {
      LeagueId: player!.player.leagueId,
      PlacementMatchesRequired: player!.player.remainingMatches,
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
