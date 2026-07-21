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

export function requestedRewardDay(value: unknown): number {
  // `claimRweard` is the original client's misspelled form key and therefore part of the
  // protocol. BeanstalkServerManager serializes its int through ToString; replacement JSON clients
  // may send the same value as a number. Do not let Number() turn null, booleans, arrays, padded
  // text, or alternate number syntax into a reward-bearing calendar index.
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:[1-9]|[12]\d|3[01])$/.test(value)
      ? Number(value)
      : Number.NaN;
  if (!Number.isInteger(parsed) || parsed < 1 || parsed > 31) {
    throw new ApiError(ApiErrorCode.DailyRewardWrongIndex, "Invalid daily reward index.");
  }
  return parsed;
}

/**
 * Resolve the stock typo or the replacement-client spelling without property precedence.
 *
 * `claimRweard` is source truth. `claimReward` is retained only for repaired JSON clients. If both
 * are present, even with equal values, the request has two descriptions of the reward cursor and
 * must fail before the ordered calendar claim transaction chooses one.
 */
export function requestedRewardDayFromRequest(req: Record<string, unknown>): number {
  const fields = ["claimRweard", "claimReward"].filter((field) => req[field] !== undefined);
  if (fields.length !== 1) {
    throw new ApiError(ApiErrorCode.DailyRewardWrongIndex, "Daily reward index field is invalid.");
  }
  return requestedRewardDay(req[fields[0]]);
}

export const dailyRewardHandlers: Record<number, HandlerEntry> = {
  [DbAction.CheckDailyReward]: authed(async ({ player }) => {
    const result = await checkDailyReward(player!.id);
    return ok(DbAction.CheckDailyReward, {
      dailyRewardData: buildDailyRewardWireData(result.calendar, unixNow()),
    });
  }),

  [DbAction.ClaimDailyReward]: authed(async ({ player, req }) => {
    const day = requestedRewardDayFromRequest(req);
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
