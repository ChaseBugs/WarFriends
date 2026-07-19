import { ApiError, ApiErrorCode } from "../apiErrors";
import { messages, type PlayerDocument, type PlayerProgressionState, type SquadDocument } from "../db";
import { mutateProgression } from "./progressionMutationService";
import { findById } from "./playerService";
import { getByName } from "./squadService";
import type { MessageDoc } from "./socialService";

const SQUAD_EVENT_MESSAGE_TYPE = 21;
const MAX_CURSOR_CLOCK_SKEW_SECONDS = 300;

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
  if (!Number.isInteger(requestedTimestamp) || requestedTimestamp < 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat timestamp must be a non-negative integer.");
  }
  if (requestedTimestamp > Math.floor(now) + MAX_CURSOR_CLOCK_SKEW_SECONDS) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat timestamp is too far in the future.");
  }

  const timestamp = Math.max(state.lastSeenSquadChatTimestamp ?? 0, requestedTimestamp);
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
