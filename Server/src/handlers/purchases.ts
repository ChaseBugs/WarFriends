import { DbAction } from "../dbActions";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { ok } from "../dtos";
import { deliverGooglePlayPurchase, parseGooglePlayPurchaseInput } from "../services/purchaseService";
import { authed, type HandlerEntry } from "./types";

export const purchaseHandlers: Record<number, HandlerEntry> = {
  [DbAction.BuyInApp]: authed(async ({ player, req }) => {
    // The Android billing bridge sends store proof plus untrusted GoldBase/WarbucksBase hints.
    // deliverGooglePlayPurchase ignores those hints, verifies the proof with Google, and selects
    // the grant from the recovered server-side catalog under a global exactly-once token ledger.
    const input = parseGooglePlayPurchaseInput(req);
    const delivered = await deliverGooglePlayPurchase(player!.id, input);
    return ok(DbAction.BuyInApp, delivered.response);
  }),

  [DbAction.OnSubscriptionExpired]: authed(async () => {
    // SubscriptionManager calls this after its locally cached deadline. The deadline itself is
    // server-owned and already makes benefits inactive, so the client cannot shorten, extend,
    // or replace it through this parameterless notification.
    return ok(DbAction.OnSubscriptionExpired);
  }),

  [DbAction.SaveFuseConfigs]: authed(async ({ req }) => {
    // The recovered debug client can upload a `fuseData` blob, but it is not an administrator
    // credential and must never publish balancing data. Accept only a bounded telemetry-shaped
    // value for wire compatibility; live sheets come exclusively from the signed operator file.
    if (typeof req.fuseData !== "string" || req.fuseData.length > 64_000) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Fuse configuration payload is invalid.");
    }
    return ok(DbAction.SaveFuseConfigs, { Ignored: true });
  }),
};
