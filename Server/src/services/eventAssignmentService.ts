import { createHash } from "node:crypto";
import { readFile } from "node:fs/promises";
import { resolve } from "node:path";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import type { EventAssignmentState, PlayerProgressionState } from "../db";
import { mutateProgression } from "./progressionMutationService";
import { grantMissionElitePartsState, isPlayerUnitName } from "./unitInventoryService";
import { grantEventAssignmentVisualState, VISUAL_CATALOG } from "./visualInventoryService";
import { validatedEventAssignmentState } from "./eventAssignmentAuthorityService";
import { validatedApplicationUnixSeconds } from "./applicationTimeAuthorityService";

const DAY_SECONDS = 86_400;
const MAX_UNIX_SECONDS = 2_147_483_647;
const MAX_EVENTS = 128;
const MAX_EVENT_DAYS = 62;
const MAX_MILESTONES = 32;
const SUPPORTED_REWARD_TYPES = new Set([0, 1, 5, 8, 15, 17]);

export interface EventAssignmentRewardConfig {
  /** GameRewardType: 0 WarBucks, 1 Gold, 5 Scraps, 8 Visual, 15 Tickets, 17 Elite Parts. */
  type: number;
  amount: number;
  /** PlayerVisuals ID for type 8 or LevelManager unit name for type 17. */
  param?: string;
}

export interface EventAssignmentDayConfig {
  /** The recovered client registers only EventAssignmentWinterBox under this name. */
  type: "xmas";
  target: number;
  /** Event points added only after this day's reward is claimed. */
  progress: number;
  reward: EventAssignmentRewardConfig;
}

export interface EventAssignmentMilestoneConfig {
  target: number;
  /** EventRewardRecord casts every milestone reward to GameRewardPlayerVisual. */
  reward: EventAssignmentRewardConfig & { type: 8; param: string };
}

export interface EventAssignmentEventConfig {
  id: string;
  startTime: number;
  endTime: number;
  eventName: string;
  milestones: EventAssignmentMilestoneConfig[];
  assignments: EventAssignmentDayConfig[];
}

export interface EventAssignmentsConfig {
  events: EventAssignmentEventConfig[];
}

export interface EventAssignmentMutationResult {
  state: PlayerProgressionState;
  eventAssignment: EventAssignmentState;
  event: EventAssignmentEventConfig;
}

export interface EventAssignmentClaimEcho {
  rewardType: number;
  rewardValue: number;
}

export interface EventMilestoneClaimEcho {
  milestoneId: number;
  rewardValue: string;
}

function object(value: unknown, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) throw new Error(`${label} must be an object.`);
  return value as Record<string, unknown>;
}

