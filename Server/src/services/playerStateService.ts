import type { PlayerDocument, PlayerProgressionState } from "../db";
import { config } from "../config";
import { createInitialItemInventory } from "./itemInventoryService";
import { createInitialVisualInventory } from "./visualInventoryService";
import { CARD_UNLOCK_LEVEL, createInitialCardCrafting, createInitialCardInventory } from "./cardInventoryService";
import { warArenaConfiguration, warArenaWireData } from "./warArenaContract";
import {
  playerLeagueBootFields,
  validatePlayerLeagueCompetitionScore,
  validatePlayerLeagueProgression,
} from "./playerLeagueContract";
import {
  validatedVipLootboxCountdown,
  VIP_LOOTBOX_MATCH_INTERVAL,
} from "./vipLootboxService";
import { validatedVipExpiration } from "./vipEntitlementService";
import { validatedSubscription } from "./subscriptionBenefitService";
import { validatedRentalState } from "./rentalEntitlementService";
import { validatedBlackMarketOfferState } from "./blackMarketEntitlementService";
import { validatedVisualInventoryState } from "./visualEntitlementService";
import {
  createInitialStarterAssignmentState,
  validatedStarterAssignmentState,
} from "./starterAssignmentAuthorityService";
import { videoAdRewardTimesForState } from "./videoAdRewardAuthorityService";
import { validatedPvpWinStreak } from "./pvpWinStreakAuthorityService";
import { validatedInstantBattleState } from "./instantBattleAuthorityService";
import { validatedSquadCreationsCount } from "./squadCreationAuthorityService";
import { validatedRenameCount } from "./playerRenameAuthorityService";
import { validatedCollectedRewards } from "./oneTimeRewardAuthorityService";
import { validatedSquadChatCursor } from "./squadChatCursorAuthorityService";
import { validatedFeatureIntroductions } from "./featureIntroductionAuthorityService";
import { validatedTutorialLifecycle } from "./tutorialCompletionAuthorityService";
import { validatedCoreProgressionBalances } from "./coreProgressionAuthorityService";
import { validatedDogTagAuthority } from "./dogTagAuthorityService";
import { progressionRevisionForRead } from "./progressionRevisionAuthorityService";
import { validatedProgressionSchemaVersion } from "./progressionSchemaAuthorityService";

/** Unix seconds are used throughout the recovered Beanstalk protocol. */
export function unixNow(): number {
  return Math.floor(Date.now() / 1000);
}

function currentUtcMidnight(now: number): number {
  const date = new Date(Math.floor(now) * 1_000);
  return Math.floor(Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate()) / 1_000);
}

/**
 * Create the server-owned part of a new account.
 *
 * New players start with empty currencies because the tutorial and reward actions are the
 * authority that should grant starter items. Granting guessed balances here would make a
 * reinstall an economy exploit. Five dog tags is the playable starting energy cap used by
 * this reconstruction until the remote balancing sheet is recovered and versioned.
 */
export function createInitialProgression(
  now = unixNow(),
  refillSeconds = config.dogTagRefillSeconds,
  cap = config.dogTagCap,
): PlayerProgressionState {
  const safeRefillSeconds = Math.max(1, Math.floor(refillSeconds));
  const safeCap = Math.max(1, Math.floor(cap));
  return {
    schemaVersion: 1,
    revision: 0,
    gold: 0,
    warBucks: 0,
    tickets: 0,
    scraps: 0,
    levelExperience: 0,
    dogTagSeconds: safeCap * safeRefillSeconds,
    dogTagLastUpdate: now,
    dogTagMax: safeCap * safeRefillSeconds,
    dogTagRefillSeconds: safeRefillSeconds,
    vipStart: 0,
    vipExpiration: 0,
    tutorialFinished: false,
    matchesToNextLootboxes: VIP_LOOTBOX_MATCH_INTERVAL,
    collectedRewards: {},
    itemInventory: createInitialItemInventory(),
    visualInventory: createInitialVisualInventory(),
    cardInventory: createInitialCardInventory(),
    cardCrafting: createInitialCardCrafting(),
    starterAssignments: createInitialStarterAssignmentState(now),
  };
}

/**
 * Read progression with a legacy-account fallback, without pretending it was persisted.
 * Callers that mutate balances must first migrate the document atomically; read-only boot
 * responses may safely use this deterministic fallback.
 */
