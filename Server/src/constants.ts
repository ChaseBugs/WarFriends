// Client-side enums the server must mirror on the wire. Values come from the recovered
// client (Client-Decompiled-Mono-1.6.0). The client's Newtonsoft.Json has no
// StringEnumConverter, so enums (de)serialize as their underlying integers — keep these
// numeric and in sync with the client.

/** AccountType — how a player authenticates. Mirrors AccountType.cs. */
export enum AccountType {
  Guest = 0,
  Facebook = 2,
  GameCenter = 3,
  GooglePlay = 4,
}

/** League tiers. Mirrors League.cs ordering (Bronze3 is the starting tier). */
export enum League {
  NoLeague = 0,
  Bronze3 = 1,
  Bronze2 = 2,
  Bronze1 = 3,
  Silver3 = 4,
  Silver2 = 5,
  Silver1 = 6,
  Gold3 = 7,
  Gold2 = 8,
  Gold1 = 9,
  Elite3 = 10,
  Elite2 = 11,
  Elite1 = 12,
  Master3 = 13,
  Master2 = 14,
  Master1 = 15,
  Champion = 16,
}

/** Rank of a member within a squad. Mirrors SquadRank.cs. */
export enum SquadRank {
  None = -1,
  Member = 0,
  Veteran = 1,
  Leader = 2,
  Coleader = 3,
}

/** Player online/presence status. Mirrors PlayerStatus.cs. */
export enum PlayerStatus {
  Offline = 0,
  Online = 1,
  InGame = 2,
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
  matchmakingEntries: "wf:mm:entries",
  session: (playerId: string) => `wf:session:${playerId}`,
  socketOfPlayer: (playerId: string) => `wf:socket:${playerId}`,
  pvpCoordinator: (instanceId: string) => `wf:pvp:coordinator:${instanceId}`,
  distributedRateLimit: (scope: string, identity: string) => `wf:rate:${scope}:${identity}`,
  leaderboardExperience: "wf:lb:experience",
  leaderboardSquad: "wf:lb:squad",
} as const;
