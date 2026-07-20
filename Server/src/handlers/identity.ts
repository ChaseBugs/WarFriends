import { ApiError, ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import type { PlayerDocument } from "../db";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  findIdentity,
  linkIdentity,
  unlinkIdentity,
  type IdentityProvider,
} from "../services/identityService";
import { findById } from "../services/playerService";
import { buildDatabasePlayer, buildPlayerStateResponse } from "../services/playerStateService";
import { createGameCenterAccount, type CreatedAccount } from "../services/authService";
import { buildPlayerLeaderboardItem } from "../services/leaderboardService";
import { claimOneTimeReward, oneTimeRewardWire } from "../services/oneTimeRewardService";
import { authed, open, type HandlerEntry } from "./types";

// Platform-account actions recovered from BeanstalkServerManager. Identity records are
// separate from player documents so uniqueness and credentials remain server-owned; the
// familiar facebookId/googlePlayId/gameCenterId values are mirrored onto DatabasePlayer
// only for the Unity client's connected-account UI.

function text(value: unknown): string {
  return typeof value === "string" || typeof value === "number" ? String(value).trim() : "";
}

function identityId(req: Record<string, unknown>, provider: IdentityProvider): string {
  if (provider === "facebook") return text(req.FacebookId);
  if (provider === "googlePlay") return text(req.GooglePlayId ?? req.googlePlayId);
  return text(req.GameCenterId ?? req.gameCenterId);
}

function identityCredential(req: Record<string, unknown>, provider: IdentityProvider): string {
  if (provider === "facebook") return text(req.FacebookPassword);
  if (provider === "googlePlay") return text(req.GooglePlayPassword ?? req.googlePlayPassword);
  return text(req.GameCenterPassword ?? req.gameCenterPassword);
}

function identityName(req: Record<string, unknown>): string {
  return text(req.Name ?? req.PlayerName);
}

/** Build every field read unconditionally by OGLEHLIPEFM.JLMICAJOHIK. */
export function buildGameCenterAccountPayload(
  created: CreatedAccount,
  gameCenterCredential: string,
): Record<string, unknown> {
  return {
    id: created.doc.id,
    Id: created.doc.id,
    PlayerId: created.doc.id,
    token: created.authToken,
    Token: created.authToken,
    password: gameCenterCredential,
    Password: gameCenterCredential,
    AccountType: AccountType.GameCenter,
    Player: buildDatabasePlayer(created.doc),
    ...buildPlayerStateResponse(created.doc),
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
      identityId(req, provider),
      identityCredential(req, provider),
      identityName(req),
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
    const externalId = identityId(req, provider);
    const identity = externalId ? await findIdentity(provider, externalId) : null;
    const idKey = provider === "facebook" ? "FacebookId" : provider === "googlePlay" ? "GooglePlayId" : "GameCenterId";

    // The tutorial callback does not read a generic Exists boolean. Decompiled client code
    // explicitly checks resultMessage == "OK", then reads the provider-specific id field.
    // Keep both aliases for diagnostics, but always satisfy that exact recovered contract.
    return ok(action, {
      Exists: Boolean(identity),
      resultMessage: identity ? "OK" : "NOT_FOUND",
      ...(identity ? { [idKey]: externalId } : {}),
    });
  });
}

const facebookExistence: HandlerEntry = open(async ({ req }) => {
  const externalId = identityId(req, "facebook");
  const identity = externalId ? await findIdentity("facebook", externalId) : null;
  if (!identity) {
    // IJEAJGCCHEF.Success is numeric 1. For ExistFBAccount this means that no previous
    // account exists and the client may offer to create/link a new one.
    return ok(DbAction.ExistFBAccount, { Code: 1, Exists: false, AccountExists: false });
  }

  const player = await findById(identity.playerId);
  // The recovered callback branches on AccountAlreadyCreated (4), then consumes these
  // exact field names for UserExistsDialog. Echoing FacebookPassword is safe here because
  // it is the credential from this request; the stored HMAC is never reversible or exposed.
  return ok(DbAction.ExistFBAccount, {
    Code: 4,
    Exists: true,
    AccountExists: true,
    PlayerId: identity.playerId,
    FacebookId: externalId,
    FacebookName: identity.displayName || player?.player.accountName || "",
    FacebookPassword: identityCredential(req, "facebook"),
    facebookLevel: player?.player.level ?? 1,
    facebookMedals: player?.player.medalsBalance ?? 0,
  });
});

const gameCenterExistence: HandlerEntry = open(async ({ req }) => {
  const externalId = identityId(req, "gameCenter");
  const identity = externalId ? await findIdentity("gameCenter", externalId) : null;
  // ExistGCAccount uses the same resultMessage contract as tutorial platform checks rather
  // than Facebook's numeric AccountAlreadyCreated branch.
  return ok(DbAction.ExistGCAccount, {
    Exists: Boolean(identity),
    resultMessage: identity ? "OK" : "NOT_FOUND",
    ...(identity ? { GameCenterId: externalId, PlayerId: identity.playerId } : {}),
  });
});

export const identityHandlers: Record<number, HandlerEntry> = {
  [DbAction.CreateGcAccount]: open(async ({ req }) => {
    const gameCenterId = identityId(req, "gameCenter");
    const credential = identityCredential(req, "gameCenter");
    try {
      const created = await createGameCenterAccount(gameCenterId, credential, text(req.DeviceToken));
      return ok(
        DbAction.CreateGcAccount,
        buildGameCenterAccountPayload(created, credential),
      );
    } catch (error) {
      if (!(error instanceof ApiError) || error.code !== ApiErrorCode.GameCenterAlreadyCreated) {
        throw error;
      }
      // A duplicate may be observed either before this request or through the unique-index
      // race in the transaction. Read after the aborted transaction so the winner is visible.
      const identity = await findIdentity("gameCenter", gameCenterId);
      const existing = identity ? await findById(identity.playerId) : null;
      if (!existing) throw error;
      return ok(
        DbAction.CreateGcAccount,
        buildExistingGameCenterPayload(existing, gameCenterId),
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
    const hasGameCenter = text(req.haveGcId) === "1";
    const updated = hasGameCenter
      ? await linkIdentity(
          player!.id,
          "gameCenter",
          identityId(req, "gameCenter"),
          identityCredential(req, "gameCenter"),
          identityName(req),
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
            gcPassword: identityCredential(req, "gameCenter"),
          }
        : {}),
    });
  }),
};
