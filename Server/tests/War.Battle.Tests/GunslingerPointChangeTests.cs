using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Exercises exhausted bursts, source point transfers and a fresh automatic shot after arrival.</summary>
internal static class GunslingerPointChangeTests
{
    private const string UnitId = "ID_UNIT-GUNSLINGER";
    private const ulong MaximumTick = 2400;
    private const float ArrivalTolerance = 0.04f;
    private static readonly string OwnerId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (RecoveredBattleMap map in content.Maps)
        {
            checks += CheckMap(content, map);
        }

        checks += CheckSelectionPolicy(content);
        return checks;
    }

    private static int CheckMap(BattleCombatContent content, RecoveredBattleMap map)
    {
        string scene = Path.GetFileNameWithoutExtension(map.Source).Replace("_Multiplayer", "");
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId, scene);
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First(index => content.Army.Option(index).Count == 1);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The point-change fixture failed normal Gunslinger deployment.");
        host.Advance(61);
        ulong actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        AdvanceUntil(host, () => host.GunslingerState(actor)?.ShotsRemaining == 0 &&
            host.GunslingerAttempt(actor)?.CompletedTick.HasValue == true);
        GunslingerArrival exhausted = host.GunslingerState(actor) ??
            throw new InvalidOperationException("No arrival.");
        GunslingerPoint previous = host.GunslingerPoint(actor) ?? throw new InvalidOperationException("No point.");
        GunslingerPoint expected = content.GunslingerPoints.ForMap(map).Where(point =>
            point.Fraction == previous.Fraction && point.ComponentFileId != previous.ComponentFileId)
            .OrderBy(point => point.Order).First();
        var fixture = new TransferFixture(host, actor, previous, expected);
        int checks = CheckTransfer(fixture, exhausted);
        checks += CheckFreshArrival(fixture, content);
        Console.WriteLine($"PASS: Gunslinger {scene} transfers at {exhausted.FirstPointChangeEligibleTick} " +
            "and fires again.");
        return checks;
    }

    private static int CheckTransfer(TransferFixture fixture, GunslingerArrival exhausted)
    {
        var (host, actor, previous, expected) = fixture;
        AdvanceUntil(host, () => host.Snapshot().ServerTick >= exhausted.FirstPointChangeEligibleTick - 1);
        int checks = Require(!host.Terminal && host.GunslingerPoint(actor) == previous &&
            host.GunslingerState(actor) == exhausted,
            "An exhausted Gunslinger changed point before the strict source move deadline.");
        Vector3 position = Position(host, actor);
        GunslingerWeaponAimState weapon = host.GunslingerAimWeapon(actor) ??
            throw new InvalidOperationException("Point transfer lost its current weapon.");
        float speed = weapon.RealBulletSpeed;
        var projectiles = host.Snapshot().Projectiles.Where(row =>
            host.ArmyProjectileSourceEntity(row.ProjectileId) == actor).ToDictionary(row => row.ProjectileId,
                row => host.ArmyProjectileLaunch(row.ProjectileId));
        host.Advance(exhausted.FirstPointChangeEligibleTick);
        checks += Require(!host.Terminal && host.GunslingerPoint(actor) == expected &&
            host.GunslingerState(actor) == null && host.GunslingerAttempt(actor) == null,
            "Gunslinger did not transfer to the source-ordered random free point after exhausting its shots.");
        checks += Require(host.GunslingerPointOccupant(previous.ComponentFileId) == null &&
            host.GunslingerPointOccupant(expected.ComponentFileId) == actor,
            "Point transfer did not release the old reservation and exclusively claim the new one.");
        checks += Require(Position(host, actor) == position &&
            host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().InfantryClip == "colt_run",
            "Point change teleported the actor or retained its stopped firing clip.");
        checks += Require(ReferenceEquals(host.GunslingerAimWeapon(actor), weapon) && weapon.RealBulletSpeed == speed,
            "Gunslinger point movement reset the current weapon multiplier.");
        foreach (var (id, authority) in projectiles)
        {
            // A normal flight may finish on this tick, but a still-live flight cannot change its launch authority.
            checks += Require(host.ArmyProjectileLaunch(id) is not { } current || current == authority,
                "Point transfer rewrote a surviving airborne projectile's authority.");
        }

        return checks;
    }

    private static int CheckFreshArrival(TransferFixture fixture, BattleCombatContent content)
    {
        var (host, actor, _, expected) = fixture;
        AdvanceUntil(host, () => host.GunslingerState(actor) != null);
        GunslingerArrival arrival = host.GunslingerState(actor) ??
            throw new InvalidOperationException("No new arrival.");
        Vector3 position = Position(host, actor);
        int maximum = content.Army.ComposeShot(UnitId, 0, null, null, 1f).FireBatchSizeMax;
        int checks = Require(host.GunslingerPoint(actor) == expected &&
            Vector2.Distance(new(position.X, position.Z),
                new(expected.Position.X, expected.Position.Z)) < ArrivalTolerance &&
            arrival.ShotsRemaining == maximum && arrival.FirstShotEligibleTick == arrival.EnteredTick + 1,
            "Repositioned Gunslinger did not reach its authored point and restore source attempt counters.");
        AdvanceUntil(host, () => host.GunslingerAttempt(actor)?.CompletedTick.HasValue == true);
        GunslingerShotAttempt attempt = host.GunslingerAttempt(actor) ??
            throw new InvalidOperationException("No new shot.");
        checks += Require(attempt.Aim.AcquisitionTick == arrival.FirstShotEligibleTick &&
            attempt.LoopEntry == GunslingerFireLoopEntry.FreshQueuedFire && attempt.CompletedTick == attempt.PollTick,
            "A repositioned Gunslinger did not run a fresh stand callback and automatic single-shot launch.");
        checks += Require(host.ConfirmArmyDeath(actor, false) && host.GunslingerPoint(actor) == null &&
            host.GunslingerPointOccupant(expected.ComponentFileId) == null,
            "Gunslinger death did not release its transferred reservation.");
        return checks;
    }

    private static int CheckSelectionPolicy(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.First();
        IReadOnlyList<GunslingerPoint> points = content.GunslingerPoints.ForMap(map);
        GunslingerPoint current = points.First(point => point.Fraction == 2);
        var occupied = points.Select(point => point.ComponentFileId).ToHashSet();
        int checks = Require(GunslingerPointSelection.SelectNext(points, current, occupied.Contains,
            _ => throw new InvalidOperationException("An empty candidate list consumed a random draw.")) == null,
            "A completely occupied source point set invented a destination.");
        GunslingerPoint released = points.First(point => point.Fraction == current.Fraction && point != current);
        occupied.Remove(released.ComponentFileId);
        checks += Require(GunslingerPointSelection.SelectNext(points, current, occupied.Contains, count =>
        {
            Require(count == 1, "The released-point draw included a friendly occupied or opposite-fraction point.");
            return 0;
        }) == released, "The next selector call did not observe a newly released reservation.");
        GunslingerPoint last = points.Where(point => point.Fraction == current.Fraction && point != current)
            .OrderBy(point => point.Order).Last();
        checks += Require(GunslingerPointSelection.SelectNext(points, current, _ => false, count => count - 1) == last,
            "The next-point draw lost serialized order or failed to exclude the current point.");
        try
        {
            GunslingerPointSelection.SelectNext(points, current, _ => false, count => count);
        }
        catch (InvalidDataException)
        {
            return checks + 1;
        }

        throw new InvalidOperationException("An out-of-range point selection entered movement authority.");
    }

    private static Vector3 Position(MatchEngine host, ulong actor)
    {
        BattleArmyEntityState entity = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(row =>
            row.EntityKey == actor);
        return new Vector3(entity.X, entity.Y, entity.Z);
    }

    private static void AdvanceUntil(MatchEngine host, Func<bool> completed)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && !completed())
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        Require(!host.Terminal && completed(),
            "Gunslinger movement fixture stopped: " + host.Snapshot().TerminalReason);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private sealed record TransferFixture(MatchEngine Host, ulong Actor,
        GunslingerPoint Previous, GunslingerPoint Expected);
}
