import type { PlayerDocument, PlayerProgressionState } from "../db";
import { config } from "../config";
import { createInitialItemInventory } from "./itemInventoryService";
import { createInitialVisualInventory } from "./visualInventoryService";
import { createInitialCardInventory } from "./cardInventoryService";
import { warArenaConfiguration, warArenaWireData } from "./warArenaContract";

/** Unix seconds are used throughout the recovered Beanstalk protocol. */
export function unixNow(): number {
  return Math.floor(Date.now() / 1000);
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
    itemInventory: createInitialItemInventory(),
    visualInventory: createInitialVisualInventory(),
    cardInventory: createInitialCardInventory(),
    starterAssignments: {
      deadline: now + Math.max(0, Math.floor(config.starterAssignmentDurationSeconds)),
      assignments: {},
    },
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
  if (Number.isFinite(state.dogTagSeconds) && Number.isFinite(state.dogTagRefillSeconds)) {
    // Accounts written before typed inventory recovery have no server-owned item state.
    // Materialize the verified 4.9.5 starter loadout at the read boundary; the next buffered
    // inventory mutation persists it together with the currency transaction.
    return {
      ...state,
      itemInventory: state.itemInventory ?? createInitialItemInventory(),
      visualInventory: state.visualInventory ?? createInitialVisualInventory(),
      cardInventory: state.cardInventory ?? createInitialCardInventory(),
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
    revision: state.revision ?? 0,
    dogTagSeconds: Math.min(cap, legacyCount) * refillSeconds,
    dogTagLastUpdate: state.dogTagLastUpdate || Math.floor(player.createdAt.getTime() / 1000),
    dogTagMax: cap * refillSeconds,
    dogTagRefillSeconds: refillSeconds,
    itemInventory: state.itemInventory ?? createInitialItemInventory(),
    visualInventory: state.visualInventory ?? createInitialVisualInventory(),
    cardInventory: state.cardInventory ?? createInitialCardInventory(),
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
    Vip: numberAttribute(dto.vipExpiration),
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
export function buildPlayerData(player: PlayerDocument): PlayerDataMap {
  const state = progressionForPlayer(player);
  const dto = player.player;
  const data: PlayerDataMap = {
    Gold: numberAttribute(state.gold),
    WarBucks: numberAttribute(state.warBucks),
    Tickets: numberAttribute(state.tickets),
    Scraps: numberAttribute(state.scraps),
    Level: numberAttribute(dto.level),
    LevelExperience: numberAttribute(state.levelExperience),
    Experience: numberAttribute(dto.experience),
    ArmyPower: numberAttribute(dto.armyPower),
    DogTagSeconds: numberAttribute(state.dogTagSeconds),
    DogTagLastUpdate: numberAttribute(state.dogTagLastUpdate),
    DogTagMax: numberAttribute(state.dogTagMax),
    Vip: numberAttribute(dto.vipExpiration),
    VipStart: numberAttribute(state.vipStart),
    SendLogs: numberAttribute(dto.sendLogsValue),
    Settings: stringAttribute(dto.notificationSettings),
  };

  // These names are the nested C# type names used as lookup keys by
  // DatabaseSerializedObjectGeneric<T>.Load; the DTO property casing is intentionally not
  // copied onto the wire.
  addSerializedObject(data, "InventoryData", state.itemInventory?.inventoryData ?? dto.inventoryData);
  addSerializedObject(data, "LevelManagerData", state.itemInventory?.levelManagerData ?? dto.levelManagerData);
  addSerializedObject(data, "DecalManagerData", state.visualInventory);
  addSerializedObject(data, "CardManagerData", state.cardInventory);
  addSerializedObject(data, "StatisticsData", dto.statisticsData);

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
    state.starterAssignments ?? {
      deadline: Math.floor(player.createdAt.getTime() / 1_000)
        + Math.max(0, Math.floor(config.starterAssignmentDurationSeconds)),
      assignments: {},
    },
  );

  // PlayerAnalytics derives from DatabaseSerializedObjectGeneric<PlayerAnalyticsData>, so
  // this exact nested type name is the boot lookup key. The real chat channel is Photon
  // Chat, but its cross-device unread cursor is persisted by Beanstalk action 193. Sending
  // only the recovered server-owned field is equivalent to the client's current LoadEmpty
  // behavior for the remaining analytics fields while restoring the cursor correctly.
  addSerializedObject(data, "PlayerAnalyticsData", {
    lastSeenSquadChatTimeStampDB: state.lastSeenSquadChatTimestamp ?? 0,
  });

  if (dto.facebookId !== -1) data.FacebookName = { S: dto.accountName };
  return data;
}

/** Fields common to CreateAccount and the mandatory post-login GetPlayerData refresh. */
export function buildPlayerStateResponse(player: PlayerDocument, now = unixNow()): Record<string, unknown> {
  return {
    Time: now,
    BeginnersLeague: player.player.beginnersLeague,
    LeagueId: player.player.leagueId,
    Skill: player.player.skill,
    MedalsBalance: player.player.medalsBalance,
    PlacementMatchesRequired: player.player.remainingMatches,
    UtcOffset: 0,
    DeviceToken: player.player.deviceToken,
    PlayerData: buildPlayerData(player),
    // JLMICAJOHIK/EGPLNLMMADN both log an error and leave the Arena closed when this key is
    // absent. The value is the Dynamo-style document consumed by IKPLPPFFDNI, not a string.
    WarArenaConfig: warArenaConfiguration(now),
  };
}
