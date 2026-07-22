import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";
import { checkedRewardBalance } from "./rewardMathService";
import {
  type PlayerLevelDefinition,
  VALIDATED_ARMY_POWER_CATALOG,
} from "./armyPowerCatalogAuthorityService";

export type { PlayerLevelDefinition } from "./armyPowerCatalogAuthorityService";

const artifact = VALIDATED_ARMY_POWER_CATALOG;
export const PLAYER_LEVELS: readonly Readonly<PlayerLevelDefinition>[] = Object.freeze(
  artifact.rankLevels.map((level) => Object.freeze({ ...level })),
);

export interface LevelExperienceResult {
  state: PlayerProgressionState;
  experienceGranted: number;
  goldGranted: number;
  levelFrom: number;
  levelTo: number;
  levelExperience: number;
}

/** Return one exact source row, rejecting corrupt stored level indexes instead of clamping. */
export function playerLevelDefinition(levelIndex: number): Readonly<PlayerLevelDefinition> {
  if (!Number.isInteger(levelIndex) || levelIndex < 0 || levelIndex >= PLAYER_LEVELS.length) {
    throw new ApiError(ApiErrorCode.InternalServerError, `Player level index ${levelIndex} is invalid.`);
  }
  return PLAYER_LEVELS[levelIndex]!;
}

/**
 * Apply XP using the exact serialized LevelManager progression rows.
 *
 * `LevelExperience` is progress within the current zero-based level. Crossing a row's
 * EXPERIENCE threshold subtracts that threshold, advances the level, and grants that row's
 * REWARDGOLD. The loop intentionally supports several level-ups in one future reward even
 * though current PvP grants are much smaller than the first 50,000-XP threshold. At the
 * final source level XP remains a lifetime overflow value because there is no next row and
 * LevelManager.GetProgress() already renders zero at max level.
 *
 * This pure transition does not increment `revision`; its caller combines it with the other
 * settlement mutations that already own exactly one progression revision.
 */
export function applyLevelExperienceState(
  state: PlayerProgressionState,
  currentLevel: number,
  experienceGranted: number,
): LevelExperienceResult {
  playerLevelDefinition(currentLevel);
  if (!Number.isSafeInteger(experienceGranted) || experienceGranted < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Granted level experience is invalid.");
  }
  if (!Number.isSafeInteger(state.levelExperience) || state.levelExperience < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored level experience is invalid.");
  }
  let levelTo = currentLevel;
  let levelExperience = state.levelExperience + experienceGranted;
  if (!Number.isSafeInteger(levelExperience)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Level experience overflowed.");
  }
  let goldGranted = 0;
  while (levelTo < PLAYER_LEVELS.length - 1) {
    const definition = playerLevelDefinition(levelTo);
    if (levelExperience < definition.experience) break;
    levelExperience -= definition.experience;
    levelTo += 1;
    goldGranted += definition.rewardGold;
  }
  // Refunded currency may leave a valid negative balance. The shared reward guard pays that debt
  // down while still rejecting a corrupt stored balance or a sum JavaScript cannot represent.
  const gold = checkedRewardBalance(state.gold, goldGranted, "Level-up Gold");

  return {
    state: {
      ...state,
      levelExperience,
      gold,
    },
    experienceGranted,
    goldGranted,
    levelFrom: currentLevel,
    levelTo,
    levelExperience,
  };
}
