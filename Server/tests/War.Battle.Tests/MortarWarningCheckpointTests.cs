using Google.Protobuf;
using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Restores captured source clocks against independent uninterrupted first/reused playback traces.</summary>
internal static class MortarWarningCheckpointTests
{
    private const int TraceFrames = 140;
    private const int ForwardFrames = 5;
    private const float FrameSeconds = 1f / 30f;
    private const ulong FirstTick = 1000;

    internal static int Run()
    {
        var clock = new MortarIndicatorClock();
        clock.BeginShot(2f);
        int checks = CheckTrace(clock, 2f);
        clock.HideForReuse();
        clock.BeginShot(2f);
        checks += CheckTrace(clock, 2f);
        var immediate = new MortarIndicatorClock();
        immediate.BeginShot(0.25f);
        return checks + CheckTrace(immediate, 0.25f) + CheckRejection();
    }

    private static int CheckTrace(MortarIndicatorClock clock, float stopSeconds)
    {
        var trace = new List<BattleMortarWarningClockState> { clock.Capture() };
        for (int frame = 0; frame < TraceFrames; frame++)
        {
            clock.Advance(FrameSeconds);
            trace.Add(clock.Capture());
        }
        int checks = 0;
        for (int frame = 0; frame + ForwardFrames < trace.Count; frame++)
        {
            BattleMortarWarningClockState checkpoint = BattleMortarWarningClockState.Parser.ParseFrom(
                trace[frame].ToByteArray());
            MortarIndicatorClock restored = MortarIndicatorClock.FromCheckpoint(checkpoint);
            for (int forward = 0; forward < ForwardFrames; forward++)
            {
                restored.Advance(FrameSeconds);
            }
            Require(restored.Capture().Equals(trace[frame + ForwardFrames]),
                "Checkpoint restoration diverged from uninterrupted source phase/startup history.");
            checks++;
            if (!checkpoint.Visible)
            {
                continue;
            }
            BattleMortarWarningState source = Row(checkpoint, FirstTick + (ulong)frame, stopSeconds);
            BattleMortarWarningState? projected = MortarWarningReconstruction.AtTick(source,
                source.ObservedTick + ForwardFrames);
            BattleMortarWarningClockState expected = trace[frame + ForwardFrames];
            Require(expected.Visible ? projected != null && projected.Clock.Equals(expected) : projected == null,
                "Late warning reconstruction restarted a clock or retained an expired warning.");
            Require(source.Clock.Equals(checkpoint) && source.ObservedTick == FirstTick + (ulong)frame,
                "Reconstruction mutated the frozen network sample.");
            checks += 2;
        }
        return checks;
    }

    private static int CheckRejection()
    {
        var clock = new MortarIndicatorClock();
        clock.BeginShot(2f);
        BattleMortarWarningClockState valid = clock.Capture();
        var mutations = new Action<BattleMortarWarningClockState>[]
        {
            state => state.HasBegun = false,
            state => state.ShrinkSpeed = float.NaN,
            state => state.BlinkFactor = 2,
            state => state.BlinkSpeed = 10,
            state => state.BlinkBoundaryCount = 7,
            state => state.Blinking = true,
            state => state.Scale = 0
        };
        foreach (Action<BattleMortarWarningClockState> mutation in mutations)
        {
            var damaged = valid.Clone();
            mutation(damaged);
            Reject(() => MortarIndicatorClock.FromCheckpoint(damaged));
        }
        BattleMortarWarningState row = Row(valid, FirstTick, 2f);
        Reject(() => MortarWarningReconstruction.AtTick(row, FirstTick - 1));
        Reject(() => MortarWarningReconstruction.AtTick(row, FirstTick + 1801));
        var inconsistent = row.Clone();
        inconsistent.Scale = 1.4f;
        Reject(() => MortarWarningPolicy.Validate([inconsistent], FirstTick, 2));
        inconsistent = row.Clone();
        inconsistent.StopSeconds = 3f;
        Reject(() => MortarWarningPolicy.Validate([inconsistent], FirstTick, 2));
        var paused = MortarIndicatorClock.FromCheckpoint(valid);
        paused.Advance(0f);
        clock.Advance(0f);
        Require(paused.Capture().Equals(clock.Capture()) && paused.RotationFactor == valid.RotationFactor,
            "A restored zero-delta update lost source sampling without elapsed time.");
        return mutations.Length + 5;
    }

    private static BattleMortarWarningState Row(BattleMortarWarningClockState state, ulong tick, float stopSeconds)
    {
        return new BattleMortarWarningState
        {
            EntityKey = (1UL << 32) | 1, OwnerPlayerId = new string('a', 32), OwnerFraction = 1,
            ObserverFraction = 2, WeaponSlot = 0, ProjectileId = 1, LaunchTick = FirstTick,
            ObservedTick = tick, StopSeconds = stopSeconds, Clock = state.Clone(),
            RotationFactor = state.RotationFactor, Scale = state.Scale, Alpha = state.Alpha
        };
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new InvalidOperationException("Malformed clock checkpoint or reconstruction time was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
