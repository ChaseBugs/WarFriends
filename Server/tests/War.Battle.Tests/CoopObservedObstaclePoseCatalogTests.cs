using System.IO.Compression;
using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares loaded immutable samples with the independent native source and reconstruction evidence.</summary>
internal static class CoopObservedObstaclePoseCatalogTests
{
    internal static void Run(string directory, BattleCombatContent content)
    {
        CoopObservedObstaclePoseCatalog catalog = content.ObservedObstaclePoses;
        using var sourceStream = new GZipStream(File.OpenRead(Path.Combine(directory,
            "coop-obstacle-fixed-step-reference.json.gz")), CompressionMode.Decompress);
        using JsonDocument source = JsonDocument.Parse(sourceStream);
        using var replayStream = new GZipStream(File.OpenRead(Path.Combine(directory,
            "coop-obstacle-fixed-step-replay-reference.json.gz")), CompressionMode.Decompress);
        using JsonDocument replay = JsonDocument.Parse(replayStream);
        JsonElement cases = replay.RootElement.GetProperty("cases");
        int count = 0;
        foreach (JsonElement frame in source.RootElement.GetProperty("samples").EnumerateArray())
        {
            Compare(catalog, frame, cases[count]);
            count++;
        }
        VerifyIsolation(catalog);
        VerifyRejection(directory, content.EnemyPoses.SourceSha256, catalog);
        Console.WriteLine($"PASS: {count} immutable observed obstacle catalog samples match native source evidence");
    }

    private static void Compare(CoopObservedObstaclePoseCatalog catalog, JsonElement source, JsonElement replay)
    {
        int phase = source.GetProperty("priorReturnTicks").GetInt32();
        int step = source.GetProperty("observationTick").GetInt32();
        CoopObstaclePreparationStart origin = CoopObstaclePreparationStart.FromReturn(1000, 1000UL - (ulong)phase,
            0.5000001f);
        int id = origin.SelectSampleId(1000UL + (ulong)step)!.Value;
        CoopObservedObstaclePoseCatalog.Sample sample = catalog.GetSample(id);
        var frame = sample.Animation(1000UL + (ulong)step);
        JsonElement states = source.GetProperty("rig").GetProperty("states");
        Require(sample.Identity.PriorReturnTicks == phase && sample.Identity.ObservationTick == step &&
            frame.Clips.Count == states.GetArrayLength(),
            "Catalog selection must preserve the native phase and states.");
        for (int index = 0; index < frame.Clips.Count; index++)
        {
            JsonElement expected = states[index];
            Require(frame.Clips[index].ClipName == expected.GetProperty("clipName").GetString() &&
                frame.Clips[index].TimeSeconds == expected.GetProperty("time").GetSingle() &&
                frame.Clips[index].Weight == expected.GetProperty("weight").GetSingle(),
                "Loaded clip samples must match the independent automatic source observation.");
        }
        Require(sample.Overrides.Count == replay.GetProperty("reconstruction").GetProperty("overrideCount").GetInt32(),
            "Loaded override count must match the independent native reconstruction.");
        foreach (CoopObservedObstaclePoseCatalog.PoseOverride pose in sample.Overrides)
        {
            JsonElement expected = source.GetProperty("rig").GetProperty("transforms")[pose.TransformIndex];
            Require(catalog.Skeleton[pose.TransformIndex - 1].Path == expected.GetProperty("path").GetString() &&
                pose.LocalPosition == Vector(expected.GetProperty("position")) &&
                pose.LocalScale == Vector(expected.GetProperty("scale")),
                "Observed channels must retain their source transform and exact float values.");
        }
    }

    private static void VerifyIsolation(CoopObservedObstaclePoseCatalog catalog)
    {
        var first = catalog.GetSample(1).Animation(10);
        float originalWeight = first.Clips[0].Weight;
        first.Clips[0].Weight = 0.125f;
        first.Clips.Clear();
        Require(catalog.GetSample(1).Animation(11).Clips[0].Weight == originalWeight,
            "Mutating a returned protobuf frame must not change catalog authority.");
        IList<CoopObservedObstaclePoseCatalog.TransformIdentity> skeleton = catalog.Skeleton;
        IList<CoopObservedObstaclePoseCatalog.PoseOverride> overrides = catalog.GetSample(2).Overrides;
        RequireReadOnly(skeleton.Clear);
        RequireReadOnly(overrides.Clear);
    }

    private static void RequireReadOnly(Action mutation)
    {
        try
        {
            mutation();
        }
        catch (NotSupportedException)
        {
            return;
        }
        throw new Exception("Loaded source pose collections must remain read-only.");
    }

    private static void VerifyRejection(string directory, string enemyRevision, CoopObservedObstaclePoseCatalog catalog)
    {
        string path = Path.Combine(directory, "coop-obstacle-fixed-step-pose-catalog.json.gz");
        Reject(() => CoopObservedObstaclePoseCatalog.Load(path, new string('0', enemyRevision.Length)));
        Reject(() => catalog.GetSample(0));
        Reject(() => catalog.GetSample(222));
        string temporary = Path.GetTempFileName();
        try
        {
            byte[] bytes = File.ReadAllBytes(path);
            bytes[bytes.Length / 2] ^= 1;
            File.WriteAllBytes(temporary, bytes);
            Reject(() => CoopObservedObstaclePoseCatalog.Load(temporary, enemyRevision));
            File.WriteAllBytes(temporary, new byte[33 * 1024]);
            Reject(() => CoopObservedObstaclePoseCatalog.Load(temporary, enemyRevision));
        }
        finally
        {
            File.Delete(temporary);
        }
    }

    private static Vector3 Vector(JsonElement values)
    {
        return new Vector3(values[0].GetSingle(), values[1].GetSingle(), values[2].GetSingle());
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new Exception("Invalid observed catalog input was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
