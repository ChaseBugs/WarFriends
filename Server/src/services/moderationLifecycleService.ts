import { randomUUID } from "crypto";
import type { ClientSession, Collection, Document, Filter } from "mongodb";
import { config } from "../config";
import {
  moderationRetentionRuns,
  playerAppeals,
  reports,
  withMongoTransaction,
  type ModerationRetentionRunDocument,
  type PlayerAppealDocument,
} from "../db";
import { validatedModerationReport, type PlayerReportDocument } from "./reportService";

const MILLISECONDS_PER_DAY = 86_400_000;
const MINIMUM_RETENTION_DAYS = 30;
const MAXIMUM_RETENTION_DAYS = 3_650;
const DEFAULT_EXPORT_PAGE_SIZE = 100;
const MAXIMUM_EXPORT_PAGE_SIZE = 500;
const OPERATION_ID_PATTERN = /^[A-Za-z0-9._:-]{8,128}$/u;
const UUID_V4_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;

export type ModerationRetentionKind = "reports" | "appeals";

export class ModerationLifecycleInputError extends Error {
  constructor(
    message: string,
    readonly httpStatus: 400 | 409,
  ) {
    super(message);
    this.name = "ModerationLifecycleInputError";
  }
}

export interface ModerationRetentionPolicy {
  reportDays: number;
  appealDays: number;
  sanctions: "indefinite";
}

export interface ModerationRetentionPreview {
  previewedAt: Date;
  reportBefore: Date;
  appealBefore: Date;
  eligibleReports: number;
  eligibleAppeals: number;
}

export interface ModerationRetentionMutationResult {
  run: ModerationRetentionRunDocument;
  replayed: boolean;
}

export interface ModerationRetentionApplyInput {
  previewedAt: Date;
  actor: string;
  operationId: string;
}

export interface ModerationExportInput {
  kind: ModerationRetentionKind;
  previewedAt: Date;
  cursor?: string;
  limit: number;
}

export interface ModerationExportPage {
  kind: ModerationRetentionKind;
  reportRows?: PlayerReportDocument[];
  appealRows?: PlayerAppealDocument[];
  nextCursor?: string;
}

interface ModerationExportCursor {
  kind: ModerationRetentionKind;
  createdAt: Date;
  id: string;
}

function configuredRetentionDays(value: number, name: string): number {
  if (!Number.isSafeInteger(value) || value < MINIMUM_RETENTION_DAYS || value > MAXIMUM_RETENTION_DAYS) {
    throw new Error(`${name} must be an integer from ${MINIMUM_RETENTION_DAYS} to ${MAXIMUM_RETENTION_DAYS}.`);
  }
  return value;
}

/**
 * Return the deploy-time lifecycle policy after validating its safety bounds.
 *
 * The recovered clients define report submission and banned-dialog behavior, but no storage
 * lifecycle. These defaults are therefore explicit backend policy. Account sanctions remain
 * indefinite because deleting the enforcement audit can make later operator decisions ambiguous.
 */
export function moderationRetentionPolicy(): ModerationRetentionPolicy {
  return {
    reportDays: configuredRetentionDays(
      config.moderationReportRetentionDays,
      "MODERATION_REPORT_RETENTION_DAYS",
    ),
    appealDays: configuredRetentionDays(
      config.moderationAppealRetentionDays,
      "MODERATION_APPEAL_RETENTION_DAYS",
    ),
    sanctions: "indefinite",
  };
}

export function normalizeModerationPreviewedAt(value: unknown, now = new Date()): Date {
  if (typeof value !== "string" || value.length < 20 || value.length > 64) {
    throw new ModerationLifecycleInputError("previewedAt must be an ISO-8601 timestamp.", 400);
  }
  const parsed = new Date(value);
  if (Number.isNaN(parsed.getTime())) {
    throw new ModerationLifecycleInputError("previewedAt must be an ISO-8601 timestamp.", 400);
  }
  // A future preview could move a cutoff forward and delete data that was not present when the
  // operator inspected the counts. One minute tolerates ordinary clock skew without widening it.
  if (parsed.getTime() > now.getTime() + 60_000) {
    throw new ModerationLifecycleInputError("previewedAt cannot be in the future.", 400);
  }
  return parsed;
}

