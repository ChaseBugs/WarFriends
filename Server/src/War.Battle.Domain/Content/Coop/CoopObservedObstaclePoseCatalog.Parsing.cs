using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopObservedObstaclePoseCatalog
{
    private const int MaximumOverrides = 21;
    private const float MaximumChannelMagnitude = 4f;
    private static readonly string[] RootFields =
    [
        "version", "client", "unity", "captureRate", "sourceSha256", "replaySha256", "prefabSha256", "clipSha256",
        "priorReturnPhaseCount", "observationCount", "sampleCount", "skeletonSha256", "skeleton", "samples", "revision"
    ];
    private static readonly Dictionary<string, string> ClipDigests = new(StringComparer.Ordinal)
    {
        ["stand_up_crawl"] = "d95dcc35f5d52d841142ce6e6e8f89fb9b9c81c8234476750f2823b79d5cbb47",
        ["stand_up_begin"] = "0a4e37ccbb678a4f5fe6253d31ba2e7ea4b1108abadf390364d32054ef0d3d6c",
        ["rifle_shot_loop"] = "760fe9311ce35c5d57069a1c70547af1f6d29a869c1ad9361126db022a769776"
    };

    private static void ValidateHeader(JsonElement root, string enemyRevision)
    {
        RequireFields(root, RootFields);
        if (root.GetProperty("version").GetInt32() != 1 || root.GetProperty("client").GetString() != "1.4.0" ||
            root.GetProperty("unity").GetString() != "2018.3.0f2" ||
            root.GetProperty("captureRate").GetInt32() != MatchManifest.TickRate ||
            root.GetProperty("priorReturnPhaseCount").GetInt32() != PhaseCount ||
            root.GetProperty("observationCount").GetInt32() != ObservationCount ||
            root.GetProperty("sampleCount").GetInt32() != SampleCount ||
            root.GetProperty("prefabSha256").GetString() != enemyRevision ||
            root.GetProperty("sourceSha256").GetString() !=
                "f1f062324d04c7a3e816984ad6edc4fa26f44a568fb3351b3418b575b181ce47" ||
            root.GetProperty("replaySha256").GetString() !=
                "82e78ac8ab0b1aa6de152f524e844d8838c3ea9052355cbb8b2cfb6509b8258e" ||
            root.GetProperty("revision").GetString() != ContentRevision ||
            DigestWithoutRevision(root) != ContentRevision)
        {
            throw new InvalidDataException("Observed obstacle catalog provenance or revision is invalid.");
        }
        JsonElement clips = root.GetProperty("clipSha256");
        RequireFields(clips, ClipDigests.Keys.ToArray());
        foreach ((string name, string digest) in ClipDigests)
        {
            if (clips.GetProperty(name).GetString() != digest)
            {
                throw new InvalidDataException("Observed obstacle catalog clip identity changed.");
            }
        }
    }

    private static List<TransformIdentity> ReadSkeleton(JsonElement rows)
    {
        string digest = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(rows.GetRawText())));
        if (rows.GetArrayLength() != SkeletonCount ||
            digest != "b1d918aefb79b7402ca611d73685ac0e3ddd7585fcba71f00df3f0458a1487fd")
        {
            throw new InvalidDataException("Observed obstacle skeleton topology changed.");
        }
        var result = new List<TransformIdentity>();
        var paths = new HashSet<string>(StringComparer.Ordinal);
        foreach (JsonElement row in rows.EnumerateArray())
        {
            RequireFields(row, ["index", "path", "name"]);
            int index = row.GetProperty("index").GetInt32();
            string path = row.GetProperty("path").GetString() ?? "";
            string name = row.GetProperty("name").GetString() ?? "";
            if (index != result.Count + 1 || !path.StartsWith("root/", StringComparison.Ordinal) ||
                path.Length > 128 || name.Length is < 1 or > 128 || !paths.Add(path))
            {
                throw new InvalidDataException("Observed obstacle skeleton identity is invalid.");
            }
            result.Add(new TransformIdentity(index, path, name));
        }
        return result;
    }

    private static Sample[] ReadSamples(JsonElement rows)
    {
        if (rows.GetArrayLength() != SampleCount)
        {
            throw new InvalidDataException("Observed obstacle sample matrix is incomplete.");
        }
        var result = new Sample[SampleCount];
        for (int index = 0; index < result.Length; index++)
        {
            JsonElement row = rows[index];
            RequireFields(row, ["id", "priorReturnTicks", "observationTick", "clips", "overrides"]);
            int id = row.GetProperty("id").GetInt32();
            int phase = row.GetProperty("priorReturnTicks").GetInt32();
            int step = row.GetProperty("observationTick").GetInt32();
            if (id != index + 1 || phase != index / ObservationCount || step != index % ObservationCount)
            {
                throw new InvalidDataException("Observed obstacle sample identity or ordering is invalid.");
            }
            result[index] = new Sample(new SampleIdentity(id, phase, step), ReadClips(row.GetProperty("clips")),
                ReadOverrides(row.GetProperty("overrides")));
        }
        return result;
    }

    private static BattleInfantryAnimationFrame ReadClips(JsonElement rows)
    {
        if (rows.GetArrayLength() is < 1 or > 2)
        {
            throw new InvalidDataException("Observed obstacle frame needs one or two source clips.");
        }
        var frame = new BattleInfantryAnimationFrame();
        var names = new HashSet<string>(StringComparer.Ordinal);
        float totalWeight = 0f;
        foreach (JsonElement row in rows.EnumerateArray())
        {
            RequireFields(row, ["clipName", "timeSeconds", "weight", "wrap"]);
            string name = row.GetProperty("clipName").GetString() ?? "";
            float seconds = row.GetProperty("timeSeconds").GetSingle();
            float weight = row.GetProperty("weight").GetSingle();
            string wrap = row.GetProperty("wrap").GetString() ?? "";
            string expectedWrap = name == "stand_up_begin" ? "Clamp" : "ClampForever";
            if (!ClipDigests.ContainsKey(name) || !names.Add(name) || wrap != expectedWrap ||
                !float.IsFinite(seconds) || seconds is < 0f or > 1f ||
                !float.IsFinite(weight) || weight is < 0f or > 1f)
            {
                throw new InvalidDataException("Observed obstacle clip frame is invalid.");
            }
            frame.Clips.Add(new BattleInfantryAnimationClip
            {
                ClipName = name, TimeSeconds = seconds, Weight = weight,
                Wrap = name == "stand_up_begin" ? BattleInfantryAnimationWrap.Clamp :
                    BattleInfantryAnimationWrap.ClampForever
            });
            totalWeight += weight;
        }
        if (totalWeight <= 0f || totalWeight > 1.000001f)
        {
            throw new InvalidDataException("Observed obstacle frame weight is invalid.");
        }
        return frame;
    }

    private static List<PoseOverride> ReadOverrides(JsonElement rows)
    {
        if (rows.GetArrayLength() > MaximumOverrides)
        {
            throw new InvalidDataException("Observed obstacle frame has too many overrides.");
        }
        var result = new List<PoseOverride>();
        int previousIndex = 0;
        foreach (JsonElement row in rows.EnumerateArray())
        {
            RequireFields(row, ["index", "position", "scale"]);
            int index = row.GetProperty("index").GetInt32();
            Vector3 position = ReadVector(row.GetProperty("position"));
            Vector3 scale = ReadVector(row.GetProperty("scale"));
            if (index <= previousIndex || index > SkeletonCount || scale.X <= 0 || scale.Y <= 0 || scale.Z <= 0)
            {
                throw new InvalidDataException("Observed obstacle override identity or scale is invalid.");
            }
            result.Add(new PoseOverride(index, position, scale));
            previousIndex = index;
        }
        return result;
    }

    private static Vector3 ReadVector(JsonElement row)
    {
        if (row.GetArrayLength() != 3)
        {
            throw new InvalidDataException("Observed obstacle vectors need three channels.");
        }
        float[] values = row.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        if (values.Any(value => !float.IsFinite(value) || MathF.Abs(value) > MaximumChannelMagnitude))
        {
            throw new InvalidDataException("Observed obstacle vector channel is invalid.");
        }
        return new Vector3(values[0], values[1], values[2]);
    }

    private static void RequireFields(JsonElement row, string[] fields)
    {
        var remaining = new HashSet<string>(fields, StringComparer.Ordinal);
        foreach (JsonProperty property in row.EnumerateObject())
        {
            if (!remaining.Remove(property.Name))
            {
                throw new InvalidDataException("Observed obstacle data has an unknown or repeated field.");
            }
        }
        if (remaining.Count != 0)
        {
            throw new InvalidDataException("Observed obstacle data is missing a required field.");
        }
    }
}
