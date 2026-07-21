import assert from "node:assert/strict";
import test from "node:test";
import type { Collection, Document } from "mongodb";
import type {
  ModerationRetentionRunDocument,
  PlayerAppealDocument,
} from "../db";
import {
  applyModerationRetentionInCollections,
  decodeModerationExportCursor,
  exportModerationRetentionPage,
  ModerationLifecycleInputError,
  moderationRetentionPolicy,
  moderationRetentionCutoffs,
  normalizeModerationExportLimit,
  normalizeModerationPreviewedAt,
  previewModerationRetention,
  validatedModerationRetentionRun,
  type ModerationRetentionPolicy,
} from "../services/moderationLifecycleService";
import type { PlayerReportDocument } from "../services/reportService";

const POLICY: ModerationRetentionPolicy = { reportDays: 30, appealDays: 60, sanctions: "indefinite" };

test("moderation retention uses one immutable exact startup policy", () => {
  assert.equal(Object.isFrozen(moderationRetentionPolicy()), true);
  assert.deepEqual(moderationRetentionPolicy(), {
    reportDays: 365,
    appealDays: 365,
    sanctions: "indefinite",
  });
  for (const policy of [
    { ...POLICY, reportDays: 29 },
    { ...POLICY, appealDays: 3_651 },
    { ...POLICY, reportDays: 30.5 },
    { ...POLICY, sanctions: "temporary" },
  ]) {
    assert.throws(
      () => moderationRetentionPolicy(policy as ModerationRetentionPolicy),
      /retention policy|must be an integer/,
    );
    assert.throws(
      () => moderationRetentionCutoffs(new Date("2026-07-21T00:00:00Z"), policy as ModerationRetentionPolicy),
      /retention policy|must be an integer/,
    );
  }
});

function report(overrides: Partial<PlayerReportDocument> = {}): PlayerReportDocument {
  const reviewedAt = new Date("2026-01-02T00:00:00Z");
  const row: PlayerReportDocument = {
    reportId: "123e4567-e89b-42d3-a456-426614174000",
    reporterPlayerId: "reporter-1",
    reportedPlayerId: "target-1",
    kind: "player",
    status: "resolved",
    reportType: 1,
    message: "reviewed report",
    evidence: {},
    createdAt: new Date("2026-01-01T00:00:00Z"),
    updatedAt: reviewedAt,
    reviewHistory: [{
      operationId: "review:retention:001",
      fromStatus: "open",
      toStatus: "resolved",
      actor: "retention-reviewer",
      note: "resolved before retention",
      createdAt: reviewedAt,
    }],
    ...overrides,
  };
  if (row.status === "open") {
    delete row.updatedAt;
    delete row.reviewHistory;
  }
  return row;
}

function appeal(overrides: Partial<PlayerAppealDocument> = {}): PlayerAppealDocument {
  const reviewedAt = new Date("2026-01-02T00:00:00Z");
  const row: PlayerAppealDocument = {
    _id: "223e4567-e89b-42d3-a456-426614174000",
    sanctionId: "323e4567-e89b-42d3-a456-426614174000",
    playerId: "player-1",
    status: "accepted",
    message: "Please review this sanction because the evidence is incorrect.",
    submissionOperationId: "appeal:player-1:001",
    createdAt: new Date("2026-01-01T00:00:00Z"),
    updatedAt: reviewedAt,
    reviewHistory: [{
      operationId: "appeal-review:retention:001",
      fromStatus: "open",
      toStatus: "accepted",
      actor: "retention-reviewer",
      note: "accepted before retention",
      createdAt: reviewedAt,
    }],
    ...overrides,
  };
  if (row.status === "open") {
    row.updatedAt = row.createdAt;
    delete row.reviewHistory;
  }
  return row;
}

function matchesRetention(
  row: { _id?: string; reportId?: string; status: string; createdAt: Date; updatedAt?: Date },
  filter: Record<string, unknown>,
): boolean {
  const statuses = (filter.status as { $in: string[] }).$in;
  const before = (filter.createdAt as { $lt: Date }).$lt;
  const previewedAt = (filter.updatedAt as { $lte: Date }).$lte;
  const reportIds = (filter.reportId as { $in?: string[] } | undefined)?.$in;
  const appealIds = (filter._id as { $in?: string[] } | undefined)?.$in;
  return (!reportIds || (row.reportId !== undefined && reportIds.includes(row.reportId)))
    && (!appealIds || (row._id !== undefined && appealIds.includes(row._id)))
    && statuses.includes(row.status) && row.createdAt < before &&
    row.updatedAt !== undefined && row.updatedAt <= previewedAt;
}

function mutableCollection<T extends { status: string; createdAt: Date; updatedAt?: Date }>(rows: T[]): Collection<T> {
  return {
    find(filter: Record<string, unknown>) {
      return { async toArray() { return rows.filter((row) => matchesRetention(row, filter)); } };
    },
    async countDocuments(filter: Record<string, unknown>) {
      return rows.filter((row) => matchesRetention(row, filter)).length;
    },
    async deleteMany(filter: Record<string, unknown>) {
      let deletedCount = 0;
      for (let index = rows.length - 1; index >= 0; index -= 1) {
        if (matchesRetention(rows[index]!, filter)) {
          rows.splice(index, 1);
          deletedCount += 1;
        }
      }
      return { acknowledged: true, deletedCount };
    },
  } as unknown as Collection<T>;
}

