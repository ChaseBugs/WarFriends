import assert from "node:assert/strict";
import { createHmac } from "node:crypto";
import test from "node:test";
import { config } from "../config";
import { AccountType, League, PlayerStatus, SquadRank } from "../constants";
import { configurationResponse, normalizeEnvelope } from "../routes";
import { squadRankAuthority } from "../services/squadService";
import { providerForAccountType } from "../services/identityService";
import {
  buildExistingGameCenterPayload,
  buildGameCenterAccountPayload,
  identityHandlers,
} from "../handlers/identity";
import { authHandlers } from "../handlers/auth";
import { DbAction } from "../dbActions";
import { ApiErrorCode, apiError } from "../apiErrors";
import type { PlayerDocument } from "../db";
import { newPlayer, newSquad, ok } from "../dtos";
import {
  buildDatabasePlayer,
  buildPlayerData,
  buildPlayerStateResponse,
  createInitialProgression,
} from "../services/playerStateService";

function contractPlayer(): PlayerDocument {
  const player = newPlayer("player-contract", "ContractPlayer", AccountType.Facebook);
  player.facebookId = "12345678901234567";
  player.level = 7;
  player.experience = 4321;
  player.armyPower = 321;
  player.skill = 77;
  player.medalsBalance = 55;
  player.notificationSettings.maintenance = true;
  return {
    id: player.id,
    accountName: player.accountName,
    authToken: "session-token",
    accountType: player.accountType,
    leagueTier: player.leagueTier,
    armyPower: player.armyPower,
    experience: player.experience,
    squadPoints: player.squadPoints,
    squadName: player.squadName,
    player,
    progression: {
      ...createInitialProgression(1_700_000_000),
      gold: 100,
      warBucks: 20,
      levelExperience: 12,
    },
    createdAt: new Date("2023-11-14T22:13:20Z"),
    updatedAt: new Date("2023-11-14T22:13:20Z"),
  };
}
import {
  normalizeCountry,
  normalizeLocale,
  normalizePlayerName,
  notificationSettingsEqual,
  parseNotificationSettings,
} from "../services/playerSettingsService";
import { normalizeReportInput } from "../services/reportService";
import { reportHandlers } from "../handlers/reports";
import { challengeIsExpired, toClientMessage, type MessageDoc } from "../services/socialService";
import {
  currentDogTagCount,
  dogTagRefillPrice,
  maximumDogTagCount,
  materializeDogTags,
  refillDogTagsState,
  spendOneDogTagState,
  SUBSCRIPTION_DOG_TAG_REFILL_SECONDS,
} from "../services/economyService";
import { economyHandlers } from "../handlers/economy";
import {
  buildDailyRewardConfig,
  buildDailyRewardWireData,
  checkDailyRewardState,
  claimDailyRewardState,
  dailyRewardDefinitionForDay,
  dailyRewardGoldForDay,
  validatedDailyRewardState,
} from "../services/dailyRewardService";
import { dailyRewardHandlers } from "../handlers/dailyRewards";
import {
  assignmentStateFor,
  claimAssignmentState,
  ensureAssignmentsState,
  processAssignmentBufferState,
  recordPvpAssignmentProgressState,
  serializeAssignmentData,
  skipAssignmentState,
} from "../services/assignmentService";
import { assignmentHandlers } from "../handlers/assignments";
import {
  pvpExperienceAmounts,
  pvpGameReward,
  pvpLevelGoldAmount,
  pvpLevelFields,
  pvpWarBucksAmounts,
  winnerFromEndReason,
} from "../services/matchService";
import { buildDatabaseSquad, buildSquadWarsDivision } from "../services/squadWireService";
import { buildPlayerLeaderboardItem } from "../services/leaderboardService";
import {
  customCredentialHashNeedsUpgrade,
  hashCustomCredential,
  playerCredentialMatches,
} from "../services/authService";
import {
  loginRateLimitBlocked,
  loginRateLimitKey,
  loginRateLimitPolicy,
} from "../services/authRateLimitService";
import { containsProhibitedLanguage, moderationForms } from "../services/textModerationService";
import { buildFriendsInfoWire, requestedFacebookFriendIds } from "../services/friendService";

test("wire enums match the recovered 1.6.0 client", () => {
  assert.equal(AccountType.Guest, 0);
  assert.equal(AccountType.Facebook, 2);
  assert.equal(League.NoLeague, 0);
  assert.equal(League.Bronze3, 1);
  assert.equal(League.Champion, 16);
  assert.equal(PlayerStatus.InGame, 2);
  assert.equal(SquadRank.None, -1);
  assert.equal(SquadRank.Member, 0);
  assert.equal(SquadRank.Veteran, 1);
  assert.equal(SquadRank.Leader, 2);
  assert.equal(SquadRank.Coleader, 3);
});

test("squad authority does not rely on numeric enum ordering", () => {
  assert.ok(squadRankAuthority(SquadRank.Leader) > squadRankAuthority(SquadRank.Coleader));
  assert.ok(squadRankAuthority(SquadRank.Coleader) > squadRankAuthority(SquadRank.Veteran));
  assert.ok(squadRankAuthority(SquadRank.Veteran) > squadRankAuthority(SquadRank.Member));
});

test("request normalization accepts JSON envelopes and BestHTTP form fields", () => {
  assert.equal(normalizeEnvelope({ DbAction: 34 }).DbAction, 34);
  assert.equal(normalizeEnvelope({ requestId: "38", PlayerId: "p1", Token: "t1" }).DbAction, 38);
  assert.equal(normalizeEnvelope({}, "124").DbAction, 124);
  assert.ok(Number.isNaN(normalizeEnvelope({ requestId: "38" }, "124").DbAction));
});

test("configuration response matches the recovered raw client parser", () => {
  assert.equal(configurationResponse({ DbAction: 157, SheetConfiguraton: "prod" }), "success;prod;{}");
  assert.equal(configurationResponse({ DbAction: 157, SheetConfig: "bad;value" }), "success;badvalue;{}");
  assert.equal(configurationResponse({ DbAction: 157 }).split(";").length, 3);
});

