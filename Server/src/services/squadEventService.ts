import { readFile } from "node:fs/promises";
import { resolve } from "node:path";
import { createHash } from "node:crypto";
import type { ClientSession } from "mongodb";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import {
  squadEventProgress,
  squads,
  messages,
  type PlayerDocument,
  type SquadEventProgressDocument,
} from "../db";
import { PLAYER_LEVELS, playerLevelDefinition } from "./levelProgressionService";
import type { MessageDoc } from "./socialService";
import { decimalNumberAttribute } from "./dynamoNumberAttributeService";
import { validatedInboxRewardMessage } from "./inboxRewardAuthorityService";
import { validatedSquadDocument } from "./squadAuthorityService";
import type { InboxFanoutReference } from "./inboxFanoutService";

const MAX_UNIX_SECONDS = 2_147_483_647;
const MAX_SEASONS = 128;
const MAX_TIERS = 32;
const MAX_ASSIGNMENTS = 32;
const PROGRESS_KEYS = new Set([
  "_id", "squadId", "eventId", "configHash", "activeTier", "tiers", "revision", "joinedAt", "updatedAt",
]);
const PROGRESS_TIER_KEYS = new Set(["reward", "assignments"]);
const PROGRESS_ASSIGNMENT_KEYS = new Set(["id", "value", "target", "param"]);

/**
 * Assignment.BFLFNAENJMJ IDs whose facts the current backend proves at PvP settlement.
 * Combat-stat IDs remain closed until the Photon/replacement relay validates those events.
 */
export const SUPPORTED_SQUAD_EVENT_ASSIGNMENT_IDS = new Set([7, 8]);

export interface SquadEventAssignmentConfig {
  id: number;
  target: number;
  param?: string;
}

export interface SquadEventTierConfig {
  reward: number;
  assignments: SquadEventAssignmentConfig[];
}

export interface SquadEventSeasonConfig {
  id: string;
  startTime: number;
  endTime: number;
  tiers: SquadEventTierConfig[];
}

export interface SquadEventConfig {
  seasons: SquadEventSeasonConfig[];
}

function object(value: unknown, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new Error(`${label} must be an object.`);
  }
  return value as Record<string, unknown>;
}

function exactKeys(value: Record<string, unknown>, allowed: readonly string[], label: string): void {
  const unexpected = Object.keys(value).filter((key) => !allowed.includes(key));
  if (unexpected.length > 0) throw new Error(`${label} contains unknown field ${unexpected[0]}.`);
}

function integer(value: unknown, label: string, minimum: number, maximum = Number.MAX_SAFE_INTEGER): number {
  if (!Number.isSafeInteger(value) || (value as number) < minimum || (value as number) > maximum) {
    throw new Error(`${label} must be an integer between ${minimum} and ${maximum}.`);
  }
  return value as number;
}

function identifier(value: unknown, label: string): string {
  if (typeof value !== "string" || !/^[A-Za-z0-9_.:-]{1,128}$/.test(value)) {
    throw new Error(`${label} must contain 1-128 safe identifier characters.`);
  }
  return value;
}

function numericParam(value: unknown, label: string): string | undefined {
  if (value === undefined) return undefined;
  const normalized = typeof value === "number" ? String(value) : value;
  if (typeof normalized !== "string" || normalized.length > 64
    || !/^-?(?:\d+\.?\d*|\.\d+)$/.test(normalized)
    || !Number.isFinite(Number(normalized))) {
    throw new Error(`${label} must be a finite numeric value.`);
  }
  return normalized;
}

/**
 * Validate operator-authored seasons before any value becomes client-visible or persistent.
 *
 * The stock EventDefinition wire has one global assignmentCount, so every tier must contain
 * the same number of assignments. Overlap is rejected because selecting one of two active
 * seasons by file order would make action 113 nondeterministic across configuration edits.
 */