function runCollection(rows: ModerationRetentionRunDocument[]): Collection<ModerationRetentionRunDocument> {
  return {
    async findOne(filter: { operationId: string }) {
      return rows.find((row) => row.operationId === filter.operationId) ?? null;
    },
    async insertOne(row: ModerationRetentionRunDocument) {
      rows.push(row);
      return { acknowledged: true, insertedId: row._id };
    },
  } as unknown as Collection<ModerationRetentionRunDocument>;
}

function exportCollection<T extends Document>(
  rows: T[],
  capture: { filter?: Record<string, unknown>; sort?: Record<string, number>; limit?: number },
): Collection<T> {
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
  } as unknown as Collection<T>;
}

test("retention timestamps and export limits reject unsafe operator input", () => {
  const now = new Date("2026-07-21T00:00:00Z");
  assert.equal(normalizeModerationPreviewedAt("2026-07-20T00:00:00.000Z", now).toISOString(),
    "2026-07-20T00:00:00.000Z");
  assert.equal(normalizeModerationExportLimit(undefined), 100);
  assert.equal(normalizeModerationExportLimit("500"), 500);
  assert.throws(() => normalizeModerationPreviewedAt("not-a-date", now), ModerationLifecycleInputError);
  assert.throws(
    () => normalizeModerationPreviewedAt("2026-07-21T00:02:00.000Z", now),
    ModerationLifecycleInputError,
  );
  assert.throws(() => normalizeModerationExportLimit(501), ModerationLifecycleInputError);
});

test("retention receipts bind safe counts and globally bounded exact cutoffs", () => {
  const previewedAt = new Date("2026-07-21T00:00:00Z");
  const createdAt = new Date("2026-07-21T01:00:00Z");
  const run: ModerationRetentionRunDocument = {
    _id: "423e4567-e89b-42d3-a456-426614174000",
    operationId: "moderation-retention:receipt:001",
    actor: "privacy-operator@example.test",
    previewedAt,
    reportBefore: new Date(previewedAt.getTime() - 30 * 86_400_000),
    appealBefore: new Date(previewedAt.getTime() - 60 * 86_400_000),
    deletedReports: 4,
    deletedAppeals: 2,
    createdAt,
  };
  assert.equal(validatedModerationRetentionRun(run, createdAt), run);
  assert.throws(
    () => validatedModerationRetentionRun({ ...run, deletedReports: Number.NaN }, createdAt),
    /retention receipt authority is invalid/,
  );
  assert.throws(
    () => validatedModerationRetentionRun({ ...run, reportBefore: new Date(previewedAt.getTime() - 1) }, createdAt),
    /retention receipt authority is invalid/,
  );
});

test("preview counts only terminal records older than each configured cutoff", async () => {
  const previewedAt = new Date("2026-07-21T00:00:00Z");
  const cutoffs = moderationRetentionCutoffs(previewedAt, POLICY);
  assert.equal(cutoffs.reportBefore.toISOString(), "2026-06-21T00:00:00.000Z");
  assert.equal(cutoffs.appealBefore.toISOString(), "2026-05-22T00:00:00.000Z");

  const reports = [
    report(),
    report({ reportId: "123e4567-e89b-42d3-a456-426614174001", status: "open" }),
    report({ reportId: "123e4567-e89b-42d3-a456-426614174002", createdAt: new Date("2026-07-01T00:00:00Z") }),
  ];
  const appeals = [
    appeal(),
    appeal({ _id: "223e4567-e89b-42d3-a456-426614174001", status: "reviewing" }),
    appeal({ _id: "223e4567-e89b-42d3-a456-426614174002", createdAt: new Date("2026-06-01T00:00:00Z") }),
  ];
  const preview = await previewModerationRetention(
    previewedAt,
    mutableCollection(reports) as unknown as Collection<Document>,
    mutableCollection(appeals),
    POLICY,
  );
  assert.equal(preview.eligibleReports, 1);
  assert.equal(preview.eligibleAppeals, 1);
});

test("retention cannot count or delete a forged terminal report without its audit proof", async () => {
  const corrupt = report();
  delete corrupt.reviewHistory;
  const reports = [corrupt];
  const runs: ModerationRetentionRunDocument[] = [];
  await assert.rejects(
    applyModerationRetentionInCollections(
      {
        previewedAt: new Date("2026-07-21T00:00:00Z"),
        actor: "privacy-operator@example.test",
        operationId: "moderation-retention:corrupt:001",
      },
      new Date("2026-07-21T01:00:00Z"),
      mutableCollection(reports) as unknown as Collection<Document>,
      mutableCollection<PlayerAppealDocument>([]),
      runCollection(runs),
      undefined,
      POLICY,
    ),
    /moderation report authority is invalid/,
  );
  assert.equal(reports.length, 1);
  assert.equal(runs.length, 0);
});

