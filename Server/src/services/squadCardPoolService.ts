import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  players,
  squads,
  withMongoTransaction,
  type CardInventoryState,
  type PlayerDocument,
  type PlayerProgressionState,
  type SavedBuddyCardState,
} from "../db";
import {
  BUDDY_CARD_NOT_READY,
  CARD_ALREADY_WITHDRAWN,
  CARD_CATALOG,
  CARD_NOT_FOUND,
  CARD_POOL_RULES,
  WITHDRAW_NOT_YET_AVAILABLE,
  cardInventoryStateFor,
} from "./cardInventoryService";
import { findById } from "./playerService";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { itemInventoryStateFor, weaponDefinitionFor } from "./itemInventoryService";
import { visualInventoryStateFor } from "./visualInventoryService";

const MAX_CONCURRENCY_RETRIES = 4;
const MAX_CHANGE_ENTRIES = 128;
const MAX_CARD_AMOUNT = 10_000;

interface NormalPoolEntry {
  kind: "normal";
  amount: number;
}

interface BuddyPoolEntry {
  kind: "buddy";
  amount: 1;
  data: SavedBuddyCardState;
}

type PoolEntry = NormalPoolEntry | BuddyPoolEntry;

export interface DepositCardChanges {
  added: Record<string, PoolEntry>;
  removed: Record<string, PoolEntry>;
}

export interface DepositCardMutationResult {
  state: PlayerProgressionState;
  cardInventory: CardInventoryState;
  depositedCards: Record<string, string>;
}

interface BuddyWeaponAuthority {
  index: number;
  category: number;
}

/** Server-owned inputs used to reproduce CardBuddy.CreateDataForCurrentPlayer. */
export interface BuddyDepositAuthority {
  playerId: string;
  accountName: string;
  levelIndex: number;
  armyPower: number;
  equippedVisuals: SavedBuddyCardState["equippedVisuals"];
  weapons: [BuddyWeaponAuthority, BuddyWeaponAuthority, BuddyWeaponAuthority, BuddyWeaponAuthority];
  now: number;
}

export interface WithdrawCardMutationResult {
  recipientState: PlayerProgressionState;
  recipientInventory: CardInventoryState;
  donorDepositedCards: Record<string, string>;
  donorReputation: number;
  nextWithdraw: number;
  buddy: boolean;
}

export interface DepartingCardReclaimResult {
  state: PlayerProgressionState;
  cardInventory: CardInventoryState;
  returnedCardIds: string[];
}

export interface DepositCardResult extends DepositCardMutationResult {
  player: PlayerDocument;
}

export interface WithdrawCardResult extends WithdrawCardMutationResult {
  recipient: PlayerDocument;
  donor: PlayerDocument;
}

function requestObject(value: unknown, field: string): Record<string, unknown> {
  if (typeof value !== "string" || value.length < 2 || value.length > 64_000) {
    throw new ApiError(CARD_NOT_FOUND, `${field} is missing or too large.`);
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(CARD_NOT_FOUND, `${field} is invalid JSON.`);
  }
  if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) {
    throw new ApiError(CARD_NOT_FOUND, `${field} must be a card dictionary.`);
  }
  const entries = Object.entries(parsed as Record<string, unknown>);
  if (entries.length > MAX_CHANGE_ENTRIES) {
    throw new ApiError(CARD_NOT_FOUND, `${field} contains too many card entries.`);
  }
  return parsed as Record<string, unknown>;
}

function innerObject(value: unknown, field: string): Record<string, unknown> {
  if (typeof value !== "string" || value.length < 2 || value.length > 16_384) {
    throw new ApiError(CARD_NOT_FOUND, `${field} contains an invalid serialized card.`);
  }
  try {
    const parsed = JSON.parse(value) as unknown;
    if (parsed && typeof parsed === "object" && !Array.isArray(parsed)) {
      return parsed as Record<string, unknown>;
    }
  } catch {
    // The exact 17401 recovery path below will restore the authoritative dictionaries.
  }
  throw new ApiError(CARD_NOT_FOUND, `${field} contains invalid card JSON.`);
}

