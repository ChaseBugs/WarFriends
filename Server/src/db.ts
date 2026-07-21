import { MongoClient, type ClientSession, type Collection, type Db, type Document } from "mongodb";
import { config } from "./config";
import { runtimeInfrastructurePolicy } from "./services/runtimeInfrastructurePolicyService";
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
  /** Rotatable opaque gameplay token; kept separate from any durable password digest. */
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
  /**
   * Normal-cap energy-time credit. It may be negative down to two refill intervals after the
   * player consumes virtual VIP tags; the client adds the active VIP bonus before rendering.
   */
  dogTagSeconds: number;
  /** Transitional field written by an early reconstruction build; read-only migration support. */
  dogTags?: number;
  dogTagLastUpdate: number;
  /** Normal five-tag cap in seconds; VIP capacity is derived from its deadline, not stored here. */
  dogTagMax: number;
  dogTagRefillSeconds: number;
  vipStart: number;
  /**
   * Unix deadline for the paid VIP entitlement.
   *
   * Older reconstruction documents kept this only in `player.vipExpiration`. New economy
   * mutations store it beside the wallet so buying VIP, spending Gold, and unlocking VIP-only
   * inventory are one optimistic transaction. The response adapter retains a legacy fallback.
   */
  vipExpiration?: number;
  /** SubscriptionManager.Subscription plus the timer boundary consumed by DogTagManager. */
  subscription?: PlayerSubscriptionState;
  /**
   * HMAC receipt key that currently owns the subscription projection above.
   *
   * This value is private and is never included in PlayerData. It prevents an older canceled
   * token from revoking a newer replacement subscription when background checks run out of order.
   */
  subscriptionAuthorityReceiptId?: string;
  /** True only after the authenticated account completes action 120 once. */
  tutorialFinished?: boolean;
  /** Server-issued tutorial battle receipt consumed by TutorialEnded. */
  tutorialBattle?: TutorialBattleState;
  /**
   * True after the level-six Play Warcards tutorial has paid its fixed five-card reward.
   *
   * This is separate from `tutorialFinished`: that older flag belongs to the opening bootcamp,
   * while TutorialManagerPlayWarcards starts later when PlayerAnalyticsData.cardTutState is 1.
   * Keeping a durable terminal marker prevents action-62 retries from duplicating cards.
   */
  warcardsTutorialFinished?: boolean;
  /**
   * Server proof that the offline bot battle reported by action 64 actually started.
   *
   * The stock client sends `TutorialWarcards=1` only on GameEnded, but that flag is forgeable.
   * Binding completion to this earlier BattleId makes an isolated action-62 request insufficient.
   */
  warcardsTutorialBattle?: TutorialBattleState;
  /**
   * Monotonic feature-introduction flags stored by the client's dedicated shown actions.
   *
   * These are public PlayerAnalyticsData fields, not economic authority. Persisting them keeps
   * one-time onboarding dialogs from reopening on another device or after local-data loss.
   */
  featureIntroductions?: PlayerFeatureIntroductionState;
  /**
   * Confirmed VIP PvP battles remaining before the next two visual-part lootboxes.
   *
   * The recovered PlayerAnalyticsData field is named `matchesToNextLootboxes`, and the
   * 4.9.5 Constants row `LootboxAfterBattles` decodes to four. The value is private economy
   * authority even though it is projected into PlayerAnalyticsData and GameEnded: only an
   * atomically settled match may decrement it, while reconnects and client analytics writes
   * must never advance or reset the cycle.
   */
  matchesToNextLootboxes?: number;
  /**
   * Exactly-once action-161 reward markers, keyed by the server-approved Constants DBKEY.
   *
   * Unity keeps the same dictionary in `PlayerAnalyticsData.collectedRewards` and uses key
   * presence to hide social/onboarding reward buttons after a restart. The values are kept as
   * integers because that is the recovered `Dictionary<string, int>` wire type; the backend
   * treats only value 1 as collected and never accepts this dictionary from the client.
   */
  collectedRewards?: Record<string, number>;
  /**
   * Private once-per-UTC-day cursor for the two paid-VIP War Cards.
   *
   * This state is deliberately not part of CardManagerData. Unity receives the granted cards
   * through the normal authoritative card inventory, while this cursor prevents a reconnect,
   * repeated GetPlayerData call, or VIP renewal from granting the same calendar day's pair
   * again. `lastRewardIds` is retained for audit/debugging and never acts as inventory itself.
   */
  vipDailyCards?: VipDailyCardRewardState;
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
   * Limited-time EventAssignmentManager state for the separately configured daily event.
   *
   * `progress` and `milestones` use stringified zero-based indexes because JSON object keys
   * become strings in MongoDB and in the recovered Dictionary<int, ...> wire model. The
   * configuration digest is private server authority: it prevents an operator from changing
   * rewards or targets underneath an already-started event while retaining the same event ID.
   */
  eventAssignment?: EventAssignmentState;
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
  /**
   * Server-owned timed ranked-PvP win streak.
   *
   * Unity persists the public equivalent as a serialized `WinStreak` object with
   * `WinCount` and `TimeStamp`. Lower-case names here keep private authority distinct from
   * that wire model and prevent the client from choosing its own reward tier.
   */
  pvpWinStreak?: PvpWinStreakState;
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
   * events such as match settlement, assignment claims, daily-reward claims, and the
   * DatabasePlayer league tier committed by placement/season settlement.
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
  /**
   * Durable outbox for stock RequestBuffer action 12.
   *
   * Message documents live outside the embedded progression object. Recording the recipient's
   * requested message IDs here in the same write as BufferId makes the later idempotent inbox
   * update retryable across a process stop, without letting a reused BufferId target new data.
   */
  pendingMessageIgnores?: string[];
  /** Number of successful squad creations; the stock client derives the next WarBucks price from it. */
  squadCreationsCount?: number;
  /**
   * Authoritative recharge and reward history for action 199 (Instant Battle / Skirmish).
   *
   * The three public counters are projected into `PlayerAnalyticsData`, because the stock
   * client calculates the visible charge count and next Gold price from them. `lastReceipt`
   * is private: action 199 has no operation UUID, so retaining the receipt lets the server
   * collapse an immediate same-second transport replay without granting or charging twice.
   */
  instantBattle?: InstantBattleState;
  /**
   * Server-owned action-156 rate-limit ledgers and narrow transport replay receipt.
   *
   * The recovered Fuse SDK callback proves completion only inside the client process; it does
   * not send a provider-signed receipt to Beanstalk. These timestamps therefore cannot prove an
   * advertisement impression, but they do enforce the exact source count/window policy on the
   * only authority that can grant inventory. They are projected to Unity as
   * `videoAdRewardTimes`, matching EventTrackingManager.KHHOMCIOKAO.MENAHKIIFOC.
   */
  videoAdRewards?: VideoAdRewardState;
  /** Narrow replay receipt for action 221, whose stock request has no operation UUID. */
  warBucksConversion?: WarBucksConversionReceiptState;
  /**
   * Server-issued Black Market weapon offers consumed by action 217 and buffered BuyWeapon.
   *
   * The public fields intentionally match BlackMarketManager.BlackMarketOfferData. Keeping
   * the selected weapon level and special feature in the same progression snapshot as the
   * wallet lets BuyWeapon prove that a premium price came from a still-active offer instead
   * of accepting an arbitrary price or upgraded weapon chosen by a modified client.
   */
  blackMarket?: BlackMarketOfferState;
  /**
   * Current two-stage daily rental offer consumed by GetPlayerData, GameEnded, and action 138.
   *
   * The stock request contains only `buyRentalDiscounted`; it never sends an item identity,
   * discount, or price. Those values must therefore remain server-owned between the initial
   * free trial, the post-battle sale, and final redemption. Private expiry/battle fields are
   * intentionally stored outside the public `Rental` object returned to Unity.
   */
  rental?: RentalOfferState;
  /** Bounded replay cache for the stock client's batched RequestBuffer transport. */
  processedRequestBuffers?: ProcessedRequestBuffer[];
}

