import { createHmac, randomUUID } from "crypto";
import { matches, reportDeduplications, reports } from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { findById } from "./playerService";
import type { MatchDoc, MatchPlayer } from "./matchService";
import { reserveReportSubmission } from "./reportRateLimitService";

const DUPLICATE_WINDOW_MS = 10 * 60 * 1000;
const MATCH_EVIDENCE_LOOKBACK_MS = 6 * 60 * 60 * 1000;

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
  return match ? buildAuthoritativeMatchEvidence(match, reporterPlayerId, reportedPlayerId) : null;
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
    const stored = winner.report as unknown as PlayerReportDocument;
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
