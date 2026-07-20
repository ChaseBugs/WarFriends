import { AccountType, League, PlayerStatus, SquadRank } from "../constants";

/** Push-notification preferences serialized by the recovered SettingsManager.Settings. */
export interface NotificationSettingsDTO {
  challenge: boolean;
  squadStatus: boolean;
  squadEvents: boolean;
  maintenance: boolean;
  playerLeague: boolean;
  dailyRewardNotification: boolean;
}

// Mirrors the recovered client's DatabasePlayer.cs. Fields the server treats as opaque
// (client-serialized blobs) are typed `unknown` for now — they round-trip untouched until
// we need to reason about their contents.
//
// Wire (JSON) key casing follows the client field/property names; see BACKEND.md §2.4.
export interface DatabasePlayerDTO {
  id: string;
  accountName: string;
  accountType: AccountType;
  // Facebook ids are signed 64-bit values in C#. Large ids remain strings in Node so they
  // cannot be rounded above Number.MAX_SAFE_INTEGER before reaching the client.
  facebookId: number | string;
  googlePlayId: string;
  gameCenterId: string;

  experience: number;
  level: number;
  skill: number;
  reputation: number;
  armyPower: number;
  medalsBalance: number;
  remainingMatches: number;

  // League / progression
  leagueTier: League;
  leagueId: string;
  leagueDivision: string;
  beginnersLeague: number;

  // Squad membership (denormalized onto the player, as the client expects)
  squadName: string;
  squadPoints: number;
  squadRank: SquadRank;

  vipExpiration: number;
  country: string;
  status: PlayerStatus;
  lastAction: number;
  awaitingSquadMember: boolean;

  visualType: string;
  visualTimestamp: number;
  influencerLink: string;
  influencerAlias: string;
  /**
   * Last bounded Photon-region latency sample submitted through action 140.
   * Optional because player documents created before region recovery do not contain it.
   */
  bestRegions?: Record<string, number>;
  connectionType: number;

  deviceToken: string;
  sendLogsValue: number;
  locale: string;
  renameCount: number;
  notificationSettings: NotificationSettingsDTO;

  // Opaque client-serialized blobs (round-tripped, not modeled yet)
  inventoryData: unknown;
  levelManagerData: unknown;
  statisticsData: unknown;
  playerVisuals: Record<string, unknown>;
  depositedCardsDic: Record<string, string>;
}

export function newPlayer(id: string, accountName: string, accountType: AccountType): DatabasePlayerDTO {
  return {
    id,
    accountName,
    accountType,
    facebookId: -1,
    googlePlayId: "",
    gameCenterId: "",
    experience: 0,
    level: 1,
    skill: 0,
    reputation: 0,
    armyPower: 0,
    medalsBalance: 0,
    remainingMatches: 0,
    leagueTier: League.Bronze3,
    leagueId: "",
    leagueDivision: "",
    beginnersLeague: 1,
    squadName: "",
    squadPoints: 0,
    squadRank: SquadRank.None,
    vipExpiration: 0,
    country: "",
    status: PlayerStatus.Online,
    lastAction: 0,
    awaitingSquadMember: false,
    visualType: "",
    visualTimestamp: 0,
    influencerLink: "",
    influencerAlias: "",
    bestRegions: {},
    connectionType: 0,
    deviceToken: "",
    sendLogsValue: 0,
    locale: "en",
    renameCount: 0,
    notificationSettings: {
      challenge: true,
      squadStatus: true,
      squadEvents: true,
      maintenance: false,
      playerLeague: true,
      dailyRewardNotification: true,
    },
    inventoryData: null,
    levelManagerData: null,
    statisticsData: null,
    playerVisuals: {},
    depositedCardsDic: {},
  };
}
