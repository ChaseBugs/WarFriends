import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";
import {
  assertTutorialWeaponUpgradeEligible,
  tutorialWeaponUpgradeFunding,
} from "./itemInventoryService";
import { mutateProgression } from "./progressionMutationService";
import {
  assertTutorialUnitUpgradeEligible,
  tutorialUnitUpgradeFunding,
} from "./unitInventoryService";

export type OneTimeRewardTrigger = "direct" | "facebook-link";

export interface OneTimeRewardRule {
  id: string;
  gold: number;
  trigger: OneTimeRewardTrigger;
}

export interface OneTimeRewardGrant {
  id: string;
  gold: number;
  warBucks?: number;
}

/**
 * Source-backed one-time rewards used by action 161 and Facebook account linking.
 *
 * Each ID is the `DBKEY` serialized beside its CodeStage `ObscuredFloat` in the 4.9.5
 * MainScene. The four-byte hidden value is read in Unity memory order, XORed with key 230887,
 * and interpreted as IEEE-754 single precision. That produces exact Gold values 10, 10, 10,
 * and 4. The direct request contains only `RewardId`, so this whitelist and trigger binding are
 * the economy authority: accepting an arbitrary ID/amount, or accepting the login row without a
 * successful Facebook link, would let a modified APK mint currency.
 */
export const ONE_TIME_REWARD_RULES = Object.freeze([
  { id: "FacebookLike", gold: 10, trigger: "direct" },
  { id: "TwitterFollow", gold: 10, trigger: "direct" },
  { id: "FacebookLoginReward", gold: 10, trigger: "facebook-link" },
  { id: "NotificationAllowReward", gold: 4, trigger: "direct" },
] as const satisfies readonly OneTimeRewardRule[]);

export interface OneTimeRewardResult {
  state: PlayerProgressionState;
  reward: OneTimeRewardGrant;
  wasAdded: boolean;
}

/** Build the presence-sensitive object consumed by OGLEHLIPEFM.OOIMBPCOENI. */
export function oneTimeRewardWire(result: OneTimeRewardResult): Record<string, unknown> {
  return {
    RewardId: result.reward.id,
    Gold: result.reward.gold,
    // TutorialManagerStage4/5 reads this optional field and adds it only inside the same
    // presence-sensitive WasAdded branch. Social rewards do not return a zero-valued key.
    ...(result.reward.warBucks !== undefined ? { WarBucks: result.reward.warBucks } : {}),
    // The parser calls ContainsKey rather than reading a Boolean value. Omitting this property
    // is therefore the only correct replay representation; `WasAdded=false` would still pay.
    ...(result.wasAdded ? { WasAdded: true } : {}),
  };
}

export function oneTimeRewardRule(
  rewardId: unknown,
  trigger: OneTimeRewardTrigger = "direct",
): OneTimeRewardRule {
  if (typeof rewardId !== "string" || rewardId.length < 1 || rewardId !== rewardId.trim()) {
    throw new ApiError(ApiErrorCode.UnknownAction, "RewardId is invalid.");
  }
  const rule = ONE_TIME_REWARD_RULES.find((entry) => entry.id === rewardId);
  if (!rule) {
    throw new ApiError(ApiErrorCode.UnknownAction, `One-time reward ${rewardId} is not available.`);
  }
  if (rule.trigger !== trigger) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, `One-time reward ${rewardId} has an invalid trigger.`);
  }
  return rule;
}

function rewardIdString(rewardId: unknown): string {
  if (typeof rewardId !== "string" || rewardId.length < 1 || rewardId !== rewardId.trim()) {
    throw new ApiError(ApiErrorCode.UnknownAction, "RewardId is invalid.");
  }
  return rewardId;
}

/**
 * Resolve tutorial currency exclusively from recovered upgrade catalogs.
 *
 * `Parameter` is supplied by the APK, so both funding helpers require the exact target selected
 * by the corresponding tutorial manager. Eligibility is separated from amount resolution: the
 * first claim checks stored inventory, while a collected replay can still return the original
 * static amount after the upgrade has changed that inventory.
 */
function tutorialReward(
  rewardId: string,
  parameter: unknown,
  checkEligibility: boolean,
  state: PlayerProgressionState,
): OneTimeRewardGrant | undefined {
  if (rewardId === "WeaponTutorial") {
    const funding = tutorialWeaponUpgradeFunding(parameter);
    if (checkEligibility) assertTutorialWeaponUpgradeEligible(state, parameter);
    return { id: rewardId, gold: funding.gold, warBucks: funding.warBucks };
  }
  if (rewardId === "UnitTutorial") {
    const funding = tutorialUnitUpgradeFunding(parameter);
    if (checkEligibility) assertTutorialUnitUpgradeEligible(state, parameter);
    return { id: rewardId, gold: funding.gold, warBucks: funding.warBucks };
  }
  return undefined;
}

/**
 * Apply one reward to a progression snapshot without mutating the caller's objects.
 *
 * The recovered response parser always records `RewardId` locally, but adds currency only when
 * the response contains the presence-only `WasAdded` field. A replay therefore returns the same
 * source Gold value with `wasAdded=false`; the handler omits `WasAdded`, keeping the stock wallet
 * unchanged. Concurrent requests are safe because `mutateProgression` re-runs this transition
 * after a revision collision and the second attempt observes the first marker.
 */
export function applyOneTimeRewardState(
  state: PlayerProgressionState,
  rewardId: unknown,
  trigger: OneTimeRewardTrigger = "direct",
  parameter?: unknown,
): OneTimeRewardResult {
  const id = rewardIdString(rewardId);
  const collectedRewards = state.collectedRewards ?? {};
  const collected = collectedRewards[id] === 1;

  // Tutorial rewards are direct action-161 requests only. Keeping the trigger check here makes
  // it impossible for a future identity-provider path to grant onboarding currency by accident.
  if ((id === "WeaponTutorial" || id === "UnitTutorial") && trigger !== "direct") {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, `One-time reward ${id} has an invalid trigger.`);
  }
  const tutorial = tutorialReward(id, parameter, !collected, state);
  const rule = tutorial ? undefined : oneTimeRewardRule(id, trigger);
  const reward: OneTimeRewardGrant = tutorial ?? { id: rule!.id, gold: rule!.gold };
  if (collected) {
    return { state, reward, wasAdded: false };
  }

  const gold = state.gold + reward.gold;
  const warBucks = state.warBucks + (reward.warBucks ?? 0);
  if (!Number.isSafeInteger(gold) || !Number.isSafeInteger(warBucks)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "One-time reward currency overflowed.");
  }
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold,
      warBucks,
      collectedRewards: { ...collectedRewards, [reward.id]: 1 },
    },
    reward,
    wasAdded: true,
  };
}

export function claimOneTimeReward(
  playerId: string,
  rewardId: unknown,
  trigger: OneTimeRewardTrigger = "direct",
  parameter?: unknown,
): Promise<OneTimeRewardResult> {
  return mutateProgression(
    playerId,
    (state) => applyOneTimeRewardState(state, rewardId, trigger, parameter),
  );
}
