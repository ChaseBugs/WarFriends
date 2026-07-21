import type { Collection, Filter } from "mongodb";
import { videoFeed, type VideoFeedDocument } from "../db";
import { validatedVideoFeedDocument } from "./videoFeedService";

export interface AdminReplayVideoListInput {
  readonly playerId: string | null;
  readonly limit: number;
  readonly cursor: string | null;
}

export interface AdminReplayVideoPage {
  readonly items: VideoFeedDocument[];
  readonly nextCursor: string | null;
}

interface ReplayVideoCursor {
  readonly v: 1;
  readonly playerId: string | null;
  readonly createdAtMs: number;
  readonly videoId: string;
}

const VIDEO_ID = /^vf-[0-9a-f]{32}$/u;
const CURSOR_KEYS = new Set(["v", "playerId", "createdAtMs", "videoId"]);

export class AdminReplayVideoInputError extends Error {
  readonly httpStatus = 400;
}

function exactNow(now: Date): number {
  if (!(now instanceof Date) || !Number.isSafeInteger(now.getTime()) || now.getTime() < 0) {
    throw new Error("Replay-video query time is invalid.");
  }
  return now.getTime();
}

export function normalizeAdminReplayVideoId(value: unknown): string {
  if (typeof value !== "string" || !VIDEO_ID.test(value)) {
    throw new AdminReplayVideoInputError("Replay videoId is invalid.");
  }
  return value;
}

function exactPlayerId(value: unknown): string | null {
  if (value === undefined || value === null || value === "") return null;
  if (typeof value !== "string"
    || value.length > 160
    || value.trim() !== value
    || /[\u0000-\u001f\u007f]/u.test(value)) {
    throw new AdminReplayVideoInputError("Replay playerId is invalid.");
  }
  return value;
}

function exactLimit(value: unknown): number {
  if (value === undefined) return 50;
  if (typeof value !== "string" || !/^(?:[1-9]|[1-9][0-9]|100)$/u.test(value)) {
    throw new AdminReplayVideoInputError("Replay limit must be an integer from 1 through 100.");
  }
  return Number(value);
}

function encodeCursor(cursor: ReplayVideoCursor): string {
  return Buffer.from(JSON.stringify(cursor), "utf8").toString("base64url");
}

function decodeCursor(
  value: unknown,
  playerId: string | null,
  nowMs: number,
): ReplayVideoCursor | null {
  if (value === undefined || value === null || value === "") return null;
  if (typeof value !== "string" || value.length > 1_024 || !/^[A-Za-z0-9_-]+$/u.test(value)) {
    throw new AdminReplayVideoInputError("Replay cursor is invalid.");
  }
  let parsed: unknown;
  try {
    const decoded = Buffer.from(value, "base64url");
    if (decoded.toString("base64url") !== value) throw new Error("non-canonical cursor");
    parsed = JSON.parse(decoded.toString("utf8"));
  } catch {
    throw new AdminReplayVideoInputError("Replay cursor is invalid.");
  }
  const raw = parsed as Record<string, unknown> | null;
  if (!raw
    || typeof raw !== "object"
    || Array.isArray(raw)
    || Object.keys(raw).length !== CURSOR_KEYS.size
    || Object.keys(raw).some((key) => !CURSOR_KEYS.has(key))
    || raw.v !== 1
    || raw.playerId !== playerId
    || !Number.isSafeInteger(raw.createdAtMs)
    || (raw.createdAtMs as number) < 0
    || (raw.createdAtMs as number) > nowMs
    || typeof raw.videoId !== "string"
    || !VIDEO_ID.test(raw.videoId)) {
    throw new AdminReplayVideoInputError("Replay cursor does not match this query.");
  }
  return raw as unknown as ReplayVideoCursor;
}

export function normalizeAdminReplayVideoListInput(
  values: Record<string, unknown>,
  now = new Date(),
): AdminReplayVideoListInput & { readonly decodedCursor: ReplayVideoCursor | null } {
  const nowMs = exactNow(now);
  const playerId = exactPlayerId(values.playerId);
  return {
    playerId,
    limit: exactLimit(values.limit),
    cursor: typeof values.cursor === "string" ? values.cursor : null,
    decodedCursor: decodeCursor(values.cursor, playerId, nowMs),
  };
}

function validateSelected(row: VideoFeedDocument, now: Date, playerId: string | null): VideoFeedDocument {
  validatedVideoFeedDocument(row, now);
  if (playerId !== null && row.playerId !== playerId) {
    throw new Error("Selected replay video does not match the player query.");
  }
  return row;
}

/**
 * Return one stable operator page over action-3000 publications.
 *
 * The cursor is bound to the optional player filter and to the exact final `(createdAt, videoId)`
 * tuple. That unique descending tuple prevents concurrent newer inserts from duplicating or
 * skipping older rows. MongoDB TTL deletion is only storage hygiene: the query and complete-row
 * validator both enforce expiry from application time before a URL can become operator-visible.
 */
export async function listAdminReplayVideos(
  input: AdminReplayVideoListInput,
  now = new Date(),
  collection?: Collection<VideoFeedDocument>,
): Promise<AdminReplayVideoPage> {
  const normalized = normalizeAdminReplayVideoListInput({
    playerId: input.playerId,
    limit: String(input.limit),
    cursor: input.cursor,
  }, now);
  const filter: Filter<VideoFeedDocument> = {
    expiresAt: { $gt: now },
    ...(normalized.playerId === null ? {} : { playerId: normalized.playerId }),
    ...(normalized.decodedCursor === null ? {} : {
      $or: [
        { createdAt: { $lt: new Date(normalized.decodedCursor.createdAtMs) } },
        {
          createdAt: new Date(normalized.decodedCursor.createdAtMs),
          videoId: { $lt: normalized.decodedCursor.videoId },
        },
      ],
    }),
  };
  const rows = await (collection ?? videoFeed())
    .find(filter)
    .sort({ createdAt: -1, videoId: -1 })
    .limit(normalized.limit)
    .toArray();
  const items = rows.map((row) => validateSelected(row, now, normalized.playerId));
  const last = items.length === normalized.limit ? items[items.length - 1] : undefined;
  return {
    items,
    nextCursor: last ? encodeCursor({
      v: 1,
      playerId: normalized.playerId,
      createdAtMs: last.createdAt.getTime(),
      videoId: last.videoId,
    }) : null,
  };
}

/** Resolve one deterministic action-3000 receipt without fetching its untrusted hosted URL. */
export async function findAdminReplayVideo(
  videoIdValue: unknown,
  now = new Date(),
  collection?: Collection<VideoFeedDocument>,
): Promise<VideoFeedDocument | null> {
  const videoId = normalizeAdminReplayVideoId(videoIdValue);
  exactNow(now);
  const row = await (collection ?? videoFeed()).findOne({
    videoId,
    expiresAt: { $gt: now },
  });
  if (!row) return null;
  const validated = validateSelected(row, now, null);
  if (validated.videoId !== videoId) {
    throw new Error("Selected replay video does not match the requested videoId.");
  }
  return validated;
}

/** Explicit reviewed shape: MongoDB internals and mutation-only timestamps never leave the API. */
export function wireAdminReplayVideo(row: VideoFeedDocument): Record<string, unknown> {
  return {
    videoId: row.videoId,
    playerId: row.playerId,
    url: row.url,
    urlHash: row.urlHash,
    createdAt: row.createdAt.toISOString(),
    expiresAt: row.expiresAt.toISOString(),
  };
}
