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
  /** Recovered `LevelExperience`: progress within the current one-based Squad level. */
  experience: number;
  squadPoints: number;
  level: number;
  leagueId: string;
  leagueDivision: string;
  /**
   * Current reconstructed Squad Wars level (1..8).
   *
   * The recovered client derives the level from the numeric prefix of RoundId. Keeping the
   * normalized value separately lets season settlement promote/demote a squad without parsing
   * client-facing identifiers or trusting a RoundId later echoed by Unity.
   */
  squadWarLevel?: number;
  /** Server-owned action-124 division identifier for the active reconstructed season. */
  squadWarRoundId?: string;
  /** Number of completed Squad Wars divisions won in first place. */
  squadWarWins?: number;
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
    squadWarLevel: 1,
    squadWarRoundId: "",
    squadWarWins: 0,
    founderId,
    joinPolicy: 0,
    minLevel: 0,
    requiredMedals: 0,
    // Client 4.9.5 Squads row 1 unlocks four members. Later rank transitions replace this with
    // the exact SIZE from their source row; it is not a client-selected squad setting.
    maxMembers: 4,
    members: [],
    joinRequests: [],
    invitedPlayerIds: [],
  };
}
