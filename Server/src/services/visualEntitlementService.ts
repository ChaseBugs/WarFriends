import { ApiError, ApiErrorCode } from "../apiErrors";
import type { SavedVisualState, VisualInventoryState } from "../db";
import { VALIDATED_VISUAL_CATALOG } from "./visualCatalogAuthorityService";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const SAVED_VISUAL_KEYS = ["borrowed", "bought", "expiresOn", "notificate", "parts", "showed"] as const;
const SAVED_SLOT_KEYS = ["equippedID"] as const;

interface VisualAuthorityDefinition {
  name: string;
  categoryId: number;
  parts: number;
}

interface VisualAuthorityCategory {
  id: number;
  defaultId: string;
}

const visualDefinitions = new Map(
  VALIDATED_VISUAL_CATALOG.visuals.map((definition) => [definition.name, definition as VisualAuthorityDefinition]),
);
const visualCategories = new Map(
  VALIDATED_VISUAL_CATALOG.categories.map((category) => [String(category.id), category as VisualAuthorityCategory]),
);

function hasExactKeys(value: object, expected: readonly string[]): boolean {
  const actual = Object.keys(value).sort();
  return actual.length === expected.length && actual.every((key, index) => key === expected[index]);
}

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
  if (
    !value
    || typeof value !== "object"
    || Array.isArray(value)
    || !hasExactKeys(value, ["previousHeadDecal", "slots", "visuals"])
    || !value.visuals
    || typeof value.visuals !== "object"
    || Array.isArray(value.visuals)
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Visual inventory is invalid.");
  }
  for (const [name, saved] of Object.entries(value.visuals)) {
    const definition = visualDefinitions.get(name);
    if (
      !definition
      || !saved
      || typeof saved !== "object"
      || Array.isArray(saved)
      || !hasExactKeys(saved, SAVED_VISUAL_KEYS)
      || typeof saved.bought !== "boolean"
      || typeof saved.showed !== "boolean"
      || typeof saved.borrowed !== "boolean"
      || typeof saved.notificate !== "boolean"
      || !Number.isSafeInteger(saved.parts)
      || saved.parts < 0
      || saved.parts > definition.parts
    ) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Saved visual authority is invalid.");
    }
    validatedVisualUnixSeconds(saved.expiresOn, `Visual ${name} expiry`);
  }
  if (!value.slots || typeof value.slots !== "object" || Array.isArray(value.slots)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Visual slots are invalid.");
  }
  if (Object.keys(value.slots).length !== visualCategories.size) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Visual slots are invalid.");
  }
  for (const [slot, saved] of Object.entries(value.slots)) {
    const category = visualCategories.get(slot);
    const equipped = saved && typeof saved.equippedID === "string"
      ? visualDefinitions.get(saved.equippedID)
      : undefined;
    if (
      !category
      || !saved
      || typeof saved !== "object"
      || Array.isArray(saved)
      || !hasExactKeys(saved, SAVED_SLOT_KEYS)
      || typeof saved.equippedID !== "string"
      || !equipped
      || equipped.categoryId !== category.id
    ) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Visual slot authority is invalid.");
    }
  }
  const previousHead = value.previousHeadDecal === ""
    ? undefined
    : visualDefinitions.get(value.previousHeadDecal);
  if (
    typeof value.previousHeadDecal !== "string"
    || (value.previousHeadDecal !== "" && (!previousHead || previousHead.categoryId !== 1))
  ) {
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
