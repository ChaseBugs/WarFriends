import { createHmac, randomUUID } from "crypto";
import {
  matches,
  reportDeduplications,
  reports,
  type ReportDeduplicationDocument,
} from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { League } from "../constants";
import { findById } from "./playerService";
import { validatedMatchDocument, type MatchDoc, type MatchPlayer } from "./matchService";
import { reserveReportSubmission } from "./reportRateLimitService";

const DUPLICATE_WINDOW_MS = 10 * 60 * 1000;
const MATCH_EVIDENCE_LOOKBACK_MS = 6 * 60 * 60 * 1000;
const REPORT_ID_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;
const CREATION_REPORT_KEYS = new Set([
  "reportId", "reporterPlayerId", "kind", "reportedPlayerId", "reportType", "message", "evidence",
  "status", "matchEvidence", "createdAt",
]);
const MODERATION_REPORT_KEYS = new Set([...CREATION_REPORT_KEYS, "_id", "updatedAt", "reviewHistory"]);
const REVIEW_ENTRY_KEYS = new Set(["operationId", "fromStatus", "toStatus", "actor", "note", "createdAt"]);
const DEDUPLICATION_KEYS = new Set(["_id", "key", "report", "reportCreatedAt", "expiresAt"]);
const MATCH_EVIDENCE_KEYS = new Set([
  "source", "matchId", "state", "createdAt", "endedAt", "reporter", "reportedPlayer", "winnerId",
  "cancelReason", "resultClaims", "relayedCardPlays", "usedCardClaims", "combatValidated",
]);
const MATCH_PLAYER_KEYS = new Set(["playerId", "name", "armyPower", "leagueTier"]);
const REPORT_EVIDENCE_KEYS = new Set([
  "MyArmyPower", "MyRank", "OpponentArmyPower", "OpponentRank", "TimeOfMatch",
]);
const MATCH_STATES = new Set<MatchDoc["state"]>(["active", "settling", "finished", "cancelled"]);

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value) && !(value instanceof Date);
}

