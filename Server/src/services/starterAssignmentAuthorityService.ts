import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import type { StarterAssignmentState } from "../db";

export const STARTER_ASSIGNMENTS_INCORRECT = 18501;

// StarterAssignmentsManager.StarterAssignmentsData.deadline is a C# signed int in the recovered
// client. A wider JavaScript-safe timestamp would pass backend arithmetic but fail client JSON
// deserialization, so the transport width is the authoritative deadline and duration ceiling.
const MAX_CLIENT_UNIX_SECONDS = 2_147_483_647;
const STARTER_ASSIGNMENT_IDS = new Set(
  Array.from({ length: 10 }, (_unused, index) => `ID_${index + 1}`),
);

export interface StarterAssignmentDurationPolicy {
  readonly seconds: number;
}

/**
 * Validate the server-owned replacement for the retired onboarding deadline policy.
 *
 * The recovered clients consume an absolute deadline but do not contain the production duration.
 * Resolve this reconstruction policy once during module startup so one process cannot issue
 * different onboarding windows after a mutable config change. The upper bound is the same bounded
 * signed-client Unix-second domain accepted by the durable StarterAssignmentsData validator.
 */
function exactStarterAssignmentDurationPolicy(
  policy: StarterAssignmentDurationPolicy,
): StarterAssignmentDurationPolicy {
  if (
    !Number.isSafeInteger(policy.seconds)
    || policy.seconds < 0
    || policy.seconds > MAX_CLIENT_UNIX_SECONDS
  ) {
    throw new ApiError(
      ApiErrorCode.InternalServerError,
      "Starter assignment duration policy is invalid.",
    );
  }
  return { seconds: policy.seconds };
}

const CONFIGURED_STARTER_ASSIGNMENT_DURATION_POLICY = Object.freeze(
  exactStarterAssignmentDurationPolicy({ seconds: config.starterAssignmentDurationSeconds }),
);

export function starterAssignmentDurationPolicy(
  policy?: StarterAssignmentDurationPolicy,
): StarterAssignmentDurationPolicy {
  return policy === undefined
    ? CONFIGURED_STARTER_ASSIGNMENT_DURATION_POLICY
    : exactStarterAssignmentDurationPolicy(policy);
}

/** Validate a starter-assignment time before it controls completion or reward eligibility. */
export function validatedStarterAssignmentUnixSeconds(value: number, field: string): number {
  if (!Number.isSafeInteger(value) || value < 0 || value > MAX_CLIENT_UNIX_SECONDS) {
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
  const duration = CONFIGURED_STARTER_ASSIGNMENT_DURATION_POLICY.seconds;
  if (start > MAX_CLIENT_UNIX_SECONDS - duration) {
    // Check subtraction before addition so an extreme but individually valid issue time can never
    // overflow the recovered signed-int durable deadline domain during initialization.
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment deadline is invalid.");
  }
  return {
    deadline: start + duration,
    assignments: {},
  };
}
