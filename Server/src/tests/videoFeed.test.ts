import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { videoFeedHandlers } from "../handlers/videoFeed";
import { normalizeVideoFeedUrl } from "../services/videoFeedService";

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

