import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  friendlyBattles,
  type FriendlyBattleDocument,
} from "../db";

const ACTIVE_RECEIPT_TTL_MS = 24 * 60 * 60 * 1_000;
const FINISHED_RECEIPT_TTL_MS = 7 * 24 * 60 * 60 * 1_000;
const BATTLE_ID_PATTERN = /^[\w.:@+-]+$/;
const FRIENDLY_END_REASONS = new Set([1, 2, 3, 5, 8]);
const RECEIPT_KEYS = new Set([
  "_id", "playerId", "battleId", "battleKind", "startAction", "state", "startedAt",
  "settledAt", "endReason", "expiresAt",
]);

export type FriendlyBattleStartDecision = "create" | "replay" | "invalid";
export type FriendlyBattleSettlementDecision = "settle" | "replay" | "invalid";
export type NoRewardBattleKind = "friendly" | "offline-bot";

export interface OfflineBotStartMetadata {
  botId: number;
  botLevel: number;
}

function validPlayerId(value: string): boolean {
  return value.length > 0
    && value.length <= 160
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
}

function validDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() > 0;
}

function invalidStoredReceipt(): never {
  throw new Error("Stored friendly battle receipt is invalid.");
}

/**
 * Validate the complete participant-owned zero-reward lifecycle before any replay or settlement.
 *
 * MongoDB TTL cleanup is asynchronous, so `expiresAt` cannot merely be trusted as storage policy.
 * The exact active/finished interval proves which fields may exist and prevents a damaged or stale
 * receipt from being treated as a valid challenge/offline-bot result. Missing `battleKind` is the
 * sole legacy migration and means the original direct-Photon-challenge path.
 */
export function validatedFriendlyBattleReceipt(
  receipt: FriendlyBattleDocument,
): FriendlyBattleDocument {
  if (!receipt
    || typeof receipt !== "object"
    || Object.keys(receipt).some((key) => !RECEIPT_KEYS.has(key))
    || !validPlayerId(receipt.playerId)
    || !receipt.battleId
    || receipt.battleId.length > 160
    || !BATTLE_ID_PATTERN.test(receipt.battleId)
    || (receipt.battleKind !== undefined
      && receipt.battleKind !== "friendly"
      && receipt.battleKind !== "offline-bot")
    || (receipt.startAction !== 64 && receipt.startAction !== 65)
    || (receipt.state !== "active" && receipt.state !== "finished")
    || !validDate(receipt.startedAt)
    || !validDate(receipt.expiresAt)) invalidStoredReceipt();

  if (receipt.state === "active") {
    if (receipt.settledAt !== undefined
      || receipt.endReason !== undefined
      || receipt.expiresAt.getTime() - receipt.startedAt.getTime() !== ACTIVE_RECEIPT_TTL_MS) {
      invalidStoredReceipt();
    }
    return receipt;
  }

  if (!validDate(receipt.settledAt)
    || receipt.settledAt.getTime() < receipt.startedAt.getTime()
    || !FRIENDLY_END_REASONS.has(receipt.endReason ?? 0)
    || receipt.expiresAt.getTime() - receipt.settledAt.getTime() !== FINISHED_RECEIPT_TTL_MS) {
    invalidStoredReceipt();
  }
  return receipt;
}

function validAuthoritativeTime(now: Date): void {
  if (!validDate(now)) throw new ApiError(ApiErrorCode.InternalServerError, "Friendly battle server time is invalid.");
}

/**
 * Validate the three fields emitted only by GameControllerDeathMatchOffline.
 *
 * They are classification evidence, not combat authority, and are deliberately not persisted:
 * a modified APK can forge all three. Their sole effect is selecting the isolated zero-reward
 * receipt path, so accepting them can never mint progression. Bounding them still prevents this
 * compatibility endpoint from becoming an oversized parsing/logging surface.
 */
