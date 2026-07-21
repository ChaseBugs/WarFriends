import { config } from "../config";

/**
 * Validate one deployment-owned public-traffic limit without changing operator intent.
 *
 * These values size both process-local protection and Redis-backed enforcement. Flooring a
 * fraction, clamping an out-of-range value, or substituting a default for `NaN` would make nodes
 * enforce a policy different from the reviewed environment and can create inconsistent limits
 * during a rolling deployment.
 */
export function exactTrafficPolicyInteger(
  value: number,
  label: string,
  minimum: number,
  maximum: number,
): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Traffic ${label} policy is invalid.`);
  }
  return value;
}

export interface TrafficPolicy {
  readonly httpRequestCapacity: number;
  readonly httpWindowSeconds: number;
  readonly httpMemoryEntryCap: number;
  readonly webSocketPayloadBytes: number;
  readonly webSocketMessageCapacity: number;
  readonly webSocketWindowSeconds: number;
  readonly webSocketViolationLimit: number;
}

function exactTrafficPolicy(policy: TrafficPolicy): TrafficPolicy {
  return {
    httpRequestCapacity: exactTrafficPolicyInteger(
      policy.httpRequestCapacity, "HTTP request-capacity", 1, 100_000,
    ),
    httpWindowSeconds: exactTrafficPolicyInteger(
      policy.httpWindowSeconds, "HTTP window-seconds", 1, 86_400,
    ),
    httpMemoryEntryCap: exactTrafficPolicyInteger(
      policy.httpMemoryEntryCap, "HTTP memory-entry-cap", 100, 1_000_000,
    ),
    webSocketPayloadBytes: exactTrafficPolicyInteger(
      policy.webSocketPayloadBytes, "WebSocket payload-byte-limit", 1_024, 1_048_576,
    ),
    webSocketMessageCapacity: exactTrafficPolicyInteger(
      policy.webSocketMessageCapacity, "WebSocket message-capacity", 1, 100_000,
    ),
    webSocketWindowSeconds: exactTrafficPolicyInteger(
      policy.webSocketWindowSeconds, "WebSocket window-seconds", 1, 86_400,
    ),
    webSocketViolationLimit: exactTrafficPolicyInteger(
      policy.webSocketViolationLimit, "WebSocket violation-limit", 1, 100,
    ),
  };
}

// Local token buckets, Redis token buckets, parser allocation, and disconnect tolerance are one
// public-traffic boundary. Freeze the entire set before listeners start so concurrent paths cannot
// enforce independently re-read process configuration.
const CONFIGURED_TRAFFIC_POLICY = Object.freeze(exactTrafficPolicy({
  httpRequestCapacity: config.httpRateLimitMaxRequests,
  httpWindowSeconds: config.httpRateLimitWindowSeconds,
  httpMemoryEntryCap: config.httpRateLimitMaxEntries,
  webSocketPayloadBytes: config.websocketMaxPayloadBytes,
  webSocketMessageCapacity: config.websocketRateLimitMessages,
  webSocketWindowSeconds: config.websocketRateLimitWindowSeconds,
  webSocketViolationLimit: config.websocketRateLimitMaxViolations,
}));

export function trafficPolicy(policy?: TrafficPolicy): TrafficPolicy {
  return policy === undefined ? CONFIGURED_TRAFFIC_POLICY : exactTrafficPolicy(policy);
}
