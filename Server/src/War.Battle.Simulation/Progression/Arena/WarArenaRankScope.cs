namespace War.BattleServer;

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
