using System.Numerics;
namespace War.BattleServer;

public sealed record VehicleEntity(ulong EntityId, string UnitId, string OwnerPlayerId, uint Generation)
{
    public System.Numerics.Vector3 Position { get; internal set; }
}
