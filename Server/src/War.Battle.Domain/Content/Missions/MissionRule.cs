using System.Collections.ObjectModel;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>A single recovered campaign mission's server-owned configuration.</summary>
public sealed record MissionRule(
    int Index, int Level, int MapStage, string MissionType, int? Objective,
    int TimeSeconds, int ScoreOneStar, int ScoreTwoStars, int ScoreThreeStars,
    int MaxUnitsAtOnce, int RewardWarbucks, int RewardGold, int RewardXp,
    float HealthTargetFraction, float TimeTargetFraction,
    int RecommendedArmyPower,
    IReadOnlyList<MissionSpawnBehaviour> Behaviours,
    IReadOnlyList<MissionTimedEvent> Events,
    string SceneDataSha256);
