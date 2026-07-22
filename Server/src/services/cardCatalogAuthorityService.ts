import { ApiError, ApiErrorCode } from "../apiErrors";
import generatedCardCatalog from "../data/cardCatalog.generated.json";
import {
  EXPECTED_SQUAD_LEVEL_COUNT,
  type SquadLevelDefinition,
  validatedSquadProgressionCatalog,
} from "./squadProgressionService";

export interface CardDefinition {
  name: string;
  rarity: number;
  fromMission: number;
  implemented: boolean;
}

export interface UnresolvedCardDefinition extends CardDefinition {
  reason: string;
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

export interface ValidatedCardCatalogArtifact {
  schemaVersion: number;
  clientVersion: string;
  source: string;
  sourceSha256: string;
  unlockLevel: number;
  rarityProbabilities: Readonly<Record<"lowLevel" | "highLevel" | "silverEarly" | "silver" | "goldEarly" | "gold", number>>;
  craftingRules: Readonly<{
    inputCount: number;
    bronzeToSilverMinutes: number;
    silverToGoldMinutes: number;
  }>;
  cardPoolRules: Readonly<{
    withdrawCooldownMinutes: number;
    buddyDepositCooldownMinutes: number;
    maximumBuddyCards: number;
    reputationPoints: Readonly<Record<"bronze" | "silver" | "gold" | "buddy", number>>;
    capacityBySquadLevel: readonly number[];
  }>;
  squadLevelDefinitions: readonly Readonly<SquadLevelDefinition>[];
  cards: readonly Readonly<CardDefinition>[];
  unresolvedRows: readonly Readonly<UnresolvedCardDefinition>[];
  packs: readonly Readonly<CardPackDefinition>[];
}

const ROOT_KEYS = new Set([
  "schemaVersion", "clientVersion", "source", "sourceSha256", "unlockLevel",
  "rarityProbabilities", "craftingRules", "cardPoolRules", "squadLevelDefinitions",
  "cards", "unresolvedRows", "packs",
]);
const CARD_KEYS = new Set(["name", "rarity", "fromMission", "implemented"]);
const UNRESOLVED_CARD_KEYS = new Set([...CARD_KEYS, "reason"]);
const PACK_KEYS = new Set([
  "name", "priceGold", "priceWarBucks", "enumValue", "cardCount", "fixedRarity",
  "fixedRarityCount", "guaranteedRarity", "maxRarity",
]);
const EXPECTED_PACK_IDENTITY = new Map<string, Readonly<{ enumValue: number; cardCount: number }>>([
  ["BRONZE_CARDPACK", { enumValue: 1, cardCount: 10 }],
  ["SILVER_CARDPACK", { enumValue: 2, cardCount: 10 }],
  ["GOLD_CARDPACK", { enumValue: 3, cardCount: 10 }],
  ["THREE_CARDS", { enumValue: 6, cardCount: 3 }],
]);
const EXPECTED_PLAYABLE_CARDS = 58;
const EXPECTED_UNRESOLVED_CARDS = 25;
const CARD_NAME = /^[A-Z][A-Z0-9_]{0,127}$/;
const SHA256 = /^[0-9a-f]{64}$/;

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function record(value: unknown, keys: ReadonlySet<string>, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    return invalid(`${label} is invalid.`);
  }
  const result = value as Record<string, unknown>;
  if (Object.keys(result).length !== keys.size || Object.keys(result).some((key) => !keys.has(key))) {
    return invalid(`${label} has an invalid field set.`);
  }
  return result;
}

function safeInteger(value: unknown, label: string, minimum = 0, maximum = 2_147_483_647): number {
  if (!Number.isSafeInteger(value) || (value as number) < minimum || (value as number) > maximum) {
    return invalid(`${label} is invalid.`);
  }
  return value as number;
}

