import type { PlayerDocument } from "../db";
import { AccountType, PlayerStatus, SquadRank } from "../constants";
import {
  validatedFacebookPlayerId,
  validatedOptionalStringPlayerId,
} from "./identityExternalIdAuthorityService";
import { isSupportedAuthenticationScryptCost } from "./authSecretService";
import { validatePlayerLeagueIdentity } from "./playerLeagueContract";
import { isCanonicalStoredPlayerName } from "./playerNameContract";
import {
  validatedNotificationSettings,
  validatedPlayerCountry,
  validatedPlayerLocale,
} from "./playerSettingsService";
import {
  validatedPhotonRoutingSnapshot,
} from "./regionPingService";
import { validatePlayerPublicScalarAuthority } from "./playerPublicScalarAuthorityService";

/**
 * Validate the public identity fields that are not duplicated at MongoDB's document root.
 *
 * Equality alone is insufficient authority: a bypassed writer can put the same malformed name in
 * both root and DTO copies, and DatabasePlayer's recovered UI allocates only fifteen characters.
 * Current server writers also trim names and exclude controls, so accepting those shapes only from
 * legacy storage would let search, chat, logs, or leaderboards publish invisible/multiline identity.
 * League identity is checked against DatabasePlayer's real first/last-segment parser; importantly,
 * this does not guess the middle portion of retired production division IDs.
 */
function validatePlayerPublicIdentityFields(player: PlayerDocument): void {
  const dto = player.player;
  if (!isCanonicalStoredPlayerName(dto.accountName)) {
    throw new Error("Stored player public identity is invalid.");
  }
  try {
    validatePlayerLeagueIdentity(dto);
    // Settings are stored inside the DTO rather than duplicated at the root, but the same shared
    // profile boundary is the earliest point that can prevent corrupt consent from reaching push
    // selection or being normalized by an unrelated settings update.
    validatedNotificationSettings(dto.notificationSettings);
    // Country is public DatabasePlayer data and locale selects private boot/notification behavior.
    // Prove their exact stored forms here instead of letting the next handler trim or uppercase a
    // bypassed write and accidentally turn damaged durable metadata into believable authority.
    validatedPlayerCountry(dto.country);
    validatedPlayerLocale(dto.locale);
    validatePlayerPublicScalarAuthority(dto);
    // Action 140 validates new measurements, but legacy imports and bypassed writers can still
    // place malformed routing hints in MongoDB. Prove the entire stored snapshot here so an
    // unrelated heartbeat cannot overwrite connection metadata and hide pre-existing damage.
    validatedPhotonRoutingSnapshot(dto.bestRegions, dto.connectionType);
  } catch {
    throw new Error("Stored player public identity is invalid.");
  }
  // These are direct numeric enums on DatabasePlayer's public wire. JavaScript accepts any number
  // at runtime, but the recovered client defines no fallback value. In particular, presence must
  // not overwrite an unknown stored status and thereby disguise durable damage as a heartbeat.
  const statusValid = dto.status === PlayerStatus.Offline
    || dto.status === PlayerStatus.Online
    || dto.status === PlayerStatus.InGame;
  const squadRankValid = dto.squadRank === SquadRank.None
    || dto.squadRank === SquadRank.Member
    || dto.squadRank === SquadRank.Veteran
    || dto.squadRank === SquadRank.Leader
    || dto.squadRank === SquadRank.Coleader;
  if (!statusValid || !squadRankValid) {
    throw new Error("Stored player public identity is invalid.");
  }
}

/**
 * Prove that MongoDB's indexed player fields still mirror the client-facing DatabasePlayer DTO.
 *
 * The root fields exist only so MongoDB can sort, filter, and match without traversing the large
 * DTO. Neither copy may silently win when they differ: a leaderboard selected by root experience
 * but rendered with `player.experience`, for example, would give the client a false position. The
 * normal write helpers update both copies atomically; a mismatch therefore indicates legacy
 * damage or a publisher that bypassed those helpers and must be repaired explicitly.
 */