function exactKeys(value: Record<string, unknown>, allowed: readonly string[], label: string): void {
  const unexpected = Object.keys(value).find((key) => !allowed.includes(key));
  if (unexpected) throw new Error(`${label} contains unknown field ${unexpected}.`);
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

function boundedText(value: unknown, label: string, maximum: number): string {
  if (typeof value !== "string" || value.trim().length < 1 || value.length > maximum) {
    throw new Error(`${label} must be a non-empty string no longer than ${maximum} characters.`);
  }
  return value;
}

function parseReward(value: unknown, label: string, milestone: boolean): EventAssignmentRewardConfig {
  const reward = object(value, label);
  exactKeys(reward, ["type", "amount", "param"], label);
  const type = integer(reward.type, `${label}.type`, 0, 17);
  if (!SUPPORTED_REWARD_TYPES.has(type)) throw new Error(`${label}.type ${type} is not supported.`);
  if (milestone && type !== 8) {
    throw new Error(`${label}.type must be 8 because the recovered milestone UI casts it to PlayerVisual.`);
  }
  const amount = integer(reward.amount, `${label}.amount`, 1);
  const param = reward.param === undefined ? undefined : boundedText(reward.param, `${label}.param`, 128);
  if (type === 8) {
    const visual = param ? VISUAL_CATALOG[param] : undefined;
    if (!visual || (visual.purchasable !== "event" && visual.purchasable !== "assignment")) {
      throw new Error(`${label}.param must name a source event/assignment visual.`);
    }
    if (amount !== 1) throw new Error(`${label}.amount must be 1 for a visual reward.`);
  } else if (type === 17) {
    if (!param || !isPlayerUnitName(param)) throw new Error(`${label}.param must name a source player unit.`);
  } else if (param !== undefined) {
    throw new Error(`${label}.param is valid only for visual or Elite-parts rewards.`);
  }
  return { type, amount, ...(param === undefined ? {} : { param }) };
}

/**
 * Validate the deployment-owned schedule before publishing any event or accepting any claim.
 *
 * UTC-midnight boundaries and one assignment per day are not convenience rules: Unity chooses
 * the assignment with `(Midnight - startTime) / 86400`. Enforcing that arithmetic here prevents
 * a timezone/rounding mismatch from displaying one reward while the server validates another.
 */
export function parseEventAssignmentsConfig(input: unknown): EventAssignmentsConfig {
  const root = object(input, "Event Assignment configuration");
  exactKeys(root, ["events"], "Event Assignment configuration");
  if (!Array.isArray(root.events) || root.events.length > MAX_EVENTS) {
    throw new Error(`events must be an array containing at most ${MAX_EVENTS} entries.`);
  }
  const ids = new Set<string>();
  const events = root.events.map((rawEvent, eventIndex): EventAssignmentEventConfig => {
    const event = object(rawEvent, `events[${eventIndex}]`);
    exactKeys(event, ["id", "startTime", "endTime", "eventName", "milestones", "assignments"], `events[${eventIndex}]`);
    const id = identifier(event.id, `events[${eventIndex}].id`);
    if (ids.has(id)) throw new Error(`Duplicate Event Assignment id ${id}.`);
    ids.add(id);
    const startTime = integer(event.startTime, `${id}.startTime`, 0, MAX_UNIX_SECONDS);
    const endTime = integer(event.endTime, `${id}.endTime`, 0, MAX_UNIX_SECONDS);
    if (startTime % DAY_SECONDS !== 0 || endTime % DAY_SECONDS !== 0 || endTime <= startTime) {
      throw new Error(`${id} startTime/endTime must be increasing UTC-midnight Unix seconds.`);
    }
    const dayCount = (endTime - startTime) / DAY_SECONDS;
    if (dayCount < 1 || dayCount > MAX_EVENT_DAYS) throw new Error(`${id} must span 1-${MAX_EVENT_DAYS} UTC days.`);
    if (!Array.isArray(event.assignments) || event.assignments.length !== dayCount) {
      throw new Error(`${id}.assignments must contain exactly one entry per event day (${dayCount}).`);
    }
    const assignments = event.assignments.map((rawDay, dayIndex): EventAssignmentDayConfig => {
      const day = object(rawDay, `${id}.assignments[${dayIndex}]`);
      exactKeys(day, ["type", "target", "progress", "reward"], `${id}.assignments[${dayIndex}]`);
      if (day.type !== "xmas") throw new Error(`${id}.assignments[${dayIndex}].type must be xmas.`);
      return {
        type: "xmas",
        target: integer(day.target, `${id}.assignments[${dayIndex}].target`, 1),
        progress: integer(day.progress, `${id}.assignments[${dayIndex}].progress`, 1),
        reward: parseReward(day.reward, `${id}.assignments[${dayIndex}].reward`, false),
      };
    });
    if (!Array.isArray(event.milestones) || event.milestones.length > MAX_MILESTONES) {
      throw new Error(`${id}.milestones must contain at most ${MAX_MILESTONES} entries.`);
    }
    let priorTarget = 0;
    const milestones = event.milestones.map((rawMilestone, milestoneIndex): EventAssignmentMilestoneConfig => {
      const milestone = object(rawMilestone, `${id}.milestones[${milestoneIndex}]`);
      exactKeys(milestone, ["target", "reward"], `${id}.milestones[${milestoneIndex}]`);
      const target = integer(milestone.target, `${id}.milestones[${milestoneIndex}].target`, 1);
      if (target <= priorTarget) throw new Error(`${id}.milestones targets must be strictly increasing.`);
      priorTarget = target;
      const reward = parseReward(milestone.reward, `${id}.milestones[${milestoneIndex}].reward`, true);
      return { target, reward: reward as EventAssignmentMilestoneConfig["reward"] };
    });
    return {
      id,
      startTime,
      endTime,
      eventName: boundedText(event.eventName, `${id}.eventName`, 128),
      milestones,
      assignments,
    };
  });
  const chronological = [...events].sort((left, right) => left.startTime - right.startTime);
  for (let index = 1; index < chronological.length; index += 1) {
    if (chronological[index].startTime < chronological[index - 1].endTime) {
      throw new Error(`Event Assignments ${chronological[index - 1].id} and ${chronological[index].id} overlap.`);
    }
  }
  return { events };
}

let loadedConfig: Promise<EventAssignmentsConfig> | null = null;

async function configuredEvents(): Promise<EventAssignmentsConfig> {
  if (!config.eventAssignmentConfigPath) return { events: [] };
  loadedConfig ??= readFile(resolve(config.eventAssignmentConfigPath), "utf8")
    .then((raw) => parseEventAssignmentsConfig(JSON.parse(raw)))
    .catch((error: unknown) => {
      loadedConfig = null;
      throw new Error(`Unable to load EVENT_ASSIGNMENT_CONFIG_PATH: ${(error as Error).message}`);
    });
  return loadedConfig;
}

export function selectActiveEventAssignment(
  source: EventAssignmentsConfig,
  now: number,
): EventAssignmentEventConfig | null {
  const currentTime = validatedApplicationUnixSeconds(now, "Event Assignment selection time");
  return source.events.find(
    (event) => event.startTime <= currentTime && currentTime < event.endTime,
  ) ?? null;
}

export async function getActiveConfiguredEventAssignment(now: number): Promise<EventAssignmentEventConfig | null> {
  return selectActiveEventAssignment(await configuredEvents(), now);
}

export function eventAssignmentConfigHash(event: EventAssignmentEventConfig): string {
  return createHash("sha256").update(JSON.stringify(event)).digest("hex");
}

export function utcMidnight(now: number): number {
  const currentTime = validatedApplicationUnixSeconds(now, "Event Assignment calendar time");
  const date = new Date(currentTime * 1_000);
  return validatedApplicationUnixSeconds(
    Math.floor(Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate()) / 1_000),
    "Event Assignment midnight",
  );
}

