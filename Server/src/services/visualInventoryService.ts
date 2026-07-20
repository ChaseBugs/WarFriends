import generatedVisualCatalog from "../data/visualCatalog.generated.json";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  PlayerProgressionState,
  SavedVisualState,
  VisualInventoryState,
} from "../db";

// Exact IJEAJGCCHEF values handled by the recovered BuyDecal/EquipDecal response branches.
export const VISUAL_NOT_ENOUGH_WARBUCKS = 100;
export const VISUAL_NOT_ENOUGH_LEVEL = 101;
export const VISUAL_NOT_ENOUGH_GOLD = 103;
export const VISUAL_NOT_BOUGHT = 107;
export const VISUAL_CATEGORY_NOT_FOUND = 108;
export const VISUAL_ONLY_FOR_VIP = 109;
export const VISUAL_NO_DISCOUNT_FOUND = 13601;

interface VisualDefinition {
  name: string;
  unlockLevel: number;
  priceWarBucks: number;
  priceGold: number;
  durationSeconds: number;
  effectType: number;
  effectValue: number;
  categoryId: number;
  vipOnly: boolean;
  purchasable: string;
  rarity: number;
  parts: number;
  duplicateWarBucks: number;
}

interface VisualCategoryDefinition {
  id: number;
  name: string;
  prefix: string;
  defaultId: string;
  ids: string[];
}

interface VisualCatalogArtifact {
  schemaVersion: number;
  clientVersion: string;
  source: string;
  sourceSha256: string;
  categories: VisualCategoryDefinition[];
  visuals: VisualDefinition[];
}

export interface VisualPurchasePayload {
  name: string;
  warBucks: number;
  gold: number;
  discount: number;
  startTime: number;
}

export interface VisualMutationResult {
  state: PlayerProgressionState;
  visualInventory: VisualInventoryState;
  definition: VisualDefinition;
  expiresOn: number;
}

export interface VisualRewardResult {
  state: PlayerProgressionState;
  visualInventory: VisualInventoryState;
  definition: VisualDefinition;
}

const artifact = generatedVisualCatalog as VisualCatalogArtifact;
export const VISUAL_CATALOG: Readonly<Record<string, Readonly<VisualDefinition>>> = Object.freeze(
  Object.fromEntries(artifact.visuals.map((definition) => [definition.name, Object.freeze({ ...definition })])),
);
const CATEGORY_CATALOG = Object.freeze(Object.fromEntries(
  artifact.categories.map((category) => [category.id, Object.freeze({ ...category, ids: Object.freeze([...category.ids]) })]),
)) as Readonly<Record<number, Readonly<VisualCategoryDefinition>>>;

function emptySavedVisual(): SavedVisualState {
  return { bought: false, showed: false, expiresOn: 0, borrowed: false, parts: 0, notificate: false };
}

/** New accounts equip the first serialized visual from each of the four scene categories. */
export function createInitialVisualInventory(): VisualInventoryState {
  return {
    // Keep this dictionary sparse. CamosManager.InitVisuals creates missing entries locally,
    // while the server materializes a row only after a real state mutation. This avoids
    // storing 146 identical empty objects on every account.
    visuals: {},
    slots: Object.fromEntries(
      artifact.categories.map((category) => [String(category.id), { equippedID: category.defaultId }]),
    ),
    previousHeadDecal: "",
  };
}

function cloneVisualInventory(value: VisualInventoryState): VisualInventoryState {
  return {
    visuals: Object.fromEntries(Object.entries(value.visuals).map(([key, item]) => [key, { ...item }])),
    slots: Object.fromEntries(Object.entries(value.slots).map(([key, item]) => [key, { ...item }])),
    previousHeadDecal: value.previousHeadDecal,
  };
}

export function visualInventoryStateFor(state: PlayerProgressionState): VisualInventoryState {
  return cloneVisualInventory(state.visualInventory ?? createInitialVisualInventory());
}

/**
 * Grant a permanent visual selected by a reviewed event definition.
 *
 * Shop rows still belong to BuyDecal, while hidden/Arena/VIP rows require their own recovered
 * entitlement paths. Event Assignment configuration may reference only the two source catalog
 * families that explicitly identify event/assignment rewards. This helper deliberately does
 * not increment progression revision; the enclosing claim owns the atomic wallet/state write.
 */
export function grantEventAssignmentVisualState(
  state: PlayerProgressionState,
  name: string,
): VisualRewardResult {
  const definition = VISUAL_CATALOG[name];
  if (!definition || (definition.purchasable !== "event" && definition.purchasable !== "assignment")) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Event Assignment visual is not reward-eligible.");
  }
  const visualInventory = visualInventoryStateFor(state);
  const saved = visualInventory.visuals[name];
  visualInventory.visuals[name] = {
    ...(saved ?? emptySavedVisual()),
    bought: true,
    borrowed: false,
    expiresOn: 0,
    notificate: true,
  };
  return {
    state: { ...state, visualInventory },
    visualInventory,
    definition,
  };
}

