import { ApiError, ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  findValidatedIdentityOwner,
  linkIdentity,
  unlinkIdentity,
  type IdentityProvider,
} from "../services/identityService";
import { buildDatabasePlayer, buildPlayerStateResponse } from "../services/playerStateService";
import { createGameCenterAccount, type CreatedAccount } from "../services/authService";
import { buildPlayerLeaderboardItem } from "../services/leaderboardService";
import { claimOneTimeReward, oneTimeRewardWire } from "../services/oneTimeRewardService";
import { authed, open, type HandlerEntry } from "./types";
import {
  buildEventAssignmentClientConfig,
  ensureActiveEventAssignment,
  type EventAssignmentMutationResult,
} from "../services/eventAssignmentService";
import {
  exactHaveGameCenterId,
  exactIdentityRequestCredential,
  exactIdentityRequestDisplayName,
  exactIdentityRequestId,
} from "./identityRequestParsing";
import { exactDeviceToken } from "../services/playerSettingsService";

// Platform-account actions recovered from BeanstalkServerManager. Identity records are
// separate from player documents so uniqueness and credentials remain server-owned; the
// familiar facebookId/googlePlayId/gameCenterId values are mirrored onto DatabasePlayer
// only for the Unity client's connected-account UI.

function optionalIdentityDeviceToken(value: unknown): string {
  return value === undefined ? "" : exactDeviceToken(value);
}

/** Build every field read unconditionally by OGLEHLIPEFM.JLMICAJOHIK. */
export function buildGameCenterAccountPayload(
  created: CreatedAccount,
  gameCenterCredential: string,
  eventAssignment?: EventAssignmentMutationResult | null,
): Record<string, unknown> {
  const projected = eventAssignment
    ? { ...created.doc, progression: eventAssignment.state }
    : created.doc;
  return {
    id: created.doc.id,
    Id: created.doc.id,
    PlayerId: created.doc.id,
    token: created.authToken,
    Token: created.authToken,
    password: gameCenterCredential,
    Password: gameCenterCredential,
    AccountType: AccountType.GameCenter,
    Player: buildDatabasePlayer(projected),
    ...buildPlayerStateResponse(projected),
    ...(eventAssignment ? {
      EventAssignmentConfig: buildEventAssignmentClientConfig(eventAssignment.event),
    } : {}),
  };
}

/**
 * Build error 15400 in the FHIPGDADNFG attribute shape consumed by UserExistsDialog.
 * The public profile identifies the existing owner without exposing its session token or
 * the irreversible Game Center credential HMAC.
 */
export function buildExistingGameCenterPayload(
  player: PlayerDocument,
  gameCenterId: string,
): Record<string, unknown> {
  return {
    Result: ApiErrorCode.GameCenterAlreadyCreated,
    Code: ApiErrorCode.GameCenterAlreadyCreated,
    Message: "Game Center account already exists.",
    GameCenterId: gameCenterId,
    PlayerData: buildPlayerLeaderboardItem(player, 0),
  };
}

function linkAction(action: DbAction, provider: IdentityProvider): HandlerEntry {
  return authed(async ({ player, req }) => {
    // Re-linking the same provider updates its credential; attempting to claim an identity
    // owned by another player fails in identityService before any player state is changed.
    const updated = await linkIdentity(
      player!.id,
      provider,
      exactIdentityRequestId(req, provider),
      exactIdentityRequestCredential(req, provider),
      exactIdentityRequestDisplayName(req, provider),
    );
    // FacebookLoginReward is tied to a successful provider link, never to a standalone
    // client-supplied RewardId. Re-linking is safe: the persisted marker makes this a no-op.
    const facebookReward = provider === "facebook"
      ? await claimOneTimeReward(updated.id, "FacebookLoginReward", "facebook-link")
      : null;
    return ok(action, {
      Player: buildDatabasePlayer(updated),
      PlayerId: updated.id,
      Linked: true,
      ...(facebookReward ? oneTimeRewardWire(facebookReward) : {}),
    });
  });
}

function unlinkAction(action: DbAction, provider: IdentityProvider): HandlerEntry {
  return authed(async ({ player }) => {
    // Unlink is idempotent: deleting an already-absent identity still leaves the player in
    // a valid guest-login state and returns the current authoritative player snapshot.
    const updated = await unlinkIdentity(player!.id, provider);
    return ok(action, { Player: buildDatabasePlayer(updated), PlayerId: updated.id, Linked: false });
  });
}

function tutorialExistenceAction(action: DbAction, provider: IdentityProvider): HandlerEntry {
  return open(async ({ req }) => {
    const externalId = exactIdentityRequestId(req, provider);
    const owner = externalId ? await findValidatedIdentityOwner(provider, externalId) : null;
    const idKey = provider === "facebook" ? "FacebookId" : provider === "googlePlay" ? "GooglePlayId" : "GameCenterId";

    // The tutorial callback does not read a generic Exists boolean. Decompiled client code
    // explicitly checks resultMessage == "OK", then reads the provider-specific id field.
    // Keep both aliases for diagnostics, but always satisfy that exact recovered contract.
    return ok(action, {
      Exists: Boolean(owner),
      resultMessage: owner ? "OK" : "NOT_FOUND",
      ...(owner ? { [idKey]: externalId } : {}),
    });
  });
}

