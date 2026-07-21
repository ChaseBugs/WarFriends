import type { PlayerDocument } from "../db";

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
  const valid = player.id === dto.id
    && player.accountName === dto.accountName
    && player.accountType === dto.accountType
    // Sparse provider indexes omit disconnected identities. Normalize absence to the exact
    // sentinel/empty values consumed by DatabasePlayer rather than requiring empty root keys.
    && (player.facebookId ?? "-1") === String(dto.facebookId)
    && (player.googlePlayId ?? "") === dto.googlePlayId
    && (player.gameCenterId ?? "") === dto.gameCenterId
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
