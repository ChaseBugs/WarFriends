import { createHash } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  videoFeed,
  videoFeedRateLimits,
  type VideoFeedDocument,
  type VideoFeedRateLimitDocument,
} from "../db";

const MAXIMUM_URL_LENGTH = 2_048;
const MAXIMUM_UPLOADS_PER_DAY = 20;
const UPLOAD_WINDOW_MS = 24 * 60 * 60 * 1_000;
const RETENTION_MS = 365 * 24 * 60 * 60 * 1_000;
const RATE_LIMIT_RETENTION_MS = UPLOAD_WINDOW_MS * 2;
const VIDEO_FEED_KEYS = new Set([
  "_id", "videoId", "playerId", "urlHash", "url", "createdAt", "updatedAt", "expiresAt",
]);
const RATE_LIMIT_BASE_KEYS = new Set(["_id", "key", "entries", "updatedAt", "expiresAt"]);
const RATE_LIMIT_DECISION_KEYS = new Set([
  ...RATE_LIMIT_BASE_KEYS, "lastUrlHash", "lastAttemptAt", "lastAdmitted",
]);
const RATE_LIMIT_ENTRY_KEYS = new Set(["urlHash", "reservedAt"]);

export interface VideoFeedPublishResult {
  videoId: string;
  url: string;
  replayed: boolean;
}

function digest(value: string): string {
  return createHash("sha256").update(value, "utf8").digest("hex");
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() > 0;
}

/** Stable opaque collection key; unlike AUTH_SECRET HMACs it does not fork a 24-hour window on key rotation. */
export function videoFeedRateLimitKey(playerId: string): string {
  return digest(`video-feed:${playerId}`);
}

/**
 * Prove the complete rolling ledger before it can authorize another replay URL.
 *
 * Old but structurally valid entries are allowed here because the atomic update is responsible
 * for removing entries proven outside the rolling window. Invalid dates/hashes are never pruned
 * as if they had expired, since doing so would silently reopen publication capacity.
 */
export function validatedVideoFeedRateLimit(
  state: VideoFeedRateLimitDocument,
  now: Date,
  expectedKey?: string,
): VideoFeedRateLimitDocument {
  const raw = state && typeof state === "object" && !Array.isArray(state)
    ? state as unknown as Record<string, unknown>
    : {};
  const keys = Object.keys(raw);
  const hasDecision = keys.some((key) => key === "lastUrlHash" || key === "lastAttemptAt" || key === "lastAdmitted");
  const expectedKeys = hasDecision ? RATE_LIMIT_DECISION_KEYS : RATE_LIMIT_BASE_KEYS;
  const seenHashes = new Set<string>();
  if (!state
    || typeof state !== "object"
    || Array.isArray(state)
    || keys.length !== expectedKeys.size
    || keys.some((key) => !expectedKeys.has(key))
    || typeof state._id !== "string"
    || typeof state.key !== "string"
    || state._id !== state.key
    || !/^[0-9a-f]{64}$/u.test(state.key)
    || (expectedKey !== undefined && state.key !== expectedKey)
    || !Array.isArray(state.entries)
    || state.entries.length > MAXIMUM_UPLOADS_PER_DAY
    || state.entries.some((entry) => {
      const entryKeys = entry && typeof entry === "object" ? Object.keys(entry) : [];
      if (!entry
        || typeof entry !== "object"
        || entryKeys.length !== RATE_LIMIT_ENTRY_KEYS.size
        || entryKeys.some((key) => !RATE_LIMIT_ENTRY_KEYS.has(key))
        || typeof entry.urlHash !== "string"
        || !/^[0-9a-f]{64}$/u.test(entry.urlHash)
        || seenHashes.has(entry.urlHash)
        || !safeDate(entry.reservedAt)) return true;
      seenHashes.add(entry.urlHash);
      return false;
    })
    || !safeDate(state.updatedAt)
    || !safeDate(state.expiresAt)
    || !safeDate(now)
    || state.updatedAt.getTime() > now.getTime()
    || state.entries.some((entry) => entry.reservedAt.getTime() > state.updatedAt.getTime())
    || state.expiresAt.getTime() - state.updatedAt.getTime() !== RATE_LIMIT_RETENTION_MS
    || (hasDecision && (typeof state.lastUrlHash !== "string"
      || !/^[0-9a-f]{64}$/u.test(state.lastUrlHash)
      || !safeDate(state.lastAttemptAt)
      || state.lastAttemptAt.getTime() !== state.updatedAt.getTime()
      || typeof state.lastAdmitted !== "boolean"
      || (state.lastAdmitted && !seenHashes.has(state.lastUrlHash))
      || (!state.lastAdmitted
        && (seenHashes.has(state.lastUrlHash) || state.entries.length !== MAXIMUM_UPLOADS_PER_DAY))))) {
    throw new Error("Stored video-feed rate-limit authority is invalid.");
  }
  return state;
}

