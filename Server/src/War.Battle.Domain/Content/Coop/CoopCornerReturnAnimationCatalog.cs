using System.Security.Cryptography;
using System.Text.Json;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Replays measured source-method return blends without granting collision or shot authority.</summary>
internal sealed class CoopCornerReturnAnimationCatalog
{
    private const string VerifiedRevision = "94121738e408a91ccfd8930f8e3ea59e395517c4b3e983faa98a646b5be8d294";
    private const string SourceRevision = "52dc91af539033bbe9c7043e2a8e7649fcc2c8bc7d06fd0546f8ace78c5f9149";
    private const string ControllerRevision = "f6971fe49c7717a96aedddc4ae41605b1f17da350f49828b1d2329462b9efe8a";
    private const int MaximumArtifactBytes = 64 * 1024;
    private const int LastMeasuredOffset = 31;
    private const int SourceReturnEpoch = 59;
    private const ulong MaximumDiagnosticOffset = 1_000_000;
    private static readonly string[] CoverClips = ["player_right_coverBack3", "player_left_coverBack3"];
    private readonly Dictionary<string, BattleInfantryAnimationFrame[]> _frames;

    private CoopCornerReturnAnimationCatalog(Dictionary<string, BattleInfantryAnimationFrame[]> frames)
    {
        _frames = frames;
    }

    internal static CoopCornerReturnAnimationCatalog Load(string path, string enemyRevision)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (bytes.Length > MaximumArtifactBytes || Convert.ToHexStringLower(SHA256.HashData(bytes)) != VerifiedRevision)
        {
            throw new InvalidDataException("The source-method corner return observation changed.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes, new JsonDocumentOptions { MaxDepth = 12 });
        JsonElement root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 1 || root.GetProperty("client").GetString() != "1.4.0" ||
            root.GetProperty("unity").GetString() != "2018.3.0f2" ||
            root.GetProperty("captureRate").GetInt32() != MatchManifest.TickRate ||
            root.GetProperty("sourceSha256").GetString() != SourceRevision ||
            root.GetProperty("controllerSha256").GetString() != ControllerRevision ||
            root.GetProperty("enemySha256").GetString() != enemyRevision ||
            root.GetProperty("sourceReturnEpoch").GetInt32() != SourceReturnEpoch)
        {
            throw new InvalidDataException("Corner return provenance does not match the reviewed source.");
        }

        return new CoopCornerReturnAnimationCatalog(ReadScenarios(root.GetProperty("scenarios")));
    }

    internal BattleInfantryAnimationFrame Sample(string coverClip, ulong offset, ulong sampleTick)
    {
        if (!_frames.TryGetValue(coverClip, out BattleInfantryAnimationFrame[]? frames) ||
            offset > MaximumDiagnosticOffset)
        {
            throw new InvalidDataException("Unsupported source return clip or diagnostic clock.");
        }

        if (offset == 0)
        {
            // Source Update calls Play(coverClip), starting this confirmed post-command sample at time zero.
            var start = new BattleInfantryAnimationFrame { SampleTick = sampleTick };
            start.Clips.Add(new BattleInfantryAnimationClip
            {
                ClipName = coverClip,
                Weight = 1f,
                Wrap = BattleInfantryAnimationWrap.Clamp
            });
            return start;
        }

        int index = (int)Math.Min(offset, LastMeasuredOffset) - 1;
        BattleInfantryAnimationFrame result = frames[index].Clone();
        result.SampleTick = sampleTick;
        if (offset > LastMeasuredOffset)
        {
            // The final captured state is pure looping idle; preserve its measured phase on continuation.
            result.Clips[0].TimeSeconds += (offset - LastMeasuredOffset) / (float)MatchManifest.TickRate;
        }
        return result;
    }

    private static Dictionary<string, BattleInfantryAnimationFrame[]> ReadScenarios(JsonElement scenarios)
    {
        if (scenarios.GetArrayLength() != CoverClips.Length)
        {
            throw new InvalidDataException("Both source corner return sides are required.");
        }

        var result = new Dictionary<string, BattleInfantryAnimationFrame[]>(StringComparer.Ordinal);
        for (int side = 0; side < CoverClips.Length; side++)
        {
            string coverClip = CoverClips[side];
            JsonElement scenario = scenarios[side];
            JsonElement samples = scenario.GetProperty("frames");
            if (scenario.GetProperty("coverClip").GetString() != coverClip ||
                samples.GetArrayLength() != LastMeasuredOffset)
            {
                throw new InvalidDataException("Source return frame coverage changed.");
            }

            var frames = new BattleInfantryAnimationFrame[LastMeasuredOffset];
            for (int index = 0; index < frames.Length; index++)
            {
                JsonElement sample = samples[index];
                if (sample.GetProperty("offset").GetInt32() != index + 1)
                {
                    throw new InvalidDataException("Source return frames must be contiguous.");
                }
                frames[index] = ReadFrame(sample.GetProperty("clips"), coverClip);
            }
            ValidateLastFrame(frames[^1]);
            result.Add(coverClip, frames);
        }
        return result;
    }

    private static BattleInfantryAnimationFrame ReadFrame(JsonElement clips, string coverClip)
    {
        if (clips.GetArrayLength() is < 1 or > 2)
        {
            throw new InvalidDataException("A source return frame requires one or two base clips.");
        }

        var frame = new BattleInfantryAnimationFrame();
        var names = new HashSet<string>(StringComparer.Ordinal);
        double weight = 0d;
        foreach (JsonElement row in clips.EnumerateArray())
        {
            string name = row.GetProperty("clipName").GetString() ?? "";
            float seconds = row.GetProperty("timeSeconds").GetSingle();
            float blendWeight = row.GetProperty("weight").GetSingle();
            string expectedWrap = name == coverClip ? "Clamp" : "Loop";
            if ((name != coverClip && name != "idle") || !names.Add(name) ||
                row.GetProperty("wrap").GetString() != expectedWrap || !float.IsFinite(seconds) || seconds < 0f ||
                !float.IsFinite(blendWeight) || blendWeight is < 0f or > 1f)
            {
                throw new InvalidDataException("Unsupported source return sample.");
            }
            frame.Clips.Add(new BattleInfantryAnimationClip
            {
                ClipName = name,
                TimeSeconds = seconds,
                Weight = blendWeight,
                Wrap = name == coverClip ? BattleInfantryAnimationWrap.Clamp : BattleInfantryAnimationWrap.Loop
            });
            weight += blendWeight;
        }
        if (Math.Abs(weight - 1d) > 0.0001d)
        {
            throw new InvalidDataException("Source return blend weights must conserve one frame.");
        }
        return frame;
    }

    private static void ValidateLastFrame(BattleInfantryAnimationFrame frame)
    {
        if (frame.Clips.Count != 1 || frame.Clips[0].ClipName != "idle" || frame.Clips[0].Weight != 1f ||
            frame.Clips[0].Wrap != BattleInfantryAnimationWrap.Loop)
        {
            throw new InvalidDataException("Source return continuation requires a final pure idle sample.");
        }
    }
}