test("JSON responses always pass the stock Result gate before action parsing", () => {
  assert.deepEqual(ok(DbAction.GetPlayerInfo, { Value: 7 }), {
    DbAction: DbAction.GetPlayerInfo,
    Result: 1,
    Value: 7,
  });
  assert.deepEqual(apiError(ApiErrorCode.InternalServerError, "failed"), {
    Result: 99_996,
    Code: 99_996,
    Message: "failed",
  });
  assert.ok(ApiErrorCode.RequestNotAuthorized > 10);
  assert.ok(ApiErrorCode.InvalidClientVersion > 10);
  assert.ok(ApiErrorCode.PlayerNotFound > 10);
});

test("account types map only to their matching external identity provider", () => {
  assert.equal(providerForAccountType(AccountType.Guest), null);
  assert.equal(providerForAccountType(AccountType.Facebook), "facebook");
  assert.equal(providerForAccountType(AccountType.GooglePlay), "googlePlay");
  assert.equal(providerForAccountType(AccountType.GameCenter), "gameCenter");
});

test("identity mutations require auth while pre-login existence checks remain open", () => {
  assert.equal(identityHandlers[DbAction.CreateGcAccount]?.requiresAuth, false);
  // The stock 1.6.0 account chooser sends LoginToCustomAccount, not action 53. Keeping
  // SwitchToFacebook unregistered prevents a response the client has no account parser for.
  assert.equal(identityHandlers[DbAction.SwitchToFacebook], undefined);
  assert.equal(identityHandlers[DbAction.AddFacebook]?.requiresAuth, true);
  assert.equal(identityHandlers[DbAction.RemoveGooglePlay]?.requiresAuth, true);
  assert.equal(identityHandlers[DbAction.RemoveOrUpdateGC]?.requiresAuth, true);
  assert.equal(identityHandlers[DbAction.ExistFBAccount]?.requiresAuth, false);
  assert.equal(identityHandlers[DbAction.TutorialCheckGPGSAccount]?.requiresAuth, false);
});

test("Game Center account creation matches the shared stock account parser", () => {
  const doc = contractPlayer();
  doc.accountType = AccountType.GameCenter;
  doc.gameCenterId = "gc-player-1";
  doc.player.accountType = AccountType.GameCenter;
  doc.player.gameCenterId = "gc-player-1";
  const payload = buildGameCenterAccountPayload({
    doc,
    player: doc.player,
    authToken: "new-session-token",
  }, "gc-platform-credential");

  assert.equal(payload.AccountType, AccountType.GameCenter);
  assert.equal(payload.Token, "new-session-token");
  assert.equal(payload.Password, "gc-platform-credential");
  assert.ok(payload.PlayerData);
  assert.deepEqual((payload.Player as Record<string, unknown>).GameCenterId, { S: "gc-player-1" });
});

test("duplicate Game Center creation returns the existing public profile for UserExistsDialog", () => {
  const payload = buildExistingGameCenterPayload(contractPlayer(), "gc-existing");
  assert.equal(payload.Result, 15400);
  assert.equal(payload.Code, 15400);
  assert.equal(payload.GameCenterId, "gc-existing");
  const publicData = payload.PlayerData as Record<string, unknown>;
  assert.deepEqual(publicData.PlayerId, { S: "player-contract" });
  assert.deepEqual(publicData.PlayerName, { S: "ContractPlayer" });
  assert.deepEqual(publicData.Level, { N: "7" });
  assert.equal(publicData.Token, undefined);
});

test("player data uses the recovered DynamoDB attribute wire format", () => {
  const data = buildPlayerData(contractPlayer());
  assert.deepEqual(data.Gold, { N: "100" });
  assert.deepEqual(data.WarBucks, { N: "20" });
  assert.deepEqual(data.Level, { N: "7" });
  assert.deepEqual(data.Experience, { N: "4321" });
  assert.deepEqual(data.DogTagLastUpdate, { N: "1700000000" });
  assert.deepEqual(data.DogTagSeconds, { N: "4500" });
  assert.deepEqual(data.DogTagMax, { N: "4500" });
  assert.equal(JSON.parse((data.Settings as { S: string }).S).maintenance, true);
  const inventory = JSON.parse((data.InventoryData as { S: string }).S);
  const levelManager = JSON.parse((data.LevelManagerData as { S: string }).S);
  assert.deepEqual(inventory.slots["0"], {
    name: "Google2u.AssaultRifle_AK47",
    weaponIndex: 1,
  });
  assert.equal(levelManager.savedWeapons["Google2u.AssaultRifle_AK47"].bought, true);
  const starter = JSON.parse((data.StarterAssignmentsData as { S: string }).S);
  assert.equal(starter.deadline, 1_700_604_800);
  assert.deepEqual(starter.assignments, {});

  const corruptStarter = contractPlayer();
  corruptStarter.progression!.starterAssignments!.deadline = Number.POSITIVE_INFINITY;
  assert.throws(
    () => buildPlayerData(corruptStarter),
    /Starter assignment deadline is invalid/,
  );
});

test("player data rejects corrupt core balances while preserving chargeback debt", () => {
  const debt = contractPlayer();
  debt.progression!.gold = -25;
  debt.progression!.warBucks = -500;
  const wire = buildPlayerData(debt);
  assert.deepEqual(wire.Gold, { N: "-25" });
  assert.deepEqual(wire.WarBucks, { N: "-500" });

  const corruptGold = contractPlayer();
  corruptGold.progression!.gold = Number.NaN;
  assert.throws(() => buildPlayerData(corruptGold), /Stored Gold balance is invalid/);

  const corruptTickets = contractPlayer();
  corruptTickets.progression!.tickets = -1;
  assert.throws(() => buildPlayerData(corruptTickets), /Stored Tickets balance is invalid/);

  const corruptExperience = contractPlayer();
  corruptExperience.progression!.levelExperience = 1.5;
  assert.throws(() => buildPlayerData(corruptExperience), /Stored level experience balance is invalid/);
});

