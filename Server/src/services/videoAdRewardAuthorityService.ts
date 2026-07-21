import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  PlayerProgressionState,
  VideoAdRewardReceiptState,
  VideoAdRewardState,
  VideoAdRewardTimesState,
} from "../db";

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

const VIDEO_AD_TIME_KEYS = new Set(["warcards", "dogtags", "goldenSuitcase", "lootboxes"]);
const VIDEO_AD_STATE_KEYS = new Set(["times", "lastReceipt"]);
const VIDEO_AD_RECEIPT_KEYS = new Set(["reward", "settledAt", "progressionRevision", "response"]);
const MAX_REPLAY_RESPONSE_BYTES = 64 * 1_024;
/** Largest Unix second that can be projected through JavaScript and BSON Date values. */
export const MAX_VIDEO_AD_REWARD_UNIX_SECONDS = 8_640_000_000_000;

export function emptyVideoAdRewardTimes(): VideoAdRewardTimesState {
  return { warcards: [], dogtags: [], goldenSuitcase: [], lootboxes: [] };
}

function safeInteger(value: number, label: string, positive = false): number {
  if (!Number.isSafeInteger(value) || value < (positive ? 1 : 0)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} is invalid.`);
  }
  return value;
}

/**
 * Prove a server clock or durable ledger value before it participates in rolling-limit logic.
 *
 * A generic safe integer is not enough for a Unix timestamp: values above the Date ceiling cannot
 * be represented by the runtime or BSON date types used around player authority. Callers must not
 * floor fractions first, because doing so turns a malformed application clock into a valid grant.
 */
export function validatedVideoAdRewardUnixSeconds(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value <= 0 || value > MAX_VIDEO_AD_REWARD_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} is invalid.`);
  }
  return value;
}

function validatedReplayJson(value: unknown, depth = 0): unknown {
  if (depth > 8) throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is invalid.");
  if (value === null || typeof value === "boolean") return value;
  if (typeof value === "string") {
    if (value.length > 4_096 || /[\u0000-\u0008\u000b\u000c\u000e-\u001f\u007f]/.test(value)) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is invalid.");
    }
    return value;
  }
  if (typeof value === "number") {
    if (!Number.isFinite(value)) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is invalid.");
    }
    return value;
  }
  if (Array.isArray(value)) {
    if (value.length > 256) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is invalid.");
    }
    return value.map((item) => validatedReplayJson(item, depth + 1));
  }
  if (typeof value !== "object" || Object.getPrototypeOf(value) !== Object.prototype) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is invalid.");
  }
  const entries = Object.entries(value);
  if (entries.length > 128) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is invalid.");
  }
  return Object.fromEntries(entries.map(([key, item]) => {
    if (key.length < 1 || key.length > 128 || /[\u0000-\u001f\u007f]/.test(key)) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is invalid.");
    }
    return [key, validatedReplayJson(item, depth + 1)];
  }));
}

/** Validate all four raw ledgers without using wall-clock time or discarding capacity. */
export function validatedVideoAdRewardTimesShape(value: VideoAdRewardTimesState): VideoAdRewardTimesState {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward ledger is invalid.");
  }
  const keys = Object.keys(value);
  if (keys.length !== VIDEO_AD_TIME_KEYS.size || keys.some((key) => !VIDEO_AD_TIME_KEYS.has(key))) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward ledger is invalid.");
  }
  const result = emptyVideoAdRewardTimes();
  for (const limit of Object.values(VIDEO_AD_LIMITS)) {
    const ledger = value[limit.key];
    if (!Array.isArray(ledger) || ledger.length > limit.count) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward ledger is invalid.");
    }
    ledger.forEach((timestamp) => validatedVideoAdRewardUnixSeconds(
      timestamp,
      "Video ad reward timestamp",
    ));
    result[limit.key] = [...ledger];
  }
  return result;
}

