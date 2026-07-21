import { ApiError } from "../apiErrors";
import { config } from "../config";
import type {
  PlayerProgressionState,
  StarterAssignmentRecordState,
  StarterAssignmentState,
} from "../db";
import { findById } from "./playerService";
import { mutateProgression } from "./progressionMutationService";
import { createInitialItemInventory } from "./itemInventoryService";
import { checkedRewardBalance } from "./rewardMathService";

/** Exact IJEAJGCCHEF values handled by the recovered RequestBuffer response parser. */
export const STARTER_ASSIGNMENTS_INCORRECT = 18501;
export const STARTER_ASSIGNMENT_REWARD_INCORRECT = 18502;

export interface StarterAssignmentDefinition {
  id: string;
  target: number;
  gold: number;
  warBucks: number;
  order: number;
  authority: "rankedWins" | "medals" | "level" | "squadPoints" | "heroicPoints" | "weaponLevel" | "craftedGold" | "warCardsPlayed" | "unrecovered";
}

/**
 * Complete balancing table serialized on the Starter Assignments Manager in the recovered
 * 4.9.5 MainScene. The 1.6.0 scripts consume the same ID/VALUE/REWARD/ORDER schema.
 *
 * Keeping even currently unsupported rows in this table matters: the server can validate a
 * claim against the real reward and order without ever accepting the Gold/WarBucks values
 * sent by the client. `authority` explicitly records whether this backend can prove the
 * completion fact. Unit deployment remains rejected until its authoritative gameplay path
 * is rebuilt. Recovered class registration proves ID_2 is PlayWarcard and ID_3 is
 * DeployUnit; ID_2 uses only cards actually consumed by confirmed PvP settlement. ID_8 is
 * proven only when ClaimCraftedCard
 * atomically grants a Gold result. ID_6 is proven
 * by the first replay-safe daily/co-op mission settlement, matching
 * StarterAssignmentWinMissionFirst's `heroicPoints > 0` check.
 */
export const STARTER_ASSIGNMENT_DEFINITIONS: readonly StarterAssignmentDefinition[] = [
  { id: "ID_1", target: 1, gold: 2, warBucks: 0, order: 1, authority: "rankedWins" },
  { id: "ID_2", target: 3, gold: 6, warBucks: 0, order: 10, authority: "warCardsPlayed" },
  { id: "ID_3", target: -1, gold: 3, warBucks: 0, order: 3, authority: "unrecovered" },
  { id: "ID_4", target: 35, gold: 0, warBucks: 2_000, order: 2, authority: "medals" },
  { id: "ID_5", target: 5, gold: 4, warBucks: 0, order: 5, authority: "level" },
  { id: "ID_6", target: 1, gold: 0, warBucks: 4_000, order: 6, authority: "heroicPoints" },
  { id: "ID_7", target: 3, gold: 0, warBucks: 3_000, order: 4, authority: "weaponLevel" },
  { id: "ID_8", target: -1, gold: 0, warBucks: 5_000, order: 9, authority: "craftedGold" },
  { id: "ID_9", target: 6, gold: 5, warBucks: 0, order: 8, authority: "level" },
  { id: "ID_10", target: 3, gold: 0, warBucks: 6_000, order: 7, authority: "squadPoints" },
];

export interface StarterAssignmentFacts {
  medalsBalance: number;
  level: number;
  squadPointsTotal: number;
}

export interface StarterAssignmentMutationResult {
  state: PlayerProgressionState;
  starterAssignments: StarterAssignmentState;
  reward?: { gold: number; warBucks: number };
}

function cloneAssignments(assignments: StarterAssignmentState): StarterAssignmentState {
  return {
    deadline: assignments.deadline,
    assignments: Object.fromEntries(
      Object.entries(assignments.assignments).map(([id, value]) => [id, { ...value }]),
    ),
  };
}

/**
 * Materialize the client object without silently renewing an expired legacy account.
 * `issuedAt` is account creation time, because choosing request time would let deletion of
 * the field restart a limited offer. Existing persisted state always wins and is cloned so
 * pure transitions never mutate a caller's snapshot in place.
 */
export function starterAssignmentStateFor(
  state: PlayerProgressionState,
  issuedAt: number,
): StarterAssignmentState {
  if (state.starterAssignments) return cloneAssignments(state.starterAssignments);
  const duration = Math.max(0, Math.floor(config.starterAssignmentDurationSeconds));
  return { deadline: Math.floor(issuedAt) + duration, assignments: {} };
}

