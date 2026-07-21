import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerFeatureIntroductionState, PlayerProgressionState } from "../db";
import { mutateProgression } from "./progressionMutationService";
import { validatedFeatureIntroductions } from "./featureIntroductionAuthorityService";

export type FeatureIntroductionKey = keyof PlayerFeatureIntroductionState;

export interface FeatureIntroductionResult {
  state: PlayerProgressionState;
  featureIntroductions: PlayerFeatureIntroductionState;
  changed: boolean;
}

/**
 * Persist one recovered feature-introduction acknowledgement monotonically.
 *
 * Every corresponding stock request is parameterless and the client sets the same local boolean
 * to true before sending it. There is no legitimate false transition, so accepting a client blob
 * or toggle would allow old/out-of-order requests to reopen already completed onboarding UI.
 */
export function markFeatureIntroductionState(
  state: PlayerProgressionState,
  key: FeatureIntroductionKey,
): FeatureIntroductionResult {
  const current = validatedFeatureIntroductions(state.featureIntroductions);
  if (current[key] === true) {
    return { state, featureIntroductions: current, changed: false };
  }
  if (!Number.isSafeInteger(state.revision) || state.revision < 0 || state.revision === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      "Feature introduction progression revision is invalid.",
    );
  }
  const featureIntroductions = { ...current, [key]: true };
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      featureIntroductions,
    },
    featureIntroductions,
    changed: true,
  };
}

export function markFeatureIntroduction(
  playerId: string,
  key: FeatureIntroductionKey,
): Promise<FeatureIntroductionResult> {
  return mutateProgression(playerId, (state) => markFeatureIntroductionState(state, key));
}
