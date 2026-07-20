import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  getOrCreateBlackMarketOffer,
  serializeBlackMarketOffer,
} from "../services/blackMarketService";
import { authed, type HandlerEntry } from "./types";

/** Black Market reads are separated from general economy handlers because action 217 issues
 * purchase authority: its persisted response is later required to validate buffered action
 * 76. Returning an ad-hoc offer without committing it first would let two concurrent reads
 * authorize different weapons and make legitimate purchases nondeterministically fail. */
export const blackMarketHandlers: Record<number, HandlerEntry> = {
  [DbAction.GetNewBMOffer]: authed(async ({ player }) => {
    const result = await getOrCreateBlackMarketOffer(player!.id, player!.player.level);
    // OAMHANEBKIE expects a JSON string, not a nested response object. It deserializes this
    // exact field through BlackMarketManager.LoadBMData and immediately opens the offer UI.
    return ok(DbAction.GetNewBMOffer, {
      BlackMarketOffer: serializeBlackMarketOffer(result.blackMarket),
    });
  }),
};
