import { players, squads, type PlayerDocument } from "../db";
import type { RequestEnvelope } from "../dtos";
import { buildDatabasePlayer } from "./playerStateService";
import { validatedSquadDocument } from "./squadAuthorityService";
import { requestedFacebookFriendCount } from "./socialRequestCountService";
import { validatedConnectedIdentityExternalId } from "./identityExternalIdAuthorityService";

export interface FriendsInfoWire extends Record<string, unknown> {
  Friends: Record<string, unknown>[];
  SquadMates: Record<string, unknown>[];
}

/**
 * Recover the dynamic Friend0..FriendN form fields emitted by BeanstalkServerManager.
 *
 * Client 1.6.0 hashes each Facebook numeric ID before sending it, and AddFacebook stores that same
 * signed Int64 decimal string as the account's FacebookId mirror. Preserve the strings exactly:
 * JavaScript Number conversion would lose precision for many valid 64-bit hashes. Count is bounded
 * before dynamic-key access so a modified APK cannot create an unbounded request loop or `$in`.
 */
export function requestedFacebookFriendIds(req: RequestEnvelope): string[] {
  const count = requestedFacebookFriendCount(req.Count);
  const unique = new Set<string>();
  for (let index = 0; index < count; index += 1) {
    const value = req[`Friend${index}`];
    try {
      // Reuse platform-identity authority so lookup hashes cannot have a spelling or range that
      // the connected Facebook mirror and identity index would reject.
      unique.add(validatedConnectedIdentityExternalId("facebook", value));
    } catch {
      // A single modified-client hash is not authority and must not hide otherwise valid friends.
    }
  }
  return [...unique];
}

function uniquePlayers(values: PlayerDocument[], excludedIds = new Set<string>()): PlayerDocument[] {
  const seen = new Set(excludedIds);
  return values.filter((player) => {
    if (seen.has(player.id)) return false;
    seen.add(player.id);
    return true;
  });
}

/**
 * Convert both recovered result groups through the central DatabasePlayer adapter.
 * Facebook friends take precedence when a player also appears in the squad roster because
 * OGLEHLIPEFM concatenates both arrays into one `players` cache without deduplication.
 */
export function buildFriendsInfoWire(
  facebookFriends: PlayerDocument[],
  squadMates: PlayerDocument[],
): FriendsInfoWire {
  const friends = uniquePlayers(facebookFriends);
  const friendPlayerIds = new Set(friends.map((player) => player.id));
  const mates = uniquePlayers(squadMates, friendPlayerIds);
  return {
    Friends: friends.map(buildDatabasePlayer),
    SquadMates: mates.map(buildDatabasePlayer),
  };
}

/**
 * Resolve client-supplied Facebook hashes and the caller's authoritative squad roster.
 *
 * `SquadId` is deliberately ignored. The recovered request includes it only as a cache hint, but
 * trusting that field would let a modified client enumerate any private roster. Squad membership
 * comes from the authenticated player's mirror plus the squad document, and the actor must still
 * exist in that roster. MongoDB result order is normalized back to Friend0..N and roster order so
 * the social UI remains stable across calls.
 */
export async function getFriendsInfo(
  actor: PlayerDocument,
  req: RequestEnvelope,
): Promise<FriendsInfoWire> {
  const friendHashes = requestedFacebookFriendIds(req);
  const friendDocs = friendHashes.length > 0
    ? await players().find({ facebookId: { $in: friendHashes } }).toArray()
    : [];
  const friendByHash = new Map<string, PlayerDocument>();
  for (const player of friendDocs) {
    const hash = String(player.facebookId ?? player.player.facebookId);
    if (!friendByHash.has(hash) && player.id !== actor.id) friendByHash.set(hash, player);
  }
  const orderedFriends = friendHashes
    .map((hash) => friendByHash.get(hash))
    .filter((player): player is PlayerDocument => Boolean(player));

  const squadName = actor.player.squadName || actor.squadName;
  const squad = squadName
    ? await squads().findOne({ name: squadName, "members.playerId": actor.id })
    : null;
  if (squad) validatedSquadDocument(squad);
  const squadPlayerIds = squad?.members
    .map((member) => member.playerId)
    .filter((playerId) => playerId !== actor.id) ?? [];
  const squadDocs = squadPlayerIds.length > 0
    ? await players().find({ id: { $in: squadPlayerIds } }).toArray()
    : [];
  const squadByPlayerId = new Map<string, PlayerDocument>(
    squadDocs.map((player) => [player.id, player] as const),
  );
  const orderedSquadMates = squadPlayerIds
    .map((playerId) => squadByPlayerId.get(playerId))
    .filter((player): player is PlayerDocument => Boolean(player));

  return buildFriendsInfoWire(orderedFriends, orderedSquadMates);
}
