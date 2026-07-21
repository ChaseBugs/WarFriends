import assert from "node:assert/strict";
import test from "node:test";
import type { Collection, Document } from "mongodb";
import type { PlayerReportDocument, PlayerReportReviewEntry } from "../services/reportService";
import {
  decodeReportCursor,
  encodeReportCursor,
  listModerationReports,
  normalizeReportListInput,
  normalizeReviewNote,
  reportTransitionAllowed,
  ReportReviewInputError,
  reviewPlayerReport,
} from "../services/reportReviewService";

function report(overrides: Partial<PlayerReportDocument> = {}): PlayerReportDocument {
  return {
    reportId: "123e4567-e89b-42d3-a456-426614174000",
    reporterPlayerId: "reporter-1",
    reportedPlayerId: "target-1",
    kind: "cheat",
    status: "open",
    reportType: 2,
    message: "suspicious result",
    evidence: {},
    createdAt: new Date("2026-07-21T00:00:00Z"),
    ...overrides,
  };
}

function mutationCollection(rows: PlayerReportDocument[]): Collection<Document> {
  return {
    async findOne(filter: Record<string, unknown>) {
      if (typeof filter.reportId === "string") {
        return rows.find((row) => row.reportId === filter.reportId) ?? null;
      }
      const operationId = filter["reviewHistory.operationId"];
      if (typeof operationId === "string") {
        return rows.find((row) => row.reviewHistory?.some((entry) => entry.operationId === operationId)) ?? null;
      }
      return null;
    },
    async findOneAndUpdate(
      filter: Record<string, unknown>,
      update: { $set: { status: PlayerReportDocument["status"]; updatedAt: Date }; $push: { reviewHistory: PlayerReportReviewEntry } },
    ) {
      const row = rows.find((candidate) =>
        candidate.reportId === filter.reportId &&
        candidate.status === filter.status &&
        !candidate.reviewHistory?.some((entry) => entry.operationId === update.$push.reviewHistory.operationId),
      );
      if (!row) return null;
      row.status = update.$set.status;
      row.updatedAt = update.$set.updatedAt;
      row.reviewHistory = [...(row.reviewHistory ?? []), update.$push.reviewHistory];
      return row;
    },
  } as unknown as Collection<Document>;
}

function listCollection(
  rows: PlayerReportDocument[],
  capture: { filter?: Record<string, unknown>; sort?: Record<string, number>; limit?: number },
): Collection<Document> {
  return {
    find(filter: Record<string, unknown>) {
      capture.filter = filter;
      const cursor = {
        sort(sort: Record<string, number>) {
          capture.sort = sort;
          return cursor;
        },
        limit(limit: number) {
          capture.limit = limit;
          return cursor;
        },
        async toArray() { return rows; },
      };
      return cursor;
    },
  } as unknown as Collection<Document>;
}

test("report review transitions preserve terminal-state and expected-state rules", () => {
  assert.equal(reportTransitionAllowed("open", "reviewing"), true);
  assert.equal(reportTransitionAllowed("open", "resolved"), true);
  assert.equal(reportTransitionAllowed("reviewing", "dismissed"), true);
  assert.equal(reportTransitionAllowed("reviewing", "open"), false);
  assert.equal(reportTransitionAllowed("resolved", "reviewing"), false);
  assert.equal(reportTransitionAllowed("dismissed", "resolved"), false);
});

test("terminal review decisions require a bounded audit note", () => {
  assert.equal(normalizeReviewNote(undefined, false), "");
  assert.equal(normalizeReviewNote("  assigned   to fraud team ", false), "assigned to fraud team");
  assert.equal(normalizeReviewNote("confirmed evidence", true), "confirmed evidence");
  assert.throws(() => normalizeReviewNote(undefined, true), ReportReviewInputError);
  assert.throws(() => normalizeReviewNote("x".repeat(1001), true), ReportReviewInputError);
});

test("moderation cursors round-trip an exact stable createdAt/reportId boundary", () => {
  const row = report();
  const encoded = encodeReportCursor(row);
  const decoded = decodeReportCursor(encoded);
  assert.equal(decoded?.createdAt.toISOString(), row.createdAt.toISOString());
  assert.equal(decoded?.reportId, row.reportId);
  assert.throws(() => decodeReportCursor("not+base64"), ReportReviewInputError);
});

test("report list filters and limits reject malformed operator input", () => {
  assert.deepEqual(normalizeReportListInput({ status: "open", kind: "cheat", limit: "25" }), {
    status: "open",
    kind: "cheat",
    reportedPlayerId: undefined,
    reporterPlayerId: undefined,
    cursor: undefined,
    limit: 25,
  });
  assert.throws(() => normalizeReportListInput({ status: "deleted" }), ReportReviewInputError);
  assert.throws(() => normalizeReportListInput({ kind: "other" }), ReportReviewInputError);
  assert.throws(() => normalizeReportListInput({ limit: 101 }), ReportReviewInputError);
});