test("dog-tag state uses accumulated seconds and recovered 900-second balancing", () => {
  const initial = createInitialProgression(1_000, 900, 5);
  assert.equal(initial.dogTagSeconds, 4_500);
  assert.equal(initial.dogTagMax, 4_500);
  assert.equal(initial.dogTagRefillSeconds, 900);
  assert.equal(currentDogTagCount(initial), 5);

  const partiallyEmpty = { ...initial, dogTagSeconds: 1_800, dogTagLastUpdate: 1_000 };
  const regenerated = materializeDogTags(partiallyEmpty, 1_450);
  assert.equal(regenerated.dogTagSeconds, 2_250);
  assert.equal(currentDogTagCount(regenerated), 2);

  // Dog-tag capacity is a paid-VIP benefit. A non-finite imported deadline must not act as a
  // permanent membership merely because JavaScript considers Infinity greater than every time.
  assert.throws(
    () => currentDogTagCount({ ...initial, vipExpiration: Number.POSITIVE_INFINITY }),
    /Stored VIP expiration is invalid/,
  );
});

test("dog-tag authority rejects malformed tuples and preserves bounded VIP debt", () => {
  const initial = createInitialProgression(1_000, 900, 5);
  const debt = { ...initial, dogTagSeconds: -1_800 };
  assert.equal(currentDogTagCount(debt), 0);

  assert.throws(
    () => materializeDogTags({ ...initial, dogTagSeconds: -1_801 }, 1_000),
    /Stored dog-tag authority is invalid/,
  );
  assert.throws(
    () => materializeDogTags({ ...initial, dogTagMax: 4_501 }, 1_000),
    /Stored dog-tag authority is invalid/,
  );
  assert.throws(
    () => materializeDogTags({ ...initial, dogTagLastUpdate: 1_001 }, 1_000),
    /Stored dog-tag time authority is invalid/,
  );

  const futureBoot = contractPlayer();
  futureBoot.progression!.dogTagLastUpdate = 1_700_000_001;
  assert.throws(
    () => buildPlayerData(futureBoot, 1_700_000_000),
    /Stored dog-tag time authority is invalid/,
  );
});

test("subscription refills dog tags every recovered 450 seconds between lock and expiry", () => {
  assert.equal(SUBSCRIPTION_DOG_TAG_REFILL_SECONDS, 450);
  const initial = {
    ...createInitialProgression(1_000),
    dogTagSeconds: 0,
    subscription: {
      type: "subscription1" as const,
      subscribeSince: 1_000,
      expireTime: 2_000,
      dogTagTimerLock: 1_000,
    },
  };
  const beforeFirstRefill = materializeDogTags(initial, 1_449);
  assert.equal(beforeFirstRefill.dogTagSeconds, 898);
  assert.equal(currentDogTagCount(beforeFirstRefill), 0);
  const firstRefill = materializeDogTags(initial, 1_450);
  assert.equal(firstRefill.dogTagSeconds, 900);
  assert.equal(currentDogTagCount(firstRefill), 1);

  // A future lock preserves progress already earned at the normal rate before purchase.
  const locked = materializeDogTags({
    ...initial,
    subscription: { ...initial.subscription, dogTagTimerLock: 1_300 },
  }, 1_600);
  assert.equal(locked.dogTagSeconds, 900);
  assert.equal(currentDogTagCount(locked), 1);

  // When reconnecting after expiry, only the historical active interval is accelerated.
  const afterExpiry = materializeDogTags(initial, 2_450);
  assert.equal(afterExpiry.dogTagSeconds, 2_450);
  assert.equal(currentDogTagCount(afterExpiry), 2);

  assert.throws(
    () => materializeDogTags({
      ...initial,
      subscription: { ...initial.subscription, expireTime: Number.POSITIVE_INFINITY },
    }, 1_450),
    /Subscription expiry is invalid/,
  );
  assert.throws(
    () => materializeDogTags({
      ...initial,
      subscription: { ...initial.subscription, dogTagTimerLock: Number.NaN },
    }, 1_450),
    /Subscription dog-tag lock is invalid/,
  );
});

test("dog-tag spend and refill transitions preserve partial time and charge server price", () => {
  const state = {
    ...createInitialProgression(1_000, 900, 5),
    gold: 100,
    dogTagSeconds: 1_800,
  };
  const spent = spendOneDogTagState(state, 1_100);
  assert.equal(spent.state.dogTagSeconds, 1_000);
  assert.equal(spent.currentDogTags, 1);
  assert.equal(spent.state.revision, 1);

  assert.equal(dogTagRefillPrice(1), 33);
  const refilled = refillDogTagsState(spent.state, 1_100);
  assert.equal(refilled.goldSpent, 33);
  assert.equal(refilled.state.gold, 67);
  assert.equal(refilled.state.dogTagSeconds, 4_500);
  assert.equal(refilled.currentDogTags, 5);
  assert.equal(economyHandlers[DbAction.PayOneDogTag]?.requiresAuth, true);
  assert.equal(economyHandlers[DbAction.RefillDogtags]?.requiresAuth, true);
});

test("dog-tag transitions reject empty spends, full refills, and insufficient gold", () => {
  const initial = createInitialProgression(1_000, 900, 5);
  assert.throws(() => spendOneDogTagState({ ...initial, dogTagSeconds: 0 }, 1_000));
  assert.throws(() => refillDogTagsState(initial, 1_000));
  assert.throws(() => refillDogTagsState({ ...initial, dogTagSeconds: 0, gold: 0 }, 1_000));
});

test("active VIP adds two virtual dog tags without rewriting or stacking the base cap", () => {
  const now = 1_000;
  const initial = {
    ...createInitialProgression(now, 900, 5),
    gold: 100,
    vipExpiration: now + 3_600,
  };
  assert.equal(initial.dogTagMax, 4_500);
  assert.equal(currentDogTagCount(initial), 7);
  assert.equal(maximumDogTagCount(initial), 7);

  // Each spend reduces the server's base time credit. Once both virtual tags are consumed,
  // the stored value is two intervals below zero and cannot be replayed as fresh VIP energy.
  let state = { ...initial, dogTagSeconds: 0 };
  const first = spendOneDogTagState(state, now);
  assert.equal(first.state.dogTagSeconds, -900);
  assert.equal(first.currentDogTags, 1);
  const second = spendOneDogTagState(first.state, now);
  assert.equal(second.state.dogTagSeconds, -1_800);
  assert.equal(second.currentDogTags, 0);
  assert.throws(() => spendOneDogTagState(second.state, now));

  // Renewal extends the same entitlement deadline and therefore still exposes only two
  // virtual capacity slots; the count is derived from activity, never accumulated in state.
  state = { ...initial, vipExpiration: now + 86_400 };
  assert.equal(maximumDogTagCount(state), 7);
});

