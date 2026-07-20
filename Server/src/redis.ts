import Redis, { type RedisOptions } from "ioredis";
import { config } from "./config";
import logger from "./utils/logger";

// Redis is optional. It backs the matchmaking queue, leaderboard sorted sets, and a
// pub/sub backbone so multiple hub instances can relay persisted Squad Chat traffic. When disabled (or
// unreachable) every helper below degrades to null/no-op so callers don't have to gate on
// availability — matchmaking then falls back to a Mongo scan.
let publisher: Redis | null = null;
let subscriber: Redis | null = null;
let dataClient: Redis | null = null;
let redisAvailable = false;
const channelHandlers = new Map<string, Set<(message: string) => void>>();

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
    // ioredis emits every subscribed channel through one connection-level event. Route it to
    // registered channel handlers here so feature modules never add duplicate global listeners.
    subscriber.on("message", (channel, message) => {
      for (const handler of channelHandlers.get(channel) ?? []) {
        try {
          handler(message);
        } catch (err) {
          logger.redis.error("Pub/sub handler failed", { channel, error: (err as Error).message });
        }
      }
    });
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
  channelHandlers.clear();
}

/** Publish transient fan-out data without making Redis part of durable gameplay authority. */
export async function redisPublish(channel: string, message: string): Promise<boolean> {
  if (!isRedisAvailable()) return false;
  const client = getRedisPublisher();
  if (!client) return false;
  try {
    await client.publish(channel, message);
    return true;
  } catch (err) {
    logger.redis.error("PUBLISH failed", { channel, error: (err as Error).message });
    return false;
  }
}

/**
 * Register a process-local handler for one Redis channel.
 *
 * The handler is installed before SUBSCRIBE so a message arriving immediately after the server
 * acknowledgement cannot be lost locally. A failed subscription removes only this registration;
 * MongoDB history and same-process WebSocket delivery continue to work without Redis.
 */
export async function redisSubscribe(channel: string, handler: (message: string) => void): Promise<boolean> {
  if (!isRedisAvailable()) return false;
  const client = getRedisSubscriber();
  if (!client) return false;
  let handlers = channelHandlers.get(channel);
  const firstHandler = !handlers;
  if (!handlers) {
    handlers = new Set();
    channelHandlers.set(channel, handlers);
  }
  handlers.add(handler);
  try {
    if (firstHandler) await client.subscribe(channel);
    return true;
  } catch (err) {
    handlers.delete(handler);
    if (handlers.size === 0) channelHandlers.delete(channel);
    logger.redis.error("SUBSCRIBE failed", { channel, error: (err as Error).message });
    return false;
  }
}

export async function redisGet(key: string): Promise<string | null | undefined> {
  const client = getRedisDataClient();
  if (!client || !isRedisAvailable()) return undefined;
  try {
    return await client.get(key);
  } catch (err) {
    logger.redis.error("GET failed", { key, error: (err as Error).message });
    return undefined;
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

/**
 * Execute one bounded atomic coordination script. Callers must still keep MongoDB as gameplay
 * authority: this helper is intended for transient queues, leases, and fan-out coordination.
 */
export async function redisEval(
  script: string,
  keys: readonly string[],
  args: ReadonlyArray<string | number>,
): Promise<unknown | undefined> {
  const client = getRedisDataClient();
  if (!client || !isRedisAvailable()) return undefined;
  try {
    return await client.eval(script, keys.length, ...keys, ...args.map(String));
  } catch (err) {
    logger.redis.error("EVAL failed", { error: (err as Error).message });
    return undefined;
  }
}

/** Read Redis server time so distributed algorithms do not depend on per-node wall clocks. */
export async function redisTimeMs(): Promise<number | undefined> {
  const client = getRedisDataClient();
  if (!client || !isRedisAvailable()) return undefined;
  try {
    const [seconds, microseconds] = await client.time();
    return Number(seconds) * 1_000 + Math.floor(Number(microseconds) / 1_000);
  } catch (err) {
    logger.redis.error("TIME failed", { error: (err as Error).message });
    return undefined;
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
