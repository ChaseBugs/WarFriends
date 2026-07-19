import generatedArmyPowerCatalog from "../data/armyPowerCatalog.generated.json";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";

export interface PlayerLevelDefinition {
  /** Zero-based LevelManager.GameLevel.index and DatabasePlayer.Level value. */
  index: number;
  /** One-based value shown by LevelManager.GameLevel.displayNumber. */
  displayLevel: number;
  /** XP required to leave this level; LevelManager.GameLevel.score. */
  experience: number;
  /** Gold granted when this level's XP threshold is crossed. */
  rewardGold: number;
  /** Rank contribution to LevelManager.armyPower while this level is active. */
  armyPower: number;
}

interface LevelCatalogArtifact {
  schemaVersion: number;
  clientVersion: string;
  rankLevels: PlayerLevelDefinition[];
}

const artifact = generatedArmyPowerCatalog as LevelCatalogArtifact;
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
  if (!Number.isSafeInteger(state.gold) || state.gold < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored Gold balance is invalid.");
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
  if (!Number.isSafeInteger(goldGranted) || state.gold > Number.MAX_SAFE_INTEGER - goldGranted) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Level-up Gold overflowed.");
  }

  return {
    state: {
      ...state,
      levelExperience,
      gold: state.gold + goldGranted,
    },
    experienceGranted,
    goldGranted,
    levelFrom: currentLevel,
    levelTo,
    levelExperience,
  };
}
