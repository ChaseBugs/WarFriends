import type { ClientSession } from "mongodb";
import { players, type PlayerDocument } from "../db";
import type { DatabasePlayerDTO } from "../dtos";
import { ApiError, ApiErrorCode } from "../apiErrors";

// Data-access for the player document. The full client-facing snapshot lives in
// document.player (DatabasePlayerDTO); a few dimensions are denormalized to the top level
// for indexed lookup/matchmaking and kept in sync on every save.

export async function findById(id: string): Promise<PlayerDocument | null> {
  return players().findOne({ id });
}

export async function findByAuthToken(id: string, authToken: string): Promise<PlayerDocument | null> {
  return players().findOne({ id, authToken });
}

/** Best-effort attach for non-auth-required handlers: returns null instead of throwing. */
export async function findByIdOptional(id: string, authToken: string): Promise<PlayerDocument | null> {
  return players().findOne({ id, authToken });
}

export async function insertPlayer(
  doc: Omit<PlayerDocument, "createdAt" | "updatedAt">,
  session?: ClientSession,
): Promise<PlayerDocument> {
  const now = new Date();
  const full: PlayerDocument = { ...doc, createdAt: now, updatedAt: now };
  await players().insertOne(full, session ? { session } : undefined);
  return full;
}

/** Persist the new password digest and its independently rotated gameplay session token. */
export async function updateAuthCredentials(id: string, authTokenHash: string, authToken: string): Promise<void> {
  await players().updateOne(
    { id },
    { $set: { authTokenHash, authToken, updatedAt: new Date() } },
  );
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
): Promise<string> {
  const currentTokenFilter = expectedToken === undefined
    ? { authToken: { $exists: false } }
    : { authToken: expectedToken };
  const updated = await players().findOneAndUpdate(
    { id, ...currentTokenFilter },
    { $set: { authToken: candidateToken, updatedAt: new Date() } },
    { returnDocument: "after", projection: { authToken: 1 } },
  );
  if (updated?.authToken) return updated.authToken;

  // A failed compare normally means another successful login rotated first. Return its token
  // instead of overwriting it. A missing player or token indicates an external destructive write
  // and must fail closed rather than returning the unpersisted candidate.
  const current = await players().findOne({ id }, { projection: { authToken: 1 } });
  if (!current?.authToken) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Authenticated session could not be rotated.");
  }
  return current.authToken;
}

/** Persist a mutated player snapshot, re-syncing the denormalized top-level fields. */
export async function savePlayer(id: string, player: DatabasePlayerDTO): Promise<void> {
  await players().updateOne(
    { id },
    {
      $set: {
        player,
        accountName: player.accountName,
        leagueTier: player.leagueTier,
        armyPower: player.armyPower,
        experience: player.experience,
        squadPoints: player.squadPoints,
        squadName: player.squadName,
        updatedAt: new Date(),
      },
    },
  );
}

/** Update only the supplied player fields so concurrent match/squad writes are not lost. */
export async function updatePlayerFields(id: string, fields: Partial<DatabasePlayerDTO>): Promise<void> {
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

  await players().updateOne({ id }, { $set: set, ...(Object.keys(unset).length ? { $unset: unset } : {}) });
}
