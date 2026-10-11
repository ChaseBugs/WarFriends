using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>A source EnemyPoint eligible for a card-spawned Rusher soldier.</summary>
public sealed record CardUnitInitialPoint(int Order, int ComponentFileId,
    string ComponentType, int Fraction, Vector3 Position, Quaternion Rotation,
    Vector3? CornerDirection, bool? CornerRightSide);

/// <summary>
/// Card Paratroopers and SWAT choose from MapDefinition.enemyPointsCollection.
/// These points are distinct from their ordinary shield-linked Rusher slots.
/// </summary>
public sealed class CardUnitInitialPointCatalog
{
    public const string VerifiedRevision =
        "f2b047343039b88371b7379dfa0d8721fc316956c486accec4493bda29fc588f";
    private readonly IReadOnlyDictionary<string, IReadOnlyList<CardUnitInitialPoint>> maps;

    private CardUnitInitialPointCatalog(
        IReadOnlyDictionary<string, IReadOnlyList<CardUnitInitialPoint>> maps)
    {
        this.maps = maps;
    }

    public static CardUnitInitialPointCatalog Load(string path,
        string expectedRevision, IReadOnlyList<RecoveredBattleMap> sourceMaps)
    {
        ArgumentNullException.ThrowIfNull(sourceMaps);
        byte[] bytes = File.ReadAllBytes(path);
        if (bytes.Length is < 100 or > 65_536 ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) != expectedRevision ||
            sourceMaps.Count != 5)
            throw new InvalidDataException("Card enemy point revision or map set changed.");

        using JsonDocument document = JsonDocument.Parse(bytes,
            new JsonDocumentOptions { MaxDepth = 8 });
        JsonElement root = document.RootElement;
        Exact(root, "version", "maps");
        if (root.GetProperty("version").GetInt32() != 2 ||
            root.GetProperty("maps").GetArrayLength() != sourceMaps.Count)
            throw new InvalidDataException("Card enemy point artifact is incomplete.");

