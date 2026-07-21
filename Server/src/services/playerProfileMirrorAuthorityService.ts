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
    && Object.is(player.leagueTier, dto.leagueTier)
    && Object.is(player.armyPower, dto.armyPower)
    && Object.is(player.experience, dto.experience)
    && Object.is(player.squadPoints, dto.squadPoints)
    && player.squadName === dto.squadName;
  if (!valid) throw new Error("Stored player profile mirrors are inconsistent.");
  return player;
}
