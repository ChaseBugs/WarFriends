using System.Collections.ObjectModel;
using System.Text.Json;

namespace War.BattleServer;

public sealed record MissionSpawnBehaviour(
    string Name, int Level, int SceneLimit, int MissionLimit);
