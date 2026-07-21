import { createHmac, timingSafeEqual } from "crypto";
import type { ClientSession } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { AccountType } from "../constants";
import { identities, withMongoTransaction, type IdentityDocument, type PlayerDocument } from "../db";
import { findById, updatePlayerFields } from "./playerService";
import { authenticationCredentialSecrets } from "./authSecretService";
import { validatedPlayerProfileMirrors } from "./playerProfileMirrorAuthorityService";

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

export function hashIdentityCredential(
  provider: IdentityProvider,
  externalId: string,
  credential: string,
  secret = config.authSecret,
): string {
  // Third-party passwords/tokens must never be stored in plaintext. Binding all three
  // values prevents an identical provider token from producing a reusable database hash.
  return createHmac("sha256", secret).update(`${provider}:${externalId}:${credential}`).digest("hex");
}

function equalHash(a: string, b: string): boolean {
  const left = Buffer.from(a, "hex");
  const right = Buffer.from(b, "hex");
  return left.length === right.length && timingSafeEqual(left, right);
}

export interface IdentityCredentialVerification {
  matches: boolean;
  /** True when the credential matched a verification-only fallback secret. */
  needsUpgrade: boolean;
}

/** Verify a provider credential without exposing which key produced its stored digest. */
export function verifyIdentityCredentialHash(
  storedHash: string,
  provider: IdentityProvider,
  externalId: string,
  credential: string,
): IdentityCredentialVerification {
  const secrets = authenticationCredentialSecrets();
  for (let index = 0; index < secrets.length; index += 1) {
    if (equalHash(storedHash, hashIdentityCredential(provider, externalId, credential, secrets[index]!))) {
      return { matches: true, needsUpgrade: index > 0 };
    }
  }
  return { matches: false, needsUpgrade: false };
}

function normalize(value: string, label: string, maxLength: number): string {
  const normalized = value.trim();
  if (!normalized || normalized.length > maxLength) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, `${label} is invalid.`);
  }
  return normalized;
}

const signedLongMinimum = -(1n << 63n);
const signedLongMaximum = (1n << 63n) - 1n;

/**
 * Normalize the provider id without losing the recovered Facebook `long` representation.
 *
 * Facebook ids cross the 1.6.0 client as `long.ToString(InvariantCulture)` and are parsed back as
 * a signed 64-bit integer. Keep large values as strings in Node, require the exact canonical text
 * that C# would emit, and reserve -1 for the client's disconnected state. Google Play and Game
 * Center are native string fields, so their existing bounded non-empty contract remains intact.
 */
export function normalizeIdentityExternalId(provider: IdentityProvider, value: string): string {
  const externalId = normalize(value, "External account id", 256);
  if (provider !== "facebook") return externalId;
  if (!/^-?(?:0|[1-9][0-9]{0,18})$/u.test(externalId)) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Facebook account id is invalid.");
  }
  const parsed = BigInt(externalId);
  if (
    parsed < signedLongMinimum
    || parsed > signedLongMaximum
    || parsed === -1n
    || parsed.toString() !== externalId
  ) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Facebook account id is invalid.");
  }
  return externalId;
}

export async function findIdentity(
  provider: IdentityProvider,
  externalId: string,
  session?: ClientSession,
): Promise<IdentityDocument | null> {
  let normalized: string;
  try {
    normalized = normalizeIdentityExternalId(provider, externalId);
  } catch {
    // Login and public existence checks treat an unrepresentable provider id as no match. Link
    // mutations call the same strict normalizer directly and retain its stable authorization error.
    return null;
  }
  return identities().findOne({ provider, externalId: normalized }, session ? { session } : undefined);
}

export interface ValidatedIdentityOwner {
  identity: IdentityDocument;
  player: PlayerDocument;
}

/**
 * Prove that one authoritative provider row still names the provider id shown by its owner.
 *
 * Root/DTO mirror equality alone cannot establish this relationship because the credential lives
 * in a separate collection. A stale row must never authenticate the account after an interrupted
 * legacy link/unlink, and an orphan row must not make an open existence endpoint advertise an
 * unusable account. Facebook's recovered disconnected sentinel is the string form of signed
 * `long` value -1; Google Play and Game Center use an empty string.
 */
