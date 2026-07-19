import { DbAction } from "../dbActions";
import { PlayerStatus } from "../constants";
import { ok } from "../dtos";
import { updatePlayerFields } from "../services/playerService";
import { authed, type HandlerEntry } from "./types";

// Player data + lightweight settings. GetPlayerData is the client's primary state fetch
// after login. BACKEND.md §2.4.

export const playerHandlers: Record<number, HandlerEntry> = {
  [DbAction.GetPlayerData]: authed(({ player }) => ok(DbAction.GetPlayerData, { Player: player!.player })),

  [DbAction.GetPlayerInfo]: authed(({ player }) =>
    ok(DbAction.GetPlayerInfo, {
      id: player!.id,
      Name: player!.player.accountName,
      Level: player!.player.level,
      ArmyPower: player!.player.armyPower,
      LeagueId: player!.player.leagueId,
      SquadId: player!.player.squadName,
    }),
  ),

  [DbAction.SetPlayerStatus]: authed(async ({ player, req }) => {
    const status = Number(req.PlayerStatus ?? req.Status ?? PlayerStatus.Online);
    if (!Object.values(PlayerStatus).includes(status)) return ok(DbAction.SetPlayerStatus, { Status: player!.player.status });
    player!.player.status = status;
    await updatePlayerFields(player!.id, { status });
    return ok(DbAction.SetPlayerStatus, { Status: status });
  }),

  [DbAction.UpdateDeviceToken]: authed(async ({ player, req }) => {
    if (typeof req.DeviceToken === "string") {
      player!.player.deviceToken = req.DeviceToken;
      await updatePlayerFields(player!.id, { deviceToken: req.DeviceToken });
    }
    return ok(DbAction.UpdateDeviceToken);
  }),

  [DbAction.ChangePlayerName]: authed(async ({ player, req }) => {
    if (typeof req.Name === "string" && req.Name.trim()) {
      player!.player.accountName = req.Name.trim().slice(0, 15);
      await updatePlayerFields(player!.id, { accountName: player!.player.accountName });
    }
    return ok(DbAction.ChangePlayerName, { Name: player!.player.accountName });
  }),

  [DbAction.ChangePlayerCountry]: authed(async ({ player, req }) => {
    if (typeof req.Country === "string") {
      player!.player.country = req.Country;
      await updatePlayerFields(player!.id, { country: req.Country });
    }
    return ok(DbAction.ChangePlayerCountry, { Country: player!.player.country });
  }),

  [DbAction.UpdateArmyPower]: authed(async ({ player, req }) => {
    const armyPower = Math.max(0, Math.floor(Number(req.ArmyPower)));
    if (Number.isFinite(armyPower)) {
      player!.player.armyPower = armyPower;
      await updatePlayerFields(player!.id, { armyPower });
    }
    return ok(DbAction.UpdateArmyPower, { ArmyPower: player!.player.armyPower });
  }),
};
