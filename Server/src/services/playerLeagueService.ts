import type { ClientSession } from "mongodb";
import { League } from "../constants";
import {
  messages,
  players,
  withMongoTransaction,
  type PlayerDocument,
} from "../db";
import { synchronizeLeagueAchievementState } from "./achievementService";
import { progressionForPlayer } from "./playerStateService";
import type { MessageDoc } from "./socialService";
import {
  managedPlayerLeagueId,
  parseManagedPlayerLeagueId,
  PLAYER_LEAGUE_PLACEMENT_MATCHES,
  playerLeagueSettlementDecision,
} from "./playerLeagueContract";

export interface PlayerLeagueFinishResult {
  finished: boolean;
  settledPlayers: number;
  leagueId?: string;
}

interface PlayerLeagueFinishedMessage extends MessageDoc {
  messageType: 23;
  idempotencyKey: string;
}

function placementLeagueId(tier: League): string {
  return `${tier}-placement`;
}

function isPlacementLeagueId(value: string): boolean {
  return /^([1-9]|1[0-6])-placement$/.test(value);
}

/**
 * Materialize an active division after the recovered one-match placement requirement.
 *
 * The player document is the membership lock: the conditional LeagueId filter means two
 * concurrent leaderboard reads cannot allocate different seasons. A still-open managed ID
 * is returned unchanged, while an expired ID is intentionally left untouched so action 198
 * can rank the complete old division before anyone enters the next season.
 */
export async function ensureActivePlayerLeague(player: PlayerDocument, now: number): Promise<PlayerDocument> {
  if (player.player.beginnersLeague > 0) return player;

  const currentId = player.player.leagueId;
  const managed = parseManagedPlayerLeagueId(currentId);
  if (managed) return player;
  if (currentId && !isPlacementLeagueId(currentId)) return player;
  if (player.player.remainingMatches > 0) return player;

  const tier = Math.min(League.Champion, Math.max(League.Bronze3, player.player.leagueTier)) as League;
  const active = managedPlayerLeagueId(tier, now);
  await players().updateOne(
    { id: player.id, "player.leagueId": currentId, "player.remainingMatches": { $lte: 0 } },
    {
      $set: {
        leagueTier: tier,
        "player.leagueTier": tier,
        "player.leagueId": active.leagueId,
        "player.leagueDivision": active.division,
        "player.remainingMatches": 0,
        updatedAt: new Date(now * 1_000),
      },
    },
  );
  return (await players().findOne({ id: player.id })) ?? player;
}

/** Return the exact stable division ordered by the weekly MedalsBalance competition. */
export async function playersInPlayerLeague(
  leagueId: string,
  session?: ClientSession,
  limit = 100,
): Promise<PlayerDocument[]> {
  if (!parseManagedPlayerLeagueId(leagueId)) return [];
  const cursor = players()
    .find({ "player.leagueId": leagueId }, { session })
    // Position is semantically important at settlement. Deterministic secondary keys keep
    // tied medal totals stable across reads and across backend processes.
    .sort({ "player.medalsBalance": -1, "player.skill": -1, createdAt: 1, id: 1 });
  // The stock screen is designed for at most 100 rows. Settlement passes limit=0 so a
  // temporarily oversized reconstructed division is still resolved as one population; it
  // must never be split into several differently ranked claims merely by repeated action 198.
  if (limit > 0) cursor.limit(Math.min(100, Math.floor(limit)));
  return cursor.toArray();
}

function finishedMessage(
  member: PlayerDocument,
  formerLeagueId: string,
  formerTier: League,
  position: number,
  nextTier: League,
  rewardGold: number,
  notEnoughPlayers: boolean,
  createdAt: Date,
): PlayerLeagueFinishedMessage {
  const idempotencyKey = `player-league-finished:${formerLeagueId}:${member.id}`;
  return {
    messageId: idempotencyKey,
    idempotencyKey,
    toPlayerId: member.id,
    fromPlayerId: "system",
    fromName: "Player League",
    body: "",
    messageType: 23,
    payload: {
      LeagueId: nextTier,
      BeforeLeagueId: formerTier,
      Medals: member.player.medalsBalance,
      FormerFullLeagueId: formerLeagueId,
      Position: position,
      ...(rewardGold > 0 ? { RewardGold: rewardGold } : {}),
      ...(notEnoughPlayers ? { NotEnoughPlayers: 1 } : {}),
    },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt,
  };
}

/**
 * Settle one expired division atomically and enqueue the recovered type-23 result messages.
 *
 * Action 198 has no request fields, so the server derives every rank, tier transition, and
 * reward from the immutable former LeagueId and the stored medal totals. All member updates
 * and messages share one MongoDB transaction: a process failure can neither pay only part of
 * a division nor move a player without the notification that makes the stock client mirror
 * its new placement state. The LeagueId predicate is also the idempotency guard; after a
 * successful commit there are no members left under that former ID.
 */
export async function finishExpiredPlayerLeague(
  requester: PlayerDocument,
  now: number,
): Promise<PlayerLeagueFinishResult> {
  const formerLeagueId = requester.player.leagueId;
  const managed = parseManagedPlayerLeagueId(formerLeagueId);
  if (!managed || managed.endsAt > now) return { finished: false, settledPlayers: 0 };

  return withMongoTransaction(async (session) => {
    const members = await playersInPlayerLeague(formerLeagueId, session, 0);
    if (members.length === 0) {
      // A retry can arrive after another process committed the division. The deterministic
      // message key proves this requester's result exists without granting anything again.
      const existing = await messages().findOne(
        { idempotencyKey: `player-league-finished:${formerLeagueId}:${requester.id}` },
        { session, projection: { _id: 1 } },
      );
      return { finished: Boolean(existing), settledPlayers: 0, leagueId: formerLeagueId };
    }

    const createdAt = new Date(now * 1_000);
    const notifications: PlayerLeagueFinishedMessage[] = [];
    for (let index = 0; index < members.length; index++) {
      const member = members[index]!;
      const position = index + 1;
      const decision = playerLeagueSettlementDecision(managed.tier, position, members.length);
      // Promotion/relegation and AchievementGetToLeague must observe one atomic season result.
      // Keep the achievement's lifetime maximum on demotion, while allowing an earned promotion
      // to unlock the exact MainScene tier before the type-23 inbox message reaches the client.
      const progression = synchronizeLeagueAchievementState(
        progressionForPlayer(member),
        decision.nextTier,
      ).state;
      const set: Record<string, unknown> = {
        progression,
        leagueTier: decision.nextTier,
        "player.leagueTier": decision.nextTier,
        "player.leagueId": placementLeagueId(decision.nextTier),
        "player.leagueDivision": "placement",
        "player.medalsBalance": 0,
        "player.remainingMatches": PLAYER_LEAGUE_PLACEMENT_MATCHES,
        updatedAt: createdAt,
      };

      const update = await players().updateOne(
        { id: member.id, "player.leagueId": formerLeagueId },
        { $set: set },
        { session },
      );
      if (update.modifiedCount !== 1) {
        throw new Error(`Concurrent player-league settlement rejected member ${member.id}.`);
      }
      notifications.push(finishedMessage(
        member,
        formerLeagueId,
        managed.tier,
        position,
        decision.nextTier,
        decision.rewardGold,
        decision.notEnoughPlayers,
        createdAt,
      ));
    }

    await messages().insertMany(notifications, { session, ordered: true });
    return { finished: true, settledPlayers: members.length, leagueId: formerLeagueId };
  });
}
