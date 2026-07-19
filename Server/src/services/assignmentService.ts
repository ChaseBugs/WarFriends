import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import { DbAction } from "../dbActions";
import type {
  AssignmentRecordState,
  AssignmentState,
  PlayerProgressionState,
  ProcessedRequestBuffer,
} from "../db";
import { mutateProgression } from "./progressionMutationService";
import { advanceSquadChatCursorState } from "./squadSocialService";
import {
  acknowledgeAchievementOffsetState,
  advanceAchievementState,
  claimAchievementState,
  validateAchievementProgressState,
} from "./achievementService";
import {
  claimStarterAssignmentState,
  serializeStarterAssignmentsData,
} from "./starterAssignmentService";
import {
  equipWeaponState,
  parseWeaponEquipData,
  parseWeaponPurchaseData,
  purchaseWeaponState,
  requestedWeaponName,
  weaponRecoveryFields,
} from "./itemInventoryService";

const SUCCESS = 1; // IJEAJGCCHEF.Success
const ASSIGNMENT_NOT_FOUND = 11201;
const ASSIGNMENT_INCORRECT_REWARD = 11203;
const MEGA_REWARD_POINTS = 50;
const MAX_BUFFER_REPLAYS = 20;

interface AssignmentTemplate {
  id: number;
  target: number;
  gold: number;
  megaPoints: number;
  progressPerPvpMatch: number;
  winsOnly: boolean;
}

/**
 * Safe subset of the TaskDefinitions rows recovered from MainScene.
 *
 * ID 5 is the easy score objective (target range starts at 2,000), ID 8 is the medium
 * "play PvP" objective (starts at 6), and ID 7 is the hard "win PvP" objective (starts at
 * 3). The original client can measure many more combat details, but the reconstructed relay
 * cannot yet verify crates, unit categories, cards, or skillshots. Generating only objectives
 * derived from a confirmed match prevents a modified client from completing arbitrary tasks.
 */
const ASSIGNMENT_TEMPLATES: readonly AssignmentTemplate[] = [
  { id: 5, target: 2_000, gold: 2, megaPoints: 1, progressPerPvpMatch: 1_000, winsOnly: false },
  { id: 8, target: 6, gold: 4, megaPoints: 2, progressPerPvpMatch: 1, winsOnly: false },
  { id: 7, target: 3, gold: 8, megaPoints: 3, progressPerPvpMatch: 1, winsOnly: true },
];

export interface AssignmentMutationResult {
  state: PlayerProgressionState;
  assignments: AssignmentState;
  goldAdded?: number;
}

export interface BufferedRequestInput {
  action: number;
  data: string;
}

export interface AssignmentBufferResult extends AssignmentMutationResult {
  requestsResults: string;
  replayed: boolean;
}

function dateAt(now: number): Date {
  return new Date(Math.floor(now) * 1_000);
}

function utcDayKey(now: number): string {
  return dateAt(now).toISOString().slice(0, 10);
}

function nextUtcMidnight(now: number): number {
  const date = dateAt(now);
  return Math.floor(Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate() + 1) / 1_000);
}

function newAssignment(template: AssignmentTemplate): AssignmentRecordState {
  return {
    id: template.id,
    done: false,
    claimed: false,
    completeFract: 0,
    lastCompletedFract: 0,
    target: template.target,
    secondTarget: 0,
    tutorialId: 0,
  };
}

/**
 * Materialize the current UTC assignment cycle. The mega cursor survives a daily reset,
 * while objectives, completion count, and the one-free-skip flag reset at midnight. This
 * function is pure so match settlement, reads, skips, and claims all apply identical rollover
 * behavior inside their optimistic-concurrency transaction.
 */
