import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";
import { mutateProgression } from "./progressionMutationService";

export interface OneTimeRewardRule {
  id: string;
  gold: number;
  trigger: "direct" | "facebook-link";
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
  reward: OneTimeRewardRule;
  wasAdded: boolean;
}

/** Build the presence-sensitive object consumed by OGLEHLIPEFM.OOIMBPCOENI. */
export function oneTimeRewardWire(result: OneTimeRewardResult): Record<string, unknown> {
  return {
    RewardId: result.reward.id,
    Gold: result.reward.gold,
    // The parser calls ContainsKey rather than reading a Boolean value. Omitting this property
    // is therefore the only correct replay representation; `WasAdded=false` would still pay.
    ...(result.wasAdded ? { WasAdded: true } : {}),
  };
}

export function oneTimeRewardRule(
  rewardId: unknown,
  trigger: OneTimeRewardRule["trigger"] = "direct",
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
  trigger: OneTimeRewardRule["trigger"] = "direct",
): OneTimeRewardResult {
  const reward = oneTimeRewardRule(rewardId, trigger);
  const collectedRewards = state.collectedRewards ?? {};
  if (collectedRewards[reward.id] === 1) {
    return { state, reward, wasAdded: false };
  }

  const gold = state.gold + reward.gold;
  if (!Number.isSafeInteger(gold)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "One-time reward Gold overflowed.");
  }
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold,
      collectedRewards: { ...collectedRewards, [reward.id]: 1 },
    },
    reward,
    wasAdded: true,
  };
}

export function claimOneTimeReward(
  playerId: string,
  rewardId: unknown,
  trigger: OneTimeRewardRule["trigger"] = "direct",
): Promise<OneTimeRewardResult> {
  return mutateProgression(playerId, (state) => applyOneTimeRewardState(state, rewardId, trigger));
}
