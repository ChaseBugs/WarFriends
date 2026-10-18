using System.Numerics;

using Google.Protobuf;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks real construction rotation, accepted cover changes, firing-branch priority and cleanup.</summary>
internal static class MortarFacingTests
{
    private const string UnitId = "ID_UNIT-MORTAR";
    private const ulong MaximumArrivalTick = 1200;
    private const int TweenTicks = 6;
    private const float FacingTolerance = 0.00001f;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (RecoveredBattleMap map in content.Maps)
        {
            foreach (int fraction in new[] { 1, 2 })
            {
                checks += CheckCoverChange(content, map, fraction);
            }
        }

        RecoveredBattleMap park = content.Maps.Single(map => map.Source.EndsWith("/Park_Multiplayer.unity"));
        return checks + CheckFiringBoundary(content, park);
    }

    private static int CheckCoverChange(BattleCombatContent content, RecoveredBattleMap map, int fraction)
    {
        Fixture fixture = CreateArrived(content, map, fraction);
        MatchEngine host = fixture.Host;
        MortarFacingTween initial = host.MortarFacing(fixture.EntityKey) ??
            throw new InvalidOperationException("Mortar did not start rotation after natural arrival.");
        ulong nextTick = host.Snapshot().ServerTick + 1;
        Vector3 expectedFrom = initial.FacingAt(nextTick);
        int oldCover = host.Snapshot().Players.Single(player => player.PlayerId == fixture.OpponentId).CoverIndex;
        int destination = MoveOpponent(fixture, map);
        host.Advance(nextTick);
        MortarFacingTween retarget = host.MortarFacing(fixture.EntityKey) ??
            throw new InvalidOperationException("Mortar lost its construction rotation.");
        int checks = Require(!host.Terminal && retarget.StartedTick == nextTick &&
            retarget.TargetCoverIndex == destination &&
            host.Snapshot().Players.Single(player => player.PlayerId == fixture.OpponentId).CoverIndex == oldCover &&
            Vector3.Distance(retarget.FacingAt(nextTick), expectedFrom) < FacingTolerance,
            "Mortar waited for physical cover arrival or restarted from the wrong current rotation.");
        for (int step = 0; step <= TweenTicks; step++)
        {
            if (step > 0)
            {
                host.Advance(host.Snapshot().ServerTick + 1);
            }
            checks += CheckPublishedFacing(fixture, retarget.FacingAt(host.Snapshot().ServerTick));
        }

        BattleArmyEntityState entity = host.ArmyEntityBatch(fixture.OwnerId, 0, 0).Entities.Single();
        Vector3 target = map.Covers[destination].ShotPosition - new Vector3(entity.X, entity.Y, entity.Z);
        target.Y = 0f;
        checks += Require(Vector3.Distance(retarget.FacingAt(host.Snapshot().ServerTick), Vector3.Normalize(target)) <
            FacingTolerance, "Mortar did not finish facing the new point's shield shotPosition.");
        checks += Require(host.ConfirmArmyDeath(fixture.EntityKey, false) &&
            host.MortarFacing(fixture.EntityKey) == null && host.InfantryPose(fixture.EntityKey) == null,
            "Mortar death retained rotation or collision pose authority.");
        return checks;
    }

    private static int CheckFiringBoundary(BattleCombatContent content, RecoveredBattleMap map)
    {
        Fixture fixture = CreateArrived(content, map, 1);
        MortarFacingTween initial = fixture.Host.MortarFacing(fixture.EntityKey) ??
            throw new InvalidOperationException("Mortar boundary fixture lacks its original rotation.");
        ulong deadline = fixture.Construction.FirstFireEligibleTick;
        while (fixture.Host.Snapshot().ServerTick < deadline - 1)
        {
            fixture.Host.Advance(fixture.Host.Snapshot().ServerTick + 1);
        }

        int destination = MoveOpponent(fixture, map);
        fixture.Host.Advance(deadline);
        MortarFacingTween current = fixture.Host.MortarFacing(fixture.EntityKey) ??
            throw new InvalidOperationException("Mortar boundary fixture lost its rotation.");
        return Require(!fixture.Host.Terminal && destination != initial.TargetCoverIndex && current == initial,
            "The source first-fire branch must win over a same-frame construction retarget.");
    }

    private static int MoveOpponent(Fixture fixture, RecoveredBattleMap map)
    {
        BattlePlayerState player = fixture.Host.Snapshot().Players.Single(candidate =>
            candidate.PlayerId == fixture.OpponentId);
        int fraction = map.Covers[player.CoverIndex].Fraction;
        int direction = map.Adjacent(player.CoverIndex, 1, fraction) >= 0 ? 1 : -1;
        int destination = map.Adjacent(player.CoverIndex, direction, fraction);
        Require(destination >= 0 && fixture.Host.Command(fixture.OpponentId, new MatchCommand
        {
            CommandId = 3, MoveCover = new() { Direction = direction }
        }).Code == "moving", "The Mortar fixture failed its real opponent cover change.");
        return destination;
    }

    private static int CheckPublishedFacing(Fixture fixture, Vector3 expected)
    {
        MatchArmyEntityBatch batch = fixture.Host.ArmyEntityBatch(fixture.OwnerId, 0, 0);
        MatchArmyEntityBatch decoded = MatchArmyEntityBatch.Parser.ParseFrom(batch.ToByteArray());
        BattleArmyEntityState entity = decoded.Entities.Single();
        Vector3 published = new(entity.InfantryFacingX, entity.InfantryFacingY, entity.InfantryFacingZ);
        Vector3 collision = fixture.Host.InfantryPose(fixture.EntityKey)?.Facing ??
            throw new InvalidOperationException("Mortar rotation lost its collision pose.");
        return Require(Vector3.Distance(published, expected) < FacingTolerance &&
            Vector3.Distance(collision, expected) < FacingTolerance,
            "Mortar collision and protobuf facing disagree with current rotation authority.");
    }

    private static Fixture CreateArrived(BattleCombatContent content, RecoveredBattleMap map, int fraction)
    {
        string scene = Path.GetFileNameWithoutExtension(map.Source).Replace("_Multiplayer", "");
        string ownerId = new(fraction == 1 ? 'a' : 'b', 32);
        string opponentId = new(fraction == 1 ? 'b' : 'a', 32);
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId, scene);
        Require(host.Command(ownerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(ownerId).OptionIndexes.First() }
        }).Code == "army-deploying", "The rotation fixture rejected its ordinary Mortar deployment.");
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumArrivalTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            BattleArmyEntityState? entity = host.ArmyEntityBatch(ownerId, 0, 0).Entities.SingleOrDefault();
            if (entity != null && host.MortarConstruction(entity.EntityKey) is { } state)
            {
                return new Fixture(host, ownerId, opponentId, entity.EntityKey, state);
            }
        }

        throw new InvalidOperationException("Mortar rotation fixture never arrived: " + host.Snapshot().TerminalReason);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private sealed record Fixture(MatchEngine Host, string OwnerId, string OpponentId, ulong EntityKey,
        MortarConstructionState Construction);
}
