import { ApiError, ApiErrorCode } from "../apiErrors";
import generatedCardCatalog from "../data/cardCatalog.generated.json";
import type { CardCraftingState } from "../db";

const MAX_CLIENT_UNIX_SECONDS = 2_147_483_647;
const artifact = generatedCardCatalog as {
  craftingRules: {
    inputCount: number;
    bronzeToSilverMinutes: number;
    silverToGoldMinutes: number;
  };
  cards: Array<{ name: string; rarity: number; implemented: boolean }>;
};
const cardDefinitions = new Map(artifact.cards.map((card) => [card.name, card]));

function authorityError(): never {
  throw new ApiError(ApiErrorCode.InternalServerError, "Stored card-crafting receipt is invalid.");
}

/**
 * Validate a server time before it is written to or compared with CraftData.
 *
 * The recovered CraftData model stores `start` and `end` as signed C# `int` fields. Keeping the
 * server boundary inside that same range prevents a valid JavaScript timestamp from wrapping when
 * Newtonsoft.Json materializes it in Unity and accidentally making a long craft immediately ready.
 */
export function validatedCardCraftingTime(value: number): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_CLIENT_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Card-crafting time is invalid.");
  }
  return value;
}

/**
 * Validate the complete three-for-one CraftData authority snapshot.
 *
 * CardCraftingManager considers any nonempty card list with `start < end` active. Therefore a
 * malformed partial receipt cannot safely be normalized to empty: doing so would discard proof
 * that three inventory cards were already consumed and could allow another recipe to spend or
 * mint against ambiguous state. Active receipts must reproduce the exact source-extracted recipe
 * duration and one-rarity input rule. Empty state is the exact shape written by StopCrafting.
 */
export function validatedCardCraftingState(value: unknown): CardCraftingState {
  if (!value || typeof value !== "object" || Array.isArray(value)) return authorityError();
  const candidate = value as Partial<CardCraftingState>;
  const keys = Object.keys(value).sort();
  if (
    keys.length !== 3
    || keys[0] !== "cards"
    || keys[1] !== "end"
    || keys[2] !== "start"
    || !Array.isArray(candidate.cards)
  ) {
    return authorityError();
  }

  const start = validatedCardCraftingTime(candidate.start as number);
  const end = validatedCardCraftingTime(candidate.end as number);
  if (candidate.cards.length === 0) {
    if (start !== 0 || end !== 0) return authorityError();
    return { cards: [], start: 0, end: 0 };
  }
  if (candidate.cards.length !== artifact.craftingRules.inputCount) return authorityError();

  const cards = candidate.cards.map((id) => {
    if (typeof id !== "string") return authorityError();
    const definition = cardDefinitions.get(id);
    if (!definition?.implemented || (definition.rarity !== 1 && definition.rarity !== 2)) {
      return authorityError();
    }
    return { id, rarity: definition.rarity };
  });
  const rarity = cards[0].rarity;
  if (cards.some((card) => card.rarity !== rarity)) return authorityError();
  const minutes = rarity === 1
    ? artifact.craftingRules.bronzeToSilverMinutes
    : artifact.craftingRules.silverToGoldMinutes;
  const duration = minutes * 60;
  if (start >= end || start > MAX_CLIENT_UNIX_SECONDS - duration || end !== start + duration) {
    return authorityError();
  }
  return { cards: cards.map((card) => card.id), start, end };
}

/** Missing CraftData is the only supported legacy fallback; present malformed state fails closed. */
export function cardCraftingAuthorityFor(value: unknown): CardCraftingState {
  return value === undefined
    ? { cards: [], start: 0, end: 0 }
    : validatedCardCraftingState(value);
}