function exactKeys(value: Record<string, unknown>, allowed: Set<string>): boolean {
  return Object.keys(value).every((key) => allowed.has(key));
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function boundedIdentity(value: unknown, maximum = 128): value is string {
  return typeof value === "string" && value.length >= 1 && value.length <= maximum && !/\p{Cc}/u.test(value);
}

function validMatchPlayer(value: unknown, expectedId: string): value is MatchPlayer {
  if (!plainRecord(value) || !exactKeys(value, MATCH_PLAYER_KEYS)) return false;
  return value.playerId === expectedId
    && boundedIdentity(value.playerId)
    && boundedIdentity(value.name, 64)
    && typeof value.armyPower === "number"
    && Number.isFinite(value.armyPower)
    && value.armyPower >= 0
    && typeof value.leagueTier === "number"
    && Number.isSafeInteger(value.leagueTier)
    && value.leagueTier >= League.NoLeague
    && value.leagueTier <= League.Champion;
}

function validClaimMap(value: unknown, participantIds: Set<string>, arrays: boolean): boolean {
  if (!plainRecord(value) || Object.keys(value).some((key) => !participantIds.has(key))) return false;
  if (arrays && Object.keys(value).length !== participantIds.size) return false;
  return Object.values(value).every((claim) => arrays
    ? Array.isArray(claim)
      && claim.length <= 16
      && claim.every((cardId) => typeof cardId === "string" && cardId.length <= 128)
    : typeof claim === "string" && claim.length <= 128);
}

function validAuthoritativeMatchEvidence(
  value: unknown,
  report: PlayerReportDocument,
): value is AuthoritativeMatchEvidence {
  if (!plainRecord(value) || !exactKeys(value, MATCH_EVIDENCE_KEYS)) return false;
  const participantIds = new Set([report.reporterPlayerId, report.reportedPlayerId]);
  if (value.source !== "ranked-match"
    || !boundedIdentity(value.matchId)
    || !MATCH_STATES.has(value.state as MatchDoc["state"])
    || value.combatValidated !== false
    || !safeDate(value.createdAt)
    || value.createdAt.getTime() > report.createdAt.getTime()
    || report.createdAt.getTime() - value.createdAt.getTime() > MATCH_EVIDENCE_LOOKBACK_MS
    || !validMatchPlayer(value.reporter, report.reporterPlayerId)
    || !validMatchPlayer(value.reportedPlayer, report.reportedPlayerId)
    || !validClaimMap(value.resultClaims, participantIds, false)
    || !validClaimMap(value.relayedCardPlays, participantIds, true)
    || !validClaimMap(value.usedCardClaims, participantIds, true)
    || (value.endedAt !== undefined && (!safeDate(value.endedAt)
      || value.endedAt.getTime() < value.createdAt.getTime()
      || value.endedAt.getTime() > report.createdAt.getTime()))
    || (value.winnerId !== undefined && !participantIds.has(value.winnerId as string))
    || (value.cancelReason !== undefined
      && (typeof value.cancelReason !== "string" || value.cancelReason.length > 64))) return false;
  return true;
}

/** Validate the immutable creation snapshot stored inside the retry-deduplication row. */
export function validatedReportCreation(
  report: PlayerReportDocument,
  now: Date,
): PlayerReportDocument {
  const raw = report as unknown as Record<string, unknown>;
  const evidence = report?.evidence as unknown;
  if (!plainRecord(report)
    || !exactKeys(raw, CREATION_REPORT_KEYS)
    || !REPORT_ID_PATTERN.test(report.reportId)
    || !boundedIdentity(report.reporterPlayerId)
    || !boundedIdentity(report.reportedPlayerId)
    || report.reporterPlayerId === report.reportedPlayerId
    || (report.kind !== "player" && report.kind !== "cheat")
    || !Number.isSafeInteger(report.reportType)
    || report.reportType < 0
    || report.reportType > 100
    || typeof report.message !== "string"
    || report.message.length > 1000
    || (report.kind === "player" && report.message.length < 1)
    || !plainRecord(evidence)
    || !exactKeys(evidence, REPORT_EVIDENCE_KEYS)
    || Object.values(evidence).some((item) => typeof item !== "string" || item.length > 64)
    || report.status !== "open"
    || !safeDate(report.createdAt)
    || !safeDate(now)
    || report.createdAt.getTime() > now.getTime()
    || (report.matchEvidence !== undefined && !validAuthoritativeMatchEvidence(report.matchEvidence, report))) {
    throw new Error("Stored report creation authority is invalid.");
  }
  return report;
}

/**
 * Validate one moderation queue row as an immutable report followed by at most two audited moves.
 * A status field is only a projection: it has no authority unless the ordered review history and
 * exact updatedAt timestamp prove how the row reached that state. This prevents damaged terminal
 * rows from bypassing optimistic review or being published as credible operator decisions.
 */
export function validatedModerationReport(
  report: PlayerReportDocument,
  now: Date,
): PlayerReportDocument {
  const raw = report as unknown as Record<string, unknown>;
  if (!plainRecord(report) || !exactKeys(raw, MODERATION_REPORT_KEYS)) {
    throw new Error("Stored moderation report authority is invalid.");
  }
  // Reuse the creation proof with an explicit open projection. Review-only fields are excluded
  // from this snapshot so they cannot weaken the immutable reporter/target/evidence contract.
  validatedReportCreation({
    reportId: report.reportId,
    reporterPlayerId: report.reporterPlayerId,
    kind: report.kind,
    reportedPlayerId: report.reportedPlayerId,
    reportType: report.reportType,
    message: report.message,
    evidence: report.evidence,
    status: "open",
    ...(report.matchEvidence === undefined ? {} : { matchEvidence: report.matchEvidence }),
    createdAt: report.createdAt,
  }, now);

  const history = report.reviewHistory;
  if (report.status === "open") {
    if (history !== undefined || report.updatedAt !== undefined) {
      throw new Error("Stored moderation report authority is invalid.");
    }
    return report;
  }
  if ((report.status !== "reviewing" && report.status !== "resolved" && report.status !== "dismissed")
    || !Array.isArray(history)
    || history.length < 1
    || history.length > 2
    || !safeDate(report.updatedAt)) {
    throw new Error("Stored moderation report authority is invalid.");
  }

  let projected: PlayerReportDocument["status"] = "open";
  let previousTime = report.createdAt.getTime();
  const operationIds = new Set<string>();
  for (const entry of history) {
    const entryRaw = entry as unknown as Record<string, unknown>;
    const terminal = entry.toStatus === "resolved" || entry.toStatus === "dismissed";
    if (!plainRecord(entry)
      || !exactKeys(entryRaw, REVIEW_ENTRY_KEYS)
      || !/^[A-Za-z0-9._:-]{8,128}$/u.test(entry.operationId)
      || operationIds.has(entry.operationId)
      || entry.fromStatus !== projected
      || (projected === "open"
        ? !["reviewing", "resolved", "dismissed"].includes(entry.toStatus)
        : projected === "reviewing"
          ? !["resolved", "dismissed"].includes(entry.toStatus)
          : true)
      || !boundedIdentity(entry.actor, 100)
      || typeof entry.note !== "string"
      || entry.note.length > 1000
      || (terminal && entry.note.length < 1)
      || !safeDate(entry.createdAt)
      || entry.createdAt.getTime() < previousTime
      || entry.createdAt.getTime() > now.getTime()) {
      throw new Error("Stored moderation report authority is invalid.");
    }
    operationIds.add(entry.operationId);
    projected = entry.toStatus;
    previousTime = entry.createdAt.getTime();
  }
  if (projected !== report.status || report.updatedAt.getTime() !== previousTime) {
    throw new Error("Stored moderation report authority is invalid.");
  }
  return report;
}

/**
 * Bind the complete retry winner to its semantic HMAC identity and exact logical/TTL interval.
 * The embedded report may differ from a concurrent candidate's message or evidence, but the four
 * identity dimensions must match; otherwise damaged durable data could publish a different report.
 */
export function validatedReportDeduplication(
  state: ReportDeduplicationDocument,
  candidate: PlayerReportDocument,
): PlayerReportDocument {
  validatedReportCreation(candidate, candidate.createdAt);
  const raw = state as unknown as Record<string, unknown>;
  const stored = state?.report as unknown as PlayerReportDocument;
  const expectedKey = reportDeduplicationKey(
    candidate.reporterPlayerId,
    candidate.reportedPlayerId,
    candidate.reportType,
    candidate.kind,
  );
  if (!plainRecord(state)
    || !exactKeys(raw, DEDUPLICATION_KEYS)
    || state.key !== expectedKey
    || !/^[0-9a-f]{64}$/u.test(state.key)
    || !safeDate(state.reportCreatedAt)
    || !safeDate(state.expiresAt)) {
    throw new Error("Stored report deduplication authority is invalid.");
  }
  validatedReportCreation(stored, candidate.createdAt);
  const age = candidate.createdAt.getTime() - stored.createdAt.getTime();
  if (stored.reporterPlayerId !== candidate.reporterPlayerId
    || stored.reportedPlayerId !== candidate.reportedPlayerId
    || stored.reportType !== candidate.reportType
    || stored.kind !== candidate.kind
    || state.reportCreatedAt.getTime() !== stored.createdAt.getTime()
    || age < 0
    || age >= DUPLICATE_WINDOW_MS
    || state.expiresAt.getTime() - state.reportCreatedAt.getTime() !== DUPLICATE_WINDOW_MS * 2) {
    throw new Error("Stored report deduplication authority is invalid.");
  }
  return stored;
}

export interface PlayerReportInput {
  reportedPlayerId: string;
  reportType: number;
  message: string;
  evidence: Record<string, string | number>;
}

export interface PlayerReportDocument extends PlayerReportInput {
  reportId: string;
  reporterPlayerId: string;
  kind: "player" | "cheat";
  status: "open" | "reviewing" | "resolved" | "dismissed";
  /** Optional immutable server correlation; client `evidence` remains an untrusted claim. */
  matchEvidence?: AuthoritativeMatchEvidence;
  /** Append-only operator decisions; report status is the projection of the final entry. */
  reviewHistory?: PlayerReportReviewEntry[];
  createdAt: Date;
  updatedAt?: Date;
}

export interface PlayerReportReviewEntry {
  operationId: string;
  fromStatus: PlayerReportDocument["status"];
  toStatus: PlayerReportDocument["status"];
  actor: string;
  note: string;
  createdAt: Date;
}

export interface AuthoritativeMatchEvidence {
  source: "ranked-match";
  matchId: string;
  state: MatchDoc["state"];
  createdAt: Date;
  endedAt?: Date;
  reporter: MatchPlayer;
  reportedPlayer: MatchPlayer;
  /** Present only after the match service has committed a terminal winner. */
  winnerId?: string;
  cancelReason?: string;
  /** These are authenticated reports, not authoritative combat simulation. */
  resultClaims: Record<string, string>;
  /** Accepted relay observations; card effects, damage, and targets are still unverified. */
  relayedCardPlays: Record<string, string[]>;
  usedCardClaims: Record<string, string[]>;
  combatValidated: false;
}

export function reportDeduplicationKey(
  reporterPlayerId: string,
  reportedPlayerId: string,
  reportType: number,
  kind: "player" | "cheat",
): string {
  return createHmac("sha256", config.authSecret)
    .update(`report-dedup:${reporterPlayerId}\0${reportedPlayerId}\0${reportType}\0${kind}`)
    .digest("hex");
}

export function reportIsWithinDuplicateWindow(createdAt: Date, now: Date): boolean {
  const age = now.getTime() - createdAt.getTime();
  return age >= 0 && age < DUPLICATE_WINDOW_MS;
}

function boundedString(value: unknown, maxLength: number): string {
  return typeof value === "string" ? value.trim().slice(0, maxLength) : "";
}

/**
 * Convert the exact recovered request fields into a bounded moderation record. Evidence is
 * retained as submitted context, not trusted as proof: a later moderation tool can compare
 * army power/rank/time values against authoritative match records when those are available.
 */
export function normalizeReportInput(req: Record<string, unknown>, requiresMessage: boolean): PlayerReportInput {
  const reportedPlayerId = boundedString(req.ReportedPlayerId, 128);
  const message = boundedString(req.Message, 1000);
  const reportType = Number(req.ReportType);
  if (!reportedPlayerId) throw new ApiError(ApiErrorCode.PlayerNotFound, "Reported player is required.");
  if (!Number.isInteger(reportType) || reportType < 0 || reportType > 100) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Invalid report type.");
  }
  if (requiresMessage && !message) throw new ApiError(ApiErrorCode.UnknownAction, "A report message is required.");

  const evidence: Record<string, string | number> = {};
  for (const key of ["MyArmyPower", "MyRank", "OpponentArmyPower", "OpponentRank", "TimeOfMatch"] as const) {
    const value = req[key];
    if (typeof value === "string" || typeof value === "number") evidence[key] = String(value).slice(0, 64);
  }
  return { reportedPlayerId, reportType, message, evidence };
}

