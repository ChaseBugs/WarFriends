import { ApiError, ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  buildDailyRewardWireData,
  checkDailyReward,
  claimDailyReward,
} from "../services/dailyRewardService";
import { unixNow } from "../services/playerStateService";
import { authed, type HandlerEntry } from "./types";

function requestedRewardDay(value: unknown): number {
  // `claimRweard` is the original client's misspelled form key and therefore part of the
  // protocol. Accepting a corrected alias helps tools, but the server never infers a day.
  const parsed = Number(value);
  if (!Number.isInteger(parsed) || parsed < 1 || parsed > 31) {
    throw new ApiError(ApiErrorCode.DailyRewardWrongIndex, "Invalid daily reward index.");
  }
  return parsed;
}

export const dailyRewardHandlers: Record<number, HandlerEntry> = {
  [DbAction.CheckDailyReward]: authed(async ({ player }) => {
    const result = await checkDailyReward(player!.id);
    return ok(DbAction.CheckDailyReward, {
      dailyRewardData: buildDailyRewardWireData(result.calendar, unixNow()),
    });
  }),

  [DbAction.ClaimDailyReward]: authed(async ({ player, req }) => {
    const day = requestedRewardDay(req.claimRweard ?? req.claimReward);
    const result = await claimDailyReward(player!.id, day);
    return ok(DbAction.ClaimDailyReward, {
      dailyRewardData: {
        ...buildDailyRewardWireData(result.calendar, unixNow()),
        // IJEAJGCCHEF.Success is 1. DailyRewardDataLoaded calls ParseReward only on this value.
        ok: 1,
        // ParseReward expects MDNLFMNBNEG.Gold (1) and reads the credited delta from `added`.
        addedType: 1,
        added: result.goldAdded,
      },
    });
  }),
};
