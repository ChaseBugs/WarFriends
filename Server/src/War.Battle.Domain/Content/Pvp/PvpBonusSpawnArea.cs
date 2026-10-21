using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record PvpBonusSpawnArea(int Order, int ColliderFileId,
    Vector3 BoundsMin, Vector3 BoundsMax);
