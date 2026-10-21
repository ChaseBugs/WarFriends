using System.Numerics;
using System.Security.Cryptography;

namespace War.BattleServer;

public sealed record PvpBonusSpawnDraw(float WeightedValue, int AreaOrder, Vector3 UnitPosition);
