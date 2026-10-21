namespace War.Backend.Features.Battle.Settlement;

/// <summary>Server-owned rank counters captured inside the settlement transaction.</summary>
public sealed record BattleRankSnapshot(int Level, int LevelExperience, long Experience);
