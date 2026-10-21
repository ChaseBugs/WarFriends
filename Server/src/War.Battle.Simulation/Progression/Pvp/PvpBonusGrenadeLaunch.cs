using System.Numerics;

namespace War.BattleServer;

public sealed record PvpBonusGrenadeLaunch(int ShotIndex, float DelayScaledSeconds,
    string? TargetId, Vector3 Position, PvpBonusGrenadeDamageOverride? DamageOverride);
