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
import type { PlayerAppealDocument, PlayerSanctionDocument } from "../db";
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
import {
  findPlayerAppeal,
  listPlayerAppeals,
  normalizeAppealExpectedStatus,
  normalizeAppealId,
  normalizeAppealListInput,
  normalizeAppealOperationId,
  normalizeAppealReviewActor,
  normalizeAppealReviewNote,
  normalizeAppealReviewStatus,
  PlayerAppealInputError,
  reviewPlayerAppeal,
} from "../services/playerAppealService";

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

function wireAppeal(appeal: PlayerAppealDocument): Record<string, unknown> {
  return {
    appealId: appeal._id,
    sanctionId: appeal.sanctionId,
    playerId: appeal.playerId,
    status: appeal.status,
    message: appeal.message,
    submissionOperationId: appeal.submissionOperationId,
    createdAt: appeal.createdAt.toISOString(),
    updatedAt: appeal.updatedAt.toISOString(),
    reviewHistory: (appeal.reviewHistory ?? []).map((entry) => ({
      ...entry,
      createdAt: entry.createdAt.toISOString(),
    })),
  };
}

function moderationFailure(error: unknown, res: Response): void {
  if (error instanceof PlayerSanctionInputError ||
      error instanceof ReportReviewInputError ||
      error instanceof PlayerAppealInputError) {
    res.status(error.httpStatus).json({ Code: 0, Message: error.message });
    return;
  }
  throw error;
}

/** Player appeals are a separate operator queue because their text is not report evidence. */
adminModerationRouter.get("/appeals", async (req, res, next) => {
  try {
    const page = await listPlayerAppeals(normalizeAppealListInput(req.query as Record<string, unknown>));
    res.json({
      Appeals: page.appeals.map(wireAppeal),
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

adminModerationRouter.get("/appeals/:appealId", async (req, res, next) => {
  try {
    const appeal = await findPlayerAppeal(normalizeAppealId(req.params.appealId));
    if (!appeal) {
      res.status(404).json({ Code: 0, Message: "Appeal was not found." });
      return;
    }
    res.json({ Appeal: wireAppeal(appeal) });
  } catch (error) {
    try {
      moderationFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

/**
 * Move an appeal through its audited operator workflow. The caller must state the status it read,
 * so two moderators cannot silently overwrite each other. Accepting an appeal and revoking its
 * sanction are committed in one MongoDB transaction; rejecting it leaves the sanction unchanged.
 */
adminModerationRouter.post("/appeals/:appealId/review", async (req, res, next) => {
  try {
    const status = normalizeAppealReviewStatus(req.body?.status);
    const result = await reviewPlayerAppeal({
      appealId: normalizeAppealId(req.params.appealId),
      expectedStatus: normalizeAppealExpectedStatus(req.body?.expectedStatus),
      status,
      actor: normalizeAppealReviewActor(header(req, "X-Admin-Actor")),
      note: normalizeAppealReviewNote(req.body?.note, status === "accepted" || status === "rejected"),
      operationId: normalizeAppealOperationId(header(req, "Idempotency-Key")),
    });
    res.json({ Replayed: result.replayed, Appeal: wireAppeal(result.appeal) });
  } catch (error) {
    try {
      moderationFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

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