export function normalizeModerationRetentionKind(value: unknown): ModerationRetentionKind {
  if (value !== "reports" && value !== "appeals") {
    throw new ModerationLifecycleInputError("kind must be reports or appeals.", 400);
  }
  return value;
}

export function normalizeModerationLifecycleActor(value: unknown): string {
  if (typeof value !== "string") {
    throw new ModerationLifecycleInputError("X-Admin-Actor must be a string.", 400);
  }
  const actor = value.trim().replace(/\s+/gu, " ");
  if (actor.length < 1 || actor.length > 100) {
    throw new ModerationLifecycleInputError("X-Admin-Actor must contain 1-100 characters.", 400);
  }
  return actor;
}

export function normalizeModerationLifecycleOperationId(value: unknown): string {
  const operationId = typeof value === "string" ? value.trim() : "";
  if (!OPERATION_ID_PATTERN.test(operationId)) {
    throw new ModerationLifecycleInputError(
      "Idempotency-Key must contain 8-128 letters, digits, dots, underscores, colons, or hyphens.",
      400,
    );
  }
  return operationId;
}

export function normalizeModerationExportLimit(value: unknown): number {
  if (value === undefined || value === null || value === "") return DEFAULT_EXPORT_PAGE_SIZE;
  const limit = Number(value);
  if (!Number.isSafeInteger(limit) || limit < 1 || limit > MAXIMUM_EXPORT_PAGE_SIZE) {
    throw new ModerationLifecycleInputError(`limit must be an integer from 1 to ${MAXIMUM_EXPORT_PAGE_SIZE}.`, 400);
  }
  return limit;
}

export function moderationRetentionCutoffs(
  previewedAt: Date,
  policy = moderationRetentionPolicy(),
): Pick<ModerationRetentionPreview, "reportBefore" | "appealBefore"> {
  return {
    reportBefore: new Date(previewedAt.getTime() - policy.reportDays * MILLISECONDS_PER_DAY),
    appealBefore: new Date(previewedAt.getTime() - policy.appealDays * MILLISECONDS_PER_DAY),
  };
}

export function reportRetentionFilter(before: Date, previewedAt: Date): Filter<Document> {
  return {
    status: { $in: ["resolved", "dismissed"] },
    createdAt: { $lt: before },
    updatedAt: { $lte: previewedAt },
  };
}

export function appealRetentionFilter(before: Date, previewedAt: Date): Filter<PlayerAppealDocument> {
  return {
    status: { $in: ["accepted", "rejected", "withdrawn"] },
    createdAt: { $lt: before },
    updatedAt: { $lte: previewedAt },
  };
}

async function validatedEligibleReports(
  collection: Collection<Document>,
  filter: Filter<Document>,
  authorityTime: Date,
  session?: ClientSession,
): Promise<PlayerReportDocument[]> {
  // Retention is intentionally operator-driven and transactional. Reading the complete eligible
  // set here lets application authority prove every terminal lifecycle before any destructive
  // write. The later delete remains filter-bound as well as ID-bound, so a concurrent status/date
  // change cannot broaden what the frozen preview authorized.
  const rows = await collection.find(filter, sessionOptions(session)).toArray() as unknown as PlayerReportDocument[];
  return rows.map((report) => validatedModerationReport(report, authorityTime));
}

