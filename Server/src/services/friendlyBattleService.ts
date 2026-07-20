import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  friendlyBattles,
  type FriendlyBattleDocument,
} from "../db";

const ACTIVE_RECEIPT_TTL_MS = 24 * 60 * 60 * 1_000;
const FINISHED_RECEIPT_TTL_MS = 7 * 24 * 60 * 60 * 1_000;
const BATTLE_ID_PATTERN = /^[\w.:@+-]+$/;
const FRIENDLY_END_REASONS = new Set([1, 2, 3, 5, 8]);

export type FriendlyBattleStartDecision = "create" | "replay" | "invalid";
export type FriendlyBattleSettlementDecision = "settle" | "replay" | "invalid";

function validPlayerId(value: string): boolean {
  return value.length > 0 && value.length <= 160;
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
): FriendlyBattleStartDecision {
  validateFriendlyBattleId(battleId);
  validateStartAction(startAction);
  if (!validPlayerId(playerId)) return "invalid";
  if (!existing) return "create";
  if (existing.playerId !== playerId || existing.battleId !== battleId) return "invalid";

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
): FriendlyBattleSettlementDecision {
  validateFriendlyBattleId(battleId);
  validateEndReason(endReason);
  if (!validPlayerId(playerId) || !existing) return "invalid";
  if (existing.playerId !== playerId || existing.battleId !== battleId) return "invalid";
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
 * Issue one authenticated, no-reward challenge receipt from action 64 or 65.
 *
 * This does not require an accepted inbox row because AcceptChallenge is sent asynchronously
 * after the recipient begins joining Photon. Requiring that unrelated HTTP request to win the
 * race would randomly reject legitimate fast joins. The receipt itself grants nothing and only
 * prevents a later GameEnded call from being mistaken for ranked matchmaking.
 */
export async function startFriendlyBattle(
  playerId: string,
  battleId: string,
  startAction: number,
  now = new Date(),
): Promise<FriendlyBattleMutationResult> {
  const decision = friendlyBattleStartDecision(null, playerId, battleId, startAction);
  if (decision !== "create") {
    throw new ApiError(ApiErrorCode.UnknownAction, "Friendly battle start is invalid.");
  }
  validateStartAction(startAction);
  const receipt: FriendlyBattleDocument = {
    playerId,
    battleId,
    startAction,
    state: "active",
    startedAt: now,
    expiresAt: new Date(now.getTime() + ACTIVE_RECEIPT_TTL_MS),
  };

  const write = await friendlyBattles().updateOne(
    { playerId, battleId },
    { $setOnInsert: receipt },
    { upsert: true },
  );
  if (write.upsertedCount === 1) return { receipt, replayed: false };

  const existing = await friendlyBattles().findOne({ playerId, battleId });
  if (friendlyBattleStartDecision(existing, playerId, battleId, startAction) !== "replay" || !existing) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Friendly battle receipt conflicts with this start.");
  }
  return { receipt: existing, replayed: true };
}

export async function findFriendlyBattle(
  playerId: string,
  battleId: string,
): Promise<FriendlyBattleDocument | null> {
  validateFriendlyBattleId(battleId);
  return friendlyBattles().findOne({ playerId, battleId });
}

/**
 * Consume one participant's friendly receipt without touching any gameplay progression.
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
  const existing = await findFriendlyBattle(playerId, battleId);
  const decision = friendlyBattleSettlementDecision(existing, playerId, battleId, endReason);
  if (decision === "invalid" || !existing) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Friendly battle receipt is missing or conflicts with this result.");
  }
  if (decision === "replay") return { receipt: existing, replayed: true };
  validateEndReason(endReason);

  const settledAt = now;
  const expiresAt = new Date(now.getTime() + FINISHED_RECEIPT_TTL_MS);
  const write = await friendlyBattles().updateOne(
    { playerId, battleId, state: "active" },
    { $set: { state: "finished", endReason, settledAt, expiresAt } },
  );
  if (write.modifiedCount === 1) {
    return {
      receipt: { ...existing, state: "finished", endReason, settledAt, expiresAt },
      replayed: false,
    };
  }

  const winner = await friendlyBattles().findOne({ playerId, battleId });
  if (friendlyBattleSettlementDecision(winner, playerId, battleId, endReason) !== "replay" || !winner) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Concurrent friendly battle settlement conflicted.");
  }
  return { receipt: winner, replayed: true };
}
