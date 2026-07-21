import type { ClientSession } from "mongodb";
import { config } from "../config";
import {
  messages,
  players,
  squads,
  squadWarRounds,
  squadWarSeasons,
  withMongoTransaction,
  type PlayerDocument,
  type SquadDocument,
  type SquadWarEntry,
  type SquadWarMemberScore,
  type SquadWarRoundDocument,
  type SquadWarSeasonDocument,
} from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { squadWarSeasonDurationSeconds } from "./competitionSchedulerPolicyService";
import { buildDatabasePlayer } from "./playerStateService";
import { progressionForPlayer } from "./playerStateService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { completeFirstSquadWarAchievementState } from "./achievementService";
import type { MessageDoc } from "./socialService";
import { validatedInboxRewardMessage } from "./inboxRewardAuthorityService";
import {
  rankSquadWarDivision,
  SQUAD_WAR_MAX_DIVISION_SIZE,
  SQUAD_WAR_MAX_LEVEL,
  SQUAD_WAR_MIN_LEVEL,
  squadWarMemberReward,
  squadWarRoundId,
  squadWarWindowAt,
} from "./squadWarContract";
import { integerNumberAttribute } from "./dynamoNumberAttributeService";
import { nextSquadUpdatedAt, validatedSquadDocument } from "./squadAuthorityService";

const MAX_UNIX_SECONDS = 2_147_483_647;
const SQUAD_WAR_SEASON_KEYS = new Set([
  "_id", "seasonId", "startsAt", "endsAt", "status", "createdAt", "settledAt",
]);
const SQUAD_WAR_ROUND_KEYS = new Set([
  "_id", "roundId", "seasonId", "level", "division", "startsAt", "endsAt", "status",
  "entries", "revision", "createdAt", "updatedAt", "settledAt",
]);
const SQUAD_WAR_ENTRY_KEYS = new Set(["squadId", "squadIcon", "baseScore", "score", "wins", "members"]);
const SQUAD_WAR_MEMBER_KEYS = new Set(["playerId", "name", "score", "rewardEligible"]);

function safeWarDate(value: unknown): value is Date {
  return value instanceof Date
    && Number.isSafeInteger(value.getTime())
    && value.getTime() >= 0
    && value.getTime() <= MAX_UNIX_SECONDS * 1_000;
}

/**
 * Prove one immutable Squad War scheduling row before it selects a division or settlement path.
 *
 * The reconstructed season ID encodes its exact UTC start second. Requiring that binding prevents
 * a damaged row from aliasing another window, while the status-specific timestamp shape keeps an
 * active season from carrying a terminal marker or a settled season from reopening after an
 * operator changes the configured duration. Application time is optional for historical audits;
 * live callers provide it so future creation or settlement timestamps fail closed.
 */
export function validatedSquadWarSeason(
  season: SquadWarSeasonDocument,
  now?: Date,
): SquadWarSeasonDocument {
  const raw = season as unknown as Record<string, unknown>;
  const keysValid = !!season
    && typeof season === "object"
    && !Array.isArray(season)
    && Object.keys(raw).every((key) => SQUAD_WAR_SEASON_KEYS.has(key));
  const datesValid = keysValid
    && safeWarDate(season.startsAt)
    && safeWarDate(season.endsAt)
    && safeWarDate(season.createdAt)
    && season.startsAt.getMilliseconds() === 0
    && season.endsAt.getMilliseconds() === 0
    && season.startsAt.getTime() < season.endsAt.getTime()
    && season.endsAt.getTime() - season.startsAt.getTime() >= 3_600_000
    && season.createdAt.getTime() >= season.startsAt.getTime()
    && season.createdAt.getTime() < season.endsAt.getTime()
    && (now === undefined || (safeWarDate(now) && season.createdAt.getTime() <= now.getTime()));
  const expectedId = datesValid
    ? `sw${Math.floor(season.startsAt.getTime() / 1_000).toString(36)}`
    : "";
  const activeValid = season?.status === "active" && season.settledAt === undefined;
  const settledValid = season?.status === "settled"
    && safeWarDate(season.settledAt)
    && season.settledAt.getTime() >= season.endsAt.getTime()
    && (now === undefined || season.settledAt.getTime() <= now.getTime());
  if (!datesValid || season.seasonId !== expectedId || (!activeValid && !settledValid)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored Squad Wars season authority is invalid.");
  }
  return season;
}

function boundedWarText(value: unknown, minimum: number, maximum: number): value is string {
  return typeof value === "string"
    && value.length >= minimum
    && value.length <= maximum
    && value.trim() === value
    && !/[\u0000-\u001f\u007f]/u.test(value);
}

/**
 * Validate one complete Squad War division before it can affect score, placement, or rewards.
 *
 * Entry score is deliberately required to equal the sum of its member contributions. Both are
 * incremented by the same confirmed match transition, so a mismatch is damaged authority rather
 * than a legacy representation. Proving every entry—not only the participant being updated—also
 * prevents unrelated corruption from influencing deterministic placement at final settlement.
 */
