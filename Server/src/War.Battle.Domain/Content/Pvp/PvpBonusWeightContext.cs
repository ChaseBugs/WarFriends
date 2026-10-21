using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Host-established source perspective, never a Client probability request.</summary>
public sealed record PvpBonusWeightContext(bool IsWarArena, bool IsFriendlyDeathMatch,
    int LocalDisplayLevel, int OwnerLevelIndex, int GoldBonusesCollected,
    bool FirstTwoWeaponsHaveLowAmmo);
