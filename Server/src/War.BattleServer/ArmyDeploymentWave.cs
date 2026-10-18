namespace War.BattleServer;

/// <summary>Identifies one accepted source deployment and its final post-spawn wait.</summary>
public sealed record ArmyDeploymentWave(ulong Id, int OptionIndex, string UnitId, ulong StartedTick)
{
    /// <summary>The final wait boundary; source completion requires a later host tick.</summary>
    public ulong FinishAfterTick { get; init; }

    /// <summary>Preserves the source behavior-family classification for spawn-event consumers.</summary>
    public bool IsSoldier { get; init; }
}
