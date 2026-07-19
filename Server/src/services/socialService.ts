import { randomUUID } from "crypto";
import { messages, players, type PlayerDocument } from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { buildDatabasePlayer } from "./playerStateService";
import { config } from "../config";

// Player discovery + messaging (BACKEND.md §2.3 "Social / messaging / hit list"). Search
// and directory reads project players to the client's summary shape; messages are stored
// per-recipient in the `messages` collection.

export async function searchPlayers(query: string, limit = 25): Promise<Record<string, unknown>[]> {
  const trimmed = query.trim();
  if (!trimmed) return [];
  // Anchored, case-insensitive prefix match on account name (escaped to a literal).
  const escaped = trimmed.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
  const docs = await players()
    .find({ accountName: { $regex: `^${escaped}`, $options: "i" } })
    .limit(limit)
    .toArray();
  // SearchPlayers passes every item to DatabasePlayer.CreateFromDatabase. Reuse the central
  // adapter so directory results cannot drift from login/profile response casing.
  return docs.map(buildDatabasePlayer);
}

export async function listPlayers(limit = 50): Promise<Record<string, unknown>[]> {
  const docs = await players().find().sort({ experience: -1 }).limit(limit).toArray();
  return docs.map(buildDatabasePlayer);
}

export interface MessageDoc {
  messageId: string;
  toPlayerId: string;
  fromPlayerId: string;
  fromName: string;
  body: string;
  /** Recovered inbox enum: Challenge(0), InformSquadLeaderAboutEvent(21), InGameMessage(27). */
  messageType: 0 | 21 | 27;
  payload: Record<string, string | number>;
  otherPlayerJson: string;
  read: boolean;
  ignored: boolean;
  accepted: boolean;
  createdAt: Date;
  /** Present only for ephemeral inbox types such as PvP challenges. */
  expiresAt?: Date;
}

const CHALLENGE_RETRY_WINDOW_MS = 10_000;

function challengeTtlMilliseconds(): number {
  return Math.max(60, Math.floor(config.challengeTtlSeconds)) * 1_000;
}

/** Pure expiry predicate shared by database paths and contract tests. */
export function challengeIsExpired(message: Pick<MessageDoc, "messageType" | "expiresAt">, now = new Date()): boolean {
  return message.messageType === 0 && (!message.expiresAt || message.expiresAt.getTime() <= now.getTime());
}

/**
 * Bound player-generated inbox traffic with a persistent rolling window.
 *
 * The limit is checked in MongoDB rather than process memory so a restart does not reset it.
 * The current count-then-insert sequence can exceed the cap by one under a multi-node race;
 * a production cluster should move this counter to an atomic Redis script. It still blocks
 * sustained abuse and never drops server-generated moderation or squad-system messages.
 */
async function enforceOutgoingMessageLimit(fromPlayerId: string, now: Date): Promise<void> {
  const maximum = Math.max(1, Math.floor(config.outgoingMessagesPerMinute));
  const since = new Date(now.getTime() - 60_000);
  const count = await messages().countDocuments({
    fromPlayerId,
    messageType: { $in: [0, 27] },
    createdAt: { $gte: since },
  });
  if (count >= maximum) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Message rate limit reached. Try again later.");
  }
}

export async function sendMessage(fromPlayerId: string, fromName: string, toPlayerId: string, body: string): Promise<MessageDoc> {
  const recipient = await players().findOne({ id: toPlayerId }, { projection: { id: 1 } });
  if (!recipient) throw new ApiError(ApiErrorCode.PlayerNotFound, "Recipient not found.");
  const createdAt = new Date();
  await enforceOutgoingMessageLimit(fromPlayerId, createdAt);
  const doc: MessageDoc = {
    messageId: randomUUID(),
    toPlayerId,
    fromPlayerId,
    fromName,
    body: body.trim().slice(0, 500),
    messageType: 27,
    payload: {},
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt,
  };
  await messages().insertOne(doc);
  return doc;
}

export interface ChallengeMessageInput {
  challengedPlayerId: string;
  mapName: string;
  gameType: number;
  region: number;
  roomName: string;
  clientVersion: string;
  missionType?: string;
  numberOfMission?: number;
  missionData?: string;
}

/**
 * Store the exact metadata consumed by ICFCHEHNHEN, the recovered challenge-message class.
 * A snapshot of the challenger is embedded because the client constructs its opponent card
 * directly from OtherPlayer rather than making a second profile request.
 */
