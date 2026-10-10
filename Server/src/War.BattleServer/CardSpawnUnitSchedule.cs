namespace War.BattleServer;

/// <summary>
/// Times the calls made by the recovered CardSpawnUnit coroutine. Each call
/// asks SpawningManager to spawn one unit. The manager's separate 0.3-second
/// wait happens after that unit and does not delay the next card call.
/// </summary>
internal sealed class CardSpawnUnitSchedule
{
    private const ulong ParaDelayTicks = 15; // 0.5 seconds at the 30 Hz host clock.

    private readonly CardSpawnUnitSourceCatalog.Row source;
    private readonly ulong activatedTick;

    internal CardSpawnUnitSchedule(string sourceCardId, ulong activatedTick)
    {
        source = CardSpawnUnitSourceCatalog.Get(sourceCardId);
        if (source.Count == 2 && source.SpawnDelaySeconds > 0 &&
            activatedTick > ulong.MaxValue - ParaDelayTicks)
            throw new InvalidDataException("Unit-card spawn time exceeds the host clock.");

        this.activatedTick = activatedTick;
    }

    internal int Count => source.Count;

    internal ulong DueTick(int unitIndex)
    {
        if (unitIndex < 0 || unitIndex >= source.Count)
            throw new InvalidDataException("Unit-card spawn index exceeds its source count.");

        return activatedTick + (unitIndex == 0 || source.SpawnDelaySeconds == 0
            ? 0UL : ParaDelayTicks);
    }
}
