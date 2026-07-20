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
    const result = await claimDailyReward(player!.id, day, player!.player.level);
    return ok(DbAction.ClaimDailyReward, {
      dailyRewardData: {
        ...buildDailyRewardWireData(result.calendar, unixNow()),
        // IJEAJGCCHEF.Success is 1. DailyRewardDataLoaded calls ParseReward only on this value.
        ok: 1,
        // ParseReward switches on this exact MDNLFMNBNEG value. Currency rewards use an
        // integer `added`; card rewards use `{ count, cards }` with semicolon-delimited IDs.
        addedType: result.addedType,
        added: result.added,
        ...(result.vipDailyCardReward ? {
          // DailyRewardManager.ParseReward receives this nested object, queues NGGINCOPKKJ,
          // and invokes AddCard for both IDs. Keeping the fields beside `added` matches that
          // exact parser surface; placing them on the outer action response would be ignored.
          VipReward1: result.vipDailyCardReward.cardIds[0],
          VipReward2: result.vipDailyCardReward.cardIds[1],
          VipRewardForDay: result.vipDailyCardReward.dayKey,
        } : {}),
      },
    });
  }),
};
