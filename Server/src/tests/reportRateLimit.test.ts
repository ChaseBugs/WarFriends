import assert from "node:assert/strict";
import test from "node:test";
import {
  reportRateLimitAllows,
  reportRateLimitMaximum,
  validatedReportRateLimit,
} from "../services/reportRateLimitService";

test("report rate-limit policy clamps malformed deployment values", () => {
  assert.equal(reportRateLimitMaximum(Number.NaN), 5);
  assert.equal(reportRateLimitMaximum(0), 1);
  assert.equal(reportRateLimitMaximum(500), 100);
  assert.equal(reportRateLimitMaximum(5.9), 5);
});

test("only the configured number of atomic reservations are accepted", () => {
  assert.equal(reportRateLimitAllows(1, 5), true);
  assert.equal(reportRateLimitAllows(5, 5), true);
  assert.equal(reportRateLimitAllows(6, 5), false);
  assert.equal(reportRateLimitAllows(0, 5), false);
  assert.equal(reportRateLimitAllows(1.5, 5), false);
  assert.equal(reportRateLimitAllows(101, 100), false);
  assert.equal(reportRateLimitAllows(1, Number.NaN), false);
});

test("complete report rate-limit authority is bounded and ordered", () => {
  const now = new Date("2026-07-21T12:00:00.000Z");
  const valid = {
    key: "a".repeat(64),
    attemptCount: 101,
    windowStartedAt: new Date(now.getTime() - 3_599_999),
    updatedAt: now,
    expiresAt: new Date(now.getTime() + 7_200_000),
  };
  assert.equal(validatedReportRateLimit(valid, now, valid.key), valid);
  assert.throws(
    () => validatedReportRateLimit({ ...valid, attemptCount: 102 }, now, valid.key),
    /rate-limit authority is invalid/,
  );
  assert.throws(
    () => validatedReportRateLimit({ ...valid, windowStartedAt: new Date(now.getTime() + 1) }, now, valid.key),
    /rate-limit authority is invalid/,
  );
  assert.throws(
    () => validatedReportRateLimit({ ...valid, expiresAt: new Date(now.getTime() + 7_200_001) }, now, valid.key),
    /rate-limit authority is invalid/,
  );
});
