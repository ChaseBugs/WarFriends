import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  normalizeIdentityExternalId,
  type IdentityProvider,
  validatedIdentityCredential,
  validatedIdentityDisplayName,
} from "../services/identityService";

const ID_ALIASES: Readonly<Record<IdentityProvider, readonly string[]>> = Object.freeze({
  facebook: Object.freeze(["FacebookId"]),
  googlePlay: Object.freeze(["GooglePlayId", "googlePlayId"]),
  gameCenter: Object.freeze(["GameCenterId", "gameCenterId"]),
});

const CREDENTIAL_ALIASES: Readonly<Record<IdentityProvider, readonly string[]>> = Object.freeze({
  facebook: Object.freeze(["FacebookPassword"]),
  googlePlay: Object.freeze(["GooglePlayPassword", "googlePlayPassword"]),
  gameCenter: Object.freeze(["GameCenterPassword", "gameCenterPassword"]),
});

const PROOF_ALIASES: Readonly<Record<IdentityProvider, readonly string[]>> = Object.freeze({
  facebook: Object.freeze(["ProviderProof", "FacebookProof"]),
  googlePlay: Object.freeze(["ProviderProof", "GooglePlayProof"]),
  gameCenter: Object.freeze(["ProviderProof", "GameCenterProof"]),
});

function exactAliasValue(
  req: Record<string, unknown>,
  aliases: readonly string[],
  label: string,
): string | undefined {
  const supplied = aliases
    .filter((alias) => Object.prototype.hasOwnProperty.call(req, alias))
    .map((alias) => req[alias]);
  if (supplied.length === 0) return undefined;
  // A replacement JSON client can send both legacy and camel-case aliases. They must describe one
  // byte-identical value; choosing the first would make authentication depend on object ordering.
  if (supplied.some((value) => typeof value !== "string")
    || supplied.some((value) => value !== supplied[0])) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, `${label} is invalid.`);
  }
  return supplied[0] as string;
}

/** Parse one recovered provider identity without JavaScript numeric conversion or alias fallback. */
export function exactIdentityRequestId(req: Record<string, unknown>, provider: IdentityProvider): string {
  const value = exactAliasValue(req, ID_ALIASES[provider], "External account id");
  if (value === undefined) return "";
  return normalizeIdentityExternalId(provider, value);
}

/** Preserve an opaque provider credential exactly as the recovered form request sends it. */
export function exactIdentityRequestCredential(req: Record<string, unknown>, provider: IdentityProvider): string {
  const value = exactAliasValue(req, CREDENTIAL_ALIASES[provider], "External account credential");
  if (value === undefined) return "";
  return validatedIdentityCredential(value);
}

/**
 * Parse the replacement-client proof channel independently from the recovered Password field.
 * Only Game Center has a reviewed proof contract today; accepting an unimplemented provider's
 * proof and then falling back to its legacy HMAC would falsely advertise live verification.
 */
export function exactIdentityRequestProof(
  req: Record<string, unknown>,
  provider: IdentityProvider,
): string | undefined {
  const value = exactAliasValue(req, PROOF_ALIASES[provider], "External account proof");
  if (value === undefined) return undefined;
  if (provider !== "gameCenter"
    || value.length === 0
    || value.length > 8_192
    || value.trim() !== value
    || /[\u0000-\u001f\u007f]/u.test(value)) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "External account proof is invalid.");
  }
  return value;
}

/**
 * Parse the recovered provider display-name contract without generic profile aliases.
 *
 * AddFacebook and AddGooglePlay send a mandatory `Name`; AddGameCenter and RemoveOrUpdateGC send
 * no display name and therefore retain the exact empty value. `PlayerName` is accepted only as an
 * agreeing diagnostic duplicate when canonical Name is present. It cannot become durable identity
 * metadata alone, and numeric JSON values are never stringified into a provider name.
 */
export function exactIdentityRequestDisplayName(
  req: Record<string, unknown>,
  provider: IdentityProvider,
): string {
  const hasName = Object.prototype.hasOwnProperty.call(req, "Name");
  const hasPlayerName = Object.prototype.hasOwnProperty.call(req, "PlayerName");
  if (!hasName) {
    if (hasPlayerName || provider !== "gameCenter") {
      throw new ApiError(ApiErrorCode.RequestNotAuthorized, "External account display name is invalid.");
    }
    return "";
  }

  const displayName = validatedIdentityDisplayName(req.Name);
  if ((provider === "facebook" || provider === "googlePlay") && displayName.length === 0) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "External account display name is invalid.");
  }
  if (hasPlayerName) {
    const duplicate = validatedIdentityDisplayName(req.PlayerName);
    if (duplicate !== displayName) {
      throw new ApiError(ApiErrorCode.RequestNotAuthorized, "External account display name is invalid.");
    }
  }
  return displayName;
}

/**
 * Parse the recovered RemoveOrUpdateGC selector.
 *
 * Treating every value except `1` as removal made a missing, Boolean, or malformed field unlink a
 * valid Game Center identity. Only the exact C# form strings may choose either mutation branch.
 */
export function exactHaveGameCenterId(value: unknown): boolean {
  if (value === "0") return false;
  if (value === "1") return true;
  throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Game Center identity selector is invalid.");
}