export function validatedSquadWarRound(
  round: SquadWarRoundDocument,
  season?: SquadWarSeasonDocument,
  now?: Date,
): SquadWarRoundDocument {
  const raw = round as unknown as Record<string, unknown>;
  const outerValid = !!round
    && typeof round === "object"
    && !Array.isArray(round)
    && Object.keys(raw).every((key) => SQUAD_WAR_ROUND_KEYS.has(key))
    && /^sw[0-9a-z]+$/u.test(round.seasonId)
    && Number.isSafeInteger(round.level)
    && round.level >= SQUAD_WAR_MIN_LEVEL
    && round.level <= SQUAD_WAR_MAX_LEVEL
    && Number.isSafeInteger(round.division)
    && round.division >= 0
    && round.division <= MAX_UNIX_SECONDS
    && round.roundId === squadWarRoundId(round.level, { seasonId: round.seasonId }, round.division)
    && safeWarDate(round.startsAt)
    && safeWarDate(round.endsAt)
    && safeWarDate(round.createdAt)
    && safeWarDate(round.updatedAt)
    && round.startsAt.getMilliseconds() === 0
    && round.endsAt.getMilliseconds() === 0
    && round.startsAt.getTime() < round.endsAt.getTime()
    && round.createdAt.getTime() >= round.startsAt.getTime()
    && round.createdAt.getTime() < round.endsAt.getTime()
    && round.updatedAt.getTime() >= round.createdAt.getTime()
    && Number.isSafeInteger(round.revision)
    && round.revision >= 0
    && round.revision < Number.MAX_SAFE_INTEGER
    && Array.isArray(round.entries)
    && round.entries.length >= 1
    && round.entries.length <= SQUAD_WAR_MAX_DIVISION_SIZE
    && (now === undefined || (safeWarDate(now) && round.updatedAt.getTime() <= now.getTime()));
  const stateValid = outerValid && ((round.status === "active"
    // Roster leave/kick can revoke eligibility after the score window closes but before the
    // leased scheduler settles the round. Scoring has its own strict half-open window proof, so
    // retaining this audit update does not reopen points while avoiding a blocked squad mutation.
    && round.settledAt === undefined)
    || (round.status === "settled"
      && safeWarDate(round.settledAt)
      && round.settledAt.getTime() >= round.endsAt.getTime()
      && round.updatedAt.getTime() === round.settledAt.getTime()
      && (now === undefined || round.settledAt.getTime() <= now.getTime())));
  const entriesValid = stateValid && round.entries.every((entry) => {
    const entryRaw = entry as unknown as Record<string, unknown>;
    if (!entry || typeof entry !== "object" || Array.isArray(entry)
      || !Object.keys(entryRaw).every((key) => SQUAD_WAR_ENTRY_KEYS.has(key))
      || !boundedWarText(entry.squadId, 3, 24)
      || typeof entry.squadIcon !== "string"
      || entry.squadIcon.length > 4_096
      || /[\u0000-\u001f\u007f]/u.test(entry.squadIcon)
      || !Number.isSafeInteger(entry.baseScore) || entry.baseScore < 0
      || !Number.isSafeInteger(entry.score) || entry.score < 0
      || !Number.isSafeInteger(entry.wins) || entry.wins < 0 || entry.wins > entry.score
      || entry.baseScore > Number.MAX_SAFE_INTEGER - entry.score
      || !Array.isArray(entry.members) || entry.members.length < 1 || entry.members.length > 50) return false;
    let memberScore = 0;
    const memberIds = new Set<string>();
    for (const member of entry.members) {
      const memberRaw = member as unknown as Record<string, unknown>;
      if (!member || typeof member !== "object" || Array.isArray(member)
        || !Object.keys(memberRaw).every((key) => SQUAD_WAR_MEMBER_KEYS.has(key))
        || !boundedWarText(member.playerId, 1, 160)
        || !boundedWarText(member.name, 1, 64)
        || !Number.isSafeInteger(member.score) || member.score < 0
        || (member.rewardEligible !== undefined && typeof member.rewardEligible !== "boolean")
        || memberIds.has(member.playerId)
        || memberScore > Number.MAX_SAFE_INTEGER - member.score) return false;
      memberIds.add(member.playerId);
      memberScore += member.score;
    }
    return memberScore === entry.score;
  });
  const squadIds = entriesValid ? round.entries.map((entry) => entry.squadId) : [];
  const seasonValid = !season || (validatedSquadWarSeason(season, now)
    && round.seasonId === season.seasonId
    && round.startsAt.getTime() === season.startsAt.getTime()
    && round.endsAt.getTime() === season.endsAt.getTime());
  if (!entriesValid || new Set(squadIds).size !== squadIds.length || !seasonValid) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored Squad Wars round authority is invalid.");
  }
  return round;
}

export type SquadWarProgressStatus =
  | "recorded"
  | "disabled"
  | "no_squad"
  | "not_member"
  // Older receipts may contain these values. New ranked-win settlement prepares every current
  // participant squad first and treats either condition as an invariant failure, preserving the
  // match for retry instead of finalizing it without the confirmed score.
  | "no_active_round"
  | "outside_round"
  | "no_points";

type CurrentSquadWarProgressStatus = Exclude<
  SquadWarProgressStatus,
  "no_active_round" | "outside_round"
>;

/**
 * Decide whether an authoritative match may project Squad War progress.
 *
 * Disabled wars and an explicitly terminal current window have no active destination, so PvP
 * may settle without a projection. An enabled window that is neither active nor terminal is the
 * short season-maintenance gap documented by `ensureActiveSquadWarSeason`; treating that gap as
 * disabled would permanently lose points because the terminal match receipt cannot be applied
 * twice. Throwing before the match transaction asks the client to retry with no partial reward.
 */
export function requireSquadWarSettlementAvailability(
  enabled: boolean,
  hasActiveSeason: boolean,
  hasTerminalSeason: boolean,
): boolean {
  if (!enabled) return false;
  if (hasActiveSeason) return true;
  if (hasTerminalSeason) return false;
  throw new ApiError(
    ApiErrorCode.InternalServerError,
    "Squad Wars season maintenance is still in progress; retry match settlement.",
  );
}

