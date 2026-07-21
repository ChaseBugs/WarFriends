import { ApiError, ApiErrorCode } from "../apiErrors";

/** Exact 4.9.5 `WarBucksCreateSquadPrice` value decoded from MainScene. */
export const SQUAD_CREATE_BASE_WARBUCKS_COST = 25;

const MAX_CLIENT_INTEGER = 2_147_483_647;
const MAX_SQUAD_CREATION_COUNT = Math.floor(MAX_CLIENT_INTEGER / SQUAD_CREATE_BASE_WARBUCKS_COST) - 1;

/**
 * Validate the history counter that selects both the next debit and the lobby's displayed price.
 *
 * The recovered client stores the counter and computes `(count + 1) * 25` with signed C# `int`
 * arithmetic. A JavaScript-safe value can still overflow that expression on the phone, producing
 * a negative or otherwise contradictory price after boot. Only an absent legacy field defaults to
 * zero; every persisted value must keep the next source price positive and client-representable.
 */
export function validatedSquadCreationsCount(value: number | undefined): number {
  const count = value ?? 0;
  if (!Number.isSafeInteger(count) || count < 0 || count > MAX_SQUAD_CREATION_COUNT) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored squad creation count is invalid.");
  }
  return count;
}

/** Reproduce PlayerAnalytics.createSquadWarBucksPrice from validated server-owned history. */
export function squadCreationWarBucksPrice(squadCreationsCount: number): number {
  const count = validatedSquadCreationsCount(squadCreationsCount);
  return (count + 1) * SQUAD_CREATE_BASE_WARBUCKS_COST;
}
