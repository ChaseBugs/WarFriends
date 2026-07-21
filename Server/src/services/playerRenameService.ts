import { ApiError, ApiErrorCode } from "../apiErrors";
import { players, type PlayerProgressionState } from "../db";
import { findById } from "./playerService";
import { progressionForPlayer } from "./playerStateService";
import {
  SECOND_RENAME_BASE_GOLD_COST,
  renameGoldPrice,
  validatedRenameCount,
} from "./playerRenameAuthorityService";

export {
  SECOND_RENAME_BASE_GOLD_COST,
  renameGoldPrice,
  validatedRenameCount,
} from "./playerRenameAuthorityService";

/** IJEAJGCCHEF.PlayerNameTaken, consumed by the stock rename error dialog. */
export const PLAYER_NAME_TAKEN = 11;
/** IJEAJGCCHEF.NotEnoughGoldForChangeName, which reads RenameCount and PlayerGold. */
export const PLAYER_RENAME_NOT_ENOUGH_GOLD = 11402;

const MAX_CONCURRENCY_RETRIES = 4;

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

/** Calculate and apply only the server-owned currency/count portion of a rename. */
export function applyRenameEconomyState(
  state: PlayerProgressionState,
  renameCount: number,
  payForRename: boolean,
): RenameEconomyResult {
  const previousRenameCount = validatedRenameCount(renameCount);
  const nextRenameCount = validatedRenameCount(previousRenameCount + 1);
  if (!Number.isSafeInteger(state.revision) || state.revision < 0 || state.revision === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rename progression revision is invalid.");
  }
  if (!Number.isSafeInteger(state.gold)) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Rename Gold balance is invalid.");
  }
  const goldSpent = renameGoldPrice(previousRenameCount);
  if (previousRenameCount > 0 && !payForRename) {
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
    previousRenameCount,
    renameCount: nextRenameCount,
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
    const renameCount = validatedRenameCount(rawRenameCount);
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
