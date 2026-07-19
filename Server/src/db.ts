import { MongoClient, type ClientSession, type Collection, type Db, type Document } from "mongodb";
import { config } from "./config";
import type { DatabasePlayerDTO, SquadDTO } from "./dtos";
import {
  syncGameCatalog,
  type GameCatalogEntryDocument,
  type GameCatalogReleaseDocument,
} from "./services/gameCatalogService";

// One document per account. Top-level fields are indexed for lookup/matchmaking; the full
// client-facing snapshot lives in `player` (DatabasePlayerDTO), mirroring the reference
// backend's playerJson pattern.
export interface PlayerDocument {
  id: string;
  accountName: string;
  /** Lower-cased name used only for case-insensitive uniqueness checks. */
  normalizedAccountName?: string;
  /** Legacy/server-issued opaque token. Removed after a human password replaces it. */
  authToken?: string;
  /** Keyed digest used for human-entered custom-account passwords. */
  authTokenHash?: string;
  accountType: number;
  facebookId?: string;
  googlePlayId?: string;
  gameCenterId?: string;
  deviceToken?: string;
  // Indexed matchmaking + leaderboard dimensions (kept in sync with player on write).
  leagueTier: number;
  armyPower: number;
  experience: number;
  squadPoints: number;
  squadName: string;
  player: DatabasePlayerDTO;
  /**
   * Server-owned values loaded through the client's `PlayerData` attribute map.
   *
   * These values deliberately do not live inside DatabasePlayerDTO. The recovered client
   * reads currencies, dog tags, and level progress from DynamoDB-style `{ N: "..." }`
   * attributes, while DatabasePlayer contains only identity/profile fields. Keeping the
   * stores separate prevents a public player/leaderboard snapshot from leaking balances
   * and gives future economy handlers one authoritative place for atomic mutations.
   *
   * Optionality is a migration boundary for accounts created before this field existed.
   * Response adapters apply safe defaults; future state-changing handlers must initialize
   * and persist the field before attempting an atomic balance update.
   */
  progression?: PlayerProgressionState;
  createdAt: Date;
  updatedAt: Date;
}

