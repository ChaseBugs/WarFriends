using System.Numerics;
using System.Reflection;
using War.BattleServer;

namespace War.Battle.Tests.Match.Effects;

internal static class PvpArmyPoisonSystemTests
{
    private const string Attacker = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Victim = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const ulong Entity = 7;

    internal static int Run()
    {
        CheckImmediateOrder();
        CheckFivePulses();
        CheckDiscard();
        CheckCaptureAndClock();
        CheckProjectionAndIsolation();
        CheckCompiledOwnership();
        return 6;
    }

    private static void CheckImmediateOrder()
    {
        var system = new PvpArmyPoisonSystem();
        Start(system, 9);
        Start(system, 2);
        PvpArmyPoisonSystem.PulseFrame frame = system.BeginFrame(10);
        Require(frame.TryTakeNext(out ArmyPoisonPulse pulse) && pulse.Source.ProjectileId == 2,
            "Poison must pulse immediately at impact, in captured ID order.");
        Require(pulse.Remaining == 4 && system.PendingPulseCount == 9 && system.Count == 2,
            "A poison pulse decrements its reservation before victim lookup and world damage.");
        Throws<InvalidOperationException>(() => frame.TryTakeNext(out _));
        frame.CompleteCurrent();
        Require(frame.TryTakeNext(out ArmyPoisonPulse later) && later.Source.ProjectileId == 9 &&
            later.Remaining == 4 && pulse.Source.ProjectileId == 2,
            "Callbacks must finish before the next independent coroutine is observed.");
        frame.CompleteCurrent();
    }

    private static void CheckFivePulses()
    {
        var system = new PvpArmyPoisonSystem();
        Start(system, 1);
        for (int index = 0; index < ArmyPoisonEffect.PulseCount; index++)
        {
            ulong tick = 10 + (ulong)(index * ArmyPoisonEffect.PulseIntervalTicks);
            PvpArmyPoisonSystem.PulseFrame frame = system.BeginFrame(tick);
            Require(frame.TryTakeNext(out ArmyPoisonPulse pulse) && pulse.Remaining == 4 - index,
                "Poison must retain the source's five independent one-second pulse deadlines.");
            Require(system.Count == 1 && system.PendingPulseCount == 4 - index,
                "The final poison entry remains visible until its world callback completes.");
            frame.CompleteCurrent();
            Require(system.Count == (index == 4 ? 0 : 1),
                "Only completion of the final callback removes the coroutine.");
        }
    }

    private static void CheckDiscard()
    {
        var system = new PvpArmyPoisonSystem();
        Start(system, 1);
        PvpArmyPoisonSystem.PulseFrame frame = system.BeginFrame(10);
        frame.TryTakeNext(out ArmyPoisonPulse pulse);
        frame.DiscardCurrent();
        Require(system.Count == 0 && system.PendingPulseCount == 0 && pulse.Remaining == 4,
            "A missing/dead victim releases all remaining reservations without rewriting the observation.");
        Throws<InvalidOperationException>(() => frame.CompleteCurrent());
    }

    private static void CheckCaptureAndClock()
    {
        var system = new PvpArmyPoisonSystem();
        Start(system, 1);
        PvpArmyPoisonSystem.PulseFrame captured = system.BeginFrame(10);
        Start(system, 2);
        captured.TryTakeNext(out _);
        captured.CompleteCurrent();
        Require(!captured.TryTakeNext(out _) && system.PendingPulseCount == 9,
            "A captured poison frame must exclude effects inserted afterward.");
        PvpArmyPoisonSystem.PulseFrame repeated = system.BeginFrame(10);
        Require(repeated.TryTakeNext(out ArmyPoisonPulse pulse) && pulse.Source.ProjectileId == 2,
            "A repeated impact tick must leave the consumed coroutine alone and admit the new one.");
        repeated.CompleteCurrent();
        PvpArmyPoisonSystem.PulseFrame early = system.BeginFrame(39);
        Require(!early.TryTakeNext(out _), "Poison must not pulse before its fixed-tick deadline.");
        PvpArmyPoisonSystem.PulseFrame skipped = system.BeginFrame(41);
        Throws<InvalidDataException>(() => skipped.TryTakeNext(out _));
        Require(system.PendingPulseCount == 8, "A skipped deadline must throw before consuming a pulse.");
        PvpArmyPoisonSystem.PulseFrame recovered = system.BeginFrame(40);
        Require(recovered.TryTakeNext(out _), "The failed observation must not change the stored deadline.");
        recovered.CompleteCurrent();
    }

    private static void CheckProjectionAndIsolation()
    {
        var first = new PvpArmyPoisonSystem();
        var second = new PvpArmyPoisonSystem();
        Start(first, 1);
        Start(second, 1);
        var projection = first.CreateProgress(Entity).ToArray();
        projection[0] = (99, 99);
        PvpArmyPoisonSystem.PulseFrame frame = first.BeginFrame(10);
        frame.TryTakeNext(out ArmyPoisonPulse pulse);
        frame.CompleteCurrent();
        Require(pulse.Source == new ArmyPoisonSource(1, Entity, Attacker, Victim) &&
            pulse.Position == Vector3.One && pulse.DamagePerPulse == 2 &&
            first.CreateProgress(Entity).Single().Remaining == 4 && second.PendingPulseCount == 5,
            "Detached source/position/damage and projection edits must not cross match ownership.");
        Throws<InvalidDataException>(() => first.StartEffect(new(2, Entity, Attacker, Victim),
            float.NaN, Vector3.One, 10));
        Require(first.Count == 1, "An invalid poison must fail construction before insertion.");
    }

    private static void CheckCompiledOwnership()
    {
        FieldInfo field = typeof(MatchEngine).GetField("_armyPoisons", BindingFlags.NonPublic | BindingFlags.Instance)!;
        Require(field.IsInitOnly && field.FieldType == typeof(PvpArmyPoisonSystem),
            "The engine must retain one readonly poison owner.");
        Require(typeof(ArmyPoisonSource).IsValueType && typeof(ArmyPoisonPulse).IsValueType &&
            typeof(PvpArmyPoisonSystem.PulseFrame).IsValueType,
            "Poison observations and cursors must not allocate per-pulse wrappers.");
        MethodInfo[] methods = typeof(PvpArmyPoisonSystem).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        Require(methods.All(method => method.ReturnType != typeof(ArmyPoisonEffect)),
            "The collection owner must not expose a stored mutable coroutine.");
    }

    private static void Start(PvpArmyPoisonSystem system, ulong id)
    {
        system.StartEffect(new(id, Entity, Attacker, Victim), 2, Vector3.One, 10);
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
