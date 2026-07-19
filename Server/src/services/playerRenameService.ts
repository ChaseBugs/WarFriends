import { ApiError, ApiErrorCode } from "../apiErrors";
import { players, type PlayerProgressionState } from "../db";
import { findById } from "./playerService";
import { progressionForPlayer } from "./playerStateService";

/** IJEAJGCCHEF.PlayerNameTaken, consumed by the stock rename error dialog. */
export const PLAYER_NAME_TAKEN = 11;
/** IJEAJGCCHEF.NotEnoughGoldForChangeName, which reads RenameCount and PlayerGold. */
export const PLAYER_RENAME_NOT_ENOUGH_GOLD = 11402;

/**
 * Exact 4.9.5 `SecondRenameGoldCost` Constants value.
 *
 * MainScene serializes the CodeStage ObscuredFloat as hidden bytes `e7858340` with key
 * 230887. Reading the bytes as little-endian and XORing the key yields IEEE-754 value 4.
 */
export const SECOND_RENAME_BASE_GOLD_COST = 4;

const MAX_CONCURRENCY_RETRIES = 4;
const MAX_POSITIVE_STOCK_RENAME_COUNT = 29;

export interface RenameEconomyResult {
  state: PlayerProgressionState;
  previousRenameCount: number;
  renameCount: number;
  goldSpent: number;
}

export interface RenamePlayerResult extends RenameEconomyResult {
  name: string;
  payForRename: boolean;
}

/**
 * Reproduce PlayerAnalytics.renameGoldPrice without reproducing its 32-bit overflow bug.
 *
 * The first rename is free because renameCount is zero. Every later price doubles from four
 * Gold: count 1 costs 4, count 2 costs 8, and so on. Unity's signed shift becomes negative
 * and then zero at extreme counts; the server rejects that unreachable overflow region rather
 * than allowing a long-lived or modified account to obtain free renames.
 */
export function renameGoldPrice(renameCount: number): number {
  if (!Number.isInteger(renameCount) || renameCount < 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, "RenameCount is invalid.");
  }
  if (renameCount === 0) return 0;
  if (renameCount > MAX_POSITIVE_STOCK_RENAME_COUNT) {
    throw new ApiError(ApiErrorCode.UnknownAction, "The stock rename price has exceeded its safe range.");
  }
  return SECOND_RENAME_BASE_GOLD_COST * (2 ** (renameCount - 1));
}

/** Calculate and apply only the server-owned currency/count portion of a rename. */
export function applyRenameEconomyState(
  state: PlayerProgressionState,
  renameCount: number,
  payForRename: boolean,
): RenameEconomyResult {
  const goldSpent = renameGoldPrice(renameCount);
  if (renameCount > 0 && !payForRename) {
    // GameLoginManager may request a free platform-name sync only before any rename. Once the
    // free rename is consumed, the explicit RenameDialog confirmation flag is mandatory.
    throw new ApiError(ApiErrorCode.UnknownAction, "PayForRename is required after the free rename.");
  }
  if (state.gold < goldSpent) {
    throw new ApiError(PLAYER_RENAME_NOT_ENOUGH_GOLD, "Not enough Gold to change the player name.");
  }
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      gold: state.gold - goldSpent,
    },
    previousRenameCount: renameCount,
    renameCount: renameCount + 1,
    goldSpent,
  };
}

function progressionRevisionFilter(progression: PlayerProgressionState | undefined): Record<string, unknown> {
  if (!progression) return { progression: { $exists: false } };
  if (progression.revision === undefined) return { "progression.revision": { $exists: false } };
  return { "progression.revision": progression.revision };
}

function renameCountFilter(renameCount: number | undefined): Record<string, unknown> {
  return renameCount === undefined
    ? { "player.renameCount": { $exists: false } }
    : { "player.renameCount": renameCount };
}

/**
 * Atomically reserve a unique public name, debit Gold, and advance RenameCount.
 *
 * All mutable values live in one player document, so one revision-guarded MongoDB update is a
 * stronger and cheaper boundary than a multi-document transaction. The unique sparse
 * `normalizedAccountName` index decides concurrent name races. A losing economy revision
 * reloads and recalculates the price; it can never commit a name with an older Gold balance.
 */
export async function renamePlayer(
  playerId: string,
  name: string,
  payForRename: boolean,
): Promise<RenamePlayerResult> {
  for (let attempt = 0; attempt < MAX_CONCURRENCY_RETRIES; attempt += 1) {
    const player = await findById(playerId);
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    if (player.player.accountName === name) {
      throw new ApiError(ApiErrorCode.UnknownAction, "The new player name matches the current name.");
    }

    const rawRenameCount = player.player.renameCount;
    const renameCount = rawRenameCount ?? 0;
    const economy = applyRenameEconomyState(
      progressionForPlayer(player),
      renameCount,
      payForRename,
    );
    const { dogTags: _legacyDogTags, ...canonicalState } = economy.state;
    const normalizedAccountName = name.toLocaleLowerCase("en-US");

    try {
      const update = await players().updateOne(
        {
          id: playerId,
          ...progressionRevisionFilter(player.progression),
          ...renameCountFilter(rawRenameCount),
        },
        {
          $set: {
            progression: canonicalState,
            accountName: name,
            normalizedAccountName,
            "player.accountName": name,
            "player.renameCount": economy.renameCount,
            updatedAt: new Date(),
          },
        },
      );
      if (update.modifiedCount === 1) {
        return { ...economy, state: canonicalState, name, payForRename };
      }
    } catch (error) {
      if ((error as { code?: number }).code === 11000) {
        throw new ApiError(PLAYER_NAME_TAKEN, "Player name is already in use.");
      }
      throw error;
    }
  }

  throw new ApiError(ApiErrorCode.InternalServerError, "Concurrent rename could not be completed.");
}
