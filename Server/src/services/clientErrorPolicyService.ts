import { config } from "../config";

export interface ClientErrorPolicy {
  readonly enabled: boolean;
  readonly retentionDays: number;
  readonly maximumPayloadBytes: number;
  readonly eventsPerMinute: number;
}

function exactInteger(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Client error ${label} policy is invalid.`);
  }
  return value;
}

/** Resolve the privacy switch and all storage bounds once before action 92 can retain data. */
function exactPolicy(value: ClientErrorPolicy): ClientErrorPolicy {
  if (typeof value.enabled !== "boolean") throw new Error("Client error enablement policy is invalid.");
  return {
    enabled: value.enabled,
    retentionDays: exactInteger(value.retentionDays, "retention", 1, 30),
    maximumPayloadBytes: exactInteger(value.maximumPayloadBytes, "payload-size", 1_024, 65_536),
    eventsPerMinute: exactInteger(value.eventsPerMinute, "rate-limit", 1, 60),
  };
}

const CONFIGURED_CLIENT_ERROR_POLICY = Object.freeze(exactPolicy({
  enabled: config.clientErrorEnabled,
  retentionDays: config.clientErrorRetentionDays,
  maximumPayloadBytes: config.clientErrorMaximumPayloadBytes,
  eventsPerMinute: config.clientErrorEventsPerMinute,
}));

export function clientErrorPolicy(value?: ClientErrorPolicy): ClientErrorPolicy {
  return value === undefined ? CONFIGURED_CLIENT_ERROR_POLICY : exactPolicy(value);
}