function safeInteger(value: unknown, field: string, minimum = 0, maximum = MAX_CARD_AMOUNT): number {
  const parsed = Number(value);
  if (!Number.isSafeInteger(parsed) || parsed < minimum || parsed > maximum) {
    throw new ApiError(CARD_NOT_FOUND, `${field} is outside the supported range.`);
  }
  return parsed;
}

function visualSlots(value: unknown): SavedBuddyCardState["equippedVisuals"] {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card visuals are invalid.");
  }
  const result: SavedBuddyCardState["equippedVisuals"] = {};
  for (const [slot, raw] of Object.entries(value as Record<string, unknown>)) {
    if (!/^\d+$/.test(slot) || !raw || typeof raw !== "object" || Array.isArray(raw)) {
      throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card visual slot is invalid.");
    }
    const equippedID = (raw as Record<string, unknown>).equippedID;
    if (typeof equippedID !== "string" || equippedID.length > 128) {
      throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card visual ID is invalid.");
    }
    result[slot] = { equippedID };
  }
  return result;
}

function decodePoolEntry(id: string, value: unknown, field: string): PoolEntry {
  if (id.length < 1 || id.length > 256) throw new ApiError(CARD_NOT_FOUND, `${field} has an invalid card ID.`);
  const data = innerObject(value, field);
  const amount = safeInteger(data.amount ?? 0, `${field}.${id}.amount`, 0);
  const buddyName = data.buddyName;
  if (typeof buddyName === "string" && buddyName.length > 0) {
    if (buddyName.length > 128 || amount > 1) {
      throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card identity or amount is invalid.");
    }
    return {
      kind: "buddy",
      amount: 1,
      data: {
        amount: 1,
        buddyName,
        equippedVisuals: visualSlots(data.equippedVisuals ?? {}),
        unityType: safeInteger(data.unityType, "BuddyCard.unityType", 0, 3),
        primaryWeapon: safeInteger(data.primaryWeapon, "BuddyCard.primaryWeapon", 0, 1_000),
        secondaryWeapon: Number(data.secondaryWeapon) === -1
          ? -1
          : safeInteger(data.secondaryWeapon, "BuddyCard.secondaryWeapon", 0, 1_000),
        armypower: safeInteger(data.armypower, "BuddyCard.armypower", 0, 100_000_000),
        level: safeInteger(data.level, "BuddyCard.level", 0, 1_000),
      },
    };
  }
  const definition = CARD_CATALOG[id];
  if (!definition?.implemented || amount < 1) {
    throw new ApiError(CARD_NOT_FOUND, `Card ${id} is unknown, disabled, or has no amount.`);
  }
  return { kind: "normal", amount };
}

function decodeDictionary(value: Record<string, unknown>, field: string): Record<string, PoolEntry> {
  return Object.fromEntries(Object.entries(value).map(([id, card]) => [id, decodePoolEntry(id, card, field)]));
}

/** Decode the client's JSON dictionary of JSON-serialized CardData/BuddyCardData values. */
export function parseDepositCardChanges(added: unknown, removed: unknown): DepositCardChanges {
  const addedCards = decodeDictionary(requestObject(added, "AddedCards"), "AddedCards");
  const removedCards = decodeDictionary(requestObject(removed, "RemovedCards"), "RemovedCards");
  for (const id of Object.keys(addedCards)) {
    if (removedCards[id]) throw new ApiError(CARD_NOT_FOUND, `Card ${id} cannot be added and removed together.`);
  }
  if (Object.keys(addedCards).length === 0 && Object.keys(removedCards).length === 0) {
    throw new ApiError(CARD_NOT_FOUND, "Deposit request contains no changes.");
  }
  return { added: addedCards, removed: removedCards };
}

function cloneDepositedCards(value: Record<string, string>): Record<string, string> {
  return Object.fromEntries(Object.entries(value ?? {}).map(([id, card]) => [id, card]));
}

