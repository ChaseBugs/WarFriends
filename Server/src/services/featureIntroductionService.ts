import type { PlayerFeatureIntroductionState, PlayerProgressionState } from "../db";
import { mutateProgression } from "./progressionMutationService";

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
  const current = state.featureIntroductions ?? {};
  if (current[key] === true) {
    return { state, featureIntroductions: current, changed: false };
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
