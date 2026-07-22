import { randomUUID } from "crypto";
import { messages } from "../db";
import { redisPublish } from "../redis";
import {
  challengeIsExpired,
  toClientMessage,
  type MessageDoc,
} from "./socialService";
import { validatedInboxMessageDocument } from "./inboxMessageAuthorityService";
import {
  enqueueFirebaseInboxPush,
  runFirebasePushDeliverySweep,
} from "./firebasePushDeliveryService";

/** Transient wake-up channel; MongoDB remains the complete inbox authority. */
export const INBOX_FANOUT_REDIS_CHANNEL = "warfriends:inbox:fanout:v1";

/** Distinguishes this process's Redis echo from a notice published by another hub node. */
export const inboxFanoutOriginId = randomUUID();

export interface InboxFanoutNotice {
  originId: string;
  recipientPlayerId: string;
  messageId: string;
}

export interface InboxFanoutMessage {
  recipientPlayerId: string;
  messageId: string;
  message: ReturnType<typeof toClientMessage>;
}

export interface InboxFanoutReference {
  recipientPlayerId: string;
  messageId: string;
}

type LocalDelivery = (recipientPlayerId: string, messageId: string) => void | Promise<void>;
let localDelivery: LocalDelivery | null = null;

/** Every inbox family for which `toClientMessage` has a recovered, validated wire projection. */
const LIVE_INBOX_MESSAGE_TYPES: readonly MessageDoc["messageType"][] = [0, 1, 3, 9, 10, 11, 21, 23, 27, 28];

function boundedIdentity(value: unknown, maximumLength: number): value is string {
  return typeof value === "string"
    && value.length > 0
    && value.length <= maximumLength
    && value.trim() === value
    && !/\p{Cc}/u.test(value);
}

/**
 * Register the one process-local WebSocket handoff owned by `gameHub`.
 *
 * HTTP handlers can persist inbox messages before or after the hub starts in tests. Keeping the
 * callback optional means persistence never depends on a live socket coordinator; an offline
 * client still retrieves the same row through `GetAllMessages`.
 */
export function registerLocalInboxDelivery(delivery: LocalDelivery): void {
  localDelivery = delivery;
}

/** Build a bounded, versioned-by-channel Redis hint containing no message content. */
export function buildInboxFanoutNotice(
  originId: string,
  recipientPlayerId: string,
  messageId: string,
): string {
  if (!/^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu.test(originId)
    || !boundedIdentity(recipientPlayerId, 256)
    || !boundedIdentity(messageId, 256)) {
    throw new Error("Inbox fan-out notice is invalid.");
  }
  return JSON.stringify({ originId, recipientPlayerId, messageId });
}

/** Reject extra fields and malformed identities before a Redis hint can trigger a database read. */
export function parseInboxFanoutNotice(raw: string): InboxFanoutNotice | null {
  if (typeof raw !== "string" || raw.length < 1 || raw.length > 1_024) return null;
  try {
    const value = JSON.parse(raw) as Record<string, unknown> | null;
    if (!value || Array.isArray(value)
      || Object.keys(value).sort().join(",") !== "messageId,originId,recipientPlayerId"
      || typeof value.originId !== "string"
      || !/^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/iu.test(value.originId)
      || !boundedIdentity(value.recipientPlayerId, 256)
      || !boundedIdentity(value.messageId, 256)) return null;
    return {
      originId: value.originId,
      recipientPlayerId: value.recipientPlayerId,
      messageId: value.messageId,
    };
  } catch {
    return null;
  }
}

/**
 * Re-bind one transient hint to a complete durable inbox message.
 *
 * Live delivery changes presentation latency only. Reward messages remain unclaimed and retain
 * their normal recipient-owned action-91 lifecycle; `GetAllMessages` remains the ordered recovery
 * path for every family. Validation runs before read/ignored/expiry filtering so a malformed
 * MongoDB row cannot become harmless-looking absence merely because Redis named it.
 */
