import { config } from "../config";

function exactSquadChatPolicy(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Squad Chat ${label} policy is invalid.`);
  }
  return value;
}

export interface SquadChatPolicy {
  readonly historyLimit: number;
  readonly retentionDays: number;
  readonly messagesPerMinute: number;
  readonly maximumLength: number;
}

/**
 * Resolve every policy value that participates in admitting and publishing one chat message.
 *
 * Text validation, atomic sender reservation, durable expiry, and history pagination execute at
 * different boundaries. Reading mutable config independently could accept a message under one
 * policy and retain or expose it under another. Validate and freeze the complete snapshot at
 * module startup so all four stages use coherent process authority.
 */
function exactSquadChatPolicySnapshot(policy: SquadChatPolicy): SquadChatPolicy {
  return {
    historyLimit: exactSquadChatPolicy(policy.historyLimit, "history-limit", 1, 100),
    retentionDays: exactSquadChatPolicy(policy.retentionDays, "retention", 1, 365),
    messagesPerMinute: exactSquadChatPolicy(policy.messagesPerMinute, "rate-limit", 1, 1_000),
    maximumLength: exactSquadChatPolicy(policy.maximumLength, "maximum-length", 1, 2_048),
  };
}

const CONFIGURED_SQUAD_CHAT_POLICY = Object.freeze(exactSquadChatPolicySnapshot({
  historyLimit: config.squadChatHistoryLimit,
  retentionDays: config.squadChatRetentionDays,
  messagesPerMinute: config.squadChatMessagesPerMinute,
  maximumLength: config.squadChatMaxLength,
}));

export function squadChatPolicy(policy?: SquadChatPolicy): SquadChatPolicy {
  return policy === undefined
    ? CONFIGURED_SQUAD_CHAT_POLICY
    : exactSquadChatPolicySnapshot(policy);
}

/** Page size for authenticated channel history; three is the recovered MainScene value. */
export function squadChatHistoryLimit(value?: number): number {
  return value === undefined
    ? CONFIGURED_SQUAD_CHAT_POLICY.historyLimit
    : exactSquadChatPolicy(value, "history-limit", 1, 100);
}

/** Durable message lifetime in whole days, compatible with the stored one-to-365-day authority. */
export function squadChatRetentionDays(value?: number): number {
  return value === undefined
    ? CONFIGURED_SQUAD_CHAT_POLICY.retentionDays
    : exactSquadChatPolicy(value, "retention", 1, 365);
}

/** Atomic per-sender fixed-window limit, bounded by the shared durable denial sentinel. */
export function squadChatMessagesPerMinute(value?: number): number {
  return value === undefined
    ? CONFIGURED_SQUAD_CHAT_POLICY.messagesPerMinute
    : exactSquadChatPolicy(value, "rate-limit", 1, 1_000);
}

/** Maximum text length accepted before moderation and durable validation. */
export function squadChatMaximumLength(value?: number): number {
  return value === undefined
    ? CONFIGURED_SQUAD_CHAT_POLICY.maximumLength
    : exactSquadChatPolicy(value, "maximum-length", 1, 2_048);
}