export function assignmentStateFor(state: PlayerProgressionState, now: number): AssignmentState {
  const key = utcDayKey(now);
  const existing = state.assignments;
  if (existing?.dayKey === key && existing.tomorrow > now) {
    return {
      ...existing,
      assignments: existing.assignments.map((assignment) => ({ ...assignment })),
    };
  }
  return {
    assignments: ASSIGNMENT_TEMPLATES.map(newAssignment),
    tomorrow: nextUtcMidnight(now),
    completed: 0,
    issued: Math.floor(now),
    megaReward: Math.max(0, existing?.megaReward ?? 0),
    skipUsed: false,
    dayKey: key,
  };
}

/** Omit server-only reset metadata and preserve the exact AssignmentData JSON property names. */
export function assignmentWireData(assignments: AssignmentState): Record<string, unknown> {
  return {
    assignments: assignments.assignments,
    tomorrow: assignments.tomorrow,
    completed: assignments.completed,
    issued: assignments.issued,
    megaReward: assignments.megaReward,
    skipUsed: assignments.skipUsed,
  };
}

export function serializeAssignmentData(assignments: AssignmentState): string {
  return JSON.stringify(assignmentWireData(assignments));
}

/** Create or refresh the daily cycle without changing any balance. */
export function ensureAssignmentsState(state: PlayerProgressionState, now: number): AssignmentMutationResult {
  const assignments = assignmentStateFor(state, now);
  return {
    state: { ...state, revision: state.revision + 1, assignments },
    assignments,
  };
}

/**
 * Advance only facts established by idempotent PvP settlement. A confirmed match always
 * advances the play and reconstructed score objectives; only the winner advances the win
 * objective. Fractions are capped at one and `done` is set by the server, so a client-sent
 * AssignmentsUpdate cannot bypass these counters.
 */
export function recordPvpAssignmentProgressState(
  state: PlayerProgressionState,
  now: number,
  won: boolean,
): AssignmentMutationResult {
  const assignments = assignmentStateFor(state, now);
  for (const assignment of assignments.assignments) {
    if (assignment.claimed || assignment.done) continue;
    const template = ASSIGNMENT_TEMPLATES.find((candidate) => candidate.id === assignment.id);
    if (!template || (template.winsOnly && !won)) continue;
    const previous = Math.max(0, assignment.lastCompletedFract + assignment.completeFract);
    const increment = template.progressPerPvpMatch / Math.max(1, assignment.target);
    assignment.lastCompletedFract = 0;
    assignment.completeFract = Math.min(1, previous + increment);
    assignment.done = assignment.completeFract >= 1;
  }
  return {
    state: { ...state, revision: state.revision + 1, assignments },
    assignments,
  };
}

function templateFor(id: number): AssignmentTemplate {
  const template = ASSIGNMENT_TEMPLATES.find((candidate) => candidate.id === id);
  if (!template) throw new ApiError(ASSIGNMENT_NOT_FOUND, "Assignment was not found.");
  return template;
}

/**
 * Credit a completed assignment exactly once. The old client submits its locally displayed
 * reward amount; validating it against the recovered server template detects altered/stale
 * requests. Gold, claim state, completion count, and mega points share one atomic write.
 */
export function claimAssignmentState(
  state: PlayerProgressionState,
  now: number,
  assignmentId: number,
  requestedReward: number,
): AssignmentMutationResult {
  const assignments = assignmentStateFor(state, now);
  const assignment = assignments.assignments.find((candidate) => candidate.id === assignmentId);
  const template = templateFor(assignmentId);
  if (!assignment || !assignment.done || assignment.claimed) {
    throw new ApiError(ASSIGNMENT_NOT_FOUND, "Assignment is not completed or was already claimed.");
  }
  if (requestedReward !== template.gold) {
    throw new ApiError(ASSIGNMENT_INCORRECT_REWARD, "Assignment reward does not match server balancing.");
  }

  assignment.claimed = true;
  assignments.completed += 1;
  assignments.megaReward += template.megaPoints;
  const rewardedState: PlayerProgressionState = {
    ...state,
    revision: state.revision + 1,
    gold: state.gold + template.gold,
    assignments,
  };
  // Achievement group 12 reads StatsManager.assignmentsCompleted in the client. Counting
  // only the atomic successful claim avoids progress from a locally forged `done` flag and
  // prevents a RequestBuffer replay from incrementing the lifetime counter twice.
  const achievementResult = advanceAchievementState(rewardedState, 12, 1);
  return {
    state: achievementResult.state,
    assignments,
    goldAdded: template.gold,
  };
}

