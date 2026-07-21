import { SquadRank } from "../constants";
import { players, type PlayerDocument, type PlayerProgressionState, type SquadDocument } from "../db";
import { progressionForPlayer } from "./playerStateService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { validatedPlayerPrivateAccountFields } from "./playerProfileMirrorAuthorityService";
import { reclaimDepositedCardsForDepartureState } from "./squadCardPoolService";

export type SquadIntegrityIssueCode =
  | "DUPLICATE_ROSTER_ENTRY"
  | "MULTIPLE_SQUAD_MEMBERSHIPS"
  | "MISSING_ROSTER_PLAYER"
  | "FOUNDER_NOT_IN_ROSTER"
  | "INVALID_LEADER_SET"
  | "INVALID_ROSTER_RANK"
  | "PLAYER_MIRROR_MISMATCH"
  | "ORPHANED_DEPOSITED_CARDS"
  | "UNREADABLE_DEPOSITED_CARDS";

export interface SquadIntegrityIssue {
  code: SquadIntegrityIssueCode;
  subject: string;
  message: string;
  repairable: boolean;
}

export interface SquadIntegrityPlayerRepair {
  playerId: string;
  expectedUpdatedAt: Date;
  squadName: string;
  squadRank: SquadRank;
  clearDepositedCards: boolean;
  progression?: PlayerProgressionState;
}

export interface SquadIntegrityReport {
  issues: SquadIntegrityIssue[];
  repairs: SquadIntegrityPlayerRepair[];
}

interface RosterMembership {
  squad: SquadDocument;
  rank: SquadRank;
}

const VALID_MEMBER_RANKS = new Set<SquadRank>([
  SquadRank.Member,
  SquadRank.Veteran,
  SquadRank.Coleader,
  SquadRank.Leader,
]);

/**
 * Audit legacy squad/player membership without changing either input snapshot.
 *
 * `squads.members` is the recovered backend's membership authority. A player mirror is safe to
 * repair only when the player occurs in zero or one roster. Duplicate membership, missing
 * founders, missing accounts, and ambiguous leader sets are reported for manual resolution;
 * guessing which roster should win would silently transfer authority between squads.
 */