export function progressionForPlayer(player: PlayerDocument): PlayerProgressionState {
  if (!player.progression) return createInitialProgression(Math.floor(player.createdAt.getTime() / 1000));
  const state = player.progression;
  validatedProgressionSchemaVersion(state.schemaVersion);
  // This is the shared persisted-progression read boundary, not only a boot serializer. Validate
  // wallet/rank balances here so cross-player transactions and ordinary economy actions cannot
  // let NaN/Infinity bypass a `< price` check before reaching a narrower service validator.
  validatedCoreProgressionBalances(state);
  const hasCanonicalDogTagTuple = Object.prototype.hasOwnProperty.call(state, "dogTagSeconds")
    || Object.prototype.hasOwnProperty.call(state, "dogTagLastUpdate")
    || Object.prototype.hasOwnProperty.call(state, "dogTagMax")
    || Object.prototype.hasOwnProperty.call(state, "dogTagRefillSeconds");
  if (hasCanonicalDogTagTuple) {
    // Accounts written before typed inventory recovery have no server-owned item state.
    // Materialize the verified 4.9.5 starter loadout at the read boundary; the next buffered
    // inventory mutation persists it together with the currency transaction. Detect the dog-tag
    // schema by field presence rather than numeric validity: a canonical NaN/Infinity/partial
    // tuple is damaged authority that downstream boot/economy validators must reject, not a
    // count-only legacy account that this read boundary is allowed to reconstruct.
    return {
      ...state,
      revision: progressionRevisionForRead(state.revision),
      vipExpiration: validatedVipExpiration(state.vipExpiration ?? player.player.vipExpiration),
      subscription: validatedSubscription(state.subscription),
      rental: validatedRentalState(state.rental),
      blackMarket: validatedBlackMarketOfferState(state.blackMarket),
      matchesToNextLootboxes: validatedVipLootboxCountdown(state.matchesToNextLootboxes),
      collectedRewards: validatedCollectedRewards(state.collectedRewards),
      itemInventory: state.itemInventory ?? createInitialItemInventory(),
      visualInventory: state.visualInventory ?? createInitialVisualInventory(),
      cardInventory: state.cardInventory ?? createInitialCardInventory(),
      cardCrafting: state.cardCrafting ?? createInitialCardCrafting(),
    };
  }

  // An early unreleased reconstruction stored dogTags as a count. Convert that shape at the
  // read boundary so development databases remain usable; the next economy mutation persists
  // the canonical seconds-based representation and removes the transitional field.
  const refillSeconds = Math.max(1, Math.floor(config.dogTagRefillSeconds));
  const cap = Math.max(1, Math.floor(config.dogTagCap));
  const legacyCount = Math.max(0, Math.floor(state.dogTags ?? cap));
  return {
    ...state,
    revision: progressionRevisionForRead(state.revision),
    dogTagSeconds: Math.min(cap, legacyCount) * refillSeconds,
    dogTagLastUpdate: state.dogTagLastUpdate || Math.floor(player.createdAt.getTime() / 1000),
    dogTagMax: cap * refillSeconds,
    dogTagRefillSeconds: refillSeconds,
    vipExpiration: validatedVipExpiration(state.vipExpiration ?? player.player.vipExpiration),
    subscription: validatedSubscription(state.subscription),
    rental: validatedRentalState(state.rental),
    blackMarket: validatedBlackMarketOfferState(state.blackMarket),
    matchesToNextLootboxes: validatedVipLootboxCountdown(state.matchesToNextLootboxes),
    collectedRewards: validatedCollectedRewards(state.collectedRewards),
    itemInventory: state.itemInventory ?? createInitialItemInventory(),
    visualInventory: state.visualInventory ?? createInitialVisualInventory(),
    cardInventory: state.cardInventory ?? createInitialCardInventory(),
    cardCrafting: state.cardCrafting ?? createInitialCardCrafting(),
  };
}

type NumberAttribute = { N: string };
type StringAttribute = { S: string };
export type PlayerDataAttribute = NumberAttribute | StringAttribute;
export type PlayerDataMap = Record<string, PlayerDataAttribute>;

function numberAttribute(value: number): NumberAttribute {
  // The old Unity parser expects the DynamoDB wire representation, where even numbers are
  // JSON strings inside an `N` property. Returning a bare JSON number makes GetPlayerData
  // parse as zero or throw, depending on which KHJJFPPACBP overload is used.
  return { N: String(Math.trunc(Number.isFinite(value) ? value : 0)) };
}

function stringAttribute(value: unknown): StringAttribute {
  return { S: JSON.stringify(value) };
}