export function starterAssignmentWireData(value: StarterAssignmentState): StarterAssignmentState {
  // The persisted shape already uses the exact lower-camel-case fields expected by
  // Newtonsoft.Json, but returning a clone prevents response construction from exposing a
  // mutable reference to the optimistic-concurrency transition.
  return cloneAssignments(value);
}

export function serializeStarterAssignmentsData(value: StarterAssignmentState): string {
  return JSON.stringify(starterAssignmentWireData(value));
}

function definitionFor(id: string): StarterAssignmentDefinition {
  const definition = STARTER_ASSIGNMENT_DEFINITIONS.find((candidate) => candidate.id === id);
  if (!definition) throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment was not found.");
  return definition;
}

/**
 * Validate one persisted fact before it participates in a starter reward decision.
 *
 * JavaScript comparisons fail open in different directions for damaged numeric values:
 * `Infinity >= target` is true, while `NaN >= target` is false. Neither result describes an
 * authoritative gameplay fact. Rejecting both here also prevents a partially imported profile
 * from publishing a permanent `completed` marker that would remain claimable after the source
 * counter is repaired.
 */
function starterCounter(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, `Starter assignment ${label} counter is invalid.`);
  }
  return value;
}

function rankedWins(state: PlayerProgressionState): number {
  // Achievement group 2 is advanced only by confirmed ranked PvP settlement. Reusing that
  // server-owned counter avoids maintaining two sources of truth for the same client stat.
  return starterCounter(
    state.achievements?.data.find((group) => group.id === 2)?.value ?? 0,
    "ranked-win",
  );
}

/**
 * Reproduce StarterAssignmentUpgradeWeapon's exact completion source.
 *
 * The client does not count total upgrades across the account. It reads inventorySlots[1],
 * resolves that slot's currently equipped weapon, and compares `weaponLevel` (boughtIndex +
 * 1) with the assignment target. Using the same equipped-slot fact avoids incorrectly
 * completing ID_7 when another weapon was upgraded or when the sniper slot was changed to a
 * lower-level compatible weapon. Legacy players without persisted itemInventory receive the
 * recovered starter loadout before this calculation.
 */
function equippedSecondaryWeaponLevel(state: PlayerProgressionState): number {
  const inventory = state.itemInventory ?? createInitialItemInventory();
  const equipped = inventory.inventoryData.slots["1"];
  if (!equipped) return 0;
  const weapon = inventory.levelManagerData.savedWeapons[equipped.name];
  if (!weapon?.bought) return 0;
  const boughtIndex = starterCounter(weapon.boughtIndex, "equipped-weapon-level");
  if (boughtIndex === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment equipped-weapon-level counter overflowed.");
  }
  return boughtIndex + 1;
}

function isServerConfirmed(
  definition: StarterAssignmentDefinition,
  state: PlayerProgressionState,
  facts: StarterAssignmentFacts,
): boolean {
  switch (definition.authority) {
    case "rankedWins": return rankedWins(state) >= definition.target;
    case "medals": return starterCounter(facts.medalsBalance, "medal") >= definition.target;
    case "level": return starterCounter(facts.level, "level") >= definition.target;
    case "squadPoints": return starterCounter(facts.squadPointsTotal, "squad-point") >= definition.target;
    case "heroicPoints": return starterCounter(
      state.dailyMissions?.heroicPoints ?? 0,
      "heroic-point",
    ) >= definition.target;
    case "weaponLevel": return equippedSecondaryWeaponLevel(state) >= definition.target;
    case "craftedGold": return starterCounter(state.goldCardsCrafted ?? 0, "Gold-card-craft") > 0;
    case "warCardsPlayed": return starterCounter(
      state.warCardsPlayed ?? 0,
      "War-Card-play",
    ) >= definition.target;
    case "unrecovered": return false;
  }
}

/**
 * Accept the client's completion notification only when every requested ID is independently
 * provable from current server state. Validation happens before mutation, preserving the
 * original request's all-or-nothing behavior when Evaluate submits several newly completed
 * IDs together. Already-completed IDs are idempotent retries after a lost HTTP response.
 */
