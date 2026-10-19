namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private CoopTransportRopeWorld? _transportRopes;
    private readonly Dictionary<ulong, float> _transportSpawnRealtime = new();
    private ulong _lastTransportRenderTick;

    internal bool HasNativeTransportRopes => _transportRopes != null;
    internal HelicopterPhysicsWorldSnapshot? TransportRopeSnapshot => _transportRopes?.Snapshot();

    /// <summary>Enables native scene ownership before admission; no approximate solver fallback is allowed.</summary>
    internal void EnableTransportRopes()
    {
        if (Terminal || tick != 0 || participants.Values.Any(player => player.Admitted) || _transportRopes != null ||
            _transportLandingNavigation == null || _transportRopeDefinition == null || _transportCrewPoolFrame == null)
        {
            throw new InvalidOperationException("Native transport ropes require pre-admission source binding.");
        }
        _transportRopes = new CoopTransportRopeWorld(_transportRopeDefinition);
    }

    internal HelicopterPhysicsWorldSnapshot? RenderTransportRopes(float scaledDeltaTime,
        HelicopterPhysicsMode mode = HelicopterPhysicsMode.Normal)
    {
        if (Terminal)
        {
            return null;
        }
        if (_transportRopes == null || tick != _lastTransportRenderTick + 1)
        {
            throw new InvalidOperationException("Native transport rendering requires one newly completed host tick.");
        }
        try
        {
            var members = transportHelicopterFlights.OrderBy(entry => entry.Key).Select(entry =>
                new TransportRopeMember(entry.Key, _transportSpawnRealtime[entry.Key],
                    new HelicopterRopeBodyPose(entry.Value.Position,
                        transportHelicopterOrientations[entry.Key].Rotation),
                    TransportLandingFor(entry.Key))).ToArray();
            HelicopterPhysicsWorldSnapshot snapshot = _transportRopes.Render(
                (float)ObservedRealTimeSeconds, scaledDeltaTime, mode, members);
            CaptureTransportCrewDrops(snapshot);
            _lastTransportRenderTick = tick;
            return snapshot;
        }
        catch
        {
            AbortForHostShutdown();
            throw;
        }
    }

    /// <summary>Aborts an unfinished runtime and releases all owned native scenes.</summary>
    public void Dispose()
    {
        AbortForHostShutdown();
    }

    private void RequireTransportFrameBoundary(ulong nextTick)
    {
        if (_transportRopes != null && nextTick > tick &&
            (_lastTransportRenderTick != tick || nextTick != tick + 1))
        {
            throw new InvalidOperationException(
                "Native transport physics requires explicit frames instead of catch-up ticks.");
        }
    }

}
