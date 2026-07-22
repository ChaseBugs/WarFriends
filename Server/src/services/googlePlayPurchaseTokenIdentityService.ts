import { createHmac } from "crypto";
import { config } from "../config";

/**
 * Convert one opaque Play purchase token into the receipt ledger's stable private identity.
 *
 * The raw token is a bearer credential. Every producer (client purchase, RTDN, and voided-purchase
 * reconciliation) must derive the same HMAC without putting the token in an index or log. Validate
 * it here as well as at each transport parser so a future internal caller cannot hash a trimmed,
 * control-bearing, or unbounded value into durable authority.
 */
export function googlePlayPurchaseTokenReceiptId(token: unknown): string {
  if (typeof token !== "string"
    || token.length === 0
    || token.length > 4_096
    || token.trim() !== token
    || /[\u0000-\u001f\u007f]/u.test(token)) {
    throw new Error("Google Play purchase token is invalid.");
  }
  return createHmac("sha256", config.purchaseTokenHashSecret)
    .update("google-play-purchase\0", "utf8")
    .update(token, "utf8")
    .digest("hex");
}
