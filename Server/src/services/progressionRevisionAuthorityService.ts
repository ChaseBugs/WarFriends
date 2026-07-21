import { ApiError, ApiErrorCode } from "../apiErrors";

/**
 * Normalize only the one source-independent legacy shape that predates progression revisions.
 *
 * An absent field means the document was written before optimistic concurrency existed and may
 * enter the migration filter as revision zero. Every value that is actually present is durable
 * server authority: coercing null, a fraction, NaN, Infinity, or an unsafe integer to zero would
 * let a damaged document compete with a legitimate revision and potentially overwrite it.
 */
export function progressionRevisionForRead(revision: unknown): number {
  if (revision === undefined) return 0;
  if (typeof revision !== "number" || !Number.isSafeInteger(revision) || revision < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored progression revision is invalid.");
  }
  return revision;
}

/**
 * Prove that a state-changing transition produced a usable optimistic-concurrency successor.
 *
 * Most actions advance by one. SendRequestBuffer can compose several recovered actions before one
 * MongoDB replacement, so requiring exactly one would reject a valid atomic batch. Requiring a
 * strictly larger safe integer preserves ordering while rejecting unchanged, decreasing, wrapped,
 * or non-finite revisions before they can be published.
 */
export function validateProgressionRevisionAdvance(current: number, next: unknown): number {
  const validatedCurrent = progressionRevisionForRead(current);
  const validatedNext = progressionRevisionForRead(next);
  if (validatedNext <= validatedCurrent) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Progression revision did not advance safely.");
  }
  return validatedNext;
}
