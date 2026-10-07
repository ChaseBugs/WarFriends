using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopNavMeshSource(
    int Stage, string Scene, string SceneSha256, string NavMeshGuid,
    string SourceAsset, string PackagedAsset, string Format,
    int Bytes, string Sha256);

/// <summary>
/// Checks the recovered Unity navigation inputs. It does not decode Unity's
/// baked tiles or claim that the Worker can follow their paths yet.
/// </summary>
public sealed class CoopNavMeshSourceCatalog
{
    public IReadOnlyList<CoopNavMeshSource> Maps { get; }

    private CoopNavMeshSourceCatalog(CoopNavMeshSource[] maps)
    {
        Maps = new ReadOnlyCollection<CoopNavMeshSource>(maps);
    }

    public CoopNavMeshSource MapForMission(MissionCatalog missions, int missionIndex)
    {
        MissionMapRule missionMap = missions.MapForMission(missionIndex);
        CoopNavMeshSource map = Maps[missionMap.Stage - 1];
        if (map.Scene != missionMap.Scene || map.SceneSha256 != missionMap.SceneSha256)
            throw new InvalidDataException("Co-op NavMesh scene differs from the mission.");
        return map;
    }

    public static CoopNavMeshSourceCatalog Load(string manifestPath, MissionCatalog missions)
    {
        ArgumentNullException.ThrowIfNull(missions);
        using JsonDocument document = JsonDocument.Parse(File.ReadAllText(manifestPath));
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "missionSourceSha256", "maps");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("missionSourceSha256").GetString() != missions.SourceSha256)
            throw new InvalidDataException("Co-op NavMesh artifact differs from the mission catalog.");

        JsonElement entries = root.GetProperty("maps");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 5)
            throw new InvalidDataException("Co-op NavMesh artifact needs five maps.");

        string assetDirectory = Path.Combine(
            Path.GetDirectoryName(manifestPath)!, "coop-navmesh");
        var maps = new CoopNavMeshSource[5];
        var guids = new HashSet<string>(StringComparer.Ordinal);
        var assetNames = new HashSet<string>(StringComparer.Ordinal);
        for (int index = 0; index < maps.Length; index++)
        {
            JsonElement entry = entries[index];
            RequireFields(entry, "stage", "scene", "sceneSha256", "navMeshGuid",
                "sourceAsset", "packagedAsset", "format", "bytes", "sha256");
            MissionMapRule expected = missions.Maps[index];
            string scene = RequiredString(entry, "scene");
            string sceneHash = RequiredHash(entry, "sceneSha256");
            string guid = RequiredHex(entry, "navMeshGuid", 32);
            string sourceAsset = RequiredString(entry, "sourceAsset");
            string packagedAsset = RequiredString(entry, "packagedAsset");
            string format = RequiredString(entry, "format");
            int size = entry.GetProperty("bytes").GetInt32();
            string hash = RequiredHash(entry, "sha256");
            if (entry.GetProperty("stage").GetInt32() != expected.Stage ||
                scene != expected.Scene || sceneHash != expected.SceneSha256 ||
                !guids.Add(guid) || !assetNames.Add(packagedAsset) ||
                sourceAsset != "Assets/NavMeshData/" + packagedAsset ||
                Path.GetFileName(packagedAsset) != packagedAsset ||
                !packagedAsset.EndsWith(".asset", StringComparison.Ordinal) ||
                format is not ("unity-binary-2018" or "unity-yaml-navmesh-tiles") ||
                size is < 10000 or > 1000000)
                throw new InvalidDataException("Co-op NavMesh map identity is invalid.");

            string assetPath = Path.Combine(assetDirectory, packagedAsset);
            byte[] bytes = File.ReadAllBytes(assetPath);
            string actualHash = Convert.ToHexStringLower(SHA256.HashData(bytes));
            if (bytes.Length != size || actualHash != hash ||
                (format == "unity-yaml-navmesh-tiles" &&
                    !bytes.AsSpan().StartsWith("%YAML 1.1"u8)) ||
                (format == "unity-binary-2018" &&
                    bytes.AsSpan(0, Math.Min(bytes.Length, 80)).IndexOf("2018.3.0f2"u8) < 0))
                throw new InvalidDataException("Co-op NavMesh bytes differ from the manifest.");

            maps[index] = new CoopNavMeshSource(expected.Stage, scene, sceneHash,
                guid, sourceAsset, packagedAsset, format, size, hash);
        }
        return new CoopNavMeshSourceCatalog(maps);
    }

    private static void RequireFields(JsonElement entry, params string[] names)
    {
        if (entry.ValueKind != JsonValueKind.Object ||
            entry.EnumerateObject().Count() != names.Length ||
            names.Any(name => !entry.TryGetProperty(name, out _)))
            throw new InvalidDataException("Co-op NavMesh artifact has unexpected fields.");
    }

    private static string RequiredString(JsonElement entry, string name)
    {
        string? value = entry.GetProperty(name).GetString();
        if (string.IsNullOrEmpty(value))
            throw new InvalidDataException($"Co-op NavMesh {name} is empty.");
        return value;
    }

    private static string RequiredHash(JsonElement entry, string name) =>
        RequiredHex(entry, name, 64);

    private static string RequiredHex(JsonElement entry, string name, int length)
    {
        string value = RequiredString(entry, name);
        if (value.Length != length || value.Any(character =>
                character is not (>= '0' and <= '9' or >= 'a' and <= 'f')))
            throw new InvalidDataException($"Co-op NavMesh {name} is not lowercase hex.");
        return value;
    }
}
