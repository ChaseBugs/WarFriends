using System.IO.Compression;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;

/// <summary>Checks construction phases and source detach evidence against both native controller orders.</summary>
internal static class MortarPreparationReferenceTests
{
    private const string Revision = "0caa927c7881476859e59153855dd90e5aa0a4357c758e5a8d221986f8376280";
    private const int MaximumReportBytes = 3_000_000;
    private const float Tolerance = 0.00001f;
    private const float NativeBuildSeconds = 2f;
    private const ulong NativeBuildDelayTicks = 61;
    private const ulong NativeHandReturnTicks = 34;

    internal static int Run(string directory)
    {
        using JsonDocument document = JsonDocument.Parse(ReadReference(directory));
        JsonElement root = document.RootElement;
        int checks = Require(root.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
            root.GetProperty("captureRate").GetInt32() == MatchManifest.TickRate &&
            root.GetProperty("timeScale").GetSingle() == 1f && root.GetProperty("scenarios").GetArrayLength() == 2,
            "Mortar native preparation evidence lost its supported capture identity.");
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        float downSeconds = content.EnemyPoses.Clip("mortar_down").Length;
        float hideSeconds = content.EnemyPoses.Clip("mortar_hide").Length;
        foreach (JsonElement scenario in root.GetProperty("scenarios").EnumerateArray())
        {
            JsonElement[] frames = scenario.GetProperty("frames").EnumerateArray().ToArray();
            foreach (JsonElement build in frames.Where(frame => Phase(frame) == "build-called"))
            {
                checks += CheckCycle(frames, build.GetProperty("tick").GetUInt64(),
                    (downSeconds, hideSeconds, content.MortarPreparedPose));
            }
        }
        checks += Reject(() => MortarConstructionClock.PoseAt(5, 4, downSeconds));
        checks += Reject(() => MortarConstructionClock.PoseAt(5, 5, float.NaN));
        checks += Reject(() => MortarConstructionClock.PoseAt(5, 5, 0f));
        checks += Reject(() => content.MortarPreparedPose.Capture(66, (5, Vector3.Zero, Vector3.Zero),
            NativeBuildSeconds, hideSeconds));
        checks += Reject(() => content.MortarPreparedPose.Capture(66, (5, Vector3.Zero, Vector3.UnitZ),
            float.NaN, hideSeconds));
        checks += Reject(() => content.MortarPreparedPose.Capture(66, (5, Vector3.Zero, Vector3.UnitZ),
            NativeBuildSeconds, float.NaN));
        checks += Reject(() => content.MortarPreparedPose.Capture(65, (5, Vector3.Zero, Vector3.UnitZ),
            NativeBuildSeconds, hideSeconds));
        return checks;
    }

