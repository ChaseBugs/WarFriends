namespace War.BattleServer;

// Server simulation input only. Never deserialize this from a player packet.
internal sealed record ResolvedPlayerDamage(float Amount, CombatDamageType Type,
    float PartWeight = 1, bool HasWeapon = true, bool FriendKill = false,
    float FriendlyCoefficient = 1, float PlayerCoefficient = 1,
    float PlayerOvertimeCoefficient = 1, float ExplosiveCoefficient = 1,
    float ExplosiveOvertimeCoefficient = 1, bool Overtime = false,
    bool IgnoreImmortality = false);
