import { ApiError, apiError } from "../apiErrors";
import { config } from "../config";
import { dbActionName } from "../dbActions";
import type { RequestEnvelope, ResponseEnvelope } from "../dtos";
import { ok } from "../dtos";
import { authenticate } from "../services/authService";
import { findByIdOptional } from "../services/playerService";
import { authHandlers } from "./auth";
import { playerHandlers } from "./player";
import { squadHandlers } from "./squad";
import { matchHandlers } from "./match";
import { leaderboardHandlers } from "./leaderboard";
import { socialHandlers } from "./social";
import type { HandlerEntry } from "./types";
import logger from "../utils/logger";

// The dispatch table: DbAction code → handler. Grouped registries are merged here; later
// spreads would override earlier ones, so keep action codes unique across groups.
const registry: Record<number, HandlerEntry> = {
  ...authHandlers,
  ...playerHandlers,
  ...squadHandlers,
  ...matchHandlers,
  ...leaderboardHandlers,
  ...socialHandlers,
};

function clientVersion(req: RequestEnvelope): number {
  return Number(req.ClientVersion ?? req.clientVersion ?? 0);
}

/**
 * Route one Beanstalk envelope to its handler and produce the response envelope.
 * Never throws — all failures become a `{ Code, Message }` error envelope.
 */
export async function dispatch(req: RequestEnvelope): Promise<ResponseEnvelope> {
  const action = Number(req.DbAction);
  logger.api.action(dbActionName(action), action);

  if (config.minClientVersion > 0 && clientVersion(req) < config.minClientVersion) {
    return { DbAction: action, ...apiError(20, "Client version too old.") };
  }

  const entry = registry[action];

  try {
    if (!entry) {
      // Not implemented yet — acknowledge so the client doesn't treat it as a hard failure.
      // Many DbActions are telemetry/analytics no-ops; the rest are tracked in BACKEND.md.
      logger.warnWithEmoji("⚠️", `Unhandled DbAction ${dbActionName(action)} (${action}) — acking`, "DISPATCH");
      return ok(action, { Unhandled: true });
    }

    // Attach the player: required handlers authenticate strictly; others attach best-effort.
    const id = typeof req.id === "string" ? req.id : undefined;
    const token = (typeof req.token === "string" ? req.token : undefined) ?? (typeof req.password === "string" ? req.password : undefined);

    const player = entry.requiresAuth
      ? await authenticate(id, token)
      : id && token
        ? await findByIdOptional(id, token)
        : null;

    return await entry.handler({ req, player });
  } catch (err) {
    if (err instanceof ApiError) {
      return { DbAction: action, ...apiError(err.code, err.message) };
    }
    const message = err instanceof Error ? err.message : String(err);
    logger.errorWithEmoji("❌", `Handler for ${dbActionName(action)} threw`, "DISPATCH", { error: message });
    return { DbAction: action, ...apiError(0, "Internal server error.") };
  }
}
