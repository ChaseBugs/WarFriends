import { randomUUID } from "crypto";
import { reports } from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { findById } from "./playerService";

const REPORTS_PER_HOUR = 5;
const DUPLICATE_WINDOW_MS = 10 * 60 * 1000;

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
  createdAt: Date;
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

  const duplicateSince = new Date(Date.now() - DUPLICATE_WINDOW_MS);
  const duplicate = await reports().findOne({
    reporterPlayerId,
    reportedPlayerId: input.reportedPlayerId,
    reportType: input.reportType,
    kind,
    createdAt: { $gte: duplicateSince },
  });
  if (duplicate) return duplicate as unknown as PlayerReportDocument;

  const hourAgo = new Date(Date.now() - 60 * 60 * 1000);
  const recentCount = await reports().countDocuments({ reporterPlayerId, createdAt: { $gte: hourAgo } });
  if (recentCount >= REPORTS_PER_HOUR) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Report rate limit reached. Try again later.");
  }

  const doc: PlayerReportDocument = {
    reportId: randomUUID(),
    reporterPlayerId,
    kind,
    ...input,
    status: "open",
    createdAt: new Date(),
  };
  await reports().insertOne(doc);
  return doc;
}
