import assert from "node:assert/strict";
import test from "node:test";
import { reportDeduplicationKey, reportIsWithinDuplicateWindow } from "../services/reportService";

test("report deduplication identity is stable and binds all semantic dimensions", () => {
  const base = reportDeduplicationKey("reporter", "target", 2, "cheat");
  assert.equal(base, reportDeduplicationKey("reporter", "target", 2, "cheat"));
  assert.notEqual(base, reportDeduplicationKey("other", "target", 2, "cheat"));
  assert.notEqual(base, reportDeduplicationKey("reporter", "other", 2, "cheat"));
  assert.notEqual(base, reportDeduplicationKey("reporter", "target", 3, "cheat"));
  assert.notEqual(base, reportDeduplicationKey("reporter", "target", 2, "player"));
});

test("the logical ten-minute replay boundary is independent of TTL cleanup timing", () => {
  const created = new Date("2026-07-21T00:00:00.000Z");
  assert.equal(reportIsWithinDuplicateWindow(created, new Date(created.getTime() + 599_999)), true);
  assert.equal(reportIsWithinDuplicateWindow(created, new Date(created.getTime() + 600_000)), false);
  assert.equal(reportIsWithinDuplicateWindow(created, new Date(created.getTime() - 1)), false);
});