function addSerializedObject(target: PlayerDataMap, typeName: string, value: unknown): void {
  // An absent object makes DatabaseSerializedObjectGeneric.Load call LoadEmpty(), which is
  // safer than serializing null: several recovered managers dereference their data directly
  // after loading and assume the default constructor has run.
  if (value !== null && value !== undefined) target[typeName] = stringAttribute(value);
}

/**
 * Convert DatabasePlayerDTO into the DynamoDB item shape consumed by
 * DatabasePlayer.CreateFromDatabase.
 *
 * This is intentionally a separate adapter from buildPlayerData. Both use DynamoDB-looking
 * wrappers, but they represent different client models: DatabasePlayer is identity/profile
 * data, while PlayerData is private progression loaded by singleton managers. Mixing them
 * was the reason early responses produced a valid JSON object but an empty Unity player.
 */
export function buildDatabasePlayer(document: PlayerDocument): Record<string, unknown> {
  const dto = document.player;
  validatePlayerLeagueProgression(dto);
  validatePlayerLeagueCompetitionScore(dto.medalsBalance, dto.skill, document.id);
  const progression = progressionForPlayer(document);
  const itemInventory = progression.itemInventory;
  const wire: Record<string, unknown> = {
    Id: { S: dto.id },
    Name: { S: dto.accountName },
    Level: numberAttribute(dto.level),
    Reputation: numberAttribute(dto.reputation),
    SquadPoints: numberAttribute(dto.squadPoints),
    Experience: numberAttribute(dto.experience),
    Country: { S: dto.country },
    SendLogs: numberAttribute(dto.sendLogsValue),
    DeviceToken: { S: dto.deviceToken },
    LastAction: numberAttribute(dto.lastAction),
    // DatabasePlayer expects exactly the four equipped CamosManager slots, not the full
    // DecalManagerData ownership dictionary. Derive them from progression so opponent,
    // challenge, and league snapshots reflect the last authoritative EquipDecal mutation.
    PlayerVisuals: stringAttribute(progression.visualInventory?.slots ?? dto.playerVisuals),
    ArmyPower: numberAttribute(dto.armyPower),
    Status: numberAttribute(dto.status),
    BeginnersLeague: numberAttribute(dto.beginnersLeague),
    Vip: numberAttribute(progression.vipExpiration ?? dto.vipExpiration),
    AccountType: numberAttribute(dto.accountType),
    Skill: numberAttribute(dto.skill),
    PlacementMatchesRequired: numberAttribute(dto.remainingMatches),
    MedalsBalance: numberAttribute(dto.medalsBalance),
    SquadRank: numberAttribute(dto.squadRank),
    VisualType: { S: dto.visualType },
    VisualTimestamp: numberAttribute(dto.visualTimestamp),
    InfluencerLink: { S: dto.influencerLink },
    InfluencerAlias: { S: dto.influencerAlias },
  };

  // An empty LeagueId has special meaning. Omitting it lets the client construct the
  // expected "<tier>-placement" value from EligibleLeagueId instead of splitting "".
  if (dto.leagueId) wire.LeagueId = { S: dto.leagueId };
  else wire.EligibleLeagueId = numberAttribute(dto.leagueTier);

  if (dto.squadName) wire.SquadId = { S: dto.squadName };
  if (dto.facebookId !== -1) wire.FacebookId = { S: String(dto.facebookId) };
  if (dto.gameCenterId) wire.GameCenterId = { S: dto.gameCenterId };
  if (dto.googlePlayId) wire.GooglePlayId = { S: dto.googlePlayId };
  if (dto.bestRegions && Object.keys(dto.bestRegions).length > 0) {
    // DatabasePlayer.CreateFromDatabase reads this exact Dynamo-style string and deserializes
    // it into Dictionary<CloudRegionCode,int>. Challenge setup then chooses the region with
    // the lowest combined local/opponent ping. Connection type is local-only in the stock
    // parser, so it is persisted for diagnostics but deliberately not invented on this wire.
    wire.Regions = stringAttribute(dto.bestRegions);
  }
  if (itemInventory) {
    // Public player snapshots use the same server-owned objects as private PlayerData. This
    // keeps profile/challenge views synchronized without duplicating mutable inventory in
    // DatabasePlayerDTO.
    wire.InventoryData = stringAttribute(itemInventory.inventoryData);
    wire.LevelManagerData = stringAttribute(itemInventory.levelManagerData);
  } else if (dto.inventoryData !== null && dto.inventoryData !== undefined) {
    wire.InventoryData = stringAttribute(dto.inventoryData);
  }
  if (!itemInventory && dto.levelManagerData !== null && dto.levelManagerData !== undefined) {
    wire.LevelManagerData = stringAttribute(dto.levelManagerData);
  }
  if (dto.statisticsData !== null && dto.statisticsData !== undefined) {
    wire.StatisticsData = stringAttribute(dto.statisticsData);
  }
  if (Object.keys(dto.depositedCardsDic).length > 0) {
    wire.DepositedCards = {
      M: Object.fromEntries(Object.entries(dto.depositedCardsDic).map(([key, value]) => [key, { S: value }])),
    };
  }
  return wire;
}

