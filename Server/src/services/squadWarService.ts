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
  type SquadWarRoundDocument,
  type SquadWarSeasonDocument,
} from "../db";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { buildDatabasePlayer } from "./playerStateService";
import { progressionForPlayer } from "./playerStateService";
import { completeFirstSquadWarAchievementState } from "./achievementService";
import type { MessageDoc } from "./socialService";
import {
  rankSquadWarDivision,
  SQUAD_WAR_MAX_DIVISION_SIZE,
  SQUAD_WAR_MAX_LEVEL,
  SQUAD_WAR_MIN_LEVEL,
  squadWarMemberReward,
  squadWarRoundId,
  squadWarWindowAt,
} from "./squadWarContract";

export type SquadWarProgressStatus =
  | "recorded"
  | "disabled"
  | "no_squad"
  | "not_member"
  | "no_active_round"
  | "outside_round"
  | "no_points";

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
  const window = squadWarWindowAt(now, config.squadWarsSeasonDurationSeconds);
  const existing = await squadWarSeasons().findOne({ seasonId: window.seasonId });
  // A settled row is terminal. It must never be reopened merely because an operator shortened
  // the configured duration and the reconstructed window calculation happens to reuse its ID.
  if (existing) return existing.status === "active" ? existing : null;
  // Never allocate the new window on stale levels. The scheduler first settles every expired
  // round and only then calls this allocator. A request that lands in that short processing gap
  // receives no active season and retries after maintenance instead of overwriting old pointers
  // before their promotion/demotion decisions commit.
  const expiredUnsettled = await squadWarRounds().countDocuments(
    { status: "active", endsAt: { $lte: now } },
    { limit: 1 },
  );
  if (expiredUnsettled > 0) return null;

  try {
    return await withMongoTransaction(async (session) => {
      const winner = await squadWarSeasons().findOne({ seasonId: window.seasonId }, { session });
      if (winner) return winner;

      const allSquads = await squads().find({}, { session }).sort({ squadWarLevel: 1, squadPoints: -1, name: 1 }).toArray();
      const rounds: SquadWarRoundDocument[] = [];
      for (let level = SQUAD_WAR_MIN_LEVEL; level <= SQUAD_WAR_MAX_LEVEL; level += 1) {
        const atLevel = allSquads.filter((squad) => boundedLevel(squad.squadWarLevel) === level);
        for (let offset = 0; offset < atLevel.length; offset += SQUAD_WAR_MAX_DIVISION_SIZE) {
          const division = Math.floor(offset / SQUAD_WAR_MAX_DIVISION_SIZE);
          const members = atLevel.slice(offset, offset + SQUAD_WAR_MAX_DIVISION_SIZE);
          const roundId = squadWarRoundId(level, window, division);
          rounds.push({
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
          });
          for (const squad of members) {
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
                  updatedAt: now,
                },
              },
              { session },
            );
          }
        }
      }
      if (rounds.length > 0) await squadWarRounds().insertMany(rounds, { session });
      const season: SquadWarSeasonDocument = {
        seasonId: window.seasonId,
        startsAt: window.startsAt,
        endsAt: window.endsAt,
        status: "active",
        createdAt: now,
      };
      await squadWarSeasons().insertOne(season, { session });
      return season;
    });
  } catch (error) {
    if (!duplicateKey(error)) throw error;
    const committed = await squadWarSeasons().findOne({ seasonId: window.seasonId });
    if (!committed) throw error;
    return committed;
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
  const window = squadWarWindowAt(now, config.squadWarsSeasonDurationSeconds);
  // Re-read after preparation because another node may have completed allocation between the
  // first check and this classification. A settled row is an intentional no-event window;
  // absence means expired rounds are still being finalized and must be retried.
  const current = await squadWarSeasons().findOne({ seasonId: window.seasonId });
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
    if (squad.squadWarRoundId) {
      const assigned = await squadWarRounds().findOne(
        { roundId: squad.squadWarRoundId, seasonId: season.seasonId, status: "active" },
        { session },
      );
      if (assigned) return assigned;
    }

    const current = await squadWarRounds().find(
      { seasonId: season.seasonId, level: SQUAD_WAR_MIN_LEVEL, status: "active" },
      { session },
    ).sort({ division: 1 }).toArray();
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
      round = updated;
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
      await squadWarRounds().insertOne(round, { session });
    }
    if (!round) throw new Error(`Squad Wars assignment did not create a round for ${squadId}.`);
    await squads().updateOne(
      { name: squadId },
      {
        $set: {
          squadWarLevel: SQUAD_WAR_MIN_LEVEL,
          squadWarRoundId: round.roundId,
          leagueId: round.roundId,
          leagueDivision: season.seasonId,
          updatedAt: now,
        },
      },
      { session },
    );
    return round;
  });
}

export interface SquadWarReadModel {
  season: SquadWarSeasonDocument;
  round: SquadWarRoundDocument;
  squads: SquadDocument[];
}

