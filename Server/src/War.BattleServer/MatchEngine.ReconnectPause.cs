namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private bool TryPauseForIdleParticipant()
    {
        var idle = players.Where(player => hostTick - player.LastSeen >=
            (ulong)manifest.IdleSeconds * MatchManifest.TickRate).ToArray();
        if (idle.Length == 0)
        {
            return false;
        }
        if (idle.Length == 2)
        {
            End("both-disconnected", "", false);
            return true;
        }
        Player disconnected = idle[0];
        disconnected.ReconnectAttempts++;
        if (disconnected.ReconnectAttempts > 3)
        {
            End("opponent-disconnected", players.Single(player => player != disconnected).Definition.PlayerId, true);
            return true;
        }
        RemoveOwnedDeployables(disconnected.Definition.PlayerId);
        disconnected.Reconnecting = true;
        uint graceSeconds = disconnected.ReconnectAttempts switch { 1 => 30, 2 => 20, _ => 10 };
        disconnected.ReconnectDeadlineHostTick = hostTick + graceSeconds * MatchManifest.TickRate;
        stateRevision++;
        return true;
    }
}
