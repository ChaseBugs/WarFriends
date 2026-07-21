/**
 * Parse one deployment switch without silently changing operator intent.
 *
 * The previous `(value ?? default).toLowerCase() === "true"` pattern turned every typo, blank,
 * numeric flag, and whitespace-padded value into `false`. For Redis coordination and purchase
 * reconciliation that is not a harmless default: one misconfigured node could join a deployment
 * with materially different safety behavior. Preserve the existing case-insensitive literals,
 * but require the complete environment value to be exactly `true` or `false`.
 */
export function exactEnvironmentBoolean(
  value: unknown,
  fallback: boolean,
  label: string,
): boolean {
  if (value === undefined) return fallback;
  if (typeof value !== "string") throw new Error(`${label} must be exactly true or false.`);
  const normalized = value.toLowerCase();
  if (normalized === "true") return true;
  if (normalized === "false") return false;
  throw new Error(`${label} must be exactly true or false.`);
}

export const config = {
  port: Number(process.env.PORT ?? 8080),
  publicUrl: process.env.PUBLIC_URL ?? "http://localhost:8080",

  mongoUrl: process.env.MONGO_URL ?? "mongodb://127.0.0.1:27017",
  mongoDbName: process.env.MONGO_DB_NAME ?? "warfriends",
  mongoPoolSize: Number(process.env.MONGO_POOL_SIZE ?? 100),

  redisEnabled: exactEnvironmentBoolean(process.env.REDIS_ENABLED, true, "REDIS_ENABLED"),
  redisUrl: process.env.REDIS_URL ?? "redis://127.0.0.1:6379",
  redisSessionTtl: Number(process.env.REDIS_SESSION_TTL ?? 1800),
  redisLeaderboardTtl: Number(process.env.REDIS_LEADERBOARD_TTL ?? 15),

  authSecret: process.env.AUTH_SECRET ?? "change-me-in-production",
  // Temporary verification-only keys used during an AUTH_SECRET rotation. New session,
  // password, and provider digests always use authSecret; a successful fallback-key login is
  // compare-and-set upgraded to the current key. Keep this list short and remove retired keys
  // after the documented overlap window.
  authSecretFallbacks: (process.env.AUTH_SECRET_FALLBACKS ?? "")
    .split(",")
    .map((secret) => secret.trim())
    .filter(Boolean),
  // Current scrypt CPU/memory work factor for durable custom passwords. Stored digests retain
  // their original factor and are opportunistically upgraded after a successful explicit login.
  authScryptCost: Number(process.env.AUTH_SCRYPT_COST ?? 16_384),
  // Separate operator credential. It is never accepted by gameplay authentication and protects
  // metrics/maintenance routes when configured.
  adminSecret: process.env.ADMIN_SECRET ?? "",
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
  playerLeagueSchedulerIntervalSeconds: Number(process.env.PLAYER_LEAGUE_SCHEDULER_INTERVAL_SECONDS ?? 60),

  // Real-money delivery is fail-closed. When enabled, Google Application Default Credentials
  // must identify a Play Console service account that can read purchases for this exact app.
  googlePlayPurchasesEnabled: exactEnvironmentBoolean(
    process.env.GOOGLE_PLAY_PURCHASES_ENABLED,
    false,
    "GOOGLE_PLAY_PURCHASES_ENABLED",
  ),
  googlePlayPackageName: (process.env.GOOGLE_PLAY_PACKAGE_NAME ?? "com.chillingo.warfriends.android.gplay").trim(),
  // Keep this stable across AUTH_SECRET/session-key rotation or migrate the receipt ledger first.
  purchaseTokenHashSecret: process.env.PURCHASE_TOKEN_HASH_SECRET ?? process.env.AUTH_SECRET ?? "change-me-in-production",
  // Subscription tokens must remain available for later Play status checks, but storing a raw
  // bearer token would turn a database read into a replayable purchase credential. A separate,
  // stable secret encrypts only subscription tokens with authenticated AES-GCM at rest.
  purchaseTokenEncryptionSecret: process.env.PURCHASE_TOKEN_ENCRYPTION_SECRET ?? "",
  googlePlaySubscriptionRevalidationEnabled: exactEnvironmentBoolean(
    process.env.GOOGLE_PLAY_SUBSCRIPTION_REVALIDATION_ENABLED
      ?? process.env.GOOGLE_PLAY_PURCHASES_ENABLED,
    false,
    "GOOGLE_PLAY_SUBSCRIPTION_REVALIDATION_ENABLED",
  ),
  googlePlaySubscriptionSchedulerIntervalSeconds:
    Number(process.env.GOOGLE_PLAY_SUBSCRIPTION_SCHEDULER_INTERVAL_SECONDS ?? 300),
  googlePlaySubscriptionRevalidationCadenceSeconds:
    Number(process.env.GOOGLE_PLAY_SUBSCRIPTION_REVALIDATION_CADENCE_SECONDS ?? 21_600),
  googlePlaySubscriptionRevalidationBatchSize:
    Number(process.env.GOOGLE_PLAY_SUBSCRIPTION_REVALIDATION_BATCH_SIZE ?? 100),
  // Voided Purchases is the delayed, authoritative backstop for refunded/charged-back one-time
  // products. It defaults to purchase enablement and keeps its own scheduler switch for staged
  // rollout or emergency suspension without disabling new purchase verification.
  googlePlayVoidedPurchaseReconciliationEnabled: exactEnvironmentBoolean(
    process.env.GOOGLE_PLAY_VOIDED_PURCHASE_RECONCILIATION_ENABLED
      ?? process.env.GOOGLE_PLAY_PURCHASES_ENABLED,
    false,
    "GOOGLE_PLAY_VOIDED_PURCHASE_RECONCILIATION_ENABLED",
  ),
  googlePlayVoidedPurchaseSchedulerIntervalSeconds:
    Number(process.env.GOOGLE_PLAY_VOIDED_PURCHASE_SCHEDULER_INTERVAL_SECONDS ?? 300),

  // Optional signed publication manifest for the stock GetConfigurations raw-text protocol.
  // Empty keeps bundled APK sheets active. The signing key is backend-only and protects the
  // operator file from accidental or unauthorized modification before any values are served.
  remoteConfigurationManifestPath: (process.env.REMOTE_CONFIGURATION_MANIFEST_PATH ?? "").trim(),
  remoteConfigurationSigningSecret: process.env.REMOTE_CONFIGURATION_SIGNING_SECRET ?? "",

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
  // prefix the client displayed. Preserve the exact operator literal for startup validation;
  // trimming or case-folding malformed input would silently create different economy authority.
  warBucksGoldVariant: process.env.WARBUCKS_GOLD_VARIANT ?? "standard",

  // Squad events were scheduled by retired live-ops data that is not present in either
  // recovered APK. An empty path keeps action 113 deliberately disabled. Deployments may
  // opt in with a reviewed JSON file whose strict schema is documented in config/README.md.
  squadEventConfigPath: (process.env.SQUAD_EVENT_CONFIG_PATH ?? "").trim(),
  // The retired Squad Wars calendar is also absent, but unlike content-driven Squad Events its
  // complete ranking/reward tables are serialized in MainScene. The offline backend therefore
  // runs an explicit reconstruction-owned weekly calendar by default; operators may disable it
  // or change cadence without pretending the generated IDs are archived production seasons.
  squadWarsEnabled: exactEnvironmentBoolean(
    process.env.SQUAD_WARS_ENABLED,
    true,
    "SQUAD_WARS_ENABLED",
  ),
  squadWarsSeasonDurationSeconds: Number(process.env.SQUAD_WARS_SEASON_DURATION_SECONDS ?? 604_800),
  squadWarsSchedulerIntervalSeconds: Number(process.env.SQUAD_WARS_SCHEDULER_INTERVAL_SECONDS ?? 60),
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
  // Moderation lifecycle is reconstruction-owned operator policy, not a Unity wire contract.
  // Only terminal reports/appeals become eligible; sanctions remain indefinitely auditable.
  moderationReportRetentionDays: Number(process.env.MODERATION_REPORT_RETENTION_DAYS ?? 365),
  moderationAppealRetentionDays: Number(process.env.MODERATION_APPEAL_RETENTION_DAYS ?? 365),

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