function encodeNormal(amount: number): string {
  return JSON.stringify({ amount });
}

function encodeBuddy(data: SavedBuddyCardState): string {
  return JSON.stringify(data);
}

function sameVisualSlots(
  actual: SavedBuddyCardState["equippedVisuals"],
  expected: SavedBuddyCardState["equippedVisuals"],
): boolean {
  const actualKeys = Object.keys(actual).sort();
  const expectedKeys = Object.keys(expected).sort();
  return actualKeys.length === expectedKeys.length
    && actualKeys.every((key, index) =>
      key === expectedKeys[index] && actual[key]?.equippedID === expected[key]?.equippedID);
}

/**
 * Derive the four weapon rows and visual slots read by CardBuddy.CreateDataForCurrentPlayer.
 *
 * PlayerInventory slots are accepted only when their name, LevelManager index, and ownership all
 * agree with the recovered 4.9.5 catalog. This prevents a forged legacy inventory blob from being
 * converted into a Buddy whose weapon index points at an unrelated or assetless prefab.
 */
export function buddyDepositAuthorityFor(
  player: PlayerDocument,
  state: PlayerProgressionState,
  now: number,
): BuddyDepositAuthority {
  const itemInventory = itemInventoryStateFor(state);
  const weapons = ["0", "1", "2", "3"].map((slotId) => {
    const slot = itemInventory.inventoryData.slots[slotId];
    const definition = slot ? weaponDefinitionFor(slot.name) : undefined;
    const saved = slot ? itemInventory.levelManagerData.savedWeapons[slot.name] : undefined;
    if (!slot || !definition || definition.index !== slot.weaponIndex || !saved?.bought) {
      throw new ApiError(BUDDY_CARD_NOT_READY, `Buddy source weapon slot ${slotId} is invalid.`);
    }
    return { index: definition.index, category: definition.category };
  }) as BuddyDepositAuthority["weapons"];

  return {
    playerId: player.id,
    accountName: player.player.accountName,
    // DatabasePlayer.level is GameLevel.displayNumber; BuddyCardData.level stores GameLevel.index.
    levelIndex: Math.max(0, player.player.level - 1),
    armyPower: player.player.armyPower,
    equippedVisuals: visualInventoryStateFor(state).slots,
    weapons,
    now,
  };
}

function expectedBuddyWeapons(
  unityType: number,
  weapons: BuddyDepositAuthority["weapons"],
): { primaryWeapon: number; secondaryWeapon: number } {
  const [assault, alternate, explosive, sidearm] = weapons;
  switch (unityType) {
    case 0: // Defender always uses inventory slot 0.
      return { primaryWeapon: assault.index, secondaryWeapon: -1 };
    case 1: // Explosive uses a launcher directly, or slot 3 plus the slot-2 throwable.
      return explosive.category === 16 || explosive.category === 512
        ? { primaryWeapon: explosive.index, secondaryWeapon: -1 }
        : { primaryWeapon: sidearm.index, secondaryWeapon: explosive.index };
    case 2: // Shooter uses a sniper from slot 1 when one is equipped.
      return { primaryWeapon: alternate.category === 8 ? alternate.index : assault.index, secondaryWeapon: -1 };
    case 3: // Rusher uses a shotgun from slot 1 when one is equipped.
      return { primaryWeapon: alternate.category === 32 ? alternate.index : assault.index, secondaryWeapon: -1 };
    default:
      throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy unit type is invalid.");
  }
}

function validateNewBuddy(
  id: string,
  data: SavedBuddyCardState,
  authority: BuddyDepositAuthority,
): void {
  const timestampText = id.startsWith(authority.playerId) ? id.slice(authority.playerId.length) : "";
  const timestamp = Number(timestampText);
  if (!/^\d{9,11}$/.test(timestampText) || Math.abs(timestamp - authority.now) > 600) {
    throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card ID is not derived from the current player timestamp.");
  }
  const expectedWeapons = expectedBuddyWeapons(data.unityType, authority.weapons);
  if (
    data.amount !== 1
    || data.buddyName !== authority.accountName
    || data.primaryWeapon !== expectedWeapons.primaryWeapon
    || data.secondaryWeapon !== expectedWeapons.secondaryWeapon
    || data.armypower !== authority.armyPower
    || data.level !== authority.levelIndex
    || !sameVisualSlots(data.equippedVisuals, authority.equippedVisuals)
  ) {
    throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card does not match the authoritative player loadout.");
  }
}

