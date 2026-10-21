using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyCardBaseStats(CardSpawnUnitSourceCatalog.Row Source,
    float Progress,ArmyBaseCombatStats Combat,ArmyBaseShotStats Shot,
    ArmyGrenadeDamageStats? Grenade, ArmyCardDroneRuntime? Drone,
    ArmyCardRocketRuntime? Rocket, ArmyCardGrenadierRuntime? Grenadier);