export interface PlayerProgressionState {
  schemaVersion: 1;
  /** Monotonic optimistic-concurrency version for atomic economy mutations. */
  revision: number;
  gold: number;
  warBucks: number;
  tickets: number;
  scraps: number;
  levelExperience: number;
  /** Accumulated energy-time credit; the client derives tag count by dividing by refill seconds. */
  dogTagSeconds: number;
  /** Transitional field written by an early reconstruction build; read-only migration support. */
  dogTags?: number;
  dogTagLastUpdate: number;
  dogTagMax: number;
  dogTagRefillSeconds: number;
  vipStart: number;
  /**
   * Monthly login-calendar cursor. `canClaim` counts distinct UTC days seen by the server;
   * `claimReward` counts rewards already collected in order. Keeping both counters makes a
   * check request idempotent and prevents a client from skipping directly to a later prize.
   */
  dailyReward?: DailyRewardState;
  /** Daily PvP objectives and their long-running mega-reward cursor. */
  assignments?: AssignmentState;
  /**
   * Server-issued daily/co-op/heroic missions and their replay-safe battle receipts.
   *
   * The public part mirrors DailyMissionsManager.DailyMissionsData exactly. Additional
   * lifecycle fields never leave the backend; they bind GameEnded to a prior start action
   * and retain the original response when Unity retries after losing an HTTP response.
   */
  dailyMissions?: DailyMissionsState;
  /**
   * Authoritative weapon ownership and equipment state.
   *
   * `inventoryData` and `levelManagerData` deliberately preserve the exact nested field
   * names used by PlayerInventory.InventoryData and LevelManager.LevelManagerData. Keeping
   * them inside progression lets a buffered purchase debit currency and grant ownership in
   * the same optimistic-concurrency write instead of trusting the client's serialized blob.
   */
  itemInventory?: ItemInventoryState;
  /**
   * Authoritative player-customization ownership and equipped slots.
   *
   * The field names intentionally match CamosManager.DecalManagerData. Cosmetic purchases,
   * temporary power-band expiry, notification flags, and all four equipped category slots
   * therefore cross the wire without a second client-specific translation model.
   */
  visualInventory?: VisualInventoryState;
  /**
   * Authoritative normal War Card counts and squad-card timing fields.
   *
   * The public shape is CardManager.CardManagerData. Pack purchases update this object in
   * the same optimistic-concurrency transaction as Gold/WarBucks so a replay cannot grant
   * the client-selected pack contents twice.
   */
  cardInventory?: CardInventoryState;
  /** Timed three-for-one recipe consumed by CardCraftingManager.CraftData. */
  cardCrafting?: CardCraftingState;
  /**
   * Number of War Cards consumed by confirmed PvP settlements.
   *
   * The stock client keeps the equivalent lifetime value in StatsManager.cardsPlayed, but
   * that serialized client counter is not authoritative. This backend counter advances only
   * while the matching inventory cards and PvP rewards commit together.
   */
  warCardsPlayed?: number;
  /** Private proof used by StarterAssignmentCraftCard; never serialized inside CraftData. */
  goldCardsCrafted?: number;
  /**
   * Persistent War Arena run state consumed by WarArena.WarArenaData.
   *
   * The recovered client keeps this object in PlayerData and receives the same public shape
   * from EnterArena/debug responses. Private receipt and replay fields remain in MongoDB so
   * a modified client cannot fabricate an arena start or claim one battle twice.
   */
  warArena?: WarArenaState;
  /**
   * Authoritative achievement counters and claimed tiers.
   *
   * The recovered client evaluates achievements locally and queues actions 218-220, but
   * locally evaluated values cannot be trusted for rewards. The server therefore stores the
   * same serialized shape while advancing supported counters only from server-confirmed
   * events such as match settlement, assignment claims, and daily-reward claims.
   */
  achievements?: AchievementState;
  /**
   * Limited-time onboarding chain consumed by StarterAssignmentsManager.
   *
   * Completion and claim flags are kept together with currency balances so a buffered claim
   * can atomically flip `claimed` and grant its server-defined reward. The dictionary keys
   * intentionally retain the recovered `ID_#` spelling used by the Unity JSON model.
   */
  starterAssignments?: StarterAssignmentState;
  /**
   * Highest squad-chat message timestamp the player has opened.
   *
   * Photon Chat transports the actual channel messages in the recovered client, but the
   * Beanstalk backend persists this cursor through RequestBuffer action 193. It is kept in
   * server-owned progression so a modified client cannot overwrite another player's unread
   * state and so reconnects/devices restore one monotonic value.
   */
  lastSeenSquadChatTimestamp?: number;
  /** Number of successful squad creations; the stock client derives the next WarBucks price from it. */
  squadCreationsCount?: number;
  /** Bounded replay cache for the stock client's batched RequestBuffer transport. */
  processedRequestBuffers?: ProcessedRequestBuffer[];
}

export interface DailyRewardState {
  year: number;
  month: number;
  canClaim: number;
  claimReward: number;
  /** YYYY-MM-DD UTC date on which availability was last advanced. */
  lastCheckDay: string;
}

/** PlayerInventory.SerializedSlotDetail from the recovered 1.6.0 client. */
export interface SerializedWeaponSlotState {
  name: string;
  weaponIndex: number;
}

/** PlayerInventory.InventoryData; JSON dictionary keys are numeric slot indexes as strings. */
export interface PlayerInventoryDataState {
  slots: Record<string, SerializedWeaponSlotState>;
}

/** LevelManager.SavedWeaponSlots from the recovered client. */
export interface SavedWeaponState {
  bought: boolean;
  boughtIndex: number;
  showed: boolean;
  borrowed: boolean;
  specialFeature: number;
}

/**
 * LevelManager.SavedArmySlots from the recovered client.
 *
 * These names intentionally follow the Unity/Newtonsoft wire contract rather than normal
 * TypeScript naming conventions. In particular, `tier` is the unit's starting/active tier,
 * while `boughtIndex` is its normal-upgrade cursor; treating those fields as interchangeable
 * would make a newly purchased high-tier unit appear to have completed the wrong upgrades.
 */
