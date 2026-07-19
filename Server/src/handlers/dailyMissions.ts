import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  getOrCreateDailyMissions,
  serializeDailyMissionsData,
  startDailyMission,
} from "../services/dailyMissionService";
import { unixNow } from "../services/playerStateService";
import { authed, type HandlerEntry } from "./types";

/**
 * Read the mission receipt identifier exactly as the recovered BestHTTP request sends it.
 *
 * BattleId is not merely a diagnostic value. The service stores it as the idempotency key
 * that connects one start request to one later GameEnded request. Accepting an empty value
 * would make unrelated battles share the same receipt and could therefore duplicate or
 * redirect a completion reward.
 */
function battleId(value: unknown): string {
  if (typeof value !== "string" || value.length < 1) {
    throw new ApiError(ApiErrorCode.UnknownAction, "BattleId is required.");
  }
  return value;
}

async function start(
  action: DbAction.GameStartedCampaign | DbAction.GameStartedCoopMaster | DbAction.GameStartedCoopClient,
  playerId: string,
  playerLevel: number,
  value: unknown,
) {
  const id = battleId(value);
  const result = await startDailyMission(playerId, playerLevel, id, action);
  return ok(action, {
    // OGLEHLIPEFM.NCAKLEOEDBO reads Time without a ContainsKey guard in the recovered
    // 1.6.0 client. Omitting Time would turn a valid server acknowledgement into a client
    // parsing exception before gameplay begins.
    Time: unixNow(),
    // BattleId is optional in the parser, but echoing the canonical receipt lets the server
    // normalize or replace IDs later without changing the client contract.
    BattleId: result.battleId,
    // Replayed is ignored by the stock client and is useful to replacement clients/tests.
    // It never changes the reward or receipt state.
    Replayed: result.replayed,
  });
}

export const dailyMissionHandlers: Record<number, HandlerEntry> = {
  [DbAction.GetNewDailyMissions]: authed(async ({ player }) => {
    const result = await getOrCreateDailyMissions(player!.id, player!.player.level);
    return ok(DbAction.GetNewDailyMissions, {
      // OGLEHLIPEFM.JPHKHHNNIOA passes this string directly to LoadFromJsonString. It must
      // therefore remain a JSON string inside the outer response, not a nested JSON object.
      DailyMissionsData: serializeDailyMissionsData(result.dailyMissions),
    });
  }),

  [DbAction.SaveDailyMissions]: authed(async ({ player }) => {
    const result = await getOrCreateDailyMissions(player!.id, player!.player.level);
    // OGLEHLIPEFM.DDIPKGOPCMK only logs success, and no surviving 1.6.0 call site submits
    // this action. A later APK may still upload its local object. We deliberately ignore
    // that object: accepting completedSolo, completedCoop, or heroicPoints from the client
    // would allow reward minting without an authenticated start/settlement lifecycle.
    // Returning the authoritative copy also gives a repaired client a safe resync path.
    return ok(DbAction.SaveDailyMissions, {
      DailyMissionsData: serializeDailyMissionsData(result.dailyMissions),
      IgnoredClientState: true,
    });
  }),

  [DbAction.GameStartedCampaign]: authed(({ player, req }) =>
    start(DbAction.GameStartedCampaign, player!.id, player!.player.level, req.BattleId)),

  [DbAction.GameStartedCoopMaster]: authed(({ player, req }) =>
    start(DbAction.GameStartedCoopMaster, player!.id, player!.player.level, req.BattleId)),

  [DbAction.GameStartedCoopClient]: authed(({ player, req }) =>
    start(DbAction.GameStartedCoopClient, player!.id, player!.player.level, req.BattleId)),
};
