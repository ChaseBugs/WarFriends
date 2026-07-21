import { config } from "../config";

function exactSquadChatPolicy(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Squad Chat ${label} policy is invalid.`);
  }
  return value;
}

/** Page size for authenticated channel history; three is the recovered MainScene value. */
export function squadChatHistoryLimit(value = config.squadChatHistoryLimit): number {
  return exactSquadChatPolicy(value, "history-limit", 1, 100);
}

/** Durable message lifetime in whole days, compatible with the stored one-to-365-day authority. */
export function squadChatRetentionDays(value = config.squadChatRetentionDays): number {
  return exactSquadChatPolicy(value, "retention", 1, 365);
}

/** Atomic per-sender fixed-window limit, bounded by the shared durable denial sentinel. */
export function squadChatMessagesPerMinute(value = config.squadChatMessagesPerMinute): number {
  return exactSquadChatPolicy(value, "rate-limit", 1, 1_000);
}

/** Maximum text length accepted before moderation and durable validation. */
export function squadChatMaximumLength(value = config.squadChatMaxLength): number {
  return exactSquadChatPolicy(value, "maximum-length", 1, 2_048);
}
