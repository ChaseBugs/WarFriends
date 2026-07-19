import { DbAction } from "../dbActions";
import { PlayerStatus } from "../constants";
import { ok } from "../dtos";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { updatePlayerFields } from "../services/playerService";
import { replaceCustomCredential } from "../services/authService";
import { buildDatabasePlayer, buildPlayerStateResponse } from "../services/playerStateService";
import {
  ensurePlayerNameAvailable,
  normalizeCountry,
  normalizeLocale,
  normalizePlayerName,
  parseNotificationSettings,
  settingsForPlayer,
} from "../services/playerSettingsService";
import { authed, type HandlerEntry } from "./types";

// Player profile and settings handlers. GetPlayerData is the client's primary state fetch
// after login. Mutations validate and persist only their own fields, which prevents a stale
// profile request from overwriting progression written concurrently by match or squad logic.

export const playerHandlers: Record<number, HandlerEntry> = {
  [DbAction.GetPlayerData]: authed(({ player }) => {
    // GetPlayerData does not deserialize DatabasePlayer. The recovered callback requires
    // Time and PlayerData, then reads league/profile aliases beside that map. Returning the
    // profile alone looked plausible in diagnostics but failed during actual Unity boot.
    return ok(DbAction.GetPlayerData, buildPlayerStateResponse(player!));
  }),

  [DbAction.GetPlayerInfo]: authed(({ player }) => {
    // The callback looks for a PlayerInfo item and passes it to the same typed-attribute
    // parser used for account responses. A flat summary object is not compatible here.
    return ok(DbAction.GetPlayerInfo, { PlayerInfo: buildDatabasePlayer(player!) });
  }),

  [DbAction.SetPlayerStatus]: authed(async ({ player, req }) => {
    const status = Number(req.PlayerStatus ?? req.Status ?? PlayerStatus.Online);
    if (!Object.values(PlayerStatus).includes(status)) return ok(DbAction.SetPlayerStatus, { Status: player!.player.status });
    player!.player.status = status;
    await updatePlayerFields(player!.id, { status });
    return ok(DbAction.SetPlayerStatus, { Status: status });
  }),

  [DbAction.UpdateDeviceToken]: authed(async ({ player, req }) => {
    if (typeof req.DeviceToken === "string") {
      // Push providers impose platform-specific token sizes. The server only needs a bounded,
      // non-whitespace value; an empty token deliberately unregisters the current device.
      const deviceToken = req.DeviceToken.trim().slice(0, 4096);
      player!.player.deviceToken = deviceToken;
      await updatePlayerFields(player!.id, { deviceToken });
    }
    if (typeof req.Locale === "string") {
      const locale = normalizeLocale(req.Locale);
      player!.player.locale = locale;
      await updatePlayerFields(player!.id, { locale });
    }
    return ok(DbAction.UpdateDeviceToken);
  }),

  [DbAction.ChangePlayerName]: authed(async ({ player, req }) => {
    const name = normalizePlayerName(req.Name);
    await ensurePlayerNameAvailable(player!.id, name);

    const renameCount = player!.player.renameCount ?? 0;
    const requestedPaidRename = Number(req.PayForRename) === 1;
    if (renameCount > 0 && requestedPaidRename) {
      // The recovered request asks the backend to charge renameGoldPrice, but the currency
      // schema is not yet authoritative. Rejecting preserves balances instead of granting a
      // paid mutation for free or trusting a client-supplied price.
      throw new ApiError(ApiErrorCode.UnknownAction, "Paid rename is unavailable until economy validation is enabled.");
    }
    if (renameCount > 0) {
      throw new ApiError(ApiErrorCode.UnknownAction, "This account has already used its free rename.");
    }

    player!.player.accountName = name;
    player!.player.renameCount = renameCount + 1;
    await updatePlayerFields(player!.id, { accountName: name, renameCount: player!.player.renameCount });
    // The client deducts currency only when PayForRename is 1. Since this path is the free
    // rename, return 0 explicitly and provide the count consumed by PlayerAnalytics.
    return ok(DbAction.ChangePlayerName, { Name: name, PayForRename: 0, RenameCount: player!.player.renameCount });
  }),

  [DbAction.ChangePlayerCountry]: authed(async ({ player, req }) => {
    // The recovered 1.6.0 client sends NewCountryCode, not Country. Retaining Country as a
    // compatibility alias helps diagnostics and newer adapters without weakening validation.
    const country = normalizeCountry(req.NewCountryCode ?? req.Country);
    player!.player.country = country;
    await updatePlayerFields(player!.id, { country });
    return ok(DbAction.ChangePlayerCountry, { Country: country, NewCountryCode: country });
  }),

  [DbAction.UpdateArmyPower]: authed(async ({ player, req }) => {
    const armyPower = Math.max(0, Math.floor(Number(req.ArmyPower)));
    if (Number.isFinite(armyPower)) {
      player!.player.armyPower = armyPower;
      await updatePlayerFields(player!.id, { armyPower });
    }
    return ok(DbAction.UpdateArmyPower, { ArmyPower: player!.player.armyPower });
  }),

  [DbAction.UpdateSettings]: authed(async ({ player, req }) => {
    const notificationSettings = parseNotificationSettings(req.Settings, settingsForPlayer(player!));
    player!.player.notificationSettings = notificationSettings;
    await updatePlayerFields(player!.id, { notificationSettings });
    return ok(DbAction.UpdateSettings);
  }),

  [DbAction.ChangeLanguage]: authed(async ({ player, req }) => {
    const locale = normalizeLocale(req.Locale);
    player!.player.locale = locale;
    await updatePlayerFields(player!.id, { locale });
    return ok(DbAction.ChangeLanguage, { Locale: locale });
  }),

  [DbAction.ChangeNameAndPassword]: authed(async ({ player, req }) => {
    const name = normalizePlayerName(req.Name);
    const password = typeof req.Password === "string" ? req.Password : "";
    if (password.length < 6 || password.length > 128) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Password must contain 6 to 128 characters.");
    }
    await ensurePlayerNameAvailable(player!.id, name);

    // Update the public name first and the credential second. The request was authenticated
    // with the old token, while the response returns the replacement so the client can store
    // it before its next login. Never write the password into the client-facing Player DTO.
    player!.player.accountName = name;
    await updatePlayerFields(player!.id, { accountName: name });
    const sessionToken = await replaceCustomCredential(player!.id, password);
    player!.authToken = sessionToken;
    return ok(DbAction.ChangeNameAndPassword, { Name: name, Password: password, Token: sessionToken });
  }),
};