export interface SavedArmyState {
  bought: boolean;
  boughtIndex: number;
  specialSlot: number;
  showed: boolean;
  tier: number;
  borrowed: boolean;
  wasEquipped: boolean;
  equipped: boolean;
  eliteSlot: number;
  parts: number;
}

/** LevelManager.ItemDelivery, retained even for zero-duration premium purchases. */
export interface ItemDeliveryState {
  activationNeeded: boolean;
  boughtIndex: number;
  end: number;
  itemId: string;
  slotId: number;
  start: number;
}

/**
 * Public subset of LevelManager.LevelManagerData currently owned by the server.
 *
 * Unit and weapon collections remain in the exact wire shape Unity loads. Unit ownership is
 * now server-owned for the recovered zero-delivery purchase path; promotion, upgrade, and
 * equipped-unit power mutations remain disabled until their additional rules are recovered.
 */
export interface LevelManagerDataState {
  savedArmies: Record<string, SavedArmyState>;
  savedWeapons: Record<string, SavedWeaponState>;
  unitDelivery: ItemDeliveryState;
  weaponDelivery: ItemDeliveryState;
}

export interface ItemInventoryState {
  inventoryData: PlayerInventoryDataState;
  levelManagerData: LevelManagerDataState;
}

/** CamosManager.SavedPlayerVisual from the recovered client. */
export interface SavedVisualState {
  bought: boolean;
  showed: boolean;
  expiresOn: number;
  borrowed: boolean;
  parts: number;
  notificate: boolean;
}

/** CamosManager.SavedPlayerVisualSlot from the recovered client. */
export interface SavedVisualSlotState {
  equippedID: string;
}

/** CamosManager.DecalManagerData; numeric category keys serialize as JSON object keys. */
export interface VisualInventoryState {
  visuals: Record<string, SavedVisualState>;
  slots: Record<string, SavedVisualSlotState>;
  previousHeadDecal: string;
}

/** CardManager.CardData from the recovered client. */
export interface SavedCardState {
  amount: number;
}

/**
 * CardManager.BuddyCardData. Buddy cards are not granted by normal card packs, but the exact
 * fields are retained so squad deposit/withdraw implementation can share this state later.
 */
export interface SavedBuddyCardState {
  amount: number;
  buddyName: string;
  equippedVisuals: Record<string, SavedVisualSlotState>;
  unityType: number;
  primaryWeapon: number;
  secondaryWeapon: number;
  armypower: number;
  level: number;
}

/** CardManager.CardManagerData; property names intentionally match Newtonsoft JSON. */
export interface CardInventoryState {
  cardData: Record<string, SavedCardState>;
  buddyCardData: Record<string, SavedBuddyCardState>;
  nextWithdraw: number;
  nextBuddyDeposit: number;
  extraSlot: boolean;
}

/** CardCraftingManager.CraftData; only these three fields are serialized to Unity. */
export interface CardCraftingState {
  cards: string[];
  start: number;
  end: number;
}

export interface AssignmentRecordState {
  id: number;
  done: boolean;
  claimed: boolean;
  /** Current-day progress expressed as a fraction of `target`, matching Unity's model. */
  completeFract: number;
  /** Progress carried from previous matches before the current local battle update. */
  lastCompletedFract: number;
  target: number;
  secondTarget: number;
  tutorialId: number;
}

export interface AssignmentState {
  assignments: AssignmentRecordState[];
  /** Unix timestamp of the next UTC assignment reset. */
  tomorrow: number;
  completed: number;
  issued: number;
  /** JSON name recovered from AssignmentsManager.AssignmentData. */
  megaReward: number;
  skipUsed: boolean;
  /** Server-only reset key; extra JSON fields are not sent to Unity. */
  dayKey: string;
}

export interface MissionUnitState {
  /** JsonProperty("i") in MissionUnit.cs: index into LevelManager.behaviours. */
  i: number;
  /** JsonProperty("vet") in MissionUnit.cs. */
  vet: boolean;
  /** JsonProperty("eli") in MissionUnit.cs. */
  eli: boolean;
  /** JsonProperty("lev") in MissionUnit.cs; Unity recalculates this from mission difficulty. */
  lev: number;
}

/**
 * Exact SavedMission JSON fields consumed by DailyMissionsManager.FEKGKHNDNHH.
 * `cnf` is intentionally an object rather than an opaque string because the client treats
 * it as JToken and immediately converts it to the selected mission's config class.
 */
