import { randomUUID } from "crypto";
import type { Filter } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import {
  players,
  squadChatMessages,
  squads,
  type PlayerDocument,
  type SquadChatMessageDocument,
  type SquadDocument,
} from "../db";
import { requireModeratedText } from "./textModerationService";

export interface SquadChatSendInput {
  clientMessageId: string;
  text: string;
}

export interface SquadChatWireMessage {
  MessageId: string;
  SquadId: string;
  SenderId: string;
  SenderName: string;
  SenderLevel: number;
  SenderLeague: number;
  SenderSquadRank: number;
  Text: string;
  Timestamp: number;
}

export interface SquadChatMembership {
  squad: SquadDocument;
  player: PlayerDocument;
  rank: number;
}

export const SQUAD_CHAT_REDIS_CHANNEL = "warfriends:squad-chat:v1";

export interface SquadChatFanoutNotice {
  originId: string;
  messageId: string;
}

interface SquadChatHistoryCursor {
  v: 1;
  /** Exact server millisecond, not the legacy display timestamp rounded to seconds. */
  t: number;
  /** Stable tie-breaker for messages persisted within the same millisecond. */
  id: string;
}

const UUID_PATTERN = /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;

function positiveInteger(value: number, fallback: number): number {
  return Number.isSafeInteger(value) && value > 0 ? value : fallback;
}

/**
 * Validate the only two client-owned chat fields.
 *
 * The old Photon payload also contained name, level, league, rank, and timestamp. Those fields
 * are intentionally absent here: the replacement backend derives every display/authority field
 * from authenticated database state, so a patched client cannot impersonate another member.
 */
export function normalizeSquadChatSend(
  value: SquadChatSendInput,
  maximumLength = positiveInteger(config.squadChatMaxLength, 256),
): SquadChatSendInput {
  const clientMessageId = typeof value?.clientMessageId === "string" ? value.clientMessageId.trim() : "";
  if (!/^[A-Za-z0-9][A-Za-z0-9._:-]{0,63}$/.test(clientMessageId)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat ClientMessageId is invalid.");
  }

  const text = typeof value?.text === "string" ? value.text.trim() : "";
  if (!text || text.length > maximumLength) {
    throw new ApiError(ApiErrorCode.UnknownAction, `Squad chat text must be between 1 and ${maximumLength} characters.`);
  }
  // The recovered Photon representation used tabs as field delimiters and the chat box was a
  // single-line control. Reject all transport/control characters instead of silently rewriting
  // the user's text into a different message that would make idempotent retries ambiguous.
  if (/\p{Cc}/u.test(text)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat text contains unsupported control characters.");
  }
  requireModeratedText(text, "Squad chat message");
  return { clientMessageId, text };
}

/**
 * Resolve membership only when both denormalized player mirrors and the authoritative roster
 * agree. A stale player mirror must not expose another squad's history, while a stale roster
 * must not let a removed member keep a previously subscribed channel alive.
 */
export function resolveSquadChatMembership(
  player: PlayerDocument | null,
  squad: SquadDocument | null,
): SquadChatMembership {
  if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  const topLevelSquad = player.squadName?.trim() ?? "";
  const snapshotSquad = player.player.squadName?.trim() ?? "";
  if (!topLevelSquad || topLevelSquad !== snapshotSquad || !squad || squad.name !== topLevelSquad) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player does not have a consistent squad membership.");
  }
  const member = squad.members.find((candidate) => candidate.playerId === player.id);
  if (!member || member.rank !== player.player.squadRank) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not present in the authoritative squad roster.");
  }
  return { player, squad, rank: member.rank };
}

async function currentMembership(playerId: string): Promise<SquadChatMembership> {
  const player = await players().findOne({ id: playerId });
  const mirroredSquad = player && player.squadName === player.player.squadName ? player.squadName : "";
  const squad = mirroredSquad ? await squads().findOne({ name: mirroredSquad }) : null;
  return resolveSquadChatMembership(player, squad);
}

/** Convert storage fields to the stable PascalCase WebSocket contract used by the hub. */
export function toSquadChatWireMessage(message: SquadChatMessageDocument): SquadChatWireMessage {
  return {
    MessageId: message.messageId,
    SquadId: message.squadId,
    SenderId: message.senderId,
    SenderName: message.senderName,
    SenderLevel: message.senderLevel,
    SenderLeague: message.senderLeague,
    SenderSquadRank: message.senderSquadRank,
    Text: message.text,
    Timestamp: Math.floor(message.createdAt.getTime() / 1_000),
  };
}

