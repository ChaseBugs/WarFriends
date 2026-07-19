import type { RoomState } from "./types";
import logger from "../utils/logger";

// In-memory registry of active PvP match rooms. A room pairs exactly two players and
// relays match traffic between them. Result recording/rewards are handled by the hub via
// the onResult callback (wired to matchService later). Single-process for now; a
// Redis-backed variant can shard this across hub instances (see redis.ts pub/sub).

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

  /** Join (creating on first arrival). Returns the room, or null if it is already full. */
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

  /** Relay an in-match event to the OTHER participant. */
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

  /** Remove a disconnected client; notify the opponent so the match can resolve. */
  evictClient(clientId: string): void {
    for (const room of this.rooms.values()) {
      const entry = [...room.participants.values()].find((p) => p.clientId === clientId);
      if (!entry) continue;
      room.participants.delete(entry.playerId);
      this.playerRoom.delete(entry.playerId);
      this.broadcast(room.matchId, { Type: "OpponentLeft", Payload: { PlayerId: entry.playerId } });
      if (room.participants.size === 0) this.finish(room.matchId);
      return;
    }
  }
}

export const roomManager = new RoomManager();
