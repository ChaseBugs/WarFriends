import assert from "node:assert/strict";
import { createHash } from "node:crypto";
import test from "node:test";
import type { Collection, Filter } from "mongodb";
import type { VideoFeedDocument } from "../db";
import {
  findAdminReplayVideo,
  listAdminReplayVideos,
  normalizeAdminReplayVideoId,
  normalizeAdminReplayVideoListInput,
  wireAdminReplayVideo,
} from "../services/adminReplayVideoService";

const NOW = new Date("2030-03-17T17:46:40.000Z");
const RETENTION_MS = 365 * 24 * 60 * 60 * 1_000;

function digest(value: string): string {
  return createHash("sha256").update(value, "utf8").digest("hex");
}

function replayVideo(): VideoFeedDocument {
  const playerId = "replay-player";
  const url = "https://cdn.example.com/replays/review-1.mp4";
  const createdAt = new Date(NOW.getTime() - 1_000);
  return {
    videoId: `vf-${digest(`${playerId}\u0000${url}`).slice(0, 32)}`,
    playerId,
    urlHash: digest(url),
    url,
    createdAt,
    updatedAt: createdAt,
    expiresAt: new Date(createdAt.getTime() + RETENTION_MS),
  };
}

function fakeCollection(
  rows: VideoFeedDocument[],
  capture?: (filter: Filter<VideoFeedDocument>) => void,
): Collection<VideoFeedDocument> {
  const cursor = {
    sort: () => cursor,
    limit: () => cursor,
    toArray: async () => rows,
  };
  return {
    find: (filter: Filter<VideoFeedDocument>) => {
      capture?.(filter);
      return cursor;
    },
  } as unknown as Collection<VideoFeedDocument>;
}

test("admin replay-video query input is exact and bounded", () => {
  assert.deepEqual(normalizeAdminReplayVideoListInput({}, NOW), {
    playerId: null,
    limit: 50,
    cursor: null,
    decodedCursor: null,
  });
  assert.throws(
    () => normalizeAdminReplayVideoListInput({ limit: "01" }, NOW),
    /integer from 1 through 100/,
  );
  assert.throws(
    () => normalizeAdminReplayVideoListInput({ playerId: " padded " }, NOW),
    /playerId is invalid/,
  );
  assert.throws(
    () => normalizeAdminReplayVideoListInput({ playerId: "x".repeat(161) }, NOW),
    /playerId is invalid/,
  );
});

test("admin replay videos use a stable player-bound descending cursor", async () => {
  const row = replayVideo();
  const first = await listAdminReplayVideos(
    { playerId: row.playerId, limit: 1, cursor: null },
    NOW,
    fakeCollection([row]),
  );
  assert.equal(first.items[0], row);
  assert.equal(typeof first.nextCursor, "string");

  let captured: Filter<VideoFeedDocument> | undefined;
  await listAdminReplayVideos(
    { playerId: row.playerId, limit: 1, cursor: first.nextCursor },
    NOW,
    fakeCollection([], (filter) => { captured = filter; }),
  );
  assert.equal(captured?.playerId, row.playerId);
  assert.deepEqual(captured?.expiresAt, { $gt: NOW });
  assert.equal(Array.isArray(captured?.$or), true);

  assert.throws(
    () => normalizeAdminReplayVideoListInput({ cursor: first.nextCursor }, NOW),
    /does not match this query/,
  );
});

test("admin replay-video pages validate every selected receipt and application-time expiry", async () => {
  const row = replayVideo();
  await assert.rejects(
    listAdminReplayVideos(
      { playerId: null, limit: 50, cursor: null },
      NOW,
      fakeCollection([{ ...row, urlHash: "0".repeat(64) }]),
    ),
    /Stored video-feed receipt is invalid/,
  );

  await assert.rejects(
    listAdminReplayVideos(
      { playerId: null, limit: 50, cursor: null },
      new Date(row.expiresAt.getTime()),
      fakeCollection([row]),
    ),
    /Stored video-feed receipt is invalid/,
  );
});

test("admin replay-video detail lookup resolves only an exact unexpired videoId", async () => {
  const row = replayVideo();
  let captured: Filter<VideoFeedDocument> | undefined;
  const collection = {
    findOne: async (filter: Filter<VideoFeedDocument>) => {
      captured = filter;
      return row;
    },
  } as unknown as Collection<VideoFeedDocument>;
  assert.equal(normalizeAdminReplayVideoId(row.videoId), row.videoId);
  assert.equal(await findAdminReplayVideo(row.videoId, NOW, collection), row);
  assert.deepEqual(captured, { videoId: row.videoId, expiresAt: { $gt: NOW } });
  assert.throws(() => normalizeAdminReplayVideoId(row.videoId.toUpperCase()), /videoId is invalid/);

  const missing = { findOne: async () => null } as unknown as Collection<VideoFeedDocument>;
  assert.equal(await findAdminReplayVideo(row.videoId, NOW, missing), null);

  const different = replayVideo();
  different.playerId = "other-player";
  different.videoId = `vf-${digest(`${different.playerId}\u0000${different.url}`).slice(0, 32)}`;
  const mismatched = { findOne: async () => different } as unknown as Collection<VideoFeedDocument>;
  await assert.rejects(
    findAdminReplayVideo(row.videoId, NOW, mismatched),
    /does not match the requested videoId/,
  );
});

test("admin replay-video wire output exposes reviewed metadata only", () => {
  const row = replayVideo();
  assert.deepEqual(wireAdminReplayVideo(row), {
    videoId: row.videoId,
    playerId: row.playerId,
    url: row.url,
    urlHash: row.urlHash,
    createdAt: row.createdAt.toISOString(),
    expiresAt: row.expiresAt.toISOString(),
  });
  assert.equal("updatedAt" in wireAdminReplayVideo(row), false);
  assert.equal("_id" in wireAdminReplayVideo(row), false);
});
