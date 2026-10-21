using System.Numerics;
using System.Security.Cryptography;

namespace War.BattleServer;

public sealed record PvpBonusSpawnContext(bool IsWarArena, bool IsFriendlyDeathMatch,
    int GoldBonusesCollected, bool FirstTwoWeaponsHaveLowAmmo);
