import assert from "node:assert/strict";
import test from "node:test";
import { ApiErrorCode } from "../apiErrors";
import { DbAction } from "../dbActions";
import { CARD_CATALOG } from "../services/cardInventoryService";
import {
  dailyMissionsStateFor,
  dailyMissionsWireData,
  missionBattleRewardFor,
  selectDailyCompletionRewardIndex,
  serializeDailyMissionsData,
  settleDailyMissionState,
  startDailyMissionState,
} from "../services/dailyMissionService";
import { playerLevelDefinition } from "../services/levelProgressionService";
import { createInitialProgression } from "../services/playerStateService";

const NOW = Date.UTC(2026, 6, 19, 12, 0, 0) / 1_000;
const POLICY = { experience: 30, warBucks: 800 } as const;

test("daily mission wire matches DailyMissionsData and rolls at UTC midnight", () => {
  const initial = createInitialProgression(NOW);
  const missions = dailyMissionsStateFor(initial, NOW, 1);
  const wire = dailyMissionsWireData(missions);

  assert.deepEqual(Object.keys(wire), [
    "dailyMissions",
    "heroicMissions",
    "heroicPoints",
    "isHeroicOpened",
    "tomorrow",
    "dailyMissionRewardInd",
    "dailyMissionLevel",
    "heroicMissionLevel",
    "heroicUnitReward",
  ]);
  assert.equal(missions.dailyMissions.length, 3);
  assert.equal(missions.heroicMissions.length, 5);
  assert.notEqual(missions.heroicUnitReward, "");
  assert.deepEqual(missions.dailyMissions.map((item) => item.type), [
    "DailyMissionKillUnits",
    "DailyMissionSurvive",
    "DailyMissionWaves",
  ]);
  assert.deepEqual(Object.keys(missions.dailyMissions[0].cnf.units[0]), ["i", "vet", "eli", "lev"]);
  assert.equal(missions.tomorrow, Date.UTC(2026, 6, 20) / 1_000);
  assert.doesNotThrow(() => JSON.parse(serializeDailyMissionsData(missions)));

  const nextDay = dailyMissionsStateFor(
    { ...initial, dailyMissions: { ...missions, heroicPoints: 7, dailyMissions: missions.dailyMissions.map((item) => ({ ...item, completedSolo: true })) } },
    Date.UTC(2026, 6, 20, 0, 0, 1) / 1_000,
    6,
  );
  assert.equal(nextDay.heroicPoints, 7);
  assert.equal(nextDay.dailyMissionLevel, 5);
  assert.equal(nextDay.dailyMissions.every((item) => !item.completedSolo), true);
});

test("daily completion reward selection enables card variants only after War Cards unlock", () => {
  assert.equal(selectDailyCompletionRewardIndex(4, (upperBound) => upperBound - 1), 2);
  assert.equal(selectDailyCompletionRewardIndex(5, (upperBound) => upperBound - 1), 5);
  assert.throws(
    () => selectDailyCompletionRewardIndex(5, (upperBound) => upperBound),
    (error: unknown) => (error as { code?: number }).code === ApiErrorCode.InternalServerError,
  );
});

test("mission battle rewards reproduce scene scaling, slot modifiers, and co-op shares", () => {
  // Database level index 1 is display level 2 and exercises the negative exponent below the
  // formula's display-level-3 anchor. The
  // values are the recovered C# float calculation rounded upward to the next 50.
  assert.deepEqual(missionBattleRewardFor(1, "Daily", 0), {
    experience: 7_850,
    warBucks: 8_350,
  });
  assert.deepEqual(missionBattleRewardFor(1, "Daily", 2), {
    experience: 10_400,
    warBucks: 11_100,
  });
  assert.deepEqual(missionBattleRewardFor(1, "Heroic", 4), {
    experience: 9_850,
    warBucks: 10_450,
  });
  assert.deepEqual(missionBattleRewardFor(1, "Coop", 0), {
    experience: 0,
    warBucks: 0,
  });
  assert.deepEqual(missionBattleRewardFor(1, "CoopClient", 0), {
    experience: 3_950,
    warBucks: 4_200,
  });
  // Database index 43 is display level 44 and guards the positive exponent/float32 order.
  assert.deepEqual(missionBattleRewardFor(43, "Heroic", 4), {
    experience: 524_100,
    warBucks: 40_850,
  });
});

