import type { Collection, Filter } from "mongodb";
import {
  clientAnalyticsEvents,
  clientErrorEvents,
  clientLogEntries,
  type ClientAnalyticsEventDocument,
  type ClientErrorEventDocument,
  type ClientLogEntryDocument,
} from "../db";
import { validatedClientAnalyticsEvent } from "./clientAnalyticsService";
import { validatedClientErrorEvent } from "./clientErrorService";
import { validatedClientLogEntry } from "./clientLogService";

export type AdminDiagnosticKind = "analytics" | "support-logs" | "client-errors";
export type AdminDiagnosticDocument =
  | ClientAnalyticsEventDocument
  | ClientLogEntryDocument
  | ClientErrorEventDocument;

export interface AdminDiagnosticListInput {
  readonly kind: AdminDiagnosticKind;
  readonly playerId: string | null;
  readonly limit: number;
  readonly cursor: string | null;
}

export interface AdminDiagnosticPage {
  readonly items: AdminDiagnosticDocument[];
  readonly nextCursor: string | null;
}

interface DiagnosticCursor {
  readonly v: 1;
  readonly kind: AdminDiagnosticKind;
  readonly playerId: string | null;
  readonly receivedAtMs: number;
  readonly id: string;
}

const UUID_V4 = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;
const CURSOR_KEYS = new Set(["v", "kind", "playerId", "receivedAtMs", "id"]);

export class AdminDiagnosticInputError extends Error {
  readonly httpStatus = 400;
}

function exactKind(value: unknown): AdminDiagnosticKind {
  if (value === "analytics" || value === "support-logs" || value === "client-errors") return value;
  throw new AdminDiagnosticInputError("Diagnostic kind is invalid.");
}

function exactPlayerId(value: unknown): string | null {
  if (value === undefined || value === null || value === "") return null;
  if (typeof value !== "string"
    || value.length > 256
    || value.trim() !== value
    || /[\u0000-\u001f\u007f]/u.test(value)) {
    throw new AdminDiagnosticInputError("Diagnostic playerId is invalid.");
  }
  return value;
}

function exactLimit(value: unknown): number {
  if (value === undefined) return 50;
  if (typeof value !== "string" || !/^(?:[1-9]|[1-9][0-9]|100)$/u.test(value)) {
    throw new AdminDiagnosticInputError("Diagnostic limit must be an integer from 1 through 100.");
  }
  return Number(value);
}

function encodeCursor(cursor: DiagnosticCursor): string {
  return Buffer.from(JSON.stringify(cursor), "utf8").toString("base64url");
}

function decodeCursor(
  value: unknown,
  kind: AdminDiagnosticKind,
  playerId: string | null,
  now: Date,
): DiagnosticCursor | null {
  if (value === undefined || value === null || value === "") return null;
  if (typeof value !== "string" || value.length > 1_024 || !/^[A-Za-z0-9_-]+$/u.test(value)) {
    throw new AdminDiagnosticInputError("Diagnostic cursor is invalid.");
  }
  let parsed: unknown;
  try {
    const decoded = Buffer.from(value, "base64url");
    if (decoded.toString("base64url") !== value) throw new Error("non-canonical cursor");
    parsed = JSON.parse(decoded.toString("utf8"));
  } catch {
    throw new AdminDiagnosticInputError("Diagnostic cursor is invalid.");
  }
  const raw = parsed as Record<string, unknown> | null;
  if (!raw
    || typeof raw !== "object"
    || Array.isArray(raw)
    || Object.keys(raw).length !== CURSOR_KEYS.size
    || Object.keys(raw).some((key) => !CURSOR_KEYS.has(key))
    || raw.v !== 1
    || raw.kind !== kind
    || raw.playerId !== playerId
    || !Number.isSafeInteger(raw.receivedAtMs)
    || (raw.receivedAtMs as number) < 0
    || (raw.receivedAtMs as number) > now.getTime()
    || typeof raw.id !== "string"
    || !UUID_V4.test(raw.id)) {
    throw new AdminDiagnosticInputError("Diagnostic cursor does not match this query.");
  }
  return raw as unknown as DiagnosticCursor;
}

export function normalizeAdminDiagnosticListInput(
  values: Record<string, unknown>,
  now = new Date(),
): AdminDiagnosticListInput & { readonly decodedCursor: DiagnosticCursor | null } {
  if (!(now instanceof Date) || !Number.isSafeInteger(now.getTime()) || now.getTime() < 0) {
    throw new Error("Diagnostic query time is invalid.");
  }
  const kind = exactKind(values.kind);
  const playerId = exactPlayerId(values.playerId);
  return {
    kind,
    playerId,
    limit: exactLimit(values.limit),
    cursor: typeof values.cursor === "string" ? values.cursor : null,
    decodedCursor: decodeCursor(values.cursor, kind, playerId, now),
  };
}

