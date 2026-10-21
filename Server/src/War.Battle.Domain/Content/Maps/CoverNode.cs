using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoverNode(int SourceIndex, int Fraction, bool Main, Vector3 Position, Vector3 ShotPosition, float ShieldBaseHealth,Quaternion Rotation,string SourcePath);