        var accepted = new Dictionary<string,
            IReadOnlyList<CardUnitInitialPoint>>(StringComparer.Ordinal);
        int mapIndex = 0;
        foreach (JsonElement mapRow in root.GetProperty("maps").EnumerateArray())
        {
            Exact(mapRow, "source", "sha256", "mapDefinitionFileId",
                "collectionComponentFileId", "points");
            RecoveredBattleMap map = sourceMaps[mapIndex++];
            if (mapRow.GetProperty("source").GetString() != map.Source ||
                mapRow.GetProperty("sha256").GetString() != map.SourceHash ||
                mapRow.GetProperty("mapDefinitionFileId").GetInt32() <= 0 ||
                mapRow.GetProperty("collectionComponentFileId").GetInt32() <= 0)
                throw new InvalidDataException("Card enemy points do not bind the multiplayer scene.");

            var points = new List<CardUnitInitialPoint>();
            var componentIds = new HashSet<int>();
            int previousOrder = -1;
            foreach (JsonElement point in mapRow.GetProperty("points").EnumerateArray())
            {
                string type = point.GetProperty("componentType").GetString() ?? "";
                if (type == "EnemyPointCorner")
                    Exact(point, "order", "componentFileId", "componentType",
                        "gameObjectFileId", "transformFileId", "fraction",
                        "worldPosition", "worldRotation", "cornerDirection",
                        "cornerRightSide");
                else
                    Exact(point, "order", "componentFileId", "componentType",
                        "gameObjectFileId", "transformFileId", "fraction",
                        "worldPosition", "worldRotation");
                int order = point.GetProperty("order").GetInt32();
                int componentId = point.GetProperty("componentFileId").GetInt32();
                int fraction = point.GetProperty("fraction").GetInt32();
                Vector3 position = Position(point.GetProperty("worldPosition"));
                Quaternion rotation = Rotation(point.GetProperty("worldRotation"));
                Vector3? cornerDirection = null;
                bool? cornerRightSide = null;
                if (type == "EnemyPointCorner")
                {
                    cornerDirection = Position(point.GetProperty("cornerDirection"));
                    cornerRightSide = point.GetProperty("cornerRightSide").GetBoolean();
                    if (Math.Abs(cornerDirection.Value.LengthSquared() - 1f) > .001f ||
                        Math.Abs(cornerDirection.Value.Y) > .001f)
                        throw new InvalidDataException("Card Corner direction must be planar and normalized.");
                }
                if (order <= previousOrder || order > 1024 || componentId <= 0 ||
                    !componentIds.Add(componentId) ||
                    point.GetProperty("gameObjectFileId").GetInt32() <= 0 ||
                    point.GetProperty("transformFileId").GetInt32() <= 0 ||
                    fraction is not (1 or 2) || type is not
                        ("EnemyPointCorner" or "EnemyPointHiding" or "EnemyPointSwat"))
                    throw new InvalidDataException("Invalid card enemy point identity or order.");
                points.Add(new CardUnitInitialPoint(order, componentId,
                    type, fraction, position, rotation,
                    cornerDirection, cornerRightSide));
                previousOrder = order;
            }

            int[] expected = map.Source switch
            {
                "Assets/Scenes/Aztec_Multiplayer.unity" => [1, 1, 2, 2],
                "Assets/Scenes/City_Multiplayer.unity" => [1, 2, 2, 2],
                "Assets/Scenes/Desert_Multiplayer.unity" => [2, 2, 2, 2],
                "Assets/Scenes/Park_Multiplayer.unity" => [2, 2, 2, 2],
                "Assets/Scenes/Snow_Multiplayer.unity" => [0, 0, 2, 2],
                _ => throw new InvalidDataException("Unknown multiplayer card map.")
            };
            int[] actual =
            [
                points.Count(row => row.ComponentType == "EnemyPointCorner" && row.Fraction == 1),
                points.Count(row => row.ComponentType == "EnemyPointCorner" && row.Fraction == 2),
                points.Count(row => row.ComponentType == "EnemyPointSwat" && row.Fraction == 1),
                points.Count(row => row.ComponentType == "EnemyPointSwat" && row.Fraction == 2)
            ];
            if (!actual.SequenceEqual(expected) ||
                points.Any(row => row.ComponentType == "EnemyPointHiding") ||
                !accepted.TryAdd(map.Source, points.AsReadOnly()))
                throw new InvalidDataException("Card enemy point inventory differs from source.");
        }
        return new CardUnitInitialPointCatalog(accepted);
    }

    /// <summary>
    /// SpawningManager.GetPoint chooses the nearest free accepted point;
    /// serialized collection order breaks a distance tie.
    /// </summary>
    public CardUnitInitialPoint? Select(RecoveredBattleMap map,
        string sourceCardId, int fraction, Vector3 spawnPosition,
        Func<int, bool> available)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(available);
        if (fraction is not (1 or 2) || !PlayerHitbox.Finite(spawnPosition) ||
            !maps.TryGetValue(map.Source, out var points) ||
            sourceCardId is not ("ELITEPARA" or "ELITESWAT"))
            throw new InvalidDataException("Invalid card initial-point selection.");

        return points.Where(point => point.Fraction == fraction &&
                (sourceCardId == "ELITEPARA"
                    ? point.ComponentType is "EnemyPointCorner" or "EnemyPointHiding"
                    : point.ComponentType == "EnemyPointSwat") &&
                available(point.ComponentFileId))
            .OrderBy(point => Vector3.Distance(point.Position, spawnPosition))
            .ThenBy(point => point.Order)
            .FirstOrDefault();
    }

    private static Vector3 Position(JsonElement values)
    {
        float[] coordinates = values.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        if (coordinates.Length != 3 || coordinates.Any(value =>
            !float.IsFinite(value) || Math.Abs(value) > 10_000))
            throw new InvalidDataException("Card enemy point position is invalid.");
        return new Vector3(coordinates[0], coordinates[1], coordinates[2]);
    }

    private static Quaternion Rotation(JsonElement values)
    {
        float[] coordinates = values.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        if (coordinates.Length != 4 || coordinates.Any(value => !float.IsFinite(value)))
            throw new InvalidDataException("Card enemy point rotation is invalid.");
        var rotation = new Quaternion(coordinates[0], coordinates[1],
            coordinates[2], coordinates[3]);
        if (Math.Abs(rotation.LengthSquared() - 1) > .01f)
            throw new InvalidDataException("Card enemy point rotation is not normalized.");
        return rotation;
    }

    private static void Exact(JsonElement value, params string[] names)
    {
        if (value.ValueKind != JsonValueKind.Object ||
            !value.EnumerateObject().Select(property => property.Name)
                .Order(StringComparer.Ordinal)
                .SequenceEqual(names.Order(StringComparer.Ordinal)))
            throw new InvalidDataException("Card enemy point JSON shape changed.");
    }
}
