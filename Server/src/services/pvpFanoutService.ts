import type { ClientEnvelope } from "../gameRooms/types";
import { MAX_PVP_CARDS_PER_MATCH } from "./cardInventoryService";
import type { MatchDoc } from "./matchService";

export const PVP_FANOUT_REDIS_CHANNEL = "wf:pvp:fanout:v1";

export interface PvpFanoutNotice {
  version: 1;
  originId: string;
  targetPlayerId: string;
  /** Authenticated event sender; absent for server-generated lifecycle notifications. */
  sourcePlayerId?: string;
  matchId: string;
  envelope: ClientEnvelope;
}

export type PvpFanoutMatchAuthority = Pick<MatchDoc,
  | "matchId"
  | "players"
  | "state"
  | "joinedPlayerIds"
  | "roomStartedAt"
  | "disconnectedAt"
  | "winnerId"
  | "resultReports"
  | "relayedCardPlays"
  | "cancelReason"
>;

function plainRecord(value: unknown): value is Record<string, unknown> {
  return Boolean(value) && typeof value === "object" && !Array.isArray(value);
}

function exactKeys(value: Record<string, unknown>, expected: readonly string[]): boolean {
  const keys = Object.keys(value);
  return keys.length === expected.length && keys.every((key) => expected.includes(key));
}

function boundedText(value: unknown, maximum: number): value is string {
  return typeof value === "string"
    && value.length > 0
    && value.length <= maximum
    && !/\p{Cc}/u.test(value);
}

function validEnvelopeShape(envelope: unknown, matchId: string, sourcePlayerId?: string): envelope is ClientEnvelope {
  if (!plainRecord(envelope) || !exactKeys(envelope, ["Type", "Payload"]) || !plainRecord(envelope.Payload)) {
    return false;
  }
  const type = envelope.Type;
  const payload = envelope.Payload;
  if (payload.MatchId !== matchId) return false;

  switch (type) {
    case "MatchFound":
      return sourcePlayerId === undefined
        && exactKeys(payload, ["MatchId", "Opponent"])
        && boundedText(payload.Opponent, 64);
    case "MatchStart":
      return sourcePlayerId === undefined && exactKeys(payload, ["MatchId"]);
    case "MatchEvent": {
      if (!boundedText(sourcePlayerId, 128)
        || !boundedText(payload.Event, 128)
        || !(exactKeys(payload, ["MatchId", "Event"])
          || exactKeys(payload, ["MatchId", "Event", "Data"]))) return false;
      if (payload.Event !== "CardPlayed") return true;
      if (!plainRecord(payload.Data)
        || !exactKeys(payload.Data, ["Sequence", "CardId"])
        || !Number.isInteger(payload.Data.Sequence)
        || Number(payload.Data.Sequence) < 0
        || Number(payload.Data.Sequence) >= MAX_PVP_CARDS_PER_MATCH
        || !boundedText(payload.Data.CardId, 256)) return false;
      return true;
    }
    case "MatchEnded":
      return sourcePlayerId === undefined
        && (exactKeys(payload, ["MatchId", "WinnerId"])
          || exactKeys(payload, ["MatchId", "Reason"])
          || exactKeys(payload, ["MatchId", "WinnerId", "Reason"]))
        && (payload.WinnerId === undefined || boundedText(payload.WinnerId, 128))
        && (payload.Reason === undefined || boundedText(payload.Reason, 64));
    case "MatchError":
      return sourcePlayerId === undefined
        && exactKeys(payload, ["MatchId", "Reason"])
        && boundedText(payload.Reason, 64);
    case "OpponentDisconnected":
    case "OpponentReconnected":
      return sourcePlayerId === undefined
        && exactKeys(payload, ["MatchId", "PlayerId"])
        && boundedText(payload.PlayerId, 128);
    default:
      return false;
  }
}

/**
 * Redis carries only a bounded delivery instruction. Receiving nodes re-read the durable match and
 * prove target participation before touching a socket, so a forged/stale pub/sub frame cannot add
 * a player to a match or grant rewards.
 */
export function buildPvpFanoutNotice(
  originId: string,
  targetPlayerId: string,
  matchId: string,
  envelope: ClientEnvelope,
  sourcePlayerId?: string,
): string {
  return JSON.stringify({
    version: 1,
    originId,
    targetPlayerId,
    ...(sourcePlayerId ? { sourcePlayerId } : {}),
    matchId,
    envelope,
  });
}

