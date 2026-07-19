// Wire envelope for the WebSocket match relay (replaces the client's Photon room traffic).
// The client connects to /hub, identifies, then joins a match room; in-match turn/action
// messages are relayed to the opponent. Exact in-match payload schema is ⚠ RE-NEEDED
// (BACKEND.md §5, §3.2) — until the Photon RPC/event set is extracted, `MatchEvent.data`
// is passed through opaquely.

export interface ClientEnvelope {
  Type: string;
  Payload?: unknown;
}

export interface IdentifyPayload {
  PlayerId: string;
  Token: string;
}

export interface JoinMatchPayload {
  MatchId: string;
}

export interface MatchEventPayload {
  MatchId: string;
  /** Opaque in-match action/turn payload relayed verbatim to the opponent. */
  Event: string;
  Data?: unknown;
}

export interface MatchResultPayload {
  MatchId: string;
  WinnerId: string;
  /** Opaque per-side stats the server will later validate before granting rewards. */
  Stats?: unknown;
}

export type RoomState = "waiting" | "active" | "finished";
