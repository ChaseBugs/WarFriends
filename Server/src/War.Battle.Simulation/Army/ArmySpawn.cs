namespace War.BattleServer;

/// <summary>Records a realized unit and its deployment scheduling-clock tick.</summary>
public sealed record ArmySpawn(int EntityId,int OptionIndex,string UnitId,int Power,ulong Tick,bool IsAir)
{
    /// <summary>Records an actual real-time iteration; Tick is then the supplied gameplay-frame timestamp.</summary>
    public float? RealTimeSeconds { get; init; }
}
