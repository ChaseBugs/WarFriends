namespace War.BattleServer;

/// <summary>Identifies one accepted source deployment and its final post-spawn wait.</summary>
public sealed record ArmyDeploymentWave(ulong Id, int OptionIndex, string UnitId, ulong StartedTick)
{
    /// <summary>The final real-time scheduling boundary; completion requires a later scheduling tick.</summary>
    public ulong FinishAfterTick { get; init; }

    /// <summary>Preserves the source behavior-family classification for spawn-event consumers.</summary>
    public bool IsSoldier { get; init; }

    /// <summary>Identifies a real-time coroutine instead of a legacy tick schedule.</summary>
    public float? StartedRealTimeSeconds { get; init; }

    /// <summary>Records actual source completion; absent while its final real-time wait is pending.</summary>
    public float? FinishedRealTimeSeconds { get; init; }

    internal void ValidateClockShape()
    {
        if (StartedRealTimeSeconds is float started)
        {
            if (!float.IsFinite(started) || started < 0f || StartedTick != 0 || FinishAfterTick != 0 ||
                FinishedRealTimeSeconds is float finished && (!float.IsFinite(finished) || finished <= started))
            {
                throw new InvalidDataException("Real-time deployment metadata mixes clock domains or invalid dates.");
            }
        }
        else if (FinishedRealTimeSeconds.HasValue || FinishAfterTick <= StartedTick)
        {
            throw new InvalidDataException("Legacy deployment metadata lost its ordered tick boundaries.");
        }
    }
}
