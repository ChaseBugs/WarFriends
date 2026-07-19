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
    RoundId: squad.leagueId || "0-placement",
    Size: squad.members.length,
    // In the recovered model Skill is the squad's current competitive score, while
    // SkillRequirement is the minimum player medal gate for joining.
    Skill: squad.squadPoints,
    Level: squad.level,
    SkillRequirement: squad.requiredMedals,
    SquadPoints: squad.squadPoints,
    Experience: squad.experience,
    LevelExperience: 0,
    Icon: icon,
    Kills: 0,
    BattlesLost: 0,
    BattlesWon: 0,
    CardsPlayed: 0,
    BestSkill: squad.squadPoints,
    UnitsDeployed: 0,
    TiersCompleted: 0,
    SquadPointsBest: squad.squadPoints,
    SquadWarWins: 0,
  };
}
