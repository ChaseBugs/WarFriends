using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal enum CoopObstaclePreparationPhase
{
    GameplayUpdate,
    EditorCallback
}
