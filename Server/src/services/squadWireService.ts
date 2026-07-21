import type { SquadDTO } from "../dtos";

/**
 * Adapt the normalized squad document to fields consumed by AANECPGDMGM.MAINIENLLIL.
 *
 * That recovered parser accepts either plain JSON values or DynamoDB attributes. Squads use
 * plain values here because their parser deliberately supports both, while player snapshots
 * require typed attributes. Keeping this conversion centralized prevents each handler from
 * inventing a different Id/Size/SkillRequirement spelling.
 */
export function buildDatabaseSquad(squad: SquadDTO): Record<string, unknown> {
  const icon = typeof squad.emblem.id === "string" ? squad.emblem.id : JSON.stringify(squad.emblem);
  return {
    Id: squad.name,
    IsPublic: squad.joinPolicy === 0 ? 1 : 0,
    Message: squad.description,
    RoundId: squad.squadWarRoundId || squad.leagueId || "0-placement",
    Size: squad.members.length,
    // In the recovered model Skill is the squad's current competitive score, while
    // SkillRequirement is the minimum player medal gate for joining.
    Skill: squad.squadPoints,
    Level: squad.level,
    SkillRequirement: squad.requiredMedals,
    SquadPoints: squad.squadPoints,
    // AANECPGDMGM parses Experience as an older 32-bit field but no recovered squad screen reads
    // it. High-rank source thresholds exceed Int32, so do not mirror 64-bit progress into that
    // incompatible legacy field. SquadStatsContent reads the exact long below.
    Experience: 0,
    LevelExperience: squad.experience,
    Icon: icon,
    Kills: 0,
    BattlesLost: 0,
    BattlesWon: 0,
    CardsPlayed: 0,
    BestSkill: squad.squadPoints,
    UnitsDeployed: 0,
    TiersCompleted: 0,
    SquadPointsBest: squad.squadPoints,
    SquadWarWins: squad.squadWarWins ?? 0,
  };
}

/**
 * Build action 124's exact division payload for CLBPOGIEGAN/AANECPGDMGM.
 *
 * The recovered client caches the array under the top-level LeagueId, then reads RoundId and
 * Position from every item. Override those fields at the wire boundary instead of mutating a
 * squad's persistent league metadata merely because a round leaderboard was viewed.
 */
export function buildSquadWarsDivision(
  roundId: string,
  squadWarsId: string,
  squads: readonly SquadDTO[],
  scoreEntries: readonly {
    squadId: string;
    baseScore: number;
    score: number;
    wins: number;
  }[] = [],
): Record<string, unknown> {
  const scoreBySquad = new Map(scoreEntries.map((entry) => [entry.squadId, entry]));
  return {
    LeagueId: roundId,
    SquadWarsId: squadWarsId,
    Items: squads.map((squad, index) => {
      const score = scoreBySquad.get(squad.name);
      return {
        ...buildDatabaseSquad(squad),
        RoundId: roundId,
        Position: index + 1,
        ...(score
          ? {
            // AANECPGDMGM first reads SquadPoints, then adds the numeric field whose key is
            // the top-level SquadWarsId. Splitting baseline and current-round gain reproduces
            // that contract while their sum remains the authoritative leaderboard score.
            SquadPoints: score.baseScore,
            [squadWarsId]: score.score,
            SquadWarWins: score.wins,
          }
          : {}),
      };
    }),
  };
}