function boundedLevel(value: unknown): number {
  const parsed = Number(value);
  if (!Number.isInteger(parsed)) return SQUAD_WAR_MIN_LEVEL;
  return Math.min(SQUAD_WAR_MAX_LEVEL, Math.max(SQUAD_WAR_MIN_LEVEL, parsed));
}

function squadIcon(squad: Pick<SquadDocument, "emblem">): string {
  return typeof squad.emblem.id === "string" ? squad.emblem.id : JSON.stringify(squad.emblem);
}

function initialEntry(squad: SquadDocument): SquadWarEntry {
  return {
    squadId: squad.name,
    squadIcon: squadIcon(squad),
    baseScore: Math.max(0, Math.floor(squad.squadPoints)),
    score: 0,
    wins: 0,
    // Round-start roster members begin at zero and are reward-eligible. A player who joins later
    // is appended only after a confirmed win, may help placement, but is marked ineligible for
    // the first-week personal reward required by the recovered leave/join warning.
    members: squad.members.map((member) => ({
      playerId: member.playerId,
      name: member.name,
      score: 0,
      rewardEligible: true,
    })),
  };
}

function duplicateKey(error: unknown): boolean {
  return Boolean(error && typeof error === "object" && "code" in error && (error as { code?: unknown }).code === 11000);
}

/**
 * Materialize one deterministic reconstructed season and allocate every existing squad.
 *
 * The season ID's unique index is the cross-node gate. Allocation, round insertion, and squad
 * pointers commit together, so action 124 can never observe a squad assigned to a missing round.
 * A concurrent creator loses the unique-key race and simply reads the committed winner.
 */
export async function ensureActiveSquadWarSeason(now = new Date()): Promise<SquadWarSeasonDocument | null> {
  if (!config.squadWarsEnabled) return null;
  const window = squadWarWindowAt(now, squadWarSeasonDurationSeconds());
  const existing = await squadWarSeasons().findOne({ seasonId: window.seasonId });
  // A settled row is terminal. It must never be reopened merely because an operator shortened
  // the configured duration and the reconstructed window calculation happens to reuse its ID.
  if (existing) {
    validatedSquadWarSeason(existing, now);
    return existing.status === "active" ? existing : null;
  }
  // Never allocate the new window on stale levels. The scheduler first settles every expired
  // round and only then calls this allocator. A request that lands in that short processing gap
  // receives no active season and retries after maintenance instead of overwriting old pointers
  // before their promotion/demotion decisions commit.
  const expiredOrDamaged = await squadWarRounds().findOne({
    $or: [
      { status: "active", endsAt: { $lte: now } },
      { status: "active", endsAt: { $not: { $type: "date" } } },
      { status: { $nin: ["active", "settled"] } },
    ],
  });
  if (expiredOrDamaged) {
    // The old count query could not distinguish an expired valid round from malformed scheduling
    // authority hidden by BSON date/status comparison. Prove the candidate before postponing the
    // new window; corruption must raise an operator-visible failure instead of silently coexisting
    // with a newly allocated season.
    validatedSquadWarRound(expiredOrDamaged, undefined, now);
    return null;
  }

  try {
    return await withMongoTransaction(async (session) => {
      const winner = await squadWarSeasons().findOne({ seasonId: window.seasonId }, { session });
      if (winner) return validatedSquadWarSeason(winner, now);

      const season: SquadWarSeasonDocument = validatedSquadWarSeason({
        seasonId: window.seasonId,
        startsAt: window.startsAt,
        endsAt: window.endsAt,
        status: "active",
        createdAt: now,
      }, now);
      const allSquads = await squads().find({}, { session }).sort({ squadWarLevel: 1, squadPoints: -1, name: 1 }).toArray();
      allSquads.forEach((squad) => validatedSquadDocument(squad, now));
      const rounds: SquadWarRoundDocument[] = [];
      for (let level = SQUAD_WAR_MIN_LEVEL; level <= SQUAD_WAR_MAX_LEVEL; level += 1) {
        const atLevel = allSquads.filter((squad) => boundedLevel(squad.squadWarLevel) === level);
        for (let offset = 0; offset < atLevel.length; offset += SQUAD_WAR_MAX_DIVISION_SIZE) {
          const division = Math.floor(offset / SQUAD_WAR_MAX_DIVISION_SIZE);
          const members = atLevel.slice(offset, offset + SQUAD_WAR_MAX_DIVISION_SIZE);
          const roundId = squadWarRoundId(level, window, division);
          const round: SquadWarRoundDocument = {
            roundId,
            seasonId: window.seasonId,
            level,
            division,
            startsAt: window.startsAt,
            endsAt: window.endsAt,
            status: "active",
            entries: members.map(initialEntry),
            revision: 0,
            createdAt: now,
            updatedAt: now,
          };
          validatedSquadWarRound(round, season, now);
          rounds.push(round);
          for (const squad of members) {
            const squadUpdatedAt = nextSquadUpdatedAt(squad, now);
            validatedSquadDocument({
              ...squad,
              squadWarLevel: level,
              squadWarRoundId: roundId,
              leagueId: roundId,
              leagueDivision: window.seasonId,
              updatedAt: squadUpdatedAt,
            }, squadUpdatedAt);
            await squads().updateOne(
              { name: squad.name },
              {
                $set: {
                  squadWarLevel: level,
                  squadWarRoundId: roundId,
                  // AANECPGDMGM parses RoundId from the ordinary squad DTO. Mirror the active
                  // war pointer there while retaining normalized server-only fields above.
                  leagueId: roundId,
                  leagueDivision: window.seasonId,
                  updatedAt: squadUpdatedAt,
                },
              },
              { session },
            );
          }
        }
      }
      if (rounds.length > 0) await squadWarRounds().insertMany(rounds, { session });
      await squadWarSeasons().insertOne(season, { session });
      return season;
    });
  } catch (error) {
    if (!duplicateKey(error)) throw error;
    const committed = await squadWarSeasons().findOne({ seasonId: window.seasonId });
    if (!committed) throw error;
    return validatedSquadWarSeason(committed, now);
  }
}