/**
 * Translate the normalized MongoDB document into the exact attribute map consumed by
 * OGLEHLIPEFM.NCNNKGNJNOH in the recovered 1.6.0 client.
 */
export function buildPlayerData(player: PlayerDocument, now = unixNow()): PlayerDataMap {
  const state = progressionForPlayer(player);
  const dto = player.player;
  const balances = validatedCoreProgressionBalances(state);
  const dogTags = validatedDogTagAuthority(state, Math.floor(now));
  const data: PlayerDataMap = {
    Gold: numberAttribute(balances.gold),
    WarBucks: numberAttribute(balances.warBucks),
    Tickets: numberAttribute(balances.tickets),
    Scraps: numberAttribute(balances.scraps),
    Level: numberAttribute(dto.level),
    LevelExperience: numberAttribute(balances.levelExperience),
    Experience: numberAttribute(dto.experience),
    ArmyPower: numberAttribute(dto.armyPower),
    DogTagSeconds: numberAttribute(dogTags.dogTagSeconds),
    DogTagLastUpdate: numberAttribute(dogTags.dogTagLastUpdate),
    DogTagMax: numberAttribute(dogTags.dogTagMax),
    Vip: numberAttribute(state.vipExpiration ?? dto.vipExpiration),
    VipStart: numberAttribute(state.vipStart),
    SendLogs: numberAttribute(dto.sendLogsValue),
    Settings: stringAttribute(dto.notificationSettings),
    // EventAssignmentManager computes its zero-based calendar day from this server boundary.
    // Send the current UTC midnight (not the next reset) so day zero begins at startTime.
    Midnight: numberAttribute(currentUtcMidnight(now)),
  };

  // These names are the nested C# type names used as lookup keys by
  // DatabaseSerializedObjectGeneric<T>.Load; the DTO property casing is intentionally not
  // copied onto the wire.
  addSerializedObject(data, "InventoryData", state.itemInventory?.inventoryData ?? dto.inventoryData);
  addSerializedObject(data, "LevelManagerData", state.itemInventory?.levelManagerData ?? dto.levelManagerData);
  addSerializedObject(data, "DecalManagerData", validatedVisualInventoryState(state.visualInventory));
  addSerializedObject(data, "CardManagerData", state.cardInventory);
  addSerializedObject(data, "CraftData", state.cardCrafting);
  // SubscriptionManager inherits DatabaseSerializedObjectGeneric<Subscription>. The stock
  // loader also reads dogTagTimerLock from the same JSON object even though the recovered
  // nested C# model does not declare it, so retain all four server-owned fields here.
  addSerializedObject(data, "Subscription", state.subscription);
  if (state.videoAdRewards) {
    // Unlike the manager-backed objects above, EventTrackingManager reads this exact lower-case
    // PlayerData key and manually deserializes its Dynamo `S` value. Expose only the four public
    // timestamp arrays; the same-revision replay receipt remains private backend authority.
    data.videoAdRewardTimes = stringAttribute(videoAdRewardTimesForState(state, Math.floor(now)));
  }
  addSerializedObject(data, "StatisticsData", dto.statisticsData);
  // WinStreakManager derives from DatabaseSerializedObjectGeneric<WinStreak>. Restore the
  // server-owned streak on every boot; otherwise LoadEmpty silently resets the lobby timer
  // after reconnect even though subsequent settlement still sees the durable streak.
  const winStreak = validatedPvpWinStreak(state.pvpWinStreak, Math.floor(now));
  addSerializedObject(data, "WinStreak", {
    WinCount: winStreak.winCount,
    TimeStamp: winStreak.timestamp,
  });
  const blackMarket = validatedBlackMarketOfferState(state.blackMarket);
  if (blackMarket) {
    // BlackMarketManager inherits DatabaseSerializedObjectGeneric<BlackMarketOfferData>, so
    // the boot lookup key is the nested type name. Action 217 uses the historic response key
    // `BlackMarketOffer`; these two names are intentionally different parts of the client
    // contract. Loading persisted state here keeps an active offer visible after relogging.
    addSerializedObject(data, "BlackMarketOfferData", {
      offersTotal: blackMarket.offersTotal,
      lastTrigger: blackMarket.lastTrigger,
      offerEnd: blackMarket.offerEnd,
      currentOffers: blackMarket.currentOffers.map((offer) => ({ ...offer })),
    });
  }

  if (state.assignments) {
    // AssignmentsManager derives from DatabaseSerializedObjectGeneric<AssignmentData>, so
    // the lookup key is the nested data type name, not the manager class name. `dayKey` is a
    // server reset marker and must not leak into the client's serialized model.
    const { dayKey: _serverDayKey, ...assignmentData } = state.assignments;
    data.AssignmentData = stringAttribute(assignmentData);
  }

  if (state.achievements) {
    // AchievementProgressGroups derives from
    // DatabaseSerializedObjectGeneric<AchievementProgressGroups.AchievementsData>. The
    // nested type name is therefore the PlayerData key, while its JSON body must contain the
    // recovered `data` array of { id, offset, value, progress } group records.
    data.AchievementsData = stringAttribute(state.achievements);
  }

  if (state.dailyMissions) {
    // DailyMissionsManager derives from DatabaseSerializedObjectGeneric<DailyMissionsData>.
    // Persisted battle receipts and claim guards are server-only; exposing them would change
    // the recovered JSON model and disclose replay identifiers to a modified client.
    const missions = state.dailyMissions;
    data.DailyMissionsData = stringAttribute({
      dailyMissions: missions.dailyMissions,
      heroicMissions: missions.heroicMissions,
      heroicPoints: missions.heroicPoints,
      isHeroicOpened: missions.isHeroicOpened,
      tomorrow: missions.tomorrow,
      dailyMissionRewardInd: missions.dailyMissionRewardInd,
      dailyMissionLevel: missions.dailyMissionLevel,
      heroicMissionLevel: missions.heroicMissionLevel,
      heroicUnitReward: missions.heroicUnitReward,
    });
  }

  if (state.eventAssignment) {
    // EventAssignmentManager derives from DatabaseSerializedObjectGeneric<EventAssignmentData>.
    // configHash is server-only immutable-definition authority and must not enter the client JSON.
    const { configHash: _serverConfigHash, ...eventAssignmentData } = state.eventAssignment;
    addSerializedObject(data, "EventAssignmentData", eventAssignmentData);
  }

  if (state.warArena) {
    // WarArena derives from DatabaseSerializedObjectGeneric<WarArenaData>. Only the thirteen
    // recovered public fields belong in PlayerData; battle receipts and replay responses are
    // backend authority and must never be exposed through the serialized object.
    data.WarArenaData = stringAttribute(warArenaWireData(state.warArena));
  }

  // StarterAssignmentsManager derives from
  // DatabaseSerializedObjectGeneric<StarterAssignmentsManager.StarterAssignmentsData>.
  // Always provide the nested type key: LoadEmpty would create deadline 0 and hide the
  // onboarding chain even for a brand-new account. Legacy accounts derive an expired (not
  // renewed) deadline from their original creation timestamp.
  data.StarterAssignmentsData = stringAttribute(
    validatedStarterAssignmentState(state.starterAssignments)
      ?? createInitialStarterAssignmentState(Math.floor(player.createdAt.getTime() / 1_000)),
  );
  const instantBattle = validatedInstantBattleState(state.instantBattle, Math.floor(now));
  const featureIntroductions = validatedFeatureIntroductions(state.featureIntroductions);
  const tutorialLifecycle = validatedTutorialLifecycle(state, Math.floor(now));

  // PlayerAnalytics derives from DatabaseSerializedObjectGeneric<PlayerAnalyticsData>, so
  // this exact nested type name is the boot lookup key. The real chat channel is Photon
  // Chat, but its cross-device unread cursor is persisted by Beanstalk action 193. Sending
  // only recovered server-owned fields is equivalent to the client's current LoadEmpty
  // behavior for the remaining analytics fields. The creation counter must also cross this
  // boot boundary: PlayerAnalytics derives the next squad price from it after every restart.
  addSerializedObject(data, "PlayerAnalyticsData", {
    lastSeenSquadChatTimeStampDB: validatedSquadChatCursor(state.lastSeenSquadChatTimestamp, Math.floor(now)),
    squadCreationsCount: validatedSquadCreationsCount(state.squadCreationsCount),
    // PlayerAnalytics.renameGoldPrice is profile-owned even though most fields in this object
    // live in progression. Restore the validated count so reconnecting cannot display a free
    // rename while the backend correctly expects an exponentially priced attempt.
    renameCount: validatedRenameCount(dto.renameCount),
    // The stock UI checks this recovered dictionary before showing an already collected
    // one-time reward. Restoring the server-owned markers prevents a reconnect/reinstall from
    // presenting the button again even though a repeated action 161 would not pay twice.
    collectedRewards: validatedCollectedRewards(state.collectedRewards),
    // PlayerAnalytics.remainingMatchesToNextLootbox renders this countdown before the next
    // match. Sending the server-owned value on boot prevents reconnecting from restoring the
    // client's local zero/default and accidentally desynchronizing the four-battle cycle.
    matchesToNextLootboxes: validatedVipLootboxCountdown(state.matchesToNextLootboxes),
    // PlayerAnalytics computes both the visible charge count and the escalating purchase
    // price locally. Restoring all three server-owned action-199 counters prevents reconnects
    // from resetting the timer to a free full batch or resetting a paid price to 35 Gold.
    instantBattlesTime: instantBattle.instantBattlesTime,
    instantBattles: instantBattle.instantBattles,
    paidInstantBattles: instantBattle.paidInstantBattles,
    // TutorialManagerPlayWarcards starts only when this recovered field equals 1 and the
    // level-six War Card lock is already open. Value 2 is its durable terminal state. Derive
    // both values from server-owned progression instead of accepting the client's analytics
    // blob, otherwise reconnecting after the fixed reward would launch and pay it again.
    cardTutState: tutorialLifecycle.warcardsTutorialFinished
      ? 2
      : tutorialLifecycle.tutorialFinished && dto.level >= CARD_UNLOCK_LEVEL - 1
        ? 1
        : 0,
    // These one-way booleans are written only by their parameterless recovered actions. They
    // must cross the boot boundary or feature-introduction dialogs can repeat after reinstall.
    chatShown: featureIntroductions.chatShown ?? false,
    elitesShown: featureIntroductions.elitesShown ?? false,
    customizationShown: featureIntroductions.customizationShown ?? false,
    warpathShown: featureIntroductions.warpathShown ?? false,
    cardpoolShown: featureIntroductions.cardpoolShown ?? false,
    craftingShown: featureIntroductions.craftingShown ?? false,
    leagueLeaderboardsShown: featureIntroductions.leagueLeaderboardsShown ?? false,
  });

  if (tutorialLifecycle.tutorialFinished) {
    // NCNNKGNJNOH uses only the presence of this Dynamo-style key to leave tutorial mode,
    // stop all bootcamp managers, and unlock nonlocal asset bundles after a reconnect.
    data.TutorialData = stringAttribute({});
  }

  if (dto.facebookId !== -1) data.FacebookName = { S: dto.accountName };
  return data;
}

