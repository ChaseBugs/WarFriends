using War.Protocol;

namespace War.BattleServer;

/// <summary>Recovered MatchStats outcome fields, without rank or reward policy.</summary>
public sealed record BattleOutcomeMatchStats(string PlayerId,string GameEndReason,
    int BattlesWon,int BattlesLost,int BattlesLostInRowDelta);

public static class BattleOutcomeStatsProjection
{
    public static IReadOnlyList<BattleOutcomeMatchStats> FromPayload(byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=TerminalOutbox.ValidatePayload(payload,matchId,digest);
        if(terminal.Phase!=BattlePhase.Ended)
            throw new InvalidDataException("Aborted battle has no source win/loss statistics.");
        bool forfeit=terminal.TerminalReason is "forfeit" or "opponent-disconnected";
        if(!forfeit && terminal.TerminalReason!="player-killed")
            throw new InvalidDataException("Battle terminal reason has no recovered win/loss mapping.");
        return terminal.Players.Select(player=>player.PlayerId==terminal.WinnerPlayerId
            ?new BattleOutcomeMatchStats(player.PlayerId,forfeit?"WinByForfeit":"Win",1,0,-1)
            :new BattleOutcomeMatchStats(player.PlayerId,forfeit?"Forfeit":"Killed",0,1,1)).ToArray();
    }
}
