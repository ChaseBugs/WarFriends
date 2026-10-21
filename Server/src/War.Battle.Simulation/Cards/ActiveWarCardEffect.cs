using System.Numerics;

namespace War.BattleServer;

public sealed record ActiveWarCardEffect(string EffectId, string OwnerPlayerId,
    WarCardEffectDefinition Definition, Vector3 Target, ulong StartedTick, WarCardEffectLease Lease);
