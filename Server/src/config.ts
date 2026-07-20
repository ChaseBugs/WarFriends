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

  // WebSocket frames bypass Express and therefore need their own payload/rate boundaries.
  websocketMaxPayloadBytes: Number(process.env.WEBSOCKET_MAX_PAYLOAD_BYTES ?? 65_536),
  websocketRateLimitMessages: Number(process.env.WEBSOCKET_RATE_LIMIT_MESSAGES ?? 120),
  websocketRateLimitWindowSeconds: Number(process.env.WEBSOCKET_RATE_LIMIT_WINDOW_SECONDS ?? 10),
  websocketRateLimitMaxViolations: Number(process.env.WEBSOCKET_RATE_LIMIT_MAX_VIOLATIONS ?? 3),

  // Recovered from MainScene's Constants rows. Requests repeat these values for compatibility,
  // but economy logic always uses the server copy so a modified client cannot accelerate energy.
  dogTagRefillSeconds: Number(process.env.DOG_TAG_REFILL_SECONDS ?? 900),
  dogTagCap: Number(process.env.DOG_TAG_CAP ?? 5),
  // The full response/type contract is recovered, but the original live-ops calendar is absent.
  // Gold positions remain environment-tunable inside the documented offline mixed calendar.
  dailyRewardGold: Number(process.env.DAILY_REWARD_GOLD ?? 5),
  dailyRewardWeeklyGold: Number(process.env.DAILY_REWARD_WEEKLY_GOLD ?? 10),
  // Task reward ranges and the 50-point threshold are present in MainScene. The mega prize
  // itself was selected by the old live backend, so its currency-only fallback is configurable.
  assignmentMegaRewardGold: Number(process.env.ASSIGNMENT_MEGA_REWARD_GOLD ?? 25),
  // Starter-assignment expiry was issued by the original backend rather than serialized in
  // the APK's Google2u sheet. Keep that server-owned policy configurable; seven days is the
  // reconstruction default, while thresholds and rewards below come from MainScene itself.
  starterAssignmentDurationSeconds: Number(process.env.STARTER_ASSIGNMENT_DURATION_SECONDS ?? 604_800),
  // Both MainScene A/B tables are source-exact, but the retired remote experiment chose which
  // prefix the client displayed. Default to the conservative standard curve; never let the
  // request choose the more generous variant.
  warBucksGoldVariant: (process.env.WARBUCKS_GOLD_VARIANT ?? "standard").trim().toLowerCase(),

  // Squad events were scheduled by retired live-ops data that is not present in either
  // recovered APK. An empty path keeps action 113 deliberately disabled. Deployments may
  // opt in with a reviewed JSON file whose strict schema is documented in config/README.md.
  squadEventConfigPath: (process.env.SQUAD_EVENT_CONFIG_PATH ?? "").trim(),
  // EventAssignmentManager is a different Christmas-style daily event system. Its archived
  // schedule is also absent, so an empty path hides it and actions 222/223 fail closed.
  eventAssignmentConfigPath: (process.env.EVENT_ASSIGNMENT_CONFIG_PATH ?? "").trim(),

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
  reportMaxPerHour: Number(process.env.REPORT_MAX_PER_HOUR ?? 5),

  // Photon Chat subscribed with the exact MainScene ChatMessagesLimit value of three. The
  // replacement hub preserves that visible history size while making retention, text length,
  // and abuse controls explicit server policy instead of accepting client-selected bounds.
  squadChatHistoryLimit: Number(process.env.SQUAD_CHAT_HISTORY_LIMIT ?? 3),
  squadChatRetentionDays: Number(process.env.SQUAD_CHAT_RETENTION_DAYS ?? 30),
  squadChatMessagesPerMinute: Number(process.env.SQUAD_CHAT_MESSAGES_PER_MINUTE ?? 10),
  squadChatMaxLength: Number(process.env.SQUAD_CHAT_MAX_LENGTH ?? 256),

  matchmakingTimeout: Number(process.env.MATCHMAKING_TIMEOUT ?? 30),
  // Once two players are paired they must both join the room within this window. This is
  // separate from queue timeout because the match already exists and both players are InGame.
  matchJoinTimeoutSeconds: Number(process.env.MATCH_JOIN_TIMEOUT_SECONDS ?? 30),
  matchDisconnectGraceSeconds: Number(process.env.MATCH_DISCONNECT_GRACE_SECONDS ?? 20),
  // The two stock clients normally submit GameEnded within the same few seconds. Keep the
  // first HTTP request open briefly so it can return the immutable receipt created by the
  // second agreeing report instead of showing a false zero-reward result screen.
  matchResultConsensusWaitMilliseconds: Number(process.env.MATCH_RESULT_CONSENSUS_WAIT_MS ?? 5_000),

  // The retired Fusebox `BattleWarbucksRewards` document was downloaded at runtime and is
  // absent from both recovered APKs. These are explicit offline reconstruction defaults,
  // never values echoed by GameEnded's client-controlled WarbuckRewardWin/Loss fields.
  pvpWinWarBucks: Number(process.env.PVP_WIN_WARBUCKS ?? 800),
  pvpLoseWarBucks: Number(process.env.PVP_LOSE_WARBUCKS ?? 400),

  // Action 199's timer, five-charge batch, and 35/70/140 Gold curve are recoverable from
  // MainScene and the 1.6.0 client. Its retired server-side reward table is not in either APK.
  // Keep this explicit offline reward policy independently tunable instead of accepting the
  // client as economy authority or pretending these defaults came from the production service.
  instantBattleExperiencePerBattle: Number(process.env.INSTANT_BATTLE_XP_PER_BATTLE ?? 20),
  instantBattleWarBucksPerBattle: Number(process.env.INSTANT_BATTLE_WARBUCKS_PER_BATTLE ?? 600),
};
