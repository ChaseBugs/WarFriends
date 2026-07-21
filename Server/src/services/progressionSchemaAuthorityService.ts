import { ApiError, ApiErrorCode } from "../apiErrors";

export const CURRENT_PROGRESSION_SCHEMA_VERSION = 1 as const;

/**
 * Refuse to interpret an embedded progression document written for another schema.
 *
 * Repository history shows version 1 on the original progression document and its count-only
 * dog-tag predecessor. A wholly absent progression remains the separate new/legacy-account
 * fallback. Treating a missing or future embedded version as version 1 would let this build erase
 * fields it does not understand during the next full replacement, so those shapes require an
 * explicit versioned migration instead.
 */
export function validatedProgressionSchemaVersion(version: unknown): 1 {
  if (version !== CURRENT_PROGRESSION_SCHEMA_VERSION) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored progression schema version is unsupported.");
  }
  return CURRENT_PROGRESSION_SCHEMA_VERSION;
}
