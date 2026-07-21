import type { ClientSession } from "mongodb";
import { players, type PlayerDocument } from "../db";
import type { DatabasePlayerDTO } from "../dtos";
import { ApiError, ApiErrorCode } from "../apiErrors";
import {
  validatedPlayerAccountEnvelope,
  validatedPlayerProfileLookup,
} from "./playerProfileMirrorAuthorityService";

// Data-access for the player document. The full client-facing snapshot lives in
// document.player (DatabasePlayerDTO); a few dimensions are denormalized to the top level
// for indexed lookup/matchmaking and kept in sync on every save.

export async function findById(id: string, session?: ClientSession): Promise<PlayerDocument | null> {
  return validatedPlayerProfileLookup(await players().findOne({ id }, session ? { session } : undefined));
}

export async function findByAuthToken(id: string, authToken: string): Promise<PlayerDocument | null> {
  return validatedPlayerProfileLookup(await players().findOne({ id, authToken }));
}

/**
 * Best-effort attach for non-auth-required handlers: a real lookup miss returns null.
 *
 * "Optional" applies only to absent or invalid credentials. If MongoDB did find the account, its
 * complete mirror tuple must still pass the same authority proof as an authenticated lookup; a
 * damaged profile is never downgraded to an anonymous request that could hide corruption.
 */
export async function findByIdOptional(id: string, authToken: string): Promise<PlayerDocument | null> {
  return validatedPlayerProfileLookup(await players().findOne({ id, authToken }));
}

export async function insertPlayer(
  doc: Omit<PlayerDocument, "createdAt" | "updatedAt">,
  session?: ClientSession,
): Promise<PlayerDocument> {
  const now = new Date();
  const full: PlayerDocument = { ...doc, createdAt: now, updatedAt: now };
  validatedPlayerAccountEnvelope(full);
  await players().insertOne(full, session ? { session } : undefined);
  return full;
}

/**
 * Publish an account name, password digest, and replacement gameplay session as one write.
 *
 * ChangeNameAndPassword is one logical Client action. Persisting the public name before deriving
 * or saving the password allowed a KDF/database failure to leave the request half-applied. The
 * expected-token filter also makes concurrent submissions deterministic: only the request that
 * still owns the authenticated session may commit, and its write revokes that session at once.
 */
export async function updateProfileAndAuthCredentials(
  id: string,
  expectedAuthToken: string,
  accountName: string,
  authTokenHash: string,
  authToken: string,
): Promise<boolean> {
  const result = await players().updateOne(
    { id, authToken: expectedAuthToken },
    {
      $set: {
        accountName,
        normalizedAccountName: accountName.toLocaleLowerCase("en-US"),
        "player.accountName": accountName,
        authTokenHash,
        authToken,
        updatedAt: new Date(),
      },
    },
  );
  return result.modifiedCount === 1;
}

/** Upgrade a verified legacy password digest without overwriting a concurrent password change. */
export async function compareAndUpgradeCredentialHash(
  id: string,
  expectedHash: string,
  upgradedHash: string,
): Promise<boolean> {
  const result = await players().updateOne(
    { id, authTokenHash: expectedHash },
    { $set: { authTokenHash: upgradedHash, updatedAt: new Date() } },
  );
  return result.modifiedCount === 1;
}

/** Persist a rotated session token without changing the account's login password digest. */
export async function updateSessionToken(id: string, authToken: string): Promise<void> {
  await players().updateOne({ id }, { $set: { authToken, updatedAt: new Date() } });
}

/**
 * Rotate a session only if the caller still owns the token snapshot it authenticated.
 *
 * Two simultaneous durable logins may both validate against the same token snapshot before either
 * writes its new gameplay token. An unconditional pair of updates would return one candidate that
 * was never the final stored value. Compare-and-set makes one candidate win; a writer that loses
 * that exact snapshot race reloads and returns the winning token instead.
 */
