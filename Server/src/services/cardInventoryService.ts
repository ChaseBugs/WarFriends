import { randomInt } from "node:crypto";
import generatedCardCatalog from "../data/cardCatalog.generated.json";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type { CardCraftingState, CardInventoryState, PlayerProgressionState } from "../db";

export const CARD_PACK_NOT_FOUND = 112;
export const CARD_PACK_NOT_ENOUGH_FUNDS = 100;
export const CARD_PACK_NO_DISCOUNT = 13601;
export const CARD_NOT_FOUND = 17401;
export const BUDDY_CARD_NOT_READY = 17402;
export const CARD_ALREADY_WITHDRAWN = 17501;
export const WITHDRAW_NOT_YET_AVAILABLE = 17502;
export const ALREADY_CRAFTING = 17601;
export const CRAFTED_CARD_NOT_READY = 17701;
export const MAX_PVP_CARDS_PER_MATCH = 6;

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
  craftingRules: {
    inputCount: number;
    bronzeToSilverMinutes: number;
    silverToGoldMinutes: number;
  };
  cardPoolRules: {
    withdrawCooldownMinutes: number;
    buddyDepositCooldownMinutes: number;
    maximumBuddyCards: number;
    reputationPoints: {
      bronze: number;
      silver: number;
      gold: number;
      buddy: number;
    };
    capacityBySquadLevel: number[];
  };
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

export interface MissionCardRewardResult {
  state: PlayerProgressionState;
  cardInventory: CardInventoryState;
  cards: string[];
}

export interface CardCraftingMutationResult {
  state: PlayerProgressionState;
  cardInventory: CardInventoryState;
  cardCrafting: CardCraftingState;
  cardId?: string;
}

const artifact = generatedCardCatalog as CardCatalogArtifact;
export const CARD_UNLOCK_LEVEL = artifact.unlockLevel;
export const CARD_CATALOG: Readonly<Record<string, Readonly<CardDefinition>>> = Object.freeze(
  Object.fromEntries(artifact.cards.map((card) => [card.name, Object.freeze({ ...card })])),
);
export const CARD_PACK_CATALOG: Readonly<Record<string, Readonly<CardPackDefinition>>> = Object.freeze(
  Object.fromEntries(artifact.packs.map((pack) => [pack.name, Object.freeze({ ...pack })])),
);
export const CARD_CRAFTING_RULES = Object.freeze({ ...artifact.craftingRules });
export const CARD_POOL_RULES = Object.freeze({ ...artifact.cardPoolRules });

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

