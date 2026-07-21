const startedAtSeconds = Math.floor(Date.now() / 1_000);

type HttpMethod = "GET" | "POST" | "PUT" | "PATCH" | "DELETE" | "OPTIONS" | "OTHER";
type StatusClass = "1xx" | "2xx" | "3xx" | "4xx" | "5xx";
export type FirebasePushAttemptOutcome = "delivered" | "invalid_token" | "transient" | "configuration";
export type FirebasePushSuppressionReason = "not_eligible" | "invalid_token";

const FIREBASE_PUSH_ATTEMPT_OUTCOMES: readonly FirebasePushAttemptOutcome[] = [
  "delivered", "invalid_token", "transient", "configuration",
];
const FIREBASE_PUSH_SUPPRESSION_REASONS: readonly FirebasePushSuppressionReason[] = [
  "not_eligible", "invalid_token",
];

function boundedMethod(method: string): HttpMethod {
  const normalized = method.toUpperCase();
  return ["GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS"].includes(normalized)
    ? normalized as HttpMethod
    : "OTHER";
}

function statusClass(status: number): StatusClass {
  const first = Math.min(5, Math.max(1, Math.floor(status / 100)));
  return `${first}xx` as StatusClass;
}

/**
 * Process-local Prometheus counters with a deliberately fixed label domain.
 *
 * These metrics diagnose each backend replica; the collector aggregates replicas. Paths, action
 * IDs, player IDs, addresses, tokens, and arbitrary message types are intentionally absent so
 * attacker-controlled input cannot create unbounded memory/cardinality or expose user data.
 */
export class ServerMetrics {
  private readonly httpTotals = new Map<string, number>();
  private httpDurationSeconds = 0;
  private httpDurationCount = 0;
  private httpInFlight = 0;
  private websocketConnections = 0;
  private websocketMessages = 0;
  private websocketRateLimited = 0;
  private readonly firebasePushAttempts = new Map<FirebasePushAttemptOutcome, number>(
    FIREBASE_PUSH_ATTEMPT_OUTCOMES.map((outcome) => [outcome, 0]),
  );
  private readonly firebasePushSuppressions = new Map<FirebasePushSuppressionReason, number>(
    FIREBASE_PUSH_SUPPRESSION_REASONS.map((reason) => [reason, 0]),
  );
  private firebasePushRecovered = 0;
  private firebasePushSweepFailures = 0;

  beginHttp(): void {
    this.httpInFlight += 1;
  }

  finishHttp(method: string, status: number, durationMs: number): void {
    this.httpInFlight = Math.max(0, this.httpInFlight - 1);
    const key = `${boundedMethod(method)}:${statusClass(status)}`;
    this.httpTotals.set(key, (this.httpTotals.get(key) ?? 0) + 1);
    this.httpDurationSeconds += Math.max(0, durationMs) / 1_000;
    this.httpDurationCount += 1;
  }

  websocketConnected(): void {
    this.websocketConnections += 1;
  }

  websocketDisconnected(): void {
    this.websocketConnections = Math.max(0, this.websocketConnections - 1);
  }

  websocketMessage(): void {
    this.websocketMessages += 1;
  }

  websocketRejectedByRateLimit(): void {
    this.websocketRateLimited += 1;
  }

  firebasePushAttempt(outcome: FirebasePushAttemptOutcome): void {
    this.firebasePushAttempts.set(outcome, (this.firebasePushAttempts.get(outcome) ?? 0) + 1);
  }

  firebasePushSuppressed(reason: FirebasePushSuppressionReason): void {
    this.firebasePushSuppressions.set(reason, (this.firebasePushSuppressions.get(reason) ?? 0) + 1);
  }

  firebasePushRecoveredIntents(count: number): void {
    if (!Number.isSafeInteger(count) || count < 0) throw new Error("Firebase push recovery count is invalid.");
    this.firebasePushRecovered += count;
  }

  firebasePushSweepFailed(): void {
    this.firebasePushSweepFailures += 1;
  }

