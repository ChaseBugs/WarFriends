import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState } from "../db";
import { CARD_CATALOG, CARD_UNLOCK_LEVEL, cardInventoryStateFor } from "./cardInventoryService";
import { mutateProgression } from "./progressionMutationService";

/**
 * Exact StringConstants.TutorialRewardCards row from the recovered 4.9.5 MainScene.
 *
 * Do not confuse this with StringConstants.TutorialCards. The latter contains the three
 * temporary cards used inside the battle; these five are the permanent cards added by
 * GameControllerTutorial.AddWarcardsForFinishingPlayWarcardsTutorial after a non-forfeit end.
 */
export const WARCARDS_TUTORIAL_REWARD_IDS = Object.freeze([
  "CLUSTERGRENADE",
  "ELITEPARA",
  "HEAVYTURRET",
  "ELECTRICTRAPS",
  "SABOTAGE",
] as const);

/** CardConstants.WarcardsUnlockLevel is display level 6; DatabasePlayer.Level is zero based. */
export const WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX = CARD_UNLOCK_LEVEL - 1;

const WARCARDS_TUTORIAL_FORFEIT_END_REASON = 5;
// The Play Warcards flow is a deathmatch. Killed, Win, WinByForfeit, and explicit Forfeit are
// its reachable recovered outcomes; rejecting campaign/unknown values narrows the settlement API.
const WARCARDS_TUTORIAL_END_REASONS = new Set([1, 2, 3, WARCARDS_TUTORIAL_FORFEIT_END_REASON]);

export interface WarcardsTutorialStartResult {
  state: PlayerProgressionState;
  battleId: string;
  started: boolean;
  replayed: boolean;
}

export interface WarcardsTutorialSettlementResult {
  state: PlayerProgressionState;
  battleId: string;
  awarded: boolean;
  replayed: boolean;
  cards: string[];
}

/** Reproduce TutorialManagerPlayWarcards.shouldStartTutorial using server-owned fields. */
export function shouldStartWarcardsTutorial(state: PlayerProgressionState, playerLevelIndex: number): boolean {
  return state.tutorialFinished === true
    && state.warcardsTutorialFinished !== true
    && Number.isSafeInteger(playerLevelIndex)
    && playerLevelIndex >= WARCARDS_TUTORIAL_MINIMUM_LEVEL_INDEX;
}

function validBattleId(value: string): void {
  if (value.length < 1 || value.length > 128) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Play Warcards battle ID is invalid.");
  }
}

/**
 * Record the eligible offline-bot action-64 start before GameEnded can pay the tutorial.
 *
 * A second request for the same BattleId is a transport replay. A different BattleId replaces
 * an abandoned receipt: the stock tutorial may be restarted after an interrupted offline match,
 * and retaining the old ID would permanently strand the account before cardTutState reaches 2.
 */
export function startWarcardsTutorialState(
  state: PlayerProgressionState,
  playerLevelIndex: number,
  battleId: string,
  now: number,
): WarcardsTutorialStartResult {
  if (!shouldStartWarcardsTutorial(state, playerLevelIndex)) {
    return { state, battleId: "", started: false, replayed: true };
  }
  validBattleId(battleId);
  if (state.warcardsTutorialBattle?.battleId === battleId) {
    return { state, battleId, started: true, replayed: true };
  }
  return {
    state: {
      ...state,
      revision: state.revision + 1,
      warcardsTutorialBattle: { battleId, startedAt: Math.max(0, Math.floor(now)) },
    },
    battleId,
    started: true,
    replayed: false,
  };
}

/**
 * Settle the permanent Play Warcards reward from one matching start receipt.
 *
 * The request's ObtainedCards field is deliberately absent from this API. A modified APK can
 * serialize any IDs there, so the backend always grants the fixed MainScene row instead. The
 * recovered manager grants after Killed/Win/WinByForfeit and withholds only on explicit Forfeit.
 * A forfeit consumes the active receipt but leaves cardTutState at 1 so a later battle can retry.
 */
export function settleWarcardsTutorialState(
  state: PlayerProgressionState,
  playerLevelIndex: number,
  battleId: string,
  endReason: number,
): WarcardsTutorialSettlementResult {
  if (state.warcardsTutorialFinished) {
    // No reward response field is required because the stock client added these fixed cards
    // locally before its original action 62. A terminal replay only needs a successful result.
    return { state, battleId, awarded: false, replayed: true, cards: [] };
  }
  if (!shouldStartWarcardsTutorial(state, playerLevelIndex)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Play Warcards tutorial is not unlocked.");
  }
  if (!Number.isInteger(endReason) || !WARCARDS_TUTORIAL_END_REASONS.has(endReason)) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Play Warcards end reason is invalid.");
  }
  validBattleId(battleId);
  const receipt = state.warcardsTutorialBattle;
  if (!receipt || receipt.battleId !== battleId) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Play Warcards battle has no matching start receipt.");
  }

  const { warcardsTutorialBattle: _battle, ...withoutBattle } = state;
  if (endReason === WARCARDS_TUTORIAL_FORFEIT_END_REASON) {
    return {
      state: { ...withoutBattle, revision: state.revision + 1 },
      battleId,
      awarded: false,
      replayed: false,
      cards: [],
    };
  }

  const cardInventory = cardInventoryStateFor(state);
  for (const cardId of WARCARDS_TUTORIAL_REWARD_IDS) {
    if (!CARD_CATALOG[cardId]?.implemented) {
      throw new ApiError(ApiErrorCode.InternalServerError, `Tutorial reward card ${cardId} is unavailable.`);
    }
    const current = cardInventory.cardData[cardId]?.amount ?? 0;
    if (!Number.isSafeInteger(current) || current < 0 || current === Number.MAX_SAFE_INTEGER) {
      throw new ApiError(ApiErrorCode.InternalServerError, `Card count for ${cardId} is invalid.`);
    }
    cardInventory.cardData[cardId] = { amount: current + 1 };
  }
  return {
    state: {
      ...withoutBattle,
      revision: state.revision + 1,
      cardInventory,
      warcardsTutorialFinished: true,
    },
    battleId,
    awarded: true,
    replayed: false,
    cards: [...WARCARDS_TUTORIAL_REWARD_IDS],
  };
}

export function startWarcardsTutorial(
  playerId: string,
  playerLevelIndex: number,
  battleId: string,
): Promise<WarcardsTutorialStartResult> {
  return mutateProgression(playerId, (state, now) => (
    startWarcardsTutorialState(state, playerLevelIndex, battleId, now)
  ));
}

export function settleWarcardsTutorial(
  playerId: string,
  playerLevelIndex: number,
  battleId: string,
  endReason: number,
): Promise<WarcardsTutorialSettlementResult> {
  return mutateProgression(playerId, (state) => (
    settleWarcardsTutorialState(state, playerLevelIndex, battleId, endReason)
  ));
}
