import { config } from "../config";

export interface ClientAnalyticsPolicy {
  readonly enabled: boolean;
  readonly retentionDays: number;
  readonly maximumPayloadBytes: number;
  readonly eventsPerMinute: number;
}

function exactInteger(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Client analytics ${label} policy is invalid.`);
  }
  return value;
}

/**
 * Freeze the complete privacy, storage, and abuse policy at module startup.
 *
 * Parsing under one payload limit and retaining under another would make deployment behavior
 * depend on when individual config fields were read. A single immutable snapshot also makes an
 * invalid opt-in fail startup instead of silently collecting under hidden defaults.
 */
function exactPolicy(value: ClientAnalyticsPolicy): ClientAnalyticsPolicy {
  if (typeof value.enabled !== "boolean") {
    throw new Error("Client analytics enablement policy is invalid.");
  }
  return {
    enabled: value.enabled,
    retentionDays: exactInteger(value.retentionDays, "retention", 1, 90),
    maximumPayloadBytes: exactInteger(value.maximumPayloadBytes, "payload-size", 256, 65_536),
    eventsPerMinute: exactInteger(value.eventsPerMinute, "rate-limit", 1, 120),
  };
}

const CONFIGURED_CLIENT_ANALYTICS_POLICY = Object.freeze(exactPolicy({
  enabled: config.clientAnalyticsEnabled,
  retentionDays: config.clientAnalyticsRetentionDays,
  maximumPayloadBytes: config.clientAnalyticsMaximumPayloadBytes,
  eventsPerMinute: config.clientAnalyticsEventsPerMinute,
}));

export function clientAnalyticsPolicy(value?: ClientAnalyticsPolicy): ClientAnalyticsPolicy {
  return value === undefined ? CONFIGURED_CLIENT_ANALYTICS_POLICY : exactPolicy(value);
}
