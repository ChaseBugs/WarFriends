import type { PlayerDocument } from "../db";
import { AccountType } from "../constants";
import {
  validatedFacebookPlayerId,
  validatedOptionalStringPlayerId,
} from "./identityExternalIdAuthorityService";

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

/**
 * Preserve a legitimate lookup miss while proving every document returned by a shared lookup.
 *
 * Keeping this nullable adapter beside the mirror proof prevents callers from accidentally
 * treating damaged authority as "player not found". A missing row remains `null`; an existing
 * split-brain row throws and the request fails closed before authentication or gameplay logic can
 * select by one root value while consuming a different value from DatabasePlayerDTO.
 */
export function validatedPlayerProfileLookup(player: PlayerDocument | null): PlayerDocument | null {
  return player === null ? null : validatedPlayerProfileMirrors(player);
}
