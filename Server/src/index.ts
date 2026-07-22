import cors from "cors";
import compression from "compression";
import express, { type NextFunction, type Request, type Response } from "express";
import { createServer } from "http";
import { randomUUID } from "crypto";
import { apiRouter } from "./routes";
import { config } from "./config";
import { connectMongo, disconnectMongo } from "./db";
import { connectRedis, disconnectRedis, isRedisAvailable, isRedisEnabled } from "./redis";
import { createGameHub, hubInstanceId } from "./gameHub";
import logger from "./utils/logger";
import { recoverInterruptedMatches } from "./services/matchService";
import { createHttpRateLimitMiddleware } from "./services/httpRateLimitService";
import { runDatabaseMigrations } from "./services/databaseMigrationService";
import {
  isPvpCoordinatorAlive,
  startPvpCoordinatorHeartbeat,
  type PvpCoordinatorHeartbeat,
} from "./services/pvpCoordinatorService";
import { serverMetrics } from "./services/metricsService";
import { requireAdmin } from "./services/adminAuthService";
import { runWithRequestContext } from "./services/requestContextService";
import { startPlayerLeagueSettlementScheduler } from "./services/playerLeagueSchedulerService";
import { startGooglePlaySubscriptionRevalidationScheduler } from "./services/googlePlaySubscriptionRevalidationService";
import { initializeRemoteConfiguration } from "./services/remoteConfigurationService";
import { startGooglePlayVoidedPurchaseScheduler } from "./services/googlePlayVoidedPurchaseService";
import { startSquadWarScheduler } from "./services/squadWarSchedulerService";
import { adminModerationRouter } from "./routes/adminModeration";
import { adminDiagnosticsRouter } from "./routes/adminDiagnostics";
import { adminReplayVideosRouter } from "./routes/adminReplayVideos";
import { supportModerationRouter } from "./routes/supportModeration";
import { validateAuthenticationSecretConfiguration } from "./services/authSecretService";
import { trafficPolicy } from "./services/trafficPolicyService";
import { runtimeInfrastructurePolicy } from "./services/runtimeInfrastructurePolicyService";
import { startFirebasePushDeliveryScheduler } from "./services/firebasePushDeliveryService";
import { googlePlayRtdnRouter } from "./routes/googlePlayRtdn";
import { startGooglePlayRtdnScheduler } from "./services/googlePlayRtdnService";
import { adminGooglePlayRefundReviewsRouter } from "./routes/adminGooglePlayRefundReviews";
import { startGooglePlayRefundReviewScheduler } from "./services/googlePlayRefundReviewService";

const app = express();
const publicTrafficPolicy = trafficPolicy();
const runtimeInfrastructure = runtimeInfrastructurePolicy();

// Express trusts no forwarded client address by default. Enable only an explicit, bounded proxy
// hop count so a public caller cannot choose its own rate-limit identity with X-Forwarded-For.
if (publicTrafficPolicy.trustedProxyHops > 0) {
  app.set("trust proxy", publicTrafficPolicy.trustedProxyHops);
}

// Correlation and metrics wrap every request, including rate-limit/404/error responses. Generated
// IDs avoid reflecting attacker-controlled headers and never encode player/address information.
app.use((req: Request, res: Response, next: NextFunction) => {
  const startedAt = Date.now();
  const requestId = randomUUID();
  const requestPath = req.path;
  res.locals.requestId = requestId;
  res.setHeader("X-Request-ID", requestId);
  runWithRequestContext(requestId, () => {
    serverMetrics.beginHttp();
    logger.api.request(req.method, requestPath);
    res.on("finish", () => {
      const durationMs = Date.now() - startedAt;
      serverMetrics.finishHttp(req.method, res.statusCode, durationMs);
      logger.api.response(req.method, requestPath, res.statusCode, { duration: `${durationMs}ms` });
    });
    next();
  });
});

app.use(cors());
app.use(createHttpRateLimitMiddleware());
app.use(compression({ threshold: 1024 }));
// strict:false so the client's non-object JSON bodies (if any) still parse.
app.use(express.json({ strict: false, limit: "2mb" }));
// BestHTTP's AddField API posts the recovered client's requests as form fields.
app.use(express.urlencoded({ extended: false, limit: "2mb" }));

app.get("/health", (_req, res) => {
  res.json({
    status: "ok",
    pid: process.pid,
    uptime: Math.floor(process.uptime()),
    redis: !isRedisEnabled() ? "disabled" : isRedisAvailable() ? "available" : "unavailable",
    memory: process.memoryUsage().rss,
  });
});

