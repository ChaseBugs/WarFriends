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
import { providerForAccountType } from "../services/identityService";
import { exactIdentityRequestProof } from "./identityRequestParsing";
import {
  exactDatabaseAction,
  exactMinimumClientVersion,
  replacementClientVersionIsAllowed,
} from "./requestEnvelopeParsing";
import {
  exactAuthenticationRequest,
  isRecoveredPreAccountSessionPlaceholder,
} from "./authenticationRequestParsing";
import { validatedRequestBufferId } from "../services/requestBufferAuthorityService";

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
    DbAction.UserAddedToSquadSuccess, DbAction.RemoveUserFromSquad, DbAction.SystemMessage,
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

    // RequestBuffer captures its common authentication fields when the delayed request object is
    // created. On first registration the stock client can therefore send one old buffer with the
    // pre-account missing/missing or `null`/`null` snapshot after the new session already exists.
    // There is no player authority in that envelope, so never execute its nested actions. Acknowledge only a valid
    // transport ID with an empty result list: OGLEHLIPEFM then removes the stale local buffer
    // without entering the UnAuthorizedAction -> OldToken -> Relog loop.
    if (action === DbAction.SendRequestBuffer
      && isRecoveredPreAccountSessionPlaceholder(req)) {
      const bufferId = validatedRequestBufferId(req.BufferId);
      return ok(action, {
        BufferId: bufferId,
        RequestsResults: "[]",
        DiscardedPreAccountBuffer: true,
      });
    }

    // Attach the player: required handlers authenticate strictly; others attach best-effort.
    // The recovered form builder emits two deliberately different envelopes: Id + Password for
    // LoginToCustomAccount, and PlayerId + Token for ordinary gameplay. Parse those contracts
    // separately so an action-specific Id or a new-password payload cannot become session proof.
    const loginAction = action === DbAction.LoginToCustomAccount;
    const authentication = exactAuthenticationRequest(req, loginAction ? "login" : "session");

    // A recovered menu-start race can dispatch GetPlayerData before GameLoginManager has restored
    // either common session field. Returning UnAuthorizedAction here is unsafe for the stock
    // client: it aliases that result to OldToken, relogs with the same absent credentials, and
    // repeats forever. With no presented authority there is nothing to refresh, so use the exact
    // LoginFailure result that clears the unusable local account and opens ManualLogin instead.
    // Partially supplied, malformed, and genuinely invalid credentials retain the strict
    // authentication path below and never gain this compatibility treatment.
    if (entry.requiresAuth
      && !loginAction
      && authentication.playerId === undefined
      && authentication.credential === undefined) {
      return { DbAction: action, ...apiError(ApiErrorCode.LoginFailure, "Missing credentials.") };
    }

    // AccountType is only meaningful during platform login. Normal authenticated form
    // requests omit it and therefore use the guest/server token path.
    const accountType = exactRequestedAccountType(req.AccountType);
    const loginProvider = loginAction && accountType !== undefined
      ? providerForAccountType(accountType)
      : null;
    const player = entry.requiresAuth
      ? await authenticate(
        authentication.playerId,
        authentication.credential,
        loginAction ? accountType : undefined,
        loginAction,
        loginProvider ? exactIdentityRequestProof(req, loginProvider) : undefined,
      )
      : authentication.playerId && authentication.credential
        ? await findByIdOptional(authentication.playerId, authentication.credential)
        : null;

    return await entry.handler({ req, player });
  } catch (err) {
    if (err instanceof ApiError) {
      // A rejected explicit login is not an expired gameplay session. The stock client treats
      // UnAuthorizedAction as OldToken and immediately relogs, creating an endless request loop.
      if (action === DbAction.LoginToCustomAccount
        && err.code === ApiErrorCode.RequestNotAuthorized) {
        return { DbAction: action, ...apiError(ApiErrorCode.LoginFailure, "Invalid credentials.") };
      }
      return { DbAction: action, ...apiError(err.code, err.message), ...(err.details ?? {}) };
    }
    const message = err instanceof Error ? err.message : String(err);
    logger.errorWithEmoji("❌", `Handler for ${dbActionName(action)} threw`, "DISPATCH", { error: message });
    return { DbAction: action, ...apiError(ApiErrorCode.InternalServerError, "Internal server error.") };
  }
}
