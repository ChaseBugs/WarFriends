using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

// Upgrade data only: prefab, muzzle, critical multiplier and projectile settings
// still require a scene binding. This is deliberately not a live weapon factory.
public sealed record RifleStage(string SourceId, int Index, int ClipSize, int ReserveAmmo,
    float ReloadSeconds, float Damage, float CadenceSeconds, float CriticalProbability,
    float PlayerDamageRatio, float OvertimePlayerDamageRatio);
