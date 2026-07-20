import type { ClientEnvelope } from "../gameRooms/types";

export const PVP_FANOUT_REDIS_CHANNEL = "wf:pvp:fanout:v1";

export interface PvpFanoutNotice {
  version: 1;
  originId: string;
  targetPlayerId: string;
  matchId: string;
  envelope: ClientEnvelope;
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
): string {
  return JSON.stringify({ version: 1, originId, targetPlayerId, matchId, envelope });
}

export function parsePvpFanoutNotice(raw: string): PvpFanoutNotice | null {
  if (raw.length === 0 || raw.length > 32_768) return null;
  try {
    const value = JSON.parse(raw) as Partial<PvpFanoutNotice>;
    const payload = value.envelope?.Payload as { MatchId?: unknown; Opponent?: unknown } | undefined;
    const envelopeType = value.envelope?.Type;
    if (value.version !== 1
      || typeof value.originId !== "string" || value.originId.length === 0 || value.originId.length > 128
      || typeof value.targetPlayerId !== "string" || value.targetPlayerId.length === 0 || value.targetPlayerId.length > 128
      || typeof value.matchId !== "string" || value.matchId.length === 0 || value.matchId.length > 128
      || !value.envelope || typeof value.envelope !== "object"
      || (envelopeType !== "MatchFound" && envelopeType !== "MatchStart")
      || !payload || payload.MatchId !== value.matchId
      || (envelopeType === "MatchFound"
        && (typeof payload.Opponent !== "string" || payload.Opponent.length === 0 || payload.Opponent.length > 64))) return null;
    return value as PvpFanoutNotice;
  } catch {
    return null;
  }
}
