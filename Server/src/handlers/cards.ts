import { ApiError } from "../apiErrors";
import { DbAction } from "../dbActions";
import type { PlayerDocument } from "../db";
import { ok, type ResponseEnvelope } from "../dtos";
import {
  WITHDRAW_NOT_YET_AVAILABLE,
  cardCraftingStateFor,
  cardInventoryStateFor,
  claimCraftedCardState,
  parseCraftingCards,
  serializeCardCrafting,
  serializeCardInventory,
  startCardCraftingState,
} from "../services/cardInventoryService";
import { depositSquadCards, withdrawSquadCard } from "../services/squadCardPoolService";
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

/**
 * Rebuild the exact recovery snapshots read by LEDNENKKDJM's 17401/17402/17501/17502 cases.
 *
 * The stock client grants/removes cards optimistically before the HTTP response. Returning the
 * current recipient CardManagerData and selected donor pool is therefore part of correctness,
 * not merely diagnostics: it rolls back a rejected tap without requiring a complete relog.
 */
async function cardPoolFailure(
  action: DbAction.DepositCards | DbAction.WithdrawCard,
  player: PlayerDocument,
  error: unknown,
  donorId?: string,
): Promise<ResponseEnvelope> {
  if (!(error instanceof ApiError)) throw error;
  const [latest, donor] = await Promise.all([
    findById(player.id),
    donorId ? findById(donorId) : Promise.resolve(null),
  ]);
  const recovered = latest ?? player;
  const state = progressionForPlayer(recovered);
  return {
    DbAction: action,
    Code: error.code,
    Message: error.message,
    CardManagerData: serializeCardInventory(cardInventoryStateFor(state)),
    DepositedCards: JSON.stringify(
      action === DbAction.WithdrawCard
        ? donor?.player.depositedCardsDic ?? {}
        : recovered.player.depositedCardsDic ?? {},
    ),
    ...(error.code === WITHDRAW_NOT_YET_AVAILABLE
      ? { NextWithdraw: cardInventoryStateFor(state).nextWithdraw }
      : {}),
  };
}

export const cardHandlers: Record<number, HandlerEntry> = {
  [DbAction.DepositCards]: authed(async ({ player, req }) => {
    try {
      const result = await depositSquadCards(player!.id, req.AddedCards, req.RemovedCards);
      return ok(DbAction.DepositCards, {
        DepositedCards: JSON.stringify(result.depositedCards),
      });
    } catch (error) {
      return cardPoolFailure(DbAction.DepositCards, player!, error);
    }
  }),

  [DbAction.WithdrawCard]: authed(async ({ player, req }) => {
    const donorId = typeof req.IdOfPlayer === "string" ? req.IdOfPlayer : "";
    const cardId = typeof req.CardId === "string" ? req.CardId : "";
    try {
      const result = await withdrawSquadCard(player!.id, donorId, cardId);
      return ok(DbAction.WithdrawCard, { NextWithdraw: result.nextWithdraw });
    } catch (error) {
      return cardPoolFailure(DbAction.WithdrawCard, player!, error, donorId);
    }
  }),

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
