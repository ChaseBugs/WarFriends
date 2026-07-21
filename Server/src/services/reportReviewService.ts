import type { Collection, Document, Filter } from "mongodb";
import { reports } from "../db";
import type {
  PlayerReportDocument,
  PlayerReportReviewEntry,
} from "./reportService";

export type PlayerReportStatus = PlayerReportDocument["status"];
export type PlayerReportKind = PlayerReportDocument["kind"];

const REPORT_STATUSES = new Set<PlayerReportStatus>(["open", "reviewing", "resolved", "dismissed"]);
const REPORT_KINDS = new Set<PlayerReportKind>(["player", "cheat"]);
const OPERATION_ID_PATTERN = /^[A-Za-z0-9._:-]{8,128}$/u;
const REPORT_ID_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;
const MAX_REVIEW_NOTE_LENGTH = 1000;
const DEFAULT_PAGE_SIZE = 50;
const MAX_PAGE_SIZE = 100;

export class ReportReviewInputError extends Error {
  constructor(
    message: string,
    readonly httpStatus: 400 | 404 | 409,
  ) {
    super(message);
    this.name = "ReportReviewInputError";
  }
}

export interface ReportReviewInput {
  reportId: string;
  expectedStatus: PlayerReportStatus;
  status: Exclude<PlayerReportStatus, "open">;
  actor: string;
  note: string;
  operationId: string;
}

export interface ReportReviewMutationResult {
  report: PlayerReportDocument;
  replayed: boolean;
}

export interface ReportListInput {
  status?: PlayerReportStatus;
  kind?: PlayerReportKind;
  reportedPlayerId?: string;
  reporterPlayerId?: string;
  cursor?: string;
  limit: number;
}

export interface ReportListPage {
  reports: PlayerReportDocument[];
  nextCursor?: string;
}

interface ReportCursor {
  createdAt: Date;
  reportId: string;
}

function boundedText(value: unknown, field: string, maximum: number, required = true): string {
  if (value === undefined || value === null || value === "") {
    if (!required) return "";
    throw new ReportReviewInputError(`${field} is required.`, 400);
  }
  if (typeof value !== "string") throw new ReportReviewInputError(`${field} must be a string.`, 400);
  const normalized = value.trim().replace(/\s+/gu, " ");
  if ((required && normalized.length < 1) || normalized.length > maximum) {
    throw new ReportReviewInputError(`${field} must contain ${required ? "1-" : "0-"}${maximum} characters.`, 400);
  }
  return normalized;
}

export function normalizeReportReviewActor(value: unknown): string {
  return boundedText(value, "X-Admin-Actor", 100);
}

export function normalizeReportReviewOperationId(value: unknown): string {
  const operationId = typeof value === "string" ? value.trim() : "";
  if (!OPERATION_ID_PATTERN.test(operationId)) {
    throw new ReportReviewInputError(
      "Idempotency-Key must contain 8-128 letters, digits, dots, underscores, colons, or hyphens.",
      400,
    );
  }
  return operationId;
}

export function normalizeReportId(value: unknown): string {
  const reportId = typeof value === "string" ? value.trim() : "";
  if (!REPORT_ID_PATTERN.test(reportId)) {
    throw new ReportReviewInputError("reportId must be a version-4 UUID.", 400);
  }
  return reportId;
}

export function normalizeReportStatus(value: unknown, required = false): PlayerReportStatus | undefined {
  if ((value === undefined || value === null || value === "") && !required) return undefined;
  if (typeof value !== "string" || !REPORT_STATUSES.has(value as PlayerReportStatus)) {
    throw new ReportReviewInputError("status must be open, reviewing, resolved, or dismissed.", 400);
  }
  return value as PlayerReportStatus;
}

export function normalizeReviewTargetStatus(value: unknown): Exclude<PlayerReportStatus, "open"> {
  const status = normalizeReportStatus(value, true);
  if (status === "open") {
    throw new ReportReviewInputError("A reviewed report cannot transition back to open.", 400);
  }
  return status as Exclude<PlayerReportStatus, "open">;
}

export function normalizeReportKind(value: unknown): PlayerReportKind | undefined {
  if (value === undefined || value === null || value === "") return undefined;
  if (typeof value !== "string" || !REPORT_KINDS.has(value as PlayerReportKind)) {
    throw new ReportReviewInputError("kind must be player or cheat.", 400);
  }
  return value as PlayerReportKind;
}

