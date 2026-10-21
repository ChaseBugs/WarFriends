using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyCoopCombatScale(
    float Health, float Damage, float HeroicHealth, float HeroicDamage);