app.get("/metrics", requireAdmin, (_req, res) => {
  res.type("text/plain; version=0.0.4; charset=utf-8").send(serverMetrics.render(isRedisAvailable()));
});

// Moderation mutations share the independent constant-time admin credential used by metrics.
// Per-operation actor and idempotency headers are validated inside the router and retained in
// the sanction audit history; the Bearer secret itself is never persisted or returned.
app.use("/admin/moderation", requireAdmin, adminModerationRouter);

// Retained diagnostics can contain player logs and failed-response bodies. Keep the entire read
// surface behind the independent admin credential; game sessions never authorize this router.
app.use("/admin/diagnostics", requireAdmin, adminDiagnosticsRouter);

// Replay URLs are retained third-party references and may identify a player or match. Only the
// independent admin credential can inspect them; this server stores but never fetches the URL.
app.use("/admin/replay-videos", requireAdmin, adminReplayVideosRouter);

// Pending-refund recommendations are irreversible at Google after the first accepted call. Keep
// queue reads and immutable encrypted submissions behind the independent operator credential.
app.use("/admin/google-play/refund-reviews", requireAdmin, adminGooglePlayRefundReviewsRouter);

// Sanctioned players cannot use the normal game dispatcher, but may prove their current session
// credential to this narrowly scoped support router. It can read/create only their own appeals and
// never returns private sanction or operator fields.
app.use("/support/moderation", supportModerationRouter);

// Google Cloud Pub/Sub calls this provider-only surface with an OIDC Bearer token. It is outside
// the recovered gameplay dispatcher and acknowledges only after durable message-ID deduplication.
app.use("/providers/google-play/rtdn", googlePlayRtdnRouter);

app.use(apiRouter);

app.use((req: Request, res: Response) => {
  res.status(404).json({ Code: 0, Message: `No route for ${req.method} ${req.originalUrl}` });
});

app.use((err: unknown, req: Request, res: Response, _next: NextFunction) => {
  const error = err instanceof Error ? err : new Error(String(err));
  logger.errorWithEmoji("❌", "Unhandled request error", "API", {
    method: req.method,
    path: req.originalUrl,
    requestId: res.locals.requestId,
    error: error.message,
  });
  res.status(500).json({ Code: 0, Message: "Internal server error." });
});

const httpServer = createServer(app);
let pvpCoordinatorHeartbeat: PvpCoordinatorHeartbeat | null = null;
let pvpOrphanRecoveryTimer: NodeJS.Timeout | null = null;
let playerLeagueSchedulerTimer: NodeJS.Timeout | null = null;
let googlePlaySubscriptionSchedulerTimer: NodeJS.Timeout | null = null;
let googlePlayVoidedPurchaseSchedulerTimer: NodeJS.Timeout | null = null;
let googlePlayRtdnSchedulerTimer: NodeJS.Timeout | null = null;
let googlePlayRefundReviewSchedulerTimer: NodeJS.Timeout | null = null;
let squadWarSchedulerTimer: NodeJS.Timeout | null = null;
let firebasePushDeliverySchedulerTimer: NodeJS.Timeout | null = null;
// Let Unity's BestHTTP reuse keep-alive sockets; headersTimeout must exceed keepAliveTimeout.
httpServer.keepAliveTimeout = 65_000;
httpServer.headersTimeout = 66_000;

