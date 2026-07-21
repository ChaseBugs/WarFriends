import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import {
  players,
  type InstantBattleReceiptState,
  type InstantBattleState,
  type PlayerDocument,
  type PlayerProgressionState,
} from "../db";
import { calculateArmyPower } from "./armyPowerService";
import { applyLevelExperienceState, playerLevelDefinition } from "./levelProgressionService";
import { progressionForPlayer, unixNow } from "./playerStateService";
import { validatedProgressionSuccessor } from "./progressionPublicationAuthorityService";
import {
  INSTANT_BATTLE_MAX_CHARGES,
  INSTANT_BATTLE_MAX_GOLD_COST,
  INSTANT_BATTLE_MIN_GOLD_COST,
  INSTANT_BATTLE_RELOAD_SECONDS,
  INSTANT_BATTLE_UNLOCK_DISPLAY_LEVEL,
  validatedInstantBattleState,
} from "./instantBattleAuthorityService";

export {
  INSTANT_BATTLE_MAX_CHARGES,
  INSTANT_BATTLE_MAX_GOLD_COST,
  INSTANT_BATTLE_MIN_GOLD_COST,
  INSTANT_BATTLE_RELOAD_SECONDS,
  INSTANT_BATTLE_UNLOCK_DISPLAY_LEVEL,
  validatedInstantBattleState,
} from "./instantBattleAuthorityService";

/**
 * Action-199 balancing reconstructed from the two recovered client versions.
 *
 * MainScene contains the five correct float values, but its labels are shifted relative to
 * the 1.6.0 Constants enum used by this hybrid project. The surrounding 4.9.5 UI explicitly
 * says "5 skirmishes" and "35 Gold". Rotating that contiguous value set into the 1.6.0 field
 * order yields the coherent 9 / 5 / 48 / 35 / 140 contract below. MainScene is patched to the
 * same order, so the stock client and backend perform identical calculations.
 */
const MAX_CONCURRENCY_RETRIES = 4;

export interface InstantBattleRewardPolicy {
  experiencePerBattle: number;
  warBucksPerBattle: number;
}

export interface InstantBattleTransition {
  state: PlayerProgressionState;
  instantBattle: InstantBattleState;
  receipt: InstantBattleReceiptState;
  replayed: boolean;
}

export interface InstantBattleSettlement extends InstantBattleTransition {
  playerLevel: number;
  armyPower: number;
}

function checkedNonNegativeInteger(value: number, name: string): number {
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} is invalid.`);
  }
  return value;
}

function checkedProduct(left: number, right: number, name: string): number {
  const value = left * right;
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} overflowed.`);
  }
  return value;
}

function checkedSum(left: number, right: number, name: string): number {
  const value = left + right;
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} overflowed.`);
  }
  return value;
}

function checkedBalanceSum(left: number, right: number, name: string): number {
  const value = left + right;
  if (!Number.isSafeInteger(left) || !Number.isSafeInteger(right) || right < 0 || !Number.isSafeInteger(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${name} overflowed.`);
  }
  return value;
}

/** Clone and validate private counters instead of mutating a MongoDB snapshot in place. */
export function instantBattleStateFor(state: PlayerProgressionState, now?: number): InstantBattleState {
  return validatedInstantBattleState(state.instantBattle, now, state.revision);
}

/** Reproduce PlayerAnalyticsData.GetInstantBattlesReady with server time as authority. */
export function instantBattlesReady(value: InstantBattleState, now: number): number {
  const current = validatedInstantBattleState(value, now);
  if (current.instantBattlesTime === 0) return INSTANT_BATTLE_MAX_CHARGES;
  return Math.min(
    INSTANT_BATTLE_MAX_CHARGES,
    Math.floor((now - current.instantBattlesTime) / INSTANT_BATTLE_RELOAD_SECONDS),
  );
}