export function completeStarterAssignmentsState(
  state: PlayerProgressionState,
  now: number,
  issuedAt: number,
  facts: StarterAssignmentFacts,
  requestedIds: readonly string[],
): StarterAssignmentMutationResult {
  const starterAssignments = starterAssignmentStateFor(state, issuedAt);
  if (now > starterAssignments.deadline) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignments have expired.");
  }
  if (requestedIds.length < 1 || new Set(requestedIds).size !== requestedIds.length) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment IDs are empty or duplicated.");
  }

  const definitions = requestedIds.map(definitionFor);
  for (const definition of definitions) {
    const existing = starterAssignments.assignments[definition.id];
    if (!existing?.completed && !isServerConfirmed(definition, state, facts)) {
      const reason = definition.authority === "unrecovered"
        ? "does not yet have an authoritative server event"
        : "has not reached its server-owned target";
      throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, `Starter assignment ${definition.id} ${reason}.`);
    }
  }

  for (const definition of definitions) {
    const existing = starterAssignments.assignments[definition.id];
    starterAssignments.assignments[definition.id] = {
      completed: true,
      claimed: existing?.claimed ?? false,
    };
  }
  const changed = definitions.some((definition) => (
    !state.starterAssignments?.assignments[definition.id]?.completed
  ));
  return {
    // CompleteStarterAssignments may be retried directly after the server committed but the
    // response was lost. The recovered protocol has no request UUID, so already-completed IDs
    // are accepted idempotently. Returning the exact state here makes that promise durable: it
    // avoids a second MongoDB replacement while still returning the complete cloned wire model.
    state: changed ? { ...state, revision: state.revision + 1, starterAssignments } : state,
    starterAssignments,
  };
}

/**
 * Claim exactly one completed onboarding reward. Both currency amounts supplied by the old
 * client are treated as assertions, never authority. Enforcing the recovered display order
 * prevents a modified APK from skipping the onboarding chain to a later, larger reward.
 */
export function claimStarterAssignmentState(
  state: PlayerProgressionState,
  now: number,
  assignmentId: string,
  requestedGold: number,
  requestedWarBucks: number,
): StarterAssignmentMutationResult {
  const starterAssignments = starterAssignmentStateFor(state, now);
  const definition = definitionFor(assignmentId);
  const record = starterAssignments.assignments[assignmentId];
  if (now > starterAssignments.deadline || !record?.completed || record.claimed) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment is not completed, is expired, or was claimed.");
  }
  if (requestedGold !== definition.gold || requestedWarBucks !== definition.warBucks) {
    throw new ApiError(STARTER_ASSIGNMENT_REWARD_INCORRECT, "Starter assignment reward does not match server balancing.");
  }

  const firstUnclaimed = STARTER_ASSIGNMENT_DEFINITIONS
    .filter((candidate) => !starterAssignments.assignments[candidate.id]?.claimed)
    .sort((left, right) => left.order - right.order)[0];
  if (firstUnclaimed?.id !== assignmentId) {
    throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Starter assignment rewards must be claimed in order.");
  }

  const gold = checkedRewardBalance(state.gold, definition.gold, "Starter assignment Gold");
  const warBucks = checkedRewardBalance(state.warBucks, definition.warBucks, "Starter assignment WarBucks");
  record.claimed = true;
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold,
      warBucks,
      starterAssignments,
    },
    starterAssignments,
    reward: { gold: definition.gold, warBucks: definition.warBucks },
  };
}

export async function completeStarterAssignments(
  playerId: string,
  requestedIds: readonly string[],
): Promise<StarterAssignmentMutationResult> {
  const player = await findById(playerId);
  if (!player) throw new ApiError(STARTER_ASSIGNMENTS_INCORRECT, "Player was not found.");
  const issuedAt = Math.floor(player.createdAt.getTime() / 1_000);
  const facts: StarterAssignmentFacts = {
    medalsBalance: player.player.medalsBalance,
    level: player.player.level,
    squadPointsTotal: player.player.squadPoints,
  };
  return mutateProgression(playerId, (state, now) =>
    completeStarterAssignmentsState(state, now, issuedAt, facts, requestedIds));
}

export function claimStarterAssignment(
  playerId: string,
  assignmentId: string,
  requestedGold: number,
  requestedWarBucks: number,
): Promise<StarterAssignmentMutationResult> {
  return mutateProgression(playerId, (state, now) =>
    claimStarterAssignmentState(state, now, assignmentId, requestedGold, requestedWarBucks));
}