function boundedCardIds(values: unknown): string[] {
  if (!Array.isArray(values)) return [];
  return values
    .filter((value): value is string => typeof value === "string")
    .slice(0, 16)
    .map((value) => value.slice(0, 128));
}

/**
 * Project one exact two-participant match into a self-describing moderation snapshot.
 *
 * Client-supplied Army Power, rank, and match time are useful statements but are never proof.
 * This projection stores the immutable matchmaking snapshots, terminal state/winner, and each
 * authenticated participant's durable reports under explicit `Claims` names. Relay card events
 * are stronger observations because the hub accepted them in sequence, but `combatValidated`
 * remains false until the backend can validate targets, damage, timing, and effects.
 */
export function buildAuthoritativeMatchEvidence(
  match: MatchDoc,
  reporterPlayerId: string,
  reportedPlayerId: string,
): AuthoritativeMatchEvidence | null {
  if (!reporterPlayerId || !reportedPlayerId || reporterPlayerId === reportedPlayerId) return null;
  const reporter = match.players.find((player) => player.playerId === reporterPlayerId);
  const reportedPlayer = match.players.find((player) => player.playerId === reportedPlayerId);
  if (!reporter || !reportedPlayer || match.players.length !== 2) return null;

  const participantIds = [reporterPlayerId, reportedPlayerId];
  const resultClaims: Record<string, string> = {};
  const relayedCardPlays: Record<string, string[]> = {};
  const usedCardClaims: Record<string, string[]> = {};
  for (const playerId of participantIds) {
    const result = match.resultReports?.[playerId];
    if (typeof result === "string" && result.length <= 128) resultClaims[playerId] = result;
    relayedCardPlays[playerId] = boundedCardIds(match.relayedCardPlays?.[playerId]);
    usedCardClaims[playerId] = boundedCardIds(match.usedCardsReports?.[playerId]);
  }

  return {
    source: "ranked-match",
    matchId: match.matchId,
    state: match.state,
    createdAt: match.createdAt,
    ...(match.endedAt ? { endedAt: match.endedAt } : {}),
    reporter: { ...reporter },
    reportedPlayer: { ...reportedPlayer },
    ...(match.winnerId ? { winnerId: match.winnerId } : {}),
    ...(match.cancelReason ? { cancelReason: match.cancelReason.slice(0, 64) } : {}),
    resultClaims,
    relayedCardPlays,
    usedCardClaims,
    combatValidated: false,
  };
}

