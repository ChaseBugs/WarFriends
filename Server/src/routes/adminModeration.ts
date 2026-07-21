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

function moderationFailure(error: unknown, res: Response): void {
  if (error instanceof PlayerSanctionInputError) {
    res.status(error.httpStatus).json({ Code: 0, Message: error.message });
    return;
  }
  throw error;
}

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
