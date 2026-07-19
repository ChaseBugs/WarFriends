// Client-side enums the server must mirror on the wire. Values come from the recovered
// client (Client-Decompiled-Mono-1.6.0). The client's Newtonsoft.Json has no
// StringEnumConverter, so enums (de)serialize as their underlying integers — keep these
// numeric and in sync with the client.

/** AccountType — how a player authenticates. Mirrors AccountType.cs. */
export enum AccountType {
  None = 0,
  Custom = 1,
  Facebook = 2,
  GameCenter = 3,
  GooglePlay = 4,
}

/** League tiers. Mirrors League.cs ordering (Bronze3 is the starting tier). */
export enum League {
  Bronze3 = 0,
  Bronze2 = 1,
  Bronze1 = 2,
  Silver3 = 3,
  Silver2 = 4,
  Silver1 = 5,
  Gold3 = 6,
  Gold2 = 7,
  Gold1 = 8,
  Diamond = 9,
}

/** Rank of a member within a squad. Mirrors SquadRank.cs. */
export enum SquadRank {
  Member = 0,
  Officer = 1,
  Leader = 2,
  Founder = 3,
}

/** Player online/presence status. Mirrors PlayerStatus.cs. */
export enum PlayerStatus {
  Offline = 0,
  Online = 1,
  InBattle = 2,
}

/** Collection names used by ServerResultsCache reads (see BACKEND.md §2.4). */
export const ResultCollections = {
  globalPlayerLeaderboard: "globalPlayerLeaderboard",
  localPlayerLeaderboard: "localPlayerLeaderboard",
  leagueMembers: "leagueMembers",
  squad: "squad",
  squadMembers: "squadMembers",
  globalSquadLeaderboard: "globalSquadLeaderboard",
  localSquadLeaderboard: "localSquadLeaderboard",
  missionLeaderboards: "missionLeaderboards",
  arenaLeaderboard: "arenaLeaderboard",
  players: "players",
  squadsFromLeague: "squadsFromLeague",
  playerInfo: "playerInfo",
  lastWeeksPlayerLeague: "lastWeeksPlayerLeague",
  facebookFriends: "facebookFriends",
} as const;

/** Redis key builders. */
export const RedisKeys = {
  matchmakingQueue: "wf:mm:queue",
  session: (playerId: string) => `wf:session:${playerId}`,
  socketOfPlayer: (playerId: string) => `wf:socket:${playerId}`,
  leaderboardExperience: "wf:lb:experience",
  leaderboardSquad: "wf:lb:squad",
} as const;