const facebookExistence: HandlerEntry = open(async ({ req }) => {
  const externalId = exactIdentityRequestId(req, "facebook");
  const owner = externalId ? await findValidatedIdentityOwner("facebook", externalId) : null;
  if (!owner) {
    // IJEAJGCCHEF.Success is numeric 1. For ExistFBAccount this means that no previous
    // account exists and the client may offer to create/link a new one.
    return ok(DbAction.ExistFBAccount, { Code: 1, Exists: false, AccountExists: false });
  }

  const { identity, player } = owner;
  // The recovered callback branches on AccountAlreadyCreated (4), then consumes these
  // exact field names for UserExistsDialog. Echoing FacebookPassword is safe here because
  // it is the credential from this request; the stored HMAC is never reversible or exposed.
  return ok(DbAction.ExistFBAccount, {
    Code: 4,
    Exists: true,
    AccountExists: true,
    PlayerId: identity.playerId,
    FacebookId: externalId,
    FacebookName: identity.displayName || player.player.accountName,
    FacebookPassword: exactIdentityRequestCredential(req, "facebook"),
    facebookLevel: player.player.level,
    facebookMedals: player.player.medalsBalance,
  });
});

const gameCenterExistence: HandlerEntry = open(async ({ req }) => {
  const externalId = exactIdentityRequestId(req, "gameCenter");
  const owner = externalId ? await findValidatedIdentityOwner("gameCenter", externalId) : null;
  // ExistGCAccount uses the same resultMessage contract as tutorial platform checks rather
  // than Facebook's numeric AccountAlreadyCreated branch.
  return ok(DbAction.ExistGCAccount, {
    Exists: Boolean(owner),
    resultMessage: owner ? "OK" : "NOT_FOUND",
    ...(owner ? { GameCenterId: externalId, PlayerId: owner.player.id } : {}),
  });
});

export const identityHandlers: Record<number, HandlerEntry> = {
  [DbAction.CreateGcAccount]: open(async ({ req }) => {
    const gameCenterId = exactIdentityRequestId(req, "gameCenter");
    const credential = exactIdentityRequestCredential(req, "gameCenter");
    try {
      const created = await createGameCenterAccount(
        gameCenterId,
        credential,
        optionalIdentityDeviceToken(req.DeviceToken),
      );
      const eventAssignment = await ensureActiveEventAssignment(created.doc.id);
      return ok(
        DbAction.CreateGcAccount,
        buildGameCenterAccountPayload(created, credential, eventAssignment),
      );
    } catch (error) {
      if (!(error instanceof ApiError) || error.code !== ApiErrorCode.GameCenterAlreadyCreated) {
        throw error;
      }
      // A duplicate may be observed either before this request or through the unique-index
      // race in the transaction. Read after the aborted transaction so the winner is visible.
      const owner = await findValidatedIdentityOwner("gameCenter", gameCenterId);
      if (!owner) throw error;
      return ok(
        DbAction.CreateGcAccount,
        buildExistingGameCenterPayload(owner.player, gameCenterId),
      );
    }
  }),

  [DbAction.AddFacebook]: linkAction(DbAction.AddFacebook, "facebook"),
  [DbAction.AddGooglePlay]: linkAction(DbAction.AddGooglePlay, "googlePlay"),
  [DbAction.AddGameCenter]: linkAction(DbAction.AddGameCenter, "gameCenter"),

  [DbAction.RemoveFacebook]: unlinkAction(DbAction.RemoveFacebook, "facebook"),
  [DbAction.RemoveGooglePlay]: unlinkAction(DbAction.RemoveGooglePlay, "googlePlay"),

  [DbAction.ExistFBAccount]: facebookExistence,
  [DbAction.ExistGCAccount]: gameCenterExistence,
  [DbAction.TutorialCheckFBAccount]: tutorialExistenceAction(DbAction.TutorialCheckFBAccount, "facebook"),
  [DbAction.TutorialCheckGPGSAccount]: tutorialExistenceAction(DbAction.TutorialCheckGPGSAccount, "googlePlay"),

  [DbAction.RemoveOrUpdateGC]: authed(async ({ player, req }) => {
    // The client sends haveGcId=0 to remove Game Center and haveGcId=1 with fresh
    // credentials to replace it. Both branches reuse the same guarded service operations.
    const hasGameCenter = exactHaveGameCenterId(req.haveGcId);
    const updated = hasGameCenter
      ? await linkIdentity(
          player!.id,
          "gameCenter",
          exactIdentityRequestId(req, "gameCenter"),
          exactIdentityRequestCredential(req, "gameCenter"),
          exactIdentityRequestDisplayName(req, "gameCenter"),
        )
      : await unlinkIdentity(player!.id, "gameCenter");
    return ok(DbAction.RemoveOrUpdateGC, {
      Player: buildDatabasePlayer(updated),
      PlayerId: updated.id,
      Linked: hasGameCenter,
      Added: hasGameCenter,
      AccountType: updated.player.accountType,
      ...(hasGameCenter
        ? {
            gcID: updated.player.gameCenterId,
            // This is an echo needed by GameLoginManager.UpdatePlayerByGC, not a value read
            // back from the identity collection.
            gcPassword: exactIdentityRequestCredential(req, "gameCenter"),
          }
        : {}),
    });
  }),
};