export interface DailyMissionRecordState {
  type: "DailyMissionKillUnits" | "DailyMissionSurvive" | "DailyMissionWaves" | "DailyMissionBoss";
  cnf: {
    units: MissionUnitState[];
    [key: string]: unknown;
  };
  completedSolo: boolean;
  completedCoop: boolean;
}

export type DailyMissionMode = "Daily" | "Coop" | "CoopClient" | "Heroic";

/** Server-only proof that an authenticated start action preceded GameEnded. */
export interface DailyMissionSessionState {
  battleId: string;
  /** 67 campaign, 68 co-op master, or 69 co-op client. */
  startAction: number;
  startedAt: number;
  dayKey: string;
}

/**
 * Stored response for one consumed battle ID. Retaining it is required for transport-level
 * idempotency: a retry must return the same reward result, not fail after the first commit.
 */
export interface DailyMissionSettlementState {
  battleId: string;
  missionIndex: number;
  missionType: DailyMissionMode;
  endReason: number;
  settledAt: number;
  response: Record<string, unknown>;
}

/**
 * The first nine fields are the exact DailyMissionsData contract from the recovered client.
 * Fields below `heroicUnitReward` are backend-only lifecycle and idempotency metadata and
 * are removed by dailyMissionsWireData before serialization.
 */
export interface DailyMissionsState {
  dailyMissions: DailyMissionRecordState[];
  heroicMissions: DailyMissionRecordState[];
  heroicPoints: number;
  isHeroicOpened: boolean;
  tomorrow: number;
  dailyMissionRewardInd: number;
  dailyMissionLevel: number;
  heroicMissionLevel: number;
  heroicUnitReward: string;
  dayKey: string;
  dailyCompletionRewardClaimed: boolean;
  heroicCompletionRewardClaimed: boolean;
  activeSessions: DailyMissionSessionState[];
  recentSettlements: DailyMissionSettlementState[];
}

/** Server-issued proof that action 64 started the current War Arena battle. */
export interface WarArenaBattleSessionState {
  battleId: string;
  startedAt: number;
  arenaId: string;
}

/** Replay record for action 62, keyed by the client BattleId. */
export interface WarArenaSettlementState {
  battleId: string;
  endReason: number;
  settledAt: number;
  response: Record<string, unknown>;
}

/**
 * The first thirteen fields exactly mirror WarArena.WarArenaData in the recovered client.
 * Fields after `heartDialogShown` are backend-only authority and idempotency metadata; use
 * warArenaWireData before sending this object to Unity.
 */
export interface WarArenaState {
  wins: number;
  lives: number;
  opponents: string[];
  arenaId: string;
  runs: number;
  visualType: string;
  visualTimestamp: number;
  flawless: number;
  topRun: number;
  matches: number;
  shields: number;
  played: boolean;
  heartDialogShown: boolean;
  runLosses: number;
  runRewardClaimed: boolean;
  activeBattle?: WarArenaBattleSessionState;
  recentSettlements: WarArenaSettlementState[];
  lastEntryResponse?: Record<string, unknown>;
  lastHeartPurchaseAt?: number;
  lastHeartResponse?: Record<string, unknown>;
  lastRunRewardResponse?: Record<string, unknown>;
}

/** One claimed flag per configured tier, matching AchievementProgressData. */
export interface AchievementTierState {
  claimed: boolean;
}

/**
 * Exact fields consumed by AchievementProgressGroupData in the 1.6.0 client.
 * `offset` and `value` are deliberately named after their JsonProperty attributes rather
 * than the decompiled C# member names (`localOffset` and `localCurrentValue`).
 */
export interface AchievementGroupState {
  id: number;
  offset: number;
  value: number;
  progress: AchievementTierState[];
}

/** `data` is the JsonProperty name on AchievementProgressGroups.AchievementsData. */
export interface AchievementState {
  data: AchievementGroupState[];
}

export interface StarterAssignmentRecordState {
  completed: boolean;
  claimed: boolean;
}

/** Exact JSON fields consumed by StarterAssignmentsManager.StarterAssignmentsData. */
export interface StarterAssignmentState {
  deadline: number;
  assignments: Record<string, StarterAssignmentRecordState>;
}