export function validatedPlayerProfileMirrors(player: PlayerDocument): PlayerDocument {
  const dto = player.player;
  validatePlayerPublicIdentityFields(player);
  let facebookId: string;
  let googlePlayId: string;
  let gameCenterId: string;
  try {
    facebookId = validatedFacebookPlayerId(dto.facebookId);
    googlePlayId = validatedOptionalStringPlayerId("googlePlay", dto.googlePlayId);
    gameCenterId = validatedOptionalStringPlayerId("gameCenter", dto.gameCenterId);
  } catch {
    throw new Error("Stored player provider identity is invalid.");
  }
  const accountTypeValid = dto.accountType === AccountType.Guest
    || dto.accountType === AccountType.Facebook
    || dto.accountType === AccountType.GooglePlay
    || dto.accountType === AccountType.GameCenter;
  const valid = player.id === dto.id
    && player.accountName === dto.accountName
    && accountTypeValid
    && player.accountType === dto.accountType
    // Sparse provider indexes omit disconnected identities. Normalize absence to the exact
    // sentinel/empty values consumed by DatabasePlayer. A stored empty/sentinel root is damage:
    // it defeats the sparse index and can reserve one pseudo-provider key for every account.
    && (facebookId === "-1" ? player.facebookId === undefined : player.facebookId === facebookId)
    && (googlePlayId === "" ? player.googlePlayId === undefined : player.googlePlayId === googlePlayId)
    && (gameCenterId === "" ? player.gameCenterId === undefined : player.gameCenterId === gameCenterId)
    && (player.deviceToken ?? "") === dto.deviceToken
    && Object.is(player.leagueTier, dto.leagueTier)
    && Object.is(player.armyPower, dto.armyPower)
    && Object.is(player.experience, dto.experience)
    && Object.is(player.squadPoints, dto.squadPoints)
    && player.squadName === dto.squadName;
  if (!valid) throw new Error("Stored player profile mirrors are inconsistent.");
  return player;
}

function validCustomCredentialHash(value: unknown): boolean {
  if (typeof value !== "string") return false;
  // Reconstruction builds before versioned scrypt stored one lower-case SHA-256 HMAC. It remains
  // verification authority only as a bounded migration format and is upgraded after valid login.
  if (/^[0-9a-f]{64}$/u.test(value)) return true;
  const parts = value.split("$");
  if (parts.length !== 7 || parts[0] !== "scrypt" || parts[1] !== "v1") return false;
  const cost = Number(parts[2]);
  return isSupportedAuthenticationScryptCost(cost)
    && parts[2] === String(cost)
    && parts[3] === "8"
    && parts[4] === "1"
    && /^[0-9a-f]{32}$/u.test(parts[5] ?? "")
    && /^[0-9a-f]{64}$/u.test(parts[6] ?? "");
}

type PlayerCredentialProjection = Pick<PlayerDocument, "authToken" | "authTokenHash">;

/**
 * Validate the private credential subset returned by authentication compare-and-set operations.
 *
 * Those reads intentionally project no public profile fields, so they cannot call the complete
 * account-envelope validator. Keeping the exact token and password-digest shapes in this shared
 * adapter prevents the narrow race-resolution path from becoming a weaker credential boundary.
 */
export function validatedPlayerCredentialProjection<T extends PlayerCredentialProjection>(player: T): T {
  const valid = (player.authToken === undefined || /^[0-9a-f]{64}$/u.test(player.authToken))
    && (player.authTokenHash === undefined || validCustomCredentialHash(player.authTokenHash));
  if (!valid) throw new Error("Stored player credential projection is invalid.");
  return player;
}

/**
 * Validate private player-account fields consumed before a request reaches gameplay logic.
 *
 * `authToken` remains optional solely for legacy rows that can prove a durable password/provider
 * credential and receive a newly rotated session. If present, it must be one server-issued HMAC;
 * a corrupt one-character token must never become an easy account credential through exact string
 * comparison. Password hashes accept only the explicit legacy-HMAC migration form or the bounded
 * versioned scrypt form. Profile timestamps are durable optimistic/audit state and must be real.
 */
export function validatedPlayerPrivateAccountFields(player: PlayerDocument): PlayerDocument {
  validatedPlayerCredentialProjection(player);
  const createdAt = player.createdAt instanceof Date ? player.createdAt.getTime() : Number.NaN;
  const updatedAt = player.updatedAt instanceof Date ? player.updatedAt.getTime() : Number.NaN;
  const valid = typeof player.id === "string"
    && player.id.length > 0
    && player.id.length <= 256
    && (player.normalizedAccountName === undefined
      || player.normalizedAccountName === player.accountName.toLocaleLowerCase("en-US"))
    && typeof player.player.deviceToken === "string"
    && player.player.deviceToken.length <= 4096
    && player.player.deviceToken === player.player.deviceToken.trim()
    && Number.isFinite(createdAt)
    && Number.isFinite(updatedAt)
    && updatedAt >= createdAt;
  if (!valid) throw new Error("Stored player account envelope is invalid.");
  return player;
}

/** Prove both the public/indexed mirrors and the private account fields on a complete read. */
export function validatedPlayerAccountEnvelope(player: PlayerDocument): PlayerDocument {
  validatedPlayerProfileMirrors(player);
  return validatedPlayerPrivateAccountFields(player);
}

/**
 * Preserve a legitimate lookup miss while proving every document returned by a shared lookup.
 *
 * Keeping this nullable adapter beside the mirror proof prevents callers from accidentally
 * treating damaged authority as "player not found". A missing row remains `null`; an existing
 * split-brain row throws and the request fails closed before authentication or gameplay logic can
 * select by one root value while consuming a different value from DatabasePlayerDTO.
 */
export function validatedPlayerProfileLookup(player: PlayerDocument | null): PlayerDocument | null {
  return player === null ? null : validatedPlayerAccountEnvelope(player);
}
