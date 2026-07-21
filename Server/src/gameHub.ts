import { randomUUID } from "crypto";
import type { Server as HttpServer } from "http";
import { WebSocket, WebSocketServer } from "ws";
import { authenticate } from "./services/authService";
import { findById } from "./services/playerService";
import {
  assertPlayerNotSanctioned,
  webSocketMessageRequiresSanctionCheck,
} from "./services/playerSanctionService";
import { enqueueForHub, removeForHub as leaveQueue, restoreWaitingForHub } from "./services/matchmakingService";
import {
  cancelMatch,
  clearMatchParticipantDisconnected,
  createMatch,
  findStartedMatchForPlayer,
  getMatch,
  joinActiveMatch,
  markRelayedCardDelivered,
  markMatchParticipantDisconnected,
  recordRelayedCardPlay,
  reportMatchResult,
  settleResult,
  type MatchPlayer,
  wasRelayedCardDelivered,
} from "./services/matchService";
import { parsePvpUsedCards } from "./services/cardInventoryService";
import { resolveMatchReportStatus, roomManager } from "./gameRooms/roomManager";
import type {
  ClientEnvelope,
  CardPlayedEventData,
  IdentifyPayload,
  JoinMatchPayload,
  MatchEventPayload,
  MatchResultPayload,
  SendSquadChatPayload,
  SquadChatHistoryPayload,
} from "./gameRooms/types";
import logger from "./utils/logger";
import { PlayerStatus } from "./constants";
import { config } from "./config";
import { ApiError, ApiErrorCode } from "./apiErrors";
import {
  buildSquadChatFanoutNotice,
  getSquadChatFanout,
  getSquadChatHistory,
  parseSquadChatFanoutNotice,
  sendSquadChatMessage,
  SQUAD_CHAT_REDIS_CHANNEL,
  type SquadChatWireMessage,
} from "./services/squadChatService";
import { isRedisAvailable, redisPublish, redisSubscribe } from "./redis";
import {
  buildPvpFanoutNotice,
  parsePvpFanoutNotice,
  pvpFanoutMatchesDurableAuthority,
  PVP_FANOUT_REDIS_CHANNEL,
} from "./services/pvpFanoutService";
import {
  claimPvpSocket,
  isUnidentifiedPvpSocket,
  isPvpPlayerConnected,
  pvpSocketOwner,
  refreshPvpSocket,
  releasePvpSocket,
  socketPresenceHeartbeatMs,
  usesDistributedPvpSocket,
} from "./services/pvpSocketPresenceService";
import { serverMetrics } from "./services/metricsService";
import {
  WebSocketRateLimiter,
  consumeWebSocketRateLimit,
  webSocketPayloadLimit,
  webSocketRateLimitKey,
  webSocketViolationLimit,
} from "./services/webSocketRateLimitService";

/**
 * WebSocket coordinator for reconstructed PvP and Squad Chat transport.
 *
 * The recovered client originally used Photon. This server exposes the same high-level flow
 * over `/hub`: authenticate, enter matchmaking, receive MatchFound, join the assigned room,
 * relay match events, and report a result. The hub owns sockets and timers only; persistent
 * match state and rewards are delegated to `matchService`, while process-local room membership
 * is delegated to `RoomManager`.
 *
 * Every message after Identify is bound to the authenticated player stored on the connection.
 * Player IDs supplied inside later payloads are never accepted as identity. Queue, join, and
 * reconnect timers cover different lifecycle gaps: queue timeout removes an unpaired player,
 * join timeout cancels a pair that never forms a live room, and reconnect timeout resolves an
 * active disconnect without letting a third party claim the vacant slot.
 *
 * Match event payloads other than the validated CardPlayed event remain opaque until the original
 * Photon RPC/event schema is fully recovered. The current authority boundary validates
 * authentication, assigned membership, room lifecycle, and two-party result consensus, but does
 * not simulate combat. Squad Chat uses MongoDB authority plus optional Redis live fan-out.
 */

interface Client {
  id: string;
  socket: WebSocket;
  playerId?: string;
  /** Captured only after Identify; used to reproduce AccountBanned without a second player read. */
  accountName?: string;
  /** Current replacement-chat subscription; every delivery is still re-bound to live roster. */
  squadChatId?: string;
  /** Serialize one socket's messages so CardPlayed persistence completes before MatchResult. */
  processing: Promise<void>;
  /** Frames are limited before JSON parsing or database work enters the serialized chain. */
  rateLimiter: WebSocketRateLimiter;
  consecutiveRateLimitViolations: number;
  /** Renewable distributed route; only the exact owning socket may refresh or delete it. */
  presenceHeartbeat?: NodeJS.Timeout;
  /** HMAC-hidden pre-auth address, replaced with the stable authenticated player identity. */
  rateLimitKey: string;
}

const clients = new Map<string, Client>();
// Maps a player ID to the player's current socket client ID. This lets matchmaking push a
// MatchFound notification to the opponent that was already waiting in the queue.
const onlinePlayers = new Map<string, string>();
// A disconnected participant keeps the right to reclaim their match slot for a short,
// configurable window. Timers are keyed by match+player so reconnects cancel only their
// own pending forfeit and cannot affect the opponent's disconnect state.
const disconnectTimers = new Map<string, NodeJS.Timeout>();
// Queue timers apply before pairing. Join timers apply after pairing, when the persistent
// match already exists and both player records have been moved to InGame.
const matchmakingTimers = new Map<string, NodeJS.Timeout>();
const matchJoinTimers = new Map<string, NodeJS.Timeout>();
export const hubInstanceId = randomUUID();
// Redis pub/sub is normally at-most-once, but reconnection or an operator bridge can repeat a
// notice. Keep a bounded process-local delivery receipt so one message never appears twice.
const deliveredSquadChatMessages = new Map<string, true>();
// Redis pub/sub may be repeated by an operator bridge or reconnection edge. CardPlayed is a
// client-visible gameplay effect, so retain a bounded receiving-node receipt in addition to the
// durable source evidence. Active matches do not survive this coordinator's restart.
const deliveredPvpCardFanout = new Map<string, true>();

function clearMatchmakingTimer(playerId: string): void {
  const timer = matchmakingTimers.get(playerId);
  if (!timer) return;
  clearTimeout(timer);
  matchmakingTimers.delete(playerId);
}