/** Prepare the current Squad War window before an atomic PvP settlement begins. */
export async function prepareSquadWarSettlement(now = new Date()): Promise<boolean> {
  if (!config.squadWarsEnabled) return false;
  // Database and allocation errors deliberately propagate. Core match rewards have not started,
  // so failing here is retryable and safer than committing a match with permanently missing war
  // score. `ensureActiveSquadWarSeason` returns null only for a terminal or maintenance window.
  const active = await ensureActiveSquadWarSeason(now);
  if (active) return true;
  const window = squadWarWindowAt(now, squadWarSeasonDurationSeconds());
  // Re-read after preparation because another node may have completed allocation between the
  // first check and this classification. A settled row is an intentional no-event window;
  // absence means expired rounds are still being finalized and must be retried.
  const current = await squadWarSeasons().findOne({ seasonId: window.seasonId });
  if (current) validatedSquadWarSeason(current, now);
  return requireSquadWarSettlementAvailability(
    true,
    current?.status === "active",
    current?.status === "settled",
  );
}

/** Assign a squad created after the season snapshot to a bounded level-one division. */
export async function ensureSquadWarAssignment(squadId: string, now = new Date()): Promise<SquadWarRoundDocument | null> {
  const season = await ensureActiveSquadWarSeason(now);
  if (!season) return null;
  return withMongoTransaction(async (session) => {
    const squad = await squads().findOne({ name: squadId }, { session });
    if (!squad) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Squad not found.");
    validatedSquadDocument(squad, now);
    // The round entry is authoritative, while squadWarRoundId is a denormalized client pointer.
    // Search by entry first so a stale or missing pointer is repaired without inserting the same
    // squad into another division. More than one entry is ambiguous corruption and must not be
    // hidden by whichever document MongoDB happens to return first.
    const existingAssignments = await squadWarRounds().find(
      { seasonId: season.seasonId, status: "active", "entries.squadId": squadId },
      { session },
    ).limit(2).toArray();
    existingAssignments.forEach((round) => validatedSquadWarRound(round, season, now));
    if (existingAssignments.length > 1) {
      throw new ApiError(
        ApiErrorCode.InternalServerError,
        `Squad ${squadId} belongs to more than one active Squad Wars division.`,
      );
    }
    if (existingAssignments.length === 1) {
      const assigned = existingAssignments[0]!;
      const pointerNeedsRepair = squad.squadWarRoundId !== assigned.roundId
        || squad.squadWarLevel !== assigned.level
        || squad.leagueId !== assigned.roundId
        || squad.leagueDivision !== season.seasonId;
      if (pointerNeedsRepair) {
        const squadUpdatedAt = nextSquadUpdatedAt(squad, now);
        validatedSquadDocument({
          ...squad,
          squadWarLevel: assigned.level,
          squadWarRoundId: assigned.roundId,
          leagueId: assigned.roundId,
          leagueDivision: season.seasonId,
          updatedAt: squadUpdatedAt,
        }, squadUpdatedAt);
        const repair = await squads().updateOne(
          { name: squadId },
          {
            $set: {
              squadWarLevel: assigned.level,
              squadWarRoundId: assigned.roundId,
              leagueId: assigned.roundId,
              leagueDivision: season.seasonId,
              updatedAt: squadUpdatedAt,
            },
          },
          { session },
        );
        if (repair.matchedCount !== 1) throw new Error(`Squad Wars pointer repair rejected ${squadId}.`);
      }
      return assigned;
    }

    const current = await squadWarRounds().find(
      { seasonId: season.seasonId, level: SQUAD_WAR_MIN_LEVEL, status: "active" },
      { session },
    ).sort({ division: 1 }).toArray();
    current.forEach((round) => validatedSquadWarRound(round, season, now));
    let round: SquadWarRoundDocument | null = current.find(
      (candidate) => candidate.entries.length < SQUAD_WAR_MAX_DIVISION_SIZE,
    ) ?? null;
    if (round) {
      const updated = await squadWarRounds().findOneAndUpdate(
        { roundId: round.roundId, revision: round.revision, status: "active" },
        {
          $push: { entries: initialEntry(squad) },
          $inc: { revision: 1 },
          $set: { updatedAt: now },
        },
        { session, returnDocument: "after" },
      );
      if (!updated) throw new Error(`Concurrent Squad Wars assignment rejected ${squadId}.`);
      round = validatedSquadWarRound(updated, season, now);
    } else {
      const division = current.reduce((maximum, candidate) => Math.max(maximum, candidate.division), -1) + 1;
      const roundId = squadWarRoundId(SQUAD_WAR_MIN_LEVEL, season, division);
      round = {
        roundId,
        seasonId: season.seasonId,
        level: SQUAD_WAR_MIN_LEVEL,
        division,
        startsAt: season.startsAt,
        endsAt: season.endsAt,
        status: "active",
        entries: [initialEntry(squad)],
        revision: 0,
        createdAt: now,
        updatedAt: now,
      };
      validatedSquadWarRound(round, season, now);
      await squadWarRounds().insertOne(round, { session });
    }
    if (!round) throw new Error(`Squad Wars assignment did not create a round for ${squadId}.`);
    const squadUpdatedAt = nextSquadUpdatedAt(squad, now);
    validatedSquadDocument({
      ...squad,
      squadWarLevel: SQUAD_WAR_MIN_LEVEL,
      squadWarRoundId: round.roundId,
      leagueId: round.roundId,
      leagueDivision: season.seasonId,
      updatedAt: squadUpdatedAt,
    }, squadUpdatedAt);
    const assignment = await squads().updateOne(
      { name: squadId },
      {
        $set: {
          squadWarLevel: SQUAD_WAR_MIN_LEVEL,
          squadWarRoundId: round.roundId,
          leagueId: round.roundId,
          leagueDivision: season.seasonId,
          updatedAt: squadUpdatedAt,
        },
      },
      { session },
    );
    if (assignment.matchedCount !== 1) throw new Error(`Squad Wars assignment pointer rejected ${squadId}.`);
    return round;
  });
}