    private static int CheckCycle(JsonElement[] frames, ulong enteredTick,
        (float DownSeconds, float HideSeconds, MortarPreparedPoseSource Source) source)
    {
        JsonElement preparation = frames.First(frame => Phase(frame) == "before-fire" && Tick(frame) > enteredTick);
        ulong preparedTick = Tick(preparation);
        int checks = Require(preparedTick == enteredTick + NativeBuildDelayTicks,
            "The native strict two-second construction deadline changed.");
        foreach (JsonElement frame in frames.Where(frame => Phase(frame) == "late-update" &&
            Tick(frame) >= enteredTick && Tick(frame) < preparedTick))
        {
            var projected = MortarConstructionClock.PoseAt(enteredTick, Tick(frame), source.DownSeconds);
            JsonElement clip = frame.GetProperty("clips").EnumerateArray().Single();
            string? name = clip.GetProperty("name").GetString();
            float seconds = (Tick(frame) - projected.StartTick) / (float)MatchManifest.TickRate;
            checks += Require((name == projected.Clip || name == projected.Clip + " - Queued Clone") &&
                MathF.Abs(seconds - clip.GetProperty("time").GetSingle()) < Tolerance,
                "Host construction phase or clip time differs from the actual native queued animation.");
        }
        JsonElement detached = frames.Single(frame => Tick(frame) == preparedTick &&
            Phase(frame) == "after-world-detach");
        JsonElement animationCall = frames.Single(frame => Tick(frame) == preparedTick &&
            Phase(frame) == "after-animation-call");
        checks += Require(SamePose(preparation, animationCall) && SamePose(preparation, detached) &&
            detached.GetProperty("detached").GetBoolean(),
            "FiredMortar or source world detachment changed the current snap-point pose.");
        JsonElement hand = frames.First(frame => Tick(frame) > preparedTick && Phase(frame) == "hand-return-callback");
        ulong handTick = Tick(hand);
        checks += Require(handTick == preparedTick + NativeHandReturnTicks &&
            !hand.GetProperty("detached").GetBoolean(),
            "Source hand return lost its observed coroutine phase.");
        Vector3 facing = Vector3.Transform(Vector3.UnitZ, Rotation(preparation, "rootRotation"));
        MortarDetachedWeaponPose captured = source.Source.Capture(preparedTick,
            (enteredTick, Vector(preparation, "rootPosition"), facing), NativeBuildSeconds, source.HideSeconds);
        checks += Require(captured.HandReturnTick == handTick &&
            Vector3.Distance(captured.Position, Vector(preparation, "snapPosition")) < Tolerance &&
            Vector3.Distance(captured.Scale, Vector(preparation, "snapScale")) < Tolerance &&
            MathF.Abs(Quaternion.Dot(captured.Rotation, Rotation(preparation))) > 1f - Tolerance,
            "Host world-transform composition differs from the native preparation pose.");
        foreach (JsonElement frame in frames.Where(frame => Phase(frame) == "late-update" &&
            Tick(frame) >= preparedTick && Tick(frame) < handTick))
        {
            checks += Require(frame.GetProperty("detached").GetBoolean() && SamePose(detached, frame),
                "The original detached weapon moved with later source animation or the synthetic body turn.");
        }
        return checks;
    }

    private static byte[] ReadReference(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "mortar-preparation-unity-reference.json.gz"));
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != Revision)
        {
            throw new InvalidDataException("Native Mortar preparation reference changed without review.");
        }
        using var compressed = new MemoryStream(bytes);
        using var decompressor = new GZipStream(compressed, CompressionMode.Decompress);
        using var report = new MemoryStream();
        byte[] buffer = new byte[4096];
        int read;
        while ((read = decompressor.Read(buffer)) > 0)
        {
            if (report.Length + read > MaximumReportBytes)
            {
                throw new InvalidDataException("Native Mortar preparation reference exceeds its bounded size.");
            }
            report.Write(buffer, 0, read);
        }
        return report.ToArray();
    }

    private static bool SamePose(JsonElement first, JsonElement second)
    {
        return Vector3.Distance(Vector(first, "snapPosition"), Vector(second, "snapPosition")) < Tolerance &&
            Vector3.Distance(Vector(first, "snapScale"), Vector(second, "snapScale")) < Tolerance &&
            MathF.Abs(Quaternion.Dot(Rotation(first), Rotation(second))) > 1f - Tolerance;
    }

    private static Vector3 Vector(JsonElement frame, string name)
    {
        JsonElement row = frame.GetProperty(name);
        return new Vector3(row[0].GetSingle(), row[1].GetSingle(), row[2].GetSingle());
    }

    private static Quaternion Rotation(JsonElement frame, string name = "snapRotation")
    {
        JsonElement row = frame.GetProperty(name);
        return new Quaternion(row[0].GetSingle(), row[1].GetSingle(), row[2].GetSingle(), row[3].GetSingle());
    }

    private static string? Phase(JsonElement frame) => frame.GetProperty("phase").GetString();

    private static ulong Tick(JsonElement frame) => frame.GetProperty("tick").GetUInt64();

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }
        throw new InvalidOperationException("Mortar construction accepted an invalid source clock.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}
