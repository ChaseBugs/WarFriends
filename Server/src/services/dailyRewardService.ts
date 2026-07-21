import { ApiError, ApiErrorCode } from "../apiErrors";
import { config } from "../config";
import type { DailyRewardState, PlayerProgressionState } from "../db";
import { advanceAchievementState } from "./achievementService";
import {
  grantCardPackRewardState,
  grantMissionCardsState,
} from "./cardInventoryService";
import { mutateProgression } from "./progressionMutationService";
import { checkedRewardBalance } from "./rewardMathService";
import {
  grantDailyVipCardsState,
  type VipDailyCardReward,
  type VipRandomIndex,
} from "./vipService";
import {
  dailyRewardAuthorityFor,
  validatedDailyRewardState,
} from "./dailyRewardAuthorityService";
export { validatedDailyRewardState } from "./dailyRewardAuthorityService";

// Exact MDNLFMNBNEG values read by DailyRewardManager.ParseReward in the 1.6.0 client.
const WARBUCKS_REWARD_TYPE = 0;
const GOLD_REWARD_TYPE = 1;
const BRONZE_CARDS_REWARD_TYPE = 2;
const SILVER_CARDS_REWARD_TYPE = 3;
const GOLD_CARDS_REWARD_TYPE = 4;
const BRONZE_PACK_REWARD_TYPE = 11;
const SILVER_PACK_REWARD_TYPE = 12;
const GOLD_PACK_REWARD_TYPE = 13;
const ARENA_TICKETS_REWARD_TYPE = 15;
// LGCDFAELDNL.None. VIP/Facebook doubling requires a separate server-owned entitlement and
// therefore remains disabled for this offline calendar rather than trusting a client claim.
const NO_DOUBLE_BONUS = 0;

/*
 * The response types and delivery shapes survived in the APK, but the production calendar was
 * remote live-ops data. These conservative values are an explicit offline replacement. The
 * seven-position cadence makes every implemented parser branch reachable without granting
 * paid VIP, visuals, or Elite parts whose original schedule/selection rules are unavailable.
 */
const OFFLINE_DAILY_WARBUCKS = 1_000;
const OFFLINE_DAILY_BRONZE_CARDS = 2;
const OFFLINE_DAILY_SILVER_CARDS = 1;
const OFFLINE_DAILY_GOLD_CARDS = 1;
const OFFLINE_DAILY_TICKETS = 1;

export interface DailyRewardDefinition {
  Type: number;
  Double: number;
  Count: number;
  Param: string;
}

export interface DailyRewardWireData {
  month: number;
  year: number;
  canClaim: number;
  claimReward: number;
  nextDay: number;
  config: Record<string, DailyRewardDefinition>;
}

export interface DailyRewardMutationResult {
  state: PlayerProgressionState;
  calendar: DailyRewardState;
  rewardDay?: number;
  goldAdded?: number;
  warBucksAdded?: number;
  ticketsAdded?: number;
  cardIds?: string[];
  addedType?: number;
  added?: number | DailyRewardCardsAdded;
  /** Optional paid-VIP pair carried inside the recovered dailyRewardData response object. */
  vipDailyCardReward?: VipDailyCardReward;
}

export interface DailyRewardCardsAdded {
  /** ParseReward applies this amount once to every semicolon-separated card identity. */
  count: number;
  cards: string;
}

export interface DailyRewardGoldPolicy {
  readonly ordinary: number;
  readonly weekly: number;
}

/**
 * Validate the offline Gold rows without changing operator-supplied authority.
 *
 * DailyRewardManager stores calendar `Count` and the claimed currency in C# `long`, while the
 * JavaScript backend can preserve integers only through `Number.MAX_SAFE_INTEGER`. Weekly Gold
 * must not be lower than the ordinary row. Resolving the pair during module initialization keeps
 * every calendar projection and later claim in one process on the same reviewed policy.
 */
function exactDailyRewardGoldPolicy(policy: DailyRewardGoldPolicy): DailyRewardGoldPolicy {
  if (
    !Number.isSafeInteger(policy.ordinary)
    || policy.ordinary < 0
    || !Number.isSafeInteger(policy.weekly)
    || policy.weekly < policy.ordinary
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Daily reward Gold policy is invalid.");
  }
  return { ordinary: policy.ordinary, weekly: policy.weekly };
}

