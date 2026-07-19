import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import type { DailyMissionMode } from "../db";
import { ok } from "../dtos";
import {
  getMatch,
  reportMatchResult,
  winnerFromEndReason,
} from "../services/matchService";
import { settleDailyMission } from "../services/dailyMissionService";
import { settleWarArenaBattle, startWarArenaBattle } from "../services/warArenaService";
import { findById } from "../services/playerService";
import { progressionForPlayer, unixNow } from "../services/playerStateService";
import { authed, type HandlerEntry } from "./types";

// PvP match lifecycle reported to the meta server. Live event traffic runs over /hub, while
// these actions preserve compatibility with the recovered client's Photon-era REST calls.

function matchId(req: Record<string, unknown>): string {
  // PvP historically names the durable record MatchId, while the stock Photon-era client
  // sends BattleId. Normalizing both names here keeps the settlement logic transport-neutral.
  const id = req.MatchId ?? req.BattleId;
  return typeof id === "string" ? id : "";
}

function missionMode(value: unknown): DailyMissionMode {
  // These strings are enum.ToString() values from GEIKAIJBCPE in the recovered client.
  // Do not accept numeric aliases: a loose conversion could map an unknown future mode to a
  // reward-bearing mode and weaken the start-action/mode ownership check.
  if (value === "Daily" || value === "Coop" || value === "CoopClient" || value === "Heroic") return value;
  throw new ApiError(ApiErrorCode.UnknownAction, "MissionType is invalid.");
}

function integer(value: unknown, field: string): number {
  // BestHTTP form values arrive as strings. Number() accepts that wire shape, while the
  // integer check rejects fractional indices, NaN, and malformed EndReason values.
  const parsed = Number(value);
  if (!Number.isInteger(parsed)) throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an integer.`);
  return parsed;
}

function enabled(value: unknown): boolean {
  return value === true || value === 1 || value === "1" || value === "True" || value === "true";
}

export const matchHandlers: Record<number, HandlerEntry> = {
  // These reports are lifecycle telemetry only. Match ownership is established when the
  // matchmaking service creates the persistent match row; a start report cannot create or
  // join an arbitrary match by itself.
  [DbAction.GameStartedMaster]: authed(async ({ player, req }) => {
    if (!enabled(req.IsWarArenaBattle)) return ok(DbAction.GameStartedMaster, { Time: unixNow() });
    const result = await startWarArenaBattle(player!.id, matchId(req));
    // NCAKLEOEDBO reads Time unconditionally and BattleId conditionally for every start
    // action. The Arena receipt uses the same parser as ordinary PvP starts.
    return ok(DbAction.GameStartedMaster, { ...result.response, Time: unixNow(), Replayed: result.replayed });
  }),
  [DbAction.GameStartedClient]: authed(async ({ player, req }) => {
    if (!enabled(req.IsWarArenaBattle)) return ok(DbAction.GameStartedClient, { Time: unixNow() });
    const result = await startWarArenaBattle(player!.id, matchId(req));
    return ok(DbAction.GameStartedClient, { ...result.response, Time: unixNow(), Replayed: result.replayed });
  }),

  [DbAction.GameEnded]: authed(async ({ player, req }) => {
    const id = matchId(req);
    if (enabled(req.IsWarArena)) {
      // BeanstalkServerManager adds IsWarArena to action 62. Branch before normal PvP: an
      // Arena BattleId belongs to the player's persistent run receipt, not the two-party
      // match-consensus collection. The service still requires the action-64/65 start proof.
      const result = await settleWarArenaBattle(player!.id, {
        battleId: id,
        endReason: integer(req.EndReason, "EndReason"),
      });
      return ok(DbAction.GameEnded, {
        ...result.response,
        LevelExperience: result.state.levelExperience,
        Time: unixNow(),
        Replayed: result.replayed,
      });
    }
    if (req.MissionType !== undefined) {
      // BeanstalkServerManager.GameEnded adds MissionType and zero-based MissionIndex only
      // when GameController.isMission is true. Branch before the PvP lookup: campaign
      // BattleIds identify short-lived mission receipts, not two-player match documents.
      // The service still validates that this BattleId was issued by the matching start
      // action, so the presence of MissionType alone is not enough to obtain a reward.
      const result = await settleDailyMission(player!.id, player!.player.level, {
        battleId: id,
        missionIndex: integer(req.MissionIndex, "MissionIndex"),
        missionType: missionMode(req.MissionType),
        endReason: integer(req.EndReason, "EndReason"),
      });
      return ok(DbAction.GameEnded, {
        ...result.response,
        // OGLEHLIPEFM.PKAHEEJBBNP reads LevelExperience without a ContainsKey guard after
        // IsWarPath selects the mission parser. Return it for success, failure, and replay.
        LevelExperience: result.state.levelExperience,
        // Time is included for parity with the other lifecycle responses and lets repaired
        // clients correct clock drift. The stock mission parser safely ignores it.
        Time: unixNow(),
        Replayed: result.replayed,
      });
    }

    const match = id ? await getMatch(id) : null;
    const endReason = Number(req.EndReason);

    // The stock 1.6.0 request sends EndReason, not WinnerId. A WinnerId alias remains useful
    // for the replacement transport, but it is accepted only when it names a real match
    // participant and still goes through two-party durable consensus.
    const explicitWinner = typeof req.WinnerId === "string" ? req.WinnerId : "";
    const inferredWinner = match
      ? winnerFromEndReason(match.players.map((participant) => participant.playerId), player!.id, endReason)
      : null;
    const winnerId = explicitWinner || inferredWinner || "";
    const report = id && winnerId
      ? await reportMatchResult(id, player!.id, winnerId)
      : { status: "invalid" as const };

    const updated = await findById(player!.id);
    const progression = updated ? progressionForPlayer(updated) : null;
    // LevelExperience is read without a ContainsKey guard by DMGJCGJDDID. Return it on every
    // outcome, including pending/conflicting reports, so a safe rejection cannot crash the
    // client's end-screen parser.
    return ok(DbAction.GameEnded, {
      Settled: report.settlement?.rewarded ?? false,
      ResultStatus: report.status,
      WinnerId: report.settlement?.winnerId ?? winnerId,
      LevelExperience: progression?.levelExperience ?? 0,
      Level: updated?.player.level ?? player!.player.level,
      Skill: updated?.player.skill ?? player!.player.skill,
      MedalsBalance: updated?.player.medalsBalance ?? player!.player.medalsBalance,
      PlacementMatchesRequired: updated?.player.remainingMatches ?? player!.player.remainingMatches,
      BeginnersLeague: updated?.player.beginnersLeague ?? player!.player.beginnersLeague,
      Time: unixNow(),
    });
  }),

  // Region latency persistence remains a follow-up; acknowledging this read-like hint does
  // not change match ownership or rewards.
  [DbAction.UpdateRegionPings]: authed(() => ok(DbAction.UpdateRegionPings)),

  // The replacement WebSocket relay does not have Photon room-capacity failures. The action
  // remains an explicit compatibility acknowledgement so it is not mistaken for settlement.
  [DbAction.PhotonIsFull]: authed(() => ok(DbAction.PhotonIsFull)),
};