/**
 * Assign every actual participant squad before the terminal match transaction starts.
 *
 * Seasons snapshot the squads that exist at allocation time, but a new squad may be created and
 * play a ranked match without first opening the Squad Wars screen. Preparing from authoritative
 * roster membership closes that UI-order dependency. A membership race is safe: the scoring
 * transaction rechecks the roster and aborts if a newly joined squad still lacks an assignment,
 * then the next retry observes and assigns it here.
 */
export async function prepareSquadWarParticipantAssignments(
  playerIds: readonly string[],
  now = new Date(),
): Promise<void> {
  if (!config.squadWarsEnabled || playerIds.length === 0) return;
  const ids = [...new Set(playerIds.filter(Boolean))];
  if (ids.length === 0) return;
  const participantSquads = await squads().find(
    { "members.playerId": { $in: ids } },
  ).toArray();
  participantSquads.forEach((squad) => validatedSquadDocument(squad, now));
  // At most two squads normally participate, so sequential assignment is inexpensive and avoids
  // manufacturing avoidable revision conflicts when both late squads enter the same division.
  for (const squadId of [...new Set(participantSquads.map((squad) => squad.name))].sort()) {
    const assignment = await ensureSquadWarAssignment(squadId, now);
    if (!assignment) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Squad Wars assignment is not ready; retry match settlement.");
    }
  }
}

/** Prove that an assigned round can accept this confirmed score at the settlement timestamp. */
export function requireSquadWarScoringEntryIndex(
  round: Pick<SquadWarRoundDocument, "roundId" | "startsAt" | "endsAt"> & {
    entries: readonly Pick<SquadWarEntry, "squadId">[];
  },
  squadId: string,
  settledAt: Date,
): number {
  if (settledAt < round.startsAt || settledAt >= round.endsAt) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      `Squad Wars round ${round.roundId} is outside the match settlement window.`,
    );
  }
  const entryIndex = round.entries.findIndex((entry) => entry.squadId === squadId);
  if (entryIndex < 0) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      `Squad ${squadId} is missing from assigned Squad Wars round ${round.roundId}.`,
    );
  }
  return entryIndex;
}

export interface SquadWarReadModel {
  season: SquadWarSeasonDocument;
  round: SquadWarRoundDocument;
  squads: SquadDocument[];
}

/** Resolve action 124 from authenticated membership, never from a client-selected score set. */
export async function getSquadWarDivision(
  player: PlayerDocument,
  requestedRoundId: string,
  now = new Date(),
): Promise<SquadWarReadModel> {
  if (!player.player.squadName) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Player is not in a squad.");
  const round = await ensureSquadWarAssignment(player.player.squadName, now);
  if (!round) throw new ApiError(ApiErrorCode.UnknownAction, "Squad Wars is disabled.");
  // A stale cached RoundId is rejected instead of returning another division under the caller's
  // requested cache key. Refreshing GetSquadDetails supplies the current server-owned pointer.
  if (requestedRoundId !== round.roundId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "RoundId is not the player's active Squad Wars division.");
  }
  const season = await squadWarSeasons().findOne({ seasonId: round.seasonId });
  if (!season) throw new Error(`Squad Wars season ${round.seasonId} is missing.`);
  validatedSquadWarSeason(season, now);
  const docs = await squads().find({ name: { $in: round.entries.map((entry) => entry.squadId) } }).toArray();
  docs.forEach((squad) => validatedSquadDocument(squad, now));
  const byName = new Map(docs.map((doc) => [doc.name, doc]));
  const orderedSquads: SquadDocument[] = [];
  for (const entry of round.entries) {
    const squad = byName.get(entry.squadId);
    if (squad) orderedSquads.push(squad);
  }
  return {
    season,
    round,
    squads: orderedSquads,
  };
}

/** Fields consumed by GetSquadDetails' LEBLKGEOHCC parser. */
export async function getSquadWarDetailFields(squadId: string): Promise<Record<string, unknown>> {
  const round = await ensureSquadWarAssignment(squadId);
  if (!round) return {};
  const ranked = rankSquadWarDivision(round.entries, round.level);
  const position = ranked.find((entry) => entry.squadId === squadId)?.position ?? 0;
  return {
    SquadWarsId: round.seasonId,
    SquadWarsPosition: position,
    WarsEvaluation: Math.floor(round.endsAt.getTime() / 1_000),
  };
}

/** Presence-only GetPlayerData flag used by ServerResultsCache.isSquadWarsProcessing. */
export async function isSquadWarProcessing(now = new Date()): Promise<boolean> {
  if (!config.squadWarsEnabled) return false;
  return (await squadWarRounds().countDocuments(
    { status: "active", endsAt: { $lte: now } },
    { limit: 1 },
  )) > 0;
}

/**
 * Add only score proven by the two-party ranked PvP settlement.
 *
 * This function runs inside the same MongoDB transaction that changes the match from active to
 * finished. The terminal match compare-and-set is therefore the idempotency key: a retry reads a
 * finished match and never reaches this increment again. Client SquadId, SquadWarsId, and local
 * SquadPoints values are deliberately absent from the input.
 */
