import { randomUUID } from "crypto";
import type { ClientSession, Collection, Document, Filter } from "mongodb";
import {
  playerAppeals,
  playerSanctions,
  withMongoTransaction,
  type PlayerAppealDocument,
  type PlayerAppealReviewEntry,
  type PlayerSanctionDocument,
} from "../db";
import { activeSanctionAt } from "./playerSanctionService";

export type PlayerAppealStatus = PlayerAppealDocument["status"];

const APPEAL_STATUSES = new Set<PlayerAppealStatus>([
  "open",
  "reviewing",
  "accepted",
  "rejected",
  "withdrawn",
]);
const UUID_V4_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;
const OPERATION_ID_PATTERN = /^[A-Za-z0-9._:-]{8,128}$/u;
const MIN_APPEAL_MESSAGE_LENGTH = 20;
const MAX_APPEAL_MESSAGE_LENGTH = 2_000;
const DEFAULT_PAGE_SIZE = 50;
const MAX_PAGE_SIZE = 100;
const APPEAL_KEYS = new Set([
  "_id", "sanctionId", "playerId", "status", "message", "submissionOperationId", "reviewHistory",
  "createdAt", "updatedAt",
]);
const APPEAL_REVIEW_KEYS = new Set(["operationId", "fromStatus", "toStatus", "actor", "note", "createdAt"]);

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value) && !(value instanceof Date);
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function boundedIdentity(value: unknown, maximum: number): value is string {
  return typeof value === "string" && value.length >= 1 && value.length <= maximum && !/\p{Cc}/u.test(value);
}

/**
 * Prove one appeal as immutable player intake followed by at most two audited lifecycle moves.
 * Status is only a projection of that history. The open row uses updatedAt=createdAt because its
 * submission operation is itself a durable mutation; every later update must equal the final
 * review/withdrawal timestamp exactly.
 */
export function validatedPlayerAppeal(
  appeal: PlayerAppealDocument,
  now: Date,
): PlayerAppealDocument {
  const raw = appeal as unknown as Record<string, unknown>;
  if (!plainRecord(appeal)
    || Object.keys(raw).some((key) => !APPEAL_KEYS.has(key))
    || !UUID_V4_PATTERN.test(appeal._id)
    || !UUID_V4_PATTERN.test(appeal.sanctionId)
    || !boundedIdentity(appeal.playerId, 256)
    || !APPEAL_STATUSES.has(appeal.status)
    || typeof appeal.message !== "string"
    || appeal.message.length < MIN_APPEAL_MESSAGE_LENGTH
    || appeal.message.length > MAX_APPEAL_MESSAGE_LENGTH
    || appeal.message.trim().replace(/\s+/gu, " ") !== appeal.message
    || !OPERATION_ID_PATTERN.test(appeal.submissionOperationId)
    || !safeDate(appeal.createdAt)
    || !safeDate(appeal.updatedAt)
    || !safeDate(now)
    || appeal.createdAt.getTime() > now.getTime()
    || appeal.updatedAt.getTime() > now.getTime()) {
    throw new Error("Stored player appeal authority is invalid.");
  }

  const history = appeal.reviewHistory;
  if (appeal.status === "open") {
    if (history !== undefined || appeal.updatedAt.getTime() !== appeal.createdAt.getTime()) {
      throw new Error("Stored player appeal authority is invalid.");
    }
    return appeal;
  }
  if (!Array.isArray(history) || history.length < 1 || history.length > 2) {
    throw new Error("Stored player appeal authority is invalid.");
  }
  let projected: PlayerAppealStatus = "open";
  let previousTime = appeal.createdAt.getTime();
  const operationIds = new Set([appeal.submissionOperationId]);
  for (const entry of history) {
    const entryRaw = entry as unknown as Record<string, unknown>;
    const terminal = entry.toStatus === "accepted" || entry.toStatus === "rejected" || entry.toStatus === "withdrawn";
    if (!plainRecord(entry)
      || Object.keys(entryRaw).some((key) => !APPEAL_REVIEW_KEYS.has(key))
      || !OPERATION_ID_PATTERN.test(entry.operationId)
      || operationIds.has(entry.operationId)
      || entry.fromStatus !== projected
      || !appealTransitionAllowed(projected, entry.toStatus)
      || !boundedIdentity(entry.actor, 100)
      || typeof entry.note !== "string"
      || entry.note.length > 1_000
      || (terminal && entry.note.length < 1)
      || !safeDate(entry.createdAt)
      || entry.createdAt.getTime() < previousTime
      || entry.createdAt.getTime() > now.getTime()) {
      throw new Error("Stored player appeal authority is invalid.");
    }
    operationIds.add(entry.operationId);
    projected = entry.toStatus;
    previousTime = entry.createdAt.getTime();
  }
  if (projected !== appeal.status || appeal.updatedAt.getTime() !== previousTime) {
    throw new Error("Stored player appeal authority is invalid.");
  }
  return appeal;
}

