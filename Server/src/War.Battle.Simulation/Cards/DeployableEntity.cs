using System.Numerics;

namespace War.BattleServer;

public sealed record DeployableEntity(int EntityId, string OwnerPlayerId, string CardId,
    Vector3 Position, int LifetimeTicks)
{
    public DeployableState State { get; internal set; } = DeployableState.Armed;
    public int RemainingTicks { get; internal set; } = LifetimeTicks;
    public int Charges { get; internal set; } = 1;
    public int CooldownTicks { get; internal set; }
}
