import { ApiError, ApiErrorCode } from "../apiErrors";
import { VALIDATED_CARD_CATALOG } from "./cardCatalogAuthorityService";
import type { SquadLevelDefinition } from "./squadProgressionCatalogAuthorityService";
export {
  EXPECTED_SQUAD_LEVEL_COUNT,
  validatedSquadProgressionCatalog,
} from "./squadProgressionCatalogAuthorityService";

export interface SquadExperienceTransition {
  levelFrom: number;
  levelTo: number;
  levelExperience: number;
  maxMembers: number;
  levelsGained: number;
}

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

// The complete card-catalog boundary owns the only runtime Squad progression snapshot. Consuming
// it here prevents Squad rank logic from separately accepting a raw partial artifact that omitted
// invalid card rows, pack prices, provenance, or other fields sharing the same generated release.
const DEFINITIONS = VALIDATED_CARD_CATALOG.squadLevelDefinitions;

function validatedDefinitions(): readonly SquadLevelDefinition[] {
  return DEFINITIONS;
}

/**
 * Return one exact, one-based row from the recovered 4.9.5 `Squads` table.
 *
 * GameVariables clamps these lookups only for presentation. Durable server state is authority, so
 * accepting level 0, a fraction, NaN, or a level beyond the final row would let damaged data gain
 * the first/final roster and card-pool unlocks. Every state transition therefore uses this exact
 * lookup and fails closed instead of reproducing the UI clamp.
 */
export function squadLevelDefinition(level: number): Readonly<SquadLevelDefinition> {
  const definitions = validatedDefinitions();
  if (!Number.isSafeInteger(level) || level < 1 || level > definitions.length) {
    return invalid(`Stored squad level ${String(level)} is invalid.`);
  }
  return definitions[level - 1]!;
}

/** Prove that rank, within-rank progress, and unlocked roster capacity are one source row. */
export function validatedSquadProgressionSnapshot(
  level: number,
  levelExperience: number,
  maxMembers: number,
): void {
  const definition = squadLevelDefinition(level);
  if (!Number.isSafeInteger(levelExperience) || levelExperience < 0) {
    invalid("Stored squad level experience is invalid.");
  }
  // At the final rank there is no successor row. The recovered UI renders MAX and ignores the
  // threshold, so valid future squad points remain accumulated instead of being discarded.
  if (level < validatedDefinitions().length && levelExperience >= definition.experience) {
    invalid("Stored squad level experience has not been advanced to its earned rank.");
  }
  if (maxMembers !== definition.size) {
    invalid("Stored squad roster capacity does not match its recovered rank.");
  }
}

/**
 * Apply server-authored Squad Points to the recovered within-rank experience lifecycle.
 *
 * `AANECPGDMGM` reads `LevelExperience` as a 64-bit value and `SquadStatsContent` divides it by
 * `GameVariables.SquadExperience(Level)`. Crossing a row subtracts that row's threshold and may
 * cross more than one rank. SIZE and CARDPOOLSIZE unlocks then come from the same extracted row;
 * no reward, message payload, or live-ops value is invented here.
 */
export function applySquadExperienceState(
  level: number,
  levelExperience: number,
  maxMembers: number,
  experienceGranted: number,
): SquadExperienceTransition {
  validatedSquadProgressionSnapshot(level, levelExperience, maxMembers);
  if (!Number.isSafeInteger(experienceGranted) || experienceGranted < 0) {
    return invalid("Granted squad level experience is invalid.");
  }
  const nextExperience = levelExperience + experienceGranted;
  if (!Number.isSafeInteger(nextExperience)) {
    return invalid("Squad level experience overflowed.");
  }

  return advanceSquadExperience(level, nextExperience);
}

function advanceSquadExperience(level: number, levelExperience: number): SquadExperienceTransition {
  squadLevelDefinition(level);
  if (!Number.isSafeInteger(levelExperience) || levelExperience < 0) {
    return invalid("Stored squad level experience is invalid.");
  }

  const definitions = validatedDefinitions();
  const levelFrom = level;
  let levelTo = level;
  let remainder = levelExperience;
  while (levelTo < definitions.length) {
    const threshold = definitions[levelTo - 1]!.experience;
    if (remainder < threshold) break;
    remainder -= threshold;
    levelTo += 1;
  }

  const target = squadLevelDefinition(levelTo);
  const result = {
    levelFrom,
    levelTo,
    levelExperience: remainder,
    maxMembers: target.size,
    levelsGained: levelTo - levelFrom,
  };
  validatedSquadProgressionSnapshot(result.levelTo, result.levelExperience, result.maxMembers);
  return result;
}

/**
 * One-time bridge for rows written before the backend implemented Squad rank advancement.
 *
 * Those rows monotonically added every Squad Point to `experience` but never changed `level`, so
 * the value may legitimately exceed the current threshold and their old `maxMembers=15` was not
 * source-backed. Startup migration may roll that exact accumulated value forward and replace the
 * capacity; ordinary gameplay must use `applySquadExperienceState`, which rejects such snapshots.
 */
export function migrateLegacySquadExperienceState(
  level: number,
  accumulatedLevelExperience: number,
): SquadExperienceTransition {
  return advanceSquadExperience(level, accumulatedLevelExperience);
}

export const MAX_SQUAD_LEVEL = validatedDefinitions().length;
export const MAX_SQUAD_ROSTER_SIZE = Math.max(...validatedDefinitions().map((row) => row.size));
