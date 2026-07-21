import { randomInt } from "node:crypto";
import { ApiError, ApiErrorCode } from "../apiErrors";
import type {
  PlayerProgressionState,
} from "../db";
import { grantMissionCardsState } from "./cardInventoryService";
import { materializeDogTags } from "./economyService";
import { grantLootboxPartsState } from "./lootboxPurchaseService";
import { mutateProgression } from "./progressionMutationService";
import {
  VIDEO_AD_LIMITS,
  VideoAdRewardKind,
  validatedVideoAdRewardState,
} from "./videoAdRewardAuthorityService";

export {
  VIDEO_AD_LIMITS,
  VideoAdRewardKind,
  validatedVideoAdRewardTimes,
} from "./videoAdRewardAuthorityService";

/**
 * Explicit offline Golden Suitcase replacement.
 *
 * The response parser proves that production could grant currencies, cards, visual suitcases,
 * VIP time, and power bands. Its production selection table was remote live-ops data, however,
 * and the bundled 4.9.5 chance/range rows contain mutually invalid ranges after decoding (for
 * example a maximum below its minimum). Enabling those rows would fabricate paid entitlement
 * behavior. The offline server therefore selects uniformly from four completely authoritative,
 * already-persisted reward families. Operators can replace this table when a reviewed archived
 * sheet is recovered; the client never chooses the branch or amount.
 */
export const OFFLINE_GOLDEN_SUITCASE_REWARDS = Object.freeze([
  Object.freeze({ kind: "warBucks" as const, amount: 1_000 }),
  Object.freeze({ kind: "gold" as const, amount: 5 }),
  Object.freeze({ kind: "card" as const, amount: 1 }),
  Object.freeze({ kind: "lootbox" as const, amount: 1 }),
]);

const TRANSPORT_REPLAY_SECONDS = 5;
type PickIndex = (exclusiveMaximum: number) => number;

export interface VideoAdRewardTransition {
  state: PlayerProgressionState;
  reward: VideoAdRewardKind;
  response: Record<string, unknown>;
  replayed: boolean;
}

