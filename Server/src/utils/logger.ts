import fs from "fs";
import path from "path";
import winston from "winston";
import { currentRequestId } from "../services/requestContextService";

// Levels/format/file-layout follow the project's shared Logging Structure Rules
// (per-level files rotated by process start time, emoji console output in dev).
const levels = {
  error: 0,
  warn: 1,
  info: 2,
  success: 3,
  http: 4,
  verbose: 5,
  debug: 6,
  silly: 7,
};

const colors = {
  error: "red",
  warn: "yellow",
  info: "blue",
  success: "green",
  http: "magenta",
  verbose: "cyan",
  debug: "white",
  silly: "grey",
};

winston.addColors(colors);

export const EMOJIS = {
  ERROR: "❌",
  WARN: "⚠️",
  INFO: "ℹ️",
  SUCCESS: "✅",
  DEBUG: "🔍",

  HTTP: "🌐",
  REQUEST: "📥",
  RESPONSE: "📤",
  CONNECTED: "🔗",
  DISCONNECTED: "🔌",

  DATABASE: "🗄️",
  QUERY: "🔎",

  AUTH: "🔐",
  TOKEN: "🎫",
  LOGIN: "🚪",

  PLAYER: "👤",
  SOCKET: "🔌",

  MATCH: "⚔️",
  SQUAD: "🛡️",

  STARTUP: "🎬",
  SHUTDOWN: "🛑",
  ALERT: "🚨",
} as const;

const startTime = new Date().toTimeString().slice(0, 8).replace(/:/g, "-");
const dateFolder = new Date().toISOString().slice(0, 10);
const logDir = path.join(process.cwd(), "logs", dateFolder);
fs.mkdirSync(logDir, { recursive: true });

const fileFormat = winston.format.printf(({ level, message, timestamp, context, emoji: _emoji, ...meta }) => {
  const ctx = context ? `[${context}] ` : "";
  const metaStr = Object.keys(meta).length ? ` ${JSON.stringify(meta)}` : "";
  return `${timestamp} [${String(level).toUpperCase()}] ${ctx}${message}${metaStr}`;
});

const consoleFormat = winston.format.printf(({ level, message, timestamp, context, emoji, ...meta }) => {
  const ctx = context ? `[${context}] ` : "";
  const prefix = emoji ? `${emoji} ` : "";
  const time = String(timestamp).slice(11, 19);
  const metaStr = Object.keys(meta).length ? `\n  ${JSON.stringify(meta, null, 2)}` : "";
  return `${prefix}${time} ${level} ${ctx}${message}${metaStr}`;
});

const baseLogger = winston.createLogger({
  levels,
  level: process.env.NODE_ENV === "production" ? "info" : "debug",
  format: winston.format.combine(
    winston.format((info) => {
      const requestId = currentRequestId();
      if (requestId && info.requestId === undefined) info.requestId = requestId;
      return info;
    })(),
    winston.format.timestamp({ format: "YYYY-MM-DD HH:mm:ss.SSS" }),
    winston.format.errors({ stack: true }),
    fileFormat,
  ),
  transports: [
    new winston.transports.File({ filename: path.join(logDir, `${startTime}-error.log`), level: "error" }),
    new winston.transports.File({ filename: path.join(logDir, `${startTime}-warn.log`), level: "warn" }),
    new winston.transports.File({ filename: path.join(logDir, `${startTime}-success.log`), level: "success" }),
    new winston.transports.File({ filename: path.join(logDir, `${startTime}-combined.log`) }),
  ],
});

if (process.env.NODE_ENV !== "production") {
  baseLogger.add(
    new winston.transports.Console({
      format: winston.format.combine(
        winston.format.timestamp({ format: "YYYY-MM-DD HH:mm:ss.SSS" }),
        winston.format.colorize({ level: true }),
        consoleFormat,
      ),
    }),
  );
} else {
  baseLogger.add(new winston.transports.Console({ format: winston.format.json() }));
}

type Meta = Record<string, unknown>;

function withEmoji(level: keyof typeof levels, emoji: string, message: string, context: string, meta?: Meta) {
  baseLogger.log(level, message, { context, emoji, ...meta });
}