function validatedVideoAdRewardReceipt(
  value: VideoAdRewardReceiptState,
  times: VideoAdRewardTimesState,
  progressionRevision?: number,
): VideoAdRewardReceiptState {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward receipt is invalid.");
  }
  const keys = Object.keys(value);
  if (keys.length !== VIDEO_AD_RECEIPT_KEYS.size
    || keys.some((key) => !VIDEO_AD_RECEIPT_KEYS.has(key))) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward receipt is invalid.");
  }
  const reward = value.reward;
  const limit = VIDEO_AD_LIMITS[reward];
  const settledAt = validatedVideoAdRewardUnixSeconds(
    value.settledAt,
    "Video ad reward receipt time",
  );
  const receiptRevision = safeInteger(value.progressionRevision, "Video ad reward receipt revision", true);
  if (!limit || (progressionRevision !== undefined && receiptRevision > progressionRevision)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward receipt is inconsistent.");
  }
  if (!times[limit.key].includes(settledAt)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward receipt has no ledger grant.");
  }
  const response = validatedReplayJson(value.response);
  if (!response || typeof response !== "object" || Array.isArray(response)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is invalid.");
  }
  const serialized = JSON.stringify(response);
  if (Buffer.byteLength(serialized, "utf8") > MAX_REPLAY_RESPONSE_BYTES) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response is too large.");
  }
  const responseTimes = (response as Record<string, unknown>).videoAdRewardTimes;
  const validatedResponseTimes = validatedVideoAdRewardTimesShape(responseTimes as VideoAdRewardTimesState);
  if (JSON.stringify(validatedResponseTimes) !== JSON.stringify(times)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad replay response ledger is inconsistent.");
  }
  return { reward, settledAt, progressionRevision: receiptRevision, response: response as Record<string, unknown> };
}

/** Validate the complete durable ledger and replay receipt without any wall-clock decision. */
export function validatedVideoAdRewardStateShape(
  value: VideoAdRewardState | undefined,
  progressionRevision?: number,
): VideoAdRewardState {
  if (progressionRevision !== undefined) {
    safeInteger(progressionRevision, "Video ad reward progression revision");
  }
  if (value === undefined) return { times: emptyVideoAdRewardTimes() };
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward state is invalid.");
  }
  const keys = Object.keys(value);
  if (keys.length < 1 || keys.length > VIDEO_AD_STATE_KEYS.size
    || keys.some((key) => !VIDEO_AD_STATE_KEYS.has(key))) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward state is invalid.");
  }
  const times = validatedVideoAdRewardTimesShape(value.times);
  const lastReceipt = Object.prototype.hasOwnProperty.call(value, "lastReceipt")
    ? validatedVideoAdRewardReceipt(
      value.lastReceipt as VideoAdRewardReceiptState,
      times,
      progressionRevision,
    )
    : undefined;
  return { times, ...(lastReceipt ? { lastReceipt } : {}) };
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
  const currentTime = validatedVideoAdRewardUnixSeconds(now, "Video ad reward comparison time");
  const current = validatedVideoAdRewardTimesShape(value);
  const result = emptyVideoAdRewardTimes();
  for (const limit of Object.values(VIDEO_AD_LIMITS)) {
    const ledger = current[limit.key];
    const cutoff = currentTime - limit.intervalSeconds;
    result[limit.key] = ledger
      .filter((timestamp) => timestamp >= cutoff)
      .sort((left, right) => left - right);
  }
  return result;
}

/** Validate authority first, then discard only timestamps provably outside their rolling window. */
export function validatedVideoAdRewardState(
  value: VideoAdRewardState | undefined,
  now: number,
  progressionRevision?: number,
): VideoAdRewardState {
  const current = validatedVideoAdRewardStateShape(value, progressionRevision);
  if (current.lastReceipt && current.lastReceipt.settledAt > now) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Video ad reward receipt is in the future.");
  }
  return {
    times: validatedVideoAdRewardTimes(current.times, now),
    ...(current.lastReceipt ? { lastReceipt: current.lastReceipt } : {}),
  };
}

/** Treat an absent reward record as a fresh account, but never as a repair for a partial record. */
export function videoAdRewardTimesForState(
  state: PlayerProgressionState,
  now: number,
): VideoAdRewardTimesState {
  return validatedVideoAdRewardState(state.videoAdRewards, now, state.revision).times;
}