export function parseSquadEventConfig(input: unknown): SquadEventConfig {
  const root = object(input, "Squad Event configuration");
  exactKeys(root, ["seasons"], "Squad Event configuration");
  if (!Array.isArray(root.seasons) || root.seasons.length > MAX_SEASONS) {
    throw new Error(`seasons must be an array containing at most ${MAX_SEASONS} entries.`);
  }

  const ids = new Set<string>();
  const seasons = root.seasons.map((rawSeason, seasonIndex): SquadEventSeasonConfig => {
    const season = object(rawSeason, `seasons[${seasonIndex}]`);
    exactKeys(season, ["id", "startTime", "endTime", "tiers"], `seasons[${seasonIndex}]`);
    const id = identifier(season.id, `seasons[${seasonIndex}].id`);
    if (ids.has(id)) throw new Error(`Duplicate Squad Event id ${id}.`);
    ids.add(id);
    const startTime = integer(season.startTime, `${id}.startTime`, 0, MAX_UNIX_SECONDS);
    const endTime = integer(season.endTime, `${id}.endTime`, 0, MAX_UNIX_SECONDS);
    if (endTime <= startTime) throw new Error(`${id}.endTime must be later than startTime.`);
    if (!Array.isArray(season.tiers) || season.tiers.length < 1 || season.tiers.length > MAX_TIERS) {
      throw new Error(`${id}.tiers must contain 1-${MAX_TIERS} entries.`);
    }

    let assignmentCount: number | undefined;
    const tiers = season.tiers.map((rawTier, tierIndex): SquadEventTierConfig => {
      const tier = object(rawTier, `${id}.tiers[${tierIndex}]`);
      exactKeys(tier, ["reward", "assignments"], `${id}.tiers[${tierIndex}]`);
      const reward = integer(tier.reward, `${id}.tiers[${tierIndex}].reward`, 0);
      if (!Array.isArray(tier.assignments) || tier.assignments.length < 1
        || tier.assignments.length > MAX_ASSIGNMENTS) {
        throw new Error(`${id}.tiers[${tierIndex}].assignments must contain 1-${MAX_ASSIGNMENTS} entries.`);
      }
      if (assignmentCount === undefined) assignmentCount = tier.assignments.length;
      if (tier.assignments.length !== assignmentCount) {
        throw new Error(`${id} tiers must use the same assignment count required by the client wire format.`);
      }
      const assignmentIds = new Set<number>();
      const assignments = tier.assignments.map((rawAssignment, assignmentIndex): SquadEventAssignmentConfig => {
        const assignment = object(rawAssignment, `${id}.tiers[${tierIndex}].assignments[${assignmentIndex}]`);
        exactKeys(assignment, ["id", "target", "param"], `${id}.tiers[${tierIndex}].assignments[${assignmentIndex}]`);
        const assignmentId = integer(assignment.id, `${id}.assignment.id`, 0);
        if (!SUPPORTED_SQUAD_EVENT_ASSIGNMENT_IDS.has(assignmentId)) {
          throw new Error(
            `${id}.assignment.id ${assignmentId} is not backed by a server-confirmed gameplay fact.`,
          );
        }
        if (assignmentIds.has(assignmentId)) throw new Error(`${id} tier ${tierIndex} repeats assignment ${assignmentId}.`);
        assignmentIds.add(assignmentId);
        return {
          id: assignmentId,
          target: integer(assignment.target, `${id}.assignment.target`, 1),
          ...(assignment.param === undefined ? {} : { param: numericParam(assignment.param, `${id}.assignment.param`) }),
        };
      });
      return { reward, assignments };
    });
    return { id, startTime, endTime, tiers };
  });

  const chronological = [...seasons].sort((left, right) => left.startTime - right.startTime);
  for (let index = 1; index < chronological.length; index += 1) {
    if (chronological[index].startTime < chronological[index - 1].endTime) {
      throw new Error(`Squad Events ${chronological[index - 1].id} and ${chronological[index].id} overlap.`);
    }
  }
  return { seasons };
}

let loadedConfig: Promise<SquadEventConfig> | null = null;

async function configuredSeasons(): Promise<SquadEventConfig> {
  if (!config.squadEventConfigPath) return { seasons: [] };
  loadedConfig ??= readFile(resolve(config.squadEventConfigPath), "utf8")
    .then((raw) => parseSquadEventConfig(JSON.parse(raw)))
    .catch((error: unknown) => {
      loadedConfig = null;
      throw new Error(`Unable to load SQUAD_EVENT_CONFIG_PATH: ${(error as Error).message}`);
    });
  return loadedConfig;
}

export function selectActiveSquadEvent(source: SquadEventConfig, nowSeconds: number): SquadEventSeasonConfig | null {
  integer(nowSeconds, "Squad Event selection time", 0, MAX_UNIX_SECONDS);
  return source.seasons.find((season) => season.startTime <= nowSeconds && nowSeconds < season.endTime) ?? null;
}

/** Stable digest prevents an operator from silently changing a live season under persisted progress. */
export function squadEventConfigHash(season: SquadEventSeasonConfig): string {
  return createHash("sha256").update(JSON.stringify(season)).digest("hex");
}