function scheduleMatchmakingTimeout(playerId: string): void {
  clearMatchmakingTimer(playerId);
  const delayMs = Math.max(1, config.matchmakingTimeout) * 1000;
  const timer = setTimeout(() => {
    matchmakingTimers.delete(playerId);
    // remove returns false when the player was paired just before this callback. In that
    // race, suppressing MatchSearchTimedOut prevents a stale timeout after MatchFound.
    void leaveQueue(playerId).then((removed) => {
      if (!removed) return;
      sendToPlayer(playerId, {
        Type: "MatchSearchTimedOut",
        Payload: { TimeoutSeconds: Math.max(1, config.matchmakingTimeout) },
      });
    }).catch((error: unknown) => {
      logger.match.error("Matchmaking timeout cleanup failed", {
        playerId,
        error: error instanceof Error ? error.message : String(error),
      });
    });
  }, delayMs);
  timer.unref();
  matchmakingTimers.set(playerId, timer);
}

function disconnectKey(matchId: string, playerId: string): string {
  return `${matchId}:${playerId}`;
}

function clearDisconnectTimer(matchId: string, playerId: string): boolean {
  const key = disconnectKey(matchId, playerId);
  const timer = disconnectTimers.get(key);
  if (!timer) return false;
  clearTimeout(timer);
  disconnectTimers.delete(key);
  return true;
}

function clearMatchDisconnectTimers(matchId: string): void {
  for (const [key, timer] of disconnectTimers) {
    if (!key.startsWith(`${matchId}:`)) continue;
    clearTimeout(timer);
    disconnectTimers.delete(key);
  }
}

function clearMatchJoinTimer(matchId: string): void {
  const timer = matchJoinTimers.get(matchId);
  if (!timer) return;
  clearTimeout(timer);
  matchJoinTimers.delete(matchId);
}

/**
 * Bound the interval between MatchFound and an active two-player room. A match record is
 * created before either client joins, so relying on socket-disconnect handling is not enough:
 * neither player may ever send JoinMatch and therefore no RoomManager participant exists to
 * evict. Cancelling here restores both persistent player statuses without awarding a winner.
 */
function scheduleMatchJoinTimeout(matchId: string, playerIds: readonly string[]): void {
  clearMatchJoinTimer(matchId);
  const timeoutSeconds = Math.max(1, config.matchJoinTimeoutSeconds);
  const timer = setTimeout(() => {
    matchJoinTimers.delete(matchId);
    void (async () => {
      const room = roomManager.getRoom(matchId);

      // The second player may have activated the room at the same moment this callback was
      // queued. Re-checking live room state avoids cancelling a match that already started.
      if (room?.state === "active") return;

      const cancelled = await cancelMatch(matchId, "join_timeout");
      if (!cancelled) return;

      const ended: ClientEnvelope = {
        Type: "MatchEnded",
        Payload: { MatchId: matchId, Reason: "JoinTimeout" },
      };
      // One or both assigned players may live on another hub node. Use the same MongoDB-bound
      // fan-out path as other distributed lifecycle transitions instead of silently notifying
      // only process-local sockets after the durable cancellation commits.
      await broadcastDistributedMatch(matchId, playerIds, ended);

      clearMatchDisconnectTimers(matchId);
      roomManager.finish(matchId);
    })().catch((error: unknown) => {
      const message = error instanceof Error ? error.message : String(error);
      logger.match.error("Match join timeout resolution failed", { matchId, error: message });
    });
  }, timeoutSeconds * 1000);
  timer.unref();
  matchJoinTimers.set(matchId, timer);
}

function scheduleDisconnectResolution(eviction: {
  matchId: string;
  playerId: string;
  opponentId?: string;
  wasActive: boolean;
}): void {
  clearDisconnectTimer(eviction.matchId, eviction.playerId);
  const delayMs = Math.max(1, config.matchDisconnectGraceSeconds) * 1000;
  const timer = setTimeout(() => {
    disconnectTimers.delete(disconnectKey(eviction.matchId, eviction.playerId));
    void (async () => {
      const room = roomManager.getRoom(eviction.matchId);
      if (!room || roomManager.isParticipant(eviction.matchId, eviction.playerId)) return;

      const opponentConnected = eviction.opponentId
        ? roomManager.isParticipant(eviction.matchId, eviction.opponentId)
        : false;

      if (eviction.wasActive && opponentConnected && eviction.opponentId) {
        // Only a match that had actually started can be won by disconnect. The connected
        // opponent is both reporter and winner, satisfying match participation checks while
        // the atomic settlement claim prevents a late result from paying rewards twice.
        const settlement = await settleResult(eviction.matchId, eviction.opponentId, eviction.opponentId);
        roomManager.broadcast(eviction.matchId, {
          Type: "MatchEnded",
          Payload: { MatchId: eviction.matchId, WinnerId: settlement.winnerId, Reason: "OpponentForfeit" },
        });
      } else {
        // If the room never started or both players disappeared, nobody receives rewards.
        // Both DatabasePlayer status values are restored by cancelMatch.
        await cancelMatch(eviction.matchId, eviction.wasActive ? "both_players_disconnected" : "join_timeout");
      }

      clearMatchDisconnectTimers(eviction.matchId);
      clearMatchJoinTimer(eviction.matchId);
      roomManager.finish(eviction.matchId);
    })().catch((error: unknown) => {
      const message = error instanceof Error ? error.message : String(error);
      logger.match.error("Disconnect resolution failed", { matchId: eviction.matchId, error: message });
    });
  }, delayMs);
  timer.unref();
  disconnectTimers.set(disconnectKey(eviction.matchId, eviction.playerId), timer);
}

function trySend(client: Client, envelope: ClientEnvelope): boolean {
  if (client.socket.readyState === WebSocket.OPEN) {
    client.socket.send(JSON.stringify(envelope));
    return true;
  }
  return false;
}

function send(client: Client, envelope: ClientEnvelope): void {
  trySend(client, envelope);
}

function sendToPlayer(playerId: string, envelope: ClientEnvelope): boolean {
  const clientId = onlinePlayers.get(playerId);
  const client = clientId ? clients.get(clientId) : undefined;
  if (!client) return false;
  return trySend(client, envelope);
}