async function start(): Promise<void> {
  validateAuthenticationSecretConfiguration(process.env.NODE_ENV === "production");
  if (process.env.NODE_ENV === "production" && config.adminSecret.length < 32) {
    throw new Error("ADMIN_SECRET must contain at least 32 characters in production.");
  }
  if (config.googlePlayPurchasesEnabled && !process.env.PURCHASE_TOKEN_HASH_SECRET?.trim()) {
    throw new Error("PURCHASE_TOKEN_HASH_SECRET must be set independently when purchases are enabled.");
  }
  if (config.googlePlayPurchasesEnabled && config.purchaseTokenHashSecret.length < 32) {
    throw new Error("PURCHASE_TOKEN_HASH_SECRET must contain at least 32 characters when purchases are enabled.");
  }
  if (config.googlePlayPurchasesEnabled && config.purchaseTokenEncryptionSecret.length < 32) {
    throw new Error("PURCHASE_TOKEN_ENCRYPTION_SECRET must contain at least 32 characters when purchases are enabled.");
  }
  if (config.googlePlaySubscriptionRevalidationEnabled && !config.googlePlayPurchasesEnabled) {
    throw new Error("Google Play subscription revalidation requires GOOGLE_PLAY_PURCHASES_ENABLED=true.");
  }
  if (config.googlePlayVoidedPurchaseReconciliationEnabled && !config.googlePlayPurchasesEnabled) {
    throw new Error("Google Play voided purchase reconciliation requires GOOGLE_PLAY_PURCHASES_ENABLED=true.");
  }
  // Parse, schema-check, and authenticate the complete publication before opening MongoDB or a
  // listener. A malformed live-ops file therefore fails deployment instead of reaching clients.
  initializeRemoteConfiguration();
  await connectMongo();
  logger.db.connect("MongoDB connected", {
    provider: "mongodb",
    database: runtimeInfrastructure.mongoDatabaseName,
  });
  // Migrations run before any repair or listener opens. A node with unknown/drifted history stays
  // out of service, and the database lease prevents two rolling-deployment nodes changing schema
  // concurrently.
  await runDatabaseMigrations();
  await connectRedis();
  pvpCoordinatorHeartbeat = await startPvpCoordinatorHeartbeat(hubInstanceId);
  await recoverInterruptedMatches(isRedisAvailable() ? isPvpCoordinatorAlive : undefined);
  if (isRedisAvailable()) {
    // A crashed coordinator key expires after 30 seconds. Periodic recovery then cancels only its
    // orphan rows and releases those participants; healthy peer-owned matches remain untouched.
    pvpOrphanRecoveryTimer = setInterval(() => {
      void recoverInterruptedMatches(isPvpCoordinatorAlive).catch((error: unknown) => {
        logger.match.error("PvP orphan recovery failed", {
          error: error instanceof Error ? error.message : String(error),
        });
      });
    }, 30_000);
    pvpOrphanRecoveryTimer.unref();
  }
  await createGameHub(httpServer);
  playerLeagueSchedulerTimer = startPlayerLeagueSettlementScheduler();
  squadWarSchedulerTimer = startSquadWarScheduler();
  googlePlaySubscriptionSchedulerTimer = startGooglePlaySubscriptionRevalidationScheduler();
  googlePlayVoidedPurchaseSchedulerTimer = startGooglePlayVoidedPurchaseScheduler();
  googlePlayRtdnSchedulerTimer = startGooglePlayRtdnScheduler();
  googlePlayRefundReviewSchedulerTimer = startGooglePlayRefundReviewScheduler();
  firebasePushDeliverySchedulerTimer = startFirebasePushDeliveryScheduler();

  httpServer.listen(runtimeInfrastructure.listenPort, () => {
    logger.server.start(runtimeInfrastructure.listenPort, process.env.NODE_ENV ?? "development");
    logger.infoWithEmoji("🌐", `Public URL: ${config.publicUrl}`, "SERVER");
    logger.infoWithEmoji("🔌", `WebSocket hub: ${config.publicUrl.replace(/^http/, "ws")}/hub`, "SERVER");
  });
}

async function shutdown(signal: string): Promise<void> {
  logger.server.shutdown(signal);
  httpServer.close();
  if (pvpOrphanRecoveryTimer) clearInterval(pvpOrphanRecoveryTimer);
  if (playerLeagueSchedulerTimer) clearInterval(playerLeagueSchedulerTimer);
  if (squadWarSchedulerTimer) clearInterval(squadWarSchedulerTimer);
  if (googlePlaySubscriptionSchedulerTimer) clearInterval(googlePlaySubscriptionSchedulerTimer);
  if (googlePlayVoidedPurchaseSchedulerTimer) clearInterval(googlePlayVoidedPurchaseSchedulerTimer);
  if (googlePlayRtdnSchedulerTimer) clearInterval(googlePlayRtdnSchedulerTimer);
  if (googlePlayRefundReviewSchedulerTimer) clearInterval(googlePlayRefundReviewSchedulerTimer);
  if (firebasePushDeliverySchedulerTimer) clearInterval(firebasePushDeliverySchedulerTimer);
  await pvpCoordinatorHeartbeat?.stop();
  await disconnectRedis();
  await disconnectMongo();
  process.exit(0);
}

process.on("SIGINT", () => void shutdown("SIGINT"));
process.on("SIGTERM", () => void shutdown("SIGTERM"));

start().catch((err: Error) => {
  logger.errorWithEmoji("❌", "Failed to start server", "SERVER", { error: err.message, stack: err.stack });
  process.exit(1);
});