/** Empty state required by CardCraftingManager.LoadData during login and failure recovery. */
export function createInitialCardCrafting(): CardCraftingState {
  return { cards: [], start: 0, end: 0 };
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

export function cardCraftingStateFor(state: PlayerProgressionState): CardCraftingState {
  const value = state.cardCrafting ?? createInitialCardCrafting();
  return { cards: [...value.cards], start: value.start, end: value.end };
}

/**
 * Decode the card-usage proof carried by GameEnded and the replacement WebSocket relay.
 *
 * The recovered REST client serializes `UsedCards` as a JSON string; the replacement relay
 * can carry the same IDs as a native JSON array. CardSelectionScreen exposes three normal
 * slots plus VIP, extra, and Buddy slots, so six entries is the largest valid one-match set.
 * The selection screen can place the same normal Card object in multiple slots when its
 * amount is greater than one, so repeated IDs are preserved and charged per occurrence.
 */
export function parsePvpUsedCards(value: unknown): string[] {
  let parsed = value;
  if (typeof value === "string") {
    if (value.length < 2 || value.length > 4_096) {
      throw new ApiError(CARD_NOT_FOUND, "UsedCards is missing or too large.");
    }
    try {
      parsed = JSON.parse(value);
    } catch {
      throw new ApiError(CARD_NOT_FOUND, "UsedCards is invalid JSON.");
    }
  }
  if (
    !Array.isArray(parsed)
    || parsed.length > MAX_PVP_CARDS_PER_MATCH
    || parsed.some((card) => typeof card !== "string" || card.length < 1 || card.length > 128)
  ) {
    throw new ApiError(CARD_NOT_FOUND, "UsedCards contains an invalid battle-card list.");
  }
  return [...parsed as string[]];
}

export interface PvpCardConsumptionResult {
  state: PlayerProgressionState;
  cardInventory: CardInventoryState;
  usedCards: string[];
}

/**
 * Consume the authenticated player's reported PvP cards from one progression snapshot.
 *
 * Normal IDs must be playable catalog cards with a positive owned amount. Buddy IDs must
 * name an exact positive snapshot in `buddyCardData`; consuming a Buddy removes that unique
 * snapshot rather than leaving an amount-zero entry that would incorrectly count toward
 * CardManager.BuddyCardsOwned(). Validation and all decrements happen on a clone, so a bad
 * ID cannot partially consume an earlier valid ID. The caller commits this state in the same
 * MongoDB transaction as match rewards and the terminal match state.
 */
export function consumePvpUsedCardsState(
  state: PlayerProgressionState,
  usedCards: readonly string[],
): PvpCardConsumptionResult {
  const cards = parsePvpUsedCards([...usedCards]);
  const cardInventory = cardInventoryStateFor(state);
  for (const cardId of cards) {
    const definition = CARD_CATALOG[cardId];
    if (definition?.implemented) {
      const current = cardInventory.cardData[cardId]?.amount ?? 0;
      if (!Number.isSafeInteger(current) || current < 1) {
        throw new ApiError(CARD_NOT_FOUND, `War Card ${cardId} is not owned.`);
      }
      if (current === 1) delete cardInventory.cardData[cardId];
      else cardInventory.cardData[cardId] = { amount: current - 1 };
      continue;
    }

    const buddy = cardInventory.buddyCardData[cardId];
    if (!buddy || buddy.amount !== 1) {
      throw new ApiError(CARD_NOT_FOUND, `Buddy War Card ${cardId} is not owned.`);
    }
    delete cardInventory.buddyCardData[cardId];
  }

  const previousPlayed = state.warCardsPlayed ?? 0;
  if (!Number.isSafeInteger(previousPlayed) || previousPlayed < 0 || previousPlayed > Number.MAX_SAFE_INTEGER - cards.length) {
    throw new ApiError(ApiErrorCode.InternalServerError, "War Card play counter is invalid.");
  }
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    cardInventory,
    warCardsPlayed: previousPlayed + cards.length,
  };
  return { state: next, cardInventory, usedCards: cards };
}