function collectionFor(
  kind: AdminDiagnosticKind,
): Collection<AdminDiagnosticDocument> {
  if (kind === "analytics") return clientAnalyticsEvents() as unknown as Collection<AdminDiagnosticDocument>;
  if (kind === "support-logs") return clientLogEntries() as unknown as Collection<AdminDiagnosticDocument>;
  return clientErrorEvents() as unknown as Collection<AdminDiagnosticDocument>;
}

function validateSelected(
  kind: AdminDiagnosticKind,
  row: AdminDiagnosticDocument,
  now: Date,
): AdminDiagnosticDocument {
  if (kind === "analytics") validatedClientAnalyticsEvent(row as ClientAnalyticsEventDocument, now);
  else if (kind === "support-logs") validatedClientLogEntry(row as ClientLogEntryDocument, now);
  else validatedClientErrorEvent(row as ClientErrorEventDocument, now);
  // MongoDB TTL cleanup is asynchronous. Application-time expiry prevents a row from remaining
  // operator-visible after the configured privacy window while the TTL monitor catches up.
  if (row.expiresAt.getTime() <= now.getTime()) {
    throw new Error("Selected client diagnostic is expired.");
  }
  return row;
}

/**
 * Read one stable, bounded diagnostics page under the admin-only HTTP boundary.
 *
 * The cursor is query-bound and carries the exact final `(receivedAt, _id)` pair. MongoDB uses the
 * same descending tuple, so rows inserted between pages cannot duplicate or skip older results.
 * Every selected document passes its complete storage-authority validator before any bytes leave
 * the process; one corrupt row aborts the whole page instead of returning partial believable data.
 */
export async function listAdminDiagnostics(
  input: AdminDiagnosticListInput,
  now = new Date(),
  collection?: Collection<AdminDiagnosticDocument>,
): Promise<AdminDiagnosticPage> {
  const normalized = normalizeAdminDiagnosticListInput({
    kind: input.kind,
    playerId: input.playerId,
    limit: String(input.limit),
    cursor: input.cursor,
  }, now);
  const filter: Filter<AdminDiagnosticDocument> = {
    expiresAt: { $gt: now },
    ...(normalized.playerId === null ? {} : { playerId: normalized.playerId }),
    ...(normalized.decodedCursor === null ? {} : {
      $or: [
        { receivedAt: { $lt: new Date(normalized.decodedCursor.receivedAtMs) } },
        {
          receivedAt: new Date(normalized.decodedCursor.receivedAtMs),
          _id: { $lt: normalized.decodedCursor.id },
        },
      ],
    }),
  };
  const rows = await (collection ?? collectionFor(normalized.kind))
    .find(filter)
    .sort({ receivedAt: -1, _id: -1 })
    .limit(normalized.limit)
    .toArray();
  const items = rows.map((row) => {
    const validated = validateSelected(normalized.kind, row, now);
    if (normalized.playerId !== null && validated.playerId !== normalized.playerId) {
      throw new Error("Selected client diagnostic does not match the player query.");
    }
    return validated;
  });
  const last = items.length === normalized.limit ? items[items.length - 1] : undefined;
  return {
    items,
    nextCursor: last ? encodeCursor({
      v: 1,
      kind: normalized.kind,
      playerId: normalized.playerId,
      receivedAtMs: last.receivedAt.getTime(),
      id: last._id,
    }) : null,
  };
}

export function wireAdminDiagnostic(
  kind: AdminDiagnosticKind,
  row: AdminDiagnosticDocument,
): Record<string, unknown> {
  const common = {
    id: row._id,
    playerId: row.playerId,
    byteLength: row.byteLength,
    receivedAt: row.receivedAt.toISOString(),
    expiresAt: row.expiresAt.toISOString(),
  };
  if (kind === "analytics") {
    const event = row as ClientAnalyticsEventDocument;
    return { ...common, payloadJson: event.payloadJson, payloadSha256: event.payloadSha256 };
  }
  if (kind === "support-logs") {
    const event = row as ClientLogEntryDocument;
    return {
      ...common,
      playerName: event.playerName,
      clientVersion: event.clientVersion,
      logs: event.logs,
      logsSha256: event.logsSha256,
    };
  }
  const event = row as ClientErrorEventDocument;
  return {
    ...common,
    playerName: event.playerName,
    clientVersion: event.clientVersion,
    kind: event.kind,
    exceptionMessage: event.exceptionMessage,
    exceptionStacktrace: event.exceptionStacktrace,
    sourceAction: event.sourceAction,
    serverResponse: event.serverResponse,
    postParameters: event.postParameters,
    messageToParse: event.messageToParse,
    payloadSha256: event.payloadSha256,
  };
}
