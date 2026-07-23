import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";

function withoutUndefined(value: unknown, path: string): unknown {
  if (Array.isArray(value)) {
    return value.map((item, index) => {
      if (item === undefined) {
        throw new ApiError(ApiErrorCode.InternalServerError, `${path}[${index}] is undefined.`);
      }
      return withoutUndefined(item, `${path}[${index}]`);
    });
  }
  if (value && typeof value === "object") {
    const result: Record<string, unknown> = {};
    for (const [key, item] of Object.entries(value as Record<string, unknown>)) {
      // MongoDB serializes an explicit JavaScript undefined as BSON null by default. Every
      // optional progression field uses absence, while null is deliberately rejected by the
      // durable validators. Omit the property recursively before replacing the subdocument.
      if (item !== undefined) result[key] = withoutUndefined(item, `${path}.${key}`);
    }
    return result;
  }
  return value;
}

/** Build the exact BSON-safe full-replacement form of one validated progression successor. */
export function progressionStateForStorage(state: PlayerProgressionState): PlayerProgressionState {
  // `dogTags` is an obsolete count-based reconstruction field and is never republished.
  const { dogTags: _legacyDogTags, ...current } = state;
  return withoutUndefined(current, "progression") as PlayerProgressionState;
}