function sendToClientId(clientId: string, envelope: unknown): void {
  const client = clients.get(clientId);
  if (client) send(client, envelope as ClientEnvelope);
}

function sendSquadChatError(client: Client, error: unknown): void {
  const apiError = error instanceof ApiError ? error : null;
  send(client, {
    Type: "SquadChatError",
    Payload: {
      Code: apiError?.code ?? 99_996,
      Message: apiError?.message ?? "Unable to process Squad Chat request.",
    },
  });
}

function rememberSquadChatDelivery(messageId: string): boolean {
  if (deliveredSquadChatMessages.has(messageId)) return false;
  deliveredSquadChatMessages.set(messageId, true);
  if (deliveredSquadChatMessages.size > 10_000) {
    const oldest = deliveredSquadChatMessages.keys().next().value as string | undefined;
    if (oldest) deliveredSquadChatMessages.delete(oldest);
  }
  return true;
}

function rememberPvpCardFanoutDelivery(key: string): boolean {
  if (deliveredPvpCardFanout.has(key)) return false;
  deliveredPvpCardFanout.set(key, true);
  if (deliveredPvpCardFanout.size > 10_000) {
    const oldest = deliveredPvpCardFanout.keys().next().value as string | undefined;
    if (oldest) deliveredPvpCardFanout.delete(oldest);
  }
  return true;
}

function deliverSquadChatMessage(message: SquadChatWireMessage, memberPlayerIds: readonly string[]): void {
  if (!rememberSquadChatDelivery(message.MessageId)) return;
  const currentMembers = new Set(memberPlayerIds);
  for (const subscriber of clients.values()) {
    if (!subscriber.playerId
      || subscriber.squadChatId !== message.SquadId
      || !currentMembers.has(subscriber.playerId)) continue;
    send(subscriber, { Type: "SquadChatMessage", Payload: message });
  }
}

async function receiveRemoteSquadChat(raw: string): Promise<void> {
  const notice = parseSquadChatFanoutNotice(raw);
  if (!notice || notice.originId === hubInstanceId) return;
  // Redis input is a wake-up hint only. Reloading by the unique message ID proves persistence,
  // applies immediate expiry, and refreshes the recipient roster on this receiving node.
  const fanout = await getSquadChatFanout(notice.messageId);
  if (fanout) deliverSquadChatMessage(fanout.message, fanout.memberPlayerIds);
}

async function receiveRemotePvpFanout(raw: string): Promise<void> {
  const notice = parsePvpFanoutNotice(raw);
  if (!notice || notice.originId === hubInstanceId || !onlinePlayers.has(notice.targetPlayerId)) return;
  // MongoDB is the authority for both membership and lifecycle. Redis cannot make an arbitrary
  // local socket believe it owns a match merely by naming that player in a pub/sub payload.
  const match = await getMatch(notice.matchId);
  if (!match || !pvpFanoutMatchesDurableAuthority(notice, match)) return;
  if (notice.envelope.Type === "MatchEvent") {
    const payload = notice.envelope.Payload as MatchEventPayload;
    if (payload.Event === "CardPlayed") {
      const sequence = Number((payload.Data as CardPlayedEventData).Sequence);
      const receiptKey = `${notice.matchId}:${notice.sourcePlayerId}:${sequence}`;
      if (deliveredPvpCardFanout.has(receiptKey)) return;
      if (sendToPlayer(notice.targetPlayerId, notice.envelope)) {
        rememberPvpCardFanoutDelivery(receiptKey);
      }
      return;
    }
  }
  sendToPlayer(notice.targetPlayerId, notice.envelope);
}

async function deliverPvpEnvelope(
  playerId: string,
  matchId: string,
  envelope: ClientEnvelope,
  sourcePlayerId?: string,
): Promise<boolean> {
  if (sendToPlayer(playerId, envelope)) return true;
  if (!isRedisAvailable()) return false;
  return redisPublish(
    PVP_FANOUT_REDIS_CHANNEL,
    buildPvpFanoutNotice(hubInstanceId, playerId, matchId, envelope, sourcePlayerId),
  );
}

async function distributedMatchOpponent(matchId: string, playerId: string): Promise<string | null> {
  const match = await getMatch(matchId);
  if (!match || match.state !== "active" || !(match.roomStartedAt instanceof Date)) return null;
  const playerIds = match.players.map((participant) => participant.playerId);
  const joined = new Set(match.joinedPlayerIds ?? []);
  if (!playerIds.includes(playerId) || !playerIds.every((id) => joined.has(id))) return null;
  return playerIds.find((id) => id !== playerId) ?? null;
}

async function broadcastDistributedMatch(
  matchId: string,
  playerIds: readonly string[],
  envelope: ClientEnvelope,
): Promise<void> {
  await Promise.all(playerIds.map((playerId) => deliverPvpEnvelope(playerId, matchId, envelope)));
}

function scheduleDistributedDisconnectResolution(matchId: string, playerId: string, opponentId: string): void {
  clearDisconnectTimer(matchId, playerId);
  const timer = setTimeout(() => {
    disconnectTimers.delete(disconnectKey(matchId, playerId));
    void (async () => {
      const match = await getMatch(matchId);
      if (!match || match.state !== "active" || !match.disconnectedAt?.[playerId]) return;
      const opponentOnline = await isPvpPlayerConnected(opponentId);
      if (opponentOnline === null) {
        // Liveness is unknown during a Redis outage. Retry a full grace window rather than turning
        // an infrastructure failure into a player loss or an unearned opponent reward.
        scheduleDistributedDisconnectResolution(matchId, playerId, opponentId);
        return;
      }
      let ended: ClientEnvelope;
      if (opponentOnline) {
        const settlement = await settleResult(matchId, opponentId, opponentId);
        ended = {
          Type: "MatchEnded",
          Payload: { MatchId: matchId, WinnerId: settlement.winnerId, Reason: "OpponentForfeit" },
        };
      } else {
        const cancelled = await cancelMatch(matchId, "both_players_disconnected");
        if (!cancelled) return;
        ended = { Type: "MatchEnded", Payload: { MatchId: matchId, Reason: "BothPlayersDisconnected" } };
      }
      await broadcastDistributedMatch(matchId, match.players.map((participant) => participant.playerId), ended);
      clearMatchDisconnectTimers(matchId);
      clearMatchJoinTimer(matchId);
    })().catch((error: unknown) => {
      logger.match.error("Distributed disconnect resolution failed", {
        matchId,
        playerId,
        error: error instanceof Error ? error.message : String(error),
      });
    });
  }, Math.max(1, config.matchDisconnectGraceSeconds) * 1000);
  timer.unref();
  disconnectTimers.set(disconnectKey(matchId, playerId), timer);
}