/** Count exactly what a later apply call with this timestamp is allowed to remove. */
export async function previewModerationRetention(
  previewedAt = new Date(),
  reportCollection: Collection<Document> = reports(),
  appealCollection: Collection<PlayerAppealDocument> = playerAppeals(),
  policy = moderationRetentionPolicy(),
): Promise<ModerationRetentionPreview> {
  const cutoffs = moderationRetentionCutoffs(previewedAt, policy);
  const [eligibleReportRows, eligibleAppeals] = await Promise.all([
    validatedEligibleReports(
      reportCollection,
      reportRetentionFilter(cutoffs.reportBefore, previewedAt),
      previewedAt,
    ),
    appealCollection.countDocuments(appealRetentionFilter(cutoffs.appealBefore, previewedAt)),
  ]);
  return { previewedAt, ...cutoffs, eligibleReports: eligibleReportRows.length, eligibleAppeals };
}

function encodeModerationExportCursor(cursor: ModerationExportCursor): string {
  return Buffer.from(JSON.stringify({
    kind: cursor.kind,
    createdAt: cursor.createdAt.toISOString(),
    id: cursor.id,
  }), "utf8").toString("base64url");
}

export function decodeModerationExportCursor(
  value: unknown,
  expectedKind: ModerationRetentionKind,
): ModerationExportCursor | undefined {
  if (value === undefined || value === null || value === "") return undefined;
  if (typeof value !== "string" || value.length > 512 || !/^[A-Za-z0-9_-]+$/u.test(value)) {
    throw new ModerationLifecycleInputError("cursor is invalid.", 400);
  }
  try {
    const parsed = JSON.parse(Buffer.from(value, "base64url").toString("utf8")) as Record<string, unknown>;
    const kind = normalizeModerationRetentionKind(parsed.kind);
    const createdAt = typeof parsed.createdAt === "string" ? new Date(parsed.createdAt) : new Date(Number.NaN);
    const id = typeof parsed.id === "string" ? parsed.id : "";
    if (kind !== expectedKind || Number.isNaN(createdAt.getTime()) || !UUID_V4_PATTERN.test(id)) {
      throw new Error("invalid cursor payload");
    }
    return { kind, createdAt, id };
  } catch {
    throw new ModerationLifecycleInputError("cursor is invalid.", 400);
  }
}

/**
 * Export one stable page from the exact terminal-record set eligible at previewedAt.
 *
 * The cursor embeds the record kind so an appeal cursor cannot silently skip report rows. Export
 * happens before purge and remains bounded; the independent database backup remains the complete
 * disaster-recovery mechanism rather than an unbounded HTTP response.
 */
export async function exportModerationRetentionPage(
  input: ModerationExportInput,
  reportCollection: Collection<Document> = reports(),
  appealCollection: Collection<PlayerAppealDocument> = playerAppeals(),
  policy = moderationRetentionPolicy(),
): Promise<ModerationExportPage> {
  const cursor = decodeModerationExportCursor(input.cursor, input.kind);
  const cutoffs = moderationRetentionCutoffs(input.previewedAt, policy);
  if (input.kind === "reports") {
    const filter = reportRetentionFilter(cutoffs.reportBefore, input.previewedAt);
    if (cursor) {
      filter.$or = [
        { createdAt: { $lt: cursor.createdAt } },
        { createdAt: cursor.createdAt, reportId: { $lt: cursor.id } },
      ];
    }
    const rows = await reportCollection.find(filter)
      .sort({ createdAt: -1, reportId: -1 })
      .limit(input.limit + 1)
      .toArray() as unknown as PlayerReportDocument[];
    const page = rows.slice(0, input.limit)
      .map((report) => validatedModerationReport(report, input.previewedAt));
    return {
      kind: input.kind,
      reportRows: page,
      ...(rows.length > input.limit && page.length > 0 ? {
        nextCursor: encodeModerationExportCursor({
          kind: input.kind,
          createdAt: page[page.length - 1]!.createdAt,
          id: page[page.length - 1]!.reportId,
        }),
      } : {}),
    };
  }

  const filter = appealRetentionFilter(cutoffs.appealBefore, input.previewedAt);
  if (cursor) {
    filter.$or = [
      { createdAt: { $lt: cursor.createdAt } },
      { createdAt: cursor.createdAt, _id: { $lt: cursor.id } },
    ];
  }
  const rows = await appealCollection.find(filter)
    .sort({ createdAt: -1, _id: -1 })
    .limit(input.limit + 1)
    .toArray();
  const page = rows.slice(0, input.limit);
  return {
    kind: input.kind,
    appealRows: page,
    ...(rows.length > input.limit && page.length > 0 ? {
      nextCursor: encodeModerationExportCursor({
        kind: input.kind,
        createdAt: page[page.length - 1]!.createdAt,
        id: page[page.length - 1]!._id,
      }),
    } : {}),
  };
}