export function eventAssignmentDayIndex(event: EventAssignmentEventConfig, now: number): number {
  return Math.floor((utcMidnight(now) - event.startTime) / DAY_SECONDS);
}

function initialEventState(event: EventAssignmentEventConfig): EventAssignmentState {
  return { eventId: event.id, totalValue: 0, progress: {}, milestones: {}, configHash: eventAssignmentConfigHash(event) };
}

function stateForEvent(state: PlayerProgressionState, event: EventAssignmentEventConfig): EventAssignmentState {
  const current = validatedEventAssignmentState(state.eventAssignment);
  if (!current || current.eventId !== event.id) return initialEventState(event);
  if (current.configHash !== eventAssignmentConfigHash(event)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Active Event Assignment changed after player progress was created.");
  }
  let expectedTotalValue = 0;
  for (const [key, progress] of Object.entries(current.progress)) {
    const index = Number(key);
    const definition = event.assignments[index];
    if (!definition || progress.v > definition.target || (progress.c && progress.v !== definition.target)) {
      throw new ApiError(ApiErrorCode.InternalServerError, "Stored Event Assignment progress is invalid.");
    }
    if (progress.c) expectedTotalValue = addSafe(expectedTotalValue, definition.progress, "Event points");
  }
  if (current.totalValue !== expectedTotalValue) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored Event Assignment progress is invalid.");
  }
  const claimedMilestones = Object.keys(current.milestones).map(Number).sort((left, right) => left - right);
  if (claimedMilestones.some((index, position) => index !== position
    || !event.milestones[index] || current.totalValue < event.milestones[index].target)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored Event Assignment progress is invalid.");
  }
  return {
    ...current,
    progress: Object.fromEntries(Object.entries(current.progress).map(([key, value]) => [key, { ...value }])),
    milestones: { ...current.milestones },
  };
}

