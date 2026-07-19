import Redis, { type RedisOptions } from "ioredis";
import { config } from "./config";
import logger from "./utils/logger";

// Redis is optional. It backs the matchmaking queue, leaderboard sorted sets, and a
// pub/sub backbone so multiple hub instances can relay match traffic. When disabled (or
// unreachable) every helper below degrades to null/no-op so callers don't have to gate on
// availability — matchmaking then falls back to a Mongo scan.
let publisher: Redis | null = null;
let subscriber: Redis | null = null;
let dataClient: Redis | null = null;
let redisAvailable = false;

const redisOptions: RedisOptions = {
  lazyConnect: true,
  enableOfflineQueue: false,
  maxRetriesPerRequest: 1,
  connectTimeout: 3000,
  retryStrategy: (attempt) => (attempt <= 3 ? attempt * 200 : null),
};

export function isRedisEnabled(): boolean {
  return config.redisEnabled;
}

export function isRedisAvailable(): boolean {
  return config.redisEnabled && redisAvailable;
}

export function getRedisPublisher(): Redis | null {
  if (!config.redisEnabled) return null;
  if (!publisher) {
    publisher = new Redis(config.redisUrl, redisOptions);
    publisher.on("error", (err) => logger.redis.error("Publisher connection error", { error: err.message }));
  }
  return publisher;
}

export function getRedisSubscriber(): Redis | null {
  if (!config.redisEnabled) return null;
  if (!subscriber) {
    subscriber = new Redis(config.redisUrl, redisOptions);
    subscriber.on("error", (err) => logger.redis.error("Subscriber connection error", { error: err.message }));
  }
  return subscriber;
}

export function getRedisDataClient(): Redis | null {
  if (!config.redisEnabled) return null;
  if (!dataClient) {
    // Disable offline queueing and cap retries so a missing Redis surfaces immediately and
    // the Mongo fallback actually kicks in, instead of commands hanging on a reconnect that
    // may never happen.
    dataClient = new Redis(config.redisUrl, redisOptions);
    dataClient.on("error", (err) => logger.redis.error("Data client connection error", { error: err.message }));
  }
  return dataClient;
}

export async function connectRedis(): Promise<void> {
  if (!config.redisEnabled) return;
  try {
    await Promise.all([getRedisPublisher()?.connect(), getRedisSubscriber()?.connect(), getRedisDataClient()?.connect()]);
    redisAvailable = true;
    logger.redis.connected({ url: config.redisUrl });
  } catch (err) {
    logger.redis.error("Failed to connect — continuing without Redis (MongoDB-only fallback)", {
      error: (err as Error).message,
    });
    publisher?.disconnect();
    subscriber?.disconnect();
    dataClient?.disconnect();
    publisher = null;
    subscriber = null;
    dataClient = null;
    redisAvailable = false;
  }
}

export async function disconnectRedis(): Promise<void> {
  await Promise.all([publisher?.quit(), subscriber?.quit(), dataClient?.quit()]);
  publisher = null;
  subscriber = null;
  dataClient = null;
  redisAvailable = false;
}

export async function redisGet(key: string): Promise<string | null> {
  const client = getRedisDataClient();
  if (!client) return null;
  try {
    return await client.get(key);
  } catch (err) {
    logger.redis.error("GET failed", { key, error: (err as Error).message });
    return null;
  }
}

export async function redisSet(key: string, value: string, ttlSeconds?: number): Promise<boolean> {
  const client = getRedisDataClient();
  if (!client) return false;
  try {
    if (ttlSeconds != null && ttlSeconds > 0) await client.set(key, value, "EX", ttlSeconds);
    else await client.set(key, value);
    return true;
  } catch (err) {
    logger.redis.error("SET failed", { key, error: (err as Error).message });
    return false;
  }
}

export async function redisDel(key: string): Promise<boolean> {
  const client = getRedisDataClient();
  if (!client) return false;
  try {
    await client.del(key);
    return true;
  } catch (err) {
    logger.redis.error("DEL failed", { key, error: (err as Error).message });
    return false;
  }
}

/** Add a member to a sorted set (leaderboards). Returns false when Redis is unavailable. */
export async function redisZAdd(key: string, score: number, member: string): Promise<boolean> {
  const client = getRedisDataClient();
  if (!client) return false;
  try {
    await client.zadd(key, score, member);
    return true;
  } catch (err) {
    logger.redis.error("ZADD failed", { key, error: (err as Error).message });
    return false;
  }
}

/** Top-N members (highest score first) with scores, or null when Redis is unavailable. */
export async function redisZRevRange(key: string, count: number): Promise<string[] | null> {
  const client = getRedisDataClient();
  if (!client) return null;
  try {
    return await client.zrevrange(key, 0, Math.max(0, count - 1), "WITHSCORES");
  } catch (err) {
    logger.redis.error("ZREVRANGE failed", { key, error: (err as Error).message });
    return null;
  }
}
