using System.Numerics;
namespace War.BattleServer;

public sealed record DroneTargetCandidate(string Id,int Fraction,bool Alive,bool Visible,
    bool IsDecoy,int? UnitType,Vector3 Position);