/** Decode the `Cards` JSON form field used by CraftCard and CraftAndClaimCard. */
export function parseCraftingCards(value: unknown): string[] {
  if (typeof value !== "string" || value.length < 2 || value.length > 16_384) {
    throw new ApiError(CARD_NOT_FOUND, "Crafting cards are missing.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(CARD_NOT_FOUND, "Crafting cards are invalid JSON.");
  }
  if (
    !Array.isArray(parsed)
    || parsed.length !== CARD_CRAFTING_RULES.inputCount
    || parsed.some((card) => typeof card !== "string" || card.length < 1 || card.length > 128)
  ) {
    throw new ApiError(CARD_NOT_FOUND, "Crafting requires exactly three valid card IDs.");
  }
  return parsed as string[];
}

function recipeRarity(cards: readonly string[]): 1 | 2 {
  if (cards.length !== CARD_CRAFTING_RULES.inputCount) {
    throw new ApiError(CARD_NOT_FOUND, "Crafting requires exactly three cards.");
  }
  const definitions = cards.map((cardId) => CARD_CATALOG[cardId]);
  if (definitions.some((definition) => !definition?.implemented)) {
    throw new ApiError(CARD_NOT_FOUND, "Crafting contains an unknown or disabled card.");
  }
  const rarity = definitions[0].rarity;
  // The recovered UI accepts only three cards of one rarity and disables Gold/Buddy cards.
  // Enforce the rule again on the backend because a modified APK can bypass the UI filters.
  if ((rarity !== 1 && rarity !== 2) || definitions.some((definition) => definition.rarity !== rarity)) {
    throw new ApiError(CARD_NOT_FOUND, "Crafting requires three Bronze cards or three Silver cards.");
  }
  return rarity;
}

function ensureOwnedRecipe(inventory: CardInventoryState, cards: readonly string[]): void {
  const required = new Map<string, number>();
  for (const cardId of cards) required.set(cardId, (required.get(cardId) ?? 0) + 1);
  for (const [cardId, count] of required) {
    const owned = inventory.cardData[cardId]?.amount ?? 0;
    if (!Number.isSafeInteger(owned) || owned < count) {
      throw new ApiError(CARD_NOT_FOUND, `Card ${cardId} is not available for crafting.`);
    }
  }
}

function consumeRecipe(inventory: CardInventoryState, cards: readonly string[]): void {
  for (const cardId of cards) {
    const next = (inventory.cardData[cardId]?.amount ?? 0) - 1;
    if (next > 0) inventory.cardData[cardId] = { amount: next };
    else delete inventory.cardData[cardId];
  }
}

/**
 * Begin the exact client-side three-for-one timed recipe.
 *
 * Bronze inputs produce a random Silver card after 30 source minutes; Silver inputs produce
 * a random Gold card after 60 source minutes. Input removal and receipt creation share one
 * progression revision, so a retry can only observe `AlreadyCrafting` and cannot consume twice.
 */
export function startCardCraftingState(
  state: PlayerProgressionState,
  now: number,
  cards: readonly string[],
): CardCraftingMutationResult {
  const existing = cardCraftingStateFor(state);
  if (existing.cards.length > 0 && existing.start < existing.end) {
    throw new ApiError(ALREADY_CRAFTING, "Player is already crafting a card.");
  }
  const rarity = recipeRarity(cards);
  const inventory = cardInventoryStateFor(state);
  ensureOwnedRecipe(inventory, cards);
  consumeRecipe(inventory, cards);
  const minutes = rarity === 1
    ? CARD_CRAFTING_RULES.bronzeToSilverMinutes
    : CARD_CRAFTING_RULES.silverToGoldMinutes;
  const cardCrafting: CardCraftingState = {
    cards: [...cards],
    start: now,
    end: now + minutes * 60,
  };
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    cardInventory: inventory,
    cardCrafting,
  };
  return { state: next, cardInventory: inventory, cardCrafting };
}

/** Pick one playable card from the next rarity using Node's unbiased cryptographic RNG. */
function craftedResultCard(inputRarity: 1 | 2, choose: (upperBound: number) => number): string {
  const outputRarity = inputRarity + 1;
  const pool = Object.values(CARD_CATALOG)
    .filter((definition) => definition.implemented && definition.rarity === outputRarity)
    .map((definition) => definition.name)
    .sort();
  if (pool.length === 0) throw new ApiError(ApiErrorCode.InternalServerError, "Craft result pool is empty.");
  const index = choose(pool.length);
  if (!Number.isInteger(index) || index < 0 || index >= pool.length) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Craft result selector is invalid.");
  }
  return pool[index];
}

/** Grant a finished server-selected result and clear the receipt atomically. */
export function claimCraftedCardState(
  state: PlayerProgressionState,
  now: number,
  choose: (upperBound: number) => number = (upperBound) => randomInt(upperBound),
): CardCraftingMutationResult {
  const crafting = cardCraftingStateFor(state);
  if (crafting.cards.length !== CARD_CRAFTING_RULES.inputCount || crafting.start >= crafting.end || now < crafting.end) {
    throw new ApiError(CRAFTED_CARD_NOT_READY, "Crafted card is not ready.");
  }
  const inputRarity = recipeRarity(crafting.cards);
  const cardId = craftedResultCard(inputRarity, choose);
  const inventory = cardInventoryStateFor(state);
  const current = inventory.cardData[cardId]?.amount ?? 0;
  if (!Number.isSafeInteger(current) || current < 0 || current === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, `Card count for ${cardId} is invalid.`);
  }
  inventory.cardData[cardId] = { amount: current + 1 };
  const cardCrafting = createInitialCardCrafting();
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    cardInventory: inventory,
    cardCrafting,
    goldCardsCrafted: (state.goldCardsCrafted ?? 0) + (inputRarity === 2 ? 1 : 0),
  };
  return { state: next, cardInventory: inventory, cardCrafting, cardId };
}