/** Replace one unfinished objective and consume the single free skip for this UTC cycle. */
export function skipAssignmentState(
  state: PlayerProgressionState,
  now: number,
  assignmentIndex: number,
): AssignmentMutationResult {
  const assignments = assignmentStateFor(state, now);
  if (!Number.isInteger(assignmentIndex) || assignmentIndex < 0 || assignmentIndex >= assignments.assignments.length) {
    throw new ApiError(ASSIGNMENT_NOT_FOUND, "Assignment index is invalid.");
  }
  const current = assignments.assignments[assignmentIndex];
  if (assignments.skipUsed || current.done || current.claimed) {
    throw new ApiError(ApiErrorCode.UnknownAction, "The daily assignment skip is not available.");
  }
  assignments.assignments[assignmentIndex] = newAssignment(templateFor(current.id));
  assignments.skipUsed = true;
  return {
    state: { ...state, revision: state.revision + 1, assignments },
    assignments,
  };
}

/** Consume 50 recovered mega points and deliver a configurable currency-only fallback. */
export function claimAssignmentMegaRewardState(
  state: PlayerProgressionState,
  now: number,
): AssignmentMutationResult {
  const assignments = assignmentStateFor(state, now);
  if (assignments.megaReward < MEGA_REWARD_POINTS) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Assignment mega reward is not ready.");
  }
  const goldAdded = Math.max(0, Math.floor(config.assignmentMegaRewardGold));
  assignments.megaReward -= MEGA_REWARD_POINTS;
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold: state.gold + goldAdded,
      assignments,
    },
    assignments,
    goldAdded,
  };
}

function parseClaimData(data: string): { assignmentId: number; reward: number } {
  let value: unknown;
  try {
    value = JSON.parse(data);
  } catch {
    throw new ApiError(ASSIGNMENT_NOT_FOUND, "Buffered assignment data is invalid JSON.");
  }
  if (!value || typeof value !== "object") {
    throw new ApiError(ASSIGNMENT_NOT_FOUND, "Buffered assignment data is missing.");
  }
  const record = value as Record<string, unknown>;
  const assignmentId = Number(record.AssignmentId);
  const reward = Number(record.Reward);
  if (!Number.isInteger(assignmentId) || !Number.isInteger(reward)) {
    throw new ApiError(ASSIGNMENT_NOT_FOUND, "Buffered assignment fields are invalid.");
  }
  return { assignmentId, reward };
}

function parseAchievementData(data: string): Record<string, unknown> {
  let value: unknown;
  try {
    value = JSON.parse(data);
  } catch {
    throw new ApiError(21801, "Buffered achievement data is invalid JSON.");
  }
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(21801, "Buffered achievement data is missing.");
  }
  return value as Record<string, unknown>;
}

function parseStarterAssignmentClaimData(data: string): {
  assignmentId: string;
  gold: number;
  warBucks: number;
} {
  let value: unknown;
  try {
    value = JSON.parse(data);
  } catch {
    throw new ApiError(18501, "Buffered starter-assignment data is invalid JSON.");
  }
  if (!value || typeof value !== "object" || Array.isArray(value)) {
    throw new ApiError(18501, "Buffered starter-assignment data is missing.");
  }
  const record = value as Record<string, unknown>;
  const assignmentId = record.AssignmentId;
  const gold = Number(record.Gold);
  const warBucks = Number(record.WarBucks);
  if (
    typeof assignmentId !== "string" ||
    !/^ID_(?:[1-9]|10)$/.test(assignmentId) ||
    !Number.isInteger(gold) ||
    !Number.isInteger(warBucks)
  ) {
    throw new ApiError(18501, "Buffered starter-assignment fields are invalid.");
  }
  return { assignmentId, gold, warBucks };
}

