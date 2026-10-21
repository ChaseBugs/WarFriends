namespace War.BattleServer;

public static class WarArenaRanking
{
    public static IReadOnlyList<WarArenaRank> Order(IEnumerable<WarArenaRank> rows)
    {
        var list=rows?.ToArray()??throw new ArgumentNullException(nameof(rows));
        if(list.Any(x=>!War.Shared.CanonicalGuid.IsCanonical(x.PlayerId)||x.Wins<0||x.Wins>1_000_000))
            throw new InvalidDataException("Invalid Arena ranking row.");
        return list.OrderByDescending(x=>x.Flawless).ThenByDescending(x=>x.Wins)
            .ThenBy(x=>x.PlayerId,StringComparer.Ordinal).ToArray();
    }
}