export interface PlayerSubscriptionState {
  type: "subscription1";
  expireTime: number;
  subscribeSince: number;
  dogTagTimerLock: number;
}

/** Exact JSON property names parsed by the recovered EventTrackingManager. */
export interface VideoAdRewardTimesState {
  warcards: number[];
  dogtags: number[];
  goldenSuitcase: number[];
  lootboxes: number[];
}

export interface VideoAdRewardReceiptState {
  reward: 1 | 2 | 3 | 4;
  settledAt: number;
  progressionRevision: number;
  /** Immutable stock-client response payload returned by an immediate transport replay. */
  response: Record<string, unknown>;
}

export interface VideoAdRewardState {
  times: VideoAdRewardTimesState;
  lastReceipt?: VideoAdRewardReceiptState;
}

export interface PvpWinStreakState {
  winCount: number;
  timestamp: number;
}

/** Exact boolean field names recovered from PlayerAnalytics.PlayerAnalyticsData. */
export interface PlayerFeatureIntroductionState {
  chatShown?: boolean;
  elitesShown?: boolean;
  customizationShown?: boolean;
  warpathShown?: boolean;
  cardpoolShown?: boolean;
  craftingShown?: boolean;
  leagueLeaderboardsShown?: boolean;
}

export interface TutorialBattleState {
  battleId: string;
  startedAt: number;
}

/** Immutable action-199 result fields needed by the recovered OGLEHLIPEFM parser. */
export interface InstantBattleReceiptState {
  settledAt: number;
  /** Progression revision produced by this settlement; required by the narrow replay guard. */
  progressionRevision: number;
  paidCost: number;
  battleCount: number;
  experienceGained: number;
  warBucks: number;
  levelFrom: number;
  levelTo: number;
  levelExperience: number;
  levelGold: number;
  dogTagsRefilled: boolean;
}

/** PlayerAnalyticsData's public Skirmish counters plus one private replay receipt. */
export interface InstantBattleState {
  /** Unix anchor used by `GetInstantBattlesReady`; zero means the initial full batch. */
  instantBattlesTime: number;
  /** Lifetime number of simulated battles, retained for the client's analytics model. */
  instantBattles: number;
  /** Lifetime number of paid five-battle batches; this drives the 35/70/140 Gold curve. */
  paidInstantBattles: number;
  lastReceipt?: InstantBattleReceiptState;
}

export interface WarBucksConversionReceiptState {
  id: string;
  goldDeducted: number;
  warBucksAdded: number;
  processedAt: number;
  progressionRevision: number;
}

/** BlackMarketManager.OfferedWeapon from the recovered 1.6.0 client. */
export interface BlackMarketOfferedWeaponState {
  level: number;
  special: number;
  weaponId: string;
}

/** BlackMarketManager.BlackMarketOfferData from the recovered 1.6.0 client. */
export interface BlackMarketOfferState {
  /** Lifetime number of offer sets issued to this account. */
  offersTotal: number;
  /** Analytics label describing which server path generated the current set. */
  lastTrigger: string;
  /** Unix timestamp after which neither display nor purchase is authorized. */
  offerEnd: number;
  currentOffers: BlackMarketOfferedWeaponState[];
}

/** DKHAOLDJLMK from the recovered client: unit, weapon, or player visual. */
export type RentalItemType = 0 | 1 | 2;

