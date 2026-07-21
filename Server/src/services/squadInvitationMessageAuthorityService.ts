import type { MessageDoc } from "./socialService";

const MESSAGE_KEYS = new Set([
  "_id", "messageId", "toPlayerId", "fromPlayerId", "fromName", "body", "messageType",
  "payload", "otherPlayerJson", "read", "ignored", "accepted", "acceptedAt", "createdAt",
  "idempotencyKey", "rewardClaimed", "claimResponse", "expiresAt",
]);
const PAYLOAD_KEYS = new Set(["SquadId", "Squad"]);
const SQUAD_WIRE_KEYS = new Set([
  "Id", "IsPublic", "Message", "RoundId", "Size", "Skill", "Level", "SkillRequirement",
  "SquadPoints", "Experience", "LevelExperience", "Icon", "Kills", "BattlesLost",
  "BattlesWon", "CardsPlayed", "BestSkill", "UnitsDeployed", "TiersCompleted",
  "SquadPointsBest", "SquadWarWins",
]);
const REQUIRED_PLAYER_WIRE_KEYS = new Set([
  "Id", "Name", "Level", "Reputation", "SquadPoints", "Experience", "Country", "SendLogs",
  "DeviceToken", "LastAction", "PlayerVisuals", "ArmyPower", "Status", "BeginnersLeague",
  "Vip", "AccountType", "Skill", "PlacementMatchesRequired", "MedalsBalance", "SquadRank",
  "VisualType", "VisualTimestamp", "InfluencerLink", "InfluencerAlias", "SquadId",
]);
const OPTIONAL_PLAYER_WIRE_KEYS = new Set([
  "LeagueId", "EligibleLeagueId", "FacebookId", "GameCenterId", "GooglePlayId", "Regions",
  "InventoryData", "LevelManagerData", "StatisticsData", "DepositedCards",
]);
const PLAYER_STRING_KEYS = new Set([
  "Id", "Name", "Country", "DeviceToken", "PlayerVisuals", "VisualType", "InfluencerLink",
  "InfluencerAlias", "SquadId", "LeagueId", "FacebookId", "GameCenterId", "GooglePlayId",
  "Regions", "InventoryData", "LevelManagerData", "StatisticsData",
]);
const UUID_PATTERN = "[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}";

function invalid(): never {
  throw new Error("Stored Squad invitation message is invalid.");
}

function exactKeys(value: object, allowed: ReadonlySet<string>): boolean {
  const keys = Object.keys(value);
  return keys.length === allowed.size && keys.every((key) => allowed.has(key));
}

function knownKeys(value: object, allowed: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => allowed.has(key));
}

function boundedText(value: unknown, minimum: number, maximum: number): value is string {
  return typeof value === "string"
    && value.length >= minimum
    && value.length <= maximum
    && value.trim() === value
    && !/\p{Cc}/u.test(value);
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() > 0;
}

function parsedObject(value: unknown, maximumBytes: number): Record<string, unknown> {
  if (typeof value !== "string" || value.length === 0 || Buffer.byteLength(value, "utf8") > maximumBytes) invalid();
  try {
    const parsed = JSON.parse(value) as unknown;
    if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) invalid();
    return parsed as Record<string, unknown>;
  } catch {
    return invalid();
  }
}

function stringAttribute(value: unknown): string | null {
  if (!value || typeof value !== "object" || Array.isArray(value)) return null;
  const record = value as Record<string, unknown>;
  return exactKeys(record, new Set(["S"])) && typeof record.S === "string" ? record.S : null;
}

function validNumberAttribute(value: unknown): boolean {
  if (!value || typeof value !== "object" || Array.isArray(value)) return false;
  const record = value as Record<string, unknown>;
  if (!exactKeys(record, new Set(["N"]))
    || typeof record.N !== "string"
    || !/^-?(?:0|[1-9]\d*)$/u.test(record.N)) return false;
  const parsed = Number(record.N);
  return Number.isSafeInteger(parsed);
}

function validDepositedCards(value: unknown): boolean {
  if (!value || typeof value !== "object" || Array.isArray(value)) return false;
  const outer = value as Record<string, unknown>;
  if (!exactKeys(outer, new Set(["M"]))
    || !outer.M || typeof outer.M !== "object" || Array.isArray(outer.M)) return false;
  const cards = outer.M as Record<string, unknown>;
  if (Object.keys(cards).length > 100) return false;
  return Object.entries(cards).every(([id, amount]) => boundedText(id, 1, 128)
    && boundedText(stringAttribute(amount), 1, 64));
}

