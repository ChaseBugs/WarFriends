import { SquadRank } from "../constants";

// Squad data model — see BACKEND.md §2.5. Backs the squad DbActions (Create/Join/
// Promote/Kick/Leave/Events/CardPool). Members are stored on the player (squadName on
// DatabasePlayer) AND summarized here for fast squad reads.
export interface SquadMemberDTO {
  playerId: string;
  name: string;
  rank: SquadRank;
  squadPoints: number;
  joinedAt: number;
  lastSeenChatTimestamp: number;
}

export interface SquadJoinRequestDTO {
  playerId: string;
  name: string;
  createdAt: number;
}

export interface SquadDTO {
  /** Unique squad name (CheckUniqueSquadName gates creation). Doubles as the id. */
  name: string;
  emblem: Record<string, unknown>;
  description: string;
  experience: number;
  squadPoints: number;
  level: number;
  leagueId: string;
  leagueDivision: string;
  founderId: string;
  /** 0 = open join, 1 = request required, 2 = invite only. */
  joinPolicy: number;
  minLevel: number;
  requiredMedals: number;
  maxMembers: number;
  members: SquadMemberDTO[];
  joinRequests: SquadJoinRequestDTO[];
  invitedPlayerIds: string[];
}

export function newSquad(name: string, founderId: string): SquadDTO {
  return {
    name,
    emblem: {},
    description: "",
    experience: 0,
    squadPoints: 0,
    level: 1,
    leagueId: "",
    leagueDivision: "",
    founderId,
    joinPolicy: 0,
    minLevel: 0,
    requiredMedals: 0,
    maxMembers: 15,
    members: [],
    joinRequests: [],
    invitedPlayerIds: [],
  };
}
