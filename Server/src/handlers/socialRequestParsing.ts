import { ApiError, ApiErrorCode } from "../apiErrors";
import type { ChallengeMessageInput } from "../services/socialService";

const CHALLENGE_GAME_TYPES = new Set([2, 4, 8, 16, 32]);
const CHALLENGE_REGIONS = new Set([0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

function invalid(field: string): never {
  throw new ApiError(ApiErrorCode.UnknownAction, `${field} is invalid.`);
}

/**
 * Read an exact nonnegative integer emitted by C# `ToString`, while also accepting a JSON number
 * from replacement clients. JavaScript's Number conversion is deliberately not used here because
 * it turns null, booleans, arrays, blanks, and exponent strings into believable challenge fields.
 */
function exactUnsignedInteger(value: unknown, field: string): number {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  if (!Number.isSafeInteger(parsed) || parsed < 0) invalid(field);
  return parsed;
}

function exactText(value: unknown, field: string, maximum: number): string {
  if (typeof value !== "string"
    || value.length < 1
    || value.length > maximum
    || value.trim() !== value
    || /[\u0000-\u001f\u007f]/u.test(value)) invalid(field);
  return value;
}

function optionalText(value: unknown, field: string, maximum: number): string | undefined {
  return value === undefined ? undefined : exactText(value, field, maximum);
}

/** Parse exactly the action-2 fields emitted by BeanstalkServerManager.Challenge. */
export function parseChallengeMessageRequest(req: Record<string, unknown>): ChallengeMessageInput {
  const gameType = exactUnsignedInteger(req.GameType, "GameType");
  const region = exactUnsignedInteger(req.Region, "Region");
  if (!CHALLENGE_GAME_TYPES.has(gameType)) invalid("GameType");
  if (!CHALLENGE_REGIONS.has(region)) invalid("Region");

  const numberOfMission = req.NumberOfMission === undefined
    ? undefined
    : exactUnsignedInteger(req.NumberOfMission, "NumberOfMission");
  if (numberOfMission !== undefined && numberOfMission > 1_000_000) invalid("NumberOfMission");

  return {
    challengedPlayerId: exactText(req.ChallengedPlayerId, "ChallengedPlayerId", 160),
    mapName: exactText(req.MapName, "MapName", 160),
    gameType,
    region,
    roomName: exactText(req.roomName, "roomName", 256),
    clientVersion: exactText(req.clientVersion, "clientVersion", 64),
    missionType: optionalText(req.MissionType, "MissionType", 64),
    numberOfMission,
    missionData: optionalText(req.MissionData, "MissionData", 16_384),
  };
}