function normalPoolCount(value: Record<string, string>): number {
  let total = 0;
  for (const [id, serialized] of Object.entries(value)) {
    const entry = decodePoolEntry(id, serialized, "DepositedCards");
    if (entry.kind === "normal") total += entry.amount;
  }
  return total;
}

/** Recovered Squads.CARDPOOLSIZE lookup with the same end-row clamp as GameVariables. */
export function squadCardPoolCapacity(squadLevel: number): number {
  const rows = CARD_POOL_RULES.capacityBySquadLevel;
  if (rows.length === 0) throw new ApiError(ApiErrorCode.InternalServerError, "Squad card-pool table is empty.");
  const index = Math.min(Math.max(Math.floor(squadLevel) - 1, 0), rows.length - 1);
  return rows[index]!;
}

/**
 * Apply one player's card-pool edit without trusting Unity's optimistic inventory changes.
 *
 * Removed normal cards return to the owner's collection; added normal cards leave it. A new Buddy
 * is accepted only when every CreateDataForCurrentPlayer field matches server-owned loadout state
 * and the recovered 480-minute deposit cooldown has elapsed.
 */
export function applyDepositCardChangesState(
  state: PlayerProgressionState,
  currentDepositedCards: Record<string, string>,
  changes: DepositCardChanges,
  capacity: number,
  buddyAuthority?: BuddyDepositAuthority,
): DepositCardMutationResult {
  const cardInventory = cardInventoryStateFor(state);
  const depositedCards = cloneDepositedCards(currentDepositedCards);

  for (const [id, requested] of Object.entries(changes.removed)) {
    const serialized = depositedCards[id];
    if (!serialized) throw new ApiError(CARD_NOT_FOUND, `Deposited card ${id} was not found.`);
    const current = decodePoolEntry(id, serialized, "DepositedCards");
    if (current.kind === "buddy") {
      if (requested.kind !== "buddy") throw new ApiError(CARD_NOT_FOUND, `Deposited Buddy card ${id} changed type.`);
      delete depositedCards[id];
      continue;
    }
    if (requested.kind !== "normal" || requested.amount > current.amount) {
      throw new ApiError(CARD_NOT_FOUND, `Deposited card ${id} has insufficient amount.`);
    }
    const remaining = current.amount - requested.amount;
    if (remaining === 0) delete depositedCards[id];
    else depositedCards[id] = encodeNormal(remaining);
    const owned = cardInventory.cardData[id]?.amount ?? 0;
    if (!Number.isSafeInteger(owned) || owned < 0 || owned > MAX_CARD_AMOUNT - requested.amount) {
      throw new ApiError(CARD_NOT_FOUND, `Owned card ${id} amount is invalid.`);
    }
    cardInventory.cardData[id] = { amount: owned + requested.amount };
  }

  for (const [id, requested] of Object.entries(changes.added)) {
    if (requested.kind === "buddy") {
      if (!buddyAuthority) {
        throw new ApiError(BUDDY_CARD_NOT_READY, "Authoritative Buddy card inputs are unavailable.");
      }
      if (cardInventory.nextBuddyDeposit > buddyAuthority.now) {
        throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card deposit is still on cooldown.");
      }
      if (Object.entries(depositedCards).some(([cardId, serialized]) =>
        cardId !== id && decodePoolEntry(cardId, serialized, "DepositedCards").kind === "buddy")) {
        throw new ApiError(BUDDY_CARD_NOT_READY, "A Buddy card is already deposited.");
      }
      if (depositedCards[id]) {
        throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card ID is already deposited.");
      }
      validateNewBuddy(id, requested.data, buddyAuthority);
      depositedCards[id] = encodeBuddy(requested.data);
      cardInventory.nextBuddyDeposit = buddyAuthority.now
        + CARD_POOL_RULES.buddyDepositCooldownMinutes * 60;
      continue;
    }
    const owned = cardInventory.cardData[id]?.amount ?? 0;
    if (!Number.isSafeInteger(owned) || owned < requested.amount) {
      throw new ApiError(CARD_NOT_FOUND, `Card ${id} is not available for deposit.`);
    }
    const existing = depositedCards[id]
      ? decodePoolEntry(id, depositedCards[id], "DepositedCards")
      : { kind: "normal" as const, amount: 0 };
    if (existing.kind !== "normal" || existing.amount > MAX_CARD_AMOUNT - requested.amount) {
      throw new ApiError(CARD_NOT_FOUND, `Deposited card ${id} amount is invalid.`);
    }
    depositedCards[id] = encodeNormal(existing.amount + requested.amount);
    const remaining = owned - requested.amount;
    if (remaining === 0) delete cardInventory.cardData[id];
    else cardInventory.cardData[id] = { amount: remaining };
  }

  if (normalPoolCount(depositedCards) > capacity) {
    throw new ApiError(CARD_NOT_FOUND, `Squad card pool exceeds its ${capacity}-card capacity.`);
  }
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    cardInventory,
  };
  return { state: next, cardInventory, depositedCards };
}