test("moderation queue uses a newest-first tie-break cursor without offset drift", async () => {
  const newer = report({ reportId: "123e4567-e89b-42d3-a456-426614174001" });
  const older = report({
    reportId: "123e4567-e89b-42d3-a456-426614174000",
    createdAt: new Date("2026-07-20T23:59:00Z"),
  });
  const capture: { filter?: Record<string, unknown>; sort?: Record<string, number>; limit?: number } = {};
  const firstPage = await listModerationReports(
    { status: "open", limit: 1 },
    listCollection([newer, older], capture),
  );
  assert.deepEqual(firstPage.reports.map((row) => row.reportId), [newer.reportId]);
  assert.ok(firstPage.nextCursor);
  assert.deepEqual(capture.filter, { status: "open" });
  assert.deepEqual(capture.sort, { createdAt: -1, reportId: -1 });
  assert.equal(capture.limit, 2);

  const secondCapture: typeof capture = {};
  await listModerationReports(
    { status: "open", limit: 1, cursor: firstPage.nextCursor },
    listCollection([older], secondCapture),
  );
  assert.deepEqual(secondCapture.filter, {
    status: "open",
    $or: [
      { createdAt: { $lt: newer.createdAt } },
      { createdAt: newer.createdAt, reportId: { $lt: newer.reportId } },
    ],
  });
});

test("review operations append one audit entry and replay without a second mutation", async () => {
  const rows = [report()];
  const collection = mutationCollection(rows);
  const input = {
    reportId: rows[0]!.reportId,
    expectedStatus: "open" as const,
    status: "reviewing" as const,
    actor: "moderator@example.test",
    note: "assigned to fraud team",
    operationId: "review:report:0001",
  };
  const reviewedAt = new Date("2026-07-21T01:00:00Z");
  const first = await reviewPlayerReport(input, reviewedAt, collection);
  const replay = await reviewPlayerReport(input, new Date("2026-07-21T02:00:00Z"), collection);

  assert.equal(first.replayed, false);
  assert.equal(replay.replayed, true);
  assert.equal(rows[0]!.status, "reviewing");
  assert.equal(rows[0]!.reviewHistory?.length, 1);
  assert.equal(rows[0]!.reviewHistory?.[0]?.createdAt.toISOString(), reviewedAt.toISOString());
});

test("review rejects stale snapshots, terminal rewrites, and changed retry intent", async () => {
  const initialEntry: PlayerReportReviewEntry = {
    operationId: "review:report:0001",
    fromStatus: "open",
    toStatus: "reviewing",
    actor: "moderator@example.test",
    note: "assigned",
    createdAt: new Date("2026-07-21T01:00:00Z"),
  };
  const rows = [report({ status: "reviewing", reviewHistory: [initialEntry] })];
  const collection = mutationCollection(rows);

  await assert.rejects(
    reviewPlayerReport({
      reportId: rows[0]!.reportId,
      expectedStatus: "open",
      status: "resolved",
      actor: "moderator@example.test",
      note: "confirmed",
      operationId: "review:report:0002",
    }, new Date(), collection),
    (error: unknown) => error instanceof ReportReviewInputError && error.httpStatus === 409,
  );
  await assert.rejects(
    reviewPlayerReport({
      reportId: rows[0]!.reportId,
      expectedStatus: "open",
      status: "dismissed",
      actor: "moderator@example.test",
      note: "changed retry",
      operationId: initialEntry.operationId,
    }, new Date(), collection),
    (error: unknown) => error instanceof ReportReviewInputError && error.httpStatus === 409,
  );

  rows[0]!.status = "resolved";
  await assert.rejects(
    reviewPlayerReport({
      reportId: rows[0]!.reportId,
      expectedStatus: "resolved",
      status: "dismissed",
      actor: "moderator@example.test",
      note: "cannot rewrite terminal decision",
      operationId: "review:report:0003",
    }, new Date(), collection),
    (error: unknown) => error instanceof ReportReviewInputError && error.httpStatus === 409,
  );
});

test("service-level terminal review cannot bypass the required audit note", async () => {
  const rows = [report()];
  await assert.rejects(
    reviewPlayerReport({
      reportId: rows[0]!.reportId,
      expectedStatus: "open",
      status: "resolved",
      actor: "moderator@example.test",
      note: "",
      operationId: "review:report:note-check",
    }, new Date(), mutationCollection(rows)),
    (error: unknown) => error instanceof ReportReviewInputError && error.httpStatus === 400,
  );
  assert.equal(rows[0]!.status, "open");
  assert.equal(rows[0]!.reviewHistory, undefined);
});