export function liveInboxMessageFor(
  raw: MessageDoc,
  recipientPlayerId: string,
  now = new Date(),
): InboxFanoutMessage | null {
  // Challenge expiry is an expected delivery race, not durable corruption. Validate its complete
  // stored shape without application time, then apply the future/expiry checks explicitly. Other
  // message families retain their normal time-aware validator.
  const message = raw.messageType === 0
    ? validatedInboxMessageDocument(raw)
    : validatedInboxMessageDocument(raw, now);
  if (!(now instanceof Date) || !Number.isSafeInteger(now.getTime()) || now.getTime() <= 0) {
    throw new Error("Inbox fan-out time is invalid.");
  }
  if (message.createdAt.getTime() > now.getTime()) {
    throw new Error("Stored inbox message is from the future.");
  }
  if (message.toPlayerId !== recipientPlayerId
    || !LIVE_INBOX_MESSAGE_TYPES.includes(message.messageType)
    || message.read
    || message.ignored
    || message.accepted
    || challengeIsExpired(message, now)) return null;
  return {
    recipientPlayerId,
    messageId: message.messageId,
    message: toClientMessage(message),
  };
}

/** Reload a Redis/local hint through recipient ownership and complete message authority. */
export async function getLiveInboxFanout(
  recipientPlayerId: string,
  messageId: string,
  now = new Date(),
): Promise<InboxFanoutMessage | null> {
  if (!boundedIdentity(recipientPlayerId, 256) || !boundedIdentity(messageId, 256)) return null;
  const message = await messages().findOne({
    toPlayerId: recipientPlayerId,
    messageId,
    messageType: { $in: LIVE_INBOX_MESSAGE_TYPES },
  }) as unknown as MessageDoc | null;
  return message ? liveInboxMessageFor(message, recipientPlayerId, now) : null;
}

/**
 * Notify local sockets, then publish only a wake-up hint for other nodes.
 *
 * Both paths are best-effort after the MongoDB insert. A socket or Redis outage must never roll
 * back, duplicate, or falsely acknowledge the durable message; `GetAllMessages` remains the
 * recovery path and the receiving node reloads the row instead of trusting notice content.
 */
export async function publishInboxFanout(recipientPlayerId: string, messageId: string): Promise<void> {
  try {
    await localDelivery?.(recipientPlayerId, messageId);
  } catch {
    // Delivery failure cannot invalidate the already committed inbox row.
  }
  const notice = buildInboxFanoutNotice(inboxFanoutOriginId, recipientPlayerId, messageId);
  await redisPublish(INBOX_FANOUT_REDIS_CHANNEL, notice);
  // Firebase is another post-commit presentation path. Its token-free delivery ledger survives
  // provider/process outages and deduplicates this same fan-out replay across backend nodes. The
  // leased immediate sweep keeps challenge latency low; contention simply leaves the row for the
  // periodic worker and never changes the durable inbox or socket/Redis recovery contract.
  try {
    if (await enqueueFirebaseInboxPush(recipientPlayerId, messageId)) {
      await runFirebasePushDeliverySweep();
    }
  } catch {
    // A later reconciliation sweep discovers the committed inbox row if even ledger insertion
    // failed. Presentation infrastructure must never turn a successful gameplay mutation into an
    // HTTP error that encourages the stock client to repeat the authoritative action.
  }
}

/**
 * Publish a committed batch without making transient delivery part of its durable transaction.
 *
 * The loop is intentionally sequential. League and Squad settlements can create many recipient
 * rows at once; an unbounded Promise.all would turn one normal division close into a Redis/socket
 * burst. Each reference still follows the same best-effort local-then-Redis recovery contract.
 */
export async function publishInboxFanouts(references: readonly InboxFanoutReference[]): Promise<void> {
  for (const reference of references) {
    await publishInboxFanout(reference.recipientPlayerId, reference.messageId);
  }
}
