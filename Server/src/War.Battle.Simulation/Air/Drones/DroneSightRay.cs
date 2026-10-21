using System.Numerics;
namespace War.BattleServer;

public sealed record DroneSightRay(Vector3 Origin,Vector3 Direction,float Range);