function validateCardRows(
  value: unknown,
  implemented: boolean,
  count: number,
  names: Set<string>,
): readonly Readonly<CardDefinition | UnresolvedCardDefinition>[] {
  if (!Array.isArray(value) || value.length !== count) {
    return invalid(`Card catalog must contain exactly ${count} ${implemented ? "playable" : "unresolved"} rows.`);
  }
  let previous: CardDefinition | undefined;
  return Object.freeze(value.map((candidate, index) => {
    const row = record(candidate, implemented ? CARD_KEYS : UNRESOLVED_CARD_KEYS, `Card row ${index}`);
    if (typeof row.name !== "string" || !CARD_NAME.test(row.name) || names.has(row.name)) {
      return invalid(`Card row ${index} has an invalid or duplicate name.`);
    }
    const rarity = safeInteger(row.rarity, `Card ${row.name} rarity`, implemented ? 1 : -1);
    const fromMission = safeInteger(row.fromMission, `Card ${row.name} mission gate`, -1, 99);
    if (rarity > 3 || row.implemented !== implemented
      || (!implemented && row.reason !== "No matching serialized Card component in MainScene.")) {
      return invalid(`Card ${row.name} has invalid recovered availability data.`);
    }
    const next: CardDefinition | UnresolvedCardDefinition = implemented
      ? { name: row.name, rarity, fromMission, implemented: true }
      : {
        name: row.name,
        rarity,
        fromMission,
        implemented: false,
        reason: row.reason as string,
      };
    // Extract-CardCatalog emits a deterministic rarity/name order. Enforcing that order catches
    // duplicate or partially replaced rows before Object.fromEntries can silently overwrite one.
    if (previous && (previous.rarity > rarity
      || (previous.rarity === rarity && previous.name.localeCompare(next.name) >= 0))) {
      return invalid(`Card row ${index} is not in recovered deterministic order.`);
    }
    previous = next;
    names.add(next.name);
    return Object.freeze(next);
  }));
}

function validatePacks(value: unknown, cards: readonly Readonly<CardDefinition>[]): readonly Readonly<CardPackDefinition>[] {
  if (!Array.isArray(value) || value.length !== EXPECTED_PACK_IDENTITY.size) {
    return invalid(`Card catalog must contain exactly ${EXPECTED_PACK_IDENTITY.size} packs.`);
  }
  const names = new Set<string>();
  const enumValues = new Set<number>();
  const packs = value.map((candidate, index) => {
    const row = record(candidate, PACK_KEYS, `Card pack row ${index}`);
    const name = row.name;
    const expected = typeof name === "string" ? EXPECTED_PACK_IDENTITY.get(name) : undefined;
    if (typeof name !== "string" || !expected
      || expected.enumValue !== row.enumValue || expected.cardCount !== row.cardCount
      || names.has(name) || enumValues.has(row.enumValue as number)) {
      return invalid(`Card pack row ${index} has an invalid identity.`);
    }
    const pack: CardPackDefinition = {
      name,
      priceGold: safeInteger(row.priceGold, `${name} Gold price`),
      priceWarBucks: safeInteger(row.priceWarBucks, `${name} WarBucks price`),
      enumValue: safeInteger(row.enumValue, `${name} enum`, 1),
      cardCount: safeInteger(row.cardCount, `${name} card count`, 1),
      fixedRarity: safeInteger(row.fixedRarity, `${name} fixed rarity`),
      fixedRarityCount: safeInteger(row.fixedRarityCount, `${name} fixed count`),
      guaranteedRarity: safeInteger(row.guaranteedRarity, `${name} guaranteed rarity`, 1),
      maxRarity: safeInteger(row.maxRarity, `${name} maximum rarity`, 1),
    };
    if ((pack.priceGold > 0) === (pack.priceWarBucks > 0)
      || pack.fixedRarity > 3
      || pack.fixedRarityCount > pack.cardCount
      || pack.guaranteedRarity > pack.maxRarity
      || pack.maxRarity > 3
      || (pack.fixedRarityCount === 0) !== (pack.fixedRarity === 0)
      || (pack.fixedRarityCount > 0 && !cards.some((card) => card.rarity === pack.fixedRarity))
      || !cards.some((card) => card.rarity >= pack.guaranteedRarity && card.rarity <= pack.maxRarity)) {
      return invalid(`Card pack ${pack.name} has invalid price or rarity authority.`);
    }
    names.add(pack.name);
    enumValues.add(pack.enumValue);
    return Object.freeze(pack);
  });
  return Object.freeze(packs);
}

/**
 * Validate and deep-freeze every card-economy value read from the generated MainScene artifact.
 *
 * The extractor remains the provenance check. This runtime boundary prevents a truncated,
 * malformed, duplicated, or later-mutated JSON snapshot from changing prices, reward pools,
 * crafting timers, card availability, or Squad pool limits after process startup.
 */
