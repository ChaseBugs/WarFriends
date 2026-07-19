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

const benignNoOpActions = new Set<number>([
  67, 68, 69, // campaign/co-op start telemetry
  92, // client error report
  104, 105, 108, // content impression telemetry
  119, 120, // tutorial start/end telemetry
  141, 163, 166, 168, 169, // crash/log/UI telemetry
  179, 180, 183, 191, 194, // analytics and UI impression telemetry
  212, 213, 1007, // feature/offer impression telemetry
]);

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
  if (!Number.isInteger(action)) {
    return { DbAction: -1, ...apiError(90, "Missing or invalid request action.") };
  }
  logger.api.action(dbActionName(action), action);

  if (config.minClientVersion > 0 && clientVersion(req) < config.minClientVersion) {
    return { DbAction: action, ...apiError(20, "Client version too old.") };
  }

  const entry = registry[action];

  try {
    if (!entry) {
      logger.warnWithEmoji("⚠️", `Unhandled DbAction ${dbActionName(action)} (${action})`, "DISPATCH");
      if (benignNoOpActions.has(action)) return ok(action, { Ignored: true });
      return { DbAction: action, ...apiError(90, `Action ${dbActionName(action)} is not implemented.`) };
    }

    // Attach the player: required handlers authenticate strictly; others attach best-effort.
    const id = [req.PlayerId, req.id, req.Id].find((value): value is string => typeof value === "string" && value !== "null");
    const token = [req.Token, req.token, req.Password, req.password].find(
      (value): value is string => typeof value === "string" && value !== "null",
    );

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
