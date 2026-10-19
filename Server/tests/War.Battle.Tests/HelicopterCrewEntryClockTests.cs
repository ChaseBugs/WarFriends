using System.Numerics;

using War.BattleServer;

/// <summary>Checks source clock isolation across active Begin calls and rejected scaled observations.</summary>
internal static class HelicopterCrewEntryClockTests
{
    private const float SourceRoundedTenMilliseconds = 10 * 0.001f;

    internal static int Run()
    {
        VerifyActiveRestart();
        int rejected = VerifyRejectedScaledInput();
        Console.WriteLine("PASS: active entry restart preserves the unscaled clock across scaled work.");
        return rejected + 1;
    }

    private static void VerifyActiveRestart()
    {
        Quaternion target = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 1);
        var entry = new HelicopterCrewEntryState(Quaternion.Identity, target, Quaternion.Identity, 0);
        var dispatch = new HelicopterCrewEntryDispatch(entry);
        var invocation = new CrewEntryInvocation
        {
            Frame = 1, Callback = CrewEntryCallback.Start, ClockMode = CrewEntryClockMode.Unscaled,
            Realtime = 0.0004f, ScaledDelta = 0, PointPosition = Vector3.One,
        };
        dispatch.Advance(invocation);

        // Begin on an already enabled source component does not invoke OnEnable or reset its clock origin.
        entry.Restart(Quaternion.Identity, target);
        dispatch.Advance(invocation with
        {
            Frame = 2, Callback = CrewEntryCallback.Update, ClockMode = CrewEntryClockMode.Scaled,
            Realtime = 0.01f, ScaledDelta = 0.02f,
        });
        entry.Restart(Quaternion.Identity, target);
        HelicopterRopeBodyPose actual = dispatch.Advance(invocation with
        {
            Frame = 3, Callback = CrewEntryCallback.Update, Realtime = 0.0104f,
        });

        // The unscaled clock still starts at 0.0004 with its retained 0.0004 residual: rounded delta is 0.01.
        var expected = new HelicopterEntryRotationTween();
        expected.Begin(Quaternion.Identity, target);
        expected.AdvanceUpdate(SourceRoundedTenMilliseconds);
        Require(actual.Rotation == expected.LocalRotation && actual.Position == Vector3.One && entry.IsRotating,
            "Scaled work or active Begin reset/advanced the unscaled origin, residual or component Start history.");
    }

    private static int VerifyRejectedScaledInput()
    {
        float[] invalid = { -1, float.NaN, float.PositiveInfinity, float.MaxValue };
        foreach (float delta in invalid)
        {
            Quaternion target = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 1);
            var entry = new HelicopterCrewEntryState(Quaternion.Identity, target, Quaternion.Identity, 0);
            var control = new HelicopterCrewEntryState(Quaternion.Identity, target, Quaternion.Identity, 0);
            entry.AdvanceUpdate(0.0004f, Vector3.Zero);
            control.AdvanceUpdate(0.0004f, Vector3.Zero);
            try
            {
                entry.AdvanceScaledUpdate(delta, Vector3.Zero);
                throw new Exception("Scaled entry accepted a malformed delta or overflowed derived progress.");
            }
            catch (InvalidDataException)
            {
                Require(entry.AdvanceUpdate(0.033f, Vector3.One) == control.AdvanceUpdate(0.033f, Vector3.One) &&
                    entry.IsRotating == control.IsRotating,
                    "Rejected scaled observation changed rotation, completion or unscaled clock residual.");
            }
        }
        return invalid.Length;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
