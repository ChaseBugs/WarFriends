namespace War.BattleServer;

public readonly record struct WarArenaRank(string PlayerId,int Wins,bool Flawless);
public readonly record struct WarArenaRankRow(string EventId,WarArenaRank Rank);

public static class WarArenaRanking
{
    public static IReadOnlyList<WarArenaRank> Order(IEnumerable<WarArenaRank> rows)
    {
        var list=rows?.ToArray()??throw new ArgumentNullException(nameof(rows));
        if(list.Any(x=>!Guid.TryParseExact(x.PlayerId,"N",out _)||x.Wins<0||x.Wins>1_000_000))
            throw new InvalidDataException("Invalid Arena ranking row.");
        return list.OrderByDescending(x=>x.Flawless).ThenByDescending(x=>x.Wins)
            .ThenBy(x=>x.PlayerId,StringComparer.Ordinal).ToArray();
    }
}

public static class WarArenaRankScope
{
    public static IReadOnlyList<WarArenaRank> Current(string eventId,IEnumerable<WarArenaRankRow> rows)
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(eventId??"",@"\Aarena-[0-9]{6,16}\z"))
            throw new InvalidDataException("Invalid Arena ranking event.");
        var selected=(rows??throw new ArgumentNullException(nameof(rows))).Where(x=>x.EventId==eventId).Select(x=>x.Rank).ToArray();
        if(selected.Length==0)return [];
        return WarArenaRanking.Order(selected);
    }
}
