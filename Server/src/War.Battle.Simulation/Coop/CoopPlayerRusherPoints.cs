using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopPlayerRusherPoints(
    int PlayerPositionIndex, int PlayerPointComponentFileId,
    IReadOnlyList<CoopRusherPoint> Points);
