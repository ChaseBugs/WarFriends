import { createHmac, randomBytes, randomUUID, scrypt, timingSafeEqual } from "crypto";
import type { ClientSession } from "mongodb";
import { config } from "../config";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { AccountType } from "../constants";
import { newPlayer, type DatabasePlayerDTO } from "../dtos";
import {
  compareAndRotateSessionToken,
  compareAndUpgradeCredentialHash,
  findById,
  insertPlayer,
  updateProfileAndAuthCredentials,
  updateSessionToken,
} from "./playerService";
import { withMongoTransaction, type PlayerDocument } from "../db";
import logger from "../utils/logger";
import {
  authenticateIdentity,
  insertIdentityForNewPlayer,
  providerForAccountType,
} from "./identityService";
import { normalizePlayerName } from "./playerSettingsService";
import { createInitialProgression } from "./playerStateService";
import {
  clearLoginAttempt,
  clearLoginAttemptsForSession,
  reserveLoginAttempt,
  type LoginAttemptReservation,
} from "./authRateLimitService";

// Auth model (BACKEND.md §2.2): id + token credential. On CreateAccount the server mints a
// player id and an HMAC auth token derived from a server-side salt; the client stores both
// and replays them on LoginToCustomAccount. Social ids link onto the same player row.

function issueToken(playerId: string, salt: string): string {
  return createHmac("sha256", config.authSecret).update(`${playerId}:${salt}`).digest("hex");
}

function legacyCredentialHash(playerId: string, credential: string): string {
  // Bind the digest to the account ID so identical passwords on two accounts never produce
  // the same stored value. AUTH_SECRET acts as a server-side pepper and must be rotated using
  // a migration strategy in production.
  return createHmac("sha256", config.authSecret).update(`custom:${playerId}:${credential}`).digest("hex");
}

const SCRYPT_VERSION = "v1";
const SCRYPT_COST = 16_384;
const SCRYPT_BLOCK_SIZE = 8;
const SCRYPT_PARALLELIZATION = 1;
const SCRYPT_KEY_LENGTH = 32;
const SCRYPT_MAX_MEMORY = 64 * 1024 * 1024;

interface ParsedScryptHash {
  salt: Buffer;
  digest: Buffer;
}

function passwordMaterial(playerId: string, credential: string): Buffer {
  // The HMAC is a server-side pepper applied before the deliberately expensive KDF. A database
  // leak alone is therefore insufficient for offline guesses, while random per-password salt
  // still prevents equal passwords from sharing a stored digest.
  return createHmac("sha256", config.authSecret)
    .update("custom-password\0")
    .update(playerId)
    .update("\0")
    .update(credential)
    .digest();
}

function deriveScryptKey(material: Buffer, salt: Buffer): Promise<Buffer> {
  return new Promise((resolve, reject) => {
    scrypt(
      material,
      salt,
      SCRYPT_KEY_LENGTH,
      {
        N: SCRYPT_COST,
        r: SCRYPT_BLOCK_SIZE,
        p: SCRYPT_PARALLELIZATION,
        maxmem: SCRYPT_MAX_MEMORY,
      },
      (error, derivedKey) => error ? reject(error) : resolve(derivedKey),
    );
  });
}

function parseScryptHash(value: string): ParsedScryptHash | null {
  const parts = value.split("$");
  if (
    parts.length !== 7
    || parts[0] !== "scrypt"
    || parts[1] !== SCRYPT_VERSION
    || Number(parts[2]) !== SCRYPT_COST
    || Number(parts[3]) !== SCRYPT_BLOCK_SIZE
    || Number(parts[4]) !== SCRYPT_PARALLELIZATION
    || !/^[0-9a-f]{32}$/u.test(parts[5] ?? "")
    || !/^[0-9a-f]{64}$/u.test(parts[6] ?? "")
  ) return null;
  return { salt: Buffer.from(parts[5]!, "hex"), digest: Buffer.from(parts[6]!, "hex") };
}

/** Produce a versioned, salted, memory-hard digest for a human-entered custom password. */
export async function hashCustomCredential(playerId: string, credential: string): Promise<string> {
  const salt = randomBytes(16);
  const digest = await deriveScryptKey(passwordMaterial(playerId, credential), salt);
  return [
    "scrypt",
    SCRYPT_VERSION,
    SCRYPT_COST,
    SCRYPT_BLOCK_SIZE,
    SCRYPT_PARALLELIZATION,
    salt.toString("hex"),
    digest.toString("hex"),
  ].join("$");
}

/** Legacy rows contain one unversioned 64-hex HMAC and are upgraded after a valid login. */
export function customCredentialHashNeedsUpgrade(value: string | undefined): boolean {
  return Boolean(value && !parseScryptHash(value));
}

