import { ApiError, ApiErrorCode } from "../apiErrors";
import { messages, type PlayerDocument, type PlayerProgressionState, type SquadDocument } from "../db";
import { mutateProgression } from "./progressionMutationService";
import { findById } from "./playerService";
import { getByName } from "./squadService";
import type { MessageDoc } from "./socialService";
import {
  requestedSquadChatCursor,
  validatedSquadChatCursor,
} from "./squadChatCursorAuthorityService";

const SQUAD_EVENT_MESSAGE_TYPE = 21;
const DEPOSIT_WARCARDS_MESSAGE_TYPE = 28;

export interface SquadChatCursorMutation {
  state: PlayerProgressionState;
  timestamp: number;
}

/**
 * Advance the player's squad-chat read cursor without allowing rollback or an arbitrary
 * future timestamp.
 *
 * The recovered PlayerAnalytics setter emits action 193 only when its local value increases,
 * but the server repeats both checks because request buffers can be replayed or modified.
 * Allowing a far-future value would permanently hide legitimate unread notifications on all
 * of the player's devices, so only a small clock-skew window beyond server time is accepted.
 */
export function advanceSquadChatCursorState(
  state: PlayerProgressionState,
  now: number,
  requestedTimestamp: number,
): SquadChatCursorMutation {
  const current = validatedSquadChatCursor(state.lastSeenSquadChatTimestamp, now);
  const timestamp = requestedSquadChatCursor(requestedTimestamp, now);
  if (timestamp <= current) {
    // A second device can flush an older RequestBuffer after another device has already read
    // further into the channel. Acknowledge the authoritative cursor without fabricating a
    // progression revision or replacing identical state.
    return { state, timestamp: current };
  }

  if (!Number.isSafeInteger(state.revision) || state.revision < 0 || state.revision === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Squad chat cursor progression revision is invalid.");
  }
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      lastSeenSquadChatTimestamp: timestamp,
    },
    timestamp,
  };
}

export function saveSquadChatCursor(playerId: string, timestamp: number): Promise<SquadChatCursorMutation> {
  return mutateProgression(playerId, (state, now) => advanceSquadChatCursorState(state, now, timestamp));
}

/** Build the minimal typed inbox message parsed by IIPKANOGHOA/HHFHFANGCEJ. */
export function buildSquadEventMessage(
  actor: PlayerDocument,
  squad: SquadDocument,
  createdAt: Date,
): MessageDoc {
  const unixTimestamp = Math.floor(createdAt.getTime() / 1_000);
  return {
    // HHFHFANGCEJ extracts the numeric suffix after the final dash as its timestamp.
    messageId: `${actor.id}-${unixTimestamp}`,
    toPlayerId: squad.founderId,
    fromPlayerId: actor.id,
    fromName: actor.player.accountName,
    body: "A squad event is available.",
    messageType: SQUAD_EVENT_MESSAGE_TYPE,
    payload: {},
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt,
  };
}

/**
 * Deliver the recovered `InformSquadLeaderAboutEvent` notification to the actual founder.
 *
 * SquadId is treated as a claim, not authority: the authenticated actor must currently be a
 * member of that exact squad. The target comes from the server-owned founderId, so a client
 * cannot redirect the message. Because the old request carries no operation/event id, one
 * notification per actor and UTC day is the narrowest deterministic retry key available.
 */
export async function informSquadLeaderAboutEvent(
  actorId: string,
  requestedSquadName: string,
): Promise<MessageDoc | null> {
  const actor = await findById(actorId);
  if (!actor) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  const squad = await getByName(requestedSquadName);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  if (actor.player.squadName !== squad.name || !squad.members.some((member) => member.playerId === actorId)) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not a member of this squad.");
  }

  // The founder already owns the destination inbox. A self-notification adds no information,
  // so acknowledge it without creating a message that immediately appears to its sender.
  if (squad.founderId === actorId) return null;

  const now = new Date();
  const dayKey = now.toISOString().slice(0, 10);
  const idempotencyKey = `squad-event:${squad.name}:${actorId}:${dayKey}`;
  const message = buildSquadEventMessage(actor, squad, now);
  try {
    const result = await messages().findOneAndUpdate(
      { idempotencyKey },
      { $setOnInsert: { ...message, idempotencyKey } },
      { upsert: true, returnDocument: "after" },
    );
    if (result) return result as unknown as MessageDoc;
  } catch (error) {
    // Two server nodes can race on the first upsert. The unique idempotency index makes one
    // insert win; the loser converts duplicate-key into the already-created success below.
    if ((error as { code?: number }).code !== 11000) throw error;
  }
  const existing = await messages().findOne({ idempotencyKey });
  if (!existing) throw new ApiError(ApiErrorCode.InternalServerError, "Squad event notification was not persisted.");
  return existing as unknown as MessageDoc;
}

