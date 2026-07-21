import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { submitClientLog } from "../services/clientLogService";
import { authed, type HandlerEntry } from "./types";

function assertIdentityEcho(value: unknown, expected: string, field: string): void {
  if (typeof value !== "string" || value !== expected) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, `Support log ${field} does not match the session.`);
  }
}

export const clientLogHandlers: Record<number, HandlerEntry> = {
  [DbAction.SendLog]: authed(async ({ player, req }) => {
    // SendLogs includes duplicate visible identity fields even though the common envelope already
    // authenticates PlayerId/Token. Bind both echoes to current authority before retaining text.
    assertIdentityEcho(req.PlayerId, player!.id, "PlayerId");
    assertIdentityEcho(req.PlayerName, player!.player.accountName, "PlayerName");
    const entry = await submitClientLog(player!, req.Logs, req.ClientVersion);
    return ok(DbAction.SendLog, { LogId: entry._id });
  }),
};
