// Wire contracts for the WebSocket match relay that currently replaces Photon room traffic.
// A client identifies before using match operations, then joins only the MatchId assigned by
// matchmaking. The exact recovered in-match action/RPC schema is still incomplete, so Event
// and Data are relayed opaquely and must not yet be treated as authoritative combat input.

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
  /** Authenticated sender's own consumed War Card IDs. */
  UsedCards?: string[];
  /** Opaque per-side stats the server will later validate before granting rewards. */
  Stats?: unknown;
}

export type RoomState = "waiting" | "active" | "finished";