/**
 * Consume one valid recipe and grant its result immediately for an active subscriber.
 *
 * CardCraftingManager.CraftInstantWarcard removes the three inputs optimistically and sends
 * action 2000 with the same `Cards` JSON used by timed crafting. Its success path is deliberately
 * shared with ClaimCraftedCard and reads exactly `CardId`, so this transition must finish the
 * whole exchange in one progression revision and leave no timed CraftData receipt behind.
 *
 * Subscription expiry is checked against server time. Returning CARD_NOT_FOUND for an inactive
 * subscription is intentional: that recovered error branch reloads CardManagerData and clears
 * `waitingForServerResponse`, restoring the stock client's optimistic local removals. The old
 * protocol has no subscription-specific crafting error with equivalent recovery behavior.
 */
export function craftAndClaimSubscribedCardState(
  state: PlayerProgressionState,
  now: number,
  cards: readonly string[],
  choose: (upperBound: number) => number = (upperBound) => randomInt(upperBound),
): CardCraftingMutationResult {
  if (state.subscription?.type !== "subscription1" || state.subscription.expireTime <= now) {
    throw new ApiError(CARD_NOT_FOUND, "An active subscription is required for instant crafting.");
  }
  const existing = cardCraftingStateFor(state);
  if (existing.cards.length > 0 && existing.start < existing.end) {
    throw new ApiError(ALREADY_CRAFTING, "Player is already crafting a card.");
  }

  const inputRarity = recipeRarity(cards);
  const inventory = cardInventoryStateFor(state);
  ensureOwnedRecipe(inventory, cards);
  consumeRecipe(inventory, cards);

  const cardId = craftedResultCard(inputRarity, choose);
  const current = inventory.cardData[cardId]?.amount ?? 0;
  if (!Number.isSafeInteger(current) || current < 0 || current === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, `Card count for ${cardId} is invalid.`);
  }
  inventory.cardData[cardId] = { amount: current + 1 };
  const cardCrafting = createInitialCardCrafting();
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    cardInventory: inventory,
    cardCrafting,
    goldCardsCrafted: (state.goldCardsCrafted ?? 0) + (inputRarity === 2 ? 1 : 0),
  };
  return { state: next, cardInventory: inventory, cardCrafting, cardId };
}