export async function getActiveConfiguredSquadEvent(now = new Date()): Promise<SquadEventSeasonConfig | null> {
  return selectActiveSquadEvent(await configuredSeasons(), Math.floor(now.getTime() / 1000));
}

/** Reproduce LevelManager.GetPlayerLevelProgress with the client's binary32 result. */
export function squadEventPlayerLevelProgress(levelIndex: number): number {
  playerLevelDefinition(levelIndex);
  return Math.fround((levelIndex + 1) / PLAYER_LEVELS.length);
}

/** Exact plain-JSON contract consumed by PFPAMNODNPF.MAINIENLLIL. */
export function buildSquadEventDefinition(season: SquadEventSeasonConfig): Record<string, unknown> {
  const result: Record<string, unknown> = {
    eventStart: season.startTime,
    eventEnd: season.endTime,
    tierCount: season.tiers.length,
    assignmentCount: season.tiers[0].assignments.length,
  };
  season.tiers.forEach((tier, tierIndex) => {
    result[`T${tierIndex}Reward`] = tier.reward;
    tier.assignments.forEach((assignment, assignmentIndex) => {
      result[`T${tierIndex}A${assignmentIndex}Id`] = assignment.id;
    });
  });
  return result;
}

/** Exact DynamoDB-attribute contract consumed by JMHLHIIMNIG.MAINIENLLIL. */
export function buildSquadEventProgress(
  progress: SquadEventProgressDocument,
  playerLevelProgress: number,
  season?: SquadEventSeasonConfig,
  now?: Date,
): Record<string, unknown> {
  // JoinSquadEvent validates its newly read row immediately before this serializer. Other read
  // paths pass the live season explicitly so a standalone database projection cannot bypass the
  // immutable-config proof merely because it is being converted to the recovered wire shape.
  if (season) validatedSquadEventProgress(progress, season, now);
  const result: Record<string, unknown> = {
    SquadId: { S: progress.squadId },
    EventId: { S: progress.eventId },
    ActiveTier: decimalNumberAttribute(progress.activeTier),
    // This is viewer-specific reward scaling, not shared Squad Event completion. Persisting the
    // first member's value would make every other member see rewards calculated for that level.
    LevelProgress: decimalNumberAttribute(playerLevelProgress),
  };
  progress.tiers.forEach((tier, tierIndex) => {
    result[`T${tierIndex}Reward`] = decimalNumberAttribute(tier.reward);
    tier.assignments.forEach((assignment, assignmentIndex) => {
      result[`T${tierIndex}A${assignmentIndex}`] = decimalNumberAttribute(assignment.value);
      result[`T${tierIndex}A${assignmentIndex}Target`] = decimalNumberAttribute(assignment.target);
      if (assignment.param !== undefined) {
        // The recovered parser unusually reads Param from a DynamoDB N wrapper as a string.
        result[`T${tierIndex}A${assignmentIndex}Param`] = { N: assignment.param };
      }
    });
  });
  return result;
}

function initialProgress(squadId: string, season: SquadEventSeasonConfig, now: Date): SquadEventProgressDocument {
  return validatedSquadEventProgress({
    squadId,
    eventId: season.id,
    configHash: squadEventConfigHash(season),
    activeTier: 0,
    tiers: season.tiers.map((tier) => ({
      reward: tier.reward,
      assignments: tier.assignments.map((assignment) => ({ ...assignment, value: 0 })),
    })),
    revision: 0,
    joinedAt: now,
    updatedAt: now,
  }, season, now);
}

function safeDate(value: unknown): value is Date {
  return value instanceof Date && Number.isSafeInteger(value.getTime()) && value.getTime() >= 0;
}

function hasOnlyKeys(value: Record<string, unknown>, keys: ReadonlySet<string>): boolean {
  return Object.keys(value).every((key) => keys.has(key));
}

function canonicalProgressFraction(value: unknown): value is number {
  return typeof value === "number"
    && Number.isFinite(value)
    && value >= 0
    && value <= 1
    && !Object.is(value, -0)
    // Progress is produced with Math.fround after every confirmed battle. Keeping that binary32
    // shape rejects arbitrary database decimals that could otherwise jump a reward gate.
    && (value === 1 || Object.is(value, Math.fround(value)));
}

