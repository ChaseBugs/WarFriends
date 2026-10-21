using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopMapSpawnPoints
{
    public int Stage { get; }
    public string Scene { get; }
    public string SceneSha256 { get; }
    public int MapDefinitionFileId { get; }
    public IReadOnlyList<CoopPlayerAnchor> PlayerPositions { get; }
    public IReadOnlyList<CoopSpawnPoint> SpawnPoints { get; }
    public IReadOnlyList<CoopSpawnPoint> EnemySpawnPoints { get; }

    internal CoopMapSpawnPoints(int stage, string scene, string sceneSha256,
        int mapDefinitionFileId, CoopPlayerAnchor[] players, CoopSpawnPoint[] spawns)
    {
        Stage = stage;
        Scene = scene;
        SceneSha256 = sceneSha256;
        MapDefinitionFileId = mapDefinitionFileId;
        PlayerPositions = new ReadOnlyCollection<CoopPlayerAnchor>(players);
        SpawnPoints = new ReadOnlyCollection<CoopSpawnPoint>(spawns);
        EnemySpawnPoints = new ReadOnlyCollection<CoopSpawnPoint>(
            spawns.Where(point => point.Fraction == 1).ToArray());
    }
}