test("VIP dog-tag debt regenerates with time and disappears cleanly at expiry", () => {
  const now = 1_000;
  const active = {
    ...createInitialProgression(now, 900, 5),
    gold: 100,
    dogTagSeconds: -1_800,
    vipExpiration: now + 1_000,
  };
  const regenerated = materializeDogTags(active, now + 900);
  assert.equal(regenerated.dogTagSeconds, -900);
  assert.equal(currentDogTagCount(regenerated), 1);

  const expired = materializeDogTags(regenerated, now + 1_001);
  assert.equal(maximumDogTagCount(expired), 5);
  assert.equal(currentDogTagCount(expired), 0);

  // RefillAll stores only the normal base cap. The stock client adds the virtual two when
  // active, producing seven visible tags without making them permanent after expiration.
  const refilled = refillDogTagsState({ ...active, dogTagSeconds: 0 }, now);
  assert.equal(refilled.state.dogTagSeconds, 4_500);
  assert.equal(refilled.state.dogTagMax, 4_500);
  assert.equal(refilled.currentDogTags, 7);
  assert.equal(refilled.goldSpent, 31);
});

test("daily reward checks unlock at most one ordered claim per UTC login day", () => {
  const noon = Date.parse("2026-07-19T12:00:00Z") / 1000;
  const initial = createInitialProgression(noon);
  const firstCheck = checkDailyRewardState(initial, noon);
  assert.deepEqual(firstCheck.calendar, {
    year: 2026,
    month: 7,
    canClaim: 1,
    claimReward: 0,
    lastCheckDay: "2026-07-19",
  });

  const repeatedCheck = checkDailyRewardState(firstCheck.state, noon + 60);
  assert.equal(repeatedCheck.calendar.canClaim, 1);
  assert.equal(repeatedCheck.state, firstCheck.state);
  assert.equal(repeatedCheck.state.revision, firstCheck.state.revision);

  const claim = claimDailyRewardState(repeatedCheck.state, noon + 120, 1);
  assert.equal(claim.calendar.claimReward, 1);
  assert.equal(claim.goldAdded, dailyRewardGoldForDay(1));
  assert.equal(claim.state.gold, dailyRewardGoldForDay(1));

  const nextDayCheck = checkDailyRewardState(claim.state, noon + 86_400);
  assert.equal(nextDayCheck.calendar.canClaim, 2);
  assert.equal(nextDayCheck.calendar.claimReward, 1);
  assert.notEqual(nextDayCheck.state, claim.state);
  assert.equal(nextDayCheck.state.revision, claim.state.revision + 1);
});

test("daily reward month rollover remains a durable transition after same-day no-op checks", () => {
  const july = Date.parse("2026-07-31T12:00:00Z") / 1000;
  const first = checkDailyRewardState(createInitialProgression(july), july);
  const repeated = checkDailyRewardState(first.state, july + 60);
  const august = checkDailyRewardState(first.state, Date.parse("2026-08-01T12:00:00Z") / 1000);

  assert.equal(repeated.state, first.state);
  assert.notEqual(august.state, first.state);
  assert.deepEqual(august.calendar, {
    year: 2026,
    month: 8,
    canClaim: 1,
    claimReward: 0,
    lastCheckDay: "2026-08-01",
  });
});

test("daily reward claims reject replays and locked future indexes", () => {
  const now = Date.parse("2026-07-19T12:00:00Z") / 1000;
  const available = checkDailyRewardState(createInitialProgression(now), now);
  const claimed = claimDailyRewardState(available.state, now, 1);

  assert.throws(
    () => claimDailyRewardState(claimed.state, now, 1),
    (error: unknown) => error instanceof Error && "code" in error && error.code === 1000002,
  );
  assert.throws(
    () => claimDailyRewardState(claimed.state, now, 2),
    (error: unknown) => error instanceof Error && "code" in error && error.code === 1000001,
  );
});

test("daily reward authority rejects corrupt current-month cursors and date markers", () => {
  const now = Date.parse("2026-07-19T12:00:00Z") / 1000;
  const valid = {
    year: 2026,
    month: 7,
    canClaim: 2,
    claimReward: 1,
    lastCheckDay: "2026-07-19",
  };
  assert.deepEqual(validatedDailyRewardState(valid), valid);
  for (const canClaim of [Number.NaN, Number.POSITIVE_INFINITY, -1, 1.5, 32]) {
    assert.throws(
      () => checkDailyRewardState({ ...createInitialProgression(now), dailyReward: { ...valid, canClaim } }, now),
      /Daily reward cursors are invalid/,
    );
  }
  for (const claimReward of [Number.NaN, Number.POSITIVE_INFINITY, -1, 1.5, 3]) {
    assert.throws(
      () => claimDailyRewardState({
        ...createInitialProgression(now),
        dailyReward: { ...valid, claimReward },
      }, now, 2),
      /Daily reward cursors are invalid/,
    );
  }
  for (const lastCheckDay of ["2026-07-00", "2026-07-32", "2026-08-01", "not-a-date"]) {
    assert.throws(
      () => buildDailyRewardWireData({ ...valid, lastCheckDay }, now),
      /Daily reward last-check day is invalid/,
    );
  }

  // An expired calendar has no claim authority in the new month. Discard it rather than making a
  // repaired player wait for an operator migration of data that can no longer grant anything.
  const rollover = checkDailyRewardState({
    ...createInitialProgression(now),
    dailyReward: {
      year: 2026,
      month: 6,
      canClaim: Number.POSITIVE_INFINITY,
      claimReward: Number.POSITIVE_INFINITY,
      lastCheckDay: "broken",
    },
  }, now);
  assert.deepEqual(rollover.calendar, {
    year: 2026,
    month: 7,
    canClaim: 1,
    claimReward: 0,
    lastCheckDay: "2026-07-19",
  });
});

