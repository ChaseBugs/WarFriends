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
  normalizeIdentityExternalId,
  providerForAccountType,
} from "./identityService";
import { exactDeviceToken, normalizeLocale, normalizePlayerName } from "./playerSettingsService";
import { createInitialProgression, unixNow } from "./playerStateService";
import {
  clearLoginAttempt,
  clearLoginAttemptsForSession,
  reserveLoginAttempt,
  type LoginAttemptReservation,
} from "./authRateLimitService";
import { assertPlayerNotSanctioned } from "./playerSanctionService";
import {
  authenticationCredentialSecrets,
  isSupportedAuthenticationScryptCost,
} from "./authSecretService";
import { verifyGameCenterIdentityOwnership } from "./gameCenterIdentityProofService";

// Auth model (BACKEND.md §2.2): id + token credential. On CreateAccount the server mints a
// player id and an HMAC auth token derived from a server-side salt; the client stores both
// and replays them on LoginToCustomAccount. Social ids link onto the same player row.

function issueToken(playerId: string, salt: string): string {
  return createHmac("sha256", config.authSecret).update(`${playerId}:${salt}`).digest("hex");
}

function legacyCredentialHash(playerId: string, credential: string, secret = config.authSecret): string {
  // Bind the digest to the account ID so identical passwords on two accounts never produce
  // the same stored value. AUTH_SECRET acts as a server-side pepper and must be rotated using
  // a migration strategy in production.
  return createHmac("sha256", secret).update(`custom:${playerId}:${credential}`).digest("hex");
}

const SCRYPT_VERSION = "v1";
const SCRYPT_BLOCK_SIZE = 8;
const SCRYPT_PARALLELIZATION = 1;
const SCRYPT_KEY_LENGTH = 32;
const SCRYPT_MIN_MAX_MEMORY = 64 * 1024 * 1024;

interface ParsedScryptHash {
  cost: number;
  salt: Buffer;
  digest: Buffer;
}

function passwordMaterial(playerId: string, credential: string, secret = config.authSecret): Buffer {
  // The HMAC is a server-side pepper applied before the deliberately expensive KDF. A database
  // leak alone is therefore insufficient for offline guesses, while random per-password salt
  // still prevents equal passwords from sharing a stored digest.
  return createHmac("sha256", secret)
    .update("custom-password\0")
    .update(playerId)
    .update("\0")
    .update(credential)
    .digest();
}

function deriveScryptKey(material: Buffer, salt: Buffer, cost: number): Promise<Buffer> {
  // Node requires maxmem to exceed roughly 128*N*r bytes. Derive it from the bounded stored
  // factor so a legitimate older/higher-cost digest remains verifiable after configuration
  // changes, while malformed database input can never request unbounded memory.
  const maxMemory = Math.max(
    SCRYPT_MIN_MAX_MEMORY,
    (128 * cost * SCRYPT_BLOCK_SIZE) + (2 * 1024 * 1024),
  );
  return new Promise((resolve, reject) => {
    scrypt(
      material,
      salt,
      SCRYPT_KEY_LENGTH,
      {
        N: cost,
        r: SCRYPT_BLOCK_SIZE,
        p: SCRYPT_PARALLELIZATION,
        maxmem: maxMemory,
      },
      (error, derivedKey) => error ? reject(error) : resolve(derivedKey),
    );
  });
}

function parseScryptHash(value: string): ParsedScryptHash | null {
  const parts = value.split("$");
  const cost = Number(parts[2]);
  if (
    parts.length !== 7
    || parts[0] !== "scrypt"
    || parts[1] !== SCRYPT_VERSION
    || !isSupportedAuthenticationScryptCost(cost)
    || Number(parts[3]) !== SCRYPT_BLOCK_SIZE
    || Number(parts[4]) !== SCRYPT_PARALLELIZATION
    || !/^[0-9a-f]{32}$/u.test(parts[5] ?? "")
    || !/^[0-9a-f]{64}$/u.test(parts[6] ?? "")
  ) return null;
  return { cost, salt: Buffer.from(parts[5]!, "hex"), digest: Buffer.from(parts[6]!, "hex") };
}

/** Produce a versioned, salted, memory-hard digest for a human-entered custom password. */
export async function hashCustomCredential(
  playerId: string,
  credential: string,
  cost = config.authScryptCost,
): Promise<string> {
  const salt = randomBytes(16);
  if (!isSupportedAuthenticationScryptCost(cost)) {
    throw new Error("AUTH_SCRYPT_COST is outside the supported work-factor range.");
  }
  const digest = await deriveScryptKey(passwordMaterial(playerId, credential), salt, cost);
  return [
    "scrypt",
    SCRYPT_VERSION,
    cost,
    SCRYPT_BLOCK_SIZE,
    SCRYPT_PARALLELIZATION,
    salt.toString("hex"),
    digest.toString("hex"),
  ].join("$");
}

