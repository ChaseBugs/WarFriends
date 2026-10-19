using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using War.BattleServer;

/// <summary>Replays actual automatic source tween dispatch, including first-frame Start/Update and reuse.</summary>
internal static class HelicopterCrewEntryLifecycleTests
{
    private const string ReferenceDigest = "544867587054596fec9d31fa32996ada4f56a6a06c07ddf4712919b21773bc1b";
    private const float RotationTolerance = 0.00001f;

    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-crew-entry-lifecycle-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == ReferenceDigest,
            "Automatic crew entry capture changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement scenarios = document.RootElement.GetProperty("scenarios");
        Require(scenarios.GetArrayLength() == 6, "Automatic entry lost its clock-mode/parent coverage.");
        int checks = 0;
        foreach (JsonElement scenario in scenarios.EnumerateArray())
        {
            JsonElement first = scenario.GetProperty("first");
            var entry = new HelicopterCrewEntryState(Rotation(first.GetProperty("from")),
                Rotation(first.GetProperty("target")), Rotation(scenario.GetProperty("parent")),
                first.GetProperty("enabledAt").GetSingle());
            JsonElement firstRows = first.GetProperty("rows");
            Require(firstRows[0].GetProperty("frame").GetInt32() ==
                firstRows[1].GetProperty("frame").GetInt32(),
                "Fresh source tween lost automatic Start plus Update in the same frame.");
            var dispatch = new HelicopterCrewEntryDispatch(entry);
            checks += VerifyCycle(first, entry, dispatch, CrewEntryCallback.Start);
            checks += VerifyCycle(scenario.GetProperty("reused"), entry, dispatch, CrewEntryCallback.Update);
        }
        Require(checks == 342, "Automatic crew entry lost evaluated updates or reuse coverage.");
        Console.WriteLine("PASS: 342 automatic source entry updates, first-frame double dispatch and retained reuse.");
        return checks + VerifyDispatchGuards() + VerifyInterrupted(directory) + VerifyDeactivationGuards();
    }

    private static int VerifyCycle(JsonElement cycle, HelicopterCrewEntryState entry,
        HelicopterCrewEntryDispatch dispatch, CrewEntryCallback firstCallback)
    {
        if (firstCallback == CrewEntryCallback.Update)
        {
            dispatch.ReactivateAt(cycle.GetProperty("enabledAt").GetSingle());
        }
        entry.Restart(Rotation(cycle.GetProperty("from")), Rotation(cycle.GetProperty("target")));
        bool isUnscaled = cycle.GetProperty("ignoreTimeScale").GetBoolean();
        JsonElement rows = cycle.GetProperty("rows");
        float maximumError = 0;
        int callbackIndex = 0;
        foreach (JsonElement row in rows.EnumerateArray())
        {
            var invocation = new CrewEntryInvocation
            {
                Frame = row.GetProperty("frame").GetUInt64(),
                Callback = callbackIndex == 0 ? firstCallback : CrewEntryCallback.Update,
                ClockMode = isUnscaled ? CrewEntryClockMode.Unscaled : CrewEntryClockMode.Scaled,
                Realtime = row.GetProperty("realtime").GetSingle(),
                ScaledDelta = row.GetProperty("scaledDelta").GetSingle(),
                PointPosition = Vector3.One,
            };
            HelicopterRopeBodyPose pose = dispatch.Advance(invocation);
            Quaternion expected = Rotation(row.GetProperty("rotation"));
            float error = MathF.Min((pose.Rotation - expected).Length(), (pose.Rotation + expected).Length());
            Require(error < RotationTolerance && pose.Position == Vector3.One &&
                entry.IsRotating == row.GetProperty("enabled").GetBoolean(),
                $"Automatic entry differs at frame {row.GetProperty("frame")}: rotation error {error}.");
            maximumError = MathF.Max(maximumError, error);
            callbackIndex++;
        }
        Console.WriteLine($"PASS: {rows.GetArrayLength()} automatic entry observations; maximum error {maximumError}.");
        return rows.GetArrayLength();
    }

    private static Quaternion Rotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }

    private static int VerifyInterrupted(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-crew-entry-interrupted-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) ==
            "94da02fe4add7905c59bda61ac9c63f82925005a3b10e1805e330e862619bd85",
            "Interrupted entry reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement root = document.RootElement;
        Require(root.GetProperty("interrupted").GetBoolean() &&
            root.GetProperty("scenarios").GetArrayLength() == 6,
            "Interrupted entry lost its clock/parent coverage.");
        int checks = 0;
        foreach (JsonElement scenario in root.GetProperty("scenarios").EnumerateArray())
        {
            JsonElement first = scenario.GetProperty("first");
            JsonElement reused = scenario.GetProperty("reused");
            JsonElement firstRows = first.GetProperty("rows");
            JsonElement reusedRows = reused.GetProperty("rows");
            Require(firstRows.GetArrayLength() == 3 && firstRows[2].GetProperty("enabled").GetBoolean() &&
                reusedRows[0].GetProperty("frame").GetInt32() - firstRows[2].GetProperty("frame").GetInt32() == 4 &&
                !reusedRows[reusedRows.GetArrayLength() - 1].GetProperty("enabled").GetBoolean(),
                "Entry interruption no longer covers an unfinished tween and inactive frame gap.");
            var entry = new HelicopterCrewEntryState(Rotation(first.GetProperty("from")),
                Rotation(first.GetProperty("target")), Rotation(scenario.GetProperty("parent")),
                first.GetProperty("enabledAt").GetSingle());
            var dispatch = new HelicopterCrewEntryDispatch(entry);
            checks += VerifyCycle(first, entry, dispatch, CrewEntryCallback.Start);
            dispatch.Deactivate();
            checks += VerifyCycle(reused, entry, dispatch, CrewEntryCallback.Update);
        }
        Require(checks == 185, "Interrupted entry lost automatic callback observations.");
        Console.WriteLine("PASS: 185 interrupted automatic entry observations across deactivation and reuse.");
        return checks;
    }

    private static int VerifyDispatchGuards()
    {
        var start = new CrewEntryInvocation
        {
            Frame = 1, Callback = CrewEntryCallback.Start, ClockMode = CrewEntryClockMode.Scaled,
            Realtime = 0.01f, ScaledDelta = 0.01f, PointPosition = Vector3.Zero,
        };
        CrewEntryInvocation[] rejected =
        {
            start,
            start with { Callback = CrewEntryCallback.Update, Frame = 0 },
            start with { Callback = CrewEntryCallback.Update, ClockMode = (CrewEntryClockMode)99 },
            start with { Callback = CrewEntryCallback.Update, PointPosition = new Vector3(float.NaN, 0, 0) },
        };
        foreach (CrewEntryInvocation invalid in rejected)
        {
            var entry = new HelicopterCrewEntryState(Quaternion.Identity,
                Quaternion.CreateFromAxisAngle(Vector3.UnitY, 1), Quaternion.Identity, 0);
            var dispatch = new HelicopterCrewEntryDispatch(entry);
            HelicopterRopeBodyPose before = dispatch.Advance(start);
            try
            {
                dispatch.Advance(invalid);
                throw new Exception("Crew entry accepted repeated, reversed or malformed dispatch.");
            }
            catch (InvalidDataException)
            {
                HelicopterRopeBodyPose after = dispatch.Advance(start with
                {
                    Callback = CrewEntryCallback.Update, ScaledDelta = 0,
                });
                Require(after == before, "Rejected callback consumed the normal same-frame Update or changed pose.");
            }
        }
        return rejected.Length;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private static int VerifyDeactivationGuards()
    {
        Quaternion target = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 1);
        var entry = new HelicopterCrewEntryState(Quaternion.Identity, target, Quaternion.Identity, 0);
        var dispatch = new HelicopterCrewEntryDispatch(entry);
        var start = new CrewEntryInvocation
        {
            Frame = 1, Callback = CrewEntryCallback.Start, ClockMode = CrewEntryClockMode.Scaled,
            Realtime = 0.01f, ScaledDelta = 0.01f, PointPosition = Vector3.One,
        };
        HelicopterRopeBodyPose before = dispatch.Advance(start);
        dispatch.Deactivate();
        CrewEntryInvocation next = start with { Frame = 2, Callback = CrewEntryCallback.Update };
        Action[] invalid =
        {
            () => dispatch.Advance(next),
            () => dispatch.ReactivateAt(float.NaN),
            () => dispatch.ReactivateAt(-1),
        };
        foreach (Action action in invalid)
        {
            try
            {
                action();
                throw new Exception("Inactive entry consumed a callback or accepted a malformed OnEnable.");
            }
            catch (Exception exception) when (exception is InvalidDataException or InvalidOperationException)
            {
                // The next valid reactivation below must still consume the unchanged next callback.
            }
        }
        dispatch.ReactivateAt(1);
        entry.Restart(Quaternion.Identity, target);
        Require(dispatch.Advance(next) == before, "Rejected inactive work changed pose, Start history or frame ownership.");
        return invalid.Length;
    }
}
