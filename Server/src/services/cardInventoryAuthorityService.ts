import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  CardInventoryState,
  SavedBuddyCardState,
  SavedCardState,
  SavedVisualSlotState,
} from "../db";
import { VALIDATED_CARD_CATALOG } from "./cardCatalogAuthorityService";
import { VALIDATED_WEAPON_CATALOG } from "./weaponCatalogAuthorityService";

const MAX_CLIENT_INTEGER = 2_147_483_647;
const CONTROL_CHARACTERS = /[\u0000-\u001f\u007f]/;
const cardArtifact = VALIDATED_CARD_CATALOG;
const weaponArtifact = VALIDATED_WEAPON_CATALOG;
const implementedCardIds = new Set(cardArtifact.cards.filter((card) => card.implemented).map((card) => card.name));
const weaponIndexes = new Set(weaponArtifact.catalog.map((weapon) => weapon.index));

function authorityError(message = "Stored War Card inventory is invalid."): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function exactKeys(value: object, expected: readonly string[]): boolean {
  const keys = Object.keys(value).sort();
  return keys.length === expected.length && keys.every((key, index) => key === expected[index]);
}

function boundedText(value: unknown, maximum: number, allowEmpty: boolean): string {
  if (
    typeof value !== "string"
    || (!allowEmpty && value.length === 0)
    || value.length > maximum
    || CONTROL_CHARACTERS.test(value)
  ) {
    return authorityError();
  }
  return value;
}

function clientInteger(value: unknown, minimum = 0): number {
  if (!Number.isSafeInteger(value) || (value as number) < minimum || (value as number) > MAX_CLIENT_INTEGER) {
    return authorityError();
  }
  return value as number;
}

/** Validate server time used by the two CardManager cooldown cursors. */
export function validatedCardInventoryTime(value: number): number {
  return clientInteger(value);
}

function normalCards(value: unknown): Record<string, SavedCardState> {
  if (!value || typeof value !== "object" || Array.isArray(value)) return authorityError();
  const entries = Object.entries(value as Record<string, unknown>);
  if (entries.length > implementedCardIds.size) return authorityError();
  return Object.fromEntries(entries.map(([id, raw]) => {
    if (!implementedCardIds.has(id) || !raw || typeof raw !== "object" || Array.isArray(raw)) {
      return authorityError();
    }
    if (!exactKeys(raw, ["amount"])) return authorityError();
    return [id, { amount: clientInteger((raw as { amount?: unknown }).amount, 1) }];
  }));
}

function buddyVisuals(value: unknown): Record<string, SavedVisualSlotState> {
  if (!value || typeof value !== "object" || Array.isArray(value)) return authorityError();
  const entries = Object.entries(value as Record<string, unknown>);
  // Current CreateDataForCurrentPlayer writes categories 0-3. Older Buddy snapshots can be
  // sparse, so require known slot numbers without inventing missing legacy cosmetics.
  if (entries.length > 4) return authorityError();
  return Object.fromEntries(entries.map(([slot, raw]) => {
    if (!/^[0-3]$/.test(slot) || !raw || typeof raw !== "object" || Array.isArray(raw)) {
      return authorityError();
    }
    if (!exactKeys(raw, ["equippedID"])) return authorityError();
    return [slot, { equippedID: boundedText((raw as { equippedID?: unknown }).equippedID, 128, true) }];
  }));
}

function weaponIndex(value: unknown, secondary = false): number {
  if (secondary && value === -1) return -1;
  const index = clientInteger(value);
  if (!weaponIndexes.has(index)) return authorityError();
  return index;
}

function buddyCards(value: unknown): Record<string, SavedBuddyCardState> {
  if (!value || typeof value !== "object" || Array.isArray(value)) return authorityError();
  const entries = Object.entries(value as Record<string, unknown>);
  if (entries.length > cardArtifact.cardPoolRules.maximumBuddyCards) return authorityError();
  return Object.fromEntries(entries.map(([id, raw]) => {
    boundedText(id, 256, false);
    if (!raw || typeof raw !== "object" || Array.isArray(raw)) return authorityError();
    if (!exactKeys(raw, [
      "amount",
      "armypower",
      "buddyName",
      "equippedVisuals",
      "level",
      "primaryWeapon",
      "secondaryWeapon",
      "unityType",
    ])) return authorityError();
    const buddy = raw as Partial<SavedBuddyCardState>;
    if (buddy.amount !== 1) return authorityError();
    const unityType = clientInteger(buddy.unityType, 0);
    if (unityType > 3) return authorityError();
    return [id, {
      amount: 1,
      buddyName: boundedText(buddy.buddyName, 128, false),
      equippedVisuals: buddyVisuals(buddy.equippedVisuals),
      unityType,
      primaryWeapon: weaponIndex(buddy.primaryWeapon),
      secondaryWeapon: weaponIndex(buddy.secondaryWeapon, true),
      armypower: clientInteger(buddy.armypower),
      level: clientInteger(buddy.level),
    }];
  }));
}

/**
 * Validate the complete CardManagerData snapshot before it can drive gameplay or reach Unity.
 *
 * A zero/negative normal amount changes whether CardManager considers a card owned, malformed
 * cooldowns can permanently lock or reopen squad actions, and a truthy non-Boolean extra slot can
 * bypass the paid entitlement. Validate and clone the whole bounded object so unrelated progression
 * writes cannot preserve malformed inventory authority by never touching the damaged entry.
 */
export function validatedCardInventoryState(value: unknown): CardInventoryState {
  if (!value || typeof value !== "object" || Array.isArray(value)) return authorityError();
  if (!exactKeys(value, ["buddyCardData", "cardData", "extraSlot", "nextBuddyDeposit", "nextWithdraw"])) {
    return authorityError();
  }
  const candidate = value as Partial<CardInventoryState>;
  if (typeof candidate.extraSlot !== "boolean") return authorityError();
  return {
    cardData: normalCards(candidate.cardData),
    buddyCardData: buddyCards(candidate.buddyCardData),
    nextWithdraw: clientInteger(candidate.nextWithdraw),
    nextBuddyDeposit: clientInteger(candidate.nextBuddyDeposit),
    extraSlot: candidate.extraSlot,
  };
}

/** Missing CardManagerData is the supported legacy fallback; present malformed data fails closed. */
export function cardInventoryAuthorityFor(value: unknown): CardInventoryState {
  return value === undefined
    ? { cardData: {}, buddyCardData: {}, nextWithdraw: 0, nextBuddyDeposit: 0, extraSlot: false }
    : validatedCardInventoryState(value);
}
