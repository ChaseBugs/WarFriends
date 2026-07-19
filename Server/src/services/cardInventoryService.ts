import generatedCardCatalog from "../data/cardCatalog.generated.json";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type { CardInventoryState, PlayerProgressionState } from "../db";

export const CARD_PACK_NOT_FOUND = 112;
export const CARD_PACK_NOT_ENOUGH_FUNDS = 100;
export const CARD_PACK_NO_DISCOUNT = 13601;

export interface CardDefinition {
  name: string;
  rarity: number;
  fromMission: number;
  implemented: boolean;
}

export interface CardPackDefinition {
  name: string;
  priceGold: number;
  priceWarBucks: number;
  enumValue: number;
  cardCount: number;
  fixedRarity: number;
  fixedRarityCount: number;
  guaranteedRarity: number;
  maxRarity: number;
}

interface CardCatalogArtifact {
  schemaVersion: number;
  clientVersion: string;
  source: string;
  sourceSha256: string;
  unlockLevel: number;
  cards: CardDefinition[];
  unresolvedRows: CardDefinition[];
  packs: CardPackDefinition[];
}

export interface CardPackPurchasePayload {
  cards: string[];
  cardPack: string;
  discount: number;
  startTime: number;
}

export interface CardInventoryMutationResult {
  state: PlayerProgressionState;
  cardInventory: CardInventoryState;
  pack: CardPackDefinition;
  cards: string[];
}

const artifact = generatedCardCatalog as CardCatalogArtifact;
export const CARD_UNLOCK_LEVEL = artifact.unlockLevel;
export const CARD_CATALOG: Readonly<Record<string, Readonly<CardDefinition>>> = Object.freeze(
  Object.fromEntries(artifact.cards.map((card) => [card.name, Object.freeze({ ...card })])),
);
export const CARD_PACK_CATALOG: Readonly<Record<string, Readonly<CardPackDefinition>>> = Object.freeze(
  Object.fromEntries(artifact.packs.map((pack) => [pack.name, Object.freeze({ ...pack })])),
);

/** New accounts begin with the exact empty CardManagerData wire shape. */
export function createInitialCardInventory(): CardInventoryState {
  return {
    // CardManager.OnPlayerDataLoaded creates zero entries for missing card components. Keep
    // server storage sparse and materialize only cards that were actually granted or spent.
    cardData: {},
    buddyCardData: {},
    nextWithdraw: 0,
    nextBuddyDeposit: 0,
    extraSlot: false,
  };
}

function cloneCardInventory(value: CardInventoryState): CardInventoryState {
  return {
    cardData: Object.fromEntries(Object.entries(value.cardData).map(([id, card]) => [id, { ...card }])),
    buddyCardData: Object.fromEntries(Object.entries(value.buddyCardData).map(([id, card]) => [id, {
      ...card,
      equippedVisuals: Object.fromEntries(
        Object.entries(card.equippedVisuals).map(([slot, visual]) => [slot, { ...visual }]),
      ),
    }])),
    nextWithdraw: value.nextWithdraw,
    nextBuddyDeposit: value.nextBuddyDeposit,
    extraSlot: value.extraSlot,
  };
}

export function cardInventoryStateFor(state: PlayerProgressionState): CardInventoryState {
  return cloneCardInventory(state.cardInventory ?? createInitialCardInventory());
}

function objectJson(value: string): Record<string, unknown> {
  if (value.length < 2 || value.length > 64_000) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Card-pack request data is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "Card-pack request data is invalid JSON.");
  }
  if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Card-pack request data must be an object.");
  }
  return parsed as Record<string, unknown>;
}