test("offline daily calendar exposes every implemented currency and card parser branch", () => {
  assert.equal(dailyRewardDefinitionForDay(1).Type, 1);
  assert.deepEqual(dailyRewardDefinitionForDay(2), { Type: 0, Double: 0, Count: 1_000, Param: "" });
  assert.deepEqual(dailyRewardDefinitionForDay(3), { Type: 2, Double: 0, Count: 2, Param: "" });
  assert.deepEqual(dailyRewardDefinitionForDay(4), { Type: 15, Double: 0, Count: 1, Param: "" });
  assert.deepEqual(dailyRewardDefinitionForDay(5), { Type: 3, Double: 0, Count: 1, Param: "" });
  assert.deepEqual(dailyRewardDefinitionForDay(6), { Type: 4, Double: 0, Count: 1, Param: "" });
  assert.equal(dailyRewardDefinitionForDay(7).Type, 1);
  assert.equal(dailyRewardDefinitionForDay(14).Type, 11);
  assert.equal(dailyRewardDefinitionForDay(21).Type, 12);
  assert.equal(dailyRewardDefinitionForDay(28).Type, 13);
});

test("daily claims atomically deliver WarBucks, Tickets, loose cards, and card packs", () => {
  const now = Date.parse("2026-07-19T12:00:00Z") / 1000;
  const calendar = (claimReward: number, canClaim: number) => ({
    year: 2026,
    month: 7,
    canClaim,
    claimReward,
    lastCheckDay: "2026-07-19",
  });

  const warBucksState = { ...createInitialProgression(now), dailyReward: calendar(1, 2) };
  const warBucks = claimDailyRewardState(warBucksState, now, 2);
  assert.equal(warBucks.addedType, 0);
  assert.equal(warBucks.added, 1_000);
  assert.equal(warBucks.state.warBucks, 1_000);

  const ticketsState = { ...createInitialProgression(now), dailyReward: calendar(3, 4) };
  const tickets = claimDailyRewardState(ticketsState, now, 4);
  assert.equal(tickets.addedType, 15);
  assert.equal(tickets.state.tickets, 1);

  const looseState = { ...createInitialProgression(now), dailyReward: calendar(2, 3) };
  const loose = claimDailyRewardState(looseState, now, 3, () => 0, 5);
  assert.equal(loose.addedType, 2);
  assert.equal(loose.cardIds?.length, 2);
  assert.equal((loose.added as { count: number }).count, 1);
  assert.equal((loose.added as { cards: string }).cards.split(";").length, 2);
  assert.equal(
    Object.values(loose.state.cardInventory?.cardData ?? {}).reduce((sum, card) => sum + card.amount, 0),
    2,
  );

  const packState = { ...createInitialProgression(now), dailyReward: calendar(13, 14) };
  const pack = claimDailyRewardState(packState, now, 14, () => 0, 5);
  assert.equal(pack.addedType, 11);
  assert.equal(pack.cardIds?.length, 10);
  assert.equal((pack.added as { cards: string }).cards.split(";").length, 10);
  assert.equal(
    Object.values(pack.state.cardInventory?.cardData ?? {}).reduce((sum, card) => sum + card.amount, 0),
    10,
  );
  assert.equal(pack.state.revision, packState.revision + 1);
});

test("daily calendar claim composes the active VIP card pair into the same state transition", () => {
  const now = Date.parse("2026-07-19T12:00:00Z") / 1000;
  const active = {
    ...createInitialProgression(now),
    vipStart: now - 60,
    vipExpiration: now + 3_600,
  };
  const available = checkDailyRewardState(active, now);
  const choices = [0, 0, 9_999, 0];
  const claimed = claimDailyRewardState(available.state, now, 1, (upperBound) => {
    const value = choices.shift();
    assert.notEqual(value, undefined);
    assert.ok(value! < upperBound);
    return value!;
  });

  assert.equal(claimed.vipDailyCardReward?.cardIds.length, 2);
  assert.equal(claimed.vipDailyCardReward?.dayKey, "2026-07-19");
  for (const id of claimed.vipDailyCardReward!.cardIds) {
    assert.equal(claimed.state.cardInventory?.cardData[id]?.amount, 1);
  }
  assert.equal(claimed.state.dailyReward?.claimReward, 1);
  assert.equal(claimed.state.gold, dailyRewardGoldForDay(1));
});

test("daily reward wire data matches the recovered Unity calendar parser", () => {
  const now = Date.parse("2026-02-10T23:59:00Z") / 1000;
  const checked = checkDailyRewardState(createInitialProgression(now), now);
  const wire = buildDailyRewardWireData(checked.calendar, now);
  const monthConfig = buildDailyRewardConfig(2026, 2);

  assert.equal(wire.month, 2);
  assert.equal(wire.year, 2026);
  assert.equal(wire.nextDay, 60);
  assert.equal(Object.keys(monthConfig).length, 28);
  assert.deepEqual(monthConfig.Day1, {
    Type: 1,
    Double: 0,
    Count: dailyRewardGoldForDay(1),
    Param: "",
  });
  assert.equal(monthConfig.Day14.Type, 11);
  assert.equal(monthConfig.Day21.Type, 12);
  assert.equal(monthConfig.Day28.Type, 13);
  assert.equal(dailyRewardHandlers[DbAction.CheckDailyReward]?.requiresAuth, true);
  assert.equal(dailyRewardHandlers[DbAction.ClaimDailyReward]?.requiresAuth, true);
});

test("daily assignments use the recovered three-difficulty PvP contract and UTC reset", () => {
  const now = Date.parse("2026-07-19T12:00:00Z") / 1000;
  const result = ensureAssignmentsState(createInitialProgression(now), now);

  assert.deepEqual(result.assignments.assignments.map((assignment) => [assignment.id, assignment.target]), [
    [5, 2_000],
    [8, 6],
    [7, 3],
  ]);
  assert.equal(result.assignments.tomorrow, Date.parse("2026-07-20T00:00:00Z") / 1000);
  assert.equal(result.assignments.megaReward, 0);
  assert.equal(result.assignments.skipUsed, false);
  assert.equal(JSON.parse(serializeAssignmentData(result.assignments)).dayKey, undefined);
});

