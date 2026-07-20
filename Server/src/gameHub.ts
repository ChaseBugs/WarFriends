import { randomUUID } from "crypto";
import type { Server as HttpServer } from "http";
import { WebSocket, WebSocketServer } from "ws";
import { authenticate } from "./services/authService";
import { findById } from "./services/playerService";
import { enqueue, remove as leaveQueue } from "./services/matchmakingService";
import {
  cancelMatch,
  createMatch,
  getMatch,
  recordRelayedCardPlay,
  reportMatchResult,
  settleResult,
  type MatchPlayer,
} from "./services/matchService";
import { parsePvpUsedCards } from "./services/cardInventoryService";
import { roomManager } from "./gameRooms/roomManager";
import type {
  ClientEnvelope,
  CardPlayedEventData,
  IdentifyPayload,
  JoinMatchPayload,
  MatchEventPayload,
  MatchResultPayload,
} from "./gameRooms/types";
import logger from "./utils/logger";
import { PlayerStatus } from "./constants";
import { config } from "./config";
import { ApiError } from "./apiErrors";
import { getSquadChatHistory, sendSquadChatMessage } from "./services/squadChatService";
import type { SendSquadChatPayload } from "./gameRooms/types";

/**
 * WebSocket coordinator for the reconstructed PvP transport.
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
 * Match event payloads remain opaque until the original Photon RPC/event schema is fully
 * recovered. The current authority boundary validates authentication, assigned membership,
 * room lifecycle, and two-party result consensus, but does not simulate combat.
 */