export interface ProcessedRequestBuffer {
  id: string;
  result: string;
  processedAt: number;
}

export interface SquadDocument extends SquadDTO {
  createdAt: Date;
  updatedAt: Date;
}

/**
 * Server-only authentication record for a linked platform account.
 *
 * Provider credentials are intentionally kept outside DatabasePlayer because that player
 * snapshot is returned to Unity and copied into social/leaderboard payloads. Only a keyed
 * credential hash is stored here; the original provider password or token is never written
 * to MongoDB and can never be returned accidentally with public player data.
 */
export interface IdentityDocument {
  provider: "facebook" | "googlePlay" | "gameCenter";
  externalId: string;
  playerId: string;
  credentialHash: string;
  displayName: string;
  createdAt: Date;
  updatedAt: Date;
}

const client = new MongoClient(config.mongoUrl, { maxPoolSize: config.mongoPoolSize });

let db: Db | null = null;
let playersCollection: Collection<PlayerDocument> | null = null;
let squadsCollection: Collection<SquadDocument> | null = null;
let matchesCollection: Collection<Document> | null = null;
let messagesCollection: Collection<Document> | null = null;
let identitiesCollection: Collection<IdentityDocument> | null = null;
let reportsCollection: Collection<Document> | null = null;
let gameCatalogEntriesCollection: Collection<GameCatalogEntryDocument> | null = null;
let gameCatalogReleasesCollection: Collection<GameCatalogReleaseDocument> | null = null;

export async function connectMongo(): Promise<void> {
  await client.connect();
  db = client.db(config.mongoDbName);

  playersCollection = db.collection<PlayerDocument>("players");
  squadsCollection = db.collection<SquadDocument>("squads");
  matchesCollection = db.collection("matches");
  messagesCollection = db.collection("messages");
  identitiesCollection = db.collection<IdentityDocument>("identities");
  reportsCollection = db.collection("playerReports");
  gameCatalogEntriesCollection = db.collection<GameCatalogEntryDocument>("gameCatalogEntries");
  gameCatalogReleasesCollection = db.collection<GameCatalogReleaseDocument>("gameCatalogReleases");

  await playersCollection.createIndex({ id: 1 }, { unique: true });
  await playersCollection.createIndex({ authToken: 1 });
  await playersCollection.createIndex({ accountName: 1 });
  // Sparse keeps recovered legacy rows valid until their first profile update, while all
  // newly created/renamed accounts receive a case-insensitive unique key.
  await playersCollection.createIndex({ normalizedAccountName: 1 }, { unique: true, sparse: true });
  await playersCollection.createIndex({ facebookId: 1 }, { sparse: true });
  await playersCollection.createIndex({ googlePlayId: 1 }, { sparse: true });
  // Matchmaking scan: opponents near league + army power.
  await playersCollection.createIndex({ leagueTier: 1, armyPower: 1 });
  // Leaderboards.
  await playersCollection.createIndex({ experience: -1 });

  await squadsCollection.createIndex({ name: 1 }, { unique: true });
  await squadsCollection.createIndex({ experience: -1 });
  await squadsCollection.createIndex({ squadPoints: -1 });

  await matchesCollection.createIndex({ matchId: 1 }, { unique: true });
  await matchesCollection.createIndex({ "players.playerId": 1, createdAt: -1 });
  // Inbox reads exclude soft-ignored rows and sort newest first, so one compound index covers
  // the ownership filter, visibility filter, and ordering without an in-memory sort.
  await messagesCollection.createIndex({ toPlayerId: 1, ignored: 1, createdAt: -1 });
  // Outgoing-message rate limits use this index for a bounded rolling-window count.
  await messagesCollection.createIndex({ fromPlayerId: 1, createdAt: -1 });
  // Only expiring message types carry expiresAt. MongoDB's TTL monitor removes stale
  // challenges asynchronously; read/accept filters enforce expiry immediately meanwhile.
  await messagesCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });
  // Squad-event notifications use a deterministic idempotency key. A unique sparse index
  // prevents simultaneous retries from inserting duplicate message-center entries while
  // remaining compatible with all legacy message rows, which do not have this field.
  await messagesCollection.createIndex({ idempotencyKey: 1 }, { unique: true, sparse: true });
  // One external identity cannot authenticate two different WarFriends players.
  await identitiesCollection.createIndex({ provider: 1, externalId: 1 }, { unique: true });
  // A player may link multiple providers, but only one identity from each provider.
  await identitiesCollection.createIndex({ provider: 1, playerId: 1 }, { unique: true });
  // Moderation reads primarily group unresolved reports by target. The reporter/time index
  // supports the rolling abuse-rate limit without scanning the complete collection.
  await reportsCollection.createIndex({ reportedPlayerId: 1, status: 1, createdAt: -1 });
  await reportsCollection.createIndex({ reporterPlayerId: 1, createdAt: -1 });

  // Catalog entries are immutable per content revision. The four-part unique key makes a
  // repeated startup idempotent while still retaining prior recovered releases for audit and
  // rollback. Gameplay reads first resolve gameCatalogReleases, then query this exact index.
  await gameCatalogEntriesCollection.createIndex(
    { clientVersion: 1, catalogRevision: 1, kind: 1, key: 1 },
    { unique: true },
  );
  await gameCatalogEntriesCollection.createIndex(
    { clientVersion: 1, catalogRevision: 1, availability: 1, kind: 1 },
  );
  // One pointer per client version identifies the only complete revision visible to readers.
  await gameCatalogReleasesCollection.createIndex({ clientVersion: 1 }, { unique: true });

  // Publish checked-in client data during boot. syncGameCatalog writes every immutable entry
  // before moving the release pointer, so a process failure cannot expose half a catalog.
  await syncGameCatalog(gameCatalogEntriesCollection, gameCatalogReleasesCollection);
}

