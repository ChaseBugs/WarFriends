export const config = {
  port: Number(process.env.PORT ?? 8080),
  publicUrl: process.env.PUBLIC_URL ?? "http://localhost:8080",

  mongoUrl: process.env.MONGO_URL ?? "mongodb://127.0.0.1:27017",
  mongoDbName: process.env.MONGO_DB_NAME ?? "warfriends",
  mongoPoolSize: Number(process.env.MONGO_POOL_SIZE ?? 100),

  redisEnabled: (process.env.REDIS_ENABLED ?? "true").toLowerCase() === "true",
  redisUrl: process.env.REDIS_URL ?? "redis://127.0.0.1:6379",
  redisSessionTtl: Number(process.env.REDIS_SESSION_TTL ?? 1800),
  redisLeaderboardTtl: Number(process.env.REDIS_LEADERBOARD_TTL ?? 15),

  authSecret: process.env.AUTH_SECRET ?? "change-me-in-production",
  // LoginToCustomAccount is the only route allowed to verify a durable password/provider
  // credential. These values bound repeated guesses for the same presented identity while
  // leaving normal session-token gameplay requests unaffected.
  authLoginMaxAttempts: Number(process.env.AUTH_LOGIN_MAX_ATTEMPTS ?? 5),
  authLoginWindowSeconds: Number(process.env.AUTH_LOGIN_WINDOW_SECONDS ?? 900),
  authLoginLockoutSeconds: Number(process.env.AUTH_LOGIN_LOCKOUT_SECONDS ?? 900),
  minClientVersion: Number(process.env.MIN_CLIENT_VERSION ?? 0),

  // Process-local HTTP abuse boundary. TRUST_PROXY_HOPS remains zero unless the deployment has
  // exactly that many trusted reverse proxies; accepting arbitrary forwarded addresses would let
  // callers evade per-IP buckets by spoofing X-Forwarded-For.
  trustProxyHops: Number(process.env.TRUST_PROXY_HOPS ?? 0),
  httpRateLimitMaxRequests: Number(process.env.HTTP_RATE_LIMIT_MAX_REQUESTS ?? 120),
  httpRateLimitWindowSeconds: Number(process.env.HTTP_RATE_LIMIT_WINDOW_SECONDS ?? 60),
  httpRateLimitMaxEntries: Number(process.env.HTTP_RATE_LIMIT_MAX_ENTRIES ?? 10_000),

  // Recovered from MainScene's Constants rows. Requests repeat these values for compatibility,
  // but economy logic always uses the server copy so a modified client cannot accelerate energy.
  dogTagRefillSeconds: Number(process.env.DOG_TAG_REFILL_SECONDS ?? 900),
  dogTagCap: Number(process.env.DOG_TAG_CAP ?? 5),
  // The response shape and Gold reward type are recovered exactly. The original live-ops
  // amounts were remote data and are absent from the APK, so these conservative defaults
  // remain environment-tunable until an archived production reward sheet is recovered.
  dailyRewardGold: Number(process.env.DAILY_REWARD_GOLD ?? 5),
  dailyRewardWeeklyGold: Number(process.env.DAILY_REWARD_WEEKLY_GOLD ?? 10),
  // Task reward ranges and the 50-point threshold are present in MainScene. The mega prize
  // itself was selected by the old live backend, so its currency-only fallback is configurable.
  assignmentMegaRewardGold: Number(process.env.ASSIGNMENT_MEGA_REWARD_GOLD ?? 25),
  // Starter-assignment expiry was issued by the original backend rather than serialized in
  // the APK's Google2u sheet. Keep that server-owned policy configurable; seven days is the
  // reconstruction default, while thresholds and rewards below come from MainScene itself.
  starterAssignmentDurationSeconds: Number(process.env.STARTER_ASSIGNMENT_DURATION_SECONDS ?? 604_800),

  // War Arena's response contracts and twelve-battle ceiling are present in the recovered
  // client. Prices and guaranteed scraps came from the retired remote arena document and
  // are not stored in either APK, so they are explicit deploy-time reconstruction policy.
  // Keep the client-visible remote sheet and these values aligned when an archived sheet is
  // recovered; the backend never accepts a client-provided price as authority.
  arenaIdPrefix: process.env.ARENA_ID_PREFIX ?? "offline-arena",
  arenaMaxBattles: Number(process.env.ARENA_MAX_BATTLES ?? 12),
  arenaLives: Number(process.env.ARENA_LIVES ?? 3),
  arenaEntryTickets: Number(process.env.ARENA_ENTRY_TICKETS ?? 1),
  arenaEntryGold: Number(process.env.ARENA_ENTRY_GOLD ?? 30),
  arenaHeartTickets: Number(process.env.ARENA_HEART_TICKETS ?? 1),
  arenaHeartGold: Number(process.env.ARENA_HEART_GOLD ?? 30),
  arenaGuaranteedScraps: Number(process.env.ARENA_GUARANTEED_SCRAPS ?? 10),

  // Persistent inbox abuse/retention controls. These defaults are intentionally conservative
  // for an offline reconstruction and remain deploy-time tunable without changing the Unity
  // wire contract.
  challengeTtlSeconds: Number(process.env.CHALLENGE_TTL_SECONDS ?? 86_400),
  outgoingMessagesPerMinute: Number(process.env.OUTGOING_MESSAGES_PER_MINUTE ?? 20),

  matchmakingTimeout: Number(process.env.MATCHMAKING_TIMEOUT ?? 30),
  // Once two players are paired they must both join the room within this window. This is
  // separate from queue timeout because the match already exists and both players are InGame.
  matchJoinTimeoutSeconds: Number(process.env.MATCH_JOIN_TIMEOUT_SECONDS ?? 30),
  matchDisconnectGraceSeconds: Number(process.env.MATCH_DISCONNECT_GRACE_SECONDS ?? 20),
};
