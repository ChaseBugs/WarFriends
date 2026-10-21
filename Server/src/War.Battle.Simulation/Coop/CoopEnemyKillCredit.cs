using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public enum CoopEnemyKillCredit
{
    Player,
    AlliedArmy,
    UnownedBasicDamage,
    UnownedExplosion
}
