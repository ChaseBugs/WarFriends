import { ApiError } from "../apiErrors";
import type {
  AchievementGroupState,
  AchievementState,
  PlayerProgressionState,
} from "../db";
import { mutateProgression } from "./progressionMutationService";

/**
 * Server-authoritative achievement progression.
 *
 * The recovered client stores four values for each achievement group: the lifetime value,
 * the already-claimed tier index, a UI acknowledgement offset, and the currently displayed
 * progress. Only the lifetime value and reward claim affect the economy. Those values are
 * advanced from backend-observed events such as a settled PvP match or a claimed daily
 * reward; the client's buffered progress message is treated only as a consistency check.
 *
 * Every `*State` function below is a pure transition over `PlayerProgressionState`. The
 * exported database wrappers run that transition through `mutateProgression`, so concurrent
 * rewards cannot overwrite one another and a failed validation never partially credits a
 * currency balance.
 */

// Exact errors recovered from IJEAJGCCHEF.cs. The stock RequestBuffer parser has dedicated
// UI/relogin handling for these two ClaimAchievement failures.
export const ACHIEVEMENT_ALREADY_CLAIMED = 21800;
export const ACHIEVEMENT_REWARD_NOT_FOUND = 21801;

export interface AchievementTierDefinition {
  target: number;
  gold: number;
  warBucks: number;
  scraps: number;
  tickets: number;
}

/**
 * Achievement rows whose progress can currently be proven by reconstructed server events.
 *
 * These values are copied from the Achievements component serialized in MainScene.unity:
 * group 2 is ranked PvP wins, 5 is completed solo missions, 12 is completed assignments,
 * 14 is lifetime squad points, and 16 is claimed daily rewards. The other client rows are
 * intentionally not invented or trusted yet because unit deployment, inventory ownership,
 * arena, and war-card telemetry do not have authoritative server implementations in this
 * reconstruction.
 */