export async function sendChallenge(from: PlayerDocument, input: ChallengeMessageInput): Promise<MessageDoc> {
  const recipient = await players().findOne({ id: input.challengedPlayerId }, { projection: { id: 1 } });
  if (!recipient) throw new ApiError(ApiErrorCode.PlayerNotFound, "Challenged player not found.");
  if (input.challengedPlayerId === from.id) throw new ApiError(ApiErrorCode.UnknownAction, "A player cannot challenge themselves.");

  const createdAt = new Date();
  // The old request has no operation UUID. Reuse an identical very recent room challenge so
  // an HTTP retry cannot create duplicate inbox cards or consume the sender's whole rate
  // allowance. A genuinely new roomName remains a distinct invitation.
  const duplicate = await messages().findOne({
    fromPlayerId: from.id,
    toPlayerId: input.challengedPlayerId,
    messageType: 0,
    "payload.roomName": input.roomName,
    createdAt: { $gte: new Date(createdAt.getTime() - CHALLENGE_RETRY_WINDOW_MS) },
    expiresAt: { $gt: createdAt },
  });
  if (duplicate) return duplicate as unknown as MessageDoc;
  await enforceOutgoingMessageLimit(from.id, createdAt);
  const doc: MessageDoc = {
    // The recovered client strips the trailing numeric segment to recover challenger ID.
    messageId: `${from.id}-${createdAt.getTime()}`,
    toPlayerId: input.challengedPlayerId,
    fromPlayerId: from.id,
    fromName: from.player.accountName,
    body: "",
    messageType: 0,
    payload: {
      MapName: input.mapName,
      GameType: input.gameType,
      Region: input.region,
      roomName: input.roomName,
      clientVersion: input.clientVersion,
      ...(input.missionType ? { MissionType: input.missionType } : {}),
      ...(input.numberOfMission !== undefined ? { NumberOfMission: input.numberOfMission } : {}),
      ...(input.missionData ? { MissionData: input.missionData } : {}),
    },
    // ICFCHEHNHEN deserializes this string and immediately calls
    // DatabasePlayer.CreateFromDatabase, so the embedded snapshot needs the same typed
    // attribute adapter as a login response. Serializing the internal DTO would create an
    // invitation whose opponent exists but has an empty name/id in the fight dialog.
    otherPlayerJson: JSON.stringify(buildDatabasePlayer(from)),
    read: false,
    ignored: false,
    accepted: false,
    createdAt,
    expiresAt: new Date(createdAt.getTime() + challengeTtlMilliseconds()),
  };
  await messages().insertOne(doc);
  return doc;
}

export async function inbox(playerId: string, limit = 50): Promise<MessageDoc[]> {
  const safeLimit = Math.min(100, Math.max(1, Math.floor(limit)));
  const docs = await messages()
    .find({
      toPlayerId: playerId,
      ignored: { $ne: true },
      // TTL deletion is deliberately asynchronous. This filter makes an expired challenge
      // disappear at its exact logical deadline even if MongoDB has not removed it yet.
      $or: [{ expiresAt: { $exists: false } }, { expiresAt: { $gt: new Date() } }],
    })
    .sort({ createdAt: -1 })
    .limit(safeLimit)
    .toArray();
  return docs as unknown as MessageDoc[];
}

export async function markRead(playerId: string, messageId: string): Promise<void> {
  await messages().updateOne({ messageId, toPlayerId: playerId }, { $set: { read: true } });
}

export async function ignoreMessage(playerId: string, messageId: string): Promise<boolean> {
  // Recipient ownership is part of the update filter; one player can never hide a message
  // from another player's inbox by guessing its identifier.
  const result = await messages().updateOne(
    { messageId, toPlayerId: playerId },
    { $set: { ignored: true, read: true } },
  );
  return result.matchedCount === 1;
}

export async function acceptChallenge(playerId: string, messageId: string): Promise<boolean> {
  const now = new Date();
  const result = await messages().updateOne(
    {
      messageId,
      toPlayerId: playerId,
      messageType: 0,
      ignored: { $ne: true },
      accepted: { $ne: true },
      expiresAt: { $gt: now },
    },
    { $set: { accepted: true, read: true } },
  );
  return result.matchedCount === 1;
}

type DynamoValue = { S: string } | { N: string } | { BOOL: boolean };

/**
 * Adapt an internal message document to the DynamoDB attribute shape parsed by the 1.6.0
 * Unity client. This boundary is intentionally explicit; leaking the Mongo document directly
 * produces syntactically valid JSON that the client cannot deserialize.
 */
export function toClientMessage(doc: MessageDoc): Record<string, DynamoValue> {
  const wire: Record<string, DynamoValue> = {
    MessageId: { S: doc.messageId },
    PlayerId: { S: doc.fromPlayerId },
    MessageType: { N: String(doc.messageType) },
  };
  if (doc.read) wire.WasShown = { BOOL: true };

  if (doc.messageType === 0) {
    wire.OpponentId = { S: doc.fromPlayerId };
    wire.OtherPlayer = { S: doc.otherPlayerJson };
    for (const [key, value] of Object.entries(doc.payload)) {
      // Challenge parser expects GameType/Region as N and optional NumberOfMission as S.
      wire[key] = key === "GameType" || key === "Region" ? { N: String(value) } : { S: String(value) };
    }
  } else {
    wire.Title = { S: doc.fromName };
    wire.Text = { S: doc.body };
    wire.CreationTime = { N: String(Math.floor(doc.createdAt.getTime() / 1000)) };
  }
  return wire;
}
