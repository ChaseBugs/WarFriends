import { SquadRank } from "../constants";
import { CARD_CATALOG, CARD_POOL_RULES } from "./cardInventoryService";
import { PLAYER_LEVELS } from "./levelProgressionService";
import type { MessageDoc } from "./socialService";

const STANDARD_MESSAGE_TYPES = new Set([3, 21, 27, 28]);
const MESSAGE_KEYS = new Set([
  "_id", "messageId", "toPlayerId", "fromPlayerId", "fromName", "body", "messageType",
  "payload", "otherPlayerJson", "read", "ignored", "accepted", "acceptedAt", "createdAt",
  "idempotencyKey", "rewardClaimed", "claimResponse", "expiresAt",
]);
const KICK_KEYS = new Set([
  "PlayerName", "Level", "SquadId", "KickedPlayerId", "SquadKickedFrom",
  "AdminName", "AdminId", "AdminLevel", "KickedPlayerDepositedCards",
]);
const DEPOSIT_KEYS = new Set(["PlayerName", "Level", "SquadId", "SquadRank", "AdminPlayerId"]);
const UUID_PATTERN = "[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}";
const MAX_RETURNED_CARDS = Math.max(...CARD_POOL_RULES.capacityBySquadLevel);

function invalid(): never {
  throw new Error("Stored standard inbox message is invalid.");
}

function knownKeys(value: object, allowed: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => allowed.has(key));
}

function exactKeys(value: object, allowed: ReadonlySet<string>): boolean {
  return Object.keys(value).length === allowed.size && knownKeys(value, allowed);
}

function boundedText(value: unknown, maximum: number, allowEmpty = false): value is string {
  return typeof value === "string"
    && value.length <= maximum
    && (allowEmpty || value.length > 0)
    && value.trim() === value
    && !/\p{Cc}/u.test(value);
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() > 0;
}

function level(value: unknown): value is number {
  return Number.isSafeInteger(value) && (value as number) >= 0 && (value as number) < PLAYER_LEVELS.length;
}

function unixSeconds(message: MessageDoc): number {
  return Math.floor(message.createdAt.getTime() / 1_000);
}

function validReturnedCards(value: unknown): boolean {
  if (typeof value !== "string" || value.length < 2 || value.length > 262_144) return false;
  try {
    const cards = JSON.parse(value) as unknown;
    return Array.isArray(cards)
      && cards.length <= MAX_RETURNED_CARDS
      && cards.every((cardId) => typeof cardId === "string" && CARD_CATALOG[cardId]?.implemented === true);
  } catch {
    return false;
  }
}

function validateKick(message: MessageDoc): void {
  const payload = message.payload;
  if (!exactKeys(payload, KICK_KEYS)
    || message.messageId !== `SquadDemotion-${message.toPlayerId}-${unixSeconds(message)}`
    || message.body !== "You were removed from your squad."
    || message.idempotencyKey !== undefined
    || !boundedText(payload.PlayerName, 64)
    || !level(payload.Level)
    || !boundedText(payload.SquadId, 24)
    || payload.SquadKickedFrom !== payload.SquadId
    || payload.KickedPlayerId !== message.toPlayerId
    || payload.AdminName !== message.fromName
    || payload.AdminId !== message.fromPlayerId
    || !level(payload.AdminLevel)
    || !validReturnedCards(payload.KickedPlayerDepositedCards)) invalid();
}

function validateSquadEvent(message: MessageDoc): void {
  const dayKey = message.createdAt.toISOString().slice(0, 10);
  const keySuffix = `:${message.fromPlayerId}:${dayKey}`;
  if (Object.keys(message.payload).length !== 0
    || message.messageId !== `InformSquadLeader-${message.fromPlayerId}-${unixSeconds(message)}`
    || message.body !== "A squad event is available."
    || (message.idempotencyKey !== undefined
      && (!boundedText(message.idempotencyKey, 512)
        || !message.idempotencyKey.startsWith("squad-event:")
        || !message.idempotencyKey.endsWith(keySuffix)
        || message.idempotencyKey.slice("squad-event:".length, -keySuffix.length).length < 1
        || message.idempotencyKey.slice("squad-event:".length, -keySuffix.length).length > 24))) invalid();
}

function validateDirectMessage(message: MessageDoc): void {
  const expected = new RegExp(`^InGameMessage-${UUID_PATTERN}-${unixSeconds(message)}$`, "u");
  if (Object.keys(message.payload).length !== 0
    || !expected.test(message.messageId)
    || !boundedText(message.body, 500)
    || message.idempotencyKey !== undefined) invalid();
}

function validateDepositReminder(message: MessageDoc): void {
  const payload = message.payload;
  const dayKey = message.createdAt.toISOString().slice(0, 10);
  const expectedKey = `deposit-warcards:${payload.SquadId}:${message.fromPlayerId}:${message.toPlayerId}:${dayKey}`;
  if (!exactKeys(payload, DEPOSIT_KEYS)
    || message.messageId !== `DepositWarcards-${message.fromName}-${unixSeconds(message)}`
    || message.body !== "Please deposit War Cards into the squad card pool."
    || !boundedText(payload.PlayerName, 64)
    || payload.PlayerName !== message.fromName
    || !level(payload.Level)
    || !boundedText(payload.SquadId, 24)
    || !Number.isSafeInteger(payload.SquadRank)
    || ![SquadRank.Member, SquadRank.Veteran, SquadRank.Leader, SquadRank.Coleader].includes(payload.SquadRank as SquadRank)
    || payload.AdminPlayerId !== message.fromPlayerId
    // Missing idempotency keys are the documented legacy migration. When present, every
    // authority component must reproduce the producer's actor/target/squad/UTC-day identity.
    || (message.idempotencyKey !== undefined && message.idempotencyKey !== expectedKey)) invalid();
}

/**
 * Validate the complete non-rewarding inbox rows emitted by this backend.
 *
 * The stock base constructor parses the final dash-separated MessageId segment with
 * Convert.ToInt32, so every supported ID ends in its bounded Unix-second creation time. This is
 * presentation state, but malformed rows still fail closed: a broken kick can replay returned
 * cards in the client, and a broken sender snapshot can redirect squad UI to the wrong player.
 */
export function validatedStandardInboxMessage(message: MessageDoc, now?: Date): MessageDoc | null {
  if (!message || typeof message !== "object" || !STANDARD_MESSAGE_TYPES.has(message.messageType)) return null;
  if (!knownKeys(message, MESSAGE_KEYS)
    || !boundedText(message.messageId, 256)
    || !boundedText(message.toPlayerId, 160)
    || !boundedText(message.fromPlayerId, 160)
    || message.toPlayerId === message.fromPlayerId
    || !boundedText(message.fromName, 64)
    || !message.payload || typeof message.payload !== "object" || Array.isArray(message.payload)
    || message.otherPlayerJson !== ""
    || typeof message.read !== "boolean"
    || typeof message.ignored !== "boolean"
    || (message.ignored && !message.read)
    || message.accepted !== false
    || message.acceptedAt !== undefined
    || message.rewardClaimed !== undefined
    || message.claimResponse !== undefined
    || message.expiresAt !== undefined
    || !safeDate(message.createdAt)
    || unixSeconds(message) <= 0
    || unixSeconds(message) > 2_147_483_647
    || (now !== undefined && (!safeDate(now) || message.createdAt.getTime() > now.getTime()))) invalid();

  if (message.messageType === 3) validateKick(message);
  else if (message.messageType === 21) validateSquadEvent(message);
  else if (message.messageType === 27) validateDirectMessage(message);
  else validateDepositReminder(message);
  return message;
}