  render(redisAvailable: boolean): string {
    const lines = [
      "# HELP warfriends_process_start_time_seconds Process start time.",
      "# TYPE warfriends_process_start_time_seconds gauge",
      `warfriends_process_start_time_seconds ${startedAtSeconds}`,
      "# HELP warfriends_http_requests_in_flight Requests currently executing.",
      "# TYPE warfriends_http_requests_in_flight gauge",
      `warfriends_http_requests_in_flight ${this.httpInFlight}`,
      "# HELP warfriends_http_request_duration_seconds Total and count of HTTP request duration.",
      "# TYPE warfriends_http_request_duration_seconds summary",
      `warfriends_http_request_duration_seconds_sum ${this.httpDurationSeconds.toFixed(6)}`,
      `warfriends_http_request_duration_seconds_count ${this.httpDurationCount}`,
      "# HELP warfriends_http_requests_total Completed HTTP requests by bounded method and status class.",
      "# TYPE warfriends_http_requests_total counter",
    ];
    for (const [key, value] of [...this.httpTotals].sort(([a], [b]) => a.localeCompare(b))) {
      const [method, status] = key.split(":");
      lines.push(`warfriends_http_requests_total{method="${method}",status_class="${status}"} ${value}`);
    }
    lines.push(
      "# HELP warfriends_websocket_connections Current WebSocket connections.",
      "# TYPE warfriends_websocket_connections gauge",
      `warfriends_websocket_connections ${this.websocketConnections}`,
      "# HELP warfriends_websocket_messages_total Accepted WebSocket frames entering rate evaluation.",
      "# TYPE warfriends_websocket_messages_total counter",
      `warfriends_websocket_messages_total ${this.websocketMessages}`,
      "# HELP warfriends_websocket_rate_limited_total WebSocket frames rejected by rate policy.",
      "# TYPE warfriends_websocket_rate_limited_total counter",
      `warfriends_websocket_rate_limited_total ${this.websocketRateLimited}`,
      "# HELP warfriends_firebase_push_attempts_total Firebase provider attempts by bounded outcome.",
      "# TYPE warfriends_firebase_push_attempts_total counter",
      ...FIREBASE_PUSH_ATTEMPT_OUTCOMES.map((outcome) =>
        `warfriends_firebase_push_attempts_total{outcome="${outcome}"} ${this.firebasePushAttempts.get(outcome) ?? 0}`),
      "# HELP warfriends_firebase_push_suppressed_total Durable push intents suppressed by bounded reason.",
      "# TYPE warfriends_firebase_push_suppressed_total counter",
      ...FIREBASE_PUSH_SUPPRESSION_REASONS.map((reason) =>
        `warfriends_firebase_push_suppressed_total{reason="${reason}"} ${this.firebasePushSuppressions.get(reason) ?? 0}`),
      "# HELP warfriends_firebase_push_recovered_total Missing post-commit delivery intents recovered from inbox authority.",
      "# TYPE warfriends_firebase_push_recovered_total counter",
      `warfriends_firebase_push_recovered_total ${this.firebasePushRecovered}`,
      "# HELP warfriends_firebase_push_sweep_failures_total Leased Firebase delivery sweeps that failed.",
      "# TYPE warfriends_firebase_push_sweep_failures_total counter",
      `warfriends_firebase_push_sweep_failures_total ${this.firebasePushSweepFailures}`,
      "# HELP warfriends_redis_available Whether Redis is currently available to this process.",
      "# TYPE warfriends_redis_available gauge",
      `warfriends_redis_available ${redisAvailable ? 1 : 0}`,
      "# HELP warfriends_process_resident_memory_bytes Resident process memory.",
      "# TYPE warfriends_process_resident_memory_bytes gauge",
      `warfriends_process_resident_memory_bytes ${process.memoryUsage().rss}`,
    );
    return `${lines.join("\n")}\n`;
  }
}

export const serverMetrics = new ServerMetrics();
