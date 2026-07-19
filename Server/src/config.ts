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
  minClientVersion: Number(process.env.MIN_CLIENT_VERSION ?? 0),

  matchmakingTimeout: Number(process.env.MATCHMAKING_TIMEOUT ?? 30),
};