interface Client {
  id: string;
  socket: WebSocket;
  playerId?: string;
  /** Current replacement-chat subscription; every delivery is still re-bound to live roster. */
  squadChatId?: string;
  /** Serialize one socket's messages so CardPlayed persistence completes before MatchResult. */
  processing: Promise<void>;
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
    if (!leaveQueue(playerId)) return;
    sendToPlayer(playerId, {
      Type: "MatchSearchTimedOut",
      Payload: { TimeoutSeconds: Math.max(1, config.matchmakingTimeout) },
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
      for (const playerId of playerIds) sendToPlayer(playerId, ended);

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

function send(client: Client, envelope: ClientEnvelope): void {
  if (client.socket.readyState === WebSocket.OPEN) {
    client.socket.send(JSON.stringify(envelope));
  }
}

function sendToPlayer(playerId: string, envelope: ClientEnvelope): boolean {
  const clientId = onlinePlayers.get(playerId);
  const client = clientId ? clients.get(clientId) : undefined;
  if (!client) return false;
  send(client, envelope);
  return true;
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

export function createGameHub(httpServer: HttpServer): WebSocketServer {
  roomManager.setSender(sendToClientId);

  const wss = new WebSocketServer({ server: httpServer, path: "/hub" });

  wss.on("connection", (socket) => {
    const client: Client = { id: randomUUID(), socket, processing: Promise.resolve() };
    clients.set(client.id, client);
    logger.websocket.connected(client.id, { totalClients: clients.size });
    send(client, { Type: "Welcome", Payload: { ClientId: client.id } });

    socket.on("message", (raw) => {
      let envelope: ClientEnvelope;
      try {
        envelope = JSON.parse(raw.toString()) as ClientEnvelope;
      } catch {
        logger.websocket.error("Malformed message", { clientId: client.id });
        return;
      }
      logger.websocket.message(client.id, envelope.Type);
      client.processing = client.processing.then(() => handleMessage(client, envelope)).catch((error: unknown) => {
        const message = error instanceof Error ? error.message : String(error);
        logger.websocket.error("Message handler failed", { clientId: client.id, type: envelope.Type, error: message });
        send(client, { Type: "ServerError", Payload: { Message: "Unable to process message." } });
      });
    });

    socket.on("close", () => {
      const eviction = roomManager.evictClient(client.id);
      if (eviction) scheduleDisconnectResolution(eviction);
      if (client.playerId) {
        leaveQueue(client.playerId);
        clearMatchmakingTimer(client.playerId);
        if (onlinePlayers.get(client.playerId) === client.id) onlinePlayers.delete(client.playerId);
      }
      clients.delete(client.id);
      logger.websocket.disconnected(client.id, { totalClients: clients.size });
    });

    socket.on("error", (err) => {
      logger.websocket.error("Socket error", { clientId: client.id, error: err.message });
    });
  });

  return wss;
}

async function handleMessage(client: Client, envelope: ClientEnvelope): Promise<void> {
  switch (envelope.Type) {
    case "Identify": {
      const p = envelope.Payload as IdentifyPayload | undefined;
      try {
        const doc = await authenticate(p?.PlayerId, p?.Token);
        const previousClientId = onlinePlayers.get(doc.id);
        const previousClient = previousClientId ? clients.get(previousClientId) : undefined;
        if (previousClient && previousClient.id !== client.id) previousClient.socket.close(4001, "Signed in elsewhere");
        client.playerId = doc.id;
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
          Payload: { SquadId: history.squadId, Messages: history.messages },
        });
      } catch (error: unknown) {
        client.squadChatId = undefined;
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
        const currentMembers = new Set(result.memberPlayerIds);
        // Checking the current roster returned by the persistence service closes the privacy
        // gap where a kicked member retains an old in-process channel subscription.
        if (!result.replayed) {
          for (const subscriber of clients.values()) {
            if (!subscriber.playerId
              || subscriber.squadChatId !== result.message.SquadId
              || !currentMembers.has(subscriber.playerId)) continue;
            send(subscriber, { Type: "SquadChatMessage", Payload: result.message });
          }
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
      const opponentId = enqueue({
        playerId: doc.id,
        armyPower: doc.player.armyPower,
        leagueTier: doc.player.leagueTier,
      });
      if (!opponentId) {
        scheduleMatchmakingTimeout(doc.id);
        send(client, { Type: "Searching", Payload: {} });
        return;
      }
      clearMatchmakingTimer(doc.id);
      clearMatchmakingTimer(opponentId);
      const opponent = await findById(opponentId);
      const opponentClientId = onlinePlayers.get(opponentId);
      const opponentClient = opponentClientId ? clients.get(opponentClientId) : undefined;
      if (!opponent || !opponentClient || opponentClient.socket.readyState !== WebSocket.OPEN) {
        // Opponent vanished between queueing and pairing; requeue this player.
        enqueue({ playerId: doc.id, armyPower: doc.player.armyPower, leagueTier: doc.player.leagueTier });
        scheduleMatchmakingTimeout(doc.id);
        send(client, { Type: "Searching", Payload: {} });
        return;
      }
      const self: MatchPlayer = { playerId: doc.id, name: doc.player.accountName, armyPower: doc.player.armyPower, leagueTier: doc.player.leagueTier };
      const other: MatchPlayer = { playerId: opponent.id, name: opponent.player.accountName, armyPower: opponent.player.armyPower, leagueTier: opponent.player.leagueTier };
      const matchId = await createMatch(self, other);
      scheduleMatchJoinTimeout(matchId, [self.playerId, other.playerId]);
      const found = (opponentName: string) => ({ Type: "MatchFound", Payload: { MatchId: matchId, Opponent: opponentName } });
      send(client, found(other.name));
      sendToPlayer(opponent.id, found(self.name));
      return;
    }

    case "CancelMatch": {
      if (client.playerId) {
        leaveQueue(client.playerId);
        clearMatchmakingTimer(client.playerId);
      }
      send(client, { Type: "MatchCancelled", Payload: {} });
      return;
    }

    case "JoinMatch": {
      if (!client.playerId) return send(client, { Type: "AuthError", Payload: { Message: "Identify first." } });
      const p = envelope.Payload as JoinMatchPayload;
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
          const delivery = roomManager.relayCardEvent(p.MatchId, client.playerId, sequence, envelope);
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
      if (!roomManager.relay(p?.MatchId, client.playerId, envelope)) {
        send(client, { Type: "MatchError", Payload: { MatchId: p?.MatchId, Reason: "NotInActiveMatch" } });
      }
      return;
    }

    case "MatchResult": {
      if (!client.playerId) return;
      const p = envelope.Payload as MatchResultPayload;
      // Settle only after both participants report the same winner.
      const report = roomManager.recordResult(p?.MatchId, client.playerId, p?.WinnerId);
      if (report === "invalid") {
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
      if (report === "conflict" || durable.status === "conflict") {
        roomManager.broadcast(p.MatchId, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "ResultConflict" } });
        return;
      }
      if (report === "pending" || durable.status === "pending") {
        return send(client, { Type: "ResultPending", Payload: { MatchId: p.MatchId } });
      }

      const settlement = durable.settlement;
      if (!settlement) {
        return send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "InvalidResult" } });
      }
      roomManager.broadcast(p.MatchId, { Type: "MatchEnded", Payload: { MatchId: p.MatchId, WinnerId: settlement.winnerId } });
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