/**
 * Validate one complete durable Squad Event projection against its immutable live definition.
 *
 * `activeTier` is a cursor, not a client-authored summary: every earlier tier must be complete,
 * the active tier must remain incomplete, and every later tier must still be untouched. This
 * prevents a damaged row from skipping reward messages or making a later match legitimize forged
 * progress. Dates are also bound to the configured half-open event window; validating application
 * time separately ensures a future row cannot become authoritative through server clock handling.
 */
export function validatedSquadEventProgress(
  progress: SquadEventProgressDocument,
  season: SquadEventSeasonConfig,
  now?: Date,
): SquadEventProgressDocument {
  const raw = progress as unknown as Record<string, unknown>;
  if (!progress || typeof progress !== "object" || Array.isArray(progress)
    || !hasOnlyKeys(raw, PROGRESS_KEYS)
    || typeof progress.squadId !== "string"
    || progress.squadId.length < 3
    || progress.squadId.length > 24
    || progress.squadId.trim() !== progress.squadId
    || /[\u0000-\u001f\u007f]/u.test(progress.squadId)
    || progress.eventId !== season.id) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      "Stored Squad Event progress identity is invalid.",
    );
  }
  if (progress.configHash !== squadEventConfigHash(season)) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      "The active Squad Event definition changed after progress was created.",
    );
  }
  const startMs = season.startTime * 1_000;
  const endMs = season.endTime * 1_000;
  const validDates = safeDate(progress.joinedAt)
    && safeDate(progress.updatedAt)
    && progress.joinedAt.getTime() >= startMs
    && progress.joinedAt.getTime() < endMs
    && progress.updatedAt.getTime() >= progress.joinedAt.getTime()
    && progress.updatedAt.getTime() < endMs
    && (now === undefined || (safeDate(now) && progress.updatedAt.getTime() <= now.getTime()));
  const validShape = validDates
    && Number.isSafeInteger(progress.activeTier)
    && progress.activeTier >= 0
    // The recovered client explicitly treats ActiveTier == tier count as the completed terminal
    // state: it shows all tier rows complete and stops producing SquadEventUpdate values.
    && progress.activeTier <= season.tiers.length
    && Number.isSafeInteger(progress.revision)
    && progress.revision >= 0
    && progress.revision < Number.MAX_SAFE_INTEGER
    && progress.revision >= progress.activeTier
    && Array.isArray(progress.tiers)
    && progress.tiers.length === season.tiers.length
    && progress.tiers.every((tier, tierIndex) => {
      const configuredTier = season.tiers[tierIndex];
      const tierRaw = tier as unknown as Record<string, unknown>;
      return !!tier
        && typeof tier === "object"
        && !Array.isArray(tier)
        && hasOnlyKeys(tierRaw, PROGRESS_TIER_KEYS)
        && tier.reward === configuredTier.reward
        && Array.isArray(tier.assignments)
        && tier.assignments.length === configuredTier.assignments.length
        && tier.assignments.every((assignment, assignmentIndex) => {
          const configured = configuredTier.assignments[assignmentIndex];
          const assignmentRaw = assignment as unknown as Record<string, unknown>;
          return !!assignment
            && typeof assignment === "object"
            && !Array.isArray(assignment)
            && hasOnlyKeys(assignmentRaw, PROGRESS_ASSIGNMENT_KEYS)
            && assignment.id === configured.id
            && assignment.target === configured.target
            && assignment.param === configured.param
            && canonicalProgressFraction(assignment.value);
        });
    })
    && progress.tiers.every((tier, tierIndex) => {
      const complete = tier.assignments.every((assignment) => assignment.value === 1);
      const untouched = tier.assignments.every((assignment) => assignment.value === 0);
      return tierIndex < progress.activeTier
        ? complete
        : tierIndex === progress.activeTier
          ? !complete
          : untouched;
    });
  if (!validShape) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      "Stored Squad Event progress does not match its immutable season definition.",
    );
  }
  return progress;
}

/**
 * Join the authenticated player's real squad to the active event exactly once.
 *
 * No request field chooses the squad or season: both are server-owned. The roster check is
 * intentionally stronger than trusting the denormalized player.squadName mirror. The client
 * sends contribution floats after a match, but this foundation never accepts those values as
 * reward authority; future progress must be derived from server-confirmed match facts.
 */
