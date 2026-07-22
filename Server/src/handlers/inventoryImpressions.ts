import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  markWeaponShownState,
  serializeLevelManagerData,
} from "../services/itemInventoryService";
import { mutateProgression } from "../services/progressionMutationService";
import { markUnitShownState } from "../services/unitInventoryService";
import { requestedDirectInventoryName } from "./inventoryRequestParsing";
import { authed, type HandlerEntry } from "./types";

/**
 * Direct compatibility routes for the two notification acknowledgements.
 *
 * The normal 4.9.5 UI sends these through RequestBuffer, but diagnostic and historical
 * clients can call them directly. Both transports use the same pure transitions, including
 * catalog and level validation, so the direct route cannot be used as an ownership shortcut.
 */
export const inventoryImpressionHandlers: Record<number, HandlerEntry> = {
  [DbAction.WeaponWasShown]: authed(async ({ player, req }) => {
    const name = requestedDirectInventoryName(req);
    const result = await mutateProgression(
      player!.id,
      (state) => markWeaponShownState(state, player!.player.level, name),
    );
    return ok(DbAction.WeaponWasShown, {
      LevelName: result.definition.name,
      Weapon: JSON.stringify(result.weapon),
      LevelManagerData: serializeLevelManagerData(result.itemInventory),
    });
  }),

  [DbAction.ArmyUnitWasShown]: authed(async ({ player, req }) => {
    const name = requestedDirectInventoryName(req);
    const result = await mutateProgression(
      player!.id,
      (state) => markUnitShownState(state, player!.player.level, name),
    );
    return ok(DbAction.ArmyUnitWasShown, {
      LevelName: result.definition.name,
      Unit: JSON.stringify(result.unit),
      LevelManagerData: serializeLevelManagerData(result.itemInventory),
    });
  }),
};