/** Legacy rows contain one unversioned 64-hex HMAC and are upgraded after a valid login. */
export function customCredentialHashNeedsUpgrade(value: string | undefined): boolean {
  if (!value) return false;
  const parsed = parseScryptHash(value);
  return !parsed || parsed.cost < config.authScryptCost;
}

/** Preserve a stronger stored factor when a fallback-key match still requires re-peppering. */
function customCredentialRehashCost(value: string): number {
  const parsed = parseScryptHash(value);
  return parsed ? Math.max(parsed.cost, config.authScryptCost) : config.authScryptCost;
}

export interface CustomCredentialVerification {
  matches: boolean;
  /** True when the stored digest uses a retired syntax or a verification-only fallback key. */
  needsUpgrade: boolean;
}

/**
 * Verify a durable password against the active pepper and then the bounded fallback ring.
 *
 * Most requests perform exactly one scrypt derivation. Extra work occurs only during the short
 * rotation overlap and only for accounts that have not yet logged in. The caller compare-and-set
 * rewrites a successful fallback digest with the active key so the cost converges back to one KDF
 * without an offline plaintext-password migration.
 */
export async function verifyCustomCredential(
  playerId: string,
  storedHash: string,
  credential: string,
): Promise<CustomCredentialVerification> {
  const parsed = parseScryptHash(storedHash);
  const secrets = authenticationCredentialSecrets();
  for (let index = 0; index < secrets.length; index += 1) {
    const secret = secrets[index]!;
    if (!parsed) {
      if (tokensMatch(storedHash, legacyCredentialHash(playerId, credential, secret))) {
        return { matches: true, needsUpgrade: true };
      }
      continue;
    }
    const candidate = await deriveScryptKey(
      passwordMaterial(playerId, credential, secret),
      parsed.salt,
      parsed.cost,
    );
    if (candidate.length === parsed.digest.length && timingSafeEqual(candidate, parsed.digest)) {
      // A temporary capacity rollback may lower the configured factor for newly created
      // passwords. Never rewrite an already stronger digest downward during that period.
      return { matches: true, needsUpgrade: index > 0 || parsed.cost < config.authScryptCost };
    }
  }
  return { matches: false, needsUpgrade: false };
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
    ? (await verifyCustomCredential(doc.id, doc.authTokenHash, credential)).matches
    : false;
  return passwordMatches;
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
  /** Exact normalized locale captured by the first account-creation request. */
  locale?: string;
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
  // This function is reused below the HTTP handlers, so validate opaque client metadata here
  // before spending password-hash work or opening a MongoDB write. In particular, preserving the
  // exact token prevents the indexed document and embedded DatabasePlayer DTO from disagreeing
  // when an internal caller supplies undefined, padded, overlong, or control-bearing input.
  const exactToken = exactDeviceToken(deviceToken ?? "");
  const exactLocale = normalizeLocale(options.locale ?? "en");
  const exactGameCenterId = options.gameCenterId === undefined
    ? undefined
    : normalizeIdentityExternalId("gameCenter", options.gameCenterId);
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
  // Validate at the reusable service boundary too: an internal caller must not bypass the HTTP
  // parser and persist free text that later boot/notification/profile authority will reject.
  player.locale = exactLocale;
  const createdAtUnix = unixNow();
  // A new account is returned to public profile lookups before it necessarily sends action 29.
  // Initialize the recovered LastAction heartbeat with the same frozen boot timestamp used by
  // progression so squad/chat rosters do not immediately downgrade this Online profile Offline.
  player.lastAction = createdAtUnix;
  player.deviceToken = exactToken;
  if (exactGameCenterId) player.gameCenterId = exactGameCenterId;

  let doc: PlayerDocument;
  try {
    doc = await insertPlayer({
      id,
      accountName: player.accountName,
      normalizedAccountName: player.accountName.toLocaleLowerCase("en-US"),
      authToken,
      ...(authTokenHash ? { authTokenHash } : {}),
      accountType,
      ...(exactGameCenterId ? { gameCenterId: exactGameCenterId } : {}),
      deviceToken: exactToken,
      leagueTier: player.leagueTier,
      armyPower: player.armyPower,
      experience: player.experience,
      squadPoints: player.squadPoints,
      squadName: player.squadName,
      player,
      progression: createInitialProgression(createdAtUnix),
    }, options.session);
  } catch (error) {
    if (isDuplicateAccountName(error)) {
      throw new ApiError(ApiErrorCode.UnknownAction, "Player name is already in use.");
    }
    throw error;
  }

  const created = { doc, player, authToken };
  if (!options.deferLogging) logCreatedAccount(created, exactToken || undefined);
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
  locale = "en",
): Promise<CreatedAccount> {
  const credential = validateCustomCredential(credentialValue);
  return createCustomAccount(accountName, AccountType.Guest, deviceToken, {
    customCredential: credential,
    locale,
  });
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
  locale = "en",
  providerProof?: unknown,
): Promise<CreatedAccount> {
  // The platform ID is an opaque authentication identifier, not display text. Silent trimming
  // could bind a request to a different account, so the reusable service enforces the same exact
  // identity contract as the request parser before starting its account/identity transaction.
  const gameCenterId = normalizeIdentityExternalId("gameCenter", externalIdValue);
  // Provider I/O occurs before the MongoDB transaction. The signed proof is short-lived but
  // repeatable during its bounded window, so an aborted transaction can retry without storing it.
  await verifyGameCenterIdentityOwnership(gameCenterId, providerProof);
  const created = await withMongoTransaction(async (session) => {
    const account = await createCustomAccount("", AccountType.GameCenter, deviceToken, {
      session,
      gameCenterId,
      deferLogging: true,
      locale,
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
  logCreatedAccount(created, created.player.deviceToken || undefined);
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
  providerProof?: unknown,
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
    // Check the server-owned moderation record only after proving account ownership. This avoids
    // turning a public player ID into a ban-status oracle while still terminating already-issued
    // gameplay sessions as soon as an operator activates a sanction. A proven credential clears
    // its brute-force reservation first so repeated banned-login retries cannot create a false
    // credential lock that survives after the sanction ends.
    await assertPlayerNotSanctioned(doc);
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

  const customPasswordVerification = doc && allowCustomPassword && typeof doc.authTokenHash === "string"
    ? await verifyCustomCredential(doc.id, doc.authTokenHash, token)
    : { matches: false, needsUpgrade: false };
  if (doc && customPasswordVerification.matches) {
    if (loginReservation) await clearLoginAttempt(loginReservation);
    // A banned login must not rotate or upgrade any credential. The stock client receives its
    // exact AccountBanned contract and keeps the existing account data for a later retry.
    await assertPlayerNotSanctioned(doc);
    if (customCredentialHashNeedsUpgrade(doc.authTokenHash) || customPasswordVerification.needsUpgrade) {
      const legacyHash = doc.authTokenHash!;
      const upgradedHash = await hashCustomCredential(
        doc.id,
        token,
        customCredentialRehashCost(legacyHash),
      );
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
  let identityPlayer: PlayerDocument | null;
  try {
    identityPlayer = provider ? await authenticateIdentity(provider, id, token, providerProof) : null;
  } catch (error) {
    // A provider outage is not a bad credential. Remove only this exact reservation so Facebook,
    // Game Center, or a future live verifier cannot lock a valid player out during an outage.
    if (loginReservation
      && error instanceof ApiError
      && error.code === ApiErrorCode.InternalServerError) {
      await clearLoginAttempt(loginReservation);
    }
    throw error;
  }
  if (identityPlayer) {
    if (loginReservation) await clearLoginAttempt(loginReservation);
    await assertPlayerNotSanctioned(identityPlayer);
    await rotateAuthenticatedSession(identityPlayer, { allowConcurrentWinner: true });
    logger.auth.login(id, true, { playerId: identityPlayer.id, provider });
    return identityPlayer;
  }

  logger.auth.login(id, false);
  throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Invalid credentials.");
}

/**
 * Prove ownership for the external moderation-appeal API without reopening gameplay access.
 *
 * This deliberately accepts only the current server-issued session credential. It does not check
 * a human password or platform token, rotate a session, clear login throttles, or skip any normal
 * credential comparison. The sole difference from gameplay authentication is that an otherwise
 * valid sanctioned account is returned instead of receiving AccountBanned, allowing a support
 * frontend to submit an appeal while every game route remains blocked.
 */
export async function authenticateModerationAppealSession(
  id: string | undefined,
  token: string | undefined,
): Promise<PlayerDocument> {
  if (!id || !token || id.length > 256 || token.length > 4096) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Invalid support credentials.");
  }
  const player = await findById(id);
  if (!player || !(await playerCredentialMatches(player, token, false))) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Invalid support credentials.");
  }
  return player;
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
