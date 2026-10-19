using System.Numerics;
using War.BattleServer;

/// <summary>Preserves source float progress, old-facing rope alignment and rejected-frame atomicity.</summary>
internal static class HelicopterDescentStateTests
{
    private const float PositionTolerance = 0.00001f;
    private const float StartHeight = 10;
    private const float LandingHeight = 0;

    internal static int Run()
    {
        VerifyAlignmentBeforeRotation();
        VerifyFloatProgress();
        VerifyFixedTickProgress();
        VerifyRejectedFrames();
        Console.WriteLine("PASS: descent progress, pose ordering, completion boundary and invalid-frame atomicity");
        return 46;
    }

    private static void VerifyAlignmentBeforeRotation()
    {
        var state = new HelicopterDescentState(StartHeight, LandingHeight);
        var frame = Frame();
        Vector3[] joints = [new(2, 12, 3), new(2, 0, 3)];
        HelicopterDescentResult result = state.Advance(frame, 0.5f, joints);
        Require(Vector3.Distance(result.Position, new Vector3(1.96f, 5, 3.02f)) < PositionTolerance,
            "Rope alignment must use the old root facing, before turning toward the aircraft's right.");
        Require(Vector3.Distance(Vector3.Transform(Vector3.UnitZ, result.Rotation), Vector3.UnitX) < PositionTolerance,
            "The resulting root must face the aircraft's right vector.");
        Require(state.Progress == 0.5f && result.Progress == 0.5f && !result.AnimationComplete,
            "Half a source second must not complete the descent.");
        var nextFrame = frame with
        {
            RootPosition = result.Position, RootRotation = result.Rotation,
            LeftPalmPosition = result.Position + Vector3.UnitY
        };
        HelicopterDescentResult complete = state.Advance(nextFrame, 0.5f, joints);
        Require(complete.AnimationComplete && state.Progress == 1f,
            "Animation completion must clamp at one without inventing a landing event.");
        try
        {
            state.Advance(nextFrame, 0.1f, joints);
            throw new Exception("A completed descent animation advanced again.");
        }
        catch (InvalidOperationException)
        {
            // The source leaves its Spawning branch after completion.
        }
    }

    private static void VerifyFloatProgress()
    {
        var state = new HelicopterDescentState(StartHeight, LandingHeight);
        HelicopterDescentFrame frame = Frame();
        for (int index = 0; index < MatchManifest.TickRate - 1; index++)
        {
            state.Advance(frame, 1f / MatchManifest.TickRate, null);
        }
        Require(state.Progress < 1f && state.Progress != (MatchManifest.TickRate - 1f) / MatchManifest.TickRate,
            "Source float accumulation must not be replaced with direct elapsed-tick division.");
        Require(state.Advance(frame, 1f / MatchManifest.TickRate, null).AnimationComplete,
            "Thirty fixed source frames must complete this one-second animation.");
    }

    private static void VerifyRejectedFrames()
    {
        var state = new HelicopterDescentState(StartHeight, LandingHeight);
        HelicopterDescentFrame frame = Frame();
        state.Advance(frame, 0.25f, null);
        foreach (float invalidDelta in new[] { -1f, float.NaN, float.PositiveInfinity })
        {
            RequireRejected(state, frame, invalidDelta, null);
        }
        RequireRejected(state, frame with { HelicopterRight = Vector3.Zero }, 0.25f, null);
        RequireRejected(state, frame with { HelicopterRight = Vector3.UnitY }, 0.25f, null);
        RequireRejected(state, frame with { RootRotation = default }, 0.25f, null);
        RequireRejected(state, frame, 0.25f, []);
    }

    private static void VerifyFixedTickProgress()
    {
        var state = new HelicopterDescentState(StartHeight, LandingHeight);
        for (int frame = 0; frame <= MatchManifest.TickRate; frame++)
        {
            Require(HelicopterDescentProgress.AtFixedTicks((ulong)frame) == state.Progress,
                "Fixed-step crew progress must retain every source float addition.");
            if (frame < MatchManifest.TickRate)
            {
                state.Advance(Frame(), 1f / MatchManifest.TickRate, null);
            }
        }
        Require(HelicopterDescentProgress.AtFixedTicks(ulong.MaxValue) == 1f,
            "A later animation sample must remain complete without iterating an unbounded tick gap.");
    }

    internal static void VerifyCrewProjection(ArmyHelicopterCrewStats stats, HelicopterCrewPointCatalog points)
    {
        const ulong StartingTick = 1;
        var crew = new HelicopterCrewState(stats, points, StartingTick);
        var schedule = new HelicopterCrewSchedule(StartingTick, stats.Seats);
        ulong observedTick = schedule.DueTick(0) + MatchManifest.TickRate - 1;
        crew.Advance(schedule, observedTick);
        HelicopterCrewDescentSnapshot descent = crew.DescentSnapshot(observedTick).Single();
        Require(descent.Progress == HelicopterDescentProgress.AtFixedTicks(MatchManifest.TickRate - 1) &&
            descent.Progress != (MatchManifest.TickRate - 1f) / MatchManifest.TickRate && !descent.AnimationComplete,
            "The actual crew projection must accumulate floats before its completion boundary.");
    }

    private static void RequireRejected(HelicopterDescentState state,
        HelicopterDescentFrame frame, float deltaTime, IReadOnlyList<Vector3>? joints)
    {
        float before = state.Progress;
        try
        {
            state.Advance(frame, deltaTime, joints);
            throw new Exception("A malformed descent frame was accepted.");
        }
        catch (InvalidDataException)
        {
            Require(state.Progress == before, "A rejected frame consumed descent progress.");
        }
    }

    private static HelicopterDescentFrame Frame()
    {
        return new HelicopterDescentFrame(new Vector3(0, StartHeight, 0), Quaternion.Identity,
            new Vector3(0, StartHeight + 1, 0), Vector3.UnitX);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
