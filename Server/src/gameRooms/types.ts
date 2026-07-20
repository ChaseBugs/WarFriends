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

/** Sender-owned retry identity and text for the persistent Squad Chat replacement. */
export interface SendSquadChatPayload {
  ClientMessageId: string;
  Text: string;
}

/** Optional cursor for requesting the next older persistent Squad Chat page. */
export interface SquadChatHistoryPayload {
  BeforeCursor?: string;
}

export interface JoinMatchPayload {
  MatchId: string;
}

export interface MatchEventPayload {
  MatchId: string;
  /** `CardPlayed` has a validated payload; other recovered events remain opaque relay data. */
  Event: string;
  Data?: unknown;
}

/** Replacement-client evidence for one inventory-consuming War Card activation. */
export interface CardPlayedEventData {
  /** Zero-based per-player sequence; retries must repeat the same sequence and identity. */
  Sequence: number;
  CardId: string;
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
