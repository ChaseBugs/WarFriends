using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal sealed record CoopMuzzlePose(Vector3 Position, Quaternion Rotation);

/// <summary>
/// Unity-sampled muzzle positions on the recovered enemy rig. These samples
/// describe geometry only; a shot still needs an authoritative animation clock.
/// </summary>
internal sealed class CoopEnemyMuzzleCatalog
{
    private const string VerifiedRevision =
        "98d9a406b9ec89a05b3049a5abe85bf4a3f88e136ac47be2f5b2e89913fd2c57";
    private const string AttachmentSuffix = "/GunPivot/gunSnapPoint";
    private const string WeaponPath = "Assets/GameObject/AssaultRifleEnemy.prefab";
    private const string MuzzleSuffix =
        "/AssaultRifleEnemy/HK416/MachinegunMuzzleFlash";

    private readonly EnemyPoseCatalog enemyPoses;
    private readonly IReadOnlyDictionary<string, CoopMuzzlePose[]> clips;

    private CoopEnemyMuzzleCatalog(EnemyPoseCatalog enemyPoses,
        Dictionary<string, CoopMuzzlePose[]> clips)
    {
        this.enemyPoses = enemyPoses;
        this.clips = clips;
    }

    internal static CoopEnemyMuzzleCatalog Load(string path,
        EnemyPoseCatalog enemyPoses)
    {
        byte[] bytes = File.ReadAllBytes(path);
        string revision = Convert.ToHexStringLower(SHA256.HashData(bytes));
        if (bytes.Length is < 500_000 or > 2_000_000 ||
            revision != VerifiedRevision)
            throw new InvalidDataException("Co-op muzzle samples changed.");

        using JsonDocument document = JsonDocument.Parse(bytes,
            new JsonDocumentOptions { MaxDepth = 12 });
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "client", "source", "sha256",
            "sampleRate", "attachmentPath", "weapon", "weaponSha256",
            "muzzlePath", "clips");
        string? attachment = root.GetProperty("attachmentPath").GetString();
        string? muzzle = root.GetProperty("muzzlePath").GetString();
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("client").GetString() != "1.4.0" ||
            root.GetProperty("source").GetString() !=
                "Assets/GameObject/enemy.prefab" ||
            root.GetProperty("sha256").GetString() != enemyPoses.SourceSha256 ||
            root.GetProperty("sampleRate").GetInt32() != 30 ||
            attachment is null || !attachment.EndsWith(AttachmentSuffix,
                StringComparison.Ordinal) ||
            root.GetProperty("weapon").GetString() != WeaponPath ||
            root.GetProperty("weaponSha256").GetString() !=
                "a55f77d5fc32e948951805b01e13c9193cf852171ec842a2caa6ad3338239de2" ||
            muzzle != attachment + MuzzleSuffix)
            throw new InvalidDataException("Co-op muzzle source binding changed.");

        JsonElement sourceClips = root.GetProperty("clips");
        if (sourceClips.ValueKind != JsonValueKind.Array ||
            sourceClips.GetArrayLength() != enemyPoses.Names.Count)
            throw new InvalidDataException("Co-op muzzle clip set is incomplete.");

        var accepted = new Dictionary<string, CoopMuzzlePose[]>(
            StringComparer.Ordinal);
        for (int clipIndex = 0; clipIndex < enemyPoses.Names.Count; clipIndex++)
        {
            string name = enemyPoses.Names[clipIndex];
            EnemyPoseClip poseClip = enemyPoses.Clip(name);
            JsonElement sourceClip = sourceClips[clipIndex];
            RequireFields(sourceClip, "name", "source", "guid", "fileId",
                "sha256", "length", "wrap", "frames");
            JsonElement frames = sourceClip.GetProperty("frames");
            if (sourceClip.GetProperty("name").GetString() != name ||
                sourceClip.GetProperty("source").GetString() !=
                    $"Assets/AnimationClip/{name}.anim" ||
                sourceClip.GetProperty("fileId").GetInt64() != 7400000 ||
                sourceClip.GetProperty("length").GetSingle() != poseClip.Length ||
                sourceClip.GetProperty("wrap").GetString() != poseClip.Wrap ||
                frames.ValueKind != JsonValueKind.Array ||
                frames.GetArrayLength() != poseClip.Frames.Count)
                throw new InvalidDataException("Co-op muzzle clip timeline changed.");

            var samples = new CoopMuzzlePose[frames.GetArrayLength()];
            for (int frameIndex = 0; frameIndex < samples.Length; frameIndex++)
            {
                JsonElement frame = frames[frameIndex];
                RequireFields(frame, "seconds", "position", "rotation");
                if (frame.GetProperty("seconds").GetSingle() !=
                    poseClip.Frames[frameIndex].Seconds)
                    throw new InvalidDataException("Co-op muzzle frame clock changed.");
                Vector3 position = ReadPosition(frame.GetProperty("position"));
                Quaternion rotation = ReadRotation(frame.GetProperty("rotation"));
                samples[frameIndex] = new CoopMuzzlePose(position, rotation);
            }
            accepted.Add(name, samples);
        }
        return new CoopEnemyMuzzleCatalog(enemyPoses, accepted);
    }

    internal CoopMuzzlePose Place(string clipName, Vector3 rootPosition,
        Quaternion rootRotation, float seconds)
    {
        if (!PlayerHitbox.Finite(rootPosition) ||
            !ValidRotation(rootRotation) ||
            !float.IsFinite(seconds) || seconds < 0)
            throw new InvalidDataException("Invalid co-op muzzle placement.");

        EnemyPoseClip clip = enemyPoses.Clip(clipName);
        float sampleTime = clip.Wrap == "Loop"
            ? seconds % clip.Length
            : Math.Min(seconds, clip.Length);
        int index = Math.Min((int)MathF.Floor(sampleTime * 30),
            clip.Frames.Count - 1);
        CoopMuzzlePose sample = clips[clipName][index];
        Quaternion root = Quaternion.Normalize(rootRotation);
        return new CoopMuzzlePose(
            rootPosition + Vector3.Transform(sample.Position, root),
            Quaternion.Normalize(root * sample.Rotation));
    }

    private static Vector3 ReadPosition(JsonElement values)
    {
        if (values.ValueKind != JsonValueKind.Array || values.GetArrayLength() != 3)
            throw new InvalidDataException("Invalid co-op muzzle position.");
        var result = new Vector3(values[0].GetSingle(),
            values[1].GetSingle(), values[2].GetSingle());
        if (!PlayerHitbox.Finite(result) ||
            Math.Abs(result.X) > 5 || Math.Abs(result.Y) > 5 ||
            Math.Abs(result.Z) > 5)
            throw new InvalidDataException("Co-op muzzle position exceeds rig bounds.");
        return result;
    }

    private static Quaternion ReadRotation(JsonElement values)
    {
        if (values.ValueKind != JsonValueKind.Array || values.GetArrayLength() != 4)
            throw new InvalidDataException("Invalid co-op muzzle rotation.");
        var result = new Quaternion(values[0].GetSingle(),
            values[1].GetSingle(), values[2].GetSingle(),
            values[3].GetSingle());
        if (!ValidRotation(result))
            throw new InvalidDataException("Co-op muzzle rotation is not a unit quaternion.");
        return Quaternion.Normalize(result);
    }

    private static bool ValidRotation(Quaternion value) =>
        float.IsFinite(value.X) && float.IsFinite(value.Y) &&
        float.IsFinite(value.Z) && float.IsFinite(value.W) &&
        Math.Abs(value.LengthSquared() - 1) < 0.0002f;

    private static void RequireFields(JsonElement value, params string[] names)
    {
        if (value.ValueKind != JsonValueKind.Object ||
            value.EnumerateObject().Count() != names.Length ||
            names.Any(name => !value.TryGetProperty(name, out _)))
            throw new InvalidDataException("Co-op muzzle artifact has unexpected fields.");
    }
}