test("default settlement pays the recovered mission formula instead of an offline constant", () => {
  let state = createInitialProgression(NOW);
  state = startDailyMissionState(state, NOW, 1, "player-1-source-reward", DbAction.GameStartedCampaign).state;
  const result = settleDailyMissionState(state, NOW + 10, 1, {
    battleId: "player-1-source-reward",
    missionIndex: 0,
    missionType: "Daily",
    endReason: 10,
  });

  assert.equal(result.experienceGained, 7_850);
  assert.equal(result.state.warBucks, 8_350);
  assert.deepEqual(result.response.GameReward, {
    Warbucks: { BattleRewards: 8_350, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 7_850, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 0, League: 0, offerMult: 1 },
    IsVip: false,
  });
});

test("failed mission consumes its start receipt and a retry returns the stored response", () => {
  let state = createInitialProgression(NOW);
  state = startDailyMissionState(state, NOW, 1, "player-1-100", DbAction.GameStartedCampaign).state;
  const failed = settleDailyMissionState(state, NOW + 10, 1, {
    battleId: "player-1-100",
    missionIndex: 0,
    missionType: "Daily",
    endReason: 9,
  }, POLICY);

  assert.equal(failed.dailyMissions.activeSessions.length, 0);
  assert.equal(failed.dailyMissions.dailyMissions[0].completedSolo, false);
  assert.equal(failed.state.gold, 0);
  assert.deepEqual(failed.response.GameReward, {
    Warbucks: { BattleRewards: 0, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 0, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 0, League: 0, offerMult: 1 },
    IsVip: false,
  });

  const replay = settleDailyMissionState(failed.state, NOW + 20, 1, {
    battleId: "player-1-100",
    missionIndex: 0,
    missionType: "Daily",
    endReason: 9,
  }, POLICY);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.revision, failed.state.revision);
  assert.equal(replay.state.gold, 0);
  assert.deepEqual(replay.response, failed.response);
});

test("three unique solo completions grant one exact scene daily reward and achievement progress", () => {
  let state = createInitialProgression(NOW);
  state = {
    ...state,
    dailyMissions: {
      ...dailyMissionsStateFor(state, NOW, 1),
      dailyMissionRewardInd: 0,
    },
  };
  let finalResponse: Record<string, unknown> = {};
  for (let index = 0; index < 3; index += 1) {
    const id = `player-1-daily-${index}`;
    state = startDailyMissionState(state, NOW + index * 20, 1, id, DbAction.GameStartedCampaign).state;
    const result = settleDailyMissionState(state, NOW + index * 20 + 10, 1, {
      battleId: id,
      missionIndex: index,
      missionType: "Daily",
      endReason: 10,
    }, POLICY);
    state = result.state;
    finalResponse = result.response;
  }

  assert.equal(state.dailyMissions?.dailyMissions.every((item) => item.completedSolo), true);
  assert.equal(state.dailyMissions?.dailyCompletionRewardClaimed, true);
  assert.equal(state.dailyMissions?.heroicPoints, 3);
  assert.equal(state.gold, 10);
  assert.equal(state.warBucks, 2_400);
  assert.equal(state.levelExperience, 90);
  assert.equal(finalResponse.DailyMissionsCompletionRewardGold, 10);
  assert.deepEqual(finalResponse.GameReward, {
    Warbucks: { BattleRewards: 800, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 30, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 0, League: 0, offerMult: 1 },
    IsVip: false,
  });
  assert.equal(state.achievements?.data.find((group) => group.id === 5)?.value, 3);

  const replay = settleDailyMissionState(state, NOW + 100, 1, {
    battleId: "player-1-daily-2",
    missionIndex: 2,
    missionType: "Daily",
    endReason: 10,
  }, POLICY);
  assert.equal(replay.replayed, true);
  assert.equal(replay.state.gold, 10);
  assert.equal(replay.state.achievements?.data.find((group) => group.id === 5)?.value, 3);
});