export class PlayerAppealInputError extends Error {
  constructor(
    message: string,
    readonly httpStatus: 400 | 404 | 409,
  ) {
    super(message);
    this.name = "PlayerAppealInputError";
  }
}

export interface SubmitPlayerAppealInput {
  sanctionId: string;
  message: string;
  operationId: string;
}

export interface PlayerAppealMutationResult {
  appeal: PlayerAppealDocument;
  replayed: boolean;
}

export interface PlayerAppealListInput {
  status?: PlayerAppealStatus;
  playerId?: string;
  cursor?: string;
  limit: number;
}

export interface PlayerAppealListPage {
  appeals: PlayerAppealDocument[];
  nextCursor?: string;
}

export interface ReviewPlayerAppealInput {
  appealId: string;
  expectedStatus: "open" | "reviewing";
  status: "reviewing" | "accepted" | "rejected" | "withdrawn";
  actor: string;
  note: string;
  operationId: string;
}

interface PlayerAppealCursor {
  createdAt: Date;
  appealId: string;
}

function boundedSingleLine(value: unknown, field: string, maximum: number): string {
  if (typeof value !== "string") throw new PlayerAppealInputError(`${field} must be a string.`, 400);
  const normalized = value.trim().replace(/\s+/gu, " ");
  if (normalized.length < 1 || normalized.length > maximum) {
    throw new PlayerAppealInputError(`${field} must contain 1-${maximum} characters.`, 400);
  }
  return normalized;
}

export function normalizeAppealId(value: unknown, field = "appealId"): string {
  const id = typeof value === "string" ? value.trim() : "";
  if (!UUID_V4_PATTERN.test(id)) throw new PlayerAppealInputError(`${field} must be a version-4 UUID.`, 400);
  return id;
}

export function normalizeAppealOperationId(value: unknown): string {
  const operationId = typeof value === "string" ? value.trim() : "";
  if (!OPERATION_ID_PATTERN.test(operationId)) {
    throw new PlayerAppealInputError(
      "Idempotency-Key must contain 8-128 letters, digits, dots, underscores, colons, or hyphens.",
      400,
    );
  }
  return operationId;
}

export function normalizeAppealMessage(value: unknown): string {
  if (typeof value !== "string") throw new PlayerAppealInputError("message must be a string.", 400);
  const normalized = value.trim().replace(/\s+/gu, " ");
  if (normalized.length < MIN_APPEAL_MESSAGE_LENGTH || normalized.length > MAX_APPEAL_MESSAGE_LENGTH) {
    throw new PlayerAppealInputError(
      `message must contain ${MIN_APPEAL_MESSAGE_LENGTH}-${MAX_APPEAL_MESSAGE_LENGTH} characters.`,
      400,
    );
  }
  return normalized;
}

export function normalizeAppealStatus(value: unknown): PlayerAppealStatus | undefined {
  if (value === undefined || value === null || value === "") return undefined;
  if (typeof value !== "string" || !APPEAL_STATUSES.has(value as PlayerAppealStatus)) {
    throw new PlayerAppealInputError("status must be open, reviewing, accepted, rejected, or withdrawn.", 400);
  }
  return value as PlayerAppealStatus;
}

export function normalizeAppealExpectedStatus(value: unknown): "open" | "reviewing" {
  const status = normalizeAppealStatus(value);
  if (status !== "open" && status !== "reviewing") {
    throw new PlayerAppealInputError("expectedStatus must be open or reviewing.", 400);
  }
  return status;
}

export function normalizeAppealReviewStatus(value: unknown): "reviewing" | "accepted" | "rejected" {
  const status = normalizeAppealStatus(value);
  if (status !== "reviewing" && status !== "accepted" && status !== "rejected") {
    throw new PlayerAppealInputError("status must be reviewing, accepted, or rejected.", 400);
  }
  return status;
}

export function normalizeAppealReviewActor(value: unknown): string {
  return boundedSingleLine(value, "X-Admin-Actor", 100);
}

export function normalizeAppealReviewNote(value: unknown, terminal: boolean): string {
  if ((value === undefined || value === null || value === "") && !terminal) return "";
  const note = boundedSingleLine(value, "note", 1_000);
  if (terminal && note.length < 1) throw new PlayerAppealInputError("A terminal decision requires a note.", 400);
  return note;
}