export async function disconnectMongo(): Promise<void> {
  await client.close();
  db = null;
  playersCollection = null;
  squadsCollection = null;
  matchesCollection = null;
  messagesCollection = null;
  identitiesCollection = null;
  reportsCollection = null;
  gameCatalogEntriesCollection = null;
  gameCatalogReleasesCollection = null;
}

/**
 * Execute a multi-document gameplay mutation in one MongoDB transaction.
 *
 * Squad-card withdrawal moves ownership between two player documents. A pair of unrelated
 * updateOne calls would have an unavoidable crash window in which the card is either lost or
 * duplicated. The driver's withTransaction helper retries transient transaction conflicts and
 * commits the donor-pool decrement together with the recipient-inventory grant.
 *
 * Production and local deployments that enable cross-player economy actions must therefore use
 * a replica set or sharded MongoDB deployment; standalone MongoDB does not support transactions.
 */
export async function withMongoTransaction<T>(work: (session: ClientSession) => Promise<T>): Promise<T> {
  return client.withSession(async (session) => {
    let result: T | undefined;
    await session.withTransaction(async () => {
      result = await work(session);
    }, {
      readConcern: { level: "snapshot" },
      writeConcern: { w: "majority" },
    });
    if (result === undefined) throw new Error("MongoDB transaction completed without a result.");
    return result;
  });
}

function requireCollection<T extends Document>(name: string, value: Collection<T> | null): Collection<T> {
  if (!value) throw new Error(`MongoDB collection ${name} is not connected.`);
  return value;
}

export function players(): Collection<PlayerDocument> {
  return requireCollection("players", playersCollection);
}

export function squads(): Collection<SquadDocument> {
  return requireCollection("squads", squadsCollection);
}

export function matches(): Collection<Document> {
  return requireCollection("matches", matchesCollection);
}

export function messages(): Collection<Document> {
  return requireCollection("messages", messagesCollection);
}

export function identities(): Collection<IdentityDocument> {
  return requireCollection("identities", identitiesCollection);
}

export function reports(): Collection<Document> {
  return requireCollection("playerReports", reportsCollection);
}

export function gameCatalogEntries(): Collection<GameCatalogEntryDocument> {
  return requireCollection("gameCatalogEntries", gameCatalogEntriesCollection);
}

export function gameCatalogReleases(): Collection<GameCatalogReleaseDocument> {
  return requireCollection("gameCatalogReleases", gameCatalogReleasesCollection);
}
