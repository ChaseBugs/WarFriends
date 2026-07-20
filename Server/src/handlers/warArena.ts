import { ApiError, ApiErrorCode } from "../apiErrors";
import { players } from "../db";
import { DbAction } from "../dbActions";
import { ok } from "../dtos";
import {
  buyWarArenaHeart,
  claimWarArenaScraps,
  endWarArena,
  enterWarArena,
  markWarArenaShown,
  takeWarArenaLife,
} from "../services/warArenaService";
import { authed, type HandlerEntry } from "./types";

function integer(value: unknown, field: string, fallback?: number): number {
  if ((value === undefined || value === null || value === "") && fallback !== undefined) return fallback;
  const parsed = Number(value);
  if (!Number.isInteger(parsed) || parsed < 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be a non-negative integer.`);
  }
  return parsed;
}

function booleanValue(value: unknown): boolean {
  // System.Boolean.ToString() sends "True"/"False" for HeartDialogShown. Tooling may use
  // normal JSON booleans or 1/0, so normalize only these explicit representations.
  return value === true || value === 1 || value === "1" || value === "True" || value === "true";
}

async function arenaOpponentIds(playerId: string, armyPower: number, limit = 12): Promise<string[]> {
  // The recovered state stores a List<string> and appends the opponent account ID after each
  // Arena battle. The old opponent-selection weights are absent, so the reconstruction uses
  // a bounded nearest-army-power pool while retaining the exact ID list contract.
  const candidates = await players()
    .find({ id: { $ne: playerId } })
    .sort({ updatedAt: -1 })
    .limit(100)
    .toArray();
  return candidates
    .sort((left, right) => Math.abs(left.armyPower - armyPower) - Math.abs(right.armyPower - armyPower))
    .slice(0, limit)
    .map((candidate) => candidate.id);
}

export const warArenaHandlers: Record<number, HandlerEntry> = {
  [DbAction.EnterArena]: authed(async ({ player, req }) => {
    const opponents = await arenaOpponentIds(player!.id, player!.armyPower);
    const result = await enterWarArena(player!.id, {
      // DIENNAGJJOM uses the singular UsedGold key when BuyTicketsDialog pays for entry.
      usedGold: integer(req.UsedGold, "UsedGold", 0),
      opponents,
    });
    return ok(DbAction.EnterArena, { ...result.response, Replayed: result.replayed });
  }),

  [DbAction.BuyArenaHearth]: authed(async ({ player, req }) => {
    const hasGoldFallback = req.UsedGolds !== undefined;
    const result = await buyWarArenaHeart(player!.id, {
      // The stock direct-ticket request misspells "heart" as hearthPrice. The Gold fallback
      // uses the plural UsedGolds. These names are wire compatibility, not normalized API.
      hearthPrice: hasGoldFallback ? undefined : integer(req.hearthPrice, "hearthPrice"),
      usedGold: hasGoldFallback ? integer(req.UsedGolds, "UsedGolds") : undefined,
    });
    return ok(DbAction.BuyArenaHearth, { ...result.response, Replayed: result.replayed });
  }),

  [DbAction.TakeArenaLife]: authed(async ({ player }) => {
    const result = await takeWarArenaLife(player!.id);
    return ok(DbAction.TakeArenaLife, { ...result.response, Replayed: result.replayed });
  }),

  [DbAction.GetScrapsReward]: authed(async ({ player, req }) => {
    const result = await claimWarArenaScraps(player!.id, booleanValue(req.HeartDialogShown));
    return ok(DbAction.GetScrapsReward, { ...result.response, Replayed: result.replayed });
  }),

  [DbAction.WarArenaEnded]: authed(async ({ player, req }) => {
    const arenaId = typeof req.ArenaId === "string" ? req.ArenaId : "";
    const result = await endWarArena(player!.id, arenaId);
    return ok(DbAction.WarArenaEnded, { ...result.response, Replayed: result.replayed });
  }),

  [DbAction.WarArenaShown]: authed(async ({ player, req }) => {
    // FCIGAKGDAHO sends the configured ArenaId and ignores all response fields. Persisting a
    // small Changed flag still helps diagnostics while remaining compatible with that parser.
    const arenaId = typeof req.ArenaId === "string" ? req.ArenaId : "";
    const result = await markWarArenaShown(player!.id, arenaId);
    return ok(DbAction.WarArenaShown, { Changed: result.changed });
  }),
};