function integer(value: unknown, field: string): number {
  const parsed = Number(value);
  if (!Number.isInteger(parsed)) throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an integer.`);
  return parsed;
}

function cardPackName(value: unknown): string {
  if (typeof value !== "string" || value.length < 1 || value.length > 128) {
    throw new ApiError(CARD_PACK_NOT_FOUND, "Card-pack name is invalid.");
  }
  return value;
}

/** Decode the exact object queued by CardManager.BuyCardPack/BuyThreeCards. */
export function parseCardPackPurchaseData(value: string): CardPackPurchasePayload {
  const data = objectJson(value);
  if (!Array.isArray(data.cards) || data.cards.some((card) => typeof card !== "string")) {
    throw new ApiError(CARD_PACK_NOT_FOUND, "Card-pack contents are invalid.");
  }
  const cards = data.cards as string[];
  if (cards.some((card) => card.length < 1 || card.length > 128)) {
    throw new ApiError(CARD_PACK_NOT_FOUND, "Card-pack contains an invalid card ID.");
  }
  return {
    cards,
    cardPack: cardPackName(data.cardPack),
    discount: integer(data.discount ?? 0, "discount"),
    startTime: integer(data.StartTime ?? 0, "StartTime"),
  };
}

export function requestedCardPackName(value: string): string {
  try {
    const parsed = JSON.parse(value) as Record<string, unknown>;
    return typeof parsed?.cardPack === "string" ? parsed.cardPack : "";
  } catch {
    return "";
  }
}

/**
 * Validate the pack roll generated by the stock Unity client.
 *
 * CardManager adds exact-rarity cards first, then fills the remaining positions from the
 * configured rarity interval. The old protocol does not transmit a server nonce and its
 * success parser does not load replacement cards, so the server cannot reproduce Unity's
 * random identity selection without breaking an unmodified client. It nevertheless rejects
 * unknown/disabled cards, wrong counts, and every roll outside the source rarity envelope.
 */
function validatePackContents(pack: CardPackDefinition, cards: readonly string[]): void {
  if (cards.length !== pack.cardCount) {
    throw new ApiError(CARD_PACK_NOT_FOUND, "Card-pack count does not match source balancing.");
  }
  for (let index = 0; index < cards.length; index++) {
    const card = CARD_CATALOG[cards[index]];
    if (!card?.implemented) {
      throw new ApiError(CARD_PACK_NOT_FOUND, "Card-pack contains an unknown or disabled card.");
    }
    if (index < pack.fixedRarityCount) {
      if (card.rarity !== pack.fixedRarity) {
        throw new ApiError(CARD_PACK_NOT_FOUND, "Card-pack fixed-rarity slot is invalid.");
      }
    } else if (card.rarity < pack.guaranteedRarity || card.rarity > pack.maxRarity) {
      throw new ApiError(CARD_PACK_NOT_FOUND, "Card-pack random slot is outside its rarity range.");
    }
  }
}

/** Debit one source-priced pack and atomically add its validated cards. */
export function purchaseCardPackState(
  state: PlayerProgressionState,
  playerLevelIndex: number,
  payload: CardPackPurchasePayload,
): CardInventoryMutationResult {
  const pack = CARD_PACK_CATALOG[payload.cardPack];
  if (!pack) throw new ApiError(CARD_PACK_NOT_FOUND, "Card pack was not found.");
  if (payload.discount !== 0) {
    throw new ApiError(CARD_PACK_NO_DISCOUNT, "Card-pack discount has no server-owned entitlement.");
  }
  if (payload.startTime < 0) throw new ApiError(CARD_PACK_NOT_FOUND, "Card-pack start time is invalid.");
  // DatabasePlayer.Level is LevelManager.levelNumber (zero based); CardConstants stores the
  // display level, matching the recovered `warcardsUnlockLevel > currentLevel.displayNumber` gate.
  if (Math.max(0, Math.floor(playerLevelIndex)) < CARD_UNLOCK_LEVEL - 1) {
    throw new ApiError(CARD_PACK_NOT_FOUND, "War Cards are not unlocked for this player level.");
  }
  validatePackContents(pack, payload.cards);
  if (state.gold < pack.priceGold || state.warBucks < pack.priceWarBucks) {
    // BuyCardPack's recovered parser groups both wallet rollback paths under code 100.
    throw new ApiError(CARD_PACK_NOT_ENOUGH_FUNDS, "Not enough currency for this card pack.");
  }

  const cardInventory = cardInventoryStateFor(state);
  for (const id of payload.cards) {
    const current = cardInventory.cardData[id]?.amount ?? 0;
    if (!Number.isSafeInteger(current) || current < 0 || current === Number.MAX_SAFE_INTEGER) {
      throw new ApiError(ApiErrorCode.InternalServerError, `Card count for ${id} is invalid.`);
    }
    cardInventory.cardData[id] = { amount: current + 1 };
  }
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold - pack.priceGold,
    warBucks: state.warBucks - pack.priceWarBucks,
    cardInventory,
  };
  return { state: next, cardInventory, pack, cards: [...payload.cards] };
}

export function serializeCardInventory(value: CardInventoryState): string {
  return JSON.stringify(value);
}

/** Exact rollback body consumed by BuyCardPack failure branches. */
export function cardPackRecoveryFields(state: PlayerProgressionState): Record<string, unknown> {
  return {
    Gold: state.gold,
    WarBucks: state.warBucks,
    CardManagerData: serializeCardInventory(cardInventoryStateFor(state)),
    SpecialOffers: JSON.stringify({}),
  };
}
