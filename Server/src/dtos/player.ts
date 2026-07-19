import { AccountType, League, PlayerStatus, SquadRank } from "../constants";

// Mirrors the recovered client's DatabasePlayer.cs. Fields the server treats as opaque
// (client-serialized blobs) are typed `unknown` for now — they round-trip untouched until
// we need to reason about their contents.
//
// Wire (JSON) key casing follows the client field/property names; see BACKEND.md §2.4.
export interface DatabasePlayerDTO {
  id: string;
  accountName: string;
  accountType: AccountType;

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

  deviceToken: string;
  sendLogsValue: number;

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
    squadRank: SquadRank.Member,
    vipExpiration: 0,
    country: "",
    status: PlayerStatus.Online,
    lastAction: 0,
    deviceToken: "",
    sendLogsValue: 0,
    inventoryData: null,
    levelManagerData: null,
    statisticsData: null,
    playerVisuals: {},
    depositedCardsDic: {},
  };
}