test("retention cannot count or delete a forged terminal appeal without its audit proof", async () => {
  const corrupt = appeal();
  delete corrupt.reviewHistory;
  const appeals = [corrupt];
  const runs: ModerationRetentionRunDocument[] = [];
  await assert.rejects(
    applyModerationRetentionInCollections(
      {
        previewedAt: new Date("2026-07-21T00:00:00Z"),
        actor: "privacy-operator@example.test",
        operationId: "moderation-retention:corrupt-appeal:001",
      },
      new Date("2026-07-21T01:00:00Z"),
      mutableCollection<PlayerReportDocument>([]) as unknown as Collection<Document>,
      mutableCollection(appeals),
      runCollection(runs),
      undefined,
      POLICY,
    ),
    /player appeal authority is invalid/,
  );
  assert.equal(appeals.length, 1);
  assert.equal(runs.length, 0);
});

test("bounded export pages use kind-bound stable cursors and the frozen preview filter", async () => {
  const previewedAt = new Date("2026-07-21T00:00:00Z");
  const older = report();
  const newer = report({
    reportId: "123e4567-e89b-42d3-a456-426614174001",
    createdAt: new Date("2026-01-02T00:00:00Z"),
  });
  const capture: { filter?: Record<string, unknown>; sort?: Record<string, number>; limit?: number } = {};
  const page = await exportModerationRetentionPage(
    { kind: "reports", previewedAt, limit: 1 },
    exportCollection([newer, older], capture) as unknown as Collection<Document>,
    exportCollection<PlayerAppealDocument>([], {}),
    POLICY,
  );
  assert.deepEqual(page.reportRows?.map((row) => row.reportId), [newer.reportId]);
  assert.ok(page.nextCursor);
  assert.deepEqual(capture.sort, { createdAt: -1, reportId: -1 });
  assert.equal(capture.limit, 2);
  assert.deepEqual(capture.filter, {
    status: { $in: ["resolved", "dismissed"] },
    createdAt: { $lt: new Date("2026-06-21T00:00:00Z") },
    updatedAt: { $lte: previewedAt },
  });
  assert.equal(decodeModerationExportCursor(page.nextCursor, "reports")?.id, newer.reportId);
  assert.throws(() => decodeModerationExportCursor(page.nextCursor, "appeals"), ModerationLifecycleInputError);
});

test("apply deletes the frozen terminal set once and retains open records and sanctions by design", async () => {
  const reports = [
    report(),
    report({ reportId: "123e4567-e89b-42d3-a456-426614174001", status: "open" }),
    report({
      reportId: "123e4567-e89b-42d3-a456-426614174002",
      updatedAt: new Date("2026-07-21T00:30:00Z"),
    }),
  ];
  const appeals = [
    appeal(),
    appeal({ _id: "223e4567-e89b-42d3-a456-426614174001", status: "reviewing" }),
    appeal({
      _id: "223e4567-e89b-42d3-a456-426614174002",
      updatedAt: new Date("2026-07-21T00:30:00Z"),
    }),
  ];
  const runs: ModerationRetentionRunDocument[] = [];
  const input = {
    previewedAt: new Date("2026-07-21T00:00:00Z"),
    actor: "privacy-operator@example.test",
    operationId: "moderation-retention:2026-07-21:001",
  };
  const reportRows = mutableCollection(reports) as unknown as Collection<Document>;
  const appealRows = mutableCollection(appeals);
  const runRows = runCollection(runs);
  const first = await applyModerationRetentionInCollections(
    input,
    new Date("2026-07-21T01:00:00Z"),
    reportRows,
    appealRows,
    runRows,
    undefined,
    POLICY,
  );
  const replay = await applyModerationRetentionInCollections(
    input,
    new Date("2026-07-21T02:00:00Z"),
    reportRows,
    appealRows,
    runRows,
    undefined,
    POLICY,
  );

  assert.equal(first.replayed, false);
  assert.equal(replay.replayed, true);
  assert.equal(first.run.deletedReports, 1);
  assert.equal(first.run.deletedAppeals, 1);
  assert.deepEqual(reports.map((row) => row.reportId), [
    "123e4567-e89b-42d3-a456-426614174001",
    "123e4567-e89b-42d3-a456-426614174002",
  ]);
  assert.deepEqual(appeals.map((row) => row._id), [
    "223e4567-e89b-42d3-a456-426614174001",
    "223e4567-e89b-42d3-a456-426614174002",
  ]);
  assert.equal(runs.length, 1);
  await assert.rejects(
    applyModerationRetentionInCollections(
      { ...input, actor: "another-operator@example.test" },
      new Date("2026-07-21T03:00:00Z"),
      reportRows,
      appealRows,
      runRows,
      undefined,
      POLICY,
    ),
    (error: unknown) => error instanceof ModerationLifecycleInputError && error.httpStatus === 409,
  );
});
