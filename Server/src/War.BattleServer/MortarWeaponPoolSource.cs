using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Binds shared weapon capacity to the admitted deployment catalog before actors can spawn.</summary>
public sealed class MortarWeaponPoolSource
{
    /// <summary>Identifies the reviewed source artifact shared by allocator and Worker startup.</summary>
    public const string VerifiedRevision = "ae80ede2b826ff009ea03f82e26ae63e751143816eea6deb7b1f40a1d3d2ea11";
    private const int MaximumArtifactBytes = 16384;
    private const int ParticipantCount = 2;

    /// <summary>Gets the complete source pool capacity after deployment binding has passed.</summary>
    public int Capacity { get; }

    private MortarWeaponPoolSource(int capacity)
    {
        Capacity = capacity;
    }

    /// <summary>Validates the immutable pool artifact against its admitted army and scene revisions.</summary>
    public static MortarWeaponPoolSource Load(string path, ArmyDeploymentCatalog army, string sceneRevision)
    {
        ArgumentNullException.ThrowIfNull(army);
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        if (stream.Length is < 100 or > MaximumArtifactBytes)
        {
            throw new InvalidDataException("Mortar pool source exceeds its bounded artifact size.");
        }
        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        if (stream.ReadByte() != -1 || Convert.ToHexStringLower(SHA256.HashData(bytes)) != VerifiedRevision)
        {
            throw new InvalidDataException("Mortar pool source revision changed.");
        }
        using JsonDocument document = JsonDocument.Parse(bytes, new JsonDocumentOptions { MaxDepth = 8 });
        JsonElement root = document.RootElement;
        JsonElement deployment = root.GetProperty("deployment");
        ArmyDeploymentFamily family = army.Families.Single(row => row.UnitId == "ID_UNIT-MORTAR");
        int capacity = root.GetProperty("capacity").GetInt32();
        // This proves the live/reserved bound only. Dead weapons remain held until corpse destruction;
        // the allocation controller must not infer an immediate return from a kill notification.
        if (root.GetProperty("schemaVersion").GetInt32() != 2 ||
            root.GetProperty("poolComponentFileId").GetInt32() != 49549 ||
            root.GetProperty("weaponComponentFileId").GetInt32() != 11496012 ||
            deployment.GetProperty("revision").GetString() != army.Revision ||
            deployment.GetProperty("sceneRevision").GetString() != sceneRevision ||
            deployment.GetProperty("behaviorFileId").GetInt32() != family.BehaviorFileId ||
            deployment.GetProperty("maxPerOwner").GetInt32() != family.MaxGeneratedCount ||
            family.MaxGeneratedCount != 2 || capacity != ParticipantCount * family.MaxGeneratedCount)
        {
            throw new InvalidDataException("Mortar pool capacity does not bind the admitted deployment limits.");
        }
        return new MortarWeaponPoolSource(capacity);
    }
}
