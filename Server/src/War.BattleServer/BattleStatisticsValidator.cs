namespace War.BattleServer;

public readonly record struct BattleStatistics(uint Hits,uint Kills,uint ArmySpawns,uint ArmyLosses);

public static class BattleStatisticsValidator
{
    public static void Validate(BattleStatistics stats)
    {
        if(stats.Kills>stats.Hits||stats.ArmyLosses>stats.ArmySpawns||
           stats.Hits>1_000_000||stats.Kills>1_000_000||stats.ArmySpawns>100_000||stats.ArmyLosses>100_000)
            throw new InvalidDataException("Inconsistent battle statistics.");
    }
}
