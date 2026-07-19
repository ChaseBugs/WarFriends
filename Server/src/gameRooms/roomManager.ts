import type { RoomState } from "./types";
import logger from "../utils/logger";

// In-memory registry for live PvP rooms. Persistent match ownership and rewards live in
// matchService; this class owns only the socket-facing state: which of the two assigned
// players are connected, whether both have joined, event relay, and result-report consensus.
// It is intentionally process-local for now. Horizontal scaling will require a shared room
// coordinator (for example Redis pub/sub) so players connected to different nodes can meet.

export interface Participant {
  playerId: string;
  clientId: string;
}

export interface MatchRoom {
  matchId: string;
  state: RoomState;
  participants: Map<string, Participant>; // keyed by playerId
  allowedPlayerIds: Set<string>;
  resultReports: Map<string, string>; // reporter playerId -> winner playerId
  createdAt: number;
}

export interface EvictedParticipant {
  matchId: string;
  playerId: string;
  opponentId?: string;
  wasActive: boolean;
}

type SendToPlayer = (clientId: string, envelope: unknown) => void;

export class RoomManager {
  private rooms = new Map<string, MatchRoom>();
  private playerRoom = new Map<string, string>(); // playerId → matchId
  private send: SendToPlayer = () => undefined;

  setSender(send: SendToPlayer): void {
    this.send = send;
  }

  getRoom(matchId: string): MatchRoom | undefined {
    return this.rooms.get(matchId);
  }

  /**
   * Attach an authenticated player to the room, creating its in-memory representation on
   * first arrival. The persistent match supplies allowedPlayerIds; checking that immutable
   * pair prevents an unrelated authenticated account from guessing a MatchId and joining.
   * Rejoining replaces only that player's socket ID, which supports reconnect safely.
   */
  join(matchId: string, playerId: string, clientId: string, allowedPlayerIds: readonly string[]): MatchRoom | null {
    if (!allowedPlayerIds.includes(playerId)) return null;
    let room = this.rooms.get(matchId);
    if (!room) {
      room = {
        matchId,
        state: "waiting",
        participants: new Map(),
        allowedPlayerIds: new Set(allowedPlayerIds),
        resultReports: new Map(),
        createdAt: Date.now(),
      };
      this.rooms.set(matchId, room);
    }
    if (!room.allowedPlayerIds.has(playerId)) return null;
    const existing = room.participants.get(playerId);
    if (!existing && room.participants.size >= 2) {
      return null; // room full with two different players
    }
    room.participants.set(playerId, { playerId, clientId });
    this.playerRoom.set(playerId, matchId);

    if (room.participants.size === 2 && room.state === "waiting") {
      room.state = "active";
      logger.match.event("Match room active", { matchId });
      this.broadcast(matchId, { Type: "MatchStart", Payload: { MatchId: matchId } });
    }
    return room;
  }

  /**
   * Relay an in-match event only after both assigned players are present. The sender must be
   * a current room participant, and the event is delivered only to the opponent. Payload
   * semantics remain opaque until authoritative combat validation is implemented.
   */
  relay(matchId: string, fromPlayerId: string, envelope: unknown): boolean {
    const room = this.rooms.get(matchId);
    if (!room || room.state !== "active" || !room.participants.has(fromPlayerId)) return false;
    for (const p of room.participants.values()) {
      if (p.playerId !== fromPlayerId) this.send(p.clientId, envelope);
    }
    return true;
  }

  isParticipant(matchId: string, playerId: string): boolean {
    return this.rooms.get(matchId)?.participants.has(playerId) ?? false;
  }

  recordResult(matchId: string, reporterId: string, winnerId: string): "pending" | "confirmed" | "conflict" | "invalid" {
    // Both the reporter and proposed winner must belong to the immutable assigned pair.
    // Rewards are not settled until every assigned player reports the same winner.
    const room = this.rooms.get(matchId);
    if (!room || !room.participants.has(reporterId) || !room.allowedPlayerIds.has(winnerId)) return "invalid";
    room.resultReports.set(reporterId, winnerId);
    if (room.resultReports.size < room.allowedPlayerIds.size) return "pending";
    return new Set(room.resultReports.values()).size === 1 ? "confirmed" : "conflict";
  }

  broadcast(matchId: string, envelope: unknown): void {
    const room = this.rooms.get(matchId);
    if (!room) return;
    for (const p of room.participants.values()) this.send(p.clientId, envelope);
  }

  finish(matchId: string): MatchRoom | undefined {
    const room = this.rooms.get(matchId);
    if (!room) return undefined;
    room.state = "finished";
    for (const p of room.participants.values()) this.playerRoom.delete(p.playerId);
    this.rooms.delete(matchId);
    logger.match.event("Match room finished", { matchId });
    return room;
  }

  /**
   * Detach a disconnected socket without immediately deleting the room. The hub uses the
   * returned match/player identity to start a reconnect grace timer. Keeping the room and
   * its allowed-player set makes a legitimate reconnect possible while still preventing a
   * third party from taking the vacant participant slot.
   */
  evictClient(clientId: string): EvictedParticipant | null {
    for (const room of this.rooms.values()) {
      const entry = [...room.participants.values()].find((p) => p.clientId === clientId);
      if (!entry) continue;
      const wasActive = room.state === "active";
      const opponentId = [...room.allowedPlayerIds].find((id) => id !== entry.playerId);
      room.participants.delete(entry.playerId);
      this.playerRoom.delete(entry.playerId);
      this.broadcast(room.matchId, {
        Type: "OpponentDisconnected",
        Payload: { MatchId: room.matchId, PlayerId: entry.playerId },
      });
      return { matchId: room.matchId, playerId: entry.playerId, opponentId, wasActive };
    }
    return null;
  }
}

export const roomManager = new RoomManager();