/**
 * Return every normal card still deposited by a player who is leaving their squad.
 *
 * OGLEHLIPEFM's LeaveSquad callback reads `DepositedCards` as a JSON list of card IDs and
 * calls CardManager.AddCard once per entry. Normal amounts are therefore expanded into repeated
 * IDs. Buddy pool entries are temporary loadout projections rather than owned normal cards;
 * AddCard cannot resolve their dynamic IDs, so they are deliberately cleared without creating
 * a permanent Buddy copy. The caller clears `player.depositedCardsDic` in the same transaction.
 */
export function reclaimDepositedCardsForDepartureState(
  state: PlayerProgressionState,
  depositedCards: Record<string, string>,
): DepartingCardReclaimResult {
  const cardInventory = cardInventoryStateFor(state);
  const returnedCardIds: string[] = [];
  for (const [id, serialized] of Object.entries(depositedCards ?? {})) {
    const entry = decodePoolEntry(id, serialized, "DepositedCards");
    if (entry.kind === "buddy") continue;
    const owned = cardInventory.cardData[id]?.amount ?? 0;
    if (!Number.isSafeInteger(owned) || owned < 0 || owned > MAX_CARD_AMOUNT - entry.amount) {
      throw new ApiError(CARD_NOT_FOUND, `Owned card ${id} amount is invalid during squad departure.`);
    }
    cardInventory.cardData[id] = { amount: owned + entry.amount };
    for (let index = 0; index < entry.amount; index += 1) returnedCardIds.push(id);
  }

  return {
    state: returnedCardIds.length > 0
      ? { ...state, revision: state.revision + 1, cardInventory }
      : state,
    cardInventory,
    returnedCardIds,
  };
}

function normalReputation(cardId: string): number {
  switch (CARD_CATALOG[cardId]?.rarity) {
    case 1: return CARD_POOL_RULES.reputationPoints.bronze;
    case 2: return CARD_POOL_RULES.reputationPoints.silver;
    case 3: return CARD_POOL_RULES.reputationPoints.gold;
    default: throw new ApiError(CARD_ALREADY_WITHDRAWN, `Deposited card ${cardId} is invalid.`);
  }
}