async function handleDistributedSocketClose(client: Client, releaseAttempt = 0): Promise<void> {
  if (!client.playerId) return;
  const owner = pvpSocketOwner(hubInstanceId, client.id);
  // A replacement Identify may already own the route. In that case this old socket did not make
  // the player offline and must not start a false disconnect grace timer.
  const released = await releasePvpSocket(client.playerId, owner);
  if (released === null && releaseAttempt < 30) {
    const retry = setTimeout(() => {
      void handleDistributedSocketClose(client, releaseAttempt + 1);
    }, 2_000);
    retry.unref();
    return;
  }
  if (released !== true) return;
  const match = await findStartedMatchForPlayer(client.playerId);
  if (!match) return;
  const opponentId = match.players.find((participant) => participant.playerId !== client.playerId)?.playerId;
  if (!opponentId) return;
  const marked = await markMatchParticipantDisconnected(match.matchId, client.playerId);
  if (!marked) return;
  await deliverPvpEnvelope(opponentId, match.matchId, {
    Type: "OpponentDisconnected",
    Payload: { MatchId: match.matchId, PlayerId: client.playerId },
  });
  scheduleDistributedDisconnectResolution(match.matchId, client.playerId, opponentId);
}

async function startClientPresenceHeartbeat(client: Client, playerId: string): Promise<void> {
  if (client.presenceHeartbeat) clearInterval(client.presenceHeartbeat);
  const owner = pvpSocketOwner(hubInstanceId, client.id);
  const claimed = await claimPvpSocket(playerId, owner);
  try {
    if (!usesDistributedPvpSocket(claimed)) return;
  } catch (error) {
    // A SET error can be ambiguous: Redis may have accepted the owner immediately before the
    // connection failed. Compare-delete only this new owner so the previous login's route is
    // preserved when the write definitely did not occur, while an uncertain new route expires or
    // is removed instead of being treated as a successful distributed claim.
    await releasePvpSocket(playerId, owner);
    throw error;
  }
  client.presenceHeartbeat = setInterval(() => {
    void refreshPvpSocket(playerId, owner).then((owned) => {
      if (owned === false) client.socket.close(4001, "Signed in elsewhere");
    });
  }, socketPresenceHeartbeatMs);
  client.presenceHeartbeat.unref();
}