export function validatedIdentityOwner(
  identity: IdentityDocument,
  player: PlayerDocument,
): ValidatedIdentityOwner {
  validatedPlayerProfileMirrors(player);
  const mirroredExternalId = identity.provider === "facebook"
    ? String(player.player.facebookId)
    : identity.provider === "googlePlay"
      ? player.player.googlePlayId
      : identity.provider === "gameCenter"
        ? player.player.gameCenterId
        : "";
  const disconnected = identity.provider === "facebook"
    ? mirroredExternalId === "-1"
    : mirroredExternalId === "";
  if (
    identity.playerId !== player.id
    || !identity.externalId
    || disconnected
    || identity.externalId !== mirroredExternalId
  ) {
    throw new Error("Stored platform identity owner mirror is inconsistent.");
  }
  return { identity, player };
}

/** Resolve a provider id only when both collections prove the same usable owner. */
export async function findValidatedIdentityOwner(
  provider: IdentityProvider,
  externalId: string,
  session?: ClientSession,
): Promise<ValidatedIdentityOwner | null> {
  const identity = await findIdentity(provider, externalId, session);
  if (!identity) return null;
  const player = await findById(identity.playerId, session);
  if (!player) throw new Error("Stored platform identity owner is missing.");
  return validatedIdentityOwner(identity, player);
}

/**
 * Select the client-visible AccountType after one provider has been removed.
 *
 * The recovered DTO exposes only one active AccountType even though a player may link several
 * providers. Preserve that current provider when it still has a durable identity row. Otherwise
 * use the first row from the caller's stable oldest-first order, and enter Guest only when no
 * external login remains. This makes unlink replay deterministic instead of depending on
 * MongoDB's unspecified natural find order.
 */
export function accountTypeAfterIdentityRemoval(
  currentAccountType: number,
  remainingProviders: readonly IdentityProvider[],
): AccountType {
  const currentProvider = providerForAccountType(currentAccountType);
  if (currentProvider && remainingProviders.includes(currentProvider)) {
    return accountTypeForProvider(currentProvider);
  }
  return remainingProviders.length > 0
    ? accountTypeForProvider(remainingProviders[0]!)
    : AccountType.Guest;
}

/**
 * Insert the first platform identity for a player being created in the same transaction.
 *
 * This is intentionally narrower than `linkIdentity`: the caller has not committed the new
 * player yet, so a normal out-of-transaction owner lookup could not see it. The unique
 * `(provider, externalId)` index remains the final race-safe ownership check. Mapping a
 * duplicate Game Center id to 15400 is required because the recovered client uses that exact
 * error to open its existing-account chooser instead of treating the response as a login fault.
 */
export async function insertIdentityForNewPlayer(
  playerId: string,
  provider: IdentityProvider,
  externalIdValue: string,
  credentialValue: string,
  session: ClientSession,
  displayName = "",
): Promise<{ externalId: string }> {
  const externalId = normalizeIdentityExternalId(provider, externalIdValue);
  const credential = normalize(credentialValue, "External account credential", 4096);
  const now = new Date();
  try {
    await identities().insertOne({
      provider,
      externalId,
      playerId,
      credentialHash: hashIdentityCredential(provider, externalId, credential),
      displayName: displayName.trim().slice(0, 100),
      createdAt: now,
      updatedAt: now,
    }, { session });
  } catch (error) {
    if ((error as { code?: number }).code === 11000 && provider === "gameCenter") {
      throw new ApiError(ApiErrorCode.GameCenterAlreadyCreated, "Game Center account already exists.");
    }
    throw error;
  }
  return { externalId };
}

