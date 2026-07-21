import { config } from "../config";

// Node clamps larger setTimeout delays to one millisecond. Keeping seconds below this quotient
// prevents an apparently long multiplayer grace period from firing immediately at runtime.
const MAX_NODE_TIMEOUT_MILLISECONDS = 2_147_483_647;
const MAX_NODE_TIMEOUT_SECONDS = Math.floor(MAX_NODE_TIMEOUT_MILLISECONDS / 1_000);
const MAX_RESULT_CONSENSUS_MILLISECONDS = 15_000;

function exactTimeout(
  value: number,
  label: string,
  minimum: number,
  maximum: number,
): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Multiplayer ${label} timeout policy is invalid.`);
  }
  return value;
}

export interface MultiplayerTimeoutPolicy {
  readonly matchmakingSeconds: number;
  readonly joinSeconds: number;
  readonly disconnectGraceSeconds: number;
  readonly resultConsensusMilliseconds: number;
}

/**
 * Resolve every wall-clock boundary that participates in one reconstructed PvP lifecycle.
 *
 * Queue expiry is enforced by both local timers and Redis cleanup; disconnects can be resolved by
 * local rooms or distributed presence; and REST consensus bridges the same terminal match. Reading
 * mutable config separately at those points could give one match contradictory deadlines even when
 * each value is individually valid. Validate and freeze the complete process policy at startup.
 */
function exactMultiplayerTimeoutPolicy(policy: MultiplayerTimeoutPolicy): MultiplayerTimeoutPolicy {
  return {
    matchmakingSeconds: exactTimeout(
      policy.matchmakingSeconds,
      "matchmaking",
      1,
      MAX_NODE_TIMEOUT_SECONDS,
    ),
    joinSeconds: exactTimeout(policy.joinSeconds, "join", 1, MAX_NODE_TIMEOUT_SECONDS),
    disconnectGraceSeconds: exactTimeout(
      policy.disconnectGraceSeconds,
      "disconnect-grace",
      1,
      MAX_NODE_TIMEOUT_SECONDS,
    ),
    resultConsensusMilliseconds: exactTimeout(
      policy.resultConsensusMilliseconds,
      "result-consensus",
      0,
      MAX_RESULT_CONSENSUS_MILLISECONDS,
    ),
  };
}

const CONFIGURED_MULTIPLAYER_TIMEOUT_POLICY = Object.freeze(exactMultiplayerTimeoutPolicy({
  matchmakingSeconds: config.matchmakingTimeout,
  joinSeconds: config.matchJoinTimeoutSeconds,
  disconnectGraceSeconds: config.matchDisconnectGraceSeconds,
  resultConsensusMilliseconds: config.matchResultConsensusWaitMilliseconds,
}));

export function multiplayerTimeoutPolicy(
  policy?: MultiplayerTimeoutPolicy,
): MultiplayerTimeoutPolicy {
  return policy === undefined
    ? CONFIGURED_MULTIPLAYER_TIMEOUT_POLICY
    : exactMultiplayerTimeoutPolicy(policy);
}

/** Queue search duration shared by the local timer and Redis stale-entry cutoff. */
export function matchmakingTimeoutSeconds(value?: number): number {
  return value === undefined
    ? CONFIGURED_MULTIPLAYER_TIMEOUT_POLICY.matchmakingSeconds
    : exactTimeout(value, "matchmaking", 1, MAX_NODE_TIMEOUT_SECONDS);
}

/** Maximum delay between durable pairing and both assigned players activating the room. */
export function matchJoinTimeoutSeconds(value?: number): number {
  return value === undefined
    ? CONFIGURED_MULTIPLAYER_TIMEOUT_POLICY.joinSeconds
    : exactTimeout(value, "join", 1, MAX_NODE_TIMEOUT_SECONDS);
}

/** Reconnect grace used identically by local-room and distributed-presence resolution. */
export function matchDisconnectGraceSeconds(value?: number): number {
  return value === undefined
    ? CONFIGURED_MULTIPLAYER_TIMEOUT_POLICY.disconnectGraceSeconds
    : exactTimeout(value, "disconnect-grace", 1, MAX_NODE_TIMEOUT_SECONDS);
}

/**
 * Read-only bridge for two already-in-flight REST result reports.
 *
 * Zero deliberately disables waiting. The existing 15-second ceiling prevents one pending client
 * request from consuming an unbounded HTTP worker, but invalid deployment values now fail closed
 * instead of being floored, clamped, or replaced by a hidden five-second default.
 */
export function matchResultConsensusTimeoutMilliseconds(
  value?: number,
): number {
  return value === undefined
    ? CONFIGURED_MULTIPLAYER_TIMEOUT_POLICY.resultConsensusMilliseconds
    : exactTimeout(value, "result-consensus", 0, MAX_RESULT_CONSENSUS_MILLISECONDS);
}
