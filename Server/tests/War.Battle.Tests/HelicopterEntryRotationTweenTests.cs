using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Replays original unscaled Update calls, component reuse and local/world parent composition.</summary>
internal static class HelicopterEntryRotationTweenTests
{
    private const string ReferenceDigest = "66efb96220882345c7029fb4eac040e5a1f78b61404920273647b309608ee82e";
    private const float RotationTolerance = 0.00001f;

    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-entry-tween-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == ReferenceDigest,
            "Entry tween reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement scenarios = document.RootElement.GetProperty("scenarios");
        Require(scenarios.GetArrayLength() == 3, "Entry tween lost its parent/arc coverage.");
        int checks = 0;
        foreach (JsonElement scenario in scenarios.EnumerateArray())
        {
            var tween = new HelicopterEntryRotationTween();
            var clock = new NguiRealtimeClock(0);
            Quaternion parent = ReadRotation(scenario.GetProperty("parent"));
            checks += VerifyCycle(scenario.GetProperty("first"), parent, tween, clock);
            checks += VerifyCycle(scenario.GetProperty("reused"), parent, tween, clock);
        }
        VerifyGuards();
        Console.WriteLine("PASS: 33 original entry tween updates, unscaled clock reuse and parent-space rotations.");
        return checks + 5;
    }

    private static int VerifyCycle(JsonElement cycle, Quaternion parent,
        HelicopterEntryRotationTween tween, NguiRealtimeClock clock)
    {
        tween.Begin(ReadRotation(cycle.GetProperty("from")), ReadRotation(cycle.GetProperty("target")));
        JsonElement rows = cycle.GetProperty("rows");
        Require(rows.GetArrayLength() is 1 or 10, "Entry tween lost its normal or long-frame completion coverage.");
        foreach (JsonElement row in rows.EnumerateArray())
        {
            clock.ReenableAt(row.GetProperty("previous").GetSingle());
            float delta = clock.Advance(row.GetProperty("realtime").GetSingle());
            Require(delta == row.GetProperty("delta").GetSingle(), "Entry tween used a different realtime delta.");
            tween.AdvanceUpdate(delta);
            Require(tween.Factor == row.GetProperty("factor").GetSingle() &&
                tween.IsRunning == row.GetProperty("enabled").GetBoolean(),
                $"Entry factor {tween.Factor:R}/{row.GetProperty("factor").GetSingle():R}, " +
                $"running {tween.IsRunning}/{row.GetProperty("enabled")}, delta {delta:R} differs from source.");
            Require(Difference(tween.LocalRotation, ReadRotation(row.GetProperty("localRotation"))) < RotationTolerance,
                "Entry tween local rotation differs from the original component.");
            Require(Difference(parent * tween.LocalRotation, ReadRotation(row.GetProperty("rotation"))) <
                RotationTolerance, "Entry tween lost the original local-to-world parent composition.");
        }
        Require(!tween.IsRunning, "Source entry cycle did not terminate.");
        return rows.GetArrayLength() * 4;
    }

    private static void VerifyGuards()
    {
        var tween = new HelicopterEntryRotationTween();
        tween.Begin(Quaternion.Identity, Quaternion.CreateFromAxisAngle(Vector3.UnitY, 1));
        tween.AdvanceUpdate(0.3f);
        Require(tween.IsRunning && tween.Factor == 1f, "Source completes only after its factor exceeds one.");
        Quaternion before = tween.LocalRotation;
        foreach (float invalid in new[] { -1f, float.NaN, float.PositiveInfinity, 1.01f })
        {
            try
            {
                tween.AdvanceUpdate(invalid);
                throw new Exception("Entry tween accepted an invalid clock delta.");
            }
            catch (InvalidDataException)
            {
                Require(tween.Factor == 1 && tween.IsRunning && tween.LocalRotation == before,
                    "Rejected entry update mutated the pose or completion state.");
            }
        }
        tween.AdvanceUpdate(0.001f);
        Require(!tween.IsRunning, "A later positive delta failed to finish the source tween.");
    }

    private static Quaternion ReadRotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }

    private static float Difference(Quaternion first, Quaternion second)
    {
        return MathF.Min((first - second).Length(), (first + second).Length());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