/** Fields common to CreateAccount and the mandatory post-login GetPlayerData refresh. */
export function buildPlayerStateResponse(player: PlayerDocument, now = unixNow()): Record<string, unknown> {
  validatePlayerLeagueProgression(player.player);
  validatePlayerLeagueCompetitionScore(
    player.player.medalsBalance,
    player.player.skill,
    player.id,
  );
  return {
    Time: now,
    BeginnersLeague: player.player.beginnersLeague,
    LeagueId: player.player.leagueId,
    Skill: player.player.skill,
    MedalsBalance: player.player.medalsBalance,
    PlacementMatchesRequired: player.player.remainingMatches,
    // The recovered GetPlayerData parser passes LeagueEvaluation to LeagueArcManager and
    // uses the mere presence of PlayerLeagueProcessing to disable stale division UI. Only
    // locally managed IDs expose these fields; unknown production-era IDs fail closed until
    // an explicit migration can preserve their original deadline.
    ...playerLeagueBootFields(player.player.leagueId, now),
    UtcOffset: 0,
    DeviceToken: player.player.deviceToken,
    PlayerData: buildPlayerData(player, now),
    // JLMICAJOHIK/EGPLNLMMADN both log an error and leave the Arena closed when this key is
    // absent. The value is the Dynamo-style document consumed by IKPLPPFFDNI, not a string.
    WarArenaConfig: warArenaConfiguration(now),
  };
}
