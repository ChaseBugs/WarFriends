using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopRusherPoint(
    int Order, int ComponentFileId, int SourceIndex,
    int GameObjectFileId, int TransformFileId,
    Vector3 Position, Quaternion Rotation);

public sealed record CoopPlayerRusherPoints(
    int PlayerPositionIndex, int PlayerPointComponentFileId,
    IReadOnlyList<CoopRusherPoint> Points);

public sealed record CoopMapRusherPoints(
    int Stage, string Scene, string SceneSha256,
    IReadOnlyList<CoopPlayerRusherPoints> PlayerPoints);

/// <summary>PlayerPoint.rusherPoints, separate from enemyPointsCollection.</summary>
public sealed class CoopRusherPointCatalog
{
    private const string ArtifactSha256 =
        "f9b1c2fa7d2b9b1212ef839408b2490f8433516a8c8db301d39681177c2fa449";

    public IReadOnlyList<CoopMapRusherPoints> Maps { get; }

    private CoopRusherPointCatalog(CoopMapRusherPoints[] maps)
    {
        Maps = new ReadOnlyCollection<CoopMapRusherPoints>(maps);
    }

    public CoopMapRusherPoints MapForMission(
        MissionCatalog missions, int missionIndex)
    {
        MissionMapRule expected = missions.MapForMission(missionIndex);
        CoopMapRusherPoints map = Maps[expected.Stage - 1];
        if (map.Scene != expected.Scene ||
            map.SceneSha256 != expected.SceneSha256)
            throw new InvalidDataException("Rusher points differ from the mission scene.");
        return map;
    }