export function normalizeAppealPageLimit(value: unknown): number {
  if (value === undefined || value === null || value === "") return DEFAULT_PAGE_SIZE;
  const limit = Number(value);
  if (!Number.isSafeInteger(limit) || limit < 1 || limit > MAX_PAGE_SIZE) {
    throw new PlayerAppealInputError(`limit must be an integer from 1 to ${MAX_PAGE_SIZE}.`, 400);
  }
  return limit;
}

function normalizeOptionalPlayerId(value: unknown): string | undefined {
  if (value === undefined || value === null || value === "") return undefined;
  return boundedSingleLine(value, "playerId", 256);
}

export function encodeAppealCursor(
  appeal: Pick<PlayerAppealDocument, "createdAt" | "_id">,
): string {
  return Buffer.from(JSON.stringify({ createdAt: appeal.createdAt.toISOString(), appealId: appeal._id }), "utf8")
    .toString("base64url");
}

export function decodeAppealCursor(value: unknown): PlayerAppealCursor | undefined {
  if (value === undefined || value === null || value === "") return undefined;
  if (typeof value !== "string" || value.length > 512 || !/^[A-Za-z0-9_-]+$/u.test(value)) {
    throw new PlayerAppealInputError("cursor is invalid.", 400);
  }
  try {
    const parsed = JSON.parse(Buffer.from(value, "base64url").toString("utf8")) as Record<string, unknown>;
    const createdAt = typeof parsed.createdAt === "string" ? new Date(parsed.createdAt) : new Date(Number.NaN);
    const appealId = normalizeAppealId(parsed.appealId);
    if (Number.isNaN(createdAt.getTime())) throw new Error("invalid date");
    return { createdAt, appealId };
  } catch {
    throw new PlayerAppealInputError("cursor is invalid.", 400);
  }
}

export function normalizeAppealListInput(query: Record<string, unknown>): PlayerAppealListInput {
  return {
    status: normalizeAppealStatus(query.status),
    playerId: normalizeOptionalPlayerId(query.playerId),
    cursor: query.cursor === undefined ? undefined : boundedSingleLine(query.cursor, "cursor", 512),
    limit: normalizeAppealPageLimit(query.limit),
  };
}

function sameSubmission(
  appeal: PlayerAppealDocument,
  playerId: string,
  input: SubmitPlayerAppealInput,
): boolean {
  return appeal.playerId === playerId &&
    appeal.sanctionId === input.sanctionId &&
    appeal.message === input.message &&
    appeal.submissionOperationId === input.operationId;
}

export function appealTransitionAllowed(from: PlayerAppealStatus, to: PlayerAppealStatus): boolean {
  if (from === "open") {
    return to === "reviewing" || to === "accepted" || to === "rejected" || to === "withdrawn";
  }
  if (from === "reviewing") return to === "accepted" || to === "rejected" || to === "withdrawn";
  return false;
}

function reviewEntryMatches(entry: PlayerAppealReviewEntry, input: ReviewPlayerAppealInput): boolean {
  return entry.operationId === input.operationId &&
    entry.fromStatus === input.expectedStatus &&
    entry.toStatus === input.status &&
    entry.actor === input.actor &&
    entry.note === input.note;
}

function reviewEntry(
  appeal: PlayerAppealDocument,
  operationId: string,
): PlayerAppealReviewEntry | undefined {
  return appeal.reviewHistory?.find((entry) => entry.operationId === operationId);
}

/**
 * Create the sole appeal for an authenticated player's currently active sanction.
 *
 * The sanction ownership query never returns the private reason. Unique sanction and operation
 * indexes make concurrent submissions converge: the exact lost-response retry returns the first
 * row, while a changed message/key or an operation reused for another sanction conflicts.
 */
