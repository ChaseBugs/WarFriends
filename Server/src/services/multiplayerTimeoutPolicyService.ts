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

/** Queue search duration shared by the local timer and Redis stale-entry cutoff. */
export function matchmakingTimeoutSeconds(value = config.matchmakingTimeout): number {
  return exactTimeout(value, "matchmaking", 1, MAX_NODE_TIMEOUT_SECONDS);
}

/** Maximum delay between durable pairing and both assigned players activating the room. */
export function matchJoinTimeoutSeconds(value = config.matchJoinTimeoutSeconds): number {
  return exactTimeout(value, "join", 1, MAX_NODE_TIMEOUT_SECONDS);
}

/** Reconnect grace used identically by local-room and distributed-presence resolution. */
export function matchDisconnectGraceSeconds(value = config.matchDisconnectGraceSeconds): number {
  return exactTimeout(value, "disconnect-grace", 1, MAX_NODE_TIMEOUT_SECONDS);
}

/**
 * Read-only bridge for two already-in-flight REST result reports.
 *
 * Zero deliberately disables waiting. The existing 15-second ceiling prevents one pending client
 * request from consuming an unbounded HTTP worker, but invalid deployment values now fail closed
 * instead of being floored, clamped, or replaced by a hidden five-second default.
 */
export function matchResultConsensusTimeoutMilliseconds(
  value = config.matchResultConsensusWaitMilliseconds,
): number {
  return exactTimeout(value, "result-consensus", 0, MAX_RESULT_CONSENSUS_MILLISECONDS);
}