/** Server lifecycle states corresponding to AINIEKCODDE and the two RentalDialog variants. */
export type RentalOfferStatus = "offered" | "trial" | "sale" | "purchased" | "cooldown";

export interface RentalOfferState {
  /** Stable catalog identity; action 138 is not allowed to replace it with client input. */
  id: string;
  type: RentalItemType;
  /** Integer percentage shown by RentalDialog and used for the discounted permanent price. */
  discount: number;
  status: RentalOfferStatus;
  /** Lifetime issuance sequence used only to make reconstructed selection deterministic. */
  generation: number;
  /** Earliest time a replacement offer may be generated. */
  nextGenerate: number;
  /** Trial authority deadline; zero outside the trial state. */
  trialExpiresAt: number;
  /** Sale redemption deadline; zero until the trial has been consumed by one battle. */
  saleExpiresAt: number;
  /** Battle whose retry is allowed to reproduce the same post-trial sale response. */
  saleBattleId?: string;
  /** Weapon slot replaced by the temporary trial, restored when trial authority ends. */
  previousWeaponSlot?: SerializedWeaponSlotState & { slotIndex: number };
}

export interface DailyRewardState {
  year: number;
  month: number;
  canClaim: number;
  claimReward: number;
  /** YYYY-MM-DD UTC date on which availability was last advanced. */
  lastCheckDay: string;
}