test("daily card completion grants the exact row count and replays without duplicate ownership", () => {
  let state = createInitialProgression(NOW);
  state = {
    ...state,
    dailyMissions: {
      ...dailyMissionsStateFor(state, NOW, 5),
      dailyMissionRewardInd: 5,
    },
  };
  let finalResponse: Record<string, unknown> = {};
  for (let index = 0; index < 3; index += 1) {
    const battleId = `player-1-daily-card-${index}`;
    state = startDailyMissionState(state, NOW + index * 20, 5, battleId, DbAction.GameStartedCampaign).state;
    const settled = settleDailyMissionState(state, NOW + index * 20 + 10, 5, {
      battleId,
      missionIndex: index,
      missionType: "Daily",
      endReason: 10,
    }, { ...POLICY, chooseCardIndex: () => 0 });
    state = settled.state;
    finalResponse = settled.response;
  }

  const cards = finalResponse.DailyMissionsCompletionRewardCards as string[];
  assert.equal(cards.length, 3);
  assert.equal(cards.every((id) => CARD_CATALOG[id]?.rarity === 3), true);
  assert.equal(cards.every((id) => (CARD_CATALOG[id]?.fromMission ?? 99) <= 6), true);
  assert.equal(
    Object.values(state.cardInventory?.cardData ?? {}).reduce((sum, card) => sum + card.amount, 0),
    3,
  );
  assert.equal(state.gold, 0);

  const replay = settleDailyMissionState(state, NOW + 100, 5, {
    battleId: "player-1-daily-card-2",
    missionIndex: 2,
    missionType: "Daily",
    endReason: 10,
  }, POLICY);
  assert.equal(replay.replayed, true);
  assert.deepEqual(replay.response, finalResponse);
  assert.equal(
    Object.values(replay.state.cardInventory?.cardData ?? {}).reduce((sum, card) => sum + card.amount, 0),
    3,
  );
});

test("heroic chain is ordered and grants the recovered currency rewards once", () => {
  let state = createInitialProgression(NOW);
  const generated = dailyMissionsStateFor(state, NOW, 1);
  state = {
    ...state,
    dailyMissions: { ...generated, heroicPoints: 30, isHeroicOpened: true },
  };

  assert.throws(
    () => {
      const started = startDailyMissionState(state, NOW, 1, "player-1-out-of-order", DbAction.GameStartedCampaign).state;
      settleDailyMissionState(started, NOW + 1, 1, {
        battleId: "player-1-out-of-order",
        missionIndex: 1,
        missionType: "Heroic",
        endReason: 10,
      }, POLICY);
    },
    (error: unknown) => (error as { code?: number }).code === 90,
  );

  let finalResponse: Record<string, unknown> = {};
  for (let index = 0; index < 5; index += 1) {
    const id = `player-1-heroic-${index}`;
    state = startDailyMissionState(state, NOW + index * 20, 1, id, DbAction.GameStartedCampaign).state;
    const result = settleDailyMissionState(state, NOW + index * 20 + 10, 1, {
      battleId: id,
      missionIndex: index,
      missionType: "Heroic",
      endReason: 10,
    }, POLICY);
    state = result.state;
    finalResponse = result.response;
  }

  // Five level-1 heroic missions grant 1 Gold each; completing all five adds 15 Gold,
  // 10 Tickets, and 30 Scraps from the first recovered MissionsRewards row.
  assert.equal(state.gold, 20);
  assert.equal(state.warBucks, 4_000);
  assert.equal(state.levelExperience, 150);
  assert.equal(state.tickets, 10);
  assert.equal(state.scraps, 30);
  assert.equal(state.dailyMissions?.heroicCompletionRewardClaimed, true);
  assert.equal(state.dailyMissions?.isHeroicOpened, false);
  assert.equal(state.dailyMissions?.heroicPoints, 0);

  const rewardedCards = finalResponse.HeroicMissionsCompletionRewardCardPack as string[];
  assert.equal(rewardedCards.length, 10);
  assert.equal(rewardedCards.slice(0, 7).every((id) => CARD_CATALOG[id]?.rarity === 1), true);
  assert.equal(rewardedCards.slice(7).every((id) => [1, 2].includes(CARD_CATALOG[id]?.rarity ?? 0)), true);
  assert.equal(
    Object.values(state.cardInventory?.cardData ?? {}).reduce((sum, card) => sum + card.amount, 0),
    10,
  );
  const unitName = state.dailyMissions!.heroicUnitReward;
  assert.equal(finalResponse.HeroicMissionsCompletionRewardArmyUnitId, unitName);
  assert.equal(finalResponse.HeroicMissionsCompletionRewardArmyUnitParts, 1);
  assert.equal(state.itemInventory?.levelManagerData.savedArmies[unitName]?.parts, 1);

  const replay = settleDailyMissionState(state, NOW + 200, 1, {
    battleId: "player-1-heroic-4",
    missionIndex: 4,
    missionType: "Heroic",
    endReason: 10,
  }, POLICY);
  assert.equal(replay.replayed, true);
  assert.deepEqual(replay.response, finalResponse);
  assert.equal(
    Object.values(replay.state.cardInventory?.cardData ?? {}).reduce((sum, card) => sum + card.amount, 0),
    10,
  );
  assert.equal(replay.state.itemInventory?.levelManagerData.savedArmies[unitName]?.parts, 1);
});

