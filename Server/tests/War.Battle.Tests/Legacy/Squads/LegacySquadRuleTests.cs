using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using War.Backend.Legacy;
using War.Backend.Legacy.Squads;
using War.Persistence;
using War.Persistence.Legacy.Squads;

namespace War.Battle.Tests.Legacy.Squads;

/// <summary>Checks the recovered rank ladder, permission differences, admission and strict form assertions.</summary>
internal static class LegacySquadRuleTests
{
    private static readonly LegacySquadRules Rules = new(new LegacySquadPolicy(SquadTestFixture.CreationPrice));

    internal static void Run()
    {
        CheckRankLadder();
        CheckAuthority();
        CheckAdmission();
        CheckCreation();
        CheckMalformedAuthority();
        CheckParser();
        Console.WriteLine("PASS: 6 squad rank, authority, admission, creation, damaged-state and parser scenarios");
    }

    private static void CheckRankLadder()
    {
        (int Current, DatabaseAction Action, int Expected)[] transitions =
        [
            (0, DatabaseAction.PromotePlayer, 1), (1, DatabaseAction.PromotePlayer, 3),
            (3, DatabaseAction.DemotePlayer, 1), (1, DatabaseAction.DemotePlayer, 0)
        ];
        foreach ((int current, DatabaseAction action, int expected) in transitions)
        {
            LegacySquadSnapshot snapshot = SquadTestFixture.Create();
            SetRank(snapshot, snapshot.Target!, current);
            LegacySquadMutation result = Rules.Calculate(snapshot, SquadTestFixture.Command(action, snapshot));
            Require(result.Result == 1 && result.Players.Single().Rank == expected,
                "Promotion/demotion must follow Member -> Veteran -> Coleader, keeping Leader separate.");
            Require(snapshot.Target!.SquadRank == current && snapshot.Squad!.Members[1].Rank == current,
                "A calculation must leave its input snapshot unchanged.");
        }

        LegacySquadSnapshot stale = SquadTestFixture.Create();
        LegacySquadCommand command = SquadTestFixture.Command(DatabaseAction.PromotePlayer, stale)
            with
        { ExpectedOldRank = 1 };
        Require(Rules.Calculate(stale, command).Result == 5501,
            "A stale rank assertion must not advance another step.");
        SetRank(stale, stale.Target!, 1);
        for (int i = 0; i < LegacySquadPolicy.MaximumColeaders; i++)
        {
            stale.Squad!.Members.Add(new LegacySquadMember { PlayerId = Guid.NewGuid().ToString("N"), Rank = 3 });
        }

        Require(Rules.Calculate(stale, command).Result == 5501, "The source three-Coleader limit must hold.");
    }

    private static void CheckAuthority()
    {
        LegacySquadSnapshot snapshot = SquadTestFixture.Create();
        SetRank(snapshot, snapshot.Actor, 3);
        AddLeader(snapshot.Squad!);
        SetRank(snapshot, snapshot.Target!, 3);
        Require(Rules.Calculate(snapshot, SquadTestFixture.Command(DatabaseAction.KickPlayer, snapshot)).Result == 1,
            "MemberRecord permits a Coleader to kick a peer.");
        LegacySquadMutation founder = Rules.Calculate(snapshot,
            SquadTestFixture.Command(DatabaseAction.PromotePlayerToFounder, snapshot));
        Require(founder.Result == 5701, "A Coleader cannot transfer the Leader role.");
        SetRank(snapshot, snapshot.Target!, 2);
        snapshot.Squad!.Members.RemoveAt(2);
        Require(Rules.Calculate(snapshot, SquadTestFixture.Command(DatabaseAction.KickPlayer, snapshot)).Result == 5802,
            "The numeric Coleader value must not outrank the Leader.");
        LegacySquadCommand emblem = SquadTestFixture.Command(DatabaseAction.UpdateSquadEmblem, snapshot)
            with
        { TargetId = null, Icon = "other" };
        Require(Rules.Calculate(snapshot, emblem).Result == 6301, "Only the Leader may change the emblem.");
    }

    private static void CheckAdmission()
    {
        LegacySquadSnapshot snapshot = SquadTestFixture.Create();
        var outsider = SquadTestFixture.Player();
        snapshot = snapshot with { Actor = outsider, ActorMemberships = [] };
        var join = new LegacySquadCommand
        {
            Action = DatabaseAction.JoinSquad,
            NowUnixSeconds = SquadTestFixture.Now,
            SquadId = snapshot.Squad!.Id
        };
        snapshot.Squad.IsPublic = false;
        Require(Rules.Calculate(snapshot, join).Result == 3804, "A private squad requires a current invitation.");
        snapshot.Squad.PendingInvites.Add(outsider.Id);
        snapshot.Squad.SkillRequirement = 1;
        Require(Rules.Calculate(snapshot, join).Result == 3803, "The source medals requirement is authoritative.");
        outsider.Skill = 1;
        LegacySquadMutation joined = Rules.Calculate(snapshot, join);
        Require(joined.Result == 1 && !joined.Squad!.PendingInvites.Contains(outsider.Id) &&
            joined.Players.Single().SquadId == snapshot.Squad.Id, "Join must consume invitation with both mirrors.");
        LegacySquadSnapshot leader = SquadTestFixture.Create();
        var leave = new LegacySquadCommand
        {
            Action = DatabaseAction.LeaveSquad,
            NowUnixSeconds = SquadTestFixture.Now
        };
        Require(Rules.Calculate(leader, leave).Result == 4601, "A non-empty squad cannot lose its sole Leader.");
        leader.Squad!.Members.RemoveAt(1);
        leader = leader with { Target = null, TargetMemberships = [] };
        Require(Rules.Calculate(leader, leave).IsDeletion, "The source last-member delete confirmation must delete.");
    }

