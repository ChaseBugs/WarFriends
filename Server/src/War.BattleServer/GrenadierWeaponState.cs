namespace War.BattleServer;

/// <summary>Retains source weapon selection and independent half-second return callbacks.</summary>
internal sealed class GrenadierWeaponState
{
    private const ulong ReturnDelayTicks = 15;
    private readonly HashSet<ulong> _secondaryActors = [];
    private readonly List<PendingReturn> _pendingReturns = [];

    /// <summary>Indicates whether the host must advance source return callbacks.</summary>
    public bool HasPendingReturns => _pendingReturns.Count > 0;

    /// <summary>Reads the inventory actually held, including changes during attack windup.</summary>
    public bool IsSecondary(ulong entityKey)
    {
        return _secondaryActors.Contains(entityKey);
    }

    /// <summary>Applies a successful secondary selection; failed draws leave the inventory unchanged.</summary>
    public void SelectSecondary(ulong entityKey)
    {
        _secondaryActors.Add(entityKey);
    }

    /// <summary>Schedules one callback for each secondary shot, rather than replacing an older timer.</summary>
    public void ScheduleReturn(ulong entityKey, ulong shotTick)
    {
        ulong dueTick = checked(shotTick + ReturnDelayTicks);
        _pendingReturns.Add(new PendingReturn(entityKey, dueTick));
    }

    /// <summary>Executes due callbacks after shooting, preserving the source Update/coroutine order.</summary>
    public void Advance(ulong currentTick, Func<ulong, bool> isLiveGrenadier)
    {
        PendingReturn[] due = _pendingReturns.Where(callback => callback.DueTick <= currentTick)
            .OrderBy(callback => callback.DueTick).ThenBy(callback => callback.EntityKey).ToArray();
        foreach (PendingReturn callback in due)
        {
            if (!isLiveGrenadier(callback.EntityKey))
            {
                throw new InvalidDataException("Grenadier weapon callback lost its live actor.");
            }
        }

        foreach (PendingReturn callback in due)
        {
            _secondaryActors.Remove(callback.EntityKey);
            _pendingReturns.Remove(callback);
        }
    }

    /// <summary>Cancels selection and all callbacks when the authoritative actor is removed.</summary>
    public void Remove(ulong entityKey)
    {
        _secondaryActors.Remove(entityKey);
        _pendingReturns.RemoveAll(callback => callback.EntityKey == entityKey);
    }

    private sealed record PendingReturn(ulong EntityKey, ulong DueTick);
}
