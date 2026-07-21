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
import { validatedPlayerProfileMirrors } from "../services/playerProfileMirrorAuthorityService";

/**
 * Parse the nonnegative integer text emitted by the recovered Arena callers' `ToString()` calls.
 * Replacement JSON clients may send the same integer as a number. `Number(value)` is deliberately
 * avoided because null, booleans, singleton arrays, blanks, and exponent text can otherwise become
 * a believable ticket or Gold assertion before the service compares it with server-owned policy.
 */
export function requestedArenaInteger(value: unknown, field: string, fallback?: number): number {
  if (value === undefined && fallback !== undefined) return fallback;
  const parsed = typeof value === "number"
    ? value
    : typeof value === "string" && /^(?:0|[1-9]\d*)$/.test(value)
      ? Number(value)
      : Number.NaN;
  if (!Number.isSafeInteger(parsed) || parsed < 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, `${field} must be a non-negative integer.`);
  }
  return parsed;
}

/** Parse the exact Boolean.ToString transport, plus the corresponding JSON Boolean type. */
export function requestedHeartDialogShown(value: unknown): boolean {
  if (value === true || value === "True") return true;
  if (value === false || value === "False") return false;
  throw new ApiError(ApiErrorCode.UnknownAction, "HeartDialogShown must be a Boolean.");
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
  // Arena matching consumes only public ID and Army Power, not private account credentials. Prove
  // their duplicated profile authority without coupling opponent availability to private fields.
  for (const candidate of candidates) validatedPlayerProfileMirrors(candidate);
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
      usedGold: requestedArenaInteger(req.UsedGold, "UsedGold", 0),
      opponents,
    });
    return ok(DbAction.EnterArena, { ...result.response, Replayed: result.replayed });
  }),

  [DbAction.BuyArenaHearth]: authed(async ({ player, req }) => {
    const hasGoldFallback = req.UsedGolds !== undefined;
    const result = await buyWarArenaHeart(player!.id, {
      // The stock direct-ticket request misspells "heart" as hearthPrice. The Gold fallback
      // uses the plural UsedGolds. These names are wire compatibility, not normalized API.
      hearthPrice: hasGoldFallback ? undefined : requestedArenaInteger(req.hearthPrice, "hearthPrice"),
      usedGold: hasGoldFallback ? requestedArenaInteger(req.UsedGolds, "UsedGolds") : undefined,
    });
    return ok(DbAction.BuyArenaHearth, { ...result.response, Replayed: result.replayed });
  }),

  [DbAction.TakeArenaLife]: authed(async ({ player }) => {
    const result = await takeWarArenaLife(player!.id);
    return ok(DbAction.TakeArenaLife, { ...result.response, Replayed: result.replayed });
  }),

  [DbAction.GetScrapsReward]: authed(async ({ player, req }) => {
    const result = await claimWarArenaScraps(player!.id, requestedHeartDialogShown(req.HeartDialogShown));
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