function retentionRunMatches(
  run: ModerationRetentionRunDocument,
  input: ModerationRetentionApplyInput,
): boolean {
  return run.operationId === input.operationId &&
    run.actor === input.actor &&
    run.previewedAt.getTime() === input.previewedAt.getTime();
}

function sessionOptions(session?: ClientSession): { session: ClientSession } | undefined {
  return session ? { session } : undefined;
}

/** Transaction core exposed for deterministic collection-level tests. */
export async function applyModerationRetentionInCollections(
  input: ModerationRetentionApplyInput,
  now: Date,
  reportCollection: Collection<Document>,
  appealCollection: Collection<PlayerAppealDocument>,
  runCollection: Collection<ModerationRetentionRunDocument>,
  session?: ClientSession,
  policy = moderationRetentionPolicy(),
): Promise<ModerationRetentionMutationResult> {
  const options = sessionOptions(session);
  const existing = await runCollection.findOne({ operationId: input.operationId }, options);
  if (existing) {
    if (!retentionRunMatches(existing, input)) {
      throw new ModerationLifecycleInputError("Idempotency-Key was already used for another retention run.", 409);
    }
    return { run: existing, replayed: true };
  }
  if (input.previewedAt.getTime() > now.getTime() + 60_000) {
    throw new ModerationLifecycleInputError("previewedAt cannot be in the future.", 400);
  }

  const cutoffs = moderationRetentionCutoffs(input.previewedAt, policy);
  const reportFilter = reportRetentionFilter(cutoffs.reportBefore, input.previewedAt);
  const eligibleReportRows = await validatedEligibleReports(
    reportCollection,
    reportFilter,
    input.previewedAt,
    session,
  );
  const reportResult = await reportCollection.deleteMany(
    { ...reportFilter, reportId: { $in: eligibleReportRows.map((report) => report.reportId) } },
    options,
  );
  const appealResult = await appealCollection.deleteMany(
    appealRetentionFilter(cutoffs.appealBefore, input.previewedAt),
    options,
  );
  const run: ModerationRetentionRunDocument = {
    _id: randomUUID(),
    operationId: input.operationId,
    actor: input.actor,
    previewedAt: input.previewedAt,
    ...cutoffs,
    deletedReports: reportResult.deletedCount,
    deletedAppeals: appealResult.deletedCount,
    createdAt: now,
  };
  await runCollection.insertOne(run, options);
  return { run, replayed: false };
}

/** Atomically purge both eligible collections and publish their immutable retry receipt. */
export async function applyModerationRetention(
  input: ModerationRetentionApplyInput,
  now = new Date(),
): Promise<ModerationRetentionMutationResult> {
  try {
    return await withMongoTransaction((session) => applyModerationRetentionInCollections(
      input,
      now,
      reports(),
      playerAppeals(),
      moderationRetentionRuns(),
      session,
    ));
  } catch (error) {
    if ((error as { code?: number }).code !== 11000) throw error;
    const winner = await moderationRetentionRuns().findOne({ operationId: input.operationId });
    if (winner && retentionRunMatches(winner, input)) return { run: winner, replayed: true };
    throw new ModerationLifecycleInputError("Idempotency-Key was already used for another retention run.", 409);
  }
}
