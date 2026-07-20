import { DbAction } from "../dbActions";
import { PlayerStatus } from "../constants";
import { ok } from "../dtos";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { findById, updatePlayerFields } from "../services/playerService";
import { replaceCustomProfileCredential } from "../services/authService";
import { buildDatabasePlayer, buildPlayerStateResponse, progressionForPlayer } from "../services/playerStateService";
import { recomputePlayerArmyPower } from "../services/armyPowerService";
import {
  ensurePlayerNameAvailable,
  normalizeCountry,
  normalizeLocale,
  normalizePlayerName,
  notificationSettingsEqual,
  parseNotificationSettings,
  settingsForPlayer,
} from "../services/playerSettingsService";
import { authed, type HandlerEntry } from "./types";
import {
  PLAYER_RENAME_NOT_ENOUGH_GOLD,
  renamePlayer,
} from "../services/playerRenameService";
import { ensureRentalOffer } from "../services/rentalService";
import { ensureDailyVipCards } from "../services/vipService";
import { setPlayerPresence } from "../services/playerPresenceService";
import {
  buildEventAssignmentClientConfig,
  ensureActiveEventAssignment,
} from "../services/eventAssignmentService";

// Player profile and settings handlers. GetPlayerData is the client's primary state fetch
// after login. Mutations validate and persist only their own fields, which prevents a stale
// profile request from overwriting progression written concurrently by match or squad logic.