test("confirmed PvP progress completes only server-derived assignment counters", () => {
  const now = Date.parse("2026-07-19T12:00:00Z") / 1000;
  let result = ensureAssignmentsState(createInitialProgression(now), now);
  result = recordPvpAssignmentProgressState(result.state, now, false);
  result = recordPvpAssignmentProgressState(result.state, now, true);

  const [score, played, wins] = result.assignments.assignments;
  assert.equal(score.done, true);
  assert.equal(score.completeFract, 1);
  assert.equal(played.completeFract, 2 / 6);
  assert.equal(wins.completeFract, 1 / 3);
});

test("assignment claim and skip mutations enforce completion, reward, and replay rules", () => {
  const now = Date.parse("2026-07-19T12:00:00Z") / 1000;
  const initial = ensureAssignmentsState(createInitialProgression(now), now);
  assert.throws(
    () => claimAssignmentState(initial.state, now, 5, 2),
    (error: unknown) => error instanceof Error && "code" in error && error.code === 11201,
  );

  let completed = recordPvpAssignmentProgressState(initial.state, now, false);
  completed = recordPvpAssignmentProgressState(completed.state, now, false);
  assert.throws(
    () => claimAssignmentState(completed.state, now, 5, 5),
    (error: unknown) => error instanceof Error && "code" in error && error.code === 11203,
  );

  const claim = claimAssignmentState(completed.state, now, 5, 2);
  assert.equal(claim.state.gold, 2);
  assert.equal(claim.assignments.completed, 1);
  assert.equal(claim.assignments.megaReward, 1);
  assert.throws(
    () => claimAssignmentState(claim.state, now, 5, 2),
    (error: unknown) => error instanceof Error && "code" in error && error.code === 11201,
  );

  const skipped = skipAssignmentState(claim.state, now, 1);
  assert.equal(skipped.assignments.skipUsed, true);
  assert.throws(() => skipAssignmentState(skipped.state, now, 2));
});

test("assignment RequestBuffer result is cached by BufferId without duplicate gold", () => {
  const now = Date.parse("2026-07-19T12:00:00Z") / 1000;
  let progression = ensureAssignmentsState(createInitialProgression(now), now).state;
  progression = recordPvpAssignmentProgressState(progression, now, false).state;
  progression = recordPvpAssignmentProgressState(progression, now, true).state;

  const request = [{ action: DbAction.ClaimAssignment, data: JSON.stringify({ AssignmentId: 5, Reward: 2 }) }];
  const first = processAssignmentBufferState(progression, now, "buffer-1", request);
  assert.equal(first.state.gold, 2);
  assert.equal(JSON.parse(first.requestsResults)[0].Result, 1);
  assert.equal(first.replayed, false);

  const replay = processAssignmentBufferState(first.state, now + 1, "buffer-1", request);
  assert.equal(replay.state, first.state);
  assert.equal(replay.state.gold, 2);
  assert.equal(replay.requestsResults, first.requestsResults);
  assert.equal(replay.replayed, true);
  assert.equal(assignmentHandlers[DbAction.SendRequestBuffer]?.requiresAuth, true);
  assert.equal(assignmentHandlers[DbAction.GetNewAssignments]?.requiresAuth, true);
});

test("PvP EndReason inference agrees from winner and loser perspectives", () => {
  const participants = ["master", "client"];
  assert.equal(winnerFromEndReason(participants, "master", 2), "master");
  assert.equal(winnerFromEndReason(participants, "client", 1), "master");
  assert.equal(winnerFromEndReason(participants, "master", 5), "client");
  assert.equal(winnerFromEndReason(participants, "outsider", 2), null);
  assert.equal(winnerFromEndReason(participants, "master", 10), null);
});

test("PvP GameReward keeps the stock result parser non-null and exposes only settled rewards", () => {
  assert.deepEqual(pvpGameReward(true, 30, 5, false, undefined, 800), {
    Warbucks: { BattleRewards: 800, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 30, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 5, League: 0, offerMult: 1 },
    IsVip: false,
  });
  assert.deepEqual(pvpGameReward(true, 10), {
    Warbucks: { BattleRewards: 0, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 10, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 0, League: 0, offerMult: 1 },
    IsVip: false,
  });
  assert.deepEqual(pvpGameReward(false, 30, 5, true), {
    Warbucks: { BattleRewards: 0, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 0, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 0, League: 0, offerMult: 1 },
    IsVip: false,
  });
});

test("PvP VIP receipts expose base XP and WarBucks while settlement persists exact bonuses", () => {
  assert.deepEqual(pvpExperienceAmounts(true, false), { baseExperience: 30, experience: 30 });
  assert.deepEqual(pvpExperienceAmounts(false, false), { baseExperience: 10, experience: 10 });
  assert.deepEqual(pvpExperienceAmounts(true, true), { baseExperience: 30, experience: 45 });
  assert.deepEqual(pvpExperienceAmounts(false, true), { baseExperience: 10, experience: 15 });
  assert.equal(pvpLevelGoldAmount(7, false), 7);
  assert.equal(pvpLevelGoldAmount(7, true), 14);
  assert.throws(() => pvpLevelGoldAmount(-1, true), /invalid/);
  assert.deepEqual(pvpWarBucksAmounts(true, false), { baseWarBucks: 800, warBucks: 800 });
  assert.deepEqual(pvpWarBucksAmounts(false, false), { baseWarBucks: 400, warBucks: 400 });
  assert.deepEqual(pvpWarBucksAmounts(true, true), { baseWarBucks: 800, warBucks: 1200 });
  assert.deepEqual(pvpWarBucksAmounts(false, true), { baseWarBucks: 400, warBucks: 600 });
  assert.deepEqual(pvpGameReward(true, 30, 7, true, undefined, 800, 700, 1250), {
    Warbucks: { BattleRewards: 800, ExtraRewards: 0, Winstreak: 700, League: 1250, offerMult: 1 },
    Xp: { BattleRewards: 30, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 7, League: 0, offerMult: 1 },
    IsVip: true,
  });
  assert.deepEqual(pvpGameReward(true, 30, 7, true, '{"HEAD_CLOWN-VIP":"1"}', 800), {
    Warbucks: { BattleRewards: 800, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 30, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 7, League: 0, offerMult: 1 },
    IsVip: true,
    NewVisuals: '{"HEAD_CLOWN-VIP":"1"}',
  });
  assert.equal(pvpGameReward(false, 30, 7, true, "{}").NewVisuals, undefined);
});

