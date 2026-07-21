import type { IdentityDocument } from "../db";

export type IdentityProviderKey = IdentityDocument["provider"];

const signedLongMinimum = -(1n << 63n);
const signedLongMaximum = (1n << 63n) - 1n;

/**
 * Return the exact external-id text that can be stored, indexed, hashed, and mirrored.
 *
 * Facebook crosses the recovered 1.6.0 client as `long.ToString(InvariantCulture)`, so accepting
 * JavaScript numbers above MAX_SAFE_INTEGER or alternate textual spellings would bind credentials
 * to an ID different from the one Unity parses. Google Play and Game Center are string fields, but
 * they still use one trimmed, nonempty, bounded key so the unique index and HMAC see one identity.
 */
export function validatedConnectedIdentityExternalId(
  provider: IdentityProviderKey,
  value: unknown,
): string {
  if (typeof value !== "string") throw new Error("Provider external account id is invalid.");
  const externalId = value.trim();
  if (!externalId || externalId.length > 256 || externalId !== value) {
    throw new Error("Provider external account id is invalid.");
  }
  if (provider !== "facebook") return externalId;
  if (!/^-?(?:0|[1-9][0-9]{0,18})$/u.test(externalId)) {
    throw new Error("Facebook external account id is invalid.");
  }
  const parsed = BigInt(externalId);
  if (
    parsed < signedLongMinimum
    || parsed > signedLongMaximum
    || parsed === -1n
    || parsed.toString() !== externalId
  ) {
    throw new Error("Facebook external account id is invalid.");
  }
  return externalId;
}

/** Validate the recovered Facebook DTO field while preserving exact numeric -1 as disconnection. */
export function validatedFacebookPlayerId(value: unknown): string {
  if (value === -1) return "-1";
  if (typeof value === "number") {
    if (!Number.isSafeInteger(value)) throw new Error("Stored Facebook player id is invalid.");
    return validatedConnectedIdentityExternalId("facebook", String(value));
  }
  if (value === "-1") {
    // Full-profile publishers use the numeric sentinel so savePlayer can reliably unset the
    // sparse root index. Accepting string -1 would leave an indexed pseudo-provider behind.
    throw new Error("Stored Facebook disconnected sentinel is invalid.");
  }
  return validatedConnectedIdentityExternalId("facebook", value);
}

/** Validate a Google Play/Game Center DTO field, including its exact empty disconnection state. */
export function validatedOptionalStringPlayerId(
  provider: Exclude<IdentityProviderKey, "facebook">,
  value: unknown,
): string {
  if (value === "") return "";
  return validatedConnectedIdentityExternalId(provider, value);
}
