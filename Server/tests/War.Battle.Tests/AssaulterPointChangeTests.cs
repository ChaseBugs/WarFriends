using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks ordinary Corner changes against the source timer, live route and arrival lifecycle.</summary>
internal static class AssaulterPointChangeTests
{
    private const ulong MaximumTick = 1800;
    private static readonly string OwnerId = new('b', 32);

    internal static int Run(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, _ => 0);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3,
            DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "Point-change verification requires a real ordinary deployment.");
        host.Advance(host.Snapshot().ServerTick + 1);
        ulong actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        AdvanceUntil(host, () => host.AssaulterCorner(actor) != null);
        AssaulterCornerState initial = host.AssaulterCorner(actor) ??
            throw new InvalidOperationException("The soldier never entered its first Corner.");
        CardUnitInitialPoint original = host.AssaulterPoint(actor) ??
            throw new InvalidOperationException("The first Corner has no reservation.");
        AdvanceUntil(host, () => host.Snapshot().ServerTick == initial.FirstPointChangeEligibleTick - 1);
        int checks = CheckReservations(content, map);
        checks += Require(host.AssaulterPoint(actor) == original,
            "An ordinary soldier changed its Corner before the strict source deadline.");
        AdvanceUntil(host, () => host.AssaulterCorner(actor)?.FirstPointChangeEligibleTick >
            initial.FirstPointChangeEligibleTick);
        ulong retryTick = host.AssaulterCorner(actor)?.FirstPointChangeEligibleTick ??
            throw new InvalidOperationException("The full map lost its unchanged Corner.");
        checks += Require(retryTick == initial.FirstPointChangeEligibleTick + 10 * MatchManifest.TickRate &&
            host.AssaulterPoint(actor) == original,
            "With both friendly Corners occupied, retry must add ten seconds to the old deadline.");
        BattleArmyEntityState other = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(entity =>
            entity.EntityKey != actor);
        Require(host.ConfirmArmyDeath(other.EntityKey, false), "The other soldier did not release its Corner.");
        AdvanceUntil(host, () => host.AssaulterPoint(actor)?.ComponentFileId != original.ComponentFileId);
        ulong changeTick = host.Snapshot().ServerTick;
        CardUnitInitialPoint next = host.AssaulterPoint(actor) ??
            throw new InvalidOperationException("A changed soldier lost its new destination.");
        checks += Require(changeTick >= retryTick && next.Fraction == original.Fraction &&
            next.ComponentType == "EnemyPointCorner", "The source timer or eligible point mask changed.");
        checks += Require(host.AssaulterCorner(actor) == null && host.AssaulterAttempt(actor) == null &&
            Entity(host, actor).InfantryClip == "run_0",
            "Point transfer did not leave firing and enter source walking.");
        Vector3 start = Position(Entity(host, actor));
        AdvanceUntil(host, () => host.AssaulterCorner(actor) != null);
        AssaulterCornerState arrived = host.AssaulterCorner(actor) ??
            throw new InvalidOperationException("The changed soldier never entered its new Corner.");
        checks += Require(arrived.Entry.PointFileId == next.ComponentFileId &&
            Vector3.Distance(start, Position(Entity(host, actor))) > 0.1f,
            "The point change did not traverse a live route into its reserved destination.");
        checks += Require(arrived.FirstPointChangeEligibleTick > initial.FirstPointChangeEligibleTick &&
            arrived.FirstShotEligibleTick > changeTick, "Arrival did not initialize fresh source clocks.");
        AdvanceUntil(host, () => host.AssaulterAttempt(actor)?.CompletedTick != null);
        checks += Require(host.AssaulterCallback(actor) != null,
            "The relocated soldier did not complete a fresh automatic source volley.");
        Console.WriteLine($"PASS: ordinary Assaulter changes Corner at {changeTick} and fires after arrival.");
        return checks;
    }

    private static int CheckReservations(BattleCombatContent content, RecoveredBattleMap map)
    {
        const ulong actor = (2UL << 32) | 1;
        const ulong other = (2UL << 32) | 2;
        var occupancy = new CardEnemyPointOccupancy(content.CardUnitInitialPoints, map);
        CardUnitInitialPoint original = occupancy.TryAssignAssaulter(actor, 2, Vector3.Zero) ??
            throw new InvalidOperationException("Reservation fixture has no first Corner.");
        IReadOnlyList<CardUnitInitialPoint> choices = occupancy.NextAssaulterPoints(actor);
        int checks = Require(choices.Count > 0 && choices.All(point => point.Fraction == 2 &&
            point.ComponentFileId != original.ComponentFileId) &&
            choices.Select(point => point.Order).SequenceEqual(choices.Select(point => point.Order).Order()),
            "Next-point candidates lost source collection order, fraction or current-point exclusion.");
        CardUnitInitialPoint next = choices[0];
        Require(occupancy.TryAssignAssaulter(other, 2, next.Position) == next,
            "The second soldier did not occupy the selected destination.");
        checks += Reject(() => occupancy.TransferAssaulter(actor, next));
        checks += Require(occupancy.Find(actor) == original &&
            occupancy.Occupant(original.ComponentFileId) == actor,
            "A rejected occupied destination released the current reservation.");
        Require(occupancy.Release(other), "The second reservation did not release.");
        checks += Reject(() => occupancy.TransferAssaulter(actor, next with
        {
            Position = next.Position + Vector3.UnitX
        }));
        occupancy.TransferAssaulter(actor, next);
        checks += Require(occupancy.Find(actor) == next && occupancy.Occupant(next.ComponentFileId) == actor &&
            occupancy.Occupant(original.ComponentFileId) == null,
            "A successful source transfer failed to release the old point and reserve the new one.");
        return checks;
    }

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }

        throw new InvalidOperationException("An invalid point transfer was accepted.");
    }

    private static BattleArmyEntityState Entity(MatchEngine host, ulong actor)
    {
        return host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(entity => entity.EntityKey == actor);
    }

    private static Vector3 Position(BattleArmyEntityState entity)
    {
        return new Vector3(entity.X, entity.Y, entity.Z);
    }

    private static void AdvanceUntil(MatchEngine host, Func<bool> predicate)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && !predicate())
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        Require(!host.Terminal && predicate(),
            $"Point-change fixture stopped at {host.Snapshot().ServerTick}: {host.Snapshot().TerminalReason}.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}