export async function createGameHub(httpServer: HttpServer): Promise<WebSocketServer> {
  roomManager.setSender(sendToClientId);

  await redisSubscribe(SQUAD_CHAT_REDIS_CHANNEL, (raw) => {
    void receiveRemoteSquadChat(raw).catch((error: unknown) => {
      logger.websocket.error("Remote Squad Chat fan-out failed", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  });
  await redisSubscribe(PVP_FANOUT_REDIS_CHANNEL, (raw) => {
    void receiveRemotePvpFanout(raw).catch((error: unknown) => {
      logger.websocket.error("Remote PvP fan-out failed", {
        error: error instanceof Error ? error.message : String(error),
      });
    });
  });

  const wss = new WebSocketServer({
    server: httpServer,
    path: "/hub",
    // ws otherwise permits very large frames. Bound allocation at the protocol parser so a
    // client cannot force JSON parsing or retain a giant opaque MatchEvent in memory.
    maxPayload: webSocketPayloadLimit(config.websocketMaxPayloadBytes),
  });

  wss.on("connection", (socket, request) => {
    const client: Client = {
      id: randomUUID(),
      socket,
      processing: Promise.resolve(),
      rateLimiter: new WebSocketRateLimiter(
        config.websocketRateLimitMessages,
        config.websocketRateLimitWindowSeconds,
      ),
      consecutiveRateLimitViolations: 0,
      rateLimitKey: webSocketRateLimitKey(request.socket.remoteAddress ?? "unknown"),
    };
    clients.set(client.id, client);
    serverMetrics.websocketConnected();
    logger.websocket.connected(client.id, { totalClients: clients.size });
    send(client, { Type: "Welcome", Payload: { ClientId: client.id } });

    socket.on("message", (raw) => {
      serverMetrics.websocketMessage();
      // Serialize rate consumption with message handling. Without this chain, a burst of async
      // Redis decisions could all observe/reorder around Identify or CardPlayed/MatchResult.
      client.processing = client.processing.then(async () => {
        const rate = await consumeWebSocketRateLimit(client.rateLimiter, client.rateLimitKey);
        if (!rate.allowed) {
          serverMetrics.websocketRejectedByRateLimit();
          client.consecutiveRateLimitViolations += 1;
          logger.warnWithEmoji("RATE", "WebSocket message rate limit exceeded", "SECURITY", {
            clientId: client.id,
            playerId: client.playerId,
            retryAfterSeconds: rate.retryAfterSeconds,
            violation: client.consecutiveRateLimitViolations,
            distributed: rate.distributed,
          });
          send(client, {
            Type: "RateLimited",
            Payload: { RetryAfterSeconds: rate.retryAfterSeconds },
          });
          if (client.consecutiveRateLimitViolations >= webSocketViolationLimit(config.websocketRateLimitMaxViolations)) {
            socket.close(1008, "Message rate limit exceeded");
          }
          return;
        }
        client.consecutiveRateLimitViolations = 0;
        let envelope: ClientEnvelope;
        try {
          envelope = JSON.parse(raw.toString()) as ClientEnvelope;
        } catch {
          logger.websocket.error("Malformed message", { clientId: client.id });
          return;
        }
        logger.websocket.message(client.id, envelope.Type);
        await handleMessage(client, envelope);
      }).catch((error: unknown) => {
        const message = error instanceof Error ? error.message : String(error);
        logger.websocket.error("Message handler failed", { clientId: client.id, error: message });
        send(client, { Type: "ServerError", Payload: { Message: "Unable to process message." } });
      });
    });

    socket.on("close", () => {
      const distributedPresence = Boolean(client.presenceHeartbeat);
      if (client.presenceHeartbeat) clearInterval(client.presenceHeartbeat);
      if (distributedPresence) {
        void handleDistributedSocketClose(client).catch((error: unknown) => {
          logger.match.error("Distributed socket close failed", {
            playerId: client.playerId,
            error: error instanceof Error ? error.message : String(error),
          });
        });
      } else {
        const eviction = roomManager.evictClient(client.id);
        if (eviction) scheduleDisconnectResolution(eviction);
      }
      if (client.playerId) {
        void leaveQueue(client.playerId);
        clearMatchmakingTimer(client.playerId);
        if (onlinePlayers.get(client.playerId) === client.id) onlinePlayers.delete(client.playerId);
      }
      clients.delete(client.id);
      serverMetrics.websocketDisconnected();
      logger.websocket.disconnected(client.id, { totalClients: clients.size });
    });

    socket.on("error", (err) => {
      logger.websocket.error("Socket error", { clientId: client.id, error: err.message });
    });
  });

  return wss;
}

async function handleMessage(client: Client, envelope: ClientEnvelope): Promise<void> {
  if (client.playerId && webSocketMessageRequiresSanctionCheck(envelope.Type)) {
    // Identify verifies the sanction at connection time, but a PvP socket can outlive an operator
    // decision. Re-read the small indexed moderation row before every non-heartbeat action so a
    // player cannot keep matchmaking, relaying combat, settling rewards, or sending chat on a
    // session that was active before the ban. Ping remains available only as transport liveness.
    try {
      // Identify already captured the authenticated public account name. Reusing it avoids a
      // second players-collection read for each relay event; the indexed sanction lookup remains
      // the only authoritative query and never trusts a name supplied by a later socket payload.
      await assertPlayerNotSanctioned({
        id: client.playerId,
        accountName: client.accountName ?? client.playerId,
      });
    } catch (error) {
      if (error instanceof ApiError && error.code === ApiErrorCode.AccountBanned) {
        send(client, {
          Type: "AuthError",
          Payload: { Code: error.code, Message: error.message, ...(error.details ?? {}) },
        });
        client.socket.close(4003, "Account suspended");
        return;
      }
      throw error;
    }
  }

  switch (envelope.Type) {
    case "Identify": {
      if (!isUnidentifiedPvpSocket(client.playerId)) {
        // Rebinding one live transport would leave the first player's onlinePlayers entry and
        // Redis owner pointing at a Client whose authenticated identity has changed. Keep socket
        // identity immutable; legitimate account switching reconnects and receives a new owner.
        send(client, { Type: "AuthError", Payload: { Message: "Socket is already identified." } });
        client.socket.close(1008, "Socket is already identified");
        return;
      }
      const p = envelope.Payload as IdentifyPayload | undefined;
      try {
        const doc = await authenticate(p?.PlayerId, p?.Token);
        try {
          // Establish the new cross-node route before evicting the old login. If Redis selected
          // distributed coordination but cannot commit the claim, the authenticated request fails
          // closed and the older valid socket remains usable.
          await startClientPresenceHeartbeat(client, doc.id);
        } catch (error: unknown) {
          logger.match.error("Distributed socket ownership claim failed", {
            playerId: doc.id,
            error: error instanceof Error ? error.message : String(error),
          });
          send(client, { Type: "ServerError", Payload: { Message: "PvP coordination is unavailable." } });
          client.socket.close(1013, "PvP coordination unavailable");
          return;
        }
        const previousClientId = onlinePlayers.get(doc.id);
        const previousClient = previousClientId ? clients.get(previousClientId) : undefined;
        if (previousClient && previousClient.id !== client.id) previousClient.socket.close(4001, "Signed in elsewhere");
        client.playerId = doc.id;
        client.accountName = doc.accountName;
        // Once authenticated, every connection/node for this account shares one player bucket.
        // This prevents reconnecting or changing source addresses from resetting the WS allowance.
        client.rateLimitKey = webSocketRateLimitKey(`player:${doc.id}`);
        onlinePlayers.set(doc.id, client.id);
        send(client, { Type: "Identified", Payload: { PlayerId: doc.id } });
      } catch {
        send(client, { Type: "AuthError", Payload: { Message: "Invalid credentials." } });
        client.socket.close();
      }
      return;
    }

    case "Ping":
      send(client, { Type: "Pong", Payload: envelope.Payload });
      return;

    case "SubscribeSquadChat": {
      if (!client.playerId) return send(client, { Type: "AuthError", Payload: { Message: "Identify first." } });
      try {
        const history = await getSquadChatHistory(client.playerId);
        client.squadChatId = history.squadId;
        send(client, {
          Type: "SquadChatSubscribed",
          Payload: {
            SquadId: history.squadId,
            Messages: history.messages,
            NextBeforeCursor: history.nextBeforeCursor,
          },
        });
      } catch (error: unknown) {
        client.squadChatId = undefined;
        sendSquadChatError(client, error);
      }
      return;
    }

    case "GetSquadChatHistory": {
      if (!client.playerId) return send(client, { Type: "AuthError", Payload: { Message: "Identify first." } });
      const payload = envelope.Payload as SquadChatHistoryPayload | undefined;
      try {
        const history = await getSquadChatHistory(
          client.playerId,
          typeof payload?.BeforeCursor === "string" ? payload.BeforeCursor : undefined,
        );
        client.squadChatId = history.squadId;
        send(client, {
          Type: "SquadChatHistory",
          Payload: {
            SquadId: history.squadId,
            Messages: history.messages,
            NextBeforeCursor: history.nextBeforeCursor,
          },
        });
      } catch (error: unknown) {
        sendSquadChatError(client, error);
      }
      return;
    }

    case "UnsubscribeSquadChat": {
      client.squadChatId = undefined;
      send(client, { Type: "SquadChatUnsubscribed", Payload: {} });
      return;
    }

    case "SendSquadChat": {
      if (!client.playerId) return send(client, { Type: "AuthError", Payload: { Message: "Identify first." } });
      const payload = envelope.Payload as SendSquadChatPayload | undefined;
      try {
        const result = await sendSquadChatMessage(client.playerId, {
          clientMessageId: typeof payload?.ClientMessageId === "string" ? payload.ClientMessageId : "",
          text: typeof payload?.Text === "string" ? payload.Text : "",
        });
        client.squadChatId = result.message.SquadId;
        // Checking the current roster returned by the persistence service closes the privacy
        // gap where a kicked member retains an old in-process channel subscription.
        if (!result.replayed) {
          deliverSquadChatMessage(result.message, result.memberPlayerIds);
          // Same-process delivery is complete even when Redis is disabled or unavailable. Remote
          // nodes treat this UUID as a hint and load authoritative content from MongoDB.
          void redisPublish(
            SQUAD_CHAT_REDIS_CHANNEL,
            buildSquadChatFanoutNotice(hubInstanceId, result.message.MessageId),
          );
        }
        send(client, {
          Type: "SquadChatMessageAccepted",
          Payload: { MessageId: result.message.MessageId, Replayed: result.replayed },
        });
      } catch (error: unknown) {
        sendSquadChatError(client, error);
      }
      return;
    }

    case "FindMatch": {
      if (!client.playerId) return send(client, { Type: "AuthError", Payload: { Message: "Identify first." } });
      const doc = await findById(client.playerId);
      if (!doc) return;
      if (doc.player.status === PlayerStatus.InGame) {
        return send(client, { Type: "MatchError", Payload: { Reason: "AlreadyInBattle" } });
      }
      let opponentId: string | null;
      try {
        opponentId = await enqueueForHub({
          playerId: doc.id,
          armyPower: doc.player.armyPower,
          leagueTier: doc.player.leagueTier,
        });
      } catch (error: unknown) {
        logger.match.error("Matchmaking coordination failed", {
          playerId: doc.id,
          error: error instanceof Error ? error.message : String(error),
        });
        return send(client, { Type: "MatchError", Payload: { Reason: "CoordinationUnavailable" } });
      }
      if (!opponentId) {
        scheduleMatchmakingTimeout(doc.id);
        send(client, { Type: "Searching", Payload: {} });
        return;
      }
      clearMatchmakingTimer(doc.id);
      clearMatchmakingTimer(opponentId);
      const opponent = await findById(opponentId);
      if (!opponent
        || opponent.player.status === PlayerStatus.InGame) {
        // Opponent vanished between queueing and pairing; requeue this player.
        try {
          await restoreWaitingForHub([{
            playerId: doc.id,
            armyPower: doc.player.armyPower,
            leagueTier: doc.player.leagueTier,
          }]);
        } catch {
          return send(client, { Type: "MatchError", Payload: { Reason: "CoordinationUnavailable" } });
        }
        scheduleMatchmakingTimeout(doc.id);
        send(client, { Type: "Searching", Payload: {} });
        return;
      }
      const self: MatchPlayer = { playerId: doc.id, name: doc.player.accountName, armyPower: doc.player.armyPower, leagueTier: doc.player.leagueTier };
      const other: MatchPlayer = { playerId: opponent.id, name: opponent.player.accountName, armyPower: opponent.player.armyPower, leagueTier: opponent.player.leagueTier };
      let matchId: string;
      try {
        matchId = await createMatch(self, other, hubInstanceId);
      } catch (error: unknown) {
        // Pairing removed both queue entries before durable admission. Re-read both profiles so
        // a player claimed by a concurrent match is never reintroduced into the queue, then
        // restore all still-connected candidates as one non-pairing batch.
        const fresh = await Promise.all([findById(self.playerId), findById(other.playerId)]);
        const candidates: MatchPlayer[] = [];
        for (const [index, candidate] of [self, other].entries()) {
          const current = fresh[index];
          if (!current
            || current.player.status === PlayerStatus.InGame
            || (!isRedisAvailable() && !onlinePlayers.has(candidate.playerId))) continue;
          // A profile may have changed Army Power, league, or display name between queueing and
          // admission. Restore its fresh server snapshot so the next pairing can pass the same
          // transaction guard instead of looping on stale queue data.
          candidates.push({
            playerId: current.id,
            name: current.player.accountName,
            armyPower: current.player.armyPower,
            leagueTier: current.player.leagueTier,
          });
        }
        await restoreWaitingForHub(candidates);
        for (const candidate of candidates) {
          // A remote candidate's original node still owns its timer and already shows Searching.
          // Starting a second timer here could remove the restored row before that owning node can
          // notify its socket. Only refresh timer/UI state for candidates attached to this process.
          if (onlinePlayers.has(candidate.playerId)) {
            scheduleMatchmakingTimeout(candidate.playerId);
            sendToPlayer(candidate.playerId, { Type: "Searching", Payload: { Restored: true } });
          }
        }
        logger.match.error("Atomic match admission failed", {
          players: [self.playerId, other.playerId],
          restored: candidates.map((candidate) => candidate.playerId),
          error: error instanceof Error ? error.message : String(error),
        });
        if (!candidates.some((candidate) => candidate.playerId === self.playerId)) {
          send(client, { Type: "MatchError", Payload: { Reason: "AdmissionRejected" } });
        }
        return;
      }
      scheduleMatchJoinTimeout(matchId, [self.playerId, other.playerId]);
      const found = (opponentName: string) => ({ Type: "MatchFound", Payload: { MatchId: matchId, Opponent: opponentName } });
      const selfDelivered = await deliverPvpEnvelope(self.playerId, matchId, found(other.name));
      const opponentDelivered = await deliverPvpEnvelope(opponent.id, matchId, found(self.name));
      if (!selfDelivered || !opponentDelivered) {
        await cancelMatch(matchId, "match_found_delivery_failed");
        clearMatchJoinTimer(matchId);
        const failed: ClientEnvelope = {
          Type: "MatchError",
          Payload: { MatchId: matchId, Reason: "DeliveryFailed" },
        };
        await Promise.all([
          ...(selfDelivered ? [deliverPvpEnvelope(self.playerId, matchId, failed)] : []),
          ...(opponentDelivered ? [deliverPvpEnvelope(opponent.id, matchId, failed)] : []),
        ]);
      }
      return;
    }

    case "CancelMatch": {
      if (client.playerId) {
        await leaveQueue(client.playerId);
        clearMatchmakingTimer(client.playerId);
      }
      send(client, { Type: "MatchCancelled", Payload: {} });
      return;
    }

    case "JoinMatch": {
      if (!client.playerId) return send(client, { Type: "AuthError", Payload: { Message: "Identify first." } });
      const p = envelope.Payload as JoinMatchPayload;
      if (client.presenceHeartbeat) {
        const joined = await joinActiveMatch(p?.MatchId, client.playerId);
        if (!joined) {
          return send(client, {
            Type: "MatchError",
            Payload: { MatchId: p?.MatchId, Reason: "NotParticipantOrFull" },
          });
        }
        send(client, {
          Type: "MatchJoined",
          Payload: {
            MatchId: p.MatchId,
            State: joined.started ? "active" : "waiting",
            Participants: joined.joinedCount,
          },
        });
        const reconnected = await clearMatchParticipantDisconnected(p.MatchId, client.playerId);
        if (reconnected) {
          clearDisconnectTimer(p.MatchId, client.playerId);
          const opponentId = joined.match.players
            .find((participant) => participant.playerId !== client.playerId)?.playerId;
          if (opponentId) {
            await deliverPvpEnvelope(opponentId, p.MatchId, {
              Type: "OpponentReconnected",
              Payload: { MatchId: p.MatchId, PlayerId: client.playerId },
            });
          }
        }
        if (joined.activatedByCaller) {
          const started: ClientEnvelope = { Type: "MatchStart", Payload: { MatchId: p.MatchId } };
          // The compare-and-set winner emits exactly one start instruction per assigned player.
          // Same-node sockets receive it directly; remote nodes revalidate roomStartedAt from
          // MongoDB before delivering the Redis instruction.
          await Promise.all(joined.match.players.map((participant) =>
            deliverPvpEnvelope(participant.playerId, p.MatchId, started)
          ));
          clearMatchJoinTimer(p.MatchId);
        }
        return;
      }
      const match = await getMatch(p?.MatchId);
      const allowedPlayerIds = match?.state === "active" ? match.players.map((participant) => participant.playerId) : [];
      const room = roomManager.join(p?.MatchId, client.playerId, client.id, allowedPlayerIds);
      if (!room) {
        return send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "NotParticipantOrFull" } });
      }
      const reconnected = clearDisconnectTimer(p.MatchId, client.playerId);
      if (reconnected) {
        roomManager.broadcast(p.MatchId, {
          Type: "OpponentReconnected",
          Payload: { MatchId: p.MatchId, PlayerId: client.playerId },
        });
      }
      // The room becomes active only when both assigned players have joined. At that exact
      // transition the pre-game deadline no longer owns the match and must be cancelled.
      if (room.state === "active") clearMatchJoinTimer(p.MatchId);
      send(client, {
        Type: "MatchJoined",
        Payload: { MatchId: p.MatchId, State: room.state, Participants: room.participants.size },
      });
      return;
    }

    case "MatchEvent": {
      if (!client.playerId) return;
      const p = envelope.Payload as MatchEventPayload;
      if (typeof p?.Event !== "string"
        || p.Event.length === 0
        || p.Event.length > 128
        || /\p{Cc}/u.test(p.Event)) {
        return send(client, {
          Type: "MatchError",
          Payload: { MatchId: p?.MatchId, Reason: "InvalidEvent" },
        });
      }
      // Never relay attacker-supplied root/payload fields. Unknown event Data remains opaque until
      // authoritative combat recovery, but the transport wrapper itself is canonical and bounded.
      const relayedEnvelope: ClientEnvelope = {
        Type: "MatchEvent",
        Payload: {
          MatchId: p.MatchId,
          Event: p.Event,
          ...(Object.prototype.hasOwnProperty.call(p, "Data") ? { Data: p.Data } : {}),
        },
      };
      if (client.presenceHeartbeat) {
        const opponentId = await distributedMatchOpponent(p?.MatchId, client.playerId);
        if (!opponentId) {
          return send(client, {
            Type: "MatchError",
            Payload: { MatchId: p?.MatchId, Reason: "NotInActiveMatch" },
          });
        }
        if (p?.Event === "CardPlayed") {
          const data = p.Data as CardPlayedEventData | undefined;
          const sequence = Number(data?.Sequence);
          try {
            const recorded = await recordRelayedCardPlay(
              p.MatchId,
              client.playerId,
              sequence,
              typeof data?.CardId === "string" ? data.CardId : "",
            );
            // Evidence persistence and live delivery have separate failure boundaries. If Redis
            // failed after evidence committed, the same sequence may retry delivery; once the
            // handoff receipt exists, an acknowledgement retry cannot emit a second effect.
            const alreadyDelivered = await wasRelayedCardDelivered(p.MatchId, client.playerId, sequence);
            const delivered = alreadyDelivered
              || await deliverPvpEnvelope(opponentId, p.MatchId, {
                Type: "MatchEvent",
                Payload: {
                  MatchId: p.MatchId,
                  Event: "CardPlayed",
                  Data: { Sequence: sequence, CardId: typeof data?.CardId === "string" ? data.CardId : "" },
                },
              }, client.playerId);
            if (!delivered) {
              return send(client, {
                Type: "MatchError",
                Payload: { MatchId: p.MatchId, Reason: "EventDeliveryFailed" },
              });
            }
            if (!alreadyDelivered) await markRelayedCardDelivered(p.MatchId, client.playerId, sequence);
            send(client, {
              Type: "MatchEventAccepted",
              Payload: {
                MatchId: p.MatchId,
                Event: p.Event,
                Sequence: sequence,
                Replayed: alreadyDelivered,
                EvidenceReplayed: recorded.replayed,
              },
            });
          } catch {
            send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "InvalidCardPlay" } });
          }
          return;
        }
        if (!await deliverPvpEnvelope(opponentId, p.MatchId, relayedEnvelope, client.playerId)) {
          send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "EventDeliveryFailed" } });
        }
        return;
      }
      if (p?.Event === "CardPlayed") {
        const data = p.Data as CardPlayedEventData | undefined;
        const sequence = Number(data?.Sequence);
        try {
          const room = roomManager.getRoom(p.MatchId);
          if (room?.state !== "active" || !roomManager.isParticipant(p.MatchId, client.playerId)) {
            return send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "NotInActiveMatch" } });
          }
          const recorded = await recordRelayedCardPlay(
            p.MatchId,
            client.playerId,
            sequence,
            typeof data?.CardId === "string" ? data.CardId : "",
          );
          // Room-local delivery tracking distinguishes a lost sender acknowledgement from
          // evidence that committed immediately before the opponent disconnected. The former is
          // suppressed; the latter may be delivered once after a valid room reconnection.
          const delivery = roomManager.relayCardEvent(p.MatchId, client.playerId, sequence, {
            Type: "MatchEvent",
            Payload: {
              MatchId: p.MatchId,
              Event: "CardPlayed",
              Data: { Sequence: sequence, CardId: typeof data?.CardId === "string" ? data.CardId : "" },
            },
          });
          if (delivery === "invalid") {
            return send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "NotInActiveMatch" } });
          }
          send(client, {
            Type: "MatchEventAccepted",
            Payload: {
              MatchId: p.MatchId,
              Event: p.Event,
              Sequence: sequence,
              Replayed: delivery === "replayed",
              EvidenceReplayed: recorded.replayed,
            },
          });
        } catch {
          send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "InvalidCardPlay" } });
        }
        return;
      }
      if (!roomManager.relay(p?.MatchId, client.playerId, relayedEnvelope)) {
        send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "NotInActiveMatch" } });
      }
      return;
    }

    case "MatchResult": {
      if (!client.playerId) return;
      const p = envelope.Payload as MatchResultPayload;
      if (client.presenceHeartbeat) {
        const durableMatch = await getMatch(p?.MatchId);
        const joined = new Set(durableMatch?.joinedPlayerIds ?? []);
        const terminalReplay = durableMatch?.state === "finished" || durableMatch?.state === "cancelled";
        if (!durableMatch
          || !durableMatch.players.some((participant) => participant.playerId === client.playerId)
          || (!terminalReplay && (
            durableMatch.state !== "active"
            || !(durableMatch.roomStartedAt instanceof Date)
            || !durableMatch.players.every((participant) => joined.has(participant.playerId))
          ))) {
          return send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "InvalidResult" } });
        }
        let durable;
        try {
          durable = await reportMatchResult(
            p.MatchId,
            client.playerId,
            p.WinnerId,
            parsePvpUsedCards(p.UsedCards ?? []),
            true,
          );
        } catch {
          return send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "InvalidUsedCards" } });
        }
        if (durable.status === "conflict") {
          const conflict: ClientEnvelope = {
            Type: "MatchError",
            Payload: { MatchId: p.MatchId, Reason: "ResultConflict" },
          };
          await broadcastDistributedMatch(
            p.MatchId,
            durableMatch.players.map((participant) => participant.playerId),
            conflict,
          );
          clearMatchJoinTimer(p.MatchId);
          clearMatchDisconnectTimers(p.MatchId);
          return;
        }
        if (durable.status === "pending") {
          return send(client, { Type: "ResultPending", Payload: { MatchId: p.MatchId } });
        }
        if (!durable.settlement) {
          return send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "InvalidResult" } });
        }
        const ended: ClientEnvelope = {
          Type: "MatchEnded",
          Payload: { MatchId: p.MatchId, WinnerId: durable.settlement.winnerId },
        };
        await broadcastDistributedMatch(
          p.MatchId,
          durableMatch.players.map((participant) => participant.playerId),
          ended,
        );
        clearMatchJoinTimer(p.MatchId);
        clearMatchDisconnectTimers(p.MatchId);
        logger.match.event("Distributed match result received", {
          matchId: p.MatchId,
          winnerId: p.WinnerId,
          rewarded: durable.settlement.rewarded,
        });
        return;
      }
      // Settle only after both participants report the same winner.
      const report = roomManager.recordResult(p?.MatchId, client.playerId, p?.WinnerId);
      // Normal reports require current local-room membership. Once MongoDB is terminal the room
      // should already be gone, so an assigned participant may bypass only that missing transient
      // mirror to recover a lost immutable MatchEnded/ResultConflict response.
      const terminalRetryMatch = report === "invalid" ? await getMatch(p?.MatchId) : null;
      const allowDurableTerminalReplay = terminalRetryMatch?.state === "finished"
        || terminalRetryMatch?.state === "cancelled";
      if (report === "invalid" && !allowDurableTerminalReplay) {
        return send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "InvalidResult" } });
      }
      let durable;
      try {
        durable = await reportMatchResult(
          p.MatchId,
          client.playerId,
          p.WinnerId,
          parsePvpUsedCards(p.UsedCards ?? []),
          true,
        );
      } catch {
        return send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "InvalidUsedCards" } });
      }
      // The local room report proves only that this socket currently belongs to the room. MongoDB
      // owns cross-handler consensus and may already be terminal when the local mirror says
      // pending, so only the durable decision may select pending/conflict/finished behavior.
      const resolvedStatus = resolveMatchReportStatus(report, durable.status, allowDurableTerminalReplay);
      if (resolvedStatus === "conflict") {
        roomManager.broadcast(p.MatchId, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "ResultConflict" } });
        if (!roomManager.isParticipant(p.MatchId, client.playerId)) {
          send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "ResultConflict" } });
        }
        clearMatchJoinTimer(p.MatchId);
        roomManager.finish(p.MatchId);
        clearMatchDisconnectTimers(p.MatchId);
        return;
      }
      if (resolvedStatus === "pending") {
        return send(client, { Type: "ResultPending", Payload: { MatchId: p.MatchId } });
      }

      if (resolvedStatus === "invalid") {
        return send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "InvalidResult" } });
      }

      const settlement = durable.settlement;
      if (!settlement) {
        return send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "InvalidResult" } });
      }
      const ended = { Type: "MatchEnded", Payload: { MatchId: p.MatchId, WinnerId: settlement.winnerId } };
      roomManager.broadcast(p.MatchId, ended);
      if (!roomManager.isParticipant(p.MatchId, client.playerId)) send(client, ended);
      clearMatchJoinTimer(p.MatchId);
      roomManager.finish(p.MatchId);
      clearMatchDisconnectTimers(p.MatchId);
      logger.match.event("Match result received", { matchId: p.MatchId, winnerId: p.WinnerId, rewarded: settlement.rewarded });
      return;
    }

    default:
      // Never acknowledge an unknown mutation as successful. Returning a protocol error
      // makes client/server version drift observable and prevents false-success gameplay UI.
      logger.websocket.error("Unknown message type", { clientId: client.id, type: envelope.Type });
      send(client, { Type: "ProtocolError", Payload: { Message: "Unknown message type.", Type: envelope.Type } });
      return;
  }
}
