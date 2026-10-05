using System.Collections.ObjectModel;
using War.Protocol;

namespace War.BattleServer;

/// <summary>The source MatchStats card fields derivable from validated terminal evidence.</summary>
public sealed record BattleCardMatchStats(string PlayerId,int CardsPlayed,
    IReadOnlyDictionary<string,int> CardsPlayedSeparately);

public static class BattleCardStatsProjection
{
    public static IReadOnlyList<BattleCardMatchStats> FromPayload(byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=TerminalOutbox.ValidatePayload(payload,matchId,digest);
        return terminal.Players.Select(player=>
        {
            var bySource=new Dictionary<string,int>(StringComparer.Ordinal);
            foreach(var usage in terminal.CardUsage.Where(row=>row.OwnerPlayerId==player.PlayerId))
            {
                if(!bySource.TryAdd(usage.SourceCardId,checked((int)usage.Count)))
                    throw new InvalidDataException("Source card identity repeated in terminal statistics.");
            }
            return new BattleCardMatchStats(player.PlayerId,checked((int)player.ConfirmedCardsPlayed),
                new ReadOnlyDictionary<string,int>(bySource));
        }).ToArray();
    }
}