export async function recordConfirmedSquadWarProgress(
  session: ClientSession,
  playerId: string,
  squadId: string,
  won: boolean,
  confirmedPoints: number,
  settledAt: Date,
): Promise<CurrentSquadWarProgressStatus> {
  if (!config.squadWarsEnabled) return "disabled";
  if (!squadId) return "no_squad";
  if (!won || !Number.isSafeInteger(confirmedPoints) || confirmedPoints <= 0) return "no_points";
  const squad = await squads().findOne({ name: squadId, "members.playerId": playerId }, { session });
  if (!squad) return "not_member";
  validatedSquadDocument(squad, settledAt);
  const roundId = squad.squadWarRoundId ?? "";
  const round = roundId
    ? await squadWarRounds().findOne({ roundId, status: "active", "entries.squadId": squadId }, { session })
    : null;
  // Participant assignment ran before this transaction. Missing authority here therefore means
  // either a concurrent membership change or damaged data. Throwing rolls back both player
  // rewards and the terminal match row; the next retry can assign the new squad or surface the
  // corruption without permanently discarding a ranked win.
  if (!round) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      `Squad ${squadId} has no active Squad Wars assignment; retry match settlement.`,
    );
  }
  validatedSquadWarRound(round, undefined, settledAt);
  const entryIndex = requireSquadWarScoringEntryIndex(round, squadId, settledAt);
  const entry = round.entries[entryIndex]!;
  const rosterMember = squad.members.find((member) => member.playerId === playerId);
  if (!rosterMember) return "not_member";
  const updatedEntry = addConfirmedSquadWarScoreState(
    entry,
    { playerId, name: rosterMember.name },
    confirmedPoints,
  );
  const entries = round.entries.map((candidate, index) => index === entryIndex
    ? updatedEntry
    : candidate);
  validatedSquadWarRound({
    ...round,
    entries,
    revision: round.revision + 1,
    updatedAt: settledAt,
  }, undefined, settledAt);
  const update = await squadWarRounds().updateOne(
    { roundId, status: "active", revision: round.revision },
    { $set: { entries, updatedAt: settledAt }, $inc: { revision: 1 } },
    { session },
  );
  if (update.modifiedCount !== 1) throw new Error(`Concurrent Squad Wars score rejected ${roundId}.`);
  return "recorded";
}

/**
 * Add one server-confirmed ranked win to a Squad War entry without mutating the round snapshot.
 *
 * Squad and member totals later determine placement, personal ordering, Gold, and promotion. All
 * persisted counters therefore have to be safe before the enclosing match transaction publishes
 * its terminal receipt. A damaged counter fails the entire transaction and remains retryable; it
 * is never repaired by dropping points or clamping an unknown historical value.
 */
export function addConfirmedSquadWarScoreState(
  entry: SquadWarEntry,
  player: Pick<SquadWarMemberScore, "playerId" | "name">,
  confirmedPoints: number,
): SquadWarEntry {
  if (!Number.isSafeInteger(confirmedPoints) || confirmedPoints <= 0
    || !Number.isSafeInteger(entry.baseScore) || entry.baseScore < 0
    || !Number.isSafeInteger(entry.score) || entry.score < 0
    || !Number.isSafeInteger(entry.wins) || entry.wins < 0
    || entry.baseScore > Number.MAX_SAFE_INTEGER - entry.score
    || entry.baseScore + entry.score > Number.MAX_SAFE_INTEGER - confirmedPoints
    || entry.score > Number.MAX_SAFE_INTEGER - confirmedPoints
    || entry.wins === Number.MAX_SAFE_INTEGER
    || !Array.isArray(entry.members)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored Squad Wars score is invalid.");
  }
  const members = entry.members.map((member) => {
    if (!member.playerId || typeof member.name !== "string"
      || !Number.isSafeInteger(member.score) || member.score < 0
      || (member.rewardEligible !== undefined && typeof member.rewardEligible !== "boolean")) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Stored Squad Wars member score is invalid.");
    }
    return { ...member };
  });
  if (new Set(members.map((member) => member.playerId)).size !== members.length) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored Squad Wars member roster is duplicated.");
  }

  const memberIndex = members.findIndex((member) => member.playerId === player.playerId);
  if (memberIndex >= 0) {
    const member = members[memberIndex]!;
    if (member.score > Number.MAX_SAFE_INTEGER - confirmedPoints) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Stored Squad Wars member score overflowed.");
    }
    member.score += confirmedPoints;
  } else {
    // The recovered leave/join warning states that a player receives no first-week Squad War
    // reward in the new squad. Their confirmed win still helps the squad's shared placement, but
    // the durable false flag prevents settlement from sending a personal type-9 reward.
    members.push({ ...player, score: confirmedPoints, rewardEligible: false });
  }
  return {
    ...entry,
    score: entry.score + confirmedPoints,
    wins: entry.wins + 1,
    members,
  };
}

/**
 * Permanently revoke this round's personal reward when a member leaves or is kicked.
 *
 * The change shares the enclosing membership transaction: if roster removal fails, eligibility
 * is restored by rollback; if this compare-and-set loses a concurrent score update, the complete
 * transaction aborts and retries from the newer round snapshot. A later rejoin therefore cannot
 * recover the first-week reward, while the player's already-confirmed score remains part of the
 * squad total used for division placement.
 */