function achievementInteger(record: Record<string, unknown>, field: string): number {
  const value = Number(record[field]);
  if (!Number.isInteger(value)) throw new ApiError(21801, `Achievement ${field} is invalid.`);
  return value;
}

function boundedReplayCache(
  existing: ProcessedRequestBuffer[] | undefined,
  item: ProcessedRequestBuffer,
): ProcessedRequestBuffer[] {
  return [...(existing ?? []).filter((entry) => entry.id !== item.id), item].slice(-MAX_BUFFER_REPLAYS);
}

/**
 * Process the stock RequestBuffer envelope in one progression transaction. Claim subrequests
 * are applied in numeric order and each receives the `ActionId`/`Result` object consumed by
 * OGLEHLIPEFM.JIMIKHFDEFC. The final serialized array is cached under BufferId, making a retry
 * after a lost response return the original result without crediting Gold again.
 *
 * SaveLastSeenSquadChatTimeStamp, ClaimStarterAssignment, achievement actions 218-220, and
 * the recovered BuyWeapon/EquipWeapon subset are also supported because their managers
 * append them to this same transport. Client progress, price, reward, ownership, and army-
 * power fields are validation assertions, not authority. Other buffered economy actions
 * remain explicit per-item failures until their resource rows and inventory lifecycles are
 * recovered to the same standard.
 */
