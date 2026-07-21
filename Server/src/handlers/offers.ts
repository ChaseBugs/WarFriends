import { ApiError } from "../apiErrors";
import { DbAction } from "../dbActions";
import { authed, type HandlerEntry } from "./types";

/** Exact IJEAJGCCHEF.NoOffers used by the recovered action-135 contract. */
export const SPECIAL_OFFERS_UNAVAILABLE = 13_501;

/** Exact IJEAJGCCHEF.NoDiscountFound used when no accepted offer authorizes a discount. */
export const SPECIAL_OFFER_NOT_ACCEPTABLE = 13_601;

/**
 * Explicit fail-closed routes for the retired Fusebox special-offer lifecycle.
 *
 * GenerateSpecialOffer echoes `finish`, `discount`, `dbKey`, and `offerName` chosen by the client
 * after a Fusebox callback. Those values describe a proposal; they do not prove that the retired
 * service issued it or define the purchase mutations returned later in RequestsResults. Neither
 * recovered APK contains that service-side definition set. Registering the routes still matters:
 * callers now receive the exact recovered errors instead of generic action 90, while no modified
 * client can manufacture a discount or make AcceptSpecialOffer return false success.
 */
export const offerHandlers: Record<number, HandlerEntry> = {
  [DbAction.GenerateSpecialOffer]: authed(async () => {
    throw new ApiError(
      SPECIAL_OFFERS_UNAVAILABLE,
      "No reviewed Fusebox special-offer definition is available.",
    );
  }),

  [DbAction.AcceptSpecialOffer]: authed(async () => {
    throw new ApiError(
      SPECIAL_OFFER_NOT_ACCEPTABLE,
      "No server-owned special offer is active for this player.",
      { SpecialOffers: {} },
    );
  }),
};
