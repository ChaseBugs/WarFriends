using System.Reflection;
using War.BattleServer;

namespace War.Battle.Tests.Match.Effects;

internal static class PvpArmyFlameSystemTests
{
    private const string Owner = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const ulong Entity = 7;

    internal static int Run()
    {
        CheckPreflightAndOrder();
        CheckFinalCompletion();
        CheckCapturedFrame();
        CheckDiscardAndIsolation();
        CheckInvalidClock();
        CheckCompiledOwnership();
        return 6;
    }

    private static void CheckPreflightAndOrder()
    {
        var system = new PvpArmyFlameSystem();
        system.StartBurst(9, Entity, Owner, 0);
        system.StartBurst(2, Entity, Owner, 0);
        PvpArmyFlameSystem.PulseFrame frame = system.BeginFrame(0.36f);

        Require(frame.TryNextDue(out ArmyFlameSource source) && source.ProjectileId == 2,
            "Flame preflight must observe the smallest captured ID first.");
        Require(system.CreateProgress(Entity).All(row => row.PulseIndex == 0),
            "Geometry/source preflight must not commit either flame clock.");
        Throws<InvalidOperationException>(() => frame.TryNextDue(out _));
        Throws<InvalidOperationException>(() => frame.CompleteCurrent());
        ArmyFlamePulse pulse = frame.CommitCurrent();
        Require(pulse.ProjectileId == 2 && pulse.PulseIndex == 1 && pulse.OwnerPlayerId == Owner,
            "Committed observations must retain source identity and the updated receipt index.");
        Throws<InvalidOperationException>(() => frame.CommitCurrent());
        Throws<InvalidOperationException>(() => frame.DiscardCurrent());
        frame.CompleteCurrent();
        Require(frame.TryNextDue(out source) && source.ProjectileId == 9 && pulse.PulseIndex == 1,
            "World callbacks must complete before another captured source is observed.");
        frame.DiscardCurrent();
    }

    private static void CheckFinalCompletion()
    {
        var system = new PvpArmyFlameSystem();
        system.StartBurst(1, Entity, Owner, 0);
        for (int index = 1; index <= ArmyFlamePulseClock.PulseCount; index++)
        {
            float deadline = system.CreateProgress(Entity).Single().NextPulseSeconds;
            PvpArmyFlameSystem.PulseFrame frame = system.BeginFrame(MathF.BitIncrement(deadline));
            Require(frame.TryNextDue(out _), "The next strict source deadline must become due.");
            ArmyFlamePulse pulse = frame.CommitCurrent();
            Require(pulse.PulseIndex == index && system.Count == 1,
                "Even the final committed burst must remain reserved through world callbacks.");
            frame.CompleteCurrent();
            Require(system.Count == (index == ArmyFlamePulseClock.PulseCount ? 0 : 1),
                "Only completion of the sixth world callback releases the burst.");
        }
        system.StartBurst(2, Entity, Owner, 0);
        PvpArmyFlameSystem.PulseFrame terminal = system.BeginFrame(1);
        terminal.TryNextDue(out _);
        terminal.CommitCurrent();
        system.Clear();
        terminal.CompleteCurrent();
        Require(system.Count == 0, "A terminal world callback may clear its own committed burst.");
    }

    private static void CheckCapturedFrame()
    {
        var system = new PvpArmyFlameSystem();
        system.StartBurst(1, Entity, Owner, 0);
        PvpArmyFlameSystem.PulseFrame frame = system.BeginFrame(2);
        system.StartBurst(2, Entity, Owner, 0);
        Require(frame.TryNextDue(out _), "The captured burst must be due after a delayed source frame.");
        frame.CommitCurrent();
        frame.CompleteCurrent();
        Require(!frame.TryNextDue(out _) && system.CreateProgress(Entity)[1].PulseIndex == 0,
            "A source frame emits at most one pulse per captured burst and excludes later insertions.");
        PvpArmyFlameSystem.PulseFrame next = system.BeginFrame(2);
        Require(next.TryNextDue(out ArmyFlameSource source) && source.ProjectileId == 1,
            "A separate source frame at the same simulation tick can emit the next overdue pulse.");
        next.DiscardCurrent();
    }

    private static void CheckDiscardAndIsolation()
    {
        var first = new PvpArmyFlameSystem();
        var second = new PvpArmyFlameSystem();
        first.StartBurst(1, Entity, Owner, 0);
        second.StartBurst(1, Entity, Owner, 0);
        var before = first.CreateProgress(Entity).ToArray();
        before[0] = (99, 99, 99);
        PvpArmyFlameSystem.PulseFrame frame = first.BeginFrame(0.35f);
        Require(!frame.TryNextDue(out _) && first.Count == 1,
            "A dead/missing source retains its reservation until the strict pulse deadline is due.");
        frame = first.BeginFrame(0.36f);
        frame.TryNextDue(out _);
        frame.DiscardCurrent();
        Require(first.Count == 0 && second.CreateProgress(Entity).Single().PulseIndex == 0,
            "Discarding a missing source or editing a projection must not affect another match.");
    }

    private static void CheckInvalidClock()
    {
        var system = new PvpArmyFlameSystem();
        Throws<InvalidDataException>(() => system.StartBurst(1, Entity, Owner, float.NaN));
        Require(system.Count == 0, "Invalid creation must not insert a burst.");
        system.StartBurst(1, Entity, Owner, 0);
        PvpArmyFlameSystem.PulseFrame frame = system.BeginFrame(0.36f);
        frame.TryNextDue(out _);
        frame.CommitCurrent();
        frame.CompleteCurrent();
        PvpArmyFlameSystem.PulseFrame reversed = system.BeginFrame(0.1f);
        Throws<InvalidDataException>(() => reversed.TryNextDue(out _));
        Require(system.CreateProgress(Entity).Single().PulseIndex == 1,
            "A reversed source clock must propagate its error without another commit.");
    }

    private static void CheckCompiledOwnership()
    {
        FieldInfo field = typeof(MatchEngine).GetField("_armyFlames", BindingFlags.NonPublic | BindingFlags.Instance)!;
        Require(field.IsInitOnly && field.FieldType == typeof(PvpArmyFlameSystem),
            "The engine must retain one readonly flame owner.");
        Require(typeof(ArmyFlameSource).IsValueType && typeof(ArmyFlamePulse).IsValueType &&
            typeof(PvpArmyFlameSystem.PulseFrame).IsValueType,
            "Flame observations and cursors must not allocate per-pulse wrapper objects.");
        MethodInfo[] methods = typeof(PvpArmyFlameSystem).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        Require(methods.All(method => method.ReturnType != typeof(ArmyFlameBurst)),
            "The collection owner must not expose a stored mutable burst.");
    }

    private static void Throws<T>(Action action) where T : Exception
    {
        try
        {
            action();
        }
        catch (T)
        {
            return;
        }
        throw new InvalidOperationException($"Expected {typeof(T).Name}.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