export async function invalidateSquadWarRewardEligibility(
  session: ClientSession,
  roundId: string,
  squadId: string,
  playerId: string,
  changedAt: Date,
): Promise<boolean> {
  if (!roundId || !squadId || !playerId) return false;
  const round = await squadWarRounds().findOne({ roundId, status: "active" }, { session });
  if (!round) return false;
  validatedSquadWarRound(round, undefined, changedAt);
  const entryIndex = round.entries.findIndex((entry) => entry.squadId === squadId);
  if (entryIndex < 0) return false;
  const memberIndex = round.entries[entryIndex]!.members.findIndex((member) => member.playerId === playerId);
  if (memberIndex < 0 || round.entries[entryIndex]!.members[memberIndex]!.rewardEligible === false) return false;

  const entries = round.entries.map((entry, currentEntryIndex) => currentEntryIndex === entryIndex
    ? {
      ...entry,
      members: entry.members.map((member, currentMemberIndex) => currentMemberIndex === memberIndex
        ? { ...member, rewardEligible: false }
        : { ...member }),
    }
    : entry);
  validatedSquadWarRound({
    ...round,
    entries,
    revision: round.revision + 1,
    updatedAt: changedAt,
  }, undefined, changedAt);
  const update = await squadWarRounds().updateOne(
    { roundId, status: "active", revision: round.revision },
    { $set: { entries, updatedAt: changedAt }, $inc: { revision: 1 } },
    { session },
  );
  if (update.modifiedCount !== 1) {
    throw new Error(`Concurrent Squad Wars reward eligibility update rejected ${roundId}.`);
  }
  return true;
}

/** Select result recipients from the immutable round roster and the current squad roster. */
export function squadWarRewardEligiblePlayerIds(
  entry: Pick<SquadWarEntry, "members">,
  currentRosterIds: ReadonlySet<string>,
): string[] {
  return entry.members
    .filter((member) => member.rewardEligible !== false && currentRosterIds.has(member.playerId))
    .map((member) => member.playerId);
}

function memberSnapshot(player: PlayerDocument, roundScore: number): Record<string, unknown> {
  const wire = buildDatabasePlayer(player);
  // DatabasePlayer.CreateFromDatabase accepts this DynamoDB attribute and SquadWarManager sorts
  // the message dialog by it. Use round contribution, not the player's lifetime squadPoints.
  wire.SquadPoints = integerNumberAttribute(roundScore);
  return wire;
}

/**
 * Persist the one-time first-Squad-War achievement inside the round settlement transaction.
 *
 * The type-9 result message is the recovered client's proof that this roster member finished
 * the round, so the achievement and that message must commit together. The progression revision
 * predicate protects the complete wallet/inventory document from being overwritten by a reward
 * claim or purchase that raced the scheduler. MongoDB retries a transient transaction conflict;
 * a non-transient mismatch aborts the whole settlement instead of delivering only half the
 * outcome. Legacy accounts without progression are migrated by the same guarded replacement.
 */
async function completeFirstSquadWarAchievement(
  player: PlayerDocument,
  session: ClientSession,
  now: Date,
): Promise<void> {
  const current = progressionForPlayer(player);
  const completed = completeFirstSquadWarAchievementState(current);
  if (completed.state === current) return;
  const successor = validatedProgressionSuccessor(current, completed.state);

  const rawRevision = player.progression?.revision;
  const progressionFilter = player.progression
    ? rawRevision === undefined
      ? { "progression.revision": { $exists: false } }
      : { "progression.revision": rawRevision }
    : { progression: { $exists: false } };
  const { dogTags: _legacyDogTags, ...canonicalState } = successor;
  const update = await players().updateOne(
    { id: player.id, ...progressionFilter },
    { $set: { progression: canonicalState, updatedAt: now } },
    { session },
  );
  if (update.modifiedCount !== 1) {
    throw new Error(`Concurrent first Squad War achievement update rejected for ${player.id}.`);
  }
}