/** Serialize only durable identity across Redis; MongoDB remains the authority for the content. */
export function buildSquadChatFanoutNotice(originId: string, messageId: string): string {
  if (!UUID_PATTERN.test(originId) || !UUID_PATTERN.test(messageId)) {
    throw new Error("Squad Chat fan-out notice requires UUID identities.");
  }
  return JSON.stringify({ originId, messageId } satisfies SquadChatFanoutNotice);
}

/** Reject malformed or unversioned pub/sub input before it can trigger a database lookup. */
export function parseSquadChatFanoutNotice(raw: string): SquadChatFanoutNotice | null {
  try {
    const value = JSON.parse(raw) as Partial<SquadChatFanoutNotice> | null;
    if (!value || typeof value !== "object"
      || typeof value.originId !== "string" || !UUID_PATTERN.test(value.originId)
      || typeof value.messageId !== "string" || !UUID_PATTERN.test(value.messageId)) return null;
    return { originId: value.originId, messageId: value.messageId };
  } catch {
    return null;
  }
}

/** Create an opaque URL-safe cursor from the oldest row in a descending database page. */
export function createSquadChatHistoryCursor(
  message: Pick<SquadChatMessageDocument, "createdAt" | "messageId">,
): string {
  if (!UUID_PATTERN.test(message.messageId) || !Number.isSafeInteger(message.createdAt.getTime())) {
    throw new Error("Squad Chat history cursor requires a valid persisted message.");
  }
  const value: SquadChatHistoryCursor = { v: 1, t: message.createdAt.getTime(), id: message.messageId };
  return Buffer.from(JSON.stringify(value), "utf8").toString("base64url");
}

/** Decode a bounded cursor without trusting it for squad identity or page size. */
export function parseSquadChatHistoryCursor(raw: string): SquadChatHistoryCursor | null {
  if (!raw || raw.length > 256 || !/^[A-Za-z0-9_-]+$/.test(raw)) return null;
  try {
    const value = JSON.parse(Buffer.from(raw, "base64url").toString("utf8")) as Partial<SquadChatHistoryCursor> | null;
    if (!value || value.v !== 1 || !Number.isSafeInteger(value.t) || (value.t ?? -1) < 0
      || typeof value.id !== "string" || !UUID_PATTERN.test(value.id)) return null;
    return { v: 1, t: value.t as number, id: value.id };
  } catch {
    return null;
  }
}

function recoveredLeagueValue(player: PlayerDocument): number {
  // CreateChatMessage encoded beginner stages as negative values and ordinary League enum values
  // as positive integers. The backend has both dimensions and reproduces that display contract.
  return player.player.beginnersLeague > 0
    ? -Math.abs(player.player.beginnersLeague)
    : player.player.leagueTier;
}

function retentionMilliseconds(): number {
  return positiveInteger(config.squadChatRetentionDays, 30) * 86_400_000;
}

async function enforceRateLimit(senderId: string, now: Date): Promise<void> {
  const limit = positiveInteger(config.squadChatMessagesPerMinute, 10);
  const count = await squadChatMessages().countDocuments({
    senderId,
    createdAt: { $gte: new Date(now.getTime() - 60_000) },
  });
  if (count >= limit) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat rate limit reached. Try again later.");
  }
}

