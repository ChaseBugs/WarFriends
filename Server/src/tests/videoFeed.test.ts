import assert from "node:assert/strict";
import test from "node:test";
import { createHash } from "node:crypto";
import { ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { videoFeedHandlers } from "../handlers/videoFeed";
import type { VideoFeedDocument, VideoFeedRateLimitDocument } from "../db";
import {
  normalizeVideoFeedUrl,
  validatedVideoFeedDocument,
  validatedVideoFeedRateLimit,
  videoFeedRateLimitKey,
} from "../services/videoFeedService";

test("AddVideoFeed accepts the hosted HTTP URL forms used by the recovered upload callback", () => {
  assert.equal(
    normalizeVideoFeedUrl("https://cdn.example.com/replays/match-1.mp4?token=abc#watch"),
    "https://cdn.example.com/replays/match-1.mp4?token=abc#watch",
  );
  // Historical Everyplay links may still use plain HTTP. The backend stores but never fetches
  // them, so retaining this protocol is compatibility without creating an SSRF request path.
  assert.equal(
    normalizeVideoFeedUrl("  http://videos.example.net/watch/legacy  "),
    "http://videos.example.net/watch/legacy",
  );
});

test("AddVideoFeed rejects executable, local-file, credential-bearing, and malformed URLs", () => {
  for (const value of [
    "javascript:alert(1)",
    "data:text/plain,video",
    "file:///tmp/video.mp4",
    "https://user:secret@example.com/video",
    "not a URL",
    "https://example.com/video\nInjected",
    "",
  ]) {
    assert.throws(
      () => normalizeVideoFeedUrl(value),
      (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
      value,
    );
  }
  assert.throws(
    () => normalizeVideoFeedUrl(`https://example.com/${"a".repeat(2_100)}`),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.UnknownAction,
  );
});

test("AddVideoFeed is an authenticated mutation with the recovered action number", () => {
  assert.equal(DbAction.AddVideoFeed, 3000);
  assert.equal(videoFeedHandlers[DbAction.AddVideoFeed]?.requiresAuth, true);
});

test("video-feed receipt authority binds URL hash, deterministic ID, and retention", () => {
  const createdAt = new Date("2026-07-21T00:00:00.000Z");
  const document: VideoFeedDocument = {
    videoId: "vf-04f562932917a3d3fd86dd9b756a7d0e",
    playerId: "player-1",
    urlHash: "5a5b30ab663b6c30b863a9d0be4a126d74d96a348c613d61d460502cb9b44c38",
    url: "https://cdn.example.com/replays/match-1.mp4",
    createdAt,
    updatedAt: createdAt,
    expiresAt: new Date(createdAt.getTime() + (365 * 86_400_000)),
  };
  // Use the exported proof to ensure test constants follow the same deterministic receipt tuple.
  assert.throws(() => validatedVideoFeedDocument(document), /Stored video-feed receipt is invalid/);
  const digest = (value: string): string => createHash("sha256").update(value).digest("hex");
  const valid = {
    ...document,
    urlHash: digest(document.url),
    videoId: `vf-${digest(`${document.playerId}\u0000${document.url}`).slice(0, 32)}`,
  };
  assert.equal(validatedVideoFeedDocument(valid, new Date(createdAt.getTime() + 1)), valid);
  assert.throws(
    () => validatedVideoFeedDocument({ ...valid, expiresAt: new Date(createdAt.getTime() + 1) }),
    /Stored video-feed receipt is invalid/,
  );
});

test("video-feed rolling authority binds its opaque key, bounded unique ledger, and exact lifetime", () => {
  const now = new Date("2026-07-22T00:00:00.000Z");
  const key = videoFeedRateLimitKey("player-1");
  const state: VideoFeedRateLimitDocument = {
    _id: key,
    key,
    entries: [{ urlHash: "a".repeat(64), reservedAt: new Date(now.getTime() - 1) }],
    updatedAt: now,
    expiresAt: new Date(now.getTime() + (48 * 60 * 60 * 1_000)),
  };
  assert.equal(validatedVideoFeedRateLimit(state, now, key), state);
  assert.throws(
    () => validatedVideoFeedRateLimit({ ...state, entries: [...state.entries, state.entries[0]] }, now, key),
    /Stored video-feed rate-limit authority is invalid/,
  );
  assert.throws(
    () => validatedVideoFeedRateLimit({ ...state, expiresAt: new Date(now.getTime() + 1) }, now, key),
    /Stored video-feed rate-limit authority is invalid/,
  );
  assert.throws(
    () => validatedVideoFeedRateLimit({ ...state, unexpected: true } as VideoFeedRateLimitDocument, now, key),
    /Stored video-feed rate-limit authority is invalid/,
  );
});

test("video-feed rolling authority proves admitted replay and saturated denial decisions", () => {
  const now = new Date("2026-07-22T00:00:00.000Z");
  const key = videoFeedRateLimitKey("player-2");
  const entries = Array.from({ length: 20 }, (_, index) => ({
    urlHash: index.toString(16).padStart(64, "0"),
    reservedAt: new Date(now.getTime() - index),
  }));
  const base = {
    _id: key,
    key,
    entries,
    updatedAt: now,
    expiresAt: new Date(now.getTime() + (48 * 60 * 60 * 1_000)),
    lastAttemptAt: now,
  };
  const replay: VideoFeedRateLimitDocument = {
    ...base,
    lastUrlHash: entries[0].urlHash,
    lastAdmitted: true,
  };
  assert.equal(validatedVideoFeedRateLimit(replay, now, key), replay);

  const denied: VideoFeedRateLimitDocument = {
    ...base,
    lastUrlHash: "f".repeat(64),
    lastAdmitted: false,
  };
  assert.equal(validatedVideoFeedRateLimit(denied, now, key), denied);
  assert.throws(
    () => validatedVideoFeedRateLimit({ ...denied, entries: entries.slice(1) }, now, key),
    /Stored video-feed rate-limit authority is invalid/,
  );
});
