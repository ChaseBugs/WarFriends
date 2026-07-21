import { ApiError, ApiErrorCode } from "../apiErrors";
import { PlayerStatus } from "../constants";
import { matches, players, withMongoTransaction, type PlayerDocument } from "../db";
import { validatedMatchDocument } from "./matchAuthorityService";
import type { MatchDoc } from "./matchService";
import { validatedPlayerLastAction } from "./playerPublicScalarAuthorityService";
import { validatedPlayerAccountEnvelope } from "./playerProfileMirrorAuthorityService";

export interface PlayerPresenceSnapshot {
  status: PlayerStatus;
  lastAction: number;
}

/** Ranked reservations override client presence; other modes retain their recovered heartbeat. */
export function effectivePlayerStatus(requested: PlayerStatus, hasActiveRankedMatch: boolean): PlayerStatus {
  return hasActiveRankedMatch ? PlayerStatus.InGame : requested;
}

/** Build the exact pair consumed by DatabasePlayer.GetRealStatus on other clients. */
export function effectivePlayerPresence(
  requested: PlayerStatus,
  hasActiveRankedMatch: boolean,
  reportedAt: number,
): PlayerPresenceSnapshot {
  return {
    status: effectivePlayerStatus(requested, hasActiveRankedMatch),
    lastAction: validatedPlayerLastAction(reportedAt),
  };
}

/**
 * Prove every complete account before and after a backend-owned presence transition.
 *
 * Match cleanup used to issue one broad `$set` against player IDs. That could overwrite the two
 * visible presence fields on a damaged credential, profile mirror, or progression document and
 * make the row look repaired. Requiring the exact expected identity set also prevents a missing
 * participant from being hidden by MongoDB's successful partial `updateMany` result.
 */
export function validatedPlayerPresenceTransitions(
  documents: readonly PlayerDocument[],
  expectedPlayerIds: readonly string[],
  status: PlayerStatus,
  lastActionValue: number,
  updatedAt: Date,
): PlayerDocument[] {
  const lastAction = validatedPlayerLastAction(lastActionValue);
  const expected = new Set(expectedPlayerIds);
  if (expected.size !== expectedPlayerIds.length || documents.length !== expected.size) {
    throw new Error("Ranked presence transition has an invalid participant set.");
  }

  const seen = new Set<string>();
  return documents.map((document) => {
    if (!expected.has(document.id) || seen.has(document.id)) {
      throw new Error("Ranked presence transition has an invalid participant set.");
    }
    seen.add(document.id);
    // Validate the stored row first; validating only the projected copy would let the fields being
    // replaced conceal existing malformed status, LastAction, or updatedAt authority.
    const current = validatedPlayerAccountEnvelope(document);
    return validatedPlayerAccountEnvelope({
      ...current,
      player: { ...current.player, status, lastAction },
      updatedAt,
    });
  });
}

/**
 * Persist one client status report without racing ranked admission or settlement.
 *
 * The match read and player write share a snapshot transaction. If createMatch, cancellation,
 * or settlement changes either document concurrently, MongoDB retries this work against the new
 * state. A client can still report InGame for campaign, co-op, Arena, or friendly Photon play,
 * but cannot write Online/Offline over an active or settling ranked reservation.
 */
export async function setPlayerPresence(
  playerId: string,
  requested: PlayerStatus,
  reportedAt = Math.floor(Date.now() / 1_000),
): Promise<PlayerPresenceSnapshot> {
  // Freeze and validate the heartbeat before MongoDB can retry the transaction. Recomputing time
  // inside a retry would make one request publish different callback and durable timestamps.
  const lastAction = validatedPlayerLastAction(reportedAt);
  const transitionAt = new Date();
  return withMongoTransaction(async (session) => {
    const player = await players().findOne(
      { id: playerId },
      { session },
    );
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    // Presence touches the public profile and updatedAt. Prove the complete account first so a
    // heartbeat cannot normalize a malformed durable row through an otherwise harmless status.
    validatedPlayerAccountEnvelope(player);
    const activeMatch = await matches().findOne(
      { "players.playerId": playerId, state: { $in: ["active", "settling"] } },
      { session },
    );
    if (activeMatch) validatedMatchDocument(activeMatch as unknown as MatchDoc);
    const effective = effectivePlayerPresence(requested, Boolean(activeMatch), lastAction);
    validatedPlayerPresenceTransitions(
      [player],
      [playerId],
      effective.status,
      effective.lastAction,
      transitionAt,
    );
    if (player.player.status !== effective.status || player.player.lastAction !== effective.lastAction) {
      const update = await players().updateOne(
        { id: playerId },
        {
          $set: {
            // Status without LastAction is not a complete recovered presence update. Remote
            // clients apply their 2700-second freshness rule to this same pair.
            "player.status": effective.status,
            "player.lastAction": effective.lastAction,
            updatedAt: transitionAt,
          },
        },
        { session },
      );
      if (update.matchedCount !== 1) throw new Error("Concurrent player presence update failed.");
    }
    return effective;
  });
}
