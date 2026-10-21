using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy.Squads;

public static class LegacySquadDataProjection
{
    /// <summary>
    /// Projects a <see cref="LegacySquadDocument"/> into the shape <c>DatabaseSquad.CreateFromDatabase</c>
    /// reads. Battle-derived fields (<c>Kills</c>/<c>BattlesWon</c>/<c>SquadPoints</c>/Squad Wars
    /// round data, …) are real fields in that reader but have no meaning without Battle Server
    /// result trust — see the remarks on <see cref="LegacySquadStore"/> — so they are emitted as
    /// zero/empty, the correct "never played a squad war" state, not a placeholder for missing work.
    /// </summary>
    public static JsonObject Squad(LegacySquadDocument squad) => new()
    {
        ["Id"] = Dynamo.S(squad.Id),
        ["Message"] = Dynamo.S(squad.Message),
        ["IsPublic"] = Dynamo.N(squad.IsPublic ? 1 : 0),
        ["Icon"] = Dynamo.S(squad.Icon),
        ["SkillRequirement"] = Dynamo.N(squad.SkillRequirement),
        ["Size"] = Dynamo.N(squad.Members.Count),
        ["Level"] = Dynamo.N(1),
        ["Skill"] = Dynamo.N(0),
        ["Position"] = Dynamo.N(0),
        ["SquadPoints"] = Dynamo.N(0),
        ["Experience"] = Dynamo.N(0),
        ["LevelExperience"] = Dynamo.N(0),
        ["Kills"] = Dynamo.N(0),
        ["BattlesLost"] = Dynamo.N(0),
        ["BattlesWon"] = Dynamo.N(0),
        ["CardsPlayed"] = Dynamo.N(0),
        ["BestSkill"] = Dynamo.N(0),
        ["UnitsDeployed"] = Dynamo.N(0),
        ["TiersCompleted"] = Dynamo.N(0),
        ["SquadPointsBest"] = Dynamo.N(0),
        ["SquadWarWins"] = Dynamo.N(0),
        ["RoundId"] = Dynamo.S("")
    };
}
