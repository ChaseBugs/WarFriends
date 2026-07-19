import { createHmac, timingSafeEqual } from "crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { AccountType } from "../constants";
import { identities, type IdentityDocument, type PlayerDocument } from "../db";
import { findById, updatePlayerFields } from "./playerService";

export type IdentityProvider = IdentityDocument["provider"];

/**
 * Convert the recovered client's numeric AccountType into the stable provider key stored
 * in MongoDB. Guest accounts deliberately return null because they authenticate with the
 * server-issued player id and token instead of a third-party identity.
 */
export function providerForAccountType(accountType: number): IdentityProvider | null {
  if (accountType === AccountType.Facebook) return "facebook";
  if (accountType === AccountType.GooglePlay) return "googlePlay";
  if (accountType === AccountType.GameCenter) return "gameCenter";
  return null;
}

function accountTypeForProvider(provider: IdentityProvider): AccountType {
  if (provider === "facebook") return AccountType.Facebook;
  if (provider === "googlePlay") return AccountType.GooglePlay;
  return AccountType.GameCenter;
}

function hashCredential(provider: IdentityProvider, externalId: string, credential: string): string {
  // Third-party passwords/tokens must never be stored in plaintext. Binding all three
  // values prevents an identical provider token from producing a reusable database hash.
  return createHmac("sha256", config.authSecret).update(`${provider}:${externalId}:${credential}`).digest("hex");
}

function equalHash(a: string, b: string): boolean {
  const left = Buffer.from(a, "hex");
  const right = Buffer.from(b, "hex");
  return left.length === right.length && timingSafeEqual(left, right);
}

function normalize(value: string, label: string, maxLength: number): string {
  const normalized = value.trim();
  if (!normalized || normalized.length > maxLength) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, `${label} is invalid.`);
  }
  return normalized;
}

export async function findIdentity(provider: IdentityProvider, externalId: string): Promise<IdentityDocument | null> {
  const normalized = externalId.trim();
  return normalized ? identities().findOne({ provider, externalId: normalized }) : null;
}

export async function linkIdentity(
  playerId: string,
  provider: IdentityProvider,
  externalIdValue: string,
  credentialValue: string,
  displayName = "",
): Promise<PlayerDocument> {
  const externalId = normalize(externalIdValue, "External account id", 256);
  // OAuth/platform tokens can be substantially longer than traditional passwords. Bound
  // the input to control request cost while storing only its fixed-length HMAC digest.
  const credential = normalize(credentialValue, "External account credential", 4096);
  // Validate the owner before inserting the identity. Without this guard a malformed
  // internal call could leave an orphan identity that authenticates to no player.
  if (!(await findById(playerId))) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");

  // A provider identity may own exactly one WarFriends player. This check gives the client
  // a deterministic error before MongoDB's unique index handles a concurrent collision.
  const owner = await findIdentity(provider, externalId);
  if (owner && owner.playerId !== playerId) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "External account is already linked to another player.");
  }

  const now = new Date();
  try {
    // The second unique index is (provider, playerId), so relinking the same provider
    // updates that player's identity instead of accumulating stale external accounts.
    await identities().updateOne(
      { provider, playerId },
      {
        $set: {
          externalId,
          credentialHash: hashCredential(provider, externalId, credential),
          displayName: displayName.trim().slice(0, 100),
          updatedAt: now,
        },
        $setOnInsert: { provider, playerId, createdAt: now },
      },
      { upsert: true },
    );
  } catch (error) {
    if ((error as { code?: number }).code === 11000) {
      throw new ApiError(ApiErrorCode.RequestNotAuthorized, "External account is already linked to another player.");
    }
    throw error;
  }

  const accountType = accountTypeForProvider(provider);
  // Membership in the identity collection is authoritative. The mirrored DatabasePlayer
  // fields exist only because the recovered Unity client uses them to render connected-
  // account UI and choose its next login method.
  if (provider === "facebook") await updatePlayerFields(playerId, { accountType, facebookId: externalId });
  if (provider === "googlePlay") await updatePlayerFields(playerId, { accountType, googlePlayId: externalId });
  if (provider === "gameCenter") await updatePlayerFields(playerId, { accountType, gameCenterId: externalId });
  const player = await findById(playerId);
  if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  return player;
}

export async function unlinkIdentity(playerId: string, provider: IdentityProvider): Promise<PlayerDocument> {
  // Delete the login credential first, then clear the client-facing mirror. If a later
  // player update fails, the removed credential still cannot be used to access the account.
  await identities().deleteOne({ provider, playerId });

  // Removing Facebook must not force guest mode when Google Play or Game Center remains
  // linked (and likewise for the other providers). Prefer a remaining provider and use the
  // permanent guest token only when no external login is left.
  const remainingIdentity = await identities().findOne({ playerId });
  const fallbackType = remainingIdentity ? accountTypeForProvider(remainingIdentity.provider) : AccountType.Guest;
  if (provider === "facebook") await updatePlayerFields(playerId, { accountType: fallbackType, facebookId: -1 });
  if (provider === "googlePlay") await updatePlayerFields(playerId, { accountType: fallbackType, googlePlayId: "" });
  if (provider === "gameCenter") await updatePlayerFields(playerId, { accountType: fallbackType, gameCenterId: "" });
  const player = await findById(playerId);
  if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
  return player;
}

export async function authenticateIdentity(
  provider: IdentityProvider,
  externalIdValue: string,
  credentialValue: string,
): Promise<PlayerDocument | null> {
  const externalId = externalIdValue.trim();
  const credential = credentialValue.trim();
  if (!externalId || !credential) return null;
  const identity = await findIdentity(provider, externalId);
  // Compare fixed-length HMAC values with timingSafeEqual so credential checks do not leak
  // the first mismatching byte through response timing.
  if (!identity || !equalHash(identity.credentialHash, hashCredential(provider, externalId, credential))) return null;
  return findById(identity.playerId);
}