export function inspectSquadIntegrity(
  squadDocuments: readonly SquadDocument[],
  playerDocuments: readonly PlayerDocument[],
): SquadIntegrityReport {
  const issues: SquadIntegrityIssue[] = [];
  const repairs: SquadIntegrityPlayerRepair[] = [];
  const playersById = new Map(playerDocuments.map((player) => [player.id, player]));
  const memberships = new Map<string, RosterMembership[]>();
  const blockedSquads = new Set<string>();

  for (const squad of squadDocuments) {
    const seen = new Set<string>();
    for (const member of squad.members) {
      if (seen.has(member.playerId)) {
        blockedSquads.add(squad.name);
        issues.push({
          code: "DUPLICATE_ROSTER_ENTRY",
          subject: squad.name,
          message: `Player ${member.playerId} occurs more than once in the roster.`,
          repairable: false,
        });
      }
      seen.add(member.playerId);
      const rows = memberships.get(member.playerId) ?? [];
      rows.push({ squad, rank: member.rank });
      memberships.set(member.playerId, rows);

      if (!playersById.has(member.playerId)) {
        issues.push({
          code: "MISSING_ROSTER_PLAYER",
          subject: `${squad.name}/${member.playerId}`,
          message: "The roster references a player document that does not exist.",
          repairable: false,
        });
      }
      if (!VALID_MEMBER_RANKS.has(member.rank)) {
        blockedSquads.add(squad.name);
        issues.push({
          code: "INVALID_ROSTER_RANK",
          subject: `${squad.name}/${member.playerId}`,
          message: `Roster rank ${member.rank} is not a valid member rank.`,
          repairable: false,
        });
      }
    }

    if (!squad.members.some((member) => member.playerId === squad.founderId)) {
      blockedSquads.add(squad.name);
      issues.push({
        code: "FOUNDER_NOT_IN_ROSTER",
        subject: squad.name,
        message: `Founder ${squad.founderId} is absent from the roster.`,
        repairable: false,
      });
    }
    const leaders = squad.members.filter((member) => member.rank === SquadRank.Leader);
    if (leaders.length !== 1 || leaders[0]?.playerId !== squad.founderId) {
      blockedSquads.add(squad.name);
      issues.push({
        code: "INVALID_LEADER_SET",
        subject: squad.name,
        message: "The roster must contain exactly one Leader and that player must be the founder.",
        repairable: false,
      });
    }
  }

  for (const [playerId, rows] of memberships) {
    if (new Set(rows.map((row) => row.squad.name)).size > 1) {
      issues.push({
        code: "MULTIPLE_SQUAD_MEMBERSHIPS",
        subject: playerId,
        message: `Player occurs in multiple squads: ${[...new Set(rows.map((row) => row.squad.name))].join(", ")}.`,
        repairable: false,
      });
    }
  }

  for (const player of playerDocuments) {
    const rows = memberships.get(player.id) ?? [];
    const distinctSquads = new Set(rows.map((row) => row.squad.name));
    if (rows.length > 1 || distinctSquads.size > 1) continue;

    const membership = rows[0];
    // Never project a damaged roster's authority into the player document. An operator must
    // first resolve its founder/leader/rank ambiguity, then rerun this deterministic mirror pass.
    if (membership && blockedSquads.has(membership.squad.name)) continue;
    const expectedSquadName = membership?.squad.name ?? "";
    const expectedRank = membership?.rank ?? SquadRank.None;
    let needsRepair = false;
    let clearDepositedCards = false;
    let repairedProgression: PlayerProgressionState | undefined;

    if (player.squadName !== expectedSquadName
      || player.player.squadName !== expectedSquadName
      || player.player.squadRank !== expectedRank) {
      issues.push({
        code: "PLAYER_MIRROR_MISMATCH",
        subject: player.id,
        message: `Player mirror is ${player.player.squadName || "<none>"}/${player.player.squadRank}; roster requires ${expectedSquadName || "<none>"}/${expectedRank}.`,
        repairable: true,
      });
      needsRepair = true;
    }

    const depositedCards = player.player.depositedCardsDic ?? {};
    if (!membership && Object.keys(depositedCards).length > 0) {
      try {
        const currentProgression = progressionForPlayer(player);
        const reclaim = reclaimDepositedCardsForDepartureState(currentProgression, depositedCards);
        repairedProgression = reclaim.returnedCardIds.length > 0
          ? validatedProgressionSuccessor(currentProgression, reclaim.state)
          : undefined;
        clearDepositedCards = true;
        needsRepair = true;
        issues.push({
          code: "ORPHANED_DEPOSITED_CARDS",
          subject: player.id,
          message: `Player has no roster membership; ${reclaim.returnedCardIds.length} normal deposited cards can be returned and the pool mirror cleared.`,
          repairable: true,
        });
      } catch (error) {
        issues.push({
          code: "UNREADABLE_DEPOSITED_CARDS",
          subject: player.id,
          message: error instanceof Error ? error.message : String(error),
          repairable: false,
        });
      }
    }

    if (needsRepair) {
      repairs.push({
        playerId: player.id,
        expectedUpdatedAt: player.updatedAt,
        squadName: expectedSquadName,
        squadRank: expectedRank,
        clearDepositedCards,
        ...(repairedProgression ? { progression: repairedProgression } : {}),
      });
    }
  }

  return { issues, repairs };
}

/** Apply only unambiguous player repairs and reject any row changed since the audit snapshot. */
export async function applySquadIntegrityRepairs(
  repairs: readonly SquadIntegrityPlayerRepair[],
): Promise<{ applied: number; conflicts: string[] }> {
  let applied = 0;
  const conflicts: string[] = [];
  for (const repair of repairs) {
    let canonicalProgression: PlayerProgressionState | undefined;
    if (repair.progression) {
      // Repair plans are operator-controlled input and may be applied well after generation.
      // Reload the exact audit snapshot before accepting a full progression replacement; the
      // following updatedAt predicate still catches a race between this proof and the write.
      const live = await players().findOne({ id: repair.playerId, updatedAt: repair.expectedUpdatedAt });
      if (!live) {
        conflicts.push(repair.playerId);
        continue;
      }
      // This operator action is explicitly allowed to repair squad profile mirrors, so applying the
      // complete mirror validator here would make the repair impossible. Still prove credentials,
      // identity shape, device data, and audit dates before accepting its progression replacement.
      validatedPlayerPrivateAccountFields(live);
      const successor = validatedProgressionSuccessor(progressionForPlayer(live), repair.progression);
      const { dogTags: _legacyDogTags, ...canonical } = successor;
      canonicalProgression = canonical;
    }
    const result = await players().updateOne(
      { id: repair.playerId, updatedAt: repair.expectedUpdatedAt },
      {
        $set: {
          squadName: repair.squadName,
          "player.squadName": repair.squadName,
          "player.squadRank": repair.squadRank,
          ...(repair.clearDepositedCards ? { "player.depositedCardsDic": {} } : {}),
          ...(canonicalProgression ? { progression: canonicalProgression } : {}),
          updatedAt: new Date(),
        },
      },
    );
    if (result.modifiedCount === 1) applied += 1;
    else conflicts.push(repair.playerId);
  }
  return { applied, conflicts };
}