export function parseOfflineBotStartMetadata(
  botIdValue: unknown,
  botNameValue: unknown,
  botLevelValue: unknown,
): OfflineBotStartMetadata {
  // BestHTTP sends invariant decimal strings; JSON tooling may send numbers. Do not use loose
  // Number(value) here because it turns null, false, and an empty string into the valid integer 0.
  const parseWireInteger = (value: unknown): number => {
    if (typeof value === "number") return value;
    if (typeof value === "string" && /^\d{1,7}$/u.test(value)) return Number(value);
    return Number.NaN;
  };
  const botId = parseWireInteger(botIdValue);
  const botLevel = parseWireInteger(botLevelValue);
  const botName = typeof botNameValue === "string" ? botNameValue.trim() : "";
  if (!Number.isSafeInteger(botId) || botId < 0 || botId > 1_000_000) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Offline bot ID is invalid.");
  }
  // BotLevel is the zero-based level written by the recovered action-64 call. The 4.9.5
  // LevelManager contains exactly 58 rows, so values outside 0..57 are not source-valid.
  if (!Number.isSafeInteger(botLevel) || botLevel < 0 || botLevel > 57) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Offline bot level is invalid.");
  }
  if (!botName || botName.length > 100 || /[\u0000-\u001f\u007f]/u.test(botName)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Offline bot name is invalid.");
  }
  return { botId, botLevel };
}

/**
 * Validate the battle ID copied from Photon room custom property `battleID`.
 *
 * The character and length boundary matches the existing mission receipt contract. Accepting
 * arbitrary objects, whitespace, or unbounded strings here would let a client turn this small
 * idempotency collection into an unbounded storage/logging surface.
 */
export function validateFriendlyBattleId(value: string): void {
  if (!value || value.length > 160 || !BATTLE_ID_PATTERN.test(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "BattleId is invalid.");
  }
}

function validateStartAction(value: number): asserts value is 64 | 65 {
  if (value !== 64 && value !== 65) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Friendly battle start action is invalid.");
  }
}

function validateEndReason(value: number): asserts value is 1 | 2 | 3 | 5 | 8 {
  // Recovered PvP outcomes are Killed, Win, WinByForfeit, Forfeit, and Kia. Mission-only
  // outcomes 9/10 and the uninitialized value 0 must not be accepted as a challenge result.
  if (!Number.isInteger(value) || !FRIENDLY_END_REASONS.has(value)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "EndReason is invalid for a friendly battle.");
  }
}

/** Pure state decision used by the database path and regression tests. */
export function friendlyBattleStartDecision(
  existing: FriendlyBattleDocument | null,
  playerId: string,
  battleId: string,
  startAction: number,
  battleKind: NoRewardBattleKind = "friendly",
  now?: Date,
): FriendlyBattleStartDecision {
  validateFriendlyBattleId(battleId);
  validateStartAction(startAction);
  if (now) validAuthoritativeTime(now);
  if (!validPlayerId(playerId)) return "invalid";
  if (!existing) return "create";
  validatedFriendlyBattleReceipt(existing);
  if (existing.playerId !== playerId || existing.battleId !== battleId) return "invalid";
  if ((existing.battleKind ?? "friendly") !== battleKind) return "invalid";
  if (now && existing.expiresAt.getTime() <= now.getTime()) return "invalid";

  // Photon can promote a client to master during reconnect. Role is useful telemetry, but it is
  // not reward authority, so action 64/65 retries share the same participant-owned receipt.
  return existing.state === "active" || existing.state === "finished" ? "replay" : "invalid";
}

/** Pure state decision used by the compare-and-set settlement and regression tests. */
export function friendlyBattleSettlementDecision(
  existing: FriendlyBattleDocument | null,
  playerId: string,
  battleId: string,
  endReason: number,
  now?: Date,
): FriendlyBattleSettlementDecision {
  validateFriendlyBattleId(battleId);
  validateEndReason(endReason);
  if (now) validAuthoritativeTime(now);
  if (!validPlayerId(playerId) || !existing) return "invalid";
  validatedFriendlyBattleReceipt(existing);
  if (existing.playerId !== playerId || existing.battleId !== battleId) return "invalid";
  if (now && (existing.startedAt.getTime() > now.getTime() || existing.expiresAt.getTime() <= now.getTime())) {
    return "invalid";
  }
  if (existing.state === "active") return "settle";

  // A lost response must be replayable, but changing the outcome after the first terminal write
  // is not a retry. Reject that contradiction even though friendly battles carry no rewards.
  return existing.state === "finished" && existing.endReason === endReason ? "replay" : "invalid";
}