export async function submitPlayerAppeal(
  playerId: string,
  input: SubmitPlayerAppealInput,
  now = new Date(),
  appealCollection: Collection<PlayerAppealDocument> = playerAppeals(),
  sanctionCollection: Collection<PlayerSanctionDocument> = playerSanctions(),
): Promise<PlayerAppealMutationResult> {
  const existingOperation = await appealCollection.findOne({ submissionOperationId: input.operationId });
  if (existingOperation) {
    validatedPlayerAppeal(existingOperation, now);
    if (!sameSubmission(existingOperation, playerId, input)) {
      throw new PlayerAppealInputError("Idempotency-Key was already used for another appeal.", 409);
    }
    return { appeal: existingOperation, replayed: true };
  }

  const sanction = await sanctionCollection.findOne({ _id: input.sanctionId, playerId });
  if (!sanction) {
    // Ownership and existence deliberately share one response so a valid player session cannot
    // enumerate sanctions belonging to other accounts.
    throw new PlayerAppealInputError("Active sanction was not found.", 404);
  }
  if (!activeSanctionAt(sanction, now)) {
    throw new PlayerAppealInputError("Only an active sanction can be appealed.", 409);
  }

  const existingSanctionAppeal = await appealCollection.findOne({ sanctionId: input.sanctionId });
  if (existingSanctionAppeal) {
    validatedPlayerAppeal(existingSanctionAppeal, now);
    if (sameSubmission(existingSanctionAppeal, playerId, input)) {
      return { appeal: existingSanctionAppeal, replayed: true };
    }
    throw new PlayerAppealInputError("This sanction already has an appeal.", 409);
  }

  const appeal: PlayerAppealDocument = {
    _id: randomUUID(),
    sanctionId: sanction._id,
    playerId,
    status: "open",
    message: input.message,
    submissionOperationId: input.operationId,
    createdAt: now,
    updatedAt: now,
  };
  validatedPlayerAppeal(appeal, now);
  try {
    await appealCollection.insertOne(appeal);
    return { appeal, replayed: false };
  } catch (error) {
    if ((error as { code?: number }).code !== 11000) throw error;
    const winner = await appealCollection.findOne({
      $or: [
        { sanctionId: input.sanctionId },
        { submissionOperationId: input.operationId },
      ],
    });
    if (winner) validatedPlayerAppeal(winner, now);
    if (winner && sameSubmission(winner, playerId, input)) {
      return { appeal: winner, replayed: true };
    }
    throw new PlayerAppealInputError("This sanction or Idempotency-Key already owns another appeal.", 409);
  }
}

function sessionOptions(session?: ClientSession): { session: ClientSession } | undefined {
  return session ? { session } : undefined;
}

/**
 * Apply one appeal transition against injected collections.
 *
 * Production wraps this function in one MongoDB transaction. Keeping the collection-level core
 * explicit makes the cross-document invariants testable: an accepted appeal revokes a still-live
 * sanction before the appeal becomes terminal, and any later failure rolls both writes back.
 */
export async function reviewPlayerAppealInCollections(
  input: ReviewPlayerAppealInput,
  now: Date,
  appealCollection: Collection<PlayerAppealDocument>,
  sanctionCollection: Collection<PlayerSanctionDocument>,
  session?: ClientSession,
): Promise<PlayerAppealMutationResult> {
  if ((input.status === "accepted" || input.status === "rejected") && input.note.trim().length === 0) {
    throw new PlayerAppealInputError("A terminal appeal decision requires a note.", 400);
  }
  const options = sessionOptions(session);
  const current = await appealCollection.findOne({ _id: input.appealId }, options);
  if (!current) throw new PlayerAppealInputError("Appeal was not found.", 404);
  validatedPlayerAppeal(current, now);
  const replay = reviewEntry(current, input.operationId);
  if (replay) {
    if (!reviewEntryMatches(replay, input)) {
      throw new PlayerAppealInputError("Idempotency-Key was already used for another appeal decision.", 409);
    }
    return { appeal: current, replayed: true };
  }
  if (current.status !== input.expectedStatus) {
    throw new PlayerAppealInputError(`Appeal status is ${current.status}, not ${input.expectedStatus}.`, 409);
  }
  if (!appealTransitionAllowed(current.status, input.status)) {
    throw new PlayerAppealInputError(`Appeal cannot transition from ${current.status} to ${input.status}.`, 409);
  }

  if (input.status === "accepted") {
    const sanction = await sanctionCollection.findOne(
      { _id: current.sanctionId, playerId: current.playerId },
      options,
    );
    if (!sanction) throw new PlayerAppealInputError("Appeal sanction no longer exists.", 409);
    if (sanction.status === "active" && activeSanctionAt(sanction, now)) {
      const result = await sanctionCollection.updateOne(
        { _id: sanction._id, playerId: current.playerId, status: "active" },
        { $set: {
          status: "revoked",
          revokedAt: now,
          revokedBy: input.actor,
          revocationReason: `Appeal accepted: ${input.note}`.slice(0, 500),
          revocationOperationId: `appeal:${current._id}`,
          resolvedAt: now,
        } },
        options,
      );
      if (result.matchedCount !== 1) {
        throw new PlayerAppealInputError("Sanction state changed before appeal acceptance.", 409);
      }
    } else if (sanction.status === "active") {
      // Application time already makes the sanction non-blocking. Persist its audit projection in
      // the same transaction so the accepted appeal cannot leave a stale active status behind.
      await sanctionCollection.updateOne(
        { _id: sanction._id, playerId: current.playerId, status: "active" },
        { $set: { status: "expired", resolvedAt: now } },
        options,
      );
    }
  }

  const entry: PlayerAppealReviewEntry = {
    operationId: input.operationId,
    fromStatus: input.expectedStatus,
    toStatus: input.status,
    actor: input.actor,
    note: input.note,
    createdAt: now,
  };
  const updated = await appealCollection.findOneAndUpdate(
    {
      _id: current._id,
      status: input.expectedStatus,
      "reviewHistory.operationId": { $ne: input.operationId },
    },
    {
      $set: { status: input.status, updatedAt: now },
      $push: { reviewHistory: entry },
    } as Document,
    { ...options, returnDocument: "after" },
  );
  if (updated) {
    validatedPlayerAppeal(updated, now);
    return { appeal: updated, replayed: false };
  }

  const winner = await appealCollection.findOne({ _id: current._id }, options);
  if (winner) validatedPlayerAppeal(winner, now);
  const winnerEntry = winner ? reviewEntry(winner, input.operationId) : undefined;
  if (winner && winnerEntry && reviewEntryMatches(winnerEntry, input)) {
    return { appeal: winner, replayed: true };
  }
  throw new PlayerAppealInputError("Appeal status changed before this decision was committed.", 409);
}