export function processAssignmentBufferState(
  state: PlayerProgressionState,
  now: number,
  bufferId: string,
  requests: readonly BufferedRequestInput[],
  playerLevel = 1,
): AssignmentBufferResult {
  const replay = state.processedRequestBuffers?.find((entry) => entry.id === bufferId);
  if (replay) {
    const assignments = assignmentStateFor(state, now);
    return {
      state: { ...state, revision: state.revision + 1, assignments },
      assignments,
      requestsResults: replay.result,
      replayed: true,
    };
  }

  let working = state;
  const responses: Record<string, unknown>[] = [];
  for (const request of requests) {
    if (request.action === DbAction.BuyWeapon || request.action === DbAction.EquipWeapon) {
      try {
        if (request.action === DbAction.BuyWeapon) {
          // WeaponScreen has already applied Buy() locally before this buffer reaches the
          // server. The transition independently validates the 4.9.5 catalog row, level,
          // currency, and discount before committing ownership.
          working = purchaseWeaponState(
            working,
            playerLevel,
            parseWeaponPurchaseData(request.data),
          ).state;
        } else {
          // EquipWeapon is also optimistic on the client. Only the stored ownership record
          // and recovered slot-category mask are authoritative here; client ArmyPower is
          // checked for shape but never written to the leaderboard/profile fields.
          working = equipWeaponState(working, parseWeaponEquipData(request.data)).state;
        }
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          // JIMIKHFDEFC consumes these fields to undo the client's optimistic local change.
          ...weaponRecoveryFields(working, requestedWeaponName(request.data)),
        });
      }
      continue;
    }

    if (request.action === DbAction.SaveLastSeenSquadChatTimeStamp) {
      try {
        const timestamp = Number(request.data);
        working = advanceSquadChatCursorState(working, now, timestamp).state;
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({ ActionId: request.action, Result: code });
      }
      continue;
    }

    if (
      request.action === DbAction.ClaimAchievement ||
      request.action === DbAction.ChangeAchievementOffset ||
      request.action === DbAction.ChangeAchievementProgres
    ) {
      try {
        const payload = parseAchievementData(request.data);
        const groupId = achievementInteger(payload, "Id");
        if (request.action === DbAction.ClaimAchievement) {
          working = claimAchievementState(
            working,
            groupId,
            achievementInteger(payload, "ProgressId"),
          ).state;
        } else if (request.action === DbAction.ChangeAchievementOffset) {
          working = acknowledgeAchievementOffsetState(
            working,
            groupId,
            achievementInteger(payload, "Offset"),
          ).state;
        } else {
          working = validateAchievementProgressState(
            working,
            groupId,
            achievementInteger(payload, "Progress"),
          ).state;
        }
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({ ActionId: request.action, Result: code });
      }
      continue;
    }

    if (request.action === DbAction.ClaimStarterAssignment) {
      try {
        const claim = parseStarterAssignmentClaimData(request.data);
        const result = claimStarterAssignmentState(
          working,
          now,
          claim.assignmentId,
          claim.gold,
          claim.warBucks,
        );
        working = result.state;
        const response: Record<string, unknown> = { ActionId: request.action, Result: SUCCESS };

        // The final onboarding claim switches the UI to daily assignments. The stock parser
        // accepts AssignmentData on a successful ClaimStarterAssignment result, so generate
        // the current UTC cycle without requiring a second network round trip.
        const allClaimed = Object.values(result.starterAssignments.assignments)
          .filter((record) => record.claimed).length === 10;
        if (allClaimed) {
          const daily = assignmentStateFor(working, now);
          working = { ...working, revision: working.revision + 1, assignments: daily };
          response.AssignmentData = serializeAssignmentData(daily);
        }
        responses.push(response);
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        const starterAssignments = working.starterAssignments ?? { deadline: now, assignments: {} };
        responses.push({
          ActionId: request.action,
          Result: code,
          StarterAssignmentsData: serializeStarterAssignmentsData(starterAssignments),
          Gold: working.gold,
          WarBucks: working.warBucks,
        });
      }
      continue;
    }

    if (request.action !== DbAction.ClaimAssignment) {
      responses.push({ ActionId: request.action, Result: ApiErrorCode.UnknownAction });
      continue;
    }
    try {
      const claim = parseClaimData(request.data);
      const result = claimAssignmentState(working, now, claim.assignmentId, claim.reward);
      working = result.state;
      responses.push({ ActionId: request.action, Result: SUCCESS });
    } catch (error) {
      const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
      const assignments = assignmentStateFor(working, now);
      responses.push({
        ActionId: request.action,
        Result: code,
        AssignmentData: serializeAssignmentData(assignments),
        Gold: working.gold,
      });
    }
  }

  const assignments = assignmentStateFor(working, now);
  const requestsResults = JSON.stringify(responses);
  const processedRequestBuffers = boundedReplayCache(working.processedRequestBuffers, {
    id: bufferId,
    result: requestsResults,
    processedAt: Math.floor(now),
  });
  return {
    state: {
      ...working,
      revision: working.revision + 1,
      assignments,
      processedRequestBuffers,
    },
    assignments,
    requestsResults,
    replayed: false,
  };
}

export function getOrCreateAssignments(playerId: string): Promise<AssignmentMutationResult> {
  return mutateProgression(playerId, ensureAssignmentsState);
}

export function recordPvpAssignmentProgress(playerId: string, won: boolean): Promise<AssignmentMutationResult> {
  return mutateProgression(playerId, (state, now) => recordPvpAssignmentProgressState(state, now, won));
}

export function claimAssignment(
  playerId: string,
  assignmentId: number,
  requestedReward: number,
): Promise<AssignmentMutationResult> {
  return mutateProgression(playerId, (state, now) =>
    claimAssignmentState(state, now, assignmentId, requestedReward));
}

export function skipAssignment(playerId: string, index: number): Promise<AssignmentMutationResult> {
  return mutateProgression(playerId, (state, now) => skipAssignmentState(state, now, index));
}

export function claimAssignmentMegaReward(playerId: string): Promise<AssignmentMutationResult> {
  return mutateProgression(playerId, claimAssignmentMegaRewardState);
}

export function processAssignmentBuffer(
  playerId: string,
  bufferId: string,
  requests: readonly BufferedRequestInput[],
  playerLevel = 1,
): Promise<AssignmentBufferResult> {
  return mutateProgression(playerId, (state, now) =>
    processAssignmentBufferState(state, now, bufferId, requests, playerLevel));
}
