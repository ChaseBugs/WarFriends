using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Composes host world poses from the native snap-point observation at preparation.</summary>
internal sealed class MortarPreparedPoseSource
{
    private const string Revision = "89e19786067160cb85980a72c5551a48ca8515e50cf2fcc2fa72dc850c871d99";
    private const int MaximumArtifactBytes = 16384;
    private const float SourceBuildSeconds = 2f;
    private const ulong SourceHandReturnTicks = 34;
    private const ulong MinimumPreparationTicks = 2 * MatchManifest.TickRate;
    private const ulong MaximumPreparationTicks = MinimumPreparationTicks + 1;
    private const float Tolerance = 0.00001f;
    private const ulong MaximumSimulationTick = 10_000_000;
    private const float MaximumAnimationSeconds = 60f;
    private readonly IReadOnlyDictionary<ulong, LocalPose> _poses;

    private MortarPreparedPoseSource(Dictionary<ulong, LocalPose> poses)
    {
        _poses = poses;
    }

    internal static MortarPreparedPoseSource Load(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        if (stream.Length <= 0 || stream.Length > MaximumArtifactBytes)
        {
            throw new InvalidDataException("Mortar prepared-pose source exceeds its bounded artifact size.");
        }
        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        if (stream.ReadByte() != -1 || Convert.ToHexStringLower(SHA256.HashData(bytes)) != Revision)
        {
            throw new InvalidDataException("Mortar prepared-pose source changed without native review.");
        }
        using JsonDocument document = JsonDocument.Parse(bytes, new JsonDocumentOptions { MaxDepth = 8 });
        JsonElement root = document.RootElement;
        JsonElement cases = root.GetProperty("observations");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("buildSeconds").GetSingle() != SourceBuildSeconds || cases.GetArrayLength() != 8)
        {
            throw new InvalidDataException("Mortar prepared-pose source lost its complete native cases.");
        }
        var poses = new Dictionary<ulong, LocalPose>();
        foreach (JsonElement row in cases.EnumerateArray())
        {
            ulong buildTick = row.GetProperty("buildTick").GetUInt64();
            ulong preparationTick = row.GetProperty("preparedTick").GetUInt64();
            if (preparationTick < buildTick || preparationTick - buildTick is
                < MinimumPreparationTicks or > MaximumPreparationTicks ||
                row.GetProperty("handReturnTick").GetUInt64() != preparationTick + SourceHandReturnTicks)
            {
                throw new InvalidDataException("Mortar preparation source lost an observed frame phase.");
            }
            var pose = new LocalPose(Vector(row.GetProperty("localPosition")),
                Rotation(row.GetProperty("localRotation")), Vector(row.GetProperty("scale")));
            ulong elapsed = preparationTick - buildTick;
            if (poses.TryGetValue(elapsed, out var previous) &&
                (Vector3.Distance(previous.Position, pose.Position) > Tolerance ||
                 Vector3.Distance(previous.Scale, pose.Scale) > Tolerance ||
                 MathF.Abs(Quaternion.Dot(previous.Rotation, pose.Rotation)) < 1f - Tolerance))
            {
                throw new InvalidDataException("Mortar preparation pose differs within one native frame phase.");
            }
            poses.TryAdd(elapsed, pose);
        }
        if (poses.Count != 2)
        {
            throw new InvalidDataException("Mortar preparation source lost a native clock phase.");
        }
        return new MortarPreparedPoseSource(poses);
    }

    internal MortarDetachedWeaponPose Capture(ulong preparedTick,
        (ulong EnteredTick, Vector3 Position, Vector3 Facing) root, float buildSeconds, float hideSeconds)
    {
        if (preparedTick > MaximumSimulationTick - SourceHandReturnTicks || preparedTick < root.EnteredTick ||
            preparedTick - root.EnteredTick is < MinimumPreparationTicks or > MaximumPreparationTicks ||
            !PlayerHitbox.Finite(root.Position) ||
            !PlayerHitbox.Finite(root.Facing) || MathF.Abs(root.Facing.Y) > Tolerance ||
            MathF.Abs(root.Facing.LengthSquared() - 1f) > Tolerance || buildSeconds != SourceBuildSeconds ||
            !float.IsFinite(hideSeconds) || hideSeconds <= 0f || hideSeconds > MaximumAnimationSeconds ||
            (ulong)MathF.Ceiling(hideSeconds * MatchManifest.TickRate) != SourceHandReturnTicks)
        {
            throw new InvalidDataException("Mortar preparation no longer matches its source capture domain.");
        }
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY,
            MathF.Atan2(root.Facing.X, root.Facing.Z));
        LocalPose pose = _poses[preparedTick - root.EnteredTick];
        return new MortarDetachedWeaponPose(preparedTick, checked(preparedTick + SourceHandReturnTicks),
            root.Position + Vector3.Transform(pose.Position, rotation),
            Quaternion.Normalize(rotation * pose.Rotation), pose.Scale);
    }

    private static Vector3 Vector(JsonElement row)
    {
        if (row.GetArrayLength() != 3)
        {
            throw new InvalidDataException("Mortar source vector lost its three components.");
        }
        var value = new Vector3(row[0].GetSingle(), row[1].GetSingle(), row[2].GetSingle());
        if (!PlayerHitbox.Finite(value))
        {
            throw new InvalidDataException("Mortar source vector is not finite.");
        }
        return value;
    }

    private static Quaternion Rotation(JsonElement row)
    {
        if (row.GetArrayLength() != 4)
        {
            throw new InvalidDataException("Mortar source rotation lost its four components.");
        }
        var value = new Quaternion(row[0].GetSingle(), row[1].GetSingle(), row[2].GetSingle(), row[3].GetSingle());
        if (!float.IsFinite(value.LengthSquared()) || MathF.Abs(value.LengthSquared() - 1f) > Tolerance)
        {
            throw new InvalidDataException("Mortar source rotation is not a finite unit quaternion.");
        }
        return value;
    }

    private sealed record LocalPose(Vector3 Position, Quaternion Rotation, Vector3 Scale);
}
