using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Projects observed grenade transforms without claiming a complete skeleton hierarchy.</summary>
internal sealed class GrenadeRigCatalog
{
    private const string VerifiedRevision = "842f1a0afe05f1d4065f3f5092aefe4f84baa8c8cd169dd7a136e2fbd7cb8365";
    private const int SampleRate = 30;
    private const int MovingTargetType = 16;
    private const int MaximumSampleSeconds = 86400;
    private readonly Dictionary<string, ObservedClip> _clips = new(StringComparer.Ordinal);
    private readonly Dictionary<string, (int Node, string Path)> _bindings = new(StringComparer.Ordinal);
    private readonly PlayerShotTargetCatalog _identities;

    private sealed record ObservedFrame(RigWorldTransform[] Roots, RifleMuzzlePose[] Targets);

    private sealed record ObservedClip(float Length, ObservedFrame[] Frames);

    private GrenadeRigCatalog(PlayerShotTargetCatalog identities)
    {
        _identities = identities;
    }

    internal static GrenadeRigCatalog Load(PlayerShotTargetCatalog identities)
    {
        using Stream stream = typeof(GrenadeRigCatalog).Assembly.GetManifestResourceStream(
            "War.BattleServer.GrenadeRig") ?? throw new InvalidDataException("Missing grenade rig evidence.");
        using var buffer = new MemoryStream();
        stream.CopyTo(buffer);
        byte[] bytes = buffer.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != VerifiedRevision)
        {
            throw new InvalidDataException("Unverified grenade rig evidence.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement source = document.RootElement;
        var result = new GrenadeRigCatalog(identities);
        int node = 1;
        foreach (JsonElement weapon in source.GetProperty("weapons").EnumerateArray())
        {
            result._bindings.Add(weapon.GetProperty("sourceId").GetString()!,
                (node++, weapon.GetProperty("path").GetString()!));
        }

        JsonElement targets = source.GetProperty("targets");
        for (int index = 0; index < identities.Gameplay.Count; index++)
        {
            PlayerShotTarget identity = identities.Gameplay[index];
            if (targets[index].GetProperty("path").GetString() != identity.Path ||
                targets[index].GetProperty("type").GetInt32() != identity.Type)
            {
                throw new InvalidDataException("Grenade rig target identity differs from combat authority.");
            }
        }

        foreach (JsonElement clip in source.GetProperty("clips").EnumerateArray())
        {
            ObservedFrame[] frames = clip.GetProperty("frames").EnumerateArray()
                .Select(frame => ReadFrame(frame, identities)).ToArray();
            result._clips.Add(clip.GetProperty("name").GetString()!,
                new ObservedClip(clip.GetProperty("length").GetSingle(), frames));
        }

        return result;
    }

    internal PlayerAimPoseDetails Place(string clip, double seconds, bool loop, PlayerCollisionModel collision)
    {
        if (!_clips.TryGetValue(clip, out ObservedClip? source) ||
            !double.IsFinite(seconds) || seconds < 0 || seconds > MaximumSampleSeconds)
        {
            throw new InvalidDataException("Invalid grenade rig sample request.");
        }

        if (loop)
        {
            seconds %= source.Length;
        }

        // Match the existing grenade collision/target sample clock; do not interpolate a different pose.
        int index = seconds >= source.Length ? source.Frames.Length - 1 :
            Math.Min(source.Frames.Length - 1, (int)Math.Floor(seconds * SampleRate));
        ObservedFrame frame = source.Frames[index];
        var targets = new Dictionary<int, RifleMuzzlePose>();
        RifleMuzzlePose? moving = null;
        for (int targetIndex = 0; targetIndex < frame.Targets.Length; targetIndex++)
        {
            PlayerShotTarget identity = _identities.Gameplay[targetIndex];
            RifleMuzzlePose target = frame.Targets[targetIndex].Place(collision.RootPosition, collision.RootRotation);
            targets[identity.TransformFileId] = target;
            if (identity.Type == MovingTargetType)
            {
                moving = target;
            }
        }

        var roots = new WeaponRootPoseSource(frame.Roots, _bindings,
            collision.RootPosition, collision.RootRotation);
        return new PlayerAimPoseDetails(moving, targets, roots);
    }

    private static ObservedFrame ReadFrame(JsonElement frame, PlayerShotTargetCatalog identities)
    {
        RigWorldTransform root = ReadTransform(frame.GetProperty("root"));
        RigWorldTransform[] roots = [root, .. frame.GetProperty("weapons").EnumerateArray().Select(ReadTransform)];
        RifleMuzzlePose[] targets = frame.GetProperty("targets").EnumerateArray().Select((value, index) =>
        {
            RigWorldTransform target = ReadTransform(value);
            return new RifleMuzzlePose(identities.Gameplay[index].Path, target.Position, target.Rotation,
                root.Position, root.Rotation);
        }).ToArray();
        return new ObservedFrame(roots, targets);
    }

    private static RigWorldTransform ReadTransform(JsonElement value)
    {
        float[] position = value.GetProperty("position").EnumerateArray().Select(item => item.GetSingle()).ToArray();
        float[] rotation = value.GetProperty("rotation").EnumerateArray().Select(item => item.GetSingle()).ToArray();
        float[] matrix = value.GetProperty("matrix").EnumerateArray().Select(item => item.GetSingle()).ToArray();
        // System.Numerics uses row vectors; transpose the captured Unity matrix rather than rebuilding scale.
        var world = new Matrix4x4(matrix[0], matrix[4], matrix[8], matrix[12],
            matrix[1], matrix[5], matrix[9], matrix[13], matrix[2], matrix[6], matrix[10], matrix[14],
            matrix[3], matrix[7], matrix[11], matrix[15]);
        return new RigWorldTransform(new Vector3(position[0], position[1], position[2]),
            Quaternion.Normalize(new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3])), world);
    }
}
