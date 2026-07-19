import { randomUUID } from "crypto";
import type { Server as HttpServer } from "http";
import { WebSocket, WebSocketServer } from "ws";
import { authenticate } from "./services/authService";
import { findById } from "./services/playerService";
import { enqueue, remove as leaveQueue } from "./services/matchmakingService";
import { createMatch, settleResult, type MatchPlayer } from "./services/matchService";
import { roomManager } from "./gameRooms/roomManager";
import type {
  ClientEnvelope,
  IdentifyPayload,
  JoinMatchPayload,
  MatchEventPayload,
  MatchResultPayload,
} from "./gameRooms/types";
import logger from "./utils/logger";

// WebSocket hub — the live PvP relay that stands in for Photon (BACKEND.md §3). A client
// connects to /hub, Identifies with its id+token, joins a match room by MatchId, then
// exchanges opaque MatchEvent messages that are relayed to the opponent. MatchResult is
// where reward/league validation will hook in (matchService, next phase).

interface Client {
  id: string;
  socket: WebSocket;
  playerId?: string;
}

const clients = new Map<string, Client>();
// playerId → clientId, so matchmaking can push MatchFound to a paired opponent's socket.
const onlinePlayers = new Map<string, string>();

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

export function createGameHub(httpServer: HttpServer): WebSocketServer {
  roomManager.setSender(sendToClientId);

  const wss = new WebSocketServer({ server: httpServer, path: "/hub" });

  wss.on("connection", (socket) => {
    const client: Client = { id: randomUUID(), socket };
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
      void handleMessage(client, envelope);
    });

    socket.on("close", () => {
      roomManager.evictClient(client.id);
      if (client.playerId) {
        leaveQueue(client.playerId);
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

    case "FindMatch": {
      if (!client.playerId) return send(client, { Type: "AuthError", Payload: { Message: "Identify first." } });
      const doc = await findById(client.playerId);
      if (!doc) return;
      const opponentId = enqueue({
        playerId: doc.id,
        armyPower: doc.player.armyPower,
        leagueTier: doc.player.leagueTier,
      });
      if (!opponentId) {
        send(client, { Type: "Searching", Payload: {} });
        return;
      }
      const opponent = await findById(opponentId);
      if (!opponent) {
        // Opponent vanished between queueing and pairing; requeue this player.
        enqueue({ playerId: doc.id, armyPower: doc.player.armyPower, leagueTier: doc.player.leagueTier });
        send(client, { Type: "Searching", Payload: {} });
        return;
      }
      const self: MatchPlayer = { playerId: doc.id, name: doc.player.accountName, armyPower: doc.player.armyPower, leagueTier: doc.player.leagueTier };
      const other: MatchPlayer = { playerId: opponent.id, name: opponent.player.accountName, armyPower: opponent.player.armyPower, leagueTier: opponent.player.leagueTier };
      const matchId = await createMatch(self, other);
      const found = (opponentName: string) => ({ Type: "MatchFound", Payload: { MatchId: matchId, Opponent: opponentName } });
      send(client, found(other.name));
      sendToPlayer(opponent.id, found(self.name));
      return;
    }

    case "CancelMatch": {
      if (client.playerId) leaveQueue(client.playerId);
      send(client, { Type: "MatchCancelled", Payload: {} });
      return;
    }

    case "JoinMatch": {
      if (!client.playerId) return send(client, { Type: "AuthError", Payload: { Message: "Identify first." } });
      const p = envelope.Payload as JoinMatchPayload;
      const room = roomManager.join(p.MatchId, client.playerId, client.id);
      if (!room) return send(client, { Type: "MatchError", Payload: { MatchId: p.MatchId, Reason: "Full" } });
      send(client, {
        Type: "MatchJoined",
        Payload: { MatchId: p.MatchId, State: room.state, Participants: room.participants.size },
      });
      return;
    }

    case "MatchEvent": {
      if (!client.playerId) return;
      const p = envelope.Payload as MatchEventPayload;
      roomManager.relay(p.MatchId, client.playerId, envelope);
      return;
    }

    case "MatchResult": {
      if (!client.playerId) return;
      const p = envelope.Payload as MatchResultPayload;
      // Settle authoritatively (idempotent — the loser's client may also report the result).
      const settlement = await settleResult(p.MatchId, p.WinnerId);
      roomManager.broadcast(p.MatchId, { Type: "MatchEnded", Payload: { MatchId: p.MatchId, WinnerId: settlement.winnerId } });
      roomManager.finish(p.MatchId);
      logger.match.event("Match result received", { matchId: p.MatchId, winnerId: p.WinnerId, rewarded: settlement.rewarded });
      return;
    }

    default:
      send(client, { Type: "Ack", Payload: { Type: envelope.Type } });
      return;
  }
}
