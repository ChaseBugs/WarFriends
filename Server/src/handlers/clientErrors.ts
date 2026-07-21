import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { ingestClientError } from "../services/clientErrorService";
import { open, type HandlerEntry } from "./types";

export const clientErrorHandlers: Record<number, HandlerEntry> = {
  [DbAction.ErrorMessage]: open(async ({ player, req }) => {
    // ErrorMessage can be emitted while account boot itself is failing, so the route must remain
    // open. Persistence, however, requires a valid attached session, explicit SendLogs consent,
    // and opt-in deployment policy; otherwise this is only the stock success acknowledgement.
    const stored = await ingestClientError(player, {
      PlayerName: req.PlayerName,
      ExceptionMessage: req.ExceptionMessage,
      ExceptionStacktrace: req.ExceptionStacktrace,
      ReportedDbAction: req.ReportedDbAction,
      ServerResponse: req.ServerResponse,
      PostParameters: req.PostParameters,
      MessageToParse: req.MessageToParse,
      ClientVersion: req.ClientVersion,
    });
    return ok(DbAction.ErrorMessage, { Stored: stored });
  }),
};