    private static void CheckCreation()
    {
        var actor = SquadTestFixture.Player();
        var snapshot = new LegacySquadSnapshot { Actor = actor, ActorMemberships = [], TargetMemberships = [] };
        LegacySquadCommand command = SquadTestFixture.Creation(SquadTestFixture.Name());
        LegacySquadMutation created = Rules.Calculate(snapshot, command);
        Require(created.Result == 1 && created.Players.Single().WarBucks == 2 * SquadTestFixture.CreationPrice &&
            created.Players.Single().CreationsCount == 1, "Creation must calculate one authoritative charge/count.");
        actor.SquadCreationsCount = int.MaxValue;
        Require(Rules.Calculate(snapshot, command).Result == 11301, "Creation counter overflow must refuse.");
        actor.SquadCreationsCount = 0;
        actor.WarBucks = 0;
        Require(Rules.Calculate(snapshot, command).Result == 11403,
            "An unaffordable creation must carry no squad write.");
    }

    private static void CheckMalformedAuthority()
    {
        LegacySquadSnapshot snapshot = SquadTestFixture.Create();
        snapshot.Target!.SquadRank = 1;
        ExpectInvalid(() => Rules.Calculate(snapshot, SquadTestFixture.Command(DatabaseAction.KickPlayer, snapshot)));
        snapshot = SquadTestFixture.Create() with { ActorMemberships = ["one", "two"] };
        ExpectInvalid(() => Rules.Calculate(snapshot, SquadTestFixture.Command(DatabaseAction.KickPlayer, snapshot)));
        snapshot = SquadTestFixture.Create();
        snapshot.Squad!.Members.Add(new LegacySquadMember { PlayerId = "duplicate-leader", Rank = 2 });
        ExpectInvalid(() => Rules.Calculate(snapshot, SquadTestFixture.Command(DatabaseAction.KickPlayer, snapshot)));
    }

    private static void CheckParser()
    {
        var fields = new Dictionary<string, StringValues>
        {
            ["requestId"] = "37",
            ["SquadId"] = "example",
            ["IsPublic"] = "1",
            ["SkillRequirement"] = " +0001 ",
            ["Icon"] = "icon1"
        };
        LegacySquadCommand parsed = Parse(fields);
        Require(parsed.SkillRequirement == 1, "Create forwards UI-validated integer text without canonicalizing it.");
        fields["SkillRequirement"] = "5001";
        ExpectInvalid(() => Parse(fields));
        fields["SkillRequirement"] = "0";
        fields["IsPublic"] = "true";
        ExpectInvalid(() => Parse(fields));
        fields["requestId"] = "55";
        fields["PlayerToPromoteId"] = "target";
        fields["OldSquadRank"] = "01";
        ExpectInvalid(() => Parse(fields));
        fields["OldSquadRank"] = "1";
        Require(Parse(fields).ExpectedOldRank == 1, "Rank assertions use the source canonical Int32 field.");
    }

    private static LegacySquadCommand Parse(Dictionary<string, StringValues> fields)
    {
        var context = new DefaultHttpContext();
        context.Request.ContentType = "application/x-www-form-urlencoded";
        context.Request.Form = new FormCollection(fields);
        Require(LegacyRequest.TryParse(context.Request, out LegacyRequest? request), "Invalid parser fixture.");
        return LegacySquadParser.Parse(request!, SquadTestFixture.Now);
    }

    private static void SetRank(LegacySquadSnapshot snapshot, LegacyPlayerDocument player, int rank)
    {
        player.SquadRank = rank;
        snapshot.Squad!.Members.Single(member => member.PlayerId == player.Id).Rank = rank;
    }

    private static void AddLeader(LegacySquadDocument squad) =>
        squad.Members.Add(new LegacySquadMember { PlayerId = "other-leader", Rank = 2 });

    private static void ExpectInvalid(Action action)
    {
        bool hasRejected = false;
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            hasRejected = true;
        }

        Require(hasRejected, "Malformed command/authority must fail before mutation.");
    }

    private static void Require(bool condition, string message) => SquadTestFixture.Require(condition, message);
}
