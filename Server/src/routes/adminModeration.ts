import { Router, type Request, type Response } from "express";
import { findById } from "../services/playerService";
import {
  issuePlayerSanction,
  listPlayerSanctions,
  normalizeSanctionActor,
  normalizeSanctionId,
  normalizeSanctionOperationId,
  normalizeSanctionPlayerId,
  normalizeSanctionReason,
  normalizeTemporaryBanSeconds,
  PlayerSanctionInputError,
  revokePlayerSanction,
} from "../services/playerSanctionService";
import type { PlayerSanctionDocument } from "../db";
import type { PlayerReportDocument } from "../services/reportService";
import {
  findModerationReport,
  listModerationReports,
  normalizeReportId,
  normalizeReportListInput,
  normalizeReportReviewActor,
  normalizeReportReviewOperationId,
  normalizeReportStatus,
  normalizeReviewNote,
  normalizeReviewTargetStatus,
  ReportReviewInputError,
  reviewPlayerReport,
} from "../services/reportReviewService";

export const adminModerationRouter = Router();

function header(req: Request, name: string): string | undefined {
  const value = req.header(name);
  return typeof value === "string" ? value : undefined;
}

function wireSanction(sanction: PlayerSanctionDocument): Record<string, unknown> {
  return {
    sanctionId: sanction._id,
    playerId: sanction.playerId,
    status: sanction.status,
    reason: sanction.reason,
    issuedBy: sanction.issuedBy,
    issuedAt: sanction.issuedAt.toISOString(),
    ...(sanction.durationSeconds === undefined ? {} : { durationSeconds: sanction.durationSeconds }),
    ...(sanction.expiresAt ? { expiresAt: sanction.expiresAt.toISOString() } : {}),
    ...(sanction.revokedAt ? { revokedAt: sanction.revokedAt.toISOString() } : {}),
    ...(sanction.revokedBy ? { revokedBy: sanction.revokedBy } : {}),
    ...(sanction.revocationReason ? { revocationReason: sanction.revocationReason } : {}),
    ...(sanction.resolvedAt ? { resolvedAt: sanction.resolvedAt.toISOString() } : {}),
  };
}

function wireReport(report: PlayerReportDocument): Record<string, unknown> {
  return {
    reportId: report.reportId,
    reporterPlayerId: report.reporterPlayerId,
    reportedPlayerId: report.reportedPlayerId,
    kind: report.kind,
    status: report.status,
    reportType: report.reportType,
    message: report.message,
    evidence: report.evidence,
    ...(report.matchEvidence ? { matchEvidence: report.matchEvidence } : {}),
    createdAt: report.createdAt.toISOString(),
    ...(report.updatedAt ? { updatedAt: report.updatedAt.toISOString() } : {}),
    reviewHistory: (report.reviewHistory ?? []).map((entry) => ({
      ...entry,
      createdAt: entry.createdAt.toISOString(),
    })),
  };
}

function moderationFailure(error: unknown, res: Response): void {
  if (error instanceof PlayerSanctionInputError || error instanceof ReportReviewInputError) {
    res.status(error.httpStatus).json({ Code: 0, Message: error.message });
    return;
  }
  throw error;
}

/**
 * Return a stable newest-first moderation queue. Optional status/kind/player filters and an
 * opaque cursor let an operator process a large queue without offset drift while new reports
 * arrive. Full evidence is admin-only and remains explicitly untrusted unless combatValidated.
 */
adminModerationRouter.get("/reports", async (req, res, next) => {
  try {
    const page = await listModerationReports(normalizeReportListInput(req.query as Record<string, unknown>));
    res.json({
      Reports: page.reports.map(wireReport),
      ...(page.nextCursor ? { NextCursor: page.nextCursor } : {}),
    });
  } catch (error) {
    try {
      moderationFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

adminModerationRouter.get("/reports/:reportId", async (req, res, next) => {
  try {
    const reportId = normalizeReportId(req.params.reportId);
    const report = await findModerationReport(reportId);
    if (!report) {
      res.status(404).json({ Code: 0, Message: "Report was not found." });
      return;
    }
    res.json({ Report: wireReport(report) });
  } catch (error) {
    try {
      moderationFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

/**
 * Move one report through open -> reviewing -> resolved/dismissed. expectedStatus is mandatory,
 * preventing two moderators from acting on the same stale queue snapshot. Terminal decisions
 * require a note; every transition and retry key is preserved in the report's append-only audit.
 */
adminModerationRouter.post("/reports/:reportId/review", async (req, res, next) => {
  try {
    const status = normalizeReviewTargetStatus(req.body?.status);
    const result = await reviewPlayerReport({
      reportId: normalizeReportId(req.params.reportId),
      expectedStatus: normalizeReportStatus(req.body?.expectedStatus, true)!,
      status,
      actor: normalizeReportReviewActor(header(req, "X-Admin-Actor")),
      note: normalizeReviewNote(req.body?.note, status !== "reviewing"),
      operationId: normalizeReportReviewOperationId(header(req, "Idempotency-Key")),
    });
    res.json({ Replayed: result.replayed, Report: wireReport(result.report) });
  } catch (error) {
    try {
      moderationFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

/**
 * Issue one account ban. Authentication is applied when the router is mounted; the additional
 * actor and idempotency headers make the human decision auditable and safe to retry after an
 * uncertain network response. Absence of durationSeconds deliberately means a permanent ban.
 */
adminModerationRouter.post("/sanctions", async (req, res, next) => {
  try {
    const playerId = normalizeSanctionPlayerId(req.body?.playerId);
    const player = await findById(playerId);
    if (!player) {
      res.status(404).json({ Code: 0, Message: "Player was not found." });
      return;
    }
    const result = await issuePlayerSanction({
      playerId,
      reason: normalizeSanctionReason(req.body?.reason),
      issuedBy: normalizeSanctionActor(header(req, "X-Admin-Actor")),
      operationId: normalizeSanctionOperationId(header(req, "Idempotency-Key")),
      durationSeconds: normalizeTemporaryBanSeconds(req.body?.durationSeconds),
    });
    res.status(result.replayed ? 200 : 201).json({
      Replayed: result.replayed,
      Sanction: wireSanction(result.sanction),
    });
  } catch (error) {
    try {
      moderationFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

adminModerationRouter.post("/sanctions/:sanctionId/revoke", async (req, res, next) => {
  try {
    const result = await revokePlayerSanction({
      sanctionId: normalizeSanctionId(req.params.sanctionId),
      reason: normalizeSanctionReason(req.body?.reason),
      revokedBy: normalizeSanctionActor(header(req, "X-Admin-Actor")),
      operationId: normalizeSanctionOperationId(header(req, "Idempotency-Key")),
    });
    res.json({ Replayed: result.replayed, Sanction: wireSanction(result.sanction) });
  } catch (error) {
    try {
      moderationFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

adminModerationRouter.get("/players/:playerId/sanctions", async (req, res, next) => {
  try {
    const playerId = normalizeSanctionPlayerId(req.params.playerId);
    const sanctions = await listPlayerSanctions(playerId);
    res.json({ PlayerId: playerId, Sanctions: sanctions.map(wireSanction) });
  } catch (error) {
    try {
      moderationFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});