export async function compareAndRotateSessionToken(
  id: string,
  expectedToken: string | undefined,
  candidateToken: string,
  options: { allowConcurrentWinner: boolean; expectedCredentialHash?: string },
): Promise<string> {
  const currentTokenFilter = expectedToken === undefined
    ? { authToken: { $exists: false } }
    : { authToken: expectedToken };
  const credentialFilter = options.expectedCredentialHash === undefined
    ? {}
    : { authTokenHash: options.expectedCredentialHash };
  const updated = await players().findOneAndUpdate(
    { id, ...currentTokenFilter, ...credentialFilter },
    { $set: { authToken: candidateToken, updatedAt: new Date() } },
    { returnDocument: "after", projection: { authToken: 1 } },
  );
  if (updated?.authToken) return updated.authToken;

  // A failed compare normally means another successful login rotated first. Return its token
  // only when the caller's durable credential still proves account ownership. A session-only
  // login must not inherit a token created by a concurrent password change, and a password login
  // must not inherit one after its verified hash was replaced.
  const current = await players().findOne({ id }, { projection: { authToken: 1, authTokenHash: 1 } });
  if (
    !current?.authToken
    || !options.allowConcurrentWinner
    || (options.expectedCredentialHash !== undefined && current.authTokenHash !== options.expectedCredentialHash)
  ) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Authenticated session could not be rotated.");
  }
  return current.authToken;
}

/** Persist a mutated player snapshot, re-syncing the denormalized top-level fields. */
export async function savePlayer(id: string, player: DatabasePlayerDTO): Promise<void> {
  // Provider roots use sparse indexes, so disconnected sentinel values must be removed rather
  // than written as shared empty keys. Publish the DTO and every duplicated root in one update.
  const set: Record<string, unknown> = {
    player,
    accountName: player.accountName,
    normalizedAccountName: player.accountName.toLocaleLowerCase("en-US"),
    accountType: player.accountType,
    deviceToken: player.deviceToken,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    updatedAt: new Date(),
  };
  const unset: Record<string, ""> = {};
  if (player.facebookId === -1) unset.facebookId = "";
  else set.facebookId = String(player.facebookId);
  if (player.googlePlayId) set.googlePlayId = player.googlePlayId;
  else unset.googlePlayId = "";
  if (player.gameCenterId) set.gameCenterId = player.gameCenterId;
  else unset.gameCenterId = "";
  await players().updateOne(
    { id },
    {
      $set: set,
      ...(Object.keys(unset).length ? { $unset: unset } : {}),
    },
  );
}

/** Update only the supplied player fields so concurrent match/squad writes are not lost. */
export async function updatePlayerFields(
  id: string,
  fields: Partial<DatabasePlayerDTO>,
  session?: ClientSession,
): Promise<void> {
  const set: Record<string, unknown> = { updatedAt: new Date() };
  for (const [key, value] of Object.entries(fields)) set[`player.${key}`] = value;

  if (fields.accountName !== undefined) {
    set.accountName = fields.accountName;
    set.normalizedAccountName = fields.accountName.toLocaleLowerCase("en-US");
  }
  if (fields.accountType !== undefined) set.accountType = fields.accountType;
  // Provider ids are duplicated at the document root only for indexed lookup. Empty values
  // must be removed rather than stored. An unrelated partial update must not unset these
  // ids, so each key is handled only when it is explicitly present in `fields`.
  const unset: Record<string, ""> = {};
  if (fields.facebookId !== undefined) {
    if (fields.facebookId === -1) unset.facebookId = "";
    else set.facebookId = String(fields.facebookId);
  }
  if (fields.googlePlayId !== undefined) {
    if (fields.googlePlayId) set.googlePlayId = fields.googlePlayId;
    else unset.googlePlayId = "";
  }
  if (fields.gameCenterId !== undefined) {
    if (fields.gameCenterId) set.gameCenterId = fields.gameCenterId;
    else unset.gameCenterId = "";
  }
  if (fields.leagueTier !== undefined) set.leagueTier = fields.leagueTier;
  if (fields.armyPower !== undefined) set.armyPower = fields.armyPower;
  if (fields.experience !== undefined) set.experience = fields.experience;
  if (fields.squadPoints !== undefined) set.squadPoints = fields.squadPoints;
  if (fields.squadName !== undefined) set.squadName = fields.squadName;
  if (fields.deviceToken !== undefined) set.deviceToken = fields.deviceToken;

  await players().updateOne(
    { id },
    { $set: set, ...(Object.keys(unset).length ? { $unset: unset } : {}) },
    session ? { session } : undefined,
  );
}