/** Prove that one durable upload receipt still matches its immutable URL and retention identity. */
export function validatedVideoFeedDocument(document: VideoFeedDocument, now?: Date): VideoFeedDocument {
  let normalizedUrl = "";
  try {
    normalizedUrl = normalizeVideoFeedUrl(document?.url);
  } catch {
    throw new Error("Stored video-feed receipt is invalid.");
  }
  if (!document
    || typeof document !== "object"
    || Object.keys(document).some((key) => !VIDEO_FEED_KEYS.has(key))
    || typeof document.playerId !== "string"
    || document.playerId.length === 0
    || document.playerId.length > 160
    || document.playerId.trim() !== document.playerId
    || /[\u0000-\u001f\u007f]/u.test(document.playerId)
    || normalizedUrl !== document.url
    || document.urlHash !== digest(document.url)
    || document.videoId !== `vf-${digest(`${document.playerId}\u0000${document.url}`).slice(0, 32)}`
    || !safeDate(document.createdAt)
    || !safeDate(document.updatedAt)
    || !safeDate(document.expiresAt)
    || document.updatedAt.getTime() !== document.createdAt.getTime()
    || document.expiresAt.getTime() - document.createdAt.getTime() !== RETENTION_MS
    || (now !== undefined && (!safeDate(now)
      || document.createdAt.getTime() > now.getTime()
      || document.expiresAt.getTime() <= now.getTime()))) {
    throw new Error("Stored video-feed receipt is invalid.");
  }
  return document;
}

/**
 * Validate action 3000's only recovered request field.
 *
 * Everyplay supplied hosted replay links to the old client. HTTP is retained alongside HTTPS for
 * compatibility with those historical links, but executable, file, data, credential-bearing, and
 * control-character URLs are rejected. The backend stores the link and never dereferences it, so
 * publishing cannot become an SSRF path.
 */
export function normalizeVideoFeedUrl(value: unknown): string {
  if (typeof value !== "string") {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video URL is required.");
  }
  const normalized = value.trim();
  if (!normalized || normalized.length > MAXIMUM_URL_LENGTH || /[\u0000-\u001f\u007f]/u.test(normalized)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video URL is invalid.");
  }
  let parsed: URL;
  try {
    parsed = new URL(normalized);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video URL is invalid.");
  }
  if ((parsed.protocol !== "https:" && parsed.protocol !== "http:")
    || !parsed.hostname
    || parsed.username
    || parsed.password) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video URL must be a public HTTP or HTTPS link.");
  }
  return normalized;
}

/**
 * Create the rolling ledger once from durable receipts written before this authority existed.
 *
 * At most 21 rows are loaded: 20 become the conservative active seed, while the extra row proves
 * a legacy race already exceeded the cap. In that case keeping the newest 20 leaves capacity at
 * zero until a real reservation ages out. Concurrent creators race on `_id`; the unique winner is
 * then validated and shared by every process before any new receipt can be inserted.
 */
async function ensureVideoFeedRateLimit(
  playerId: string,
  key: string,
  now: Date,
): Promise<VideoFeedRateLimitDocument> {
  const collection = videoFeedRateLimits();
  const existing = await collection.findOne({ _id: key });
  if (existing) return validatedVideoFeedRateLimit(existing, now, key);

  const cutoff = new Date(now.getTime() - UPLOAD_WINDOW_MS);
  const recentReceipts = await videoFeed()
    .find({ playerId, createdAt: { $gte: cutoff } })
    .sort({ createdAt: -1 })
    .limit(MAXIMUM_UPLOADS_PER_DAY + 1)
    .toArray();
  for (const receipt of recentReceipts) validatedVideoFeedDocument(receipt, now);
  const seed: VideoFeedRateLimitDocument = {
    _id: key,
    key,
    entries: recentReceipts.slice(0, MAXIMUM_UPLOADS_PER_DAY).map((receipt) => ({
      urlHash: receipt.urlHash,
      reservedAt: receipt.createdAt,
    })),
    updatedAt: now,
    expiresAt: new Date(now.getTime() + RATE_LIMIT_RETENTION_MS),
  };
  validatedVideoFeedRateLimit(seed, now, key);
  try {
    await collection.insertOne(seed);
    return seed;
  } catch (error) {
    if ((error as { code?: number }).code !== 11000) throw error;
    const winner = await collection.findOne({ _id: key });
    if (!winner) throw error;
    return validatedVideoFeedRateLimit(winner, now, key);
  }
}

