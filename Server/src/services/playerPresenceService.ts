import { ApiError, ApiErrorCode } from "../apiErrors";
import { PlayerStatus } from "../constants";
import { matches, players, withMongoTransaction } from "../db";

/** Ranked reservations override client presence; other modes retain their recovered heartbeat. */
export function effectivePlayerStatus(requested: PlayerStatus, hasActiveRankedMatch: boolean): PlayerStatus {
  return hasActiveRankedMatch ? PlayerStatus.InGame : requested;
}

/**
 * Persist one client status report without racing ranked admission or settlement.
 *
 * The match read and player write share a snapshot transaction. If createMatch, cancellation,
 * or settlement changes either document concurrently, MongoDB retries this work against the new
 * state. A client can still report InGame for campaign, co-op, Arena, or friendly Photon play,
 * but cannot write Online/Offline over an active or settling ranked reservation.
 */
export async function setPlayerPresence(playerId: string, requested: PlayerStatus): Promise<PlayerStatus> {
  return withMongoTransaction(async (session) => {
    const player = await players().findOne(
      { id: playerId },
      { session, projection: { id: 1, "player.status": 1 } },
    );
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    const activeMatch = await matches().findOne(
      { "players.playerId": playerId, state: { $in: ["active", "settling"] } },
      { session, projection: { _id: 1 } },
    );
    const effective = effectivePlayerStatus(requested, Boolean(activeMatch));
    if (player.player.status !== effective) {
      const update = await players().updateOne(
        { id: playerId },
        { $set: { "player.status": effective, updatedAt: new Date() } },
        { session },
      );
      if (update.matchedCount !== 1) throw new Error("Concurrent player presence update failed.");
    }
    return effective;
  });
}