export async function joinSquadEventForSeason(
  player: PlayerDocument,
  season: SquadEventSeasonConfig,
  now = new Date(),
): Promise<SquadEventProgressDocument> {
  const squadId = player.player.squadName;
  const squad = squadId ? await squads().findOne({ name: squadId }) : null;
  if (squad) validatedSquadDocument(squad, now);
  if (!squad || !squad.members.some((member) => member.playerId === player.id)) {
    throw new ApiError(ApiErrorCode.NotSquadMember, "Player is not a member of a squad.");
  }
  const seed = initialProgress(squad.name, season, now);
  const progress = await squadEventProgress().findOneAndUpdate(
    { squadId: squad.name, eventId: season.id },
    { $setOnInsert: seed },
    { upsert: true, returnDocument: "after" },
  );
  if (!progress) throw new ApiError(ApiErrorCode.InternalServerError, "Squad Event progress was not persisted.");
  return validatedSquadEventProgress(progress, season, now);
}

export async function joinSquadEvent(player: PlayerDocument, now = new Date()): Promise<SquadEventProgressDocument> {
  const season = await getActiveConfiguredSquadEvent(now);
  if (!season) throw new ApiError(ApiErrorCode.NoActiveEvent, "No Squad Event is active.");
  return joinSquadEventForSeason(player, season, now);
}

export interface SquadEventPvpProgressResult {
  progress: SquadEventProgressDocument;
  changed: boolean;
  completedTier?: { tierIndex: number; reward: number };
}

/**
 * Apply only facts proven by the two-party PvP settlement.
 *
 * The recovered assignment classes return a fraction for one battle, not a raw count:
 * WinMultiplayerMatches (7) contributes `1 / target` only to the winner and
 * PlayMultiplayerMatches (8) contributes `1 / target` to either participant. Math.fround
 * reproduces the binary32 values that the original Unity client serialized in
 * `SquadEventUpdate`. When every assignment reaches one, the recovered ActiveTier contract and
 * type-11 inbox message prove that the backend advances exactly one tier and offers its configured
 * Gold reward to each current member through action 91.
 */
export function applyConfirmedPvpSquadEventProgress(
  current: SquadEventProgressDocument,
  season: SquadEventSeasonConfig,
  won: boolean,
  now = new Date(),
): SquadEventPvpProgressResult {
  validatedSquadEventProgress(current, season, now);
  const tier = current.tiers[current.activeTier];
  if (!tier) return { progress: current, changed: false };
  let changed = false;
  const assignments = tier.assignments.map((assignment) => {
    const eligible = assignment.id === 8 || (assignment.id === 7 && won);
    if (!eligible || assignment.value >= 1) return assignment;
    const value = Math.min(1, Math.fround(assignment.value + Math.fround(1 / assignment.target)));
    if (value === assignment.value) return assignment;
    changed = true;
    return { ...assignment, value };
  });
  if (!changed) return { progress: current, changed: false };
  const completed = assignments.every((assignment) => assignment.value >= 1);
  const progress = validatedSquadEventProgress({
    ...current,
    activeTier: completed ? current.activeTier + 1 : current.activeTier,
    tiers: current.tiers.map((entry, index) => (index === current.activeTier
      ? { ...entry, assignments }
      : entry)),
    revision: current.revision + 1,
    updatedAt: now,
  }, season, now);
  return {
    changed: true,
    progress,
    ...(completed ? {
      completedTier: { tierIndex: current.activeTier, reward: tier.reward },
    } : {}),
  };
}

/** Build the exact type-11 reward document parsed by OKLNJJBHAIH. */
export function buildSquadEventTierRewardMessage(
  memberId: string,
  squadId: string,
  eventId: string,
  tierIndex: number,
  reward: number,
  createdAt: Date,
): MessageDoc {
  const idempotencyKey = `squad-event-tier:${eventId}:${squadId}:${tierIndex}:${memberId}`;
  return {
    messageId: `${idempotencyKey}-${Math.floor(createdAt.getTime() / 1_000)}`,
    idempotencyKey,
    toPlayerId: memberId,
    fromPlayerId: "system",
    fromName: "Squad Event",
    body: "",
    messageType: 11,
    payload: { Tier: tierIndex, SquadId: squadId, Reward: reward },
    otherPlayerJson: "",
    read: false,
    ignored: false,
    accepted: false,
    createdAt,
  };
}

export type SquadEventProjectionStatus =
  | "not_joined"
  | "not_member"
  | "unchanged"
  | "updated"
  // These two values remain in the persisted receipt type because older Server builds could
  // commit them. New settlements never return them: definition drift or damaged progress now
  // aborts the enclosing match transaction so the event contribution remains retryable.
  | "config_mismatch"
  | "invalid_progress";

type CurrentSquadEventProjectionStatus = Exclude<
  SquadEventProjectionStatus,
  "config_mismatch" | "invalid_progress"
