using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopMapRusherPoints(
    int Stage, string Scene, string SceneSha256,
    IReadOnlyList<CoopPlayerRusherPoints> PlayerPoints);
