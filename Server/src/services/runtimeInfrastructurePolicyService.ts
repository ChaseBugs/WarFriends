import { config } from "../config";

export interface RuntimeInfrastructurePolicy {
  readonly listenPort: number;
  readonly mongoPoolSize: number;
  readonly mongoDatabaseName: string;
}

function exactInteger(value: number, label: string, minimum: number, maximum: number): number {
  if (!Number.isSafeInteger(value) || value < minimum || value > maximum) {
    throw new Error(`Runtime ${label} policy is invalid.`);
  }
  return value;
}

/**
 * Validate the database name before MongoDB connections or migrations can begin.
 *
 * MongoDB rejects empty, oversized, NUL-containing, and platform-reserved names. Performing the
 * same conservative check here prevents one node from reaching migrations and only then failing
 * to select its database. Byte length matters because MongoDB's namespace limit is byte-based.
 */
export function exactMongoDatabaseName(value: string): string {
  if (typeof value !== "string"
    || value.length < 1
    || value.trim() !== value
    || Buffer.byteLength(value, "utf8") > 63
    || /[\0/\\. "$*<>:|?]/u.test(value)) {
    throw new Error("Runtime MongoDB database-name policy is invalid.");
  }
  return value;
}

function exactRuntimeInfrastructurePolicy(
  policy: RuntimeInfrastructurePolicy,
): RuntimeInfrastructurePolicy {
  return {
    listenPort: exactInteger(policy.listenPort, "listen-port", 1, 65_535),
    mongoPoolSize: exactInteger(policy.mongoPoolSize, "MongoDB pool-size", 1, 1_000),
    mongoDatabaseName: exactMongoDatabaseName(policy.mongoDatabaseName),
  };
}

// Resolve before the MongoClient is constructed. A malformed listener value must not be discovered
// after migrations and background-worker initialization have already changed external state.
const CONFIGURED_RUNTIME_INFRASTRUCTURE_POLICY = Object.freeze(exactRuntimeInfrastructurePolicy({
  listenPort: config.port,
  mongoPoolSize: config.mongoPoolSize,
  mongoDatabaseName: config.mongoDbName,
}));

export function runtimeInfrastructurePolicy(
  policy?: RuntimeInfrastructurePolicy,
): RuntimeInfrastructurePolicy {
  return policy === undefined
    ? CONFIGURED_RUNTIME_INFRASTRUCTURE_POLICY
    : exactRuntimeInfrastructurePolicy(policy);
}
