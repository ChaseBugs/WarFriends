import { ApiError, ApiErrorCode } from "../apiErrors";

export interface SquadLevelDefinition {
  level: number;
  experience: number;
  size: number;
  cardPoolSize: number;
}

interface SquadProgressionCatalog {
  squadLevelDefinitions?: unknown;
  cardPoolRules?: {
    capacityBySquadLevel?: unknown;
  };
}

export const EXPECTED_SQUAD_LEVEL_COUNT = 50;

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

/**
 * Validate the complete duplicated Squad-rank authority in the generated card artifact.
 *
 * MainScene contains exactly levels 1 through 50. Merely accepting a nonempty contiguous prefix
 * would let a truncated generated file redefine the final Squad rank at startup. CARDPOOLSIZE is
 * also emitted twice for legacy card-pool consumers, so both copies must remain identical;
 * otherwise two backend paths could authorize different capacities for the same durable rank.
 * This pure validator intentionally does not import the card artifact, allowing the complete card
 * authority to own one snapshot without a card-catalog/Squad-progression module cycle.
 */
export function validatedSquadProgressionCatalog(catalog: unknown): readonly Readonly<SquadLevelDefinition>[] {
  if (!catalog || typeof catalog !== "object" || Array.isArray(catalog)) {
    return invalid("Squad progression catalog root is invalid.");
  }
  const candidate = catalog as SquadProgressionCatalog;
  const definitions = candidate.squadLevelDefinitions;
  const capacities = candidate.cardPoolRules?.capacityBySquadLevel;
  if (!Array.isArray(definitions) || definitions.length !== EXPECTED_SQUAD_LEVEL_COUNT) {
    return invalid(`Squad progression catalog must contain exactly ${EXPECTED_SQUAD_LEVEL_COUNT} rows.`);
  }
  if (!Array.isArray(capacities) || capacities.length !== EXPECTED_SQUAD_LEVEL_COUNT) {
    return invalid(`Squad card-pool catalog must contain exactly ${EXPECTED_SQUAD_LEVEL_COUNT} capacities.`);
  }
  for (let index = 0; index < definitions.length; index += 1) {
    const row = definitions[index] as Partial<SquadLevelDefinition> | null;
    const previous = index > 0
      ? definitions[index - 1] as Partial<SquadLevelDefinition> | null
      : null;
    if (!row
      || typeof row !== "object"
      || Array.isArray(row)
      || row.level !== index + 1
      || !Number.isSafeInteger(row.experience)
      || (row.experience as number) < 1
      || !Number.isSafeInteger(row.size)
      || (row.size as number) < 1
      || !Number.isSafeInteger(row.cardPoolSize)
      || (row.cardPoolSize as number) < 1
      || (previous !== null && (row.experience as number) < (previous.experience as number))
      || (previous !== null && (row.size as number) < (previous.size as number))
      || (previous !== null && (row.cardPoolSize as number) < (previous.cardPoolSize as number))
      || capacities[index] !== row.cardPoolSize) {
      return invalid(`Squad progression catalog row ${index + 1} is invalid.`);
    }
  }
  return Object.freeze(definitions.map((row) => Object.freeze({
    level: (row as SquadLevelDefinition).level,
    experience: (row as SquadLevelDefinition).experience,
    size: (row as SquadLevelDefinition).size,
    cardPoolSize: (row as SquadLevelDefinition).cardPoolSize,
  })));
}
