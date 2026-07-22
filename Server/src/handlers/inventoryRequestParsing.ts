import { ApiError, ApiErrorCode } from "../apiErrors";

const DIRECT_PAYLOAD_MAX_LENGTH = 256_000;
const INVENTORY_NAME_MAX_LENGTH = 128;

function exactDirectString(value: unknown, field: string, maximumLength: number): string {
  if (typeof value !== "string" || value.length < 1 || value.length > maximumLength) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} is invalid.`);
  }
  return value;
}

/**
 * Resolve one replacement-client field without letting compatibility aliases become authority.
 *
 * The stock client does not call these inventory mutations directly: it places the raw value in
 * RequestBuffer.data. Direct handlers exist only for explicit diagnostic/replacement clients, so
 * they require their documented canonical field. A legacy alias may accompany that field only as
 * an exact duplicate; alias precedence or alias-only acceptance would create a second mutable wire
 * contract that the recovered client never emitted.
 */
function canonicalDirectString(
  req: Record<string, unknown>,
  canonicalField: string,
  aliases: readonly string[],
  maximumLength: number,
): string {
  const canonical = exactDirectString(req[canonicalField], canonicalField, maximumLength);
  for (const alias of aliases) {
    if (req[alias] === undefined) continue;
    const duplicate = exactDirectString(req[alias], alias, maximumLength);
    if (duplicate !== canonical) {
      throw new ApiError(ApiErrorCode.UnknownAction, `${canonicalField} fields conflict.`);
    }
  }
  return canonical;
}

/** Exact outer JSON text for the direct BuyDecal replacement-client route. */
export function requestedDirectVisualPurchase(req: Record<string, unknown>): string {
  return canonicalDirectString(req, "ObjData", ["Data", "data"], DIRECT_PAYLOAD_MAX_LENGTH);
}

/** Exact visual identity for direct EquipDecal and VisualWasShown replacement routes. */
export function requestedDirectVisualName(req: Record<string, unknown>): string {
  return canonicalDirectString(
    req,
    "DecalId",
    ["Name", "Data", "data"],
    INVENTORY_NAME_MAX_LENGTH,
  );
}

/** Exact item identity for direct WeaponWasShown and ArmyUnitWasShown replacement routes. */
export function requestedDirectInventoryName(req: Record<string, unknown>): string {
  return canonicalDirectString(
    req,
    "LevelName",
    ["Name", "Data", "data"],
    INVENTORY_NAME_MAX_LENGTH,
  );
}
