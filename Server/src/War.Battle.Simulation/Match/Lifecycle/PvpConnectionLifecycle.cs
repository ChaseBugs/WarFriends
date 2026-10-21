using War.Protocol;

namespace War.BattleServer;

/// <summary>Owns connection admission, readiness and reconnect decisions for one validated match roster.</summary>
internal sealed class PvpConnectionLifecycle
{
    private readonly PvpParticipantConnection[] _participants;
    private readonly ulong _idleTicks;
    private readonly string _manifestHash;

    internal PvpConnectionLifecycle(MatchManifest manifest, string manifestHash)
    {
        _participants = manifest.Players.Select(player => new PvpParticipantConnection(player.PlayerId)).ToArray();
        _idleTicks = (ulong)manifest.IdleSeconds * MatchManifest.TickRate;
        AdmissionDeadline = (ulong)manifest.AdmissionSeconds * MatchManifest.TickRate;
        _manifestHash = manifestHash;
    }

    internal ulong AdmissionDeadline { get; }
    internal bool HasReconnect => _participants.Any(player => player.Reconnecting);

    internal PvpParticipantConnection Participant(string playerId)
    {
        return Find(playerId) ?? throw new InvalidOperationException("Unknown lifecycle participant.");
    }

    internal bool CanAdmit(string playerId, BattlePhase phase, ulong simulationTick)
    {
        return phase == BattlePhase.Waiting && simulationTick < AdmissionDeadline && Find(playerId) != null;
    }

    internal bool TryAdmit(string playerId, BattlePhase phase, ulong simulationTick, ulong hostTick)
    {
        if (!CanAdmit(playerId, phase, simulationTick))
        {
            return false;
        }
        Participant(playerId).Admit(hostTick);
        return true;
    }

    internal bool CanResume(string playerId, bool terminal)
    {
        return !terminal && Find(playerId)?.Admitted == true;
    }

    internal bool Resume(string playerId, bool terminal, ulong hostTick)
    {
        if (!CanResume(playerId, terminal))
        {
            return false;
        }
        Participant(playerId).Resume(hostTick);
        return true;
    }

    internal void ObserveTraffic(string playerId, ulong hostTick)
    {
        Participant(playerId).ObserveTraffic(hostTick);
    }

    internal string Ready(string playerId, BattlePhase phase, string requestedHash, out bool beginCountdown)
    {
        beginCountdown = false;
        if (phase != BattlePhase.Waiting)
        {
            return "wrong-phase";
        }
        if (requestedHash != _manifestHash)
        {
            return "manifest-mismatch";
        }
        PvpParticipantConnection? player = Find(playerId);
        if (player?.Admitted != true)
        {
            return "not-admitted";
        }
        player.MarkReady();
        beginCountdown = _participants.All(participant => participant.Ready && participant.Admitted);
        return "ready";
    }

    internal string PresentationReady(string playerId, BattlePhase phase)
    {
        PvpParticipantConnection? player = Find(playerId);
        if (phase != BattlePhase.Running || player?.Ready != true)
        {
            return "wrong-phase";
        }
        player.MarkPresentationReady();
        return "presentation-ready";
    }

    internal bool HasIdleParticipant(ulong hostTick)
    {
        return _participants.Any(player => hostTick - player.LastSeen >= _idleTicks);
    }

    internal PvpReconnectDecision BeginIdlePause(ulong hostTick)
    {
        PvpParticipantConnection[] idle = _participants
            .Where(player => hostTick - player.LastSeen >= _idleTicks).ToArray();
        if (idle.Length == 0)
        {
            return new(PvpReconnectDisposition.None, "", "");
        }
        if (idle.Length == _participants.Length)
        {
            return new(PvpReconnectDisposition.BothDisconnected, "", "");
        }
        PvpParticipantConnection disconnected = idle[0];
        if (!disconnected.RecordDisconnection())
        {
            string winner = _participants.Single(player => player != disconnected).PlayerId;
            return new(PvpReconnectDisposition.OpponentForfeit, disconnected.PlayerId, winner);
        }
        // The engine must remove owned deployables before ActivateReconnect. If that cleanup
        // throws, only the attempt increment is retained, exactly as in the original engine.
        return new(PvpReconnectDisposition.PauseRequired, disconnected.PlayerId, "");
    }

    internal void ActivateReconnect(string playerId, ulong hostTick)
    {
        Participant(playerId).ActivateReconnect(hostTick);
    }

    internal PvpReconnectDecision CheckGraceExpiry(ulong hostTick)
    {
        PvpParticipantConnection[] expired = _participants.Where(player => player.Reconnecting &&
            hostTick >= player.ReconnectDeadlineHostTick).ToArray();
        if (expired.Length == 0)
        {
            return new(PvpReconnectDisposition.None, "", "");
        }
        PvpParticipantConnection[] active = _participants.Where(player => !player.Reconnecting &&
            hostTick - player.LastSeen < _idleTicks).ToArray();
        if (expired.Length == 1 && active.Length == 1)
        {
            return new(PvpReconnectDisposition.OpponentForfeit, expired[0].PlayerId, active[0].PlayerId);
        }
        // The recovered Client supplies no authoritative reward for a second silent peer.
        // Preserve the existing self-hosted abort policy rather than awarding it a forfeit win.
        return new(PvpReconnectDisposition.BothDisconnected, "", "");
    }

    internal void ClearReconnects()
    {
        foreach (PvpParticipantConnection player in _participants)
        {
            player.ClearReconnect();
        }
    }

    private PvpParticipantConnection? Find(string playerId)
    {
        return _participants.FirstOrDefault(player => player.PlayerId == playerId);
    }
}
