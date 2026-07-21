import type { RoomState } from "./types";
import logger from "../utils/logger";

// In-memory registry for live PvP rooms. Persistent match ownership and rewards live in
// matchService; this class owns only the socket-facing state: which of the two assigned
// players are connected, whether both have joined, event relay, and a local result-report mirror.
// It is intentionally process-local for now. Horizontal scaling will require a shared room
// coordinator (for example Redis pub/sub) so players connected to different nodes can meet.

export type LocalMatchReportStatus = "pending" | "confirmed" | "conflict" | "invalid";
export type DurableMatchReportStatus = LocalMatchReportStatus | "finished";

/**
 * Resolve the live-room observation against the durable result-report decision.
 *
 * The local map exists only to reject a socket that is not in this process's current room. It can
 * lag MongoDB when two socket handlers report concurrently, so local pending/conflict must never
 * override a terminal or newer durable decision. Invalid local membership still fails before the
 * database result is accepted because that socket has no authority to report through this room.
 */
export function resolveMatchReportStatus(
  local: LocalMatchReportStatus,
  durable: DurableMatchReportStatus,
  allowDurableTerminalReplay = false,
): DurableMatchReportStatus {
  if (local !== "invalid") return durable;
  // A finished/cancelled room is deliberately absent from the local registry after cleanup. An
  // authenticated assigned participant may still recover that lost terminal response, but this
  // exception must never let a non-member bypass an active room with pending/confirmed state.
  return allowDurableTerminalReplay && (durable === "finished" || durable === "conflict")
    ? durable
    : "invalid";
}

export interface Participant {
  /** Authenticated database player ID used as the stable room key. */
  playerId: string;
  /** Current socket ID; replaced when the same player reconnects. */
  clientId: string;
}

export interface MatchRoom {
  /** Durable match identifier created by matchService before room join. */
  matchId: string;
  /** Transient socket lifecycle; reward settlement lives outside this class. */
  state: RoomState;
  /** Currently connected assigned players, keyed by stable player ID. */
  participants: Map<string, Participant>; // keyed by playerId
  /** Immutable pair copied from the persistent match and used as the admission allowlist. */
  allowedPlayerIds: Set<string>;
  /** Best-effort local mirror; MongoDB remains the sole result-consensus authority. */
  resultReports: Map<string, string>; // reporter playerId -> winner playerId
  /** CardPlayed sequences already delivered to the opponent on this process-local room. */
  deliveredCardSequences: Map<string, Set<number>>;
  /** Local creation time used by diagnostics; it is not a durable match timestamp. */
  createdAt: number;
}

export interface EvictedParticipant {
  /** Room whose socket disappeared. */
  matchId: string;
  /** Authenticated player associated with the disconnected socket. */
  playerId: string;
  /** Assigned peer, if present, used by timeout/forfeit resolution. */
  opponentId?: string;
  /** Distinguishes an active-match disconnect from leaving a not-yet-full room. */
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
    const suppliedAllowlist = new Set(allowedPlayerIds);
    if (allowedPlayerIds.length !== 2
      || suppliedAllowlist.size !== 2
      || !suppliedAllowlist.has(playerId)) return null;
    const currentMatchId = this.playerRoom.get(playerId);
    // The authenticated socket identity can own only one process-local room. Without this check a
    // stale/duplicate JoinMatch could leave the same client in two room participant maps; close
    // cleanup would evict only the first and the ghost room could continue relaying opaque events.
    if (currentMatchId !== undefined && currentMatchId !== matchId) return null;
    let room = this.rooms.get(matchId);
    if (!room) {
      room = {
        matchId,
        state: "waiting",
        participants: new Map(),
        allowedPlayerIds: new Set(allowedPlayerIds),
        resultReports: new Map(),
        deliveredCardSequences: new Map(),
        createdAt: Date.now(),
      };
      this.rooms.set(matchId, room);
    }
    // Every join reloads the durable match allowlist. Require it to reproduce the room's immutable
    // pair exactly rather than accepting one overlapping player from a contradictory snapshot.
    if (room.allowedPlayerIds.size !== suppliedAllowlist.size
      || [...suppliedAllowlist].some((id) => !room!.allowedPlayerIds.has(id))
      || !room.allowedPlayerIds.has(playerId)) return null;
    const existing = room.participants.get(playerId);
    if (!existing && room.participants.size >= 2) {
      return null; // room full with two different players
    }
    room.participants.set(playerId, { playerId, clientId });
    this.playerRoom.set(playerId, matchId);

    if (room.participants.size === room.allowedPlayerIds.size && room.state === "waiting") {
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
    if (!room
      || room.state !== "active"
      || room.participants.size !== room.allowedPlayerIds.size
      || !room.participants.has(fromPlayerId)) return false;
    for (const p of room.participants.values()) {
      if (p.playerId !== fromPlayerId) this.send(p.clientId, envelope);
    }
    return true;
  }

  /**
   * Relay one durably accepted CardPlayed sequence at most once per live room.
   *
   * Durable match evidence and transient socket delivery have different failure boundaries. If
   * MongoDB commits immediately before an opponent disconnect, the sender can retry after that
   * opponent rejoins and this method delivers the still-undelivered sequence. If only the sender's
   * acknowledgement was lost, the local delivered set suppresses a second opponent effect. Active
   * matches are cancelled on process restart, so process-local delivery memory cannot be mistaken
   * for a resumable cross-restart guarantee.
   */
  relayCardEvent(
    matchId: string,
    fromPlayerId: string,
    sequence: number,
    envelope: unknown,
  ): "delivered" | "replayed" | "invalid" {
    const room = this.rooms.get(matchId);
    if (
      !room
      || room.state !== "active"
      || room.participants.size !== room.allowedPlayerIds.size
      || !room.participants.has(fromPlayerId)
    ) return "invalid";
    const delivered = room.deliveredCardSequences.get(fromPlayerId) ?? new Set<number>();
    if (delivered.has(sequence)) return "replayed";
    for (const participant of room.participants.values()) {
      if (participant.playerId !== fromPlayerId) this.send(participant.clientId, envelope);
    }
    delivered.add(sequence);
    room.deliveredCardSequences.set(fromPlayerId, delivered);
    return "delivered";
  }

  isParticipant(matchId: string, playerId: string): boolean {
    return this.rooms.get(matchId)?.participants.has(playerId) ?? false;
  }

  recordResult(matchId: string, reporterId: string, winnerId: string): LocalMatchReportStatus {
    // Both the reporter and proposed winner must belong to the immutable assigned pair.
    // This transient mirror never authorizes rewards; durable reports decide consensus.
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
    for (const p of room.participants.values()) {
      if (this.playerRoom.get(p.playerId) === matchId) this.playerRoom.delete(p.playerId);
    }
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
      if (this.playerRoom.get(entry.playerId) === room.matchId) this.playerRoom.delete(entry.playerId);
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
