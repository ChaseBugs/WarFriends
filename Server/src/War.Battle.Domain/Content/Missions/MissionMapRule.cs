using System.Collections.ObjectModel;
using System.Text.Json;

namespace War.BattleServer;

public sealed record MissionMapRule(
    int Stage, string Name, string Scene, string SceneSha256);
