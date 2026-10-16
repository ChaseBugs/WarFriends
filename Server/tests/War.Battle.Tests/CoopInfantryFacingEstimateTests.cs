using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks bounded presentation facing and preserves explicit disagreement with native steering.</summary>
internal static class CoopInfantryFacingEstimateTests
{
    private const float AngularStepDegrees = 20f;
    private const float AngleTolerance = 0.001f;
    private const float RotationTolerance = 0.000001f;

    internal static void Run(string directory)
    {
        Quaternion rotation = Quaternion.Identity;
        Quaternion target = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.PI / 2f);
        for (int frame = 0; frame < 5; frame++)
        {
            Quaternion previous = rotation;
            rotation = CoopInfantryFacingEstimate.Advance(rotation, Vector3.UnitX);
            Require(Angle(previous, rotation) <= AngularStepDegrees + AngleTolerance,
                "The navigation estimate must not exceed the source angular-speed upper bound.");
        }

        Require(SameRotation(rotation, target), "Route facing must reach its target without overshooting.");
        Require(SameRotation(CoopInfantryFacingEstimate.Advance(rotation, Vector3.Zero), rotation),
            "No route direction must preserve the last estimated facing.");
        ExpectInvalid(() => CoopInfantryFacingEstimate.Advance(default, Vector3.UnitX));
        ExpectInvalid(() => CoopInfantryFacingEstimate.Advance(rotation, new Vector3(float.NaN, 0, 0)));
        CompareNativeSteering(directory);
        Console.WriteLine("PASS: bounded infantry visual facing and source tween composition");
    }

    private static void CompareNativeSteering(string directory)
    {
        // The preceding composition fixture pins these same raw observations before this comparison.
        using JsonDocument plan = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "coop-obstacle-turn-source-plan.json")));
        using JsonDocument phases = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "coop-moving-root-phase-unity-reference.json")));
        Quaternion estimate = Rotation(plan.RootElement.GetProperty("startRotation"));
        var tween = new CoopShotRootTween(0.2f);
        tween.Begin(estimate, Rotation(plan.RootElement.GetProperty("targetRotation")));
        int disagreements = 0;
        float maximumAngle = 0;
        foreach (JsonElement frame in phases.RootElement.GetProperty("samples").EnumerateArray())
        {
            JsonElement velocity = frame.GetProperty("velocity");
            var direction = new Vector3(velocity[0].GetSingle(), velocity[1].GetSingle(), velocity[2].GetSingle());
            Quaternion facing = CoopInfantryFacingEstimate.Advance(estimate, direction);
            bool tweenWritesThisFrame = tween.IsRunning;
            estimate = CoopShotRootComposition.AfterFrame(tween, facing, frame.GetProperty("deltaSeconds").GetSingle());
            Quaternion native = Rotation(frame.GetProperty("afterRotation"));
            if (tweenWritesThisFrame)
            {
                Require(SameRotation(estimate, native), "The known tween stage must preserve actual native writes.");
            }
            if (!SameRotation(estimate, native))
            {
                disagreements++;
            }
            maximumAngle = Math.Max(maximumAngle, Angle(estimate, native));
        }

        Console.WriteLine($"Infantry facing/native comparison: {disagreements} differing frames, " +
            $"maximum angle {maximumAngle:F2} degrees; presentation-only estimate.");
    }

    private static Quaternion Rotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }

    private static float Angle(Quaternion left, Quaternion right)
    {
        float cosine = Math.Clamp(Math.Abs(Quaternion.Dot(left, right)), 0f, 1f);
        return 2f * MathF.Acos(cosine) * (180f / MathF.PI);
    }

    private static bool SameRotation(Quaternion left, Quaternion right)
    {
        return 1f - Math.Abs(Quaternion.Dot(left, right)) <= RotationTolerance;
    }

    private static void ExpectInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidDataException("Invalid visual facing input was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