/** Exact JSON document parsed by EventAssignmentsConfig/EventAssignmentConfig in Unity. */
export function buildEventAssignmentClientConfig(event: EventAssignmentEventConfig): string {
  const reward = (value: EventAssignmentRewardConfig) => ({
    type: value.type,
    d: { amount: value.amount, ...(value.param === undefined ? {} : { param: value.param }) },
  });
  return JSON.stringify({
    startTime: event.startTime,
    endTime: event.endTime,
    eventName: event.eventName,
    milestones: event.milestones.map((item) => ({ target: item.target, reward: reward(item.reward) })),
    assignments: event.assignments.map((item) => ({
      type: item.type,
      target: item.target,
      progress: item.progress,
      reward: reward(item.reward),
    })),
  });
}

export function serializeEventAssignmentData(value: EventAssignmentState): Record<string, unknown> {
  const validated = validatedEventAssignmentState(value)!;
  return {
    eventId: validated.eventId,
    totalValue: validated.totalValue,
    progress: validated.progress,
    milestones: validated.milestones,
  };
}

/** Initialize/reset the active event without accepting any client progress. */
export function ensureEventAssignmentState(
  state: PlayerProgressionState,
  event: EventAssignmentEventConfig,
): EventAssignmentMutationResult {
  const eventAssignment = stateForEvent(state, event);
  if (state.eventAssignment?.eventId === event.id) return { state, eventAssignment, event };
  return { state: { ...state, revision: state.revision + 1, eventAssignment }, eventAssignment, event };
}

