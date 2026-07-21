import assert from "node:assert/strict";
import test from "node:test";
import {
  reportDeduplicationKey,
  reportIsWithinDuplicateWindow,
  validatedReportDeduplication,
} from "../services/reportService";

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

test("durable report deduplication binds its winner, HMAC identity, and retention", () => {
  const createdAt = new Date("2026-07-21T12:00:00.000Z");
  const report = {
    reportId: "12345678-1234-4234-8234-123456789abc",
    reporterPlayerId: "reporter",
    kind: "cheat" as const,
    reportedPlayerId: "target",
    reportType: 2,
    message: "",
    evidence: { MyRank: "3" },
    status: "open" as const,
    createdAt,
  };
  const key = reportDeduplicationKey("reporter", "target", 2, "cheat");
  const row = {
    key,
    report,
    reportCreatedAt: createdAt,
    expiresAt: new Date(createdAt.getTime() + 1_200_000),
  };
  assert.equal(validatedReportDeduplication(row, report), report);
  assert.throws(
    () => validatedReportDeduplication({ ...row, key: "0".repeat(64) }, report),
    /deduplication authority is invalid/,
  );
  assert.throws(
    () => validatedReportDeduplication({ ...row, expiresAt: new Date(createdAt.getTime() + 1_200_001) }, report),
    /deduplication authority is invalid/,
  );
  assert.throws(
    () => validatedReportDeduplication({
      ...row,
      report: { ...report, reportedPlayerId: "other" },
    }, report),
    /deduplication authority is invalid/,
  );
});
