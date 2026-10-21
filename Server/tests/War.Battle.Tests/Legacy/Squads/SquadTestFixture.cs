using War.Backend.Legacy;
using War.Backend.Legacy.Squads;
using War.Persistence;
using War.Persistence.Legacy.Squads;

namespace War.Battle.Tests.Legacy.Squads;

/// <summary>Readable source-width squad fixtures shared by rule and Mongo scenarios.</summary>
internal static class SquadTestFixture
{
    internal const int Now = 1700000000;
    internal const int CreationPrice = 50000;

    internal static LegacySquadSnapshot Create()
    {
        string name = Name();
        var actor = Player();
        var target = Player();
        actor.SquadId = name;
        actor.SquadRank = (int)LegacySquadRank.Leader;
        target.SquadId = name;
        target.SquadRank = (int)LegacySquadRank.Member;
        var squad = new LegacySquadDocument
        {
            Id = name,
            CreatedUtc = DateTimeOffset.FromUnixTimeSeconds(Now).UtcDateTime,
            Members = [new() { PlayerId = actor.Id, Rank = actor.SquadRank },
                new() { PlayerId = target.Id, Rank = target.SquadRank }]
        };
        return new LegacySquadSnapshot
        {
            Actor = actor,
            Target = target,
            Squad = squad,
            ActorMemberships = [name],
            TargetMemberships = [name]
        };
    }

    internal static LegacyPlayerDocument Player() => new()
    {
        Id = Guid.NewGuid().ToString("N"),
        SquadRank = (int)LegacySquadRank.None,
        SessionHash = Guid.NewGuid().ToString("N"),
        WarBucks = 3 * CreationPrice
    };

    internal static LegacySquadCommand Command(DatabaseAction action, LegacySquadSnapshot snapshot) => new()
    {
        Action = action,
        NowUnixSeconds = Now,
        TargetId = snapshot.Target?.Id,
        ExpectedOldRank = action is DatabaseAction.PromotePlayer or DatabaseAction.DemotePlayer
            ? snapshot.Target?.SquadRank : null
    };

    internal static LegacySquadCommand Creation(string name) => new()
    {
        Action = DatabaseAction.CreateSquad,
        NowUnixSeconds = Now,
        SquadId = name,
        IsPublic = true,
        SkillRequirement = 0,
        Icon = "icon1"
    };

    internal static string Name() => "sq" + Guid.NewGuid().ToString("N")[..10];

    internal static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