/** Find the newest server match that contains both authenticated report parties. */
async function recentAuthoritativeMatchEvidence(
  reporterPlayerId: string,
  reportedPlayerId: string,
  now: Date,
): Promise<AuthoritativeMatchEvidence | null> {
  const match = await matches().findOne(
    {
      "players.playerId": { $all: [reporterPlayerId, reportedPlayerId] },
      createdAt: { $gte: new Date(now.getTime() - MATCH_EVIDENCE_LOOKBACK_MS) },
    },
    { sort: { createdAt: -1 } },
  ) as unknown as MatchDoc | null;
  const evidenceReadAt = new Date();
  return match
    ? buildAuthoritativeMatchEvidence(
      validatedMatchDocument(match, evidenceReadAt),
      reporterPlayerId,
      reportedPlayerId,
    )
    : null;
}

/**
 * Select and persist one winning report payload for a target/type window.
 *
 * The atomic pipeline stores the full winner, not merely a lock. Every concurrent caller then
 * upserts that exact reportId/payload, so a response race cannot produce duplicates or let a
 * later request overwrite the first request's message/evidence. Logical expiry is checked here;
 * MongoDB TTL is only delayed storage cleanup and never controls replay correctness.
 */
async function persistDeduplicatedReport(
  candidate: PlayerReportDocument,
  retry = 0,
): Promise<PlayerReportDocument> {
  const key = reportDeduplicationKey(
    candidate.reporterPlayerId,
    candidate.reportedPlayerId,
    candidate.reportType,
    candidate.kind,
  );
  const cutoff = new Date(candidate.createdAt.getTime() - DUPLICATE_WINDOW_MS);
  const expiresAt = new Date(candidate.createdAt.getTime() + DUPLICATE_WINDOW_MS * 2);
  try {
    const winner = await reportDeduplications().findOneAndUpdate(
      { key },
      [
        { $set: { _replace: { $lte: [{ $ifNull: ["$reportCreatedAt", new Date(0)] }, cutoff] } } },
        { $set: {
          key,
          report: { $cond: ["$_replace", candidate, { $ifNull: ["$report", candidate] }] },
          reportCreatedAt: { $cond: ["$_replace", candidate.createdAt, { $ifNull: ["$reportCreatedAt", candidate.createdAt] }] },
          expiresAt: { $cond: ["$_replace", expiresAt, { $ifNull: ["$expiresAt", expiresAt] }] },
        } },
        { $unset: "_replace" },
      ],
      { upsert: true, returnDocument: "after" },
    );
    if (!winner?.report) throw new Error("Report deduplication winner was not persisted.");
    const stored = validatedReportDeduplication(winner, candidate);
    await reports().updateOne({ reportId: stored.reportId }, { $setOnInsert: stored }, { upsert: true });
    return stored;
  } catch (error) {
    if ((error as { code?: number }).code === 11000 && retry < 2) {
      return persistDeduplicatedReport(candidate, retry + 1);
    }
    throw error;
  }
}

