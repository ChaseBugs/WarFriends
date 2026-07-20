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
  synchronizeLeagueAchievementState,
  validateAchievementProgressState,
} from "./achievementService";
import {
  claimStarterAssignmentState,
  serializeStarterAssignmentsData,
} from "./starterAssignmentService";
import {
  activateWeaponUpgradeState,
  equipWeaponState,
  instantWeaponUpgradeState,
  markWeaponShownState,
  parseWeaponUpgradeActivateData,
  parseWeaponUpgradeInstantData,
  parseWeaponUpgradePurchaseData,
  parseWeaponEquipData,
  parseWeaponPurchaseData,
  purchaseWeaponState,
  requestedWeaponName,
  startWeaponUpgradeState,
  weaponRecoveryFields,
} from "./itemInventoryService";
import {
  activateUnitState,
  activateUnitUpgradeState,
  convertScrapsToUnitPartsState,
  convertUnitPartsToScrapsState,
  equippedUnitsRecoveryFields,
  instantUnitUpgradeState,
  markUnitShownState,
  parseUnitActivateData,
  parseUnitEquipData,
  parseUnitEliteUpgradeData,
  parseUnitPartsToScrapsData,
  parseUnitPromoteData,
  parseUnitPurchaseData,
  parseUnitScrapsToPartsData,
  parseUnitUpgradeActivateData,
  parseUnitUpgradeInstantData,
  parseUnitUpgradePurchaseData,
  purchaseUnitState,
  promoteUnitState,
  requestedUnitName,
  startUnitUpgradeState,
  unitRecoveryFields,
  unitPromotionErrorFields,
  upgradeUnitEliteState,
  updateEquippedUnitsState,
} from "./unitInventoryService";
import {
  equipVisualState,
  markVisualShownState,
  parseVisualPurchaseData,
  purchaseVisualState,
  requestedVisualName,
  visualRecoveryFields,
  VISUAL_CATALOG,
} from "./visualInventoryService";
import {
  cardPackRecoveryFields,
  parseCardPackPurchaseData,
  purchaseCardPackState,
  requestedCardPackName,
} from "./cardInventoryService";
import {
  claimEventAssignmentState,
  claimEventMilestoneState,
  getActiveConfiguredEventAssignment,
  type EventAssignmentEventConfig,
} from "./eventAssignmentService";

/**
 * Daily assignments and the recovered RequestBuffer transaction boundary.
 *
 * This module has two closely related responsibilities. First, it creates the UTC daily
 * assignment cycle and advances objectives only from facts already established by the
 * backend. Second, it decodes the client's batched RequestBuffer, executes supported actions
 * in their original order, and returns one result object per action. Several managers share
 * that buffer, so weapon purchases, starter rewards, achievements, chat cursors, and normal
 * assignment claims all meet here even though their state transitions live in separate
 * services.
 *
 * A `BufferId` is an idempotency key. The complete serialized response is persisted after
 * processing and returned unchanged on retry. This is essential because the Unity client
 * can resend a whole batch after losing the HTTP response; recomputing the batch would grant
 * successful rewards twice or make a previously successful claim appear to fail.
 */

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

function parseEventClaimData(data: string): { rewardType: number; rewardValue: number } {
  const record = parseAchievementData(data);
  const rewardType = Number(record.RewardType);
  const rewardValue = Number(record.RewardValue);
  if (!Number.isInteger(rewardType) || !Number.isInteger(rewardValue)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Buffered Event Assignment reward fields are invalid.");
  }
  return { rewardType, rewardValue };
}

function parseEventMilestoneData(data: string): { milestoneId: number; rewardValue: string } {
  const record = parseAchievementData(data);
  const milestoneId = Number(record.MilestoneId);
  const rewardValue = record.RewardValue;
  if (!Number.isInteger(milestoneId) || typeof rewardValue !== "string" || rewardValue.length > 128) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Buffered Event milestone fields are invalid.");
  }
  return { milestoneId, rewardValue };
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
 * the recovered weapon lifecycle, zero-delivery unit purchase/equip actions, and Elite-part
 * conversions are also supported because their managers append them to this same transport.
 * Client progress, price, reward, ownership, and army-power fields are validation assertions,
 * not authority. Other buffered economy actions remain explicit per-item failures until their
 * resource rows and inventory lifecycles are recovered to the same standard.
 */
