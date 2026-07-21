import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Exact region family exposed by the recovered KJMGFHMIBII matchmaking base class.
 * Keep this list closed: arbitrary JSON keys would become public profile data and could grow
 * every player document without bound. `none` is a Photon sentinel, not a routable region.
 */
export const PHOTON_REGIONS = [
  "eu",
  "us",
  "asia",
  "jp",
  "au",
  "usw",
  "sa",
  "cae",
  "kr",
  "in",
] as const;

export type PhotonRegion = typeof PHOTON_REGIONS[number];
export type RegionPings = Partial<Record<PhotonRegion, number>>;

const REGION_SET = new Set<string>(PHOTON_REGIONS);
const MAX_REGIONS_JSON_LENGTH = 1_024;
const MAX_PING_MILLISECONDS = 60_000;

/** Recovered InternetConnection enum: None=0, Cellural=1, Wifi=2. */
const CONNECTION_TYPES: Record<string, number> = {
  None: 0,
  Cellural: 1,
  Wifi: 2,
};

function canonicalRegionPings(
  value: unknown,
  invalid: (message: string) => Error,
): RegionPings {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw invalid("Regions must be an object.");
  }

  const prototype = Object.getPrototypeOf(value);
  if (prototype !== Object.prototype && prototype !== null) {
    throw invalid("Regions must be a plain object.");
  }

  const source = value as Record<string, unknown>;
  if (Object.keys(source).length > PHOTON_REGIONS.length) {
    throw invalid("Regions contains too many entries.");
  }

  // Rebuild rather than return the stored/request object. Besides producing stable public JSON,
  // this prevents inherited properties or a future caller's wider object type from becoming part
  // of the durable routing snapshot.
  const result: RegionPings = {};
  for (const region of PHOTON_REGIONS) {
    if (!Object.prototype.hasOwnProperty.call(source, region)) continue;
    const ping = source[region];
    if (!Number.isInteger(ping) || Number(ping) < 0 || Number(ping) > MAX_PING_MILLISECONDS) {
      throw invalid(`Region ${region} has an invalid ping.`);
    }
    result[region] = Number(ping);
  }
  for (const region of Object.keys(source)) {
    if (!REGION_SET.has(region)) {
      throw invalid(`Region ${region} is not supported by this client.`);
    }
  }
  return result;
}

/**
 * Validate the persisted action-140 latency snapshot before it is used or published.
 *
 * Total absence is the only legacy migration: accounts created before this field was recovered
 * behaved exactly like an empty dictionary. Once present, every key and latency is authority and
 * malformed values must fail closed rather than being dropped as though the player had capacity
 * to submit a fresh trustworthy sample.
 */
export function validatedRegionPings(value: unknown): RegionPings {
  if (value === undefined) return {};
  return canonicalRegionPings(value, (message) => new Error(`Stored ${message}`));
}

/**
 * Validate the persisted recovered InternetConnection enum.
 *
 * Connection type is not emitted by DatabasePlayer.CreateFromDatabase, so old documents may lack
 * it and safely retain the recovered None value. Unknown, fractional, or non-finite values cannot
 * be normalized: even diagnostic/routing metadata must not conceal a writer bypassing action 140.
 */
export function validatedInternetConnection(value: unknown): number {
  if (value === undefined) return CONNECTION_TYPES.None!;
  if (value !== CONNECTION_TYPES.None
    && value !== CONNECTION_TYPES.Cellural
    && value !== CONNECTION_TYPES.Wifi) {
    throw new Error("Stored Connection is not a recovered InternetConnection value.");
  }
  return Number(value);
}

export interface ValidatedPhotonRoutingSnapshot {
  bestRegions: RegionPings;
  connectionType: number;
}

/**
 * Prove that both fields belong to one action-140 sample.
 *
 * The handler persists both values in one MongoDB update, so exactly one missing field is not a
 * supported legacy state. Accepting that partial tuple would let an unrelated valid half hide a
 * damaged or bypassed write behind the default for the absent half.
 */
export function validatedPhotonRoutingSnapshot(
  bestRegions: unknown,
  connectionType: unknown,
): ValidatedPhotonRoutingSnapshot {
  const regionsAbsent = bestRegions === undefined;
  const connectionAbsent = connectionType === undefined;
  if (regionsAbsent !== connectionAbsent) {
    throw new Error("Stored Photon routing snapshot is incomplete.");
  }
  return {
    bestRegions: validatedRegionPings(bestRegions),
    connectionType: validatedInternetConnection(connectionType),
  };
}

/**
 * Parse the exact JsonConvert Dictionary<CloudRegionCode,int> emitted by action 140.
 *
 * Pings only help the stock client select a shared Photon region. They never establish match
 * ownership, combat results, or rewards. Even so, strict validation is necessary because the
 * values are persisted and later copied into public challenge/opponent snapshots.
 */
export function parseRegionPings(value: unknown): RegionPings {
  if (typeof value !== "string" || value.length > MAX_REGIONS_JSON_LENGTH) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Regions must be a bounded JSON object.");
  }

  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "Regions must be valid JSON.");
  }
  return canonicalRegionPings(
    parsed,
    (message) => new ApiError(ApiErrorCode.UnknownAction, message),
  );
}

/** Parse the exact enum name produced by InternetConnection.ToString(). */
export function parseInternetConnection(value: unknown): number {
  if (typeof value !== "string" || !(value in CONNECTION_TYPES)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Connection is not a recovered InternetConnection value.");
  }
  return CONNECTION_TYPES[value]!;
}
