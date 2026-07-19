import { ApiError, apiError } from "../apiErrors";
import { config } from "../config";
import { DbAction, dbActionName } from "../dbActions";
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
import { identityHandlers } from "./identity";
import { reportHandlers } from "./reports";
import { economyHandlers } from "./economy";
import { dailyRewardHandlers } from "./dailyRewards";
import { assignmentHandlers } from "./assignments";
import { dailyMissionHandlers } from "./dailyMissions";
import { warArenaHandlers } from "./warArena";
import { visualHandlers } from "./visuals";
import { cardHandlers } from "./cards";
import type { HandlerEntry } from "./types";
import logger from "../utils/logger";

const benignNoOpActions = new Set<number>([
  92, // client error report
  104, 105, // content impression telemetry
  119, 120, // tutorial start/end telemetry
  141, 163, 166, 168, 169, // crash/log/UI telemetry
  179, 180, 183, 194, // analytics and UI impression telemetry
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
  ...identityHandlers,
  ...reportHandlers,
  ...economyHandlers,
  ...dailyRewardHandlers,
  ...assignmentHandlers,
  ...dailyMissionHandlers,
  ...warArenaHandlers,
  ...visualHandlers,
  ...cardHandlers,
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
    // LoginToCustomAccount is the one route where the durable human/provider password is
    // the primary credential. All gameplay routes prefer Token so a stale Password field
    // cannot silently bypass a rotated session. The authentication service separately gates
    // custom-password hash checks to this exact action.
    const credentialCandidates = action === DbAction.LoginToCustomAccount
      ? [req.Password, req.password, req.Token, req.token]
      : [req.Token, req.token, req.Password, req.password];
    const token = credentialCandidates.find(
      (value): value is string => typeof value === "string" && value !== "null",
    );

    // AccountType is only meaningful during platform login. Normal authenticated form
    // requests omit it and therefore use the guest/server token path.
    const accountType = Number(req.AccountType);
    const player = entry.requiresAuth
      ? await authenticate(
        id,
        token,
        Number.isInteger(accountType) ? accountType : undefined,
        action === DbAction.LoginToCustomAccount,
      )
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
