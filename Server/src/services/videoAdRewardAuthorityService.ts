import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, VideoAdRewardTimesState } from "../db";

/** Exact MHNMOFPPKBN values sent in action 156's `Reward` field. */
export enum VideoAdRewardKind {
  RandomCard = 1,
  Dogtag = 2,
  GoldenSuitcase = 3,
  LootBox = 4,
}

interface VideoAdLimit {
  key: keyof VideoAdRewardTimesState;
  count: number;
  intervalSeconds: number;
  minimumSpacingSeconds: number;
}

/**
 * Exact 4.9.5 MainScene Constants values after decoding ObscuredFloat's XOR storage.
 *
 * EventTrackingManager applies these as a rolling count/window, not as a UTC-day counter.
 * Only Golden Suitcase has a separate spacing row (`GoldenSuitcaseAdTimeBetweenMinutes=1`).
 * The server repeats the same policy because a modified client can bypass the local manager.
 */
export const VIDEO_AD_LIMITS: Readonly<Record<VideoAdRewardKind, Readonly<VideoAdLimit>>> = Object.freeze({
  [VideoAdRewardKind.RandomCard]: Object.freeze({
    key: "warcards",
    count: 24,
    intervalSeconds: 5 * 60 * 60,
    minimumSpacingSeconds: 0,
  }),
  [VideoAdRewardKind.Dogtag]: Object.freeze({
    key: "dogtags",
    count: 24,
    intervalSeconds: 12 * 60 * 60,
    minimumSpacingSeconds: 0,
  }),
  [VideoAdRewardKind.GoldenSuitcase]: Object.freeze({
    key: "goldenSuitcase",
    count: 24,
    intervalSeconds: 15 * 60 * 60,
    minimumSpacingSeconds: 60,
  }),
  [VideoAdRewardKind.LootBox]: Object.freeze({
    key: "lootboxes",
    count: 24,
    intervalSeconds: 100 * 60 * 60,
    minimumSpacingSeconds: 0,
  }),
});

export function emptyVideoAdRewardTimes(): VideoAdRewardTimesState {
  return { warcards: [], dogtags: [], goldenSuitcase: [], lootboxes: [] };
}

/**
 * Validate and project the four durable rolling ledgers at one server-owned timestamp.
 *
 * Invalid numbers cannot be discarded as though they were expired. In particular, silently
 * dropping `NaN` or `Infinity` reopens an ad allowance even though the server cannot prove when
 * that recorded grant happened. Each service transition can produce at most the source-defined
 * count, so an oversized array is damaged authority as well. Valid timestamps older than their
 * rolling window are different: they provably grant no current authority and are safely removed.
 * Future safe timestamps remain in the ledger, deliberately consuming capacity after a clock
 * rollback instead of letting the same advertisements mint rewards twice.
 */
export function validatedVideoAdRewardTimes(
  value: VideoAdRewardTimesState,
  now: number,
): VideoAdRewardTimesState {
  if (!Number.isSafeInteger(now) || now <= 0 || !value || typeof value !== "object") {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward ledger is invalid.");
  }
  const result = emptyVideoAdRewardTimes();
  for (const limit of Object.values(VIDEO_AD_LIMITS)) {
    const ledger = value[limit.key];
    if (!Array.isArray(ledger) || ledger.length > limit.count) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward ledger is invalid.");
    }
    if (ledger.some((timestamp) => !Number.isSafeInteger(timestamp) || timestamp <= 0)) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward timestamp is invalid.");
    }
    const cutoff = now - limit.intervalSeconds;
    result[limit.key] = ledger
      .filter((timestamp) => timestamp >= cutoff)
      .sort((left, right) => left - right);
  }
  return result;
}

/** Treat an absent reward record as a fresh account, but never as a repair for a partial record. */
export function videoAdRewardTimesForState(
  state: PlayerProgressionState,
  now: number,
): VideoAdRewardTimesState {
  return state.videoAdRewards === undefined
    ? emptyVideoAdRewardTimes()
    : validatedVideoAdRewardTimes(state.videoAdRewards.times, now);
}