/**
 * Persist a report with two abuse controls. A rolling per-reporter limit blocks report spam,
 * while an identical target/type report inside ten minutes reuses the existing record. The
 * latter makes client retries idempotent without hiding distinct reports about new behavior.
 */
export async function submitPlayerReport(
  reporterPlayerId: string,
  kind: "player" | "cheat",
  input: PlayerReportInput,
): Promise<PlayerReportDocument> {
  if (input.reportedPlayerId === reporterPlayerId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "A player cannot report their own account.");
  }
  if (!(await findById(input.reportedPlayerId))) {
    throw new ApiError(ApiErrorCode.PlayerNotFound, "Reported player not found.");
  }

  // Preserve the cheap sequential lost-response path before reserving rate capacity. The atomic
  // winner below is still required because simultaneous callers can both miss this read.
  const duplicate = await reports().findOne({
    reporterPlayerId,
    reportedPlayerId: input.reportedPlayerId,
    reportType: input.reportType,
    kind,
    createdAt: { $gte: new Date(Date.now() - DUPLICATE_WINDOW_MS) },
  });
  if (duplicate) return duplicate as unknown as PlayerReportDocument;

  await reserveReportSubmission(reporterPlayerId);

  const createdAt = new Date();
  // Correlation is optional by design. SendPlayerReport is also available from social/profile
  // screens, and legacy Photon matches may not have a replacement-backend match row. Absence is
  // recorded as absence; it must not reject a valid moderation complaint or fabricate evidence.
  const matchEvidence = await recentAuthoritativeMatchEvidence(
    reporterPlayerId,
    input.reportedPlayerId,
    createdAt,
  );
  const doc: PlayerReportDocument = {
    reportId: randomUUID(),
    reporterPlayerId,
    kind,
    ...input,
    status: "open",
    ...(matchEvidence ? { matchEvidence } : {}),
    createdAt,
  };
  return persistDeduplicatedReport(doc);
}
