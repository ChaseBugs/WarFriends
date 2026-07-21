import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";

export interface TutorialCompletionAuthority {
  tutorialFinished: boolean;
  warcardsTutorialFinished: boolean;
}

/**
 * Validate the two ordered tutorial completion markers shared by boot and gameplay gates.
 *
 * Both fields are server-written Booleans. JavaScript truthiness is unsafe here because a damaged
 * string such as `"false"` would expose `TutorialData` and rentals while the exact Play Warcards
 * check still treats bootcamp as unfinished. The later Warcards tutorial cannot be terminal before
 * bootcamp, so that impossible ordering is rejected rather than projected as `cardTutState = 2`.
 * Only absent legacy fields retain their original false default.
 */
export function validatedTutorialCompletion(
  state: Pick<PlayerProgressionState, "tutorialFinished" | "warcardsTutorialFinished">,
): TutorialCompletionAuthority {
  const tutorialFinished = state.tutorialFinished ?? false;
  const warcardsTutorialFinished = state.warcardsTutorialFinished ?? false;
  if (typeof tutorialFinished !== "boolean" || typeof warcardsTutorialFinished !== "boolean") {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored tutorial completion state is invalid.");
  }
  if (warcardsTutorialFinished && !tutorialFinished) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored tutorial completion order is invalid.");
  }
  return { tutorialFinished, warcardsTutorialFinished };
}

/** Validate the shared progression cursor immediately before a tutorial lifecycle write. */
export function validatedTutorialRevision(revision: number): number {
  if (!Number.isSafeInteger(revision) || revision < 0 || revision === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Tutorial progression revision is invalid.");
  }
  return revision;
}