async function customCredentialMatches(playerId: string, storedHash: string, credential: string): Promise<boolean> {
  const parsed = parseScryptHash(storedHash);
  if (!parsed) return tokensMatch(storedHash, legacyCredentialHash(playerId, credential));
  const candidate = await deriveScryptKey(passwordMaterial(playerId, credential), parsed.salt);
  return candidate.length === parsed.digest.length && timingSafeEqual(candidate, parsed.digest);
}

function tokensMatch(a: string, b: string): boolean {
  const ba = Buffer.from(a);
  const bb = Buffer.from(b);
  return ba.length === bb.length && timingSafeEqual(ba, bb);
}

/** Mint and persist the gameplay credential returned by a successful explicit login. */
async function rotateAuthenticatedSession(
  player: PlayerDocument,
  options: { allowConcurrentWinner: boolean; expectedCredentialHash?: string },
): Promise<void> {
  const candidate = issueToken(player.id, randomBytes(16).toString("hex"));
  player.authToken = await compareAndRotateSessionToken(player.id, player.authToken, candidate, options);
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
export async function playerCredentialMatches(
  doc: PlayerDocument,
  credential: string,
  allowCustomPassword: boolean,
): Promise<boolean> {
  const sessionMatches = typeof doc.authToken === "string" && tokensMatch(doc.authToken, credential);
  if (sessionMatches) return true;
  const passwordMatches = allowCustomPassword && typeof doc.authTokenHash === "string"
    ? await customCredentialMatches(doc.id, doc.authTokenHash, credential)
    : false;
  return sessionMatches || passwordMatches;
}

export interface CreatedAccount {
  doc: PlayerDocument;
  player: DatabasePlayerDTO;
  authToken: string;
}

interface CreateAccountOptions {
  /** Join a wider identity/account transaction instead of committing the player alone. */
  session?: ClientSession;
  /** Platform id mirrored into both the indexed document and DatabasePlayer response. */
  gameCenterId?: string;
  /** Transactional callers log only after the complete identity/account commit succeeds. */
  deferLogging?: boolean;
  /** Optional human password hashed before the new player document becomes visible. */
  customCredential?: string;
}

function logCreatedAccount(created: CreatedAccount, deviceToken?: string): void {
  logger.auth.register(deviceToken ?? created.doc.id, true, { playerId: created.doc.id });
  logger.player.create(created.doc.id, created.player.accountName);
  logger.auth.token("issued", { playerId: created.doc.id });
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
  options: CreateAccountOptions = {},
): Promise<CreatedAccount> {
  const id = randomUUID();
  const salt = randomBytes(16).toString("hex");
  const authToken = issueToken(id, salt);
  const authTokenHash = options.customCredential === undefined
    ? undefined
    : await hashCustomCredential(id, options.customCredential);

  // User-supplied names use the same validation path as later renames. Empty names are
  // intentionally replaced with a collision-resistant guest label for first-time boot.
  const resolvedName = accountName ? normalizePlayerName(accountName) : `Recruit-${id.slice(0, 6)}`;
  const player = newPlayer(id, resolvedName, accountType);
  player.deviceToken = deviceToken ?? "";
  if (options.gameCenterId) player.gameCenterId = options.gameCenterId;

  let doc: PlayerDocument;
  try {
    doc = await insertPlayer({
      id,
      accountName: player.accountName,
      normalizedAccountName: player.accountName.toLocaleLowerCase("en-US"),
      authToken,
      ...(authTokenHash ? { authTokenHash } : {}),
      accountType,
      ...(options.gameCenterId ? { gameCenterId: options.gameCenterId } : {}),
      deviceToken,
      leagueTier: player.leagueTier,
      armyPower: player.armyPower,
      experience: player.experience,
      squadPoints: player.squadPoints,
      squadName: player.squadName,
      player,
      progression: createInitialProgression(),
    }, options.session);
  } catch (error) {
    if (isDuplicateAccountName(error)) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Player name is already in use.");
    }
    throw error;
  }

  const created = { doc, player, authToken };
  if (!options.deferLogging) logCreatedAccount(created, deviceToken);
  return created;
}

/** Enforce one custom-password contract for account creation and later replacement. */
export function validateCustomCredential(value: unknown): string {
  if (typeof value !== "string" || value.length < 6 || value.length > 128) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Password must contain 6 to 128 characters.");
  }
  return value;
}

/**
 * Create a durable custom account without exposing a guest-only intermediate document.
 * Password hashing completes before insertPlayer runs, so KDF failure cannot orphan an account
 * whose successful response was never returned to the Client.
 */
export async function createFullCustomAccount(
  accountName: string,
  credentialValue: unknown,
  deviceToken?: string,
): Promise<CreatedAccount> {
  const credential = validateCustomCredential(credentialValue);
  return createCustomAccount(accountName, AccountType.Guest, deviceToken, { customCredential: credential });
}

