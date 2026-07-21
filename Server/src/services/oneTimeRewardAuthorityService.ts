import { ApiError, ApiErrorCode } from "../apiErrors";

const MAX_COLLECTED_REWARD_MARKERS = 256;
const MAX_REWARD_ID_LENGTH = 128;

/**
 * Validate the durable dictionary shared by backend replay authority and PlayerAnalytics boot.
 *
 * The recovered client decides collection with `Dictionary.ContainsKey`, while the backend grants
 * only when a marker is absent. Accepting a present value other than exact integer `1` creates a
 * split decision: Unity hides the reward, but `value === 1` is false and the server pays again.
 * Unknown bounded keys are retained because retired live-ops rows may have legitimately marked
 * rewards that this offline server no longer enables; only their shape and presence semantics are
 * authority here. Size and identifier bounds also keep this boot-projected object wire-safe.
 */
export function validatedCollectedRewards(
  value: Record<string, number> | undefined,
): Record<string, number> {
  if (value === undefined) return {};
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Collected reward markers are invalid.");
  }
  const entries = Object.entries(value);
  if (entries.length > MAX_COLLECTED_REWARD_MARKERS) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Collected reward markers are oversized.");
  }
  for (const [id, marker] of entries) {
    if (id.length < 1
      || id.length > MAX_REWARD_ID_LENGTH
      || id !== id.trim()
      || /\p{Cc}/u.test(id)
      || marker !== 1) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Collected reward marker is invalid.");
    }
  }
  return Object.fromEntries(entries);
}