const logger = Object.assign(baseLogger, {
  errorWithEmoji: (emoji: string, message: string, context: string, meta?: Meta) =>
    withEmoji("error", emoji, message, context, meta),
  warnWithEmoji: (emoji: string, message: string, context: string, meta?: Meta) =>
    withEmoji("warn", emoji, message, context, meta),
  infoWithEmoji: (emoji: string, message: string, context: string, meta?: Meta) =>
    withEmoji("info", emoji, message, context, meta),
  successWithEmoji: (emoji: string, message: string, context: string, meta?: Meta) =>
    withEmoji("success", emoji, message, context, meta),
  debugWithEmoji: (emoji: string, message: string, context: string, meta?: Meta) =>
    withEmoji("debug", emoji, message, context, meta),

  server: {
    start: (port: number, env: string) =>
      withEmoji("success", EMOJIS.STARTUP, `Server listening on port ${port}`, "SERVER", { env }),
    shutdown: (signal: string) =>
      withEmoji("warn", EMOJIS.SHUTDOWN, `Server shutting down (${signal})`, "SERVER"),
  },

  db: {
    connect: (message: string, meta?: Meta) => withEmoji("success", EMOJIS.DATABASE, message, "DATABASE", meta),
    error: (message: string, meta?: Meta) => withEmoji("error", EMOJIS.ERROR, message, "DATABASE", meta),
  },

  api: {
    request: (method: string, urlPath: string, meta?: Meta) =>
      withEmoji("http", EMOJIS.REQUEST, `${method} ${urlPath}`, "API", meta),
    response: (method: string, urlPath: string, status: number, meta?: Meta) => {
      const level: keyof typeof levels =
        status >= 500 ? "error" : status >= 400 ? "warn" : status >= 300 ? "warn" : "success";
      const emoji = status >= 400 ? EMOJIS.WARN : EMOJIS.RESPONSE;
      withEmoji(level, emoji, `${method} ${urlPath} -> ${status}`, "API", meta);
    },
    action: (name: string, code: number, meta?: Meta) =>
      withEmoji("http", EMOJIS.HTTP, `DbAction ${name} (${code})`, "API", meta),
  },

  auth: {
    login: (deviceId: string, ok: boolean, meta?: Meta) =>
      withEmoji(ok ? "success" : "warn", EMOJIS.LOGIN, ok ? "Login succeeded" : "Login failed", "AUTH", {
        deviceId,
        ...meta,
      }),
    register: (deviceId: string, ok: boolean, meta?: Meta) =>
      withEmoji(ok ? "success" : "warn", EMOJIS.AUTH, ok ? "Registration succeeded" : "Registration failed", "AUTH", {
        deviceId,
        ...meta,
      }),
    token: (action: "issued" | "rotated", meta?: Meta) =>
      withEmoji("info", EMOJIS.TOKEN, `Auth token ${action}`, "AUTH", meta),
  },

  player: {
    create: (playerId: string, name: string) =>
      withEmoji("success", EMOJIS.PLAYER, "Player created", "PLAYER", { playerId, name }),
  },

  squad: {
    event: (message: string, meta?: Meta) => withEmoji("info", EMOJIS.SQUAD, message, "SQUAD", meta),
  },

  match: {
    event: (message: string, meta?: Meta) => withEmoji("info", EMOJIS.MATCH, message, "MATCH", meta),
    error: (message: string, meta?: Meta) => withEmoji("error", EMOJIS.ERROR, message, "MATCH", meta),
  },

  websocket: {
    connected: (clientId: string, meta?: Meta) =>
      withEmoji("success", EMOJIS.CONNECTED, "Client connected", "WEBSOCKET", { clientId, ...meta }),
    disconnected: (clientId: string, meta?: Meta) =>
      withEmoji("info", EMOJIS.DISCONNECTED, "Client disconnected", "WEBSOCKET", { clientId, ...meta }),
    message: (clientId: string, type: string, meta?: Meta) =>
      withEmoji("debug", EMOJIS.SOCKET, `Message received: ${type}`, "WEBSOCKET", { clientId, ...meta }),
    error: (message: string, meta?: Meta) => withEmoji("error", EMOJIS.ERROR, message, "WEBSOCKET", meta),
  },

  redis: {
    connected: (meta?: Meta) => withEmoji("success", EMOJIS.CONNECTED, "Redis connected", "REDIS", meta),
    error: (message: string, meta?: Meta) => withEmoji("error", EMOJIS.ERROR, message, "REDIS", meta),
  },
});

export default logger;