/** Settle one expired division, including deterministic type-9 claim messages. */
export async function settleSquadWarRound(roundId: string, now = new Date()): Promise<{ settled: boolean; messages: number }> {
  return withMongoTransaction(async (session) => {
    const round = await squadWarRounds().findOne({ roundId }, { session });
    if (!round) return { settled: false, messages: 0 };
    const season = await squadWarSeasons().findOne({ seasonId: round.seasonId }, { session });
    if (!season) throw new Error(`Squad Wars season ${round.seasonId} is missing.`);
    validatedSquadWarRound(round, season, now);
    if (round.status === "settled") return { settled: false, messages: 0 };
    if (round.endsAt > now) return { settled: false, messages: 0 };

    const placements = rankSquadWarDivision(round.entries, round.level);
    let insertedMessages = 0;
    for (const placement of placements) {
      const entry = round.entries.find((candidate) => candidate.squadId === placement.squadId)!;
      const squad = await squads().findOne({ name: placement.squadId }, { session });
      if (!squad) continue;
      validatedSquadDocument(squad, now);
      const currentRosterIds = new Set(squad.members.map((member) => member.playerId));
      const eligiblePlayerIds = squadWarRewardEligiblePlayerIds(entry, currentRosterIds);
      const playerDocs = eligiblePlayerIds.length > 0
        ? await players().find({ id: { $in: eligiblePlayerIds } }, { session }).toArray()
        : [];
      const roundScoreByPlayer = new Map(entry.members.map((member) => [member.playerId, member.score]));
      const rankedMembers = [...playerDocs].sort((left, right) =>
        (roundScoreByPlayer.get(right.id) ?? 0) - (roundScoreByPlayer.get(left.id) ?? 0)
        || left.id.localeCompare(right.id, "en"));
      const squadMembersJson = JSON.stringify(
        rankedMembers.map((member) => memberSnapshot(member, roundScoreByPlayer.get(member.id) ?? 0)),
      );
      for (let index = 0; index < rankedMembers.length; index += 1) {
        const member = rankedMembers[index]!;
        const rewardGold = squadWarMemberReward(placement.tier, round.level, index + 1);
        // An eligible round-start member finishes the war when this result is issued, including
        // an eligible zero-score member. Couple group 19 to the same transaction so scheduler
        // retries can neither omit the achievement nor increment it twice.
        await completeFirstSquadWarAchievement(member, session, now);
        const message: MessageDoc = {
          messageId: `squad-war-end:${round.roundId}:${member.id}-${Math.floor(now.getTime() / 1_000)}`,
          idempotencyKey: `squad-war-end:${round.roundId}:${member.id}`,
          toPlayerId: member.id,
          fromPlayerId: "server",
          fromName: "Squad Wars",
          body: "Squad Wars division finished.",
          messageType: 9,
          payload: {
            Position: placement.position,
            SquadId: squad.name,
            SquadIcon: entry.squadIcon,
            RewardGold: rewardGold,
            PrevLevelId: round.level,
            NewLevelId: placement.nextLevel,
            SquadMembers: squadMembersJson,
          },
          otherPlayerJson: "",
          read: false,
          ignored: false,
          accepted: false,
          createdAt: now,
        };
        validatedInboxRewardMessage(message);
        const result = await messages().updateOne(
          { idempotencyKey: message.idempotencyKey },
          { $setOnInsert: message },
          { upsert: true, session },
        );
        insertedMessages += result.upsertedCount;
      }
      // Do not clear a pointer already advanced by an operator repair/newer season. This guard
      // makes a delayed old-round settlement unable to roll a squad backward.
      const squadUpdatedAt = nextSquadUpdatedAt(squad, now);
      validatedSquadDocument({
        ...squad,
        squadWarLevel: placement.nextLevel,
        squadWarRoundId: "",
        leagueId: "",
        leagueDivision: "",
        squadWarWins: (squad.squadWarWins ?? 0) + (placement.position === 1 ? 1 : 0),
        updatedAt: squadUpdatedAt,
      }, squadUpdatedAt);
      await squads().updateOne(
        { name: squad.name, squadWarRoundId: round.roundId },
        {
          $set: {
            squadWarLevel: placement.nextLevel,
            squadWarRoundId: "",
            leagueId: "",
            leagueDivision: "",
            updatedAt: squadUpdatedAt,
          },
          ...(placement.position === 1 ? { $inc: { squadWarWins: 1 } } : {}),
        },
        { session },
      );
    }
    validatedSquadWarRound({
      ...round,
      status: "settled",
      settledAt: now,
      updatedAt: now,
      revision: round.revision + 1,
    }, season, now);
    const finish = await squadWarRounds().updateOne(
      { roundId, status: "active", revision: round.revision },
      { $set: { status: "settled", settledAt: now, updatedAt: now }, $inc: { revision: 1 } },
      { session },
    );
    if (finish.modifiedCount !== 1) throw new Error(`Concurrent Squad Wars settlement rejected ${roundId}.`);
    return { settled: true, messages: insertedMessages };
  });
}

/** Settle every expired round, close complete seasons, and allocate the current window. */
export async function maintainSquadWars(
  now = new Date(),
  assertLeaseOwned: () => Promise<void> = async () => undefined,
): Promise<{ rounds: number; messages: number }> {
  if (!config.squadWarsEnabled) return { rounds: 0, messages: 0 };
  await assertLeaseOwned();
  const expired = await squadWarRounds().find({
    $or: [
      { status: "active", endsAt: { $lte: now } },
      { status: "active", endsAt: { $not: { $type: "date" } } },
      { status: { $nin: ["active", "settled"] } },
    ],
  }).sort({ endsAt: 1 }).limit(100).toArray();
  const endedSeasons = await squadWarSeasons().find({
    $or: [
      { status: "active", endsAt: { $lte: now } },
      { status: "active", endsAt: { $not: { $type: "date" } } },
      { status: { $nin: ["active", "settled"] } },
    ],
  }).sort({ endsAt: 1 }).limit(100).toArray();
  // Validate both scheduler batches before the first settlement write. MongoDB comparisons do not
  // make malformed dates/statuses benign; the widened queries deliberately surface them here.
  expired.forEach((round) => validatedSquadWarRound(round, undefined, now));
  endedSeasons.forEach((season) => validatedSquadWarSeason(season, now));
  let rounds = 0;
  let messageCount = 0;
  for (const round of expired) {
    await assertLeaseOwned();
    const result = await settleSquadWarRound(round.roundId, now);
    if (result.settled) rounds += 1;
    messageCount += result.messages;
  }
  // Inspect ended season rows as well as seasons represented by the round batch. This closes an
  // empty season (created while there were no squads) and also completes a season whose last
  // active round was settled by another node between this sweep's initial query and this point.
  for (const season of endedSeasons) {
    await assertLeaseOwned();
    const remaining = await squadWarRounds().findOne({
      seasonId: season.seasonId,
      status: { $ne: "settled" },
    });
    if (remaining) validatedSquadWarRound(remaining, season, now);
    if (!remaining) {
      validatedSquadWarSeason({ ...season, status: "settled", settledAt: now }, now);
      await assertLeaseOwned();
      const closed = await squadWarSeasons().updateOne(
        { seasonId: season.seasonId, status: "active" },
        { $set: { status: "settled", settledAt: now } },
      );
      if (closed.modifiedCount !== 1) {
        throw new Error(`Concurrent Squad Wars season closure rejected ${season.seasonId}.`);
      }
    }
  }
  await assertLeaseOwned();
  await ensureActiveSquadWarSeason(now);
  return { rounds, messages: messageCount };
}
