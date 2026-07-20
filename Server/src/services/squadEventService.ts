import { readFile } from "node:fs/promises";
import { resolve } from "node:path";
import { createHash } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import {
  squadEventProgress,
  squads,
  type PlayerDocument,
  type SquadEventProgressDocument,
} from "../db";
import { PLAYER_LEVELS, playerLevelDefinition } from "./levelProgressionService";

const MAX_UNIX_SECONDS = 2_147_483_647;
const MAX_SEASONS = 128;
const MAX_TIERS = 32;
const MAX_ASSIGNMENTS = 32;

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
  return source.seasons.find((season) => season.startTime <= nowSeconds && nowSeconds < season.endTime) ?? null;
}

/** Stable digest prevents an operator from silently changing a live season under persisted progress. */
export function squadEventConfigHash(season: SquadEventSeasonConfig): string {
  return createHash("sha256").update(JSON.stringify(season)).digest("hex");
}

async function activeSquadEvent(now: Date): Promise<SquadEventSeasonConfig | null> {
  return selectActiveSquadEvent(await configuredSeasons(), Math.floor(now.getTime() / 1000));
}

function numberAttribute(value: number): { N: string } {
  return { N: String(value) };
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
): Record<string, unknown> {
  const result: Record<string, unknown> = {
    SquadId: { S: progress.squadId },
    EventId: { S: progress.eventId },
    ActiveTier: numberAttribute(progress.activeTier),
    // This is viewer-specific reward scaling, not shared Squad Event completion. Persisting the
    // first member's value would make every other member see rewards calculated for that level.
    LevelProgress: numberAttribute(playerLevelProgress),
  };
  progress.tiers.forEach((tier, tierIndex) => {
    result[`T${tierIndex}Reward`] = numberAttribute(tier.reward);
    tier.assignments.forEach((assignment, assignmentIndex) => {
      result[`T${tierIndex}A${assignmentIndex}`] = numberAttribute(assignment.value);
      result[`T${tierIndex}A${assignmentIndex}Target`] = numberAttribute(assignment.target);
      if (assignment.param !== undefined) {
        // The recovered parser unusually reads Param from a DynamoDB N wrapper as a string.
        result[`T${tierIndex}A${assignmentIndex}Param`] = { N: assignment.param };
      }
    });
  });
  return result;
}

function initialProgress(squadId: string, season: SquadEventSeasonConfig, now: Date): SquadEventProgressDocument {
  return {
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
  };
}

function assertProgressMatchesSeason(
  progress: SquadEventProgressDocument,
  season: SquadEventSeasonConfig,
): SquadEventProgressDocument {
  if (progress.configHash !== squadEventConfigHash(season)) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      "The active Squad Event definition changed after progress was created.",
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
  return assertProgressMatchesSeason(progress, season);
}

export async function joinSquadEvent(player: PlayerDocument, now = new Date()): Promise<SquadEventProgressDocument> {
  const season = await activeSquadEvent(now);
  if (!season) throw new ApiError(ApiErrorCode.NoActiveEvent, "No Squad Event is active.");
  return joinSquadEventForSeason(player, season, now);
}

/** Optional event fields appended to squad-detail responses for the currently active season. */
export async function getSquadEventWireFields(
  squadId: string,
  playerLevel: number,
  now = new Date(),
): Promise<Record<string, unknown>> {
  const season = await activeSquadEvent(now);
  if (!season) return {};
  const progress = await squadEventProgress().findOne({ squadId, eventId: season.id });
  return {
    EventDefinition: buildSquadEventDefinition(season),
    ...(progress ? {
      SquadEventProgress: buildSquadEventProgress(
        assertProgressMatchesSeason(progress, season),
        squadEventPlayerLevelProgress(playerLevel),
      ),
    } : {}),
  };
}