/** Return the recovered last-N channel history, oldest first for direct UI append order. */
export async function getSquadChatHistory(playerId: string, beforeCursor?: string): Promise<{
  squadId: string;
  messages: SquadChatWireMessage[];
  nextBeforeCursor: string | null;
}> {
  const membership = await currentMembership(playerId);
  const limit = positiveInteger(config.squadChatHistoryLimit, 3);
  const now = new Date();
  const cursor = beforeCursor ? parseSquadChatHistoryCursor(beforeCursor) : null;
  if (beforeCursor && !cursor) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Squad Chat history cursor is invalid.");
  }
  // Squad identity is always taken from authenticated membership. The cursor contributes only
  // an older-than boundary, so modifying it can neither cross channels nor increase page size.
  const filter: Filter<SquadChatMessageDocument> = {
    squadId: membership.squad.name,
    expiresAt: { $gt: now },
    ...(cursor ? {
      $or: [
        { createdAt: { $lt: new Date(cursor.t) } },
        { createdAt: new Date(cursor.t), messageId: { $lt: cursor.id } },
      ],
    } : {}),
  };
  const rows = await squadChatMessages()
    .find(filter)
    .sort({ createdAt: -1, messageId: -1 })
    .limit(limit + 1)
    .toArray();
  const hasMore = rows.length > limit;
  const page = rows.slice(0, limit);
  const nextBeforeCursor = hasMore && page.length > 0
    ? createSquadChatHistoryCursor(page[page.length - 1])
    : null;
  page.reverse();
  return {
    squadId: membership.squad.name,
    messages: page.map(toSquadChatWireMessage),
    nextBeforeCursor,
  };
}

/**
 * Resolve a cross-node notice through durable storage and the current squad roster.
 *
 * Redis carries only a message UUID, never trusted display text or recipient IDs. This lookup
 * both rejects forged/stale notices and ensures a member kicked after the originating node's
 * insert cannot receive the message from a slower remote node.
 */
export async function getSquadChatFanout(messageId: string): Promise<{
  message: SquadChatWireMessage;
  memberPlayerIds: string[];
} | null> {
  if (!UUID_PATTERN.test(messageId)) return null;
  const document = await squadChatMessages().findOne({ messageId, expiresAt: { $gt: new Date() } });
  if (!document) return null;
  const squad = await squads().findOne({ name: document.squadId });
  if (!squad) return null;
  return {
    message: toSquadChatWireMessage(document),
    memberPlayerIds: squad.members.map((member) => member.playerId),
  };
}

/**
 * Persist one authenticated message before it is fanned out by the process-local hub.
 *
 * The unique sender/nonce key survives reconnects, process restarts, and multi-node retries.
 * Reusing a nonce with different text is rejected rather than returning a misleading success.
 */
export async function sendSquadChatMessage(playerId: string, input: SquadChatSendInput): Promise<{
  message: SquadChatWireMessage;
  memberPlayerIds: string[];
  replayed: boolean;
}> {
  const normalized = normalizeSquadChatSend(input);
  const membership = await currentMembership(playerId);
  const idempotencyKey = `${playerId}:${normalized.clientMessageId}`;
  const existing = await squadChatMessages().findOne({ idempotencyKey });
  if (existing) {
    if (existing.squadId !== membership.squad.name || existing.text !== normalized.text) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat ClientMessageId was already used for different content.");
    }
    return {
      message: toSquadChatWireMessage(existing),
      memberPlayerIds: membership.squad.members.map((member) => member.playerId),
      replayed: true,
    };
  }

  const now = new Date();
  await enforceRateLimit(playerId, now);
  const document: SquadChatMessageDocument = {
    messageId: randomUUID(),
    idempotencyKey,
    clientMessageId: normalized.clientMessageId,
    squadId: membership.squad.name,
    senderId: playerId,
    senderName: membership.player.player.accountName,
    senderLevel: membership.player.player.level,
    senderLeague: recoveredLeagueValue(membership.player),
    senderSquadRank: membership.rank,
    text: normalized.text,
    createdAt: now,
    expiresAt: new Date(now.getTime() + retentionMilliseconds()),
  };

  try {
    await squadChatMessages().insertOne(document);
  } catch (error: unknown) {
    if ((error as { code?: number }).code !== 11000) throw error;
    // A second process won the same nonce race. Read the committed row and apply the same
    // content check as the ordinary retry path rather than broadcasting our uncommitted UUID.
    const winner = await squadChatMessages().findOne({ idempotencyKey });
    if (!winner || winner.squadId !== membership.squad.name || winner.text !== normalized.text) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Squad chat ClientMessageId conflicted with another message.");
    }
    return {
      message: toSquadChatWireMessage(winner),
      memberPlayerIds: membership.squad.members.map((member) => member.playerId),
      replayed: true,
    };
  }

  return {
    message: toSquadChatWireMessage(document),
    memberPlayerIds: membership.squad.members.map((member) => member.playerId),
    replayed: false,
  };
}