export async function linkIdentity(
  playerId: string,
  provider: IdentityProvider,
  externalIdValue: string,
  credentialValue: string,
  displayName = "",
): Promise<PlayerDocument> {
  const externalId = normalizeIdentityExternalId(provider, externalIdValue);
  // OAuth/platform tokens can be substantially longer than traditional passwords. Bound
  // the input to control request cost while storing only its fixed-length HMAC digest.
  const credential = normalize(credentialValue, "External account credential", 4096);
  const now = new Date();
  try {
    return await withMongoTransaction(async (session) => {
      // Validate the owner inside the same snapshot that will publish the credential. Without
      // this guard a malformed internal call could leave an orphan login targeting no player.
      if (!(await findById(playerId, session))) {
        throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
      }

      // A provider identity may own exactly one WarFriends player. This check gives the client
      // a deterministic error; the unique index remains the final authority for concurrent links.
      const owner = await findIdentity(provider, externalId, session);
      if (owner && owner.playerId !== playerId) {
        throw new ApiError(ApiErrorCode.RequestNotAuthorized, "External account is already linked to another player.");
      }

      // The second unique index is (provider, playerId), so relinking the same provider replaces
      // its old external credential. The player mirror update shares this transaction: neither
      // the login row nor Unity's connected-account state can commit without the other.
      await identities().updateOne(
        { provider, playerId },
        {
          $set: {
            externalId,
            credentialHash: hashIdentityCredential(provider, externalId, credential),
            displayName: displayName.trim().slice(0, 100),
            updatedAt: now,
          },
          $setOnInsert: { provider, playerId, createdAt: now },
        },
        { upsert: true, session },
      );

      const accountType = accountTypeForProvider(provider);
      // Membership in the identity collection is authoritative. The mirrored DatabasePlayer
      // fields exist only because Unity renders connected-account UI and chooses its next login.
      if (provider === "facebook") {
        await updatePlayerFields(playerId, { accountType, facebookId: externalId }, session);
      }
      if (provider === "googlePlay") {
        await updatePlayerFields(playerId, { accountType, googlePlayId: externalId }, session);
      }
      if (provider === "gameCenter") {
        await updatePlayerFields(playerId, { accountType, gameCenterId: externalId }, session);
      }
      const player = await findById(playerId, session);
      if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
      return player;
    });
  } catch (error) {
    if ((error as { code?: number }).code === 11000) {
      throw new ApiError(ApiErrorCode.RequestNotAuthorized, "External account is already linked to another player.");
    }
    throw error;
  }
}

export async function unlinkIdentity(playerId: string, provider: IdentityProvider): Promise<PlayerDocument> {
  return withMongoTransaction(async (session) => {
    const current = await findById(playerId, session);
    if (!current) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");

    await identities().deleteOne({ provider, playerId }, { session });

    // At most three rows can remain because (provider, playerId) is unique. Sort oldest-first
    // with provider as a tie-breaker so an unlink retry cannot oscillate AccountType.
    const remainingIdentities = await identities()
      .find({ playerId }, { session })
      .sort({ createdAt: 1, provider: 1 })
      .toArray();
    const fallbackType = accountTypeAfterIdentityRemoval(
      current.player.accountType,
      remainingIdentities.map((identity) => identity.provider),
    );

    // Credential removal and the exact sparse player-mirror removal are one commit. A process
    // stop therefore cannot leave a usable credential hidden from Unity or a displayed provider
    // whose authoritative login row has already disappeared.
    if (provider === "facebook") {
      await updatePlayerFields(playerId, { accountType: fallbackType, facebookId: -1 }, session);
    }
    if (provider === "googlePlay") {
      await updatePlayerFields(playerId, { accountType: fallbackType, googlePlayId: "" }, session);
    }
    if (provider === "gameCenter") {
      await updatePlayerFields(playerId, { accountType: fallbackType, gameCenterId: "" }, session);
    }
    const player = await findById(playerId, session);
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    return player;
  });
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
  if (!identity) return null;
  const verification = verifyIdentityCredentialHash(
    identity.credentialHash,
    provider,
    externalId,
    credential,
  );
  if (!verification.matches) return null;
  if (verification.needsUpgrade) {
    const upgradedHash = hashIdentityCredential(provider, externalId, credential);
    const upgraded = await identities().updateOne(
      { provider, externalId, credentialHash: identity.credentialHash },
      { $set: { credentialHash: upgradedHash, updatedAt: new Date() } },
    );
    if (upgraded.modifiedCount !== 1) {
      // A concurrent link/rotation may have replaced the digest after we read it. Trust that
      // winner only if the same presented credential verifies against its current value;
      // otherwise the owner changed credentials during login and this stale proof is rejected.
      const current = await findIdentity(provider, externalId);
      if (!current || !verifyIdentityCredentialHash(
        current.credentialHash,
        provider,
        externalId,
        credential,
      ).matches) return null;
    }
  }

  // Re-read after verification even when no key upgrade was needed. An unlink/relink may transfer
  // the external id between the first read and this point; a stale successful HMAC comparison must
  // never authenticate the former owner. Re-verifying the final digest also rejects a concurrent
  // credential rotation before its newly linked player can be returned.
  const currentOwner = await findValidatedIdentityOwner(provider, externalId);
  if (
    !currentOwner
    || currentOwner.identity.playerId !== identity.playerId
    || !verifyIdentityCredentialHash(
      currentOwner.identity.credentialHash,
      provider,
      externalId,
      credential,
    ).matches
  ) return null;
  return currentOwner.player;
}
