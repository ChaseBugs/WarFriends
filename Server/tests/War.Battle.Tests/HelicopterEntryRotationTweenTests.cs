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
            JsonElement first = scenario.GetProperty("first");
            var entry = new HelicopterCrewEntryState(ReadRotation(first.GetProperty("from")),
                ReadRotation(first.GetProperty("target")), parent, 0);
            var replay = new EntryReplay(clock, entry);
            checks += VerifyCycle(first, parent, tween, replay);
            checks += VerifyCycle(scenario.GetProperty("reused"), parent, tween, replay);
        }
        VerifyGuards();
        Console.WriteLine("PASS: 33 original entry tween updates, unscaled clock reuse and parent-space rotations.");
        return checks + 5 + VerifyEntryGuards() + VerifyRestartResidual() + VerifyScaledCapture(directory) +
            HelicopterCrewEntryLifecycleTests.Run(directory);
    }

    private static int VerifyCycle(JsonElement cycle, Quaternion parent,
        HelicopterEntryRotationTween tween, EntryReplay replay)
    {
        tween.Begin(ReadRotation(cycle.GetProperty("from")), ReadRotation(cycle.GetProperty("target")));
        JsonElement rows = cycle.GetProperty("rows");
        NguiRealtimeClock clock = replay.Clock;
        HelicopterCrewEntryState entry = replay.Entry;
        entry.Restart(ReadRotation(cycle.GetProperty("from")), ReadRotation(cycle.GetProperty("target")));
        Require(rows.GetArrayLength() is 1 or 10, "Entry tween lost its normal or long-frame completion coverage.");
        foreach (JsonElement row in rows.EnumerateArray())
        {
            clock.ReenableAt(row.GetProperty("previous").GetSingle());
            float delta = clock.Advance(row.GetProperty("realtime").GetSingle());
            Require(delta == row.GetProperty("delta").GetSingle(), "Entry tween used a different realtime delta.");
            tween.AdvanceUpdate(delta);
            entry.ReenableAt(row.GetProperty("previous").GetSingle());
            var pointPosition = new Vector3(3, row.GetProperty("factor").GetSingle(), 7);
            HelicopterRopeBodyPose pose = entry.AdvanceUpdate(row.GetProperty("realtime").GetSingle(), pointPosition);
            Require(pose.Position == pointPosition &&
                Difference(pose.Rotation, ReadRotation(row.GetProperty("rotation"))) < RotationTolerance &&
                entry.IsRotating == row.GetProperty("enabled").GetBoolean(),
                "Composed crew entry differs from source clock, parent rotation or Driving point position.");
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
        Vector3 moved = new(13, 17, 19);
        JsonElement last = rows[rows.GetArrayLength() - 1];
        HelicopterRopeBodyPose held = entry.AdvanceUpdate(last.GetProperty("realtime").GetSingle() + 1, moved);
        Require(held.Position == moved && Difference(held.Rotation,
            ReadRotation(last.GetProperty("rotation"))) < RotationTolerance && !entry.IsRotating,
            "Completed entry stopped following position or changed its retained world rotation.");
        return rows.GetArrayLength() * 5 + 1;
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

    private static int VerifyEntryGuards()
    {
        (float Realtime, Vector3 Position)[] invalid =
        {
            (float.NaN, Vector3.Zero),
            (-1, Vector3.Zero),
            (0.02f, new Vector3(float.NaN, 0, 0)),
            (0.02f, new Vector3(0, float.PositiveInfinity, 0)),
        };
        foreach ((float realtime, Vector3 position) in invalid)
        {
            Quaternion target = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 1);
            var entry = new HelicopterCrewEntryState(Quaternion.Identity, target, Quaternion.Identity, 0);
            var control = new HelicopterCrewEntryState(Quaternion.Identity, target, Quaternion.Identity, 0);
            try
            {
                entry.AdvanceUpdate(realtime, position);
                throw new Exception("Crew entry accepted a malformed observation.");
            }
            catch (InvalidDataException)
            {
                Require(entry.AdvanceUpdate(0.033f, Vector3.One) ==
                    control.AdvanceUpdate(0.033f, Vector3.One),
                    "Rejected crew observation advanced its clock or changed its pose.");
            }
        }
        return invalid.Length;
    }

    private static int VerifyRestartResidual()
    {
        Quaternion target = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 1);
        var expected = new HelicopterEntryRotationTween();
        expected.Begin(Quaternion.Identity, target);
        expected.AdvanceUpdate(0.001f);
        foreach (bool hasOnEnable in new[] { false, true })
        {
            var entry = new HelicopterCrewEntryState(Quaternion.Identity, target, Quaternion.Identity, 0);
            entry.AdvanceUpdate(0.0004f, Vector3.Zero);
            entry.Restart(Quaternion.Identity, target);
            if (hasOnEnable)
            {
                entry.ReenableAt(0.0004f);
            }
            HelicopterRopeBodyPose pose = entry.AdvanceUpdate(0.0008f, Vector3.One);
            Require(pose.Rotation == expected.LocalRotation,
                "Restart discarded the source clock residual or invented an OnEnable time origin.");
        }
        return 2;
    }

    private static int VerifyScaledCapture(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-entry-scaled-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) ==
            "6d5875a2c9f1dcd2e633b44505ad101302ce33e4832d3e8942960a2eb4496344",
            "Scaled entry reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        int checks = 0;
        foreach (JsonElement scenario in document.RootElement.GetProperty("scenarios").EnumerateArray())
        {
            Quaternion parent = ReadRotation(scenario.GetProperty("parent"));
            JsonElement first = scenario.GetProperty("first");
            var entry = new HelicopterCrewEntryState(ReadRotation(first.GetProperty("from")),
                ReadRotation(first.GetProperty("target")), parent, 0);
            checks += VerifyScaledCycle(first, entry);
            checks += VerifyScaledCycle(scenario.GetProperty("reused"), entry);
        }
        Require(checks == 24, "Scaled entry lost fresh/reused parent-space update coverage.");
        Console.WriteLine("PASS: 24 original scaled entry updates across fresh and reused cycles.");
        return checks;
    }

    private static int VerifyScaledCycle(JsonElement cycle, HelicopterCrewEntryState entry)
    {
        entry.Restart(ReadRotation(cycle.GetProperty("from")), ReadRotation(cycle.GetProperty("target")));
        Quaternion initial = entry.AdvanceScaledUpdate(0, Vector3.Zero).Rotation;
        Require(entry.AdvanceScaledUpdate(0, Vector3.One).Rotation == initial && entry.IsRotating,
            "Paused scaled entry moved its rotation or completed without a positive delta.");
        JsonElement rows = cycle.GetProperty("rows");
        foreach (JsonElement row in rows.EnumerateArray())
        {
            Require(!row.GetProperty("ignoreTimeScale").GetBoolean() &&
                row.GetProperty("scaledDelta").GetSingle() > 0 && row.GetProperty("delta").GetSingle() == 0,
                "Scaled reference used the unscaled clock or lost its positive scaled delta.");
            HelicopterRopeBodyPose pose = entry.AdvanceScaledUpdate(row.GetProperty("scaledDelta").GetSingle(),
                Vector3.One);
            Require(Difference(pose.Rotation, ReadRotation(row.GetProperty("rotation"))) < RotationTolerance &&
                entry.IsRotating == row.GetProperty("enabled").GetBoolean(),
                "Scaled crew entry differs from original Update or reused completion state.");
        }
        return rows.GetArrayLength();
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

    private sealed record EntryReplay(NguiRealtimeClock Clock, HelicopterCrewEntryState Entry);
}
