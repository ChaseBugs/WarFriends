namespace War.BattleServer;

/// <summary>One source OnInstancied realtime wait; the match world owns the activated native lease.</summary>
internal sealed class HelicopterRopeActivationState
{
    private const float SourceDelaySeconds = 2f;
    private readonly HelicopterRopeDefinition _definition;
    private readonly ulong _entityId;
    private readonly float _finishTime;
    private float _lastRealtime;
    private bool _isCanceled;
    private bool _hasFailed;

    internal HelicopterRopeActivationState(HelicopterRopeDefinition definition, ulong entityId, float spawnRealtime)
    {
        ArgumentNullException.ThrowIfNull(definition);
        ValidateRealtime(spawnRealtime, 0);
        if (entityId == 0)
        {
            throw new InvalidDataException("Rope activation requires a host entity identity.");
        }
        _definition = definition;
        _entityId = entityId;
        // WaitForRealSeconds stores this addition in a float and uses a strict greater-than comparison.
        _finishTime = spawnRealtime + SourceDelaySeconds;
        _lastRealtime = spawnRealtime;
    }

    internal HelicopterPhysicsLease? ActiveLease { get; private set; }

    /// <summary>Call after the world's current render; source RadicalRoutine resumes at WaitForEndOfFrame.</summary>
    internal HelicopterPhysicsLease? TryActivateAfterRender(NativeHelicopterPhysicsWorld world,
        float realtime, HelicopterRopeBodyPose currentAircraft)
    {
        ArgumentNullException.ThrowIfNull(world);
        ValidateRealtime(realtime, _lastRealtime);
        NativeHelicopterRope.ValidateAircraftTransform(currentAircraft);
        if (_hasFailed)
        {
            throw new InvalidOperationException("Failed native rope activation cannot retry an unproven allocation.");
        }
        if (_isCanceled || ActiveLease.HasValue)
        {
            _lastRealtime = realtime;
            return null;
        }
        if (realtime <= _finishTime)
        {
            _lastRealtime = realtime;
            return null;
        }
        try
        {
            HelicopterRopeInitialState initial = _definition.CreateInitial(currentAircraft);
            HelicopterPhysicsLease lease = world.Add(_entityId, initial, currentAircraft,
                _definition.CreationRestRotation);
            ActiveLease = lease;
            _lastRealtime = realtime;
            return lease;
        }
        catch
        {
            _hasFailed = true;
            throw;
        }
    }

    /// <summary>Cancels the pending callback; activated scene removal belongs to its match-world lease owner.</summary>
    internal void CancelPending()
    {
        if (ActiveLease.HasValue)
        {
            throw new InvalidOperationException("An active native rope must be removed through its owning world.");
        }
        _isCanceled = true;
    }

    private static void ValidateRealtime(float realtime, float previous)
    {
        if (!float.IsFinite(realtime) || realtime < previous)
        {
            throw new InvalidDataException("Rope activation requires finite nonnegative monotonic source realtime.");
        }
    }
}
