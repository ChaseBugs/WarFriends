using System.Numerics;

namespace War.BattleServer;

public readonly record struct ProjectileAuthority(ulong ProjectileId, string OwnerPlayerId,
    Vector3 Origin, Vector3 Direction, float Speed, ulong SpawnTick, ulong MaxLifetimeTicks);
