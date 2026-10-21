using System.Numerics;
using War.BattleServer;
using static War.Battle.Tests.Match.Effects.ArmyFlameClockTests;

namespace War.Battle.Tests.Match.Effects;

internal static class ArmyFlameInterpolationTests
{
    private const float SourceRadius = 3;
    private const float SourceNearAngle = 60;
    private const float SourceFarAngle = 40;
    private const float RelativeTolerance = 0.000002f;

    internal static int Run()
    {
        using var source = new FlameInterpolationReference();
        CheckOriginalLerp(source);
        var failures = new List<string>();
        CheckRegression(() => CheckFarAngle(source), "far angle", failures);
        CheckRegression(() => CheckOutsideCenter(source), "outside center", failures);
        if (failures.Count > 0)
        {
            throw new InvalidOperationException(string.Join("; ", failures));
        }
        CheckDifferentialMatrix(source);
        CheckOverlapGate();
        CheckNearAndEdge(source);
        CheckColliderOrder();
        CheckInvalidAuthority();
        return 8;
    }

    private static void CheckOriginalLerp(FlameInterpolationReference source)
    {
        Require(source.Lerp(1, 10, -1f / 3) == 1 && source.Lerp(1, 10, 2) == 10 &&
            source.Lerp(1, 10, 0.5f) == 5.5f, "The original Client Mathf.Lerp did not clamp interpolation inputs.");
    }

    private static void CheckFarAngle(FlameInterpolationReference source)
    {
        Vector3 center = Center(2, 38);
        float allowed = source.Lerp(SourceNearAngle, SourceFarAngle, MathF.Pow(center.Length(), 0.25f));
        Require(allowed == 40, "The original far cone did not retain its configured forty-degree half angle.");
        ArmyFlameHit? hit = ArmyFlameBurst.ResolveParts(Vector3.Zero, Vector3.UnitZ, [LargeBox(center)], 60);
        Require(hit != null, "An eligible 38-degree collider at distance two was rejected.");
    }

    private static void CheckOutsideCenter(FlameInterpolationReference source)
    {
        PlayerHitbox part = LargeBox(new Vector3(0, 0, 4));
        Require(part.OverlapsSphere(Vector3.Zero, SourceRadius),
            "The large fixture did not overlap the source sphere.");
        float expected = source.Lerp(1, 10, 1f - part.Center.Length() / SourceRadius);
        ArmyFlameHit? hit = ArmyFlameBurst.ResolveParts(Vector3.Zero, Vector3.UnitZ, [part], 60);
        Require(hit?.RawDamage == expected && expected == 1,
            "A large overlapping collider must receive source minimum damage instead of negative extrapolation.");
    }

    private static void CheckDifferentialMatrix(FlameInterpolationReference source)
    {
        foreach (float damage in new[] { 0f, 1f, 60f, 1234.5f, 10_000_000f })
        {
            foreach (float distance in new[] { 0.3f, 0.5f, 1f, 1.25f, 2f, 2.9f, 3f, 3.1f, 4f, 5f, 6f })
            {
                CheckAngles(source, damage, distance);
            }
        }
    }

    private static void CheckAngles(FlameInterpolationReference source, float damage, float distance)
    {
        foreach (float degrees in new[] { 0f, 20f, 35f, 38f, 39.5f, 40.5f, 60f, 179f })
        {
            Vector3 center = Center(distance, degrees);
            PlayerHitbox part = LargeBox(center);
            float measured = center.Length();
            float allowed = source.Lerp(SourceNearAngle, SourceFarAngle, MathF.Pow(measured, 0.25f));
            bool shouldHit = part.OverlapsSphere(Vector3.Zero, SourceRadius) && measured >= 0.3f && degrees < allowed;
            ArmyFlameHit? hit = ArmyFlameBurst.ResolveParts(Vector3.Zero, Vector3.UnitZ, [part], damage);
            Require((hit != null) == shouldHit, $"Source cone differs at distance {distance}, angle {degrees}.");
            if (hit != null)
            {
                float expected = source.Lerp(damage * 0.1f / 6, damage / 6, 1f - measured / SourceRadius);
                float tolerance = RelativeTolerance * Math.Max(1, expected);
                Require(Math.Abs(hit.RawDamage - expected) <= tolerance,
                    $"Source interpolation differs at distance {distance}, angle {degrees}, damage {damage}.");
            }
        }
    }

    private static void CheckOverlapGate()
    {
        var outside = new PlayerHitbox("fixture/outside", PlayerHitboxKind.Sphere, 1,
            new Vector3(0, 0, 4), Vector3.Zero, Quaternion.Identity, 0.1f, Vector3.Zero, 0);
        Require(!outside.OverlapsSphere(Vector3.Zero, SourceRadius) &&
            ArmyFlameBurst.ResolveParts(Vector3.Zero, Vector3.UnitZ, [outside], 60) == null,
            "Clamped damage granted a hit to a collider outside the overlap volume.");
    }

    private static void CheckNearAndEdge(FlameInterpolationReference source)
    {
        foreach ((float distance, float degrees) in new[] { (0.29f, 0f), (0.5f, 44f), (1f, 39.9f), (2f, 40.1f) })
        {
            float allowed = source.Lerp(SourceNearAngle, SourceFarAngle, MathF.Pow(distance, 0.25f));
            bool expected = distance >= 0.3f && degrees < allowed;
            ArmyFlameHit? hit = ArmyFlameBurst.ResolveParts(Vector3.Zero, Vector3.UnitZ,
                [LargeBox(Center(distance, degrees))], 60);
            Require((hit != null) == expected, "Near-distance or cone-edge filtering changed.");
        }
    }

    private static void CheckColliderOrder()
    {
        PlayerHitbox first = LargeBox(new Vector3(0, 0, 4));
        PlayerHitbox closer = LargeBox(Vector3.UnitZ);
        ArmyFlameHit? hit = ArmyFlameBurst.ResolveParts(Vector3.Zero, Vector3.UnitZ, [first, closer], 60);
        Require(hit is { RawDamage: 1, Distance: 4 }, "Clamping changed the first eligible collider selection.");
    }

    private static void CheckInvalidAuthority()
    {
        foreach (float damage in new[] { float.NaN, float.PositiveInfinity, -1f, 10_000_001f })
        {
            RejectInvalidDamage(damage);
        }
    }

    private static void RejectInvalidDamage(float damage)
    {
        try
        {
            ArmyFlameBurst.ResolveParts(Vector3.Zero, Vector3.UnitZ, [LargeBox(Vector3.UnitZ)], damage);
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("Interpolation clamping concealed invalid source damage.");
    }

    private static PlayerHitbox LargeBox(Vector3 center)
    {
        return new("fixture/large-box", PlayerHitboxKind.Box, 1, center, new Vector3(8),
            Quaternion.Identity, 0, Vector3.Zero, 0);
    }

    private static Vector3 Center(float distance, float degrees)
    {
        float radians = degrees * MathF.PI / 180;
        return new Vector3(MathF.Sin(radians) * distance, 0, MathF.Cos(radians) * distance);
    }

    private static void CheckRegression(Action action, string name, List<string> failures)
    {
        try
        {
            action();
        }
        catch (Exception error) when (error is InvalidDataException or InvalidOperationException)
        {
            failures.Add(name + ": " + error.Message);
        }
    }
}
