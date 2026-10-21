namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private bool TryPauseForIdleParticipant()
    {
        PvpReconnectDecision decision = _connections.BeginIdlePause(hostTick);
        switch (decision.Disposition)
        {
            case PvpReconnectDisposition.None:
                return false;
            case PvpReconnectDisposition.BothDisconnected:
                End("both-disconnected", "", false);
                return true;
            case PvpReconnectDisposition.OpponentForfeit:
                End("opponent-disconnected", decision.WinnerPlayerId, true);
                return true;
            case PvpReconnectDisposition.PauseRequired:
                // Preserve failure order: attempt recorded, cleanup, then visible pause/deadline.
                RemoveOwnedDeployables(decision.DisconnectedPlayerId);
                _connections.ActivateReconnect(decision.DisconnectedPlayerId, hostTick);
                stateRevision++;
                return true;
            default:
                throw new InvalidOperationException("Unsupported reconnect decision.");
        }
    }

    private void ResolveReconnectExpiry()
    {
        PvpReconnectDecision decision = _connections.CheckGraceExpiry(hostTick);
        switch (decision.Disposition)
        {
            case PvpReconnectDisposition.None:
                return;
            case PvpReconnectDisposition.OpponentForfeit:
                End("opponent-disconnected", decision.WinnerPlayerId, true);
                return;
            case PvpReconnectDisposition.BothDisconnected:
                End("both-disconnected", "", false);
                return;
            default:
                throw new InvalidOperationException("Unsupported reconnect expiry decision.");
        }
    }
}