test("co-op client result cannot claim the co-op master's completion", () => {
  let state = createInitialProgression(NOW);
  state = startDailyMissionState(state, NOW, 1, "player-1-coop-client", DbAction.GameStartedCoopClient).state;
  const result = settleDailyMissionState(state, NOW + 10, 1, {
    battleId: "player-1-coop-client",
    missionIndex: 0,
    missionType: "CoopClient",
    endReason: 10,
  }, POLICY);
  assert.equal(result.dailyMissions.dailyMissions[0].completedCoop, false);
  assert.equal(result.dailyMissions.heroicPoints, 0);
  assert.equal(result.state.gold, 0);
  assert.equal(result.state.warBucks, 800);
  assert.equal(result.state.levelExperience, 30);
});

test("active VIP multiplies persisted mission XP and WarBucks while wire components stay base", () => {
  let state = createInitialProgression(NOW);
  state = { ...state, vipExpiration: NOW + 3_600 };
  state = startDailyMissionState(state, NOW, 1, "player-1-vip", DbAction.GameStartedCampaign).state;
  const result = settleDailyMissionState(state, NOW + 10, 1, {
    battleId: "player-1-vip",
    missionIndex: 0,
    missionType: "Daily",
    endReason: 10,
  }, POLICY);

  assert.equal(result.experienceGained, 45);
  assert.equal(result.state.levelExperience, 45);
  assert.equal(result.state.warBucks, 1_200);
  assert.deepEqual(result.response.GameReward, {
    Warbucks: { BattleRewards: 800, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 30, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 0, League: 0, offerMult: 1 },
    IsVip: true,
  });
});

test("active VIP doubles heroic per-mission GameGold without multiplying chain prizes", () => {
  let state = createInitialProgression(NOW);
  const generated = dailyMissionsStateFor(state, NOW, 1);
  state = {
    ...state,
    vipExpiration: NOW + 3_600,
    dailyMissions: { ...generated, heroicPoints: 30, isHeroicOpened: true },
  };
  state = startDailyMissionState(state, NOW, 1, "player-1-vip-heroic", DbAction.GameStartedCampaign).state;
  const result = settleDailyMissionState(state, NOW + 10, 1, {
    battleId: "player-1-vip-heroic",
    missionIndex: 0,
    missionType: "Heroic",
    endReason: 10,
  }, { experience: 0, warBucks: 0 });

  // The first source row grants one base Gold per heroic mission. IsVip tells the stock
  // parser to render two, and the authoritative wallet persists that same doubled amount.
  assert.equal(result.state.gold, 2);
  assert.deepEqual(result.response.GameReward, {
    Warbucks: { BattleRewards: 0, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 0, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: 1, League: 0, offerMult: 1 },
    IsVip: true,
  });
});

test("mission XP level-up grants source Gold and durably refills dog tags", () => {
  const definition = playerLevelDefinition(1);
  let state = {
    ...createInitialProgression(NOW),
    levelExperience: definition.experience - 1,
    dogTagSeconds: 0,
  };
  state = startDailyMissionState(state, NOW, 1, "player-1-level-up", DbAction.GameStartedCampaign).state;
  const result = settleDailyMissionState(state, NOW + 10, 1, {
    battleId: "player-1-level-up",
    missionIndex: 0,
    missionType: "Daily",
    endReason: 10,
  }, { experience: 1, warBucks: 0 });

  assert.equal(result.levelFrom, 1);
  assert.equal(result.levelTo, 2);
  assert.equal(result.state.levelExperience, 0);
  assert.equal(result.state.gold, definition.rewardGold);
  assert.equal(result.state.dogTagSeconds, result.state.dogTagMax);
  assert.equal(result.response.Level, 2);
  assert.equal(result.response.DogtagsRefillRankUp, true);
  assert.deepEqual(result.response.GameReward, {
    Warbucks: { BattleRewards: 0, ExtraRewards: 0, Winstreak: 0, League: 0, offerMult: 1 },
    Xp: { BattleRewards: 1, ExtraRewards: 0, Winstreak: 0, Time: 0, offerMult: 1 },
    GameGold: { BattleRewards: definition.rewardGold, League: 0, offerMult: 1 },
    IsVip: false,
  });
});
