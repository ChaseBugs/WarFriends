using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal sealed record CoopObstaclePoseClock(ulong ElapsedTick,
    IReadOnlyList<ulong> EmittedRoundTicks, ulong? CrawlReturnTick = null,
    CoopObstaclePreparationPhase PreparationPhase = CoopObstaclePreparationPhase.GameplayUpdate);
