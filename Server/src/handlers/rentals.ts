import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  RENTAL_NOT_FOUND,
  acceptRentalOffer,
} from "../services/rentalService";
import { progressionForPlayer } from "../services/playerStateService";
import { findById } from "../services/playerService";
import { unitRecoveryFields } from "../services/unitInventoryService";
import { weaponRecoveryFields } from "../services/itemInventoryService";
import { authed, type HandlerEntry } from "./types";

function boolean(value: unknown): boolean | undefined {
  if (value === true || value === 1 || value === "1" || value === "True" || value === "true") return true;
  if (value === false || value === 0 || value === "0" || value === "False" || value === "false") return false;
  return undefined;
}

/**
 * Action 138 is an aggregate endpoint despite carrying only one Boolean request field.
 *
 * IEPANBKNHIA does not parse the outer response as a normal action result. It deserializes
 * `RequestsResults` and dispatches every nested object through the ordinary buffered-action
 * parser. A free trial therefore returns nested action 138 with `Rental`, while a discounted
 * permanent purchase returns BuyWeapon/BuyUnit so the client does not mark that item borrowed.
 */
export const rentalHandlers: Record<number, HandlerEntry> = {
  [DbAction.AcceptRentalOffer]: authed(async ({ player, req }) => {
    const buyDiscounted = boolean(req.buyRentalDiscounted);
    if (buyDiscounted === undefined) {
      throw new ApiError(ApiErrorCode.UnknownAction, "buyRentalDiscounted must be a Boolean.");
    }

    try {
      const result = await acceptRentalOffer(player!.id, buyDiscounted);
      return ok(DbAction.AcceptRentalOffer, {
        RequestsResults: JSON.stringify([{
          ActionId: result.resultAction,
          Result: 1,
          ...result.resultFields,
        }]),
        Replayed: result.replayed,
      });
    } catch (error) {
      const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
      // Another economy request may have won the revision race before validation failed.
      // Reload the committed wallet/inventory so the optimistic Unity rollback never restores
      // the stale authentication snapshot captured at the beginning of this HTTP request.
      const current = await findById(player!.id);
      const state = progressionForPlayer(current ?? player!);
      const rental = state.rental;
      let recovery: Record<string, unknown> = {};
      let action: DbAction = DbAction.AcceptRentalOffer;
      if (buyDiscounted && rental?.type === 1) {
        action = DbAction.BuyWeapon;
        recovery = weaponRecoveryFields(state, rental.id);
      } else if (buyDiscounted && rental?.type === 0) {
        action = DbAction.BuyUnit;
        recovery = unitRecoveryFields(state, rental.id);
      }
      // NoRentalFound is intentionally nested too: OGLEHLIPEFM has its only dedicated
      // 13602 branch inside JIMIKHFDEFC, after the outer RequestsResults parser succeeds.
      return ok(DbAction.AcceptRentalOffer, {
        RequestsResults: JSON.stringify([{
          ActionId: action,
          Result: code || RENTAL_NOT_FOUND,
          ...recovery,
        }]),
      });
    }
  }),
};