/** Exact public EventAssignmentManager.EventAssignmentData fields plus one private digest. */
export interface EventAssignmentState {
  eventId: string;
  totalValue: number;
  progress: Record<string, { v: number; c: boolean }>;
  milestones: Record<string, boolean>;
  configHash: string;
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

/** Server-only receipt for the source-defined daily paid-VIP card benefit. */
export interface VipDailyCardRewardState {
  /** ISO YYYY-MM-DD in UTC; lexical equality is sufficient for duplicate suppression. */
  lastGrantDay: string;
  /** Authoritative server time at which the inventory mutation committed. */
  lastGrantedAt: number;
  /** The exact pair added by that transition, including a legal duplicate card ID. */
  lastRewardIds: [string, string];
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
  /**
   * Backend-only IDs whose event-opening dialog was acknowledged by action 212.
   * This is bounded by the service and deliberately omitted from WarArenaData.
   */
  shownArenaIds: string[];
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

/** One immutable scheduling window shared by every Squad Wars division. */
export interface SquadWarSeasonDocument {
  seasonId: string;
  startsAt: Date;
  endsAt: Date;
  /** Active seasons accept confirmed PvP contributions; settled seasons never reopen. */
  status: "active" | "settled";
  createdAt: Date;
  settledAt?: Date;
}

/**
 * Transactional admission counter for one reconstructed player-league tier/window.
 *
 * The player rows remain the authoritative division roster. This small document exists only to
 * allocate a monotonically increasing ordinal without a count-then-write race: every 100 committed
 * ordinals map to one bounded division, while an aborted PvP settlement rolls its increment back.
 */
export interface PlayerLeagueAllocationDocument {
  seasonKey: string;
  tier: number;
  endsAt: number;
  nextMemberOrdinal: number;
  createdAt: Date;
  updatedAt: Date;
}

export interface SquadWarMemberScore {
  playerId: string;
  name: string;
  /** Points earned by this member from confirmed ranked PvP during this round only. */
  score: number;
  /**
   * True only when the player belonged to this squad when the round was allocated and has not
   * left or been kicked since. Missing means true for rounds created before this field existed.
   * A late joiner may contribute to the shared score but cannot receive the first-week reward.
   */
  rewardEligible?: boolean;
}

export interface SquadWarEntry {
  squadId: string;
  squadIcon: string;
  /** Cumulative squad score when the round was allocated. */
  baseScore: number;
  /** Confirmed score earned after allocation. */
  score: number;
  /** Confirmed ranked wins during this round; exposed as SquadWarWins for diagnostics/UI. */
  wins: number;
  members: SquadWarMemberScore[];
}

/**
 * Durable action-124 division and its exactly-once settlement state.
 *
 * A complete division is stored in one bounded document (at most 50 squads). That makes final
 * ordering, promotion/demotion, and per-member inbox creation one MongoDB transaction instead
 * of a partially visible series of leaderboard writes.
 */
export interface SquadWarRoundDocument {
  roundId: string;
  seasonId: string;
  level: number;
  division: number;
  startsAt: Date;
  endsAt: Date;
  status: "active" | "settled";
  entries: SquadWarEntry[];
  revision: number;
  createdAt: Date;
  updatedAt: Date;
  settledAt?: Date;
}

/**
 * Server-owned shared progress for one squad in one explicitly configured event.
 *
 * This lives outside SquadDocument so ordinary roster/settings updates cannot accidentally
 * overwrite live-event progress. The unique squadId/eventId index makes action 113 idempotent
 * across retries and across multiple backend processes.
 */
export interface SquadEventProgressDocument {
  squadId: string;
  eventId: string;
  /** SHA-256 of the normalized immutable season definition used to create this row. */
  configHash: string;
  /** Zero-based active tier; equals tiers.length after the final tier is complete. */
  activeTier: number;
  tiers: Array<{
    reward: number;
    assignments: Array<{
      id: number;
      value: number;
      target: number;
      param?: string;
    }>;
  }>;
  revision: number;
  joinedAt: Date;
  updatedAt: Date;
}

/** Durable replacement for one message formerly stored and relayed by Photon Chat. */
export interface SquadChatMessageDocument {
  messageId: string;
  /** Unique sender-owned request identity; prevents reconnect/retry duplication. */
  idempotencyKey: string;
  clientMessageId: string;
  squadId: string;
  senderId: string;
  senderName: string;
  senderLevel: number;
  /** Negative values retain the recovered client's beginner-league convention. */
  senderLeague: number;
  senderSquadRank: number;
  text: string;
  createdAt: Date;
  /** MongoDB TTL cleanup; reads also exclude expired rows immediately. */
  expiresAt: Date;
}

/** Durable action-3000 record for a replay URL uploaded by an authenticated player. */
export interface VideoFeedDocument {
  videoId: string;
  playerId: string;
  /** SHA-256 identity used for per-player retry deduplication without indexing a long URL. */
  urlHash: string;
  url: string;
  createdAt: Date;
  updatedAt: Date;
  /** Bounded retention for an integration whose retired feed reader is not in the stock client. */
  expiresAt: Date;
}

/** One atomic, bounded rolling-window authority row for action 3000 publications. */
export interface VideoFeedRateLimitDocument extends Document {
  _id: string;
  key: string;
  /** At most the 20 URL reservations that can still consume the recovered 24-hour allowance. */
  entries: Array<{ urlHash: string; reservedAt: Date }>;
  updatedAt: Date;
  /** TTL cleanup is storage hygiene; application-time pruning controls admission. */
  expiresAt: Date;
  /** Last atomic decision, retained so findOneAndUpdate can return this caller's result. */
  lastUrlHash?: string;
  lastAttemptAt?: Date;
  lastAdmitted?: boolean;
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

/** Persistent LoginToCustomAccount throttle keyed by a non-reversible HMAC of the presented ID. */
export interface AuthRateLimitDocument {
  key: string;
  attemptCount: number;
  revision: number;
  windowStartedAt: Date;
  lockedUntil: Date | null;
  updatedAt: Date;
  /** TTL cleanup is storage hygiene only; application checks enforce lock expiry immediately. */
  expiresAt: Date;
}

export interface ReportRateLimitDocument {
  key: string;
  attemptCount: number;
  windowStartedAt: Date;
  updatedAt: Date;
  expiresAt: Date;
}

/** Atomic cross-node throttle for player-authored challenge and direct inbox traffic. */
export interface OutgoingMessageRateLimitDocument extends Document {
  _id: string;
  key: string;
  attemptCount: number;
  windowStartedAt: Date;
  updatedAt: Date;
  expiresAt: Date;
}

export interface ReportDeduplicationDocument {
  key: string;
  report: Document;
  reportCreatedAt: Date;
  expiresAt: Date;
}

/**
 * Append-preserving moderation decision for one account.
 *
 * Historic rows remain available after revocation/expiry for operator audit. A partial unique
 * index permits only one row whose status is `active` per player; application time checks make
 * an elapsed temporary ban non-blocking immediately, without waiting for cleanup or a TTL pass.
 */
export interface PlayerSanctionDocument extends Document {
  _id: string;
  playerId: string;
  status: "active" | "revoked" | "expired";
  reason: string;
  issuedBy: string;
  issuedAt: Date;
  durationSeconds?: number;
  expiresAt?: Date;
  operationId: string;
  revokedAt?: Date;
  revokedBy?: string;
  revocationReason?: string;
  revocationOperationId?: string;
  resolvedAt?: Date;
}

/**
 * Player-authored appeal for one active sanction.
 *
 * A unique sanctionId permits exactly one intake record per moderation decision. The public
 * support API never receives or returns the sanction's private reason/operator fields; those
 * remain available only through the authenticated moderation API.
 */
export interface PlayerAppealDocument extends Document {
  _id: string;
  sanctionId: string;
  playerId: string;
  status: "open" | "reviewing" | "accepted" | "rejected" | "withdrawn";
  message: string;
  submissionOperationId: string;
  reviewHistory?: PlayerAppealReviewEntry[];
  createdAt: Date;
  updatedAt: Date;
}

export interface PlayerAppealReviewEntry {
  operationId: string;
  fromStatus: PlayerAppealDocument["status"];
  toStatus: PlayerAppealDocument["status"];
  actor: string;
  note: string;
  createdAt: Date;
}

/**
 * Immutable receipt for one explicit moderation-retention purge.
 *
 * The operation key makes an uncertain admin retry return the first deletion counts instead of
 * running a second, differently-scoped purge. Sanctions are deliberately absent: account-ban
 * audit records are retained indefinitely unless a future reviewed policy replaces that rule.
 */
export interface ModerationRetentionRunDocument extends Document {
  _id: string;
  operationId: string;
  actor: string;
  previewedAt: Date;
  reportBefore: Date;
  appealBefore: Date;
  deletedReports: number;
  deletedAppeals: number;
  createdAt: Date;
}

/**
 * Server-only lifecycle receipt for one participant in a no-reward PvP-shaped battle.
 *
 * The recovered Photon client creates the room before it sends the inbox challenge. The room
 * owns `battleID`, and each participant later submits action 64/65 with `IsMatchMaking=0`.
 * There is no message ID or room name in those start requests, so this receipt is deliberately
 * keyed by the only stable tuple available on both the start and GameEnded calls: authenticated
 * player ID plus battle ID. Direct challenges and offline bots never enter the ranked `matches`
 * collection and therefore can never reach its reward, league, medal, War Card, rental,
 * assignment, achievement, or squad-event settlement.
 */
export interface FriendlyBattleDocument {
  playerId: string;
  battleId: string;
  /** Missing on legacy rows means a direct Photon challenge. */
  battleKind?: "friendly" | "offline-bot";
  /** 64 for the Photon master, 65 for the Photon client. */
  startAction: 64 | 65;
  state: "active" | "finished";
  startedAt: Date;
  settledAt?: Date;
  /** Exact recovered PvP EndReason accepted by the no-reward settlement. */
  endReason?: 1 | 2 | 3 | 5 | 8;
  /** Storage cleanup only; application-level state checks never depend on TTL timing. */
  expiresAt: Date;
}

const runtimeInfrastructure = runtimeInfrastructurePolicy();
const client = new MongoClient(config.mongoUrl, { maxPoolSize: runtimeInfrastructure.mongoPoolSize });

let db: Db | null = null;
let playersCollection: Collection<PlayerDocument> | null = null;
let squadsCollection: Collection<SquadDocument> | null = null;
let playerLeagueAllocationsCollection: Collection<PlayerLeagueAllocationDocument> | null = null;
let squadWarSeasonsCollection: Collection<SquadWarSeasonDocument> | null = null;
let squadWarRoundsCollection: Collection<SquadWarRoundDocument> | null = null;
let squadEventProgressCollection: Collection<SquadEventProgressDocument> | null = null;
let squadChatMessagesCollection: Collection<SquadChatMessageDocument> | null = null;
let videoFeedCollection: Collection<VideoFeedDocument> | null = null;
let videoFeedRateLimitsCollection: Collection<VideoFeedRateLimitDocument> | null = null;
let matchesCollection: Collection<Document> | null = null;
let messagesCollection: Collection<Document> | null = null;
let identitiesCollection: Collection<IdentityDocument> | null = null;
let reportsCollection: Collection<Document> | null = null;
let authRateLimitsCollection: Collection<AuthRateLimitDocument> | null = null;
let reportRateLimitsCollection: Collection<ReportRateLimitDocument> | null = null;
let outgoingMessageRateLimitsCollection: Collection<OutgoingMessageRateLimitDocument> | null = null;
let reportDeduplicationsCollection: Collection<ReportDeduplicationDocument> | null = null;
let playerSanctionsCollection: Collection<PlayerSanctionDocument> | null = null;
let playerAppealsCollection: Collection<PlayerAppealDocument> | null = null;
let moderationRetentionRunsCollection: Collection<ModerationRetentionRunDocument> | null = null;
let friendlyBattlesCollection: Collection<FriendlyBattleDocument> | null = null;
let gameCatalogEntriesCollection: Collection<GameCatalogEntryDocument> | null = null;
let gameCatalogReleasesCollection: Collection<GameCatalogReleaseDocument> | null = null;

/**
 * Global exactly-once ledger for a verified store token.
 *
 * `_id` is an HMAC of the opaque purchase token, never the token itself. A token belongs to
 * one player and product for its lifetime; keeping that ownership outside the player document
 * prevents the same paid receipt from being submitted to two accounts concurrently.
 */
export interface PurchaseReceiptDocument extends Document {
  _id: string;
  platform: "google-play";
  playerId: string;
  productId: string;
  storeProductId: string;
  orderId: string;
  kind: "currency" | "pack" | "subscription";
  purchasedAt: Date;
  verifiedAt: Date;
  response: Record<string, string | number | boolean>;
  /** Exact reversible benefit snapshot captured before a one-time delivery commits. */
  reversibleGrant?: PurchaseReversibleGrant;
  /** Authenticated ciphertext required only for later subscription status checks. */
  encryptedPurchaseToken?: {
    version: 1;
    iv: string;
    authTag: string;
    ciphertext: string;
  };
  /** Last successfully observed subscriptionsv2 state and expiry. */
  subscriptionState?: string;
  subscriptionExpiresAt?: Date;
  /** Durable retry cursor shared by every backend node. */
  revalidateAfter?: Date;
  lastRevalidatedAt?: Date;
  revalidationFailures?: number;
  revokedAt?: Date;
  voidedSource?: number;
  voidedReason?: number;
  voidedOrderId?: string;
}

export interface PurchaseReversibleGrant {
  gold: number;
  warBucks: number;
  vipSeconds: number;
  weapons: Array<{ name: string; introduced: boolean }>;
  visuals: Array<{ name: string; durationSeconds: number; introduced: boolean }>;
  extraCardSlot: boolean;
  introducedExtraCardSlot: boolean;
}

let purchaseReceiptsCollection: Collection<PurchaseReceiptDocument> | null = null;
export interface PurchaseReconciliationCursorDocument extends Document {
  _id: "google-play-voided-products";
  /** End of the last fully paginated API window; partial/failed sweeps never advance it. */
  lastSuccessfulEndTime: Date;
  updatedAt: Date;
}

let purchaseReconciliationCursorsCollection: Collection<PurchaseReconciliationCursorDocument> | null = null;
export interface ScheduledJobLeaseDocument extends Document {
  _id: string;
  ownerId: string;
  acquiredAt: Date;
  expiresAt: Date;
}

let scheduledJobLeasesCollection: Collection<ScheduledJobLeaseDocument> | null = null;

/** Durable at-least-once Firebase delivery state for one committed inbox row. */
export interface FirebasePushDeliveryDocument extends Document {
  _id: string;
  recipientPlayerId: string;
  messageId: string;
  status: "pending" | "delivered" | "suppressed";
  attempts: number;
  createdAt: Date;
  updatedAt: Date;
  nextAttemptAt: Date | null;
  completedAt: Date | null;
  lastDisposition: "transient" | "configuration" | null;
  terminalReason: "not-eligible" | "invalid-token" | null;
}

let firebasePushDeliveriesCollection: Collection<FirebasePushDeliveryDocument> | null = null;

export async function connectMongo(): Promise<void> {
  await client.connect();
  db = client.db(runtimeInfrastructure.mongoDatabaseName);

  playersCollection = db.collection<PlayerDocument>("players");
  squadsCollection = db.collection<SquadDocument>("squads");
  playerLeagueAllocationsCollection = db.collection<PlayerLeagueAllocationDocument>("playerLeagueAllocations");
  squadWarSeasonsCollection = db.collection<SquadWarSeasonDocument>("squadWarSeasons");
  squadWarRoundsCollection = db.collection<SquadWarRoundDocument>("squadWarRounds");
  squadEventProgressCollection = db.collection<SquadEventProgressDocument>("squadEventProgress");
  squadChatMessagesCollection = db.collection<SquadChatMessageDocument>("squadChatMessages");
  videoFeedCollection = db.collection<VideoFeedDocument>("videoFeed");
  videoFeedRateLimitsCollection = db.collection<VideoFeedRateLimitDocument>("videoFeedRateLimits");
  matchesCollection = db.collection("matches");
  messagesCollection = db.collection("messages");
  identitiesCollection = db.collection<IdentityDocument>("identities");
  reportsCollection = db.collection("playerReports");
  authRateLimitsCollection = db.collection<AuthRateLimitDocument>("authRateLimits");
  reportRateLimitsCollection = db.collection<ReportRateLimitDocument>("reportRateLimits");
  outgoingMessageRateLimitsCollection = db.collection<OutgoingMessageRateLimitDocument>("outgoingMessageRateLimits");
  reportDeduplicationsCollection = db.collection<ReportDeduplicationDocument>("reportDeduplications");
  playerSanctionsCollection = db.collection<PlayerSanctionDocument>("playerSanctions");
  playerAppealsCollection = db.collection<PlayerAppealDocument>("playerAppeals");
  moderationRetentionRunsCollection = db.collection<ModerationRetentionRunDocument>("moderationRetentionRuns");
  friendlyBattlesCollection = db.collection<FriendlyBattleDocument>("friendlyBattles");
  gameCatalogEntriesCollection = db.collection<GameCatalogEntryDocument>("gameCatalogEntries");
  gameCatalogReleasesCollection = db.collection<GameCatalogReleaseDocument>("gameCatalogReleases");
  purchaseReceiptsCollection = db.collection<PurchaseReceiptDocument>("purchaseReceipts");
  purchaseReconciliationCursorsCollection = db.collection<PurchaseReconciliationCursorDocument>(
    "purchaseReconciliationCursors",
  );
  scheduledJobLeasesCollection = db.collection<ScheduledJobLeaseDocument>("scheduledJobLeases");
  firebasePushDeliveriesCollection = db.collection<FirebasePushDeliveryDocument>("firebasePushDeliveries");

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

  // MongoDB already gives `_id` a unique index. These secondary indexes support account
  // support/refund audits without ever storing or logging the raw Play purchase token.
  await purchaseReceiptsCollection.createIndex({ playerId: 1, purchasedAt: -1 });
  await purchaseReceiptsCollection.createIndex({ orderId: 1 }, { unique: true, sparse: true });

  // One scheduler query reads only due pending rows. `_id` is already the unique recipient/message
  // digest, so retries and fan-out replays cannot create a second provider delivery lifecycle.
  await firebasePushDeliveriesCollection.createIndex(
    { status: 1, nextAttemptAt: 1, _id: 1 },
    { name: "firebase_push_due" },
  );
  await firebasePushDeliveriesCollection.createIndex(
    { recipientPlayerId: 1, messageId: 1 },
    { name: "firebase_push_inbox_identity", unique: true },
  );

  await squadsCollection.createIndex({ name: 1 }, { unique: true });
  await squadsCollection.createIndex({ experience: -1 });
  await squadsCollection.createIndex({ squadPoints: -1 });

  await playerLeagueAllocationsCollection.createIndex({ seasonKey: 1 }, { unique: true });
  await playerLeagueAllocationsCollection.createIndex({ endsAt: 1 });

  await squadWarSeasonsCollection.createIndex({ seasonId: 1 }, { unique: true });
  await squadWarSeasonsCollection.createIndex({ status: 1, endsAt: 1 });
  await squadWarRoundsCollection.createIndex({ roundId: 1 }, { unique: true });
  await squadWarRoundsCollection.createIndex({ seasonId: 1, level: 1, division: 1 }, { unique: true });
  await squadWarRoundsCollection.createIndex({ status: 1, endsAt: 1 });
  await squadWarRoundsCollection.createIndex({ "entries.squadId": 1, status: 1 });

  // A squad joins a season once. Concurrent JoinSquadEvent retries all resolve to this one
  // shared row rather than creating separate member-owned progress or duplicate rewards.
  await squadEventProgressCollection.createIndex({ squadId: 1, eventId: 1 }, { unique: true });
  await squadEventProgressCollection.createIndex({ eventId: 1, updatedAt: -1 });

  // A reconnect may resend the same client message after losing its acknowledgement. The
  // sender-scoped nonce makes that retry return the original row on every backend process.
  await squadChatMessagesCollection.createIndex({ idempotencyKey: 1 }, { unique: true });
  await squadChatMessagesCollection.createIndex({ messageId: 1 }, { unique: true });
  await squadChatMessagesCollection.createIndex({ squadId: 1, createdAt: -1, messageId: -1 });
  await squadChatMessagesCollection.createIndex({ senderId: 1, createdAt: -1 });
  await squadChatMessagesCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });

  await videoFeedCollection.createIndex({ videoId: 1 }, { unique: true });
  await videoFeedCollection.createIndex({ playerId: 1, urlHash: 1 }, { unique: true });
  await videoFeedCollection.createIndex({ playerId: 1, createdAt: -1 });
  await videoFeedCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });
  await videoFeedRateLimitsCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });

  await matchesCollection.createIndex({ matchId: 1 }, { unique: true });
  await matchesCollection.createIndex({ "players.playerId": 1, createdAt: -1 });
  // Inbox reads exclude soft-ignored rows and sort newest first, so one compound index covers
  // the ownership filter, visibility filter, and ordering without an in-memory sort.
  await messagesCollection.createIndex({ toPlayerId: 1, ignored: 1, createdAt: -1 });
  // Stable cursor pagination adds messageId as a same-millisecond tie-breaker. Keep the older
  // index declaration compatible with existing deployments while this covering index rolls out.
  await messagesCollection.createIndex({ toPlayerId: 1, ignored: 1, createdAt: -1, messageId: -1 });
  // Every stock inbox mutation is recipient-scoped and identifies one row by MessageId. The
  // recovered protocol offers only second precision for challenge IDs, so this index converts a
  // concurrent same-second collision into a recoverable duplicate-key result rather than leaving
  // two rows that one Accept/Read/Ignore request could mutate ambiguously.
  await messagesCollection.createIndex({ toPlayerId: 1, messageId: 1 }, { unique: true });
  // Retain sender/time ordering for moderation and operational inspection. The admission limit is
  // enforced by the separate atomic counter below rather than a racy count-then-insert query.
  await messagesCollection.createIndex({ fromPlayerId: 1, createdAt: -1 });
  // Only expiring message types carry expiresAt. MongoDB's TTL monitor removes stale
  // challenges asynchronously; read/accept filters enforce expiry immediately meanwhile.
  await messagesCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });
  // Squad-event notifications use a deterministic idempotency key. A unique sparse index
  // prevents simultaneous retries from inserting duplicate message-center entries while
  // remaining compatible with all legacy message rows, which do not have this field.
  await messagesCollection.createIndex({ idempotencyKey: 1 }, { unique: true, sparse: true });
  // The Firebase outbox reconciler closes the post-commit crash window by discovering supported
  // unread messages that do not yet have a delivery ledger row. This index bounds that scan.
  await messagesCollection.createIndex(
    { messageType: 1, read: 1, ignored: 1, accepted: 1, createdAt: 1, messageId: 1 },
    { name: "firebase_push_recovery" },
  );
  // One external identity cannot authenticate two different WarFriends players.
  await identitiesCollection.createIndex({ provider: 1, externalId: 1 }, { unique: true });
  // A player may link multiple providers, but only one identity from each provider.
  await identitiesCollection.createIndex({ provider: 1, playerId: 1 }, { unique: true });
  // Moderation reads primarily group unresolved reports by target. The reporter/time index
  // supports the rolling abuse-rate limit without scanning the complete collection.
  await reportsCollection.createIndex({ reportedPlayerId: 1, status: 1, createdAt: -1 });
  await reportsCollection.createIndex({ reporterPlayerId: 1, createdAt: -1 });
  await reportsCollection.createIndex({ reportId: 1 }, { unique: true, sparse: true });
  // Review queues use stable createdAt/reportId ordering. Operation IDs live inside the same
  // report mutation as status/history, so this sparse multikey index prevents one admin retry key
  // from being applied to two different reports without requiring a cross-collection transaction.
  await reportsCollection.createIndex({ status: 1, createdAt: -1, reportId: -1 });
  await reportsCollection.createIndex(
    { "reviewHistory.operationId": 1 },
    { unique: true, sparse: true },
  );

  // One atomic counter covers every process for a presented login identity. The key is an
  // HMAC rather than a raw player/provider identifier so expired throttle rows do not become
  // a second account directory. MongoDB removes inactive windows after their safety margin.
  await authRateLimitsCollection.createIndex({ key: 1 }, { unique: true });
  await authRateLimitsCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });
  await reportRateLimitsCollection.createIndex({ key: 1 }, { unique: true });
  await reportRateLimitsCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });
  await outgoingMessageRateLimitsCollection.createIndex({ key: 1 }, { unique: true });
  await outgoingMessageRateLimitsCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });
  await reportDeduplicationsCollection.createIndex({ key: 1 }, { unique: true });
  await reportDeduplicationsCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });
  // The active-state uniqueness boundary is race-safe across every backend and admin process.
  // Expired history is retained intentionally; issuePlayerSanction first marks elapsed rows
  // expired so a later sanction can take ownership of this partial index.
  await playerSanctionsCollection.createIndex(
    { playerId: 1, status: 1 },
    { unique: true, partialFilterExpression: { status: "active" } },
  );
  await playerSanctionsCollection.createIndex({ operationId: 1 }, { unique: true });
  await playerSanctionsCollection.createIndex(
    { revocationOperationId: 1 },
    { unique: true, sparse: true },
  );
  await playerSanctionsCollection.createIndex({ playerId: 1, issuedAt: -1 });
  await playerAppealsCollection.createIndex({ sanctionId: 1 }, { unique: true });
  await playerAppealsCollection.createIndex({ submissionOperationId: 1 }, { unique: true });
  await playerAppealsCollection.createIndex({ status: 1, createdAt: -1, _id: -1 });
  await playerAppealsCollection.createIndex({ playerId: 1, createdAt: -1 });
  await playerAppealsCollection.createIndex(
    { "reviewHistory.operationId": 1 },
    { unique: true, sparse: true },
  );
  await moderationRetentionRunsCollection.createIndex({ operationId: 1 }, { unique: true });
  await moderationRetentionRunsCollection.createIndex({ createdAt: -1 });

  // A reconnect or lost HTTP response may repeat the same challenge start. The compound unique
  // key turns every process into the same idempotent writer, while TTL bounds telemetry storage.
  await friendlyBattlesCollection.createIndex({ playerId: 1, battleId: 1 }, { unique: true });
  await friendlyBattlesCollection.createIndex({ expiresAt: 1 }, { expireAfterSeconds: 0 });

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

  // Only subscription rows carry a revalidation cursor. The partial index keeps the background
  // sweep bounded without adding index entries for immutable one-time currency receipts.
  await purchaseReceiptsCollection.createIndex(
    { revalidateAfter: 1, _id: 1 },
    { partialFilterExpression: { kind: "subscription", revalidateAfter: { $exists: true } } },
  );
  await purchaseReceiptsCollection.createIndex({ orderId: 1 }, { unique: true, sparse: true });

  // Publish checked-in client data during boot. syncGameCatalog writes every immutable entry
  // before moving the release pointer, so a process failure cannot expose half a catalog.
  await syncGameCatalog(gameCatalogEntriesCollection, gameCatalogReleasesCollection);
}