/**
 * Atomically prune and reserve one URL hash across all backend processes.
 *
 * The last-decision fields are written by the same findOneAndUpdate that changes the ledger, so
 * this caller receives its own admission result. A reserved hash is admitted again without an
 * append: that lets a crash between reservation and receipt insertion recover on exact retry.
 */
async function reserveVideoFeedPublication(playerId: string, urlHash: string, now: Date): Promise<void> {
  const key = videoFeedRateLimitKey(playerId);
  await ensureVideoFeedRateLimit(playerId, key, now);
  const cutoff = new Date(now.getTime() - UPLOAD_WINDOW_MS);
  const state = await videoFeedRateLimits().findOneAndUpdate(
    { _id: key, key },
    [
      {
        $set: {
          _activeEntries: {
            $filter: { input: "$entries", as: "entry", cond: { $gte: ["$$entry.reservedAt", cutoff] } },
          },
        },
      },
      {
        $set: {
          _alreadyReserved: {
            $in: [urlHash, { $map: { input: "$_activeEntries", as: "entry", in: "$$entry.urlHash" } }],
          },
          _hasCapacity: { $lt: [{ $size: "$_activeEntries" }, MAXIMUM_UPLOADS_PER_DAY] },
        },
      },
      {
        $set: {
          entries: {
            $cond: [
              "$_alreadyReserved",
              "$_activeEntries",
              {
                $cond: [
                  "$_hasCapacity",
                  { $concatArrays: ["$_activeEntries", [{ urlHash, reservedAt: now }]] },
                  "$_activeEntries",
                ],
              },
            ],
          },
          lastUrlHash: urlHash,
          lastAttemptAt: now,
          lastAdmitted: { $or: ["$_alreadyReserved", "$_hasCapacity"] },
          updatedAt: now,
          expiresAt: new Date(now.getTime() + RATE_LIMIT_RETENTION_MS),
        },
      },
      { $unset: ["_activeEntries", "_alreadyReserved", "_hasCapacity"] },
    ],
    { returnDocument: "after" },
  );
  if (!state) throw new Error("Video-feed publication reservation was not persisted.");
  validatedVideoFeedRateLimit(state, now, key);
  if (state.lastUrlHash !== urlHash || state.lastAttemptAt?.getTime() !== now.getTime()) {
    throw new Error("Video-feed publication reservation returned a mismatched decision.");
  }
  if (!state.lastAdmitted) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video upload limit reached.");
  }
}

/**
 * Persist one authenticated replay publication and return MHEHGPLIFHF's exact URL echo.
 *
 * The 1.6.0 APK has an upload callback but no feed-read database action. A durable record therefore
 * restores the backend half that can be proven without inventing an unreachable mobile screen.
 * The per-player URL hash turns a lost-response retry into the original success, while the atomic
 * rolling ledger and TTL prevent this write-only compatibility endpoint from becoming unbounded
 * storage even when many backend nodes receive distinct URLs at the cap boundary.
 */
export async function publishVideoFeed(
  playerId: string,
  rawUrl: unknown,
  now = new Date(),
): Promise<VideoFeedPublishResult> {
  if (!safeDate(now)) throw new ApiError(ApiErrorCode.InternalServerError, "Video-feed server time is invalid.");
  const url = normalizeVideoFeedUrl(rawUrl);
  const urlHash = digest(url);
  const existing = await videoFeed().findOne({ playerId, urlHash });
  if (existing) {
    validatedVideoFeedDocument(existing, now);
    return { videoId: existing.videoId, url: existing.url, replayed: true };
  }

  await reserveVideoFeedPublication(playerId, urlHash, now);

  const videoId = `vf-${digest(`${playerId}\u0000${url}`).slice(0, 32)}`;
  const document: VideoFeedDocument = {
    videoId,
    playerId,
    urlHash,
    url,
    createdAt: now,
    updatedAt: now,
    expiresAt: new Date(now.getTime() + RETENTION_MS),
  };
  validatedVideoFeedDocument(document, now);
  try {
    await videoFeed().insertOne(document);
    return { videoId, url, replayed: false };
  } catch (error) {
    // Simultaneous repeats can both pass the initial read. The unique player/hash index selects
    // one winner; the loser returns the committed record instead of surfacing a false failure.
    if (!error || typeof error !== "object" || !("code" in error) || error.code !== 11000) throw error;
    const winner = await videoFeed().findOne({ playerId, urlHash });
    if (!winner) throw error;
    validatedVideoFeedDocument(winner, now);
    return { videoId: winner.videoId, url: winner.url, replayed: true };
  }
}
