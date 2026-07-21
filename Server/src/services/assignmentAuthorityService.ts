import { ApiError, ApiErrorCode } from "../apiErrors";
import type { AssignmentRecordState, AssignmentState } from "../db";

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const ASSIGNMENT_STATE_KEYS = new Set([
  "assignments", "tomorrow", "completed", "issued", "megaReward", "skipUsed", "dayKey",
]);
const ASSIGNMENT_RECORD_KEYS = new Set([
  "id", "done", "claimed", "completeFract", "lastCompletedFract", "target", "secondTarget", "tutorialId",
]);

export interface AssignmentTemplate {
  id: number;
  target: number;
  gold: number;
  megaPoints: number;
  progressPerPvpMatch: number;
  winsOnly: boolean;
}

/** Exact backend-verifiable TaskDefinitions subset, in the recovered client display order. */
export const ASSIGNMENT_TEMPLATES: readonly AssignmentTemplate[] = Object.freeze([
  Object.freeze({ id: 5, target: 2_000, gold: 2, megaPoints: 1, progressPerPvpMatch: 1_000, winsOnly: false }),
  Object.freeze({ id: 8, target: 6, gold: 4, megaPoints: 2, progressPerPvpMatch: 1, winsOnly: false }),
  Object.freeze({ id: 7, target: 3, gold: 8, megaPoints: 3, progressPerPvpMatch: 1, winsOnly: true }),
]);

function invalid(message: string): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function exactObject(value: unknown, keys: ReadonlySet<string>, label: string): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) invalid(`${label} is invalid.`);
  const record = value as Record<string, unknown>;
  const actual = Object.keys(record);
  if (actual.length !== keys.size || actual.some((key) => !keys.has(key))) invalid(`${label} is invalid.`);
  return record;
}

/** Validate a daily-assignment clock before it controls rollover or serialization. */
export function assignmentUnixSeconds(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_DATE_UNIX_SECONDS) invalid(`${label} is invalid.`);
  return value;
}

/** Validate a nonnegative durable assignment counter before comparison or increment. */
export function assignmentCounter(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value < 0) invalid(`${label} is invalid.`);
  return value;
}

function utcDayKey(now: number): string {
  return new Date(now * 1_000).toISOString().slice(0, 10);
}

function nextUtcMidnight(now: number): number {
  const date = new Date(now * 1_000);
  return Math.floor(Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate() + 1) / 1_000);
}

function validatedRecord(value: unknown, template: AssignmentTemplate, index: number): AssignmentRecordState {
  const record = exactObject(value, ASSIGNMENT_RECORD_KEYS, `Stored assignment ${index}`);
  if (record.id !== template.id || record.target !== template.target
    || record.secondTarget !== 0 || record.tutorialId !== 0) {
    invalid(`Stored assignment ${index} definition is invalid.`);
  }
  if (typeof record.done !== "boolean" || typeof record.claimed !== "boolean") {
    invalid(`Stored assignment ${index} flags are invalid.`);
  }
  const completeFract = record.completeFract;
  const lastCompletedFract = record.lastCompletedFract;
  if (typeof completeFract !== "number" || !Number.isFinite(completeFract)
    || completeFract < 0 || completeFract > 1
    || typeof lastCompletedFract !== "number" || !Number.isFinite(lastCompletedFract)
    || lastCompletedFract < 0 || lastCompletedFract > 1
    || completeFract + lastCompletedFract > 1) {
    invalid(`Stored assignment ${index} progress is invalid.`);
  }
  const complete = completeFract + lastCompletedFract >= 1;
  if (record.done !== complete || (record.claimed && !record.done)) {
    invalid(`Stored assignment ${index} completion authority is inconsistent.`);
  }
  return {
    id: template.id,
    done: record.done,
    claimed: record.claimed,
    completeFract,
    lastCompletedFract,
    target: template.target,
    secondTarget: 0,
    tutorialId: 0,
  };
}

/**
 * Validate the complete recovered AssignmentData snapshot plus its private UTC day key.
 *
 * The client displays fractions and flags but does not own them. Binding every record to the
 * three server-verifiable templates prevents a damaged or imported client-authored objective
 * from reaching claim pricing. The claimed-record count must equal `completed`, so neither field
 * can independently unlock achievements or hide an unclaimed reward.
 */
export function validatedAssignmentState(value: AssignmentState | undefined): AssignmentState | undefined {
  if (value === undefined) return undefined;
  const root = exactObject(value, ASSIGNMENT_STATE_KEYS, "Stored assignment cycle");
  const issued = assignmentUnixSeconds(root.issued as number, "Stored assignment issue time");
  const tomorrow = assignmentUnixSeconds(root.tomorrow as number, "Stored assignment reset time");
  if (root.dayKey !== utcDayKey(issued) || tomorrow !== nextUtcMidnight(issued)) {
    invalid("Stored assignment UTC cycle is inconsistent.");
  }
  // Preserve the older counter-first diagnostic contract when an imported row contains more
  // than one damaged field. Record/claim consistency is still checked below before use.
  const completed = assignmentCounter(root.completed as number, "Stored daily assignment completion count");
  const megaReward = assignmentCounter(root.megaReward as number, "Stored assignment mega reward");
  if (typeof root.skipUsed !== "boolean") invalid("Stored assignment skip flag is invalid.");
  const assignmentValues = root.assignments;
  if (!Array.isArray(assignmentValues) || assignmentValues.length !== ASSIGNMENT_TEMPLATES.length) {
    invalid("Stored assignment collection is invalid.");
  }
  const assignments = ASSIGNMENT_TEMPLATES.map((template, index) => (
    validatedRecord(assignmentValues[index], template, index)
  ));
  if (completed !== assignments.filter((assignment) => assignment.claimed).length) {
    invalid("Stored daily assignment completion count is inconsistent.");
  }
  return {
    assignments,
    tomorrow,
    completed,
    issued,
    megaReward,
    skipUsed: root.skipUsed,
    dayKey: root.dayKey as string,
  };
}
