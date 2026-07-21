import { ApiError, ApiErrorCode } from "../apiErrors";
import { parsePvpUsedCards } from "../services/cardInventoryService";

const CSHARP_INT32_MAX = 2_147_483_647;

/**
 * Parse a nonnegative decimal emitted by C# `int.ToString(CultureInfo.InvariantCulture)`.
 * GameEnded fields select reward-bearing mission and battle outcomes, so null, booleans, arrays,
 * blanks, signs, leading zeros, fractions, and exponent text must not become integers through
 * JavaScript coercion. Feature services still restrict the resulting value to their exact enum or
 * mission-index set.
 */
export function exactMatchInteger(value: unknown, field: string): number {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  if (!Number.isSafeInteger(parsed) || parsed < 0 || parsed > CSHARP_INT32_MAX) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an exact nonnegative C# integer.`);
  }
  return parsed;
}

/**
 * Bind the replacement transport's optional WinnerId to the recovered EndReason meaning.
 *
 * The stock 1.6.0 request sends only EndReason. WinnerId exists solely as a replacement-client
 * assertion and therefore cannot select a different participant or supply a winner for an enum
 * value that the recovered PvP contract does not recognize. Treat explicit null/non-string input
 * as malformed instead of silently falling back to EndReason through JavaScript truthiness.
 */
export function assertedPvpWinnerId(
  inferredWinnerId: string | null,
  winnerIdAlias: unknown,
): string | null {
  if (winnerIdAlias === undefined) return inferredWinnerId;
  if (typeof winnerIdAlias !== "string"
    || inferredWinnerId === null
    || winnerIdAlias !== inferredWinnerId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "WinnerId does not match the recovered EndReason result.");
  }
  return inferredWinnerId;
}

/**
 * Decode GameEnded.UsedCards while preserving the replacement client's omission shorthand.
 *
 * Stock 1.6.0 always sends a JSON string. The replacement transport may omit the field for an
 * empty list, but an explicitly present null/Boolean/object is malformed and must not become an
 * empty authoritative consumption report through nullish-coalescing or other broad defaults.
 */
export function exactGameEndedUsedCards(value: unknown): string[] {
  return parsePvpUsedCards(value === undefined ? [] : value);
}

/**
 * Resolve the stock BattleId and replacement MatchId aliases without precedence ambiguity.
 *
 * Some legacy tutorial migration deliberately reaches its service with no/empty BattleId, so this
 * boundary preserves true total absence as an empty string and leaves feature-specific nonempty
 * validation downstream. Once an alias is present, however, it must be a string; if both are
 * present they must identify the exact same durable lifecycle instead of letting MatchId silently
 * override a contradictory BattleId.
 */
export function exactMatchIdentityAliases(matchId: unknown, battleId: unknown): string {
  const aliases = [matchId, battleId].filter((value) => value !== undefined);
  if (aliases.length === 0) return "";
  if (aliases.some((value) => typeof value !== "string")) {
    throw new ApiError(ApiErrorCode.UnknownAction, "MatchId and BattleId must be exact strings when present.");
  }
  const values = aliases as string[];
  if (values.some((value) => value !== values[0])) {
    throw new ApiError(ApiErrorCode.UnknownAction, "MatchId and BattleId identify different battles.");
  }
  return values[0]!;
}