function addSafe(current: number, amount: number, label: string): number {
  if (!Number.isSafeInteger(current) || current < 0 || current > Number.MAX_SAFE_INTEGER - amount) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} reward overflowed.`);
  }
  return current + amount;
}

function grantReward(state: PlayerProgressionState, reward: EventAssignmentRewardConfig): PlayerProgressionState {
  if (reward.type === 0) return { ...state, warBucks: addSafe(state.warBucks, reward.amount, "WarBucks") };
  if (reward.type === 1) return { ...state, gold: addSafe(state.gold, reward.amount, "Gold") };
  if (reward.type === 5) return { ...state, scraps: addSafe(state.scraps, reward.amount, "Scraps") };
  if (reward.type === 15) return { ...state, tickets: addSafe(state.tickets, reward.amount, "Tickets") };
  if (reward.type === 8 && reward.param) return grantEventAssignmentVisualState(state, reward.param).state;
  if (reward.type === 17 && reward.param) return grantMissionElitePartsState(state, reward.param, reward.amount).state;
  throw new ApiError(ApiErrorCode.InternalServerError, "Configured Event Assignment reward is invalid.");
}

/**
 * Advance today's winter-box count only from a future trusted battle/relay fact.
 *
 * This helper is intentionally not connected to the client's `EventAssignmentUpdate` field:
 * that field is copied from the phone's destroyed-box counter and is therefore forgeable. The
 * pure transition exists now so a later authoritative combat relay can supply a verified delta
 * without changing claim semantics or persisted data.
 */
export function recordConfirmedEventAssignmentProgressState(
  state: PlayerProgressionState,
  event: EventAssignmentEventConfig,
  now: number,
  confirmedBoxes: number,
): EventAssignmentMutationResult {
  if (!Number.isSafeInteger(confirmedBoxes) || confirmedBoxes <= 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Confirmed Event Assignment progress must be positive.");
  }
  const day = eventAssignmentDayIndex(event, now);
  if (day < 0 || day >= event.assignments.length) throw new ApiError(ApiErrorCode.UnknownAction, "Event Assignment is not active.");
  const eventAssignment = stateForEvent(state, event);
  const current = eventAssignment.progress[String(day)] ?? { v: 0, c: false };
  if (current.c) return { state, eventAssignment, event };
  eventAssignment.progress[String(day)] = {
    v: Math.min(event.assignments[day].target, addSafe(current.v, confirmedBoxes, "Event progress")),
    c: false,
  };
  return {
    state: { ...state, revision: state.revision + 1, eventAssignment },
    eventAssignment,
    event,
  };
}

export function claimEventAssignmentState(
  state: PlayerProgressionState,
  event: EventAssignmentEventConfig,
  now: number,
  echo: EventAssignmentClaimEcho,
): EventAssignmentMutationResult {
  const day = eventAssignmentDayIndex(event, now);
  if (day < 0 || day >= event.assignments.length) throw new ApiError(ApiErrorCode.UnknownAction, "Event Assignment is not active.");
  const definition = event.assignments[day];
  const eventAssignment = stateForEvent(state, event);
  const progress = eventAssignment.progress[String(day)] ?? { v: 0, c: false };
  if (progress.c) throw new ApiError(ApiErrorCode.UnknownAction, "Today's Event Assignment reward was already claimed.");
  if (progress.v < definition.target) throw new ApiError(ApiErrorCode.UnknownAction, "Today's Event Assignment is incomplete.");
  if (echo.rewardType !== definition.reward.type || echo.rewardValue !== definition.reward.amount) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Event Assignment reward does not match server configuration.");
  }
  const totalValue = addSafe(eventAssignment.totalValue, definition.progress, "Event points");
  eventAssignment.progress[String(day)] = { ...progress, c: true };
  eventAssignment.totalValue = totalValue;
  const rewarded = grantReward(state, definition.reward);
  const next = { ...rewarded, revision: state.revision + 1, eventAssignment };
  return { state: next, eventAssignment, event };
}

export function claimEventMilestoneState(
  state: PlayerProgressionState,
  event: EventAssignmentEventConfig,
  now: number,
  echo: EventMilestoneClaimEcho,
): EventAssignmentMutationResult {
  const currentTime = validatedApplicationUnixSeconds(now, "Event Assignment milestone time");
  if (currentTime < event.startTime || currentTime >= event.endTime) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Event Assignment is not active.");
  }
  const eventAssignment = stateForEvent(state, event);
  const firstUnclaimed = event.milestones.findIndex((_, index) => eventAssignment.milestones[String(index)] !== true);
  if (firstUnclaimed < 0 || echo.milestoneId !== firstUnclaimed) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Event milestone is already claimed or out of order.");
  }
  const milestone = event.milestones[firstUnclaimed];
  if (eventAssignment.totalValue < milestone.target) throw new ApiError(ApiErrorCode.UnknownAction, "Event milestone is incomplete.");
  if (echo.rewardValue !== milestone.reward.param) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Event milestone reward does not match server configuration.");
  }
  eventAssignment.milestones[String(firstUnclaimed)] = true;
  const rewarded = grantReward(state, milestone.reward);
  return {
    state: { ...rewarded, revision: state.revision + 1, eventAssignment },
    eventAssignment,
    event,
  };
}

function activeOrThrow(event: EventAssignmentEventConfig | null): EventAssignmentEventConfig {
  if (!event) throw new ApiError(ApiErrorCode.UnknownAction, "No Event Assignment is active.");
  return event;
}

export async function ensureActiveEventAssignment(playerId: string): Promise<EventAssignmentMutationResult | null> {
  const now = Math.floor(Date.now() / 1_000);
  const event = await getActiveConfiguredEventAssignment(now);
  if (!event) return null;
  return mutateProgression(playerId, (state) => ensureEventAssignmentState(state, event));
}

export async function claimEventAssignment(
  playerId: string,
  echo: EventAssignmentClaimEcho,
): Promise<EventAssignmentMutationResult> {
  const event = activeOrThrow(await getActiveConfiguredEventAssignment(Math.floor(Date.now() / 1_000)));
  return mutateProgression(playerId, (state, now) => claimEventAssignmentState(state, event, now, echo));
}

export async function claimEventMilestone(
  playerId: string,
  echo: EventMilestoneClaimEcho,
): Promise<EventAssignmentMutationResult> {
  const event = activeOrThrow(await getActiveConfiguredEventAssignment(Math.floor(Date.now() / 1_000)));
  return mutateProgression(playerId, (state, now) => claimEventMilestoneState(state, event, now, echo));
}
