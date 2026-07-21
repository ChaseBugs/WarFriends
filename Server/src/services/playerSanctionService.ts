import { randomUUID } from "crypto";
import type { Collection } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  playerSanctions,
  type PlayerDocument,
  type PlayerSanctionDocument,
} from "../db";

const MIN_TEMPORARY_BAN_SECONDS = 60;
const MAX_TEMPORARY_BAN_SECONDS = 10 * 365 * 24 * 60 * 60;
const MAX_REASON_LENGTH = 500;
const MAX_ACTOR_LENGTH = 100;
const OPERATION_ID_PATTERN = /^[A-Za-z0-9._:-]{8,128}$/u;
const SANCTION_ID_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu;

export class PlayerSanctionInputError extends Error {
  constructor(
    message: string,
    readonly httpStatus: 400 | 404 | 409,
  ) {
    super(message);
    this.name = "PlayerSanctionInputError";
  }
}

export interface IssuePlayerSanctionInput {
  playerId: string;
  reason: string;
  issuedBy: string;
  operationId: string;
  /** Omit for a permanent account ban. */
  durationSeconds?: number;
}

export interface RevokePlayerSanctionInput {
  sanctionId: string;
  reason: string;
  revokedBy: string;
  operationId: string;
}

export interface SanctionMutationResult {
  sanction: PlayerSanctionDocument;
  replayed: boolean;
}

function boundedText(value: unknown, field: string, maximum: number): string {
  if (typeof value !== "string") {
    throw new PlayerSanctionInputError(`${field} must be a string.`, 400);
  }
  const normalized = value.trim().replace(/\s+/gu, " ");
  if (normalized.length < 1 || normalized.length > maximum) {
    throw new PlayerSanctionInputError(`${field} must contain 1-${maximum} characters.`, 400);
  }
  return normalized;
}

export function normalizeSanctionOperationId(value: unknown): string {
  const operationId = typeof value === "string" ? value.trim() : "";
  if (!OPERATION_ID_PATTERN.test(operationId)) {
    throw new PlayerSanctionInputError(
      "Idempotency-Key must contain 8-128 letters, digits, dots, underscores, colons, or hyphens.",
      400,
    );
  }
  return operationId;
}

export function normalizeSanctionId(value: unknown): string {
  const sanctionId = typeof value === "string" ? value.trim() : "";
  if (!SANCTION_ID_PATTERN.test(sanctionId)) {
    throw new PlayerSanctionInputError("sanctionId must be a version-4 UUID.", 400);
  }
  return sanctionId;
}

export function normalizeSanctionActor(value: unknown): string {
  return boundedText(value, "X-Admin-Actor", MAX_ACTOR_LENGTH);
}

export function normalizeSanctionReason(value: unknown): string {
  return boundedText(value, "reason", MAX_REASON_LENGTH);
}

export function normalizeTemporaryBanSeconds(value: unknown): number | undefined {
  if (value === undefined || value === null || value === "") return undefined;
  const seconds = Number(value);
  if (!Number.isSafeInteger(seconds) ||
      seconds < MIN_TEMPORARY_BAN_SECONDS ||
      seconds > MAX_TEMPORARY_BAN_SECONDS) {
    throw new PlayerSanctionInputError(
      `durationSeconds must be an integer from ${MIN_TEMPORARY_BAN_SECONDS} to ${MAX_TEMPORARY_BAN_SECONDS}.`,
      400,
    );
  }
  return seconds;
}

export function normalizeSanctionPlayerId(value: unknown): string {
  return boundedText(value, "playerId", 256);
}

export function activeSanctionAt(
  sanction: Pick<PlayerSanctionDocument, "status" | "expiresAt"> | null,
  now: Date,
): boolean {
  return sanction?.status === "active" &&
    (sanction.expiresAt === undefined || sanction.expiresAt.getTime() > now.getTime());
}

/**
 * Ping is transport liveness and Identify performs the full credential-plus-sanction check itself.
 * Every other authenticated WebSocket message can read or mutate live game state, so it must
 * revalidate the durable sanction record. This closes the long-lived-session window after an
 * operator bans a player who already completed Identify.
 */
export function webSocketMessageRequiresSanctionCheck(messageType: unknown): boolean {
  return messageType !== "Identify" && messageType !== "Ping";
}

/**
 * Convert a private moderation row into only the fields consumed by LEDNENKKDJM's recovered
 * AccountBanned branch. The internal reason and operator identity are deliberately not exposed.
 */
export function accountBannedError(
  player: Pick<PlayerDocument, "id" | "accountName">,
  sanction: Pick<PlayerSanctionDocument, "expiresAt">,
  now: Date,
): ApiError {
  const details: Record<string, unknown> = {
    accountId: player.id,
    accountName: player.accountName,
  };
  if (sanction.expiresAt) {
    // The client formats a duration from an integer `seconds` field. Ceil keeps a temporary ban
    // visible until its actual deadline and avoids accidentally sending zero on the final second.
    details.seconds = Math.max(1, Math.ceil((sanction.expiresAt.getTime() - now.getTime()) / 1000));
  }
  return new ApiError(ApiErrorCode.AccountBanned, "Account access is suspended.", details);
}