test("PvP Level is emitted only when the server actually advances the level", () => {
  assert.deepEqual(pvpLevelFields(4, 4, 120), { LevelExperience: 120 });
  assert.deepEqual(pvpLevelFields(4, 5, 3), { LevelExperience: 3, Level: 5 });
});

test("database player snapshots use the field names and wrappers parsed by Unity", () => {
  const player = buildDatabasePlayer(contractPlayer());
  assert.deepEqual(player.Id, { S: "player-contract" });
  assert.deepEqual(player.Name, { S: "ContractPlayer" });
  assert.deepEqual(player.Level, { N: "7" });
  assert.deepEqual(player.FacebookId, { S: "12345678901234567" });
  assert.deepEqual(player.EligibleLeagueId, { N: String(League.Bronze3) });
  assert.equal(player.id, undefined);
});

test("squad snapshots use the recovered AANECPGDMGM field contract", () => {
  const squad = newSquad("Alpha Team", "founder");
  squad.description = "Ready for battle";
  squad.requiredMedals = 25;
  squad.members.push({
    playerId: "founder",
    name: "Founder",
    rank: SquadRank.Leader,
    squadPoints: 10,
    joinedAt: 1,
    lastSeenChatTimestamp: 0,
  });
  const wire = buildDatabaseSquad(squad);
  assert.equal(wire.Id, "Alpha Team");
  assert.equal(wire.Message, "Ready for battle");
  assert.equal(wire.Size, 1);
  assert.equal(wire.SkillRequirement, 25);
  assert.equal(wire.name, undefined);
});

test("Squad Wars division uses the CLBPOGIEGAN cache and item fields", () => {
  const alpha = newSquad("Alpha", "alpha-leader");
  alpha.squadPoints = 100;
  const bravo = newSquad("Bravo", "bravo-leader");
  bravo.squadPoints = 80;
  const wire = buildSquadWarsDivision("4-gold", "reconstructed-4-gold", [alpha, bravo]);
  const items = wire.Items as Record<string, unknown>[];

  assert.equal(wire.LeagueId, "4-gold");
  assert.equal(wire.SquadWarsId, "reconstructed-4-gold");
  assert.equal(items[0]?.Id, "Alpha");
  assert.equal(items[0]?.RoundId, "4-gold");
  assert.equal(items[0]?.Position, 1);
  assert.equal(items[1]?.Position, 2);
});

test("experience leaderboard items use the FHIPGDADNFG field contract", () => {
  const wire = buildPlayerLeaderboardItem(contractPlayer(), 4);
  assert.deepEqual(wire.PlayerId, { S: "player-contract" });
  assert.deepEqual(wire.PlayerName, { S: "ContractPlayer" });
  assert.deepEqual(wire.Experience, { N: "4321" });
  assert.deepEqual(wire.Position, { N: "4" });
  assert.equal(wire.Id, undefined);
});

test("boot state contains every field read unconditionally by GetPlayerData", () => {
  const response = buildPlayerStateResponse(contractPlayer(), 1_700_000_100);
  assert.equal(response.Time, 1_700_000_100);
  assert.equal(response.Skill, 77);
  assert.equal(response.MedalsBalance, 55);
  assert.ok(response.PlayerData);
});

test("custom login returns distinct session and provider credentials", async () => {
  const entry = authHandlers[DbAction.LoginToCustomAccount];
  const response = await entry.handler({
    player: contractPlayer(),
    req: {
      DbAction: DbAction.LoginToCustomAccount,
      AccountType: AccountType.Facebook,
      Password: "facebook-credential",
    },
  });
  assert.equal(response.AccountType, AccountType.Facebook);
  assert.equal(response.Token, "session-token");
  assert.equal(response.Password, "facebook-credential");
  assert.ok(response.PlayerData);
  assert.deepEqual((response.Player as Record<string, unknown>).Id, { S: "player-contract" });
});

test("custom password login works while gameplay routes still require the session token", async () => {
  const player = contractPlayer();
  const password = "correct-horse-battery-staple";
  player.authToken = "rotated-session-token";
  player.authTokenHash = createHmac("sha256", config.authSecret)
    .update(`custom:${player.id}:${password}`)
    .digest("hex");

  assert.equal(await playerCredentialMatches(player, player.authToken, false), true);
  assert.equal(await playerCredentialMatches(player, password, false), false);
  assert.equal(await playerCredentialMatches(player, password, true), true);
  assert.equal(await playerCredentialMatches(player, "wrong-password", true), false);
  assert.equal(customCredentialHashNeedsUpgrade(player.authTokenHash), true);
});

test("new custom passwords use salted memory-hard hashes", async () => {
  const player = contractPlayer();
  const password = "correct-horse-battery-staple";
  const first = await hashCustomCredential(player.id, password);
  const second = await hashCustomCredential(player.id, password);
  assert.match(first, /^scrypt\$v1\$16384\$8\$1\$[0-9a-f]{32}\$[0-9a-f]{64}$/u);
  assert.notEqual(first, second);
  player.authTokenHash = first;
  assert.equal(customCredentialHashNeedsUpgrade(first), false);
  assert.equal(await playerCredentialMatches(player, password, true), true);
  assert.equal(await playerCredentialMatches(player, "wrong-password", true), false);
  assert.equal(await playerCredentialMatches(player, password, false), false);
});