/** Transactional production wrapper for operator decisions and player withdrawal. */
export async function reviewPlayerAppeal(
  input: ReviewPlayerAppealInput,
  now = new Date(),
): Promise<PlayerAppealMutationResult> {
  try {
    return await withMongoTransaction((session) => reviewPlayerAppealInCollections(
      input,
      now,
      playerAppeals(),
      playerSanctions(),
      session,
    ));
  } catch (error) {
    if ((error as { code?: number }).code !== 11000) throw error;
    const owner = await playerAppeals().findOne({ "reviewHistory.operationId": input.operationId });
    if (owner) validatedPlayerAppeal(owner, now);
    const ownerEntry = owner ? reviewEntry(owner, input.operationId) : undefined;
    if (owner?._id === input.appealId && ownerEntry && reviewEntryMatches(ownerEntry, input)) {
      return { appeal: owner, replayed: true };
    }
    throw new PlayerAppealInputError("Idempotency-Key was already used for another appeal decision.", 409);
  }
}

export async function findPlayerAppeal(
  appealId: string,
  appealCollection: Collection<PlayerAppealDocument> = playerAppeals(),
  now = new Date(),
): Promise<PlayerAppealDocument | null> {
  const appeal = await appealCollection.findOne({ _id: appealId });
  return appeal ? validatedPlayerAppeal(appeal, now) : null;
}

export async function findOwnedPlayerAppeal(
  appealId: string,
  playerId: string,
  appealCollection: Collection<PlayerAppealDocument> = playerAppeals(),
  now = new Date(),
): Promise<PlayerAppealDocument | null> {
  const appeal = await appealCollection.findOne({ _id: appealId, playerId });
  return appeal ? validatedPlayerAppeal(appeal, now) : null;
}

/** Stable admin queue ordered by creation time plus appeal UUID as a deterministic tie-breaker. */
export async function listPlayerAppeals(
  input: PlayerAppealListInput,
  appealCollection: Collection<PlayerAppealDocument> = playerAppeals(),
  now = new Date(),
): Promise<PlayerAppealListPage> {
  const filter: Filter<PlayerAppealDocument> = {};
  if (input.status) filter.status = input.status;
  if (input.playerId) filter.playerId = input.playerId;
  const cursor = decodeAppealCursor(input.cursor);
  if (cursor) {
    filter.$or = [
      { createdAt: { $lt: cursor.createdAt } },
      { createdAt: cursor.createdAt, _id: { $lt: cursor.appealId } },
    ];
  }
  const rows = await appealCollection.find(filter)
    .sort({ createdAt: -1, _id: -1 })
    .limit(input.limit + 1)
    .toArray();
  const hasMore = rows.length > input.limit;
  const page = rows.slice(0, input.limit).map((appeal) => validatedPlayerAppeal(appeal, now));
  return {
    appeals: page,
    ...(hasMore && page.length > 0 ? { nextCursor: encodeAppealCursor(page[page.length - 1]!) } : {}),
  };
}