/** Resolve action 124 from authenticated membership, never from a client-selected score set. */
export async function getSquadWarDivision(player: PlayerDocument, requestedRoundId: string): Promise<SquadWarReadModel> {
  if (!player.player.squadName) throw new ApiError(ApiErrorCode.SquadNoLongerExists, "Player is not in a squad.");
  const round = await ensureSquadWarAssignment(player.player.squadName);
  if (!round) throw new ApiError(ApiErrorCode.UnknownAction, "Squad Wars is disabled.");
  // A stale cached RoundId is rejected instead of returning another division under the caller's
  // requested cache key. Refreshing GetSquadDetails supplies the current server-owned pointer.
  if (requestedRoundId !== round.roundId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "RoundId is not the player's active Squad Wars division.");
  }
  const season = await squadWarSeasons().findOne({ seasonId: round.seasonId });
  if (!season) throw new Error(`Squad Wars season ${round.seasonId} is missing.`);
  const docs = await squads().find({ name: { $in: round.entries.map((entry) => entry.squadId) } }).toArray();
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
): Promise<SquadWarProgressStatus> {
  if (!config.squadWarsEnabled) return "disabled";
  if (!squadId) return "no_squad";
  if (!won || !Number.isSafeInteger(confirmedPoints) || confirmedPoints <= 0) return "no_points";
  const squad = await squads().findOne({ name: squadId, "members.playerId": playerId }, { session });
  if (!squad) return "not_member";
  const roundId = squad.squadWarRoundId ?? "";
  if (!roundId) return "no_active_round";
  const round = await squadWarRounds().findOne({ roundId, status: "active" }, { session });
  if (!round) return "no_active_round";
  if (settledAt < round.startsAt || settledAt >= round.endsAt) return "outside_round";

  const entryIndex = round.entries.findIndex((entry) => entry.squadId === squadId);
  if (entryIndex < 0) return "no_active_round";
  const entry = round.entries[entryIndex]!;
  const rosterMember = squad.members.find((member) => member.playerId === playerId);
  if (!rosterMember) return "not_member";
  const memberIndex = entry.members.findIndex((member) => member.playerId === playerId);
  const members = entry.members.map((member) => ({ ...member }));
  if (memberIndex >= 0) members[memberIndex]!.score += confirmedPoints;
  else {
    // The recovered leave/join warning states that a player receives no first-week Squad War
    // reward in the new squad. Their confirmed win still helps the squad's shared placement, but
    // the durable false flag prevents settlement from sending a personal type-9 reward.
    members.push({ playerId, name: rosterMember.name, score: confirmedPoints, rewardEligible: false });
  }
  const entries = round.entries.map((candidate, index) => index === entryIndex
    ? {
      ...candidate,
      score: candidate.score + confirmedPoints,
      wins: candidate.wins + 1,
      members,
    }
    : candidate);
  const update = await squadWarRounds().updateOne(
    { roundId, status: "active", revision: round.revision },
    { $set: { entries, updatedAt: settledAt }, $inc: { revision: 1 } },
    { session },
  );
  if (update.modifiedCount !== 1) throw new Error(`Concurrent Squad Wars score rejected ${roundId}.`);
  return "recorded";
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
  wire.SquadPoints = { N: String(roundScore) };
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

  const rawRevision = player.progression?.revision;
  const progressionFilter = player.progression
    ? rawRevision === undefined
      ? { "progression.revision": { $exists: false } }
      : { "progression.revision": rawRevision }
    : { progression: { $exists: false } };
  const { dogTags: _legacyDogTags, ...canonicalState } = completed.state;
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
    if (!round || round.status === "settled") return { settled: false, messages: 0 };
    if (round.endsAt > now) return { settled: false, messages: 0 };

    const placements = rankSquadWarDivision(round.entries, round.level);
    let insertedMessages = 0;
    for (const placement of placements) {
      const entry = round.entries.find((candidate) => candidate.squadId === placement.squadId)!;
      const squad = await squads().findOne({ name: placement.squadId }, { session });
      if (!squad) continue;
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
          messageId: `SquadWarEnd-${round.roundId}-${member.id}`,
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
        const result = await messages().updateOne(
          { idempotencyKey: message.idempotencyKey },
          { $setOnInsert: message },
          { upsert: true, session },
        );
        insertedMessages += result.upsertedCount;
      }
      // Do not clear a pointer already advanced by an operator repair/newer season. This guard
      // makes a delayed old-round settlement unable to roll a squad backward.
      await squads().updateOne(
        { name: squad.name, squadWarRoundId: round.roundId },
        {
          $set: {
            squadWarLevel: placement.nextLevel,
            squadWarRoundId: "",
            leagueId: "",
            leagueDivision: "",
            updatedAt: now,
          },
          ...(placement.position === 1 ? { $inc: { squadWarWins: 1 } } : {}),
        },
        { session },
      );
    }
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
export async function maintainSquadWars(now = new Date()): Promise<{ rounds: number; messages: number }> {
  if (!config.squadWarsEnabled) return { rounds: 0, messages: 0 };
  const expired = await squadWarRounds().find({ status: "active", endsAt: { $lte: now } }).sort({ endsAt: 1 }).limit(100).toArray();
  let rounds = 0;
  let messageCount = 0;
  for (const round of expired) {
    const result = await settleSquadWarRound(round.roundId, now);
    if (result.settled) rounds += 1;
    messageCount += result.messages;
  }
  // Inspect ended season rows as well as seasons represented by the round batch. This closes an
  // empty season (created while there were no squads) and also completes a season whose last
  // active round was settled by another node between this sweep's initial query and this point.
  const endedSeasons = await squadWarSeasons().find(
    { status: "active", endsAt: { $lte: now } },
  ).sort({ endsAt: 1 }).limit(100).toArray();
  for (const seasonId of endedSeasons.map((season) => season.seasonId)) {
    const remaining = await squadWarRounds().countDocuments({ seasonId, status: "active" }, { limit: 1 });
    if (remaining === 0) {
      await squadWarSeasons().updateOne(
        { seasonId, status: "active" },
        { $set: { status: "settled", settledAt: now } },
      );
    }
  }
  await ensureActiveSquadWarSeason(now);
  return { rounds, messages: messageCount };
}