test("durable login throttling hides identity keys and enforces a real cooldown", () => {
  const publicId = "public-player-or-provider-id";
  const key = loginRateLimitKey(publicId);
  assert.equal(key.length, 64);
  assert.equal(key.includes(publicId), false);
  assert.equal(loginRateLimitKey(publicId), key);
  assert.notEqual(loginRateLimitKey(`${publicId}-other`), key);

  const now = new Date("2026-07-20T00:00:00.000Z");
  assert.equal(loginRateLimitBlocked(null, now), false);
  assert.equal(loginRateLimitBlocked({ lockedUntil: new Date(now.getTime() - 1) }, now), false);
  assert.equal(loginRateLimitBlocked({ lockedUntil: new Date(now.getTime() + 1) }, now), true);

  const policy = loginRateLimitPolicy();
  assert.equal(policy.maxAttempts >= 2, true);
  assert.equal(policy.windowMilliseconds >= 60_000, true);
  assert.equal(policy.lockoutMilliseconds >= 60_000, true);
});

test("GetFriendsInfo preserves signed Int64 hashes and exact recovered result groups", () => {
  const ids = requestedFacebookFriendIds({
    DbAction: DbAction.GetFriendsInfo,
    Count: "6",
    Friend0: "9223372036854775807",
    Friend1: "-9223372036854775808",
    Friend2: "9223372036854775807",
    Friend3: "-1",
    Friend4: "not-a-number",
    Friend5: " 42 ",
  });
  assert.deepEqual(ids, ["9223372036854775807", "-9223372036854775808", "42"]);

  const friend = contractPlayer();
  friend.id = "facebook-friend";
  friend.player.id = friend.id;
  const mate = contractPlayer();
  mate.id = "squad-mate";
  mate.player.id = mate.id;
  const result = buildFriendsInfoWire([friend, friend], [friend, mate, mate]);
  assert.deepEqual(result.Friends.map((item) => (item.Id as { S: string }).S), ["facebook-friend"]);
  assert.deepEqual(result.SquadMates.map((item) => (item.Id as { S: string }).S), ["squad-mate"]);
  assert.equal((result as unknown as Record<string, unknown>).facebookFriends, undefined);
});

test("player settings parser accepts only the recovered boolean preference contract", () => {
  const parsed = parseNotificationSettings(JSON.stringify({ challenge: false, squadEvents: false }));
  assert.equal(parsed.challenge, false);
  assert.equal(parsed.squadEvents, false);
  assert.equal(parsed.playerLeague, true);
  assert.equal(notificationSettingsEqual(parsed, { ...parsed }), true);
  assert.equal(notificationSettingsEqual(parsed, { ...parsed, challenge: true }), false);
  assert.equal(notificationSettingsEqual(undefined, parsed), false);
  assert.throws(() => parseNotificationSettings(JSON.stringify({ challenge: "false" })));
  assert.throws(() => parseNotificationSettings("not-json"));
});

test("profile normalization preserves localized names and validates locale/country fields", () => {
  assert.equal(normalizePlayerName("  Игрок  "), "Игрок");
  assert.equal(normalizeLocale("pt-BR"), "pt-BR");
  assert.equal(normalizeCountry("us"), "US");
  assert.throws(() => normalizePlayerName("  "));
  assert.throws(() => normalizeLocale("../../etc"));
  assert.throws(() => normalizeCountry("USA"));
});

test("multilingual moderation rejects punctuation, leetspeak, and localized evasions", () => {
  assert.equal(moderationForms("F.u.u.u.c.k").compact, "fuck");
  assert.equal(containsProhibitedLanguage("F.u.u.u.c.k"), true);
  assert.equal(containsProhibitedLanguage("sh1t-player"), true);
  assert.equal(containsProhibitedLanguage("씨 발"), true);
  assert.equal(containsProhibitedLanguage("х.у.й"), true);
  assert.equal(containsProhibitedLanguage("AssaultTeam"), false);
  assert.equal(containsProhibitedLanguage("ClassicRecruit"), false);
  assert.throws(() => normalizePlayerName("f.u.c.k"));
});

test("moderation report contract preserves recovered fields and requires authentication", () => {
  const report = normalizeReportInput(
    {
      ReportedPlayerId: "target-1",
      ReportType: "2",
      Message: " abusive name ",
      MyArmyPower: "1200",
      OpponentRank: "5",
    },
    true,
  );
  assert.equal(report.reportedPlayerId, "target-1");
  assert.equal(report.reportType, 2);
  assert.equal(report.message, "abusive name");
  assert.equal(report.evidence.MyArmyPower, "1200");
  assert.equal(reportHandlers[DbAction.SendPlayerReport]?.requiresAuth, true);
  assert.equal(reportHandlers[DbAction.ReportCheater]?.requiresAuth, true);
  assert.throws(() => normalizeReportInput({ ReportedPlayerId: "target-1", ReportType: 2 }, true));
});

test("challenge inbox adapter emits the DynamoDB attribute wrappers parsed by Unity", () => {
  const message: MessageDoc = {
    messageId: "challenger-1700000000000",
    toPlayerId: "target",
    fromPlayerId: "challenger",
    fromName: "Challenger",
    body: "",
    messageType: 0,
    payload: { MapName: "map_1", GameType: 2, Region: 1, roomName: "room" },
    otherPlayerJson: "{\"id\":\"challenger\"}",
    read: false,
    ignored: false,
    accepted: false,
    createdAt: new Date(1_700_000_000_000),
  };
  const wire = toClientMessage(message);
  assert.deepEqual(wire.MessageType, { N: "0" });
  assert.deepEqual(wire.MessageId, { S: message.messageId });
  assert.deepEqual(wire.PlayerId, { S: "target" });
  assert.deepEqual(wire.MapName, { S: "map_1" });
  assert.deepEqual(wire.GameType, { N: "2" });
  assert.deepEqual(wire.OtherPlayer, { S: message.otherPlayerJson });
});

test("challenge expiry is enforced independently of MongoDB TTL cleanup timing", () => {
  const deadline = new Date("2026-07-20T12:00:00Z");
  assert.equal(challengeIsExpired({ messageType: 0, expiresAt: deadline }, new Date(deadline.getTime() - 1)), false);
  assert.equal(challengeIsExpired({ messageType: 0, expiresAt: deadline }, deadline), true);
  assert.equal(challengeIsExpired({ messageType: 0 }, new Date()), true);
  assert.equal(challengeIsExpired({ messageType: 27 }, new Date("2099-01-01T00:00:00Z")), false);
});
