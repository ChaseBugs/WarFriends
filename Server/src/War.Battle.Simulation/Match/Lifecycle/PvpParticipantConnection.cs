namespace War.BattleServer;

/// <summary>Owns one participant's connection flags; callers cannot assign them independently.</summary>
internal sealed class PvpParticipantConnection
{
    private const uint MaximumReconnectAttempts = 3;

    internal PvpParticipantConnection(string playerId)
    {
        PlayerId = playerId;
    }

    internal string PlayerId { get; }
    internal bool Admitted { get; private set; }
    internal bool Ready { get; private set; }
    internal bool PresentationReady { get; private set; }
    internal ulong LastSeen { get; private set; }
    internal bool Reconnecting { get; private set; }
    internal uint ReconnectAttempts { get; private set; }
    internal ulong ReconnectDeadlineHostTick { get; private set; }

    internal void Admit(ulong hostTick)
    {
        Admitted = true;
        ObserveTraffic(hostTick);
    }

    internal void ObserveTraffic(ulong hostTick)
    {
        // Polls and exact command replays refresh presence, even while paused or terminal.
        // Presence alone must never clear a reconnect pause; only Resume does that.
        LastSeen = hostTick;
    }

    internal void Resume(ulong hostTick)
    {
        ObserveTraffic(hostTick);
        ClearReconnect();
    }

    internal void MarkReady()
    {
        Ready = true;
    }

    internal void MarkPresentationReady()
    {
        PresentationReady = true;
    }

    internal bool RecordDisconnection()
    {
        // GameControllerOnline.CheckIfDisconnected3rdTime forfeits only when count > 3.
        ReconnectAttempts++;
        return ReconnectAttempts <= MaximumReconnectAttempts;
    }

    internal void ActivateReconnect(ulong hostTick)
    {
        // MatchManager.mReconnectTimes is 30, 20, 10 seconds. Keep host time distinct
        // from the paused simulation tick and retain the attempt count after Resume.
        uint graceSeconds = ReconnectAttempts switch { 1 => 30, 2 => 20, _ => 10 };
        Reconnecting = true;
        ReconnectDeadlineHostTick = hostTick + graceSeconds * MatchManifest.TickRate;
    }

    internal void ClearReconnect()
    {
        Reconnecting = false;
        ReconnectDeadlineHostTick = 0;
    }
}