/**
 * Create the first WarFriends account for a Game Center identity.
 *
 * `CreateGcAccount` is an unauthenticated first-boot route, so the platform credential must
 * establish identity ownership while the backend still issues a separate internal session
 * token for ordinary gameplay calls. Player and identity rows commit together. If two devices
 * race with the same Game Center id, the unique identity index aborts the losing transaction;
 * no unreachable Recruit player is left behind.
 */
export async function createGameCenterAccount(
  externalIdValue: string,
  credentialValue: string,
  deviceToken?: string,
): Promise<CreatedAccount> {
  const gameCenterId = externalIdValue.trim();
  const created = await withMongoTransaction(async (session) => {
    const account = await createCustomAccount("", AccountType.GameCenter, deviceToken, {
      session,
      gameCenterId,
      deferLogging: true,
    });
    await insertIdentityForNewPlayer(
      account.doc.id,
      "gameCenter",
      gameCenterId,
      credentialValue,
      session,
    );
    return account;
  });
  logCreatedAccount(created, deviceToken);
  return created;
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
  // Match the provider-link input bounds before any MongoDB lookup or memory-hard password work.
  // This prevents a modified client from turning the 2 MB HTTP body allowance into oversized
  // index keys or repeated multi-megabyte HMAC inputs.
  if (id.length > 256 || token.length > 4096) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Invalid credentials.");
  }
  const doc = await findById(id);
  // A rotatable gameplay token is both cheap to verify and proof that the caller already owns
  // a live session. Let it bypass/clear durable-login failures so an attacker cannot lock an
  // active player out of ordinary play by guessing that player's public ID.
  const sessionCredentialMatches = doc ? await playerCredentialMatches(doc, token, false) : false;
  if (doc && sessionCredentialMatches) {
    if (allowCustomPassword) await clearLoginAttemptsForSession(id);
    if (allowCustomPassword) await rotateAuthenticatedSession(doc, { allowConcurrentWinner: false });
    logger.auth.login(id, true, { playerId: id });
    return doc;
  }

  // Only LoginToCustomAccount passes allowCustomPassword. Reserve before checking a human or
  // provider credential so every server node shares one persistent brute-force boundary.
  let loginReservation: LoginAttemptReservation | null = null;
  if (allowCustomPassword) {
    try {
      loginReservation = await reserveLoginAttempt(id);
    } catch (error) {
      logger.auth.login(id, false, { throttled: true });
      throw error;
    }
  }

  const customPasswordMatches = doc
    ? await playerCredentialMatches(doc, token, allowCustomPassword)
    : false;
  if (doc && customPasswordMatches) {
    if (loginReservation) await clearLoginAttempt(loginReservation);
    if (customCredentialHashNeedsUpgrade(doc.authTokenHash)) {
      const legacyHash = doc.authTokenHash!;
      const upgradedHash = await hashCustomCredential(doc.id, token);
      if (await compareAndUpgradeCredentialHash(doc.id, legacyHash, upgradedHash)) {
        doc.authTokenHash = upgradedHash;
      } else {
        // A simultaneous password change or legacy migration won the compare. Reject this
        // snapshot instead of returning a session token that the verified legacy hash no longer
        // authorizes. A retry will verify against the new versioned digest.
        throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Credentials changed during login.");
      }
    }
    await rotateAuthenticatedSession(doc, {
      allowConcurrentWinner: true,
      expectedCredentialHash: doc.authTokenHash,
    });
    logger.auth.login(id, true, { playerId: id });
    return doc;
  }

  const provider = providerForAccountType(accountType ?? AccountType.Guest);
  const identityPlayer = provider ? await authenticateIdentity(provider, id, token) : null;
  if (identityPlayer) {
    if (loginReservation) await clearLoginAttempt(loginReservation);
    await rotateAuthenticatedSession(identityPlayer, { allowConcurrentWinner: true });
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
/**
 * Atomically apply the exact Name + Password payload sent by ChangeNameAndPassword (action 121).
 * The unique normalized-name index remains the final race-safe authority for name ownership.
 */
export async function replaceCustomProfileCredential(
  playerId: string,
  expectedAuthToken: string,
  accountName: string,
  credentialValue: unknown,
): Promise<string> {
  const credential = validateCustomCredential(credentialValue);
  const authTokenHash = await hashCustomCredential(playerId, credential);
  const sessionToken = issueToken(playerId, randomBytes(16).toString("hex"));
  try {
    const updated = await updateProfileAndAuthCredentials(
      playerId,
      expectedAuthToken,
      accountName,
      authTokenHash,
      sessionToken,
    );
    if (!updated) {
      throw new ApiError(ApiErrorCode.RequestNotAuthorized, "The authenticated session changed before update.");
    }
  } catch (error) {
    if (isDuplicateAccountName(error)) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Player name is already in use.");
    }
    throw error;
  }
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
