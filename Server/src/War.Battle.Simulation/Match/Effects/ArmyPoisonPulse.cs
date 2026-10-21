using System.Numerics;

namespace War.BattleServer;

/// <summary>Detached poison observation after consuming a due pulse and before its world effects.</summary>
internal readonly record struct ArmyPoisonPulse(
    ArmyPoisonSource Source, float DamagePerPulse, Vector3 Position, int Remaining);
