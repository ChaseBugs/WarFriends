import { randomUUID } from "crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { players, type PlayerProgressionState } from "../db";
import { PLAYER_LEAGUE_PLACEMENT_MATCHES } from "./playerLeagueContract";
import { findById } from "./playerService";
import { progressionForPlayer } from "./playerStateService";
import { mutateProgression } from "./progressionMutationService";

/** MainScene Constants.StartingGold, decoded from ObscuredFloat. */
export const TUTORIAL_STARTING_GOLD = 75;
/** MainScene Constants.StartingWarbucks, decoded from ObscuredFloat. */
export const TUTORIAL_STARTING_WARBUCKS = 15_000;

const TUTORIAL_WIN_END_REASON = 2;
const MAX_CONCURRENCY_RETRIES = 4;

export interface TutorialMutationResult {
  state: PlayerProgressionState;
  battleId: string;
  replayed: boolean;
  remainingMatches: number;
}

/**
 * Create or replay the server identity used by action 119.
 *
 * The recovered request sends only the player's display name, which is not battle authority.
 * The server therefore issues its own opaque ID and persists it before returning. Repeating the
 * start request while the bootcamp is active returns the same ID so a lost HTTP response cannot
 * strand the client with a receipt the server no longer recognizes.
 */
export function startTutorialState(
  state: PlayerProgressionState,
  now: number,
  newBattleId: string,
): TutorialMutationResult {
  if (state.tutorialFinished) {
    return { state, battleId: "", replayed: true, remainingMatches: PLAYER_LEAGUE_PLACEMENT_MATCHES };
  }
  if (state.tutorialBattle) {
    return {
      state,
      battleId: state.tutorialBattle.battleId,
      replayed: true,
      remainingMatches: PLAYER_LEAGUE_PLACEMENT_MATCHES,
    };
  }
  if (!newBattleId || newBattleId.length > 128) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Could not issue tutorial battle ID.");
  }
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      tutorialBattle: { battleId: newBattleId, startedAt: Math.max(0, Math.floor(now)) },
    },
    battleId: newBattleId,
    replayed: false,
    remainingMatches: PLAYER_LEAGUE_PLACEMENT_MATCHES,
  };
}

/**
 * Commit the one-time bootcamp completion using only recovered server constants.
 *
 * TutorialEnded echoes score, box counts, cards, Army Power, and the complete client wallet.
 * Those values are gameplay observations from an offline tutorial and are trivially forgeable,
 * so none become authority. Completion establishes the exact 75 Gold / 15,000 WarBucks starting
 * minimum and one placement match decoded from MainScene. `Math.max` preserves any legitimate
 * server-side reward credited before completion, while the terminal flag prevents a replay from
 * refilling currency after the player spends it.
 */
export function finishTutorialState(
  state: PlayerProgressionState,
  battleId: string,
  endReason: number,
  currentRemainingMatches: number,
): TutorialMutationResult {
  if (state.tutorialFinished) {
    return {
      state,
      battleId: state.tutorialBattle?.battleId ?? battleId,
      replayed: true,
      remainingMatches: Math.max(currentRemainingMatches, PLAYER_LEAGUE_PLACEMENT_MATCHES),
    };
  }
  if (endReason !== TUTORIAL_WIN_END_REASON) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Tutorial completion requires the recovered Win end reason.");
  }
  const receipt = state.tutorialBattle;
  if (receipt && battleId !== receipt.battleId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Tutorial battle ID does not match the active receipt.");
  }

  // Accounts that began bootcamp before this receipt implementation can legitimately submit an
  // empty BattleId. Accept that one-time migration only because no rewards beyond the fixed source
  // minimum are client-controlled; all new starts carry and enforce the server-issued receipt.
  if (!receipt && battleId.length > 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Tutorial battle has no matching start receipt.");
  }
  const { tutorialBattle: _battle, ...withoutBattle } = state;
  return {
    state: {
      ...withoutBattle,
      revision: state.revision + 1,
      gold: Math.max(state.gold, TUTORIAL_STARTING_GOLD),
      warBucks: Math.max(state.warBucks, TUTORIAL_STARTING_WARBUCKS),
      tutorialFinished: true,
    },
    battleId: receipt?.battleId ?? "",
    replayed: false,
    remainingMatches: Math.max(currentRemainingMatches, PLAYER_LEAGUE_PLACEMENT_MATCHES),
  };
}

export function startTutorial(playerId: string): Promise<TutorialMutationResult> {
  return mutateProgression(playerId, (state, now) => startTutorialState(state, now, randomUUID()));
}

/** Atomically persist completion, starter currency, and the profile placement counter. */
export async function finishTutorial(
  playerId: string,
  battleId: string,
  endReason: number,
): Promise<TutorialMutationResult> {
  for (let attempt = 0; attempt < MAX_CONCURRENCY_RETRIES; attempt += 1) {
    const player = await findById(playerId);
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    const state = progressionForPlayer(player);
    const result = finishTutorialState(state, battleId, endReason, player.player.remainingMatches);
    const profileNeedsUpdate = player.player.remainingMatches !== result.remainingMatches;
    if (result.state === state && !profileNeedsUpdate) return result;

    const rawRevision = player.progression?.revision;
    const progressionFilter = player.progression
      ? rawRevision === undefined
        ? { "progression.revision": { $exists: false } }
        : { "progression.revision": rawRevision }
      : { progression: { $exists: false } };
    const { dogTags: _legacyDogTags, ...canonicalState } = result.state;
    const update = await players().updateOne(
      { id: playerId, ...progressionFilter },
      {
        $set: {
          progression: canonicalState,
          "player.remainingMatches": result.remainingMatches,
          updatedAt: new Date(),
        },
      },
    );
    if (update.modifiedCount === 1) return { ...result, state: canonicalState };
  }
  throw new ApiError(ApiErrorCode.InternalServerError, "Concurrent tutorial completion could not be committed.");
}
