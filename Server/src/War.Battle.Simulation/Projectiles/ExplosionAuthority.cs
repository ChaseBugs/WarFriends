using System.Numerics;

namespace War.BattleServer;

public readonly record struct ExplosionAuthority(ulong EntityId, string OwnerPlayerId,
    Vector3 Origin, float Radius, float Damage, int PelletCount);
