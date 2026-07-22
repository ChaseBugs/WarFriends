import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Read the exact Squad Wars round identity echoed by the recovered client.
 *
 * `BeanstalkServerManager.HCDNHLKDNLB` sends the cached server-authored value under the single
 * canonical `RoundId` form field. It performs no normalization. This ID selects a competition
 * division whose placement can later authorize rewards, so trimming or stringifying input would
 * let two distinct requests converge on one stored authority key. Keep the existing bounded ID
 * alphabet, but require the exact bytes before the service compares them with the player's active
 * round. A replacement-only `roundId` alias is deliberately not a source of authority.
 */
export function requestedSquadWarRoundId(req: Record<string, unknown>): string {
  const value = req.RoundId;
  if (typeof value !== "string"
    || value.length < 1
    || value.length > 128
    || value.trim() !== value
    || !/^[\p{L}\p{N}_.:-]+$/u.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "RoundId is invalid.");
  }
  return value;
}