export function serializeCardCrafting(value: CardCraftingState): string {
  return JSON.stringify(value);
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

/**
 * Select and grant one server-owned card-pack reward without charging its shop price.
 *
 * Heroic missions return the selected IDs in `HeroicMissionsCompletionRewardCardPack`, so
 * unlike BuyCardPack the backend can safely own identity selection without a request nonce or
 * patched client. Fixed slots use the exact source rarity; every remaining slot is selected
 * from the pack's recovered inclusive rarity interval. Duplicate IDs are valid because the
 * stock CardManager increments amounts once for every array element.
 *
 * This composable helper deliberately preserves `revision`. The enclosing reward settlement
 * combines cards with currencies, elite parts, achievements, and its receipt under one revision.
 */
export function grantCardPackRewardState(
  state: PlayerProgressionState,
  packName: string,
  choose: (upperBound: number) => number = (upperBound) => randomInt(upperBound),
): CardInventoryMutationResult {
  const pack = CARD_PACK_CATALOG[packName];
  if (!pack) throw new ApiError(ApiErrorCode.InternalServerError, `Reward card pack ${packName} is invalid.`);

  const fixedPool = Object.values(CARD_CATALOG)
    .filter((card) => card.implemented && card.rarity === pack.fixedRarity)
    .map((card) => card.name)
    .sort();
  const rangedPool = Object.values(CARD_CATALOG)
    .filter((card) => (
      card.implemented
      && card.rarity >= pack.guaranteedRarity
      && card.rarity <= pack.maxRarity
    ))
    .map((card) => card.name)
    .sort();
  if (fixedPool.length === 0 || rangedPool.length === 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `Reward card pack ${packName} has an empty pool.`);
  }

  const cards: string[] = [];
  for (let index = 0; index < pack.cardCount; index += 1) {
    const pool = index < pack.fixedRarityCount ? fixedPool : rangedPool;
    const selected = choose(pool.length);
    if (!Number.isInteger(selected) || selected < 0 || selected >= pool.length) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Reward card selector is invalid.");
    }
    cards.push(pool[selected]!);
  }
  // Keep this assertion beside selection so future catalog/rule changes cannot silently grant
  // a pack shape that the already recovered purchase validator would reject.
  validatePackContents(pack, cards);

  const cardInventory = cardInventoryStateFor(state);
  for (const id of cards) {
    const current = cardInventory.cardData[id]?.amount ?? 0;
    if (!Number.isSafeInteger(current) || current < 0 || current === Number.MAX_SAFE_INTEGER) {
      throw new ApiError(ApiErrorCode.InternalServerError, `Card count for ${id} is invalid.`);
    }
    cardInventory.cardData[id] = { amount: current + 1 };
  }
  return {
    state: { ...state, cardInventory },
    cardInventory,
    pack,
    cards,
  };
}

/**
 * Grant the exact-rarity loose cards used by the three-Daily-mission completion reward.
 *
 * CardDefinitions.FROMMISSION is the only recovered eligibility marker for this acquisition
 * path: normal rows use 1, later rows use 10/40, and unavailable rows use 99. The archived
 * client exposes the value but the retired server-side selector is absent, so interpreting it
 * as a display-level threshold is an explicit reconstruction boundary. Eligible IDs then use
 * a documented uniform cryptographic replacement. As with the Heroic pack helper, the enclosing
 * mission receipt owns the single progression revision.
 */
export function grantMissionCardsState(
  state: PlayerProgressionState,
  rarity: number,
  count: number,
  playerLevelIndex: number,
  choose: (upperBound: number) => number = (upperBound) => randomInt(upperBound),
): MissionCardRewardResult {
  if (!Number.isSafeInteger(rarity) || rarity < 1 || rarity > 3 || !Number.isSafeInteger(count) || count <= 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Daily mission card reward is invalid.");
  }
  const displayLevel = Math.max(1, Math.floor(playerLevelIndex) + 1);
  const pool = Object.values(CARD_CATALOG)
    .filter((card) => (
      card.implemented
      && card.rarity === rarity
      && card.fromMission <= displayLevel
    ))
    .map((card) => card.name)
    .sort();
  if (pool.length === 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Daily mission card reward pool is empty.");
  }

  const cardInventory = cardInventoryStateFor(state);
  const cards: string[] = [];
  for (let index = 0; index < count; index += 1) {
    const selected = choose(pool.length);
    if (!Number.isInteger(selected) || selected < 0 || selected >= pool.length) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Daily mission card selector is invalid.");
    }
    const id = pool[selected]!;
    const current = cardInventory.cardData[id]?.amount ?? 0;
    if (!Number.isSafeInteger(current) || current < 0 || current === Number.MAX_SAFE_INTEGER) {
      throw new ApiError(ApiErrorCode.InternalServerError, `Card count for ${id} is invalid.`);
    }
    cardInventory.cardData[id] = { amount: current + 1 };
    cards.push(id);
  }
  return {
    state: { ...state, cardInventory },
    cardInventory,
    cards,
  };
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