const CONFIGURED_DAILY_REWARD_GOLD_POLICY = Object.freeze(exactDailyRewardGoldPolicy({
  ordinary: config.dailyRewardGold,
  weekly: config.dailyRewardWeeklyGold,
}));

export function dailyRewardGoldPolicy(
  policy?: DailyRewardGoldPolicy,
): DailyRewardGoldPolicy {
  return policy === undefined
    ? CONFIGURED_DAILY_REWARD_GOLD_POLICY
    : exactDailyRewardGoldPolicy(policy);
}

function utcDate(now: number): Date {
  return new Date(Math.floor(now) * 1000);
}

function utcDayKey(date: Date): string {
  return date.toISOString().slice(0, 10);
}

function daysInMonth(year: number, month: number): number {
  // Date.UTC uses a zero-based month. Passing the one-based current month as the next
  // month's index and asking for day zero returns the final day of the current month.
  return new Date(Date.UTC(year, month, 0)).getUTCDate();
}

function secondsUntilNextUtcDay(date: Date): number {
  const next = Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate() + 1);
  return Math.max(1, Math.floor((next - date.getTime()) / 1000));
}

/**
 * Return the startup-resolved Gold fallback retained for compatibility and operator tuning.
 *
 * The day is a one-based calendar identity, not an arbitrary modulus input. Validating it here
 * keeps direct callers from selecting ordinary/weekly policy with zero, fractions, or non-finite
 * values even when they bypass `dailyRewardDefinitionForDay`.
 */
export function dailyRewardGoldForDay(day: number): number {
  if (!Number.isInteger(day) || day < 1 || day > 31) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Daily reward day is invalid.");
  }
  return day % 7 === 0
    ? CONFIGURED_DAILY_REWARD_GOLD_POLICY.weekly
    : CONFIGURED_DAILY_REWARD_GOLD_POLICY.ordinary;
}

/**
 * Build one deterministic offline replacement row using only fully implemented reward types.
 *
 * Days 1..6 of each seven-position block exercise Gold, WarBucks, loose Bronze cards, Arena
 * Tickets, loose Silver cards, and one loose Gold card. The first seventh day retains the old
 * weekly Gold fallback; later weekly milestones grant Bronze, Silver, then Gold packs. Months
 * longer than 28 days restart the cadence for their final positions. Persisted claim order makes
 * the schedule stable across reconnects and prevents selecting a more valuable future row.
 */
export function dailyRewardDefinitionForDay(day: number): DailyRewardDefinition {
  if (!Number.isInteger(day) || day < 1 || day > 31) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Daily reward day is invalid.");
  }
  const slot = ((day - 1) % 7) + 1;
  switch (slot) {
    case 1:
      return { Type: GOLD_REWARD_TYPE, Double: NO_DOUBLE_BONUS, Count: dailyRewardGoldForDay(day), Param: "" };
    case 2:
      return { Type: WARBUCKS_REWARD_TYPE, Double: NO_DOUBLE_BONUS, Count: OFFLINE_DAILY_WARBUCKS, Param: "" };
    case 3:
      return { Type: BRONZE_CARDS_REWARD_TYPE, Double: NO_DOUBLE_BONUS, Count: OFFLINE_DAILY_BRONZE_CARDS, Param: "" };
    case 4:
      return { Type: ARENA_TICKETS_REWARD_TYPE, Double: NO_DOUBLE_BONUS, Count: OFFLINE_DAILY_TICKETS, Param: "" };
    case 5:
      return { Type: SILVER_CARDS_REWARD_TYPE, Double: NO_DOUBLE_BONUS, Count: OFFLINE_DAILY_SILVER_CARDS, Param: "" };
    case 6:
      return { Type: GOLD_CARDS_REWARD_TYPE, Double: NO_DOUBLE_BONUS, Count: OFFLINE_DAILY_GOLD_CARDS, Param: "" };
    default: {
      const week = Math.ceil(day / 7);
      if (week === 1) {
        return { Type: GOLD_REWARD_TYPE, Double: NO_DOUBLE_BONUS, Count: dailyRewardGoldForDay(day), Param: "" };
      }
      const type = week === 2
        ? BRONZE_PACK_REWARD_TYPE
        : week === 3
          ? SILVER_PACK_REWARD_TYPE
          : GOLD_PACK_REWARD_TYPE;
      return { Type: type, Double: NO_DOUBLE_BONUS, Count: 1, Param: "" };
    }
  }
}