/** Reproduce PlayerAnalyticsData.GetInstantBattleCost's 35, 70, 140, 140... curve. */
export function instantBattleGoldCost(paidInstantBattles: number): number {
  checkedNonNegativeInteger(paidInstantBattles, "Paid Instant Battle count");
  const exponentLimit = Math.sqrt(INSTANT_BATTLE_MAX_GOLD_COST / INSTANT_BATTLE_MIN_GOLD_COST) + 1;
  const exponent = Math.min(paidInstantBattles, exponentLimit);
  return Math.min(
    INSTANT_BATTLE_MAX_GOLD_COST,
    INSTANT_BATTLE_MIN_GOLD_COST * Math.pow(2, exponent),
  );
}

function paidBattleRejection(
  current: InstantBattleState,
  state: PlayerProgressionState,
  message: string,
): ApiError {
  const expectedCost = instantBattleGoldCost(current.paidInstantBattles);
  // The stock client subtracts Gold before the HTTP response. Its dedicated 19902 callback
  // is therefore the only safe rejection path for a syntactically valid paid request: it
  // restores the authoritative wallet, paid counter, and current price from these fields.
  return new ApiError(ApiErrorCode.NotEnoughGoldForSkirmish, message, {
    SkirmishCost: expectedCost,
    PaidBattles: current.paidInstantBattles,
    PlayerGold: state.gold,
  });
}

function rewardPolicyFromConfig(): InstantBattleRewardPolicy {
  return {
    experiencePerBattle: checkedNonNegativeInteger(
      config.instantBattleExperiencePerBattle,
      "Instant Battle XP policy",
    ),
    warBucksPerBattle: checkedNonNegativeInteger(
      config.instantBattleWarBucksPerBattle,
      "Instant Battle WarBucks policy",
    ),
  };
}

/**
 * Calculate one complete Skirmish batch as a pure state transition.
 *
 * An absent `paidCost` means the player is consuming every naturally recharged battle. A
 * present value is only an assertion from the optimistic client: the backend independently
 * derives the escalating price, requires the natural charge count to be zero, and debits its
 * own wallet. Rewards are also derived exclusively from server policy. This makes changing
 * IsPaid, BattleCount, or reward fields in a modified APK ineffective.
 */