export function normalizeReviewNote(value: unknown, terminal: boolean): string {
  return boundedText(value, "note", MAX_REVIEW_NOTE_LENGTH, terminal);
}

function normalizeOptionalPlayerId(value: unknown, field: string): string | undefined {
  if (value === undefined || value === null || value === "") return undefined;
  return boundedText(value, field, 256);
}

export function normalizeReportPageLimit(value: unknown): number {
  if (value === undefined || value === null || value === "") return DEFAULT_PAGE_SIZE;
  const limit = Number(value);
  if (!Number.isSafeInteger(limit) || limit < 1 || limit > MAX_PAGE_SIZE) {
    throw new ReportReviewInputError(`limit must be an integer from 1 to ${MAX_PAGE_SIZE}.`, 400);
  }
  return limit;
}

export function encodeReportCursor(report: Pick<PlayerReportDocument, "createdAt" | "reportId">): string {
  return Buffer.from(JSON.stringify({ createdAt: report.createdAt.toISOString(), reportId: report.reportId }), "utf8")
    .toString("base64url");
}

export function decodeReportCursor(value: unknown): ReportCursor | undefined {
  if (value === undefined || value === null || value === "") return undefined;
  if (typeof value !== "string" || value.length > 512 || !/^[A-Za-z0-9_-]+$/u.test(value)) {
    throw new ReportReviewInputError("cursor is invalid.", 400);
  }
  try {
    const parsed = JSON.parse(Buffer.from(value, "base64url").toString("utf8")) as Record<string, unknown>;
    const createdAt = typeof parsed.createdAt === "string" ? new Date(parsed.createdAt) : new Date(Number.NaN);
    const reportId = normalizeReportId(parsed.reportId);
    if (Number.isNaN(createdAt.getTime())) throw new Error("invalid date");
    return { createdAt, reportId };
  } catch (error) {
    if (error instanceof ReportReviewInputError) throw new ReportReviewInputError("cursor is invalid.", 400);
    throw new ReportReviewInputError("cursor is invalid.", 400);
  }
}

export function normalizeReportListInput(query: Record<string, unknown>): ReportListInput {
  const cursorValue = typeof query.cursor === "string" ? query.cursor : query.cursor;
  return {
    status: normalizeReportStatus(query.status),
    kind: normalizeReportKind(query.kind),
    reportedPlayerId: normalizeOptionalPlayerId(query.reportedPlayerId, "reportedPlayerId"),
    reporterPlayerId: normalizeOptionalPlayerId(query.reporterPlayerId, "reporterPlayerId"),
    cursor: cursorValue === undefined ? undefined : boundedText(cursorValue, "cursor", 512),
    limit: normalizeReportPageLimit(query.limit),
  };
}

export function reportTransitionAllowed(from: PlayerReportStatus, to: PlayerReportStatus): boolean {
  if (from === "open") return to === "reviewing" || to === "resolved" || to === "dismissed";
  if (from === "reviewing") return to === "resolved" || to === "dismissed";
  return false;
}

function reviewEntryMatches(entry: PlayerReportReviewEntry, input: ReportReviewInput): boolean {
  return entry.operationId === input.operationId &&
    entry.fromStatus === input.expectedStatus &&
    entry.toStatus === input.status &&
    entry.actor === input.actor &&
    entry.note === input.note;
}

function existingReview(report: PlayerReportDocument, operationId: string): PlayerReportReviewEntry | undefined {
  return report.reviewHistory?.find((entry) => entry.operationId === operationId);
}

/**
 * Apply one status transition and append its audit entry in the same report-document update.
 *
 * expectedStatus is mandatory optimistic concurrency. Different operators cannot both resolve
 * the same snapshot, terminal reports cannot be reopened, and a lost response returns the exact
 * winning report when the same operation ID and intent are retried.
 */