export async function assertPlayerNotSanctioned(
  player: Pick<PlayerDocument, "id" | "accountName">,
  now = new Date(),
  collection: Collection<PlayerSanctionDocument> = playerSanctions(),
): Promise<void> {
  const sanction = await collection.findOne({
    playerId: player.id,
    status: "active",
    $or: [
      { expiresAt: { $exists: false } },
      { expiresAt: { $gt: now } },
    ],
  });
  if (sanction) throw accountBannedError(player, sanction, now);
}

function sameIssueIntent(existing: PlayerSanctionDocument, input: IssuePlayerSanctionInput): boolean {
  return existing.playerId === input.playerId &&
    existing.reason === input.reason &&
    existing.issuedBy === input.issuedBy &&
    existing.durationSeconds === input.durationSeconds;
}

/**
 * Issue one permanent or temporary account ban with a durable operator idempotency key.
 *
 * The partial unique index is the concurrency authority. Two different operations cannot both
 * become active, while a retried operation returns its original row rather than generating a
 * second audit record or moving a temporary deadline forward.
 */
export async function issuePlayerSanction(
  input: IssuePlayerSanctionInput,
  now = new Date(),
  collection: Collection<PlayerSanctionDocument> = playerSanctions(),
): Promise<SanctionMutationResult> {
  const existingOperation = await collection.findOne({ operationId: input.operationId });
  if (existingOperation) {
    if (!sameIssueIntent(existingOperation, input)) {
      throw new PlayerSanctionInputError("Idempotency-Key was already used for another sanction.", 409);
    }
    return { sanction: existingOperation, replayed: true };
  }

  // An elapsed temporary row must not continue owning the active partial-index slot. This write
  // is storage/audit normalization only; assertPlayerNotSanctioned already enforces time directly.
  await collection.updateMany(
    { playerId: input.playerId, status: "active", expiresAt: { $lte: now } },
    { $set: { status: "expired", resolvedAt: now } },
  );

  const sanction: PlayerSanctionDocument = {
    _id: randomUUID(),
    playerId: input.playerId,
    status: "active",
    reason: input.reason,
    issuedBy: input.issuedBy,
    issuedAt: now,
    operationId: input.operationId,
    ...(input.durationSeconds === undefined ? {} : {
      durationSeconds: input.durationSeconds,
      expiresAt: new Date(now.getTime() + input.durationSeconds * 1000),
    }),
  };

  try {
    await collection.insertOne(sanction);
    return { sanction, replayed: false };
  } catch (error) {
    if ((error as { code?: number }).code !== 11000) throw error;
    const replayWinner = await collection.findOne({ operationId: input.operationId });
    if (replayWinner && sameIssueIntent(replayWinner, input)) {
      return { sanction: replayWinner, replayed: true };
    }
    throw new PlayerSanctionInputError("The player already has an active sanction.", 409);
  }
}

export async function revokePlayerSanction(
  input: RevokePlayerSanctionInput,
  now = new Date(),
  collection: Collection<PlayerSanctionDocument> = playerSanctions(),
): Promise<SanctionMutationResult> {
  const existing = await collection.findOne({ _id: input.sanctionId });
  if (!existing) throw new PlayerSanctionInputError("Sanction was not found.", 404);
  if (existing.revocationOperationId === input.operationId) {
    if (existing.revokedBy !== input.revokedBy || existing.revocationReason !== input.reason) {
      throw new PlayerSanctionInputError("Idempotency-Key was already used for another revocation.", 409);
    }
    return { sanction: existing, replayed: true };
  }
  if (!activeSanctionAt(existing, now)) {
    if (existing.status === "active") {
      await collection.updateOne(
        { _id: existing._id, status: "active" },
        { $set: { status: "expired", resolvedAt: now } },
      );
    }
    throw new PlayerSanctionInputError("Only an active, unexpired sanction can be revoked.", 409);
  }

  let updated: PlayerSanctionDocument | null;
  try {
    updated = await collection.findOneAndUpdate(
      { _id: existing._id, status: "active" },
      { $set: {
        status: "revoked",
        revokedAt: now,
        revokedBy: input.revokedBy,
        revocationReason: input.reason,
        revocationOperationId: input.operationId,
        resolvedAt: now,
      } },
      { returnDocument: "after" },
    );
  } catch (error) {
    if ((error as { code?: number }).code === 11000) {
      throw new PlayerSanctionInputError("Idempotency-Key was already used for another revocation.", 409);
    }
    throw error;
  }
  if (updated) return { sanction: updated, replayed: false };

  // A concurrent retry may have committed between the initial read and compare-and-set update.
  const winner = await collection.findOne({ _id: existing._id });
  if (winner?.revocationOperationId === input.operationId &&
      winner.revokedBy === input.revokedBy &&
      winner.revocationReason === input.reason) {
    return { sanction: winner, replayed: true };
  }
  throw new PlayerSanctionInputError("Sanction state changed before revocation.", 409);
}

export async function listPlayerSanctions(
  playerId: string,
  collection: Collection<PlayerSanctionDocument> = playerSanctions(),
): Promise<PlayerSanctionDocument[]> {
  return collection.find({ playerId }).sort({ issuedAt: -1 }).limit(100).toArray();
}