export function processAssignmentBufferState(
  state: PlayerProgressionState,
  now: number,
  bufferId: string,
  requests: readonly BufferedRequestInput[],
  playerLevel = 1,
  playerVipExpiration = 0,
  playerLeagueTier?: number,
  eventAssignment?: EventAssignmentEventConfig | null,
): AssignmentBufferResult {
  // VIP is part of the same progression revision as buffered visual purchases. The optional
  // argument exists only for legacy documents whose entitlement still lives in the profile.
  const effectiveVipExpiration = state.vipExpiration ?? playerVipExpiration;
  const replay = state.processedRequestBuffers?.find((entry) => entry.id === bufferId);
  if (replay) {
    // Do not execute any subrequest again. Even deterministic validation is insufficient
    // here: a successful item earlier in the original batch may already have changed the
    // wallet, so recalculating later items against the new balance could produce a different
    // response array. Return the exact bytes stored for the original attempt instead.
    const assignments = assignmentStateFor(state, now);
    return {
      state: { ...state, revision: state.revision + 1, assignments },
      assignments,
      requestsResults: replay.result,
      replayed: true,
    };
  }

  // AchievementGetToLeague reads DatabasePlayer.leagueTier in the recovered client. Supply the
  // authenticated document's server-owned value at this transaction boundary so actions 218-220
  // can validate/claim group 13 even for accounts promoted before the achievement was recovered.
  // A stored BufferId replay returns above without re-running this migration or any subrequest.
  let working = playerLeagueTier === undefined
    ? state
    : synchronizeLeagueAchievementState(state, playerLeagueTier).state;
  const responses: Record<string, unknown>[] = [];
  for (const request of requests) {
    // `working` is advanced only by successful subrequests. A rejected item contributes an
    // error result but does not abort the remaining batch, matching the stock parser's
    // one-result-per-action contract. The outer optimistic transaction commits the final
    // working snapshot and the replay record together.
    if (request.action === DbAction.WeaponWasShown) {
      try {
        // WeaponScreen.WasShown queues the raw runtime name after displaying an unlocked
        // weapon. Persist only the badge flag; catalog, level, ownership, and equipment stay
        // server-owned and the enclosing BufferId makes this acknowledgement replay-safe.
        working = markWeaponShownState(working, playerLevel, request.data).state;
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          ...weaponRecoveryFields(working, request.data),
        });
      }
      continue;
    }

    if (request.action === DbAction.ArmyUnitWasShown) {
      try {
        // ArmyScreen sends the raw unit sheet name under the same conditions. The sparse
        // SavedArmySlots row survives login but cannot be equipped or upgraded as ownership.
        working = markUnitShownState(working, playerLevel, request.data).state;
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          ...unitRecoveryFields(working, request.data),
        });
      }
      continue;
    }

    if (
      request.action === DbAction.BuyWeapon
      || request.action === DbAction.EquipWeapon
      || request.action === DbAction.BuyWeaponUpgrade
      || request.action === DbAction.InstantWeaponUpgrade
      || request.action === DbAction.ActivateWeaponUpgrade
    ) {
      try {
        let successResponse: Record<string, unknown> = { ActionId: request.action, Result: SUCCESS };
        if (request.action === DbAction.BuyWeapon) {
          // WeaponScreen has already applied Buy() locally before this buffer reaches the
          // server. The transition independently validates the 4.9.5 catalog row, level,
          // currency, and discount before committing ownership.
          working = purchaseWeaponState(
            working,
            playerLevel,
            parseWeaponPurchaseData(request.data),
            now,
          ).state;
        } else if (request.action === DbAction.EquipWeapon) {
          // EquipWeapon is also optimistic on the client. Only the stored ownership record
          // and recovered slot-category mask are authoritative here; client ArmyPower is
          // checked for shape but never written to the leaderboard/profile fields.
          // RentalDialog queues the ordinary EquipWeapon action after action 138 grants a
          // borrowed trial. Pass the authoritative buffer time so only that live trial may
          // cross the otherwise permanent-ownership equipment boundary.
          working = equipWeaponState(working, parseWeaponEquipData(request.data), now).state;
        } else if (request.action === DbAction.BuyWeaponUpgrade) {
          // Buying an upgrade creates a shared LevelManager.weaponDelivery receipt but does
          // not increment boughtIndex. The response duration is important: on the last item
          // in a RequestBuffer, JIMIKHFDEFC calls SetWeaponDeliveryTime so client clock drift
          // is corrected to the exact server-authoritative MainScene duration.
          const upgraded = startWeaponUpgradeState(
            working,
            now,
            parseWeaponUpgradePurchaseData(request.data),
          );
          working = upgraded.state;
          successResponse = {
            ActionId: request.action,
            Result: SUCCESS,
            DeliveryTime: upgraded.deliveryTime,
          };
        } else if (request.action === DbAction.InstantWeaponUpgrade) {
          // WeaponScreen has already incremented its local boughtIndex. The server verifies
          // the old index and pending receipt, recalculates Gold from remaining server time,
          // then commits the increment and clears delivery in one progression transition.
          working = instantWeaponUpgradeState(
            working,
            now,
            parseWeaponUpgradeInstantData(request.data),
          ).state;
        } else {
          // Normal activation is free, but only after the persisted delivery end timestamp.
          // Consuming the receipt and incrementing the level together prevents duplicate
          // activation when the client retries a lost RequestBuffer response.
          working = activateWeaponUpgradeState(
            working,
            now,
            parseWeaponUpgradeActivateData(request.data),
          ).state;
        }
        responses.push(successResponse);
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

    if (request.action === DbAction.BuyUnit || request.action === DbAction.ActivateUnit) {
      try {
        if (request.action === DbAction.BuyUnit) {
          // ArmyScreen calls UpgradeSlots.Buy() before transport, so a failure must later
          // return the authoritative unit and wallet for rollback. The server independently
          // verifies the recovered roster row, zero-based level gate, exact price, display
          // unlock level, and unsupported discount before granting SavedArmySlots ownership.
          working = purchaseUnitState(
            working,
            playerLevel,
            parseUnitPurchaseData(request.data),
          ).state;
        } else {
          // All supported 4.9.5 purchase rows have zero delivery time. Unity therefore queues
          // ActivateUnit immediately after BuyUnit; this validates that the earlier subrequest
          // really created ownership but does not debit or grant a second time.
          working = activateUnitState(working, parseUnitActivateData(request.data)).state;
        }
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          // The client already changed UpgradeSlots locally; these exact fields restore the
          // last committed state while allowing later subrequests in the batch to continue.
          ...unitRecoveryFields(working, requestedUnitName(request.data)),
        });
      }
      continue;
    }

    if (
      request.action === DbAction.BuyUnitUpgrade
      || request.action === DbAction.InstantUnitUpgrade
      || request.action === DbAction.ActivateUnitUpgrade
    ) {
      try {
        let successResponse: Record<string, unknown> = { ActionId: request.action, Result: SUCCESS };
        if (request.action === DbAction.BuyUnitUpgrade) {
          // UpgradeSlot.KDIHEKPKCJJ has already created the optimistic local unitDelivery.
          // The server independently validates the selected lane, current cursor, tier
          // boundary, recovered price/time row, wallet, and shared-receipt availability.
          const upgraded = startUnitUpgradeState(
            working,
            now,
            parseUnitUpgradePurchaseData(request.data),
          );
          working = upgraded.state;
          successResponse = {
            ActionId: request.action,
            Result: SUCCESS,
            // OGLEHLIPEFM forwards this value to SetUnitDeliveryTime for clock correction
            // when this result is the last entry in the stock RequestBuffer response.
            DeliveryTime: upgraded.deliveryTime,
          };
        } else if (request.action === DbAction.InstantUnitUpgrade) {
          // The request omits IsSpecial. matchingUnitDelivery uses the persisted slotId so a
          // modified client cannot finish the cheaper lane while advancing the other cursor.
          working = instantUnitUpgradeState(
            working,
            now,
            parseUnitUpgradeInstantData(request.data),
          ).state;
        } else {
          // Normal activation is free only after the server receipt expires. Receipt removal
          // and cursor advancement happen in one immutable progression transition.
          working = activateUnitUpgradeState(
            working,
            now,
            parseUnitUpgradeActivateData(request.data),
          ).state;
        }
        responses.push(successResponse);
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          // ArmyScreen has already changed its wallet, cursor, and receipt. These are the
          // exact fields consumed by OGLEHLIPEFM to restore the last committed server state.
          ...unitRecoveryFields(working, requestedUnitName(request.data)),
        });
      }
      continue;
    }

    if (request.action === DbAction.PromoteUnit) {
      try {
        // ArmyScreen has already incremented actualTier locally. The server reconstructs the
        // gate from its saved normal cursor, zero-based player level, recovered UNLOCKTIERn
        // values, maximum tier, and the globally shared unit-delivery receipt.
        working = promoteUnitState(
          working,
          playerLevel,
          parseUnitPromoteData(request.data),
        ).state;
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        const name = requestedUnitName(request.data);
        responses.push({
          ActionId: request.action,
          Result: code,
          // NotEnoughLevelForPromote's global handler reads these two strings for diagnostics.
          ...unitPromotionErrorFields(working, playerLevel, name),
          // Preserve the authoritative unit snapshot for compatible clients and diagnostics;
          // the stock 1.6.0 promotion success path needs no response body beyond Result.
          ...unitRecoveryFields(working, name),
        });
      }
      continue;
    }

    if (request.action === DbAction.UpgradeEliteSlot) {
      try {
        // ArmyScreen has already removed unit-specific parts, removed WarBucks, and advanced
        // eliteSlot locally. The server selects the old relative cursor's STARTINGELITE row,
        // validates both echoed costs, and commits all three fields without a delivery timer.
        working = upgradeUnitEliteState(
          working,
          parseUnitEliteUpgradeData(request.data),
        ).state;
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          // The stock error branch relogs for every recoverable elite failure. Returning the
          // authoritative snapshot also supports compatible clients and makes the batch result
          // self-contained while BufferId replay protection preserves exactly-once spending.
          ...unitRecoveryFields(working, requestedUnitName(request.data)),
        });
      }
      continue;
    }

    if (
      request.action === DbAction.ConvertScrapsToParts
      || request.action === DbAction.ConvertPartsToScraps
    ) {
      try {
        if (request.action === DbAction.ConvertScrapsToParts) {
          // ArmyLeftBuffDialog sends only the unit sheet name, then optimistically spends
          // Scraps and fills the current Elite requirement. The server selects that target
          // from the current cursor and recovered 24-Scraps-per-part constant.
          working = convertScrapsToUnitPartsState(
            working,
            parseUnitScrapsToPartsData(request.data),
          ).state;
        } else {
          // The sell dialog sends all current parts plus its expected reward. Validate both
          // against the stored unit and the recovered 5-Scraps-per-part rate before clearing
          // parts and crediting the wallet in the same RequestBuffer transaction.
          working = convertUnitPartsToScrapsState(
            working,
            parseUnitPartsToScrapsData(request.data),
          ).state;
        }
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        // The stock parser has dedicated conversion warnings and then relogs. It does not
        // consume inline rollback fields, so the last committed state remains untouched and
        // GetPlayerData restores the optimistic client mutation after the warning closes.
        responses.push({ ActionId: request.action, Result: code });
      }
      continue;
    }

    if (request.action === DbAction.UpdateEquippedUnits) {
      try {
        // ArmyScreen sends this immediately after TryToEquip succeeds. The transition treats
        // the map as a full active-roster snapshot and independently enforces ownership plus
        // the recovered two-per-category and three-mechanical-unit limits.
        working = updateEquippedUnitsState(working, parseUnitEquipData(request.data), now).state;
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          // CantEquipUnit makes Unity replace every included SavedArmySlots object with this
          // last committed snapshot before rebuilding the ArmyScreen selection state.
          ...equippedUnitsRecoveryFields(working),
        });
      }
      continue;
    }

    if (
      request.action === DbAction.BuyDecal
      || request.action === DbAction.EquipDecal
      || request.action === DbAction.DecalWasShown
      || request.action === DbAction.VisualWasShown
    ) {
      try {
        let response: Record<string, unknown> = { ActionId: request.action, Result: SUCCESS };
        if (request.action === DbAction.BuyDecal) {
          // CamosScreen marks the item bought and debits its local wallet before transport.
          // Rebuild the price, unlock, VIP, duration, and shop eligibility from the extracted
          // MainScene row; client values are assertions and cannot authorize hidden/event loot.
          const result = purchaseVisualState(
            working,
            now,
            playerLevel,
            effectiveVipExpiration,
            parseVisualPurchaseData(request.data),
          );
          working = result.state;
          response = {
            ActionId: request.action,
            Result: SUCCESS,
            DecalId: result.definition.name,
            ExpiresOn: result.expiresOn,
          };
        } else if (request.action === DbAction.EquipDecal) {
          // EquipDecal.data is the raw PlayerVisuals row name rather than a JSON object.
          // Ownership includes free defaults and unexpired timed power bands, but never an
          // unsupported borrowed/rental record.
          working = equipVisualState(working, now, request.data).state;
        } else if (request.action === DbAction.VisualWasShown || VISUAL_CATALOG[request.data]) {
          // Current VisualWasShown carries the row ID. Historical builds also used
          // DecalWasShown, but some recovered call sites attach unrelated impression data;
          // persist the legacy acknowledgement only when it resolves to a real visual.
          working = markVisualShownState(working, request.data).state;
        }
        responses.push(response);
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          // BuyDecal and EquipDecal are optimistic locally; the recovered result parser uses
          // this complete snapshot and both wallet balances to roll them back on failure.
          ...visualRecoveryFields(working),
          DecalId: requestedVisualName(request.data),
        });
      }
      continue;
    }

    if (request.action === DbAction.BuyCardPack) {
      try {
        // CardManager has already added the locally rolled cards before transport. Rebuild
        // pack price/count/rarity rules from MainScene and add only source-valid card IDs;
        // the request never supplies an authoritative price.
        const result = purchaseCardPackState(
          working,
          playerLevel,
          parseCardPackPurchaseData(request.data),
        );
        working = result.state;
        responses.push({
          ActionId: request.action,
          Result: SUCCESS,
          CardPack: result.pack.name,
          Cards: result.cards,
        });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        responses.push({
          ActionId: request.action,
          Result: code,
          // Codes 100/112/13601 make the stock parser replace its optimistic local card
          // counts and both wallet balances with this last committed server snapshot.
          ...cardPackRecoveryFields(working),
          CardPack: requestedCardPackName(request.data),
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

    if (request.action === DbAction.ClaimEventAssignment || request.action === DbAction.ClaimEventMilestone) {
      try {
        if (!eventAssignment) throw new ApiError(ApiErrorCode.UnknownAction, "No Event Assignment is active.");
        // Both requests are optimistic locally. The phone echoes what it displayed, but the
        // immutable deployment config chooses the day, target, points, and reward actually
        // committed. EventAssignmentUpdate is intentionally absent because its box count is
        // client-controlled until the battle relay can prove individual destructions.
        working = request.action === DbAction.ClaimEventAssignment
          ? claimEventAssignmentState(working, eventAssignment, now, parseEventClaimData(request.data)).state
          : claimEventMilestoneState(working, eventAssignment, now, parseEventMilestoneData(request.data)).state;
        responses.push({ ActionId: request.action, Result: SUCCESS });
      } catch (error) {
        const code = error instanceof ApiError ? error.code : ApiErrorCode.InternalServerError;
        // The recovered action-222/223 parser only checks Result and relogs on failure, so no
        // guessed rollback fields are emitted. GetPlayerData then restores the durable state.
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
  // Cache only a bounded tail. Buffer IDs protect short-term transport retries, not an
  // unbounded audit history; retaining every mobile request forever would make the embedded
  // progression document grow without limit.
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

export async function processAssignmentBuffer(
  playerId: string,
  bufferId: string,
  requests: readonly BufferedRequestInput[],
  playerLevel = 1,
  playerVipExpiration = 0,
  playerLeagueTier?: number,
): Promise<AssignmentBufferResult> {
  // Load once before the optimistic transaction. The config is process-cached and immutable;
  // each retry still receives a fresh `now` and revalidates the active half-open time window.
  const eventAssignment = await getActiveConfiguredEventAssignment(Math.floor(Date.now() / 1_000));
  return mutateProgression(playerId, (state, now) =>
    processAssignmentBufferState(
      state,
      now,
      bufferId,
      requests,
      playerLevel,
      playerVipExpiration,
      playerLeagueTier,
      eventAssignment,
    ));
}