/** Build the exact `config.DayN` objects read by DailyRewardManager.MCGFHPOPMHL. */
export function buildDailyRewardConfig(year: number, month: number): Record<string, DailyRewardDefinition> {
  const result: Record<string, DailyRewardDefinition> = {};
  for (let day = 1; day <= daysInMonth(year, month); day += 1) {
    result[`Day${day}`] = dailyRewardDefinitionForDay(day);
  }
  return result;
}

function packNameForReward(type: number): string | undefined {
  if (type === BRONZE_PACK_REWARD_TYPE) return "BRONZE_CARDPACK";
  if (type === SILVER_PACK_REWARD_TYPE) return "SILVER_CARDPACK";
  if (type === GOLD_PACK_REWARD_TYPE) return "GOLD_CARDPACK";
  return undefined;
}

function rarityForLooseReward(type: number): number | undefined {
  if (type === BRONZE_CARDS_REWARD_TYPE) return 1;
  if (type === SILVER_CARDS_REWARD_TYPE) return 2;
  if (type === GOLD_CARDS_REWARD_TYPE) return 3;
  return undefined;
}

function calendarFor(state: PlayerProgressionState, date: Date): DailyRewardState {
  const year = date.getUTCFullYear();
  const month = date.getUTCMonth() + 1;
  const existing = dailyRewardAuthorityFor(state.dailyReward, Math.floor(date.getTime() / 1000));
  if (existing) return existing;

  // A new month starts a new ordered calendar. We intentionally do not carry unclaimed
  // rewards across months because the Unity model contains only one month/year/config.
  return { year, month, canClaim: 0, claimReward: 0, lastCheckDay: "" };
}

/**
 * Register today's login once. Repeated boot/check requests on the same UTC day only refresh
 * the wire snapshot; they cannot manufacture additional claim slots. Availability advances
 * by login days rather than by the wall-calendar day, matching the client's separate
 * `canClaim` and `claimReward` counters and allowing a returning player to continue in order.
 */
export function checkDailyRewardState(state: PlayerProgressionState, now: number): DailyRewardMutationResult {
  const date = utcDate(now);
  const calendar = calendarFor(state, date);
  const today = utcDayKey(date);
  if (calendar.lastCheckDay === today) {
    // CheckDailyReward runs during ordinary reconnect/boot flows and the stock request has no
    // replay identifier. Once today's login is recorded, the response is only a projection of
    // the existing calendar. Return the exact input state so mutateProgression skips MongoDB;
    // a repeated check must not create an artificial progression revision or contend with a
    // simultaneous reward claim. `calendarFor` still returns a clone, preventing response code
    // from mutating the persisted object by reference.
    return { state, calendar };
  }
  calendar.canClaim = Math.min(daysInMonth(calendar.year, calendar.month), calendar.canClaim + 1);
  calendar.lastCheckDay = today;
  return {
    state: { ...state, revision: state.revision + 1, dailyReward: calendar },
    calendar,
  };
}

/**
 * Claim exactly the next unlocked calendar entry and credit Gold in the same revision-guarded
 * document write. A replay after a lost HTTP response sees the advanced claim cursor and is
 * rejected, so it cannot credit the amount twice even though the old client sends no request
 * UUID. Later days cannot be selected early because `requestedDay` must equal cursor + 1.
 */