/**
 * Return the connected database for deployment-level work such as versioned migrations.
 *
 * Gameplay services should continue to use the typed collection accessors below. Exposing the
 * database narrowly here prevents migration code from constructing a second MongoClient (and a
 * second connection pool) while still failing fast if startup order is changed accidentally.
 */
export function mongoDatabase(): Db {
  if (!db) throw new Error("MongoDB is not connected.");
  return db;
}

export async function disconnectMongo(): Promise<void> {
  await client.close();
  db = null;
  playersCollection = null;
  squadsCollection = null;
  playerLeagueAllocationsCollection = null;
  squadWarSeasonsCollection = null;
  squadWarRoundsCollection = null;
  squadEventProgressCollection = null;
  squadChatMessagesCollection = null;
  videoFeedCollection = null;
  videoFeedRateLimitsCollection = null;
  matchesCollection = null;
  messagesCollection = null;
  identitiesCollection = null;
  reportsCollection = null;
  authRateLimitsCollection = null;
  reportRateLimitsCollection = null;
  outgoingMessageRateLimitsCollection = null;
  reportDeduplicationsCollection = null;
  playerSanctionsCollection = null;
  playerAppealsCollection = null;
  moderationRetentionRunsCollection = null;
  friendlyBattlesCollection = null;
  gameCatalogEntriesCollection = null;
  gameCatalogReleasesCollection = null;
  purchaseReceiptsCollection = null;
  purchaseReconciliationCursorsCollection = null;
  scheduledJobLeasesCollection = null;
  firebasePushDeliveriesCollection = null;
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

export function playerLeagueAllocations(): Collection<PlayerLeagueAllocationDocument> {
  return requireCollection("playerLeagueAllocations", playerLeagueAllocationsCollection);
}

export function squadWarSeasons(): Collection<SquadWarSeasonDocument> {
  return requireCollection("squadWarSeasons", squadWarSeasonsCollection);
}

export function squadWarRounds(): Collection<SquadWarRoundDocument> {
  return requireCollection("squadWarRounds", squadWarRoundsCollection);
}

export function squadEventProgress(): Collection<SquadEventProgressDocument> {
  return requireCollection("squadEventProgress", squadEventProgressCollection);
}

export function squadChatMessages(): Collection<SquadChatMessageDocument> {
  return requireCollection("squadChatMessages", squadChatMessagesCollection);
}

export function videoFeed(): Collection<VideoFeedDocument> {
  return requireCollection("videoFeed", videoFeedCollection);
}

export function videoFeedRateLimits(): Collection<VideoFeedRateLimitDocument> {
  return requireCollection("videoFeedRateLimits", videoFeedRateLimitsCollection);
}

export function matches(): Collection<Document> {
  return requireCollection("matches", matchesCollection);
}

export function purchaseReceipts(): Collection<PurchaseReceiptDocument> {
  return requireCollection("purchaseReceipts", purchaseReceiptsCollection);
}

export function purchaseReconciliationCursors(): Collection<PurchaseReconciliationCursorDocument> {
  return requireCollection("purchaseReconciliationCursors", purchaseReconciliationCursorsCollection);
}

export function scheduledJobLeases(): Collection<ScheduledJobLeaseDocument> {
  return requireCollection("scheduledJobLeases", scheduledJobLeasesCollection);
}

export function firebasePushDeliveries(): Collection<FirebasePushDeliveryDocument> {
  return requireCollection("firebasePushDeliveries", firebasePushDeliveriesCollection);
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

export function authRateLimits(): Collection<AuthRateLimitDocument> {
  return requireCollection("authRateLimits", authRateLimitsCollection);
}

export function reportRateLimits(): Collection<ReportRateLimitDocument> {
  return requireCollection("reportRateLimits", reportRateLimitsCollection);
}

export function outgoingMessageRateLimits(): Collection<OutgoingMessageRateLimitDocument> {
  return requireCollection("outgoingMessageRateLimits", outgoingMessageRateLimitsCollection);
}

export function reportDeduplications(): Collection<ReportDeduplicationDocument> {
  return requireCollection("reportDeduplications", reportDeduplicationsCollection);
}

export function playerSanctions(): Collection<PlayerSanctionDocument> {
  return requireCollection("playerSanctions", playerSanctionsCollection);
}

export function playerAppeals(): Collection<PlayerAppealDocument> {
  return requireCollection("playerAppeals", playerAppealsCollection);
}

export function moderationRetentionRuns(): Collection<ModerationRetentionRunDocument> {
  return requireCollection("moderationRetentionRuns", moderationRetentionRunsCollection);
}

export function friendlyBattles(): Collection<FriendlyBattleDocument> {
  return requireCollection("friendlyBattles", friendlyBattlesCollection);
}

export function gameCatalogEntries(): Collection<GameCatalogEntryDocument> {
  return requireCollection("gameCatalogEntries", gameCatalogEntriesCollection);
}

export function gameCatalogReleases(): Collection<GameCatalogReleaseDocument> {
  return requireCollection("gameCatalogReleases", gameCatalogReleasesCollection);
}