>;

export interface SquadEventProjectionResult {
  status: CurrentSquadEventProjectionStatus;
  fanouts: InboxFanoutReference[];
}

/**
 * Project one confirmed participant result inside the match settlement transaction.
 *
 * The match's `active -> finished` compare-and-set is the idempotency key: this function is
 * reached only by the transaction that wins that transition. Roster membership is rechecked
 * in the same snapshot, so a stale player mirror cannot contribute to a squad the player left.
 */
export async function recordConfirmedPvpSquadEventProgressWithFanouts(
  session: ClientSession,
  season: SquadEventSeasonConfig,
  playerId: string,
  squadId: string,
  won: boolean,
  now = new Date(),
): Promise<SquadEventProjectionResult> {
  const squad = squadId
    ? await squads().findOne({ name: squadId, "members.playerId": playerId }, { session })
    : null;
  if (!squad) {
    return { status: "not_member", fanouts: [] };
  }
  validatedSquadDocument(squad, now);
  const current = await squadEventProgress().findOne({ squadId, eventId: season.id }, { session });
  if (!current) return { status: "not_joined", fanouts: [] };
  // `applyConfirmedPvpSquadEventProgress` verifies both the immutable configuration hash and the
  // complete stored progress shape. Do not translate either invariant failure into a successful
  // terminal receipt: once the match is finished, its confirmed win/play contribution cannot be
  // applied again. Let the error abort core rewards as well, then retry after the operator restores
  // the live definition or repairs the damaged projection.
  const next = applyConfirmedPvpSquadEventProgress(current, season, won, now);
  if (!next.changed) return { status: "unchanged", fanouts: [] };
  const update = await squadEventProgress().updateOne(
    { _id: current._id, revision: current.revision, configHash: current.configHash },
    {
      $set: {
        activeTier: next.progress.activeTier,
        tiers: next.progress.tiers,
        updatedAt: now,
      },
      $inc: { revision: 1 },
    },
    { session },
  );
  if (update.modifiedCount !== 1) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Concurrent Squad Event progress update was rejected.");
  }
  if (next.completedTier && next.completedTier.reward > 0) {
    // Tier progress is shared, but the reward is one claimable inbox row per current member.
    // Insert every row in the same match transaction as ActiveTier, so a crash cannot advance
    // the squad without its rewards or enqueue rewards for a tier that did not commit.
    const fanouts: InboxFanoutReference[] = [];
    for (const member of squad.members) {
      const message = buildSquadEventTierRewardMessage(
        member.playerId,
        squad.name,
        season.id,
        next.completedTier.tierIndex,
        next.completedTier.reward,
        now,
      );
      validatedInboxRewardMessage(message);
      const insert = await messages().updateOne(
        { idempotencyKey: message.idempotencyKey },
        { $setOnInsert: message },
        { upsert: true, session },
      );
      if (insert.upsertedCount === 1) {
        fanouts.push({ recipientPlayerId: message.toPlayerId, messageId: message.messageId });
      }
    }
    return { status: "updated", fanouts };
  }
  return { status: "updated", fanouts: [] };
}

/**
 * Preserve the original projection API for callers that do not own the outer commit boundary.
 * Match settlement uses the fan-out-aware variant above because only it can publish after the
 * enclosing economy transaction commits; other callers still receive the established status.
 */
export async function recordConfirmedPvpSquadEventProgress(
  session: ClientSession,
  season: SquadEventSeasonConfig,
  playerId: string,
  squadId: string,
  won: boolean,
  now = new Date(),
): Promise<CurrentSquadEventProjectionStatus> {
  const result = await recordConfirmedPvpSquadEventProgressWithFanouts(
    session,
    season,
    playerId,
    squadId,
    won,
    now,
  );
  return result.status;
}

/** Optional event fields appended to squad-detail responses for the currently active season. */
export async function getSquadEventWireFields(
  squadId: string,
  playerLevel: number,
  now = new Date(),
): Promise<Record<string, unknown>> {
  const season = await getActiveConfiguredSquadEvent(now);
  if (!season) return {};
  const progress = await squadEventProgress().findOne({ squadId, eventId: season.id });
  return {
    EventDefinition: buildSquadEventDefinition(season),
    ...(progress ? {
      SquadEventProgress: buildSquadEventProgress(
        progress,
        squadEventPlayerLevelProgress(playerLevel),
        season,
        now,
      ),
    } : {}),
  };
}
