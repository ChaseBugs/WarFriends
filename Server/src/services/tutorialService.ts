import { randomUUID } from "crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import { players, type PlayerProgressionState } from "../db";
import {
  PLAYER_LEAGUE_PLACEMENT_MATCHES,
  validatedPlayerLeagueRemainingMatches,
} from "./playerLeagueContract";
import { findById } from "./playerService";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import { mutateProgression } from "./progressionMutationService";
import { checkedRewardBalance } from "./rewardMathService";
import {
  validatedTutorialBattleId,
  validatedTutorialLifecycle,
  validatedTutorialRevision,
} from "./tutorialCompletionAuthorityService";

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
  const lifecycle = validatedTutorialLifecycle(state, now);
  if (lifecycle.tutorialFinished) {
    return { state, battleId: "", replayed: true, remainingMatches: PLAYER_LEAGUE_PLACEMENT_MATCHES };
  }
  if (lifecycle.tutorialBattle) {
    return {
      state,
      battleId: lifecycle.tutorialBattle.battleId,
      replayed: true,
      remainingMatches: PLAYER_LEAGUE_PLACEMENT_MATCHES,
    };
  }
  const battleId = validatedTutorialBattleId(newBattleId, ApiErrorCode.InternalServerError);
  const revision = validatedTutorialRevision(state.revision);
  return {
    state: {
      ...state,
      revision: revision + 1,
      tutorialBattle: { battleId, startedAt: now },
    },
    battleId,
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
  now: number,
): TutorialMutationResult {
  const remainingMatches = validatedPlayerLeagueRemainingMatches(currentRemainingMatches);
  const lifecycle = validatedTutorialLifecycle(state, now);
  if (lifecycle.tutorialFinished) {
    return {
      state,
      battleId,
      replayed: true,
      remainingMatches: Math.max(remainingMatches, PLAYER_LEAGUE_PLACEMENT_MATCHES),
    };
  }
  if (endReason !== TUTORIAL_WIN_END_REASON) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Tutorial completion requires the recovered Win end reason.");
  }
  const receipt = lifecycle.tutorialBattle;
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
  // Normally bootcamp raises a new account to the fixed starting balances. A chargeback debt is
  // different: using Math.max would erase it. In that case treat the same constants as the exact
  // one-time tutorial grant, allowing them to pay the debt before exposing spendable currency.
  // Express the source minimum as a nonnegative grant so the shared reward guard validates the
  // persisted wallet before tutorialFinished is published. Debt receives the full starter grant;
  // a nonnegative wallet receives only the amount needed to reach the recovered minimum.
  const goldGranted = state.gold < 0
    ? TUTORIAL_STARTING_GOLD
    : Math.max(0, TUTORIAL_STARTING_GOLD - state.gold);
  const warBucksGranted = state.warBucks < 0
    ? TUTORIAL_STARTING_WARBUCKS
    : Math.max(0, TUTORIAL_STARTING_WARBUCKS - state.warBucks);
  const tutorialGold = checkedRewardBalance(state.gold, goldGranted, "Tutorial starter Gold");
  const tutorialWarBucks = checkedRewardBalance(
    state.warBucks,
    warBucksGranted,
    "Tutorial starter WarBucks",
  );
  const revision = validatedTutorialRevision(state.revision);
  return {
    state: {
      ...withoutBattle,
      revision: revision + 1,
      gold: tutorialGold,
      warBucks: tutorialWarBucks,
      tutorialFinished: true,
    },
    battleId: receipt?.battleId ?? "",
    replayed: false,
    remainingMatches: Math.max(remainingMatches, PLAYER_LEAGUE_PLACEMENT_MATCHES),
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
    const result = finishTutorialState(
      state,
      battleId,
      endReason,
      player.player.remainingMatches,
      unixNow(),
    );
    const profileNeedsUpdate = player.player.remainingMatches !== result.remainingMatches;
    const progressionChanged = result.state !== state;
    if (!progressionChanged && !profileNeedsUpdate) return result;

    const rawRevision = player.progression?.revision;
    const progressionFilter = player.progression
      ? rawRevision === undefined
        ? { "progression.revision": { $exists: false } }
        : { "progression.revision": rawRevision }
      : { progression: { $exists: false } };
    const successor = progressionChanged
      ? validatedProgressionSuccessor(state, result.state)
      : state;
    const { dogTags: _legacyDogTags, ...canonicalState } = successor;
    const update = await players().updateOne(
      { id: playerId, ...progressionFilter },
      {
        $set: {
          ...(progressionChanged ? { progression: canonicalState } : {}),
          "player.remainingMatches": result.remainingMatches,
          updatedAt: new Date(),
        },
      },
    );
    if (update.modifiedCount === 1) {
      return { ...result, state: progressionChanged ? canonicalState : state };
    }
  }
  throw new ApiError(ApiErrorCode.InternalServerError, "Concurrent tutorial completion could not be committed.");
}