export function claimDailyRewardState(
  state: PlayerProgressionState,
  now: number,
  requestedDay: number,
  chooseRandom?: VipRandomIndex,
  playerLevelIndex = 1,
): DailyRewardMutationResult {
  const calendar = calendarFor(state, utcDate(now));
  const expectedDay = calendar.claimReward + 1;
  if (requestedDay <= calendar.claimReward) {
    throw new ApiError(ApiErrorCode.DailyRewardAlreadyClaimed, "Daily reward was already claimed.");
  }
  if (requestedDay !== expectedDay || requestedDay > calendar.canClaim) {
    throw new ApiError(ApiErrorCode.DailyRewardWrongIndex, "Daily reward is not available yet.");
  }

  const definition = dailyRewardDefinitionForDay(requestedDay);
  let rewardedState = state;
  let goldAdded = 0;
  let warBucksAdded = 0;
  let ticketsAdded = 0;
  let cardIds: string[] | undefined;
  let added: number | DailyRewardCardsAdded;

  if (definition.Type === GOLD_REWARD_TYPE) {
    goldAdded = definition.Count;
    // Currency and the calendar cursor publish in one revision. Use the shared reward guard before
    // advancing that cursor so overflow cannot consume a day whose value was not safely credited.
    rewardedState = {
      ...rewardedState,
      gold: checkedRewardBalance(rewardedState.gold, goldAdded, "Daily reward Gold"),
    };
    added = goldAdded;
  } else if (definition.Type === WARBUCKS_REWARD_TYPE) {
    warBucksAdded = definition.Count;
    rewardedState = {
      ...rewardedState,
      warBucks: checkedRewardBalance(rewardedState.warBucks, warBucksAdded, "Daily reward WarBucks"),
    };
    added = warBucksAdded;
  } else if (definition.Type === ARENA_TICKETS_REWARD_TYPE) {
    ticketsAdded = definition.Count;
    rewardedState = {
      ...rewardedState,
      tickets: checkedRewardBalance(rewardedState.tickets, ticketsAdded, "Daily reward Tickets"),
    };
    added = ticketsAdded;
  } else {
    const rarity = rarityForLooseReward(definition.Type);
    const packName = packNameForReward(definition.Type);
    if (rarity !== undefined) {
      const cards = grantMissionCardsState(
        rewardedState,
        rarity,
        definition.Count,
        playerLevelIndex,
        chooseRandom,
      );
      rewardedState = cards.state;
      cardIds = [...cards.cards];
    } else if (packName) {
      const cards = grantCardPackRewardState(rewardedState, packName, chooseRandom);
      rewardedState = cards.state;
      cardIds = [...cards.cards];
    } else {
      throw new ApiError(ApiErrorCode.InternalServerError, "Daily reward type is not implemented.");
    }
    // The parser applies `count` to each listed identity. Each selected array entry already
    // represents one authoritative inventory increment, including valid duplicate identities.
    added = { count: 1, cards: cardIds.join(";") };
  }

  calendar.claimReward = requestedDay;
  rewardedState = {
    ...rewardedState,
    dailyReward: calendar,
  };

  // Achievement group 16 is `AchievementClaimedRewards`. Advancing it inside this same
  // transition ensures the login reward and achievement progress either both commit or both
  // retry under the progression revision guard; a dropped HTTP response cannot count twice.
  const achievementResult = advanceAchievementState(rewardedState, 16, 1);
  // DailyRewardManager.ParseReward explicitly reads VipReward1/2 from this same response object
  // and adds both identities locally. Compose the independent paid-VIP benefit before MongoDB's
  // revision guard so Gold, achievement progress, cards, and both cursors commit or retry together.
  const vipResult = chooseRandom
    ? grantDailyVipCardsState(achievementResult.state, now, chooseRandom)
    : grantDailyVipCardsState(achievementResult.state, now);
  return {
    // Card, currency, achievement, optional VIP pair, and claim cursor are one logical write.
    // Composition helpers may increment their local revision, so normalize the final document
    // to exactly one monotonic step before mutateProgression performs its compare-and-swap.
    state: { ...vipResult.state, revision: state.revision + 1 },
    calendar,
    rewardDay: requestedDay,
    ...(goldAdded ? { goldAdded } : {}),
    ...(warBucksAdded ? { warBucksAdded } : {}),
    ...(ticketsAdded ? { ticketsAdded } : {}),
    ...(cardIds ? { cardIds } : {}),
    addedType: definition.Type,
    added,
    vipDailyCardReward: vipResult.reward,
  };
}

export function buildDailyRewardWireData(calendar: DailyRewardState, now: number): DailyRewardWireData {
  const validated = validatedDailyRewardState(calendar);
  return {
    month: validated.month,
    year: validated.year,
    canClaim: validated.canClaim,
    claimReward: validated.claimReward,
    nextDay: secondsUntilNextUtcDay(utcDate(now)),
    config: buildDailyRewardConfig(validated.year, validated.month),
  };
}

export function checkDailyReward(playerId: string): Promise<DailyRewardMutationResult> {
  return mutateProgression(playerId, checkDailyRewardState);
}

export function claimDailyReward(
  playerId: string,
  requestedDay: number,
  playerLevelIndex: number,
): Promise<DailyRewardMutationResult> {
  return mutateProgression(
    playerId,
    (state, now) => claimDailyRewardState(state, now, requestedDay, undefined, playerLevelIndex),
  );
}
