import { ApiError, ApiErrorCode } from "../apiErrors";
import type { EventAssignmentState } from "../db";

const MAX_CLIENT_INTEGER = 2_147_483_647;
const MAX_EVENT_DAYS = 62;
const MAX_MILESTONES = 32;
const ROOT_KEYS = new Set(["eventId", "totalValue", "progress", "milestones", "configHash"]);
const PROGRESS_KEYS = new Set(["v", "c"]);

function invalid(message = "Stored Event Assignment progress is invalid."): never {
  throw new ApiError(ApiErrorCode.InternalServerError, message);
}

function dictionary(value: unknown): Record<string, unknown> {
  if (!value || typeof value !== "object" || Array.isArray(value)) invalid();
  return value as Record<string, unknown>;
}

function canonicalIndex(key: string, maximumExclusive: number): number {
  if (!/^(0|[1-9]\d*)$/.test(key)) invalid();
  const index = Number(key);
  if (!Number.isSafeInteger(index) || index < 0 || index >= maximumExclusive) invalid();
  return index;
}

/** Validate the config-independent durable EventAssignmentState shape. */
export function validatedEventAssignmentState(value: EventAssignmentState | undefined): EventAssignmentState | undefined {
  if (value === undefined) return undefined;
  const root = dictionary(value);
  const actualKeys = Object.keys(root);
  if (actualKeys.length !== ROOT_KEYS.size || actualKeys.some((key) => !ROOT_KEYS.has(key))) invalid();
  if (typeof root.eventId !== "string" || !/^[A-Za-z0-9_.:-]{1,128}$/.test(root.eventId)
    || typeof root.configHash !== "string" || !/^[a-f0-9]{64}$/.test(root.configHash)
    || !Number.isSafeInteger(root.totalValue) || (root.totalValue as number) < 0
    || (root.totalValue as number) > MAX_CLIENT_INTEGER) {
    invalid();
  }
  const progressValues = dictionary(root.progress);
  if (Object.keys(progressValues).length > MAX_EVENT_DAYS) invalid();
  const progressEntries = Object.entries(progressValues).map(([key, value]) => {
    const index = canonicalIndex(key, MAX_EVENT_DAYS);
    const record = dictionary(value);
    const keys = Object.keys(record);
    if (keys.length !== PROGRESS_KEYS.size || keys.some((candidate) => !PROGRESS_KEYS.has(candidate))
      || !Number.isSafeInteger(record.v) || (record.v as number) < 0 || (record.v as number) > MAX_CLIENT_INTEGER
      || typeof record.c !== "boolean") {
      invalid();
    }
    return [index, { v: record.v as number, c: record.c }] as const;
  }).sort(([left], [right]) => left - right);

  const milestoneValues = dictionary(root.milestones);
  if (Object.keys(milestoneValues).length > MAX_MILESTONES) invalid();
  const milestoneEntries = Object.entries(milestoneValues).map(([key, claimed]) => {
    const index = canonicalIndex(key, MAX_MILESTONES);
    // The server stores this dictionary sparsely. A false value is not a migration marker; it is
    // equivalent to absence in client logic and must not survive as ambiguous durable state.
    if (claimed !== true) invalid();
    return index;
  }).sort((left, right) => left - right);

  return {
    eventId: root.eventId,
    totalValue: root.totalValue as number,
    progress: Object.fromEntries(progressEntries.map(([index, progress]) => [String(index), progress])),
    milestones: Object.fromEntries(milestoneEntries.map((index) => [String(index), true])),
    configHash: root.configHash,
  };
}