function objectJson(value: string): Record<string, unknown> {
  if (value.length < 2 || value.length > 64_000) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Visual request data is invalid.");
  }
  let parsed: unknown;
  try {
    parsed = JSON.parse(value);
  } catch {
    throw new ApiError(ApiErrorCode.UnknownAction, "Visual request data is invalid JSON.");
  }
  if (!parsed || typeof parsed !== "object" || Array.isArray(parsed)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Visual request data must be an object.");
  }
  return parsed as Record<string, unknown>;
}

function integer(value: unknown, field: string): number {
  const parsed = Number(value);
  if (!Number.isInteger(parsed)) throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be an integer.`);
  return parsed;
}

function visualName(value: unknown): string {
  if (typeof value !== "string" || value.length < 1 || value.length > 128) {
    throw new ApiError(VISUAL_CATEGORY_NOT_FOUND, "Visual name is invalid.");
  }
  return value;
}

/** Decode the exact dictionary queued by CamosScreen.BuyPlayerVisual. */
export function parseVisualPurchaseData(value: string): VisualPurchasePayload {
  const data = objectJson(value);
  return {
    name: visualName(data.Name),
    warBucks: integer(data.Warbucks, "Warbucks"),
    gold: integer(data.Gold, "Gold"),
    discount: integer(data.discount ?? 0, "discount"),
    startTime: integer(data.StartTime, "StartTime"),
  };
}

export function requestedVisualName(value: string): string {
  try {
    const parsed = JSON.parse(value) as Record<string, unknown>;
    return typeof parsed?.Name === "string" ? parsed.Name : value;
  } catch {
    return value;
  }
}

function ownsVisual(
  definition: VisualDefinition,
  saved: SavedVisualState | undefined,
  now: number,
): boolean {
  // The client treats zero-price shop defaults as owned without setting `bought`.
  if (definition.purchasable === "shop" && definition.priceGold === 0 && definition.priceWarBucks === 0) {
    return true;
  }
  // MainScene's ServerRentalVisualProbability is exactly zero. Weapon/unit rentals have a
  // dedicated authority path, but a borrowed visual remains invalid unless future source
  // data enables and defines that family.
  if (saved?.borrowed) return false;
  if (definition.durationSeconds > 0) return (saved?.expiresOn ?? 0) > now;
  return saved?.bought === true || (definition.parts > 0 && (saved?.parts ?? 0) >= definition.parts);
}

/**
 * Purchase one source-authoritative shop visual.
 *
 * Client prices and discounts are assertions only. Non-shop rows (Arena, events, loyalty,
 * assignments, value packs, and hidden assets) remain closed until their own reward or
 * entitlement service grants them. A repeated purchase of an already permanent item is an
 * idempotent no-op, preventing a second BufferId from charging the same cosmetic twice.
 */
export function purchaseVisualState(
  state: PlayerProgressionState,
  now: number,
  playerLevelIndex: number,
  vipExpiration: number,
  payload: VisualPurchasePayload,
): VisualMutationResult {
  const definition = VISUAL_CATALOG[payload.name];
  if (!definition || definition.purchasable !== "shop") {
    throw new ApiError(VISUAL_CATEGORY_NOT_FOUND, "Visual is not available in the authoritative shop catalog.");
  }
  if (payload.discount !== 0) {
    throw new ApiError(VISUAL_NO_DISCOUNT_FOUND, "Visual discount has no server-owned entitlement.");
  }
  if (payload.startTime < 0) throw new ApiError(ApiErrorCode.UnknownAction, "Visual start time is invalid.");
  if (playerLevelIndex < definition.unlockLevel - 1) {
    throw new ApiError(VISUAL_NOT_ENOUGH_LEVEL, "Player level is below the visual unlock level.");
  }
  if (definition.vipOnly && vipExpiration <= now) {
    throw new ApiError(VISUAL_ONLY_FOR_VIP, "Visual requires an active VIP entitlement.");
  }

  // The stock BuyDecal parser has no dedicated price-mismatch branch. Return the matching
  // wallet error so it consumes the rollback wallet and DecalManagerData fields correctly.
  if (payload.warBucks !== definition.priceWarBucks) {
    throw new ApiError(VISUAL_NOT_ENOUGH_WARBUCKS, "Visual WarBucks price does not match source balancing.");
  }
  if (payload.gold !== definition.priceGold) {
    throw new ApiError(VISUAL_NOT_ENOUGH_GOLD, "Visual Gold price does not match source balancing.");
  }

  const visualInventory = visualInventoryStateFor(state);
  const saved = visualInventory.visuals[definition.name];
  if (ownsVisual(definition, saved, now)) {
    return { state, visualInventory, definition, expiresOn: saved?.expiresOn ?? 0 };
  }
  if (state.warBucks < definition.priceWarBucks) {
    throw new ApiError(VISUAL_NOT_ENOUGH_WARBUCKS, "Not enough WarBucks for this visual.");
  }
  if (state.gold < definition.priceGold) {
    throw new ApiError(VISUAL_NOT_ENOUGH_GOLD, "Not enough Gold for this visual.");
  }

  const expiresOn = definition.durationSeconds > 0 ? Math.floor(now) + definition.durationSeconds : 0;
  visualInventory.visuals[definition.name] = {
    ...(saved ?? emptySavedVisual()),
    bought: true,
    borrowed: false,
    expiresOn,
  };
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold - definition.priceGold,
    warBucks: state.warBucks - definition.priceWarBucks,
    visualInventory,
  };
  return { state: next, visualInventory, definition, expiresOn };
}

/** Equip an owned visual into the category encoded by its immutable catalog row. */
export function equipVisualState(
  state: PlayerProgressionState,
  now: number,
  name: string,
): VisualMutationResult {
  const definition = VISUAL_CATALOG[name];
  const category = definition ? CATEGORY_CATALOG[definition.categoryId] : undefined;
  const visualInventory = visualInventoryStateFor(state);
  const saved = definition ? visualInventory.visuals[definition.name] : undefined;
  if (!definition || !category) {
    throw new ApiError(VISUAL_CATEGORY_NOT_FOUND, "Visual category was not found.");
  }
  if (!ownsVisual(definition, saved, now)) {
    throw new ApiError(VISUAL_NOT_BOUGHT, "Visual is not owned or its temporary entitlement expired.");
  }

  const slotKey = String(category.id);
  const current = visualInventory.slots[slotKey]?.equippedID ?? category.defaultId;
  if (current === definition.name) {
    // EquipDecal is buffered and can be resent after a response loss. Ownership/expiry was
    // validated above, but selecting the item that already occupies its immutable category is
    // only an acknowledgement. Preserve exact state identity so the enclosing BufferId does not
    // manufacture an inventory revision for an unchanged loadout.
    return { state, visualInventory, definition, expiresOn: saved?.expiresOn ?? 0 };
  }
  // The client uses previousHeadDecal to restore a normal helmet after an Arena helmet expires.
  if (category.id === 1 && definition.purchasable === "arena") {
    const currentDefinition = VISUAL_CATALOG[current];
    if (currentDefinition && currentDefinition.purchasable !== "arena") {
      visualInventory.previousHeadDecal = current;
    }
  }
  visualInventory.slots[slotKey] = { equippedID: definition.name };
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    visualInventory,
  };
  return { state: next, visualInventory, definition, expiresOn: saved?.expiresOn ?? 0 };
}

/** Persist the UI notification acknowledgement without granting ownership. */
export function markVisualShownState(
  state: PlayerProgressionState,
  name: string,
): VisualMutationResult {
  const definition = VISUAL_CATALOG[name];
  if (!definition) throw new ApiError(VISUAL_CATEGORY_NOT_FOUND, "Visual was not found.");
  const visualInventory = visualInventoryStateFor(state);
  const current = visualInventory.visuals[definition.name];
  if (current?.showed && !current.notificate) {
    // Both DecalWasShown and VisualWasShown may report the same badge. Once `showed` is true and
    // the reward notification is cleared, another acknowledgement has no durable effect. Return
    // the clone for response serialization but retain the original progression object so
    // mutateProgression can skip the database write.
    return { state, visualInventory, definition, expiresOn: 0 };
  }
  visualInventory.visuals[definition.name] = {
    ...(current ?? emptySavedVisual()),
    showed: true,
    notificate: false,
  };
  const next: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    visualInventory,
  };
  return { state: next, visualInventory, definition, expiresOn: 0 };
}

export function serializeVisualInventory(value: VisualInventoryState): string {
  return JSON.stringify(value);
}

/** Complete rollback body consumed by the BuyDecal and EquipDecal client branches. */
export function visualRecoveryFields(state: PlayerProgressionState): Record<string, unknown> {
  return {
    Gold: state.gold,
    WarBucks: state.warBucks,
    DecalManagerData: serializeVisualInventory(visualInventoryStateFor(state)),
    // No server-owned offer was accepted; the stock NoDiscountFound branch still reads this.
    SpecialOffers: JSON.stringify({}),
  };
}
