import { Router, type Request, type Response } from "express";
import { ApiError } from "../apiErrors";
import type { PlayerAppealDocument } from "../db";
import {
  findOwnedPlayerAppeal,
  listPlayerAppeals,
  normalizeAppealExpectedStatus,
  normalizeAppealId,
  normalizeAppealMessage,
  normalizeAppealOperationId,
  normalizeAppealPageLimit,
  PlayerAppealInputError,
  reviewPlayerAppeal,
  submitPlayerAppeal,
} from "../services/playerAppealService";
import { authenticatePlayerSupportRequest } from "../services/playerSupportAuthService";

export const supportModerationRouter = Router();

function publicAppeal(appeal: PlayerAppealDocument): Record<string, unknown> {
  return {
    appealId: appeal._id,
    sanctionId: appeal.sanctionId,
    status: appeal.status,
    message: appeal.message,
    createdAt: appeal.createdAt.toISOString(),
    updatedAt: appeal.updatedAt.toISOString(),
  };
}

async function supportPlayer(req: Request) {
  const playerId = req.header("X-Player-Id");
  return authenticatePlayerSupportRequest(playerId, req.header("authorization"));
}

function supportFailure(error: unknown, res: Response): void {
  if (error instanceof PlayerAppealInputError) {
    res.status(error.httpStatus).json({ Code: 0, Message: error.message });
    return;
  }
  if (error instanceof ApiError) {
    // Never expose whether the player ID, session token, or sanction ownership check failed.
    res.setHeader("WWW-Authenticate", "Bearer realm=\"warfriends-player-support\"");
    res.status(401).json({ Code: 0, Message: "Player support authorization required." });
    return;
  }
  throw error;
}

/**
 * Submit the only appeal for the authenticated player's active sanction. This support endpoint is
 * intentionally outside the recovered gameplay action router: the stock banned dialog has no
 * appeal action, and normal gameplay authentication must continue returning AccountBanned.
 */
supportModerationRouter.post("/appeals", async (req, res, next) => {
  try {
    const player = await supportPlayer(req);
    const result = await submitPlayerAppeal(player.id, {
      sanctionId: normalizeAppealId(req.body?.sanctionId, "sanctionId"),
      message: normalizeAppealMessage(req.body?.message),
      operationId: normalizeAppealOperationId(req.header("Idempotency-Key")),
    });
    res.status(result.replayed ? 200 : 201).json({
      Replayed: result.replayed,
      Appeal: publicAppeal(result.appeal),
    });
  } catch (error) {
    try {
      supportFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

supportModerationRouter.get("/appeals", async (req, res, next) => {
  try {
    const player = await supportPlayer(req);
    const page = await listPlayerAppeals({
      playerId: player.id,
      limit: normalizeAppealPageLimit(req.query.limit),
      cursor: typeof req.query.cursor === "string" ? req.query.cursor : undefined,
    });
    res.json({
      Appeals: page.appeals.map(publicAppeal),
      ...(page.nextCursor ? { NextCursor: page.nextCursor } : {}),
    });
  } catch (error) {
    try {
      supportFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

supportModerationRouter.get("/appeals/:appealId", async (req, res, next) => {
  try {
    const player = await supportPlayer(req);
    const appeal = await findOwnedPlayerAppeal(normalizeAppealId(req.params.appealId), player.id);
    if (!appeal) {
      res.status(404).json({ Code: 0, Message: "Appeal was not found." });
      return;
    }
    res.json({ Appeal: publicAppeal(appeal) });
  } catch (error) {
    try {
      supportFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});

/**
 * Let a player close only their own non-terminal appeal. Ownership is verified before the
 * compare-and-set transition; the appeal review service then makes an exact retry idempotent and
 * rejects a stale expectedStatus rather than overwriting a concurrent moderator decision.
 */
supportModerationRouter.post("/appeals/:appealId/withdraw", async (req, res, next) => {
  try {
    const player = await supportPlayer(req);
    const appealId = normalizeAppealId(req.params.appealId);
    const owned = await findOwnedPlayerAppeal(appealId, player.id);
    if (!owned) {
      res.status(404).json({ Code: 0, Message: "Appeal was not found." });
      return;
    }
    const result = await reviewPlayerAppeal({
      appealId,
      expectedStatus: normalizeAppealExpectedStatus(req.body?.expectedStatus),
      status: "withdrawn",
      actor: `player:${player.id}`,
      note: "Withdrawn by player.",
      operationId: normalizeAppealOperationId(req.header("Idempotency-Key")),
    });
    res.json({ Replayed: result.replayed, Appeal: publicAppeal(result.appeal) });
  } catch (error) {
    try {
      supportFailure(error, res);
    } catch (unexpected) {
      next(unexpected);
    }
  }
});