    public static CoopRusherPointCatalog Load(string path,
        MissionCatalog missions, CoopSpawnPointCatalog spawns)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(spawns);
        byte[] source = File.ReadAllBytes(path);
        if (source.Length is < 20_000 or > 100_000 ||
            Convert.ToHexStringLower(SHA256.HashData(source)) != ArtifactSha256)
            throw new InvalidDataException("Co-op Rusher points differ from source scenes.");
        using JsonDocument document = JsonDocument.Parse(source);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "maps");
        JsonElement entries = root.GetProperty("maps");
        if (root.GetProperty("version").GetInt32() != 1 ||
            entries.ValueKind != JsonValueKind.Array ||
            entries.GetArrayLength() != 5)
            throw new InvalidDataException("Co-op Rusher map inventory changed.");

        var maps = new CoopMapRusherPoints[5];
        for (int mapIndex = 0; mapIndex < maps.Length; mapIndex++)
        {
            JsonElement entry = entries[mapIndex];
            MissionMapRule mission = missions.Maps[mapIndex];
            CoopMapSpawnPoints spawnMap = spawns.Maps[mapIndex];
            RequireFields(entry, "stage", "scene", "sceneSha256",
                "playerPoints");
            if (entry.GetProperty("stage").GetInt32() != mission.Stage ||
                entry.GetProperty("scene").GetString() != mission.Scene ||
                entry.GetProperty("sceneSha256").GetString() !=
                    mission.SceneSha256 ||
                mission.Scene != spawnMap.Scene ||
                mission.SceneSha256 != spawnMap.SceneSha256)
                throw new InvalidDataException("Rusher points do not bind the map.");
            JsonElement players = entry.GetProperty("playerPoints");
            if (players.ValueKind != JsonValueKind.Array ||
                players.GetArrayLength() != 4)
                throw new InvalidDataException("Map needs four Rusher player shields.");
            var groups = new CoopPlayerRusherPoints[4];
            var seenIds = new HashSet<int>();
            for (int playerIndex = 0; playerIndex < groups.Length; playerIndex++)
            {
                JsonElement player = players[playerIndex];
                CoopPlayerAnchor anchor = spawnMap.PlayerPositions[playerIndex];
                RequireFields(player, "playerPositionIndex",
                    "playerPointComponentFileId", "points");
                if (player.GetProperty("playerPositionIndex").GetInt32() !=
                        anchor.Index ||
                    player.GetProperty("playerPointComponentFileId").GetInt32() !=
                        anchor.ComponentFileId)
                    throw new InvalidDataException("Rusher points changed player shield.");
                JsonElement points = player.GetProperty("points");
                if (points.ValueKind != JsonValueKind.Array ||
                    points.GetArrayLength() != 4)
                    throw new InvalidDataException("Player shield needs four Rusher points.");
                var groupPoints = new CoopRusherPoint[4];
                for (int order = 0; order < groupPoints.Length; order++)
                {
                    JsonElement point = points[order];
                    RequireFields(point, "order", "componentFileId",
                        "sourceIndex", "gameObjectFileId", "transformFileId",
                        "worldPosition", "worldRotation");
                    int id = point.GetProperty("componentFileId").GetInt32();
                    if (point.GetProperty("order").GetInt32() != order ||
                        point.GetProperty("sourceIndex").GetInt32() != order ||
                        id <= 0 || !seenIds.Add(id))
                        throw new InvalidDataException("Rusher point identity changed.");
                    groupPoints[order] = new CoopRusherPoint(order, id, order,
                        PositiveId(point, "gameObjectFileId"),
                        PositiveId(point, "transformFileId"),
                        Vector(point.GetProperty("worldPosition")),
                        Rotation(point.GetProperty("worldRotation")));
                }
                groups[playerIndex] = new CoopPlayerRusherPoints(anchor.Index,
                    anchor.ComponentFileId,
                    new ReadOnlyCollection<CoopRusherPoint>(groupPoints));
            }
            maps[mapIndex] = new CoopMapRusherPoints(mission.Stage,
                mission.Scene, mission.SceneSha256,
                new ReadOnlyCollection<CoopPlayerRusherPoints>(groups));
        }
        return new CoopRusherPointCatalog(maps);
    }

    /// <summary>
    /// SoldierBehaviourRusher.GetInitPoint scans the active player's points.
    /// Once a near point (index 0 or 1) wins, a far point cannot displace it.
    /// Counts of four or more use the separate RusherSpare fallback.
    /// </summary>
    public static CoopRusherPoint? ChooseInitial(
        CoopPlayerRusherPoints player, Vector3 soldierPosition,
        IReadOnlySet<int> occupiedPointIds, int rusherCounts)
    {
        ArgumentNullException.ThrowIfNull(player);
        ArgumentNullException.ThrowIfNull(occupiedPointIds);
        if (!PlayerHitbox.Finite(soldierPosition) || rusherCounts < 0)
            throw new ArgumentOutOfRangeException(nameof(rusherCounts));
        if (rusherCounts >= 4)
            return null;

        CoopRusherPoint? selected = null;
        float nearestDistance = float.MaxValue;
        foreach (CoopRusherPoint candidate in player.Points)
        {
            if (occupiedPointIds.Contains(candidate.ComponentFileId))
                continue;
            float distance = Vector3.Distance(soldierPosition,
                candidate.Position);
            if (distance >= nearestDistance)
                continue;
            if (selected == null || selected.SourceIndex > 1 ||
                candidate.SourceIndex <= 1)
            {
                nearestDistance = distance;
                selected = candidate;
            }
        }
        return selected;
    }

    private static int PositiveId(JsonElement entry, string name)
    {
        int value = entry.GetProperty(name).GetInt32();
        if (value <= 0)
            throw new InvalidDataException("Rusher source file ID is invalid.");
        return value;
    }

    private static Vector3 Vector(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Array || value.GetArrayLength() != 3)
            throw new InvalidDataException("Rusher point needs a position.");
        var position = new Vector3(value[0].GetSingle(),
            value[1].GetSingle(), value[2].GetSingle());
        if (!PlayerHitbox.Finite(position) ||
            Vector3.Abs(position).X > 10_000 ||
            Vector3.Abs(position).Y > 10_000 ||
            Vector3.Abs(position).Z > 10_000)
            throw new InvalidDataException("Rusher point is outside the scene.");
        return position;
    }

    private static Quaternion Rotation(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Array || value.GetArrayLength() != 4)
            throw new InvalidDataException("Rusher point needs a rotation.");
        var rotation = new Quaternion(value[0].GetSingle(),
            value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
        if (!float.IsFinite(rotation.LengthSquared()) ||
            Math.Abs(rotation.LengthSquared() - 1f) > 0.0002f)
            throw new InvalidDataException("Invalid Rusher point rotation.");
        return Quaternion.Normalize(rotation);
    }

    private static void RequireFields(JsonElement value, params string[] names)
    {
        if (value.ValueKind != JsonValueKind.Object ||
            value.EnumerateObject().Count() != names.Length ||
            names.Any(name => !value.TryGetProperty(name, out _)))
            throw new InvalidDataException("Unexpected Rusher point fields.");
    }
}
