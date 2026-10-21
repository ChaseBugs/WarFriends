using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBossAttackTiming(
    int MissionIndex, int SourceDifficulty, int PlayerBotsRow, int ConfigIndex,
    string PrimaryCategory, string SecondaryCategory,
    string ExplosiveCategory, string PistolCategory,
    float ShootFrequencyMinSeconds, float ShootFrequencyMaxSeconds,
    float ShootingLengthMinSeconds, float ShootingLengthMaxSeconds,
    float ShootAccuracy, float ExplosiveSwitchProbability,
    float OpponentShotProbability, float OpponentWithoutShieldProbability,
    float WalkingOpponentShotProbability, float HeadshotProbability,
    float OpponentOffense,
    float OpponentOffenseReactionSeconds);