export function validatedCardCatalogArtifact(value: unknown): Readonly<ValidatedCardCatalogArtifact> {
  const root = record(value, ROOT_KEYS, "Card catalog root");
  if (root.schemaVersion !== 4 || root.clientVersion !== "4.9.5"
    || root.source !== "Client/ExportedProject/Assets/Scenes/MainScene.unity"
    || typeof root.sourceSha256 !== "string" || !SHA256.test(root.sourceSha256)) {
    return invalid("Card catalog provenance is invalid.");
  }

  const squadLevelDefinitions = Object.freeze(
    validatedSquadProgressionCatalog(root).map((row) => Object.freeze({ ...row })),
  );
  if (squadLevelDefinitions.length !== EXPECTED_SQUAD_LEVEL_COUNT) {
    return invalid("Card catalog Squad progression is incomplete.");
  }

  const names = new Set<string>();
  const cards = validateCardRows(root.cards, true, EXPECTED_PLAYABLE_CARDS, names) as readonly Readonly<CardDefinition>[];
  const unresolvedRows = validateCardRows(
    root.unresolvedRows,
    false,
    EXPECTED_UNRESOLVED_CARDS,
    names,
  ) as readonly Readonly<UnresolvedCardDefinition>[];
  const packs = validatePacks(root.packs, cards);

  const rarity = record(root.rarityProbabilities,
    new Set(["lowLevel", "highLevel", "silverEarly", "silver", "goldEarly", "gold"]),
    "Card rarity rules");
  const lowLevel = safeInteger(rarity.lowLevel, "Card low-level boundary");
  const highLevel = safeInteger(rarity.highLevel, "Card high-level boundary");
  const silverEarly = rarity.silverEarly;
  const silver = rarity.silver;
  const goldEarly = rarity.goldEarly;
  const gold = rarity.gold;
  if (lowLevel >= highLevel || ![silverEarly, silver, goldEarly, gold].every(
    (entry) => typeof entry === "number" && Number.isFinite(entry) && entry >= 0 && entry <= 1,
  ) || (silverEarly as number) > (goldEarly as number) || (silver as number) > (gold as number)) {
    return invalid("Card rarity rules are invalid.");
  }

  const crafting = record(root.craftingRules,
    new Set(["inputCount", "bronzeToSilverMinutes", "silverToGoldMinutes"]),
    "Card crafting rules");
  const inputCount = safeInteger(crafting.inputCount, "Card crafting input count", 1);
  const bronzeToSilverMinutes = safeInteger(crafting.bronzeToSilverMinutes, "Bronze crafting duration", 1);
  const silverToGoldMinutes = safeInteger(crafting.silverToGoldMinutes, "Silver crafting duration", 1);
  if (inputCount !== 3 || bronzeToSilverMinutes > silverToGoldMinutes) {
    return invalid("Card crafting rules contradict the recovered recipe.");
  }

  const pool = record(root.cardPoolRules,
    new Set(["withdrawCooldownMinutes", "buddyDepositCooldownMinutes", "maximumBuddyCards", "reputationPoints", "capacityBySquadLevel"]),
    "Card pool rules");
  const reputation = record(pool.reputationPoints,
    new Set(["bronze", "silver", "gold", "buddy"]),
    "Card pool reputation rules");
  const capacityBySquadLevel = Object.freeze([...(pool.capacityBySquadLevel as number[])]);

  return Object.freeze({
    schemaVersion: 4,
    clientVersion: "4.9.5",
    source: root.source as string,
    sourceSha256: root.sourceSha256 as string,
    unlockLevel: safeInteger(root.unlockLevel, "War Card unlock level", 1, 58),
    rarityProbabilities: Object.freeze({
      lowLevel,
      highLevel,
      silverEarly: silverEarly as number,
      silver: silver as number,
      goldEarly: goldEarly as number,
      gold: gold as number,
    }),
    craftingRules: Object.freeze({ inputCount, bronzeToSilverMinutes, silverToGoldMinutes }),
    cardPoolRules: Object.freeze({
      withdrawCooldownMinutes: safeInteger(pool.withdrawCooldownMinutes, "Card withdrawal cooldown", 1),
      buddyDepositCooldownMinutes: safeInteger(pool.buddyDepositCooldownMinutes, "Buddy deposit cooldown", 1),
      maximumBuddyCards: safeInteger(pool.maximumBuddyCards, "Maximum Buddy cards", 1),
      reputationPoints: Object.freeze({
        bronze: safeInteger(reputation.bronze, "Bronze card reputation"),
        silver: safeInteger(reputation.silver, "Silver card reputation"),
        gold: safeInteger(reputation.gold, "Gold card reputation"),
        buddy: safeInteger(reputation.buddy, "Buddy card reputation"),
      }),
      capacityBySquadLevel,
    }),
    squadLevelDefinitions,
    cards,
    unresolvedRows,
    packs,
  });
}

export const VALIDATED_CARD_CATALOG = validatedCardCatalogArtifact(generatedCardCatalog);
