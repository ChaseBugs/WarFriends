import { createHash } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { videoFeed, type VideoFeedDocument } from "../db";

const MAXIMUM_URL_LENGTH = 2_048;
const MAXIMUM_UPLOADS_PER_DAY = 20;
const UPLOAD_WINDOW_MS = 24 * 60 * 60 * 1_000;
const RETENTION_MS = 365 * 24 * 60 * 60 * 1_000;

export interface VideoFeedPublishResult {
  videoId: string;
  url: string;
  replayed: boolean;
}

function digest(value: string): string {
  return createHash("sha256").update(value, "utf8").digest("hex");
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
 * Persist one authenticated replay publication and return MHEHGPLIFHF's exact URL echo.
 *
 * The 1.6.0 APK has an upload callback but no feed-read database action. A durable record therefore
 * restores the backend half that can be proven without inventing an unreachable mobile screen.
 * The per-player URL hash turns a lost-response retry into the original success, while the rolling
 * cap and TTL prevent this write-only compatibility endpoint from becoming unbounded storage.
 */
export async function publishVideoFeed(
  playerId: string,
  rawUrl: unknown,
  now = new Date(),
): Promise<VideoFeedPublishResult> {
  const url = normalizeVideoFeedUrl(rawUrl);
  const urlHash = digest(url);
  const existing = await videoFeed().findOne({ playerId, urlHash });
  if (existing) return { videoId: existing.videoId, url: existing.url, replayed: true };

  const windowStart = new Date(now.getTime() - UPLOAD_WINDOW_MS);
  const recent = await videoFeed().countDocuments(
    { playerId, createdAt: { $gte: windowStart } },
    { limit: MAXIMUM_UPLOADS_PER_DAY },
  );
  if (recent >= MAXIMUM_UPLOADS_PER_DAY) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video upload limit reached.");
  }

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
  try {
    await videoFeed().insertOne(document);
    return { videoId, url, replayed: false };
  } catch (error) {
    // Simultaneous repeats can both pass the initial read. The unique player/hash index selects
    // one winner; the loser returns the committed record instead of surfacing a false failure.
    if (!error || typeof error !== "object" || !("code" in error) || error.code !== 11000) throw error;
    const winner = await videoFeed().findOne({ playerId, urlHash });
    if (!winner) throw error;
    return { videoId: winner.videoId, url: winner.url, replayed: true };
  }
}