export function playInstantBattleState(
  state: PlayerProgressionState,
  playerLevel: number,
  now: number,
  paidCost: number | undefined,
  policy: InstantBattleRewardPolicy,
): InstantBattleTransition {
  checkedNonNegativeInteger(now, "Instant Battle request time");
  checkedNonNegativeInteger(state.revision, "Progression revision");
  checkedNonNegativeInteger(state.gold, "Gold balance");
  checkedNonNegativeInteger(state.warBucks, "WarBucks balance");
  checkedNonNegativeInteger(policy.experiencePerBattle, "Instant Battle XP policy");
  checkedNonNegativeInteger(policy.warBucksPerBattle, "Instant Battle WarBucks policy");

  const levelDefinition = playerLevelDefinition(playerLevel);
  if (levelDefinition.displayLevel < INSTANT_BATTLE_UNLOCK_DISPLAY_LEVEL) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Instant Battle is not unlocked at this rank.");
  }

  const current = instantBattleStateFor(state, now);
  const normalizedPaidCost = paidCost ?? 0;
  if (!Number.isSafeInteger(normalizedPaidCost) || normalizedPaidCost < 0) {
    throw new ApiError(ApiErrorCode.RequestNotAuthorized, "Instant Battle Gold price is invalid.");
  }

  // Direct action 199 has no BufferId or operation UUID. The narrow replay proof available to
  // the server is an identical request received in the same server second before any other
  // progression mutation. This covers an immediate HTTP transport duplicate without blocking
  // a legitimate Play Again at the capped 140-Gold price in a later second.
  const previous = current.lastReceipt;
  if (
    previous
    && previous.settledAt === now
    && previous.paidCost === normalizedPaidCost
    && previous.progressionRevision === state.revision
  ) {
    return { state, instantBattle: current, receipt: previous, replayed: true };
  }

  const ready = instantBattlesReady(current, now);
  const isPaid = paidCost !== undefined;
  let battleCount: number;
  let nextPaidCount = current.paidInstantBattles;
  if (isPaid) {
    if (ready !== 0) {
      throw paidBattleRejection(
        current,
        state,
        "A paid Instant Battle cannot be used while free charges are ready.",
      );
    }
    const expectedCost = instantBattleGoldCost(current.paidInstantBattles);
    if (paidCost !== expectedCost) {
      throw paidBattleRejection(current, state, "Instant Battle Gold price is stale or forged.");
    }
    if (state.gold < expectedCost) {
      // LEDNENKKDJM's 19902 branch repairs all three local values from these exact keys after
      // the client has optimistically attempted a purchase.
      throw paidBattleRejection(current, state, "Not enough Gold for Instant Battle.");
    }
    battleCount = INSTANT_BATTLE_MAX_CHARGES;
    nextPaidCount = checkedSum(current.paidInstantBattles, 1, "Paid Instant Battle count");
  } else {
    if (ready === 0) {
      throw new ApiError(ApiErrorCode.NoSkirmishAvailable, "No Instant Battle charge is ready.");
    }
    // The results screen is initialized with GetInstantBattlesReady(), confirming that one
    // free request consumes the whole currently accrued batch rather than a single charge.
    battleCount = ready;
  }

  const experienceGained = checkedProduct(
    battleCount,
    policy.experiencePerBattle,
    "Instant Battle XP reward",
  );
  const warBucks = checkedProduct(
    battleCount,
    policy.warBucksPerBattle,
    "Instant Battle WarBucks reward",
  );
  const goldAfterPayment = state.gold - normalizedPaidCost;
  const leveled = applyLevelExperienceState(
    { ...state, gold: goldAfterPayment },
    playerLevel,
    experienceGained,
  );
  const levelChanged = leveled.levelTo !== leveled.levelFrom;
  const revision = checkedSum(state.revision, 1, "Progression revision");
  const receipt: InstantBattleReceiptState = {
    settledAt: now,
    paidCost: normalizedPaidCost,
    battleCount,
    experienceGained,
    warBucks,
    levelFrom: leveled.levelFrom,
    levelTo: leveled.levelTo,
    levelExperience: leveled.levelExperience,
    levelGold: leveled.goldGranted,
    dogTagsRefilled: levelChanged,
    progressionRevision: revision,
  };
  // `instantBattlesTime` is a zero-charge anchor, not merely the last request timestamp.
  // Consuming a partially recharged batch advances it by the exact number of elapsed charge
  // intervals and preserves the fractional remainder toward the next charge. Once the cap was
  // reached, surplus elapsed time was already discarded, so consumption starts a fresh timer.
  // A paid batch does not consume natural charges and therefore must not delay their countdown.
  const nextTimer = isPaid
    ? current.instantBattlesTime
    : current.instantBattlesTime === 0 || ready === INSTANT_BATTLE_MAX_CHARGES
      ? now
      : current.instantBattlesTime + ready * INSTANT_BATTLE_RELOAD_SECONDS;
  const instantBattle: InstantBattleState = {
    instantBattlesTime: nextTimer,
    instantBattles: checkedSum(current.instantBattles, battleCount, "Instant Battle lifetime count"),
    paidInstantBattles: nextPaidCount,
    lastReceipt: receipt,
  };
  const rewardedWarBucks = checkedBalanceSum(leveled.state.warBucks, warBucks, "WarBucks balance");
  return {
    state: {
      ...leveled.state,
      revision,
      warBucks: rewardedWarBucks,
      // Both recovered success parsers refill energy when the level marker is present. Persist
      // the same refill so a reconnect cannot undo the local rank-up benefit.
      ...(levelChanged
        ? { dogTagSeconds: leveled.state.dogTagMax, dogTagLastUpdate: now }
        : {}),
      instantBattle,
    },
    instantBattle,
    receipt,
    replayed: false,
  };
}

