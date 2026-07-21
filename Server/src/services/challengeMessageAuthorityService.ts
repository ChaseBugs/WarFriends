import type { MessageDoc } from "./socialService";

export const MIN_CHALLENGE_TTL_MS = 60_000;
export const MAX_CHALLENGE_TTL_MS = 7 * 24 * 60 * 60 * 1_000;

const MESSAGE_KEYS = new Set([
  "_id", "messageId", "toPlayerId", "fromPlayerId", "fromName", "body", "messageType",
  "payload", "otherPlayerJson", "read", "ignored", "accepted", "acceptedAt", "createdAt",
  "idempotencyKey", "rewardClaimed", "claimResponse", "expiresAt",
]);
const PAYLOAD_KEYS = new Set([
  "MapName", "GameType", "Region", "roomName", "clientVersion", "MissionType",
  "NumberOfMission", "MissionData",
]);
const GAME_TYPES = new Set([2, 4, 8, 16, 32]);
const REGIONS = new Set([0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

function invalid(): never {
  throw new Error("Stored challenge message is invalid.");
}

function exactKeys(value: object, allowed: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => allowed.has(key));
}

function boundedText(value: unknown, maximum: number, allowEmpty = false): value is string {
  return typeof value === "string"
    && value.length <= maximum
    && (allowEmpty || value.length > 0)
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
}

function safeInteger(value: unknown, minimum: number, maximum: number): value is number {
  return typeof value === "number" && Number.isSafeInteger(value) && value >= minimum && value <= maximum;
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() > 0;
}

function creationUnixSeconds(message: MessageDoc): number {
  return Math.floor(message.createdAt.getTime() / 1_000);
}

function jsonObject(value: string): boolean {
  if (value.length === 0 || value.length > 262_144) return false;
  try {
    const parsed = JSON.parse(value) as unknown;
    return Boolean(parsed) && typeof parsed === "object" && !Array.isArray(parsed);
  } catch {
    return false;
  }
}

/**
 * Validate the complete recovered type-0 challenge before publication, acceptance, or replay.
 * The TTL interval is bounded rather than tied to today's deployment setting because old rows do
 * not carry a configuration version; changing `CHALLENGE_TTL_SECONDS` must not retroactively turn
 * an otherwise valid invitation into corrupt authority.
 */
export function validatedChallengeMessage(message: MessageDoc, now?: Date): MessageDoc | null {
  if (!message || typeof message !== "object" || message.messageType !== 0) return null;
  const payload = message.payload;
  if (!exactKeys(message, MESSAGE_KEYS)
    || !boundedText(message.toPlayerId, 160)
    || !boundedText(message.fromPlayerId, 160)
    || message.toPlayerId === message.fromPlayerId
    || !boundedText(message.fromName, 256)
    || message.body !== ""
    || !payload || typeof payload !== "object" || Array.isArray(payload)
    || !exactKeys(payload, PAYLOAD_KEYS)
    || !boundedText(payload.MapName, 160)
    || !safeInteger(payload.GameType, 0, 64) || !GAME_TYPES.has(payload.GameType)
    || !safeInteger(payload.Region, 0, 10) || !REGIONS.has(payload.Region)
    || !boundedText(payload.roomName, 256)
    || !boundedText(payload.clientVersion, 64)
    || (payload.MissionType !== undefined && !boundedText(payload.MissionType, 64))
    || (payload.NumberOfMission !== undefined && !safeInteger(payload.NumberOfMission, 0, 1_000_000))
    || (payload.MissionData !== undefined && !boundedText(payload.MissionData, 16_384))
    || !jsonObject(message.otherPlayerJson)
    || typeof message.read !== "boolean"
    || typeof message.ignored !== "boolean"
    || typeof message.accepted !== "boolean"
    || !safeDate(message.createdAt)
    || !safeDate(message.expiresAt)
    || message.expiresAt.getTime() - message.createdAt.getTime() < MIN_CHALLENGE_TTL_MS
    || message.expiresAt.getTime() - message.createdAt.getTime() > MAX_CHALLENGE_TTL_MS
    // HHFHFANGCEJ parses the final dash segment with Convert.ToInt32. Milliseconds overflow and
    // make the stock client discard the complete inbox page, so challenge IDs use Unix seconds.
    || creationUnixSeconds(message) <= 0
    || creationUnixSeconds(message) > 2_147_483_647
    || message.messageId !== `${message.fromPlayerId}-${creationUnixSeconds(message)}`
    || message.idempotencyKey !== undefined
    || message.rewardClaimed !== undefined
    || message.claimResponse !== undefined) invalid();

  if (now !== undefined && (!safeDate(now)
    || message.createdAt.getTime() > now.getTime()
    || message.expiresAt.getTime() <= now.getTime())) invalid();

  if (message.accepted) {
    if (!safeDate(message.acceptedAt)
      || message.acceptedAt.getTime() < message.createdAt.getTime()
      || message.acceptedAt.getTime() >= message.expiresAt.getTime()
      || !message.read) invalid();
  } else if (message.acceptedAt !== undefined) {
    invalid();
  }
  return message;
}
