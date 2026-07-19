import { createHmac, randomBytes, randomUUID, timingSafeEqual } from "crypto";
import { config } from "../config";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import { newPlayer, type DatabasePlayerDTO } from "../dtos";
import { findById, insertPlayer, updateAuthCredentials, updateSessionToken } from "./playerService";
import type { PlayerDocument } from "../db";
import logger from "../utils/logger";
import { authenticateIdentity, providerForAccountType } from "./identityService";
import { normalizePlayerName } from "./playerSettingsService";
import { createInitialProgression } from "./playerStateService";

// Auth model (BACKEND.md §2.2): id + token credential. On CreateAccount the server mints a
// player id and an HMAC auth token derived from a server-side salt; the client stores both
// and replays them on LoginToCustomAccount. Social ids link onto the same player row.

function issueToken(playerId: string, salt: string): string {
  return createHmac("sha256", config.authSecret).update(`${playerId}:${salt}`).digest("hex");
}

function credentialHash(playerId: string, credential: string): string {
  // Bind the digest to the account ID so identical passwords on two accounts never produce
  // the same stored value. AUTH_SECRET acts as a server-side pepper and must be rotated using
  // a migration strategy in production.
  return createHmac("sha256", config.authSecret).update(`custom:${playerId}:${credential}`).digest("hex");
}

function tokensMatch(a: string, b: string): boolean {
  const ba = Buffer.from(a);
  const bb = Buffer.from(b);
  return ba.length === bb.length && timingSafeEqual(ba, bb);
}

/**
 * Validate a direct WarFriends credential without conflating gameplay sessions and human
 * passwords. A custom account normally stores both values. The old nested ternary checked
 * `authToken` first and therefore never examined `authTokenHash`, making a valid saved
 * password unusable as soon as a session token existed.
 *
 * Password hashes are accepted only on the explicit LoginToCustomAccount path. Ordinary
 * gameplay actions must present the rotatable session token; otherwise knowledge of a
 * long-lived password would bypass session revocation on every API route.
 */
export function playerCredentialMatches(
  doc: PlayerDocument,
  credential: string,
  allowCustomPassword: boolean,
): boolean {
  const sessionMatches = typeof doc.authToken === "string" && tokensMatch(doc.authToken, credential);
  const passwordMatches = allowCustomPassword && typeof doc.authTokenHash === "string"
    ? tokensMatch(doc.authTokenHash, credentialHash(doc.id, credential))
    : false;
  return sessionMatches || passwordMatches;
}

export interface CreatedAccount {
  doc: PlayerDocument;
  player: DatabasePlayerDTO;
  authToken: string;
}

/**
 * MongoDB is the final authority for account-name uniqueness. A separate "does this name
 * exist?" query would still have a race: two requests could both observe an unused name and
 * then attempt the insert together. We therefore rely on the unique index and translate only
 * its normalized-account-name violation into a stable game API error. Other database errors
 * remain unexpected and are deliberately allowed to reach the central error logger.
 */
function isDuplicateAccountName(error: unknown): boolean {
  if (!error || typeof error !== "object") return false;
  const mongoError = error as {
    code?: number;
    keyPattern?: Record<string, unknown>;
    message?: string;
  };
  return mongoError.code === 11000 &&
    (mongoError.keyPattern?.normalizedAccountName === 1 ||
      mongoError.message?.includes("normalizedAccountName_1") === true);
}

export async function createCustomAccount(
  accountName: string,
  accountType: AccountType,
  deviceToken?: string,
): Promise<CreatedAccount> {
  const id = randomUUID();
  const salt = randomBytes(16).toString("hex");
  const authToken = issueToken(id, salt);

  // User-supplied names use the same validation path as later renames. Empty names are
  // intentionally replaced with a collision-resistant guest label for first-time boot.
  const resolvedName = accountName ? normalizePlayerName(accountName) : `Recruit-${id.slice(0, 6)}`;
  const player = newPlayer(id, resolvedName, accountType);
  player.deviceToken = deviceToken ?? "";

  let doc: PlayerDocument;
  try {
    doc = await insertPlayer({
      id,
      accountName: player.accountName,
      normalizedAccountName: player.accountName.toLocaleLowerCase("en-US"),
      authToken,
      accountType,
      deviceToken,
      leagueTier: player.leagueTier,
      armyPower: player.armyPower,
      experience: player.experience,
      squadPoints: player.squadPoints,
      squadName: player.squadName,
      player,
      progression: createInitialProgression(),
    });
  } catch (error) {
    if (isDuplicateAccountName(error)) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Player name is already in use.");
    }
    throw error;
  }

  logger.auth.register(deviceToken ?? id, true, { playerId: id });
  logger.player.create(id, player.accountName);
  logger.auth.token("issued", { playerId: id });
  return { doc, player, authToken };
}

/**
 * Authenticate either a guest/server session or a linked platform identity.
 *
 * The direct player-id/token check runs first for backward compatibility: some recovered
 * client paths retain a social AccountType while continuing to send the server-issued
 * player credentials. If that fails and AccountType identifies a platform provider, the
 * same Id/Password fields are interpreted as that provider's external credentials.
 */
export async function authenticate(
  id: string | undefined,
  token: string | undefined,
  accountType?: number,
  allowCustomPassword = false,
): Promise<PlayerDocument> {
  if (!id || !token) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Missing credentials.");
  }
  const doc = await findById(id);
  const directCredentialMatches = doc
    ? playerCredentialMatches(doc, token, allowCustomPassword)
    : false;
  if (doc && directCredentialMatches) {
    logger.auth.login(id, true, { playerId: id });
    return doc;
  }

  const provider = providerForAccountType(accountType ?? AccountType.Guest);
  const identityPlayer = provider ? await authenticateIdentity(provider, id, token) : null;
  if (identityPlayer) {
    logger.auth.login(id, true, { playerId: identityPlayer.id, provider });
    return identityPlayer;
  }

  logger.auth.login(id, false);
  throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Invalid credentials.");
}

/**
 * Replace the custom-account password and rotate the ordinary session credential.
 *
 * The password digest allows the next LoginToCustomAccount request to authenticate. The
 * distinct random session token is what normal gameplay requests send afterward. Rotation
 * revokes the old guest/session token without forcing provider logins to reuse a Facebook,
 * Google Play, or Game Center credential as an internal WarFriends session secret.
 */
export async function replaceCustomCredential(playerId: string, credential: string): Promise<string> {
  const sessionToken = issueToken(playerId, randomBytes(16).toString("hex"));
  await updateAuthCredentials(playerId, credentialHash(playerId, credential), sessionToken);
  return sessionToken;
}

/**
 * Guarantee that a successfully authenticated account can make its next ordinary request.
 * This mainly migrates rows written by an earlier reconstruction that removed authToken
 * after setting a password. Provider credentials must never be reused as internal session
 * tokens, so a missing token is replaced with fresh server-generated entropy.
 */
export async function ensureSessionToken(player: PlayerDocument): Promise<string> {
  if (player.authToken) return player.authToken;
  const sessionToken = issueToken(player.id, randomBytes(16).toString("hex"));
  await updateSessionToken(player.id, sessionToken);
  player.authToken = sessionToken;
  return sessionToken;
}
