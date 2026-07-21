import { ApiError } from "../apiErrors";
import { config } from "../config";
import type { StarterAssignmentState } from "../db";

export const STARTER_ASSIGNMENTS_INCORRECT = 18501;

const MAX_DATE_UNIX_SECONDS = 8_640_000_000_000;
const STARTER_ASSIGNMENT_IDS = new Set(
  Array.from({ length: 10 }, (_unused, index) => `ID_${index + 1}`),
);

/** Validate a starter-assignment time before it controls completion or reward eligibility. */
export function validatedStarterAssignmentUnixSeconds(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_DATE_UNIX_SECONDS) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, `${field} is invalid.`);
  }
  return value;
}

/**
 * Validate the complete recovered StarterAssignmentsData authority snapshot.
 *
 * A damaged `Infinity` or `NaN` deadline defeats a raw `now > deadline` expiry check. Likewise,
 * accepting an unknown record or a claimed-but-incomplete record would publish state that the
 * stock client can display but the backend cannot justify. This boundary runs before boot and
 * every completion/claim transition so corrupt imported JSON never becomes reward authority.
 */
export function validatedStarterAssignmentState(
  value: StarterAssignmentState | undefined,
): StarterAssignmentState | undefined {
  if (value === undefined) return undefined;
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment state is invalid.");
  }
  validatedStarterAssignmentUnixSeconds(value.deadline, "Starter assignment deadline");
  if (!value.assignments || typeof value.assignments !== "object" || Array.isArray(value.assignments)) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment records are invalid.");
  }
  const entries = Object.entries(value.assignments);
  if (entries.length > STARTER_ASSIGNMENT_IDS.size) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment record count is invalid.");
  }
  for (const [id, record] of entries) {
    if (
      !STARTER_ASSIGNMENT_IDS.has(id)
      || !record
      || typeof record.completed !== "boolean"
      || typeof record.claimed !== "boolean"
      || (record.claimed && !record.completed)
    ) {
      throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, `Starter assignment ${id} record is invalid.`);
    }
  }
  return value;
}

/** Derive a new or legacy account deadline without allowing arithmetic overflow. */
export function createInitialStarterAssignmentState(issuedAt: number): StarterAssignmentState {
  const start = validatedStarterAssignmentUnixSeconds(issuedAt, "Starter assignment issue time");
  const duration = config.starterAssignmentDurationSeconds;
  if (!Number.isSafeInteger(duration) || duration < 0) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment duration is invalid.");
  }
  return {
    deadline: validatedStarterAssignmentUnixSeconds(start + duration, "Starter assignment deadline"),
    assignments: {},
  };
}