export const playerHandlers: Record<number, HandlerEntry> = {
  [DbAction.GetPlayerData]: authed(async ({ player }) => {
    // GetPlayerData does not deserialize DatabasePlayer. The recovered callback requires
    // Time and PlayerData, then reads league/profile aliases beside that map. Returning the
    // profile alone looked plausible in diagnostics but failed during actual Unity boot.
    const rental = await ensureRentalOffer(player!.id, player!.player.level);
    // Rental is an outer GetPlayerData field, not part of the Dynamo-style PlayerData map.
    // EGPLNLMMADN reads it directly and always opens this boot variant as a free trial.
    const vipCards = await ensureDailyVipCards(player!.id);
    // This is the separate EventAssignmentManager calendar, not Squad Events. With no reviewed
    // deployment schedule the service returns null and the feature remains completely hidden.
    // When active, initialization is persisted before its config/state are exposed together.
    const eventAssignment = await ensureActiveEventAssignment(player!.id);
    // ensureDailyVipCards reloads after the rental transition and returns the newest complete
    // progression snapshot. Building PlayerData from rental.state here would omit the newly
    // committed cards and make the popup disagree with CardManagerData after this response.
    const projected = { ...player!, progression: eventAssignment?.state ?? vipCards.state };
    return ok(DbAction.GetPlayerData, {
      ...buildPlayerStateResponse(projected),
      ...(eventAssignment ? {
        EventAssignmentConfig: buildEventAssignmentClientConfig(eventAssignment.event),
      } : {}),
      ...(rental.bootOffer ? { Rental: rental.bootOffer } : {}),
      ...(vipCards.reward ? {
        // NCNNKGNJNOH has already loaded the authoritative CardManagerData from PlayerData by
        // the time it queues this dialog. Unlike BuyVip, this callback intentionally does not
        // call AddCard again; returning only the IDs here is therefore presentation metadata.
        VipReward1: vipCards.reward.cardIds[0],
        VipReward2: vipCards.reward.cardIds[1],
        VipRewardForDay: vipCards.reward.dayKey,
      } : {}),
    });
  }),

  [DbAction.GetPlayerInfo]: authed(({ player }) => {
    // The callback looks for a PlayerInfo item and passes it to the same typed-attribute
    // parser used for account responses. A flat summary object is not compatible here.
    return ok(DbAction.GetPlayerInfo, { PlayerInfo: buildDatabasePlayer(player!) });
  }),

  [DbAction.SetPlayerStatus]: authed(async ({ player, req }) => {
    const status = Number(req.PlayerStatus ?? req.Status ?? PlayerStatus.Online);
    if (!Object.values(PlayerStatus).includes(status)) return ok(DbAction.SetPlayerStatus, { Status: player!.player.status });
    const effective = await setPlayerPresence(player!.id, status as PlayerStatus);
    player!.player.status = effective;
    return ok(DbAction.SetPlayerStatus, { Status: effective });
  }),

  [DbAction.UpdateDeviceToken]: authed(async ({ player, req }) => {
    const fields: Parameters<typeof updatePlayerFields>[1] = {};
    if (typeof req.DeviceToken === "string") {
      // Push providers impose platform-specific token sizes. The server only needs a bounded,
      // non-whitespace value; an empty token deliberately unregisters the current device.
      const deviceToken = req.DeviceToken.trim().slice(0, 4096);
      if (player!.player.deviceToken !== deviceToken) fields.deviceToken = deviceToken;
    }
    if (typeof req.Locale === "string") {
      const locale = normalizeLocale(req.Locale);
      if (player!.player.locale !== locale) fields.locale = locale;
    }
    if (Object.keys(fields).length > 0) {
      // Device registration sends token and locale together. Publish their changed subset in one
      // MongoDB update so a reconnect neither writes twice nor leaves a half-refreshed profile if
      // the process stops between two independent writes. An exact retry performs no write.
      Object.assign(player!.player, fields);
      await updatePlayerFields(player!.id, fields);
    }
    return ok(DbAction.UpdateDeviceToken);
  }),

  [DbAction.ChangePlayerName]: authed(async ({ player, req }) => {
    const name = normalizePlayerName(req.Name);
    const payForRenameValue = Number(req.PayForRename);
    if (payForRenameValue !== 0 && payForRenameValue !== 1) {
      throw new ApiError(ApiErrorCode.UnknownAction, "PayForRename must be 0 or 1.");
    }
    try {
      const result = await renamePlayer(player!.id, name, payForRenameValue === 1);
      // HIKDINCJEPB deducts its locally displayed price only when this flag is one, then sets
      // RenameCount. Echoing the request supports both the free platform-name sync (zero) and
      // RenameDialog, whose first confirmed rename sends one even though its current price is 0.
      return ok(DbAction.ChangePlayerName, {
        Name: result.name,
        PayForRename: payForRenameValue,
        RenameCount: result.renameCount,
      });
    } catch (error) {
      if (!(error instanceof ApiError) || error.code !== PLAYER_RENAME_NOT_ENOUGH_GOLD) throw error;
      const latest = await findById(player!.id) ?? player!;
      return {
        DbAction: DbAction.ChangePlayerName,
        Result: error.code,
        Code: error.code,
        Message: error.message,
        // LEDNENKKDJM's 11402 branch uses both fields to restore the optimistic wallet and
        // keep PlayerAnalytics.renameGoldPrice aligned with the server's next attempt.
        RenameCount: latest.player.renameCount ?? 0,
        PlayerGold: progressionForPlayer(latest).gold,
      };
    }
  }),

  [DbAction.ChangePlayerCountry]: authed(async ({ player, req }) => {
    // The recovered 1.6.0 client sends NewCountryCode, not Country. Retaining Country as a
    // compatibility alias helps diagnostics and newer adapters without weakening validation.
    const country = normalizeCountry(req.NewCountryCode ?? req.Country);
    if (player!.player.country !== country) {
      player!.player.country = country;
      await updatePlayerFields(player!.id, { country });
    }
    return ok(DbAction.ChangePlayerCountry, { Country: country, NewCountryCode: country });
  }),

  [DbAction.UpdateArmyPower]: authed(async ({ player }) => {
    // The recovered client normally echoes ArmyPower after detecting a boot mismatch, but
    // InstantBattle also invokes this action with no value. Neither form is authoritative:
    // recompute all three LevelManager components from the latest persisted revision and use
    // the client request only as a signal that the public/indexed cache should be refreshed.
    const power = await recomputePlayerArmyPower(player!.id);
    player!.player.armyPower = power.total;
    return ok(DbAction.UpdateArmyPower, {
      ArmyPower: power.total,
      UnitPower: power.unitPower,
      WeaponPower: power.weaponPower,
      RankPower: power.rankPower,
    });
  }),

  [DbAction.UpdateSettings]: authed(async ({ player, req }) => {
    const notificationSettings = parseNotificationSettings(req.Settings, settingsForPlayer(player!));
    if (!notificationSettingsEqual(player!.player.notificationSettings, notificationSettings)) {
      player!.player.notificationSettings = notificationSettings;
      await updatePlayerFields(player!.id, { notificationSettings });
    }
    return ok(DbAction.UpdateSettings);
  }),

  [DbAction.ChangeLanguage]: authed(async ({ player, req }) => {
    const locale = normalizeLocale(req.Locale);
    if (player!.player.locale !== locale) {
      player!.player.locale = locale;
      await updatePlayerFields(player!.id, { locale });
    }
    return ok(DbAction.ChangeLanguage, { Locale: locale });
  }),

  [DbAction.ChangeNameAndPassword]: authed(async ({ player, req }) => {
    const name = normalizePlayerName(req.Name);
    const password = typeof req.Password === "string" ? req.Password : "";
    await ensurePlayerNameAvailable(player!.id, name);

    // The recovered Client sends Name and Password together for action 121, so publish them
    // with the rotated gameplay token in one compare-and-set write. Mutate the request snapshot
    // only after MongoDB commits; an error must leave both durable and in-memory state unchanged.
    const sessionToken = await replaceCustomProfileCredential(
      player!.id,
      player!.authToken!,
      name,
      password,
    );
    player!.player.accountName = name;
    player!.authToken = sessionToken;
    return ok(DbAction.ChangeNameAndPassword, { Name: name, Password: password, Token: sessionToken });
  }),
};
