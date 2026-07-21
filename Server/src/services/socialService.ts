import { randomUUID } from "crypto";
import type { Document, Filter } from "mongodb";
import {
  messages,
  players,
  withMongoTransaction,
  type PlayerDocument,
  type PlayerProgressionState,
} from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { buildDatabasePlayer, progressionForPlayer } from "./playerStateService";
import { config } from "../config";
import { requireModeratedText } from "./textModerationService";
import { checkedRewardBalance } from "./rewardMathService";
import { validatedCoreProgressionBalances } from "./coreProgressionAuthorityService";
import {
  progressionRevisionForRead,
  validateProgressionRevisionAdvance,
} from "./progressionRevisionAuthorityService";

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
  /**
   * Recovered inbox enum values currently emitted by this backend:
   * Challenge(0), SquadDemotion/kick(3), SquadWarEnd(9), SquadEventTierReward(11), InformSquadLeaderAboutEvent(21),
   * PlayerLeagueFinished(23), InGameMessage(27), and DepositWarcards(28).
   */
  messageType: 0 | 3 | 9 | 11 | 21 | 23 | 27 | 28;
  payload: Record<string, string | number>;
  otherPlayerJson: string;
  read: boolean;
  ignored: boolean;
  accepted: boolean;
  /** Durable first-acceptance time; absent on rows created by older server builds. */
  acceptedAt?: Date;
  createdAt: Date;
  /** Deterministic key for server-generated events which must survive request retries once. */
  idempotencyKey?: string;
  /** Server-owned terminal marker for action 91; never inferred from the client's UI state. */
  rewardClaimed?: boolean;
  /** Stored response lets a lost HTTP response replay without crediting currency twice. */
  claimResponse?: { Gold: number; Warbucks: number };
  /** Present only for ephemeral inbox types such as PvP challenges. */
  expiresAt?: Date;
}

interface InboxCursor {
  v: 1;
  t: number;
  id: string;
}

const CHALLENGE_RETRY_WINDOW_MS = 10_000;

/**
 * Build the exact persisted message consumed by MBACFNICJPL after a squad kick.
 *
 * The absence of SquadRank is intentional: the recovered constructor converts that absence
 * to rank -1, which is how it distinguishes a kick from an ordinary demotion. A connected
 * client uses KickedPlayerDepositedCards to update its already-loaded inventory immediately;
 * a client that logs in later has already loaded the same authoritative inventory revision
 * and suppresses that replay by comparing the message and player-data timestamps.
 */
