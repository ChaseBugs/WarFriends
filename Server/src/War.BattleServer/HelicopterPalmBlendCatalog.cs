using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Exact captured frame selections and a host-owned slide weight, without inferred fade timing.</summary>
internal sealed record HelicopterPalmBlendSelection(int IdleFrame, int SlideFrame, float SlideWeight);

/// <summary>Blends the recovered palm's local bone chain before composing its root-relative position.</summary>
internal sealed class HelicopterPalmBlendCatalog
{
    private const string ReferenceDigest = "663c3260d0f833716b46e6fd42bc2507f1e97d43f2b2a6234a7f31f02b9e8f8f";
    private const int ExpectedNodeCount = 11;
    private readonly int[] _parents;
    private readonly RigLocalTransform[][] _idle;
    private readonly RigLocalTransform[][] _slide;

    internal int IdleFrameCount => _idle.Length;
    internal int SlideFrameCount => _slide.Length;

    private HelicopterPalmBlendCatalog(int[] parents, RigLocalTransform[][] idle, RigLocalTransform[][] slide)
    {
        _parents = parents;
        _idle = idle;
        _slide = slide;
    }

    internal static HelicopterPalmBlendCatalog Load(string path, EnemyPoseCatalog poses)
    {
        ArgumentNullException.ThrowIfNull(poses);
        string reference = File.ReadAllText(path).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(reference))) != ReferenceDigest)
        {
            throw new InvalidDataException("The recovered palm blend reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(reference);
        JsonElement root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 1 || root.GetProperty("client").GetString() != "1.4.0" ||
            root.GetProperty("sourceSha256").GetString() != poses.SourceSha256 ||
            root.GetProperty("sampleRate").GetInt32() != MatchManifest.TickRate)
        {
            throw new InvalidDataException("Palm blend sources differ from the enemy rig.");
        }
        ValidateResetClip(root.GetProperty("resetClip"), poses.Clip("T_pose"));
        int[] parents = root.GetProperty("nodes").EnumerateArray()
            .Select(node => node.GetProperty("parent").GetInt32()).ToArray();
        if (parents.Length != ExpectedNodeCount || parents.Where((parent, index) => parent != index - 1).Any())
        {
            throw new InvalidDataException("The source palm chain is incomplete or reordered.");
        }
        JsonElement[] clips = root.GetProperty("clips").EnumerateArray().ToArray();
        if (clips.Length != 2)
        {
            throw new InvalidDataException("The palm blend needs its two source clips.");
        }
        return new HelicopterPalmBlendCatalog(parents,
            ReadClip(clips[0], poses.Clip("idle_1"), parents),
            ReadClip(clips[1], poses.Clip("helicopter_jump_pose"), parents));
    }

    internal Vector3 Sample(HelicopterPalmBlendSelection selection)
    {
        ArgumentNullException.ThrowIfNull(selection);
        if (selection.IdleFrame < 0 || selection.IdleFrame >= _idle.Length ||
            selection.SlideFrame < 0 || selection.SlideFrame >= _slide.Length)
        {
            throw new InvalidDataException("Unknown captured palm frame.");
        }
        RigLocalTransform[] local = RigLocalPose.Blend(
            _idle[selection.IdleFrame], _slide[selection.SlideFrame], selection.SlideWeight);
        RigWorldTransform[] world = RigLocalPose.Compose(_parents, local);
        return world[^1].Position;
    }

    /// <summary>Places an explicitly selected sampled blend; it does not infer the current animation phase.</summary>
    internal HelicopterDescentFrame CreateSampledFrame(HelicopterPalmBlendSelection selection,
        Vector3 rootPosition, Quaternion rootRotation, Vector3 helicopterRight)
    {
        Vector3 palm = Sample(selection);
        return HelicopterPalmFramePlacement.Create(palm, rootPosition, rootRotation, helicopterRight);
    }

    private static void ValidateResetClip(JsonElement reset, EnemyPoseClip source)
    {
        if (reset.GetProperty("name").GetString() != source.Name ||
            reset.GetProperty("length").GetSingle() != source.Length ||
            reset.GetProperty("wrap").GetString() != source.Wrap ||
            reset.GetProperty("layer").GetInt32() != 0 ||
            reset.GetProperty("blendMode").GetString() != "Blend")
        {
            throw new InvalidDataException("Palm blend reset differs from its source animation state.");
        }
    }

    private static RigLocalTransform[][] ReadClip(JsonElement clip, EnemyPoseClip source, int[] parents)
    {
        JsonElement[] frames = clip.GetProperty("frames").EnumerateArray().ToArray();
        int expectedFrames = checked((int)MathF.Ceiling(source.Length * MatchManifest.TickRate) + 1);
        if (clip.GetProperty("name").GetString() != source.Name ||
            clip.GetProperty("length").GetSingle() != source.Length ||
            clip.GetProperty("wrap").GetString() != source.Wrap || frames.Length != expectedFrames)
        {
            throw new InvalidDataException("Palm frames differ from their bound animation clip.");
        }
        var result = new RigLocalTransform[frames.Length][];
        for (int frame = 0; frame < frames.Length; frame++)
        {
            result[frame] = frames[frame].EnumerateArray().Select(ReadTransform).ToArray();
            RigLocalPose.Compose(parents, result[frame]);
        }
        return result;
    }

    private static RigLocalTransform ReadTransform(JsonElement transform)
    {
        float[] rotation = transform.GetProperty("rotation").EnumerateArray()
            .Select(value => value.GetSingle()).ToArray();
        if (rotation.Length != 4)
        {
            throw new InvalidDataException("Invalid palm-chain rotation.");
        }
        return new RigLocalTransform(ReadVector(transform.GetProperty("position")),
            new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3]),
            ReadVector(transform.GetProperty("scale")));
    }

    private static Vector3 ReadVector(JsonElement vector)
    {
        float[] values = vector.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        if (values.Length != 3)
        {
            throw new InvalidDataException("Invalid palm-chain vector.");
        }
        return new Vector3(values[0], values[1], values[2]);
    }
}