/** Move one available donor card into the recipient and start the 240-minute cooldown. */
export function withdrawSquadCardState(
  recipientState: PlayerProgressionState,
  donorDepositedCards: Record<string, string>,
  donorReputation: number,
  cardId: string,
  now: number,
): WithdrawCardMutationResult {
  const recipientInventory = cardInventoryStateFor(recipientState);
  if (recipientInventory.nextWithdraw > now) {
    throw new ApiError(WITHDRAW_NOT_YET_AVAILABLE, "Squad card withdrawal is still on cooldown.");
  }
  const serialized = donorDepositedCards[cardId];
  if (!serialized) throw new ApiError(CARD_ALREADY_WITHDRAWN, "Selected squad card was already withdrawn.");
  const entry = decodePoolEntry(cardId, serialized, "DepositedCards");
  const nextDonorCards = cloneDepositedCards(donorDepositedCards);
  let reputation: number;

  if (entry.kind === "buddy") {
    if (Object.keys(recipientInventory.buddyCardData).length >= CARD_POOL_RULES.maximumBuddyCards) {
      throw new ApiError(BUDDY_CARD_NOT_READY, "Maximum number of Buddy cards is already owned.");
    }
    if (recipientInventory.buddyCardData[cardId]) {
      throw new ApiError(BUDDY_CARD_NOT_READY, "Buddy card is already owned.");
    }
    recipientInventory.buddyCardData[cardId] = {
      ...entry.data,
      equippedVisuals: Object.fromEntries(
        Object.entries(entry.data.equippedVisuals).map(([slot, visual]) => [slot, { ...visual }]),
      ),
    };
    delete nextDonorCards[cardId];
    reputation = CARD_POOL_RULES.reputationPoints.buddy;
  } else {
    const owned = recipientInventory.cardData[cardId]?.amount ?? 0;
    if (!Number.isSafeInteger(owned) || owned < 0 || owned >= MAX_CARD_AMOUNT) {
      throw new ApiError(CARD_ALREADY_WITHDRAWN, `Owned card ${cardId} amount is invalid.`);
    }
    recipientInventory.cardData[cardId] = { amount: owned + 1 };
    if (entry.amount === 1) delete nextDonorCards[cardId];
    else nextDonorCards[cardId] = encodeNormal(entry.amount - 1);
    reputation = normalReputation(cardId);
  }

  if (!Number.isSafeInteger(donorReputation) || donorReputation < 0 || donorReputation > Number.MAX_SAFE_INTEGER - reputation) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Donor reputation is invalid.");
  }
  const nextWithdraw = now + CARD_POOL_RULES.withdrawCooldownMinutes * 60;
  recipientInventory.nextWithdraw = nextWithdraw;
  const nextRecipient: PlayerProgressionState = {
    ...recipientState,
    revision: recipientState.revision + 1,
    cardInventory: recipientInventory,
  };
  return {
    recipientState: nextRecipient,
    recipientInventory,
    donorDepositedCards: nextDonorCards,
    donorReputation: donorReputation + reputation,
    nextWithdraw,
    buddy: entry.kind === "buddy",
  };
}

function progressionRevisionFilter(player: PlayerDocument): Record<string, unknown> {
  if (!player.progression) return { progression: { $exists: false } };
  return player.progression.revision === undefined
    ? { "progression.revision": { $exists: false } }
    : { "progression.revision": player.progression.revision };
}

function canonicalProgression(state: PlayerProgressionState): PlayerProgressionState {
  const { dogTags: _legacyDogTags, ...canonical } = state;
  return canonical;
}

function requireSquadMembership(player: PlayerDocument, squad: { name: string; members: Array<{ playerId: string }> }): void {
  if (!player.player.squadName || player.player.squadName !== squad.name) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player does not belong to this squad.");
  }
  if (!squad.members.some((member) => member.playerId === player.id)) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player is missing from the squad roster.");
  }
}

