import { League } from "../constants";
import type { MessageDoc } from "./socialService";

const REWARD_MESSAGE_TYPES = new Set([9, 11, 23]);
const MESSAGE_KEYS = new Set([
  "_id", "messageId", "toPlayerId", "fromPlayerId", "fromName", "body", "messageType",
  "payload", "otherPlayerJson", "read", "ignored", "accepted", "acceptedAt", "createdAt",
  "idempotencyKey", "rewardClaimed", "claimResponse", "expiresAt",
]);
const TYPE_9_KEYS = new Set([
  "Position", "SquadId", "SquadIcon", "RewardGold", "PrevLevelId", "NewLevelId", "SquadMembers",
]);
const TYPE_11_KEYS = new Set(["Tier", "SquadId", "Reward"]);
const TYPE_23_KEYS = new Set([
  "LeagueId", "BeforeLeagueId", "Medals", "FormerFullLeagueId", "RewardGold", "Position",
  "NotEnoughPlayers",
]);
const CLAIM_RESPONSE_KEYS = new Set(["Gold", "Warbucks"]);

export interface InboxRewardAuthority {
  Gold: number;
  Warbucks: 0;
}

function invalid(): never {
  throw new Error("Stored inbox reward message is invalid.");
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

/**
 * Early reconstruction builds and DynamoDB imports can contain numeric strings. Preserve that
 * migration only for canonical integer text; JavaScript coercions such as empty strings,
 * whitespace, exponent notation, and fractions must never become placement or reward authority.
 */
function legacyInteger(value: unknown, minimum: number, maximum = Number.MAX_SAFE_INTEGER): number | null {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|-?[1-9][0-9]*)$/u.test(value)
      ? Number(value)
      : Number.NaN;
  return Number.isSafeInteger(parsed) && parsed >= minimum && parsed <= maximum ? parsed : null;
}

function boundedJsonArray(value: unknown, maximumItems: number): boolean {
  if (typeof value !== "string" || value.length === 0 || value.length > 262_144) return false;
  try {
    const parsed = JSON.parse(value) as unknown;
    return Array.isArray(parsed) && parsed.length <= maximumItems;
  } catch {
    return false;
  }
}

function validCommonEnvelope(message: MessageDoc, now?: Date): boolean {
  const unixSeconds = message.createdAt instanceof Date
    ? Math.floor(message.createdAt.getTime() / 1_000)
    : Number.NaN;
  return exactKeys(message, MESSAGE_KEYS)
    // The page cursor carries this identity and has the same 256-character limit.
    && boundedText(message.messageId, 256)
    && boundedText(message.toPlayerId, 256)
    && boundedText(message.fromPlayerId, 256)
    && boundedText(message.fromName, 256, true)
    && boundedText(message.body, 1_024, true)
    && message.payload !== null
    && typeof message.payload === "object"
    && !Array.isArray(message.payload)
    && message.otherPlayerJson === ""
    && typeof message.read === "boolean"
    && typeof message.ignored === "boolean"
    && typeof message.accepted === "boolean"
    && !message.accepted
    && message.acceptedAt === undefined
    && message.expiresAt === undefined
    && message.createdAt instanceof Date
    && Number.isSafeInteger(message.createdAt.getTime())
    && message.createdAt.getTime() > 0
    // The recovered base message constructor parses only the final dash-separated ID segment
    // as Int32. Bind it to creation time so durable reward rows cannot break the entire page.
    && Number.isSafeInteger(unixSeconds)
    && unixSeconds > 0
    && unixSeconds <= 2_147_483_647
    && message.messageId.endsWith(`-${unixSeconds}`)
    && (message.idempotencyKey === undefined || message.messageId === `${message.idempotencyKey}-${unixSeconds}`)
    && (now === undefined || (now instanceof Date
      && Number.isSafeInteger(now.getTime())
      && now.getTime() >= message.createdAt.getTime()))
    && (message.idempotencyKey === undefined || boundedText(message.idempotencyKey, 512))
    && (message.rewardClaimed === undefined || typeof message.rewardClaimed === "boolean");
}

function type9Reward(message: MessageDoc): number | null {
  const payload = message.payload;
  if (!exactKeys(payload, TYPE_9_KEYS)
    || legacyInteger(payload.Position, 1, 50) === null
    || !boundedText(payload.SquadId, 256)
    || !boundedText(payload.SquadIcon, 256, true)
    || legacyInteger(payload.PrevLevelId, 1, 8) === null
    || legacyInteger(payload.NewLevelId, 1, 8) === null
    || !boundedJsonArray(payload.SquadMembers, 100)) invalid();
  const reward = legacyInteger(payload.RewardGold, 0);
  if (reward === null) invalid();
  return reward > 0 ? reward : null;
}

function type11Reward(message: MessageDoc): number | null {
  const payload = message.payload;
  if (!exactKeys(payload, TYPE_11_KEYS)
    || legacyInteger(payload.Tier, 0, 31) === null
    || !boundedText(payload.SquadId, 256)) invalid();
  const reward = legacyInteger(payload.Reward, 0);
  if (reward === null) invalid();
  return reward > 0 ? reward : null;
}

function type23Reward(message: MessageDoc): number | null {
  const payload = message.payload;
  if (!exactKeys(payload, TYPE_23_KEYS)
    || legacyInteger(payload.LeagueId, League.Bronze3, League.Champion) === null
    || (payload.BeforeLeagueId !== undefined
      && legacyInteger(payload.BeforeLeagueId, League.Bronze3, League.Champion) === null)
    || (payload.Medals !== undefined && legacyInteger(payload.Medals, 0) === null)
    || (payload.FormerFullLeagueId !== undefined
      && !boundedText(payload.FormerFullLeagueId, 512))
    || (payload.Position !== undefined && legacyInteger(payload.Position, 1, 100) === null)
    || (payload.NotEnoughPlayers !== undefined && legacyInteger(payload.NotEnoughPlayers, 1, 1) === null)) invalid();
  if (payload.RewardGold === undefined) return null;
  const reward = legacyInteger(payload.RewardGold, 0);
  if (reward === null) invalid();
  return reward > 0 ? reward : null;
}

function validateClaimMarker(message: MessageDoc, reward: number | null): void {
  if (!message.rewardClaimed) {
    if (message.claimResponse !== undefined) invalid();
    return;
  }
  const response = message.claimResponse;
  if (!response
    || reward === null
    || !exactKeys(response, CLAIM_RESPONSE_KEYS)
    || response.Gold !== reward
    || response.Warbucks !== 0
    || !message.read
    || !message.ignored) invalid();
}

/**
 * Validate one complete server-authored reward message before insertion, client publication,
 * claim, or replay. Other inbox types return null because they are not economy authority.
 *
 * `idempotencyKey` remains optional only for messages written by older reconstruction builds;
 * when present it is still bounded and control-free. Reward payload and terminal response are
 * never optional migrations: they must agree exactly or the message fails closed.
 */
export function validatedInboxRewardMessage(message: MessageDoc, now?: Date): InboxRewardAuthority | null {
  if (!message || typeof message !== "object" || !REWARD_MESSAGE_TYPES.has(message.messageType)) return null;
  if (!validCommonEnvelope(message, now)) invalid();
  const reward = message.messageType === 9
    ? type9Reward(message)
    : message.messageType === 11
      ? type11Reward(message)
      : type23Reward(message);
  validateClaimMarker(message, reward);
  return reward === null ? null : { Gold: reward, Warbucks: 0 };
}
