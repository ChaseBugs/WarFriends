import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import { normalizeReportInput, submitPlayerReport } from "../services/reportService";
import { authed, type HandlerEntry } from "./types";

// Moderation reports are authenticated durable mutations. They are deliberately separate
// from crash/log telemetry: reporting another account affects people and therefore requires
// ownership, validation, rate limiting, an audit identifier, and a reviewable status.
export const reportHandlers: Record<number, HandlerEntry> = {
  [DbAction.SendPlayerReport]: authed(async ({ player, req }) => {
    const report = await submitPlayerReport(player!.id, "player", normalizeReportInput(req, true));
    // The recovered response parser reads Reported after this action.
    return ok(DbAction.SendPlayerReport, { Reported: true, ReportId: report.reportId });
  }),

  [DbAction.ReportCheater]: authed(async ({ player, req }) => {
    const report = await submitPlayerReport(player!.id, "cheat", normalizeReportInput(req, false));
    // The recovered response parser reads PlayerID (capital D) for its confirmation log.
    return ok(DbAction.ReportCheater, { PlayerID: report.reportedPlayerId, ReportId: report.reportId });
  }),
};