function validateSquadSnapshot(message: MessageDoc): void {
  if (!exactKeys(message.payload, PAYLOAD_KEYS)
    || !boundedText(message.payload.SquadId, 3, 24)) invalid();
  const squad = parsedObject(message.payload.Squad, 65_536);
  if (!exactKeys(squad, SQUAD_WIRE_KEYS)
    || squad.Id !== message.payload.SquadId
    || !boundedText(squad.Icon, 1, 128)
    || typeof squad.Message !== "string"
    || Buffer.byteLength(squad.Message, "utf8") > 2_048
    || /\p{Cc}/u.test(squad.Message)
    || !boundedText(squad.RoundId, 1, 160)
    || ![0, 1].includes(squad.IsPublic as number)) invalid();
  for (const [key, value] of Object.entries(squad)) {
    if (["Id", "Icon", "Message", "RoundId"].includes(key)) continue;
    if (!Number.isSafeInteger(value) || (value as number) < 0 || (value as number) > 2_147_483_647) invalid();
  }
}

function validateInviterSnapshot(message: MessageDoc): void {
  const player = parsedObject(message.otherPlayerJson, 262_144);
  const keys = Object.keys(player);
  if (![...REQUIRED_PLAYER_WIRE_KEYS].every((key) => keys.includes(key))
    || keys.some((key) => !REQUIRED_PLAYER_WIRE_KEYS.has(key) && !OPTIONAL_PLAYER_WIRE_KEYS.has(key))
    || (keys.includes("LeagueId") === keys.includes("EligibleLeagueId"))
    || stringAttribute(player.Id) !== message.fromPlayerId
    || stringAttribute(player.Name) !== message.fromName
    || stringAttribute(player.SquadId) !== message.payload.SquadId) invalid();
  for (const [key, value] of Object.entries(player)) {
    if (key === "DepositedCards") {
      if (!validDepositedCards(value)) invalid();
    } else if (PLAYER_STRING_KEYS.has(key)) {
      const text = stringAttribute(value);
      if (text === null || Buffer.byteLength(text, "utf8") > 262_144 || /\p{Cc}/u.test(text)) invalid();
    } else if (!validNumberAttribute(value)) invalid();
  }
}

/**
 * Validate the complete recovered MessageType=1 invitation capability.
 *
 * Active and merely shown rows have no acceptance timestamp. Decline is represented by the
 * stock IgnoreMessage transition (`read && ignored && !accepted`). Acceptance is terminal only
 * when all three flags are true and acceptedAt is present; this lets a lost action-38 response
 * replay the already committed membership without reopening the invitation.
 */
export function validatedSquadInvitationMessage(message: MessageDoc, now?: Date): MessageDoc | null {
  if (!message || typeof message !== "object" || message.messageType !== 1) return null;
  const unixSeconds = Math.floor(message.createdAt?.getTime?.() / 1_000);
  const idPattern = new RegExp(`^SquadInvitation-${UUID_PATTERN}-${unixSeconds}$`, "u");
  if (!knownKeys(message, MESSAGE_KEYS)
    || !boundedText(message.messageId, 1, 256)
    || !idPattern.test(message.messageId)
    || !boundedText(message.toPlayerId, 1, 160)
    || !boundedText(message.fromPlayerId, 1, 160)
    || message.toPlayerId === message.fromPlayerId
    || !boundedText(message.fromName, 1, 64)
    || message.body !== "You were invited to a squad."
    || !message.payload || typeof message.payload !== "object" || Array.isArray(message.payload)
    || typeof message.read !== "boolean"
    || typeof message.ignored !== "boolean"
    || typeof message.accepted !== "boolean"
    || (message.ignored && !message.read)
    || (message.accepted
      ? (!message.read || !message.ignored || !safeDate(message.acceptedAt))
      : message.acceptedAt !== undefined)
    || message.idempotencyKey !== undefined
    || message.rewardClaimed !== undefined
    || message.claimResponse !== undefined
    || message.expiresAt !== undefined
    || !safeDate(message.createdAt)
    || unixSeconds <= 0
    || unixSeconds > 2_147_483_647
    || (now !== undefined && (!safeDate(now) || message.createdAt.getTime() > now.getTime()))
    || (message.acceptedAt !== undefined
      && (message.acceptedAt.getTime() < message.createdAt.getTime()
        || (now !== undefined && message.acceptedAt.getTime() > now.getTime())))) invalid();

  validateSquadSnapshot(message);
  validateInviterSnapshot(message);
  return message;
}