/** Persist an owner's validated normal/Buddy pool edit in one revision-guarded document write. */
export async function depositSquadCards(
  playerId: string,
  added: unknown,
  removed: unknown,
): Promise<DepositCardResult> {
  const changes = parseDepositCardChanges(added, removed);
  for (let attempt = 0; attempt < MAX_CONCURRENCY_RETRIES; attempt += 1) {
    const player = await findById(playerId);
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    const squad = player.player.squadName
      ? await squads().findOne({ name: player.player.squadName })
      : null;
    if (!squad) throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not in a squad.");
    requireSquadMembership(player, squad);
    const result = applyDepositCardChangesState(
      progressionForPlayer(player),
      player.player.depositedCardsDic ?? {},
      changes,
      squadCardPoolCapacity(squad.level),
      buddyDepositAuthorityFor(player, progressionForPlayer(player), unixNow()),
    );
    const canonical = canonicalProgression(result.state);
    const update = await players().updateOne(
      {
        id: player.id,
        "player.squadName": squad.name,
        ...progressionRevisionFilter(player),
      },
      {
        $set: {
          progression: canonical,
          "player.depositedCardsDic": result.depositedCards,
          updatedAt: new Date(),
        },
      },
    );
    if (update.modifiedCount === 1) {
      return {
        ...result,
        state: canonical,
        player: {
          ...player,
          progression: canonical,
          player: { ...player.player, depositedCardsDic: result.depositedCards },
        },
      };
    }
  }
  throw new ApiError(ApiErrorCode.InternalServerError, "Concurrent card-pool update could not be completed.");
}

/**
 * Transfer a squad card between two players with no duplication/loss window.
 *
 * Both players and the authoritative squad roster are read in one snapshot. The donor pool,
 * donor reputation, recipient inventory, and recipient cooldown then commit together. MongoDB
 * aborts the complete transaction if either revision changed or any write fails.
 */
export async function withdrawSquadCard(
  recipientId: string,
  donorId: string,
  cardId: string,
): Promise<WithdrawCardResult> {
  if (!donorId || donorId === recipientId || !cardId || cardId.length > 256) {
    throw new ApiError(CARD_ALREADY_WITHDRAWN, "Squad card withdrawal target is invalid.");
  }
  return withMongoTransaction(async (session) => {
    const [recipient, donor] = await Promise.all([
      players().findOne({ id: recipientId }, { session }),
      players().findOne({ id: donorId }, { session }),
    ]);
    if (!recipient) throw new ApiError(ApiErrorCode.PlayerNotFound, "Recipient was not found.");
    if (!donor) throw new ApiError(CARD_ALREADY_WITHDRAWN, "Card donor was not found.");
    if (!recipient.player.squadName || recipient.player.squadName !== donor.player.squadName) {
      throw new ApiError(ApiErrorCode.NotSquadMember, "Players do not belong to the same squad.");
    }
    const squad = await squads().findOne({ name: recipient.player.squadName }, { session });
    if (!squad) throw new ApiError(ApiErrorCode.NotSquadMember, "Squad was not found.");
    requireSquadMembership(recipient, squad);
    requireSquadMembership(donor, squad);

    const result = withdrawSquadCardState(
      progressionForPlayer(recipient),
      donor.player.depositedCardsDic ?? {},
      donor.player.reputation,
      cardId,
      unixNow(),
    );
    const canonicalRecipient = canonicalProgression(result.recipientState);
    const now = new Date();
    const recipientUpdate = await players().updateOne(
      { id: recipient.id, ...progressionRevisionFilter(recipient) },
      { $set: { progression: canonicalRecipient, updatedAt: now } },
      { session },
    );
    const donorUpdate = await players().updateOne(
      { id: donor.id, "player.squadName": squad.name },
      {
        $set: {
          "player.depositedCardsDic": result.donorDepositedCards,
          "player.reputation": result.donorReputation,
          updatedAt: now,
        },
      },
      { session },
    );
    if (recipientUpdate.modifiedCount !== 1 || donorUpdate.modifiedCount !== 1) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Concurrent squad-card transfer was rejected.");
    }
    return {
      ...result,
      recipientState: canonicalRecipient,
      recipient: {
        ...recipient,
        progression: canonicalRecipient,
      },
      donor: {
        ...donor,
        player: {
          ...donor.player,
          reputation: result.donorReputation,
          depositedCardsDic: result.donorDepositedCards,
        },
      },
    };
  });
}
