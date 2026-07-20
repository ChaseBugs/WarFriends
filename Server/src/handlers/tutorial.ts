import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { finishTutorial, startTutorial } from "../services/tutorialService";
import { unixNow } from "../services/playerStateService";
import { authed, type HandlerEntry } from "./types";

function integer(value: unknown, field: string): number {
  const parsed = Number(value);
  if (!Number.isInteger(parsed)) throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an integer.`);
  return parsed;
}

function battleId(value: unknown): string {
  if (value === undefined || value === null) return "";
  if (typeof value !== "string" || value.length > 128) {
    throw new ApiError(ApiErrorCode.UnknownAction, "BattleId is invalid.");
  }
  return value;
}

/** Source-backed bootcamp lifecycle used by the stock action-119/120 response parser. */
export const tutorialHandlers: Record<number, HandlerEntry> = {
  [DbAction.GameStartedTutorial]: authed(async ({ player }) => {
    const result = await startTutorial(player!.id);
    return ok(DbAction.GameStartedTutorial, {
      BattleId: result.battleId,
      Time: unixNow(),
      Replayed: result.replayed,
      ...(result.state.tutorialFinished ? { TutorialData: {} } : {}),
    });
  }),

  [DbAction.TutorialEnded]: authed(async ({ player, req }) => {
    const result = await finishTutorial(
      player!.id,
      battleId(req.BattleId),
      integer(req.EndReason, "EndReason"),
    );
    return ok(DbAction.TutorialEnded, {
      // The recovered end parser uses key presence as the terminal tutorial signal.
      TutorialData: {},
      BattleId: result.battleId,
      Gold: result.state.gold,
      WarBucks: result.state.warBucks,
      PlacementMatchesRequired: result.remainingMatches,
      Time: unixNow(),
      Replayed: result.replayed,
    });
  }),
};