function selectedIndex(pick: PickIndex, upperBound: number, context: string): number {
  const selected = pick(upperBound);
  if (!Number.isInteger(selected) || selected < 0 || selected >= upperBound) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${context} selector is invalid.`);
  }
  return selected;
}

function checkedCurrencyAdd(current: number, amount: number, currency: string): number {
  if (!Number.isSafeInteger(current) || !Number.isSafeInteger(amount) || amount < 1) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${currency} ad reward is invalid.`);
  }
  const next = current + amount;
  if (!Number.isSafeInteger(next)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${currency} ad reward overflowed.`);
  }
  return next;
}

function immutableResponse(response: Record<string, unknown>): Record<string, unknown> {
  // Every response value in this service is JSON data. A JSON round trip detaches receipt
  // arrays from the mutable transition object without introducing a runtime-specific clone API.
  return JSON.parse(JSON.stringify(response)) as Record<string, unknown>;
}

function grantRandomCard(
  state: PlayerProgressionState,
  playerLevelIndex: number,
  pick: PickIndex,
): { state: PlayerProgressionState; response: Record<string, unknown> } {
  // The retired backend's RandomCard rarity weights are absent. Bronze is the conservative
  // source-valid fallback and FROMMISSION still limits the pool to cards visible at this level.
  const cards = grantMissionCardsState(state, 1, 1, playerLevelIndex, pick);
  return { state: cards.state, response: { AddedCards: cards.cards } };
}

function grantDogTag(
  state: PlayerProgressionState,
  now: number,
): { state: PlayerProgressionState; response: Record<string, unknown> } {
  const materialized = materializeDogTags(state, now);
  if (materialized.dogTagSeconds >= materialized.dogTagMax) {
    // Do not consume the ad allowance when no inventory credit can be delivered. The stock UI
    // normally hides this button at the cap, but the backend must enforce it independently.
    throw new ApiError(ApiErrorCode.UnknownAction, "Dog tags are already full.");
  }
  const rewarded = {
    ...materialized,
    dogTagSeconds: Math.min(
      materialized.dogTagMax,
      materialized.dogTagSeconds + Math.max(1, Math.floor(materialized.dogTagRefillSeconds)),
    ),
  };
  return {
    state: rewarded,
    response: {
      DogTagSeconds: rewarded.dogTagSeconds,
      DogTagLastUpdate: rewarded.dogTagLastUpdate,
    },
  };
}

function grantVisualSuitcase(
  state: PlayerProgressionState,
  pick: PickIndex,
): { state: PlayerProgressionState; response: Record<string, unknown> } {
  const lootbox = grantLootboxPartsState(state, 1, pick);
  return { state: lootbox.state, response: { NewVisuals: lootbox.newVisuals } };
}

function grantGoldenSuitcase(
  state: PlayerProgressionState,
  playerLevelIndex: number,
  pick: PickIndex,
): { state: PlayerProgressionState; response: Record<string, unknown> } {
  const definition = OFFLINE_GOLDEN_SUITCASE_REWARDS[
    selectedIndex(pick, OFFLINE_GOLDEN_SUITCASE_REWARDS.length, "Golden Suitcase")
  ]!;
  if (definition.kind === "warBucks") {
    return {
      state: { ...state, warBucks: checkedCurrencyAdd(state.warBucks, definition.amount, "WarBucks") },
      response: { WarBucks: definition.amount },
    };
  }
  if (definition.kind === "gold") {
    return {
      state: { ...state, gold: checkedCurrencyAdd(state.gold, definition.amount, "Gold") },
      response: { Gold: definition.amount },
    };
  }
  if (definition.kind === "card") return grantRandomCard(state, playerLevelIndex, pick);
  return grantVisualSuitcase(state, pick);
}

/**
 * Validate one completed-ad report and atomically grant its server-selected reward.
 *
 * Security boundary: the stock 1.6.0 request contains only Reward, DogTagRefillTime, and
 * DogTagCap. The latter two are ignored, and there is no provider-signed impression token.
 * Consequently this service enforces authoritative inventory and source rate limits but cannot
 * attest that Fuse actually rendered a video. A future ad provider integration must validate a
 * server-to-server callback/nonce before invoking this transition; accepting another client
 * boolean or timestamp would add no security.
 */
export function grantVideoAdRewardState(
  state: PlayerProgressionState,
  now: number,
  playerLevelIndex: number,
  reward: VideoAdRewardKind,
  pick: PickIndex = (exclusiveMaximum) => randomInt(exclusiveMaximum),
): VideoAdRewardTransition {
  const currentTime = Math.floor(now);
  const limit = VIDEO_AD_LIMITS[reward];
  if (!limit || !Number.isSafeInteger(currentTime) || currentTime <= 0) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video ad reward request is invalid.");
  }

  // Validate the complete private receipt before consulting its replay fields. A malformed
  // truthy object must never bypass grant/rate-limit work or return attacker-controlled JSON.
  const authority = validatedVideoAdRewardState(state.videoAdRewards, currentTime, state.revision);
  const prior = authority.lastReceipt;
  if (
    prior?.reward === reward
    && prior.progressionRevision === state.revision
    && currentTime >= prior.settledAt
    && currentTime <= prior.settledAt + TRANSPORT_REPLAY_SECONDS
  ) {
    // Action 156 has no BufferId or ad nonce. This narrow same-revision window collapses the
    // stock HTTP retry after a lost response without treating a later completed ad as a replay.
    return { state, reward, response: immutableResponse(prior.response), replayed: true };
  }

  const times = authority.times;
  const ledger = times[limit.key];
  if (ledger.length >= limit.count) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video ad reward limit reached.", {
      videoAdRewardTimes: times,
    });
  }
  const last = ledger.at(-1);
  if (last !== undefined && currentTime < last + limit.minimumSpacingSeconds) {
    throw new ApiError(ApiErrorCode.UnknownAction, "Video ad reward is still cooling down.", {
      videoAdRewardTimes: times,
      RetryAfter: last + limit.minimumSpacingSeconds - currentTime,
    });
  }

  let granted: { state: PlayerProgressionState; response: Record<string, unknown> };
  if (reward === VideoAdRewardKind.RandomCard) {
    granted = grantRandomCard(state, playerLevelIndex, pick);
  } else if (reward === VideoAdRewardKind.Dogtag) {
    granted = grantDogTag(state, currentTime);
  } else if (reward === VideoAdRewardKind.GoldenSuitcase) {
    granted = grantGoldenSuitcase(state, playerLevelIndex, pick);
  } else {
    granted = grantVisualSuitcase(state, pick);
  }

  ledger.push(currentTime);
  const response = { ...granted.response, videoAdRewardTimes: times };
  const revision = state.revision + 1;
  const next: PlayerProgressionState = {
    ...granted.state,
    revision,
    videoAdRewards: {
      times,
      lastReceipt: {
        reward,
        settledAt: currentTime,
        progressionRevision: revision,
        response: immutableResponse(response),
      },
    },
  };
  return { state: next, reward, response, replayed: false };
}

export function grantVideoAdReward(
  playerId: string,
  playerLevelIndex: number,
  reward: VideoAdRewardKind,
): Promise<VideoAdRewardTransition> {
  return mutateProgression(
    playerId,
    (state, now) => grantVideoAdRewardState(state, now, playerLevelIndex, reward),
  );
}
