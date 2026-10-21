namespace War.Persistence.Battles.Settlement;

/// <summary>Only economy/progression fields owned by ordinary battle settlement may be published.</summary>
public sealed record BattleSettlementPlayerChange
{
    public required string PlayerId { get; init; }
    public required long Gold { get; init; }
    public required long WarBucks { get; init; }
    public required int Level { get; init; }
    public required int LevelExperience { get; init; }
    public required long Experience { get; init; }
    public required int ArmyPower { get; init; }
    public required int Skill { get; init; }
    public required int MedalsBalance { get; init; }
    public required int PlacementMatchesRequired { get; init; }
    public required int BattlesLostInRow { get; init; }
    public required string WinStreakJson { get; init; }
    public required string ResponseJson { get; init; }
}
