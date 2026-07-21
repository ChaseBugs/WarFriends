import assert from "node:assert/strict";
import test from "node:test";
import { ServerMetrics } from "../services/metricsService";

test("metrics expose bounded aggregate labels without request paths or identities", () => {
  const metrics = new ServerMetrics();
  metrics.beginHttp();
  metrics.finishHttp("POST", 201, 250);
  metrics.beginHttp();
  metrics.finishHttp("UNUSUAL", 429, 50);
  metrics.websocketConnected();
  metrics.websocketMessage();
  metrics.websocketRejectedByRateLimit();
  metrics.firebasePushAttempt("delivered");
  metrics.firebasePushAttempt("transient");
  metrics.firebasePushSuppressed("not_eligible");
  metrics.firebasePushRecoveredIntents(2);
  metrics.firebasePushSweepFailed();
  const output = metrics.render(true);
  assert.match(output, /warfriends_http_requests_total\{method="POST",status_class="2xx"\} 1/u);
  assert.match(output, /warfriends_http_requests_total\{method="OTHER",status_class="4xx"\} 1/u);
  assert.match(output, /warfriends_http_request_duration_seconds_count 2/u);
  assert.match(output, /warfriends_websocket_connections 1/u);
  assert.match(output, /warfriends_redis_available 1/u);
  assert.match(output, /warfriends_firebase_push_attempts_total\{outcome="delivered"\} 1/u);
  assert.match(output, /warfriends_firebase_push_attempts_total\{outcome="transient"\} 1/u);
  assert.match(output, /warfriends_firebase_push_suppressed_total\{reason="not_eligible"\} 1/u);
  assert.match(output, /warfriends_firebase_push_recovered_total 2/u);
  assert.match(output, /warfriends_firebase_push_sweep_failures_total 1/u);
  assert.equal(output.includes("/player/"), false);
});

test("metrics gauges never become negative", () => {
  const metrics = new ServerMetrics();
  metrics.websocketDisconnected();
  metrics.finishHttp("GET", 500, -10);
  const output = metrics.render(false);
  assert.match(output, /warfriends_http_requests_in_flight 0/u);
  assert.match(output, /warfriends_websocket_connections 0/u);
  assert.match(output, /warfriends_redis_available 0/u);
});

test("Firebase metric counts reject unsafe recovered-intent values", () => {
  const metrics = new ServerMetrics();
  assert.throws(() => metrics.firebasePushRecoveredIntents(-1), /recovery count is invalid/);
  assert.throws(() => metrics.firebasePushRecoveredIntents(Number.NaN), /recovery count is invalid/);
});