export const ACHIEVEMENT_DEFINITIONS: Readonly<Record<number, readonly AchievementTierDefinition[]>> = {
  2: [
    { target: 10, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 50, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 100, gold: 10, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  5: [
    { target: 10, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 30, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 60, gold: 10, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  12: [
    { target: 3, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 20, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 100, gold: 30, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  14: [
    { target: 15, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 150, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 1_500, gold: 25, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  16: [
    { target: 7, gold: 0, warBucks: 5_000, scraps: 0, tickets: 0 },
    { target: 30, gold: 0, warBucks: 25_000, scraps: 0, tickets: 0 },
    { target: 100, gold: 0, warBucks: 100_000, scraps: 0, tickets: 0 },
  ],
};

export interface AchievementMutationResult {
  state: PlayerProgressionState;
  achievements: AchievementState;
  reward?: AchievementTierDefinition;
}

function cloneGroup(group: AchievementGroupState): AchievementGroupState {
  return {
    ...group,
    progress: group.progress.map((tier) => ({ ...tier })),
  };
}

/**
 * Materialize every server-supported group without deleting future/legacy groups.
 *
 * AchievementProgressGroups.EnsureInitialized merges server rows with the local scene
 * definitions and extends short progress arrays. Mirroring that behavior here makes schema
 * upgrades safe: adding a newly authoritative group or tier preserves every existing claim.
 */
export function achievementStateFor(state: PlayerProgressionState): AchievementState {
  const byId = new Map((state.achievements?.data ?? []).map((group) => [group.id, cloneGroup(group)]));
  for (const [rawId, tiers] of Object.entries(ACHIEVEMENT_DEFINITIONS)) {
    const id = Number(rawId);
    const existing = byId.get(id);
    if (!existing) {
      byId.set(id, {
        id,
        offset: 0,
        value: 0,
        progress: tiers.map(() => ({ claimed: false })),
      });
      continue;
    }
    while (existing.progress.length < tiers.length) existing.progress.push({ claimed: false });
  }
  return { data: [...byId.values()].sort((left, right) => left.id - right.id) };
}

export function serializeAchievementsData(achievements: AchievementState): string {
  // The outer property must be `data`; this is the JsonProperty on the client's nested
  // AchievementsData class. Group fields already use their recovered JsonProperty names.
  return JSON.stringify(achievements);
}

/**
 * Advance a monotonic achievement counter from a fact already accepted by the server.
 * Values are capped at the final configured tier because the client applies the same clamp
 * in AchievementProgressGroup.SetLocalCurrentValue and no later reward depends on overflow.
 */
export function advanceAchievementState(
  state: PlayerProgressionState,
  groupId: number,
  amount: number,
): AchievementMutationResult {
  const definitions = ACHIEVEMENT_DEFINITIONS[groupId];
  if (!definitions) return { state, achievements: achievementStateFor(state) };
  if (!Number.isInteger(amount) || amount < 0) {
    throw new ApiError(ACHIEVEMENT_REWARD_NOT_FOUND, "Achievement progress increment is invalid.");
  }

  const achievements = achievementStateFor(state);
  const group = achievements.data.find((candidate) => candidate.id === groupId)!;
  const finalTarget = definitions[definitions.length - 1].target;
  group.value = Math.min(finalTarget, group.value + amount);
  return {
    state: { ...state, revision: state.revision + 1, achievements },
    achievements,
  };
}

/**
 * Validate the client's buffered ChangeAchievementProgres request without using it as an
 * authority. Honest clients calculate the same value from their local StatsManager after
 * the corresponding server event. A larger submitted value is rejected because accepting
 * it would let a modified APK unlock reward tiers without playing.
 */
export function validateAchievementProgressState(
  state: PlayerProgressionState,
  groupId: number,
  requestedProgress: number,
): AchievementMutationResult {
  const achievements = achievementStateFor(state);
  const group = achievements.data.find((candidate) => candidate.id === groupId);
  if (!group || !Number.isInteger(requestedProgress) || requestedProgress < 0 || requestedProgress > group.value) {
    throw new ApiError(ACHIEVEMENT_REWARD_NOT_FOUND, "Achievement progress is not confirmed by the server.");
  }
  return {
    state: { ...state, revision: state.revision + 1, achievements },
    achievements,
  };
}

/**
 * Acknowledge the client's one-time local offset calculation while retaining a zero server
 * offset. Offsets exist to translate pre-achievement local statistics; allowing a client to
 * store an arbitrary offset would make later client-supplied progress authoritative. The
 * rebuilt backend starts counters at account creation, so zero is the only safe server value.
 */
export function acknowledgeAchievementOffsetState(
  state: PlayerProgressionState,
  groupId: number,
  requestedOffset: number,
): AchievementMutationResult {
  const achievements = achievementStateFor(state);
  const group = achievements.data.find((candidate) => candidate.id === groupId);
  if (!group || !Number.isInteger(requestedOffset)) {
    throw new ApiError(ACHIEVEMENT_REWARD_NOT_FOUND, "Achievement offset is invalid.");
  }
  group.offset = 0;
  return {
    state: { ...state, revision: state.revision + 1, achievements },
    achievements,
  };
}

/**
 * Claim the first completed, unclaimed tier and credit its recovered reward atomically.
 * The client sends only group Id and zero-based ProgressId; reward amounts never come from
 * the request, so an altered APK cannot choose a currency or amount.
 */
export function claimAchievementState(
  state: PlayerProgressionState,
  groupId: number,
  progressId: number,
): AchievementMutationResult {
  const definitions = ACHIEVEMENT_DEFINITIONS[groupId];
  const achievements = achievementStateFor(state);
  const group = achievements.data.find((candidate) => candidate.id === groupId);
  const definition = definitions?.[progressId];
  if (!group || !definition || !Number.isInteger(progressId)) {
    throw new ApiError(ACHIEVEMENT_REWARD_NOT_FOUND, "Achievement reward was not found.");
  }
  if (group.progress[progressId]?.claimed) {
    throw new ApiError(ACHIEVEMENT_ALREADY_CLAIMED, "Achievement reward was already claimed.");
  }

  const firstUnclaimed = group.progress.findIndex((tier) => !tier.claimed);
  if (firstUnclaimed !== progressId || group.value < definition.target) {
    throw new ApiError(ACHIEVEMENT_REWARD_NOT_FOUND, "Achievement tier is not completed.");
  }

  group.progress[progressId].claimed = true;
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold: state.gold + definition.gold,
      warBucks: state.warBucks + definition.warBucks,
      scraps: state.scraps + definition.scraps,
      tickets: state.tickets + definition.tickets,
      achievements,
    },
    achievements,
    reward: definition,
  };
}

export function advanceAchievement(playerId: string, groupId: number, amount: number): Promise<AchievementMutationResult> {
  return mutateProgression(playerId, (state) => advanceAchievementState(state, groupId, amount));
}

/** Apply the two achievement facts produced by authoritative ranked PvP settlement. */
export function recordRankedPvpAchievements(
  playerId: string,
  won: boolean,
  squadPointsAwarded: number,
): Promise<AchievementMutationResult> {
  return mutateProgression(playerId, (state) => {
    let result: AchievementMutationResult = { state, achievements: achievementStateFor(state) };
    if (won) result = advanceAchievementState(result.state, 2, 1);
    if (squadPointsAwarded > 0) result = advanceAchievementState(result.state, 14, squadPointsAwarded);

    // A loss by a player without a squad still materializes the recovered achievement shape
    // so subsequent boot responses have a stable AchievementsData object.
    if (result.state === state) {
      const achievements = achievementStateFor(state);
      result = {
        state: { ...state, revision: state.revision + 1, achievements },
        achievements,
      };
    }
    return result;
  });
}