/**
 * Build the exact DepositWarcards inbox item consumed by BOAFLMMKCGB in client 1.6.0.
 *
 * Unlike a normal text message, this notification contains a compact DatabasePlayer snapshot.
 * The recovered constructor reads PlayerName, Level, SquadId, SquadRank, and AdminPlayerId, while
 * HHFHFANGCEJ reads the common MessageId, PlayerId, and MessageType attributes. The squad member
 * rank is taken from the authoritative roster rather than the player's denormalized mirror.
 */
export function buildDepositWarcardsMessage(
  actor: PlayerDocument,
  targetPlayerId: string,
  squad: SquadDocument,
  createdAt: Date,
): MessageDoc {
  const actorMember = squad.members.find((member) => member.playerId === actor.id);
  if (!actorMember) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not a member of this squad.");
  }

  const unixTimestamp = Math.floor(createdAt.getTime() / 1_000);
  return {
    // The stock local constructor uses DepositWarcards-{player name}-{timestamp}. Retaining the
    // same prefix makes diagnostics familiar, and the numeric suffix is required by the base
    // message parser for chronological presentation.
    messageId: `DepositWarcards-${actor.player.accountName}-${unixTimestamp}`,
    toPlayerId: targetPlayerId,
    fromPlayerId: actor.id,
    fromName: actor.player.accountName,
    body: "Please deposit War Cards into the squad card pool.",
    messageType: DEPOSIT_WARCARDS_MESSAGE_TYPE,
    payload: {
      PlayerName: actor.player.accountName,
      Level: actor.player.level,
      SquadId: squad.name,
      SquadRank: actorMember.rank,
      AdminPlayerId: actor.id,
    },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt,
  };
}

/**
 * Ask one current squad member to contribute War Cards to the shared pool.
 *
 * Action 178 contains only SquadMemberId, so all authority is reconstructed from server state:
 * the authenticated actor selects their current squad, both players must exist in that squad's
 * roster, and self-notification is rejected. The target never comes from a client-supplied squad
 * name. Since the old protocol has no operation ID, a deterministic actor/target/day key turns
 * retries into the original success and also prevents reminder spam from repeated or modified
 * client requests. A unique sparse MongoDB index makes this rule safe across server processes.
 */
export async function notifySquadMemberToDeposit(
  actorId: string,
  requestedTargetId: string,
): Promise<MessageDoc> {
  const targetId = requestedTargetId.trim();
  if (!targetId) throw new ApiError(ApiErrorCode.PlayerNotFound, "Squad member not found.");
  if (targetId === actorId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "A player cannot notify themselves.");
  }

  const actor = await findById(actorId);
  if (!actor) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  if (!actor.player.squadName) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not a member of a squad.");
  }

  const squad = await getByName(actor.player.squadName);
  if (!squad) throw new ApiError(ApiErrorCode.SquadNotFound, "Squad not found.");
  if (!squad.members.some((member) => member.playerId === actorId)) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not a member of this squad.");
  }
  if (!squad.members.some((member) => member.playerId === targetId)) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Target player is not a member of this squad.");
  }

  // Confirm that the roster entry still points to a real account. The squad roster remains the
  // membership source of truth, but persisting a message for a deleted account would create an
  // inbox row that can never be consumed.
  const target = await findById(targetId);
  if (!target) throw new ApiError(ApiErrorCode.PlayerNotFound, "Squad member not found.");

  const now = new Date();
  const dayKey = now.toISOString().slice(0, 10);
  const idempotencyKey = `deposit-warcards:${squad.name}:${actorId}:${targetId}:${dayKey}`;
  const message = buildDepositWarcardsMessage(actor, targetId, squad, now);
  try {
    const result = await messages().findOneAndUpdate(
      { idempotencyKey },
      { $setOnInsert: { ...message, idempotencyKey } },
      { upsert: true, returnDocument: "after" },
    );
    if (result) return result as unknown as MessageDoc;
  } catch (error) {
    // A concurrent first request can lose the unique-index race. Treat that duplicate-key as a
    // successful retry and return the winner, while preserving every unrelated database error.
    if ((error as { code?: number }).code !== 11000) throw error;
  }

  const existing = await messages().findOne({ idempotencyKey });
  if (!existing) {
    throw new ApiError(ApiErrorCode.InternalServerError, "War Card reminder was not persisted.");
  }
  return existing as unknown as MessageDoc;
}