export async function reviewPlayerReport(
  input: ReportReviewInput,
  now = new Date(),
  collection: Collection<Document> = reports(),
): Promise<ReportReviewMutationResult> {
  // Keep the terminal-decision evidence rule inside the mutation boundary as well as the HTTP
  // parser. Future administrative callers must not be able to bypass it by invoking the service
  // directly with a structurally valid but empty note.
  if (input.status !== "reviewing" && input.note.trim().length === 0) {
    throw new ReportReviewInputError("A terminal review decision requires a note.", 400);
  }
  const current = await collection.findOne({ reportId: input.reportId }) as unknown as PlayerReportDocument | null;
  if (!current) throw new ReportReviewInputError("Report was not found.", 404);

  const replay = existingReview(current, input.operationId);
  if (replay) {
    if (!reviewEntryMatches(replay, input)) {
      throw new ReportReviewInputError("Idempotency-Key was already used for another review decision.", 409);
    }
    return { report: current, replayed: true };
  }
  if (current.status !== input.expectedStatus) {
    throw new ReportReviewInputError(`Report status is ${current.status}, not ${input.expectedStatus}.`, 409);
  }
  if (!reportTransitionAllowed(current.status, input.status)) {
    throw new ReportReviewInputError(`Report cannot transition from ${current.status} to ${input.status}.`, 409);
  }

  const entry: PlayerReportReviewEntry = {
    operationId: input.operationId,
    fromStatus: input.expectedStatus,
    toStatus: input.status,
    actor: input.actor,
    note: input.note,
    createdAt: now,
  };

  let updated: Document | null;
  try {
    updated = await collection.findOneAndUpdate(
      {
        reportId: input.reportId,
        status: input.expectedStatus,
        "reviewHistory.operationId": { $ne: input.operationId },
      },
      {
        $set: { status: input.status, updatedAt: now },
        $push: { reviewHistory: entry },
      } as Document,
      { returnDocument: "after" },
    );
  } catch (error) {
    if ((error as { code?: number }).code !== 11000) throw error;
    const operationOwner = (await collection.findOne({ "reviewHistory.operationId": input.operationId })) as
      unknown as PlayerReportDocument | null;
    const ownerEntry = operationOwner ? existingReview(operationOwner, input.operationId) : undefined;
    if (operationOwner?.reportId === input.reportId && ownerEntry && reviewEntryMatches(ownerEntry, input)) {
      return { report: operationOwner, replayed: true };
    }
    throw new ReportReviewInputError("Idempotency-Key was already used for another report review.", 409);
  }
  if (updated) return { report: updated as unknown as PlayerReportDocument, replayed: false };

  // A concurrent identical retry can win after our initial read but before compare-and-set.
  const winner = await collection.findOne({ reportId: input.reportId }) as unknown as PlayerReportDocument | null;
  const winnerEntry = winner ? existingReview(winner, input.operationId) : undefined;
  if (winner && winnerEntry && reviewEntryMatches(winnerEntry, input)) {
    return { report: winner, replayed: true };
  }
  throw new ReportReviewInputError("Report status changed before this review was committed.", 409);
}

export async function findModerationReport(
  reportId: string,
  collection: Collection<Document> = reports(),
): Promise<PlayerReportDocument | null> {
  return collection.findOne({ reportId }) as unknown as PlayerReportDocument | null;
}

/** Stable newest-first moderation queue with an opaque createdAt/reportId tie-break cursor. */
export async function listModerationReports(
  input: ReportListInput,
  collection: Collection<Document> = reports(),
): Promise<ReportListPage> {
  const filter: Filter<Document> = {};
  if (input.status) filter.status = input.status;
  if (input.kind) filter.kind = input.kind;
  if (input.reportedPlayerId) filter.reportedPlayerId = input.reportedPlayerId;
  if (input.reporterPlayerId) filter.reporterPlayerId = input.reporterPlayerId;
  const cursor = decodeReportCursor(input.cursor);
  if (cursor) {
    filter.$or = [
      { createdAt: { $lt: cursor.createdAt } },
      { createdAt: cursor.createdAt, reportId: { $lt: cursor.reportId } },
    ];
  }

  const rows = await collection.find(filter)
    .sort({ createdAt: -1, reportId: -1 })
    .limit(input.limit + 1)
    .toArray() as unknown as PlayerReportDocument[];
  const hasMore = rows.length > input.limit;
  const page = rows.slice(0, input.limit);
  return {
    reports: page,
    ...(hasMore && page.length > 0 ? { nextCursor: encodeReportCursor(page[page.length - 1]!) } : {}),
  };
}
