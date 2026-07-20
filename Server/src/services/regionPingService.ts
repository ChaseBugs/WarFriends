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
  if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Regions must be a JSON object.");
  }

  const source = parsed as Record<string, unknown>;
  if (Object.keys(source).length > PHOTON_REGIONS.length) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Regions contains too many entries.");
  }

  // Rebuild in the recovered canonical order. This makes storage and the public JSON stable
  // across devices even when Json.NET enumerates the original dictionary differently.
  const result: RegionPings = {};
  for (const region of PHOTON_REGIONS) {
    if (!(region in source)) continue;
    const ping = source[region];
    if (!Number.isInteger(ping) || Number(ping) < 0 || Number(ping) > MAX_PING_MILLISECONDS) {
      throw new ApiError(ApiErrorCode.UnknownAction, `Region ${region} has an invalid ping.`);
    }
    result[region] = Number(ping);
  }
  for (const region of Object.keys(source)) {
    if (!REGION_SET.has(region)) {
      throw new ApiError(ApiErrorCode.UnknownAction, `Region ${region} is not supported by this client.`);
    }
  }
  return result;
}

/** Parse the exact enum name produced by InternetConnection.ToString(). */
export function parseInternetConnection(value: unknown): number {
  if (typeof value !== "string" || !(value in CONNECTION_TYPES)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Connection is not a recovered InternetConnection value.");
  }
  return CONNECTION_TYPES[value]!;
}