function progressionRevisionFilter(player: PlayerDocument): Record<string, unknown> {
  if (!player.progression) return { progression: { $exists: false } };
  return player.progression.revision === undefined
    ? { "progression.revision": { $exists: false } }
    : { "progression.revision": player.progression.revision };
}

/**
 * Atomically persist wallet, XP/rank, timer, and Army Power for one Instant Battle request.
 *
 * A normal progression helper cannot be used here because level-up changes also touch the
 * public DatabasePlayer level, lifetime experience, denormalized root fields, and rank-based
 * Army Power. One revision-guarded MongoDB document write keeps all those mirrors consistent;
 * concurrent economy requests reload and recalculate instead of overwriting one another.
 */
export async function playInstantBattle(
  playerId: string,
  paidCost?: number,
): Promise<InstantBattleSettlement> {
  const policy = rewardPolicyFromConfig();
  for (let attempt = 0; attempt < MAX_CONCURRENCY_RETRIES; attempt += 1) {
    const player = await players().findOne({ id: playerId });
    if (!player) throw new ApiError(ApiErrorCode.PlayerNotFound, "Player not found.");
    const state = progressionForPlayer(player);
    const transition = playInstantBattleState(state, player.player.level, unixNow(), paidCost, policy);

    if (transition.replayed) {
      return {
        ...transition,
        playerLevel: transition.receipt.levelTo,
        armyPower: player.player.armyPower,
      };
    }
    const successor = validatedProgressionSuccessor(state, transition.state);

    const nextLifetimeExperience = checkedSum(
      player.player.experience,
      transition.receipt.experienceGained,
      "Player lifetime experience",
    );
    const levelChanged = transition.receipt.levelTo !== transition.receipt.levelFrom;
    const projected: PlayerDocument = {
      ...player,
      progression: successor,
      player: {
        ...player.player,
        experience: nextLifetimeExperience,
        level: transition.receipt.levelTo,
      },
    };
    const armyPower = levelChanged ? calculateArmyPower(projected).total : player.player.armyPower;
    const { dogTags: _legacyDogTags, ...canonicalState } = successor;
    const update = await players().updateOne(
      { id: playerId, ...progressionRevisionFilter(player) },
      {
        $set: {
          progression: canonicalState,
          experience: nextLifetimeExperience,
          "player.experience": nextLifetimeExperience,
          "player.level": transition.receipt.levelTo,
          armyPower,
          "player.armyPower": armyPower,
          updatedAt: new Date(),
        },
      },
    );
    if (update.modifiedCount === 1) {
      return {
        ...transition,
        state: canonicalState,
        playerLevel: transition.receipt.levelTo,
        armyPower,
      };
    }
  }
  throw new ApiError(
    ApiErrorCode.InternalServerError,
    "Concurrent Instant Battle update could not be completed.",
  );
}

/** Build only fields consumed by OGLEHLIPEFM.DKKLKHHLEOK. */
export function instantBattleWireResponse(result: InstantBattleSettlement): Record<string, unknown> {
  const { receipt, instantBattle } = result;
  const levelChanged = receipt.levelTo !== receipt.levelFrom;
  return {
    InstantBattleTime: instantBattle.instantBattlesTime,
    ExperienceGained: receipt.experienceGained,
    LevelExperience: receipt.levelExperience,
    WarBucks: receipt.warBucks,
    BattleCount: receipt.battleCount,
    ...(receipt.paidCost > 0 ? { PaidInstantBattles: instantBattle.paidInstantBattles } : {}),
    ...(levelChanged
      ? {
        Level: receipt.levelTo,
        LevelGold: receipt.levelGold,
        DogtagsRefillRankUp: true,
      }
      : {}),
    ...(result.replayed ? { Replayed: true } : {}),
  };
}