export interface FriendlyBattleMutationResult {
  receipt: FriendlyBattleDocument;
  replayed: boolean;
}

/**
 * Issue one authenticated, no-reward battle receipt from action 64 or 65.
 *
 * A friendly receipt does not require an accepted inbox row because AcceptChallenge is sent
 * asynchronously after the recipient begins joining Photon. An offline-bot receipt instead
 * classifies GameControllerDeathMatchOffline after its metadata has been bounded by the caller.
 * Neither kind grants anything; both exist only to prevent a later GameEnded call from being
 * mistaken for ranked matchmaking.
 */
export async function startFriendlyBattle(
  playerId: string,
  battleId: string,
  startAction: number,
  battleKind: NoRewardBattleKind = "friendly",
  now = new Date(),
): Promise<FriendlyBattleMutationResult> {
  validAuthoritativeTime(now);
  const decision = friendlyBattleStartDecision(null, playerId, battleId, startAction, battleKind);
  if (decision !== "create") {
    throw new ApiError(ApiErrorCode.UnknownAction, "Friendly battle start is invalid.");
  }
  validateStartAction(startAction);
  const receipt: FriendlyBattleDocument = {
    playerId,
    battleId,
    battleKind,
    startAction,
    state: "active",
    startedAt: now,
    expiresAt: new Date(now.getTime() + ACTIVE_RECEIPT_TTL_MS),
  };
  validatedFriendlyBattleReceipt(receipt);

  const write = await friendlyBattles().updateOne(
    { playerId, battleId },
    { $setOnInsert: receipt },
    { upsert: true },
  );
  if (write.upsertedCount === 1) return { receipt, replayed: false };

  const existing = await friendlyBattles().findOne({ playerId, battleId });
  if (friendlyBattleStartDecision(existing, playerId, battleId, startAction, battleKind, now) !== "replay" || !existing) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Friendly battle receipt conflicts with this start.");
  }
  return { receipt: existing, replayed: true };
}

export async function findFriendlyBattle(
  playerId: string,
  battleId: string,
): Promise<FriendlyBattleDocument | null> {
  validateFriendlyBattleId(battleId);
  const receipt = await friendlyBattles().findOne({ playerId, battleId });
  return receipt ? validatedFriendlyBattleReceipt(receipt) : null;
}

/**
 * Consume one participant's no-reward receipt without touching any gameplay progression.
 *
 * The state transition is a compare-and-set. Concurrent identical GameEnded requests converge
 * on the stored terminal row; a different result cannot overwrite it. Keeping this collection
 * separate from ranked matches is the central authority boundary: no code in this service can
 * grant currency, XP, medals, league progress, cards, squad points, assignments, or rentals.
 */
export async function settleFriendlyBattle(
  playerId: string,
  battleId: string,
  endReason: number,
  now = new Date(),
): Promise<FriendlyBattleMutationResult> {
  validAuthoritativeTime(now);
  const existing = await findFriendlyBattle(playerId, battleId);
  const decision = friendlyBattleSettlementDecision(existing, playerId, battleId, endReason, now);
  if (decision === "invalid" || !existing) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Friendly battle receipt is missing or conflicts with this result.");
  }
  if (decision === "replay") return { receipt: existing, replayed: true };
  validateEndReason(endReason);

  const settledAt = now;
  const expiresAt = new Date(now.getTime() + FINISHED_RECEIPT_TTL_MS);
  const write = await friendlyBattles().updateOne(
    { playerId, battleId, state: "active", expiresAt: { $gt: now } },
    { $set: { state: "finished", endReason, settledAt, expiresAt } },
  );
  if (write.modifiedCount === 1) {
    const receipt = validatedFriendlyBattleReceipt({
      ...existing,
      state: "finished",
      endReason,
      settledAt,
      expiresAt,
    });
    return {
      receipt,
      replayed: false,
    };
  }

  const winner = await friendlyBattles().findOne({ playerId, battleId });
  if (friendlyBattleSettlementDecision(winner, playerId, battleId, endReason, now) !== "replay" || !winner) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Concurrent friendly battle settlement conflicted.");
  }
  return { receipt: winner, replayed: true };
}