export function buildSquadKickMessage(
  actor: PlayerDocument,
  target: PlayerDocument,
  squadName: string,
  returnedCardIds: string[],
  createdAt: Date,
): MessageDoc {
  const unixTimestamp = Math.floor(createdAt.getTime() / 1_000);
  return {
    messageId: `SquadDemotion-${target.id}-${unixTimestamp}`,
    toPlayerId: target.id,
    fromPlayerId: actor.id,
    fromName: actor.player.accountName,
    body: "You were removed from your squad.",
    messageType: 3,
    payload: {
      PlayerName: target.player.accountName,
      Level: target.player.level,
      SquadId: squadName,
      KickedPlayerId: target.id,
      SquadKickedFrom: squadName,
      AdminName: actor.player.accountName,
      AdminId: actor.id,
      AdminLevel: actor.player.level,
      KickedPlayerDepositedCards: JSON.stringify(returnedCardIds),
    },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt,
  };
}

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
  const normalizedBody = body.trim().slice(0, 500);
  requireModeratedText(normalizedBody, "Message");
  const doc: MessageDoc = {
    messageId: randomUUID(),
    toPlayerId,
    fromPlayerId,
    fromName,
    body: normalizedBody,
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

/** Encode a stable older-than boundary; recipient identity is deliberately not client-owned. */
export function createInboxCursor(message: Pick<MessageDoc, "createdAt" | "messageId">): string {
  const timestamp = message.createdAt.getTime();
  if (!Number.isSafeInteger(timestamp) || timestamp < 0
    || !message.messageId || message.messageId.length > 256 || /\p{Cc}/u.test(message.messageId)) {
    throw new Error("Inbox cursor requires a valid persisted message.");
  }
  const cursor: InboxCursor = { v: 1, t: timestamp, id: message.messageId };
  return Buffer.from(JSON.stringify(cursor), "utf8").toString("base64url");
}

/** Decode only position. The authenticated player and bounded page size remain server-owned. */
export function parseInboxCursor(raw: string): InboxCursor | null {
  if (!raw || raw.length > 512 || !/^[A-Za-z0-9_-]+$/.test(raw)) return null;
  try {
    const value = JSON.parse(Buffer.from(raw, "base64url").toString("utf8")) as Partial<InboxCursor> | null;
    if (!value || value.v !== 1 || !Number.isSafeInteger(value.t) || (value.t ?? -1) < 0
      || typeof value.id !== "string" || !value.id || value.id.length > 256 || /\p{Cc}/u.test(value.id)) return null;
    return { v: 1, t: value.t as number, id: value.id };
  } catch {
    return null;
  }
}

export interface InboxPage {
  messages: MessageDoc[];
  nextCursor: string | null;
}

/**
 * Return one stable newest-first inbox page for the authenticated recipient.
 *
 * The query fetches one extra row only to decide whether another page exists. `messageId` is the
 * tie-breaker for server notifications created in the same millisecond; without it, an older-than
 * timestamp cursor could permanently skip rows. Expired challenges remain hidden immediately even
 * when MongoDB's asynchronous TTL monitor has not deleted them yet.
 */
export async function inboxPage(
  playerId: string,
  limit = 50,
  beforeCursor?: string,
): Promise<InboxPage> {
  const safeLimit = Math.min(100, Math.max(1, Math.floor(limit)));
  const cursor = beforeCursor ? parseInboxCursor(beforeCursor) : null;
  if (beforeCursor && !cursor) throw new ApiError(ApiErrorCode.UnknownAction, "Inbox cursor is invalid.");
  const conditions: Filter<Document>[] = [
    { $or: [{ expiresAt: { $exists: false } }, { expiresAt: { $gt: new Date() } }] },
  ];
  if (cursor) {
    conditions.push({
      $or: [
        { createdAt: { $lt: new Date(cursor.t) } },
        { createdAt: new Date(cursor.t), messageId: { $lt: cursor.id } },
      ],
    });
  }
  const docs = await messages()
    .find({
      toPlayerId: playerId,
      ignored: { $ne: true },
      $and: conditions,
    })
    .sort({ createdAt: -1, messageId: -1 })
    .limit(safeLimit + 1)
    .toArray();
  const typed = docs as unknown as MessageDoc[];
  const hasMore = typed.length > safeLimit;
  const page = typed.slice(0, safeLimit);
  return {
    messages: page,
    nextCursor: hasMore && page.length > 0 ? createInboxCursor(page[page.length - 1]) : null,
  };
}

/** Backward-compatible service helper for callers that need only the first page. */
export async function inbox(playerId: string, limit = 50): Promise<MessageDoc[]> {
  return (await inboxPage(playerId, limit)).messages;
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

function canonicalProgression(state: PlayerProgressionState): PlayerProgressionState {
  const { dogTags: _legacyDogTags, ...canonical } = state;
  return canonical;
}

function progressionRevisionFilter(player: PlayerDocument): Filter<PlayerDocument> {
  const rawRevision = player.progression?.revision;
  if (!player.progression) return { id: player.id, progression: { $exists: false } };
  return rawRevision === undefined
    ? { id: player.id, "progression.revision": { $exists: false } }
    : { id: player.id, "progression.revision": rawRevision };
}

export interface ClaimedMessageReward {
  Gold: number;
  Warbucks: number;
  replayed: boolean;
}

/** Pure allowlist used by action 91 before it touches player currency. */
export function claimableMessageReward(
  message: Pick<MessageDoc, "messageType" | "payload">,
): { Gold: number; Warbucks: number } | null {
  const rewardGold = message.messageType === 23 || message.messageType === 9
    ? Number(message.payload.RewardGold ?? 0)
    : message.messageType === 11
      ? Number(message.payload.Reward ?? 0)
      : 0;
  if (!Number.isSafeInteger(rewardGold) || rewardGold <= 0) return null;
  return { Gold: rewardGold, Warbucks: 0 };
}

/**
 * Apply one server-authored inbox Gold reward without publishing its message receipt yet.
 *
 * Keeping this transition pure makes the two authorities independently testable: the caller owns
 * the MongoDB transaction that marks the message terminal, while this function proves the wallet
 * and optimistic revision successor. The transaction retries the complete read/transition/write
 * callback after a write conflict, and its revision filter prevents a stale snapshot from being
 * accepted as an ordinary successful update.
 */
export function applyInboxGoldRewardState(
  state: PlayerProgressionState,
  rewardGold: number,
): PlayerProgressionState {
  validatedCoreProgressionBalances(state);
  const revision = progressionRevisionForRead(state.revision);
  if (!Number.isSafeInteger(rewardGold) || rewardGold <= 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored inbox Gold reward is invalid.");
  }
  const next: PlayerProgressionState = {
    ...state,
    revision: revision + 1,
    gold: checkedRewardBalance(state.gold, rewardGold, "Inbox Gold"),
  };
  validateProgressionRevisionAdvance(revision, next.revision);
  validatedCoreProgressionBalances(next);
  return next;
}

/**
 * Claim one server-generated inbox reward with exactly-once authoritative delivery.
 *
 * BeanstalkServerManager sends only MessageId for action 91. Currency amounts therefore come
 * exclusively from the stored message payload, never from the request. The player balance and
 * terminal message state commit in one MongoDB transaction so a crash cannot delete an unpaid
 * reward or pay one while leaving it claimable. A transport retry receives the original delta,
 * which the stock FABILEDDNIM parser requires to update its local Wallet after a lost response.
 */
export async function claimMessageReward(playerId: string, messageId: string): Promise<ClaimedMessageReward> {
  if (!messageId) throw new ApiError(ApiErrorCode.UnknownAction, "MessageId is required.");

  return withMongoTransaction(async (session) => {
    const message = await messages().findOne({ messageId, toPlayerId: playerId }, { session }) as unknown as MessageDoc | null;
    if (!message) throw new ApiError(ApiErrorCode.UnknownAction, "Reward message was not found.");
    if (message.rewardClaimed && message.claimResponse) {
      return { ...message.claimResponse, replayed: true };
    }

    // Only recovered message types with an explicit server-authored reward are claimable.
    // Supporting arbitrary Title/Text messages here would turn the generic inbox into an
    // economy endpoint. SquadWarEnd, PlayerLeagueFinished, and SquadEventTierReward carry Gold only.
    const reward = claimableMessageReward(message);
    if (!reward) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Message has no claimable reward.");
    }

    const player = await players().findOne({ id: playerId }, { session });
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    const progression = progressionForPlayer(player);
    const nextProgression = canonicalProgression(applyInboxGoldRewardState(progression, reward.Gold));
    const response = reward;

    const playerUpdate = await players().updateOne(
      progressionRevisionFilter(player),
      { $set: { progression: nextProgression, updatedAt: new Date() } },
      { session },
    );
    if (playerUpdate.modifiedCount !== 1) throw new Error(`Could not credit inbox reward for ${playerId}.`);

    const messageUpdate = await messages().updateOne(
      { messageId, toPlayerId: playerId, rewardClaimed: { $ne: true } },
      { $set: { rewardClaimed: true, claimResponse: response, read: true, ignored: true } },
      { session },
    );
    if (messageUpdate.modifiedCount !== 1) throw new Error(`Concurrent reward claim rejected for ${messageId}.`);
    return { ...response, replayed: false };
  });
}

export type ChallengeAcceptanceDecision = "accept" | "replay" | "invalid";

/** Pure ownership/lifecycle decision shared by the database path and contract tests. */
export function challengeAcceptanceDecision(
  message: Pick<MessageDoc, "toPlayerId" | "messageType" | "ignored" | "accepted" | "expiresAt"> | null,
  playerId: string,
  now: Date,
): ChallengeAcceptanceDecision {
  if (!message
    || message.toPlayerId !== playerId
    || message.messageType !== 0
    || message.ignored
    || !message.expiresAt
    || message.expiresAt.getTime() <= now.getTime()) return "invalid";
  return message.accepted ? "replay" : "accept";
}

export async function acceptChallenge(playerId: string, messageId: string): Promise<boolean> {
  const now = new Date();
  const message = await messages().findOne({ messageId, toPlayerId: playerId }) as unknown as MessageDoc | null;
  const decision = challengeAcceptanceDecision(message, playerId, now);
  if (decision === "invalid") return false;
  if (decision === "replay") return true;

  const result = await messages().updateOne(
    {
      messageId,
      toPlayerId: playerId,
      messageType: 0,
      ignored: { $ne: true },
      accepted: { $ne: true },
      expiresAt: { $gt: now },
    },
    { $set: { accepted: true, acceptedAt: now, read: true } },
  );
  if (result.modifiedCount === 1) return true;

  // A concurrent request may have committed between the read and compare-and-set update. Re-read
  // the terminal state so both callers receive Accepted=true; never convert expiry/ignore races
  // into a false replay success.
  const winner = await messages().findOne({ messageId, toPlayerId: playerId }) as unknown as MessageDoc | null;
  return challengeAcceptanceDecision(winner, playerId, new Date()) === "replay";
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
    // HHFHFANGCEJ's local-message constructor assigns currentPlayer.id here, proving that
    // PlayerId is the inbox owner/recipient. Sender identity has message-specific fields such as
    // OpponentId, AdminPlayerId, or OtherPlayer. Emitting fromPlayerId caused read/ignore requests
    // from an unmodified client to carry the wrong DynamoDB partition owner.
    PlayerId: { S: doc.toPlayerId },
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
  } else if (doc.messageType === 3) {
    // MBACFNICJPL treats a missing SquadRank as -1 (kick) and parses the returned-card list
    // from a JSON string. Numeric player levels remain DynamoDB N attributes.
    wire.PlayerName = { S: String(doc.payload.PlayerName ?? "") };
    wire.Level = { N: String(doc.payload.Level ?? 0) };
    wire.SquadId = { S: String(doc.payload.SquadId ?? "") };
    wire.KickedPlayerId = { S: String(doc.payload.KickedPlayerId ?? doc.toPlayerId) };
    wire.SquadKickedFrom = { S: String(doc.payload.SquadKickedFrom ?? "") };
    wire.AdminName = { S: String(doc.payload.AdminName ?? doc.fromName) };
    wire.AdminId = { S: String(doc.payload.AdminId ?? doc.fromPlayerId) };
    wire.AdminLevel = { N: String(doc.payload.AdminLevel ?? 0) };
    wire.KickedPlayerDepositedCards = {
      S: String(doc.payload.KickedPlayerDepositedCards ?? "[]"),
    };
  } else if (doc.messageType === 28) {
    // BOAFLMMKCGB does not parse the generic Title/Text fields. It constructs a lightweight
    // DatabasePlayer directly from these five DynamoDB attributes and uses that player in the
    // card-pool reminder row. Keep this adapter explicit so a harmless-looking refactor to the
    // generic message shape cannot silently produce an empty sender name or a broken profile.
    wire.PlayerName = { S: String(doc.payload.PlayerName ?? doc.fromName) };
    wire.Level = { N: String(doc.payload.Level ?? 0) };
    wire.SquadId = { S: String(doc.payload.SquadId ?? "") };
    wire.SquadRank = { N: String(doc.payload.SquadRank ?? 0) };
    wire.AdminPlayerId = { S: String(doc.payload.AdminPlayerId ?? doc.fromPlayerId) };
  } else if (doc.messageType === 9) {
    // LDDEMALIBBK requires these exact DynamoDB wrappers. SquadMembers is itself a JSON string
    // containing DatabasePlayer DynamoDB objects; keeping it as S matches its constructor's
    // JsonConvert.DeserializeObject<JArray> path. The claim request later sends only MessageId.
    wire.Position = { N: String(doc.payload.Position ?? 0) };
    wire.SquadId = { S: String(doc.payload.SquadId ?? "") };
    wire.SquadIcon = { S: String(doc.payload.SquadIcon ?? "") };
    wire.RewardGold = { N: String(doc.payload.RewardGold ?? 0) };
    wire.PrevLevelId = { N: String(doc.payload.PrevLevelId ?? 1) };
    wire.NewLevelId = { N: String(doc.payload.NewLevelId ?? 1) };
    wire.SquadMembers = { S: String(doc.payload.SquadMembers ?? "[]") };
  } else if (doc.messageType === 11) {
    // OKLNJJBHAIH requires these exact wrappers, then sends only MessageId to action 91. The
    // reward remains server-authored in this durable message and is never echoed by the claim.
    wire.Tier = { N: String(doc.payload.Tier ?? 0) };
    wire.SquadId = { S: String(doc.payload.SquadId ?? "") };
    wire.Reward = { N: String(doc.payload.Reward ?? 0) };
  } else if (doc.messageType === 23) {
    // MMKFEEGDFKN parses this type-23 document before it performs any UI work. LeagueId is
    // mandatory and numeric; the remaining values are optional DynamoDB attributes. The
    // stock client compares FormerFullLeagueId with its current ID before moving locally to
    // the new tier's placement division, which prevents a delayed old result from replacing
    // a newer season.
    wire.LeagueId = { N: String(doc.payload.LeagueId ?? 0) };
    if (doc.payload.BeforeLeagueId !== undefined) {
      wire.BeforeLeagueId = { N: String(doc.payload.BeforeLeagueId) };
    }
    if (doc.payload.Medals !== undefined) wire.Medals = { N: String(doc.payload.Medals) };
    if (doc.payload.FormerFullLeagueId !== undefined) {
      wire.FormerFullLeagueId = { S: String(doc.payload.FormerFullLeagueId) };
    }
    if (doc.payload.RewardGold !== undefined) wire.RewardGold = { N: String(doc.payload.RewardGold) };
    if (doc.payload.Position !== undefined) wire.Position = { N: String(doc.payload.Position) };
    // MMKFEEGDFKN only checks whether this attribute exists. BOOL expresses that semantic
    // directly and avoids suggesting that its numeric value is part of the reward formula.
    if (doc.payload.NotEnoughPlayers !== undefined) wire.NotEnoughPlayers = { BOOL: true };
  } else {
    wire.Title = { S: doc.fromName };
    wire.Text = { S: doc.body };
    wire.CreationTime = { N: String(Math.floor(doc.createdAt.getTime() / 1000)) };
  }
  return wire;
}
