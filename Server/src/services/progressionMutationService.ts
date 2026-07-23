import { ApiError, ApiErrorCode } from "../apiErrors";
import { players, type PlayerProgressionState } from "../db";
import { findById } from "./playerService";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { progressionStateForStorage } from "./progressionStorageService";

const MAX_CONCURRENCY_RETRIES = 4;

export interface ProgressionMutation {
  state: PlayerProgressionState;
}

/**
 * Commit a server-owned progression transition with optimistic concurrency control.
 *
 * Economy and reward requests frequently arrive close together: for example, a client can
 * claim a daily prize while a delayed dog-tag spend is still in flight. Replacing progression
 * without a revision guard would let the last writer restore an older currency or energy
 * value. Each attempt therefore reads one revision, calculates a pure transition, and writes
 * only when that exact revision still exists. A losing request reloads the winner's state and
 * re-evaluates its validation rules before retrying.
 *
 * The legacy filters support development accounts written before `revision` or `progression`
 * existed. Their first successful mutation migrates the document to the canonical shape.
 */
export async function mutateProgression<T extends ProgressionMutation>(
  playerId: string,
  transition: (state: PlayerProgressionState, now: number) => T,
): Promise<T> {
  for (let attempt = 0; attempt < MAX_CONCURRENCY_RETRIES; attempt += 1) {
    const player = await findById(playerId);
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");

    const state = progressionForPlayer(player);
    const result = transition(state, unixNow());
    // Pure transitions return the exact input object for an idempotent replay/no-op. Returning
    // immediately avoids an unnecessary replacement and, more importantly, avoids depending on
    // MongoDB `modifiedCount` for an identical document. In a race the losing request reaches
    // this branch only after its failed revision filter causes a reload, so it observes the
    // winner's committed receipt/marker before being acknowledged.
    if (result.state === state) return result;
    // The transition is still pure at this point, so reject a corrupt successor before it can
    // enter either the MongoDB filter or replacement document. The shared proof accepts a
    // multi-step RequestBuffer revision while rejecting non-monotonic revisions and any produced
    // core balance that underflowed, overflowed, or became non-integral/non-finite.
    const canonicalState = progressionStateForStorage(result.state);
    validatedProgressionSuccessor(state, canonicalState);
    const rawRevision = player.progression?.revision;
    const progressionFilter = player.progression
      ? rawRevision === undefined
        ? { "progression.revision": { $exists: false } }
        : { "progression.revision": rawRevision }
      : { progression: { $exists: false } };

    // `dogTags` was an early count-based reconstruction field. Omitting it from every full
    // replacement turns any successful progression write into a one-way schema migration.
    const update = await players().updateOne(
      { id: playerId, ...progressionFilter },
      { $set: { progression: canonicalState, updatedAt: new Date() } },
    );
    if (update.modifiedCount === 1) {
      return { ...result, state: canonicalState };
    }
  }

  // A persistent collision is safer to fail than to apply without a guard. The client can
  // retry; no balance or claim cursor has been partially committed.
  throw new ApiError(ApiErrorCode.InternalServerError, "Concurrent progression update could not be completed.");
}
