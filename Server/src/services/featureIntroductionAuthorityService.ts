import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerFeatureIntroductionState } from "../db";

/** Exact Boolean field names recovered from PlayerAnalytics.PlayerAnalyticsData. */
export const FEATURE_INTRODUCTION_KEYS = [
  "chatShown",
  "elitesShown",
  "customizationShown",
  "warpathShown",
  "cardpoolShown",
  "craftingShown",
  "leagueLeaderboardsShown",
] as const satisfies readonly (keyof PlayerFeatureIntroductionState)[];

const FEATURE_INTRODUCTION_KEY_SET = new Set<string>(FEATURE_INTRODUCTION_KEYS);

/**
 * Validate the complete server-owned feature-introduction snapshot.
 *
 * The recovered client deserializes every known member into a C# `bool`; JavaScript truthiness is
 * not compatible with that contract (`"false"`, `1`, and objects are all truthy). Unknown keys are
 * also rejected rather than carried through future mutations, because these narrow action markers
 * must never become a back door for the broad, deliberately untrusted PlayerAnalytics blob.
 * Missing legacy fields retain the recovered default `false` behavior.
 */
export function validatedFeatureIntroductions(
  value: PlayerFeatureIntroductionState | undefined,
): PlayerFeatureIntroductionState {
  if (value === undefined) return {};
  if (typeof value !== "object" || value === null || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored feature introduction state is invalid.");
  }

  for (const [key, flag] of Object.entries(value)) {
    if (!FEATURE_INTRODUCTION_KEY_SET.has(key) || typeof flag !== "boolean") {
      throw new ApiError(ApiErrorCode.InternalServerError, "Stored feature introduction state is invalid.");
    }
  }
  return value;
}
