import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  grantVideoAdReward,
  VideoAdRewardKind,
} from "../services/videoAdRewardService";
import { authed, type HandlerEntry } from "./types";

/**
 * Parse the enum integer emitted by `BeanstalkServerManager.AHOMAGJIGKM` as `num.ToString()`.
 * Replacement JSON clients may send the same integer as a number, but JavaScript coercions such
 * as `true`, `[1]`, `"+1"`, or `"1e0"` must not select a reward-bearing branch.
 */
export function requestedVideoAdRewardKind(value: unknown): VideoAdRewardKind {
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  if (
    !Number.isInteger(parsed)
    || (
    parsed !== VideoAdRewardKind.RandomCard
    && parsed !== VideoAdRewardKind.Dogtag
    && parsed !== VideoAdRewardKind.GoldenSuitcase
    && parsed !== VideoAdRewardKind.LootBox
    )
  ) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Reward must identify a supported video ad prize.");
  }
  return parsed;
}

export const videoAdHandlers: Record<number, HandlerEntry> = {
  [DbAction.AddVideoReward]: authed(async ({ player, req }) => {
    // BeanstalkServerManager.AHOMAGJIGKM also sends DogTagRefillTime and DogTagCap. They are
    // compatibility echoes from the phone, not authority. The service derives timing, caps,
    // reward contents, and rolling limits solely from server state and recovered constants.
    const result = await grantVideoAdReward(
      player!.id,
      player!.player.level,
      requestedVideoAdRewardKind(req.Reward),
    );
    return ok(DbAction.AddVideoReward, result.response);
  }),
};
