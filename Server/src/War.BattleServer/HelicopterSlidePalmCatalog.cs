using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Source palm position at the end of the unblended, clamped slide clip.</summary>
internal sealed class HelicopterSlidePalmCatalog
{
    private const string ReferenceDigest = "8a3c1f5d3022c0bd05165e71b443fcf056b9203ba4ead45c7498ae636b716760";
    private const string ClipName = "helicopter_jump_pose";
    private readonly Vector3 _endPalm;

    internal float ClipLength { get; }
    internal bool HasConstantCurves { get; }

    private HelicopterSlidePalmCatalog(Vector3 endPalm, float clipLength, bool hasConstantCurves)
    {
        _endPalm = endPalm;
        ClipLength = clipLength;
        HasConstantCurves = hasConstantCurves;
    }

    internal static HelicopterSlidePalmCatalog Load(string path, EnemyPoseCatalog poses)
    {
        ArgumentNullException.ThrowIfNull(poses);
        string reference = File.ReadAllText(path).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(reference))) != ReferenceDigest)
        {
            throw new InvalidDataException("The recovered slide palm reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(reference);
        JsonElement root = document.RootElement;
        JsonElement clip = root.GetProperty("clip");
        EnemyPoseClip sourceClip = poses.Clip(ClipName);
        if (root.GetProperty("version").GetInt32() != 1 || root.GetProperty("client").GetString() != "1.4.0" ||
            root.GetProperty("sourceInputSha256").GetString() != poses.SourceSha256 ||
            root.GetProperty("sourceLoadedSha256").GetString() != poses.SourceSha256 ||
            ReadVector(root.GetProperty("rootScale")) != Vector3.One ||
            clip.GetProperty("name").GetString() != ClipName ||
            clip.GetProperty("length").GetSingle() != sourceClip.Length ||
            clip.GetProperty("wrap").GetString() != "ClampForever" || sourceClip.Wrap != "ClampForever")
        {
            throw new InvalidDataException("The slide palm differs from the bound enemy pose source.");
        }
        return new HelicopterSlidePalmCatalog(ReadVector(root.GetProperty("endPalm")), sourceClip.Length,
            clip.GetProperty("constantCurves").GetBoolean());
    }

    /// <summary>
    /// Prepares a frame at original unit scale after the caller establishes a settled, unblended slide clip.
    /// </summary>
    internal HelicopterDescentFrame CreateSettledFrame(
        Vector3 rootPosition, Quaternion rootRotation, Vector3 helicopterRight)
    {
        return HelicopterPalmFramePlacement.Create(_endPalm, rootPosition, rootRotation, helicopterRight);
    }

    private static Vector3 ReadVector(JsonElement vector)
    {
        float[] values = vector.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        if (values.Length != 3)
        {
            throw new InvalidDataException("Invalid slide palm vector.");
        }
        Vector3 result = new(values[0], values[1], values[2]);
        if (!PlayerHitbox.Finite(result))
        {
            throw new InvalidDataException("Non-finite slide palm vector.");
        }
        return result;
    }
}
