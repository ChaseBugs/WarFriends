using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopBossMapAnchors
{
    public int Stage { get; }
    public string Scene { get; }
    public string SceneSha256 { get; }
    public int MapDefinitionFileId { get; }
    public IReadOnlyList<CoopBossAnchor> PlayerPositions { get; }

    // BotMission.GetMainPlayerPoint returns the first matching main point.
    public CoopBossAnchor BossStart => PlayerPositions[1];
    public IReadOnlyList<CoopBossAnchor> AlliedStarts =>
        new ReadOnlyCollection<CoopBossAnchor>(
            [PlayerPositions[5], PlayerPositions[6]]);

    internal CoopBossMapAnchors(int stage, string scene, string sceneHash,
        int mapDefinitionFileId, CoopBossAnchor[] positions)
    {
        Stage = stage;
        Scene = scene;
        SceneSha256 = sceneHash;
        MapDefinitionFileId = mapDefinitionFileId;
        PlayerPositions = new ReadOnlyCollection<CoopBossAnchor>(positions);
    }
}
