import { createHash } from "node:crypto";
import type {
  BlackMarketOfferState,
  BlackMarketOfferedWeaponState,
  PlayerProgressionState,
} from "../db";
import { WEAPON_BLACK_MARKET_PRICES } from "../data/weaponUpgradeCatalog.generated";
import { BLACK_MARKET_WEAPON_CATALOG } from "./itemInventoryService";
import { mutateProgression } from "./progressionMutationService";

/**
 * Recovered Black Market offer lifecycle.
 *
 * Action 217 has no request fields. Its response contains `BlackMarketOffer`, a JSON string
 * whose four public fields are loaded by BlackMarketManager.BlackMarketOfferData. Buying one
 * of those weapons does not use a dedicated action: WeaponScreen queues the normal buffered
 * BuyWeapon action with Warbucks=0 and the selected level's WEAPONPRICE as Gold.
 *
 * The original production selection weights and trigger scheduler lived remotely and are no
 * longer present in the recovered client. This implementation therefore uses a deliberately
 * bounded, deterministic replacement: four unowned supported weapons for 24 hours, at the
 * player's current zero-based progression level (clamped to each weapon table). Determinism
 * makes concurrent/retried reads return the same set; stored state, not the hash, remains the
 * purchase authority. The reconstructed selection rule is documented in BACKEND_FEATURES.md
 * and can later be swapped without changing the wire contract or redemption validation.
 */

export const BLACK_MARKET_OFFER_SECONDS = 24 * 60 * 60;
export const BLACK_MARKET_OFFER_COUNT = 4;

export interface BlackMarketMutationResult {
  state: PlayerProgressionState;
  blackMarket: BlackMarketOfferState;
  issued: boolean;
}

function hasActiveOffer(value: BlackMarketOfferState | undefined, now: number): boolean {
  return Boolean(
    value
      && Number.isInteger(value.offerEnd)
      && value.offerEnd > now
      && Array.isArray(value.currentOffers),
  );
}

/**
 * Produce a stable per-player ordering without global mutable RNG state.
 *
 * The seed includes the issue sequence and UTC day. It is used only for fair distribution;
 * the complete chosen set is persisted before being returned, so a later retry never relies
 * on reproducing the hash and cannot rotate offers by resubmitting action 217.
 */
function offerOrderKey(playerId: string, issue: number, now: number, weaponId: string): string {
  const day = Math.floor(now / 86_400);
  return createHash("sha256")
    .update(`${playerId}:${issue}:${day}:${weaponId}`)
    .digest("hex");
}

function offeredWeapon(weaponId: string, playerLevel: number): BlackMarketOfferedWeaponState | null {
  const prices = WEAPON_BLACK_MARKET_PRICES[weaponId];
  if (!prices || prices.length === 0) return null;

  // DatabasePlayer.Level is the same zero-based levelNumber used elsewhere in the recovered
  // LevelManager. BlackMarketManager passes this `level` directly to SavedWeapon.boughtIndex.
  const level = Math.min(prices.length - 1, Math.max(0, Math.floor(playerLevel)));
  if (!Number.isInteger(prices[level]) || prices[level]! < 0) return null;
  return { weaponId, level, special: 0 };
}

/**
 * Pure state transition used by action 217 and unit tests.
 *
 * Active state is returned with the exact input progression identity. Once
 * expired, owned/starter/unresolved weapon rows are excluded, then at most four candidates
 * are selected. An empty set is still persisted with an expiry so accounts owning the full
 * supported catalog cannot spam generation or receive invalid duplicate purchases.
 */
export function ensureBlackMarketOfferState(
  state: PlayerProgressionState,
  playerId: string,
  playerLevel: number,
  now: number,
): BlackMarketMutationResult {
  if (hasActiveOffer(state.blackMarket, now)) {
    return {
      // Action 217 is both an issuance request and a read of the current set. A reconnect must
      // not rotate offers, advance progression revision, or replace identical MongoDB state.
      state,
      blackMarket: state.blackMarket!,
      issued: false,
    };
  }

  const owned = state.itemInventory?.levelManagerData.savedWeapons ?? {};
  const issue = Math.max(0, Math.floor(state.blackMarket?.offersTotal ?? 0)) + 1;
  const currentOffers = Object.values(BLACK_MARKET_WEAPON_CATALOG)
    // Two recovered LevelManager rows have no WEAPONPRICE column and therefore cannot be
    // sold safely; offeredWeapon returns null for them. Nine additional balancing rows have
    // no concrete LevelManager setup and never enter this runtime catalog at all.
    .filter((definition) => !owned[definition.name]?.bought)
    .map((definition) => ({
      offer: offeredWeapon(definition.name, playerLevel),
      order: offerOrderKey(playerId, issue, now, definition.name),
    }))
    .filter((entry): entry is { offer: BlackMarketOfferedWeaponState; order: string } => entry.offer !== null)
    .sort((left, right) => left.order.localeCompare(right.order))
    .slice(0, BLACK_MARKET_OFFER_COUNT)
    .map((entry) => entry.offer);

  const blackMarket: BlackMarketOfferState = {
    offersTotal: issue,
    lastTrigger: "ServerSchedule",
    offerEnd: now + BLACK_MARKET_OFFER_SECONDS,
    currentOffers,
  };
  return {
    state: { ...state, revision: state.revision + 1, blackMarket },
    blackMarket,
    issued: true,
  };
}

/** Persist or read the authenticated player's current offer set with revision protection. */
export async function getOrCreateBlackMarketOffer(
  playerId: string,
  playerLevel: number,
): Promise<BlackMarketMutationResult> {
  return mutateProgression(playerId, (state, now) => (
    ensureBlackMarketOfferState(state, playerId, playerLevel, now)
  ));
}

/**
 * Serialize only the exact public Unity model. Explicit projection prevents future private
 * validation fields from accidentally becoming part of the client contract.
 */
export function serializeBlackMarketOffer(value: BlackMarketOfferState): string {
  return JSON.stringify({
    offersTotal: value.offersTotal,
    lastTrigger: value.lastTrigger,
    offerEnd: value.offerEnd,
    currentOffers: value.currentOffers.map((offer) => ({
      level: offer.level,
      special: offer.special,
      weaponId: offer.weaponId,
    })),
  });
}
