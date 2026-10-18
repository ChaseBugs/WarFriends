using System.IO.Compression;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;

/// <summary>Checks stored float time, build prediction, relocation and both observed preparation poses.</summary>
internal static class MortarAccumulatedClockReferenceTests
{
    private const string Revision = "98346fe6745e76eed3dd1016c6fdab810941cebcefe8b5f65d62ecd505c7cd14";
    private const int MaximumReportBytes = 5_000_000;
    private const float Tolerance = 0.00001f;
    private const float BuildSeconds = 2f;

    internal static int Run(string directory)
    {
        using JsonDocument document = JsonDocument.Parse(ReadReference(directory));
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        JsonElement root = document.RootElement;
        int checks = Require(root.GetProperty("captureRate").GetInt32() == MatchManifest.TickRate &&
            root.GetProperty("scenarios").GetArrayLength() == 4,
            "Accumulated Mortar reference lost its paired source-controller scenarios.");
        foreach (JsonElement scenario in root.GetProperty("scenarios").EnumerateArray())
        {
            if (scenario.GetProperty("useAccumulatedClock").GetBoolean())
            {
                checks += CheckClock(scenario, content);
            }
            checks += CheckPoses(scenario, content);
        }
        var unchanged = new MortarControllerClock(0f);
        checks += Reject(() => new MortarControllerClock(float.NaN));
        checks += Reject(() => new MortarControllerClock(-1f));
        checks += Reject(() => unchanged.Advance(float.NaN));
        checks += Reject(() => unchanged.Advance(-MortarControllerClock.FixedDeltaSeconds));
        checks += Reject(() => unchanged.TicksUntilStrictDelay(0f));
        checks += Require(unchanged.Time == 0f, "Rejected Mortar clock input changed timer authority.");
        return checks;
    }

    private static int CheckClock(JsonElement scenario, BattleCombatContent content)
    {
        var clock = new MortarControllerClock(scenario.GetProperty("initialControllerTime").GetSingle());
        JsonElement[] frames = scenario.GetProperty("frames").EnumerateArray().ToArray();
        float relocationDeadline = float.PositiveInfinity;
        float previousTime = clock.Time;
        int checks = 0;
        foreach (JsonElement frame in frames)
        {
            string? phase = frame.GetProperty("phase").GetString();
            ulong tick = frame.GetProperty("tick").GetUInt64();
            if (phase == "update-entry")
            {
                previousTime = clock.Time;
                clock.Advance(frame.GetProperty("deltaTime").GetSingle());
                checks += Require(clock.Time == frame.GetProperty("controllerTime").GetSingle(),
                    "Host float accumulation differs from the actual Unity probe's stored mTime.");
            }
            if (phase == "build-called")
            {
                JsonElement shot = frames.First(row => row.GetProperty("tick").GetUInt64() > tick &&
                    row.GetProperty("phase").GetString() == "before-fire");
                checks += Require(clock.TicksUntilStrictDelay(BuildSeconds) ==
                    shot.GetProperty("tick").GetUInt64() - tick,
                    "Host construction prediction lost the source float-dependent preparation frame.");
            }
            if (phase == "before-fire")
            {
                relocationDeadline = clock.Time + content.EnemyPoses.Clip("mortar_hide").Length +
                    content.EnemyPoses.Clip("mortar_up").Length;
            }
            if (phase == "relocation-due")
            {
                checks += Require(previousTime <= relocationDeadline && clock.Time > relocationDeadline,
                    "Host relocation clock lost the source strict float deadline.");
            }
        }
        return checks;
    }

    private static int CheckPoses(JsonElement scenario, BattleCombatContent content)
    {
        JsonElement[] frames = scenario.GetProperty("frames").EnumerateArray().ToArray();
        int checks = 0;
        foreach (JsonElement build in frames.Where(row => row.GetProperty("phase").GetString() == "build-called"))
        {
            ulong buildTick = build.GetProperty("tick").GetUInt64();
            JsonElement shot = frames.First(row => row.GetProperty("tick").GetUInt64() > buildTick &&
                row.GetProperty("phase").GetString() == "before-fire");
            Quaternion root = Rotation(shot.GetProperty("rootRotation"));
            MortarDetachedWeaponPose pose = content.MortarPreparedPose.Capture(
                shot.GetProperty("tick").GetUInt64(),
                (buildTick, Vector(shot.GetProperty("rootPosition")), Vector3.Transform(Vector3.UnitZ, root)),
                BuildSeconds, content.EnemyPoses.Clip("mortar_hide").Length);
            checks += Require(Vector3.Distance(pose.Position, Vector(shot.GetProperty("snapPosition"))) < Tolerance &&
                MathF.Abs(Quaternion.Dot(pose.Rotation, Rotation(shot.GetProperty("snapRotation")))) > 1f - Tolerance &&
                Vector3.Distance(pose.Scale, Vector(shot.GetProperty("snapScale"))) < Tolerance,
                "Host selected the wrong observed pose for the actual construction frame count.");
        }
        return checks;
    }

    private static byte[] ReadReference(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "mortar-accumulated-unity-reference.json.gz"));
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != Revision)
        {
            throw new InvalidDataException("Native accumulated Mortar reference changed without review.");
        }
        using var input = new MemoryStream(bytes);
        using var gzip = new GZipStream(input, CompressionMode.Decompress);
        using var output = new MemoryStream();
        byte[] buffer = new byte[4096];
        int read;
        while ((read = gzip.Read(buffer)) > 0)
        {
            if (output.Length + read > MaximumReportBytes)
            {
                throw new InvalidDataException("Native accumulated Mortar reference exceeds its bounded size.");
            }
            output.Write(buffer, 0, read);
        }
        return output.ToArray();
    }

    private static Vector3 Vector(JsonElement row) =>
        new(row[0].GetSingle(), row[1].GetSingle(), row[2].GetSingle());

    private static Quaternion Rotation(JsonElement row) =>
        new(row[0].GetSingle(), row[1].GetSingle(), row[2].GetSingle(), row[3].GetSingle());

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }

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
        throw new InvalidOperationException("Mortar controller clock accepted malformed source time.");
    }
}
