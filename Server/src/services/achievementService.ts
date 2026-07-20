import { ApiError } from "../apiErrors";
import type {
  AchievementGroupState,
  AchievementState,
  PlayerProgressionState,
} from "../db";
import { itemInventoryStateFor, weaponDefinitionFor } from "./itemInventoryService";
import { mutateProgression } from "./progressionMutationService";
import { UNIT_CATALOG } from "./unitInventoryService";
import { VISUAL_CATALOG, visualInventoryStateFor } from "./visualInventoryService";

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
 * Achievement rows whose progress can currently be proven by reconstructed server events or
 * directly from server-owned inventory.
 *
 * These values are copied from the Achievements component serialized in MainScene.unity:
 * groups 0/1 are purchased units/weapons, 8 is confirmed War Cards played, 9/10 are
 * soldier/mechanical normal upgrades, 11 is weapon upgrades, and 15 is paid permanent visuals.
 * Group 2 is ranked PvP wins, 3/4 are accepted Arena wins/flawless runs, 5 is completed solo
 * missions, 12 is completed assignments, 14 is lifetime squad points, and 16 is claimed daily
 * rewards. Combat-detail-only rows remain intentionally disabled until their event facts are
 * authoritative; a client-reported achievement value is never enough to enable one.
 */
export const ACHIEVEMENT_DEFINITIONS: Readonly<Record<number, readonly AchievementTierDefinition[]>> = {
  0: [
    { target: 8, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 16, gold: 10, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 24, gold: 15, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  1: [
    { target: 5, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 10, gold: 10, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 15, gold: 15, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  2: [
    { target: 10, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 50, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 100, gold: 10, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  3: [
    { target: 2, gold: 0, warBucks: 0, scraps: 0, tickets: 5 },
    { target: 10, gold: 0, warBucks: 0, scraps: 0, tickets: 15 },
    { target: 100, gold: 0, warBucks: 0, scraps: 0, tickets: 50 },
  ],
  4: [
    { target: 1, gold: 0, warBucks: 0, scraps: 50, tickets: 0 },
    { target: 3, gold: 0, warBucks: 0, scraps: 150, tickets: 0 },
    { target: 10, gold: 0, warBucks: 0, scraps: 250, tickets: 0 },
  ],
  5: [
    { target: 10, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 30, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 60, gold: 10, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  8: [
    { target: 5, gold: 0, warBucks: 2_500, scraps: 0, tickets: 0 },
    { target: 50, gold: 0, warBucks: 25_000, scraps: 0, tickets: 0 },
    { target: 500, gold: 0, warBucks: 250_000, scraps: 0, tickets: 0 },
  ],
  9: [
    { target: 10, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 25, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 100, gold: 25, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  10: [
    { target: 1, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 10, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 50, gold: 25, warBucks: 0, scraps: 0, tickets: 0 },
  ],
  11: [
    { target: 15, gold: 1, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 150, gold: 5, warBucks: 0, scraps: 0, tickets: 0 },
    { target: 300, gold: 25, warBucks: 0, scraps: 0, tickets: 0 },
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
  15: [
    { target: 7, gold: 0, warBucks: 5_000, scraps: 0, tickets: 0 },
    { target: 14, gold: 0, warBucks: 50_000, scraps: 0, tickets: 0 },
    { target: 29, gold: 0, warBucks: 500_000, scraps: 0, tickets: 0 },
  ],
  16: [
    { target: 7, gold: 0, warBucks: 5_000, scraps: 0, tickets: 0 },
    { target: 30, gold: 0, warBucks: 25_000, scraps: 0, tickets: 0 },
    { target: 100, gold: 0, warBucks: 100_000, scraps: 0, tickets: 0 },
  ],
};

/**
 * Reproduce the inventory-backed StatsManager properties read by the six recovered classes.
 *
 * Purchases count only rows whose display unlock level is above three, exactly matching
 * `StatsManager.weaponsPurchased` and `unitsPurchased`; this excludes the starter loadout and
 * tutorial Assaulter. Upgrade counters are sums of the stored normal `boughtIndex`, not events,
 * special slots, promotions, or Elite parts. Visuals exclude power bands and require a permanent
 * bought row with a non-zero source shop price. Borrowed rentals are deliberately excluded from
 * every count because they are temporary entitlements and must not unlock permanent rewards.
 */
function snapshotAchievementValues(state: PlayerProgressionState): Readonly<Record<number, number>> {
  const itemInventory = itemInventoryStateFor(state);
  let unitsPurchased = 0;
  let weaponsPurchased = 0;
  let soldierUpgrades = 0;
  let mechanicalUpgrades = 0;
  let weaponUpgrades = 0;

  for (const [name, weapon] of Object.entries(itemInventory.levelManagerData.savedWeapons)) {
    const definition = weaponDefinitionFor(name);
    if (!definition || !weapon.bought || weapon.borrowed) continue;
    if (definition.unlockLevel > 3) weaponsPurchased += 1;
    weaponUpgrades += Math.max(0, weapon.boughtIndex);
  }
  for (const [name, unit] of Object.entries(itemInventory.levelManagerData.savedArmies)) {
    const definition = UNIT_CATALOG[name];
    if (!definition || !unit.bought || unit.borrowed) continue;
    if (definition.unlockLevel > 3) unitsPurchased += 1;
    if (definition.isSoldier) soldierUpgrades += Math.max(0, unit.boughtIndex);
    else mechanicalUpgrades += Math.max(0, unit.boughtIndex);
  }

  const visuals = visualInventoryStateFor(state).visuals;
  const paidVisuals = Object.entries(visuals).filter(([name, saved]) => {
    const definition = VISUAL_CATALOG[name];
    return Boolean(
      definition
      && definition.categoryId !== 3
      && definition.priceGold + definition.priceWarBucks > 0
      && saved.bought
      && !saved.borrowed,
    );
  }).length;
  return {
    0: unitsPurchased,
    1: weaponsPurchased,
    // PvP settlement increments this only by cards it successfully validates and consumes.
    // It is therefore the server equivalent of StatsManager.cardsPlayed, not client telemetry.
    8: Math.max(0, state.warCardsPlayed ?? 0),
    9: soldierUpgrades,
    10: mechanicalUpgrades,
    11: weaponUpgrades,
    15: paidVisuals,
  };
}

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
  // Inventory is already the authority for these counters. Re-deriving them on every read and
  // buffered achievement action also migrates older accounts without trusting a client offset or
  // requiring historical purchase events that predate this server implementation.
  for (const [rawId, value] of Object.entries(snapshotAchievementValues(state))) {
    const id = Number(rawId);
    const group = byId.get(id);
    const tiers = ACHIEVEMENT_DEFINITIONS[id];
    if (group && tiers) group.value = Math.min(tiers[tiers.length - 1].target, value);
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
