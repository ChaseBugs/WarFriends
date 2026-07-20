import assert from "node:assert/strict";
import test from "node:test";
import { reportRateLimitAllows, reportRateLimitMaximum } from "../services/reportRateLimitService";

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
});
