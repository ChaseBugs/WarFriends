import { ApiError, ApiErrorCode } from "../apiErrors";
import type { SavedVisualState, VisualInventoryState } from "../db";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;

/** Validate a timed-cosmetic deadline before it participates in ownership or persistence. */
export function validatedVisualUnixSeconds(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_DATE_UNIX_SECONDS) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${field} is invalid.`);
  }
  return value;
}

/**
 * Validate the complete recovered DecalManagerData authority snapshot.
 *
 * Timed visuals, completed-part ownership, and equipped slots all live in this client object.
 * Validating it before cloning or boot serialization prevents imported non-finite deadlines or
 * counters from becoming permanent cosmetics and prevents malformed slot values from leaking to
 * the stock parser.
 */
export function validatedVisualInventoryState(
  value: VisualInventoryState | undefined,
): VisualInventoryState | undefined {
  if (value === undefined) return undefined;
  if (!value.visuals || typeof value.visuals !== "object" || Array.isArray(value.visuals)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Visual inventory is invalid.");
  }
  for (const [name, saved] of Object.entries(value.visuals)) {
    if (
      name.length === 0
      || name.length > 256
      || !saved
      || typeof saved.bought !== "boolean"
      || typeof saved.showed !== "boolean"
      || typeof saved.borrowed !== "boolean"
      || typeof saved.notificate !== "boolean"
      || !Number.isSafeInteger(saved.parts)
      || saved.parts < 0
    ) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Saved visual authority is invalid.");
    }
    validatedVisualUnixSeconds(saved.expiresOn, `Visual ${name} expiry`);
  }
  if (!value.slots || typeof value.slots !== "object" || Array.isArray(value.slots)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Visual slots are invalid.");
  }
  for (const [slot, saved] of Object.entries(value.slots)) {
    if (
      !/^\d{1,3}$/.test(slot)
      || !saved
      || typeof saved.equippedID !== "string"
      || saved.equippedID.length === 0
      || saved.equippedID.length > 256
    ) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Visual slot authority is invalid.");
    }
  }
  if (typeof value.previousHeadDecal !== "string" || value.previousHeadDecal.length > 256) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Previous head visual is invalid.");
  }
  return value;
}

/** Check one timed visual without allowing `Infinity > now` to become permanent ownership. */
export function hasActiveTimedVisual(saved: SavedVisualState | undefined, now: number, name: string): boolean {
  const currentTime = validatedVisualUnixSeconds(now, "Visual comparison time");
  const expiry = validatedVisualUnixSeconds(saved?.expiresOn ?? 0, `Visual ${name} expiry`);
  return expiry > currentTime;
}
