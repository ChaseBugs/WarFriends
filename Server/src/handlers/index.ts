import { ApiError, ApiErrorCode, apiError } from "../apiErrors";
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
import { blackMarketHandlers } from "./blackMarket";
import { rentalHandlers } from "./rentals";
import { vipHandlers } from "./vip";
import { instantBattleHandlers } from "./instantBattle";
import { lootboxHandlers } from "./lootboxes";
import { inventoryImpressionHandlers } from "./inventoryImpressions";
import { tutorialHandlers } from "./tutorial";
import { analyticsHandlers } from "./analytics";
import { purchaseHandlers } from "./purchases";
import { videoAdHandlers } from "./videoAds";
import { videoFeedHandlers } from "./videoFeed";
import { offerHandlers } from "./offers";
import { clientLogHandlers } from "./clientLogs";
import { clientErrorHandlers } from "./clientErrors";
import type { HandlerEntry } from "./types";
import logger from "../utils/logger";
import { exactRequestedAccountType } from "../services/accountTypeRequestService";
import {
  exactDatabaseAction,
  exactMinimumClientVersion,
  replacementClientVersionIsAllowed,
} from "./requestEnvelopeParsing";

// Evaluate the deployment gate while the dispatcher module loads. Invalid policy must stop server
// startup before one node silently accepts clients that another node rejects during a rolling deploy.
const minimumClientVersion = exactMinimumClientVersion(config.minClientVersion);

const benignNoOpActions = new Set<number>([
  141, // crash telemetry has no trustworthy active payload call site
]);

/**
 * Recovered enum values that intentionally do not own a direct dispatcher handler.
 *
 * This is an executable companion to BACKEND_FEATURES.md. Buffer-only economy actions execute
 * inside SendRequestBuffer's transaction; response-only values are emitted/consumed locally;
 * retired actions lack a trustworthy active call contract; debug mutations remain closed; and
 * GetConfigurations is intercepted by the raw semicolon-response route. Keeping every exception
 * explicit lets the coverage test distinguish a deliberate fail-closed boundary from a newly
 * forgotten backend action.
 */
export const handlerlessActionDispositions = Object.freeze({
  buffered: Object.freeze([
    DbAction.BuyWeaponUpgrade, DbAction.InstantWeaponUpgrade, DbAction.ActivateWeaponUpgrade,
    DbAction.BuyWeapon, DbAction.BuyUnitUpgrade, DbAction.InstantUnitUpgrade,
    DbAction.ActivateUnitUpgrade, DbAction.BuyUnit, DbAction.BuyCardPack, DbAction.EquipWeapon,
    DbAction.InstantBuyUnit, DbAction.InstantBuyWeapon, DbAction.ActivateUnit,
    DbAction.ActivateWeapon, DbAction.PromoteUnit, DbAction.ConvertScrapsToParts,
    DbAction.ConvertPartsToScraps, DbAction.UpgradeEliteSlot, DbAction.ClaimAchievement,
    DbAction.ChangeAchievementOffset, DbAction.ChangeAchievementProgres,
    DbAction.UpdateEquippedUnits,
  ] as const),
  responseOnly: Object.freeze([
    DbAction.UniqueSquadNameFailure, DbAction.UniqueSquadNameSuccess, DbAction.FacebookLoginOk,
    DbAction.UserAddedToSquadSuccess, DbAction.SystemMessage,
  ] as const),
  retired: Object.freeze([
    DbAction.SwitchToFacebook, DbAction.AddToHitList, DbAction.GetPlayersFromHitList,
    DbAction.ExpandHitList, DbAction.HitListPlayerLoggedIn, DbAction.ProvokePlayer,
  ] as const),
  debugDisabled: Object.freeze([
    DbAction.DebugAddLevel, DbAction.DebugAddSquadLevel, DbAction.AddDebugGoodies,
    DbAction.DebugChangeLevel, DbAction.DebugChangeMedals, DbAction.Test,
    DbAction.DebugChangeArenaLives, DbAction.DebugChangeArenaWins, DbAction.DebugAddScraps,
    DbAction.DebugRenewRental, DbAction.DebugChangeLeague, DbAction.DebugChangeDivision,
    DbAction.DebugChangeAnticheat, DbAction.DebugSetHeroicPoints,
  ] as const),
  rawRoute: Object.freeze([DbAction.GetConfigurations] as const),
  openTelemetry: Object.freeze([...benignNoOpActions]),
  sentinel: Object.freeze([DbAction.MaxAll] as const),
});

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
  ...blackMarketHandlers,
  ...rentalHandlers,
  ...vipHandlers,
  ...instantBattleHandlers,
  ...lootboxHandlers,
  ...inventoryImpressionHandlers,
  ...tutorialHandlers,
  ...analyticsHandlers,
  ...purchaseHandlers,
  ...videoAdHandlers,
  ...videoFeedHandlers,
  ...offerHandlers,
  ...clientLogHandlers,
  ...clientErrorHandlers,
};

/** Read-only direct-handler inventory used by the recovered action coverage test. */
export const registeredHandlerActions = Object.freeze(
  Object.keys(registry).map((value) => Number(value)).sort((left, right) => left - right),
);

/**
 * Route one Beanstalk envelope to its handler and produce the response envelope.
 * Never throws — all failures become a `{ Code, Message }` error envelope.
 */
export async function dispatch(req: RequestEnvelope): Promise<ResponseEnvelope> {
  const action = exactDatabaseAction(req.DbAction);
  if (action === undefined) {
    return { DbAction: -1, ...apiError(90, "Missing or invalid request action.") };
  }
  logger.api.action(dbActionName(action), action);

  if (!replacementClientVersionIsAllowed(req.ClientVersion, req.clientVersion, minimumClientVersion)) {
    return { DbAction: action, ...apiError(ApiErrorCode.InvalidClientVersion, "Client version is missing, invalid, or too old.") };
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
    const accountType = exactRequestedAccountType(req.AccountType);
    const player = entry.requiresAuth
      ? await authenticate(
        id,
        token,
        action === DbAction.LoginToCustomAccount ? accountType : undefined,
        action === DbAction.LoginToCustomAccount,
      )
      : id && token
        ? await findByIdOptional(id, token)
        : null;

    return await entry.handler({ req, player });
  } catch (err) {
    if (err instanceof ApiError) {
      return { DbAction: action, ...apiError(err.code, err.message), ...(err.details ?? {}) };
    }
    const message = err instanceof Error ? err.message : String(err);
    logger.errorWithEmoji("❌", `Handler for ${dbActionName(action)} threw`, "DISPATCH", { error: message });
    return { DbAction: action, ...apiError(ApiErrorCode.InternalServerError, "Internal server error.") };
  }
}
