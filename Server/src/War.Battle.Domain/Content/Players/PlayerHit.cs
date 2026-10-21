using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record PlayerHit(float Distance, Vector3 Position, string PartPath, float Weight);
