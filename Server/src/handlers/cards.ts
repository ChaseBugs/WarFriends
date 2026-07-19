import { ApiError } from "../apiErrors";
import { DbAction } from "../dbActions";
import type { PlayerDocument } from "../db";
import { ok, type ResponseEnvelope } from "../dtos";
import {
  cardCraftingStateFor,
  cardInventoryStateFor,
  claimCraftedCardState,
  parseCraftingCards,
  serializeCardCrafting,
  serializeCardInventory,
  startCardCraftingState,
} from "../services/cardInventoryService";
import { findById } from "../services/playerService";
import { progressionForPlayer } from "../services/playerStateService";
import { mutateProgression } from "../services/progressionMutationService";
import { authed, type HandlerEntry } from "./types";

/**
 * Return the authoritative snapshots consumed by the recovered generic error parser.
 *
 * CraftCard removes inputs optimistically on the Unity side. If validation fails, error 17401
 * reloads CardManagerData; errors 17601 and 17701 reload CraftData. Supplying both objects for
 * every known crafting failure is harmless to the old parser and ensures a modified or newer
 * client cannot remain desynchronized after a rejected request.
 */
async function craftingFailure(
  action: DbAction.CraftCard | DbAction.ClaimCraftedCard,
  player: PlayerDocument,
  error: unknown,
): Promise<ResponseEnvelope> {
  if (!(error instanceof ApiError)) throw error;
  const latest = await findById(player.id) ?? player;
  const state = progressionForPlayer(latest);
  return {
    DbAction: action,
    Code: error.code,
    Message: error.message,
    CardManagerData: serializeCardInventory(cardInventoryStateFor(state)),
    CraftData: serializeCardCrafting(cardCraftingStateFor(state)),
    DepositedCards: JSON.stringify(latest.player.depositedCardsDic ?? {}),
  };
}

export const cardHandlers: Record<number, HandlerEntry> = {
  [DbAction.CraftCard]: authed(async ({ player, req }) => {
    try {
      const cards = parseCraftingCards(req.Cards);
      const result = await mutateProgression(player!.id, (state, now) =>
        startCardCraftingState(state, now, cards));
      // DGCHKNFPMEN reads End unconditionally and schedules the local notification.
      return ok(DbAction.CraftCard, { End: result.cardCrafting.end });
    } catch (error) {
      return craftingFailure(DbAction.CraftCard, player!, error);
    }
  }),

  [DbAction.ClaimCraftedCard]: authed(async ({ player }) => {
    try {
      const result = await mutateProgression(player!.id, (state, now) =>
        claimCraftedCardState(state, now));
      // GDNAPODCNCI adds exactly this server-selected card and then clears local CraftData.
      return ok(DbAction.ClaimCraftedCard, { CardId: result.cardId });
    } catch (error) {
      return craftingFailure(DbAction.ClaimCraftedCard, player!, error);
    }
  }),
};