export function parsePvpFanoutNotice(raw: string): PvpFanoutNotice | null {
  if (raw.length === 0 || raw.length > 32_768) return null;
  try {
    const value = JSON.parse(raw) as unknown;
    if (!plainRecord(value)
      || !(exactKeys(value, ["version", "originId", "targetPlayerId", "matchId", "envelope"])
        || exactKeys(value, ["version", "originId", "targetPlayerId", "sourcePlayerId", "matchId", "envelope"]))
      || value.version !== 1
      || !boundedText(value.originId, 128)
      || !boundedText(value.targetPlayerId, 128)
      || !boundedText(value.matchId, 128)
      || (value.sourcePlayerId !== undefined && !boundedText(value.sourcePlayerId, 128))
      || !validEnvelopeShape(value.envelope, value.matchId, value.sourcePlayerId as string | undefined)) return null;
    return value as unknown as PvpFanoutNotice;
  } catch {
    return null;
  }
}

/**
 * Bind every client-visible Redis instruction to the complete match already validated by getMatch.
 * Redis remains transport only: it may wake another node, but it cannot choose an opponent name,
 * terminal winner/reason, participant presence, or inventory-consuming CardPlayed identity.
 */
export function pvpFanoutMatchesDurableAuthority(
  notice: PvpFanoutNotice,
  match: PvpFanoutMatchAuthority,
): boolean {
  if (notice.matchId !== match.matchId) return false;
  const target = match.players.find((participant) => participant.playerId === notice.targetPlayerId);
  if (!target) return false;
  const payload = notice.envelope.Payload as Record<string, unknown>;
  const type = notice.envelope.Type;

  if (type === "MatchFound") {
    const opponent = match.players.find((participant) => participant.playerId !== target.playerId);
    return match.state === "active" && Boolean(opponent) && payload.Opponent === opponent?.name;
  }

  const joined = new Set(match.joinedPlayerIds ?? []);
  if (type === "MatchStart") {
    return match.state === "active"
      && match.roomStartedAt instanceof Date
      && match.players.every((participant) => joined.has(participant.playerId));
  }
  if (type === "MatchEvent") {
    const source = notice.sourcePlayerId;
    if (match.state !== "active"
      || !(match.roomStartedAt instanceof Date)
      || !source
      || source === target.playerId
      || !match.players.some((participant) => participant.playerId === source)
      || !joined.has(source)
      || !joined.has(target.playerId)) return false;
    if (payload.Event !== "CardPlayed") return true;
    const data = payload.Data as { Sequence: number; CardId: string };
    return match.relayedCardPlays?.[source]?.[data.Sequence] === data.CardId;
  }
  if (type === "MatchEnded") {
    if (match.state === "finished") {
      const reportCount = Object.keys(match.resultReports ?? {}).length;
      const expectedReason = reportCount < match.players.length ? "OpponentForfeit" : undefined;
      return payload.WinnerId === match.winnerId && payload.Reason === expectedReason;
    }
    if (match.state !== "cancelled" || payload.WinnerId !== undefined) return false;
    const expectedReason = match.cancelReason === "join_timeout"
      ? "JoinTimeout"
      : match.cancelReason === "both_players_disconnected"
        ? "BothPlayersDisconnected"
        : undefined;
    return expectedReason !== undefined && payload.Reason === expectedReason;
  }
  if (type === "MatchError") {
    if (match.state !== "cancelled") return false;
    const expectedReason = match.cancelReason === "result_conflict"
      ? "ResultConflict"
      : match.cancelReason === "match_found_delivery_failed"
        ? "DeliveryFailed"
        : undefined;
    return expectedReason !== undefined && payload.Reason === expectedReason;
  }
  if (type === "OpponentDisconnected" || type === "OpponentReconnected") {
    const playerId = payload.PlayerId;
    if (match.state !== "active"
      || !match.players.some((participant) => participant.playerId === playerId)
      || playerId === target.playerId) return false;
    const disconnected = typeof playerId === "string" && match.disconnectedAt?.[playerId] instanceof Date;
    return type === "OpponentDisconnected" ? disconnected : !disconnected;
  }
  return false;
}
