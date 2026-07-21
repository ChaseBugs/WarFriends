import { config } from "../config";

export interface ClientLogPolicy {
  readonly retentionDays: number;
  readonly maximumPayloadBytes: number;
  readonly eventsPerMinute: number;
}

function exactInteger(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Client support-log ${label} policy is invalid.`);
  }
  return value;
}

/** Resolve size, retention, and abuse authority once before any support upload is admitted. */
function exactPolicy(value: ClientLogPolicy): ClientLogPolicy {
  return {
    retentionDays: exactInteger(value.retentionDays, "retention", 1, 30),
    // Express accepts at most 2 MiB for the complete form. Leave room for credentials and other
    // source fields while allowing the stock StringBuilder to carry a useful diagnostic history.
    maximumPayloadBytes: exactInteger(value.maximumPayloadBytes, "payload-size", 1_024, 1_048_576),
    eventsPerMinute: exactInteger(value.eventsPerMinute, "rate-limit", 1, 20),
  };
}

const CONFIGURED_CLIENT_LOG_POLICY = Object.freeze(exactPolicy({
  retentionDays: config.clientLogRetentionDays,
  maximumPayloadBytes: config.clientLogMaximumPayloadBytes,
  eventsPerMinute: config.clientLogEventsPerMinute,
}));

export function clientLogPolicy(value?: ClientLogPolicy): ClientLogPolicy {
  return value === undefined ? CONFIGURED_CLIENT_LOG_POLICY : exactPolicy(value);
}
